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

using MASES.JCOBridge.C2JBridge;
using MASES.KNet.Common.Serialization;
using MASES.KNet.Streams.Processor;

namespace MASES.KNet.Streams.KStream
{
    public class Consumed<K, V> : JVMBridgeBase<Consumed<K, V>>, INamedOperation<Consumed<K, V>>
    {
        public override string ClassName => "org.apache.kafka.streams.kstream.Consumed";

        public static Consumed<K, V> With(Serde<K> keySerde,
                                          Serde<V> valueSerde,
                                          TimestampExtractor timestampExtractor,
                                          Topology.AutoOffsetReset resetPolicy)
        {
            return SExecute<Consumed<K, V>>("with", keySerde, valueSerde, timestampExtractor, resetPolicy);
        }

        public static Consumed<K, V> With(Serde<K> keySerde, Serde<V> valueSerde)
        {
            return SExecute<Consumed<K, V>>("with", keySerde, valueSerde);
        }

        public static Consumed<K, V> With(TimestampExtractor timestampExtractor)
        {
            return SExecute<Consumed<K, V>>("with", timestampExtractor);
        }

        public static Consumed<K, V> With(Topology.AutoOffsetReset resetPolicy)
        {
            return SExecute<Consumed<K, V>>("with", resetPolicy);
        }

        public Consumed<K, V> WithKeySerde(Serde<K> keySerde)
        {
            return IExecute<Consumed<K, V>>("withKeySerde", keySerde);
        }

        public Consumed<K, V> WithValueSerde(Serde<V> valueSerde)
        {
            return IExecute<Consumed<K, V>>("withValueSerde", valueSerde);
        }

        public Consumed<K, V> WithTimestampExtractor(TimestampExtractor timestampExtractor)
        {
            return IExecute<Consumed<K, V>>("withTimestampExtractor", timestampExtractor);
        }

        public Consumed<K, V> WithOffsetResetPolicy(Topology.AutoOffsetReset resetPolicy)
        {
            return IExecute<Consumed<K, V>>("withOffsetResetPolicy", resetPolicy);
        }

        public Consumed<K, V> WithName(string name)
        {
            return IExecute<Consumed<K, V>>("withName", name);
        }
    }
}
