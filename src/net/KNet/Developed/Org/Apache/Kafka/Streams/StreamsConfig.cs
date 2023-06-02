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

using Org.Apache.Kafka.Clients;
using Org.Apache.Kafka.Common.Config;
using Java.Util;

namespace Org.Apache.Kafka.Streams
{
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

        public long StateStoreMaxBytesBuffering { get { return GetProperty<int>(StreamsConfig.STATESTORE_CACHE_MAX_BYTES_CONFIG); } set { SetProperty(StreamsConfig.STATESTORE_CACHE_MAX_BYTES_CONFIG, value); } }

        public StreamsConfigBuilder WithStateStoreMaxBytesBuffering(long stateStoreMaxBytesBuffering)
        {
            var clone = Clone();
            clone.StateStoreMaxBytesBuffering = stateStoreMaxBytesBuffering;
            return clone;
        }

        [System.Obsolete("To be checked")]
        public Java.Lang.Class DefaultDeserializationExceptionHandlerClass { get { return GetProperty<Java.Lang.Class>(StreamsConfig.DEFAULT_DESERIALIZATION_EXCEPTION_HANDLER_CLASS_CONFIG); } set { SetProperty(StreamsConfig.DEFAULT_DESERIALIZATION_EXCEPTION_HANDLER_CLASS_CONFIG, value); } }

        [System.Obsolete("To be checked")]
        public StreamsConfigBuilder WithDefaultDeserializationExceptionHandlerClass(Java.Lang.Class defaultDeserializationExceptionHandlerClass)
        {
            var clone = Clone();
            clone.DefaultDeserializationExceptionHandlerClass = defaultDeserializationExceptionHandlerClass;
            return clone;
        }

        [System.Obsolete("To be checked")]
        public Java.Lang.Class DefaultKeySerdeClass { get { return GetProperty<Java.Lang.Class>(StreamsConfig.DEFAULT_KEY_SERDE_CLASS_CONFIG); } set { SetProperty(StreamsConfig.DEFAULT_KEY_SERDE_CLASS_CONFIG, value); } }

        [System.Obsolete("To be checked")]
        public StreamsConfigBuilder WithDefaultKeySerdeClass(Java.Lang.Class defaultKeySerdeClass)
        {
            var clone = Clone();
            clone.DefaultKeySerdeClass = defaultKeySerdeClass;
            return clone;
        }

        [System.Obsolete("To be checked")]
        public Java.Lang.Class DefaultProductionExceptionHandlerClass { get { return GetProperty<Java.Lang.Class>(StreamsConfig.DEFAULT_PRODUCTION_EXCEPTION_HANDLER_CLASS_CONFIG); } set { SetProperty(StreamsConfig.DEFAULT_PRODUCTION_EXCEPTION_HANDLER_CLASS_CONFIG, value); } }

        [System.Obsolete("To be checked")]
        public StreamsConfigBuilder WithDefaultProductionExceptionHandlerClass(Java.Lang.Class defaultProductionExceptionHandlerClass)
        {
            var clone = Clone();
            clone.DefaultProductionExceptionHandlerClass = defaultProductionExceptionHandlerClass;
            return clone;
        }

        public string DefaultDSLStore { get { return GetProperty<string>(StreamsConfig.DEFAULT_DSL_STORE_CONFIG); } set { SetProperty(StreamsConfig.DEFAULT_DSL_STORE_CONFIG, value); } }

        public StreamsConfigBuilder WithDefaultDSLStore(string defaultDSLStore)
        {
            var clone = Clone();
            clone.DefaultDSLStore = defaultDSLStore;
            return clone;
        }

        [System.Obsolete("To be checked")]
        public Java.Lang.Class DefaultTimestampExtractorClass { get { return GetProperty<Java.Lang.Class>(StreamsConfig.DEFAULT_TIMESTAMP_EXTRACTOR_CLASS_CONFIG); } set { SetProperty(StreamsConfig.DEFAULT_TIMESTAMP_EXTRACTOR_CLASS_CONFIG, value); } }

        [System.Obsolete("To be checked")]
        public StreamsConfigBuilder WithDefaultTimestampExtractorClass(Java.Lang.Class defaultTimestampExtractorClass)
        {
            var clone = Clone();
            clone.DefaultTimestampExtractorClass = defaultTimestampExtractorClass;
            return clone;
        }

        [System.Obsolete("To be checked")]
        public Java.Lang.Class DefaultValueSerdeClass { get { return GetProperty<Java.Lang.Class>(StreamsConfig.DEFAULT_VALUE_SERDE_CLASS_CONFIG); } set { SetProperty(StreamsConfig.DEFAULT_VALUE_SERDE_CLASS_CONFIG, value); } }

        [System.Obsolete("To be checked")]
        public StreamsConfigBuilder WithDefaultValueSerdeClass(Java.Lang.Class defaultValueSerdeClass)
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

        public long RepartitionPurgeIntervalMs { get { return GetProperty<long>(StreamsConfig.REPARTITION_PURGE_INTERVAL_MS_CONFIG); } set { SetProperty(StreamsConfig.REPARTITION_PURGE_INTERVAL_MS_CONFIG, value); } }

        public StreamsConfigBuilder WithRepartitionPurgeIntervalMs(long repartitionPurgeIntervalMs)
        {
            var clone = Clone();
            clone.RepartitionPurgeIntervalMs = repartitionPurgeIntervalMs;
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
        public Java.Lang.Class RocksDbConfigSetterClass { get { return GetProperty<Java.Lang.Class>(StreamsConfig.ROCKSDB_CONFIG_SETTER_CLASS_CONFIG); } set { SetProperty(StreamsConfig.ROCKSDB_CONFIG_SETTER_CLASS_CONFIG, value); } }

        [System.Obsolete("To be checked")]
        public StreamsConfigBuilder WithRocksDbConfigSetterClass(Java.Lang.Class rocksDbConfigSetterClass)
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

        public long WindowStoreChangeLogAdditionalRetentionMs { get { return GetProperty<long>(StreamsConfig.WINDOW_STORE_CHANGE_LOG_ADDITIONAL_RETENTION_MS_CONFIG); } set { SetProperty(StreamsConfig.WINDOW_STORE_CHANGE_LOG_ADDITIONAL_RETENTION_MS_CONFIG, value); } }

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
