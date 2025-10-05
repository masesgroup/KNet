/*
*  Copyright (c) 2021-2025 MASES s.r.l.
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
    /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
    /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
    public class KGroupedStream<K, V, TJVMK, TJVMV> : IGenericSerDesFactoryApplier
    {
        Org.Apache.Kafka.Streams.Kstream.KGroupedStream<TJVMK, TJVMV> _inner;

        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set => _factory = value; }

        internal KGroupedStream(IGenericSerDesFactory factory, Org.Apache.Kafka.Streams.Kstream.KGroupedStream<TJVMK, TJVMV> inner)
        {
            _factory = factory;
            _inner = inner;
        }

        /// <summary>
        /// Converter from <see cref="KGroupedStream{K, V, TJVMK, TJVMV}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.KGroupedStream{TJVMK, TJVMV}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.KGroupedStream<TJVMK, TJVMV>(KGroupedStream<K, V, TJVMK, TJVMV> t) => t._inner;

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.1.0/org/apache/kafka/streams/kstream/KGroupedStream.html#cogroup(org.apache.kafka.streams.kstream.Aggregator)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Aggregator{K, V, VA, TJVMK, TJVMV, TJVMVA}"/></param>
        /// <typeparam name="VOut"></typeparam>
        /// <typeparam name="TJVMVOut">The JVM type of <typeparamref name="VOut"/></typeparam>
        /// <typeparam name="Arg0objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="CogroupedKStream{K, V, TJVMK, TJVMVOut}"/></returns>
        public CogroupedKStream<K, VOut, TJVMK, TJVMVOut> Cogroup<VOut, TJVMVOut, Arg0objectSuperK, Arg0objectSuperV>(Aggregator<Arg0objectSuperK, Arg0objectSuperV, VOut, TJVMK, TJVMV, TJVMVOut> arg0) where Arg0objectSuperK : K where Arg0objectSuperV : V
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new CogroupedKStream<K, VOut, TJVMK, TJVMVOut>(_factory, _inner.Cogroup<TJVMVOut, TJVMK, TJVMV>(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.1.0/org/apache/kafka/streams/kstream/KGroupedStream.html#aggregate(org.apache.kafka.streams.kstream.Initializer,org.apache.kafka.streams.kstream.Aggregator,org.apache.kafka.streams.kstream.Materialized)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Initializer{VA, TJVMVA}"/></param>
        /// <param name="arg1"><see cref="Aggregator{K, V, VA, TJVMK, TJVMV, TJVMVA}"/></param>
        /// <param name="arg2"><see cref="Materialized{K, VR, TJVMK, TJVMVR}"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="TJVMVR">The JVM type of <typeparamref name="VR"/></typeparam>
        /// <typeparam name="Arg1objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="KTable{K, VR, TJVMK, TJVMVR}"/></returns>
        public KTable<K, VR, TJVMK, TJVMVR> Aggregate<VR, TJVMVR, Arg1objectSuperK, Arg1objectSuperV>(Initializer<VR, TJVMVR> arg0, Aggregator<Arg1objectSuperK, Arg1objectSuperV, VR, TJVMK, TJVMV, TJVMVR> arg1, Materialized<K, VR, TJVMK, TJVMVR> arg2) where Arg1objectSuperK : K where Arg1objectSuperV : V
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            if (arg2 is IGenericSerDesFactoryApplier applier2) applier2.Factory = _factory;
            return new KTable<K, VR, TJVMK, TJVMVR>(_factory, _inner.Aggregate<TJVMVR, TJVMK, TJVMV>(arg0, arg1, arg2));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.1.0/org/apache/kafka/streams/kstream/KGroupedStream.html#aggregate(org.apache.kafka.streams.kstream.Initializer,org.apache.kafka.streams.kstream.Aggregator,org.apache.kafka.streams.kstream.Named,org.apache.kafka.streams.kstream.Materialized)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Initializer{VR}"/></param>
        /// <param name="arg1"><see cref="Aggregator{Arg1objectSuperK, Arg1objectSuperV, VR}"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <param name="arg3"><see cref="Materialized{K, VR, TJVMK, TJVMVR}"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="TJVMVR">The JVM type of <typeparamref name="VR"/></typeparam>
        /// <typeparam name="Arg1objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="KTable{K, VR, TJVMK, TJVMVR}"/></returns>
        public KTable<K, VR, TJVMK, TJVMVR> Aggregate<VR, TJVMVR, Arg1objectSuperK, Arg1objectSuperV>(Initializer<VR, TJVMVR> arg0, Aggregator<Arg1objectSuperK, Arg1objectSuperV, VR, TJVMK, TJVMV, TJVMVR> arg1, Org.Apache.Kafka.Streams.Kstream.Named arg2, Materialized<K, VR, TJVMK, TJVMVR> arg3) where Arg1objectSuperK : K where Arg1objectSuperV : V
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            if (arg3 is IGenericSerDesFactoryApplier applier3) applier3.Factory = _factory;
            return new KTable<K, VR, TJVMK, TJVMVR>(_factory, _inner.Aggregate<TJVMVR, TJVMK, TJVMV>(arg0, arg1, arg2, arg3));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.1.0/org/apache/kafka/streams/kstream/KGroupedStream.html#aggregate(org.apache.kafka.streams.kstream.Initializer,org.apache.kafka.streams.kstream.Aggregator)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Initializer{VA, TJVMVA}"/></param>
        /// <param name="arg1"><see cref="Aggregator{K, V, VA, TJVMK, TJVMV, TJVMVA}"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="TJVMVR">The JVM type of <typeparamref name="VR"/></typeparam>
        /// <typeparam name="Arg1objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="KTable{K, VR, TJVMK, TJVMVR}"/></returns>
        public KTable<K, VR, TJVMK, TJVMVR> Aggregate<VR, TJVMVR, Arg1objectSuperK, Arg1objectSuperV>(Initializer<VR, TJVMVR> arg0, Aggregator<Arg1objectSuperK, Arg1objectSuperV, VR, TJVMK, TJVMV, TJVMVR> arg1) where Arg1objectSuperK : K where Arg1objectSuperV : V
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            return new KTable<K, VR, TJVMK, TJVMVR>(_factory, _inner.Aggregate<TJVMVR, TJVMK, TJVMV>(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.1.0/org/apache/kafka/streams/kstream/KGroupedStream.html#windowedBy(org.apache.kafka.streams.kstream.Windows)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Windows"/></param>
        /// <typeparam name="W"><see cref="Org.Apache.Kafka.Streams.Kstream.Window"/></typeparam>
        /// <returns><see cref="TimeWindowedKStream{K, V, TJVMK, TJVMV}"/></returns>
        public TimeWindowedKStream<K, V, TJVMK, TJVMV> WindowedBy<W>(Org.Apache.Kafka.Streams.Kstream.Windows<W> arg0) where W : Org.Apache.Kafka.Streams.Kstream.Window
        {
            return new TimeWindowedKStream<K, V, TJVMK, TJVMV>(_factory, _inner.WindowedBy(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.1.0/org/apache/kafka/streams/kstream/KGroupedStream.html#count()"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KTable<K, long, TJVMK, Java.Lang.Long> Count()
        {
            return new KTable<K, long, TJVMK, Java.Lang.Long>(_factory, _inner.Count());
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.1.0/org/apache/kafka/streams/kstream/KGroupedStream.html#count(org.apache.kafka.streams.kstream.Materialized)"/>
        /// </summary>
        /// <param name="arg0"><see cref="CountingMaterialized{K, TJVMK}"/></param>
        /// <returns><see cref="KTable{K, V, TJVMK, TJVMV}"/></returns>
        public KTable<K, long, TJVMK, Java.Lang.Long> Count(CountingMaterialized<K, TJVMK> arg0)
        {
            return new KTable<K, long, TJVMK, Java.Lang.Long>(_factory, _inner.Count(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.1.0/org/apache/kafka/streams/kstream/KGroupedStream.html#count(org.apache.kafka.streams.kstream.Named,org.apache.kafka.streams.kstream.Materialized)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <param name="arg1"><see cref="CountingMaterialized{K, TJVMK}"/></param>
        /// <returns><see cref="KTable{K, V, TJVMK, TJVMV}"/></returns>
        public KTable<K, long, TJVMK, Java.Lang.Long> Count(Org.Apache.Kafka.Streams.Kstream.Named arg0, CountingMaterialized<K, TJVMK> arg1)
        {
            return new KTable<K, long, TJVMK, Java.Lang.Long>(_factory, _inner.Count(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.1.0/org/apache/kafka/streams/kstream/KGroupedStream.html#count(org.apache.kafka.streams.kstream.Named)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <returns><see cref="KTable{K, V, TJVMK, TJVMV}"/></returns>
        public KTable<K, long, TJVMK, Java.Lang.Long> Count(Org.Apache.Kafka.Streams.Kstream.Named arg0)
        {
            return new KTable<K, long, TJVMK, Java.Lang.Long>(_factory, _inner.Count(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.1.0/org/apache/kafka/streams/kstream/KGroupedStream.html#reduce(org.apache.kafka.streams.kstream.Reducer,org.apache.kafka.streams.kstream.Materialized)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Reducer{V, TJVMV}"/></param>
        /// <param name="arg1"><see cref="Materialized{K, V, TJVMK, TJVMV}"/></param>
        /// <returns><see cref="KTable{K, V, TJVMK, TJVMV}"/></returns>
        public KTable<K, V, TJVMK, TJVMV> Reduce(Reducer<V, TJVMV> arg0, Materialized<K, V, TJVMK, TJVMV> arg1)
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            return new KTable<K, V, TJVMK, TJVMV>(_factory, _inner.Reduce(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.1.0/org/apache/kafka/streams/kstream/KGroupedStream.html#reduce(org.apache.kafka.streams.kstream.Reducer,org.apache.kafka.streams.kstream.Named,org.apache.kafka.streams.kstream.Materialized)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Reducer{V, TJVMV}"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <param name="arg2"><see cref="Materialized{K, V, TJVMK, TJVMV}"/></param>
        /// <returns><see cref="KTable{K, V, TJVMK, TJVMV}"/></returns>
        public KTable<K, V, TJVMK, TJVMV> Reduce(Reducer<V, TJVMV> arg0, Org.Apache.Kafka.Streams.Kstream.Named arg1, Materialized<K, V, TJVMK, TJVMV> arg2)
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg2 is IGenericSerDesFactoryApplier applier2) applier2.Factory = _factory;
            return new KTable<K, V, TJVMK, TJVMV>(_factory, _inner.Reduce(arg0, arg1, arg2));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.1.0/org/apache/kafka/streams/kstream/KGroupedStream.html#reduce(org.apache.kafka.streams.kstream.Reducer)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Reducer{V, TJVMV}"/></param>
        /// <returns><see cref="KTable{K, V, TJVMK, TJVMV}"/></returns>
        public KTable<K, V, TJVMK, TJVMV> Reduce(Reducer<V, TJVMV> arg0)
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KTable<K, V, TJVMK, TJVMV>(_factory, _inner.Reduce(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.1.0/org/apache/kafka/streams/kstream/KGroupedStream.html#windowedBy(org.apache.kafka.streams.kstream.SessionWindows)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.SessionWindows"/></param>
        /// <returns><see cref="SessionWindowedKStream{K, V, TJVMK, TJVMV}"/></returns>
        public SessionWindowedKStream<K, V, TJVMK, TJVMV> WindowedBy(Org.Apache.Kafka.Streams.Kstream.SessionWindows arg0)
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new SessionWindowedKStream<K, V, TJVMK, TJVMV>(_factory, _inner.WindowedBy(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.1.0/org/apache/kafka/streams/kstream/KGroupedStream.html#windowedBy(org.apache.kafka.streams.kstream.SlidingWindows)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.SlidingWindows"/></param>
        /// <returns><see cref="TimeWindowedKStream{K, V, TJVMK, TJVMV}"/></returns>
        public TimeWindowedKStream<K, V, TJVMK, TJVMV> WindowedBy(Org.Apache.Kafka.Streams.Kstream.SlidingWindows arg0)
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new TimeWindowedKStream<K, V, TJVMK, TJVMV>(_factory, _inner.WindowedBy(arg0));
        }

        #endregion
    }
}
