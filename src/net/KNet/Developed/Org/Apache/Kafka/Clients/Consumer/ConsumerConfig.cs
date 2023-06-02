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

using Org.Apache.Kafka.Common;
using Org.Apache.Kafka.Common.Config;
using Org.Apache.Kafka.Common.Metrics;
using Java.Util;

namespace Org.Apache.Kafka.Clients.Consumer
{
    public partial class ConsumerConfig
    {
        public enum AutoOffsetReset
        {
            None,
            EARLIEST,
            LATEST
        }
   }

    public class ConsumerConfigBuilder : CommonClientConfigsBuilder<ConsumerConfigBuilder>
    {
        public int MaxPollRecords { get { return GetProperty<int>(ConsumerConfig.MAX_POLL_RECORDS_CONFIG); } set { SetProperty(ConsumerConfig.MAX_POLL_RECORDS_CONFIG, value); } }

        public ConsumerConfigBuilder WithMaxPollRecords(int maxPollRecords)
        {
            var clone = Clone();
            clone.MaxPollRecords = maxPollRecords;
            return clone;
        }

        public bool EnableAutoCommit { get { return GetProperty<bool>(ConsumerConfig.ENABLE_AUTO_COMMIT_CONFIG); } set { SetProperty(ConsumerConfig.ENABLE_AUTO_COMMIT_CONFIG, value); } }

        public ConsumerConfigBuilder WithEnableAutoCommit(bool enableAutoCommit)
        {
            var clone = Clone();
            clone.EnableAutoCommit = enableAutoCommit;
            return clone;
        }

        public int AutoCommitIntervalMs { get { return GetProperty<int>(ConsumerConfig.AUTO_COMMIT_INTERVAL_MS_CONFIG); } set { SetProperty(ConsumerConfig.AUTO_COMMIT_INTERVAL_MS_CONFIG, value); } }

        public ConsumerConfigBuilder WithAutoCommitIntervalMs(int autoCommitIntervalMs)
        {
            var clone = Clone();
            clone.AutoCommitIntervalMs = autoCommitIntervalMs;
            return clone;
        }

        public string PartitionAssignmentStrategy { get { return GetProperty<string>(ConsumerConfig.PARTITION_ASSIGNMENT_STRATEGY_CONFIG); } set { SetProperty(ConsumerConfig.PARTITION_ASSIGNMENT_STRATEGY_CONFIG, value); } }

        public ConsumerConfigBuilder WithPartitionAssignmentStrategy(string partitionAssignmentStrategy)
        {
            var clone = Clone();
            clone.PartitionAssignmentStrategy = partitionAssignmentStrategy;
            return clone;
        }

        // "latest", "earliest", "none"
        public ConsumerConfig.AutoOffsetReset AutoOffsetReset
        {
            get
            {
                var strName = GetProperty<string>(ConsumerConfig.AUTO_OFFSET_RESET_CONFIG);
                if (System.Enum.GetName(typeof(ConsumerConfig.AutoOffsetReset), ConsumerConfig.AutoOffsetReset.None).ToLowerInvariant() == strName)
                    return ConsumerConfig.AutoOffsetReset.None;
                else if (System.Enum.GetName(typeof(ConsumerConfig.AutoOffsetReset), ConsumerConfig.AutoOffsetReset.EARLIEST).ToLowerInvariant() == strName)
                    return ConsumerConfig.AutoOffsetReset.EARLIEST;
                else if (System.Enum.GetName(typeof(ConsumerConfig.AutoOffsetReset), ConsumerConfig.AutoOffsetReset.LATEST).ToLowerInvariant() == strName)
                    return ConsumerConfig.AutoOffsetReset.LATEST;
                else return ConsumerConfig.AutoOffsetReset.LATEST;
            }
            set
            {
                SetProperty(ConsumerConfig.AUTO_OFFSET_RESET_CONFIG, System.Enum.GetName(typeof(ConsumerConfig.AutoOffsetReset), value).ToLowerInvariant());
            }
        }

        public ConsumerConfigBuilder WithAutoOffsetReset(ConsumerConfig.AutoOffsetReset autoOffsetReset)
        {
            var clone = Clone();
            clone.AutoOffsetReset = autoOffsetReset;
            return clone;
        }

        public int FetchMinBytes { get { return GetProperty<int>(ConsumerConfig.FETCH_MIN_BYTES_CONFIG); } set { SetProperty(ConsumerConfig.FETCH_MIN_BYTES_CONFIG, value); } }

        public ConsumerConfigBuilder WithFetchMinBytes(int fetchMinBytes)
        {
            var clone = Clone();
            clone.FetchMinBytes = fetchMinBytes;
            return clone;
        }

        public int FetchMaxBytes { get { return GetProperty<int>(ConsumerConfig.FETCH_MAX_BYTES_CONFIG); } set { SetProperty(ConsumerConfig.FETCH_MAX_BYTES_CONFIG, value); } }

        public ConsumerConfigBuilder WithFetchMaxBytes(int fetchMaxBytes)
        {
            var clone = Clone();
            clone.FetchMaxBytes = fetchMaxBytes;
            return clone;
        }

        public int FetchMaxWaitMs { get { return GetProperty<int>(ConsumerConfig.FETCH_MAX_WAIT_MS_CONFIG); } set { SetProperty(ConsumerConfig.FETCH_MAX_WAIT_MS_CONFIG, value); } }

        public ConsumerConfigBuilder WithFetchMaxWaitMs(int fetchMaxWaitMs)
        {
            var clone = Clone();
            clone.FetchMaxWaitMs = fetchMaxWaitMs;
            return clone;
        }

        public int MaxPartitionFetchBytes { get { return GetProperty<int>(ConsumerConfig.MAX_PARTITION_FETCH_BYTES_CONFIG); } set { SetProperty(ConsumerConfig.MAX_PARTITION_FETCH_BYTES_CONFIG, value); } }

        public ConsumerConfigBuilder WithMaxPartitionFetchBytes(int maxPartitionFetchBytes)
        {
            var clone = Clone();
            clone.MaxPartitionFetchBytes = maxPartitionFetchBytes;
            return clone;
        }

        public bool CheckCrcs { get { return GetProperty<bool>(ConsumerConfig.CHECK_CRCS_CONFIG); } set { SetProperty(ConsumerConfig.CHECK_CRCS_CONFIG, value); } }

        public ConsumerConfigBuilder WithCheckCrcs(bool checkCrcs)
        {
            var clone = Clone();
            clone.CheckCrcs = checkCrcs;
            return clone;
        }

        public string KeyDeserializerClass { get { return GetProperty<string>(ConsumerConfig.KEY_DESERIALIZER_CLASS_CONFIG); } set { SetProperty(ConsumerConfig.KEY_DESERIALIZER_CLASS_CONFIG, value); } }

        public ConsumerConfigBuilder WithKeyDeserializerClass(string keyDeserializerClass)
        {
            var clone = Clone();
            clone.KeyDeserializerClass = keyDeserializerClass;
            return clone;
        }

        public string ValueDeserializerClass { get { return GetProperty<string>(ConsumerConfig.VALUE_DESERIALIZER_CLASS_CONFIG); } set { SetProperty(ConsumerConfig.VALUE_DESERIALIZER_CLASS_CONFIG, value); } }

        public ConsumerConfigBuilder WithValueDeserializerClass(string valueDeserializerClass)
        {
            var clone = Clone();
            clone.ValueDeserializerClass = valueDeserializerClass;
            return clone;
        }

        [System.Obsolete("To be checked")]
        public List InterceptorClasses { get { return GetProperty<List>(ConsumerConfig.INTERCEPTOR_CLASSES_CONFIG); } set { SetProperty(ConsumerConfig.INTERCEPTOR_CLASSES_CONFIG, value); } }
        
        [System.Obsolete("To be checked")]
        public ConsumerConfigBuilder WithInterceptorClasses(List interceptorClasses)
        {
            var clone = Clone();
            clone.InterceptorClasses = interceptorClasses;
            return clone;
        }

        public bool ExcludeInternalTopics { get { return GetProperty<bool>(ConsumerConfig.EXCLUDE_INTERNAL_TOPICS_CONFIG); } set { SetProperty(ConsumerConfig.EXCLUDE_INTERNAL_TOPICS_CONFIG, value); } }

        public ConsumerConfigBuilder WithExcludeInternalTopics(bool excludeInternalTopics)
        {
            var clone = Clone();
            clone.ExcludeInternalTopics = excludeInternalTopics;
            return clone;
        }

        // IsolationLevel.READ_COMMITTED.toString().toLowerCase(Locale.ROOT), IsolationLevel.READ_UNCOMMITTED.toString().toLowerCase(Locale.ROOT)
        public IsolationLevel IsolationLevel
        {
            get
            {
                var strName = GetProperty<string>(ConsumerConfig.ISOLATION_LEVEL_CONFIG);
                if (System.Enum.GetName(typeof(IsolationLevel), IsolationLevel.READ_COMMITTED).ToLowerInvariant() == strName)
                    return IsolationLevel.READ_COMMITTED;
                else if (System.Enum.GetName(typeof(IsolationLevel), IsolationLevel.READ_UNCOMMITTED).ToLowerInvariant() == strName)
                    return IsolationLevel.READ_UNCOMMITTED;
                else return IsolationLevel.READ_UNCOMMITTED;
            }
            set
            {
                SetProperty(ConsumerConfig.ISOLATION_LEVEL_CONFIG, System.Enum.GetName(typeof(IsolationLevel), value).ToLowerInvariant());
            }
        }

        public ConsumerConfigBuilder WithIsolationLevel(IsolationLevel isolationLevel)
        {
            var clone = Clone();
            clone.IsolationLevel = isolationLevel;
            return clone;
        }

        public bool AllowAutoCreateTopics { get { return GetProperty<bool>(ConsumerConfig.ALLOW_AUTO_CREATE_TOPICS_CONFIG); } set { SetProperty(ConsumerConfig.ALLOW_AUTO_CREATE_TOPICS_CONFIG, value); } }

        public ConsumerConfigBuilder WithAllowAutoCreateTopics(bool allowAutoCreateTopics)
        {
            var clone = Clone();
            clone.AllowAutoCreateTopics = allowAutoCreateTopics;
            return clone;
        }

        public string SecurityProviders { get { return GetProperty<string>(ConsumerConfig.SECURITY_PROVIDERS_CONFIG); } set { SetProperty(ConsumerConfig.SECURITY_PROVIDERS_CONFIG, value); } }

        public ConsumerConfigBuilder WithSecurityProviders(string securityProviders)
        {
            var clone = Clone();
            clone.SecurityProviders = securityProviders;
            return clone;
        }
    }
}
