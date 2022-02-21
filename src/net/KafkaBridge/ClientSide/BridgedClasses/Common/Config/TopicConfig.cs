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

namespace MASES.KafkaBridge.Common.Config
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

        public static readonly string CLEANUP_POLICY_CONFIG = Clazz.GetField<string>("CLEANUP_POLICY_CONFIG");
        public static readonly string CLEANUP_POLICY_COMPACT = Clazz.GetField<string>("CLEANUP_POLICY_COMPACT");
        public static readonly string CLEANUP_POLICY_DELETE = Clazz.GetField<string>("CLEANUP_POLICY_DELETE");

        public static readonly string UNCLEAN_LEADER_ELECTION_ENABLE_CONFIG = Clazz.GetField<string>("UNCLEAN_LEADER_ELECTION_ENABLE_CONFIG");

        public static readonly string MIN_IN_SYNC_REPLICAS_CONFIG = Clazz.GetField<string>("MIN_IN_SYNC_REPLICAS_CONFIG");

        public static readonly string COMPRESSION_TYPE_CONFIG = Clazz.GetField<string>("COMPRESSION_TYPE_CONFIG");

        public static readonly string PREALLOCATE_CONFIG = Clazz.GetField<string>("PREALLOCATE_CONFIG");

        [System.Obsolete()]
        public static readonly string MESSAGE_FORMAT_VERSION_CONFIG = Clazz.GetField<string>("MESSAGE_FORMAT_VERSION_CONFIG");

        public static readonly string MESSAGE_TIMESTAMP_TYPE_CONFIG = Clazz.GetField<string>("MESSAGE_TIMESTAMP_TYPE_CONFIG");

        public static readonly string MESSAGE_TIMESTAMP_DIFFERENCE_MAX_MS_CONFIG = Clazz.GetField<string>("MESSAGE_TIMESTAMP_DIFFERENCE_MAX_MS_CONFIG");

        public static readonly string MESSAGE_DOWNCONVERSION_ENABLE_CONFIG = Clazz.GetField<string>("MESSAGE_DOWNCONVERSION_ENABLE_CONFIG");

    }
}
