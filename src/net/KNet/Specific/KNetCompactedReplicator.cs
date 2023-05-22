/*
*  Copyright 2023 MASES s.r.l.
*
*  Licensed under the Apache License, Version 2.0 (the "License");
*  you may not use this file except in compliance with the License.
*  You may obtain a copy of the License at
*
*  http://www.apache.org/licenses/LICENSE-2.0
*
*  Unless required by applicable law or agreed to in writing, software
*  distributed under the License is distributed on an "AS IS" BASIS,
*  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
*  See the License for the specific language governing permissions and
*  limitations under the License.
*
*  Refer to LICENSE for more information.
*/

using Java.Util;
using MASES.JCOBridge.C2JBridge;
using MASES.KNet.Clients.Admin;
using MASES.KNet.Clients.Consumer;
using MASES.KNet.Clients.Producer;
using MASES.KNet.Common;
using MASES.KNet.Common.Config;
using MASES.KNet.Common.Errors;
using MASES.KNet.Common.Header;
using MASES.KNet.Extensions;
using MASES.KNet.Serialization;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace MASES.KNet
{
    /// <summary>
    /// Provides a reliable dictionary, persisted in a COMPACTED Kafka topic and shared among applications
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the dictionary. Must be a nullable type</typeparam>
    public class KNetCompactedReplicator<TKey, TValue> :
        IDictionary<TKey, TValue>,
        IDisposable
        where TValue : class
    {
        #region AccessRights
        /// <summary>
        /// Access rights to data
        /// </summary>
        [Flags]
        public enum AccessRights
        {
            /// <summary>
            /// Data are readable, i.e. aligned with the REMOTE dictionary and accessible from the LOCAL dictionary
            /// </summary>
            Read = 1,
            /// <summary>
            /// Data are writable, i.e. updates can be produced, but the LOCAL dictionary is not accessible and not aligned with the REMOTE
            /// </summary>
            Write = 2,
            /// <summary>
            /// Data are readable and writable, i.e. updates can be produced, and data are aligned with the REMOTE dictionary and accessible from the LOCAL dictionary
            /// </summary>
            ReadWrite = Read | Write,
        }

        #endregion


        #region Private members

        private IAdmin _admin = null;
        private ConcurrentDictionary<TKey, TValue> _dictionary = new ConcurrentDictionary<TKey, TValue>();
        private ConsumerRebalanceListener _consumerListener = null;
        private KNetConsumer<TKey, TValue> _consumer = null;
        private KNetProducer<TKey, TValue> _producer = null;
        private string _bootstrapServers = null;
        private string _stateName = string.Empty;
        private int _partitions = 1;
        private short _replicationFactor = 1;
        private TopicConfigBuilder _topicConfig = null;
        private ConsumerConfigBuilder _consumerConfig = null;
        private ProducerConfigBuilder _producerConfig = null;
        private AccessRights _accessrights = AccessRights.ReadWrite;
        private readonly ManualResetEvent _assignmentWaiter = new ManualResetEvent(false);

        private KNetSerDes<TKey> _keySerDes = null;
        private KNetSerDes<TValue> _valueSerDes = null;

        private bool _started = false;

        #endregion

        #region Events

        /// <summary>
        /// Called when a [<typeparamref name="TKey"/>, <typeparamref name="TValue"/>] is updated by consuming data from the REMOTE dictionary
        /// </summary>
        public Action<object, KeyValuePair<TKey, TValue>> OnRemoteUpdate;

        /// <summary>
        /// Called when a <typeparamref name="TKey"/> is removed by consuming data from the REMOTE dictionary
        /// </summary>
        public Action<object, TKey> OnRemoteRemove;

        /// <summary>
        /// Called when a <typeparamref name="TKey"/> is removed from the LOCAL dictionary due to time to live expiration
        /// </summary>
        public event Action<object, TKey> OnLocalRemove;

        #endregion

        #region Public Properties

        public string BootstrapServers { get { return _bootstrapServers; } set { CheckStarted(); _bootstrapServers = value; } }

        public string StateName { get { return _stateName; } set { CheckStarted(); _stateName = value; } }

        public int Partitions { get { return _partitions; } set { CheckStarted(); _partitions = value; } }

        public short ReplicationFactor { get { return _replicationFactor; } set { CheckStarted(); _replicationFactor = value; } }

        public TopicConfigBuilder TopicConfig { get { return _topicConfig; } set { CheckStarted(); _topicConfig = value; } }

        public ConsumerConfigBuilder ConsumerConfig { get { return _consumerConfig; } set { CheckStarted(); _consumerConfig = value; } }

        public ProducerConfigBuilder ProducerConfig { get { return _producerConfig; } set { CheckStarted(); _producerConfig = value; } }

        public KNetSerDes<TKey> KeySerDes { get { return _keySerDes; } set { CheckStarted(); _keySerDes = value; } }

        public KNetSerDes<TValue> ValueSerDes { get { return _valueSerDes; } set { CheckStarted(); _valueSerDes = value; } }

        #endregion

        #region Private methods

        void CheckStarted()
        {
            if (_started) throw new InvalidOperationException("Cannot be changed after Start");
        }

        //private void OnMessage(
        //    object sender,
        //    ConsumeResult<TKey, TValue> message)
        //{
        //    if (message?.Message == null)
        //        return;

        //    if (message.Message.Value == null)
        //    {
        //        _dictionary.TryRemove(message.Message.Key, out _);
        //        OnRemoteRemove?.Invoke(this, message.Message.Key);
        //    }
        //    else
        //    {
        //        _dictionary[message.Message.Key] = message.Message.Value;
        //        OnRemoteUpdate?.Invoke(this, new KeyValuePair<TKey, TValue>(message.Message.Key, message.Message.Value));
        //    }
        //}

        private void OnPartitionsAssigned(Collection<TopicPartition> topicPartitions)
        {
            _assignmentWaiter?.Set();
        }

        private void OnPartitionsRevoked(Collection<TopicPartition> topicPartitionOffsets)
        {
            _assignmentWaiter?.Set();
        }

        private void RemoveRecord(TKey key)
        {
            ValidateAccessRights(AccessRights.Write);

            if (key == null)
                throw new ArgumentNullException(nameof(key));

            JVMBridgeException exception = null;

            DateTime pTimestamp = DateTime.MaxValue;
            using (AutoResetEvent deliverySemaphore = new AutoResetEvent(false))
            {
                _producer.Produce(new KNetProducerRecord<TKey, TValue>(_stateName, key, null), (record, error) =>
                {
                    try
                    {
                        if (deliverySemaphore.SafeWaitHandle.IsClosed)
                            return;

                        exception = error;

                        deliverySemaphore.Set();
                    }
                    catch { }
                });

                deliverySemaphore.WaitOne();
            }

            if (exception != null) throw exception;
            _dictionary.TryRemove(key, out _);
        }

        private void AddOrUpdate(TKey key, TValue value)
        {
            ValidateAccessRights(AccessRights.Write);

            if (key == null)
                throw new ArgumentNullException(nameof(key));

            JVMBridgeException exception = null;

            DateTime pTimestamp = DateTime.MaxValue;
            using (AutoResetEvent deliverySemaphore = new AutoResetEvent(false))
            {
                _producer.Produce(_stateName, key, value, (record, error) =>
                {
                    try
                    {
                        if (deliverySemaphore.SafeWaitHandle.IsClosed)
                            return;

                        exception = error;

                        deliverySemaphore.Set();
                    }
                    catch { }
                });

                deliverySemaphore.WaitOne();
            }

            if (exception != null) throw exception;

            if (value == null)
            {
                _dictionary.TryRemove(key, out _);
            }
            else
            {
                _dictionary[key] = value;
            }
        }

        private void ValidateAccessRights(AccessRights rights)
        {
            if (!_accessrights.HasFlag(rights))
                throw new InvalidOperationException($"{rights} access flag not set");
        }

        private ConcurrentDictionary<TKey, TValue> ValidateAndGetLocalDictionary()
        {
            ValidateAccessRights(AccessRights.Read);
            return _dictionary;
        }

        #endregion

        #region Public methods

        public void Start()
        {
            if (string.IsNullOrWhiteSpace(_bootstrapServers)) throw new InvalidOperationException("BootstrapServers must be set before start.");
            if (string.IsNullOrWhiteSpace(_stateName)) throw new InvalidOperationException("StateName must be set before start.");

            Properties props = AdminClientConfigBuilder.Create().WithBootstrapServers(_bootstrapServers).ToProperties();
            _admin = KafkaAdminClient.Create(props);

            if (_accessrights.HasFlag(AccessRights.Write))
            {
                var topic = new NewTopic(_stateName, _partitions, _replicationFactor);
                _topicConfig ??= TopicConfigBuilder.Create().WithDeleteRetentionMs(100)
                                                            .WithMinCleanableDirtyRatio(0.01)
                                                            .WithSegmentMs(100);

                _topicConfig.CleanupPolicy = MASES.KNet.Common.Config.TopicConfig.CleanupPolicy.Compact | MASES.KNet.Common.Config.TopicConfig.CleanupPolicy.Delete;
                topic = topic.Configs(_topicConfig);
                try
                {
                    _admin.CreateTopic(topic);
                }
                catch (TopicExistsException)
                {
                }
            }

            if (_accessrights.HasFlag(AccessRights.Read))
            {
                _consumerConfig ??= ConsumerConfigBuilder.Create().WithEnableAutoCommit(true)
                                                                  .WithAutoOffsetReset(Clients.Consumer.ConsumerConfig.AutoOffsetReset.EARLIEST)
                                                                  .WithAllowAutoCreateTopics(false);

                _consumerConfig.BootstrapServers = _bootstrapServers;
                _consumerConfig.GroupId = Guid.NewGuid().ToString();
                if (_consumerConfig.CanApplyBasicDeserializer<TKey>() && KeySerDes == null)
                {
                    KeySerDes = new KNetSerDes<TKey>();
                }
                
                if (KeySerDes == null) throw new InvalidOperationException($"{typeof(TKey)} needs an external deserializer, set KeySerDes.");

                if (_consumerConfig.CanApplyBasicDeserializer<TValue>() && ValueSerDes == null)
                {
                    ValueSerDes = new KNetSerDes<TValue>();
                }
                
                if (ValueSerDes == null) throw new InvalidOperationException($"{typeof(TValue)} needs an external deserializer, set ValueSerDes.");

                _consumer = new KNetConsumer<TKey, TValue>(_consumerConfig, KeySerDes, ValueSerDes);
                _consumerListener = new ConsumerRebalanceListener(OnPartitionsRevoked, OnPartitionsAssigned);
            }

            if (_accessrights.HasFlag(AccessRights.Write))
            {
                _producerConfig ??= ProducerConfigBuilder.Create().WithAcks(Clients.Producer.ProducerConfig.Acks.All)
                                                                  .WithRetries(0)
                                                                  .WithLingerMs(1);

                _producerConfig.BootstrapServers = _bootstrapServers;
                if (_producerConfig.CanApplyBasicSerializer<TKey>() && KeySerDes == null)
                {
                    KeySerDes = new KNetSerDes<TKey>();
                }
                
                if (KeySerDes == null) throw new InvalidOperationException($"{typeof(TKey)} needs an external serializer, set KeySerDes.");

                if (_producerConfig.CanApplyBasicSerializer<TValue>() && ValueSerDes == null)
                {
                    ValueSerDes = new KNetSerDes<TValue>();
                }
                
                if (ValueSerDes == null) throw new InvalidOperationException($"{typeof(TValue)} needs an external serializer, set ValueSerDes.");

                _producer = new KNetProducer<TKey, TValue>(_producerConfig, KeySerDes, ValueSerDes);
            }

            _consumer?.Subscribe(Collections.Singleton(_stateName), _consumerListener);

            _started = true;
        }

        /// <summary>
        /// Waits for the very first parition assignment of the COMPACTED topic which stores dictionary data
        /// </summary>
        /// <param name="timeout">The number of milliseconds to wait, or System.Threading.Timeout.Infinite (-1) to wait indefinitely</param>
        /// <returns>true if the current instance receives a signal within the given <paramref name="timeout"/>; otherwise, false</returns>
        /// <exception cref="InvalidOperationException">The provided <see cref="AccessRights"/> do not include the <see cref="AccessRights.Read"/> flag</exception>
        public bool WaitForStateAssignment(int timeout = Timeout.Infinite)
        {
            ValidateAccessRights(AccessRights.Read);

            return _assignmentWaiter.WaitOne(timeout);
        }

        /// <summary>
        /// Ensures the sync between the LOCAL and the REMOTE dictionary 
        /// </summary>
        /// <param name="timeout">The number of milliseconds to wait for the sync, or System.Threading.Timeout.Infinite (-1) to wait indefinitely</param>
        /// <param name="partitions">The list of partitions for which ensuring the sync, or null for all available partitions</param>
        /// <returns>true if the current instance gets the sync within the given <paramref name="timeout"/>; otherwise, false</returns>
        /// <remarks>If this method returns false, it does not mean that the sync between the LOCAL and the REMOTE dictionary will never be reached. 
        /// In background the fetch of data keeps going on</remarks>
        /// <exception cref="InvalidOperationException">The provided <see cref="AccessRights"/> do not include the <see cref="AccessRights.Read"/> flag</exception>
        /// <exception cref="ArgumentException"><paramref name="partitions"/> is not null, but empty</exception>
        public bool EnsureSync(
            int timeout = Timeout.Infinite,
            System.Collections.Generic.List<int> partitions = null)
        {
            ValidateAccessRights(AccessRights.Read);

            if (partitions != null && partitions.Count == 0)
                throw new ArgumentException($"{nameof(partitions)} must be null or NOT empty");

            if (!WaitForStateAssignment(timeout))
                return false;

            return true;
        }

        /// <summary>
        /// Waits until all outstanding produce requests and delivery report callbacks are completed
        /// </summary>
        public void Flush()
        {
            _producer?.Flush();
        }

        #endregion

        #region IDictionary<TKey, TValue>

        /// <summary>
        /// Gets or sets the element with the specified keyy. Null value removes the specified key
        /// </summary>
        /// <param name="key">The key of the element to get or set</param>
        /// <returns>The element with the specified key</returns>
        /// <exception cref="InvalidOperationException">The call is get, and the provided <see cref="AccessRights"/> do not include the <see cref="AccessRights.Read"/> flag</exception>
        /// <exception cref="InvalidOperationException">The call is set, and the provided <see cref="AccessRights"/> do not include the <see cref="AccessRights.Write"/> flag</exception>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is null</exception>
        /// <exception cref="KeyNotFoundException">The call is get and <paramref name="key"/> is not found</exception>
        /// <exception cref="UpdateDeliveryException">The call is set and the delivery of the update to the REMOTE dictionary fails</exception>
        public TValue this[TKey key]
        {
            get { return ValidateAndGetLocalDictionary()[key]; }
            set { AddOrUpdate(key, value); }
        }

        /// <summary>
        /// Gets an <see cref="ICollection{TKey}"/> containing the keys of the LOCAL dictionary
        /// </summary>
        /// <returns><see cref="ICollection{TKey}"/> containing the keys of the LOCAL dictionary</returns>
        /// <exception cref="InvalidOperationException">The provided <see cref="AccessRights"/> do not include the <see cref="AccessRights.Read"/> flag</exception>
        public ICollection<TKey> Keys
        {
            get { return ValidateAndGetLocalDictionary().Keys; }
        }

        /// <summary>
        /// Gets an <see cref="ICollection{TValue}"/> containing the values of the LOCAL dictionary
        /// </summary>
        /// <returns><see cref="ICollection{TValue}"/> containing the values of the LOCAL dictionary</returns>
        /// <exception cref="InvalidOperationException">The provided <see cref="AccessRights"/> do not include the <see cref="AccessRights.Read"/> flag</exception>
        public ICollection<TValue> Values
        {
            get { return ValidateAndGetLocalDictionary().Values; }
        }

        /// <summary>
        /// Gets the number of elements contained in the LOCAL dictionary
        /// </summary>
        /// <returns>The number of elements contained in the LOCAL dictionary</returns>
        /// <exception cref="InvalidOperationException">The provided <see cref="AccessRights"/> do not include the <see cref="AccessRights.Read"/> flag</exception>
        public int Count
        {
            get { return ValidateAndGetLocalDictionary().Count; }
        }

        /// <summary>
        /// false
        /// </summary>
        public bool IsReadOnly
        {
            get { return !_accessrights.HasFlag(AccessRights.Write); }
        }

        /// <summary>
        /// Adds or updates the <paramref name="key"/> in the REMOTE dictionary; 
        /// consequently updates, in the way defined by the <see cref="KSharpDictionaryUpdateModes"/> provided at constructor time, the LOCAL dictionary
        /// </summary>
        /// <param name="key">The object to use as the key of the element to add</param>
        /// <param name="value">The object to use as the value of the element to add. null means remove <paramref name="key"/></param>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is null</exception>
        /// <exception cref="UpdateDeliveryException">The delivery of the update to the REMOTE dictionary fails</exception>
        /// <exception cref="InvalidOperationException">The provided <see cref="AccessRights"/> do not include the <see cref="AccessRights.Write"/> flag</exception>
        public void Add(
            TKey key,
            TValue value)
        {
            AddOrUpdate(key, value);
        }

        /// <summary>
        /// Adds or updates the <paramref name="item"/> in the REMOTE dictionary; 
        /// consequently updates, in the way defined by the <see cref="KSharpDictionaryUpdateModes"/> provided at constructor time, the LOCAL dictionary
        /// </summary>
        /// <param name="item">The item to add or updates. Value == null means remove key</param>
        /// <exception cref="ArgumentNullException"><paramref name="item"/>.Key is null</exception>
        /// <exception cref="UpdateDeliveryException">The delivery of the update to the REMOTE dictionary fails</exception>
        /// <exception cref="InvalidOperationException">The provided <see cref="AccessRights"/> do not include the <see cref="AccessRights.Write"/> flag</exception>
        public void Add(KeyValuePair<TKey, TValue> item)
        {
            AddOrUpdate(item.Key, item.Value);
        }

        /// <summary>
        /// Clears the LOCAL dictionary, resetting all paritions' sync
        /// </summary>
        /// <remarks>After this call, a call to <see cref="EnsureSync(int, List{int})"/> 
        /// is recommended to get back in sync with the REMOTE dictionary</remarks>
        /// <exception cref="InvalidOperationException">The provided <see cref="AccessRights"/> do not include the <see cref="AccessRights.Read"/> flag</exception>
        public void Clear()
        {
            ValidateAndGetLocalDictionary().Clear();
        }

        /// <summary>
        /// Determines whether the LOCAL dictionary contains the specified item
        /// </summary>
        /// <param name="item">The item to locate in the LOCAL dictionary</param>
        /// <returns>true if the LOCAL dictionary contains an element <paramref name="item"/>; otherwise, false</returns>
        /// <exception cref="ArgumentNullException"><paramref name="item"/>.Key is null</exception>
        /// <exception cref="InvalidOperationException">The provided <see cref="AccessRights"/> do not include the <see cref="AccessRights.Read"/> flag</exception>
        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return (ValidateAndGetLocalDictionary() as IDictionary).Contains(item);
        }

        /// <summary>
        /// Determines whether the LOCAL dictionary contains an element with the specified key
        /// </summary>
        /// <param name="key">The key to locate in the LOCAL dictionary</param>
        /// <returns>true if the LOCAL dictionary contains an element with <paramref name="key"/>; otherwise, false</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is null</exception>
        /// <exception cref="InvalidOperationException">The provided <see cref="AccessRights"/> do not include the <see cref="AccessRights.Read"/> flag</exception>
        public bool ContainsKey(TKey key)
        {
            return ValidateAndGetLocalDictionary().ContainsKey(key);
        }

        /// <summary>
        /// Copies the elements of the LOCAL dictionary to an System.Array, starting at a particular System.Array index
        /// </summary>
        /// <param name="array">The one-dimensional System.Array that is the destination of the elements copied 
        /// from the LOCAL dictionary. The System.Array must have zero-based indexing</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins</param>ù
        /// <exception cref="ArgumentNullException"><paramref name="array"/> is null</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="arrayIndex"/> is less than zero</exception>
        /// <exception cref="ArgumentException"><paramref name="array"/> is multidimensional. 
        /// -or- The number of elements in the source LOCAL dictionary is greater than the available space from <paramref name="arrayIndex"/> to the end of the destination <paramref name="array"/>. 
        /// -or- The type of the source LOCAL dictionary cannot be cast automatically to the type of the destination <paramref name="array"/></exception>
        /// <exception cref="InvalidOperationException">The provided <see cref="AccessRights"/> do not include the <see cref="AccessRights.Read"/> flag</exception>
        public void CopyTo(
            KeyValuePair<TKey, TValue>[] array,
            int arrayIndex)
        {
            (ValidateAndGetLocalDictionary() as ICollection).CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the LOCAL dictionary
        /// </summary>
        /// <returns>An enumerator for the LOCAL dictionary</returns>
        /// <exception cref="InvalidOperationException">The provided <see cref="AccessRights"/> do not include the <see cref="AccessRights.Read"/> flag</exception>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return ValidateAndGetLocalDictionary().GetEnumerator();
        }

        /// <summary>
        /// Removes the item with the specified <paramref name="key"/> from the REMOTE dictionary; 
        /// consequently updates, in the way defined by the <see cref="KSharpDictionaryUpdateModes"/> provided at constructor time, the LOCAL dictionary
        /// </summary>
        /// <param name="key">The key of the element to remove</param>
        /// <returns>true if the removal request is delivered to the REMOTE dictionary</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is null</exception>
        /// <exception cref="UpdateDeliveryException">The delivery of the update to the REMOTE dictionary fails</exception>
        /// <exception cref="InvalidOperationException">The provided <see cref="AccessRights"/> do not include the <see cref="AccessRights.Write"/> flag</exception>
        public bool Remove(TKey key)
        {
            AddOrUpdate(key, null);

            return true;
        }

        /// <summary>
        /// Removes the <paramref name="item"/> from the REMOTE dictionary; 
        /// consequently updates, in the way defined by the <see cref="KSharpDictionaryUpdateModes"/> provided at constructor time, the LOCAL dictionary
        /// </summary>
        /// <param name="item">Item to be removed</param>
        /// <returns>true if the removal request is delivered to the REMOTE dictionary</returns>
        /// <exception cref="ArgumentNullException"><paramref name="item"/>.Key is null</exception>
        /// <exception cref="UpdateDeliveryException">The delivery of the update to the REMOTE dictionary fails</exception>
        /// <exception cref="InvalidOperationException">The provided <see cref="AccessRights"/> do not include the <see cref="AccessRights.Write"/> flag</exception>
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            AddOrUpdate(item.Key, null);

            return true;
        }

        /// <summary>
        /// Attempts to get the value associated with the specified <paramref name="key"/> from the LOCAL dictionary
        /// </summary>
        /// <param name="key">The key of the value to get</param>
        /// <param name="value">When this method returns, contains the object from the LOCAL dictionary 
        /// that has the specified <paramref name="key"/>, or the default value of the type if the operation failed</param>
        /// <returns>true if the <paramref name="key"/> was found in the LOCAL dictionary; otherwise, fals</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is null</exception>
        /// <exception cref="InvalidOperationException">The provided <see cref="AccessRights"/> do not include the <see cref="AccessRights.Read"/> flag</exception>
        public bool TryGetValue(
            TKey key,
            out TValue value)
        {
            return ValidateAndGetLocalDictionary().TryGetValue(key, out value);
        }

        /// <exception cref="InvalidOperationException">The provided <see cref="AccessRights"/> do not include the <see cref="AccessRights.Read"/> flag</exception>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (ValidateAndGetLocalDictionary() as IEnumerable).GetEnumerator();
        }

        #endregion

        #region IDisposable

        /// <summary>
        /// Release all managed and unmanaged resources
        /// </summary>
        public void Dispose()
        {
            _consumer?.Dispose();

            _producer?.Flush();
            _producer?.Dispose();

            _assignmentWaiter?.Close();
        }

        #endregion
    }
}
