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
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.KGroupedStream{TJVMK, TJVMV}"/>
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    public class KNetKGroupedStream<K, V, TJVMK, TJVMV> : IGenericSerDesFactoryApplier
    {
        Org.Apache.Kafka.Streams.Kstream.KGroupedStream<TJVMK, TJVMV> _inner;

        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        internal KNetKGroupedStream(IGenericSerDesFactory factory, Org.Apache.Kafka.Streams.Kstream.KGroupedStream<TJVMK, TJVMV> inner)
        {
            _factory = factory;
            _inner = inner;
        }

        /// <summary>
        /// Converter from <see cref="KNetKGroupedStream{K, V, TJVMK, TJVMV}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.KGroupedStream{TJVMK, TJVMV}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.KGroupedStream<TJVMK, TJVMV>(KNetKGroupedStream<K, V, TJVMK, TJVMV> t) => t._inner;

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KGroupedStream.html#cogroup-org.apache.kafka.streams.kstream.Aggregator-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KNetAggregator{K, V, VA, TJVMK, TJVMV, TJVMVA}"/></param>
        /// <typeparam name="VOut"></typeparam>
        /// <typeparam name="Arg0objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="KNetCogroupedKStream{K, V, TJVMK, TJVMVOut}"/></returns>
        public KNetCogroupedKStream<K, VOut, TJVMK, TJVMVOut> Cogroup<VOut, TJVMVOut, Arg0objectSuperK, Arg0objectSuperV>(KNetAggregator<Arg0objectSuperK, Arg0objectSuperV, VOut, TJVMK, TJVMV, TJVMVOut> arg0) where Arg0objectSuperK : K where Arg0objectSuperV : V
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KNetCogroupedKStream<K, VOut, TJVMK, TJVMVOut>(_factory, _inner.Cogroup<TJVMVOut, TJVMK, TJVMV>(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KGroupedStream.html#aggregate-org.apache.kafka.streams.kstream.Initializer-org.apache.kafka.streams.kstream.Aggregator-org.apache.kafka.streams.kstream.Materialized-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KNetInitializer{VA, TJVMVA}"/></param>
        /// <param name="arg1"><see cref="KNetAggregator{K, V, VA, TJVMK, TJVMV, TJVMVA}"/></param>
        /// <param name="arg2"><see cref="KNetMaterialized{K, VR, TJVMK, TJVMVR}"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="Arg1objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="KNetKTable{K, VR, TJVMK, TJVMVR}"/></returns>
        public KNetKTable<K, VR, TJVMK, TJVMVR> Aggregate<VR, TJVMVR, Arg1objectSuperK, Arg1objectSuperV>(KNetInitializer<VR, TJVMVR> arg0, KNetAggregator<Arg1objectSuperK, Arg1objectSuperV, VR, TJVMK, TJVMV, TJVMVR> arg1, KNetMaterialized<K, VR, TJVMK, TJVMVR> arg2) where Arg1objectSuperK : K where Arg1objectSuperV : V
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            if (arg2 is IGenericSerDesFactoryApplier applier2) applier2.Factory = _factory;
            return new KNetKTable<K, VR, TJVMK, TJVMVR>(_factory, _inner.Aggregate<TJVMVR, TJVMK, TJVMV>(arg0, arg1, arg2));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KGroupedStream.html#aggregate-org.apache.kafka.streams.kstream.Initializer-org.apache.kafka.streams.kstream.Aggregator-org.apache.kafka.streams.kstream.Named-org.apache.kafka.streams.kstream.Materialized-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KNetInitializer{VR}"/></param>
        /// <param name="arg1"><see cref="KNetAggregator{Arg1objectSuperK, Arg1objectSuperV, VR}"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <param name="arg3"><see cref="KNetMaterialized{K, VR, TJVMK, TJVMVR}"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="Arg1objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="KNetKTable{K, VR, TJVMK, TJVMVR}"/></returns>
        public KNetKTable<K, VR, TJVMK, TJVMVR> Aggregate<VR, TJVMVR, Arg1objectSuperK, Arg1objectSuperV>(KNetInitializer<VR, TJVMVR> arg0, KNetAggregator<Arg1objectSuperK, Arg1objectSuperV, VR, TJVMK, TJVMV, TJVMVR> arg1, Org.Apache.Kafka.Streams.Kstream.Named arg2, KNetMaterialized<K, VR, TJVMK, TJVMVR> arg3) where Arg1objectSuperK : K where Arg1objectSuperV : V
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            if (arg3 is IGenericSerDesFactoryApplier applier3) applier3.Factory = _factory;
            return new KNetKTable<K, VR, TJVMK, TJVMVR>(_factory, _inner.Aggregate<TJVMVR, TJVMK, TJVMV>(arg0, arg1, arg2, arg3));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KGroupedStream.html#aggregate-org.apache.kafka.streams.kstream.Initializer-org.apache.kafka.streams.kstream.Aggregator-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KNetInitializer{VA, TJVMVA}"/></param>
        /// <param name="arg1"><see cref="KNetAggregator{K, V, VA, TJVMK, TJVMV, TJVMVA}"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="Arg1objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="KNetKTable{K, VR, TJVMK, TJVMVR}"/></returns>
        public KNetKTable<K, VR, TJVMK, TJVMVR> Aggregate<VR, TJVMVR, Arg1objectSuperK, Arg1objectSuperV>(KNetInitializer<VR, TJVMVR> arg0, KNetAggregator<Arg1objectSuperK, Arg1objectSuperV, VR, TJVMK, TJVMV, TJVMVR> arg1) where Arg1objectSuperK : K where Arg1objectSuperV : V
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            return new KNetKTable<K, VR, TJVMK, TJVMVR>(_factory, _inner.Aggregate<TJVMVR, TJVMK, TJVMV>(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KGroupedStream.html#windowedBy-org.apache.kafka.streams.kstream.Windows-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Windows"/></param>
        /// <typeparam name="W"><see cref="Org.Apache.Kafka.Streams.Kstream.Window"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.TimeWindowedKStream"/></returns>
        public KNetTimeWindowedKStream<K, V, TJVMK, TJVMV> WindowedBy<W>(Org.Apache.Kafka.Streams.Kstream.Windows<W> arg0) where W : Org.Apache.Kafka.Streams.Kstream.Window
        {
            return new KNetTimeWindowedKStream<K, V, TJVMK, TJVMV>(_factory, _inner.WindowedBy(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KGroupedStream.html#count--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, long, TJVMK, Java.Lang.Long> Count()
        {
            return new KNetKTable<K, long, TJVMK, Java.Lang.Long>(_factory, _inner.Count());
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KGroupedStream.html#count-org.apache.kafka.streams.kstream.Materialized-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KNetCountingMaterialized{K, TJVMK}"/></param>
        /// <returns><see cref="KNetKTable{K, V, TJVMK, TJVMV}"/></returns>
        public KNetKTable<K, long, TJVMK, Java.Lang.Long> Count(KNetCountingMaterialized<K, TJVMK> arg0)
        {
            return new KNetKTable<K, long, TJVMK, Java.Lang.Long>(_factory, _inner.Count(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KGroupedStream.html#count-org.apache.kafka.streams.kstream.Named-org.apache.kafka.streams.kstream.Materialized-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <param name="arg1"><see cref="KNetCountingMaterialized{K, TJVMK}"/></param>
        /// <returns><see cref="KNetKTable{K, V, TJVMK, TJVMV}"/></returns>
        public KNetKTable<K, long, TJVMK, Java.Lang.Long> Count(Org.Apache.Kafka.Streams.Kstream.Named arg0, KNetCountingMaterialized<K, TJVMK> arg1)
        {
            return new KNetKTable<K, long, TJVMK, Java.Lang.Long>(_factory, _inner.Count(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KGroupedStream.html#count-org.apache.kafka.streams.kstream.Named-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <returns><see cref="KNetKTable{K, V, TJVMK, TJVMV}"/></returns>
        public KNetKTable<K, long, TJVMK, Java.Lang.Long> Count(Org.Apache.Kafka.Streams.Kstream.Named arg0)
        {
            return new KNetKTable<K, long, TJVMK, Java.Lang.Long>(_factory, _inner.Count(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KGroupedStream.html#reduce-org.apache.kafka.streams.kstream.Reducer-org.apache.kafka.streams.kstream.Materialized-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KNetReducer{V, TJVMV}"/></param>
        /// <param name="arg1"><see cref="KNetMaterialized{K, V, TJVMK, TJVMV}"/></param>
        /// <returns><see cref="KNetKTable{K, V, TJVMK, TJVMV}"/></returns>
        public KNetKTable<K, V, TJVMK, TJVMV> Reduce(KNetReducer<V, TJVMV> arg0, KNetMaterialized<K, V, TJVMK, TJVMV> arg1)
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            return new KNetKTable<K, V, TJVMK, TJVMV>(_factory, _inner.Reduce(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KGroupedStream.html#reduce-org.apache.kafka.streams.kstream.Reducer-org.apache.kafka.streams.kstream.Named-org.apache.kafka.streams.kstream.Materialized-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KNetReducer{V, TJVMV}"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <param name="arg2"><see cref="KNetMaterialized{K, V, TJVMK, TJVMV}"/></param>
        /// <returns><see cref="KNetKTable{K, V, TJVMK, TJVMV}"/></returns>
        public KNetKTable<K, V, TJVMK, TJVMV> Reduce(KNetReducer<V, TJVMV> arg0, Org.Apache.Kafka.Streams.Kstream.Named arg1, KNetMaterialized<K, V, TJVMK, TJVMV> arg2)
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg2 is IGenericSerDesFactoryApplier applier2) applier2.Factory = _factory;
            return new KNetKTable<K, V, TJVMK, TJVMV>(_factory, _inner.Reduce(arg0, arg1, arg2));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KGroupedStream.html#reduce-org.apache.kafka.streams.kstream.Reducer-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KNetReducer{V, TJVMV}"/></param>
        /// <returns><see cref="KNetKTable{K, V, TJVMK, TJVMV}"/></returns>
        public KNetKTable<K, V, TJVMK, TJVMV> Reduce(KNetReducer<V, TJVMV> arg0)
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KNetKTable<K, V, TJVMK, TJVMV>(_factory, _inner.Reduce(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KGroupedStream.html#windowedBy-org.apache.kafka.streams.kstream.SessionWindows-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.SessionWindows"/></param>
        /// <returns><see cref="KNetSessionWindowedKStream{K, V, TJVMK, TJVMV}"/></returns>
        public KNetSessionWindowedKStream<K, V, TJVMK, TJVMV> WindowedBy(Org.Apache.Kafka.Streams.Kstream.SessionWindows arg0)
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KNetSessionWindowedKStream<K, V, TJVMK, TJVMV>(_factory, _inner.WindowedBy(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KGroupedStream.html#windowedBy-org.apache.kafka.streams.kstream.SlidingWindows-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.SlidingWindows"/></param>
        /// <returns><see cref="KNetTimeWindowedKStream{K, V, TJVMK, TJVMV}"/></returns>
        public KNetTimeWindowedKStream<K, V, TJVMK, TJVMV> WindowedBy(Org.Apache.Kafka.Streams.Kstream.SlidingWindows arg0)
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KNetTimeWindowedKStream<K, V, TJVMK, TJVMV>(_factory, _inner.WindowedBy(arg0));
        }

        #endregion
    }
}
