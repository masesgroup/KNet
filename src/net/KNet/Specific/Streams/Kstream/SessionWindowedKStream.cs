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
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.SessionWindowedKStream{TJVMK, TJVMV}"/>
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
    /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
    public class SessionWindowedKStream<K, V, TJVMK, TJVMV> : IGenericSerDesFactoryApplier
    {
        Org.Apache.Kafka.Streams.Kstream.SessionWindowedKStream<TJVMK, TJVMV> _inner;

        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set => _factory = value; }

        internal SessionWindowedKStream(IGenericSerDesFactory factory, Org.Apache.Kafka.Streams.Kstream.SessionWindowedKStream<TJVMK, TJVMV> inner)
        {
            _factory = factory;
            _inner = inner;
        }

        /// <summary>
        /// Converter from <see cref="SessionWindowedKStream{K, V, TJVMK, TJVMV}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.SessionWindowedKStream{TJVMK, TJVMV}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.SessionWindowedKStream<TJVMK, TJVMV>(SessionWindowedKStream<K, V, TJVMK, TJVMV> t) => t._inner;

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/SessionWindowedKStream.html#aggregate(org.apache.kafka.streams.kstream.Initializer,org.apache.kafka.streams.kstream.Aggregator,org.apache.kafka.streams.kstream.Merger,org.apache.kafka.streams.kstream.Materialized)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Initializer{VA, TJVMVA}"/></param>
        /// <param name="arg1"><see cref="Aggregator{K, V, VA, TJVMK, TJVMV, TJVMVA}"/></param>
        /// <param name="arg2"><see cref="Merger{K, V, TJVMK, TJVMV}"/></param>
        /// <param name="arg3"><see cref="Materialized{K, V, TJVMK, TJVMV}"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="TJVMVR">The JVM type of <typeparamref name="VR"/></typeparam>
        /// <typeparam name="Arg1objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg2objectSuperK"><typeparamref name="K"/></typeparam>
        /// <returns><see cref="KTable{K, V, TJVMK, TJVMV}"/></returns>
        public KTable<K, VR, Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, TJVMVR> Aggregate<VR, TJVMVR, Arg1objectSuperK, Arg1objectSuperV, Arg2objectSuperK>(Initializer<VR, TJVMVR> arg0, Aggregator<Arg1objectSuperK, Arg1objectSuperV, VR, TJVMK, TJVMV, TJVMVR> arg1, Merger<Arg2objectSuperK, VR, TJVMK, TJVMVR> arg2, Materialized<K, VR,TJVMK, TJVMVR> arg3) where Arg1objectSuperK : K where Arg1objectSuperV : V where Arg2objectSuperK : K
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            if (arg2 is IGenericSerDesFactoryApplier applier2) applier2.Factory = _factory;
            if (arg3 is IGenericSerDesFactoryApplier applier3) applier3.Factory = _factory;
            return new KTable<K, VR, Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, TJVMVR>(_factory, _inner.Aggregate(arg0, arg1, arg2, arg3));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/SessionWindowedKStream.html#aggregate(org.apache.kafka.streams.kstream.Initializer,org.apache.kafka.streams.kstream.Aggregator,org.apache.kafka.streams.kstream.Merger,org.apache.kafka.streams.kstream.Named,org.apache.kafka.streams.kstream.Materialized)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Initializer{VA, TJVMVA}"/></param>
        /// <param name="arg1"><see cref="Aggregator{K, V, VA, TJVMK, TJVMV, TJVMVA}"/></param>
        /// <param name="arg2"><see cref="Merger{K, V, TJVMK, TJVMV}"/></param>
        /// <param name="arg3"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <param name="arg4"><see cref="Materialized{K, V, TJVMK, TJVMV}"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="TJVMVR">The JVM type of <typeparamref name="VR"/></typeparam>
        /// <typeparam name="Arg1objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg2objectSuperK"><typeparamref name="K"/></typeparam>
        /// <returns><see cref="KTable{K, V, TJVMK, TJVMV}"/></returns>
        public KTable<K, VR, Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, TJVMVR> Aggregate<VR, TJVMVR, Arg1objectSuperK, Arg1objectSuperV, Arg2objectSuperK>(Initializer<VR, TJVMVR> arg0, Aggregator<Arg1objectSuperK, Arg1objectSuperV, VR, TJVMK, TJVMV, TJVMVR> arg1, Merger<Arg2objectSuperK, VR, TJVMK, TJVMVR> arg2, Org.Apache.Kafka.Streams.Kstream.Named arg3, Materialized<K, VR, TJVMK, TJVMVR> arg4) where Arg1objectSuperK : K where Arg1objectSuperV : V where Arg2objectSuperK : K
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            if (arg2 is IGenericSerDesFactoryApplier applier2) applier2.Factory = _factory;
            if (arg4 is IGenericSerDesFactoryApplier applier4) applier4.Factory = _factory;
            return new KTable<K, VR, Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, TJVMVR>(_factory, _inner.Aggregate(arg0, arg1, arg2, arg3, arg4));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/SessionWindowedKStream.html#aggregate(org.apache.kafka.streams.kstream.Initializer,org.apache.kafka.streams.kstream.Aggregator,org.apache.kafka.streams.kstream.Merger,org.apache.kafka.streams.kstream.Named)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Initializer{VA, TJVMVA}"/></param>
        /// <param name="arg1"><see cref="Aggregator{K, V, VA, TJVMK, TJVMV, TJVMVA}"/></param>
        /// <param name="arg2"><see cref="Merger{K, V, TJVMK, TJVMV}"/></param>
        /// <param name="arg3"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="TJVMVR">The JVM type of <typeparamref name="VR"/></typeparam>
        /// <typeparam name="Arg1objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg2objectSuperK"><typeparamref name="K"/></typeparam>
        /// <returns><see cref="KTable{K, V, TJVMK, TJVMV}"/></returns>
        public KTable<K, VR, Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, TJVMVR> Aggregate<VR, TJVMVR, Arg1objectSuperK, Arg1objectSuperV, Arg2objectSuperK>(Initializer<VR, TJVMVR> arg0, Aggregator<Arg1objectSuperK, Arg1objectSuperV, VR, TJVMK, TJVMV, TJVMVR> arg1, Merger<Arg2objectSuperK, VR, TJVMK, TJVMVR> arg2, Org.Apache.Kafka.Streams.Kstream.Named arg3) where Arg1objectSuperK : K where Arg1objectSuperV : V where Arg2objectSuperK : K
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            if (arg2 is IGenericSerDesFactoryApplier applier2) applier2.Factory = _factory;
            return new KTable<K, VR, Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, TJVMVR>(_factory, _inner.Aggregate(arg0, arg1, arg2, arg3));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/SessionWindowedKStream.html#aggregate(org.apache.kafka.streams.kstream.Initializer,org.apache.kafka.streams.kstream.Aggregator,org.apache.kafka.streams.kstream.Merger)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Initializer{VA, TJVMVA}"/></param>
        /// <param name="arg1"><see cref="Aggregator{K, V, VA, TJVMK, TJVMV, TJVMVA}"/></param>
        /// <param name="arg2"><see cref="Merger{K, V, TJVMK, TJVMV}"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="TJVMVR">The JVM type of <typeparamref name="VR"/></typeparam>
        /// <typeparam name="Arg1objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg2objectSuperK"><typeparamref name="K"/></typeparam>
        /// <returns><see cref="KTable{K, V, TJVMK, TJVMV}"/></returns>
        public KTable<K, VR, Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, TJVMVR> Aggregate<VR, TJVMVR, Arg1objectSuperK, Arg1objectSuperV, Arg2objectSuperK>(Initializer<VR, TJVMVR> arg0, Aggregator<Arg1objectSuperK, Arg1objectSuperV, VR, TJVMK, TJVMV, TJVMVR> arg1, Merger<Arg2objectSuperK, VR, TJVMK, TJVMVR> arg2) where Arg1objectSuperK : K where Arg1objectSuperV : V where Arg2objectSuperK : K
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            if (arg2 is IGenericSerDesFactoryApplier applier2) applier2.Factory = _factory;
            return new KTable<K, VR, Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, TJVMVR>(_factory, _inner.Aggregate(arg0, arg1, arg2));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/SessionWindowedKStream.html#count()"/>
        /// </summary>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KTable<K, long, Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, Java.Lang.Long> Count()
        {
            return new KTable<K, long, Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, Java.Lang.Long>(_factory, _inner.Count());
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/SessionWindowedKStream.html#count(org.apache.kafka.streams.kstream.Materialized)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Materialized{K, V, TJVMK, TJVMV}"/></param>
        /// <returns><see cref="KTable{K, V, TJVMK, TJVMV}"/></returns>
        public KTable<K, long, Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, Java.Lang.Long> Count(Materialized<K, long, TJVMK, Java.Lang.Long> arg0)
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KTable<K, long, Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, Java.Lang.Long>(_factory, _inner.Count(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/SessionWindowedKStream.html#count(org.apache.kafka.streams.kstream.Named,org.apache.kafka.streams.kstream.Materialized)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <param name="arg1"><see cref="Materialized{K, V, TJVMK, TJVMV}"/></param>
        /// <returns><see cref="KTable{K, V, TJVMK, TJVMV}"/></returns>
        public KTable<K, long, Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, Java.Lang.Long> Count(Org.Apache.Kafka.Streams.Kstream.Named arg0, Materialized<K, long, TJVMK, Java.Lang.Long> arg1)
        {
            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            return new KTable<K, long, Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, Java.Lang.Long>(_factory, _inner.Count(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/SessionWindowedKStream.html#count(org.apache.kafka.streams.kstream.Named)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <returns><see cref="KTable{K, V, TJVMK, TJVMV}"/></returns>
        public KTable<K, long, Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, Java.Lang.Long> Count(Org.Apache.Kafka.Streams.Kstream.Named arg0)
        {
            return new KTable<K, long, Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, Java.Lang.Long>(_factory, _inner.Count(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/SessionWindowedKStream.html#reduce(org.apache.kafka.streams.kstream.Reducer,org.apache.kafka.streams.kstream.Materialized)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Reducer{V, TJVMV}"/></param>
        /// <param name="arg1"><see cref="Materialized{K, V, TJVMK, TJVMV}"/></param>
        /// <returns><see cref="KTable{K, V, TJVMK, TJVMV}"/></returns>
        public KTable<K, V, Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, TJVMV> Reduce(Reducer<V, TJVMV> arg0, Materialized<K, V, TJVMK, TJVMV> arg1)
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            return new KTable<K, V, Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, TJVMV>(_factory, _inner.Reduce(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/SessionWindowedKStream.html#reduce(org.apache.kafka.streams.kstream.Reducer,org.apache.kafka.streams.kstream.Named,org.apache.kafka.streams.kstream.Materialized)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Reducer{V, TJVMV}"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <param name="arg2"><see cref="Materialized{K, V, TJVMK, TJVMV}"/></param>
        /// <returns><see cref="KTable{K, V, TJVMK, TJVMV}"/></returns>
        public KTable<K, V, Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, TJVMV> Reduce(Reducer<V, TJVMV> arg0, Org.Apache.Kafka.Streams.Kstream.Named arg1, Materialized<K, V, TJVMK, TJVMV> arg2)
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg2 is IGenericSerDesFactoryApplier applier2) applier2.Factory = _factory;
            return new KTable<K, V, Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, TJVMV>(_factory, _inner.Reduce(arg0, arg1, arg2));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/SessionWindowedKStream.html#reduce(org.apache.kafka.streams.kstream.Reducer,org.apache.kafka.streams.kstream.Named)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Reducer{V, TJVMV}"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <returns><see cref="KTable{K, V, TJVMK, TJVMV}"/></returns>
        public KTable<K, V, Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, TJVMV> Reduce(Reducer<V, TJVMV> arg0, Org.Apache.Kafka.Streams.Kstream.Named arg1)
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KTable<K, V, Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, TJVMV>(_factory, _inner.Reduce(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/SessionWindowedKStream.html#reduce(org.apache.kafka.streams.kstream.Reducer)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Reducer{V, TJVMV}"/></param>
        /// <returns><see cref="KTable{K, V, TJVMK, TJVMV}"/></returns>
        public KTable<K, V, Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, TJVMV> Reduce(Reducer<V, TJVMV> arg0)
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KTable<K, V, Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, TJVMV>(_factory, _inner.Reduce(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/SessionWindowedKStream.html#emitStrategy(org.apache.kafka.streams.kstream.EmitStrategy)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.EmitStrategy"/></param>
        /// <returns><see cref="SessionWindowedKStream{K, V, TJVMK, TJVMV}"/></returns>
        public SessionWindowedKStream<K, V, TJVMK, TJVMV> EmitStrategy(Org.Apache.Kafka.Streams.Kstream.EmitStrategy arg0)
        {
            return new SessionWindowedKStream<K, V, TJVMK, TJVMV>(_factory, _inner.EmitStrategy(arg0));
        }

        #endregion
    }
}
