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

using MASES.JCOBridge.C2JBridge;
using MASES.JCOBridge.C2JBridge.JVMInterop;

namespace MASES.KafkaBridge.Common
{
    public class PartitionInfo : JVMBridgeBase<PartitionInfo>
    {
        public override string ClassName => "org.apache.kafka.common.PartitionInfo";

        public string Topic => IExecute<string>("topic");

        public int Partition => IExecute<int>("partition");

        public Node Leader => IExecute<Node>("leader");

        public Node[] Replicas
        {
            get
            {
                var array = IExecute("replicas") as IJavaArray;
                System.Collections.Generic.List<Node> nodes = new System.Collections.Generic.List<Node>();
                foreach (var item in array)
                {
                    nodes.Add(Wraps<Node>(item as IJavaObject));
                }
                return nodes.ToArray();
            }
        }

        public Node[] InSyncReplicas
        {
            get
            {
                var array = IExecute("inSyncReplicas") as IJavaArray;
                System.Collections.Generic.List<Node> nodes = new System.Collections.Generic.List<Node>();
                foreach (var item in array)
                {
                    nodes.Add(Wraps<Node>(item as IJavaObject));
                }
                return nodes.ToArray();
            }
        }

        public Node[] OfflineReplicas
        {
            get
            {
                var array = IExecute("offlineReplicas") as IJavaArray;
                System.Collections.Generic.List<Node> nodes = new System.Collections.Generic.List<Node>();
                foreach (var item in array)
                {
                    nodes.Add(Wraps<Node>(item as IJavaObject));
                }
                return nodes.ToArray();
            }
        }
    }
}
