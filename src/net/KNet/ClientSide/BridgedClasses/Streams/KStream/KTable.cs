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
using Java.Util.Function;
using MASES.KNet.Common.Utils;
using MASES.KNet.Streams.State;

namespace MASES.KNet.Streams.KStream
{
    public interface IKTable<K, V> : IJVMBridgeBase
    {
        KTable<K, V> Filter<T, J>(Predicate<T, J> predicate)
            where T : K
            where J : V;

        KTable<K, V> Filter<T, J>(Predicate<T, J> predicate, Named named)
            where T : K
            where J : V;

        KTable<K, V> Filter<T, J>(Predicate<T, J> predicate, Materialized<K, V, KeyValueStore<Bytes, byte[]>> materialized)
            where T : K
            where J : V;

        KTable<K, V> Filter<T, J>(Predicate<T, J> predicate, Named named, Materialized<K, V, KeyValueStore<Bytes, byte[]>> materialized)
            where T : K
            where J : V;


        KTable<K, V> FilterNot<T, J>(Predicate<T, J> predicate)
            where T : K
            where J : V;

        KTable<K, V> FilterNot<T, J>(Predicate<T, J> predicate, Named named)
            where T : K
            where J : V;

        KTable<K, V> FilterNot<T, J>(Predicate<T, J> predicate, Materialized<K, V, KeyValueStore<Bytes, byte[]>> materialized)
            where T : K
            where J : V;

        KTable<K, V> FilterNot<T, J>(Predicate<T, J> predicate, Named named, Materialized<K, V, KeyValueStore<Bytes, byte[]>> materialized)
            where T : K
            where J : V;

        KTable<K, VR> MapValues<VData, VR>(ValueMapper<VData, VR> mapper)
            where VData : V;

        KTable<K, VR> MapValues<VData, VR>(ValueMapper<VData, VR> mapper, Named named)
            where VData : V;

        KTable<K, VR> MapValues<KData, VData, VR>(ValueMapperWithKey<KData, VData, VR> mapper)
            where KData : K
            where VData : V;

        KTable<K, VR> MapValues<KData, VData, VR>(ValueMapperWithKey<KData, VData, VR> mapper, Named named)
            where KData : K
            where VData : V;

        KTable<K, VR> MapValues<VData, VR>(ValueMapper<VData, VR> mapper, Materialized<K, VR, KeyValueStore<Bytes, byte[]>> materialized)
            where VData : V;

        KTable<K, VR> MapValues<VData, VR>(ValueMapper<VData, VR> mapper, Named named, Materialized<K, VR, KeyValueStore<Bytes, byte[]>> materialized)
            where VData : V;

        KTable<K, VR> MapValues<KData, VData, VR>(ValueMapperWithKey<KData, VData, VR> mapper, Materialized<K, VR, KeyValueStore<Bytes, byte[]>> materialized)
            where KData : K
            where VData : V;

        KTable<K, VR> MapValues<KData, VData, VR>(ValueMapperWithKey<KData, VData, VR> mapper, Named named, Materialized<K, VR, KeyValueStore<Bytes, byte[]>> materialized)
            where KData : K
            where VData : V;

        KStream<K, V> ToStream();

        KStream<K, V> ToStream(Named named);

        KStream<KR, V> ToStream<TSuperK, TSuperV, TExtendsKR, KR>(KeyValueMapper<TSuperK, TSuperV, TExtendsKR> mapper)
            where TSuperK : K
            where TSuperV : V
            where TExtendsKR : KR;

        KStream<KR, V> ToStream<TSuperK, TSuperV, TExtendsKR, KR>(KeyValueMapper<TSuperK, TSuperV, TExtendsKR> mapper, Named named)
            where TSuperK : K
            where TSuperV : V
            where TExtendsKR : KR;

        KTable<K, V> Suppress<TSuperK>(Suppressed<TSuperK> suppressed)
            where TSuperK : K;

        KTable<K, VR> TransformValues<TSuperK, TSuperV, TExtendsVR, VR>(ValueTransformerWithKeySupplier<TSuperK, TSuperV, TExtendsVR> transformerSupplier, params string[] stateStoreNames)
            where TSuperK : K
            where TSuperV : V
            where TExtendsVR : VR;

        KTable<K, VR> TransformValues<TSuperK, TSuperV, TExtendsVR, VR>(ValueTransformerWithKeySupplier<TSuperK, TSuperV, TExtendsVR> transformerSupplier, Named named, params string[] stateStoreNames)
            where TSuperK : K
            where TSuperV : V
            where TExtendsVR : VR;

        KTable<K, VR> TransformValues<TSuperK, TSuperV, TExtendsVR, VR>(ValueTransformerWithKeySupplier<TSuperK, TSuperV, TExtendsVR> transformerSupplier, Materialized<K, VR, KeyValueStore<Bytes, byte[]>> materialized, params string[] stateStoreNames)
            where TSuperK : K
            where TSuperV : V
            where TExtendsVR : VR;

        KTable<K, VR> TransformValues<TSuperK, TSuperV, TExtendsVR, VR>(ValueTransformerWithKeySupplier<TSuperK, TSuperV, TExtendsVR> transformerSupplier, Materialized<K, VR, KeyValueStore<Bytes, byte[]>> materialized, Named named, params string[] stateStoreNames)
            where TSuperK : K
            where TSuperV : V
            where TExtendsVR : VR;

        KGroupedTable<KR, VR> GroupBy<TSuperK, TSuperV, KR, VR>(KeyValueMapper<TSuperK, TSuperV, KeyValue<KR, VR>> selector);

        KGroupedTable<KR, VR> GroupBy<TSuperK, TSuperV, KR, VR>(KeyValueMapper<TSuperK, TSuperV, KeyValue<KR, VR>> selector, Grouped<KR, VR> grouped);

        KTable<K, VR> Join<TSuperV, TSuperVO, VO, TExtendsVR, VR>(KTable<K, VO> other, ValueJoiner<TSuperV, TSuperVO, TExtendsVR> joiner)
            where TSuperV : V
            where TSuperVO : VO
            where TExtendsVR : VR;

        KTable<K, VR> Join<TSuperV, TSuperVO, VO, TExtendsVR, VR>(KTable<K, VO> other, ValueJoiner<TSuperV, TSuperVO, TExtendsVR> joiner, Named named)
            where TSuperV : V
            where TSuperVO : VO
            where TExtendsVR : VR;

        KTable<K, VR> Join<TSuperV, TSuperVO, VO, TExtendsVR, VR>(KTable<K, VO> other, ValueJoiner<TSuperV, TSuperVO, TExtendsVR> joiner, Materialized<K, VR, KeyValueStore<Bytes, byte[]>> materialized)
            where TSuperV : V
            where TSuperVO : VO
            where TExtendsVR : VR;

        KTable<K, VR> Join<TSuperV, TSuperVO, VO, TExtendsVR, VR>(KTable<K, VO> other, ValueJoiner<TSuperV, TSuperVO, TExtendsVR> joiner, Named named, Materialized<K, VR, KeyValueStore<Bytes, byte[]>> materialized)
            where TSuperV : V
            where TSuperVO : VO
            where TExtendsVR : VR;

        KTable<K, VR> LeftJoin<TSuperV, TSuperVO, VO, TExtendsVR, VR>(KTable<K, VO> other, ValueJoiner<TSuperV, TSuperVO, TExtendsVR> joiner)
            where TSuperV : V
            where TSuperVO : VO
            where TExtendsVR : VR;

        KTable<K, VR> LeftJoin<TSuperV, TSuperVO, VO, TExtendsVR, VR>(KTable<K, VO> other, ValueJoiner<TSuperV, TSuperVO, TExtendsVR> joiner, Named named)
            where TSuperV : V
            where TSuperVO : VO
            where TExtendsVR : VR;

        KTable<K, VR> LeftJoin<TSuperV, TSuperVO, VO, TExtendsVR, VR>(KTable<K, VO> other, ValueJoiner<TSuperV, TSuperVO, TExtendsVR> joiner, Materialized<K, VR, KeyValueStore<Bytes, byte[]>> materialized)
            where TSuperV : V
            where TSuperVO : VO
            where TExtendsVR : VR;

        KTable<K, VR> LeftJoin<TSuperV, TSuperVO, VO, TExtendsVR, VR>(KTable<K, VO> other, ValueJoiner<TSuperV, TSuperVO, TExtendsVR> joiner, Named named, Materialized<K, VR, KeyValueStore<Bytes, byte[]>> materialized)
            where TSuperV : V
            where TSuperVO : VO
            where TExtendsVR : VR;

        KTable<K, VR> OuterJoin<TSuperV, TSuperVO, VO, TExtendsVR, VR>(KTable<K, VO> other, ValueJoiner<TSuperV, TSuperVO, TExtendsVR> joiner)
            where TSuperV : V
            where TSuperVO : VO
            where TExtendsVR : VR;

        KTable<K, VR> OuterJoin<TSuperV, TSuperVO, VO, TExtendsVR, VR>(KTable<K, VO> other, ValueJoiner<TSuperV, TSuperVO, TExtendsVR> joiner, Named named)
            where TSuperV : V
            where TSuperVO : VO
            where TExtendsVR : VR;

        KTable<K, VR> OuterJoin<TSuperV, TSuperVO, VO, TExtendsVR, VR>(KTable<K, VO> other, ValueJoiner<TSuperV, TSuperVO, TExtendsVR> joiner, Materialized<K, VR, KeyValueStore<Bytes, byte[]>> materialized)
            where TSuperV : V
            where TSuperVO : VO
            where TExtendsVR : VR;

        KTable<K, VR> OuterJoin<TSuperV, TSuperVO, VO, TExtendsVR, VR>(KTable<K, VO> other, ValueJoiner<TSuperV, TSuperVO, TExtendsVR> joiner, Named named, Materialized<K, VR, KeyValueStore<Bytes, byte[]>> materialized)
            where TSuperV : V
            where TSuperVO : VO
            where TExtendsVR : VR;

        KTable<K, VR> Join<KO, VO, VR>(KTable<KO, VO> other, Function<V, KO> foreignKeyExtractor, ValueJoiner<V, VO, VR> joiner);

        KTable<K, VR> Join<KO, VO, VR>(KTable<KO, VO> other, Function<V, KO> foreignKeyExtractor, ValueJoiner<V, VO, VR> joiner, Named named);

        KTable<K, VR> Join<KO, VO, VR>(KTable<KO, VO> other, Function<V, KO> foreignKeyExtractor, ValueJoiner<V, VO, VR> joiner, Materialized<K, VR, KeyValueStore<Bytes, byte[]>> materialized);

        KTable<K, VR> Join<KO, VO, VR>(KTable<KO, VO> other, Function<V, KO> foreignKeyExtractor, ValueJoiner<V, VO, VR> joiner, Named named, Materialized<K, VR, KeyValueStore<Bytes, byte[]>> materialized);

        KTable<K, VR> LeftJoin<KO, VO, VR>(KTable<KO, VO> other, Function<V, KO> foreignKeyExtractor, ValueJoiner<V, VO, VR> joiner);

        KTable<K, VR> LeftJoin<KO, VO, VR>(KTable<KO, VO> other, Function<V, KO> foreignKeyExtractor, ValueJoiner<V, VO, VR> joiner, Named named);

        KTable<K, VR> LeftJoin<KO, VO, VR>(KTable<KO, VO> other, Function<V, KO> foreignKeyExtractor, ValueJoiner<V, VO, VR> joiner, Materialized<K, VR, KeyValueStore<Bytes, byte[]>> materialized);

        KTable<K, VR> LeftJoin<KO, VO, VR>(KTable<KO, VO> other, Function<V, KO> foreignKeyExtractor, ValueJoiner<V, VO, VR> joiner, Named named, Materialized<K, VR, KeyValueStore<Bytes, byte[]>> materialized);

        string QueryableStoreName { get; }
    }

    public class KTable<K, V> : JVMBridgeBase<KTable<K, V>, IKTable<K, V>>, IKTable<K, V>
    {
        public override string ClassName => "org.apache.kafka.streams.kstream.KTable";

        public string QueryableStoreName => IExecute<string>("queryableStoreName");

        public KTable<K, V> Filter<T, J>(Predicate<T, J> predicate)
            where T : K
            where J : V
        {
            return IExecute<KTable<K, V>>("filter", predicate);
        }

        public KTable<K, V> Filter<T, J>(Predicate<T, J> predicate, Named named)
            where T : K
            where J : V
        {
            return IExecute<KTable<K, V>>("filter", predicate, named);
        }

        public KTable<K, V> Filter<T, J>(Predicate<T, J> predicate, Materialized<K, V, KeyValueStore<Bytes, byte[]>> materialized)
            where T : K
            where J : V
        {
            return IExecute<KTable<K, V>>("filter", predicate, materialized);
        }

        public KTable<K, V> Filter<T, J>(Predicate<T, J> predicate, Named named, Materialized<K, V, KeyValueStore<Bytes, byte[]>> materialized)
            where T : K
            where J : V
        {
            return IExecute<KTable<K, V>>("filter", predicate, named, materialized);
        }

        public KTable<K, V> FilterNot<T, J>(Predicate<T, J> predicate)
            where T : K
            where J : V
        {
            return IExecute<KTable<K, V>>("filterNot", predicate);
        }

        public KTable<K, V> FilterNot<T, J>(Predicate<T, J> predicate, Named named)
            where T : K
            where J : V
        {
            return IExecute<KTable<K, V>>("filterNot", predicate, named);
        }

        public KTable<K, V> FilterNot<T, J>(Predicate<T, J> predicate, Materialized<K, V, KeyValueStore<Bytes, byte[]>> materialized)
            where T : K
            where J : V
        {
            return IExecute<KTable<K, V>>("filterNot", predicate, materialized);
        }

        public KTable<K, V> FilterNot<T, J>(Predicate<T, J> predicate, Named named, Materialized<K, V, KeyValueStore<Bytes, byte[]>> materialized)
            where T : K
            where J : V
        {
            return IExecute<KTable<K, V>>("filterNot", predicate, named, materialized);
        }

        public KGroupedTable<KR, VR> GroupBy<TSuperK, TSuperV, KR, VR>(KeyValueMapper<TSuperK, TSuperV, KeyValue<KR, VR>> selector)
        {
            return IExecute<KGroupedTable<KR, VR>>("groupBy", selector);
        }

        public KGroupedTable<KR, VR> GroupBy<TSuperK, TSuperV, KR, VR>(KeyValueMapper<TSuperK, TSuperV, KeyValue<KR, VR>> selector, Grouped<KR, VR> grouped)
        {
            return IExecute<KGroupedTable<KR, VR>>("groupBy", selector, grouped);
        }

        public KTable<K, VR> Join<TSuperV, TSuperVO, VO, TExtendsVR, VR>(KTable<K, VO> other, ValueJoiner<TSuperV, TSuperVO, TExtendsVR> joiner)
            where TSuperV : V
            where TSuperVO : VO
            where TExtendsVR : VR
        {
            return IExecute<KTable<K, VR>>("join", other, joiner);
        }

        public KTable<K, VR> Join<TSuperV, TSuperVO, VO, TExtendsVR, VR>(KTable<K, VO> other, ValueJoiner<TSuperV, TSuperVO, TExtendsVR> joiner, Named named)
            where TSuperV : V
            where TSuperVO : VO
            where TExtendsVR : VR
        {
            return IExecute<KTable<K, VR>>("join", other, joiner, named);
        }

        public KTable<K, VR> Join<TSuperV, TSuperVO, VO, TExtendsVR, VR>(KTable<K, VO> other, ValueJoiner<TSuperV, TSuperVO, TExtendsVR> joiner, Materialized<K, VR, KeyValueStore<Bytes, byte[]>> materialized)
            where TSuperV : V
            where TSuperVO : VO
            where TExtendsVR : VR
        {
            return IExecute<KTable<K, VR>>("join", other, joiner, materialized);
        }

        public KTable<K, VR> Join<TSuperV, TSuperVO, VO, TExtendsVR, VR>(KTable<K, VO> other, ValueJoiner<TSuperV, TSuperVO, TExtendsVR> joiner, Named named, Materialized<K, VR, KeyValueStore<Bytes, byte[]>> materialized)
            where TSuperV : V
            where TSuperVO : VO
            where TExtendsVR : VR
        {
            return IExecute<KTable<K, VR>>("join", other, joiner, named, materialized);
        }

        public KTable<K, VR> Join<KO, VO, VR>(KTable<KO, VO> other, Function<V, KO> foreignKeyExtractor, ValueJoiner<V, VO, VR> joiner)
        {
            return IExecute<KTable<K, VR>>("join", other, foreignKeyExtractor, joiner);
        }

        public KTable<K, VR> Join<KO, VO, VR>(KTable<KO, VO> other, Function<V, KO> foreignKeyExtractor, ValueJoiner<V, VO, VR> joiner, Named named)
        {
            return IExecute<KTable<K, VR>>("join", other, foreignKeyExtractor, joiner, named);
        }

        public KTable<K, VR> Join<KO, VO, VR>(KTable<KO, VO> other, Function<V, KO> foreignKeyExtractor, ValueJoiner<V, VO, VR> joiner, Materialized<K, VR, KeyValueStore<Bytes, byte[]>> materialized)
        {
            return IExecute<KTable<K, VR>>("join", other, foreignKeyExtractor, joiner, materialized);
        }

        public KTable<K, VR> Join<KO, VO, VR>(KTable<KO, VO> other, Function<V, KO> foreignKeyExtractor, ValueJoiner<V, VO, VR> joiner, Named named, Materialized<K, VR, KeyValueStore<Bytes, byte[]>> materialized)
        {
            return IExecute<KTable<K, VR>>("join", other, foreignKeyExtractor, joiner, named, materialized);
        }

        public KTable<K, VR> LeftJoin<TSuperV, TSuperVO, VO, TExtendsVR, VR>(KTable<K, VO> other, ValueJoiner<TSuperV, TSuperVO, TExtendsVR> joiner)
            where TSuperV : V
            where TSuperVO : VO
            where TExtendsVR : VR
        {
            return IExecute<KTable<K, VR>>("leftJoin", other, joiner);
        }

        public KTable<K, VR> LeftJoin<TSuperV, TSuperVO, VO, TExtendsVR, VR>(KTable<K, VO> other, ValueJoiner<TSuperV, TSuperVO, TExtendsVR> joiner, Named named)
            where TSuperV : V
            where TSuperVO : VO
            where TExtendsVR : VR
        {
            return IExecute<KTable<K, VR>>("leftJoin", other, joiner, named);
        }

        public KTable<K, VR> LeftJoin<TSuperV, TSuperVO, VO, TExtendsVR, VR>(KTable<K, VO> other, ValueJoiner<TSuperV, TSuperVO, TExtendsVR> joiner, Materialized<K, VR, KeyValueStore<Bytes, byte[]>> materialized)
            where TSuperV : V
            where TSuperVO : VO
            where TExtendsVR : VR
        {
            return IExecute<KTable<K, VR>>("leftJoin", other, joiner, materialized);
        }

        public KTable<K, VR> LeftJoin<TSuperV, TSuperVO, VO, TExtendsVR, VR>(KTable<K, VO> other, ValueJoiner<TSuperV, TSuperVO, TExtendsVR> joiner, Named named, Materialized<K, VR, KeyValueStore<Bytes, byte[]>> materialized)
            where TSuperV : V
            where TSuperVO : VO
            where TExtendsVR : VR
        {
            return IExecute<KTable<K, VR>>("leftJoin", other, joiner, named, materialized);
        }

        public KTable<K, VR> LeftJoin<KO, VO, VR>(KTable<KO, VO> other, Function<V, KO> foreignKeyExtractor, ValueJoiner<V, VO, VR> joiner)
        {
            return IExecute<KTable<K, VR>>("leftJoin", other, foreignKeyExtractor, joiner);
        }

        public KTable<K, VR> LeftJoin<KO, VO, VR>(KTable<KO, VO> other, Function<V, KO> foreignKeyExtractor, ValueJoiner<V, VO, VR> joiner, Named named)
        {
            return IExecute<KTable<K, VR>>("leftJoin", other, foreignKeyExtractor, joiner, named);
        }

        public KTable<K, VR> LeftJoin<KO, VO, VR>(KTable<KO, VO> other, Function<V, KO> foreignKeyExtractor, ValueJoiner<V, VO, VR> joiner, Materialized<K, VR, KeyValueStore<Bytes, byte[]>> materialized)
        {
            return IExecute<KTable<K, VR>>("leftJoin", other, foreignKeyExtractor, joiner, materialized);
        }

        public KTable<K, VR> LeftJoin<KO, VO, VR>(KTable<KO, VO> other, Function<V, KO> foreignKeyExtractor, ValueJoiner<V, VO, VR> joiner, Named named, Materialized<K, VR, KeyValueStore<Bytes, byte[]>> materialized)
        {
            return IExecute<KTable<K, VR>>("leftJoin", other, foreignKeyExtractor, joiner, named, materialized);
        }

        public KTable<K, VR> MapValues<VData, VR>(ValueMapper<VData, VR> mapper)
            where VData : V
        {
            return IExecute<KTable<K, VR>>("mapValues", mapper);
        }

        public KTable<K, VR> MapValues<VData, VR>(ValueMapper<VData, VR> mapper, Named named)
            where VData : V
        {
            return IExecute<KTable<K, VR>>("mapValues", mapper, named);
        }

        public KTable<K, VR> MapValues<KData, VData, VR>(ValueMapperWithKey<KData, VData, VR> mapper)
            where KData : K
            where VData : V
        {
            return IExecute<KTable<K, VR>>("mapValues", mapper);
        }

        public KTable<K, VR> MapValues<KData, VData, VR>(ValueMapperWithKey<KData, VData, VR> mapper, Named named)
            where KData : K
            where VData : V
        {
            return IExecute<KTable<K, VR>>("mapValues", mapper, named);
        }

        public KTable<K, VR> MapValues<VData, VR>(ValueMapper<VData, VR> mapper, Materialized<K, VR, KeyValueStore<Bytes, byte[]>> materialized)
            where VData : V
        {
            return IExecute<KTable<K, VR>>("mapValues", mapper, materialized);
        }

        public KTable<K, VR> MapValues<VData, VR>(ValueMapper<VData, VR> mapper, Named named, Materialized<K, VR, KeyValueStore<Bytes, byte[]>> materialized)
            where VData : V
        {
            return IExecute<KTable<K, VR>>("mapValues", mapper, named, materialized);
        }

        public KTable<K, VR> MapValues<KData, VData, VR>(ValueMapperWithKey<KData, VData, VR> mapper, Materialized<K, VR, KeyValueStore<Bytes, byte[]>> materialized)
            where KData : K
            where VData : V
        {
            return IExecute<KTable<K, VR>>("mapValues", mapper, materialized);
        }

        public KTable<K, VR> MapValues<KData, VData, VR>(ValueMapperWithKey<KData, VData, VR> mapper, Named named, Materialized<K, VR, KeyValueStore<Bytes, byte[]>> materialized)
            where KData : K
            where VData : V
        {
            return IExecute<KTable<K, VR>>("mapValues", mapper, named, materialized);
        }

        public KTable<K, VR> OuterJoin<TSuperV, TSuperVO, VO, TExtendsVR, VR>(KTable<K, VO> other, ValueJoiner<TSuperV, TSuperVO, TExtendsVR> joiner)
            where TSuperV : V
            where TSuperVO : VO
            where TExtendsVR : VR
        {
            return IExecute<KTable<K, VR>>("outerJoin", other, joiner);
        }

        public KTable<K, VR> OuterJoin<TSuperV, TSuperVO, VO, TExtendsVR, VR>(KTable<K, VO> other, ValueJoiner<TSuperV, TSuperVO, TExtendsVR> joiner, Named named)
            where TSuperV : V
            where TSuperVO : VO
            where TExtendsVR : VR
        {
            return IExecute<KTable<K, VR>>("outerJoin", other, joiner, named);
        }

        public KTable<K, VR> OuterJoin<TSuperV, TSuperVO, VO, TExtendsVR, VR>(KTable<K, VO> other, ValueJoiner<TSuperV, TSuperVO, TExtendsVR> joiner, Materialized<K, VR, KeyValueStore<Bytes, byte[]>> materialized)
            where TSuperV : V
            where TSuperVO : VO
            where TExtendsVR : VR
        {
            return IExecute<KTable<K, VR>>("outerJoin", other, joiner, materialized);
        }

        public KTable<K, VR> OuterJoin<TSuperV, TSuperVO, VO, TExtendsVR, VR>(KTable<K, VO> other, ValueJoiner<TSuperV, TSuperVO, TExtendsVR> joiner, Named named, Materialized<K, VR, KeyValueStore<Bytes, byte[]>> materialized)
            where TSuperV : V
            where TSuperVO : VO
            where TExtendsVR : VR
        {
            return IExecute<KTable<K, VR>>("outerJoin", other, joiner, named, materialized);
        }

        public KTable<K, V> Suppress<TSuperK>(Suppressed<TSuperK> suppressed) where TSuperK : K
        {
            return IExecute<KTable<K, V>>("suppress", suppressed);
        }

        public KStream<K, V> ToStream()
        {
            return IExecute<KStream<K, V>>("toStream");
        }

        public KStream<K, V> ToStream(Named named)
        {
            return IExecute<KStream<K, V>>("toStream", named);
        }

        public KStream<KR, V> ToStream<TSuperK, TSuperV, TExtendsKR, KR>(KeyValueMapper<TSuperK, TSuperV, TExtendsKR> mapper)
            where TSuperK : K
            where TSuperV : V
            where TExtendsKR : KR
        {
            return IExecute<KStream<KR, V>>("toStream", mapper);
        }

        public KStream<KR, V> ToStream<TSuperK, TSuperV, TExtendsKR, KR>(KeyValueMapper<TSuperK, TSuperV, TExtendsKR> mapper, Named named)
            where TSuperK : K
            where TSuperV : V
            where TExtendsKR : KR
        {
            return IExecute<KStream<KR, V>>("toStream", mapper, named);
        }

        public KTable<K, VR> TransformValues<TSuperK, TSuperV, TExtendsVR, VR>(ValueTransformerWithKeySupplier<TSuperK, TSuperV, TExtendsVR> transformerSupplier, params string[] stateStoreNames)
            where TSuperK : K
            where TSuperV : V
            where TExtendsVR : VR
        {
            return stateStoreNames.Length == 0 ? IExecute<KTable<K, VR>>("transformValues", transformerSupplier)
                                               : IExecute<KTable<K, VR>>("transformValues", transformerSupplier, stateStoreNames);
        }

        public KTable<K, VR> TransformValues<TSuperK, TSuperV, TExtendsVR, VR>(ValueTransformerWithKeySupplier<TSuperK, TSuperV, TExtendsVR> transformerSupplier, Named named, params string[] stateStoreNames)
            where TSuperK : K
            where TSuperV : V
            where TExtendsVR : VR
        {
            return stateStoreNames.Length == 0 ? IExecute<KTable<K, VR>>("transformValues", transformerSupplier, named)
                                               : IExecute<KTable<K, VR>>("transformValues", transformerSupplier, named, stateStoreNames);
        }

        public KTable<K, VR> TransformValues<TSuperK, TSuperV, TExtendsVR, VR>(ValueTransformerWithKeySupplier<TSuperK, TSuperV, TExtendsVR> transformerSupplier, Materialized<K, VR, KeyValueStore<Bytes, byte[]>> materialized, params string[] stateStoreNames)
            where TSuperK : K
            where TSuperV : V
            where TExtendsVR : VR
        {
            return stateStoreNames.Length == 0 ? IExecute<KTable<K, VR>>("transformValues", transformerSupplier, materialized)
                                               : IExecute<KTable<K, VR>>("transformValues", transformerSupplier, materialized, stateStoreNames);
        }

        public KTable<K, VR> TransformValues<TSuperK, TSuperV, TExtendsVR, VR>(ValueTransformerWithKeySupplier<TSuperK, TSuperV, TExtendsVR> transformerSupplier, Materialized<K, VR, KeyValueStore<Bytes, byte[]>> materialized, Named named, params string[] stateStoreNames)
            where TSuperK : K
            where TSuperV : V
            where TExtendsVR : VR
        {
            return stateStoreNames.Length == 0 ? IExecute<KTable<K, VR>>("transformValues", transformerSupplier, materialized, named)
                                               : IExecute<KTable<K, VR>>("transformValues", transformerSupplier, materialized, named, stateStoreNames);
        }
    }
}
