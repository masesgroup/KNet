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
    public class Repartitioned<K, V> : JVMBridgeBase<Repartitioned<K, V>>, INamedOperation<Repartitioned<K, V>>
    {
        public override string BridgeClassName => "org.apache.kafka.streams.kstream.Repartitioned";

        public static Repartitioned<K, V> As(string name)
        {
            return SExecute<Repartitioned<K, V>>("as", name);
        }

        public static Repartitioned<K, V> With(Serde<K> keySerde,
                                               Serde<V> valueSerde)
        {
            return SExecute<Repartitioned<K, V>>("with", keySerde, valueSerde);
        }

        public static Repartitioned<K, V> StreamPartitioner(StreamPartitioner<K, V> partitioner)
        {
            return SExecute<Repartitioned<K, V>>("streamPartitioner", partitioner);
        }

        public static Repartitioned<K, V> NumberOfPartitions(int numberOfPartitions)
        {
            return SExecute<Repartitioned<K, V>>("numberOfPartitions", numberOfPartitions);
        }

        public Repartitioned<K, V> WithName(string name)
        {
            return IExecute<Repartitioned<K, V>>("withName", name);
        }
    }
}
