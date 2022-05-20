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
    public class DescribeProducersResult : JCOBridge.C2JBridge.JVMBridgeBase<DescribeProducersResult>
    {
        public override string ClassName => "org.apache.kafka.clients.admin.DescribeProducersResult";

        public KafkaFuture<PartitionProducerState> PartitionResult(TopicPartition partition)
        {
            return IExecute<KafkaFuture<PartitionProducerState>>("partitionResult");
        }

        public KafkaFuture<Map<TopicPartition, PartitionProducerState>> All => IExecute<KafkaFuture<Map<TopicPartition, PartitionProducerState>>>("all");


        public class PartitionProducerState : JCOBridge.C2JBridge.JVMBridgeBase<DescribeProducersResult>
        {
            public override string ClassName => "org.apache.kafka.clients.admin.DescribeProducersResult$PartitionProducerState";

            public PartitionProducerState(List<ProducerState> activeProducers)
                :base(activeProducers)
            {
            }

            public List<ProducerState> ActiveProducers => IExecute<List<ProducerState>>("activeProducers");
        }
    }
}
