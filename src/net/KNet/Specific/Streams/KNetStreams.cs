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

using MASES.KNet.Serialization;
using MASES.KNet.Streams.Processor;
using MASES.KNet.Streams.State;
using System;

namespace MASES.KNet.Streams
{
    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.KafkaStreams"/>
    /// </summary>
    public class KNetStreams : IGenericSerDesFactoryApplier
    {
        readonly Org.Apache.Kafka.Streams.KafkaStreams _inner;
        readonly KNetClientSupplier _supplier = null; // used to avoid GC recall
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        Org.Apache.Kafka.Streams.Processor.StateRestoreListener _stateRestoreListener; // used to avoid GC recall
        Org.Apache.Kafka.Streams.KafkaStreams.StateListener _stateListener; // used to avoid GC recall
        Org.Apache.Kafka.Streams.Errors.StreamsUncaughtExceptionHandler _streamsUncaughtExceptionHandler; // used to avoid GC recall

        #region Constructors
        /// <summary>
        /// KNet override of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#org.apache.kafka.streams.KafkaStreams(KNetTopology,java.util.Properties,org.apache.kafka.common.utils.Time)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Topology"/></param>
        /// <param name="arg1"><see cref="Java.Util.Properties"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Common.Utils.Time"/></param>
        public KNetStreams(Topology arg0, StreamsConfigBuilder arg1, Org.Apache.Kafka.Common.Utils.Time arg2)
        {
            _inner = new Org.Apache.Kafka.Streams.KafkaStreams(arg0, PrepareProperties(arg1), arg2);
            _factory = arg1;
        }
        /// <summary>
        /// KNet override of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#org.apache.kafka.streams.KafkaStreams(KNetTopology,java.util.Properties,KNetClientSupplier,org.apache.kafka.common.utils.Time)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Topology"/></param>
        /// <param name="arg1"><see cref="Java.Util.Properties"/></param>
        /// <param name="arg2"><see cref="KNetClientSupplier"/></param>
        /// <param name="arg3"><see cref="Org.Apache.Kafka.Common.Utils.Time"/></param>
        public KNetStreams(Topology arg0, StreamsConfigBuilder arg1, KNetClientSupplier arg2, Org.Apache.Kafka.Common.Utils.Time arg3)
        {
            _inner = new Org.Apache.Kafka.Streams.KafkaStreams(arg0, PrepareProperties(arg1), arg2, arg3);
            _factory = arg1;
            _supplier = arg2;
        }
        /// <summary>
        /// KNet override of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#org.apache.kafka.streams.KafkaStreams(KNetTopology,java.util.Properties,KNetClientSupplier)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Topology"/></param>
        /// <param name="arg1"><see cref="Java.Util.Properties"/></param>
        /// <param name="arg2"><see cref="KNetClientSupplier"/></param>
        public KNetStreams(Topology arg0, StreamsConfigBuilder arg1, KNetClientSupplier arg2)
        {
            _inner = new Org.Apache.Kafka.Streams.KafkaStreams(arg0, PrepareProperties(arg1), arg2);
            _factory = arg1;
            _supplier = arg2;
        }
        /// <summary>
        /// KNet override of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#org.apache.kafka.streams.KafkaStreams(KNetTopology,java.util.Properties)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Topology"/></param>
        /// <param name="arg1"><see cref="Java.Util.Properties"/></param>
        public KNetStreams(Topology arg0, StreamsConfigBuilder arg1)
        {
            _inner = new Org.Apache.Kafka.Streams.KafkaStreams(arg0, PrepareProperties(arg1));
            _factory = arg1;
        }
        #endregion

        /// <summary>
        /// Converter from <see cref="KNetStreams"/> to <see cref="Org.Apache.Kafka.Streams.KafkaStreams"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.KafkaStreams(KNetStreams t) => t._inner;
        /// <summary>
        /// If set, this <see cref="Func{T, TResult}"/> will be called from <see cref="PrepareProperties(StreamsConfigBuilder)"/>
        /// </summary>
        public static Func<StreamsConfigBuilder, Java.Util.Properties> OverrideProperties { get; set; }
        /// <summary>
        /// Override this method to check and modify the <see cref="Java.Util.Properties"/> returned to underlying <see cref="Org.Apache.Kafka.Streams.KafkaStreams"/>
        /// </summary>
        /// <param name="builder"><see cref="StreamsConfigBuilder"/> to use to return <see cref="Java.Util.Properties"/></param>
        /// <returns><see cref="Java.Util.Properties"/> used from underlying <see cref="Org.Apache.Kafka.Streams.KafkaStreams"/></returns>
        protected virtual Java.Util.Properties PrepareProperties(StreamsConfigBuilder builder)
        {
            return OverrideProperties != null ? OverrideProperties(builder) : builder;
        }

        #region Instance methods
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#queryMetadataForKey-java.lang.String-java.lang.Object-org.apache.kafka.common.serialization.Serializer-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><typeparamref name="TKey"/></param>
        /// <param name="arg2"><see cref="ISerializer{T, TJVMK}"/></param>
        /// <typeparam name="TKey"></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.KeyQueryMetadata"/></returns>
        public Org.Apache.Kafka.Streams.KeyQueryMetadata QueryMetadataForKey<TKey>(string arg0, TKey arg1, ISerializer<TKey, byte[]> arg2)
        {
            return _inner.QueryMetadataForKey<byte[]>(arg0, arg2.Serialize(null, arg1), arg2.KafkaSerializer);
        }
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#queryMetadataForKey-java.lang.String-java.lang.Object-org.apache.kafka.streams.processor.StreamPartitioner-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><typeparamref name="TKey"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Processor.StreamPartitioner"/></param>
        /// <typeparam name="TKey">The key type</typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.KeyQueryMetadata"/></returns>
        public Org.Apache.Kafka.Streams.KeyQueryMetadata QueryMetadataForKey<TKey>(string arg0, TKey arg1, StreamPartitioner<TKey, object> arg2)
        {
            if (arg2 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            var keySerDes = _factory?.BuildKeySerDes<TKey, byte[]>();
            return _inner.IExecute<Org.Apache.Kafka.Streams.KeyQueryMetadata>("queryMetadataForKey", arg0, keySerDes.Serialize(null, arg1), arg2);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#query-org.apache.kafka.streams.query.StateQueryRequest-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Query.StateQueryRequest{R}"/></param>
        /// <typeparam name="R"></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Query.StateQueryResult{R}"/></returns>
        public Org.Apache.Kafka.Streams.Query.StateQueryResult<R> Query<R>(Org.Apache.Kafka.Streams.Query.StateQueryRequest<R> arg0)
        {
            return _inner.Query(arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#store-org.apache.kafka.streams.StoreQueryParameters-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.StoreQueryParameters"/></param>
        /// <typeparam name="TKNetManagedStore"></typeparam>
        /// <typeparam name="TStore"></typeparam>
        /// <returns><typeparamref name="TKNetManagedStore"/></returns>
        public TKNetManagedStore Store<TKNetManagedStore, TStore>(Org.Apache.Kafka.Streams.StoreQueryParameters<TStore> arg0)
            where TKNetManagedStore : ManagedStore<TStore>, IGenericSerDesFactoryApplier, new()
        {
            TKNetManagedStore store = new();
            var substore = _inner.Store<TStore>(arg0);
            if (store is IManagedStore<TStore> knetManagedStore)
            {
                knetManagedStore.SetData(_factory, substore);
            }
            return store;
        }

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#store-org.apache.kafka.streams.StoreQueryParameters-"/>
        /// </summary>
        /// <param name="storageId"><see cref="Org.Apache.Kafka.Streams.StoreQueryParameters"/></param>
        /// <param name="storeType"></param>
        /// <typeparam name="TKNetManagedStore"></typeparam>
        /// <typeparam name="TStore"></typeparam>
        /// <returns><typeparamref name="TKNetManagedStore"/></returns>
        public TKNetManagedStore Store<TKNetManagedStore, TStore>(string storageId, QueryableStoreTypes.StoreType<TKNetManagedStore, TStore> storeType)
            where TKNetManagedStore : ManagedStore<TStore>, IGenericSerDesFactoryApplier, new()
        {
            var sqp = Org.Apache.Kafka.Streams.StoreQueryParameters<TStore>.FromNameAndType(storageId, storeType.Store);
            TKNetManagedStore store = new();
            var substore = _inner.Store<TStore>(sqp);
            if (store is IManagedStore<TStore> knetManagedStore)
            {
                knetManagedStore.SetData(_factory, substore);
            }
            return store;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#isPaused--"/>
        /// </summary>
        public bool IsPaused => _inner.IsPaused();
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#metadataForAllStreamsClients--"/>
        /// </summary>
        public Java.Util.Collection<Org.Apache.Kafka.Streams.StreamsMetadata> MetadataForAllStreamsClients => _inner.MetadataForAllStreamsClients();
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#streamsMetadataForStore-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="Java.Util.Collection"/></returns>
        public Java.Util.Collection<Org.Apache.Kafka.Streams.StreamsMetadata> StreamsMetadataForStore(string arg0)
        {
            return _inner.StreamsMetadataForStore(arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#allLocalStorePartitionLags--"/>
        /// </summary>
        public Java.Util.Map<Java.Lang.String, Java.Util.Map<Java.Lang.Integer, Org.Apache.Kafka.Streams.LagInfo>> AllLocalStorePartitionLags => _inner.AllLocalStorePartitionLags();
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#metrics--"/>
        /// </summary>

        /// <typeparam name="ReturnExtendsOrg_Apache_Kafka_Common_Metric"><see cref="Org.Apache.Kafka.Common.Metric"/></typeparam>
        /// <returns><see cref="Java.Util.Map"/></returns>
        public Java.Util.Map<Org.Apache.Kafka.Common.MetricName, ReturnExtendsOrg_Apache_Kafka_Common_Metric> Metrics<ReturnExtendsOrg_Apache_Kafka_Common_Metric>() where ReturnExtendsOrg_Apache_Kafka_Common_Metric : Org.Apache.Kafka.Common.Metric
        {
            return _inner.Metrics<ReturnExtendsOrg_Apache_Kafka_Common_Metric>();
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#addStreamThread--"/>
        /// </summary>
        /// <returns><see cref="Java.Util.Optional{T}"/></returns>
        public Java.Util.Optional<Java.Lang.String> AddStreamThread()
        {
            return _inner.AddStreamThread();
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#removeStreamThread--"/>
        /// </summary>
        /// <returns><see cref="Java.Util.Optional"/></returns>
        public Java.Util.Optional<Java.Lang.String> RemoveStreamThread()
        {
            return _inner.RemoveStreamThread();
        }
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#removeStreamThread-java.time.Duration-"/>
        /// </summary>
        /// <param name="arg0"><see cref="TimeSpan"/></param>
        /// <returns><see cref="Java.Lang.String"/></returns>
        public Java.Lang.String RemoveStreamThread(TimeSpan arg0)
        {
            var res = _inner.RemoveStreamThread(arg0);
            return res.IsPresent() ? res.Get() : null;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#metadataForLocalThreads--"/>
        /// </summary>
        public Java.Util.Set<Org.Apache.Kafka.Streams.ThreadMetadata> MetadataForLocalThreads => _inner.MetadataForLocalThreads();
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#state--"/>
        /// </summary>
        /// <returns><see cref="Org.Apache.Kafka.Streams.KafkaStreams.State"/></returns>
        public Org.Apache.Kafka.Streams.KafkaStreams.State State => _inner.StateMethod();
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#close-java.time.Duration-"/>
        /// </summary>
        /// <param name="arg0"><see cref="TimeSpan"/></param>
        /// <returns><see cref="bool"/></returns>
        /// <exception cref="Java.Lang.IllegalArgumentException"/>
        public bool Close(TimeSpan arg0)
        {
            return _inner.Close(arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#close-java.time.Duration-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Time.Duration"/></param>
        /// <returns><see cref="bool"/></returns>
        /// <exception cref="Java.Lang.IllegalArgumentException"/>
        public bool Close(Java.Time.Duration arg0)
        {
            return _inner.Close(arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#close-org.apache.kafka.streams.KafkaStreams.CloseOptions-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.KafkaStreams.CloseOptions"/></param>
        /// <returns><see cref="bool"/></returns>
        /// <exception cref="Java.Lang.IllegalArgumentException"/>
        public bool Close(Org.Apache.Kafka.Streams.KafkaStreams.CloseOptions arg0)
        {
            return _inner.Close(arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#start--"/>
        /// </summary>
        /// <exception cref="Java.Lang.IllegalStateException"/>
        /// <exception cref="Org.Apache.Kafka.Streams.Errors.StreamsException"/>
        public void Start()
        {
            _inner.Start();
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#cleanUp--"/>
        /// </summary>
        public void CleanUp()
        {
            _inner.CleanUp();
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#close--"/>
        /// </summary>
        public void Close()
        {
            _inner.Close();
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#pause--"/>
        /// </summary>
        public void Pause()
        {
            _inner.Pause();
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#resume--"/>
        /// </summary>
        public void Resume()
        {
            _inner.Resume();
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#setGlobalStateRestoreListener-org.apache.kafka.streams.processor.StateRestoreListener-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Processor.StateRestoreListener"/></param>
        public void SetGlobalStateRestoreListener(Org.Apache.Kafka.Streams.Processor.StateRestoreListener arg0)
        {
            _inner.SetGlobalStateRestoreListener(arg0);
            _stateRestoreListener = arg0;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#setStateListener-org.apache.kafka.streams.KafkaStreams.StateListener-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.KafkaStreams.StateListener"/></param>
        public void SetStateListener(Org.Apache.Kafka.Streams.KafkaStreams.StateListener arg0)
        {
            _inner.SetStateListener(arg0);
            _stateListener = arg0;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#setUncaughtExceptionHandler-org.apache.kafka.streams.errors.StreamsUncaughtExceptionHandler-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Errors.StreamsUncaughtExceptionHandler"/></param>
        public void SetUncaughtExceptionHandler(Org.Apache.Kafka.Streams.Errors.StreamsUncaughtExceptionHandler arg0)
        {
            _inner.SetUncaughtExceptionHandler(arg0);
            _streamsUncaughtExceptionHandler = arg0;
        }

        #endregion
    }
}
