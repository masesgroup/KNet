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

using Java.Time;
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
using System.Diagnostics;
using System.Linq;
using System.Threading;
using static Javax.Swing.Text.Html.HTML;

namespace MASES.KNet.Replicator
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
    [Flags()]
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
        OnConsumeSync = 3,
        /// <summary>
        /// The value is stored in <see cref="KNetCompactedReplicator{TKey, TValue}"/> only upon a request, otherwise only the key is stored
        /// </summary>
        Delayed = 0x1000
    }

    #endregion

    #region IKNetCompactedReplicator<TKey, TValue>
    /// <summary>
    /// Public interface for <see cref="KNetCompactedReplicator{TKey, TValue}"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the dictionary. Must be a nullable type</typeparam>
    public interface IKNetCompactedReplicator<TKey, TValue> : IDictionary<TKey, TValue>, IDisposable
        where TValue : class
    {
        #region Events

        /// <summary>
        /// Called when a [<typeparamref name="TKey"/>, <typeparamref name="TValue"/>] is updated by consuming data from the others <see cref="KNetCompactedReplicator{TKey, TValue}"/>
        /// </summary>
        event Action<KNetCompactedReplicator<TKey, TValue>, KeyValuePair<TKey, TValue>> OnRemoteUpdate;

        /// <summary>
        /// Called when a [<typeparamref name="TKey"/>, <typeparamref name="TValue"/>] is removed by consuming data from the others <see cref="KNetCompactedReplicator{TKey, TValue}"/>
        /// </summary>
        event Action<KNetCompactedReplicator<TKey, TValue>, KeyValuePair<TKey, TValue>> OnRemoteRemove;

        /// <summary>
        /// Called when a [<typeparamref name="TKey"/>, <typeparamref name="TValue"/>] is updated on this <see cref="KNetCompactedReplicator{TKey, TValue}"/>
        /// </summary>
        event Action<KNetCompactedReplicator<TKey, TValue>, KeyValuePair<TKey, TValue>> OnLocalUpdate;

        /// <summary>
        /// Called when a [<typeparamref name="TKey"/>, <typeparamref name="TValue"/>] is removed from this <see cref="KNetCompactedReplicator{TKey, TValue}"/>
        /// </summary>
        event Action<KNetCompactedReplicator<TKey, TValue>, KeyValuePair<TKey, TValue>> OnLocalRemove;

        /// <summary>
        /// If <see cref="UpdateMode"/> contains the <see cref="UpdateModeTypes.Delayed"/> it is called to request if the [<typeparamref name="TKey"/>, <typeparamref name="TValue"/>] shall be stored in the <see cref="KNetCompactedReplicator{TKey, TValue}"/>
        /// </summary>
        event Func<KNetCompactedReplicator<TKey, TValue>, KeyValuePair<TKey, TValue>, bool> OnDelayedStore;

        #endregion

        #region Public Properties
        /// <summary>
        /// Get or set <see cref="AccessRightsType"/>
        /// </summary>
        AccessRightsType AccessRights { get; }
        /// <summary>
        /// Get or set <see cref="UpdateModeTypes"/>
        /// </summary>
        UpdateModeTypes UpdateMode { get; }
        /// <summary>
        /// Get or set bootstrap servers
        /// </summary>
        string BootstrapServers { get; }
        /// <summary>
        /// Get or set topic name
        /// </summary>
        string StateName { get; }
        /// <summary>
        /// Get or set the group id, if not set a value is generated
        /// </summary>
        string GroupId { get; }
        /// <summary>
        /// Get or set partitions to use when topic is created for the first time, otherwise reports the partiions of the topic
        /// </summary>
        int Partitions { get; }
        /// <summary>
        /// Get or set replication factor to use when topic is created for the first time, otherwise reports the replication factor of the topic
        /// </summary>
        short ReplicationFactor { get; }
        /// <summary>
        /// Get or set <see cref="TopicConfigBuilder"/> to use when topic is created for the first time
        /// </summary>
        TopicConfigBuilder TopicConfig { get; }
        /// <summary>
        /// Get or set <see cref="ConsumerConfigBuilder"/> to use in <see cref="KNetCompactedReplicator{TKey, TValue}"/>
        /// </summary>
        ConsumerConfigBuilder ConsumerConfig { get; }
        /// <summary>
        /// Get or set <see cref="ProducerConfigBuilder"/> to use in <see cref="KNetCompactedReplicator{TKey, TValue}"/>
        /// </summary>
        ProducerConfigBuilder ProducerConfig { get; }
        /// <summary>
        /// Get or set <see cref="KNetSerDes{TKey}"/> to use in <see cref="KNetCompactedReplicator{TKey, TValue}"/>, by default it creates a default one based on <typeparamref name="TKey"/>
        /// </summary>
        KNetSerDes<TKey> KeySerDes { get; }
        /// <summary>
        /// Get or set <see cref="KNetSerDes{TValue}"/> to use in <see cref="KNetCompactedReplicator{TKey, TValue}"/>, by default it creates a default one based on <typeparamref name="TValue"/>
        /// </summary>
        KNetSerDes<TValue> ValueSerDes { get; }
        /// <summary>
        /// <see langword="true"/> if the instance was started
        /// </summary>
        bool IsStarted { get; }
        /// <summary>
        /// <see langword="true"/> if the instance was started
        /// </summary>
        bool IsAssigned { get; }

        #endregion

        #region Public methods
        /// <summary>
        /// Start this <see cref="KNetCompactedReplicator{TKey, TValue}"/>: create the <see cref="StateName"/> topic if not available, allocates Producer and Consumer, sets serializer/deserializer
        /// </summary>
        /// <exception cref="InvalidOperationException">Some errors occurred</exception>
        void Start();
        /// <summary>
        /// Start this <see cref="KNetCompactedReplicator{TKey, TValue}"/>: create the <see cref="StateName"/> topic if not available, allocates Producer and Consumers, sets serializer/deserializer
        /// Then waits its synchronization with <see cref="StateName"/> topic which stores dictionary data
        /// </summary>
        /// <exception cref="InvalidOperationException">Some errors occurred or the provided <see cref="AccessRights"/> do not include the <see cref="AccessRightsType.Read"/> flag</exception>
        void StartAndWait(int timeout = Timeout.Infinite);
        /// <summary>
        /// Waits for all paritions assignment of the <see cref="StateName"/> topic which stores dictionary data
        /// </summary>
        /// <param name="timeout">The number of milliseconds to wait, or <see cref="Timeout.Infinite"/> to wait indefinitely</param>
        /// <returns><see langword="true"/> if the current instance receives a signal within the given <paramref name="timeout"/>; otherwise, <see langword="false"/></returns>
        /// <exception cref="InvalidOperationException">The provided <see cref="AccessRights"/> do not include the <see cref="AccessRightsType.Read"/> flag</exception>
        bool WaitForStateAssignment(int timeout = Timeout.Infinite);
        /// <summary>
        /// Waits that <see cref="KNetCompactedReplicator{TKey, TValue}"/> is synchronized to the <see cref="StateName"/> topic which stores dictionary data
        /// </summary>
        /// <param name="timeout">The number of milliseconds to wait, or <see cref="Timeout.Infinite"/> to wait indefinitely</param>
        /// <returns><see langword="true"/> if the current instance synchronize within the given <paramref name="timeout"/>; otherwise, <see langword="false"/></returns>
        /// <exception cref="InvalidOperationException">The provided <see cref="AccessRights"/> do not include the <see cref="AccessRightsType.Read"/> flag</exception>
        void SyncWait(int timeout = Timeout.Infinite);
        /// <summary>
        /// Waits until all outstanding produce requests and delivery report callbacks are completed
        /// </summary>
        void Flush();

        #endregion
    }

    #endregion

    #region IKNetCompactedReplicator<TKey, TValue>
    /// <summary>
    /// Provides a reliable dictionary, persisted in a COMPACTED Kafka topic and shared among applications
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the dictionary. Must be a nullable type</typeparam>
    public class KNetCompactedReplicator<TKey, TValue> : IKNetCompactedReplicator<TKey, TValue>
        where TValue : class
    {
        #region Local storage data

        interface ILocalDataStorage
        {
            object Lock { get; }
            Int32 Partition { get; set; }
            bool HasOffset { get; set; }
            Int64 Offset { get; set; }
            bool HasValue { get; set; }
            TValue Value { get; set; }
        }

        struct LocalDataStorage : ILocalDataStorage
        {
            object _lock = new object();
            public LocalDataStorage()
            {
                Partition = -1;
                HasOffset = HasValue = false;
                Offset = -1;
                Value = null;
            }
            public object Lock => _lock;
            public int Partition { get; set; }
            public bool HasOffset { get; set; }
            public long Offset { get; set; }
            public bool HasValue { get; set; }
            public TValue Value { get; set; }
        }

        #endregion

        #region Local Enumerator

        class LocalDataStorageEnumerator : IEnumerator<KeyValuePair<TKey, TValue>>
        {
            private IEnumerator<KeyValuePair<TKey, ILocalDataStorage>> _enumerator;
            private readonly ConcurrentDictionary<TKey, ILocalDataStorage> _dictionary;
            private readonly IKNetConsumer<TKey, TValue> _consumer = null;
            private readonly string _topic;
            public LocalDataStorageEnumerator(ConcurrentDictionary<TKey, ILocalDataStorage> dictionary, IKNetConsumer<TKey, TValue> consumer, string topic)
            {
                _dictionary = dictionary;
                _consumer = consumer;
                _topic = topic;
                _enumerator = _dictionary.GetEnumerator();
            }

            KeyValuePair<TKey, TValue>? _current = null;
            public KeyValuePair<TKey, TValue> Current
            {
                get
                {
                    lock (_enumerator)
                    {
                        if (_current == null)
                        {
                            var localCurrent = _enumerator.Current;
                            ILocalDataStorage data = localCurrent.Value;
                            lock (data.Lock)
                            {
                                if (!data.HasValue)
                                {
                                    OnDemandRetrieve(_consumer, _topic, localCurrent.Key, data);
                                }
                                _current = new KeyValuePair<TKey, TValue>(localCurrent.Key, localCurrent.Value.Value);
                            }
                        }
                        return _current.Value;
                    }
                }
            }

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                _enumerator.Dispose();
            }

            public bool MoveNext()
            {
                lock (_enumerator)
                {
                    _current = null;
                    return _enumerator.MoveNext();
                }
            }

            public void Reset()
            {
                _enumerator.Reset();
            }

            public System.Collections.Generic.ICollection<TValue> Values()
            {
                System.Collections.Generic.List<TValue> values = new System.Collections.Generic.List<TValue>();
                while (_enumerator.MoveNext())
                {
                    values.Add(_enumerator.Current.Value.Value);
                }
                return values;
            }

            public bool TryGetValue(TKey key, out TValue value)
            {
                value = default;
                if (_dictionary.TryGetValue(key, out var data))
                {
                    if (!data.HasValue)
                    {
                        OnDemandRetrieve(_consumer, _topic, key, data);
                    }
                    value = data.Value;
                    return true;
                }
                return false;
            }

            public bool Contains(KeyValuePair<TKey, TValue> item)
            {
                if (_dictionary.TryGetValue(item.Key, out var data))
                {
                    if (!data.HasValue)
                    {
                        OnDemandRetrieve(_consumer, _topic, item.Key, data);
                    }
                    if (data.HasValue && data.Value == item.Value) return true;
                }
                return false;
            }

            public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
            {
                var values = new System.Collections.Generic.List<KeyValuePair<TKey, TValue>>();
                while (_enumerator.MoveNext())
                {
                    values.Add(new KeyValuePair<TKey, TValue>(_enumerator.Current.Key, _enumerator.Current.Value.Value));
                }

                Array.Copy(values.ToArray(), 0, array, arrayIndex, values.Count);
            }
        }

        #endregion

        #region Private members

        private bool _consumerPollRun = false;
        private Thread[] _consumerPollThreads = null;
        private IAdmin _admin = null;
        private ConcurrentDictionary<TKey, ILocalDataStorage> _dictionary = new ConcurrentDictionary<TKey, ILocalDataStorage>();
        private ConsumerRebalanceListener _consumerListener = null;
        private KNetConsumer<TKey, TValue>[] _consumers = null;
        private KNetConsumer<TKey, TValue> _onTheFlyConsumer = null;
        private KNetProducer<TKey, TValue> _producer = null;
        private string _bootstrapServers = null;
        private string _stateName = string.Empty;
        private string _groupId = Guid.NewGuid().ToString();
        private int _partitions = 1;
        private short _replicationFactor = 1;
        private TopicConfigBuilder _topicConfig = null;
        private ConsumerConfigBuilder _consumerConfig = null;
        private ProducerConfigBuilder _producerConfig = null;
        private AccessRightsType _accessrights = AccessRightsType.ReadWrite;
        private UpdateModeTypes _updateMode = UpdateModeTypes.OnDelivery;
        private Tuple<TKey, ManualResetEvent> _OnConsumeSyncWaiter = null;
        private ManualResetEvent[] _assignmentWaiters;
        private long[] _lastPartitionLags = null;

        private KNetSerDes<TKey> _keySerDes = null;
        private KNetSerDes<TValue> _valueSerDes = null;

        private bool _started = false;

        #endregion

        #region Events

        /// <summary>
        /// Called when a [<typeparamref name="TKey"/>, <typeparamref name="TValue"/>] is updated by consuming data from the others <see cref="KNetCompactedReplicator{TKey, TValue}"/>
        /// </summary>
        public event Action<KNetCompactedReplicator<TKey, TValue>, KeyValuePair<TKey, TValue>> OnRemoteUpdate;

        /// <summary>
        /// Called when a [<typeparamref name="TKey"/>, <typeparamref name="TValue"/>] is removed by consuming data from the others <see cref="KNetCompactedReplicator{TKey, TValue}"/>
        /// </summary>
        public event Action<KNetCompactedReplicator<TKey, TValue>, KeyValuePair<TKey, TValue>> OnRemoteRemove;

        /// <summary>
        /// Called when a [<typeparamref name="TKey"/>, <typeparamref name="TValue"/>] is updated on this <see cref="KNetCompactedReplicator{TKey, TValue}"/>
        /// </summary>
        public event Action<KNetCompactedReplicator<TKey, TValue>, KeyValuePair<TKey, TValue>> OnLocalUpdate;

        /// <summary>
        /// Called when a [<typeparamref name="TKey"/>, <typeparamref name="TValue"/>] is removed from this <see cref="KNetCompactedReplicator{TKey, TValue}"/>
        /// </summary>
        public event Action<KNetCompactedReplicator<TKey, TValue>, KeyValuePair<TKey, TValue>> OnLocalRemove;

        /// <summary>
        /// If <see cref="UpdateMode"/> contains the <see cref="UpdateModeTypes.Delayed"/> it is called to request if the [<typeparamref name="TKey"/>, <typeparamref name="TValue"/>] shall be stored in the <see cref="KNetCompactedReplicator{TKey, TValue}"/>
        /// </summary>
        public event Func<KNetCompactedReplicator<TKey, TValue>, KeyValuePair<TKey, TValue>, bool> OnDelayedStore;

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
        /// Get or set the group id, if not set a value is generated
        /// </summary>
        public string GroupId { get { return _groupId; } set { CheckStarted(); _groupId = value; } }
        /// <summary>
        /// Get or set partitions to use when topic is created for the first time, otherwise reports the partiions of the topic
        /// </summary>
        public int Partitions { get { return _partitions; } set { CheckStarted(); _partitions = value; } }
        /// <summary>
        /// Get or set replication factor to use when topic is created for the first time, otherwise reports the replication factor of the topic
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
        /// <summary>
        /// <see langword="true"/> if the instance was started
        /// </summary>
        public bool IsStarted => _started;
        /// <summary>
        /// <see langword="true"/> if the instance was started
        /// </summary>
        public bool IsAssigned => _assignmentWaiters.All((o) => o.WaitOne(0));

        #endregion

        #region Private methods
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        static void OnDemandRetrieve(IKNetConsumer<TKey, TValue> consumer, string topic, TKey key, ILocalDataStorage data)
        {
            if (!data.HasValue)
            {
                var topicPartition = new TopicPartition(topic, data.Partition);
                consumer.Assign(Collections.SingletonList(topicPartition));
                consumer.Seek(topicPartition, data.Offset);
                var results = consumer.Poll(TimeSpan.FromMinutes(1));
                if (results == null) throw new InvalidOperationException("Failed to get records from remote.");
                foreach (var result in results)
                {
                    if (!Equals(result.Key, key)) continue;
                    if (data.Offset != result.Offset) throw new IndexOutOfRangeException($"Requested offset is {data.Offset} while received offset is {result.Offset}");
                    data.HasValue = true;
                    data.Value = result.Value;
                    break;
                }
            }
        }
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        void CheckStarted()
        {
            if (_started) throw new InvalidOperationException("Cannot be changed after Start");
        }

        bool UpdateModeOnDelivery => (UpdateMode & UpdateModeTypes.OnDelivery) == UpdateModeTypes.OnDelivery;

        bool UpdateModeOnConsume => (UpdateMode & UpdateModeTypes.OnConsume) == UpdateModeTypes.OnConsume;

        bool UpdateModeOnConsumeSync => (UpdateMode & UpdateModeTypes.OnConsumeSync) == UpdateModeTypes.OnConsumeSync;

        bool UpdateModeDelayed => UpdateMode.HasFlag(UpdateModeTypes.Delayed);

        private void OnMessage(KNetConsumerRecord<TKey, TValue> record)
        {
            if (record.Value == null)
            {
                _dictionary.TryRemove(record.Key, out var data);
                OnRemoteRemove?.Invoke(this, new KeyValuePair<TKey, TValue>(record.Key, data.Value));
            }
            else
            {
                ILocalDataStorage data;
                if (!_dictionary.TryGetValue(record.Key, out data))
                {
                    data = new LocalDataStorage();
                    _dictionary[record.Key] = data;
                }
                lock (data.Lock)
                {
                    data.Partition = record.Partition;
                    data.HasOffset = true;
                    data.Offset = record.Offset;
                    bool storeValue = true;
                    if (UpdateModeDelayed)
                    {
                        storeValue = (OnDelayedStore != null) ? OnDelayedStore.Invoke(this, new KeyValuePair<TKey, TValue>(record.Key, record.Value)) : false;
                    }
                    if (storeValue)
                    {
                        data.HasValue = true;
                        data.Value = record.Value;
                    }
                }
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
            foreach (var topicPartition in topicPartitions)
            {
                _assignmentWaiters[topicPartition.Partition()].Set();
            }
        }

        private void OnTopicPartitionsRevoked(Collection<TopicPartition> topicPartitions)
        {
            foreach (var topicPartition in topicPartitions)
            {
                _assignmentWaiters[topicPartition.Partition()].Reset();
            }
        }

        private void OnTopicPartitionsLost(Collection<TopicPartition> topicPartitions)
        {
            foreach (var topicPartition in topicPartitions)
            {
                _assignmentWaiters[topicPartition.Partition()].Reset();
            }
        }
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        private void RemoveRecord(TKey key)
        {
            ValidateAccessRights(AccessRightsType.Write);

            if (key == null)
                throw new ArgumentNullException(nameof(key));

            if (UpdateModeOnDelivery)
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
            else if (UpdateModeOnConsume || UpdateModeOnConsumeSync)
            {
                _producer.Produce(StateName, key, null, (Callback)null);
            }
            _dictionary.TryRemove(key, out _);
        }
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        private void AddOrUpdate(TKey key, TValue value)
        {
            ValidateAccessRights(AccessRightsType.Write);

            if (key == null)
                throw new ArgumentNullException(nameof(key));

            if (UpdateModeOnDelivery)
            {
                RecordMetadata metadata = null;
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
                                metadata = record;
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
                    _dictionary.TryRemove(key, out var data);
                    OnLocalRemove?.Invoke(this, new KeyValuePair<TKey, TValue>(key, data.Value));
                }
                else
                {
                    ILocalDataStorage data;
                    if (!_dictionary.TryGetValue(key, out data))
                    {
                        data = new LocalDataStorage();
                        _dictionary[key] = data;
                    }
                    lock (data.Lock)
                    {
                        data.Partition = metadata.Partition();
                        data.HasOffset = metadata.HasOffset();
                        data.Offset = metadata.Offset();
                        bool storeValue = true;
                        if (UpdateModeDelayed)
                        {
                            storeValue = (OnDelayedStore != null) ? OnDelayedStore.Invoke(this, new KeyValuePair<TKey, TValue>(key, value)) : false;
                        }
                        if (storeValue)
                        {
                            data.HasValue = true;
                            data.Value = value;
                        }
                    }
                    OnLocalUpdate?.Invoke(this, new KeyValuePair<TKey, TValue>(key, value));
                }
            }
            else if (UpdateModeOnConsume || UpdateModeOnConsumeSync)
            {
                _producer.Produce(StateName, key, value, (Callback)null);
                if (UpdateModeOnConsumeSync)
                {
                    _OnConsumeSyncWaiter = new Tuple<TKey, ManualResetEvent>(key, new ManualResetEvent(false));
                    _OnConsumeSyncWaiter.Item2.WaitOne();
                    _OnConsumeSyncWaiter.Item2.Dispose();
                }
            }
        }
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        private void ValidateAccessRights(AccessRightsType rights)
        {
            if (!_accessrights.HasFlag(rights))
                throw new InvalidOperationException($"{rights} access flag not set");
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        void BuildConsumers()
        {
            _consumerConfig ??= ConsumerConfigBuilder.Create().WithEnableAutoCommit(true)
                                                  .WithAutoOffsetReset(ConsumerConfigBuilder.AutoOffsetResetTypes.EARLIEST)
                                                  .WithAllowAutoCreateTopics(false);

            ConsumerConfig.BootstrapServers = BootstrapServers;
            ConsumerConfig.GroupId = GroupId;
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

            _assignmentWaiters = new ManualResetEvent[_partitions];
            _lastPartitionLags = new long[_partitions];
            _consumers = new KNetConsumer<TKey, TValue>[_partitions];

            for (int i = 0; i < _partitions; i++)
            {
                _assignmentWaiters[i] = new ManualResetEvent(false);
                _lastPartitionLags[i] = -1;
                _consumers[i] = new KNetConsumer<TKey, TValue>(ConsumerConfig, KeySerDes, ValueSerDes);
                _consumers[i].SetCallback(OnMessage);
            }
            _consumerListener = new ConsumerRebalanceListener()
            {
                OnOnPartitionsRevoked = OnTopicPartitionsRevoked,
                OnOnPartitionsAssigned = OnTopicPartitionsAssigned,
                OnOnPartitionsLost = OnTopicPartitionsLost
            };
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        void BuildOnTheFlyConsumer()
        {
            if (_onTheFlyConsumer == null)
            {
                ConsumerConfigBuilder consumerConfigBuilder = ConsumerConfigBuilder.CreateFrom(_consumerConfig);
                consumerConfigBuilder.WithEnableAutoCommit(false).WithGroupId(Guid.NewGuid().ToString());

                _onTheFlyConsumer = new KNetConsumer<TKey, TValue>(consumerConfigBuilder, KeySerDes, ValueSerDes);
            }
        }
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        void BuildProducer()
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

        void ConsumerPollHandler(object o)
        {
            int index = (int)o;
            _consumers[index].Subscribe(Collections.Singleton(StateName), _consumerListener);
            while (_consumerPollRun)
            {
                try
                {
                    _consumers[index].ConsumeAsync(100);
                    if (_assignmentWaiters[index].WaitOne(0))
                    {
                        try
                        {
                            var lag = _consumers[index].CurrentLag(new TopicPartition(StateName, index));
                            Interlocked.Exchange(ref _lastPartitionLags[index], lag.IsPresent() ? lag.AsLong : -1);
                        }
                        catch (Java.Lang.IllegalStateException)
                        {
                            Interlocked.Exchange(ref _lastPartitionLags[index], -1);
                        }
                    }
                }
                catch { }
            }
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
                                                            .WithSegmentMs(100)
                                                            .WithRetentionBytes(1073741824);

                TopicConfig.CleanupPolicy = TopicConfigBuilder.CleanupPolicyTypes.Compact | TopicConfigBuilder.CleanupPolicyTypes.Delete;
                topic = topic.Configs(TopicConfig);
                try
                {
                    _admin.CreateTopic(topic);
                }
                catch (TopicExistsException)
                {
                    // recover partitions of the topic
                    try
                    {
                        var result = _admin.DescribeTopics(Collections.Singleton(StateName));
                        if (result != null)
                        {
                            var map = result.AllTopicNames().Get();
                            if (map != null)
                            {
                                var topicDesc = map.Get(StateName);
                                _partitions = topicDesc.Partitions().Size();
                            }
                        }
                    }
                    catch
                    {

                    }
                }
            }

            if (AccessRights.HasFlag(AccessRightsType.Read))
            {
                BuildConsumers();
            }

            if (AccessRights.HasFlag(AccessRightsType.Write))
            {
                BuildProducer();
            }

            if (_consumers != null)
            {
                _consumerPollRun = true;
                _consumerPollThreads = new Thread[_partitions];
                for (int i = 0; i < _partitions; i++)
                {
                    _consumerPollThreads[i] = new Thread(ConsumerPollHandler);
                    _consumerPollThreads[i].Start(i);
                }
            }

            _started = true;
        }


        /// <summary>
        /// Start this <see cref="KNetCompactedReplicator{TKey, TValue}"/>: create the <see cref="StateName"/> topic if not available, allocates Producer and Consumers, sets serializer/deserializer
        /// Then waits its synchronization with <see cref="StateName"/> topic which stores dictionary data
        /// </summary>
        /// <exception cref="InvalidOperationException">Some errors occurred or the provided <see cref="AccessRights"/> do not include the <see cref="AccessRightsType.Read"/> flag</exception>
        public void StartAndWait(int timeout = Timeout.Infinite)
        {
            ValidateAccessRights(AccessRightsType.Read);
            Start();
            WaitForStateAssignment(timeout);
            SyncWait(timeout);
        }

        /// <summary>
        /// Waits for all paritions assignment of the <see cref="StateName"/> topic which stores dictionary data
        /// </summary>
        /// <param name="timeout">The number of milliseconds to wait, or <see cref="Timeout.Infinite"/> to wait indefinitely</param>
        /// <returns><see langword="true"/> if the current instance receives a signal within the given <paramref name="timeout"/>; otherwise, <see langword="false"/></returns>
        /// <exception cref="InvalidOperationException">The provided <see cref="AccessRights"/> do not include the <see cref="AccessRightsType.Read"/> flag</exception>
        public bool WaitForStateAssignment(int timeout = Timeout.Infinite)
        {
            ValidateAccessRights(AccessRightsType.Read);
            return WaitHandle.WaitAll(_assignmentWaiters, timeout);
        }
        /// <summary>
        /// Waits that <see cref="KNetCompactedReplicator{TKey, TValue}"/> is synchronized to the <see cref="StateName"/> topic which stores dictionary data
        /// </summary>
        /// <param name="timeout">The number of milliseconds to wait, or <see cref="Timeout.Infinite"/> to wait indefinitely</param>
        /// <returns><see langword="true"/> if the current instance synchronize within the given <paramref name="timeout"/>; otherwise, <see langword="false"/></returns>
        /// <exception cref="InvalidOperationException">The provided <see cref="AccessRights"/> do not include the <see cref="AccessRightsType.Read"/> flag</exception>
        public void SyncWait(int timeout = Timeout.Infinite)
        {
            ValidateAccessRights(AccessRightsType.Read);
            Stopwatch watcher = Stopwatch.StartNew();
            bool sync = false;
            while (!sync && watcher.ElapsedMilliseconds < (uint)timeout)
            {
                for (int i = 0; i < _partitions; i++)
                {
                    sync = _consumers[i].IsEmpty && (Interlocked.Read(ref _lastPartitionLags[i]) == 0 || Interlocked.Read(ref _lastPartitionLags[i]) == -1) ;
                }
            }
        }

        /// <summary>
        /// Waits until all outstanding produce requests and delivery report callbacks are completed
        /// </summary>
        public void Flush()
        {
            ValidateAccessRights(AccessRightsType.Write);
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
            get
            {
                ValidateAccessRights(AccessRightsType.Read);
                BuildOnTheFlyConsumer();
                if (!new LocalDataStorageEnumerator(_dictionary, _onTheFlyConsumer, StateName).TryGetValue(key, out var data))
                {
                    throw new IndexOutOfRangeException($"Key {key} not available locally");
                }
                return data;
            }
            set { AddOrUpdate(key, value); }
        }

        /// <summary>
        /// Gets an <see cref="System.Collections.Generic.ICollection{TKey}"/> containing the keys of this <see cref="KNetCompactedReplicator{TKey, TValue}"/>
        /// </summary>
        /// <returns><see cref="System.Collections.Generic.ICollection{TKey}"/> containing the keys of this <see cref="KNetCompactedReplicator{TKey, TValue}"/></returns>
        /// <exception cref="InvalidOperationException">The provided <see cref="AccessRights"/> do not include the <see cref="AccessRightsType.Read"/> flag</exception>
        public System.Collections.Generic.ICollection<TKey> Keys
        {
            get
            {
                ValidateAccessRights(AccessRightsType.Read);
                return _dictionary.Keys;
            }
        }

        /// <summary>
        /// Gets an <see cref="System.Collections.Generic.ICollection{TValue}"/> containing the values of this <see cref="KNetCompactedReplicator{TKey, TValue}"/>
        /// </summary>
        /// <returns><see cref="System.Collections.Generic.ICollection{TValue}"/> containing the values of this <see cref="KNetCompactedReplicator{TKey, TValue}"/></returns>
        /// <exception cref="InvalidOperationException">The provided <see cref="AccessRights"/> do not include the <see cref="AccessRightsType.Read"/> flag</exception>
        public System.Collections.Generic.ICollection<TValue> Values
        {
            get
            {
                ValidateAccessRights(AccessRightsType.Read);
                BuildOnTheFlyConsumer();
                return new LocalDataStorageEnumerator(_dictionary, _onTheFlyConsumer, StateName).Values();
            }
        }

        /// <summary>
        /// Gets the number of elements contained in this <see cref="KNetCompactedReplicator{TKey, TValue}"/>
        /// </summary>
        /// <returns>The number of elements contained in this <see cref="KNetCompactedReplicator{TKey, TValue}"/></returns>
        /// <exception cref="InvalidOperationException">The provided <see cref="AccessRights"/> do not include the <see cref="AccessRightsType.Read"/> flag</exception>
        public int Count
        {
            get
            {
                ValidateAccessRights(AccessRightsType.Read);
                return _dictionary.Count;
            }
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
        /// Clears this <see cref="KNetCompactedReplicator{TKey, TValue}"/>, resetting all partitions' sync
        /// </summary>
        /// <exception cref="InvalidOperationException">The provided <see cref="AccessRights"/> do not include the <see cref="AccessRightsType.Read"/> flag</exception>
        public void Clear()
        {
            ValidateAccessRights(AccessRightsType.Write);
            _dictionary.Clear();
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
            ValidateAccessRights(AccessRightsType.Read);
            BuildOnTheFlyConsumer();
            return new LocalDataStorageEnumerator(_dictionary, _onTheFlyConsumer, StateName).Contains(item);
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
            ValidateAccessRights(AccessRightsType.Read);
            return _dictionary.ContainsKey(key);
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
            ValidateAccessRights(AccessRightsType.Read);
            BuildOnTheFlyConsumer();
            new LocalDataStorageEnumerator(_dictionary, _onTheFlyConsumer, StateName).CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Returns an enumerator that iterates through this <see cref="KNetCompactedReplicator{TKey, TValue}"/>
        /// </summary>
        /// <returns>An enumerator for this <see cref="KNetCompactedReplicator{TKey, TValue}"/></returns>
        /// <exception cref="InvalidOperationException">The provided <see cref="AccessRights"/> do not include the <see cref="AccessRightsType.Read"/> flag</exception>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            ValidateAccessRights(AccessRightsType.Read);
            BuildOnTheFlyConsumer();
            return new LocalDataStorageEnumerator(_dictionary, _onTheFlyConsumer, StateName);
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
        public bool TryGetValue(TKey key, out TValue value)
        {
            ValidateAccessRights(AccessRightsType.Read);
            BuildOnTheFlyConsumer();
            return new LocalDataStorageEnumerator(_dictionary, _onTheFlyConsumer, StateName).TryGetValue(key, out value);
        }

        /// <exception cref="InvalidOperationException">The provided <see cref="AccessRights"/> do not include the <see cref="AccessRightsType.Read"/> flag</exception>
        IEnumerator IEnumerable.GetEnumerator()
        {
            ValidateAccessRights(AccessRightsType.Read);
            BuildOnTheFlyConsumer();
            return new LocalDataStorageEnumerator(_dictionary, _onTheFlyConsumer, StateName);
        }

        #endregion

        #region IDisposable

        /// <summary>
        /// Release all managed and unmanaged resources
        /// </summary>
        public void Dispose()
        {
            _consumerPollRun = false;

            if (_consumers != null)
            {
                foreach (var item in _consumers)
                {
                    item?.Dispose();
                }
            }

            _producer?.Flush();
            _producer?.Dispose();

            if (_assignmentWaiters != null)
            {
                foreach (var item in _assignmentWaiters)
                {
                    item?.Close();
                }
            }
        }

        #endregion
    }
    #endregion
}
