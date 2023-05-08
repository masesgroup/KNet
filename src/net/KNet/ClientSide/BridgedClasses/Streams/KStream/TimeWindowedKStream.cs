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
using MASES.KNet.Common.Utils;
using MASES.KNet.Streams.State;

namespace MASES.KNet.Streams.KStream
{
    public interface ITimeWindowedKStream<K, V> : IJVMBridgeBase
    {
        KTable<Windowed<K>, long> Count();

        KTable<Windowed<K>, long> Count(Named named);

        KTable<Windowed<K>, long> Count(Materialized<K, long, WindowStore<Bytes, byte[]>> materialized);

        KTable<Windowed<K>, long> Count(Named named, Materialized<K, long, WindowStore<Bytes, byte[]>> materialized);

        KTable<Windowed<K>, VR> Aggregate<TSuperK, TSuperV, VR>(Initializer<VR> initializer, Aggregator<TSuperK, TSuperV, VR> aggregator)
            where TSuperK : K
            where TSuperV : V;

        KTable<Windowed<K>, VR> Aggregate<TSuperK, TSuperV, VR>(Initializer<VR> initializer, Aggregator<TSuperK, TSuperV, VR> aggregator, Named named)
            where TSuperK : K
            where TSuperV : V;

        KTable<Windowed<K>, VR> Aggregate<TSuperK, TSuperV, VR>(Initializer<VR> initializer, Aggregator<TSuperK, TSuperV, VR> aggregator, Materialized<K, VR, WindowStore<Bytes, byte[]>> materialized)
            where TSuperK : K
            where TSuperV : V;

        KTable<Windowed<K>, VR> Aggregate<TSuperK, TSuperV, VR>(Initializer<VR> initializer, Aggregator<TSuperK, TSuperV, VR> aggregator, Named named, Materialized<K, VR, WindowStore<Bytes, byte[]>> materialized)
            where TSuperK : K
            where TSuperV : V;

        KTable<Windowed<K>, V> Reduce(Reducer<V> reducer);

        KTable<Windowed<K>, V> Reduce(Reducer<V> reducer, Named named);

        KTable<Windowed<K>, V> Reduce(Reducer<V> reducer, Materialized<K, V, WindowStore<Bytes, byte[]>> materialized);

        KTable<Windowed<K>, V> Reduce(Reducer<V> reducer, Named named, Materialized<K, V, WindowStore<Bytes, byte[]>> materialized);

        TimeWindowedKStream<K, V> EmitStrategy(EmitStrategy emitStrategy);
    }

    public class TimeWindowedKStream<K, V> : JVMBridgeBase<TimeWindowedKStream<K, V>, ITimeWindowedKStream<K, V>>, ITimeWindowedKStream<K, V>
    {
        public override string BridgeClassName => "org.apache.kafka.streams.kstream.TimeWindowedKStream";

        public KTable<Windowed<K>, VR> Aggregate<TSuperK, TSuperV, VR>(Initializer<VR> initializer, Aggregator<TSuperK, TSuperV, VR> aggregator)
            where TSuperK : K
            where TSuperV : V
        {
            return IExecute<KTable<Windowed<K>, VR>>("aggregate", initializer, aggregator);
        }

        public KTable<Windowed<K>, VR> Aggregate<TSuperK, TSuperV, VR>(Initializer<VR> initializer, Aggregator<TSuperK, TSuperV, VR> aggregator, Named named)
            where TSuperK : K
            where TSuperV : V
        {
            return IExecute<KTable<Windowed<K>, VR>>("aggregate", initializer, aggregator, named);
        }

        public KTable<Windowed<K>, VR> Aggregate<TSuperK, TSuperV, VR>(Initializer<VR> initializer, Aggregator<TSuperK, TSuperV, VR> aggregator, Materialized<K, VR, WindowStore<Bytes, byte[]>> materialized)
            where TSuperK : K
            where TSuperV : V
        {
            return IExecute<KTable<Windowed<K>, VR>>("aggregate", initializer, aggregator, materialized);
        }

        public KTable<Windowed<K>, VR> Aggregate<TSuperK, TSuperV, VR>(Initializer<VR> initializer, Aggregator<TSuperK, TSuperV, VR> aggregator, Named named, Materialized<K, VR, WindowStore<Bytes, byte[]>> materialized)
            where TSuperK : K
            where TSuperV : V
        {
            return IExecute<KTable<Windowed<K>, VR>>("aggregate", initializer, aggregator, named, materialized);
        }

        public KTable<Windowed<K>, long> Count()
        {
            return IExecute<KTable<Windowed<K>, long>>("count");
        }

        public KTable<Windowed<K>, long> Count(Named named)
        {
            return IExecute<KTable<Windowed<K>, long>>("count", named);
        }

        public KTable<Windowed<K>, long> Count(Materialized<K, long, WindowStore<Bytes, byte[]>> materialized)
        {
            return IExecute<KTable<Windowed<K>, long>>("count", materialized);
        }

        public KTable<Windowed<K>, long> Count(Named named, Materialized<K, long, WindowStore<Bytes, byte[]>> materialized)
        {
            return IExecute<KTable<Windowed<K>, long>>("count", named, materialized);
        }

        public KTable<Windowed<K>, V> Reduce(Reducer<V> reducer)
        {
            return IExecute<KTable<Windowed<K>, V>>("reduce", reducer);
        }

        public KTable<Windowed<K>, V> Reduce(Reducer<V> reducer, Named named)
        {
            return IExecute<KTable<Windowed<K>, V>>("reduce", reducer, named);
        }

        public KTable<Windowed<K>, V> Reduce(Reducer<V> reducer, Materialized<K, V, WindowStore<Bytes, byte[]>> materialized)
        {
            return IExecute<KTable<Windowed<K>, V>>("reduce", reducer, materialized);
        }

        public KTable<Windowed<K>, V> Reduce(Reducer<V> reducer, Named named, Materialized<K, V, WindowStore<Bytes, byte[]>> materialized)
        {
            return IExecute<KTable<Windowed<K>, V>>("reduce", reducer, named, materialized);
        }

        public TimeWindowedKStream<K, V> EmitStrategy(EmitStrategy emitStrategy)
        {
            return IExecute<TimeWindowedKStream<K, V>>("emitStrategy", emitStrategy);
        }
    }
}
