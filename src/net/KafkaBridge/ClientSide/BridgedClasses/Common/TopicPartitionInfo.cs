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

using Java.Util;

namespace MASES.KafkaBridge.Common
{
    public class TopicPartitionInfo : JCOBridge.C2JBridge.JVMBridgeBase<TopicPartitionInfo>
    {
        public override string ClassName => "org.apache.kafka.common.TopicPartitionInfo";

        public TopicPartitionInfo()
        {
        }

        public TopicPartitionInfo(int partition, Node leader, List<Node> replicas, List<Node> isr)
            :base(partition, leader, replicas, isr)
        {
        }

        public int Partition => IExecute<int>("partition");

        public Node Leader => IExecute<Node>("leader");

        public List<Node> Replicas => IExecute<List<Node>>("replicas");

        public List<Node> Isr => IExecute<List<Node>>("isr");
    }
}
