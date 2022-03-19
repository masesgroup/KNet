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

using MASES.KNet.Clients;
using MASES.KNet.Common.Config;
using Java.Util;

namespace MASES.KNet.Streams
{
    public class StreamsConfig : AbstractConfig<StreamsConfig>
    {
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

        [System.Obsolete]
        public static readonly string EXACTLY_ONCE = Clazz.GetField<string>("EXACTLY_ONCE");

        [System.Obsolete]
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

        [System.Obsolete]
        public static readonly string DEFAULT_WINDOWED_KEY_SERDE_INNER_CLASS = Clazz.GetField<string>("DEFAULT_WINDOWED_KEY_SERDE_INNER_CLASS");

        [System.Obsolete]
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

        [System.Obsolete]
        public static readonly string TOPOLOGY_OPTIMIZATION = Clazz.GetField<string>("TOPOLOGY_OPTIMIZATION");

        [System.Obsolete("This is not public in Apache Kafka API")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public StreamsConfig() { }

        public StreamsConfig(Map props)
            : base(props)
        {
        }
    }

    public class StreamsConfigBuilder : CommonClientConfigsBuilder<StreamsConfigBuilder>
    {
        public string ApplicationId { get { return GetProperty<string>(StreamsConfig.APPLICATION_ID_CONFIG); } set { SetProperty(StreamsConfig.APPLICATION_ID_CONFIG, value); } }

        public StreamsConfigBuilder WithApplicationId(string applicationId)
        {
            var clone = Clone();
            clone.ApplicationId = applicationId;
            return clone;
        }

        public int NumStandByReplicas { get { return GetProperty<int>(StreamsConfig.NUM_STANDBY_REPLICAS_CONFIG); } set { SetProperty(StreamsConfig.NUM_STANDBY_REPLICAS_CONFIG, value); } }

        public StreamsConfigBuilder WithNumStandByReplicas(int numStandByReplicas)
        {
            var clone = Clone();
            clone.NumStandByReplicas = numStandByReplicas;
            return clone;
        }

        public string StateDir { get { return GetProperty<string>(StreamsConfig.STATE_DIR_CONFIG); } set { SetProperty(StreamsConfig.STATE_DIR_CONFIG, value); } }

        public StreamsConfigBuilder WithStateDir(string stateDir)
        {
            var clone = Clone();
            clone.StateDir = stateDir;
            return clone;
        }

        public long AcceptableRecoveryLag { get { return GetProperty<int>(StreamsConfig.ACCEPTABLE_RECOVERY_LAG_CONFIG); } set { SetProperty(StreamsConfig.ACCEPTABLE_RECOVERY_LAG_CONFIG, value); } }

        public StreamsConfigBuilder WithAcceptableRecoveryLag(long acceptableRecoveryLag)
        {
            var clone = Clone();
            clone.AcceptableRecoveryLag = acceptableRecoveryLag;
            return clone;
        }

        public long CacheMaxBytesBuffering { get { return GetProperty<int>(StreamsConfig.CACHE_MAX_BYTES_BUFFERING_CONFIG); } set { SetProperty(StreamsConfig.CACHE_MAX_BYTES_BUFFERING_CONFIG, value); } }

        public StreamsConfigBuilder WithCacheMaxBytesBuffering(long cacheMaxBytesBuffering)
        {
            var clone = Clone();
            clone.CacheMaxBytesBuffering = cacheMaxBytesBuffering;
            return clone;
        }

        [System.Obsolete("To be checked")]
        public dynamic DefaultDeserializationExceptionHandlerClass { get { return GetProperty<dynamic>(StreamsConfig.DEFAULT_DESERIALIZATION_EXCEPTION_HANDLER_CLASS_CONFIG); } set { SetProperty(StreamsConfig.DEFAULT_DESERIALIZATION_EXCEPTION_HANDLER_CLASS_CONFIG, value); } }

        [System.Obsolete("To be checked")]
        public StreamsConfigBuilder WithDefaultDeserializationExceptionHandlerClass(dynamic defaultDeserializationExceptionHandlerClass)
        {
            var clone = Clone();
            clone.DefaultDeserializationExceptionHandlerClass = defaultDeserializationExceptionHandlerClass;
            return clone;
        }

        [System.Obsolete("To be checked")]
        public dynamic DefaultKeySerdeClass { get { return GetProperty<dynamic>(StreamsConfig.DEFAULT_KEY_SERDE_CLASS_CONFIG); } set { SetProperty(StreamsConfig.DEFAULT_KEY_SERDE_CLASS_CONFIG, value); } }

        [System.Obsolete("To be checked")]
        public StreamsConfigBuilder WithDefaultKeySerdeClass(dynamic defaultKeySerdeClass)
        {
            var clone = Clone();
            clone.DefaultKeySerdeClass = defaultKeySerdeClass;
            return clone;
        }

        [System.Obsolete("To be checked")]
        public dynamic DefaultProductionExceptionHandlerClass { get { return GetProperty<dynamic>(StreamsConfig.DEFAULT_PRODUCTION_EXCEPTION_HANDLER_CLASS_CONFIG); } set { SetProperty(StreamsConfig.DEFAULT_PRODUCTION_EXCEPTION_HANDLER_CLASS_CONFIG, value); } }

        [System.Obsolete("To be checked")]
        public StreamsConfigBuilder WithDefaultProductionExceptionHandlerClass(dynamic defaultProductionExceptionHandlerClass)
        {
            var clone = Clone();
            clone.DefaultProductionExceptionHandlerClass = defaultProductionExceptionHandlerClass;
            return clone;
        }

        [System.Obsolete("To be checked")]
        public dynamic DefaultTimestampExtractorClass { get { return GetProperty<dynamic>(StreamsConfig.DEFAULT_TIMESTAMP_EXTRACTOR_CLASS_CONFIG); } set { SetProperty(StreamsConfig.DEFAULT_TIMESTAMP_EXTRACTOR_CLASS_CONFIG, value); } }

        [System.Obsolete("To be checked")]
        public StreamsConfigBuilder WithDefaultTimestampExtractorClass(dynamic defaultTimestampExtractorClass)
        {
            var clone = Clone();
            clone.DefaultTimestampExtractorClass = defaultTimestampExtractorClass;
            return clone;
        }

        [System.Obsolete("To be checked")]
        public dynamic DefaultValueSerdeClass { get { return GetProperty<dynamic>(StreamsConfig.DEFAULT_VALUE_SERDE_CLASS_CONFIG); } set { SetProperty(StreamsConfig.DEFAULT_VALUE_SERDE_CLASS_CONFIG, value); } }

        [System.Obsolete("To be checked")]
        public StreamsConfigBuilder WithDefaultValueSerdeClass(dynamic defaultValueSerdeClass)
        {
            var clone = Clone();
            clone.DefaultValueSerdeClass = defaultValueSerdeClass;
            return clone;
        }

        public long MaxTaskIdleMs { get { return GetProperty<int>(StreamsConfig.MAX_TASK_IDLE_MS_CONFIG); } set { SetProperty(StreamsConfig.MAX_TASK_IDLE_MS_CONFIG, value); } }

        public StreamsConfigBuilder WithMaxTaskIdleMs(long maxTaskIdleMs)
        {
            var clone = Clone();
            clone.MaxTaskIdleMs = maxTaskIdleMs;
            return clone;
        }

        public int MaxWarmupReplicas { get { return GetProperty<int>(StreamsConfig.MAX_WARMUP_REPLICAS_CONFIG); } set { SetProperty(StreamsConfig.MAX_WARMUP_REPLICAS_CONFIG, value); } }

        public StreamsConfigBuilder WithMaxWarmupReplicas(int maxWarmupReplicas)
        {
            var clone = Clone();
            clone.MaxWarmupReplicas = maxWarmupReplicas;
            return clone;
        }

        public int NumStreamThreads { get { return GetProperty<int>(StreamsConfig.NUM_STREAM_THREADS_CONFIG); } set { SetProperty(StreamsConfig.NUM_STREAM_THREADS_CONFIG, value); } }

        public StreamsConfigBuilder WithNumStreamThreads(int numStreamThreads)
        {
            var clone = Clone();
            clone.NumStreamThreads = numStreamThreads;
            return clone;
        }

        public int ReplicationFactor { get { return GetProperty<int>(StreamsConfig.REPLICATION_FACTOR_CONFIG); } set { SetProperty(StreamsConfig.REPLICATION_FACTOR_CONFIG, value); } }

        public StreamsConfigBuilder WithReplicationFactor(int replicationFactor)
        {
            var clone = Clone();
            clone.ReplicationFactor = replicationFactor;
            return clone;
        }

        public long TaskTimeoutMs { get { return GetProperty<long>(StreamsConfig.TASK_TIMEOUT_MS_CONFIG); } set { SetProperty(StreamsConfig.TASK_TIMEOUT_MS_CONFIG, value); } }

        public StreamsConfigBuilder WithTaskTimeoutMs(long taskTimeoutMs)
        {
            var clone = Clone();
            clone.TaskTimeoutMs = taskTimeoutMs;
            return clone;
        }

        public bool TopologyOptimization { get { return GetProperty<string>(StreamsConfig.TOPOLOGY_OPTIMIZATION_CONFIG) == StreamsConfig.OPTIMIZE; } set { SetProperty(StreamsConfig.TOPOLOGY_OPTIMIZATION_CONFIG, value ? StreamsConfig.OPTIMIZE : StreamsConfig.NO_OPTIMIZATION); } }

        public StreamsConfigBuilder WithTopologyOptimization(bool topologyOptimization)
        {
            var clone = Clone();
            clone.TopologyOptimization = topologyOptimization;
            return clone;
        }

        public string ApplicationServer { get { return GetProperty<string>(StreamsConfig.APPLICATION_SERVER_CONFIG); } set { SetProperty(StreamsConfig.APPLICATION_SERVER_CONFIG, value); } }

        public StreamsConfigBuilder WithApplicationServer(string applicationServer)
        {
            var clone = Clone();
            clone.ApplicationServer = applicationServer;
            return clone;
        }

        public int BufferedRecordsPerPartition { get { return GetProperty<int>(StreamsConfig.BUFFERED_RECORDS_PER_PARTITION_CONFIG); } set { SetProperty(StreamsConfig.BUFFERED_RECORDS_PER_PARTITION_CONFIG, value); } }

        public StreamsConfigBuilder WithBufferedRecordsPerPartition(int bufferedRecordsPerPartition)
        {
            var clone = Clone();
            clone.BufferedRecordsPerPartition = bufferedRecordsPerPartition;
            return clone;
        }

        public string BuiltInMetricsVersion { get { return GetProperty<string>(StreamsConfig.BUILT_IN_METRICS_VERSION_CONFIG); } set { SetProperty(StreamsConfig.BUILT_IN_METRICS_VERSION_CONFIG, value); } }

        public StreamsConfigBuilder WithBuiltInMetricsVersion(string builtInMetricsVersion)
        {
            var clone = Clone();
            clone.BuiltInMetricsVersion = builtInMetricsVersion;
            return clone;
        }

        public long CommitIntervalMs { get { return GetProperty<long>(StreamsConfig.COMMIT_INTERVAL_MS_CONFIG); } set { SetProperty(StreamsConfig.COMMIT_INTERVAL_MS_CONFIG, value); } }

        public StreamsConfigBuilder WithCommitIntervalMs(long commitIntervalMs)
        {
            var clone = Clone();
            clone.CommitIntervalMs = commitIntervalMs;
            return clone;
        }

        public long ProbingRebalanceIntervalMs { get { return GetProperty<long>(StreamsConfig.PROBING_REBALANCE_INTERVAL_MS_CONFIG); } set { SetProperty(StreamsConfig.PROBING_REBALANCE_INTERVAL_MS_CONFIG, value); } }

        public StreamsConfigBuilder WithProbingRebalanceIntervalMs(long probingRebalanceIntervalMs)
        {
            var clone = Clone();
            clone.ProbingRebalanceIntervalMs = probingRebalanceIntervalMs;
            return clone;
        }

        [System.Obsolete("To be checked")]
        public dynamic RocksDbConfigSetterClass { get { return GetProperty<dynamic>(StreamsConfig.ROCKSDB_CONFIG_SETTER_CLASS_CONFIG); } set { SetProperty(StreamsConfig.ROCKSDB_CONFIG_SETTER_CLASS_CONFIG, value); } }

        [System.Obsolete("To be checked")]
        public StreamsConfigBuilder WithRocksDbConfigSetterClass(dynamic rocksDbConfigSetterClass)
        {
            var clone = Clone();
            clone.RocksDbConfigSetterClass = rocksDbConfigSetterClass;
            return clone;
        }

        public long StateCleanupDelayMs { get { return GetProperty<long>(StreamsConfig.STATE_CLEANUP_DELAY_MS_CONFIG); } set { SetProperty(StreamsConfig.STATE_CLEANUP_DELAY_MS_CONFIG, value); } }

        public StreamsConfigBuilder WithStateCleanupDelayMs(long stateCleanupDelayMs)
        {
            var clone = Clone();
            clone.StateCleanupDelayMs = stateCleanupDelayMs;
            return clone;
        }

        public string UpgradeFrom { get { return GetProperty<string>(StreamsConfig.UPGRADE_FROM_CONFIG); } set { SetProperty(StreamsConfig.UPGRADE_FROM_CONFIG, value); } }

        public StreamsConfigBuilder WithUpgradeFrom(string upgradeFrom)
        {
            var clone = Clone();
            clone.UpgradeFrom = upgradeFrom;
            return clone;
        }

        public string WindowedInnerClassSerde { get { return GetProperty<string>(StreamsConfig.WINDOWED_INNER_CLASS_SERDE); } set { SetProperty(StreamsConfig.WINDOWED_INNER_CLASS_SERDE, value); } }

        public StreamsConfigBuilder WithWindowedInnerClassSerde(string windowedInnerClassSerde)
        {
            var clone = Clone();
            clone.WindowedInnerClassSerde = windowedInnerClassSerde;
            return clone;
        }

        public long WindowStoreChangeLogAdditionalRetentionMs{ get { return GetProperty<long>(StreamsConfig.WINDOW_STORE_CHANGE_LOG_ADDITIONAL_RETENTION_MS_CONFIG); } set { SetProperty(StreamsConfig.WINDOW_STORE_CHANGE_LOG_ADDITIONAL_RETENTION_MS_CONFIG, value); } }

        public StreamsConfigBuilder WithWindowStoreChangeLogAdditionalRetentionMs(long windowStoreChangeLogAdditionalRetentionMs)
        {
            var clone = Clone();
            clone.WindowStoreChangeLogAdditionalRetentionMs = windowStoreChangeLogAdditionalRetentionMs;
            return clone;
        }

        public long WindowSizeMs { get { return GetProperty<long>(StreamsConfig.WINDOW_SIZE_MS_CONFIG); } set { SetProperty(StreamsConfig.WINDOW_SIZE_MS_CONFIG, value); } }

        public StreamsConfigBuilder WithWindowSizeMs(long windowSizeMs)
        {
            var clone = Clone();
            clone.WindowSizeMs = windowSizeMs;
            return clone;
        }
    }
}
