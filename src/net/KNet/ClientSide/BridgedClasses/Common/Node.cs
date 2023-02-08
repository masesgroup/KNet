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

namespace MASES.KNet.Common
{
    public class Node : JCOBridge.C2JBridge.JVMBridgeBase<Node>
    {
        public override string ClassName => "org.apache.kafka.common.Node";

        public static Node NoNode => SExecute<Node>("noNode");

        public bool IsEmpty => IExecute<bool>("isEmpty");

        public int Id => IExecute<int>("id");

        public string IdString => IExecute<string>("idString");

        public string Host => IExecute<string>("host");

        public int Port => IExecute<int>("port");

        public bool HasRack => IExecute<bool>("hasRack");

        public string Rack => IExecute<string>("rack");
    }
}
