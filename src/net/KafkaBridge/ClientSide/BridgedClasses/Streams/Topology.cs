/*
*  Copyright 2021 MASES s.r.l.
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

namespace MASES.KafkaBridge.Streams
{
    public class Topology : JCOBridge.C2JBridge.JVMBridgeBase<Topology>
    {
        public enum AutoOffsetReset
        {
            EARLIEST, LATEST
        }

        public override string ClassName => "org.apache.kafka.streams.Topology";

        public Topology AddSource(string name, params string[] topics)
        {
            IExecute("addSource", name, topics);
            return this;
        }

        public Topology AddSource(AutoOffsetReset offsetReset, string name, params string[] topics)
        {
            IExecute("addSource", offsetReset, name, topics);
            return this;
        }

        public Topology AddSink(string name, string topic, params string[] parentNames)
        {
            IExecute("addSink", name, topic, parentNames);
            return this;
        }
    }
}
