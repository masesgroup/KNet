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
using MASES.JCOBridge.C2JBridge;

namespace MASES.KNet.Connect.Health
{
    public class ConnectorHealth : JVMBridgeBase<ConnectorHealth>
    {
        public override string ClassName => "org.apache.kafka.connect.health.ConnectorHealth";

        [System.Obsolete("This is not public in Apache Kafka API")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public ConnectorHealth()
        {
        }

        public ConnectorHealth(string name, ConnectorState connectorState, Map<int, TaskState> tasks, ConnectorType type)
            : base(name, connectorState, tasks, type)
        {
        }

        public string Name => IExecute<string>("name");

        public ConnectorState ConnectorState => IExecute<ConnectorState>("connectorState");

        public Map<int, TaskState> TasksState => IExecute<Map<int, TaskState>>("tasksState");

        public ConnectorType Type => IExecute<ConnectorType>("type");
    }
}
