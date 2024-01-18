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

using Org.Apache.Kafka.Common;
using Java.Util;
using Org.Apache.Kafka.Clients.Consumer;
using Java.Lang;

namespace MASES.KNet.Consumer
{
    /// <summary>
    /// Builder for <see cref="ConsumerConfig"/>
    /// </summary>
    public class ConsumerConfigBuilder : CommonClientConfigsBuilder<ConsumerConfigBuilder>
    {
        /// <summary>
        /// Used from <see cref="AutoOffsetReset"/> and <see cref="WithAutoOffsetReset(AutoOffsetResetTypes)"/>
        /// </summary>
        public enum AutoOffsetResetTypes
        {
            /// <summary>
            /// None
            /// </summary>
            None,
            /// <summary>
            /// Earliest
            /// </summary>
            EARLIEST,
            /// <summary>
            /// Latest
            /// </summary>
            LATEST
        }
        /// <summary>
        /// Manages <see cref="ConsumerConfig.MAX_POLL_RECORDS_CONFIG"/>
        /// </summary>
        public int MaxPollRecords { get { return GetProperty<int>(ConsumerConfig.MAX_POLL_RECORDS_CONFIG); } set { SetProperty(ConsumerConfig.MAX_POLL_RECORDS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="ConsumerConfig.MAX_POLL_RECORDS_CONFIG"/>
        /// </summary>
        public ConsumerConfigBuilder WithMaxPollRecords(int maxPollRecords)
        {
            var clone = Clone();
            clone.MaxPollRecords = maxPollRecords;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="ConsumerConfig.ENABLE_AUTO_COMMIT_CONFIG"/>
        /// </summary>
        public bool EnableAutoCommit { get { return GetProperty<bool>(ConsumerConfig.ENABLE_AUTO_COMMIT_CONFIG); } set { SetProperty(ConsumerConfig.ENABLE_AUTO_COMMIT_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="ConsumerConfig.ENABLE_AUTO_COMMIT_CONFIG"/>
        /// </summary>
        public ConsumerConfigBuilder WithEnableAutoCommit(bool enableAutoCommit)
        {
            var clone = Clone();
            clone.EnableAutoCommit = enableAutoCommit;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="ConsumerConfig.AUTO_COMMIT_INTERVAL_MS_CONFIG"/>
        /// </summary>
        public int AutoCommitIntervalMs { get { return GetProperty<int>(ConsumerConfig.AUTO_COMMIT_INTERVAL_MS_CONFIG); } set { SetProperty(ConsumerConfig.AUTO_COMMIT_INTERVAL_MS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="ConsumerConfig.AUTO_COMMIT_INTERVAL_MS_CONFIG"/>
        /// </summary>
        public ConsumerConfigBuilder WithAutoCommitIntervalMs(int autoCommitIntervalMs)
        {
            var clone = Clone();
            clone.AutoCommitIntervalMs = autoCommitIntervalMs;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="ConsumerConfig.PARTITION_ASSIGNMENT_STRATEGY_CONFIG"/>
        /// </summary>
        public string PartitionAssignmentStrategy { get { return GetProperty<string>(ConsumerConfig.PARTITION_ASSIGNMENT_STRATEGY_CONFIG); } set { SetProperty(ConsumerConfig.PARTITION_ASSIGNMENT_STRATEGY_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="ConsumerConfig.PARTITION_ASSIGNMENT_STRATEGY_CONFIG"/>
        /// </summary>
        public ConsumerConfigBuilder WithPartitionAssignmentStrategy(string partitionAssignmentStrategy)
        {
            var clone = Clone();
            clone.PartitionAssignmentStrategy = partitionAssignmentStrategy;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="ConsumerConfig.AUTO_OFFSET_RESET_CONFIG"/>
        /// </summary>
        // "latest", "earliest", "none"
        public AutoOffsetResetTypes AutoOffsetReset
        {
            get
            {
                var strName = GetProperty<string>(ConsumerConfig.AUTO_OFFSET_RESET_CONFIG);

                if (string.IsNullOrWhiteSpace(strName)) return AutoOffsetResetTypes.LATEST;

                if (System.Enum.GetName(typeof(AutoOffsetResetTypes), AutoOffsetResetTypes.None).ToLowerInvariant() == strName)
                    return AutoOffsetResetTypes.None;
                else if (System.Enum.GetName(typeof(AutoOffsetResetTypes), AutoOffsetResetTypes.EARLIEST).ToLowerInvariant() == strName)
                    return AutoOffsetResetTypes.EARLIEST;
                else if (System.Enum.GetName(typeof(AutoOffsetResetTypes), AutoOffsetResetTypes.LATEST).ToLowerInvariant() == strName)
                    return AutoOffsetResetTypes.LATEST;
                else return AutoOffsetResetTypes.LATEST;
            }
            set
            {
                SetProperty(ConsumerConfig.AUTO_OFFSET_RESET_CONFIG, System.Enum.GetName(typeof(AutoOffsetResetTypes), value).ToLowerInvariant());
            }
        }
        /// <summary>
        /// Manages <see cref="ConsumerConfig.AUTO_OFFSET_RESET_CONFIG"/>
        /// </summary>
        public ConsumerConfigBuilder WithAutoOffsetReset(AutoOffsetResetTypes autoOffsetReset)
        {
            var clone = Clone();
            clone.AutoOffsetReset = autoOffsetReset;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="ConsumerConfig.FETCH_MIN_BYTES_CONFIG"/>
        /// </summary>
        public int FetchMinBytes { get { return GetProperty<int>(ConsumerConfig.FETCH_MIN_BYTES_CONFIG); } set { SetProperty(ConsumerConfig.FETCH_MIN_BYTES_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="ConsumerConfig.FETCH_MIN_BYTES_CONFIG"/>
        /// </summary>
        public ConsumerConfigBuilder WithFetchMinBytes(int fetchMinBytes)
        {
            var clone = Clone();
            clone.FetchMinBytes = fetchMinBytes;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="ConsumerConfig.FETCH_MAX_BYTES_CONFIG"/>
        /// </summary>
        public int FetchMaxBytes { get { return GetProperty<int>(ConsumerConfig.FETCH_MAX_BYTES_CONFIG); } set { SetProperty(ConsumerConfig.FETCH_MAX_BYTES_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="ConsumerConfig.FETCH_MAX_BYTES_CONFIG"/>
        /// </summary>
        public ConsumerConfigBuilder WithFetchMaxBytes(int fetchMaxBytes)
        {
            var clone = Clone();
            clone.FetchMaxBytes = fetchMaxBytes;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="ConsumerConfig.FETCH_MAX_WAIT_MS_CONFIG"/>
        /// </summary>
        public int FetchMaxWaitMs { get { return GetProperty<int>(ConsumerConfig.FETCH_MAX_WAIT_MS_CONFIG); } set { SetProperty(ConsumerConfig.FETCH_MAX_WAIT_MS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="ConsumerConfig.FETCH_MAX_WAIT_MS_CONFIG"/>
        /// </summary>
        public ConsumerConfigBuilder WithFetchMaxWaitMs(int fetchMaxWaitMs)
        {
            var clone = Clone();
            clone.FetchMaxWaitMs = fetchMaxWaitMs;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="ConsumerConfig.MAX_PARTITION_FETCH_BYTES_CONFIG"/>
        /// </summary>
        public int MaxPartitionFetchBytes { get { return GetProperty<int>(ConsumerConfig.MAX_PARTITION_FETCH_BYTES_CONFIG); } set { SetProperty(ConsumerConfig.MAX_PARTITION_FETCH_BYTES_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="ConsumerConfig.MAX_PARTITION_FETCH_BYTES_CONFIG"/>
        /// </summary>
        public ConsumerConfigBuilder WithMaxPartitionFetchBytes(int maxPartitionFetchBytes)
        {
            var clone = Clone();
            clone.MaxPartitionFetchBytes = maxPartitionFetchBytes;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="ConsumerConfig.CHECK_CRCS_CONFIG"/>
        /// </summary>
        public bool CheckCrcs { get { return GetProperty<bool>(ConsumerConfig.CHECK_CRCS_CONFIG); } set { SetProperty(ConsumerConfig.CHECK_CRCS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="ConsumerConfig.CHECK_CRCS_CONFIG"/>
        /// </summary>
        public ConsumerConfigBuilder WithCheckCrcs(bool checkCrcs)
        {
            var clone = Clone();
            clone.CheckCrcs = checkCrcs;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="ConsumerConfig.KEY_DESERIALIZER_CLASS_CONFIG"/>
        /// </summary>
        public string KeyDeserializerClass { get { return GetProperty<string>(ConsumerConfig.KEY_DESERIALIZER_CLASS_CONFIG); } set { SetProperty(ConsumerConfig.KEY_DESERIALIZER_CLASS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="ConsumerConfig.KEY_DESERIALIZER_CLASS_CONFIG"/>
        /// </summary>
        public ConsumerConfigBuilder WithKeyDeserializerClass(string keyDeserializerClass)
        {
            var clone = Clone();
            clone.KeyDeserializerClass = keyDeserializerClass;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="ConsumerConfig.VALUE_DESERIALIZER_CLASS_CONFIG"/>
        /// </summary>
        public string ValueDeserializerClass { get { return GetProperty<string>(ConsumerConfig.VALUE_DESERIALIZER_CLASS_CONFIG); } set { SetProperty(ConsumerConfig.VALUE_DESERIALIZER_CLASS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="ConsumerConfig.VALUE_DESERIALIZER_CLASS_CONFIG"/>
        /// </summary>
        public ConsumerConfigBuilder WithValueDeserializerClass(string valueDeserializerClass)
        {
            var clone = Clone();
            clone.ValueDeserializerClass = valueDeserializerClass;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="ConsumerConfig.INTERCEPTOR_CLASSES_CONFIG"/>
        /// </summary>
        public List<Class> InterceptorClasses { get { return GetProperty<List<Class>>(ConsumerConfig.INTERCEPTOR_CLASSES_CONFIG); } set { SetProperty(ConsumerConfig.INTERCEPTOR_CLASSES_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="ConsumerConfig.INTERCEPTOR_CLASSES_CONFIG"/>
        /// </summary>
        public ConsumerConfigBuilder WithInterceptorClasses(List<Class> interceptorClasses)
        {
            var clone = Clone();
            clone.InterceptorClasses = interceptorClasses;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="ConsumerConfig.EXCLUDE_INTERNAL_TOPICS_CONFIG"/>
        /// </summary>
        public bool ExcludeInternalTopics { get { return GetProperty<bool>(ConsumerConfig.EXCLUDE_INTERNAL_TOPICS_CONFIG); } set { SetProperty(ConsumerConfig.EXCLUDE_INTERNAL_TOPICS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="ConsumerConfig.EXCLUDE_INTERNAL_TOPICS_CONFIG"/>
        /// </summary>
        public ConsumerConfigBuilder WithExcludeInternalTopics(bool excludeInternalTopics)
        {
            var clone = Clone();
            clone.ExcludeInternalTopics = excludeInternalTopics;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="ConsumerConfig.ISOLATION_LEVEL_CONFIG"/>
        /// </summary>
        // IsolationLevel.READ_COMMITTED.toString().toLowerCase(Locale.ROOT), IsolationLevel.READ_UNCOMMITTED.toString().toLowerCase(Locale.ROOT)
        public IsolationLevel IsolationLevel { get { return GetProperty<IsolationLevel>(ConsumerConfig.ISOLATION_LEVEL_CONFIG); } set { SetProperty(ConsumerConfig.ISOLATION_LEVEL_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="ConsumerConfig.ISOLATION_LEVEL_CONFIG"/>
        /// </summary>
        public ConsumerConfigBuilder WithIsolationLevel(IsolationLevel isolationLevel)
        {
            var clone = Clone();
            clone.IsolationLevel = isolationLevel;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="ConsumerConfig.ALLOW_AUTO_CREATE_TOPICS_CONFIG"/>
        /// </summary>
        public bool AllowAutoCreateTopics { get { return GetProperty<bool>(ConsumerConfig.ALLOW_AUTO_CREATE_TOPICS_CONFIG); } set { SetProperty(ConsumerConfig.ALLOW_AUTO_CREATE_TOPICS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="ConsumerConfig.ALLOW_AUTO_CREATE_TOPICS_CONFIG"/>
        /// </summary>
        public ConsumerConfigBuilder WithAllowAutoCreateTopics(bool allowAutoCreateTopics)
        {
            var clone = Clone();
            clone.AllowAutoCreateTopics = allowAutoCreateTopics;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="ConsumerConfig.SECURITY_PROVIDERS_CONFIG"/>
        /// </summary>
        public string SecurityProviders { get { return GetProperty<string>(ConsumerConfig.SECURITY_PROVIDERS_CONFIG); } set { SetProperty(ConsumerConfig.SECURITY_PROVIDERS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="ConsumerConfig.SECURITY_PROVIDERS_CONFIG"/>
        /// </summary>
        public ConsumerConfigBuilder WithSecurityProviders(string securityProviders)
        {
            var clone = Clone();
            clone.SecurityProviders = securityProviders;
            return clone;
        }
    }
}
