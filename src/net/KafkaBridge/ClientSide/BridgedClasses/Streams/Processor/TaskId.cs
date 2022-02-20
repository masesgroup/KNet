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

namespace MASES.KafkaBridge.Streams.Processor
{
    public class TaskId : JCOBridge.C2JBridge.JVMBridgeBase<TaskId>
    {
        public override string ClassName => "org.apache.kafka.streams.processor.TaskId";

        [System.Obsolete("This is not public in Apache Kafka API")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public TaskId() { }

        public TaskId(int topicGroupId, int partition)
            :base(topicGroupId, partition)
        {
        }

        public TaskId(int topicGroupId, int partition, string topologyName)
            :base(topicGroupId, partition, topologyName)
        {

        }

        public static TaskId Parse(string taskIdStr)
        {
            return SExecute<TaskId>("parse", taskIdStr);
        }

        public int Subtopology => IExecute<int>("subtopology");

        public int Partition => IExecute<int>("partition");

        public string TopologyName => IExecute<string>("topologyName");
    }
}
