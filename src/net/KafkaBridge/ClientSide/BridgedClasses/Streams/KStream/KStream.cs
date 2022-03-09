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
using Java.Lang;
using MASES.KafkaBridge.Streams.Processor;
using MASES.KafkaBridge.Streams.State;

namespace MASES.KafkaBridge.Streams.KStream
{
    public interface IKStream<K, V> : IJVMBridgeBase
    {
        KStream<K, V> Filter<TKey, TValue>(Predicate<TKey, TValue> predicate)
            where TKey : K
            where TValue : V;

        KStream<K, V> Filter<TKey, TValue>(Predicate<TKey, TValue> predicate, Named named)
            where TKey : K
            where TValue : V;

        KStream<K, V> FilterNot<TKey, TValue>(Predicate<TKey, TValue> predicate)
            where TKey : K
            where TValue : V;

        KStream<K, V> FilterNot<TKey, TValue>(Predicate<TKey, TValue> predicate, Named named)
            where TKey : K
            where TValue : V;

        KStream<KR, V> SelectKey<TKey, TValue, KR, TResult>(KeyValueMapper<TKey, TValue, TResult> mapper)
            where TKey : K
            where TValue : V
            where TResult : KR;

        KStream<KR, V> SelectKey<TKey, TValue, KR, TResult>(KeyValueMapper<TKey, TValue, TResult> mapper, Named named)
            where TKey : K
            where TValue : V
            where TResult : KR;

        KStream<KResult, VResult> Map<TKey, TValue, TKeyValue, KResult, VResult, TKeyValueKey, TKeyValueValue>(KeyValueMapper<TKey, TValue, TKeyValue> mapper)
            where TKey : K
            where TValue : V
            where TKeyValueKey : KResult
            where TKeyValueValue : VResult
            where TKeyValue : KeyValue<TKeyValueKey, TKeyValueValue>;

        KStream<KResult, VResult> Map<TKey, TValue, TKeyValue, KResult, VResult, TKeyValueKey, TKeyValueValue>(KeyValueMapper<TKey, TValue, TKeyValue> mapper, Named named)
            where TKey : K
            where TValue : V
            where TKeyValueKey : KResult
            where TKeyValueValue : VResult
            where TKeyValue : KeyValue<TKeyValueKey, TKeyValueValue>;

        KStream<K, VR> MapValues<TKey, TValue, VR>(ValueMapper<TKey, TValue> mapper)
            where TKey : V
            where TValue : VR;

        KStream<K, VR> MapValues<TKey, TValue, VR>(ValueMapper<TKey, TValue> mapper, Named named)
            where TKey : V
            where TValue : VR;

        KStream<K, VR> MapValues<TKey, TValue, TResult, VR>(ValueMapperWithKey<TKey, TValue, TResult> mapper)
            where TKey : K
            where TValue : V
            where TResult : VR;

        KStream<K, VR> MapValues<TKey, TValue, TResult, VR>(ValueMapperWithKey<TKey, TValue, TResult> mapper, Named named)
            where TKey : K
            where TValue : V
            where TResult : VR;

        KStream<KR, VR> FlatMap<TSuperK, TSuperV, KR, VR>(KeyValueMapper<TSuperK, TSuperV, Iterable<KeyValue<KR, VR>>> mapper)
            where TSuperK : K
            where TSuperV : V;

        KStream<KR, VR> FlatMap<TSuperK, TSuperV, KR, VR>(KeyValueMapper<TSuperK, TSuperV, Iterable<KeyValue<KR, VR>>> mapper, Named named)
            where TSuperK : K
            where TSuperV : V;

        KStream<K, VR> FlatMapValues<TSuperV, VR>(ValueMapper<TSuperV, Iterable<VR>> mapper)
            where TSuperV : V;

        KStream<K, VR> FlatMapValues<TSuperV, VR>(ValueMapper<TSuperV, Iterable<VR>> mapper, Named named)
            where TSuperV : V;

        KStream<K, VR> FlatMapValues<TSuperK, TSuperV, VR>(ValueMapperWithKey<TSuperK, TSuperV, Iterable<VR>> mapper)
            where TSuperK : K
            where TSuperV : V;

        KStream<K, VR> FlatMapValues<TSuperK, TSuperV, VR>(ValueMapperWithKey<TSuperK, TSuperV, Iterable<VR>> mapper, Named named)
            where TSuperK : K
            where TSuperV : V;

        void Print(Printed<K, V> printed);

        void Foreach<TKey, TValue>(ForeachAction<TKey, TValue> action)
            where TKey : K
            where TValue : V;

        void Foreach<TKey, TValue>(ForeachAction<TKey, TValue> action, Named named)
            where TKey : K
            where TValue : V;

        void Peek<TKey, TValue>(ForeachAction<TKey, TValue> action)
            where TKey : K
            where TValue : V;

        void Peek<TKey, TValue>(ForeachAction<TKey, TValue> action, Named named)
            where TKey : K
            where TValue : V;

        BranchedKStream<K, V> Split();

        BranchedKStream<K, V> Split(Named named);

        KStream<K, V> Merge(KStream<K, V> stream);

        KStream<K, V> Merge(KStream<K, V> stream, Named named);

        KStream<K, V> Repartition();

        KStream<K, V> Repartition(Repartitioned<K, V> repartitioned);

        void To(string topic);

        void To(string topic, Produced<K, V> produced);

        void To(TopicNameExtractor<K, V> topicExtractor);

        void To(TopicNameExtractor<K, V> topicExtractor, Produced<K, V> produced);

        KTable<K, V> ToTable();

        KTable<K, V> ToTable(Named named);

        KTable<K, V> ToTable(Materialized<K, V, KeyValueStore<Bytes, byte[]>> materialized);

        KTable<K, V> ToTable(Named named, Materialized<K, V, KeyValueStore<Bytes, byte[]>> materialized);

        KGroupedStream<KR, V> GroupBy<TKey, TValue, KR>(KeyValueMapper<TKey, TValue, KR> keySelector)
            where TKey : K
            where TValue : V;

        KGroupedStream<KR, V> GroupBy<TKey, TValue, KR>(KeyValueMapper<TKey, TValue, KR> keySelector, Grouped<KR, V> grouped)
            where TKey : K
            where TValue : V;

        KGroupedStream<K, V> GroupByKey();

        KGroupedStream<K, V> GroupByKey(Grouped<K, V> grouped);

        KStream<K, VR> Join<TKey, TValue, TSuperVR, VO, VR>(KStream<K, VO> otherStream, ValueJoiner<TKey, TValue, TSuperVR> joiner, JoinWindows windows)
            where TKey : V
            where TValue : VO
            where TSuperVR : VR;

        KStream<K, VR> Join<TKey, TValue, TSuperVO, TSuperVR, VO, VR>(KStream<K, VO> otherStream, ValueJoinerWithKey<TKey, TValue, TSuperVO, TSuperVR> joiner, JoinWindows windows)
            where TKey : K
            where TValue : V
            where TSuperVO : VO
            where TSuperVR : VR;

        KStream<K, VR> Join<TKey, TValue, TSuperVR, VO, VR>(KStream<K, VO> otherStream, ValueJoiner<TKey, TValue, TSuperVR> joiner, JoinWindows windows, StreamJoined<K, V, VO> streamJoined)
            where TKey : V
            where TValue : VO
            where TSuperVR : VR;

        KStream<K, VR> Join<TKey, TValue, TSuperVO, TSuperVR, VO, VR>(KStream<K, VO> otherStream, ValueJoinerWithKey<TKey, TValue, TSuperVO, TSuperVR> joiner, JoinWindows windows, StreamJoined<K, V, VO> streamJoined)
            where TKey : K
            where TValue : V
            where TSuperVO : VO
            where TSuperVR : VR;

        KStream<K, VR> LeftJoin<TKey, TValue, TSuperVR, VO, VR>(KStream<K, VO> otherStream, ValueJoiner<TKey, TValue, TSuperVR> joiner, JoinWindows windows)
            where TKey : V
            where TValue : VO
            where TSuperVR : VR;

        KStream<K, VR> LeftJoin<TKey, TValue, TSuperVO, TSuperVR, VO, VR>(KStream<K, VO> otherStream, ValueJoinerWithKey<TKey, TValue, TSuperVO, TSuperVR> joiner, JoinWindows windows)
            where TKey : K
            where TValue : V
            where TSuperVO : VO
            where TSuperVR : VR;

        KStream<K, VR> LeftJoin<TKey, TValue, TSuperVR, VO, VR>(KStream<K, VO> otherStream, ValueJoiner<TKey, TValue, TSuperVR> joiner, JoinWindows windows, StreamJoined<K, V, VO> streamJoined)
            where TKey : V
            where TValue : VO
            where TSuperVR : VR;

        KStream<K, VR> LeftJoin<TKey, TValue, TSuperVO, TSuperVR, VO, VR>(KStream<K, VO> otherStream, ValueJoinerWithKey<TKey, TValue, TSuperVO, TSuperVR> joiner, JoinWindows windows, StreamJoined<K, V, VO> streamJoined)
            where TKey : K
            where TValue : V
            where TSuperVO : VO
            where TSuperVR : VR;

        KStream<K, VR> OuterJoin<TKey, TValue, TSuperVR, VO, VR>(KStream<K, VO> otherStream, ValueJoiner<TKey, TValue, TSuperVR> joiner, JoinWindows windows)
            where TKey : V
            where TValue : VO
            where TSuperVR : VR;

        KStream<K, VR> OuterJoin<TKey, TValue, TSuperVO, TSuperVR, VO, VR>(KStream<K, VO> otherStream, ValueJoinerWithKey<TKey, TValue, TSuperVO, TSuperVR> joiner, JoinWindows windows)
            where TKey : K
            where TValue : V
            where TSuperVO : VO
            where TSuperVR : VR;

        KStream<K, VR> OuterJoin<TKey, TValue, TSuperVR, VO, VR>(KStream<K, VO> otherStream, ValueJoiner<TKey, TValue, TSuperVR> joiner, JoinWindows windows, StreamJoined<K, V, VO> streamJoined)
            where TKey : V
            where TValue : VO
            where TSuperVR : VR;

        KStream<K, VR> OuterJoin<TKey, TValue, TSuperVO, TSuperVR, VO, VR>(KStream<K, VO> otherStream, ValueJoinerWithKey<TKey, TValue, TSuperVO, TSuperVR> joiner, JoinWindows windows, StreamJoined<K, V, VO> streamJoined)
            where TKey : K
            where TValue : V
            where TSuperVO : VO
            where TSuperVR : VR;

        KStream<K, VR> Join<TKey, TValue, TSuperVR, VT, VR>(KTable<K, VT> table, ValueJoiner<TKey, TValue, TSuperVR> joiner)
            where TKey : V
            where TValue : VT
            where TSuperVR : VR;

        KStream<K, VR> Join<TKey, TValue, TSuperVT, TSuperVR, VT, VR>(KTable<K, VT> table, ValueJoinerWithKey<TKey, TValue, TSuperVT, TSuperVR> joiner)
            where TKey : V
            where TValue : VT
            where TSuperVT : VT
            where TSuperVR : VR;

        KStream<K, VR> Join<TKey, TValue, TSuperVR, VT, VR>(KTable<K, VT> table, ValueJoiner<TKey, TValue, TSuperVR> joiner, Joined<K, V, VT> joined)
            where TKey : V
            where TValue : VT
            where TSuperVR : VR;

        KStream<K, VR> Join<TKey, TValue, TSuperVT, TSuperVR, VT, VR>(KTable<K, VT> table, ValueJoinerWithKey<TKey, TValue, TSuperVT, TSuperVR> joiner, Joined<K, V, VT> joined)
            where TKey : V
            where TValue : VT
            where TSuperVT : VT
            where TSuperVR : VR;

        KStream<K, VR> LeftJoin<TKey, TValue, TSuperVR, VT, VR>(KTable<K, VT> table, ValueJoiner<TKey, TValue, TSuperVR> joiner)
            where TKey : V
            where TValue : VT
            where TSuperVR : VR;

        KStream<K, VR> LeftJoin<TKey, TValue, TSuperVT, TSuperVR, VT, VR>(KTable<K, VT> table, ValueJoinerWithKey<TKey, TValue, TSuperVT, TSuperVR> joiner)
            where TKey : V
            where TValue : VT
            where TSuperVT : VT
            where TSuperVR : VR;

        KStream<K, VR> LeftJoin<TKey, TValue, TSuperVR, VT, VR>(KTable<K, VT> table, ValueJoiner<TKey, TValue, TSuperVR> joiner, Joined<K, V, VT> joined)
            where TKey : V
            where TValue : VT
            where TSuperVR : VR;

        KStream<K, VR> LeftJoin<TKey, TValue, TSuperVT, TSuperVR, VT, VR>(KTable<K, VT> table, ValueJoinerWithKey<TKey, TValue, TSuperVT, TSuperVR> joiner, Joined<K, V, VT> joined)
            where TKey : V
            where TValue : VT
            where TSuperVT : VT
            where TSuperVR : VR;


        KStream<K, RV> Join<TKey, TValue, TSuperGK, TSuperGV, TSuperRV, GK, GV, RV>(GlobalKTable<GK, GV> globalTable,
                                                                                    KeyValueMapper<TKey, TValue, TSuperGK> keySelector,
                                                                                    ValueJoiner<TValue, TSuperGV, TSuperRV> joiner)
            where TKey : K
            where TValue : V
             where TSuperGV : GV
            where TSuperGK : GK
            where TSuperRV : RV;

        KStream<K, RV> Join<TKey, TValue, TSuperGK, TSuperGV, TSuperRV, GK, GV, RV>(GlobalKTable<GK, GV> globalTable,
                                                                                    KeyValueMapper<TKey, TValue, TSuperGK> keySelector,
                                                                                    ValueJoinerWithKey<TKey, TValue, TSuperGV, TSuperRV> joiner)
            where TKey : K
            where TValue : V
             where TSuperGV : GV
            where TSuperGK : GK
            where TSuperRV : RV;

        KStream<K, RV> Join<TKey, TValue, TSuperGK, TSuperGV, TSuperRV, GK, GV, RV>(GlobalKTable<GK, GV> globalTable,
                                                                                    KeyValueMapper<TKey, TValue, TSuperGK> keySelector,
                                                                                    ValueJoiner<TValue, TSuperGV, TSuperRV> joiner,
                                                                                    Named named)
            where TKey : K
            where TValue : V
             where TSuperGV : GV
            where TSuperGK : GK
            where TSuperRV : RV;

        KStream<K, RV> Join<TKey, TValue, TSuperGK, TSuperGV, TSuperRV, GK, GV, RV>(GlobalKTable<GK, GV> globalTable,
                                                                                    KeyValueMapper<TKey, TValue, TSuperGK> keySelector,
                                                                                    ValueJoinerWithKey<TKey, TValue, TSuperGV, TSuperRV> joiner,
                                                                                    Named named)
            where TKey : K
            where TValue : V
             where TSuperGV : GV
            where TSuperGK : GK
            where TSuperRV : RV;

        KStream<K, RV> LeftJoin<TKey, TValue, TSuperGK, TSuperGV, TSuperRV, GK, GV, RV>(GlobalKTable<GK, GV> globalTable,
                                                                                        KeyValueMapper<TKey, TValue, TSuperGK> keySelector,
                                                                                        ValueJoiner<TValue, TSuperGV, TSuperRV> joiner)
            where TKey : K
            where TValue : V
             where TSuperGV : GV
            where TSuperGK : GK
            where TSuperRV : RV;

        KStream<K, RV> LeftJoin<TKey, TValue, TSuperGK, TSuperGV, TSuperRV, GK, GV, RV>(GlobalKTable<GK, GV> globalTable,
                                                                                        KeyValueMapper<TKey, TValue, TSuperGK> keySelector,
                                                                                        ValueJoinerWithKey<TKey, TValue, TSuperGV, TSuperRV> joiner)
            where TKey : K
            where TValue : V
             where TSuperGV : GV
            where TSuperGK : GK
            where TSuperRV : RV;

        KStream<K, RV> LeftJoin<TKey, TValue, TSuperGK, TSuperGV, TSuperRV, GK, GV, RV>(GlobalKTable<GK, GV> globalTable,
                                                                                    KeyValueMapper<TKey, TValue, TSuperGK> keySelector,
                                                                                    ValueJoiner<TValue, TSuperGV, TSuperRV> joiner,
                                                                                    Named named)
            where TKey : K
            where TValue : V
             where TSuperGV : GV
            where TSuperGK : GK
            where TSuperRV : RV;

        KStream<K, RV> LeftJoin<TKey, TValue, TSuperGK, TSuperGV, TSuperRV, GK, GV, RV>(GlobalKTable<GK, GV> globalTable,
                                                                                    KeyValueMapper<TKey, TValue, TSuperGK> keySelector,
                                                                                    ValueJoinerWithKey<TKey, TValue, TSuperGV, TSuperRV> joiner,
                                                                                    Named named)
            where TKey : K
            where TValue : V
             where TSuperGV : GV
            where TSuperGK : GK
            where TSuperRV : RV;

        KStream<K1, V1> Transform<TSuperK, TSuperV, K1, V1>(TransformerSupplier<TSuperK, TSuperV, KeyValue<K1, V1>> transformerSupplier, params string[] stateStoreNames)
            where TSuperK : K
            where TSuperV : V;

        KStream<K1, V1> Transform<TSuperK, TSuperV, K1, V1>(TransformerSupplier<TSuperK, TSuperV, KeyValue<K1, V1>> transformerSupplier, Named named, params string[] stateStoreNames)
            where TSuperK : K
            where TSuperV : V;

        KStream<K1, V1> FlatTransform<TSuperK, TSuperV, K1, V1>(TransformerSupplier<TSuperK, TSuperV, Iterable<KeyValue<K1, V1>>> transformerSupplier, params string[] stateStoreNames)
            where TSuperK : K
            where TSuperV : V;

        KStream<K1, V1> FlatTransform<TSuperK, TSuperV, K1, V1>(TransformerSupplier<TSuperK, TSuperV, Iterable<KeyValue<K1, V1>>> transformerSupplier, Named named, params string[] stateStoreNames)
            where TSuperK : K
            where TSuperV : V;

        KStream<K, VR> TransformValues<TSuperV, TSuperVR, VR>(ValueTransformerSupplier<TSuperV, TSuperVR> valueTransformerSupplier, params string[] stateStoreNames)
            where TSuperV : V
            where TSuperVR : VR;

        KStream<K, VR> TransformValues<TSuperV, TSuperVR, VR>(ValueTransformerSupplier<TSuperV, TSuperVR> valueTransformerSupplier, Named named, params string[] stateStoreNames)
            where TSuperV : V
            where TSuperVR : VR;

        KStream<K, VR> TransformValues<TSuperK, TSuperV, TSuperVR, VR>(ValueTransformerWithKeySupplier<TSuperK, TSuperV, TSuperVR> valueTransformerSupplier, params string[] stateStoreNames)
            where TSuperK : K
            where TSuperV : V
            where TSuperVR : VR;

        KStream<K, VR> TransformValues<TSuperK, TSuperV, TSuperVR, VR>(ValueTransformerWithKeySupplier<TSuperK, TSuperV, TSuperVR> valueTransformerSupplier, Named named, params string[] stateStoreNames)
            where TSuperK : K
            where TSuperV : V
            where TSuperVR : VR;

        KStream<K, VR> FlatTransformValues<TSuperV, VR>(ValueTransformerSupplier<TSuperV, Iterable<VR>> valueTransformerSupplier, params string[] stateStoreNames)
            where TSuperV : V;

        KStream<K, VR> FlatTransformValues<TSuperV, VR>(ValueTransformerSupplier<TSuperV, Iterable<VR>> valueTransformerSupplier, Named named, params string[] stateStoreNames)
            where TSuperV : V;

        KStream<K, VR> FlatTransformValues<TSuperK, TSuperV, VR>(ValueTransformerWithKeySupplier<TSuperK, TSuperV, Iterable<VR>> valueTransformerSupplier, params string[] stateStoreNames)
            where TSuperK : K
            where TSuperV : V;

        KStream<K, VR> FlatTransformValues<TSuperK, TSuperV, VR>(ValueTransformerWithKeySupplier<TSuperK, TSuperV, Iterable<VR>> valueTransformerSupplier, Named named, params string[] stateStoreNames)
            where TSuperK : K
            where TSuperV : V;

        void Process<TSuperK, TSuperV>(Streams.Processor.Api.ProcessorSupplier<TSuperK, TSuperV, Void, Void> processorSupplier, params string[] stateStoreNames);

        void Process<TSuperK, TSuperV>(Streams.Processor.Api.ProcessorSupplier<TSuperK, TSuperV, Void, Void> processorSupplier, Named named, params string[] stateStoreNames);
    }

    public class KStream<K, V> : JVMBridgeBase<KStream<K, V>, IKStream<K, V>>, IKStream<K, V>
    {
        public override string ClassName => "org.apache.kafka.streams.kstream.KStream";

        public KStream<K, V> Filter<TKey, TValue>(Predicate<TKey, TValue> predicate)
            where TKey : K
            where TValue : V
        {
            return IExecute<KStream<K, V>>("filter", predicate);
        }

        public KStream<K, V> Filter<TKey, TValue>(Predicate<TKey, TValue> predicate, Named named)
            where TKey : K
            where TValue : V
        {
            return IExecute<KStream<K, V>>("filter", predicate, named);
        }

        public KStream<K, V> FilterNot<TKey, TValue>(Predicate<TKey, TValue> predicate)
            where TKey : K
            where TValue : V
        {
            return IExecute<KStream<K, V>>("filterNot", predicate);
        }

        public KStream<K, V> FilterNot<TKey, TValue>(Predicate<TKey, TValue> predicate, Named named)
            where TKey : K
            where TValue : V
        {
            return IExecute<KStream<K, V>>("filterNot", predicate, named);
        }

        public KStream<KR, VR> FlatMap<TSuperK, TSuperV, KR, VR>(KeyValueMapper<TSuperK, TSuperV, Iterable<KeyValue<KR, VR>>> mapper)
            where TSuperK : K
            where TSuperV : V
        {
            return IExecute<KStream<KR, VR>>("flatMap", mapper);
        }

        public KStream<KR, VR> FlatMap<TSuperK, TSuperV, KR, VR>(KeyValueMapper<TSuperK, TSuperV, Iterable<KeyValue<KR, VR>>> mapper, Named named)
            where TSuperK : K
            where TSuperV : V
        {
            return IExecute<KStream<KR, VR>>("flatMap", mapper, named);
        }

        public KStream<K, VR> FlatMapValues<TSuperV, VR>(ValueMapper<TSuperV, Iterable<VR>> mapper) where TSuperV : V
        {
            return IExecute<KStream<K, VR>>("flatMapValues", mapper);
        }

        public KStream<K, VR> FlatMapValues<TSuperV, VR>(ValueMapper<TSuperV, Iterable<VR>> mapper, Named named) where TSuperV : V
        {
            return IExecute<KStream<K, VR>>("flatMapValues", mapper, named);
        }

        public KStream<K, VR> FlatMapValues<TSuperK, TSuperV, VR>(ValueMapperWithKey<TSuperK, TSuperV, Iterable<VR>> mapper)
            where TSuperK : K
            where TSuperV : V
        {
            return IExecute<KStream<K, VR>>("flatMapValues", mapper);
        }

        public KStream<K, VR> FlatMapValues<TSuperK, TSuperV, VR>(ValueMapperWithKey<TSuperK, TSuperV, Iterable<VR>> mapper, Named named)
            where TSuperK : K
            where TSuperV : V
        {
            return IExecute<KStream<K, VR>>("flatMapValues", mapper, named);
        }

        public KStream<K1, V1> FlatTransform<TSuperK, TSuperV, K1, V1>(TransformerSupplier<TSuperK, TSuperV, Iterable<KeyValue<K1, V1>>> transformerSupplier, params string[] stateStoreNames)
            where TSuperK : K
            where TSuperV : V
        {
            return IExecute<KStream<K1, V1>>("flatTransform", transformerSupplier, stateStoreNames);
        }

        public KStream<K1, V1> FlatTransform<TSuperK, TSuperV, K1, V1>(TransformerSupplier<TSuperK, TSuperV, Iterable<KeyValue<K1, V1>>> transformerSupplier, Named named, params string[] stateStoreNames)
            where TSuperK : K
            where TSuperV : V
        {
            return IExecute<KStream<K1, V1>>("flatTransform", transformerSupplier, named, stateStoreNames);
        }

        public KStream<K, VR> FlatTransformValues<TSuperV, VR>(ValueTransformerSupplier<TSuperV, Iterable<VR>> valueTransformerSupplier, params string[] stateStoreNames) where TSuperV : V
        {
            return IExecute<KStream<K, VR>>("flatTransformValues", valueTransformerSupplier, stateStoreNames);
        }

        public KStream<K, VR> FlatTransformValues<TSuperV, VR>(ValueTransformerSupplier<TSuperV, Iterable<VR>> valueTransformerSupplier, Named named, params string[] stateStoreNames) where TSuperV : V
        {
            return IExecute<KStream<K, VR>>("flatTransformValues", valueTransformerSupplier, named, stateStoreNames);
        }

        public KStream<K, VR> FlatTransformValues<TSuperK, TSuperV, VR>(ValueTransformerWithKeySupplier<TSuperK, TSuperV, Iterable<VR>> valueTransformerSupplier, params string[] stateStoreNames)
            where TSuperK : K
            where TSuperV : V
        {
            return IExecute<KStream<K, VR>>("flatTransformValues", valueTransformerSupplier, stateStoreNames);
        }

        public KStream<K, VR> FlatTransformValues<TSuperK, TSuperV, VR>(ValueTransformerWithKeySupplier<TSuperK, TSuperV, Iterable<VR>> valueTransformerSupplier, Named named, params string[] stateStoreNames)
            where TSuperK : K
            where TSuperV : V
        {
            return IExecute<KStream<K, VR>>("flatTransformValues", valueTransformerSupplier, named, stateStoreNames);
        }

        public void Foreach<TKey, TValue>(ForeachAction<TKey, TValue> action)
            where TKey : K
            where TValue : V
        {
            IExecute("foreach", action);
        }

        public void Foreach<TKey, TValue>(ForeachAction<TKey, TValue> action, Named named)
            where TKey : K
            where TValue : V
        {
            IExecute("foreach", action, named);
        }

        public KGroupedStream<KR, V> GroupBy<TKey, TValue, KR>(KeyValueMapper<TKey, TValue, KR> keySelector)
            where TKey : K
            where TValue : V
        {
            return IExecute<KGroupedStream<KR, V>>("groupBy", keySelector);
        }

        public KGroupedStream<KR, V> GroupBy<TKey, TValue, KR>(KeyValueMapper<TKey, TValue, KR> keySelector, Grouped<KR, V> grouped)
            where TKey : K
            where TValue : V
        {
            return IExecute<KGroupedStream<KR, V>>("groupBy", keySelector, grouped);
        }

        public KGroupedStream<K, V> GroupByKey()
        {
            return IExecute<KGroupedStream<K, V>>("groupByKey");
        }

        public KGroupedStream<K, V> GroupByKey(Grouped<K, V> grouped)
        {
            return IExecute<KGroupedStream<K, V>>("groupByKey", grouped);
        }

        public KStream<K, VR> Join<TKey, TValue, TSuperVR, VO, VR>(KStream<K, VO> otherStream, ValueJoiner<TKey, TValue, TSuperVR> joiner, JoinWindows windows)
            where TKey : V
            where TValue : VO
            where TSuperVR : VR
        {
            return IExecute<KStream<K, VR>>("join", otherStream, joiner, windows);
        }

        public KStream<K, VR> Join<TKey, TValue, TSuperVO, TSuperVR, VO, VR>(KStream<K, VO> otherStream, ValueJoinerWithKey<TKey, TValue, TSuperVO, TSuperVR> joiner, JoinWindows windows)
            where TKey : K
            where TValue : V
            where TSuperVO : VO
            where TSuperVR : VR
        {
            return IExecute<KStream<K, VR>>("join", otherStream, joiner, windows);
        }

        public KStream<K, VR> Join<TKey, TValue, TSuperVR, VO, VR>(KStream<K, VO> otherStream, ValueJoiner<TKey, TValue, TSuperVR> joiner, JoinWindows windows, StreamJoined<K, V, VO> streamJoined)
            where TKey : V
            where TValue : VO
            where TSuperVR : VR
        {
            return IExecute<KStream<K, VR>>("join", otherStream, joiner, windows, streamJoined);
        }

        public KStream<K, VR> Join<TKey, TValue, TSuperVO, TSuperVR, VO, VR>(KStream<K, VO> otherStream, ValueJoinerWithKey<TKey, TValue, TSuperVO, TSuperVR> joiner, JoinWindows windows, StreamJoined<K, V, VO> streamJoined)
            where TKey : K
            where TValue : V
            where TSuperVO : VO
            where TSuperVR : VR
        {
            return IExecute<KStream<K, VR>>("join", otherStream, joiner, windows, streamJoined);
        }

        public KStream<K, VR> Join<TKey, TValue, TSuperVR, VT, VR>(KTable<K, VT> table, ValueJoiner<TKey, TValue, TSuperVR> joiner)
            where TKey : V
            where TValue : VT
            where TSuperVR : VR
        {
            return IExecute<KStream<K, VR>>("join", table, joiner);
        }

        public KStream<K, VR> Join<TKey, TValue, TSuperVT, TSuperVR, VT, VR>(KTable<K, VT> table, ValueJoinerWithKey<TKey, TValue, TSuperVT, TSuperVR> joiner)
            where TKey : V
            where TValue : VT
            where TSuperVT : VT
            where TSuperVR : VR
        {
            return IExecute<KStream<K, VR>>("join", table, joiner);
        }

        public KStream<K, VR> Join<TKey, TValue, TSuperVR, VT, VR>(KTable<K, VT> table, ValueJoiner<TKey, TValue, TSuperVR> joiner, Joined<K, V, VT> joined)
            where TKey : V
            where TValue : VT
            where TSuperVR : VR
        {
            return IExecute<KStream<K, VR>>("join", table, joiner, joined);
        }

        public KStream<K, VR> Join<TKey, TValue, TSuperVT, TSuperVR, VT, VR>(KTable<K, VT> table, ValueJoinerWithKey<TKey, TValue, TSuperVT, TSuperVR> joiner, Joined<K, V, VT> joined)
            where TKey : V
            where TValue : VT
            where TSuperVT : VT
            where TSuperVR : VR
        {
            return IExecute<KStream<K, VR>>("join", table, joiner, joined);
        }

        public KStream<K, RV> Join<TKey, TValue, TSuperGK, TSuperGV, TSuperRV, GK, GV, RV>(GlobalKTable<GK, GV> globalTable, KeyValueMapper<TKey, TValue, TSuperGK> keySelector, ValueJoiner<TValue, TSuperGV, TSuperRV> joiner)
            where TKey : K
            where TValue : V
            where TSuperGK : GK
            where TSuperGV : GV
            where TSuperRV : RV
        {
            return IExecute<KStream<K, RV>>("join", globalTable, keySelector, joiner);
        }

        public KStream<K, RV> Join<TKey, TValue, TSuperGK, TSuperGV, TSuperRV, GK, GV, RV>(GlobalKTable<GK, GV> globalTable, KeyValueMapper<TKey, TValue, TSuperGK> keySelector, ValueJoinerWithKey<TKey, TValue, TSuperGV, TSuperRV> joiner)
            where TKey : K
            where TValue : V
            where TSuperGK : GK
            where TSuperGV : GV
            where TSuperRV : RV
        {
            return IExecute<KStream<K, RV>>("join", globalTable, keySelector, joiner);
        }

        public KStream<K, RV> Join<TKey, TValue, TSuperGK, TSuperGV, TSuperRV, GK, GV, RV>(GlobalKTable<GK, GV> globalTable, KeyValueMapper<TKey, TValue, TSuperGK> keySelector, ValueJoiner<TValue, TSuperGV, TSuperRV> joiner, Named named)
            where TKey : K
            where TValue : V
            where TSuperGK : GK
            where TSuperGV : GV
            where TSuperRV : RV
        {
            return IExecute<KStream<K, RV>>("join", globalTable, keySelector, joiner, named);
        }

        public KStream<K, RV> Join<TKey, TValue, TSuperGK, TSuperGV, TSuperRV, GK, GV, RV>(GlobalKTable<GK, GV> globalTable, KeyValueMapper<TKey, TValue, TSuperGK> keySelector, ValueJoinerWithKey<TKey, TValue, TSuperGV, TSuperRV> joiner, Named named)
            where TKey : K
            where TValue : V
            where TSuperGK : GK
            where TSuperGV : GV
            where TSuperRV : RV
        {
            return IExecute<KStream<K, RV>>("join", globalTable, keySelector, joiner, named);
        }

        public KStream<K, VR> LeftJoin<TKey, TValue, TSuperVR, VO, VR>(KStream<K, VO> otherStream, ValueJoiner<TKey, TValue, TSuperVR> joiner, JoinWindows windows)
            where TKey : V
            where TValue : VO
            where TSuperVR : VR
        {
            return IExecute<KStream<K, VR>>("leftJoin", otherStream, joiner, windows);
        }

        public KStream<K, VR> LeftJoin<TKey, TValue, TSuperVO, TSuperVR, VO, VR>(KStream<K, VO> otherStream, ValueJoinerWithKey<TKey, TValue, TSuperVO, TSuperVR> joiner, JoinWindows windows)
            where TKey : K
            where TValue : V
            where TSuperVO : VO
            where TSuperVR : VR
        {
            return IExecute<KStream<K, VR>>("leftJoin", otherStream, joiner, windows);
        }

        public KStream<K, VR> LeftJoin<TKey, TValue, TSuperVR, VO, VR>(KStream<K, VO> otherStream, ValueJoiner<TKey, TValue, TSuperVR> joiner, JoinWindows windows, StreamJoined<K, V, VO> streamJoined)
            where TKey : V
            where TValue : VO
            where TSuperVR : VR
        {
            return IExecute<KStream<K, VR>>("leftJoin", otherStream, joiner, windows, streamJoined);
        }

        public KStream<K, VR> LeftJoin<TKey, TValue, TSuperVO, TSuperVR, VO, VR>(KStream<K, VO> otherStream, ValueJoinerWithKey<TKey, TValue, TSuperVO, TSuperVR> joiner, JoinWindows windows, StreamJoined<K, V, VO> streamJoined)
            where TKey : K
            where TValue : V
            where TSuperVO : VO
            where TSuperVR : VR
        {
            return IExecute<KStream<K, VR>>("leftJoin", otherStream, joiner, windows, streamJoined);
        }

        public KStream<K, VR> LeftJoin<TKey, TValue, TSuperVR, VT, VR>(KTable<K, VT> table, ValueJoiner<TKey, TValue, TSuperVR> joiner)
            where TKey : V
            where TValue : VT
            where TSuperVR : VR
        {
            return IExecute<KStream<K, VR>>("leftJoin", table, joiner);
        }

        public KStream<K, VR> LeftJoin<TKey, TValue, TSuperVT, TSuperVR, VT, VR>(KTable<K, VT> table, ValueJoinerWithKey<TKey, TValue, TSuperVT, TSuperVR> joiner)
            where TKey : V
            where TValue : VT
            where TSuperVT : VT
            where TSuperVR : VR
        {
            return IExecute<KStream<K, VR>>("leftJoin", table, joiner);
        }

        public KStream<K, VR> LeftJoin<TKey, TValue, TSuperVR, VT, VR>(KTable<K, VT> table, ValueJoiner<TKey, TValue, TSuperVR> joiner, Joined<K, V, VT> joined)
            where TKey : V
            where TValue : VT
            where TSuperVR : VR
        {
            return IExecute<KStream<K, VR>>("leftJoin", table, joiner, joined);
        }

        public KStream<K, VR> LeftJoin<TKey, TValue, TSuperVT, TSuperVR, VT, VR>(KTable<K, VT> table, ValueJoinerWithKey<TKey, TValue, TSuperVT, TSuperVR> joiner, Joined<K, V, VT> joined)
            where TKey : V
            where TValue : VT
            where TSuperVT : VT
            where TSuperVR : VR
        {
            return IExecute<KStream<K, VR>>("leftJoin", table, joiner, joined);
        }

        public KStream<K, RV> LeftJoin<TKey, TValue, TSuperGK, TSuperGV, TSuperRV, GK, GV, RV>(GlobalKTable<GK, GV> globalTable, KeyValueMapper<TKey, TValue, TSuperGK> keySelector, ValueJoiner<TValue, TSuperGV, TSuperRV> joiner)
            where TKey : K
            where TValue : V
            where TSuperGK : GK
            where TSuperGV : GV
            where TSuperRV : RV
        {
            return IExecute<KStream<K, RV>>("leftJoin", globalTable, keySelector, joiner);
        }

        public KStream<K, RV> LeftJoin<TKey, TValue, TSuperGK, TSuperGV, TSuperRV, GK, GV, RV>(GlobalKTable<GK, GV> globalTable, KeyValueMapper<TKey, TValue, TSuperGK> keySelector, ValueJoinerWithKey<TKey, TValue, TSuperGV, TSuperRV> joiner)
            where TKey : K
            where TValue : V
            where TSuperGK : GK
            where TSuperGV : GV
            where TSuperRV : RV
        {
            return IExecute<KStream<K, RV>>("leftJoin", globalTable, keySelector, joiner);
        }

        public KStream<K, RV> LeftJoin<TKey, TValue, TSuperGK, TSuperGV, TSuperRV, GK, GV, RV>(GlobalKTable<GK, GV> globalTable, KeyValueMapper<TKey, TValue, TSuperGK> keySelector, ValueJoiner<TValue, TSuperGV, TSuperRV> joiner, Named named)
            where TKey : K
            where TValue : V
            where TSuperGK : GK
            where TSuperGV : GV
            where TSuperRV : RV
        {
            return IExecute<KStream<K, RV>>("leftJoin", globalTable, keySelector, joiner, named);
        }

        public KStream<K, RV> LeftJoin<TKey, TValue, TSuperGK, TSuperGV, TSuperRV, GK, GV, RV>(GlobalKTable<GK, GV> globalTable, KeyValueMapper<TKey, TValue, TSuperGK> keySelector, ValueJoinerWithKey<TKey, TValue, TSuperGV, TSuperRV> joiner, Named named)
            where TKey : K
            where TValue : V
            where TSuperGK : GK
            where TSuperGV : GV
            where TSuperRV : RV
        {
            return IExecute<KStream<K, RV>>("leftJoin", globalTable, keySelector, joiner, named);
        }

        public KStream<KResult, VResult> Map<TKey, TValue, TKeyValue, KResult, VResult, TKeyValueKey, TKeyValueValue>(KeyValueMapper<TKey, TValue, TKeyValue> mapper)
            where TKey : K
            where TValue : V
            where TKeyValue : KeyValue<TKeyValueKey, TKeyValueValue>
            where TKeyValueKey : KResult
            where TKeyValueValue : VResult
        {
            return IExecute<KStream<KResult, VResult>>("map", mapper);
        }

        public KStream<KResult, VResult> Map<TKey, TValue, TKeyValue, KResult, VResult, TKeyValueKey, TKeyValueValue>(KeyValueMapper<TKey, TValue, TKeyValue> mapper, Named named)
            where TKey : K
            where TValue : V
            where TKeyValue : KeyValue<TKeyValueKey, TKeyValueValue>
            where TKeyValueKey : KResult
            where TKeyValueValue : VResult
        {
            return IExecute<KStream<KResult, VResult>>("map", mapper, named);
        }

        public KStream<K, VR> MapValues<TKey, TValue, VR>(ValueMapper<TKey, TValue> mapper)
            where TKey : V
            where TValue : VR
        {
            return IExecute<KStream<K, VR>>("mapValues", mapper);
        }

        public KStream<K, VR> MapValues<TKey, TValue, VR>(ValueMapper<TKey, TValue> mapper, Named named)
            where TKey : V
            where TValue : VR
        {
            return IExecute<KStream<K, VR>>("mapValues", mapper, named);
        }

        public KStream<K, VR> MapValues<TKey, TValue, TResult, VR>(ValueMapperWithKey<TKey, TValue, TResult> mapper)
            where TKey : K
            where TValue : V
            where TResult : VR
        {
            return IExecute<KStream<K, VR>>("mapValues", mapper);
        }

        public KStream<K, VR> MapValues<TKey, TValue, TResult, VR>(ValueMapperWithKey<TKey, TValue, TResult> mapper, Named named)
            where TKey : K
            where TValue : V
            where TResult : VR
        {
            return IExecute<KStream<K, VR>>("mapValues", mapper, named);
        }

        public KStream<K, V> Merge(KStream<K, V> stream)
        {
            return IExecute<KStream<K, V>>("merge", stream);
        }

        public KStream<K, V> Merge(KStream<K, V> stream, Named named)
        {
            return IExecute<KStream<K, V>>("merge", stream, named);
        }

        public KStream<K, VR> OuterJoin<TKey, TValue, TSuperVR, VO, VR>(KStream<K, VO> otherStream, ValueJoiner<TKey, TValue, TSuperVR> joiner, JoinWindows windows)
            where TKey : V
            where TValue : VO
            where TSuperVR : VR
        {
            return IExecute<KStream<K, VR>>("outerJoin", otherStream, joiner, windows);
        }

        public KStream<K, VR> OuterJoin<TKey, TValue, TSuperVO, TSuperVR, VO, VR>(KStream<K, VO> otherStream, ValueJoinerWithKey<TKey, TValue, TSuperVO, TSuperVR> joiner, JoinWindows windows)
            where TKey : K
            where TValue : V
            where TSuperVO : VO
            where TSuperVR : VR
        {
            return IExecute<KStream<K, VR>>("outerJoin", otherStream, joiner, windows);
        }

        public KStream<K, VR> OuterJoin<TKey, TValue, TSuperVR, VO, VR>(KStream<K, VO> otherStream, ValueJoiner<TKey, TValue, TSuperVR> joiner, JoinWindows windows, StreamJoined<K, V, VO> streamJoined)
            where TKey : V
            where TValue : VO
            where TSuperVR : VR
        {
            return IExecute<KStream<K, VR>>("outerJoin", otherStream, joiner, windows, streamJoined);
        }

        public KStream<K, VR> OuterJoin<TKey, TValue, TSuperVO, TSuperVR, VO, VR>(KStream<K, VO> otherStream, ValueJoinerWithKey<TKey, TValue, TSuperVO, TSuperVR> joiner, JoinWindows windows, StreamJoined<K, V, VO> streamJoined)
            where TKey : K
            where TValue : V
            where TSuperVO : VO
            where TSuperVR : VR
        {
            return IExecute<KStream<K, VR>>("outerJoin", otherStream, joiner, windows, streamJoined);
        }

        public void Peek<TKey, TValue>(ForeachAction<TKey, TValue> action)
            where TKey : K
            where TValue : V
        {
            IExecute("peek", action);
        }

        public void Peek<TKey, TValue>(ForeachAction<TKey, TValue> action, Named named)
            where TKey : K
            where TValue : V
        {
            IExecute("peek", action, named);
        }

        public void Print(Printed<K, V> printed)
        {
            IExecute("print", printed);
        }

        public void Process<TSuperK, TSuperV>(Streams.Processor.Api.ProcessorSupplier<TSuperK, TSuperV, Void, Void> processorSupplier, params string[] stateStoreNames)
        {
            IExecute("process", processorSupplier, stateStoreNames);
        }

        public void Process<TSuperK, TSuperV>(Streams.Processor.Api.ProcessorSupplier<TSuperK, TSuperV, Void, Void> processorSupplier, Named named, params string[] stateStoreNames)
        {
            IExecute("process", processorSupplier, named, stateStoreNames);
        }

        public KStream<K, V> Repartition()
        {
            return IExecute<KStream<K, V>>("repartition");
        }

        public KStream<K, V> Repartition(Repartitioned<K, V> repartitioned)
        {
            return IExecute<KStream<K, V>>("repartition", repartitioned);
        }

        public KStream<KR, V> SelectKey<TKey, TValue, KR, TResult>(KeyValueMapper<TKey, TValue, TResult> mapper)
            where TKey : K
            where TValue : V
            where TResult : KR
        {
            return IExecute<KStream<KR, V>>("selectKey", mapper);
        }

        public KStream<KR, V> SelectKey<TKey, TValue, KR, TResult>(KeyValueMapper<TKey, TValue, TResult> mapper, Named named)
            where TKey : K
            where TValue : V
            where TResult : KR
        {
            return IExecute<KStream<KR, V>>("selectKey", mapper, named);
        }

        public BranchedKStream<K, V> Split()
        {
            return IExecute<BranchedKStream<K, V>>("split");
        }

        public BranchedKStream<K, V> Split(Named named)
        {
            return IExecute<BranchedKStream<K, V>>("split", named);
        }

        public void To(string topic)
        {
            IExecute("to", topic);
        }

        public void To(string topic, Produced<K, V> produced)
        {
            IExecute("to", topic, produced);
        }

        public void To(TopicNameExtractor<K, V> topicExtractor)
        {
            IExecute("to", topicExtractor);
        }

        public void To(TopicNameExtractor<K, V> topicExtractor, Produced<K, V> produced)
        {
            IExecute("to", topicExtractor, produced);
        }

        public KTable<K, V> ToTable()
        {
            return IExecute<KTable<K, V>>("toTable");
        }

        public KTable<K, V> ToTable(Named named)
        {
            return IExecute<KTable<K, V>>("toTable", named);
        }

        public KTable<K, V> ToTable(Materialized<K, V, KeyValueStore<Bytes, byte[]>> materialized)
        {
            return IExecute<KTable<K, V>>("toTable", materialized);
        }

        public KTable<K, V> ToTable(Named named, Materialized<K, V, KeyValueStore<Bytes, byte[]>> materialized)
        {
            return IExecute<KTable<K, V>>("toTable", named, materialized);
        }

        public KStream<K1, V1> Transform<TSuperK, TSuperV, K1, V1>(TransformerSupplier<TSuperK, TSuperV, KeyValue<K1, V1>> transformerSupplier, params string[] stateStoreNames)
            where TSuperK : K
            where TSuperV : V
        {
            return IExecute<KStream<K1, V1>>("transform", transformerSupplier, stateStoreNames);
        }

        public KStream<K1, V1> Transform<TSuperK, TSuperV, K1, V1>(TransformerSupplier<TSuperK, TSuperV, KeyValue<K1, V1>> transformerSupplier, Named named, params string[] stateStoreNames)
            where TSuperK : K
            where TSuperV : V
        {
            return IExecute<KStream<K1, V1>>("transform", transformerSupplier, named, stateStoreNames);
        }

        public KStream<K, VR> TransformValues<TSuperV, TSuperVR, VR>(ValueTransformerSupplier<TSuperV, TSuperVR> valueTransformerSupplier, params string[] stateStoreNames)
            where TSuperV : V
            where TSuperVR : VR
        {
            return IExecute<KStream<K, VR>>("transformValues", valueTransformerSupplier, stateStoreNames);
        }

        public KStream<K, VR> TransformValues<TSuperV, TSuperVR, VR>(ValueTransformerSupplier<TSuperV, TSuperVR> valueTransformerSupplier, Named named, params string[] stateStoreNames)
            where TSuperV : V
            where TSuperVR : VR
        {
            return IExecute<KStream<K, VR>>("transformValues", valueTransformerSupplier, named, stateStoreNames);
        }

        public KStream<K, VR> TransformValues<TSuperK, TSuperV, TSuperVR, VR>(ValueTransformerWithKeySupplier<TSuperK, TSuperV, TSuperVR> valueTransformerSupplier, params string[] stateStoreNames)
            where TSuperK : K
            where TSuperV : V
            where TSuperVR : VR
        {
            return IExecute<KStream<K, VR>>("transformValues", valueTransformerSupplier, stateStoreNames);
        }

        public KStream<K, VR> TransformValues<TSuperK, TSuperV, TSuperVR, VR>(ValueTransformerWithKeySupplier<TSuperK, TSuperV, TSuperVR> valueTransformerSupplier, Named named, params string[] stateStoreNames)
            where TSuperK : K
            where TSuperV : V
            where TSuperVR : VR
        {
            return IExecute<KStream<K, VR>>("transformValues", valueTransformerSupplier, named, stateStoreNames);
        }
    }
}
