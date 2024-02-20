/*
*  Copyright 2024 MASES s.r.l.
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

using MASES.JCOBridge.C2JBridge;
using MASES.KNet.Admin;
using MASES.KNet.Common;
using MASES.KNet.Consumer;
using MASES.KNet.Extensions;
using MASES.KNet.Producer;
using MASES.KNet.Serialization;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

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
        /// Called when a [<typeparamref name="TKey"/>, <typeparamref name="TValue"/>] is added by consuming data from the others <see cref="IKNetCompactedReplicator{TKey, TValue}"/>
        /// </summary>
        event Action<IKNetCompactedReplicator<TKey, TValue>, KeyValuePair<TKey, TValue>> OnRemoteAdd;

        /// <summary>
        /// Called when a [<typeparamref name="TKey"/>, <typeparamref name="TValue"/>] is updated by consuming data from the others <see cref="IKNetCompactedReplicator{TKey, TValue}"/>
        /// </summary>
        event Action<IKNetCompactedReplicator<TKey, TValue>, KeyValuePair<TKey, TValue>> OnRemoteUpdate;

        /// <summary>
        /// Called when a [<typeparamref name="TKey"/>, <typeparamref name="TValue"/>] is removed by consuming data from the others <see cref="IKNetCompactedReplicator{TKey, TValue}"/>
        /// </summary>
        event Action<IKNetCompactedReplicator<TKey, TValue>, KeyValuePair<TKey, TValue>> OnRemoteRemove;

        /// <summary>
        /// Called when a [<typeparamref name="TKey"/>, <typeparamref name="TValue"/>] is added on this <see cref="IKNetCompactedReplicator{TKey, TValue}"/>
        /// </summary>
        event Action<IKNetCompactedReplicator<TKey, TValue>, KeyValuePair<TKey, TValue>> OnLocalAdd;

        /// <summary>
        /// Called when a [<typeparamref name="TKey"/>, <typeparamref name="TValue"/>] is updated on this <see cref="IKNetCompactedReplicator{TKey, TValue}"/>
        /// </summary>
        event Action<IKNetCompactedReplicator<TKey, TValue>, KeyValuePair<TKey, TValue>> OnLocalUpdate;

        /// <summary>
        /// Called when a [<typeparamref name="TKey"/>, <typeparamref name="TValue"/>] is removed from this <see cref="IKNetCompactedReplicator{TKey, TValue}"/>
        /// </summary>
        event Action<IKNetCompactedReplicator<TKey, TValue>, KeyValuePair<TKey, TValue>> OnLocalRemove;

        /// <summary>
        /// It is called to request if the [<typeparamref name="TKey"/>, <typeparamref name="TValue"/>] can be stored in the <see cref="IKNetCompactedReplicator{TKey, TValue}"/> instance.
        /// </summary>
        /// <remarks>The second parameter reports the current value that depends on values set to <see cref="UpdateMode"/> and if it contains the <see cref="UpdateModeTypes.Delayed"/></remarks>
        Func<IKNetCompactedReplicator<TKey, TValue>, bool, KeyValuePair<TKey, TValue>, bool> OnDelayedStore { get; }

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
        /// Get or set the number of <see cref="KNetConsumer{K, V}"/> instances to be used, null to allocate <see cref="KNetConsumer{K, V}"/> based on <see cref="Partitions"/>
        /// </summary>
        int? ConsumerInstances { get; }
        /// <summary>
        /// Get or set replication factor to use when topic is created for the first time, otherwise reports the replication factor of the topic
        /// </summary>
        short ReplicationFactor { get; }
        /// <summary>
        /// Get or set the poll timeout to be used for <see cref="IKNetConsumer{K, V}.ConsumeAsync(long)"/>
        /// </summary>
        long ConsumePollTimeout { get; }
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
        /// The <see cref="Type"/> used to create an instance of <see cref="KeySerDes"/>"/>
        /// </summary>
        Type KNetKeySerDes { get; }
        /// <summary>
        /// Get or set an instance of <see cref="IKNetSerDes{TKey}"/> to use in <see cref="KNetCompactedReplicator{TKey, TValue}"/>, by default it creates a default one based on <typeparamref name="TKey"/>
        /// </summary>
        IKNetSerDes<TKey> KeySerDes { get; }
        /// <summary>
        /// The <see cref="Type"/> used to create an instance of <see cref="ValueSerDes"/>"/>
        /// </summary>
        Type KNetValueSerDes { get; }
        /// <summary>
        /// Get or set an instance of <see cref="IKNetSerDes{TValue}"/> to use in <see cref="KNetCompactedReplicator{TKey, TValue}"/>, by default it creates a default one based on <typeparamref name="TValue"/>
        /// </summary>
        IKNetSerDes<TValue> ValueSerDes { get; }
#if NET7_0_OR_GREATER
        /// <summary>
        /// <see langword="true"/> if enumeration will use prefetch and the number of records is more than <see cref="PrefetchThreshold"/>, i.e. the preparation of <see cref="KNetConsumerRecord{K, V}"/> happens in an external thread
        /// </summary>
        /// <remarks>It is <see langword="true"/> by default if one of <typeparamref name="TKey"/> or <typeparamref name="TValue"/> are not <see cref="ValueType"/>, override the value using <see cref="ApplyPrefetch(bool, int)"/></remarks>
        bool IsPrefecth { get; }
        /// <summary>
        /// The minimum threshold to activate pretech, i.e. the preparation of <see cref="KNetConsumerRecord{K, V}"/> happens in external thread if <see cref="Org.Apache.Kafka.Clients.Consumer.ConsumerRecords{K, V}"/> contains more than <see cref="PrefetchThreshold"/> elements
        /// </summary>
        /// <remarks>The default value is 10, however it shall be chosen by the developer and in the decision shall be verified if external thread activation costs more than inline execution</remarks>
        int PrefetchThreshold { get; }
#endif
        /// <summary>
        /// <see langword="true"/> if the instance was started
        /// </summary>
        bool IsStarted { get; }
        /// <summary>
        /// <see langword="true"/> if the instance was started
        /// </summary>
        bool IsAssigned { get; }
        /// <summary>
        /// Reports a snapshot of current lags (the value) associated to each partition (the key). 
        /// </summary>
        /// <remarks>It is only a snapshot when the property is read and cannot reflect real conditions</remarks>
        IReadOnlyDictionary<int, long> CurrentPartitionLags { get; }
        /// <summary>
        /// Reports a snapshot of current sync state the value (<see langword="true"/> means it is in sync) associated to each consumer (the key). 
        /// </summary>
        /// <remarks>It is only a snapshot when the property is read and cannot reflect real conditions</remarks>
        IReadOnlyDictionary<int, bool> CurrentConsumersSyncState { get; }
        #endregion

        #region Public methods
#if NET7_0_OR_GREATER
        /// <summary>
        /// Set to <see langword="true"/> to enable enumeration with prefetch over <paramref name="prefetchThreshold"/> threshold, i.e. preparation of <see cref="KNetConsumerRecord{K, V}"/> in external thread 
        /// </summary>
        /// <param name="enablePrefetch"><see langword="true"/> to enable prefetch. See <see cref="IsPrefecth"/></param>
        /// <param name="prefetchThreshold">The minimum threshold to activate pretech, default is 10. See <see cref="PrefetchThreshold"/></param>
        /// <remarks>Setting <paramref name="prefetchThreshold"/> to a value less, or equal, to 0 and <paramref name="enablePrefetch"/> to <see langword="true"/>, the prefetch is always actived</remarks>
        void ApplyPrefetch(bool enablePrefetch = true, int prefetchThreshold = 10);
#endif
        /// <summary>
        /// Start this <see cref="KNetCompactedReplicator{TKey, TValue}"/>: create the <see cref="StateName"/> topic if not available, allocates Producer and Consumer, sets serializer/deserializer
        /// </summary>
        /// <exception cref="InvalidOperationException">Some errors occurred</exception>
        void Start();
        /// <summary>
        /// Start this <see cref="KNetCompactedReplicator{TKey, TValue}"/>: create the <see cref="StateName"/> topic if not available, allocates Producer and Consumers, sets serializer/deserializer
        /// Then waits its synchronization with <see cref="StateName"/> topic which stores dictionary data
        /// </summary>
        /// <param name="timeout">The number of milliseconds to wait, or <see cref="Timeout.Infinite"/> to wait indefinitely</param>
        /// <returns><see langword="true"/> if the current instance synchronize within the given <paramref name="timeout"/>; otherwise, <see langword="false"/></returns>
        /// <exception cref="InvalidOperationException">Some errors occurred or the provided <see cref="AccessRights"/> do not include the <see cref="AccessRightsType.Read"/> flag</exception>
        bool StartAndWait(int timeout = Timeout.Infinite);
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
        bool SyncWait(int timeout = Timeout.Infinite);
        /// <summary>
        /// Waits until all outstanding produce requests and delivery report callbacks are completed
        /// </summary>
        void Flush();
        /// <summary>
        /// Reports the <see cref="KNetProducer{TKey, TValue}"/> metrics. <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/KafkaProducer.html#metrics--"/>
        /// </summary>
        /// <typeparam name="TMetric">Extends <see cref="Org.Apache.Kafka.Common.Metric"/></typeparam>
        /// <returns>A <see cref="Java.Util.Map"/> of <see cref="Org.Apache.Kafka.Common.MetricName"/> and <typeparamref name="TMetric"/></returns>
        Java.Util.Map<Org.Apache.Kafka.Common.MetricName, TMetric> ProducerMetrics<TMetric>() where TMetric : Org.Apache.Kafka.Common.Metric;
        /// <summary>
        /// Reports the <see cref="KNetConsumer{TKey, TValue}"/> metrics. <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/KafkaProducer.html#metrics--"/>
        /// </summary>
        /// <typeparam name="TMetric">Extends <see cref="Org.Apache.Kafka.Common.Metric"/></typeparam>
        /// <returns>An <see cref="IReadOnlyDictionary{T, V}"/> where the key is the current allocated <see cref="KNetConsumer{TKey, TValue}"/> and value is a <see cref="Java.Util.Map"/> of <see cref="Org.Apache.Kafka.Common.MetricName"/> and <typeparamref name="TMetric"/></returns>
        IReadOnlyDictionary<int, Java.Util.Map<Org.Apache.Kafka.Common.MetricName, TMetric>> ConsumerMetrics<TMetric>() where TMetric : Org.Apache.Kafka.Common.Metric;
        #endregion
    }

    #endregion

    #region KNetCompactedReplicator<TKey, TValue>
    /// <summary>
    /// Provides a reliable dictionary, persisted in a COMPACTED Kafka topic and shared among applications
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the dictionary. Must be a nullable type</typeparam>
    public class KNetCompactedReplicator<TKey, TValue> : IKNetCompactedReplicator<TKey, TValue>
        where TValue : class
    {
        const long InitialLagState = -2;
        const long NotPresentLagState = -1;
        const long InvalidLagState = -3;

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
                while (this.MoveNext())
                {
                    values.Add(this.Current.Value);
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
                if (this.TryGetValue(item.Key, out var data))
                {
                    return data == item.Value;
                }
                return false;
            }

            public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
            {
                var values = new System.Collections.Generic.List<KeyValuePair<TKey, TValue>>();
                while (this.MoveNext())
                {
                    values.Add(new KeyValuePair<TKey, TValue>(this.Current.Key, this.Current.Value));
                }

                Array.Copy(values.ToArray(), 0, array, arrayIndex, values.Count);
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
            static void OnDemandRetrieve(IKNetConsumer<TKey, TValue> consumer, string topic, TKey key, ILocalDataStorage data)
            {
                var topicPartition = new Org.Apache.Kafka.Common.TopicPartition(topic, data.Partition);
                var topics = Java.Util.Collections.SingletonList(topicPartition);
                try
                {
                    consumer.Assign(topics);
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
                finally
                {
                    topicPartition?.Dispose();
                    topics?.Dispose();
                }
            }
        }

        #endregion

        #region KNetCompactedConsumerRebalanceListener

        class KNetCompactedConsumerRebalanceListener : Org.Apache.Kafka.Clients.Consumer.ConsumerRebalanceListener
        {
            int _consumerIndex;
            public KNetCompactedConsumerRebalanceListener(int consumerIndex)
                : base()
            {
                _consumerIndex = consumerIndex;
            }

            public int ConsumerIndex => _consumerIndex;

            public new System.Action<KNetCompactedConsumerRebalanceListener, Java.Util.Collection<Org.Apache.Kafka.Common.TopicPartition>> OnOnPartitionsAssigned { get; set; }

            public override void OnPartitionsAssigned(Java.Util.Collection<Org.Apache.Kafka.Common.TopicPartition> arg0)
            {
                OnOnPartitionsAssigned?.Invoke(this, arg0);
            }

            public new System.Action<KNetCompactedConsumerRebalanceListener, Java.Util.Collection<Org.Apache.Kafka.Common.TopicPartition>> OnOnPartitionsRevoked { get; set; }

            public override void OnPartitionsRevoked(Java.Util.Collection<Org.Apache.Kafka.Common.TopicPartition> arg0)
            {
                OnOnPartitionsRevoked?.Invoke(this, arg0);
            }

            public new System.Action<KNetCompactedConsumerRebalanceListener, Java.Util.Collection<Org.Apache.Kafka.Common.TopicPartition>> OnOnPartitionsLost { get; set; }

            public override void OnPartitionsLost(Java.Util.Collection<Org.Apache.Kafka.Common.TopicPartition> arg0)
            {
                OnOnPartitionsLost?.Invoke(this, arg0);
            }
        }

        #endregion

        #region Private members

        private bool _consumerPollRun = false;
        private Thread[] _consumerPollThreads = null;
        private ManualResetEvent[] _consumerPollThreadWaiter = null;
        private ConcurrentDictionary<TKey, ILocalDataStorage> _dictionary = new ConcurrentDictionary<TKey, ILocalDataStorage>();
        private KNetCompactedConsumerRebalanceListener[] _consumerListeners = null;
        private IKNetConsumer<TKey, TValue>[] _consumers = null;
        private IKNetConsumer<TKey, TValue> _onTheFlyConsumer = null;
        private IKNetProducer<TKey, TValue> _producer = null;
        private string _bootstrapServers = null;
        private string _stateName = string.Empty;
        private string _groupId = Guid.NewGuid().ToString();
        private int _partitions = 1;
        private int? _consumerInstances = null;
        private short _replicationFactor = 1;
        private long _consumePollTimeout = 10;
        private TopicConfigBuilder _topicConfig = null;
        private ConsumerConfigBuilder _consumerConfig = null;
        private ProducerConfigBuilder _producerConfig = null;
        private Func<IKNetCompactedReplicator<TKey, TValue>, bool, KeyValuePair<TKey, TValue>, bool> _onDelayedStore = null;
        private AccessRightsType _accessrights = AccessRightsType.ReadWrite;
        private UpdateModeTypes _updateMode = UpdateModeTypes.OnDelivery;
        private Tuple<TKey, ManualResetEvent> _OnConsumeSyncWaiter = null;
        private System.Collections.Generic.Dictionary<int, System.Collections.Generic.IList<int>> _consumerAssociatedPartition = new();
        private ManualResetEvent[] _assignmentWaiters;
        private bool[] _assignmentWaitersStatus;
        private long[] _lastPartitionLags = null;

        private Type _KNetKeySerDes = null;
        private IKNetSerDes<TKey> _keySerDes = null;
        private bool _disposeKeySerDes = false;
        private Type _KNetValueSerDes = null;
        private IKNetSerDes<TValue> _valueSerDes = null;
        private bool _disposeValueSerDes = false;

        private bool _started = false;

        #endregion

        #region Events

        /// <inheritdoc cref="IKNetCompactedReplicator{TKey, TValue}.OnRemoteAdd"/>
        public event Action<IKNetCompactedReplicator<TKey, TValue>, KeyValuePair<TKey, TValue>> OnRemoteAdd;

        /// <inheritdoc cref="IKNetCompactedReplicator{TKey, TValue}.OnRemoteUpdate"/>
        public event Action<IKNetCompactedReplicator<TKey, TValue>, KeyValuePair<TKey, TValue>> OnRemoteUpdate;

        /// <inheritdoc cref="IKNetCompactedReplicator{TKey, TValue}.OnRemoteRemove"/>
        public event Action<IKNetCompactedReplicator<TKey, TValue>, KeyValuePair<TKey, TValue>> OnRemoteRemove;

        /// <inheritdoc cref="IKNetCompactedReplicator{TKey, TValue}.OnLocalAdd"/>
        public event Action<IKNetCompactedReplicator<TKey, TValue>, KeyValuePair<TKey, TValue>> OnLocalAdd;

        /// <inheritdoc cref="IKNetCompactedReplicator{TKey, TValue}.OnLocalUpdate"/>
        public event Action<IKNetCompactedReplicator<TKey, TValue>, KeyValuePair<TKey, TValue>> OnLocalUpdate;

        /// <inheritdoc cref="IKNetCompactedReplicator{TKey, TValue}.OnLocalRemove"/>
        public event Action<IKNetCompactedReplicator<TKey, TValue>, KeyValuePair<TKey, TValue>> OnLocalRemove;

        /// <inheritdoc cref="IKNetCompactedReplicator{TKey, TValue}.OnDelayedStore"/>
        public Func<IKNetCompactedReplicator<TKey, TValue>, bool, KeyValuePair<TKey, TValue>, bool> OnDelayedStore
        {
            get { return _onDelayedStore; }
            set { CheckStarted(); _onDelayedStore = value; }
        }

        #endregion

        #region Public Properties
        /// <inheritdoc cref="IKNetCompactedReplicator{TKey, TValue}.AccessRights"/>
        public AccessRightsType AccessRights { get { return _accessrights; } set { CheckStarted(); _accessrights = value; } }

        /// <inheritdoc cref="IKNetCompactedReplicator{TKey, TValue}.UpdateMode"/>
        public UpdateModeTypes UpdateMode { get { return _updateMode; } set { CheckStarted(); _updateMode = value; } }

        /// <inheritdoc cref="IKNetCompactedReplicator{TKey, TValue}.BootstrapServers"/>
        public string BootstrapServers { get { return _bootstrapServers; } set { CheckStarted(); _bootstrapServers = value; } }

        /// <inheritdoc cref="IKNetCompactedReplicator{TKey, TValue}.StateName"/>
        public string StateName { get { return _stateName; } set { CheckStarted(); _stateName = value; } }

        /// <inheritdoc cref="IKNetCompactedReplicator{TKey, TValue}.GroupId"/>
        public string GroupId { get { return _groupId; } set { CheckStarted(); _groupId = value; } }

        /// <inheritdoc cref="IKNetCompactedReplicator{TKey, TValue}.Partitions"/>
        public int Partitions { get { return _partitions; } set { CheckStarted(); _partitions = value; } }

        /// <inheritdoc cref="IKNetCompactedReplicator{TKey, TValue}.ConsumerInstances"/>
        public int? ConsumerInstances { get { return _consumerInstances.HasValue ? _consumerInstances.Value : _partitions; } set { CheckStarted(); _consumerInstances = value; } }

        /// <inheritdoc cref="IKNetCompactedReplicator{TKey, TValue}.ReplicationFactor"/>
        public short ReplicationFactor { get { return _replicationFactor; } set { CheckStarted(); _replicationFactor = value; } }

        /// <inheritdoc cref="IKNetCompactedReplicator{TKey, TValue}.ConsumePollTimeout"/>
        public long ConsumePollTimeout { get { return _consumePollTimeout; } set { CheckStarted(); _consumePollTimeout = value; } }

        /// <inheritdoc cref="IKNetCompactedReplicator{TKey, TValue}.TopicConfig"/>
        public TopicConfigBuilder TopicConfig { get { return _topicConfig; } set { CheckStarted(); _topicConfig = value; } }

        /// <inheritdoc cref="IKNetCompactedReplicator{TKey, TValue}.ConsumerConfig"/>
        public ConsumerConfigBuilder ConsumerConfig { get { return _consumerConfig; } set { CheckStarted(); _consumerConfig = value; } }

        /// <inheritdoc cref="IKNetCompactedReplicator{TKey, TValue}.ProducerConfig"/>
        public ProducerConfigBuilder ProducerConfig { get { return _producerConfig; } set { CheckStarted(); _producerConfig = value; } }

        /// <inheritdoc cref="IKNetCompactedReplicator{TKey, TValue}.KNetKeySerDes"/>
        public Type KNetKeySerDes
        {
            get { return _KNetKeySerDes; }
            set
            {
                CheckStarted();
                if (value.GetConstructors().Single(ci => ci.GetParameters().Length == 0) == null)
                {
                    throw new ArgumentException($"{value.Name} does not contains a default constructor and cannot be used because it is not a valid Serializer type");
                }

                if (value.IsGenericType)
                {
                    var keyT = value.GetGenericArguments();
                    if (keyT.Length != 1) { throw new ArgumentException($"{value.Name} does not contains a single generic argument and cannot be used because it is not a valid Serializer type"); }
                    var t = value.GetGenericTypeDefinition();
                    if (t.GetInterface(typeof(IKNetSerDes<>).Name) == null)
                    {
                        throw new ArgumentException($"{value.Name} does not implement IKNetSerDes<> and cannot be used because it is not a valid Serializer type");
                    }
                    _KNetKeySerDes = value;
                }
                else throw new ArgumentException($"{value.Name} is not a generic type and cannot be used as a valid ValueContainer type");
            }
        }

        /// <inheritdoc cref="IKNetCompactedReplicator{TKey, TValue}.KeySerDes"/>
        public IKNetSerDes<TKey> KeySerDes { get { return _keySerDes; } set { CheckStarted(); _keySerDes = value; } }

        /// <inheritdoc cref="IKNetCompactedReplicator{TKey, TValue}.KNetValueSerDes"/>
        public Type KNetValueSerDes
        {
            get { return _KNetValueSerDes; }
            set
            {
                CheckStarted();
                if (value.GetConstructors().Single(ci => ci.GetParameters().Length == 0) == null)
                {
                    throw new ArgumentException($"{value.Name} does not contains a default constructor and cannot be used because it is not a valid Serializer type");
                }

                if (value.IsGenericType)
                {
                    var keyT = value.GetGenericArguments();
                    if (keyT.Length != 1) { throw new ArgumentException($"{value.Name} does not contains a single generic argument and cannot be used because it is not a valid Serializer type"); }
                    var t = value.GetGenericTypeDefinition();
                    if (t.GetInterface(typeof(IKNetSerDes<>).Name) == null)
                    {
                        throw new ArgumentException($"{value.Name} does not implement IKNetSerDes<> and cannot be used because it is not a valid Serializer type");
                    }
                    _KNetValueSerDes = value;
                }
                else throw new ArgumentException($"{value.Name} is not a generic type and cannot be used as a valid Serializer type");
            }
        }

        /// <inheritdoc cref="IKNetCompactedReplicator{TKey, TValue}.ValueSerDes"/>
        public IKNetSerDes<TValue> ValueSerDes { get { return _valueSerDes; } set { CheckStarted(); _valueSerDes = value; } }
#if NET7_0_OR_GREATER
        /// <inheritdoc cref="IKNetCompactedReplicator{TKey, TValue}.IsPrefecth"/>
        public bool IsPrefecth { get; private set; } = !(typeof(TKey).IsValueType && typeof(TValue).IsValueType);

        /// <inheritdoc cref="IKNetCompactedReplicator{TKey, TValue}.PrefetchThreshold"/>
        public int PrefetchThreshold { get; private set; } = 10;
#endif
        /// <inheritdoc cref="IKNetCompactedReplicator{TKey, TValue}.IsStarted"/>
        public bool IsStarted => _started;

        /// <inheritdoc cref="IKNetCompactedReplicator{TKey, TValue}.IsAssigned"/>
        public bool IsAssigned => _assignmentWaiters.All((o) => o.WaitOne(0));

        /// <inheritdoc cref="IKNetCompactedReplicator{TKey, TValue}.CurrentPartitionLags"/>
        public IReadOnlyDictionary<int, long> CurrentPartitionLags
        {
            get
            {
                ValidateStarted();
                var dict = new System.Collections.Generic.Dictionary<int, long>();
                for (int i = 0; i < _lastPartitionLags.Length; i++)
                {
                    dict.Add(i, Interlocked.Read(ref _lastPartitionLags[i]));
                }
                return dict;
            }
        }

        /// <inheritdoc cref="IKNetCompactedReplicator{TKey, TValue}.CurrentConsumersSyncState"/>
        public IReadOnlyDictionary<int, bool> CurrentConsumersSyncState
        {
            get
            {
                ValidateStarted();
                var dict = new System.Collections.Generic.Dictionary<int, bool>();
                for (int i = 0; i < ConsumersToAllocate(); i++)
                {
                    dict.Add(i, CheckConsumerSyncState(i));
                }
                return dict;
            }
        }

        #endregion

        #region Private methods

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        void CheckStarted()
        {
            if (_started) throw new InvalidOperationException("Cannot be changed after Start");
        }
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        int ConsumersToAllocate()
        {
            return ConsumerInstances.HasValue ? ConsumerInstances.Value : Partitions;
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
                bool containsKey = true;
                ILocalDataStorage data;
                if (!_dictionary.TryGetValue(record.Key, out data))
                {
                    containsKey = false;
                    data = new LocalDataStorage();
                    _dictionary[record.Key] = data;
                }
                lock (data.Lock)
                {
                    data.Partition = record.Partition;
                    data.HasOffset = true;
                    data.Offset = record.Offset;
                    bool storeValue = UpdateModeDelayed ? false : true;
                    if (OnDelayedStore != null)
                    {
                        storeValue = OnDelayedStore.Invoke(this, storeValue, new KeyValuePair<TKey, TValue>(record.Key, record.Value));
                    }
                    if (storeValue)
                    {
                        data.HasValue = true;
                        data.Value = record.Value;
                    }
                }
                if (containsKey)
                {
                    OnRemoteUpdate?.Invoke(this, new KeyValuePair<TKey, TValue>(record.Key, record.Value));
                }
                else
                {
                    OnRemoteAdd?.Invoke(this, new KeyValuePair<TKey, TValue>(record.Key, record.Value));
                }
            }

            if (_OnConsumeSyncWaiter != null)
            {
                if (_OnConsumeSyncWaiter.Item1.Equals(record.Key))
                {
                    _OnConsumeSyncWaiter.Item2.Set();
                }
            }
        }

        private void OnTopicPartitionsAssigned(KNetCompactedConsumerRebalanceListener listener, Java.Util.Collection<Org.Apache.Kafka.Common.TopicPartition> topicPartitions)
        {
            foreach (var topicPartition in topicPartitions)
            {
                var partition = topicPartition.Partition();
                lock (_consumerAssociatedPartition)
                {
                    _consumerAssociatedPartition[listener.ConsumerIndex].Add(partition);
                }
                if (!_assignmentWaiters[partition].SafeWaitHandle.IsClosed)
                {
                    lock (_assignmentWaitersStatus) { _assignmentWaitersStatus[partition] = true; }
                    _assignmentWaiters[partition].Set();
                }
            }
        }

        private void OnTopicPartitionsRevoked(KNetCompactedConsumerRebalanceListener listener, Java.Util.Collection<Org.Apache.Kafka.Common.TopicPartition> topicPartitions)
        {
            foreach (var topicPartition in topicPartitions)
            {
                var partition = topicPartition.Partition();
                lock (_consumerAssociatedPartition)
                {
                    _consumerAssociatedPartition[listener.ConsumerIndex].Remove(partition);
                }
                if (!_assignmentWaiters[partition].SafeWaitHandle.IsClosed)
                {
                    lock (_assignmentWaitersStatus) { _assignmentWaitersStatus[partition] = false; }
                    _assignmentWaiters[partition].Reset();
                }
            }
        }

        private void OnTopicPartitionsLost(KNetCompactedConsumerRebalanceListener listener, Java.Util.Collection<Org.Apache.Kafka.Common.TopicPartition> topicPartitions)
        {
            foreach (var topicPartition in topicPartitions)
            {
                var partition = topicPartition.Partition();
                lock (_consumerAssociatedPartition)
                {
                    _consumerAssociatedPartition[listener.ConsumerIndex].Remove(partition);
                }
                if (!_assignmentWaiters[partition].SafeWaitHandle.IsClosed)
                {
                    lock (_assignmentWaitersStatus) { _assignmentWaitersStatus[partition] = false; }
                    _assignmentWaiters[partition].Reset();
                }
            }
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        private void AddOrUpdate(TKey key, TValue value)
        {
            ValidateAccessRights(AccessRightsType.Write);
            ValidateStarted();

            if (key == null)
                throw new ArgumentNullException(nameof(key));

            if (UpdateModeOnDelivery)
            {
                Org.Apache.Kafka.Clients.Producer.RecordMetadata metadata = null;
                JVMBridgeException exception = null;
                DateTime pTimestamp = DateTime.MaxValue;
                using (AutoResetEvent deliverySemaphore = new AutoResetEvent(false))
                {
                    using (Org.Apache.Kafka.Clients.Producer.Callback cb = new Org.Apache.Kafka.Clients.Producer.Callback()
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
                    bool containsKey = true;
                    ILocalDataStorage data;
                    if (!_dictionary.TryGetValue(key, out data))
                    {
                        containsKey = false;
                        data = new LocalDataStorage();
                        _dictionary[key] = data;
                    }
                    lock (data.Lock)
                    {
                        data.Partition = metadata.Partition();
                        data.HasOffset = metadata.HasOffset();
                        data.Offset = metadata.Offset();
                        bool storeValue = UpdateModeDelayed ? false : true;
                        if (OnDelayedStore != null)
                        {
                            storeValue = OnDelayedStore.Invoke(this, storeValue, new KeyValuePair<TKey, TValue>(key, value));
                        }
                        if (storeValue)
                        {
                            data.HasValue = true;
                            data.Value = value;
                        }
                    }
                    if (containsKey)
                    {
                        OnLocalUpdate?.Invoke(this, new KeyValuePair<TKey, TValue>(key, value));
                    }
                    else
                    {
                        OnLocalAdd?.Invoke(this, new KeyValuePair<TKey, TValue>(key, value));
                    }
                }
            }
            else if (UpdateModeOnConsume || UpdateModeOnConsumeSync)
            {
                _producer.Produce(StateName, key, value, (Org.Apache.Kafka.Clients.Producer.Callback)null);
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
        private void ValidateStarted()
        {
            if (!IsStarted)
                throw new InvalidOperationException("The instance was not started");
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        void BuildConsumers()
        {
            _consumerConfig ??= ConsumerConfigBuilder.Create()
                                                     .WithEnableAutoCommit(true)
                                                     .WithAutoOffsetReset(ConsumerConfigBuilder.AutoOffsetResetTypes.EARLIEST)
                                                     .WithAllowAutoCreateTopics(false);

            ConsumerConfig.BootstrapServers = BootstrapServers;
            if (!ConsumerConfig.ExistProperty(Org.Apache.Kafka.Clients.CommonClientConfigs.GROUP_ID_CONFIG))
            {
                ConsumerConfig.GroupId = GroupId;
            }

            if (KNetKeySerDes != null)
            {
                ConsumerConfig.KNetKeySerDes = KNetKeySerDes;
            }
            else if (KeySerDes == null) throw new InvalidOperationException($"{typeof(TKey)} needs an external deserializer, set KNetKeySerDes or KeySerDes.");

            if (KNetValueSerDes != null)
            {
                ConsumerConfig.KNetValueSerDes = KNetValueSerDes;
            }
            else if (ValueSerDes == null) throw new InvalidOperationException($"{typeof(TValue)} needs an external deserializer, set KNetValueSerDes or ValueSerDes.");

            _assignmentWaiters = new ManualResetEvent[Partitions];
            _assignmentWaitersStatus = new bool[Partitions];
            _lastPartitionLags = new long[Partitions];
            _consumers = new KNetConsumer<TKey, TValue>[ConsumersToAllocate()];
            _consumerListeners = new KNetCompactedConsumerRebalanceListener[ConsumersToAllocate()];

            for (int i = 0; i < Partitions; i++)
            {
                _lastPartitionLags[i] = InitialLagState;
                _assignmentWaiters[i] = new ManualResetEvent(false);
                _assignmentWaitersStatus[i] = false;
            }

            for (int i = 0; i < ConsumersToAllocate(); i++)
            {
                _consumerAssociatedPartition.Add(i, new System.Collections.Generic.List<int>());
                _consumers[i] = (KNetKeySerDes != null || KNetValueSerDes != null) ? new KNetConsumer<TKey, TValue>(ConsumerConfig) : new KNetConsumer<TKey, TValue>(ConsumerConfig, KeySerDes, ValueSerDes);
#if NET7_0_OR_GREATER
                _consumers[i].ApplyPrefetch(IsPrefecth, PrefetchThreshold);
#endif
                _consumers[i].SetCallback(OnMessage);
                _consumerListeners[i] = new KNetCompactedConsumerRebalanceListener(i)
                {
                    OnOnPartitionsRevoked = OnTopicPartitionsRevoked,
                    OnOnPartitionsAssigned = OnTopicPartitionsAssigned,
                    OnOnPartitionsLost = OnTopicPartitionsLost
                };
            }
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        void BuildOnTheFlyConsumer()
        {
            if (_onTheFlyConsumer == null)
            {
                ConsumerConfigBuilder consumerConfigBuilder = ConsumerConfigBuilder.CreateFrom(_consumerConfig);
                consumerConfigBuilder.WithEnableAutoCommit(false).WithGroupId(Guid.NewGuid().ToString());

                _onTheFlyConsumer = (KNetKeySerDes != null || KNetValueSerDes != null) ? new KNetConsumer<TKey, TValue>(consumerConfigBuilder) : new KNetConsumer<TKey, TValue>(consumerConfigBuilder, KeySerDes, ValueSerDes);
            }
        }
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        void BuildProducer()
        {
            _producerConfig ??= ProducerConfigBuilder.Create().WithAcks(ProducerConfigBuilder.AcksTypes.All)
                                                              .WithRetries(0)
                                                              .WithLingerMs(1);

            ProducerConfig.BootstrapServers = BootstrapServers;

            if (KNetKeySerDes != null)
            {
                ProducerConfig.KNetKeySerDes = KNetKeySerDes;
            }
            else if (KeySerDes == null) throw new InvalidOperationException($"{typeof(TKey)} needs an external serializer, set KNetKeySerDes or KeySerDes.");

            if (KNetValueSerDes != null)
            {
                ProducerConfig.KNetValueSerDes = KNetValueSerDes;
            }
            else if (ValueSerDes == null) throw new InvalidOperationException($"{typeof(TValue)} needs an external serializer, set KNetValueSerDes or ValueSerDes.");

            _producer = (KNetKeySerDes != null || KNetValueSerDes != null) ? new KNetProducer<TKey, TValue>(ProducerConfig) : new KNetProducer<TKey, TValue>(ProducerConfig, KeySerDes, ValueSerDes);
        }

        void ConsumerPollHandler(object o)
        {
            bool firstExecution = false;
            int index = (int)o;
            var topics = Java.Util.Collections.Singleton((Java.Lang.String)StateName);
            try
            {
                _consumers[index].Subscribe(topics, _consumerListeners[index]);
                _consumerPollThreadWaiter[index].Set();
                while (_consumerPollRun)
                {
                    try
                    {
                        _consumers[index].ConsumeAsync(ConsumePollTimeout);
                        if (!firstExecution) { _consumers[index].GroupMetadata(); firstExecution = true; }
                        lock (_consumerAssociatedPartition)
                        {
                            foreach (var partitionIndex in _consumerAssociatedPartition[index])
                            {
                                bool execute = false;
                                if (_assignmentWaiters[partitionIndex].SafeWaitHandle.IsClosed) continue;
                                else execute = _assignmentWaitersStatus[partitionIndex];
                                if (execute)
                                {
                                    try
                                    {
                                        var lag = _consumers[index].CurrentLag(new Org.Apache.Kafka.Common.TopicPartition(StateName, partitionIndex));
                                        Interlocked.Exchange(ref _lastPartitionLags[partitionIndex], lag.IsPresent() ? lag.AsLong : NotPresentLagState);
                                    }
                                    catch (Java.Lang.IllegalStateException)
                                    {
                                        Interlocked.Exchange(ref _lastPartitionLags[partitionIndex], InvalidLagState);
                                    }
                                }
                            }
                        }
                    }
                    catch (Org.Apache.Kafka.Common.Errors.WakeupException) { return; }
                    catch { }
                }
            }
            catch { }
            finally
            {
                _consumers[index].Unsubscribe();
                topics?.Dispose();
            }
        }
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        bool CheckConsumerSyncState(int index)
        {
            bool lagInSync = true;
            foreach (var partitionIndex in _consumerAssociatedPartition[index])
            {
                var partitionLag = Interlocked.Read(ref _lastPartitionLags[partitionIndex]);
                lagInSync &= partitionLag == 0;
            }
            return _consumers[index].IsEmpty && !_consumers[index].IsCompleting && lagInSync;
        }

#endregion

        #region Public methods
#if NET7_0_OR_GREATER
        /// <inheritdoc cref="IKNetCompactedReplicator{TKey, TValue}.ApplyPrefetch(bool, int)"/>
        public void ApplyPrefetch(bool enablePrefetch = true, int prefetchThreshold = 10)
        {
            IsPrefecth = enablePrefetch;
            PrefetchThreshold = IsPrefecth ? prefetchThreshold : 10;
        }
#endif
        /// <inheritdoc cref="IKNetCompactedReplicator{TKey, TValue}.Start"/>
        public void Start()
        {
            if (string.IsNullOrWhiteSpace(BootstrapServers)) throw new InvalidOperationException("BootstrapServers must be set before start.");
            if (string.IsNullOrWhiteSpace(StateName)) throw new InvalidOperationException("StateName must be set before start.");

            if (KNetKeySerDes != null && KeySerDes != null) { throw new InvalidOperationException($"Set only one of {nameof(KNetKeySerDes)} or {nameof(KeySerDes)}."); }
            if (KNetValueSerDes != null && ValueSerDes != null) { throw new InvalidOperationException($"Set only one of {nameof(KNetValueSerDes)} or {nameof(ValueSerDes)}."); }

            if (ConsumerInstances > Partitions) throw new InvalidOperationException("ConsumerInstances cannot be high than Partitions");

            using Java.Util.Properties props = AdminClientConfigBuilder.Create().WithBootstrapServers(BootstrapServers).ToProperties();
            using var admin = Org.Apache.Kafka.Clients.Admin.KafkaAdminClient.Create(props);

            if (AccessRights.HasFlag(AccessRightsType.Write))
            {
                var topic = new Org.Apache.Kafka.Clients.Admin.NewTopic(StateName, Partitions, ReplicationFactor);
                _topicConfig ??= TopicConfigBuilder.Create().WithDeleteRetentionMs(100)
                                                            .WithMinCleanableDirtyRatio(0.01)
                                                            .WithSegmentMs(100)
                                                            .WithRetentionBytes(1073741824);

                TopicConfig.CleanupPolicy = TopicConfigBuilder.CleanupPolicyTypes.Compact | TopicConfigBuilder.CleanupPolicyTypes.Delete;
                topic = topic.Configs(TopicConfig);
                try
                {
                    admin.CreateTopic(topic);
                }
                catch (Org.Apache.Kafka.Common.Errors.TopicExistsException)
                {
                    var topics = Java.Util.Collections.Singleton((Java.Lang.String)StateName);
                    // recover partitions of the topic
                    try
                    {
                        var result = admin.DescribeTopics(topics);
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
                    catch { }
                    finally { topics?.Dispose(); }
                }
                finally { topic?.Dispose(); }
            }
            _disposeKeySerDes = false;
            if (KNetKeySerDes == null && KeySerDes == null && KNetSerialization.IsInternalManaged<TKey>())
            {
                KeySerDes = new KNetSerDes<TKey>();
                _disposeKeySerDes = true;
            }
            _disposeValueSerDes = false;
            if (KNetValueSerDes == null && ValueSerDes == null && KNetSerialization.IsInternalManaged<TValue>())
            {
                ValueSerDes = new KNetSerDes<TValue>();
                _disposeValueSerDes = true;
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
                _consumerPollThreads = new Thread[ConsumersToAllocate()];
                _consumerPollThreadWaiter = new ManualResetEvent[ConsumersToAllocate()];
                for (int i = 0; i < ConsumersToAllocate(); i++)
                {
                    _consumerPollThreadWaiter[i] = new ManualResetEvent(false);
                    _consumerPollThreads[i] = new Thread(ConsumerPollHandler);
                    _consumerPollThreads[i].Start(i);
                }
                if (WaitHandle.WaitAll(_consumerPollThreadWaiter))
                {
                    for (int i = 0; i < _consumerPollThreadWaiter.Length; i++)
                    {
                        _consumerPollThreadWaiter[i].Dispose();
                        _consumerPollThreadWaiter[i] = null;
                    }
                    _consumerPollThreadWaiter = null;
                }
            }

            _started = true;
        }

        /// <inheritdoc cref="IKNetCompactedReplicator{TKey, TValue}.StartAndWait(int)"/>
        public bool StartAndWait(int timeout = Timeout.Infinite)
        {
            ValidateAccessRights(AccessRightsType.Read);
            Start();
            WaitForStateAssignment(timeout);
            return SyncWait(timeout);
        }

        /// <inheritdoc cref="IKNetCompactedReplicator{TKey, TValue}.WaitForStateAssignment(int)"/>
        public bool WaitForStateAssignment(int timeout = Timeout.Infinite)
        {
            ValidateAccessRights(AccessRightsType.Read);
            ValidateStarted();
            bool status = false;
            do
            {
                if (WaitHandle.WaitAll(_assignmentWaiters, timeout))
                {
                    status = _assignmentWaitersStatus.All((o) => o == true);
                }
                else break;
            }
            while (!status);
            return status;
        }

        /// <inheritdoc cref="IKNetCompactedReplicator{TKey, TValue}.SyncWait(int)"/>
        public bool SyncWait(int timeout = Timeout.Infinite)
        {
            ValidateAccessRights(AccessRightsType.Read);
            ValidateStarted();
            Stopwatch watcher = Stopwatch.StartNew();
            bool sync = false;
            while (!sync && watcher.ElapsedMilliseconds < (uint)timeout)
            {
                bool[] syncs = new bool[ConsumersToAllocate()];
                for (int i = 0; i < ConsumersToAllocate(); i++)
                {
                    syncs[i] = CheckConsumerSyncState(i);
                }
                sync = syncs.All(x => x == true);
            }
            return sync;
        }

        /// <inheritdoc cref="IKNetCompactedReplicator{TKey, TValue}.Flush"/>
        public void Flush()
        {
            ValidateAccessRights(AccessRightsType.Write);
            ValidateStarted();
            _producer?.Flush();
        }

        /// <inheritdoc cref="IKNetCompactedReplicator{TKey, TValue}.ProducerMetrics{TMetric}"/>
        public Java.Util.Map<Org.Apache.Kafka.Common.MetricName, TMetric> ProducerMetrics<TMetric>() where TMetric : Org.Apache.Kafka.Common.Metric
        {
            ValidateStarted();
            return _producer.Metrics<TMetric>();
        }
        /// <inheritdoc cref="IKNetCompactedReplicator{TKey, TValue}.ConsumerMetrics{TMetric}"/>
        public IReadOnlyDictionary<int, Java.Util.Map<Org.Apache.Kafka.Common.MetricName, TMetric>> ConsumerMetrics<TMetric>() where TMetric : Org.Apache.Kafka.Common.Metric
        {
            ValidateStarted();
            var dict = new System.Collections.Generic.Dictionary<int, Java.Util.Map<Org.Apache.Kafka.Common.MetricName, TMetric>>();

            for (int i = 0; i < ConsumersToAllocate(); i++)
            {
                dict.Add(i, _consumers[i].Metrics<TMetric>());
            }

            return dict;
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
                ValidateStarted();
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
                ValidateStarted();
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
                ValidateStarted();
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
                ValidateStarted();
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
            ValidateStarted();
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
            ValidateStarted();
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
            ValidateStarted();
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
            ValidateStarted();
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
            ValidateStarted();
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
            ValidateStarted();
            BuildOnTheFlyConsumer();
            return new LocalDataStorageEnumerator(_dictionary, _onTheFlyConsumer, StateName).TryGetValue(key, out value);
        }

        /// <exception cref="InvalidOperationException">The provided <see cref="AccessRights"/> do not include the <see cref="AccessRightsType.Read"/> flag</exception>
        IEnumerator IEnumerable.GetEnumerator()
        {
            ValidateAccessRights(AccessRightsType.Read);
            ValidateStarted();
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

            foreach (var consumerPollThread in _consumerPollThreads)
            {
                consumerPollThread.Join();
            }

            if (_consumers != null)
            {
                foreach (var item in _consumers)
                {
                    item?.Dispose();
                }
            }

            _onTheFlyConsumer?.Dispose();

            _producer?.Flush();
            _producer?.Dispose();

            if (_assignmentWaiters != null)
            {
                foreach (var item in _assignmentWaiters)
                {
                    lock (item)
                    {
                        item?.Close();
                    }
                }
            }

            _started = false;

            if (_disposeKeySerDes)
            {
                KeySerDes?.Dispose();
                KeySerDes = null;
            }

            if (_disposeValueSerDes)
            {
                ValueSerDes?.Dispose();
                ValueSerDes = null;
            }
        }

        #endregion

        #region Object methods
        /// <inheritdoc cref="object.ToString"/>
        public override string ToString()
        {
            System.Text.StringBuilder stringBuilder = new();
            for (int i = 0; i < _lastPartitionLags.Length; i++)
            {
                stringBuilder.AppendFormat("P{0}: {1} ", i, Interlocked.Read(ref _lastPartitionLags[i]));
            }

            return $"StateName: {StateName} - Current elements: {Count} - Consumers: {ConsumersToAllocate()} - Partitions: {Partitions} - Lags: {stringBuilder.ToString()}";
        }

        #endregion
    }
#endregion
}
