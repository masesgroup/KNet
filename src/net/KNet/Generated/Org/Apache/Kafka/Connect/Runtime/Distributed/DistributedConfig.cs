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

/*
*  This file is generated by MASES.JNetReflector (ver. 1.5.5.0)
*  using connect-runtime-3.4.0.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Connect.Runtime.Distributed
{
    #region DistributedConfig
    public partial class DistributedConfig
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#%3Cinit%3E(java.util.Map)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Map"/></param>
        public DistributedConfig(Java.Util.Map<string, string> arg0)
            : base(arg0)
        {
        }

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#INTER_WORKER_KEY_TTL_MS_MS_DEFAULT"/>
        /// </summary>
        public static int INTER_WORKER_KEY_TTL_MS_MS_DEFAULT { get { return SGetField<int>(LocalBridgeClazz, "INTER_WORKER_KEY_TTL_MS_MS_DEFAULT"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#SCHEDULED_REBALANCE_MAX_DELAY_MS_DEFAULT"/>
        /// </summary>
        public static int SCHEDULED_REBALANCE_MAX_DELAY_MS_DEFAULT { get { return SGetField<int>(LocalBridgeClazz, "SCHEDULED_REBALANCE_MAX_DELAY_MS_DEFAULT"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#WORKER_UNSYNC_BACKOFF_MS_DEFAULT"/>
        /// </summary>
        public static int WORKER_UNSYNC_BACKOFF_MS_DEFAULT { get { return SGetField<int>(LocalBridgeClazz, "WORKER_UNSYNC_BACKOFF_MS_DEFAULT"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#INTER_WORKER_KEY_SIZE_DEFAULT"/>
        /// </summary>
        public static long? INTER_WORKER_KEY_SIZE_DEFAULT { get { return SGetField<long?>(LocalBridgeClazz, "INTER_WORKER_KEY_SIZE_DEFAULT"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#CONFIG_STORAGE_PREFIX"/>
        /// </summary>
        public static string CONFIG_STORAGE_PREFIX { get { return SGetField<string>(LocalBridgeClazz, "CONFIG_STORAGE_PREFIX"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#CONFIG_STORAGE_REPLICATION_FACTOR_CONFIG"/>
        /// </summary>
        public static string CONFIG_STORAGE_REPLICATION_FACTOR_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "CONFIG_STORAGE_REPLICATION_FACTOR_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#CONFIG_TOPIC_CONFIG"/>
        /// </summary>
        public static string CONFIG_TOPIC_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "CONFIG_TOPIC_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#CONNECT_PROTOCOL_CONFIG"/>
        /// </summary>
        public static string CONNECT_PROTOCOL_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "CONNECT_PROTOCOL_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#CONNECT_PROTOCOL_DEFAULT"/>
        /// </summary>
        public static string CONNECT_PROTOCOL_DEFAULT { get { return SGetField<string>(LocalBridgeClazz, "CONNECT_PROTOCOL_DEFAULT"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#CONNECT_PROTOCOL_DOC"/>
        /// </summary>
        public static string CONNECT_PROTOCOL_DOC { get { return SGetField<string>(LocalBridgeClazz, "CONNECT_PROTOCOL_DOC"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#EXACTLY_ONCE_SOURCE_SUPPORT_CONFIG"/>
        /// </summary>
        public static string EXACTLY_ONCE_SOURCE_SUPPORT_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "EXACTLY_ONCE_SOURCE_SUPPORT_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#EXACTLY_ONCE_SOURCE_SUPPORT_DEFAULT"/>
        /// </summary>
        public static string EXACTLY_ONCE_SOURCE_SUPPORT_DEFAULT { get { return SGetField<string>(LocalBridgeClazz, "EXACTLY_ONCE_SOURCE_SUPPORT_DEFAULT"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#EXACTLY_ONCE_SOURCE_SUPPORT_DOC"/>
        /// </summary>
        public static string EXACTLY_ONCE_SOURCE_SUPPORT_DOC { get { return SGetField<string>(LocalBridgeClazz, "EXACTLY_ONCE_SOURCE_SUPPORT_DOC"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#GROUP_ID_CONFIG"/>
        /// </summary>
        public static string GROUP_ID_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "GROUP_ID_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#HEARTBEAT_INTERVAL_MS_CONFIG"/>
        /// </summary>
        public static string HEARTBEAT_INTERVAL_MS_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "HEARTBEAT_INTERVAL_MS_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#INTER_WORKER_KEY_GENERATION_ALGORITHM_CONFIG"/>
        /// </summary>
        public static string INTER_WORKER_KEY_GENERATION_ALGORITHM_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "INTER_WORKER_KEY_GENERATION_ALGORITHM_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#INTER_WORKER_KEY_GENERATION_ALGORITHM_DEFAULT"/>
        /// </summary>
        public static string INTER_WORKER_KEY_GENERATION_ALGORITHM_DEFAULT { get { return SGetField<string>(LocalBridgeClazz, "INTER_WORKER_KEY_GENERATION_ALGORITHM_DEFAULT"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#INTER_WORKER_KEY_GENERATION_ALGORITHM_DOC"/>
        /// </summary>
        public static string INTER_WORKER_KEY_GENERATION_ALGORITHM_DOC { get { return SGetField<string>(LocalBridgeClazz, "INTER_WORKER_KEY_GENERATION_ALGORITHM_DOC"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#INTER_WORKER_KEY_SIZE_CONFIG"/>
        /// </summary>
        public static string INTER_WORKER_KEY_SIZE_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "INTER_WORKER_KEY_SIZE_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#INTER_WORKER_KEY_SIZE_DOC"/>
        /// </summary>
        public static string INTER_WORKER_KEY_SIZE_DOC { get { return SGetField<string>(LocalBridgeClazz, "INTER_WORKER_KEY_SIZE_DOC"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#INTER_WORKER_KEY_TTL_MS_CONFIG"/>
        /// </summary>
        public static string INTER_WORKER_KEY_TTL_MS_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "INTER_WORKER_KEY_TTL_MS_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#INTER_WORKER_KEY_TTL_MS_MS_DOC"/>
        /// </summary>
        public static string INTER_WORKER_KEY_TTL_MS_MS_DOC { get { return SGetField<string>(LocalBridgeClazz, "INTER_WORKER_KEY_TTL_MS_MS_DOC"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#INTER_WORKER_SIGNATURE_ALGORITHM_CONFIG"/>
        /// </summary>
        public static string INTER_WORKER_SIGNATURE_ALGORITHM_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "INTER_WORKER_SIGNATURE_ALGORITHM_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#INTER_WORKER_SIGNATURE_ALGORITHM_DEFAULT"/>
        /// </summary>
        public static string INTER_WORKER_SIGNATURE_ALGORITHM_DEFAULT { get { return SGetField<string>(LocalBridgeClazz, "INTER_WORKER_SIGNATURE_ALGORITHM_DEFAULT"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#INTER_WORKER_SIGNATURE_ALGORITHM_DOC"/>
        /// </summary>
        public static string INTER_WORKER_SIGNATURE_ALGORITHM_DOC { get { return SGetField<string>(LocalBridgeClazz, "INTER_WORKER_SIGNATURE_ALGORITHM_DOC"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#INTER_WORKER_VERIFICATION_ALGORITHMS_CONFIG"/>
        /// </summary>
        public static string INTER_WORKER_VERIFICATION_ALGORITHMS_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "INTER_WORKER_VERIFICATION_ALGORITHMS_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#INTER_WORKER_VERIFICATION_ALGORITHMS_DOC"/>
        /// </summary>
        public static string INTER_WORKER_VERIFICATION_ALGORITHMS_DOC { get { return SGetField<string>(LocalBridgeClazz, "INTER_WORKER_VERIFICATION_ALGORITHMS_DOC"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#OFFSET_STORAGE_PARTITIONS_CONFIG"/>
        /// </summary>
        public static string OFFSET_STORAGE_PARTITIONS_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "OFFSET_STORAGE_PARTITIONS_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#OFFSET_STORAGE_PREFIX"/>
        /// </summary>
        public static string OFFSET_STORAGE_PREFIX { get { return SGetField<string>(LocalBridgeClazz, "OFFSET_STORAGE_PREFIX"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#OFFSET_STORAGE_REPLICATION_FACTOR_CONFIG"/>
        /// </summary>
        public static string OFFSET_STORAGE_REPLICATION_FACTOR_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "OFFSET_STORAGE_REPLICATION_FACTOR_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#OFFSET_STORAGE_TOPIC_CONFIG"/>
        /// </summary>
        public static string OFFSET_STORAGE_TOPIC_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "OFFSET_STORAGE_TOPIC_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#PARTITIONS_SUFFIX"/>
        /// </summary>
        public static string PARTITIONS_SUFFIX { get { return SGetField<string>(LocalBridgeClazz, "PARTITIONS_SUFFIX"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#REBALANCE_TIMEOUT_MS_CONFIG"/>
        /// </summary>
        public static string REBALANCE_TIMEOUT_MS_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "REBALANCE_TIMEOUT_MS_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#REPLICATION_FACTOR_SUFFIX"/>
        /// </summary>
        public static string REPLICATION_FACTOR_SUFFIX { get { return SGetField<string>(LocalBridgeClazz, "REPLICATION_FACTOR_SUFFIX"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#SCHEDULED_REBALANCE_MAX_DELAY_MS_CONFIG"/>
        /// </summary>
        public static string SCHEDULED_REBALANCE_MAX_DELAY_MS_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "SCHEDULED_REBALANCE_MAX_DELAY_MS_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#SCHEDULED_REBALANCE_MAX_DELAY_MS_DOC"/>
        /// </summary>
        public static string SCHEDULED_REBALANCE_MAX_DELAY_MS_DOC { get { return SGetField<string>(LocalBridgeClazz, "SCHEDULED_REBALANCE_MAX_DELAY_MS_DOC"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#SESSION_TIMEOUT_MS_CONFIG"/>
        /// </summary>
        public static string SESSION_TIMEOUT_MS_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "SESSION_TIMEOUT_MS_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#STATUS_STORAGE_PARTITIONS_CONFIG"/>
        /// </summary>
        public static string STATUS_STORAGE_PARTITIONS_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "STATUS_STORAGE_PARTITIONS_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#STATUS_STORAGE_PREFIX"/>
        /// </summary>
        public static string STATUS_STORAGE_PREFIX { get { return SGetField<string>(LocalBridgeClazz, "STATUS_STORAGE_PREFIX"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#STATUS_STORAGE_REPLICATION_FACTOR_CONFIG"/>
        /// </summary>
        public static string STATUS_STORAGE_REPLICATION_FACTOR_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "STATUS_STORAGE_REPLICATION_FACTOR_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#STATUS_STORAGE_TOPIC_CONFIG"/>
        /// </summary>
        public static string STATUS_STORAGE_TOPIC_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "STATUS_STORAGE_TOPIC_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#STATUS_STORAGE_TOPIC_CONFIG_DOC"/>
        /// </summary>
        public static string STATUS_STORAGE_TOPIC_CONFIG_DOC { get { return SGetField<string>(LocalBridgeClazz, "STATUS_STORAGE_TOPIC_CONFIG_DOC"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#TOPIC_SUFFIX"/>
        /// </summary>
        public static string TOPIC_SUFFIX { get { return SGetField<string>(LocalBridgeClazz, "TOPIC_SUFFIX"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#WORKER_SYNC_TIMEOUT_MS_CONFIG"/>
        /// </summary>
        public static string WORKER_SYNC_TIMEOUT_MS_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "WORKER_SYNC_TIMEOUT_MS_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#WORKER_UNSYNC_BACKOFF_MS_CONFIG"/>
        /// </summary>
        public static string WORKER_UNSYNC_BACKOFF_MS_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "WORKER_UNSYNC_BACKOFF_MS_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#INTER_WORKER_VERIFICATION_ALGORITHMS_DEFAULT"/>
        /// </summary>
        public static Java.Util.List INTER_WORKER_VERIFICATION_ALGORITHMS_DEFAULT { get { return SGetField<Java.Util.List>(LocalBridgeClazz, "INTER_WORKER_VERIFICATION_ALGORITHMS_DEFAULT"); } }

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#transactionalProducerId(java.lang.String)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="string"/></returns>
        public static string TransactionalProducerId(string arg0)
        {
            return SExecute<string>(LocalBridgeClazz, "transactionalProducerId", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#main(java.lang.String[])"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        public static void Main(string[] arg0)
        {
            SExecute(LocalBridgeClazz, "main", new object[] { arg0 });
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#getInternalRequestKeyGenerator()"/> 
        /// </summary>
        public Javax.Crypto.KeyGenerator InternalRequestKeyGenerator
        {
            get { return IExecute<Javax.Crypto.KeyGenerator>("getInternalRequestKeyGenerator"); }
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#transactionalLeaderEnabled()"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool TransactionalLeaderEnabled()
        {
            return IExecute<bool>("transactionalLeaderEnabled");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#transactionalProducerId()"/>
        /// </summary>

        /// <returns><see cref="string"/></returns>
        public string TransactionalProducerId()
        {
            return IExecute<string>("transactionalProducerId");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#configStorageTopicSettings()"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Map"/></returns>
        public Java.Util.Map<string, object> ConfigStorageTopicSettings()
        {
            return IExecute<Java.Util.Map<string, object>>("configStorageTopicSettings");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#offsetStorageTopicSettings()"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Map"/></returns>
        public Java.Util.Map<string, object> OffsetStorageTopicSettings()
        {
            return IExecute<Java.Util.Map<string, object>>("offsetStorageTopicSettings");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/distributed/DistributedConfig.html#statusStorageTopicSettings()"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Map"/></returns>
        public Java.Util.Map<string, object> StatusStorageTopicSettings()
        {
            return IExecute<Java.Util.Map<string, object>>("statusStorageTopicSettings");
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}