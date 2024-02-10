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
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.CogroupedKStream{K, VOut}"/>
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="VOut"></typeparam>
    public class KNetCogroupedKStream<K, VOut> : IGenericSerDesFactoryApplier
    {
        Org.Apache.Kafka.Streams.Kstream.CogroupedKStream<byte[], byte[]> _inner;

        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        internal KNetCogroupedKStream(IGenericSerDesFactory factory, Org.Apache.Kafka.Streams.Kstream.CogroupedKStream<byte[], byte[]> inner)
        {
            _factory = factory;
            _inner = inner;
        }

        /// <summary>
        /// Converter from <see cref="KNetCogroupedKStream{K, VOut}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.CogroupedKStream{K, VOut}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.CogroupedKStream<byte[], byte[]>(KNetCogroupedKStream<K, VOut> t) => t._inner;

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/CogroupedKStream.html#cogroup-org.apache.kafka.streams.kstream.KGroupedStream-org.apache.kafka.streams.kstream.Aggregator-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KNetKGroupedStream{K, V}"/></param>
        /// <param name="arg1"><see cref="KNetAggregator{K, V, VA}"/></param>
        /// <typeparam name="VIn"></typeparam>
        /// <typeparam name="Arg1objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg1objectSuperVIn"><typeparamref name="VIn"/></typeparam>
        /// <returns><see cref="KNetCogroupedKStream{K, VOut}"/></returns>
        public KNetCogroupedKStream<K, VOut> Cogroup<VIn, Arg1objectSuperK, Arg1objectSuperVIn>(KNetKGroupedStream<K, VIn> arg0, KNetAggregator<Arg1objectSuperK, Arg1objectSuperVIn, VOut> arg1) where Arg1objectSuperK : K where Arg1objectSuperVIn : VIn
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            return new KNetCogroupedKStream<K, VOut>(_factory, _inner.Cogroup<byte[], byte[], byte[]>(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/CogroupedKStream.html#windowedBy-org.apache.kafka.streams.kstream.Windows-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Windows"/></param>
        /// <typeparam name="W"><see cref="Org.Apache.Kafka.Streams.Kstream.Window"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.TimeWindowedCogroupedKStream"/></returns>
        public KNetTimeWindowedCogroupedKStream<K, VOut> WindowedBy<W>(Org.Apache.Kafka.Streams.Kstream.Windows<W> arg0) where W : Org.Apache.Kafka.Streams.Kstream.Window
        {
            return new KNetTimeWindowedCogroupedKStream<K, VOut>(_factory, _inner.WindowedBy(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/CogroupedKStream.html#aggregate-org.apache.kafka.streams.kstream.Initializer-org.apache.kafka.streams.kstream.Materialized-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KNetInitializer{VOut}"/></param>
        /// <param name="arg1"><see cref="KNetMaterialized{K, V}"/></param>
        /// <returns><see cref="KNetKTable{K, V}"/></returns>
        public KNetKTable<K, VOut> Aggregate(KNetInitializer<VOut> arg0, KNetMaterialized<K, VOut> arg1)
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            return new KNetKTable<K, VOut>(_factory, _inner.Aggregate(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/CogroupedKStream.html#aggregate-org.apache.kafka.streams.kstream.Initializer-org.apache.kafka.streams.kstream.Named-org.apache.kafka.streams.kstream.Materialized-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KNetInitializer{VA}"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <param name="arg2"><see cref="KNetMaterialized{K, V}"/></param>
        /// <returns><see cref="KNetKTable{K, VOut}"/></returns>
        public KNetKTable<K, VOut> Aggregate(KNetInitializer<VOut> arg0, Org.Apache.Kafka.Streams.Kstream.Named arg1, KNetMaterialized<K, VOut> arg2)
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg2 is IGenericSerDesFactoryApplier applier2) applier2.Factory = _factory;
            return new KNetKTable<K, VOut>(_factory, _inner.Aggregate(arg0, arg1, arg2));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/CogroupedKStream.html#aggregate-org.apache.kafka.streams.kstream.Initializer-org.apache.kafka.streams.kstream.Named-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KNetInitializer{VA}"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <returns><see cref="KNetKTable{K, V}"/></returns>
        public KNetKTable<K, VOut> Aggregate(KNetInitializer<VOut> arg0, Org.Apache.Kafka.Streams.Kstream.Named arg1)
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KNetKTable<K, VOut>(_factory, _inner.Aggregate(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/CogroupedKStream.html#aggregate-org.apache.kafka.streams.kstream.Initializer-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KNetInitializer{VA}"/></param>
        /// <returns><see cref="KNetKTable{K, V}"/></returns>
        public KNetKTable<K, VOut> Aggregate(KNetInitializer<VOut> arg0)
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KNetKTable<K, VOut>(_factory, _inner.Aggregate(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/CogroupedKStream.html#windowedBy-org.apache.kafka.streams.kstream.SessionWindows-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.SessionWindows"/></param>
        /// <returns><see cref="KNetSessionWindowedCogroupedKStream{K, VOut}"/></returns>
        public KNetSessionWindowedCogroupedKStream<K, VOut> WindowedBy(Org.Apache.Kafka.Streams.Kstream.SessionWindows arg0)
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KNetSessionWindowedCogroupedKStream<K, VOut>(_factory, _inner.WindowedBy(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/CogroupedKStream.html#windowedBy-org.apache.kafka.streams.kstream.SlidingWindows-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.SlidingWindows"/></param>
        /// <returns><see cref="KNetTimeWindowedCogroupedKStream{K, VOut}"/></returns>
        public KNetTimeWindowedCogroupedKStream<K, VOut> WindowedBy(Org.Apache.Kafka.Streams.Kstream.SlidingWindows arg0)
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KNetTimeWindowedCogroupedKStream<K, VOut>(_factory, _inner.WindowedBy(arg0));
        }

        #endregion
    }
}
