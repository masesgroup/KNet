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
*  using kafka-clients-3.7.0.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Clients
{
    #region Metadata
    public partial class Metadata
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
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/Metadata.html#lastSeenLeaderEpoch-org.apache.kafka.common.TopicPartition-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.TopicPartition"/></param>
        /// <returns><see cref="Java.Util.Optional"/></returns>
        public Java.Util.Optional<Java.Lang.Integer> LastSeenLeaderEpoch(Org.Apache.Kafka.Common.TopicPartition arg0)
        {
            return IExecuteWithSignature<Java.Util.Optional<Java.Lang.Integer>>("lastSeenLeaderEpoch", "(Lorg/apache/kafka/common/TopicPartition;)Ljava/util/Optional;", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/Metadata.html#metadataExpireMs--"/>
        /// </summary>

        /// <returns><see cref="long"/></returns>
        public long MetadataExpireMs()
        {
            return IExecuteWithSignature<long>("metadataExpireMs", "()J");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/Metadata.html#isClosed--"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool IsClosed()
        {
            return IExecuteWithSignature<bool>("isClosed", "()Z");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/Metadata.html#updateLastSeenEpochIfNewer-org.apache.kafka.common.TopicPartition-int-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.TopicPartition"/></param>
        /// <param name="arg1"><see cref="int"/></param>
        /// <returns><see cref="bool"/></returns>
        public bool UpdateLastSeenEpochIfNewer(Org.Apache.Kafka.Common.TopicPartition arg0, int arg1)
        {
            return IExecute<bool>("updateLastSeenEpochIfNewer", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/Metadata.html#updateRequested--"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool UpdateRequested()
        {
            return IExecuteWithSignature<bool>("updateRequested", "()Z");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/Metadata.html#requestUpdate-boolean-"/>
        /// </summary>
        /// <param name="arg0"><see cref="bool"/></param>
        /// <returns><see cref="int"/></returns>
        public int RequestUpdate(bool arg0)
        {
            return IExecuteWithSignature<int>("requestUpdate", "(Z)I", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/Metadata.html#requestUpdateForNewTopics--"/>
        /// </summary>

        /// <returns><see cref="int"/></returns>
        public int RequestUpdateForNewTopics()
        {
            return IExecuteWithSignature<int>("requestUpdateForNewTopics", "()I");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/Metadata.html#updateVersion--"/>
        /// </summary>

        /// <returns><see cref="int"/></returns>
        public int UpdateVersion()
        {
            return IExecuteWithSignature<int>("updateVersion", "()I");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/Metadata.html#topicIds--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Map"/></returns>
        public Java.Util.Map<Java.Lang.String, Org.Apache.Kafka.Common.Uuid> TopicIds()
        {
            return IExecuteWithSignature<Java.Util.Map<Java.Lang.String, Org.Apache.Kafka.Common.Uuid>>("topicIds", "()Ljava/util/Map;");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/Metadata.html#topicNames--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Map"/></returns>
        public Java.Util.Map<Org.Apache.Kafka.Common.Uuid, Java.Lang.String> TopicNames()
        {
            return IExecuteWithSignature<Java.Util.Map<Org.Apache.Kafka.Common.Uuid, Java.Lang.String>>("topicNames", "()Ljava/util/Map;");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/Metadata.html#updatePartitionLeadership-java.util.Map-java.util.List-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Map"/></param>
        /// <param name="arg1"><see cref="Java.Util.List"/></param>
        /// <returns><see cref="Java.Util.Set"/></returns>
        public Java.Util.Set<Org.Apache.Kafka.Common.TopicPartition> UpdatePartitionLeadership(Java.Util.Map<Org.Apache.Kafka.Common.TopicPartition, Org.Apache.Kafka.Clients.Metadata.LeaderIdAndEpoch> arg0, Java.Util.List<Org.Apache.Kafka.Common.Node> arg1)
        {
            return IExecute<Java.Util.Set<Org.Apache.Kafka.Common.TopicPartition>>("updatePartitionLeadership", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/Metadata.html#lastSuccessfulUpdate--"/>
        /// </summary>

        /// <returns><see cref="long"/></returns>
        public long LastSuccessfulUpdate()
        {
            return IExecuteWithSignature<long>("lastSuccessfulUpdate", "()J");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/Metadata.html#timeToAllowUpdate-long-"/>
        /// </summary>
        /// <param name="arg0"><see cref="long"/></param>
        /// <returns><see cref="long"/></returns>
        public long TimeToAllowUpdate(long arg0)
        {
            return IExecuteWithSignature<long>("timeToAllowUpdate", "(J)J", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/Metadata.html#timeToNextUpdate-long-"/>
        /// </summary>
        /// <param name="arg0"><see cref="long"/></param>
        /// <returns><see cref="long"/></returns>
        public long TimeToNextUpdate(long arg0)
        {
            return IExecuteWithSignature<long>("timeToNextUpdate", "(J)J", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/Metadata.html#currentLeader-org.apache.kafka.common.TopicPartition-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.TopicPartition"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Clients.Metadata.LeaderAndEpoch"/></returns>
        public Org.Apache.Kafka.Clients.Metadata.LeaderAndEpoch CurrentLeader(Org.Apache.Kafka.Common.TopicPartition arg0)
        {
            return IExecuteWithSignature<Org.Apache.Kafka.Clients.Metadata.LeaderAndEpoch>("currentLeader", "(Lorg/apache/kafka/common/TopicPartition;)Lorg/apache/kafka/clients/Metadata$LeaderAndEpoch;", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/Metadata.html#newMetadataRequestAndVersion-long-"/>
        /// </summary>
        /// <param name="arg0"><see cref="long"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Clients.Metadata.MetadataRequestAndVersion"/></returns>
        public Org.Apache.Kafka.Clients.Metadata.MetadataRequestAndVersion NewMetadataRequestAndVersion(long arg0)
        {
            return IExecuteWithSignature<Org.Apache.Kafka.Clients.Metadata.MetadataRequestAndVersion>("newMetadataRequestAndVersion", "(J)Lorg/apache/kafka/clients/Metadata$MetadataRequestAndVersion;", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/Metadata.html#fetch--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Cluster"/></returns>
        public Org.Apache.Kafka.Common.Cluster Fetch()
        {
            return IExecuteWithSignature<Org.Apache.Kafka.Common.Cluster>("fetch", "()Lorg/apache/kafka/common/Cluster;");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/Metadata.html#addClusterUpdateListener-org.apache.kafka.common.ClusterResourceListener-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.ClusterResourceListener"/></param>
        public void AddClusterUpdateListener(Org.Apache.Kafka.Common.ClusterResourceListener arg0)
        {
            IExecuteWithSignature("addClusterUpdateListener", "(Lorg/apache/kafka/common/ClusterResourceListener;)V", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/Metadata.html#bootstrap-java.util.List-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.List"/></param>
        public void Bootstrap(Java.Util.List<Java.Net.InetSocketAddress> arg0)
        {
            IExecuteWithSignature("bootstrap", "(Ljava/util/List;)V", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/Metadata.html#close--"/>
        /// </summary>
        public void Close()
        {
            IExecuteWithSignature("close", "()V");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/Metadata.html#failedUpdate-long-"/>
        /// </summary>
        /// <param name="arg0"><see cref="long"/></param>
        public void FailedUpdate(long arg0)
        {
            IExecuteWithSignature("failedUpdate", "(J)V", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/Metadata.html#fatalError-org.apache.kafka.common.KafkaException-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.KafkaException"/></param>
        public void FatalError(MASES.JCOBridge.C2JBridge.JVMBridgeException arg0)
        {
            IExecuteWithSignature("fatalError", "(Lorg/apache/kafka/common/KafkaException;)V", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/Metadata.html#maybeThrowAnyException--"/>
        /// </summary>
        public void MaybeThrowAnyException()
        {
            IExecuteWithSignature("maybeThrowAnyException", "()V");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/Metadata.html#maybeThrowExceptionForTopic-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        public void MaybeThrowExceptionForTopic(Java.Lang.String arg0)
        {
            IExecuteWithSignature("maybeThrowExceptionForTopic", "(Ljava/lang/String;)V", arg0);
        }

        #endregion

        #region Nested classes
        #region LeaderAndEpoch
        public partial class LeaderAndEpoch
        {
            #region Constructors
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/Metadata.LeaderAndEpoch.html#org.apache.kafka.clients.Metadata$LeaderAndEpoch(java.util.Optional,java.util.Optional)"/>
            /// </summary>
            /// <param name="arg0"><see cref="Java.Util.Optional"/></param>
            /// <param name="arg1"><see cref="Java.Util.Optional"/></param>
            public LeaderAndEpoch(Java.Util.Optional<Org.Apache.Kafka.Common.Node> arg0, Java.Util.Optional<Java.Lang.Integer> arg1)
                : base(arg0, arg1)
            {
            }

            #endregion

            #region Class/Interface conversion operators

            #endregion

            #region Fields
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/Metadata.LeaderAndEpoch.html#epoch"/>
            /// </summary>
            public Java.Util.Optional epoch { get { if (!_epochReady) { _epochContent = IGetField<Java.Util.Optional>("epoch"); _epochReady = true; } return _epochContent; } }
            private Java.Util.Optional _epochContent = default;
            private bool _epochReady = false; // this is used because in case of generics 
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/Metadata.LeaderAndEpoch.html#leader"/>
            /// </summary>
            public Java.Util.Optional leader { get { if (!_leaderReady) { _leaderContent = IGetField<Java.Util.Optional>("leader"); _leaderReady = true; } return _leaderContent; } }
            private Java.Util.Optional _leaderContent = default;
            private bool _leaderReady = false; // this is used because in case of generics 

            #endregion

            #region Static methods
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/Metadata.LeaderAndEpoch.html#noLeaderOrEpoch--"/>
            /// </summary>

            /// <returns><see cref="Org.Apache.Kafka.Clients.Metadata.LeaderAndEpoch"/></returns>
            public static Org.Apache.Kafka.Clients.Metadata.LeaderAndEpoch NoLeaderOrEpoch()
            {
                return SExecuteWithSignature<Org.Apache.Kafka.Clients.Metadata.LeaderAndEpoch>(LocalBridgeClazz, "noLeaderOrEpoch", "()Lorg/apache/kafka/clients/Metadata$LeaderAndEpoch;");
            }

            #endregion

            #region Instance methods

            #endregion

            #region Nested classes

            #endregion

            // TODO: complete the class
        }
        #endregion

        #region LeaderIdAndEpoch
        public partial class LeaderIdAndEpoch
        {
            #region Constructors
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/Metadata.LeaderIdAndEpoch.html#org.apache.kafka.clients.Metadata$LeaderIdAndEpoch(java.util.Optional,java.util.Optional)"/>
            /// </summary>
            /// <param name="arg0"><see cref="Java.Util.Optional"/></param>
            /// <param name="arg1"><see cref="Java.Util.Optional"/></param>
            public LeaderIdAndEpoch(Java.Util.Optional<Java.Lang.Integer> arg0, Java.Util.Optional<Java.Lang.Integer> arg1)
                : base(arg0, arg1)
            {
            }

            #endregion

            #region Class/Interface conversion operators

            #endregion

            #region Fields
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/Metadata.LeaderIdAndEpoch.html#epoch"/>
            /// </summary>
            public Java.Util.Optional epoch { get { if (!_epochReady) { _epochContent = IGetField<Java.Util.Optional>("epoch"); _epochReady = true; } return _epochContent; } }
            private Java.Util.Optional _epochContent = default;
            private bool _epochReady = false; // this is used because in case of generics 
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/Metadata.LeaderIdAndEpoch.html#leaderId"/>
            /// </summary>
            public Java.Util.Optional leaderId { get { if (!_leaderIdReady) { _leaderIdContent = IGetField<Java.Util.Optional>("leaderId"); _leaderIdReady = true; } return _leaderIdContent; } }
            private Java.Util.Optional _leaderIdContent = default;
            private bool _leaderIdReady = false; // this is used because in case of generics 

            #endregion

            #region Static methods

            #endregion

            #region Instance methods

            #endregion

            #region Nested classes

            #endregion

            // TODO: complete the class
        }
        #endregion

        #region MetadataRequestAndVersion
        public partial class MetadataRequestAndVersion
        {
            #region Constructors

            #endregion

            #region Class/Interface conversion operators

            #endregion

            #region Fields
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/Metadata.MetadataRequestAndVersion.html#isPartialUpdate"/>
            /// </summary>
            public bool isPartialUpdate { get { if (!_isPartialUpdateReady) { _isPartialUpdateContent = IGetField<bool>("isPartialUpdate"); _isPartialUpdateReady = true; } return _isPartialUpdateContent; } }
            private bool _isPartialUpdateContent = default;
            private bool _isPartialUpdateReady = false; // this is used because in case of generics 
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/Metadata.MetadataRequestAndVersion.html#requestVersion"/>
            /// </summary>
            public int requestVersion { get { if (!_requestVersionReady) { _requestVersionContent = IGetField<int>("requestVersion"); _requestVersionReady = true; } return _requestVersionContent; } }
            private int _requestVersionContent = default;
            private bool _requestVersionReady = false; // this is used because in case of generics 

            #endregion

            #region Static methods

            #endregion

            #region Instance methods

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