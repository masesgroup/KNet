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

using MASES.KNet.Clients;
using MASES.KNet.Common.Config;
using Java.Util;
using MASES.KNet.Streams.KStream;
using MASES.JCOBridge.C2JBridge;

namespace MASES.KNet.Streams
{
    public class TopologyConfig : AbstractConfig<TopologyConfig>
    {
        public override string BridgeClassName => "org.apache.kafka.streams.TopologyConfig";

        public TopologyConfig()
        {
        }

        public TopologyConfig(StreamsConfig globalAppConfigs)
            : base(globalAppConfigs)
        {
        }

        public TopologyConfig(string topologyName, StreamsConfig globalAppConfigs, Properties topologyOverrides)
            : base(topologyName, globalAppConfigs, topologyOverrides)
        {
        }

        public Materialized.StoreType ParseStoreType => IExecute<Materialized.StoreType>("parseStoreType");

        public bool IsNamedTopology => IExecute<bool>("isNamedTopology");

        public TaskConfig GetTaskConfig() => IExecute<TaskConfig>("getTaskConfig");

        public class TaskConfig : JVMBridgeBase<TaskConfig>
        {
            public override string BridgeClassName => "org.apache.kafka.streams.TopologyConfig$TaskConfig";

            // TO BE COMPETED
        }
    }
}
