/*
*  Copyright 2024 MASES s.r.l.
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

using MASES.KNet.Serialization;

namespace MASES.KNet.Streams.Kstream
{
    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.KGroupedTable{TJVMK, TJVMV}"/>
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    public class KNetKGroupedTable<K, V, TJVMK, TJVMV> : IGenericSerDesFactoryApplier
    {
        Org.Apache.Kafka.Streams.Kstream.KGroupedTable<TJVMK, TJVMV> _inner;

        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        internal KNetKGroupedTable(IGenericSerDesFactory factory, Org.Apache.Kafka.Streams.Kstream.KGroupedTable<TJVMK, TJVMV> inner)
        {
            _factory = factory;
            _inner = inner;
        }

        /// <summary>
        /// Converter from <see cref="KNetKGroupedTable{K, V,TJVMK, TJVMV}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.KGroupedTable{TJVMK, TJVMV}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.KGroupedTable<TJVMK, TJVMV>(KNetKGroupedTable<K, V, TJVMK, TJVMV> t) => t._inner;

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KGroupedTable.html#aggregate-org.apache.kafka.streams.kstream.Initializer-org.apache.kafka.streams.kstream.Aggregator-org.apache.kafka.streams.kstream.Aggregator-org.apache.kafka.streams.kstream.Materialized-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Initializer"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Aggregator"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Kstream.Aggregator"/></param>
        /// <param name="arg3"><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="Arg1objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg2objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg2objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, VR> Aggregate<VR, Arg1objectSuperK, Arg1objectSuperV, Arg2objectSuperK, Arg2objectSuperV>(KNetInitializer<VR> arg0, KNetAggregator<Arg1objectSuperK, Arg1objectSuperV, VR> arg1, KNetAggregator<Arg2objectSuperK, Arg2objectSuperV, VR> arg2, KNetMaterialized<K, VR> arg3) where Arg1objectSuperK : K where Arg1objectSuperV : V where Arg2objectSuperK : K where Arg2objectSuperV : V
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            if (arg2 is IGenericSerDesFactoryApplier applier2) applier2.Factory = _factory;
            if (arg3 is IGenericSerDesFactoryApplier applier3) applier3.Factory = _factory;
            return new KNetKTable<K, VR>(_factory, _inner.Aggregate(arg0, arg1, arg2, arg3));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KGroupedTable.html#aggregate-org.apache.kafka.streams.kstream.Initializer-org.apache.kafka.streams.kstream.Aggregator-org.apache.kafka.streams.kstream.Aggregator-org.apache.kafka.streams.kstream.Named-org.apache.kafka.streams.kstream.Materialized-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Initializer"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Aggregator"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Kstream.Aggregator"/></param>
        /// <param name="arg3"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <param name="arg4"><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="Arg1objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg2objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg2objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, VR> Aggregate<VR, Arg1objectSuperK, Arg1objectSuperV, Arg2objectSuperK, Arg2objectSuperV>(KNetInitializer<VR> arg0, KNetAggregator<Arg1objectSuperK, Arg1objectSuperV, VR> arg1, KNetAggregator<Arg2objectSuperK, Arg2objectSuperV, VR> arg2, Org.Apache.Kafka.Streams.Kstream.Named arg3, KNetMaterialized<K, VR> arg4) where Arg1objectSuperK : K where Arg1objectSuperV : V where Arg2objectSuperK : K where Arg2objectSuperV : V
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            if (arg2 is IGenericSerDesFactoryApplier applier2) applier2.Factory = _factory;
            if (arg4 is IGenericSerDesFactoryApplier applier4) applier4.Factory = _factory;
            return new KNetKTable<K, VR>(_factory, _inner.Aggregate(arg0, arg1, arg2, arg3, arg4));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KGroupedTable.html#aggregate-org.apache.kafka.streams.kstream.Initializer-org.apache.kafka.streams.kstream.Aggregator-org.apache.kafka.streams.kstream.Aggregator-org.apache.kafka.streams.kstream.Named-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Initializer"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Aggregator"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Kstream.Aggregator"/></param>
        /// <param name="arg3"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="Arg1objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg2objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg2objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, VR> Aggregate<VR, Arg1objectSuperK, Arg1objectSuperV, Arg2objectSuperK, Arg2objectSuperV>(KNetInitializer<VR> arg0, KNetAggregator<Arg1objectSuperK, Arg1objectSuperV, VR> arg1, KNetAggregator<Arg2objectSuperK, Arg2objectSuperV, VR> arg2, Org.Apache.Kafka.Streams.Kstream.Named arg3) where Arg1objectSuperK : K where Arg1objectSuperV : V where Arg2objectSuperK : K where Arg2objectSuperV : V
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            if (arg2 is IGenericSerDesFactoryApplier applier2) applier2.Factory = _factory;
            return new KNetKTable<K, VR>(_factory, _inner.Aggregate(arg0, arg1, arg2, arg3));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KGroupedTable.html#aggregate-org.apache.kafka.streams.kstream.Initializer-org.apache.kafka.streams.kstream.Aggregator-org.apache.kafka.streams.kstream.Aggregator-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Initializer"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Aggregator"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Kstream.Aggregator"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="Arg1objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg2objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg2objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, VR> Aggregate<VR, Arg1objectSuperK, Arg1objectSuperV, Arg2objectSuperK, Arg2objectSuperV>(KNetInitializer<VR> arg0, KNetAggregator<Arg1objectSuperK, Arg1objectSuperV, VR> arg1, KNetAggregator<Arg2objectSuperK, Arg2objectSuperV, VR> arg2) where Arg1objectSuperK : K where Arg1objectSuperV : V where Arg2objectSuperK : K where Arg2objectSuperV : V
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            if (arg2 is IGenericSerDesFactoryApplier applier2) applier2.Factory = _factory;
            return new KNetKTable<K, VR>(_factory, _inner.Aggregate(arg0, arg1, arg2));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KGroupedTable.html#count--"/>
        /// </summary>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, long> Count()
        {
            return new KNetKTable<K, long>(_factory, _inner.Count());
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KGroupedTable.html#count-org.apache.kafka.streams.kstream.Materialized-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, long> Count(KNetCountingMaterialized<K> arg0)
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KNetKTable<K, long>(_factory, _inner.Count(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KGroupedTable.html#count-org.apache.kafka.streams.kstream.Named-org.apache.kafka.streams.kstream.Materialized-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, long> Count(Org.Apache.Kafka.Streams.Kstream.Named arg0, KNetCountingMaterialized<K> arg1)
        {
            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            return new KNetKTable<K, long>(_factory, _inner.Count(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KGroupedTable.html#count-org.apache.kafka.streams.kstream.Named-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, long> Count(Org.Apache.Kafka.Streams.Kstream.Named arg0)
        {
            return new KNetKTable<K, long>(_factory, _inner.Count(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KGroupedTable.html#reduce-org.apache.kafka.streams.kstream.Reducer-org.apache.kafka.streams.kstream.Reducer-org.apache.kafka.streams.kstream.Materialized-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Reducer"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Reducer"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, V> Reduce(KNetReducer<V> arg0, KNetReducer<V> arg1, KNetMaterialized<K, V> arg2)
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            if (arg2 is IGenericSerDesFactoryApplier applier2) applier2.Factory = _factory;
            return new KNetKTable<K, V>(_factory, _inner.Reduce(arg0, arg1, arg2));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KGroupedTable.html#reduce-org.apache.kafka.streams.kstream.Reducer-org.apache.kafka.streams.kstream.Reducer-org.apache.kafka.streams.kstream.Named-org.apache.kafka.streams.kstream.Materialized-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Reducer"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Reducer"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <param name="arg3"><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, V> Reduce(KNetReducer<V> arg0, KNetReducer<V> arg1, Org.Apache.Kafka.Streams.Kstream.Named arg2, KNetMaterialized<K, V> arg3)
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            if (arg3 is IGenericSerDesFactoryApplier applier3) applier3.Factory = _factory;
            return new KNetKTable<K, V>(_factory, _inner.Reduce(arg0, arg1, arg2, arg3));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KGroupedTable.html#reduce-org.apache.kafka.streams.kstream.Reducer-org.apache.kafka.streams.kstream.Reducer-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Reducer"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Reducer"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, V> Reduce(KNetReducer<V> arg0, KNetReducer<V> arg1)
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            return new KNetKTable<K, V>(_factory, _inner.Reduce(arg0, arg1));
        }

    }
}
