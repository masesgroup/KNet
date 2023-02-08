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

namespace MASES.KNet.Streams.KStream
{
    public class Grouped<K, V> : JVMBridgeBase<Grouped<K, V>>, INamedOperation<Grouped<K, V>>
    {
        public override string ClassName => "org.apache.kafka.streams.kstream.Grouped";

        public static Grouped<K, V> As(string name)
        {
            return SExecute<Grouped<K, V>>("as", name);
        }

        public static Grouped<K, V> KeySerde(Serde<K> keySerde)
        {
            return SExecute<Grouped<K, V>>("keySerde", keySerde);
        }

        public static Grouped<K, V> ValueSerde(Serde<V> valueSerde)
        {
            return SExecute<Grouped<K, V>>("valueSerde", valueSerde);
        }

        public static Grouped<K, V> With(string name,
                                         Serde<K> keySerde,
                                         Serde<V> valueSerde)
        {
            return SExecute<Grouped<K, V>>("with", name, keySerde, valueSerde);
        }

        public static Grouped<K, V> With(Serde<K> keySerde,
                                         Serde<V> valueSerde)
        {
            return SExecute<Grouped<K, V>>("with", keySerde, valueSerde);
        }

        public Grouped<K, V> WithName(string name)
        {
            return IExecute<Grouped<K, V>>("withName", name);
        }

        public Grouped<K, V> WithKeySerde(Serde<K> keySerde)
        {
            return IExecute<Grouped<K, V>>("withKeySerde", keySerde);
        }

        public Grouped<K, V> WithValueSerde(Serde<V> valueSerde)
        {
            return IExecute<Grouped<K, V>>("withValueSerde", valueSerde);
        }
    }
}
