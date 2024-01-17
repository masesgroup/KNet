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

using Org.Apache.Kafka.Common.Config;

namespace MASES.KNet.Common
{
    /// <summary>
    /// Builder for <see cref="TopicConfig"/>
    /// </summary>
    public class TopicConfigBuilder : GenericConfigBuilder<TopicConfigBuilder>
    {
        /// <summary>
        /// Used from <see cref="CleanupPolicy"/> and <see cref="WithCleanupPolicy(CleanupPolicyTypes)"/>
        /// </summary>
        [System.Flags]
        public enum CleanupPolicyTypes
        {
            /// <summary>
            /// None
            /// </summary>
            None = 0,
            /// <summary>
            /// Compact
            /// </summary>
            Compact = 0x1,
            /// <summary>
            /// Delete
            /// </summary>
            Delete = 0x2
        }
        /// <summary>
        /// Used from <see cref="CompressionType"/> and <see cref="WithCompressionType(CompressionTypes)"/>
        /// </summary>
        public enum CompressionTypes
        {
            /// <summary>
            /// uncompressed
            /// </summary>
            uncompressed,
            /// <summary>
            /// gzip
            /// </summary>
            gzip,
            /// <summary>
            /// snappy
            /// </summary>
            snappy,
            /// <summary>
            /// lz4
            /// </summary>
            lz4,
            /// <summary>
            /// zstd
            /// </summary>
            zstd,
            /// <summary>
            /// producer
            /// </summary>
            producer
        }
        /// <summary>
        /// Used from <see cref="MessageTimestampType"/> and <see cref="WithMessageTimestampType(MessageTimestampTypes)"/>
        /// </summary>
        public enum MessageTimestampTypes
        {
            /// <summary>
            /// CreateTime
            /// </summary>
            CreateTime,
            /// <summary>
            /// LogAppendTime
            /// </summary>
            LogAppendTime,
        }
        /// <summary>
        /// Manages <see cref="TopicConfig.SEGMENT_BYTES_CONFIG"/>
        /// </summary>
        public int SegmentBytes { get { return GetProperty<int>(TopicConfig.SEGMENT_BYTES_CONFIG); } set { SetProperty(TopicConfig.SEGMENT_BYTES_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="TopicConfig.SEGMENT_BYTES_CONFIG"/>
        /// </summary>
        public TopicConfigBuilder WithSegmentBytes(int segmentBytes)
        {
            var clone = Clone();
            clone.SegmentBytes = segmentBytes;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="TopicConfig.SEGMENT_MS_CONFIG"/>
        /// </summary>
        public int SegmentMs { get { return GetProperty<int>(TopicConfig.SEGMENT_MS_CONFIG); } set { SetProperty(TopicConfig.SEGMENT_MS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="TopicConfig.SEGMENT_MS_CONFIG"/>
        /// </summary>
        public TopicConfigBuilder WithSegmentMs(int segmentMs)
        {
            var clone = Clone();
            clone.SegmentMs = segmentMs;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="TopicConfig.SEGMENT_JITTER_MS_CONFIG"/>
        /// </summary>
        public int SegmentJitterMs { get { return GetProperty<int>(TopicConfig.SEGMENT_JITTER_MS_CONFIG); } set { SetProperty(TopicConfig.SEGMENT_JITTER_MS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="TopicConfig.SEGMENT_JITTER_MS_CONFIG"/>
        /// </summary>
        public TopicConfigBuilder WithSegmentJitterMs(int segmentJitterMs)
        {
            var clone = Clone();
            clone.SegmentJitterMs = segmentJitterMs;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="TopicConfig.SEGMENT_INDEX_BYTES_CONFIG"/>
        /// </summary>
        public int SegmentIndexBytes { get { return GetProperty<int>(TopicConfig.SEGMENT_INDEX_BYTES_CONFIG); } set { SetProperty(TopicConfig.SEGMENT_INDEX_BYTES_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="TopicConfig.SEGMENT_INDEX_BYTES_CONFIG"/>
        /// </summary>
        public TopicConfigBuilder WithSegmentIndexBytes(int segmentIndexBytes)
        {
            var clone = Clone();
            clone.SegmentIndexBytes = segmentIndexBytes;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="TopicConfig.FLUSH_MESSAGES_INTERVAL_CONFIG"/>
        /// </summary>
        public int FlushMessageInterval { get { return GetProperty<int>(TopicConfig.FLUSH_MESSAGES_INTERVAL_CONFIG); } set { SetProperty(TopicConfig.FLUSH_MESSAGES_INTERVAL_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="TopicConfig.FLUSH_MESSAGES_INTERVAL_CONFIG"/>
        /// </summary>
        public TopicConfigBuilder WithFlushMessageInterval(int flushMessageInterval)
        {
            var clone = Clone();
            clone.FlushMessageInterval = flushMessageInterval;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="TopicConfig.FLUSH_MS_CONFIG"/>
        /// </summary>
        public int FlushMs { get { return GetProperty<int>(TopicConfig.FLUSH_MS_CONFIG); } set { SetProperty(TopicConfig.FLUSH_MS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="TopicConfig.FLUSH_MS_CONFIG"/>
        /// </summary>
        public TopicConfigBuilder WithFlushMs(int flushMs)
        {
            var clone = Clone();
            clone.FlushMs = flushMs;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="TopicConfig.RETENTION_BYTES_CONFIG"/>
        /// </summary>
        public int RetentionBytes { get { return GetProperty<int>(TopicConfig.RETENTION_BYTES_CONFIG); } set { SetProperty(TopicConfig.RETENTION_BYTES_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="TopicConfig.RETENTION_BYTES_CONFIG"/>
        /// </summary>
        public TopicConfigBuilder WithRetentionBytes(int retentionBytes)
        {
            var clone = Clone();
            clone.RetentionBytes = retentionBytes;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="TopicConfig.RETENTION_MS_CONFIG"/>
        /// </summary>
        public int RetentionMs { get { return GetProperty<int>(TopicConfig.RETENTION_MS_CONFIG); } set { SetProperty(TopicConfig.RETENTION_MS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="TopicConfig.RETENTION_MS_CONFIG"/>
        /// </summary>
        public TopicConfigBuilder WithRetentionMs(int retentionMs)
        {
            var clone = Clone();
            clone.RetentionMs = retentionMs;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="TopicConfig.REMOTE_LOG_STORAGE_ENABLE_CONFIG"/>
        /// </summary>
        public bool RemoteLogStorageEnable { get { return GetProperty<bool>(TopicConfig.REMOTE_LOG_STORAGE_ENABLE_CONFIG); } set { SetProperty(TopicConfig.REMOTE_LOG_STORAGE_ENABLE_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="TopicConfig.REMOTE_LOG_STORAGE_ENABLE_CONFIG"/>
        /// </summary>
        public TopicConfigBuilder WithRemoteLogStorageEnable(bool remoteLogStorageEnable)
        {
            var clone = Clone();
            clone.RemoteLogStorageEnable = remoteLogStorageEnable;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="TopicConfig.LOCAL_LOG_RETENTION_MS_CONFIG"/>
        /// </summary>
        public int LocalLogRetentionMs { get { return GetProperty<int>(TopicConfig.LOCAL_LOG_RETENTION_MS_CONFIG); } set { SetProperty(TopicConfig.LOCAL_LOG_RETENTION_MS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="TopicConfig.LOCAL_LOG_RETENTION_MS_CONFIG"/>
        /// </summary>
        public TopicConfigBuilder WithLocalLogRetentionMs(int localLogRetentionMs)
        {
            var clone = Clone();
            clone.LocalLogRetentionMs = localLogRetentionMs;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="TopicConfig.LOCAL_LOG_RETENTION_BYTES_CONFIG"/>
        /// </summary>
        public int LocalLogRetentionBytes { get { return GetProperty<int>(TopicConfig.LOCAL_LOG_RETENTION_BYTES_CONFIG); } set { SetProperty(TopicConfig.LOCAL_LOG_RETENTION_BYTES_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="TopicConfig.LOCAL_LOG_RETENTION_BYTES_CONFIG"/>
        /// </summary>
        public TopicConfigBuilder WithLocalLogRetentionBytes(int localLogRetentionBytes)
        {
            var clone = Clone();
            clone.LocalLogRetentionBytes = localLogRetentionBytes;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="TopicConfig.MAX_MESSAGE_BYTES_CONFIG"/>
        /// </summary>
        public int MaxMessageBytes { get { return GetProperty<int>(TopicConfig.MAX_MESSAGE_BYTES_CONFIG); } set { SetProperty(TopicConfig.MAX_MESSAGE_BYTES_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="TopicConfig.MAX_MESSAGE_BYTES_CONFIG"/>
        /// </summary>
        public TopicConfigBuilder WithMaxMessageBytes(int maxMessageBytes)
        {
            var clone = Clone();
            clone.MaxMessageBytes = maxMessageBytes;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="TopicConfig.INDEX_INTERVAL_BYTES_CONFIG"/>
        /// </summary>
        public int IndexIntervalBytes { get { return GetProperty<int>(TopicConfig.INDEX_INTERVAL_BYTES_CONFIG); } set { SetProperty(TopicConfig.INDEX_INTERVAL_BYTES_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="TopicConfig.INDEX_INTERVAL_BYTES_CONFIG"/>
        /// </summary>
        public TopicConfigBuilder WithIndexIntervalBytes(int indexIntervalBytes)
        {
            var clone = Clone();
            clone.IndexIntervalBytes = indexIntervalBytes;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="TopicConfig.FILE_DELETE_DELAY_MS_CONFIG"/>
        /// </summary>
        public int FileDeleteDelayMs { get { return GetProperty<int>(TopicConfig.FILE_DELETE_DELAY_MS_CONFIG); } set { SetProperty(TopicConfig.FILE_DELETE_DELAY_MS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="TopicConfig.FILE_DELETE_DELAY_MS_CONFIG"/>
        /// </summary>
        public TopicConfigBuilder WithFileDeleteDelayMs(int fileDeleteDelayMs)
        {
            var clone = Clone();
            clone.FileDeleteDelayMs = fileDeleteDelayMs;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="TopicConfig.DELETE_RETENTION_MS_CONFIG"/>
        /// </summary>
        public int DeleteRetentionMs { get { return GetProperty<int>(TopicConfig.DELETE_RETENTION_MS_CONFIG); } set { SetProperty(TopicConfig.DELETE_RETENTION_MS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="TopicConfig.DELETE_RETENTION_MS_CONFIG"/>
        /// </summary>
        public TopicConfigBuilder WithDeleteRetentionMs(int deleteRetentionMs)
        {
            var clone = Clone();
            clone.DeleteRetentionMs = deleteRetentionMs;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="TopicConfig.MIN_COMPACTION_LAG_MS_CONFIG"/>
        /// </summary>
        public int MinCompactationLagMs { get { return GetProperty<int>(TopicConfig.MIN_COMPACTION_LAG_MS_CONFIG); } set { SetProperty(TopicConfig.MIN_COMPACTION_LAG_MS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="TopicConfig.MIN_COMPACTION_LAG_MS_CONFIG"/>
        /// </summary>
        public TopicConfigBuilder WithMinCompactationLagMs(int minCompactationLagMs)
        {
            var clone = Clone();
            clone.MinCompactationLagMs = minCompactationLagMs;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="TopicConfig.MAX_COMPACTION_LAG_MS_CONFIG"/>
        /// </summary>
        public int MaxCompactationLagMs { get { return GetProperty<int>(TopicConfig.MAX_COMPACTION_LAG_MS_CONFIG); } set { SetProperty(TopicConfig.MAX_COMPACTION_LAG_MS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="TopicConfig.MAX_COMPACTION_LAG_MS_CONFIG"/>
        /// </summary>
        public TopicConfigBuilder WithMaxCompactationLagMs(int maxCompactationLagMs)
        {
            var clone = Clone();
            clone.MaxCompactationLagMs = maxCompactationLagMs;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="TopicConfig.MIN_CLEANABLE_DIRTY_RATIO_CONFIG"/>
        /// </summary>
        public double MinCleanableDirtyRatio { get { return GetProperty<double>(TopicConfig.MIN_CLEANABLE_DIRTY_RATIO_CONFIG); } set { SetProperty(TopicConfig.MIN_CLEANABLE_DIRTY_RATIO_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="TopicConfig.MIN_CLEANABLE_DIRTY_RATIO_CONFIG"/>
        /// </summary>
        public TopicConfigBuilder WithMinCleanableDirtyRatio(double minCleanableDirtyRatio)
        {
            var clone = Clone();
            clone.MinCleanableDirtyRatio = minCleanableDirtyRatio;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="TopicConfig.CLEANUP_POLICY_CONFIG"/>
        /// </summary>
        public CleanupPolicyTypes CleanupPolicy
        {
            get
            {
                var policyStr = GetProperty<string>(TopicConfig.CLEANUP_POLICY_CONFIG);
                CleanupPolicyTypes policy = CleanupPolicyTypes.None;
                if (string.IsNullOrWhiteSpace(policyStr)) return policy;

                if (policyStr.Contains(TopicConfig.CLEANUP_POLICY_COMPACT)) policy |= CleanupPolicyTypes.Compact;
                if (policyStr.Contains(TopicConfig.CLEANUP_POLICY_DELETE)) policy |= CleanupPolicyTypes.Delete;
                return policy;
            }
            set
            {
                if (value == CleanupPolicyTypes.None) return;
                var str = value.ToString();
                str = str.ToLowerInvariant();
                str = str.Replace(", ", ",");
                SetProperty(TopicConfig.CLEANUP_POLICY_CONFIG, str);
            }
        }
        /// <summary>
        /// Manages <see cref="TopicConfig.CLEANUP_POLICY_CONFIG"/>
        /// </summary>
        public TopicConfigBuilder WithCleanupPolicy(CleanupPolicyTypes cleanupPolicy)
        {
            var clone = Clone();
            clone.CleanupPolicy = cleanupPolicy;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="TopicConfig.UNCLEAN_LEADER_ELECTION_ENABLE_CONFIG"/>
        /// </summary>
        public bool UncleanLeaderElectionEnable { get { return GetProperty<bool>(TopicConfig.UNCLEAN_LEADER_ELECTION_ENABLE_CONFIG); } set { SetProperty(TopicConfig.UNCLEAN_LEADER_ELECTION_ENABLE_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="TopicConfig.UNCLEAN_LEADER_ELECTION_ENABLE_CONFIG"/>
        /// </summary>
        public TopicConfigBuilder WithUncleanLeaderElectionEnable(bool uncleanLeaderElectionEnable)
        {
            var clone = Clone();
            clone.UncleanLeaderElectionEnable = uncleanLeaderElectionEnable;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="TopicConfig.MIN_IN_SYNC_REPLICAS_CONFIG"/>
        /// </summary>
        public int MinInSyncReplicas { get { return GetProperty<int>(TopicConfig.MIN_IN_SYNC_REPLICAS_CONFIG); } set { SetProperty(TopicConfig.MIN_IN_SYNC_REPLICAS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="TopicConfig.MIN_IN_SYNC_REPLICAS_CONFIG"/>
        /// </summary>
        public TopicConfigBuilder WithMinInSyncReplicas(int minInSyncReplicas)
        {
            var clone = Clone();
            clone.MinInSyncReplicas = minInSyncReplicas;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="TopicConfig.COMPRESSION_TYPE_CONFIG"/>
        /// </summary>
        public CompressionTypes CompressionType
        {
            get
            {
                var strName = GetProperty<string>(TopicConfig.COMPRESSION_TYPE_CONFIG);
                if (!string.IsNullOrWhiteSpace(strName) && System.Enum.TryParse<CompressionTypes>(strName, out var rest))
                {
                    return rest;
                }
                return CompressionTypes.producer;
            }
            set
            {
                SetProperty(TopicConfig.COMPRESSION_TYPE_CONFIG, System.Enum.GetName(typeof(CompressionTypes), value).ToLowerInvariant());
            }
        }
        /// <summary>
        /// Manages <see cref="TopicConfig.COMPRESSION_TYPE_CONFIG"/>
        /// </summary>
        public TopicConfigBuilder WithCompressionType(CompressionTypes compressionType)
        {
            var clone = Clone();
            clone.CompressionType = compressionType;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="TopicConfig.PREALLOCATE_CONFIG"/>
        /// </summary>
        public bool Preallocate { get { return GetProperty<bool>(TopicConfig.PREALLOCATE_CONFIG); } set { SetProperty(TopicConfig.PREALLOCATE_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="TopicConfig.PREALLOCATE_CONFIG"/>
        /// </summary>
        public TopicConfigBuilder WithPreallocate(bool preallocate)
        {
            var clone = Clone();
            clone.Preallocate = preallocate;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="TopicConfig.MESSAGE_TIMESTAMP_TYPE_CONFIG"/>
        /// </summary>
        public MessageTimestampTypes MessageTimestampType
        {
            get
            {
                var strName = GetProperty<string>(TopicConfig.MESSAGE_TIMESTAMP_TYPE_CONFIG);
                if (System.Enum.TryParse<MessageTimestampTypes>(strName, out var rest))
                {
                    return rest;
                }
                return MessageTimestampTypes.CreateTime;
            }
            set
            {
                SetProperty(TopicConfig.MESSAGE_TIMESTAMP_TYPE_CONFIG, System.Enum.GetName(typeof(MessageTimestampTypes), value));
            }
        }
        /// <summary>
        /// Manages <see cref="TopicConfig.MESSAGE_TIMESTAMP_TYPE_CONFIG"/>
        /// </summary>
        public TopicConfigBuilder WithMessageTimestampType(MessageTimestampTypes messageTimestampType)
        {
            var clone = Clone();
            clone.MessageTimestampType = messageTimestampType;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="TopicConfig.MESSAGE_TIMESTAMP_AFTER_MAX_MS_CONFIG"/>
        /// </summary>
        public int MessageTimestampAfterMaxMs { get { return GetProperty<int>(TopicConfig.MESSAGE_TIMESTAMP_AFTER_MAX_MS_CONFIG); } set { SetProperty(TopicConfig.MESSAGE_TIMESTAMP_AFTER_MAX_MS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="TopicConfig.MESSAGE_TIMESTAMP_AFTER_MAX_MS_CONFIG"/>
        /// </summary>
        public TopicConfigBuilder WithMessageTimestampAfterMaxMs(int messageTimestampAfterMaxMs)
        {
            var clone = Clone();
            clone.MessageTimestampAfterMaxMs = messageTimestampAfterMaxMs;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="TopicConfig.MESSAGE_TIMESTAMP_BEFORE_MAX_MS_CONFIG"/>
        /// </summary>
        public int MessageTimestampBeforeMaxMs { get { return GetProperty<int>(TopicConfig.MESSAGE_TIMESTAMP_BEFORE_MAX_MS_CONFIG); } set { SetProperty(TopicConfig.MESSAGE_TIMESTAMP_BEFORE_MAX_MS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="TopicConfig.MESSAGE_TIMESTAMP_BEFORE_MAX_MS_CONFIG"/>
        /// </summary>
        public TopicConfigBuilder WithMessageTimestampBeforeMaxMs(int messageTimestampBeforeMaxMs)
        {
            var clone = Clone();
            clone.MessageTimestampBeforeMaxMs = messageTimestampBeforeMaxMs;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="TopicConfig.MESSAGE_DOWNCONVERSION_ENABLE_CONFIG"/>
        /// </summary>
        public bool MessageDownConversionEnable { get { return GetProperty<bool>(TopicConfig.MESSAGE_DOWNCONVERSION_ENABLE_CONFIG); } set { SetProperty(TopicConfig.MESSAGE_DOWNCONVERSION_ENABLE_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="TopicConfig.MESSAGE_DOWNCONVERSION_ENABLE_CONFIG"/>
        /// </summary>
        public TopicConfigBuilder WithMessageDownConversionEnable(bool messageDownConversionEnable)
        {
            var clone = Clone();
            clone.MessageDownConversionEnable = messageDownConversionEnable;
            return clone;
        }
    }
}
