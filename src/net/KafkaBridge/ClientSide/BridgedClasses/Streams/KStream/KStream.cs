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

namespace MASES.KafkaBridge.Streams.KStream
{
    public class KStream<K, V> : JCOBridge.C2JBridge.JVMBridgeBase<KStream<K, V>>
    {
        public override string ClassName => "org.apache.kafka.streams.kstream.KStream";

        public KStream<K, V> Merge(KStream<K, V> stream) { return New<KStream<K, V>>("merge", stream.Instance); }

        public KStream<K, V> Repartition() { return New<KStream<K, V>>("repartition"); }

       public void To(string topic) { IExecute("to", topic); }

        public KTable<K, V> ToTable() { return New<KTable<K, V>>("toTable"); }
    }
}
