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

using MASES.KNet.Common;
using Java.Util;

namespace MASES.KNet.Clients.Admin
{
    public class DescribeReplicaLogDirsResult : JCOBridge.C2JBridge.JVMBridgeBase<DescribeReplicaLogDirsResult>
    {
        public override string ClassName => "org.apache.kafka.clients.admin.DescribeReplicaLogDirsResult";

        public Map<TopicPartitionReplica, KafkaFuture<ReplicaLogDirInfo>> Values => IExecute<Map<TopicPartitionReplica, KafkaFuture<ReplicaLogDirInfo>>>("values");

        public KafkaFuture<Map<TopicPartitionReplica, ReplicaLogDirInfo>> All => IExecute<KafkaFuture<Map<TopicPartitionReplica, ReplicaLogDirInfo>>>("all");

        public class ReplicaLogDirInfo : JCOBridge.C2JBridge.JVMBridgeBase<DescribeReplicaLogDirsResult>
        {
            public override string ClassName => "org.apache.kafka.clients.admin.DescribeReplicaLogDirsResult$ReplicaLogDirInfo";

            public string GetCurrentReplicaLogDir => IExecute<string>("getCurrentReplicaLogDir");

            public long GetCurrentReplicaOffsetLag => IExecute<long>("getCurrentReplicaOffsetLag");

            public string GetFutureReplicaLogDir => IExecute<string>("getFutureReplicaLogDir");

            public long GetFutureReplicaOffsetLag => IExecute<long>("getFutureReplicaOffsetLag");
        }
    }
}
