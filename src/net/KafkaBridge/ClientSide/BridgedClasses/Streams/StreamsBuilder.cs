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

using MASES.KafkaBridge.Java.Util;
using MASES.KafkaBridge.Streams.KStream;

namespace MASES.KafkaBridge.Streams
{
    public class StreamsBuilder : JCOBridge.C2JBridge.JVMBridgeBase<StreamsBuilder>
    {
        public override string ClassName => "org.apache.kafka.streams.StreamsBuilder";

        public KStream<K, V> Stream<K, V>(string topic) { return New<KStream<K, V>>("stream", topic); }

        public KTable<K, V> Table<K, V>(string topic) { return New<KTable<K, V>>("table", topic); }

        public GlobalKTable<K, V> GlobalTable<K, V>(string topic) { return New<GlobalKTable<K, V>>("globalTable", topic); }

        public Topology Build()
        {
            return New<Topology>("build");
        }

        public Topology Build(Properties props)
        {
            return New<Topology>("build", props.Instance);
        }
    }
}
