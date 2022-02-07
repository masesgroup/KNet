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
using MASES.KafkaBridge.Common.Utils;
using MASES.KafkaBridge.Streams.State;

namespace MASES.KafkaBridge.Streams.KStream
{
    public interface IKGroupedTable<K, V> : IJVMBridgeBase
    {
        KTable<K, long> Count(Materialized<K, long, KeyValueStore<Bytes, byte[]>> materialized);

        KTable<K, long> Count(Named named, Materialized<K, long, KeyValueStore<Bytes, byte[]>> materialized);

        KTable<K, long> Count();

        KTable<K, long> Count(Named named);

        KTable<K, V> Reduce(Reducer<V> adder,
                            Reducer<V> subtractor,
                            Materialized<K, V, KeyValueStore<Bytes, byte[]>> materialized);

        KTable<K, V> Reduce(Reducer<V> adder,
                            Reducer<V> subtractor,
                            Named named,
                            Materialized<K, V, KeyValueStore<Bytes, byte[]>> materialized);

        KTable<K, V> Reduce(Reducer<V> adder,
                            Reducer<V> subtractor);

        KTable<K, VR> Aggregate<TSuperK, TSuperV, VR>(Initializer<VR> initializer,
                                                      Aggregator<TSuperK, TSuperV, VR> adder,
                                                      Aggregator<TSuperK, TSuperV, VR> subtractor,
                                                      Materialized<K, VR, KeyValueStore<Bytes, byte[]>> materialized)
            where TSuperK : K
            where TSuperV : V;

        KTable<K, VR> Aggregate<TSuperK, TSuperV, VR>(Initializer<VR> initializer,
                                                      Aggregator<TSuperK, TSuperV, VR> adder,
                                                      Aggregator<TSuperK, TSuperV, VR> subtractor,
                                                      Named named,
                                                      Materialized<K, VR, KeyValueStore<Bytes, byte[]>> materialized)
            where TSuperK : K
            where TSuperV : V;

        KTable<K, VR> Aggregate<TSuperK, TSuperV, VR>(Initializer<VR> initializer,
                                                      Aggregator<TSuperK, TSuperV, VR> adder,
                                                      Aggregator<TSuperK, TSuperV, VR> subtractor)
            where TSuperK : K
            where TSuperV : V;

        KTable<K, VR> Aggregate<TSuperK, TSuperV, VR>(Initializer<VR> initializer,
                                                      Aggregator<TSuperK, TSuperV, VR> adder,
                                                      Aggregator<TSuperK, TSuperV, VR> subtractor,
                                                      Named named)
            where TSuperK : K
            where TSuperV : V;
    }

    public class KGroupedTable<K, V> : JVMBridgeBase<KGroupedTable<K, V>, IKGroupedTable<K, V>>, IKGroupedTable<K, V>
    {
        public override string ClassName => "org.apache.kafka.streams.kstream.KGroupedTable";

        public KTable<K, VR> Aggregate<TSuperK, TSuperV, VR>(Initializer<VR> initializer, Aggregator<TSuperK, TSuperV, VR> adder, Aggregator<TSuperK, TSuperV, VR> subtractor, Materialized<K, VR, KeyValueStore<Bytes, byte[]>> materialized)
            where TSuperK : K
            where TSuperV : V
        {
            return IExecute<KTable<K, VR>>("aggregate", initializer, adder, subtractor, materialized);
        }

        public KTable<K, VR> Aggregate<TSuperK, TSuperV, VR>(Initializer<VR> initializer, Aggregator<TSuperK, TSuperV, VR> adder, Aggregator<TSuperK, TSuperV, VR> subtractor, Named named, Materialized<K, VR, KeyValueStore<Bytes, byte[]>> materialized)
            where TSuperK : K
            where TSuperV : V
        {
            return IExecute<KTable<K, VR>>("aggregate", initializer, adder, subtractor, named, materialized);
        }

        public KTable<K, VR> Aggregate<TSuperK, TSuperV, VR>(Initializer<VR> initializer, Aggregator<TSuperK, TSuperV, VR> adder, Aggregator<TSuperK, TSuperV, VR> subtractor)
            where TSuperK : K
            where TSuperV : V
        {
            return IExecute<KTable<K, VR>>("aggregate", initializer, adder, subtractor);
        }

        public KTable<K, VR> Aggregate<TSuperK, TSuperV, VR>(Initializer<VR> initializer, Aggregator<TSuperK, TSuperV, VR> adder, Aggregator<TSuperK, TSuperV, VR> subtractor, Named named)
            where TSuperK : K
            where TSuperV : V
        {
            return IExecute<KTable<K, VR>>("aggregate", initializer, adder, subtractor, named);
        }

        public KTable<K, long> Count(Materialized<K, long, KeyValueStore<Bytes, byte[]>> materialized)
        {
            return IExecute<KTable<K, long>>("count", materialized);
        }

        public KTable<K, long> Count(Named named, Materialized<K, long, KeyValueStore<Bytes, byte[]>> materialized)
        {
            return IExecute<KTable<K, long>>("count", named, materialized);
        }

        public KTable<K, long> Count()
        {
            return IExecute<KTable<K, long>>("count");
        }

        public KTable<K, long> Count(Named named)
        {
            return IExecute<KTable<K, long>>("count", named);
        }

        public KTable<K, V> Reduce(Reducer<V> adder, Reducer<V> subtractor, Materialized<K, V, KeyValueStore<Bytes, byte[]>> materialized)
        {
            return IExecute<KTable<K, V>>("reduce", adder, subtractor, materialized);
        }

        public KTable<K, V> Reduce(Reducer<V> adder, Reducer<V> subtractor, Named named, Materialized<K, V, KeyValueStore<Bytes, byte[]>> materialized)
        {
            return IExecute<KTable<K, V>>("reduce", adder, subtractor, named, materialized);
        }

        public KTable<K, V> Reduce(Reducer<V> adder, Reducer<V> subtractor)
        {
            return IExecute<KTable<K, V>>("reduce", adder, subtractor);
        }
    }
}
