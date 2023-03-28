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
using Org.Apache.Kafka.Common.Utils;
using Org.Apache.Kafka.Streams.State;

namespace Org.Apache.Kafka.Streams.KStream
{
    public interface IKGroupedStream<K, V> : IJVMBridgeBase
    {
        KTable<K, long> Count();

        KTable<K, long> Count(Named named);

        KTable<K, long> Count(Materialized<K, long, KeyValueStore<Bytes, byte[]>> materialized);

        KTable<K, long> Count(Named named,
                              Materialized<K, long, KeyValueStore<Bytes, byte[]>> materialized);

        KTable<K, V> Reduce(Reducer<V> reducer);

        KTable<K, V> Reduce(Reducer<V> reducer,
                            Materialized<K, V, KeyValueStore<Bytes, byte[]>> materialized);

        KTable<K, V> Reduce(Reducer<V> reducer,
                            Named named,
                            Materialized<K, V, KeyValueStore<Bytes, byte[]>> materialized);

        KTable<K, VR> Aggregate<TSuperK, TSuperV, VR>(Initializer<VR> initializer,
                                                      Aggregator<TSuperK, TSuperV, VR> aggregator);


        KTable<K, VR> Aggregate<TSuperK, TSuperV, VR>(Initializer<VR> initializer,
                                                      Aggregator<TSuperK, TSuperV, VR> aggregator,
                                                      Materialized<K, VR, KeyValueStore<Bytes, byte[]>> materialized);


        KTable<K, VR> Aggregate<TSuperK, TSuperV, VR>(Initializer<VR> initializer,
                                                      Aggregator<TSuperK, TSuperV, VR> aggregator,
                                                      Named named,
                                                      Materialized<K, VR, KeyValueStore<Bytes, byte[]>> materialized);

        TimeWindowedKStream<K, V> WindowedBy<W>(Windows<W> windows)
            where W : Window;

        TimeWindowedKStream<K, V> WindowedBy(SlidingWindows windows);

        SessionWindowedKStream<K, V> WindowedBy(SessionWindows windows);

        CogroupedKStream<K, VOut> Cogroup<TSuperK, TSuperV, VOut>(Aggregator<TSuperK, TSuperV, VOut> aggregator)
            where TSuperK : K
            where TSuperV : V;
    }

    public class KGroupedStream<K, V> : JVMBridgeBase<KGroupedStream<K, V>, IKGroupedStream<K, V>>, IKGroupedStream<K, V>
    {
        public override string ClassName => "org.apache.kafka.streams.kstream.KGroupedStream";

        public KTable<K, VR> Aggregate<TSuperK, TSuperV, VR>(Initializer<VR> initializer, Aggregator<TSuperK, TSuperV, VR> aggregator)
        {
            return IExecute<KTable<K, VR>>("aggregate", initializer, aggregator);
        }

        public KTable<K, VR> Aggregate<TSuperK, TSuperV, VR>(Initializer<VR> initializer, Aggregator<TSuperK, TSuperV, VR> aggregator, Materialized<K, VR, KeyValueStore<Bytes, byte[]>> materialized)
        {
            return IExecute<KTable<K, VR>>("aggregate", initializer, aggregator, materialized);
        }

        public KTable<K, VR> Aggregate<TSuperK, TSuperV, VR>(Initializer<VR> initializer, Aggregator<TSuperK, TSuperV, VR> aggregator, Named named, Materialized<K, VR, KeyValueStore<Bytes, byte[]>> materialized)
        {
            return IExecute<KTable<K, VR>>("aggregate", initializer, aggregator, named, materialized);
        }

        public CogroupedKStream<K, VOut> Cogroup<TSuperK, TSuperV, VOut>(Aggregator<TSuperK, TSuperV, VOut> aggregator)
            where TSuperK : K
            where TSuperV : V
        {
            return IExecute<CogroupedKStream<K, VOut>>("cogroup", aggregator);
        }

        public KTable<K, long> Count()
        {
            return IExecute<KTable<K, long>>("count");
        }

        public KTable<K, long> Count(Named named)
        {
            return IExecute<KTable<K, long>>("count", named);
        }

        public KTable<K, long> Count(Materialized<K, long, KeyValueStore<Bytes, byte[]>> materialized)
        {
            return IExecute<KTable<K, long>>("count", materialized);
        }

        public KTable<K, long> Count(Named named, Materialized<K, long, KeyValueStore<Bytes, byte[]>> materialized)
        {
            return IExecute<KTable<K, long>>("count", named, materialized);
        }

        public KTable<K, V> Reduce(Reducer<V> reducer)
        {
            return IExecute<KTable<K, V>>("reduce", reducer);
        }

        public KTable<K, V> Reduce(Reducer<V> reducer, Materialized<K, V, KeyValueStore<Bytes, byte[]>> materialized)
        {
            return IExecute<KTable<K, V>>("reduce", reducer, materialized);
        }

        public KTable<K, V> Reduce(Reducer<V> reducer, Named named, Materialized<K, V, KeyValueStore<Bytes, byte[]>> materialized)
        {
            return IExecute<KTable<K, V>>("reduce", reducer, named, materialized);
        }

        public TimeWindowedKStream<K, V> WindowedBy<W>(Windows<W> windows) where W : Window
        {
            return IExecute<TimeWindowedKStream<K, V>>("windowedBy", windows);
        }

        public TimeWindowedKStream<K, V> WindowedBy(SlidingWindows windows)
        {
            return IExecute<TimeWindowedKStream<K, V>>("windowedBy", windows);
        }

        public SessionWindowedKStream<K, V> WindowedBy(SessionWindows windows)
        {
            return IExecute<SessionWindowedKStream<K, V>>("windowedBy", windows);
        }
    }
}
