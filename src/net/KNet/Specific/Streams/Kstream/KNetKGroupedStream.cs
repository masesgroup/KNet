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
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.KGroupedStream{K, V}"/>
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    public class KNetKGroupedStream<K, V> : IGenericSerDesFactoryApplier
    {
        Org.Apache.Kafka.Streams.Kstream.KGroupedStream<byte[], byte[]> _inner;

        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        internal KNetKGroupedStream(IGenericSerDesFactory factory, Org.Apache.Kafka.Streams.Kstream.KGroupedStream<byte[], byte[]> inner)
        {
            _factory = factory;
            _inner = inner;
        }

        /// <summary>
        /// Converter from <see cref="KNetKGroupedStream{K, V}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.KGroupedStream{K, V}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.KGroupedStream<byte[], byte[]>(KNetKGroupedStream<K, V> t) => t._inner;

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KGroupedStream.html#cogroup-org.apache.kafka.streams.kstream.Aggregator-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KNetAggregator{K, V, VA}"/></param>
        /// <typeparam name="VOut"></typeparam>
        /// <typeparam name="Arg0objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="KNetCogroupedKStream{K, V}"/></returns>
        public KNetCogroupedKStream<K, VOut> Cogroup<VOut, Arg0objectSuperK, Arg0objectSuperV>(KNetAggregator<Arg0objectSuperK, Arg0objectSuperV, VOut> arg0) where Arg0objectSuperK : K where Arg0objectSuperV : V
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KNetCogroupedKStream<K, VOut>(_factory, _inner.Cogroup<byte[], byte[], byte[]>(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KGroupedStream.html#aggregate-org.apache.kafka.streams.kstream.Initializer-org.apache.kafka.streams.kstream.Aggregator-org.apache.kafka.streams.kstream.Materialized-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KNetInitializer{VR}"/></param>
        /// <param name="arg1"><see cref="KNetAggregator{Arg1objectSuperK, Arg1objectSuperV, VR}"/></param>
        /// <param name="arg2"><see cref="KNetMaterialized{K, VR}"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="Arg1objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="KNetKTable{K, VR}"/></returns>
        public KNetKTable<K, VR> Aggregate<VR, Arg1objectSuperK, Arg1objectSuperV>(KNetInitializer<VR> arg0, KNetAggregator<Arg1objectSuperK, Arg1objectSuperV, VR> arg1, KNetMaterialized<K, VR> arg2) where Arg1objectSuperK : K where Arg1objectSuperV : V
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            if (arg2 is IGenericSerDesFactoryApplier applier2) applier2.Factory = _factory;
            return new KNetKTable<K, VR>(_factory, _inner.Aggregate<byte[], byte[], byte[]>(arg0, arg1, arg2));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KGroupedStream.html#aggregate-org.apache.kafka.streams.kstream.Initializer-org.apache.kafka.streams.kstream.Aggregator-org.apache.kafka.streams.kstream.Named-org.apache.kafka.streams.kstream.Materialized-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KNetInitializer{VR}"/></param>
        /// <param name="arg1"><see cref="KNetAggregator{Arg1objectSuperK, Arg1objectSuperV, VR}"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <param name="arg3"><see cref="KNetMaterialized{K, VR}"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="Arg1objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="KNetKTable{K, VR}"/></returns>
        public KNetKTable<K, VR> Aggregate<VR, Arg1objectSuperK, Arg1objectSuperV>(KNetInitializer<VR> arg0, KNetAggregator<Arg1objectSuperK, Arg1objectSuperV, VR> arg1, Org.Apache.Kafka.Streams.Kstream.Named arg2, KNetMaterialized<K, VR> arg3) where Arg1objectSuperK : K where Arg1objectSuperV : V
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            if (arg3 is IGenericSerDesFactoryApplier applier3) applier3.Factory = _factory;
            return new KNetKTable<K, VR>(_factory, _inner.Aggregate<byte[], byte[], byte[]>(arg0, arg1, arg2, arg3));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KGroupedStream.html#aggregate-org.apache.kafka.streams.kstream.Initializer-org.apache.kafka.streams.kstream.Aggregator-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KNetInitializer{VR}"/></param>
        /// <param name="arg1"><see cref="KNetAggregator{Arg1objectSuperK, Arg1objectSuperV, VR}"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="Arg1objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="KNetKTable{K, VR}"/></returns>
        public KNetKTable<K, VR> Aggregate<VR, Arg1objectSuperK, Arg1objectSuperV>(KNetInitializer<VR> arg0, KNetAggregator<Arg1objectSuperK, Arg1objectSuperV, VR> arg1) where Arg1objectSuperK : K where Arg1objectSuperV : V
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            return new KNetKTable<K, VR>(_factory, _inner.Aggregate<byte[], byte[], byte[]>(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KGroupedStream.html#windowedBy-org.apache.kafka.streams.kstream.Windows-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Windows"/></param>
        /// <typeparam name="W"><see cref="Org.Apache.Kafka.Streams.Kstream.Window"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.TimeWindowedKStream"/></returns>
        public KNetTimeWindowedKStream<K, V> WindowedBy<W>(Org.Apache.Kafka.Streams.Kstream.Windows<W> arg0) where W : Org.Apache.Kafka.Streams.Kstream.Window
        {
            return new KNetTimeWindowedKStream<K, V>(_factory, _inner.WindowedBy(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KGroupedStream.html#count--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, long> Count()
        {
            return new KNetKTable<K, long>(_factory, _inner.Count());
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KGroupedStream.html#count-org.apache.kafka.streams.kstream.Materialized-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KNetCountingMaterialized{K}"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, long> Count(KNetCountingMaterialized<K> arg0)
        {
            return new KNetKTable<K, long>(_factory, _inner.Count(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KGroupedStream.html#count-org.apache.kafka.streams.kstream.Named-org.apache.kafka.streams.kstream.Materialized-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <param name="arg1"><see cref="KNetCountingMaterialized{K}"/></param>
        /// <returns><see cref="KNetKTable{K, V}"/></returns>
        public KNetKTable<K, long> Count(Org.Apache.Kafka.Streams.Kstream.Named arg0, KNetCountingMaterialized<K> arg1)
        {
            return new KNetKTable<K, long>(_factory, _inner.Count(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KGroupedStream.html#count-org.apache.kafka.streams.kstream.Named-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <returns><see cref="KNetKTable{K, V}"/></returns>
        public KNetKTable<K, long> Count(Org.Apache.Kafka.Streams.Kstream.Named arg0)
        {
            return new KNetKTable<K, long>(_factory, _inner.Count(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KGroupedStream.html#reduce-org.apache.kafka.streams.kstream.Reducer-org.apache.kafka.streams.kstream.Materialized-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KNetReducer{V}"/></param>
        /// <param name="arg1"><see cref="KNetMaterialized{K, V}"/></param>
        /// <returns><see cref="KNetKTable{K, V}"/></returns>
        public KNetKTable<K, V> Reduce(KNetReducer<V> arg0, KNetMaterialized<K, V> arg1)
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            return new KNetKTable<K, V>(_factory, _inner.Reduce(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KGroupedStream.html#reduce-org.apache.kafka.streams.kstream.Reducer-org.apache.kafka.streams.kstream.Named-org.apache.kafka.streams.kstream.Materialized-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KNetReducer{V}"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <param name="arg2"><see cref="KNetMaterialized{K, V}"/></param>
        /// <returns><see cref="KNetKTable{K, V}"/></returns>
        public KNetKTable<K, V> Reduce(KNetReducer<V> arg0, Org.Apache.Kafka.Streams.Kstream.Named arg1, KNetMaterialized<K, V> arg2)
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg2 is IGenericSerDesFactoryApplier applier2) applier2.Factory = _factory;
            return new KNetKTable<K, V>(_factory, _inner.Reduce(arg0, arg1, arg2));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KGroupedStream.html#reduce-org.apache.kafka.streams.kstream.Reducer-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KNetReducer{V}"/></param>
        /// <returns><see cref="KNetKTable{K, V}"/></returns>
        public KNetKTable<K, V> Reduce(KNetReducer<V> arg0)
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KNetKTable<K, V>(_factory, _inner.Reduce(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KGroupedStream.html#windowedBy-org.apache.kafka.streams.kstream.SessionWindows-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.SessionWindows"/></param>
        /// <returns><see cref="KNetSessionWindowedKStream{K, V}"/></returns>
        public KNetSessionWindowedKStream<K, V> WindowedBy(Org.Apache.Kafka.Streams.Kstream.SessionWindows arg0)
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KNetSessionWindowedKStream<K, V>(_factory, _inner.WindowedBy(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KGroupedStream.html#windowedBy-org.apache.kafka.streams.kstream.SlidingWindows-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.SlidingWindows"/></param>
        /// <returns><see cref="KNetTimeWindowedKStream{K, V}"/></returns>
        public KNetTimeWindowedKStream<K, V> WindowedBy(Org.Apache.Kafka.Streams.Kstream.SlidingWindows arg0)
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KNetTimeWindowedKStream<K, V>(_factory, _inner.WindowedBy(arg0));
        }

        #endregion
    }
}
