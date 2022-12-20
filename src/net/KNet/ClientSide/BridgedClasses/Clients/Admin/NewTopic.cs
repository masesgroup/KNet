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

using Java.Util;

namespace MASES.KNet.Clients.Admin
{
    public class NewTopic : JCOBridge.C2JBridge.JVMBridgeBase<NewTopic>
    {
        public override string ClassName => "org.apache.kafka.clients.admin.NewTopic";

        [System.Obsolete("This is not public in Apache Kafka API", true)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public NewTopic()
        {
        }

        public NewTopic(string name, int numPartitions = 1, short replicationFactor = 1)
            : base(name, numPartitions, replicationFactor)
        {
        }

        public NewTopic(string name, Map<int, List<int>> replicasAssignments)
            :base(name, replicasAssignments)
        {
        }

        public string Name => IExecute<string>("name");

        public int NumPartitions => IExecute<int>("numPartitions");

        public int ReplicationFactor => IExecute<int>("replicationFactor");

        public Map<int, List<int>> ReplicasAssignments => IExecute<Map<int, List<int>>>("replicasAssignments");

        public NewTopic Configs(Map<string, string> configs)
        {
            return IExecute<NewTopic>("configs", configs);
        }

        public Map<string, string> Configs() => IExecute<Map<string, string>>("configs");
    }
}

