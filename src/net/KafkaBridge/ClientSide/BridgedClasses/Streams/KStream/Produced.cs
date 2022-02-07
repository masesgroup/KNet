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
using MASES.KafkaBridge.Common.Serialization;
using MASES.KafkaBridge.Streams.Processor;

namespace MASES.KafkaBridge.Streams.KStream
{
    public class Produced<K, V> : JVMBridgeBase<Produced<K, V>>, INamedOperation<Produced<K, V>>
    {
        public override string ClassName => "org.apache.kafka.streams.kstream.Produced";

        public static Produced<KIn, VIn> With<KIn, VIn>(Serde<KIn> keySerde, Serde<VIn> valueSerde)
        {
            return SExecute<Produced<KIn, VIn>>("with", keySerde, valueSerde);
        }

        public static Produced<K, V> With<TSuperK, TSuperV>(Serde<K> keySerde, Serde<V> valueSerde, StreamPartitioner<TSuperK, TSuperV> partitioner)
            where TSuperK : K
            where TSuperV: V
        {
            return SExecute<Produced<K, V>>("with", keySerde, valueSerde, partitioner);
        }

        public static Produced<K, V> As(string processorName)
        {
            return SExecute<Produced<K, V>>("as", processorName);
        }

        public static Produced<K, V> KeySerde(Serde<K> keySerde)
        {
            return SExecute<Produced<K, V>>("keySerde", keySerde);
        }

        public static Produced<K, V> ValueSerde(Serde<V> valueSerde)
        {
            return SExecute<Produced<K, V>>("valueSerde", valueSerde);
        }

        public static Produced<K, V> StreamPartitioner<TSuperK, TSuperV>(StreamPartitioner<TSuperK, TSuperV> partitioner)
            where TSuperK : K
            where TSuperV : V
        {
            return SExecute<Produced<K, V>>("streamPartitioner", partitioner);
        }

        public Produced<K, V> WithStreamPartitioner<TSuperK, TSuperV>(StreamPartitioner<TSuperK, TSuperV> partitioner)
            where TSuperK : K
            where TSuperV : V
        {
            return IExecute<Produced<K, V>>("withStreamPartitioner", partitioner);
        }

        public Produced<K, V> WithValueSerde(Serde<V> valueSerde)
        {
            return IExecute<Produced<K, V>>("withValueSerde", valueSerde);
        }

        public Produced<K, V> WithName(string name)
        {
            return IExecute<Produced<K, V>>("withName", name);
        }
    }
}
