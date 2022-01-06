/*
*  Copyright 2022 MASES s.r.l.
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

using System;

namespace MASES.KafkaBridge.Streams
{
    public class StreamsConfig : JCOBridge.C2JBridge.JVMBridgeBase<StreamsConfig>
    {
        public override bool IsStatic => true;
        public override string ClassName => "org.apache.kafka.streams.StreamsConfig";

        public static readonly string TOPIC_PREFIX = Clazz.GetField<string>("TOPIC_PREFIX");

        public static readonly string CONSUMER_PREFIX = Clazz.GetField<string>("CONSUMER_PREFIX");

        public static readonly string MAIN_CONSUMER_PREFIX = Clazz.GetField<string>("MAIN_CONSUMER_PREFIX");

        public static readonly string RESTORE_CONSUMER_PREFIX = Clazz.GetField<string>("RESTORE_CONSUMER_PREFIX");

        public static readonly string GLOBAL_CONSUMER_PREFIX = Clazz.GetField<string>("GLOBAL_CONSUMER_PREFIX");

        public static readonly string PRODUCER_PREFIX = Clazz.GetField<string>("PRODUCER_PREFIX");

        public static readonly string ADMIN_CLIENT_PREFIX = Clazz.GetField<string>("ADMIN_CLIENT_PREFIX");

        public static readonly string NO_OPTIMIZATION = Clazz.GetField<string>("NO_OPTIMIZATION");

        public static readonly string OPTIMIZE = Clazz.GetField<string>("OPTIMIZE");

        public static readonly string UPGRADE_FROM_0100 = Clazz.GetField<string>("UPGRADE_FROM_0100");

        public static readonly string UPGRADE_FROM_0101 = Clazz.GetField<string>("UPGRADE_FROM_0101");

        public static readonly string UPGRADE_FROM_0102 = Clazz.GetField<string>("UPGRADE_FROM_0102");

        public static readonly string UPGRADE_FROM_0110 = Clazz.GetField<string>("UPGRADE_FROM_0110");

        public static readonly string UPGRADE_FROM_10 = Clazz.GetField<string>("UPGRADE_FROM_10");

        public static readonly string UPGRADE_FROM_11 = Clazz.GetField<string>("UPGRADE_FROM_11");

        public static readonly string UPGRADE_FROM_20 = Clazz.GetField<string>("UPGRADE_FROM_20");

        public static readonly string UPGRADE_FROM_21 = Clazz.GetField<string>("UPGRADE_FROM_21");

        public static readonly string UPGRADE_FROM_22 = Clazz.GetField<string>("UPGRADE_FROM_22");

        public static readonly string UPGRADE_FROM_23 = Clazz.GetField<string>("UPGRADE_FROM_23");

        public static readonly string AT_LEAST_ONCE = Clazz.GetField<string>("AT_LEAST_ONCE");

        [Obsolete]
        public static readonly string EXACTLY_ONCE = Clazz.GetField<string>("EXACTLY_ONCE");

        [Obsolete]
        public static readonly string EXACTLY_ONCE_BETA = Clazz.GetField<string>("EXACTLY_ONCE_BETA");

        public static readonly string EXACTLY_ONCE_V2 = Clazz.GetField<string>("EXACTLY_ONCE_V2");

        public static readonly string METRICS_LATEST = Clazz.GetField<string>("METRICS_LATEST");

        public static readonly string ACCEPTABLE_RECOVERY_LAG_CONFIG = Clazz.GetField<string>("ACCEPTABLE_RECOVERY_LAG_CONFIG");

        public static readonly string APPLICATION_ID_CONFIG = Clazz.GetField<string>("APPLICATION_ID_CONFIG");

        public static readonly string APPLICATION_SERVER_CONFIG = Clazz.GetField<string>("APPLICATION_SERVER_CONFIG");

        public static readonly string BOOTSTRAP_SERVERS_CONFIG = Clazz.GetField<string>("BOOTSTRAP_SERVERS_CONFIG");

        public static readonly string BUFFERED_RECORDS_PER_PARTITION_CONFIG = Clazz.GetField<string>("BUFFERED_RECORDS_PER_PARTITION_CONFIG");

        public static readonly string BUILT_IN_METRICS_VERSION_CONFIG = Clazz.GetField<string>("BUILT_IN_METRICS_VERSION_CONFIG");

        public static readonly string CACHE_MAX_BYTES_BUFFERING_CONFIG = Clazz.GetField<string>("CACHE_MAX_BYTES_BUFFERING_CONFIG");

        public static readonly string CLIENT_ID_CONFIG = Clazz.GetField<string>("CLIENT_ID_CONFIG");

        public static readonly string COMMIT_INTERVAL_MS_CONFIG = Clazz.GetField<string>("COMMIT_INTERVAL_MS_CONFIG");

        public static readonly string CONNECTIONS_MAX_IDLE_MS_CONFIG = Clazz.GetField<string>("CONNECTIONS_MAX_IDLE_MS_CONFIG");

        public static readonly string DEFAULT_DESERIALIZATION_EXCEPTION_HANDLER_CLASS_CONFIG = Clazz.GetField<string>("DEFAULT_DESERIALIZATION_EXCEPTION_HANDLER_CLASS_CONFIG");

        public static readonly string DEFAULT_PRODUCTION_EXCEPTION_HANDLER_CLASS_CONFIG = Clazz.GetField<string>("DEFAULT_PRODUCTION_EXCEPTION_HANDLER_CLASS_CONFIG");

        [Obsolete]
        public static readonly string DEFAULT_WINDOWED_KEY_SERDE_INNER_CLASS = Clazz.GetField<string>("DEFAULT_WINDOWED_KEY_SERDE_INNER_CLASS");

        [Obsolete]
        public static readonly string DEFAULT_WINDOWED_VALUE_SERDE_INNER_CLASS = Clazz.GetField<string>("DEFAULT_WINDOWED_VALUE_SERDE_INNER_CLASS");

        public static readonly string WINDOWED_INNER_CLASS_SERDE = Clazz.GetField<string>("WINDOWED_INNER_CLASS_SERDE");

        public static readonly string DEFAULT_KEY_SERDE_CLASS_CONFIG = Clazz.GetField<string>("DEFAULT_KEY_SERDE_CLASS_CONFIG");

        public static readonly string DEFAULT_VALUE_SERDE_CLASS_CONFIG = Clazz.GetField<string>("DEFAULT_VALUE_SERDE_CLASS_CONFIG");

        public static readonly string DEFAULT_TIMESTAMP_EXTRACTOR_CLASS_CONFIG = Clazz.GetField<string>("DEFAULT_TIMESTAMP_EXTRACTOR_CLASS_CONFIG");

        public static readonly string MAX_TASK_IDLE_MS_CONFIG = Clazz.GetField<string>("MAX_TASK_IDLE_MS_CONFIG");

        public static readonly string MAX_WARMUP_REPLICAS_CONFIG = Clazz.GetField<string>("MAX_WARMUP_REPLICAS_CONFIG");

        public static readonly string METADATA_MAX_AGE_CONFIG = Clazz.GetField<string>("METADATA_MAX_AGE_CONFIG");

        public static readonly string METRICS_NUM_SAMPLES_CONFIG = Clazz.GetField<string>("METRICS_NUM_SAMPLES_CONFIG");

        public static readonly string METRICS_RECORDING_LEVEL_CONFIG = Clazz.GetField<string>("METRICS_RECORDING_LEVEL_CONFIG");

        public static readonly string METRIC_REPORTER_CLASSES_CONFIG = Clazz.GetField<string>("METRIC_REPORTER_CLASSES_CONFIG");

        public static readonly string METRICS_SAMPLE_WINDOW_MS_CONFIG = Clazz.GetField<string>("METRICS_SAMPLE_WINDOW_MS_CONFIG");

        public static readonly string NUM_STANDBY_REPLICAS_CONFIG = Clazz.GetField<string>("NUM_STANDBY_REPLICAS_CONFIG");

        public static readonly string NUM_STREAM_THREADS_CONFIG = Clazz.GetField<string>("NUM_STREAM_THREADS_CONFIG");

        public static readonly string POLL_MS_CONFIG = Clazz.GetField<string>("POLL_MS_CONFIG");

        public static readonly string PROBING_REBALANCE_INTERVAL_MS_CONFIG = Clazz.GetField<string>("PROBING_REBALANCE_INTERVAL_MS_CONFIG");

        public static readonly string PROCESSING_GUARANTEE_CONFIG = Clazz.GetField<string>("PROCESSING_GUARANTEE_CONFIG");

        public static readonly string RECEIVE_BUFFER_CONFIG = Clazz.GetField<string>("RECEIVE_BUFFER_CONFIG");

        public static readonly string RECONNECT_BACKOFF_MS_CONFIG = Clazz.GetField<string>("RECONNECT_BACKOFF_MS_CONFIG");

        public static readonly string RECONNECT_BACKOFF_MAX_MS_CONFIG = Clazz.GetField<string>("RECONNECT_BACKOFF_MAX_MS_CONFIG");

        public static readonly string REPLICATION_FACTOR_CONFIG = Clazz.GetField<string>("REPLICATION_FACTOR_CONFIG");

        public static readonly string REQUEST_TIMEOUT_MS_CONFIG = Clazz.GetField<string>("REQUEST_TIMEOUT_MS_CONFIG");

        public static readonly string RETRIES_CONFIG = Clazz.GetField<string>("RETRIES_CONFIG");

        public static readonly string RETRY_BACKOFF_MS_CONFIG = Clazz.GetField<string>("RETRY_BACKOFF_MS_CONFIG");

        public static readonly string ROCKSDB_CONFIG_SETTER_CLASS_CONFIG = Clazz.GetField<string>("ROCKSDB_CONFIG_SETTER_CLASS_CONFIG");

        public static readonly string SECURITY_PROTOCOL_CONFIG = Clazz.GetField<string>("SECURITY_PROTOCOL_CONFIG");

        public static readonly string SEND_BUFFER_CONFIG = Clazz.GetField<string>("SEND_BUFFER_CONFIG");

        public static readonly string STATE_CLEANUP_DELAY_MS_CONFIG = Clazz.GetField<string>("STATE_CLEANUP_DELAY_MS_CONFIG");

        public static readonly string STATE_DIR_CONFIG = Clazz.GetField<string>("STATE_DIR_CONFIG");

        public static readonly string TASK_TIMEOUT_MS_CONFIG = Clazz.GetField<string>("TASK_TIMEOUT_MS_CONFIG");

        public static readonly string TOPOLOGY_OPTIMIZATION_CONFIG = Clazz.GetField<string>("TOPOLOGY_OPTIMIZATION_CONFIG");

        public static readonly string WINDOW_SIZE_MS_CONFIG = Clazz.GetField<string>("WINDOW_SIZE_MS_CONFIG");

        public static readonly string UPGRADE_FROM_CONFIG = Clazz.GetField<string>("UPGRADE_FROM_CONFIG");

        public static readonly string WINDOW_STORE_CHANGE_LOG_ADDITIONAL_RETENTION_MS_CONFIG = Clazz.GetField<string>("WINDOW_STORE_CHANGE_LOG_ADDITIONAL_RETENTION_MS_CONFIG");

        [Obsolete]
        public static readonly string TOPOLOGY_OPTIMIZATION = Clazz.GetField<string>("TOPOLOGY_OPTIMIZATION");
    }
}
