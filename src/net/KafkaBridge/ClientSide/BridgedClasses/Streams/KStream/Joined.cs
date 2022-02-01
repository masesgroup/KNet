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
using MASES.JCOBridge.C2JBridge.Function;
using MASES.KafkaBridge.Common.Serialization;

namespace MASES.KafkaBridge.Streams.KStream
{
    public class Joined<K, V, VO> : JVMBridgeBase<Joined<K, V, VO>>, INamedOperation<Joined<K, V, VO>>
    {
        public override string ClassName => "org.apache.kafka.streams.kstream.Joined";

        public static Joined<K, V, VO> With(Serde<K> keySerde,
                                            Serde<V> valueSerde,
                                            Serde<VO> otherValueSerde)
        {
            return SExecute<Joined<K, V, VO>>("with", keySerde, valueSerde, otherValueSerde);
        }

        public static Joined<K, V, VO> With(Serde<K> keySerde,
                                            Serde<V> valueSerde,
                                            Serde<VO> otherValueSerde,
                                            string name)
        {
            return SExecute<Joined<K, V, VO>>("with", keySerde, valueSerde, otherValueSerde, name);
        }

        public static Joined<K, V, VO> KeySerde(Serde<K> keySerde)
        {
            return SExecute<Joined<K, V, VO>>("keySerde", keySerde);
        }

        public static Joined<K, V, VO> ValueSerde(Serde<V> valueSerde)
        {
            return SExecute<Joined<K, V, VO>>("valueSerde", valueSerde);
        }

        public static Joined<K, V, VO> OtherValueSerde(Serde<VO> otherValueSerde)
        {
            return SExecute<Joined<K, V, VO>>("otherValueSerde", otherValueSerde);
        }

        public static Joined<K, V, VO> As(string name)
        {
            return SExecute<Joined<K, V, VO>>("as", name);
        }

        public Joined<K, V, VO> WithKeySerde(Serde<K> keySerde)
        {
            return IExecute<Joined<K, V, VO>>("withKeySerde", keySerde);
        }

        public Joined<K, V, VO> WithValueSerde( Serde<V> valueSerde)
        {
            return IExecute<Joined<K, V, VO>>("withValueSerde", valueSerde);
        }

        public Joined<K, V, VO> WithOtherValueSerde(Serde<VO> otherValueSerde)
        {
            return IExecute<Joined<K, V, VO>>("withOtherValueSerde", otherValueSerde);
        }

        public Joined<K, V, VO> WithName(string name)
        {
            return IExecute<Joined<K, V, VO>>("withName", name);
        }

        public Serde<K> KeySerde() { return IExecute<Serde<K>>("keySerde"); }

        public Serde<V> ValueSerde() { return IExecute<Serde<V>>("valueSerde"); }

        public Serde<VO> OtherValueSerde() { return IExecute<Serde<VO>>("otherValueSerde"); }
    }
}
