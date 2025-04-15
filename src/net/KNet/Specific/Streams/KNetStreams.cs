/*
*  Copyright 2025 MASES s.r.l.
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
        Org.Apache.Kafka.Streams.Processor.StandbyUpdateListener _standbyUpdateListener; // used to avoid GC recall
        Org.Apache.Kafka.Streams.KafkaStreams.StateListener _stateListener; // used to avoid GC recall
        Org.Apache.Kafka.Streams.Errors.StreamsUncaughtExceptionHandler _streamsUncaughtExceptionHandler; // used to avoid GC recall

        #region Constructors
        /// <summary>
        /// KNet override of <see cref="Org.Apache.Kafka.Streams.KafkaStreams.KafkaStreams(Org.Apache.Kafka.Streams.Topology, Java.Util.Properties, Org.Apache.Kafka.Common.Utils.Time)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Topology"/></param>
        /// <param name="arg1"><see cref="StreamsConfigBuilder"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Common.Utils.Time"/></param>
        public KNetStreams(Topology arg0, StreamsConfigBuilder arg1, Org.Apache.Kafka.Common.Utils.Time arg2)
        {
            _inner = new Org.Apache.Kafka.Streams.KafkaStreams(arg0, PrepareProperties(arg1), arg2);
            _factory = arg1;
        }
        /// <summary>
        /// KNet override of <see cref="Org.Apache.Kafka.Streams.KafkaStreams.KafkaStreams(Org.Apache.Kafka.Streams.Topology, Java.Util.Properties, Org.Apache.Kafka.Streams.KafkaClientSupplier, Org.Apache.Kafka.Common.Utils.Time)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Topology"/></param>
        /// <param name="arg1"><see cref="StreamsConfigBuilder"/></param>
        /// <param name="arg2"><see cref="KNetClientSupplier"/></param>
        /// <param name="arg3"><see cref="Org.Apache.Kafka.Common.Utils.Time"/></param>
        public KNetStreams(Topology arg0, StreamsConfigBuilder arg1, KNetClientSupplier arg2, Org.Apache.Kafka.Common.Utils.Time arg3)
        {
            _inner = new Org.Apache.Kafka.Streams.KafkaStreams(arg0, PrepareProperties(arg1), arg2, arg3);
            _factory = arg1;
            _supplier = arg2;
        }
        /// <summary>
        /// KNet override of <see cref="Org.Apache.Kafka.Streams.KafkaStreams.KafkaStreams(Org.Apache.Kafka.Streams.Topology, Java.Util.Properties, Org.Apache.Kafka.Streams.KafkaClientSupplier)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Topology"/></param>
        /// <param name="arg1"><see cref="StreamsConfigBuilder"/></param>
        /// <param name="arg2"><see cref="KNetClientSupplier"/></param>
        public KNetStreams(Topology arg0, StreamsConfigBuilder arg1, KNetClientSupplier arg2)
        {
            _inner = new Org.Apache.Kafka.Streams.KafkaStreams(arg0, PrepareProperties(arg1), arg2);
            _factory = arg1;
            _supplier = arg2;
        }
        /// <summary>
        /// KNet override of <see cref="Org.Apache.Kafka.Streams.KafkaStreams.KafkaStreams(Org.Apache.Kafka.Streams.Topology, Java.Util.Properties)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Topology"/></param>
        /// <param name="arg1"><see cref="StreamsConfigBuilder"/></param>
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
        /// <inheritdoc cref="Org.Apache.Kafka.Streams.KafkaStreams.QueryMetadataForKey{K}(Java.Lang.String, K, Org.Apache.Kafka.Common.Serialization.Serializer{K})"/>
        public Org.Apache.Kafka.Streams.KeyQueryMetadata QueryMetadataForKey<K, TJVMK>(string arg0, K arg1, ISerializer<K, TJVMK> arg2)
        {
            return _inner.QueryMetadataForKey<TJVMK>(arg0, arg2.Serialize(null, arg1), arg2.KafkaSerializer);
        }
        /// <inheritdoc cref="Org.Apache.Kafka.Streams.KafkaStreams.QueryMetadataForKey{K}(Java.Lang.String, K, Org.Apache.Kafka.Common.Serialization.Serializer{K})"/>
        public Org.Apache.Kafka.Streams.KeyQueryMetadata QueryMetadataForKey<K>(string arg0, K arg1, ISerializer<K, byte[]> arg2)
        {
            return QueryMetadataForKey<K, byte[]>(arg0, arg1, arg2);
        }
        /// <inheritdoc cref="Org.Apache.Kafka.Streams.KafkaStreams.QueryMetadataForKey{K, Arg2objectSuperK}(Java.Lang.String, K, Org.Apache.Kafka.Streams.Processor.StreamPartitioner{Arg2objectSuperK, object})"/>
        public Org.Apache.Kafka.Streams.KeyQueryMetadata QueryMetadataForKey<K, TJVMK>(string arg0, K arg1, StreamPartitioner<K, object> arg2)
        {
            if (arg2 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            var keySerDes = _factory?.BuildKeySerDes<K, TJVMK>();
            return _inner.IExecute<Org.Apache.Kafka.Streams.KeyQueryMetadata>("queryMetadataForKey", arg0, keySerDes.Serialize(null, arg1), arg2);
        }
        /// <inheritdoc cref="Org.Apache.Kafka.Streams.KafkaStreams.QueryMetadataForKey{K}(Java.Lang.String, K, Org.Apache.Kafka.Common.Serialization.Serializer{K})"/>
        public Org.Apache.Kafka.Streams.KeyQueryMetadata QueryMetadataForKey<K>(string arg0, K arg1, StreamPartitioner<K, object> arg2)
        {
            return QueryMetadataForKey<K, byte[]>(arg0, arg1, arg2);
        }
        /// <inheritdoc cref="Org.Apache.Kafka.Streams.KafkaStreams.Query{R}(Org.Apache.Kafka.Streams.Query.StateQueryRequest{R})"/>
        public Org.Apache.Kafka.Streams.Query.StateQueryResult<R> Query<R>(Org.Apache.Kafka.Streams.Query.StateQueryRequest<R> arg0)
        {
            return _inner.Query(arg0);
        }
        /// <inheritdoc cref="Org.Apache.Kafka.Streams.KafkaStreams.Store{T}(Org.Apache.Kafka.Streams.StoreQueryParameters{T})"/>
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

        /// <inheritdoc cref="Org.Apache.Kafka.Streams.KafkaStreams.Store{T}(Org.Apache.Kafka.Streams.StoreQueryParameters{T})"/>
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
        /// <inheritdoc cref="Org.Apache.Kafka.Streams.KafkaStreams.IsPaused"/>
        public bool IsPaused => _inner.IsPaused();
        /// <inheritdoc cref="Org.Apache.Kafka.Streams.KafkaStreams.MetadataForAllStreamsClients"/>
        public Java.Util.Collection<Org.Apache.Kafka.Streams.StreamsMetadata> MetadataForAllStreamsClients => _inner.MetadataForAllStreamsClients();
        /// <inheritdoc cref="Org.Apache.Kafka.Streams.KafkaStreams.StreamsMetadataForStore(Java.Lang.String)"/>
        public Java.Util.Collection<Org.Apache.Kafka.Streams.StreamsMetadata> StreamsMetadataForStore(string arg0)
        {
            return _inner.StreamsMetadataForStore(arg0);
        }
        /// <inheritdoc cref="Org.Apache.Kafka.Streams.KafkaStreams.AllLocalStorePartitionLags"/>
        public Java.Util.Map<Java.Lang.String, Java.Util.Map<Java.Lang.Integer, Org.Apache.Kafka.Streams.LagInfo>> AllLocalStorePartitionLags => _inner.AllLocalStorePartitionLags();
        /// <inheritdoc cref="Org.Apache.Kafka.Streams.KafkaStreams.Metrics{ReturnExtendsOrg_Apache_Kafka_Common_Metric}"/>
        public Java.Util.Map<Org.Apache.Kafka.Common.MetricName, ReturnExtendsOrg_Apache_Kafka_Common_Metric> Metrics<ReturnExtendsOrg_Apache_Kafka_Common_Metric>() where ReturnExtendsOrg_Apache_Kafka_Common_Metric : Org.Apache.Kafka.Common.Metric
        {
            return _inner.Metrics<ReturnExtendsOrg_Apache_Kafka_Common_Metric>();
        }
        /// <inheritdoc cref="Org.Apache.Kafka.Streams.KafkaStreams.AddStreamThread"/>
        public Java.Util.Optional<Java.Lang.String> AddStreamThread()
        {
            return _inner.AddStreamThread();
        }
        /// <inheritdoc cref="Org.Apache.Kafka.Streams.KafkaStreams.RemoveStreamThread()"/>
        public Java.Util.Optional<Java.Lang.String> RemoveStreamThread()
        {
            return _inner.RemoveStreamThread();
        }
        /// <inheritdoc cref="Org.Apache.Kafka.Streams.KafkaStreams.RemoveStreamThread(Java.Time.Duration)"/>
        public Java.Lang.String RemoveStreamThread(TimeSpan arg0)
        {
            var res = _inner.RemoveStreamThread(arg0);
            return res.IsPresent() ? res.Get() : null;
        }
        /// <inheritdoc cref="Org.Apache.Kafka.Streams.KafkaStreams.MetadataForLocalThreads"/>
        public Java.Util.Set<Org.Apache.Kafka.Streams.ThreadMetadata> MetadataForLocalThreads => _inner.MetadataForLocalThreads();
        /// <inheritdoc cref="Org.Apache.Kafka.Streams.KafkaStreams.StateMethod"/>
        public Org.Apache.Kafka.Streams.KafkaStreams.State State => _inner.StateMethod();
        /// <inheritdoc cref="Org.Apache.Kafka.Streams.KafkaStreams.Close()"/>
        public bool Close(TimeSpan arg0)
        {
            return _inner.Close(arg0);
        }
        /// <inheritdoc cref="Org.Apache.Kafka.Streams.KafkaStreams.Close(Java.Time.Duration)"/>
        public bool Close(Java.Time.Duration arg0)
        {
            return _inner.Close(arg0);
        }
        /// <inheritdoc cref="Org.Apache.Kafka.Streams.KafkaStreams.Close(Org.Apache.Kafka.Streams.KafkaStreams.CloseOptions)"/>
        public bool Close(Org.Apache.Kafka.Streams.KafkaStreams.CloseOptions arg0)
        {
            return _inner.Close(arg0);
        }
        /// <inheritdoc cref="Org.Apache.Kafka.Streams.KafkaStreams.ClientInstanceIds(Java.Time.Duration)"/>
        public Org.Apache.Kafka.Streams.ClientInstanceIds ClientInstanceIds(Java.Time.Duration arg0)
        {
            return _inner.ClientInstanceIds(arg0);
        }
        /// <inheritdoc cref="Org.Apache.Kafka.Streams.KafkaStreams.Start"/>
        public void Start()
        {
            _inner.Start();
        }
        /// <inheritdoc cref="Org.Apache.Kafka.Streams.KafkaStreams.CleanUp"/>
        public void CleanUp()
        {
            _inner.CleanUp();
        }
        /// <inheritdoc cref="Org.Apache.Kafka.Streams.KafkaStreams.Close()"/>
        public void Close()
        {
            _inner.Close();
        }
        /// <inheritdoc cref="Org.Apache.Kafka.Streams.KafkaStreams.Pause"/>
        public void Pause()
        {
            _inner.Pause();
        }
        /// <inheritdoc cref="Org.Apache.Kafka.Streams.KafkaStreams.Resume"/>
        public void Resume()
        {
            _inner.Resume();
        }
        /// <inheritdoc cref="Org.Apache.Kafka.Streams.KafkaStreams.SetGlobalStateRestoreListener(Org.Apache.Kafka.Streams.Processor.StateRestoreListener)"/>
        public void SetGlobalStateRestoreListener(Org.Apache.Kafka.Streams.Processor.StateRestoreListener arg0)
        {
            _inner.SetGlobalStateRestoreListener(arg0);
            _stateRestoreListener = arg0;
        }
        /// <inheritdoc cref="Org.Apache.Kafka.Streams.KafkaStreams.SetStandbyUpdateListener(Org.Apache.Kafka.Streams.Processor.StandbyUpdateListener)"/>
        public void SetStandbyUpdateListener(Org.Apache.Kafka.Streams.Processor.StandbyUpdateListener arg0)
        {
            _inner.SetStandbyUpdateListener(arg0);
            _standbyUpdateListener = arg0;
        }
        /// <inheritdoc cref="Org.Apache.Kafka.Streams.KafkaStreams.SetStateListener(Org.Apache.Kafka.Streams.KafkaStreams.StateListener)"/>
        public void SetStateListener(Org.Apache.Kafka.Streams.KafkaStreams.StateListener arg0)
        {
            _inner.SetStateListener(arg0);
            _stateListener = arg0;
        }
        /// <inheritdoc cref="Org.Apache.Kafka.Streams.KafkaStreams.SetUncaughtExceptionHandler(Org.Apache.Kafka.Streams.Errors.StreamsUncaughtExceptionHandler)"/>
        public void SetUncaughtExceptionHandler(Org.Apache.Kafka.Streams.Errors.StreamsUncaughtExceptionHandler arg0)
        {
            _inner.SetUncaughtExceptionHandler(arg0);
            _streamsUncaughtExceptionHandler = arg0;
        }

        #endregion
    }
}
