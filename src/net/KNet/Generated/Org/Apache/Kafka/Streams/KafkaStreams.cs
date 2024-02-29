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

/*
*  This file is generated by MASES.JNetReflector (ver. 2.4.0.0)
*  using kafka-streams-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Streams
{
    #region KafkaStreams
    public partial class KafkaStreams
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#org.apache.kafka.streams.KafkaStreams(org.apache.kafka.streams.Topology,java.util.Properties,org.apache.kafka.common.utils.Time)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Topology"/></param>
        /// <param name="arg1"><see cref="Java.Util.Properties"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Common.Utils.Time"/></param>
        public KafkaStreams(Org.Apache.Kafka.Streams.Topology arg0, Java.Util.Properties arg1, Org.Apache.Kafka.Common.Utils.Time arg2)
            : base(arg0, arg1, arg2)
        {
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#org.apache.kafka.streams.KafkaStreams(org.apache.kafka.streams.Topology,java.util.Properties,org.apache.kafka.streams.KafkaClientSupplier,org.apache.kafka.common.utils.Time)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Topology"/></param>
        /// <param name="arg1"><see cref="Java.Util.Properties"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.KafkaClientSupplier"/></param>
        /// <param name="arg3"><see cref="Org.Apache.Kafka.Common.Utils.Time"/></param>
        public KafkaStreams(Org.Apache.Kafka.Streams.Topology arg0, Java.Util.Properties arg1, Org.Apache.Kafka.Streams.KafkaClientSupplier arg2, Org.Apache.Kafka.Common.Utils.Time arg3)
            : base(arg0, arg1, arg2, arg3)
        {
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#org.apache.kafka.streams.KafkaStreams(org.apache.kafka.streams.Topology,java.util.Properties,org.apache.kafka.streams.KafkaClientSupplier)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Topology"/></param>
        /// <param name="arg1"><see cref="Java.Util.Properties"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.KafkaClientSupplier"/></param>
        public KafkaStreams(Org.Apache.Kafka.Streams.Topology arg0, Java.Util.Properties arg1, Org.Apache.Kafka.Streams.KafkaClientSupplier arg2)
            : base(arg0, arg1, arg2)
        {
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#org.apache.kafka.streams.KafkaStreams(org.apache.kafka.streams.Topology,java.util.Properties)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Topology"/></param>
        /// <param name="arg1"><see cref="Java.Util.Properties"/></param>
        public KafkaStreams(Org.Apache.Kafka.Streams.Topology arg0, Java.Util.Properties arg1)
            : base(arg0, arg1)
        {
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#org.apache.kafka.streams.KafkaStreams(org.apache.kafka.streams.Topology,org.apache.kafka.streams.StreamsConfig,org.apache.kafka.common.utils.Time)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Topology"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.StreamsConfig"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Common.Utils.Time"/></param>
        public KafkaStreams(Org.Apache.Kafka.Streams.Topology arg0, Org.Apache.Kafka.Streams.StreamsConfig arg1, Org.Apache.Kafka.Common.Utils.Time arg2)
            : base(arg0, arg1, arg2)
        {
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#org.apache.kafka.streams.KafkaStreams(org.apache.kafka.streams.Topology,org.apache.kafka.streams.StreamsConfig,org.apache.kafka.streams.KafkaClientSupplier)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Topology"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.StreamsConfig"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.KafkaClientSupplier"/></param>
        public KafkaStreams(Org.Apache.Kafka.Streams.Topology arg0, Org.Apache.Kafka.Streams.StreamsConfig arg1, Org.Apache.Kafka.Streams.KafkaClientSupplier arg2)
            : base(arg0, arg1, arg2)
        {
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#org.apache.kafka.streams.KafkaStreams(org.apache.kafka.streams.Topology,org.apache.kafka.streams.StreamsConfig)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Topology"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.StreamsConfig"/></param>
        public KafkaStreams(Org.Apache.Kafka.Streams.Topology arg0, Org.Apache.Kafka.Streams.StreamsConfig arg1)
            : base(arg0, arg1)
        {
        }

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#queryMetadataForKey-java.lang.String-java.lang.Object-org.apache.kafka.common.serialization.Serializer-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <param name="arg1"><typeparamref name="K"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Common.Serialization.Serializer"/></param>
        /// <typeparam name="K"></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.KeyQueryMetadata"/></returns>
        public Org.Apache.Kafka.Streams.KeyQueryMetadata QueryMetadataForKey<K>(Java.Lang.String arg0, K arg1, Org.Apache.Kafka.Common.Serialization.Serializer<K> arg2)
        {
            return IExecute<Org.Apache.Kafka.Streams.KeyQueryMetadata>("queryMetadataForKey", arg0, arg1, arg2);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#queryMetadataForKey-java.lang.String-java.lang.Object-org.apache.kafka.streams.processor.StreamPartitioner-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <param name="arg1"><typeparamref name="K"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Processor.StreamPartitioner"/></param>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="Arg2objectSuperK"><typeparamref name="K"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.KeyQueryMetadata"/></returns>
        public Org.Apache.Kafka.Streams.KeyQueryMetadata QueryMetadataForKey<K, Arg2objectSuperK>(Java.Lang.String arg0, K arg1, Org.Apache.Kafka.Streams.Processor.StreamPartitioner<Arg2objectSuperK, object> arg2) where Arg2objectSuperK: K
        {
            return IExecute<Org.Apache.Kafka.Streams.KeyQueryMetadata>("queryMetadataForKey", arg0, arg1, arg2);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#query-org.apache.kafka.streams.query.StateQueryRequest-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Query.StateQueryRequest"/></param>
        /// <typeparam name="R"></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Query.StateQueryResult"/></returns>
        public Org.Apache.Kafka.Streams.Query.StateQueryResult<R> Query<R>(Org.Apache.Kafka.Streams.Query.StateQueryRequest<R> arg0)
        {
            return IExecuteWithSignature<Org.Apache.Kafka.Streams.Query.StateQueryResult<R>>("query", "(Lorg/apache/kafka/streams/query/StateQueryRequest;)Lorg/apache/kafka/streams/query/StateQueryResult;", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#store-org.apache.kafka.streams.StoreQueryParameters-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.StoreQueryParameters"/></param>
        /// <typeparam name="T"></typeparam>
        /// <returns><typeparamref name="T"/></returns>
        public T Store<T>(Org.Apache.Kafka.Streams.StoreQueryParameters<T> arg0)
        {
            return IExecuteWithSignature<T>("store", "(Lorg/apache/kafka/streams/StoreQueryParameters;)Ljava/lang/Object;", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#isPaused--"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool IsPaused()
        {
            return IExecuteWithSignature<bool>("isPaused", "()Z");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#metadataForAllStreamsClients--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Collection"/></returns>
        public Java.Util.Collection<Org.Apache.Kafka.Streams.StreamsMetadata> MetadataForAllStreamsClients()
        {
            return IExecuteWithSignature<Java.Util.Collection<Org.Apache.Kafka.Streams.StreamsMetadata>>("metadataForAllStreamsClients", "()Ljava/util/Collection;");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#streamsMetadataForStore-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <returns><see cref="Java.Util.Collection"/></returns>
        public Java.Util.Collection<Org.Apache.Kafka.Streams.StreamsMetadata> StreamsMetadataForStore(Java.Lang.String arg0)
        {
            return IExecuteWithSignature<Java.Util.Collection<Org.Apache.Kafka.Streams.StreamsMetadata>>("streamsMetadataForStore", "(Ljava/lang/String;)Ljava/util/Collection;", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#allLocalStorePartitionLags--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Map"/></returns>
        public Java.Util.Map<Java.Lang.String, Java.Util.Map<Java.Lang.Integer, Org.Apache.Kafka.Streams.LagInfo>> AllLocalStorePartitionLags()
        {
            return IExecuteWithSignature<Java.Util.Map<Java.Lang.String, Java.Util.Map<Java.Lang.Integer, Org.Apache.Kafka.Streams.LagInfo>>>("allLocalStorePartitionLags", "()Ljava/util/Map;");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#metrics--"/>
        /// </summary>

        /// <typeparam name="ReturnExtendsOrg_Apache_Kafka_Common_Metric"><see cref="Org.Apache.Kafka.Common.Metric"/></typeparam>
        /// <returns><see cref="Java.Util.Map"/></returns>
        public Java.Util.Map<Org.Apache.Kafka.Common.MetricName, ReturnExtendsOrg_Apache_Kafka_Common_Metric> Metrics<ReturnExtendsOrg_Apache_Kafka_Common_Metric>() where ReturnExtendsOrg_Apache_Kafka_Common_Metric: Org.Apache.Kafka.Common.Metric
        {
            return IExecuteWithSignature<Java.Util.Map<Org.Apache.Kafka.Common.MetricName, ReturnExtendsOrg_Apache_Kafka_Common_Metric>>("metrics", "()Ljava/util/Map;");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#addStreamThread--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Optional"/></returns>
        public Java.Util.Optional<Java.Lang.String> AddStreamThread()
        {
            return IExecuteWithSignature<Java.Util.Optional<Java.Lang.String>>("addStreamThread", "()Ljava/util/Optional;");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#removeStreamThread--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Optional"/></returns>
        public Java.Util.Optional<Java.Lang.String> RemoveStreamThread()
        {
            return IExecuteWithSignature<Java.Util.Optional<Java.Lang.String>>("removeStreamThread", "()Ljava/util/Optional;");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#removeStreamThread-java.time.Duration-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Time.Duration"/></param>
        /// <returns><see cref="Java.Util.Optional"/></returns>
        public Java.Util.Optional<Java.Lang.String> RemoveStreamThread(Java.Time.Duration arg0)
        {
            return IExecuteWithSignature<Java.Util.Optional<Java.Lang.String>>("removeStreamThread", "(Ljava/time/Duration;)Ljava/util/Optional;", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#metadataForLocalThreads--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Set"/></returns>
        public Java.Util.Set<Org.Apache.Kafka.Streams.ThreadMetadata> MetadataForLocalThreads()
        {
            return IExecuteWithSignature<Java.Util.Set<Org.Apache.Kafka.Streams.ThreadMetadata>>("metadataForLocalThreads", "()Ljava/util/Set;");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#state--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Streams.KafkaStreams.State"/></returns>
        public Org.Apache.Kafka.Streams.KafkaStreams.State StateMethod()
        {
            return IExecuteWithSignature<Org.Apache.Kafka.Streams.KafkaStreams.State>("state", "()Lorg/apache/kafka/streams/KafkaStreams$State;");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#close-java.time.Duration-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Time.Duration"/></param>
        /// <returns><see cref="bool"/></returns>
        /// <exception cref="Java.Lang.IllegalArgumentException"/>
        public bool Close(Java.Time.Duration arg0)
        {
            return IExecuteWithSignature<bool>("close", "(Ljava/time/Duration;)Z", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#close-org.apache.kafka.streams.KafkaStreams.CloseOptions-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.KafkaStreams.CloseOptions"/></param>
        /// <returns><see cref="bool"/></returns>
        /// <exception cref="Java.Lang.IllegalArgumentException"/>
        public bool Close(Org.Apache.Kafka.Streams.KafkaStreams.CloseOptions arg0)
        {
            return IExecuteWithSignature<bool>("close", "(Lorg/apache/kafka/streams/KafkaStreams$CloseOptions;)Z", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#start--"/>
        /// </summary>

        /// <exception cref="Java.Lang.IllegalStateException"/>
        /// <exception cref="Org.Apache.Kafka.Streams.Errors.StreamsException"/>
        public void Start()
        {
            IExecuteWithSignature("start", "()V");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#cleanUp--"/>
        /// </summary>
        public void CleanUp()
        {
            IExecuteWithSignature("cleanUp", "()V");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#close--"/>
        /// </summary>
        public void Close()
        {
            IExecuteWithSignature("close", "()V");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#pause--"/>
        /// </summary>
        public void Pause()
        {
            IExecuteWithSignature("pause", "()V");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#resume--"/>
        /// </summary>
        public void Resume()
        {
            IExecuteWithSignature("resume", "()V");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#setGlobalStateRestoreListener-org.apache.kafka.streams.processor.StateRestoreListener-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Processor.StateRestoreListener"/></param>
        public void SetGlobalStateRestoreListener(Org.Apache.Kafka.Streams.Processor.StateRestoreListener arg0)
        {
            IExecuteWithSignature("setGlobalStateRestoreListener", "(Lorg/apache/kafka/streams/processor/StateRestoreListener;)V", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#setStateListener-org.apache.kafka.streams.KafkaStreams.StateListener-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.KafkaStreams.StateListener"/></param>
        public void SetStateListener(Org.Apache.Kafka.Streams.KafkaStreams.StateListener arg0)
        {
            IExecuteWithSignature("setStateListener", "(Lorg/apache/kafka/streams/KafkaStreams$StateListener;)V", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.html#setUncaughtExceptionHandler-org.apache.kafka.streams.errors.StreamsUncaughtExceptionHandler-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Errors.StreamsUncaughtExceptionHandler"/></param>
        public void SetUncaughtExceptionHandler(Org.Apache.Kafka.Streams.Errors.StreamsUncaughtExceptionHandler arg0)
        {
            IExecuteWithSignature("setUncaughtExceptionHandler", "(Lorg/apache/kafka/streams/errors/StreamsUncaughtExceptionHandler;)V", arg0);
        }

        #endregion

        #region Nested classes
        #region CloseOptions
        public partial class CloseOptions
        {
            #region Constructors

            #endregion

            #region Class/Interface conversion operators

            #endregion

            #region Fields

            #endregion

            #region Static methods

            #endregion

            #region Instance methods
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.CloseOptions.html#leaveGroup-boolean-"/>
            /// </summary>
            /// <param name="arg0"><see cref="bool"/></param>
            /// <returns><see cref="Org.Apache.Kafka.Streams.KafkaStreams.CloseOptions"/></returns>
            public Org.Apache.Kafka.Streams.KafkaStreams.CloseOptions LeaveGroup(bool arg0)
            {
                return IExecuteWithSignature<Org.Apache.Kafka.Streams.KafkaStreams.CloseOptions>("leaveGroup", "(Z)Lorg/apache/kafka/streams/KafkaStreams$CloseOptions;", arg0);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.CloseOptions.html#timeout-java.time.Duration-"/>
            /// </summary>
            /// <param name="arg0"><see cref="Java.Time.Duration"/></param>
            /// <returns><see cref="Org.Apache.Kafka.Streams.KafkaStreams.CloseOptions"/></returns>
            public Org.Apache.Kafka.Streams.KafkaStreams.CloseOptions Timeout(Java.Time.Duration arg0)
            {
                return IExecuteWithSignature<Org.Apache.Kafka.Streams.KafkaStreams.CloseOptions>("timeout", "(Ljava/time/Duration;)Lorg/apache/kafka/streams/KafkaStreams$CloseOptions;", arg0);
            }

            #endregion

            #region Nested classes

            #endregion

            // TODO: complete the class
        }
        #endregion

        #region State
        public partial class State
        {
            #region Constructors

            #endregion

            #region Class/Interface conversion operators

            #endregion

            #region Fields
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.State.html#CREATED"/>
            /// </summary>
            public static Org.Apache.Kafka.Streams.KafkaStreams.State CREATED { get { if (!_CREATEDReady) { _CREATEDContent = SGetField<Org.Apache.Kafka.Streams.KafkaStreams.State>(LocalBridgeClazz, "CREATED"); _CREATEDReady = true; } return _CREATEDContent; } }
            private static Org.Apache.Kafka.Streams.KafkaStreams.State _CREATEDContent = default;
            private static bool _CREATEDReady = false; // this is used because in case of generics 
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.State.html#ERROR"/>
            /// </summary>
            public static Org.Apache.Kafka.Streams.KafkaStreams.State ERROR { get { if (!_ERRORReady) { _ERRORContent = SGetField<Org.Apache.Kafka.Streams.KafkaStreams.State>(LocalBridgeClazz, "ERROR"); _ERRORReady = true; } return _ERRORContent; } }
            private static Org.Apache.Kafka.Streams.KafkaStreams.State _ERRORContent = default;
            private static bool _ERRORReady = false; // this is used because in case of generics 
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.State.html#NOT_RUNNING"/>
            /// </summary>
            public static Org.Apache.Kafka.Streams.KafkaStreams.State NOT_RUNNING { get { if (!_NOT_RUNNINGReady) { _NOT_RUNNINGContent = SGetField<Org.Apache.Kafka.Streams.KafkaStreams.State>(LocalBridgeClazz, "NOT_RUNNING"); _NOT_RUNNINGReady = true; } return _NOT_RUNNINGContent; } }
            private static Org.Apache.Kafka.Streams.KafkaStreams.State _NOT_RUNNINGContent = default;
            private static bool _NOT_RUNNINGReady = false; // this is used because in case of generics 
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.State.html#PENDING_ERROR"/>
            /// </summary>
            public static Org.Apache.Kafka.Streams.KafkaStreams.State PENDING_ERROR { get { if (!_PENDING_ERRORReady) { _PENDING_ERRORContent = SGetField<Org.Apache.Kafka.Streams.KafkaStreams.State>(LocalBridgeClazz, "PENDING_ERROR"); _PENDING_ERRORReady = true; } return _PENDING_ERRORContent; } }
            private static Org.Apache.Kafka.Streams.KafkaStreams.State _PENDING_ERRORContent = default;
            private static bool _PENDING_ERRORReady = false; // this is used because in case of generics 
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.State.html#PENDING_SHUTDOWN"/>
            /// </summary>
            public static Org.Apache.Kafka.Streams.KafkaStreams.State PENDING_SHUTDOWN { get { if (!_PENDING_SHUTDOWNReady) { _PENDING_SHUTDOWNContent = SGetField<Org.Apache.Kafka.Streams.KafkaStreams.State>(LocalBridgeClazz, "PENDING_SHUTDOWN"); _PENDING_SHUTDOWNReady = true; } return _PENDING_SHUTDOWNContent; } }
            private static Org.Apache.Kafka.Streams.KafkaStreams.State _PENDING_SHUTDOWNContent = default;
            private static bool _PENDING_SHUTDOWNReady = false; // this is used because in case of generics 
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.State.html#REBALANCING"/>
            /// </summary>
            public static Org.Apache.Kafka.Streams.KafkaStreams.State REBALANCING { get { if (!_REBALANCINGReady) { _REBALANCINGContent = SGetField<Org.Apache.Kafka.Streams.KafkaStreams.State>(LocalBridgeClazz, "REBALANCING"); _REBALANCINGReady = true; } return _REBALANCINGContent; } }
            private static Org.Apache.Kafka.Streams.KafkaStreams.State _REBALANCINGContent = default;
            private static bool _REBALANCINGReady = false; // this is used because in case of generics 
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.State.html#RUNNING"/>
            /// </summary>
            public static Org.Apache.Kafka.Streams.KafkaStreams.State RUNNING { get { if (!_RUNNINGReady) { _RUNNINGContent = SGetField<Org.Apache.Kafka.Streams.KafkaStreams.State>(LocalBridgeClazz, "RUNNING"); _RUNNINGReady = true; } return _RUNNINGContent; } }
            private static Org.Apache.Kafka.Streams.KafkaStreams.State _RUNNINGContent = default;
            private static bool _RUNNINGReady = false; // this is used because in case of generics 

            #endregion

            #region Static methods
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.State.html#valueOf-java.lang.String-"/>
            /// </summary>
            /// <param name="arg0"><see cref="Java.Lang.String"/></param>
            /// <returns><see cref="Org.Apache.Kafka.Streams.KafkaStreams.State"/></returns>
            public static Org.Apache.Kafka.Streams.KafkaStreams.State ValueOf(Java.Lang.String arg0)
            {
                return SExecuteWithSignature<Org.Apache.Kafka.Streams.KafkaStreams.State>(LocalBridgeClazz, "valueOf", "(Ljava/lang/String;)Lorg/apache/kafka/streams/KafkaStreams$State;", arg0);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.State.html#values--"/>
            /// </summary>

            /// <returns><see cref="Org.Apache.Kafka.Streams.KafkaStreams.State"/></returns>
            public static Org.Apache.Kafka.Streams.KafkaStreams.State[] Values()
            {
                return SExecuteWithSignatureArray<Org.Apache.Kafka.Streams.KafkaStreams.State>(LocalBridgeClazz, "values", "()[Lorg/apache/kafka/streams/KafkaStreams$State;");
            }

            #endregion

            #region Instance methods
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.State.html#hasCompletedShutdown--"/>
            /// </summary>

            /// <returns><see cref="bool"/></returns>
            public bool HasCompletedShutdown()
            {
                return IExecuteWithSignature<bool>("hasCompletedShutdown", "()Z");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.State.html#hasNotStarted--"/>
            /// </summary>

            /// <returns><see cref="bool"/></returns>
            public bool HasNotStarted()
            {
                return IExecuteWithSignature<bool>("hasNotStarted", "()Z");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.State.html#hasStartedOrFinishedShuttingDown--"/>
            /// </summary>

            /// <returns><see cref="bool"/></returns>
            public bool HasStartedOrFinishedShuttingDown()
            {
                return IExecuteWithSignature<bool>("hasStartedOrFinishedShuttingDown", "()Z");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.State.html#isRunningOrRebalancing--"/>
            /// </summary>

            /// <returns><see cref="bool"/></returns>
            public bool IsRunningOrRebalancing()
            {
                return IExecuteWithSignature<bool>("isRunningOrRebalancing", "()Z");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.State.html#isShuttingDown--"/>
            /// </summary>

            /// <returns><see cref="bool"/></returns>
            public bool IsShuttingDown()
            {
                return IExecuteWithSignature<bool>("isShuttingDown", "()Z");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.State.html#isValidTransition-org.apache.kafka.streams.KafkaStreams.State-"/>
            /// </summary>
            /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.KafkaStreams.State"/></param>
            /// <returns><see cref="bool"/></returns>
            public bool IsValidTransition(Org.Apache.Kafka.Streams.KafkaStreams.State arg0)
            {
                return IExecuteWithSignature<bool>("isValidTransition", "(Lorg/apache/kafka/streams/KafkaStreams$State;)Z", arg0);
            }

            #endregion

            #region Nested classes

            #endregion

            // TODO: complete the class
        }
        #endregion

        #region StateListener
        public partial class StateListener
        {
            #region Constructors

            #endregion

            #region Class/Interface conversion operators

            #endregion

            #region Fields

            #endregion

            #region Static methods

            #endregion

            #region Instance methods
            /// <summary>
            /// Handlers initializer for <see cref="StateListener"/>
            /// </summary>
            protected virtual void InitializeHandlers()
            {
                AddEventHandler("onChange", new System.EventHandler<CLRListenerEventArgs<CLREventData<Org.Apache.Kafka.Streams.KafkaStreams.State>>>(OnChangeEventHandler));

            }

            /// <summary>
            /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.StateListener.html#onChange-org.apache.kafka.streams.KafkaStreams.State-org.apache.kafka.streams.KafkaStreams.State-"/>
            /// </summary>
            /// <remarks>If <see cref="OnOnChange"/> has a value it takes precedence over corresponding class method</remarks>
            public System.Action<Org.Apache.Kafka.Streams.KafkaStreams.State, Org.Apache.Kafka.Streams.KafkaStreams.State> OnOnChange { get; set; } = null;

            void OnChangeEventHandler(object sender, CLRListenerEventArgs<CLREventData<Org.Apache.Kafka.Streams.KafkaStreams.State>> data)
            {
                var methodToExecute = (OnOnChange != null) ? OnOnChange : OnChange;
                methodToExecute.Invoke(data.EventData.TypedEventData, data.EventData.GetAt<Org.Apache.Kafka.Streams.KafkaStreams.State>(0));
            }

            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KafkaStreams.StateListener.html#onChange-org.apache.kafka.streams.KafkaStreams.State-org.apache.kafka.streams.KafkaStreams.State-"/>
            /// </summary>
            /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.KafkaStreams.State"/></param>
            /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.KafkaStreams.State"/></param>
            public virtual void OnChange(Org.Apache.Kafka.Streams.KafkaStreams.State arg0, Org.Apache.Kafka.Streams.KafkaStreams.State arg1)
            {
                
            }

            #endregion

            #region Nested classes

            #endregion

            // TODO: complete the class
        }
        #endregion

    
        #endregion

        // TODO: complete the class
    }
    #endregion
}