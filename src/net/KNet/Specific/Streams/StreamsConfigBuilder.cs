/*
*  Copyright (c) 2021-2026 MASES s.r.l.
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

using Java.Lang;
using Java.Util;
using MASES.JCOBridge.C2JBridge;
using MASES.KNet.Specific.Streams;
using Org.Apache.Kafka.Streams;
using Org.Apache.Kafka.Streams.State;
using Org.Rocksdb;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace MASES.KNet.Streams
{
    /// <summary>
    /// Builder for <see cref="StreamsConfig"/>
    /// </summary>
    public class StreamsConfigBuilder : CommonClientConfigsBuilder<StreamsConfigBuilder>
    {
        class StreamsConfigBuilderKNetRocksDBConfigSetter(Action<string, Org.Rocksdb.Options, IKNetConfigurationFromMap, IDictionary<string, object>> onSetConfig,
                                                          Action<string, Org.Rocksdb.Options, IDictionary<string, object>> onClose) : KNetRocksDBConfigSetterCallback
        {
            ConcurrentDictionary<IntPtr, IDictionary<string, object>> _localStorage = new();

            public override void OnSetConfig(KNetRocksDBConfigSetter setter, string store, Org.Rocksdb.Options options, Map<Java.Lang.String, object> map)
            {
                if (_localStorage.ContainsKey(setter.BridgeInstance.Pointer)) throw new InvalidOperationException($"{nameof(OnSetConfig)} invoked twice from the same object.");
                IDictionary<string, object> keyValuePairs = new System.Collections.Generic.Dictionary<string, object>();
                onSetConfig?.Invoke(store, options, new KNetConfigurationFromMap(map), keyValuePairs);
                if (!_localStorage.TryAdd(setter.BridgeInstance.Pointer, keyValuePairs))
                {
                    throw new InvalidOperationException($"{nameof(OnSetConfig)} is unable to add configured information in local dictionary. A double invocation to {nameof(OnSetConfig)} was made by subsystem?");
                }
            }

            public override void OnClose(KNetRocksDBConfigSetter setter, string store, Org.Rocksdb.Options options)
            {
                if (_localStorage.TryRemove(setter.BridgeInstance.Pointer, out IDictionary<string, object> keyValuePairs))
                {
                    onClose?.Invoke(store, options, keyValuePairs);
                }
            }
        }

        static readonly object _callbackLock = new();
        static StreamsConfigBuilderKNetRocksDBConfigSetter _callback = null;
        /// <summary>
        /// <see langword="true"/> if a previous invocation of <see cref="SetRocksDBConfigSetterCallback"/> succeded
        /// </summary>
        public static bool RocksDBConfigSetterCallbackSet => _callback != null;

        /// <summary>
        /// Sets the global <see cref="KNetRocksDBConfigSetterCallback"/> will be shared across all requests of <see cref="KNetRocksDBConfigSetter"/>
        /// </summary>
        /// <param name="onSetConfig">Invoked when a new <see cref="KNetRocksDBConfigSetter"/> is requested and needs to be configured: the parameters are the same of <see cref="RocksDBConfigSetter.SetConfig(Java.Lang.String, Options, Map{Java.Lang.String, object})"/> with an extra parameter can be filled in with used specific information will be received back on <paramref name="onClose"/> invocation</param>
        /// <param name="onClose">Invoked when a previously configured instance of <see cref="KNetRocksDBConfigSetter"/> shall be closed: the parameters are the same of <see cref="RocksDBConfigSetter.Close(Java.Lang.String, Options)"/> with an extra parameter filled in when <paramref name="onSetConfig"/> was invoked</param>
        /// <remarks>The callbacks will be in effect only registering <see cref="KNetRocksDBConfigSetter"/> as <see cref="Java.Lang.Class"/> used from <see cref="RocksDbConfigSetterClass"/>:
        /// <code>
        /// StreamsConfigBuilder builder = StreamsConfigBuilder.Create();
        /// builder.RocksDbConfigSetterClass = KNetRocksDBConfigSetter.KNetRocksDBConfigSetterClass;
        /// ...
        /// builder.Build();
        /// </code>
        /// In general the fourth parameter of <paramref name="onSetConfig"/> can be used to store the reference to objects needs to be closed when <paramref name="onClose"/> is invoked.
        /// The example in <see href="https://docs.confluent.io/platform/current/streams/developer-guide/config-streams.html#rocksdb-config-setter"/> translates into:
        /// <code>
        /// void OnSetConfig(string store, Org.Rocksdb.Options options, IKNetConfigurationFromMap configs, IDictionary&lt;string, object&gt; data)
        /// {
        ///     Org.Rocksdb.Cache cache = new Org.Rocksdb.LRUCache(16 * 1024L * 1024L);
        ///     data.Add("cache", cache);
        ///     // See #1 in https://docs.confluent.io/platform/current/streams/developer-guide/config-streams.html#rocksdb-config-setter.
        ///     BlockBasedTableConfig tableConfig = options.TableFormatConfig().Cast&lt;BlockBasedTableConfig&gt;();
        ///     tableConfig.SetBlockCache(cache);
        ///     // See #2 in https://docs.confluent.io/platform/current/streams/developer-guide/config-streams.html#rocksdb-config-setter.
        ///     tableConfig.SetBlockSize(16 * 1024L);
        ///     // See #3 in https://docs.confluent.io/platform/current/streams/developer-guide/config-streams.html#rocksdb-config-setter.
        ///     tableConfig.SetCacheIndexAndFilterBlocks(true);
        ///     options.SetTableFormatConfig(tableConfig);
        ///     // See #4 in https://docs.confluent.io/platform/current/streams/developer-guide/config-streams.html#rocksdb-config-setter.
        ///     options.SetMaxWriteBufferNumber(2);
        /// }
        /// 
        /// void OnClose(string store, Org.Rocksdb.Options options, IDictionary&lt;string, object&gt; data)
        /// {
        ///     if (data.TryGetValue("cache", out var obj) &amp;&amp; obj is Org.Rocksdb.Cache cache)
        ///     {
        ///         // See #5 in https://docs.confluent.io/platform/current/streams/developer-guide/config-streams.html#rocksdb-config-setter.
        ///         cache.Close();
        ///     }
        /// }
        /// </code>
        /// </remarks>
        /// <exception cref="InvalidOperationException">If <see cref="SetRocksDBConfigSetterCallback"/> is invoked twice without an invocation to <see cref="ResetRocksDBConfigSetterCallback"/></exception>
        public static void SetRocksDBConfigSetterCallback(Action<string, Org.Rocksdb.Options, IKNetConfigurationFromMap, IDictionary<string, object>> onSetConfig,
                                                          Action<string, Org.Rocksdb.Options, IDictionary<string, object>> onClose)
        {
            lock (_callbackLock)
            {
                if (_callback != null) 
                {
                        throw new InvalidOperationException("The callbacks can be set only once per application.");
                }
                _callback = new StreamsConfigBuilderKNetRocksDBConfigSetter(onSetConfig, onClose);
                KNetRocksDBConfigSetter.SetCallback(_callback);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public static void ResetRocksDBConfigSetterCallback()
        {
            lock (_callbackLock)
            {
                KNetRocksDBConfigSetter.SetCallback(null);
                _callback?.Dispose();
                _callback = null;
            }
        }

        /// <summary>
        /// Manages <see cref="StreamsConfig.APPLICATION_ID_CONFIG"/>
        /// </summary>
        public string ApplicationId { get { return GetProperty<string>(StreamsConfig.APPLICATION_ID_CONFIG); } set { SetProperty(StreamsConfig.APPLICATION_ID_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="StreamsConfig.APPLICATION_ID_CONFIG"/>
        /// </summary>
        public StreamsConfigBuilder WithApplicationId(string applicationId)
        {
            var clone = Clone();
            clone.ApplicationId = applicationId;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="StreamsConfig.NUM_STANDBY_REPLICAS_CONFIG"/>
        /// </summary>
        public int NumStandByReplicas { get { return GetProperty<int>(StreamsConfig.NUM_STANDBY_REPLICAS_CONFIG); } set { SetProperty(StreamsConfig.NUM_STANDBY_REPLICAS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="StreamsConfig.NUM_STANDBY_REPLICAS_CONFIG"/>
        /// </summary>
        public StreamsConfigBuilder WithNumStandByReplicas(int numStandByReplicas)
        {
            var clone = Clone();
            clone.NumStandByReplicas = numStandByReplicas;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="StreamsConfig.STATE_DIR_CONFIG"/>
        /// </summary>
        public string StateDir { get { return GetProperty<string>(StreamsConfig.STATE_DIR_CONFIG); } set { SetProperty(StreamsConfig.STATE_DIR_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="StreamsConfig.STATE_DIR_CONFIG"/>
        /// </summary>
        public StreamsConfigBuilder WithStateDir(string stateDir)
        {
            var clone = Clone();
            clone.StateDir = stateDir;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="StreamsConfig.ACCEPTABLE_RECOVERY_LAG_CONFIG"/>
        /// </summary>
        public long AcceptableRecoveryLag { get { return GetProperty<long>(StreamsConfig.ACCEPTABLE_RECOVERY_LAG_CONFIG); } set { SetProperty(StreamsConfig.ACCEPTABLE_RECOVERY_LAG_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="StreamsConfig.ACCEPTABLE_RECOVERY_LAG_CONFIG"/>
        /// </summary>
        public StreamsConfigBuilder WithAcceptableRecoveryLag(long acceptableRecoveryLag)
        {
            var clone = Clone();
            clone.AcceptableRecoveryLag = acceptableRecoveryLag;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="StreamsConfig.STATESTORE_CACHE_MAX_BYTES_CONFIG"/>
        /// </summary>
        public long StateStoreMaxBytesBuffering { get { return GetProperty<int>(StreamsConfig.STATESTORE_CACHE_MAX_BYTES_CONFIG); } set { SetProperty(StreamsConfig.STATESTORE_CACHE_MAX_BYTES_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="StreamsConfig.STATESTORE_CACHE_MAX_BYTES_CONFIG"/>
        /// </summary>
        public StreamsConfigBuilder WithStateStoreMaxBytesBuffering(long stateStoreMaxBytesBuffering)
        {
            var clone = Clone();
            clone.StateStoreMaxBytesBuffering = stateStoreMaxBytesBuffering;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="StreamsConfig.DEFAULT_KEY_SERDE_CLASS_CONFIG"/>
        /// </summary>
        public Java.Lang.Class DefaultKeySerdeClass { get { return GetProperty<Java.Lang.Class>(StreamsConfig.DEFAULT_KEY_SERDE_CLASS_CONFIG); } set { SetProperty(StreamsConfig.DEFAULT_KEY_SERDE_CLASS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="StreamsConfig.DEFAULT_KEY_SERDE_CLASS_CONFIG"/>
        /// </summary>
        public StreamsConfigBuilder WithDefaultKeySerdeClass(Java.Lang.Class defaultKeySerdeClass)
        {
            var clone = Clone();
            clone.DefaultKeySerdeClass = defaultKeySerdeClass;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="StreamsConfig.DEFAULT_TIMESTAMP_EXTRACTOR_CLASS_CONFIG"/>
        /// </summary>
        public Java.Lang.Class DefaultTimestampExtractorClass { get { return GetProperty<Java.Lang.Class>(StreamsConfig.DEFAULT_TIMESTAMP_EXTRACTOR_CLASS_CONFIG); } set { SetProperty(StreamsConfig.DEFAULT_TIMESTAMP_EXTRACTOR_CLASS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="StreamsConfig.DEFAULT_TIMESTAMP_EXTRACTOR_CLASS_CONFIG"/>
        /// </summary>
        public StreamsConfigBuilder WithDefaultTimestampExtractorClass(Java.Lang.Class defaultTimestampExtractorClass)
        {
            var clone = Clone();
            clone.DefaultTimestampExtractorClass = defaultTimestampExtractorClass;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="StreamsConfig.DEFAULT_VALUE_SERDE_CLASS_CONFIG"/>
        /// </summary>
        public Java.Lang.Class DefaultValueSerdeClass { get { return GetProperty<Java.Lang.Class>(StreamsConfig.DEFAULT_VALUE_SERDE_CLASS_CONFIG); } set { SetProperty(StreamsConfig.DEFAULT_VALUE_SERDE_CLASS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="StreamsConfig.DEFAULT_VALUE_SERDE_CLASS_CONFIG"/>
        /// </summary>
        public StreamsConfigBuilder WithDefaultValueSerdeClass(Java.Lang.Class defaultValueSerdeClass)
        {
            var clone = Clone();
            clone.DefaultValueSerdeClass = defaultValueSerdeClass;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="StreamsConfig.MAX_TASK_IDLE_MS_CONFIG"/>
        /// </summary>
        public long MaxTaskIdleMs { get { return GetProperty<int>(StreamsConfig.MAX_TASK_IDLE_MS_CONFIG); } set { SetProperty(StreamsConfig.MAX_TASK_IDLE_MS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="StreamsConfig.MAX_TASK_IDLE_MS_CONFIG"/>
        /// </summary>
        public StreamsConfigBuilder WithMaxTaskIdleMs(long maxTaskIdleMs)
        {
            var clone = Clone();
            clone.MaxTaskIdleMs = maxTaskIdleMs;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="StreamsConfig.MAX_WARMUP_REPLICAS_CONFIG"/>
        /// </summary>
        public int MaxWarmupReplicas { get { return GetProperty<int>(StreamsConfig.MAX_WARMUP_REPLICAS_CONFIG); } set { SetProperty(StreamsConfig.MAX_WARMUP_REPLICAS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="StreamsConfig.MAX_WARMUP_REPLICAS_CONFIG"/>
        /// </summary>
        public StreamsConfigBuilder WithMaxWarmupReplicas(int maxWarmupReplicas)
        {
            var clone = Clone();
            clone.MaxWarmupReplicas = maxWarmupReplicas;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="StreamsConfig.NUM_STREAM_THREADS_CONFIG"/>
        /// </summary>
        public int NumStreamThreads { get { return GetProperty<int>(StreamsConfig.NUM_STREAM_THREADS_CONFIG); } set { SetProperty(StreamsConfig.NUM_STREAM_THREADS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="StreamsConfig.NUM_STREAM_THREADS_CONFIG"/>
        /// </summary>
        public StreamsConfigBuilder WithNumStreamThreads(int numStreamThreads)
        {
            var clone = Clone();
            clone.NumStreamThreads = numStreamThreads;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="StreamsConfig.PROCESSING_EXCEPTION_HANDLER_CLASS_CONFIG"/>
        /// </summary>
        public Java.Lang.Class ProcessingExceptionHandlerClass { get { return GetProperty<Java.Lang.Class>(StreamsConfig.PROCESSING_EXCEPTION_HANDLER_CLASS_CONFIG); } set { SetProperty(StreamsConfig.PROCESSING_EXCEPTION_HANDLER_CLASS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="StreamsConfig.PROCESSING_EXCEPTION_HANDLER_CLASS_CONFIG"/>
        /// </summary>
        public StreamsConfigBuilder WithProcessingExceptionHandlerClass(Java.Lang.Class processingExceptionHandlerClass)
        {
            var clone = Clone();
            clone.ProcessingExceptionHandlerClass = processingExceptionHandlerClass;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="StreamsConfig.TASK_ASSIGNOR_CLASS_CONFIG"/>
        /// </summary>
        public Java.Lang.Class TaskAssignorClass { get { return GetProperty<Java.Lang.Class>(StreamsConfig.TASK_ASSIGNOR_CLASS_CONFIG); } set { SetProperty(StreamsConfig.TASK_ASSIGNOR_CLASS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="StreamsConfig.TASK_ASSIGNOR_CLASS_CONFIG"/>
        /// </summary>
        public StreamsConfigBuilder WithTaskAssignorClass(Java.Lang.Class taskAssignorClass)
        {
            var clone = Clone();
            clone.TaskAssignorClass = taskAssignorClass;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="StreamsConfig.PROCESSING_GUARANTEE_CONFIG"/>: use <see cref="StreamsConfig.AT_LEAST_ONCE"/> or <see cref="StreamsConfig.EXACTLY_ONCE_V2"/>
        /// </summary>
        public string ProcessingGuarantee { get { return GetProperty<string>(StreamsConfig.PROCESSING_GUARANTEE_CONFIG); } set { SetProperty(StreamsConfig.PROCESSING_GUARANTEE_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="StreamsConfig.PROCESSING_GUARANTEE_CONFIG"/>: use <see cref="StreamsConfig.AT_LEAST_ONCE"/> or <see cref="StreamsConfig.EXACTLY_ONCE_V2"/>
        /// </summary>
        public StreamsConfigBuilder WithProcessingGuarantee(string processingGuarantee)
        {
            var clone = Clone();
            clone.ProcessingGuarantee = processingGuarantee;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="StreamsConfig.RACK_AWARE_ASSIGNMENT_NON_OVERLAP_COST_CONFIG"/>
        /// </summary>
        public int RackAwareAssignmentNonOverlapCost { get { return GetProperty<int>(StreamsConfig.RACK_AWARE_ASSIGNMENT_NON_OVERLAP_COST_CONFIG); } set { SetProperty(StreamsConfig.RACK_AWARE_ASSIGNMENT_NON_OVERLAP_COST_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="StreamsConfig.RACK_AWARE_ASSIGNMENT_NON_OVERLAP_COST_CONFIG"/>
        /// </summary>
        public StreamsConfigBuilder WithRackAwareAssignmentNonOverlapCost(int rackAwareAssignmentNonOverlapCost)
        {
            var clone = Clone();
            clone.RackAwareAssignmentNonOverlapCost = rackAwareAssignmentNonOverlapCost;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="StreamsConfig.RACK_AWARE_ASSIGNMENT_STRATEGY_CONFIG"/>: use <see cref="StreamsConfig.RACK_AWARE_ASSIGNMENT_STRATEGY_NONE"/> or <see cref="StreamsConfig.RACK_AWARE_ASSIGNMENT_STRATEGY_MIN_TRAFFIC"/>
        /// </summary>
        public string RackAwareAssignmentStrategy { get { return GetProperty<string>(StreamsConfig.RACK_AWARE_ASSIGNMENT_STRATEGY_CONFIG); } set { SetProperty(StreamsConfig.RACK_AWARE_ASSIGNMENT_STRATEGY_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="StreamsConfig.RACK_AWARE_ASSIGNMENT_NON_OVERLAP_COST_CONFIG"/>: use <see cref="StreamsConfig.RACK_AWARE_ASSIGNMENT_STRATEGY_NONE"/> or <see cref="StreamsConfig.RACK_AWARE_ASSIGNMENT_STRATEGY_MIN_TRAFFIC"/>
        /// </summary>
        public StreamsConfigBuilder WithRackAwareAssignmentStrategy(string rackAwareAssignmentStrategy)
        {
            var clone = Clone();
            clone.RackAwareAssignmentStrategy = rackAwareAssignmentStrategy;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="StreamsConfig.RACK_AWARE_ASSIGNMENT_TAGS_CONFIG"/>
        /// </summary>
        public Java.Util.List<string> RackAwareAssignmentTags { get { return GetProperty<Java.Util.List<string>>(StreamsConfig.RACK_AWARE_ASSIGNMENT_TAGS_CONFIG); } set { SetProperty(StreamsConfig.RACK_AWARE_ASSIGNMENT_TAGS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="StreamsConfig.RACK_AWARE_ASSIGNMENT_TAGS_CONFIG"/>
        /// </summary>
        public StreamsConfigBuilder WithRackAwareAssignmentTags(Java.Util.List<string> rackAwareAssignmentTags)
        {
            var clone = Clone();
            clone.RackAwareAssignmentTags = rackAwareAssignmentTags;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="StreamsConfig.RACK_AWARE_ASSIGNMENT_TRAFFIC_COST_CONFIG"/>
        /// </summary>
        public int RackAwareAssignmentTrafficCost { get { return GetProperty<int>(StreamsConfig.RACK_AWARE_ASSIGNMENT_TRAFFIC_COST_CONFIG); } set { SetProperty(StreamsConfig.RACK_AWARE_ASSIGNMENT_TRAFFIC_COST_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="StreamsConfig.RACK_AWARE_ASSIGNMENT_TRAFFIC_COST_CONFIG"/>
        /// </summary>
        public StreamsConfigBuilder WithRackAwareAssignmentTrafficCost(int rackAwareAssignmentTrafficCost)
        {
            var clone = Clone();
            clone.RackAwareAssignmentTrafficCost = rackAwareAssignmentTrafficCost;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="StreamsConfig.REPLICATION_FACTOR_CONFIG"/>
        /// </summary>
        public int ReplicationFactor { get { return GetProperty<int>(StreamsConfig.REPLICATION_FACTOR_CONFIG); } set { SetProperty(StreamsConfig.REPLICATION_FACTOR_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="StreamsConfig.REPLICATION_FACTOR_CONFIG"/>
        /// </summary>
        public StreamsConfigBuilder WithReplicationFactor(int replicationFactor)
        {
            var clone = Clone();
            clone.ReplicationFactor = replicationFactor;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="StreamsConfig.TASK_TIMEOUT_MS_CONFIG"/>
        /// </summary>
        public long TaskTimeoutMs { get { return GetProperty<long>(StreamsConfig.TASK_TIMEOUT_MS_CONFIG); } set { SetProperty(StreamsConfig.TASK_TIMEOUT_MS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="StreamsConfig.TASK_TIMEOUT_MS_CONFIG"/>
        /// </summary>
        public StreamsConfigBuilder WithTaskTimeoutMs(long taskTimeoutMs)
        {
            var clone = Clone();
            clone.TaskTimeoutMs = taskTimeoutMs;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="StreamsConfig.TOPOLOGY_OPTIMIZATION_CONFIG"/>: use <see cref="StreamsConfig.OPTIMIZE"/> or <see cref="StreamsConfig.NO_OPTIMIZATION"/>
        /// </summary>
        public bool TopologyOptimization { get { return GetProperty<string>(StreamsConfig.TOPOLOGY_OPTIMIZATION_CONFIG) == StreamsConfig.OPTIMIZE; } set { SetProperty(StreamsConfig.TOPOLOGY_OPTIMIZATION_CONFIG, value ? StreamsConfig.OPTIMIZE : StreamsConfig.NO_OPTIMIZATION); } }
        /// <summary>
        /// Manages <see cref="StreamsConfig.TOPOLOGY_OPTIMIZATION_CONFIG"/>: use <see cref="StreamsConfig.OPTIMIZE"/> or <see cref="StreamsConfig.NO_OPTIMIZATION"/>
        /// </summary>
        public StreamsConfigBuilder WithTopologyOptimization(bool topologyOptimization)
        {
            var clone = Clone();
            clone.TopologyOptimization = topologyOptimization;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="StreamsConfig.APPLICATION_SERVER_CONFIG"/>
        /// </summary>
        public string ApplicationServer { get { return GetProperty<string>(StreamsConfig.APPLICATION_SERVER_CONFIG); } set { SetProperty(StreamsConfig.APPLICATION_SERVER_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="StreamsConfig.APPLICATION_SERVER_CONFIG"/>
        /// </summary>
        public StreamsConfigBuilder WithApplicationServer(string applicationServer)
        {
            var clone = Clone();
            clone.ApplicationServer = applicationServer;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="StreamsConfig.BUFFERED_RECORDS_PER_PARTITION_CONFIG"/>
        /// </summary>
        public int BufferedRecordsPerPartition { get { return GetProperty<int>(StreamsConfig.BUFFERED_RECORDS_PER_PARTITION_CONFIG); } set { SetProperty(StreamsConfig.BUFFERED_RECORDS_PER_PARTITION_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="StreamsConfig.BUFFERED_RECORDS_PER_PARTITION_CONFIG"/>
        /// </summary>
        public StreamsConfigBuilder WithBufferedRecordsPerPartition(int bufferedRecordsPerPartition)
        {
            var clone = Clone();
            clone.BufferedRecordsPerPartition = bufferedRecordsPerPartition;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="StreamsConfig.BUILT_IN_METRICS_VERSION_CONFIG"/>
        /// </summary>
        public string BuiltInMetricsVersion { get { return GetProperty<string>(StreamsConfig.BUILT_IN_METRICS_VERSION_CONFIG); } set { SetProperty(StreamsConfig.BUILT_IN_METRICS_VERSION_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="StreamsConfig.BUILT_IN_METRICS_VERSION_CONFIG"/>
        /// </summary>
        public StreamsConfigBuilder WithBuiltInMetricsVersion(string builtInMetricsVersion)
        {
            var clone = Clone();
            clone.BuiltInMetricsVersion = builtInMetricsVersion;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="StreamsConfig.COMMIT_INTERVAL_MS_CONFIG"/>
        /// </summary>
        public long CommitIntervalMs { get { return GetProperty<long>(StreamsConfig.COMMIT_INTERVAL_MS_CONFIG); } set { SetProperty(StreamsConfig.COMMIT_INTERVAL_MS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="StreamsConfig.COMMIT_INTERVAL_MS_CONFIG"/>
        /// </summary>
        public StreamsConfigBuilder WithCommitIntervalMs(long commitIntervalMs)
        {
            var clone = Clone();
            clone.CommitIntervalMs = commitIntervalMs;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="StreamsConfig.REPARTITION_PURGE_INTERVAL_MS_CONFIG"/>
        /// </summary>
        public long RepartitionPurgeIntervalMs { get { return GetProperty<long>(StreamsConfig.REPARTITION_PURGE_INTERVAL_MS_CONFIG); } set { SetProperty(StreamsConfig.REPARTITION_PURGE_INTERVAL_MS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="StreamsConfig.REPARTITION_PURGE_INTERVAL_MS_CONFIG"/>
        /// </summary>
        public StreamsConfigBuilder WithRepartitionPurgeIntervalMs(long repartitionPurgeIntervalMs)
        {
            var clone = Clone();
            clone.RepartitionPurgeIntervalMs = repartitionPurgeIntervalMs;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="StreamsConfig.DSL_STORE_SUPPLIERS_CLASS_CONFIG"/>: use <see cref="BuiltInDslStoreSuppliers.ROCKS_DB"/> or <see cref="BuiltInDslStoreSuppliers.IN_MEMORY"/>
        /// </summary>
        public Class DSLStoreSuppliersClass { get { return GetProperty<Class>(StreamsConfig.DSL_STORE_SUPPLIERS_CLASS_CONFIG); } set { SetProperty(StreamsConfig.DSL_STORE_SUPPLIERS_CLASS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="StreamsConfig.DSL_STORE_SUPPLIERS_CLASS_CONFIG"/>: use <see cref="BuiltInDslStoreSuppliers.ROCKS_DB"/> or <see cref="BuiltInDslStoreSuppliers.IN_MEMORY"/>
        /// </summary>
        public StreamsConfigBuilder WithDSLStoreSuppliersClass(Class dSLStoreSuppliersClass)
        {
            var clone = Clone();
            clone.DSLStoreSuppliersClass = dSLStoreSuppliersClass;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="StreamsConfig.DEFAULT_CLIENT_SUPPLIER_CONFIG"/>
        /// </summary>
        public Class DefaultClientSupplier { get { return GetProperty<Class>(StreamsConfig.DEFAULT_CLIENT_SUPPLIER_CONFIG); } set { SetProperty(StreamsConfig.DEFAULT_CLIENT_SUPPLIER_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="StreamsConfig.DEFAULT_CLIENT_SUPPLIER_CONFIG"/>
        /// </summary>
        public StreamsConfigBuilder WithDefaultClientSupplier(Class defaultClientSupplier)
        {
            var clone = Clone();
            clone.DefaultClientSupplier = defaultClientSupplier;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="StreamsConfig.LOG_SUMMARY_INTERVAL_MS_CONFIG"/>
        /// </summary>
        public long LogSummaryIntervalMs { get { return GetProperty<long>(StreamsConfig.LOG_SUMMARY_INTERVAL_MS_CONFIG); } set { SetProperty(StreamsConfig.LOG_SUMMARY_INTERVAL_MS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="StreamsConfig.LOG_SUMMARY_INTERVAL_MS_CONFIG"/>
        /// </summary>
        public StreamsConfigBuilder WithLogSummaryIntervalMs(long logSummaryIntervalMs)
        {
            var clone = Clone();
            clone.LogSummaryIntervalMs = logSummaryIntervalMs;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="StreamsConfig.POLL_MS_CONFIG"/>
        /// </summary>
        public long PollMs { get { return GetProperty<long>(StreamsConfig.POLL_MS_CONFIG); } set { SetProperty(StreamsConfig.POLL_MS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="StreamsConfig.POLL_MS_CONFIG"/>
        /// </summary>
        public StreamsConfigBuilder WithPollMs(long pollMs)
        {
            var clone = Clone();
            clone.PollMs = pollMs;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="StreamsConfig.PROBING_REBALANCE_INTERVAL_MS_CONFIG"/>
        /// </summary>
        public long ProbingRebalanceIntervalMs { get { return GetProperty<long>(StreamsConfig.PROBING_REBALANCE_INTERVAL_MS_CONFIG); } set { SetProperty(StreamsConfig.PROBING_REBALANCE_INTERVAL_MS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="StreamsConfig.PROBING_REBALANCE_INTERVAL_MS_CONFIG"/>
        /// </summary>
        public StreamsConfigBuilder WithProbingRebalanceIntervalMs(long probingRebalanceIntervalMs)
        {
            var clone = Clone();
            clone.ProbingRebalanceIntervalMs = probingRebalanceIntervalMs;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="StreamsConfig.ROCKSDB_CONFIG_SETTER_CLASS_CONFIG"/>
        /// </summary>
        public Java.Lang.Class RocksDbConfigSetterClass { get { return GetProperty<Java.Lang.Class>(StreamsConfig.ROCKSDB_CONFIG_SETTER_CLASS_CONFIG); } set { SetProperty(StreamsConfig.ROCKSDB_CONFIG_SETTER_CLASS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="StreamsConfig.ROCKSDB_CONFIG_SETTER_CLASS_CONFIG"/>
        /// </summary>
        public StreamsConfigBuilder WithRocksDbConfigSetterClass(Java.Lang.Class rocksDbConfigSetterClass)
        {
            var clone = Clone();
            clone.RocksDbConfigSetterClass = rocksDbConfigSetterClass;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="StreamsConfig.STATE_CLEANUP_DELAY_MS_CONFIG"/>
        /// </summary>
        public long StateCleanupDelayMs { get { return GetProperty<long>(StreamsConfig.STATE_CLEANUP_DELAY_MS_CONFIG); } set { SetProperty(StreamsConfig.STATE_CLEANUP_DELAY_MS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="StreamsConfig.STATE_CLEANUP_DELAY_MS_CONFIG"/>
        /// </summary>
        public StreamsConfigBuilder WithStateCleanupDelayMs(long stateCleanupDelayMs)
        {
            var clone = Clone();
            clone.StateCleanupDelayMs = stateCleanupDelayMs;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="StreamsConfig.UPGRADE_FROM_CONFIG"/>
        /// </summary>
        public string UpgradeFrom { get { return GetProperty<string>(StreamsConfig.UPGRADE_FROM_CONFIG); } set { SetProperty(StreamsConfig.UPGRADE_FROM_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="StreamsConfig.UPGRADE_FROM_CONFIG"/>
        /// </summary>
        public StreamsConfigBuilder WithUpgradeFrom(string upgradeFrom)
        {
            var clone = Clone();
            clone.UpgradeFrom = upgradeFrom;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="StreamsConfig.WINDOWED_INNER_CLASS_SERDE"/>
        /// </summary>
        public string WindowedInnerClassSerde { get { return GetProperty<string>(StreamsConfig.WINDOWED_INNER_CLASS_SERDE); } set { SetProperty(StreamsConfig.WINDOWED_INNER_CLASS_SERDE, value); } }
        /// <summary>
        /// Manages <see cref="StreamsConfig.WINDOWED_INNER_CLASS_SERDE"/>
        /// </summary>
        public StreamsConfigBuilder WithWindowedInnerClassSerde(string windowedInnerClassSerde)
        {
            var clone = Clone();
            clone.WindowedInnerClassSerde = windowedInnerClassSerde;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="StreamsConfig.WINDOW_STORE_CHANGE_LOG_ADDITIONAL_RETENTION_MS_CONFIG"/>
        /// </summary>
        public long WindowStoreChangeLogAdditionalRetentionMs { get { return GetProperty<long>(StreamsConfig.WINDOW_STORE_CHANGE_LOG_ADDITIONAL_RETENTION_MS_CONFIG); } set { SetProperty(StreamsConfig.WINDOW_STORE_CHANGE_LOG_ADDITIONAL_RETENTION_MS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="StreamsConfig.WINDOW_STORE_CHANGE_LOG_ADDITIONAL_RETENTION_MS_CONFIG"/>
        /// </summary>
        public StreamsConfigBuilder WithWindowStoreChangeLogAdditionalRetentionMs(long windowStoreChangeLogAdditionalRetentionMs)
        {
            var clone = Clone();
            clone.WindowStoreChangeLogAdditionalRetentionMs = windowStoreChangeLogAdditionalRetentionMs;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="StreamsConfig.WINDOW_SIZE_MS_CONFIG"/>
        /// </summary>
        public long WindowSizeMs { get { return GetProperty<long>(StreamsConfig.WINDOW_SIZE_MS_CONFIG); } set { SetProperty(StreamsConfig.WINDOW_SIZE_MS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="StreamsConfig.WINDOW_SIZE_MS_CONFIG"/>
        /// </summary>
        public StreamsConfigBuilder WithWindowSizeMs(long windowSizeMs)
        {
            var clone = Clone();
            clone.WindowSizeMs = windowSizeMs;
            return clone;
        }
    }
}
