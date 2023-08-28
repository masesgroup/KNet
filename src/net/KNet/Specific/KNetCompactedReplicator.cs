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
using MASES.KNet.Admin;
using MASES.KNet.Common;
using MASES.KNet.Consumer;
using MASES.KNet.Extensions;
using MASES.KNet.Producer;
using MASES.KNet.Serialization;
using Org.Apache.Kafka.Clients.Admin;
using Org.Apache.Kafka.Clients.Consumer;
using Org.Apache.Kafka.Clients.Producer;
using Org.Apache.Kafka.Common;
using Org.Apache.Kafka.Common.Config;
using Org.Apache.Kafka.Common.Errors;
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
        #region AccessRightsType
        /// <summary>
        /// <see cref="KNetCompactedReplicator{TKey, TValue}"/> access rights to data
        /// </summary>
        [Flags]
        public enum AccessRightsType
        {
            /// <summary>
            /// Data are readable, i.e. aligned with the others <see cref="KNetCompactedReplicator{TKey, TValue}"/> and accessible from this <see cref="KNetCompactedReplicator{TKey, TValue}"/>
            /// </summary>
            Read = 1,
            /// <summary>
            /// Data are writable, i.e. updates can be produced, but this <see cref="KNetCompactedReplicator{TKey, TValue}"/> is not accessible and not aligned with the others <see cref="KNetCompactedReplicator{TKey, TValue}"/>
            /// </summary>
            Write = 2,
            /// <summary>
            /// Data are readable and writable, i.e. updates can be produced, and data are aligned with the others <see cref="KNetCompactedReplicator{TKey, TValue}"/> and accessible from this <see cref="KNetCompactedReplicator{TKey, TValue}"/>
            /// </summary>
            ReadWrite = Read | Write,
        }

        #endregion

        #region UpdateModeTypes

        /// <summary>
        /// <see cref="KNetCompactedReplicator{TKey, TValue}"/> update modes
        /// </summary>
        public enum UpdateModeTypes
        {
            /// <summary>
            /// The <see cref="KNetCompactedReplicator{TKey, TValue}"/> is updated as soon as an update is delivered to Kafka by the current application
            /// </summary>
            OnDelivery = 1,
            /// <summary>
            /// The <see cref="KNetCompactedReplicator{TKey, TValue}"/> is updated only after an update is consumed from Kafka, even if the add or update is made locally by the current instance
            /// </summary>
            OnConsume = 2,
            /// <summary>
            /// The <see cref="KNetCompactedReplicator{TKey, TValue}"/> is updated only after an update is consumed from Kafka, even if the add or update is made locally by the current instance. Plus the update waits the consume of the data before unlock
            /// </summary>
            OnConsumeSync = 3
        }

        #endregion

        #region Private members

        private bool _consumerPollRun = false;
        private Thread _consumerPollThread = null;
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
        private AccessRightsType _accessrights = AccessRightsType.ReadWrite;
        private UpdateModeTypes _updateMode = UpdateModeTypes.OnDelivery;
        private Tuple<TKey, ManualResetEvent> _OnConsumeSyncWaiter = null;
        private readonly ManualResetEvent _assignmentWaiter = new ManualResetEvent(false);

        private KNetSerDes<TKey> _keySerDes = null;
        private KNetSerDes<TValue> _valueSerDes = null;

        private bool _started = false;

        #endregion

        #region Events

        /// <summary>
        /// Called when a [<typeparamref name="TKey"/>, <typeparamref name="TValue"/>] is updated by consuming data from the others <see cref="KNetCompactedReplicator{TKey, TValue}"/>
        /// </summary>
        public Action<KNetCompactedReplicator<TKey, TValue>, KeyValuePair<TKey, TValue>> OnRemoteUpdate;

        /// <summary>
        /// Called when a <typeparamref name="TKey"/> is removed by consuming data from the others <see cref="KNetCompactedReplicator{TKey, TValue}"/>
        /// </summary>
        public Action<KNetCompactedReplicator<TKey, TValue>, TKey> OnRemoteRemove;

        /// <summary>
        /// Called when a <typeparamref name="TKey"/> is removed from this <see cref="KNetCompactedReplicator{TKey, TValue}"/>
        /// </summary>
        public event Action<KNetCompactedReplicator<TKey, TValue>, KeyValuePair<TKey, TValue>> OnLocalUpdate;

        /// <summary>
        /// Called when a <typeparamref name="TKey"/> is removed from this <see cref="KNetCompactedReplicator{TKey, TValue}"/>
        /// </summary>
        public event Action<KNetCompactedReplicator<TKey, TValue>, TKey> OnLocalRemove;

        #endregion

        #region Public Properties
        /// <summary>
        /// Get or set <see cref="AccessRightsType"/>
        /// </summary>
        public AccessRightsType AccessRights { get { return _accessrights; } set { CheckStarted(); _accessrights = value; } }
        /// <summary>
        /// Get or set <see cref="UpdateModeTypes"/>
        /// </summary>
        public UpdateModeTypes UpdateMode { get { return _updateMode; } set { CheckStarted(); _updateMode = value; } }
        /// <summary>
        /// Get or set bootstrap servers
        /// </summary>
        public string BootstrapServers { get { return _bootstrapServers; } set { CheckStarted(); _bootstrapServers = value; } }
        /// <summary>
        /// Get or set topic name
        /// </summary>
        public string StateName { get { return _stateName; } set { CheckStarted(); _stateName = value; } }
        /// <summary>
        /// Get or set partitions to use when topic is created for the first time
        /// </summary>
        public int Partitions { get { return _partitions; } set { CheckStarted(); _partitions = value; } }
        /// <summary>
        /// Get or set replication factor to use when topic is created for the first time
        /// </summary>
        public short ReplicationFactor { get { return _replicationFactor; } set { CheckStarted(); _replicationFactor = value; } }
        /// <summary>
        /// Get or set <see cref="TopicConfigBuilder"/> to use when topic is created for the first time
        /// </summary>
        public TopicConfigBuilder TopicConfig { get { return _topicConfig; } set { CheckStarted(); _topicConfig = value; } }
        /// <summary>
        /// Get or set <see cref="ConsumerConfigBuilder"/> to use in <see cref="KNetCompactedReplicator{TKey, TValue}"/>
        /// </summary>
        public ConsumerConfigBuilder ConsumerConfig { get { return _consumerConfig; } set { CheckStarted(); _consumerConfig = value; } }
        /// <summary>
        /// Get or set <see cref="ProducerConfigBuilder"/> to use in <see cref="KNetCompactedReplicator{TKey, TValue}"/>
        /// </summary>
        public ProducerConfigBuilder ProducerConfig { get { return _producerConfig; } set { CheckStarted(); _producerConfig = value; } }
        /// <summary>
        /// Get or set <see cref="KNetSerDes{TKey}"/> to use in <see cref="KNetCompactedReplicator{TKey, TValue}"/>, by default it creates a default one based on <typeparamref name="TKey"/>
        /// </summary>
        public KNetSerDes<TKey> KeySerDes { get { return _keySerDes; } set { CheckStarted(); _keySerDes = value; } }
        /// <summary>
        /// Get or set <see cref="KNetSerDes{TValue}"/> to use in <see cref="KNetCompactedReplicator{TKey, TValue}"/>, by default it creates a default one based on <typeparamref name="TValue"/>
        /// </summary>
        public KNetSerDes<TValue> ValueSerDes { get { return _valueSerDes; } set { CheckStarted(); _valueSerDes = value; } }

        #endregion

        #region Private methods

        void CheckStarted()
        {
            if (_started) throw new InvalidOperationException("Cannot be changed after Start");
        }

        private void OnMessage(KNetConsumerRecord<TKey, TValue> record)
        {
            if (record.Value == null)
            {
                _dictionary.TryRemove(record.Key, out _);
                OnRemoteRemove?.Invoke(this, record.Key);
            }
            else
            {
                _dictionary[record.Key] = record.Value;
                OnRemoteUpdate?.Invoke(this, new KeyValuePair<TKey, TValue>(record.Key, record.Value));
            }

            if (_OnConsumeSyncWaiter != null)
            {
                if (_OnConsumeSyncWaiter.Item1.Equals(record.Key))
                {
                    _OnConsumeSyncWaiter.Item2.Set();
                }
            }
        }

        private void OnTopicPartitionsAssigned(Collection<TopicPartition> topicPartitions)
        {
            _assignmentWaiter?.Set();
        }

        private void OnTopicPartitionsRevoked(Collection<TopicPartition> topicPartitionOffsets)
        {
            _assignmentWaiter?.Set();
        }

        private void RemoveRecord(TKey key)
        {
            ValidateAccessRights(AccessRightsType.Write);

            if (key == null)
                throw new ArgumentNullException(nameof(key));

            if (UpdateMode == UpdateModeTypes.OnDelivery)
            {
                JVMBridgeException exception = null;

                DateTime pTimestamp = DateTime.MaxValue;
                using (AutoResetEvent deliverySemaphore = new AutoResetEvent(false))
                {
                    using (Callback cb = new Callback()
                    {
                        OnOnCompletion = (record, error) =>
                        {
                            try
                            {
                                if (deliverySemaphore.SafeWaitHandle.IsClosed)
                                    return;

                                exception = error;
                                deliverySemaphore.Set();
                            }
                            catch { }
                        }
                    })
                    {
                        _producer.Produce(new KNetProducerRecord<TKey, TValue>(_stateName, key, null), cb);
                        deliverySemaphore.WaitOne();
                        if (exception != null) throw exception;
                    }
                }
            }
            else if (UpdateMode == UpdateModeTypes.OnConsume || UpdateMode == UpdateModeTypes.OnConsumeSync)
            {
                _producer.Produce(StateName, key, null, (Callback)null);
            }
            _dictionary.TryRemove(key, out _);
        }

        private void AddOrUpdate(TKey key, TValue value)
        {
            ValidateAccessRights(AccessRightsType.Write);

            if (key == null)
                throw new ArgumentNullException(nameof(key));

            if (UpdateMode == UpdateModeTypes.OnDelivery)
            {
                JVMBridgeException exception = null;
                DateTime pTimestamp = DateTime.MaxValue;
                using (AutoResetEvent deliverySemaphore = new AutoResetEvent(false))
                {
                    using (Callback cb = new Callback()
                    {
                        OnOnCompletion = (record, error) =>
                        {
                            try
                            {
                                if (deliverySemaphore.SafeWaitHandle.IsClosed)
                                    return;

                                exception = error;
                                deliverySemaphore.Set();
                            }
                            catch { }
                        }
                    })
                    {
                        _producer.Produce(new KNetProducerRecord<TKey, TValue>(_stateName, key, value), cb);
                        deliverySemaphore.WaitOne();
                        if (exception != null) throw exception;
                    }
                }

                if (value == null)
                {
                    _dictionary.TryRemove(key, out _);
                    OnLocalRemove?.Invoke(this, key);
                }
                else
                {
                    _dictionary[key] = value;
                    OnLocalUpdate?.Invoke(this, new KeyValuePair<TKey, TValue>(key, value));
                }
            }
            else if (UpdateMode == UpdateModeTypes.OnConsume || UpdateMode == UpdateModeTypes.OnConsumeSync)
            {
                _producer.Produce(StateName, key, value, (Callback)null);
                if (UpdateMode == UpdateModeTypes.OnConsumeSync)
                {
                    _OnConsumeSyncWaiter = new Tuple<TKey, ManualResetEvent>(key, new ManualResetEvent(false));
                    _OnConsumeSyncWaiter.Item2.WaitOne();
                    _OnConsumeSyncWaiter.Item2.Dispose();
                }
            }
        }

        private void ValidateAccessRights(AccessRightsType rights)
        {
            if (!_accessrights.HasFlag(rights))
                throw new InvalidOperationException($"{rights} access flag not set");
        }

        private ConcurrentDictionary<TKey, TValue> ValidateAndGetLocalDictionary()
        {
            ValidateAccessRights(AccessRightsType.Read);
            return _dictionary;
        }

        #endregion

        #region Public methods
        /// <summary>
        /// Start this <see cref="KNetCompactedReplicator{TKey, TValue}"/>: create the <see cref="StateName"/> topic if not available, allocates Producer and Consumer, sets serializer/deserializer
        /// </summary>
        /// <exception cref="InvalidOperationException">Some errors occurred</exception>
        public void Start()
        {
            if (string.IsNullOrWhiteSpace(BootstrapServers)) throw new InvalidOperationException("BootstrapServers must be set before start.");
            if (string.IsNullOrWhiteSpace(StateName)) throw new InvalidOperationException("StateName must be set before start.");

            Properties props = AdminClientConfigBuilder.Create().WithBootstrapServers(BootstrapServers).ToProperties();
            _admin = KafkaAdminClient.Create(props);

            if (AccessRights.HasFlag(AccessRightsType.Write))
            {
                var topic = new NewTopic(StateName, Partitions, ReplicationFactor);
                _topicConfig ??= TopicConfigBuilder.Create().WithDeleteRetentionMs(100)
                                                            .WithMinCleanableDirtyRatio(0.01)
                                                            .WithSegmentMs(100);

                TopicConfig.CleanupPolicy = TopicConfigBuilder.CleanupPolicyTypes.Compact | TopicConfigBuilder.CleanupPolicyTypes.Delete;
                topic = topic.Configs(TopicConfig);
                try
                {
                    _admin.CreateTopic(topic);
                }
                catch (TopicExistsException)
                {
                }
            }

            if (AccessRights.HasFlag(AccessRightsType.Read))
            {
                _consumerConfig ??= ConsumerConfigBuilder.Create().WithEnableAutoCommit(true)
                                                                  .WithAutoOffsetReset(ConsumerConfigBuilder.AutoOffsetResetTypes.EARLIEST)
                                                                  .WithAllowAutoCreateTopics(false);

                ConsumerConfig.BootstrapServers = BootstrapServers;
                ConsumerConfig.GroupId = Guid.NewGuid().ToString();
                if (ConsumerConfig.CanApplyBasicDeserializer<TKey>() && KeySerDes == null)
                {
                    KeySerDes = new KNetSerDes<TKey>();
                }

                if (KeySerDes == null) throw new InvalidOperationException($"{typeof(TKey)} needs an external deserializer, set KeySerDes.");

                if (ConsumerConfig.CanApplyBasicDeserializer<TValue>() && ValueSerDes == null)
                {
                    ValueSerDes = new KNetSerDes<TValue>();
                }

                if (ValueSerDes == null) throw new InvalidOperationException($"{typeof(TValue)} needs an external deserializer, set ValueSerDes.");

                _consumer = new KNetConsumer<TKey, TValue>(ConsumerConfig, KeySerDes, ValueSerDes);
                _consumer.SetCallback(OnMessage);
                _consumerListener = new ConsumerRebalanceListener()
                {
                    OnOnPartitionsRevoked = OnTopicPartitionsRevoked,
                    OnOnPartitionsAssigned = OnTopicPartitionsAssigned
                };
            }

            if (AccessRights.HasFlag(AccessRightsType.Write))
            {
                _producerConfig ??= ProducerConfigBuilder.Create().WithAcks(ProducerConfigBuilder.AcksTypes.All)
                                                                  .WithRetries(0)
                                                                  .WithLingerMs(1);

                ProducerConfig.BootstrapServers = BootstrapServers;
                if (ProducerConfig.CanApplyBasicSerializer<TKey>() && KeySerDes == null)
                {
                    KeySerDes = new KNetSerDes<TKey>();
                }

                if (KeySerDes == null) throw new InvalidOperationException($"{typeof(TKey)} needs an external serializer, set KeySerDes.");

                if (ProducerConfig.CanApplyBasicSerializer<TValue>() && ValueSerDes == null)
                {
                    ValueSerDes = new KNetSerDes<TValue>();
                }

                if (ValueSerDes == null) throw new InvalidOperationException($"{typeof(TValue)} needs an external serializer, set ValueSerDes.");

                _producer = new KNetProducer<TKey, TValue>(ProducerConfig, KeySerDes, ValueSerDes);
            }

            if (_consumer != null)
            {
                _consumerPollRun = true;
                _consumerPollThread = new Thread(ConsumerPollHandler);
                _consumerPollThread.Start();
            }

            _started = true;
        }

        void ConsumerPollHandler(object o)
        {
            _consumer.Subscribe(Collections.Singleton(StateName), _consumerListener);
            while (_consumerPollRun)
            {
                try
                {
                    _consumer.ConsumeAsync(100);
                }
                catch { }
            }
        }

        /// <summary>
        /// Waits for the very first parition assignment of the <see cref="StateName"/> topic which stores dictionary data
        /// </summary>
        /// <param name="timeout">The number of milliseconds to wait, or <see cref="Timeout.Infinite"/> to wait indefinitely</param>
        /// <returns><see langword="true"/> if the current instance receives a signal within the given <paramref name="timeout"/>; otherwise, <see langword="false"/></returns>
        /// <exception cref="InvalidOperationException">The provided <see cref="AccessRights"/> do not include the <see cref="AccessRightsType.Read"/> flag</exception>
        public bool WaitForStateAssignment(int timeout = Timeout.Infinite)
        {
            ValidateAccessRights(AccessRightsType.Read);

            return _assignmentWaiter.WaitOne(timeout);
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
        /// Gets or sets the element with the specified keyy. <see langword="null"/> value removes the specified key
        /// </summary>
        /// <param name="key">The key of the element to get or set</param>
        /// <returns>The element with the specified key</returns>
        /// <exception cref="InvalidOperationException">The call is get, and the provided <see cref="AccessRights"/> do not include the <see cref="AccessRightsType.Read"/> flag</exception>
        /// <exception cref="InvalidOperationException">The call is set, and the provided <see cref="AccessRights"/> do not include the <see cref="AccessRightsType.Write"/> flag</exception>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is null</exception>
        /// <exception cref="KeyNotFoundException">The call is get and <paramref name="key"/> is not found</exception>
        public TValue this[TKey key]
        {
            get { return ValidateAndGetLocalDictionary()[key]; }
            set { AddOrUpdate(key, value); }
        }

        /// <summary>
        /// Gets an <see cref="System.Collections.Generic.ICollection{TKey}"/> containing the keys of this <see cref="KNetCompactedReplicator{TKey, TValue}"/>
        /// </summary>
        /// <returns><see cref="System.Collections.Generic.ICollection{TKey}"/> containing the keys of this <see cref="KNetCompactedReplicator{TKey, TValue}"/></returns>
        /// <exception cref="InvalidOperationException">The provided <see cref="AccessRights"/> do not include the <see cref="AccessRightsType.Read"/> flag</exception>
        public System.Collections.Generic.ICollection<TKey> Keys
        {
            get { return ValidateAndGetLocalDictionary().Keys; }
        }

        /// <summary>
        /// Gets an <see cref="System.Collections.Generic.ICollection{TValue}"/> containing the values of this <see cref="KNetCompactedReplicator{TKey, TValue}"/>
        /// </summary>
        /// <returns><see cref="System.Collections.Generic.ICollection{TValue}"/> containing the values of this <see cref="KNetCompactedReplicator{TKey, TValue}"/></returns>
        /// <exception cref="InvalidOperationException">The provided <see cref="AccessRights"/> do not include the <see cref="AccessRightsType.Read"/> flag</exception>
        public System.Collections.Generic.ICollection<TValue> Values
        {
            get { return ValidateAndGetLocalDictionary().Values; }
        }

        /// <summary>
        /// Gets the number of elements contained in this <see cref="KNetCompactedReplicator{TKey, TValue}"/>
        /// </summary>
        /// <returns>The number of elements contained in this <see cref="KNetCompactedReplicator{TKey, TValue}"/></returns>
        /// <exception cref="InvalidOperationException">The provided <see cref="AccessRights"/> do not include the <see cref="AccessRightsType.Read"/> flag</exception>
        public int Count
        {
            get { return ValidateAndGetLocalDictionary().Count; }
        }

        /// <summary>
        /// <see langword="true"/> if <see cref="AccessRights"/> do not include the <see cref="AccessRightsType.Write"/> flag
        /// </summary>
        public bool IsReadOnly
        {
            get { return !_accessrights.HasFlag(AccessRightsType.Write); }
        }

        /// <summary>
        /// Adds or updates the <paramref name="key"/> in this and others <see cref="KNetCompactedReplicator{TKey, TValue}"/> in the way defined by the <see cref="UpdateModeTypes"/> provided
        /// </summary>
        /// <param name="key">The object to use as the key of the element to add</param>
        /// <param name="value">The object to use as the value of the element to add. null means remove <paramref name="key"/></param>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is null</exception>
        /// <exception cref="InvalidOperationException">The provided <see cref="AccessRights"/> do not include the <see cref="AccessRightsType.Write"/> flag</exception>
        public void Add(TKey key, TValue value)
        {
            AddOrUpdate(key, value);
        }

        /// <summary>
        /// Adds or updates the <paramref name="item"/> in this and others <see cref="KNetCompactedReplicator{TKey, TValue}"/> in the way defined by the <see cref="UpdateModeTypes"/> provided
        /// </summary>
        /// <param name="item">The item to add or updates. Value == null means remove key</param>
        /// <exception cref="ArgumentNullException"><paramref name="item"/>.Key is null</exception>
        /// <exception cref="InvalidOperationException">The provided <see cref="AccessRights"/> do not include the <see cref="AccessRightsType.Write"/> flag</exception>
        public void Add(KeyValuePair<TKey, TValue> item)
        {
            AddOrUpdate(item.Key, item.Value);
        }

        /// <summary>
        /// Clears this <see cref="KNetCompactedReplicator{TKey, TValue}"/>, resetting all paritions' sync
        /// </summary>
        /// <exception cref="InvalidOperationException">The provided <see cref="AccessRights"/> do not include the <see cref="AccessRightsType.Read"/> flag</exception>
        public void Clear()
        {
            ValidateAndGetLocalDictionary().Clear();
        }

        /// <summary>
        /// Determines whether this <see cref="KNetCompactedReplicator{TKey, TValue}"/> contains the specified item
        /// </summary>
        /// <param name="item">The item to locate in this <see cref="KNetCompactedReplicator{TKey, TValue}"/></param>
        /// <returns><see langword="true"/> if this <see cref="KNetCompactedReplicator{TKey, TValue}"/> contains an element <paramref name="item"/>; otherwise, <see langword="false"/></returns>
        /// <exception cref="ArgumentNullException"><paramref name="item"/>.Key is <see langword="null"/></exception>
        /// <exception cref="InvalidOperationException">The provided <see cref="AccessRights"/> do not include the <see cref="AccessRightsType.Read"/> flag</exception>
        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return (ValidateAndGetLocalDictionary() as IDictionary).Contains(item);
        }

        /// <summary>
        /// Determines whether this <see cref="KNetCompactedReplicator{TKey, TValue}"/> contains an element with the specified key
        /// </summary>
        /// <param name="key">The key to locate in this <see cref="KNetCompactedReplicator{TKey, TValue}"/></param>
        /// <returns><see langword="true"/> if this <see cref="KNetCompactedReplicator{TKey, TValue}"/> contains an element with <paramref name="key"/>; otherwise, <see langword="false"/></returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/></exception>
        /// <exception cref="InvalidOperationException">The provided <see cref="AccessRights"/> do not include the <see cref="AccessRightsType.Read"/> flag</exception>
        public bool ContainsKey(TKey key)
        {
            return ValidateAndGetLocalDictionary().ContainsKey(key);
        }

        /// <summary>
        /// Copies the elements of this <see cref="KNetCompactedReplicator{TKey, TValue}"/> to an <see cref="Array"/>, starting at a particular <see cref="Array"/> index
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="Array"/> that is the destination of the elements copied 
        /// from this <see cref="KNetCompactedReplicator{TKey, TValue}"/>. The <see cref="Array"/> must have zero-based indexing</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins</param>ù
        /// <exception cref="ArgumentNullException"><paramref name="array"/> is null</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="arrayIndex"/> is less than zero</exception>
        /// <exception cref="ArgumentException"><paramref name="array"/> is multidimensional. 
        /// -or- The number of elements in the source <see cref="KNetCompactedReplicator{TKey, TValue}"/> is greater than the available space from <paramref name="arrayIndex"/> to the end of the destination <paramref name="array"/>. 
        /// -or- The type of the source <see cref="KNetCompactedReplicator{TKey, TValue}"/> cannot be cast automatically to the type of the destination <paramref name="array"/></exception>
        /// <exception cref="InvalidOperationException">The provided <see cref="AccessRights"/> do not include the <see cref="AccessRightsType.Read"/> flag</exception>
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            (ValidateAndGetLocalDictionary() as ICollection).CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Returns an enumerator that iterates through this <see cref="KNetCompactedReplicator{TKey, TValue}"/>
        /// </summary>
        /// <returns>An enumerator for this <see cref="KNetCompactedReplicator{TKey, TValue}"/></returns>
        /// <exception cref="InvalidOperationException">The provided <see cref="AccessRights"/> do not include the <see cref="AccessRightsType.Read"/> flag</exception>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return ValidateAndGetLocalDictionary().GetEnumerator();
        }

        /// <summary>
        /// Removes the <paramref name="key"/> from this and others <see cref="KNetCompactedReplicator{TKey, TValue}"/> in the way defined by the <see cref="UpdateModeTypes"/> provided
        /// </summary>
        /// <param name="key">The key of the element to remove</param>
        /// <returns><see langword="true"/> if the removal request is delivered to the others <see cref="KNetCompactedReplicator{TKey, TValue}"/></returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/></exception>
        /// <exception cref="InvalidOperationException">The provided <see cref="AccessRights"/> do not include the <see cref="AccessRightsType.Write"/> flag</exception>
        public bool Remove(TKey key)
        {
            AddOrUpdate(key, null);

            return true;
        }

        /// <summary>
        /// Removes the <paramref name="item"/> from this and others <see cref="KNetCompactedReplicator{TKey, TValue}"/> in the way defined by the <see cref="UpdateModeTypes"/> provided
        /// </summary>
        /// <param name="item">Item to be removed</param>
        /// <returns><see langword="true"/> if the removal request is delivered to the others <see cref="KNetCompactedReplicator{TKey, TValue}"/></returns>
        /// <exception cref="ArgumentNullException"><paramref name="item"/>.Key is <see langword="null"/></exception>
        /// <exception cref="InvalidOperationException">The provided <see cref="AccessRights"/> do not include the <see cref="AccessRightsType.Write"/> flag</exception>
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            AddOrUpdate(item.Key, null);

            return true;
        }

        /// <summary>
        /// Attempts to get the value associated with the specified <paramref name="key"/> from this <see cref="KNetCompactedReplicator{TKey, TValue}"/>
        /// </summary>
        /// <param name="key">The key of the value to get</param>
        /// <param name="value">When this method returns, contains the object from this <see cref="KNetCompactedReplicator{TKey, TValue}"/>
        /// that has the specified <paramref name="key"/>, or the default value of the type if the operation failed</param>
        /// <returns><see langword="true"/> if the <paramref name="key"/> was found in this <see cref="KNetCompactedReplicator{TKey, TValue}"/>; otherwise, <see langword="false"/></returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/></exception>
        /// <exception cref="InvalidOperationException">The provided <see cref="AccessRights"/> do not include the <see cref="AccessRightsType.Read"/> flag</exception>
        public bool TryGetValue(
            TKey key,
            out TValue value)
        {
            return ValidateAndGetLocalDictionary().TryGetValue(key, out value);
        }

        /// <exception cref="InvalidOperationException">The provided <see cref="AccessRights"/> do not include the <see cref="AccessRightsType.Read"/> flag</exception>
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
            _consumerPollRun = false;

            _consumer?.Dispose();

            _producer?.Flush();
            _producer?.Dispose();

            _assignmentWaiter?.Close();
        }

        #endregion
    }
}
