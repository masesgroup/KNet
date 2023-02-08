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

using MASES.KNet.Clients.Producer;

namespace MASES.KNet.Common.Config
{
    public class TopicConfig : JCOBridge.C2JBridge.JVMBridgeBase<TopicConfig>
    {
        public override bool IsStatic => true;
        public override string ClassName => "org.apache.kafka.common.config.TopicConfig";

        public static readonly string SEGMENT_BYTES_CONFIG = Clazz.GetField<string>("SEGMENT_BYTES_CONFIG");

        public static readonly string SEGMENT_MS_CONFIG = Clazz.GetField<string>("SEGMENT_MS_CONFIG");

        public static readonly string SEGMENT_JITTER_MS_CONFIG = Clazz.GetField<string>("SEGMENT_JITTER_MS_CONFIG");

        public static readonly string SEGMENT_INDEX_BYTES_CONFIG = Clazz.GetField<string>("SEGMENT_INDEX_BYTES_CONFIG");

        public static readonly string FLUSH_MESSAGES_INTERVAL_CONFIG = Clazz.GetField<string>("FLUSH_MESSAGES_INTERVAL_CONFIG");

        public static readonly string FLUSH_MS_CONFIG = Clazz.GetField<string>("FLUSH_MS_CONFIG");

        public static readonly string RETENTION_BYTES_CONFIG = Clazz.GetField<string>("RETENTION_BYTES_CONFIG");

        public static readonly string RETENTION_MS_CONFIG = Clazz.GetField<string>("RETENTION_MS_CONFIG");

        public static readonly string REMOTE_LOG_STORAGE_ENABLE_CONFIG = Clazz.GetField<string>("REMOTE_LOG_STORAGE_ENABLE_CONFIG");

        public static readonly string LOCAL_LOG_RETENTION_MS_CONFIG = Clazz.GetField<string>("LOCAL_LOG_RETENTION_MS_CONFIG");

        public static readonly string LOCAL_LOG_RETENTION_BYTES_CONFIG = Clazz.GetField<string>("LOCAL_LOG_RETENTION_BYTES_CONFIG");

        public static readonly string MAX_MESSAGE_BYTES_CONFIG = Clazz.GetField<string>("MAX_MESSAGE_BYTES_CONFIG");

        public static readonly string INDEX_INTERVAL_BYTES_CONFIG = Clazz.GetField<string>("INDEX_INTERVAL_BYTES_CONFIG");

        public static readonly string FILE_DELETE_DELAY_MS_CONFIG = Clazz.GetField<string>("FILE_DELETE_DELAY_MS_CONFIG");

        public static readonly string DELETE_RETENTION_MS_CONFIG = Clazz.GetField<string>("DELETE_RETENTION_MS_CONFIG");

        public static readonly string MIN_COMPACTION_LAG_MS_CONFIG = Clazz.GetField<string>("MIN_COMPACTION_LAG_MS_CONFIG");

        public static readonly string MAX_COMPACTION_LAG_MS_CONFIG = Clazz.GetField<string>("MAX_COMPACTION_LAG_MS_CONFIG");

        public static readonly string MIN_CLEANABLE_DIRTY_RATIO_CONFIG = Clazz.GetField<string>("MIN_CLEANABLE_DIRTY_RATIO_CONFIG");
        [System.Flags]
        public enum CleanupPolicy
        {
            None = 0,
            Compact = 0x1,
            Delete = 0x2
        }

        public static readonly string CLEANUP_POLICY_CONFIG = Clazz.GetField<string>("CLEANUP_POLICY_CONFIG");
        public static readonly string CLEANUP_POLICY_COMPACT = Clazz.GetField<string>("CLEANUP_POLICY_COMPACT");
        public static readonly string CLEANUP_POLICY_DELETE = Clazz.GetField<string>("CLEANUP_POLICY_DELETE");

        public static readonly string UNCLEAN_LEADER_ELECTION_ENABLE_CONFIG = Clazz.GetField<string>("UNCLEAN_LEADER_ELECTION_ENABLE_CONFIG");

        public static readonly string MIN_IN_SYNC_REPLICAS_CONFIG = Clazz.GetField<string>("MIN_IN_SYNC_REPLICAS_CONFIG");

        public enum CompressionType
        {
            uncompressed,
            gzip,
            snappy,
            lz4,
            zstd,
            producer
        }

        public static readonly string COMPRESSION_TYPE_CONFIG = Clazz.GetField<string>("COMPRESSION_TYPE_CONFIG");

        public static readonly string PREALLOCATE_CONFIG = Clazz.GetField<string>("PREALLOCATE_CONFIG");

        [System.Obsolete()]
        public static readonly string MESSAGE_FORMAT_VERSION_CONFIG = Clazz.GetField<string>("MESSAGE_FORMAT_VERSION_CONFIG");

        public enum MessageTimestampType
        {
            CreateTime,
            LogAppendTime,
        }

        public static readonly string MESSAGE_TIMESTAMP_TYPE_CONFIG = Clazz.GetField<string>("MESSAGE_TIMESTAMP_TYPE_CONFIG");

        public static readonly string MESSAGE_TIMESTAMP_DIFFERENCE_MAX_MS_CONFIG = Clazz.GetField<string>("MESSAGE_TIMESTAMP_DIFFERENCE_MAX_MS_CONFIG");

        public static readonly string MESSAGE_DOWNCONVERSION_ENABLE_CONFIG = Clazz.GetField<string>("MESSAGE_DOWNCONVERSION_ENABLE_CONFIG");

    }

    public class TopicConfigBuilder : GenericConfigBuilder<TopicConfigBuilder>
    {
        public int SegmentBytes { get { return GetProperty<int>(TopicConfig.SEGMENT_BYTES_CONFIG); } set { SetProperty(TopicConfig.SEGMENT_BYTES_CONFIG, value); } }

        public TopicConfigBuilder WithSegmentBytes(int segmentBytes)
        {
            var clone = Clone();
            clone.SegmentBytes = segmentBytes;
            return clone;
        }

        public int SegmentMs { get { return GetProperty<int>(TopicConfig.SEGMENT_MS_CONFIG); } set { SetProperty(TopicConfig.SEGMENT_MS_CONFIG, value); } }

        public TopicConfigBuilder WithSegmentMs(int segmentMs)
        {
            var clone = Clone();
            clone.SegmentMs = segmentMs;
            return clone;
        }

        public int SegmentJitterMs { get { return GetProperty<int>(TopicConfig.SEGMENT_JITTER_MS_CONFIG); } set { SetProperty(TopicConfig.SEGMENT_JITTER_MS_CONFIG, value); } }

        public TopicConfigBuilder WithSegmentJitterMs(int segmentJitterMs)
        {
            var clone = Clone();
            clone.SegmentJitterMs = segmentJitterMs;
            return clone;
        }

        public int SegmentIndexBytes { get { return GetProperty<int>(TopicConfig.SEGMENT_INDEX_BYTES_CONFIG); } set { SetProperty(TopicConfig.SEGMENT_INDEX_BYTES_CONFIG, value); } }

        public TopicConfigBuilder WithSegmentIndexBytes(int segmentIndexBytes)
        {
            var clone = Clone();
            clone.SegmentIndexBytes = segmentIndexBytes;
            return clone;
        }

        public int FlushMessageInterval { get { return GetProperty<int>(TopicConfig.FLUSH_MESSAGES_INTERVAL_CONFIG); } set { SetProperty(TopicConfig.FLUSH_MESSAGES_INTERVAL_CONFIG, value); } }

        public TopicConfigBuilder WithFlushMessageInterval(int flushMessageInterval)
        {
            var clone = Clone();
            clone.FlushMessageInterval = flushMessageInterval;
            return clone;
        }

        public int FlushMs { get { return GetProperty<int>(TopicConfig.FLUSH_MS_CONFIG); } set { SetProperty(TopicConfig.FLUSH_MS_CONFIG, value); } }

        public TopicConfigBuilder WithFlushMs(int flushMs)
        {
            var clone = Clone();
            clone.FlushMs = flushMs;
            return clone;
        }

        public int RetentionBytes { get { return GetProperty<int>(TopicConfig.RETENTION_BYTES_CONFIG); } set { SetProperty(TopicConfig.RETENTION_BYTES_CONFIG, value); } }

        public TopicConfigBuilder WithRetentionBytes(int retentionBytes)
        {
            var clone = Clone();
            clone.RetentionBytes = retentionBytes;
            return clone;
        }

        public int RetentionMs { get { return GetProperty<int>(TopicConfig.RETENTION_MS_CONFIG); } set { SetProperty(TopicConfig.RETENTION_MS_CONFIG, value); } }

        public TopicConfigBuilder WithRetentionMs(int retentionMs)
        {
            var clone = Clone();
            clone.RetentionMs = retentionMs;
            return clone;
        }

        public bool RemoteLogStorageEnable { get { return GetProperty<bool>(TopicConfig.REMOTE_LOG_STORAGE_ENABLE_CONFIG); } set { SetProperty(TopicConfig.REMOTE_LOG_STORAGE_ENABLE_CONFIG, value); } }

        public TopicConfigBuilder WithRemoteLogStorageEnable(bool remoteLogStorageEnable)
        {
            var clone = Clone();
            clone.RemoteLogStorageEnable = remoteLogStorageEnable;
            return clone;
        }

        public int LocalLogRetentionMs { get { return GetProperty<int>(TopicConfig.LOCAL_LOG_RETENTION_MS_CONFIG); } set { SetProperty(TopicConfig.LOCAL_LOG_RETENTION_MS_CONFIG, value); } }

        public TopicConfigBuilder WithLocalLogRetentionMs(int localLogRetentionMs)
        {
            var clone = Clone();
            clone.LocalLogRetentionMs = localLogRetentionMs;
            return clone;
        }

        public int LocalLogRetentionBytes { get { return GetProperty<int>(TopicConfig.LOCAL_LOG_RETENTION_BYTES_CONFIG); } set { SetProperty(TopicConfig.LOCAL_LOG_RETENTION_BYTES_CONFIG, value); } }

        public TopicConfigBuilder WithLocalLogRetentionBytes(int localLogRetentionBytes)
        {
            var clone = Clone();
            clone.LocalLogRetentionBytes = localLogRetentionBytes;
            return clone;
        }

        public int MaxMessageBytes { get { return GetProperty<int>(TopicConfig.MAX_MESSAGE_BYTES_CONFIG); } set { SetProperty(TopicConfig.MAX_MESSAGE_BYTES_CONFIG, value); } }

        public TopicConfigBuilder WithMaxMessageBytes(int maxMessageBytes)
        {
            var clone = Clone();
            clone.MaxMessageBytes = maxMessageBytes;
            return clone;
        }

        public int IndexIntervalBytes { get { return GetProperty<int>(TopicConfig.INDEX_INTERVAL_BYTES_CONFIG); } set { SetProperty(TopicConfig.INDEX_INTERVAL_BYTES_CONFIG, value); } }

        public TopicConfigBuilder WithIndexIntervalBytes(int indexIntervalBytes)
        {
            var clone = Clone();
            clone.IndexIntervalBytes = indexIntervalBytes;
            return clone;
        }

        public int FileDeleteDelayMs { get { return GetProperty<int>(TopicConfig.FILE_DELETE_DELAY_MS_CONFIG); } set { SetProperty(TopicConfig.FILE_DELETE_DELAY_MS_CONFIG, value); } }

        public TopicConfigBuilder WithFileDeleteDelayMs(int fileDeleteDelayMs)
        {
            var clone = Clone();
            clone.FileDeleteDelayMs = fileDeleteDelayMs;
            return clone;
        }

        public int DeleteRetentionMs { get { return GetProperty<int>(TopicConfig.DELETE_RETENTION_MS_CONFIG); } set { SetProperty(TopicConfig.DELETE_RETENTION_MS_CONFIG, value); } }

        public TopicConfigBuilder WithDeleteRetentionMs(int deleteRetentionMs)
        {
            var clone = Clone();
            clone.DeleteRetentionMs = deleteRetentionMs;
            return clone;
        }

        public int MinCompactationLagMs { get { return GetProperty<int>(TopicConfig.MIN_COMPACTION_LAG_MS_CONFIG); } set { SetProperty(TopicConfig.MIN_COMPACTION_LAG_MS_CONFIG, value); } }

        public TopicConfigBuilder WithMinCompactationLagMs(int minCompactationLagMs)
        {
            var clone = Clone();
            clone.MinCompactationLagMs = minCompactationLagMs;
            return clone;
        }

        public int MaxCompactationLagMs { get { return GetProperty<int>(TopicConfig.MAX_COMPACTION_LAG_MS_CONFIG); } set { SetProperty(TopicConfig.MAX_COMPACTION_LAG_MS_CONFIG, value); } }

        public TopicConfigBuilder WithMaxCompactationLagMs(int maxCompactationLagMs)
        {
            var clone = Clone();
            clone.MaxCompactationLagMs = maxCompactationLagMs;
            return clone;
        }

        public int MinCleanableDirtyRatio { get { return GetProperty<int>(TopicConfig.MIN_CLEANABLE_DIRTY_RATIO_CONFIG); } set { SetProperty(TopicConfig.MIN_CLEANABLE_DIRTY_RATIO_CONFIG, value); } }

        public TopicConfigBuilder WithMinCleanableDirtyRatio(int minCleanableDirtyRatio)
        {
            var clone = Clone();
            clone.MinCleanableDirtyRatio = minCleanableDirtyRatio;
            return clone;
        }

        public TopicConfig.CleanupPolicy CleanupPolicy
        {
            get
            {
                var policyStr = GetProperty<string>(TopicConfig.CLEANUP_POLICY_CONFIG);
                TopicConfig.CleanupPolicy policy = TopicConfig.CleanupPolicy.None;
                if (policyStr.Contains(TopicConfig.CLEANUP_POLICY_COMPACT)) policy |= TopicConfig.CleanupPolicy.Compact;
                if (policyStr.Contains(TopicConfig.CLEANUP_POLICY_DELETE)) policy |= TopicConfig.CleanupPolicy.Delete;
                return policy;
            }
            set
            {
                if (value == TopicConfig.CleanupPolicy.None) return;
                var str = string.Empty;
                if (value.HasFlag(TopicConfig.CleanupPolicy.Compact)) str += TopicConfig.CLEANUP_POLICY_COMPACT;
                if (value.HasFlag(TopicConfig.CleanupPolicy.Delete)) str += TopicConfig.CLEANUP_POLICY_DELETE;
                SetProperty(TopicConfig.CLEANUP_POLICY_CONFIG, str);
            }
        }

        public TopicConfigBuilder WithCleanupPolicy(TopicConfig.CleanupPolicy cleanupPolicy)
        {
            var clone = Clone();
            clone.CleanupPolicy = cleanupPolicy;
            return clone;
        }

        public bool UncleanLeaderElectionEnable { get { return GetProperty<bool>(TopicConfig.UNCLEAN_LEADER_ELECTION_ENABLE_CONFIG); } set { SetProperty(TopicConfig.UNCLEAN_LEADER_ELECTION_ENABLE_CONFIG, value); } }

        public TopicConfigBuilder WithUncleanLeaderElectionEnable(bool uncleanLeaderElectionEnable)
        {
            var clone = Clone();
            clone.UncleanLeaderElectionEnable = uncleanLeaderElectionEnable;
            return clone;
        }

        public int MinInSyncReplicas { get { return GetProperty<int>(TopicConfig.MIN_IN_SYNC_REPLICAS_CONFIG); } set { SetProperty(TopicConfig.MIN_IN_SYNC_REPLICAS_CONFIG, value); } }

        public TopicConfigBuilder WithMinInSyncReplicas(int minInSyncReplicas)
        {
            var clone = Clone();
            clone.MinInSyncReplicas = minInSyncReplicas;
            return clone;
        }

        public TopicConfig.CompressionType CompressionType
        {
            get
            {
                var strName = GetProperty<string>(TopicConfig.COMPRESSION_TYPE_CONFIG);
                if (System.Enum.TryParse<TopicConfig.CompressionType>(strName, out var rest))
                {
                    return rest;
                }
                return TopicConfig.CompressionType.producer;
            }
            set
            {
                SetProperty(TopicConfig.COMPRESSION_TYPE_CONFIG, System.Enum.GetName(typeof(TopicConfig.CompressionType), value).ToLowerInvariant());
            }
        }

        public TopicConfigBuilder WithCompressionType(TopicConfig.CompressionType compressionType)
        {
            var clone = Clone();
            clone.CompressionType = compressionType;
            return clone;
        }

        public bool Preallocate { get { return GetProperty<bool>(TopicConfig.PREALLOCATE_CONFIG); } set { SetProperty(TopicConfig.PREALLOCATE_CONFIG, value); } }

        public TopicConfigBuilder WithPreallocate(bool preallocate)
        {
            var clone = Clone();
            clone.Preallocate = preallocate;
            return clone;
        }

        public TopicConfig.MessageTimestampType MessageTimestampType
        {
            get
            {
                var strName = GetProperty<string>(TopicConfig.MESSAGE_TIMESTAMP_TYPE_CONFIG);
                if (System.Enum.TryParse<TopicConfig.MessageTimestampType>(strName, out var rest))
                {
                    return rest;
                }
                return TopicConfig.MessageTimestampType.CreateTime;
            }
            set
            {
                SetProperty(TopicConfig.MESSAGE_TIMESTAMP_TYPE_CONFIG, System.Enum.GetName(typeof(TopicConfig.MessageTimestampType), value));
            }
        }

        public TopicConfigBuilder WithCompressionType(TopicConfig.MessageTimestampType messageTimestampType)
        {
            var clone = Clone();
            clone.MessageTimestampType = messageTimestampType;
            return clone;
        }

        public int MessageTimestampDifferenceMaxMs { get { return GetProperty<int>(TopicConfig.MESSAGE_TIMESTAMP_DIFFERENCE_MAX_MS_CONFIG); } set { SetProperty(TopicConfig.MESSAGE_TIMESTAMP_DIFFERENCE_MAX_MS_CONFIG, value); } }

        public TopicConfigBuilder WithMessageTimestampDifferenceMaxMs(int messageTimestampDifferenceMaxMs)
        {
            var clone = Clone();
            clone.MessageTimestampDifferenceMaxMs = messageTimestampDifferenceMaxMs;
            return clone;
        }

        public bool MessageDownConversionEnable { get { return GetProperty<bool>(TopicConfig.MESSAGE_DOWNCONVERSION_ENABLE_CONFIG); } set { SetProperty(TopicConfig.MESSAGE_DOWNCONVERSION_ENABLE_CONFIG, value); } }

        public TopicConfigBuilder WithMessageDownConversionEnable(bool messageDownConversionEnable)
        {
            var clone = Clone();
            clone.MessageDownConversionEnable = messageDownConversionEnable;
            return clone;
        }
    }
}
