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
using Java.Util;
using Java.Util.Regex;
using MASES.KNet.Streams.Processor;

namespace MASES.KNet.Streams
{
    public class TopologyDescription : JVMBridgeBase<TopologyDescription>
    {
        public override string ClassName => "org.apache.kafka.streams.TopologyDescription";

        public Set<Subtopology> Subtopologies => IExecute<Set<Subtopology>>("subtopologies");

        public Set<GlobalStore> GlobalStores => IExecute<Set<GlobalStore>>("globalStores");

        public class Subtopology : JVMBridgeBase<Subtopology>
        {
            public override string ClassName => "org.apache.kafka.streams.TopologyDescription$Subtopology";

            public int Id => IExecute<int>("id");

            public Set<Node> Nodes => IExecute<Set<Node>>("nodes");
        }

        public class GlobalStore : JVMBridgeBase<GlobalStore>
        {
            public override string ClassName => "org.apache.kafka.streams.TopologyDescription$GlobalStore";

            public Source Source => IExecute<Source>("source");

            public Processor Processor => IExecute<Processor>("processor");

            public int Id => IExecute<int>("id");
        }

        public class Node : JVMBridgeBase<Node>
        {
            public override string ClassName => "org.apache.kafka.streams.TopologyDescription$Node";

            public string Name => IExecute<string>("name");

            public Set<Node> Predecessors => IExecute<Set<Node>>("predecessors");

            public Set<Node> Successors => IExecute<Set<Node>>("successors");
        }

        public class Source : Node
        {
            public override string ClassName => "org.apache.kafka.streams.TopologyDescription$Source";

            public Set<string> TopicSet => IExecute<Set<string>>("topicSet");

            public Pattern TopicPattern => IExecute<Pattern>("topicPattern");
        }

        public class Sink : Node
        {
            public override string ClassName => "org.apache.kafka.streams.TopologyDescription$Sink";

            public string Topic => IExecute<string>("topic");

            public ITopicNameExtractor TopicNameExtractor => IExecute<ITopicNameExtractor>("topicNameExtractor");
        }

        public class Processor : Node
        {
            public override string ClassName => "org.apache.kafka.streams.TopologyDescription$Processor";

            public Set<string> Stores => IExecute<Set<string>>("stores");
        }
    }
}
