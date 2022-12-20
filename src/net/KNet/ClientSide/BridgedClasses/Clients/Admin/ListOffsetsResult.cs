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

using MASES.KNet.Common;
using Java.Util;

namespace MASES.KNet.Clients.Admin
{
    public class ListOffsetsResult : JCOBridge.C2JBridge.JVMBridgeBase<ListOffsetsResult>
    {
        public override string ClassName => "org.apache.kafka.clients.admin.ListOffsetsResult";

        [System.Obsolete("This is not public in Apache Kafka API")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public ListOffsetsResult()
        {

        }

        public ListOffsetsResult(Map<TopicPartition, KafkaFuture<ListOffsetsResultInfo>> futures)
            : base(futures)
        {

        }

        public KafkaFuture<ListOffsetsResultInfo> PartitionResult(TopicPartition partition)
        {
            return IExecute<KafkaFuture<ListOffsetsResultInfo>>("partitionResult", partition); ;
        }

        public KafkaFuture<Map<TopicPartition, ListOffsetsResultInfo>> All => IExecute<KafkaFuture<Map<TopicPartition, ListOffsetsResultInfo>>>("all");

        public class ListOffsetsResultInfo : JCOBridge.C2JBridge.JVMBridgeBase<ListOffsetsResultInfo>
        {
            public override string ClassName => "org.apache.kafka.clients.admin.ListOffsetsResult$ListOffsetsResultInfo";

            [System.Obsolete("This is not public in Apache Kafka API")]
            [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
            public ListOffsetsResultInfo()
            {

            }

            public ListOffsetsResultInfo(long offset, long timestamp, Optional<int> leaderEpoch)
                : base(offset, timestamp, leaderEpoch)
            {

            }

            public long Offset => IExecute<long>("offset");

            public long Timestamp => IExecute<long>("timestamp");

            public Optional<int> LeaderEpoch => IExecute<Optional<int>>("leaderEpoch");
        }
    }
}
