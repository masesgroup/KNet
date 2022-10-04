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
using MASES.KNet.Common.Utils;
using MASES.KNet.Streams.State;

namespace MASES.KNet.Streams.KStream
{
    public interface ISessionWindowedKStream<K, V> : IJVMBridgeBase
    {
        KTable<Windowed<K>, long> Count();

        KTable<Windowed<K>, long> Count(Named named);

        KTable<Windowed<K>, long> Count(Materialized<K, long, SessionStore<Bytes, byte[]>> materialized);

        KTable<Windowed<K>, long> Count(Named named, Materialized<K, long, SessionStore<Bytes, byte[]>> materialized);

        KTable<Windowed<K>, VR> Aggregate<TSuperK, TSuperV, VR>(Initializer<VR> initializer,
                                                                Aggregator<TSuperK, TSuperV, VR> aggregator,
                                                                Merger<TSuperK, VR> sessionMerger)
            where TSuperK : K
            where TSuperV : V;

        KTable<Windowed<K>, VR> Aggregate<TSuperK, TSuperV, VR>(Initializer<VR> initializer,
                                                                Aggregator<TSuperK, TSuperV, VR> aggregator,
                                                                Merger<TSuperK, VR> sessionMerger,
                                                                Named named)
            where TSuperK : K
            where TSuperV : V;

        KTable<Windowed<K>, VR> Aggregate<TSuperK, TSuperV, VR>(Initializer<VR> initializer,
                                                                Aggregator<TSuperK, TSuperV, VR> aggregator,
                                                                Merger<TSuperK, VR> sessionMerger,
                                                                Named named,
                                                                Materialized<K, VR, SessionStore<Bytes, byte[]>> materialized)
            where TSuperK : K
            where TSuperV : V;

        KTable<Windowed<K>, VR> Aggregate<TSuperK, TSuperV, VR>(Initializer<VR> initializer,
                                                                Aggregator<TSuperK, TSuperV, VR> aggregator,
                                                                Merger<TSuperK, VR> sessionMerger,
                                                                Materialized<K, VR, SessionStore<Bytes, byte[]>> materialized)
            where TSuperK : K
            where TSuperV : V;

        KTable<Windowed<K>, V> Reduce(Reducer<V> reducer);

        KTable<Windowed<K>, V> Reduce(Reducer<V> reducer, Named named);

        KTable<Windowed<K>, V> Reduce(Reducer<V> reducer,
                                      Materialized<K, V, SessionStore<Bytes, byte[]>> materialized);

        KTable<Windowed<K>, V> Reduce(Reducer<V> reducer,
                                      Named named,
                                      Materialized<K, V, SessionStore<Bytes, byte[]>> materialized);

        SessionWindowedKStream<K, V> EmitStrategy(EmitStrategy emitStrategy);
    }

    public class SessionWindowedKStream<K, V> : JVMBridgeBase<SessionWindowedKStream<K, V>, ISessionWindowedKStream<K, V>>, ISessionWindowedKStream<K, V>
    {
        public override string ClassName => "org.apache.kafka.streams.kstream.SessionWindowedKStream";

        public KTable<Windowed<K>, VR> Aggregate<TSuperK, TSuperV, VR>(Initializer<VR> initializer, Aggregator<TSuperK, TSuperV, VR> aggregator, Merger<TSuperK, VR> sessionMerger)
            where TSuperK : K
            where TSuperV : V
        {
            return IExecute<KTable<Windowed<K>, VR>>("aggregate", initializer, aggregator, sessionMerger);
        }

        public KTable<Windowed<K>, VR> Aggregate<TSuperK, TSuperV, VR>(Initializer<VR> initializer, Aggregator<TSuperK, TSuperV, VR> aggregator, Merger<TSuperK, VR> sessionMerger, Named named)
            where TSuperK : K
            where TSuperV : V
        {
            return IExecute<KTable<Windowed<K>, VR>>("aggregate", initializer, aggregator, sessionMerger, named);
        }

        public KTable<Windowed<K>, VR> Aggregate<TSuperK, TSuperV, VR>(Initializer<VR> initializer, Aggregator<TSuperK, TSuperV, VR> aggregator, Merger<TSuperK, VR> sessionMerger, Named named, Materialized<K, VR, SessionStore<Bytes, byte[]>> materialized)
            where TSuperK : K
            where TSuperV : V
        {
            return IExecute<KTable<Windowed<K>, VR>>("aggregate", initializer, aggregator, sessionMerger, named, materialized);
        }

        public KTable<Windowed<K>, VR> Aggregate<TSuperK, TSuperV, VR>(Initializer<VR> initializer, Aggregator<TSuperK, TSuperV, VR> aggregator, Merger<TSuperK, VR> sessionMerger, Materialized<K, VR, SessionStore<Bytes, byte[]>> materialized)
            where TSuperK : K
            where TSuperV : V
        {
            return IExecute<KTable<Windowed<K>, VR>>("aggregate", initializer, aggregator, sessionMerger, materialized);
        }

        public KTable<Windowed<K>, long> Count()
        {
            return IExecute<KTable<Windowed<K>, long>>("count");
        }

        public KTable<Windowed<K>, long> Count(Named named)
        {
            return IExecute<KTable<Windowed<K>, long>>("count", named);
        }

        public KTable<Windowed<K>, long> Count(Materialized<K, long, SessionStore<Bytes, byte[]>> materialized)
        {
            return IExecute<KTable<Windowed<K>, long>>("count", materialized);
        }

        public KTable<Windowed<K>, long> Count(Named named, Materialized<K, long, SessionStore<Bytes, byte[]>> materialized)
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

        public KTable<Windowed<K>, V> Reduce(Reducer<V> reducer, Materialized<K, V, SessionStore<Bytes, byte[]>> materialized)
        {
            return IExecute<KTable<Windowed<K>, V>>("reduce", reducer, materialized);
        }

        public KTable<Windowed<K>, V> Reduce(Reducer<V> reducer, Named named, Materialized<K, V, SessionStore<Bytes, byte[]>> materialized)
        {
            return IExecute<KTable<Windowed<K>, V>>("reduce", reducer, named, materialized);
        }

        public SessionWindowedKStream<K, V> EmitStrategy(EmitStrategy emitStrategy)
        {
            return IExecute<SessionWindowedKStream<K, V>>("emitStrategy", emitStrategy);
        }
    }
}
