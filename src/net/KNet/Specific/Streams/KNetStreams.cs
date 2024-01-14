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

using MASES.KNet.Serialization;
using MASES.KNet.Streams.Processor;
using MASES.KNet.Streams.State;
using System;

namespace MASES.KNet.Streams
{
    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.KafkaStreams"/>
    /// </summary>
    public class KNetStreams : Org.Apache.Kafka.Streams.KafkaStreams, IGenericSerDesFactoryApplier
    {
        readonly KNetClientSupplier _supplier = null; // used to avoid GC recall
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        Org.Apache.Kafka.Streams.Processor.StateRestoreListener _stateRestoreListener;
        StateListener _stateListener;
        Org.Apache.Kafka.Streams.Errors.StreamsUncaughtExceptionHandler _streamsUncaughtExceptionHandler;

        #region Constructors
        /// <inheritdoc/>
        public KNetStreams() : base() { }
        /// <inheritdoc/>
        public KNetStreams(params object[] args) : base(args) { }
        /// <summary>
        /// KNet override of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#org.apache.kafka.streams.KafkaStreams(KNetTopology,java.util.Properties,org.apache.kafka.common.utils.Time)"/>
        /// </summary>
        /// <param name="arg0"><see cref="KNetTopology"/></param>
        /// <param name="arg1"><see cref="Java.Util.Properties"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Common.Utils.Time"/></param>
        public KNetStreams(KNetTopology arg0, StreamsConfigBuilder arg1, Org.Apache.Kafka.Common.Utils.Time arg2)
            : base(arg0, arg1, arg2)
        {
            _factory = arg1;
        }
        /// <summary>
        /// KNet override of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#org.apache.kafka.streams.KafkaStreams(KNetTopology,java.util.Properties,KNetClientSupplier,org.apache.kafka.common.utils.Time)"/>
        /// </summary>
        /// <param name="arg0"><see cref="KNetTopology"/></param>
        /// <param name="arg1"><see cref="Java.Util.Properties"/></param>
        /// <param name="arg2"><see cref="KNetClientSupplier"/></param>
        /// <param name="arg3"><see cref="Org.Apache.Kafka.Common.Utils.Time"/></param>
        public KNetStreams(KNetTopology arg0, StreamsConfigBuilder arg1, KNetClientSupplier arg2, Org.Apache.Kafka.Common.Utils.Time arg3)
            : base(arg0, arg1, arg2, arg3)
        {
            _factory = arg1;
            _supplier = arg2;
        }
        /// <summary>
        /// KNet override of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#org.apache.kafka.streams.KafkaStreams(KNetTopology,java.util.Properties,KNetClientSupplier)"/>
        /// </summary>
        /// <param name="arg0"><see cref="KNetTopology"/></param>
        /// <param name="arg1"><see cref="Java.Util.Properties"/></param>
        /// <param name="arg2"><see cref="KNetClientSupplier"/></param>
        public KNetStreams(KNetTopology arg0, StreamsConfigBuilder arg1, KNetClientSupplier arg2)
            : base(arg0, arg1, arg2)
        {
            _factory = arg1;
            _supplier = arg2;
        }
        /// <summary>
        /// KNet override of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#org.apache.kafka.streams.KafkaStreams(KNetTopology,java.util.Properties)"/>
        /// </summary>
        /// <param name="arg0"><see cref="KNetTopology"/></param>
        /// <param name="arg1"><see cref="Java.Util.Properties"/></param>
        public KNetStreams(KNetTopology arg0, StreamsConfigBuilder arg1)
            : base(arg0, arg1)
        {
            _factory = arg1;
        }
        #endregion

        #region Instance methods
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#queryMetadataForKey-java.lang.String-java.lang.Object-org.apache.kafka.common.serialization.Serializer-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><typeparamref name="TKey"/></param>
        /// <param name="arg2"><see cref="IKNetSerializer{T}"/></param>
        /// <typeparam name="TKey"></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.KeyQueryMetadata"/></returns>
        public Org.Apache.Kafka.Streams.KeyQueryMetadata QueryMetadataForKey<TKey>(string arg0, TKey arg1, IKNetSerializer<TKey> arg2)
        {
            return QueryMetadataForKey<byte[]>(arg0, arg2.Serialize(null, arg1), arg2.KafkaSerializer);
        }
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#queryMetadataForKey-java.lang.String-java.lang.Object-org.apache.kafka.streams.processor.StreamPartitioner-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><typeparamref name="TKey"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Processor.StreamPartitioner"/></param>
        /// <typeparam name="TKey">The key type</typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.KeyQueryMetadata"/></returns>
        public Org.Apache.Kafka.Streams.KeyQueryMetadata QueryMetadataForKey<TKey>(string arg0, TKey arg1, KNetStreamPartitioner<TKey, object> arg2)
        {
            if (arg2 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            var keySerDes = _factory.BuildKeySerDes<TKey>();
            return IExecute<Org.Apache.Kafka.Streams.KeyQueryMetadata>("queryMetadataForKey", arg0, keySerDes.Serialize(null, arg1), arg2);
        }

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#store-org.apache.kafka.streams.StoreQueryParameters-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.StoreQueryParameters"/></param>
        /// <typeparam name="TKNetManagedStore"></typeparam>
        /// <typeparam name="TStore"></typeparam>
        /// <returns><typeparamref name="TKNetManagedStore"/></returns>
        public TKNetManagedStore Store<TKNetManagedStore, TStore>(Org.Apache.Kafka.Streams.StoreQueryParameters<TStore> arg0)
            where TKNetManagedStore : KNetManagedStore<TStore>, IGenericSerDesFactoryApplier
        {
            var t = typeof(TKNetManagedStore);
            var substore = Store<TStore>(arg0);
            return Activator.CreateInstance(t, _factory, substore) as TKNetManagedStore;
        }

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#store-org.apache.kafka.streams.StoreQueryParameters-"/>
        /// </summary>
        /// <param name="storageId"><see cref="Org.Apache.Kafka.Streams.StoreQueryParameters"/></param>
        /// <param name="storeType"></param>
        /// <typeparam name="TKNetManagedStore"></typeparam>
        /// <typeparam name="TStore"></typeparam>
        /// <returns><typeparamref name="TKNetManagedStore"/></returns>
        public TKNetManagedStore Store<TKNetManagedStore, TStore>(string storageId, KNetQueryableStoreTypes.StoreType<TKNetManagedStore, TStore> storeType)
            where TKNetManagedStore : KNetManagedStore<TStore>, IGenericSerDesFactoryApplier
        {
            var sqp = Org.Apache.Kafka.Streams.StoreQueryParameters<TStore>.FromNameAndType(storageId, storeType.Store);
            var t = typeof(TKNetManagedStore);
            var substore = Store<TStore>(sqp);
            return Activator.CreateInstance(t, _factory, substore) as TKNetManagedStore;
        }

        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#removeStreamThread-java.time.Duration-"/>
        /// </summary>
        /// <param name="arg0"><see cref="TimeSpan"/></param>
        /// <returns><see cref="string"/></returns>
        public string RemoveStreamThread(TimeSpan arg0)
        {
            var res = base.RemoveStreamThread(arg0);
            return res.IsPresent() ? res.Get() : null;
        }

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#state--"/>
        /// </summary>
        /// <returns><see cref="Org.Apache.Kafka.Streams.KafkaStreams.State"/></returns>
        public new State State => base.StateMethod();

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#setGlobalStateRestoreListener-org.apache.kafka.streams.processor.StateRestoreListener-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Processor.StateRestoreListener"/></param>
        public new void SetGlobalStateRestoreListener(Org.Apache.Kafka.Streams.Processor.StateRestoreListener arg0)
        {
            base.SetGlobalStateRestoreListener(null);
            _stateRestoreListener = arg0;
            base.SetGlobalStateRestoreListener(arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#setStateListener-org.apache.kafka.streams.KafkaStreams.StateListener-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.KafkaStreams.StateListener"/></param>
        public new void SetStateListener(Org.Apache.Kafka.Streams.KafkaStreams.StateListener arg0)
        {
            base.SetStateListener(null);
            _stateListener = arg0;
            base.SetStateListener(arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#setUncaughtExceptionHandler-org.apache.kafka.streams.errors.StreamsUncaughtExceptionHandler-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Errors.StreamsUncaughtExceptionHandler"/></param>
        public new void SetUncaughtExceptionHandler(Org.Apache.Kafka.Streams.Errors.StreamsUncaughtExceptionHandler arg0)
        {
            base.SetUncaughtExceptionHandler(null);
            _streamsUncaughtExceptionHandler = arg0;
            base.SetUncaughtExceptionHandler(arg0);
        }

        #endregion
    }
}
