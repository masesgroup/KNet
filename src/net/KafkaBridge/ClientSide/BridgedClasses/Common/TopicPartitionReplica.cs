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

namespace MASES.KafkaBridge.Common
{
    public class TopicPartitionReplica : JCOBridge.C2JBridge.JVMBridgeBase<TopicPartitionReplica>
    {
        public override string ClassName => "org.apache.kafka.common.TopicPartitionReplica";

        public TopicPartitionReplica()
        {
        }

        public TopicPartitionReplica(string topic, int partition, int brokerId)
            : base(topic, partition, brokerId)
        {
        }

        public int Partition => IExecute<int>("partition");

        public string Topic => IExecute<string>("topic");

        public int BrokerId => IExecute<int>("brokerId");
    }
}
