/*
*  Copyright 2025 MASES s.r.l.
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
using MASES.KNet.Streams.Processor;

namespace MASES.KNet.Streams.Kstream
{
    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.KStream{TJVMK, TJVMV}"/>
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
    /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
    public class KStream<K, V, TJVMK, TJVMV> : IGenericSerDesFactoryApplier
    {
        Org.Apache.Kafka.Streams.Kstream.KStream<TJVMK, TJVMV> _inner;

        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        internal KStream(IGenericSerDesFactory factory, Org.Apache.Kafka.Streams.Kstream.KStream<TJVMK, TJVMV> inner)
        {
            _factory = factory;
            _inner = inner;
        }

        /// <summary>
        /// Converter from <see cref="KStream{K, V, TJVMK, TJVMV}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.KStream{TJVMK, TJVMV}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.KStream<TJVMK, TJVMV>(KStream<K, V, TJVMK, TJVMV> t) => t._inner;

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#join-GlobalKTable{K, V, TJVMK, TJVMV}-KeyValueMapper{K, V, VR, TJVMK, TJVMV, TJVMVR}-org.apache.kafka.streams.kstream.ValueJoiner-org.apache.kafka.streams.kstream.Named-"/>
        /// </summary>
        /// <param name="arg0"><see cref="GlobalKTable{K, V, TJVMK, TJVMV}"/></param>
        /// <param name="arg1"><see cref="KeyValueMapper{K, V, VR, TJVMK, TJVMV, TJVMVR}"/></param>
        /// <param name="arg2"><see cref="ValueJoiner{V1, V2, VR, TJVMV1, TJVMV2, TJVMVR}"/></param>
        /// <param name="arg3"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <typeparam name="RV"></typeparam>
        /// <typeparam name="GK"></typeparam>
        /// <typeparam name="GV"></typeparam>
        /// <typeparam name="TJVMRV">The JVM type of <typeparamref name="RV"/></typeparam>
        /// <typeparam name="TJVMGK">The JVM type of <typeparamref name="GK"/></typeparam>
        /// <typeparam name="TJVMGV">The JVM type of <typeparamref name="GV"/></typeparam>
        /// <typeparam name="Arg1objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg1ExtendsGK"><typeparamref name="GK"/></typeparam>
        /// <typeparam name="Arg2objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg2objectSuperGV"><typeparamref name="GV"/></typeparam>
        /// <typeparam name="Arg2ExtendsRV"><typeparamref name="RV"/></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, RV, TJVMK, TJVMRV> Join<RV, GK, GV, TJVMRV, TJVMGK, TJVMGV, Arg1objectSuperK, Arg1objectSuperV, Arg1ExtendsGK, Arg2objectSuperV, Arg2objectSuperGV, Arg2ExtendsRV>(GlobalKTable<GK, GV, TJVMGK, TJVMGV> arg0, KeyValueMapper<Arg1objectSuperK, Arg1objectSuperV, Arg1ExtendsGK, TJVMK, TJVMV, TJVMGK> arg1, ValueJoiner<Arg2objectSuperV, Arg2objectSuperGV, Arg2ExtendsRV, TJVMV, TJVMGV, TJVMRV> arg2, Org.Apache.Kafka.Streams.Kstream.Named arg3) where Arg1objectSuperK : K where Arg1objectSuperV : V where Arg1ExtendsGK : GK where Arg2objectSuperV : V where Arg2objectSuperGV : GV where Arg2ExtendsRV : RV
        {
            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            if (arg2 is IGenericSerDesFactoryApplier applier2) applier2.Factory = _factory;
            return new KStream<K, RV, TJVMK, TJVMRV>(_factory, _inner.Join<TJVMRV, TJVMGK, TJVMGV, TJVMK, TJVMV, TJVMGK, TJVMV, TJVMGV, TJVMRV>(arg0, arg1, arg2, arg3));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#join-GlobalKTable{K, V, TJVMK, TJVMV}-KeyValueMapper{K, V, VR, TJVMK, TJVMV, TJVMVR}-org.apache.kafka.streams.kstream.ValueJoiner-"/>
        /// </summary>
        /// <param name="arg0"><see cref="GlobalKTable{K, V, TJVMK, TJVMV}"/></param>
        /// <param name="arg1"><see cref="KeyValueMapper{K, V, VR, TJVMK, TJVMV, TJVMVR}"/></param>
        /// <param name="arg2"><see cref="ValueJoiner{V1, V2, VR, TJVMV1, TJVMV2, TJVMVR}"/></param>
        /// <typeparam name="RV"></typeparam>
        /// <typeparam name="GK"></typeparam>
        /// <typeparam name="GV"></typeparam>
        /// <typeparam name="TJVMRV">The JVM type of <typeparamref name="RV"/></typeparam>
        /// <typeparam name="TJVMGK">The JVM type of <typeparamref name="GK"/></typeparam>
        /// <typeparam name="TJVMGV">The JVM type of <typeparamref name="GV"/></typeparam>
        /// <typeparam name="Arg1objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg1ExtendsGK"><typeparamref name="GK"/></typeparam>
        /// <typeparam name="Arg2objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg2objectSuperGV"><typeparamref name="GV"/></typeparam>
        /// <typeparam name="Arg2ExtendsRV"><typeparamref name="RV"/></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, RV, TJVMK, TJVMRV> Join<RV, GK, GV, TJVMRV, TJVMGK, TJVMGV, Arg1objectSuperK, Arg1objectSuperV, Arg1ExtendsGK, Arg2objectSuperV, Arg2objectSuperGV, Arg2ExtendsRV>(GlobalKTable<GK, GV, TJVMGK, TJVMGV> arg0, KeyValueMapper<Arg1objectSuperK, Arg1objectSuperV, Arg1ExtendsGK, TJVMK, TJVMV, TJVMGK> arg1, ValueJoiner<Arg2objectSuperV, Arg2objectSuperGV, Arg2ExtendsRV, TJVMV, TJVMGV, TJVMRV> arg2) where Arg1objectSuperK : K where Arg1objectSuperV : V where Arg1ExtendsGK : GK where Arg2objectSuperV : V where Arg2objectSuperGV : GV where Arg2ExtendsRV : RV
        {
            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            if (arg2 is IGenericSerDesFactoryApplier applier2) applier2.Factory = _factory;
            return new KStream<K, RV, TJVMK, TJVMRV>(_factory, _inner.Join<TJVMRV, TJVMGK, TJVMGV, TJVMK, TJVMV, TJVMGK, TJVMV, TJVMGV, TJVMRV>(arg0, arg1, arg2));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#join-GlobalKTable{K, V, TJVMK, TJVMV}-KeyValueMapper{K, V, VR, TJVMK, TJVMV, TJVMVR}-org.apache.kafka.streams.kstream.ValueJoinerWithKey-org.apache.kafka.streams.kstream.Named-"/>
        /// </summary>
        /// <param name="arg0"><see cref="GlobalKTable{K, V, TJVMK, TJVMV}"/></param>
        /// <param name="arg1"><see cref="KeyValueMapper{K, V, VR, TJVMK, TJVMV, TJVMVR}"/></param>
        /// <param name="arg2"><see cref="ValueJoinerWithKey{K1, V1, V2, VR, TJVMK1, TJVMV1, TJVMV2, TJVMVR}"/></param>
        /// <param name="arg3"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <typeparam name="RV"></typeparam>
        /// <typeparam name="GK"></typeparam>
        /// <typeparam name="GV"></typeparam>
        /// <typeparam name="TJVMRV">The JVM type of <typeparamref name="RV"/></typeparam>
        /// <typeparam name="TJVMGK">The JVM type of <typeparamref name="GK"/></typeparam>
        /// <typeparam name="TJVMGV">The JVM type of <typeparamref name="GV"/></typeparam>
        /// <typeparam name="Arg1objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg1ExtendsGK"><typeparamref name="GK"/></typeparam>
        /// <typeparam name="Arg2objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg2objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg2objectSuperGV"><typeparamref name="GV"/></typeparam>
        /// <typeparam name="Arg2ExtendsRV"><typeparamref name="RV"/></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, RV, TJVMK, TJVMRV> Join<RV, GK, GV, TJVMRV, TJVMGK, TJVMGV, Arg1objectSuperK, Arg1objectSuperV, Arg1ExtendsGK, Arg2objectSuperK, Arg2objectSuperV, Arg2objectSuperGV, Arg2ExtendsRV>(GlobalKTable<GK, GV, TJVMGK, TJVMGV> arg0, KeyValueMapper<Arg1objectSuperK, Arg1objectSuperV, Arg1ExtendsGK, TJVMK, TJVMV, TJVMGK> arg1, ValueJoinerWithKey<Arg2objectSuperK, Arg2objectSuperV, Arg2objectSuperGV, Arg2ExtendsRV, TJVMK, TJVMV, TJVMGV, TJVMRV> arg2, Org.Apache.Kafka.Streams.Kstream.Named arg3) where Arg1objectSuperK : K where Arg1objectSuperV : V where Arg1ExtendsGK : GK where Arg2objectSuperK : K where Arg2objectSuperV : V where Arg2objectSuperGV : GV where Arg2ExtendsRV : RV
        {
            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            if (arg2 is IGenericSerDesFactoryApplier applier2) applier2.Factory = _factory;
            return new KStream<K, RV, TJVMK, TJVMRV>(_factory, _inner.Join<TJVMRV, TJVMGK, TJVMGV, TJVMK, TJVMV, TJVMGK, TJVMK, TJVMV, TJVMGV, TJVMRV>(arg0, arg1, arg2, arg3));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#join-GlobalKTable{K, V, TJVMK, TJVMV}-KeyValueMapper{K, V, VR, TJVMK, TJVMV, TJVMVR}-org.apache.kafka.streams.kstream.ValueJoinerWithKey-"/>
        /// </summary>
        /// <param name="arg0"><see cref="GlobalKTable{K, V, TJVMK, TJVMV}"/></param>
        /// <param name="arg1"><see cref="KeyValueMapper{K, V, VR, TJVMK, TJVMV, TJVMVR}"/></param>
        /// <param name="arg2"><see cref="ValueJoinerWithKey{K1, V1, V2, VR, TJVMK1, TJVMV1, TJVMV2, TJVMVR}"/></param>
        /// <typeparam name="RV"></typeparam>
        /// <typeparam name="GK"></typeparam>
        /// <typeparam name="GV"></typeparam>
        /// <typeparam name="TJVMRV">The JVM type of <typeparamref name="RV"/></typeparam>
        /// <typeparam name="TJVMGK">The JVM type of <typeparamref name="GK"/></typeparam>
        /// <typeparam name="TJVMGV">The JVM type of <typeparamref name="GV"/></typeparam>
        /// <typeparam name="Arg1objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg1ExtendsGK"><typeparamref name="GK"/></typeparam>
        /// <typeparam name="Arg2objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg2objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg2objectSuperGV"><typeparamref name="GV"/></typeparam>
        /// <typeparam name="Arg2ExtendsRV"><typeparamref name="RV"/></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, RV, TJVMK, TJVMRV> Join<RV, GK, GV, TJVMRV, TJVMGK, TJVMGV, Arg1objectSuperK, Arg1objectSuperV, Arg1ExtendsGK, Arg2objectSuperK, Arg2objectSuperV, Arg2objectSuperGV, Arg2ExtendsRV>(GlobalKTable<GK, GV, TJVMGK, TJVMGV> arg0, KeyValueMapper<Arg1objectSuperK, Arg1objectSuperV, Arg1ExtendsGK, TJVMK, TJVMV, TJVMGK> arg1, ValueJoinerWithKey<Arg2objectSuperK, Arg2objectSuperV, Arg2objectSuperGV, Arg2ExtendsRV, TJVMK, TJVMV, TJVMGV, TJVMRV> arg2) where Arg1objectSuperK : K where Arg1objectSuperV : V where Arg1ExtendsGK : GK where Arg2objectSuperK : K where Arg2objectSuperV : V where Arg2objectSuperGV : GV where Arg2ExtendsRV : RV
        {
            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            if (arg2 is IGenericSerDesFactoryApplier applier2) applier2.Factory = _factory;
            return new KStream<K, RV, TJVMK, TJVMRV>(_factory, _inner.Join<TJVMRV, TJVMGK, TJVMGV, TJVMK, TJVMV, TJVMGK, TJVMK, TJVMV, TJVMGV, TJVMRV>(arg0, arg1, arg2));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#leftJoin-GlobalKTable{K, V, TJVMK, TJVMV}-KeyValueMapper{K, V, VR, TJVMK, TJVMV, TJVMVR}-org.apache.kafka.streams.kstream.ValueJoiner-org.apache.kafka.streams.kstream.Named-"/>
        /// </summary>
        /// <param name="arg0"><see cref="GlobalKTable{K, V, TJVMK, TJVMV}"/></param>
        /// <param name="arg1"><see cref="KeyValueMapper{K, V, VR, TJVMK, TJVMV, TJVMVR}"/></param>
        /// <param name="arg2"><see cref="ValueJoiner{V1, V2, VR, TJVMV1, TJVMV2, TJVMVR}"/></param>
        /// <param name="arg3"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <typeparam name="RV"></typeparam>
        /// <typeparam name="GK"></typeparam>
        /// <typeparam name="GV"></typeparam>
        /// <typeparam name="TJVMRV">The JVM type of <typeparamref name="RV"/></typeparam>
        /// <typeparam name="TJVMGK">The JVM type of <typeparamref name="GK"/></typeparam>
        /// <typeparam name="TJVMGV">The JVM type of <typeparamref name="GV"/></typeparam>
        /// <typeparam name="Arg1objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg1ExtendsGK"><typeparamref name="GK"/></typeparam>
        /// <typeparam name="Arg2objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg2objectSuperGV"><typeparamref name="GV"/></typeparam>
        /// <typeparam name="Arg2ExtendsRV"><typeparamref name="RV"/></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, RV, TJVMK, TJVMRV> LeftJoin<RV, GK, GV, TJVMRV, TJVMGK, TJVMGV, Arg1objectSuperK, Arg1objectSuperV, Arg1ExtendsGK, Arg2objectSuperV, Arg2objectSuperGV, Arg2ExtendsRV>(GlobalKTable<GK, GV, TJVMGK, TJVMGV> arg0, KeyValueMapper<Arg1objectSuperK, Arg1objectSuperV, Arg1ExtendsGK, TJVMK, TJVMV, TJVMGK> arg1, ValueJoiner<Arg2objectSuperV, Arg2objectSuperGV, Arg2ExtendsRV, TJVMV, TJVMGV, TJVMRV> arg2, Org.Apache.Kafka.Streams.Kstream.Named arg3) where Arg1objectSuperK : K where Arg1objectSuperV : V where Arg1ExtendsGK : GK where Arg2objectSuperV : V where Arg2objectSuperGV : GV where Arg2ExtendsRV : RV
        {
            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            if (arg2 is IGenericSerDesFactoryApplier applier2) applier2.Factory = _factory;
            return new KStream<K, RV, TJVMK, TJVMRV>(_factory, _inner.LeftJoin<TJVMRV, TJVMGK, TJVMGV, TJVMK, TJVMV, TJVMGK, TJVMV, TJVMGV, TJVMRV>(arg0, arg1, arg2, arg3));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#leftJoin-GlobalKTable{K, V, TJVMK, TJVMV}-KeyValueMapper{K, V, VR, TJVMK, TJVMV, TJVMVR}-org.apache.kafka.streams.kstream.ValueJoiner-"/>
        /// </summary>
        /// <param name="arg0"><see cref="GlobalKTable{K, V, TJVMK, TJVMV}"/></param>
        /// <param name="arg1"><see cref="KeyValueMapper{K, V, VR, TJVMK, TJVMV, TJVMVR}"/></param>
        /// <param name="arg2"><see cref="ValueJoiner{V1, V2, VR, TJVMV1, TJVMV2, TJVMVR}"/></param>
        /// <typeparam name="RV"></typeparam>
        /// <typeparam name="GK"></typeparam>
        /// <typeparam name="GV"></typeparam>
        /// <typeparam name="TJVMRV">The JVM type of <typeparamref name="RV"/></typeparam>
        /// <typeparam name="TJVMGK">The JVM type of <typeparamref name="GK"/></typeparam>
        /// <typeparam name="TJVMGV">The JVM type of <typeparamref name="GV"/></typeparam>
        /// <typeparam name="Arg1objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg1ExtendsGK"><typeparamref name="GK"/></typeparam>
        /// <typeparam name="Arg2objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg2objectSuperGV"><typeparamref name="GV"/></typeparam>
        /// <typeparam name="Arg2ExtendsRV"><typeparamref name="RV"/></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, RV, TJVMK, TJVMRV> LeftJoin<RV, GK, GV, TJVMRV, TJVMGK, TJVMGV, Arg1objectSuperK, Arg1objectSuperV, Arg1ExtendsGK, Arg2objectSuperV, Arg2objectSuperGV, Arg2ExtendsRV>(GlobalKTable<GK, GV, TJVMGK, TJVMGV> arg0, KeyValueMapper<Arg1objectSuperK, Arg1objectSuperV, Arg1ExtendsGK, TJVMK, TJVMV, TJVMGK> arg1, ValueJoiner<Arg2objectSuperV, Arg2objectSuperGV, Arg2ExtendsRV, TJVMV, TJVMGV, TJVMRV> arg2) where Arg1objectSuperK : K where Arg1objectSuperV : V where Arg1ExtendsGK : GK where Arg2objectSuperV : V where Arg2objectSuperGV : GV where Arg2ExtendsRV : RV
        {
            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            if (arg2 is IGenericSerDesFactoryApplier applier2) applier2.Factory = _factory;
            return new KStream<K, RV, TJVMK, TJVMRV>(_factory, _inner.LeftJoin<TJVMRV, TJVMGK, TJVMGV, TJVMK, TJVMV, TJVMGK, TJVMV, TJVMGV, TJVMRV>(arg0, arg1, arg2));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#leftJoin-GlobalKTable{K, V, TJVMK, TJVMV}-KeyValueMapper{K, V, VR, TJVMK, TJVMV, TJVMVR}-org.apache.kafka.streams.kstream.ValueJoinerWithKey-org.apache.kafka.streams.kstream.Named-"/>
        /// </summary>
        /// <param name="arg0"><see cref="GlobalKTable{K, V, TJVMK, TJVMV}"/></param>
        /// <param name="arg1"><see cref="KeyValueMapper{K, V, VR, TJVMK, TJVMV, TJVMVR}"/></param>
        /// <param name="arg2"><see cref="ValueJoinerWithKey{K1, V1, V2, VR, TJVMK1, TJVMV1, TJVMV2, TJVMVR}"/></param>
        /// <param name="arg3"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <typeparam name="RV"></typeparam>
        /// <typeparam name="GK"></typeparam>
        /// <typeparam name="GV"></typeparam>
        /// <typeparam name="TJVMRV">The JVM type of <typeparamref name="RV"/></typeparam>
        /// <typeparam name="TJVMGK">The JVM type of <typeparamref name="GK"/></typeparam>
        /// <typeparam name="TJVMGV">The JVM type of <typeparamref name="GV"/></typeparam>
        /// <typeparam name="Arg1objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg1ExtendsGK"><typeparamref name="GK"/></typeparam>
        /// <typeparam name="Arg2objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg2objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg2objectSuperGV"><typeparamref name="GV"/></typeparam>
        /// <typeparam name="Arg2ExtendsRV"><typeparamref name="RV"/></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, RV, TJVMK, TJVMRV> LeftJoin<RV, GK, GV, TJVMRV, TJVMGK, TJVMGV, Arg1objectSuperK, Arg1objectSuperV, Arg1ExtendsGK, Arg2objectSuperK, Arg2objectSuperV, Arg2objectSuperGV, Arg2ExtendsRV>(GlobalKTable<GK, GV, TJVMGK, TJVMGV> arg0, KeyValueMapper<Arg1objectSuperK, Arg1objectSuperV, Arg1ExtendsGK, TJVMK, TJVMV, TJVMGK> arg1, ValueJoinerWithKey<Arg2objectSuperK, Arg2objectSuperV, Arg2objectSuperGV, Arg2ExtendsRV, TJVMK, TJVMV, TJVMGV, TJVMRV> arg2, Org.Apache.Kafka.Streams.Kstream.Named arg3) where Arg1objectSuperK : K where Arg1objectSuperV : V where Arg1ExtendsGK : GK where Arg2objectSuperK : K where Arg2objectSuperV : V where Arg2objectSuperGV : GV where Arg2ExtendsRV : RV
        {
            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            if (arg2 is IGenericSerDesFactoryApplier applier2) applier2.Factory = _factory;
            return new KStream<K, RV, TJVMK, TJVMRV>(_factory, _inner.LeftJoin<TJVMRV, TJVMGK, TJVMGV, TJVMK, TJVMV, TJVMGK, TJVMK, TJVMV, TJVMGV, TJVMRV>(arg0, arg1, arg2, arg3));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#leftJoin-GlobalKTable{K, V, TJVMK, TJVMV}-KeyValueMapper{K, V, VR, TJVMK, TJVMV, TJVMVR}-org.apache.kafka.streams.kstream.ValueJoinerWithKey-"/>
        /// </summary>
        /// <param name="arg0"><see cref="GlobalKTable{K, V, TJVMK, TJVMV}"/></param>
        /// <param name="arg1"><see cref="KeyValueMapper{K, V, VR, TJVMK, TJVMV, TJVMVR}"/></param>
        /// <param name="arg2"><see cref="ValueJoinerWithKey{K1, V1, V2, VR, TJVMK1, TJVMV1, TJVMV2, TJVMVR}"/></param>
        /// <typeparam name="RV"></typeparam>
        /// <typeparam name="GK"></typeparam>
        /// <typeparam name="GV"></typeparam>
        /// <typeparam name="TJVMRV">The JVM type of <typeparamref name="RV"/></typeparam>
        /// <typeparam name="TJVMGK">The JVM type of <typeparamref name="GK"/></typeparam>
        /// <typeparam name="TJVMGV">The JVM type of <typeparamref name="GV"/></typeparam>
        /// <typeparam name="Arg1objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg1ExtendsGK"><typeparamref name="GK"/></typeparam>
        /// <typeparam name="Arg2objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg2objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg2objectSuperGV"><typeparamref name="GV"/></typeparam>
        /// <typeparam name="Arg2ExtendsRV"><typeparamref name="RV"/></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, RV, TJVMK, TJVMRV> LeftJoin<RV, GK, GV, TJVMRV, TJVMGK, TJVMGV, Arg1objectSuperK, Arg1objectSuperV, Arg1ExtendsGK, Arg2objectSuperK, Arg2objectSuperV, Arg2objectSuperGV, Arg2ExtendsRV>(GlobalKTable<GK, GV, TJVMGK, TJVMGV> arg0, KeyValueMapper<Arg1objectSuperK, Arg1objectSuperV, Arg1ExtendsGK, TJVMK, TJVMV, TJVMGK> arg1, ValueJoinerWithKey<Arg2objectSuperK, Arg2objectSuperV, Arg2objectSuperGV, Arg2ExtendsRV, TJVMK, TJVMV, TJVMGV, TJVMRV> arg2) where Arg1objectSuperK : K where Arg1objectSuperV : V where Arg1ExtendsGK : GK where Arg2objectSuperK : K where Arg2objectSuperV : V where Arg2objectSuperGV : GV where Arg2ExtendsRV : RV
        {
            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            if (arg2 is IGenericSerDesFactoryApplier applier2) applier2.Factory = _factory;
            return new KStream<K, RV, TJVMK, TJVMRV>(_factory, _inner.LeftJoin<TJVMRV, TJVMGK, TJVMGV, TJVMK, TJVMV, TJVMGK, TJVMK, TJVMV, TJVMGV, TJVMRV>(arg0, arg1, arg2));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#flatMap-KeyValueMapper{K, V, VR, TJVMK, TJVMV, TJVMVR}-org.apache.kafka.streams.kstream.Named-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KeyValueMapper{K, V, VR, TJVMK, TJVMV, TJVMVR}"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <typeparam name="KR"></typeparam>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="TJVMKR">The JVM type of <typeparamref name="KR"/></typeparam>
        /// <typeparam name="TJVMVR">The JVM type of <typeparamref name="VR"/></typeparam>
        /// <typeparam name="Arg0objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg0ExtendsKR"><typeparamref name="KR"/></typeparam>
        /// <typeparam name="Arg0ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<KR, VR, TJVMKR, TJVMVR> FlatMap<KR, VR, TJVMKR, TJVMVR, Arg0objectSuperK, Arg0objectSuperV, Arg0ExtendsKR, Arg0ExtendsVR>(EnumerableKeyValueMapper<Arg0objectSuperK, Arg0objectSuperV, Arg0ExtendsKR, Arg0ExtendsVR, TJVMK, TJVMV, TJVMKR, TJVMVR> arg0, Org.Apache.Kafka.Streams.Kstream.Named arg1) where Arg0objectSuperK : K where Arg0objectSuperV : V where Arg0ExtendsKR : KR where Arg0ExtendsVR : VR
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KStream<KR, VR, TJVMKR, TJVMVR>(_factory, _inner.FlatMap<TJVMKR, TJVMVR, TJVMK, TJVMV, Java.Lang.Iterable<Org.Apache.Kafka.Streams.KeyValue<TJVMKR, TJVMVR>>, Org.Apache.Kafka.Streams.KeyValue<TJVMKR, TJVMVR>, TJVMKR, TJVMVR>(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#flatMap-KeyValueMapper{K, V, VR, TJVMK, TJVMV, TJVMVR}-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KeyValueMapper{K, V, VR, TJVMK, TJVMV, TJVMVR}"/></param>
        /// <typeparam name="KR"></typeparam>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="TJVMKR">The JVM type of <typeparamref name="KR"/></typeparam>
        /// <typeparam name="TJVMVR">The JVM type of <typeparamref name="VR"/></typeparam>
        /// <typeparam name="Arg0objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg0ExtendsKR"><typeparamref name="KR"/></typeparam>
        /// <typeparam name="Arg0ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<KR, VR, TJVMKR, TJVMVR> FlatMap<KR, VR, TJVMKR, TJVMVR, Arg0objectSuperK, Arg0objectSuperV, Arg0ExtendsKR, Arg0ExtendsVR>(EnumerableKeyValueMapper<Arg0objectSuperK, Arg0objectSuperV, Arg0ExtendsKR, Arg0ExtendsVR, TJVMK, TJVMV, TJVMKR, TJVMVR> arg0) where Arg0objectSuperK : K where Arg0objectSuperV : V where Arg0ExtendsKR : KR where Arg0ExtendsVR : VR
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KStream<KR, VR, TJVMKR, TJVMVR>(_factory, _inner.FlatMap<TJVMKR, TJVMVR, TJVMK, TJVMV, Java.Lang.Iterable<Org.Apache.Kafka.Streams.KeyValue<TJVMKR, TJVMVR>>, Org.Apache.Kafka.Streams.KeyValue<TJVMKR, TJVMVR>, TJVMKR, TJVMVR>(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#map-KeyValueMapper{K, V, VR, TJVMK, TJVMV, TJVMVR}-org.apache.kafka.streams.kstream.Named-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KeyValueMapper{K, V, VR, TJVMK, TJVMV, TJVMVR}"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <typeparam name="KR"></typeparam>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="TJVMKR">The JVM type of <typeparamref name="KR"/></typeparam>
        /// <typeparam name="TJVMVR">The JVM type of <typeparamref name="VR"/></typeparam>
        /// <typeparam name="Arg0objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg0ExtendsKR"><typeparamref name="KR"/></typeparam>
        /// <typeparam name="Arg0ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<KR, VR, TJVMKR, TJVMVR> Map<KR, VR, TJVMKR, TJVMVR, Arg0objectSuperK, Arg0objectSuperV, Arg0ExtendsKR, Arg0ExtendsVR>(KeyValueKeyValueMapper<Arg0objectSuperK, Arg0objectSuperV, Arg0ExtendsKR, Arg0ExtendsVR, TJVMK, TJVMV, TJVMKR, TJVMVR> arg0, Org.Apache.Kafka.Streams.Kstream.Named arg1) where Arg0objectSuperK : K where Arg0objectSuperV : V where Arg0ExtendsKR : KR where Arg0ExtendsVR : VR
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KStream<KR, VR, TJVMKR, TJVMVR>(_factory, _inner.Map<TJVMKR, TJVMVR, TJVMK, TJVMV, Org.Apache.Kafka.Streams.KeyValue<TJVMKR, TJVMVR>, TJVMKR, TJVMVR>(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#map-KeyValueMapper{K, V, VR, TJVMK, TJVMV, TJVMVR}-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KeyValueMapper{K, V, VR, TJVMK, TJVMV, TJVMVR}"/></param>
        /// <typeparam name="KR"></typeparam>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="TJVMKR">The JVM type of <typeparamref name="KR"/></typeparam>
        /// <typeparam name="TJVMVR">The JVM type of <typeparamref name="VR"/></typeparam>
        /// <typeparam name="Arg0objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg0ExtendsKR"><typeparamref name="KR"/></typeparam>
        /// <typeparam name="Arg0ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<KR, VR, TJVMKR, TJVMVR> Map<KR, VR, TJVMKR, TJVMVR, Arg0objectSuperK, Arg0objectSuperV, Arg0ExtendsKR, Arg0ExtendsVR>(KeyValueKeyValueMapper<Arg0objectSuperK, Arg0objectSuperV, Arg0ExtendsKR, Arg0ExtendsVR, TJVMK, TJVMV, TJVMKR, TJVMVR> arg0) where Arg0objectSuperK : K where Arg0objectSuperV : V where Arg0ExtendsKR : KR where Arg0ExtendsVR : VR
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KStream<KR, VR, TJVMKR, TJVMVR>(_factory, _inner.Map<TJVMKR, TJVMVR, TJVMK, TJVMV, Org.Apache.Kafka.Streams.KeyValue<TJVMKR, TJVMVR>, TJVMKR, TJVMVR>(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#groupBy-KeyValueMapper{K, V, VR, TJVMK, TJVMV, TJVMVR}-org.apache.kafka.streams.kstream.Grouped-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KeyValueMapper{K, V, VR, TJVMK, TJVMV, TJVMVR}"/></param>
        /// <param name="arg1"><see cref="Grouped{K, V, TJVMK, TJVMV}"/></param>
        /// <typeparam name="KR"></typeparam>
        /// <typeparam name="TJVMKR">The JVM type of <typeparamref name="KR"/></typeparam>
        /// <typeparam name="Arg0objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="KGroupedStream{K, V, TJVMK, TJVMV}"/></returns>
        public KGroupedStream<KR, V, TJVMKR, TJVMV> GroupBy<KR, TJVMKR, Arg0objectSuperK, Arg0objectSuperV>(KeyValueMapper<Arg0objectSuperK, Arg0objectSuperV, KR, TJVMK, TJVMV, TJVMKR> arg0, Grouped<KR, V, TJVMKR, TJVMV> arg1) where Arg0objectSuperK : K where Arg0objectSuperV : V
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            return new KGroupedStream<KR, V, TJVMKR, TJVMV>(_factory, _inner.GroupBy<TJVMKR, TJVMK, TJVMV>(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#groupBy-KeyValueMapper{K, V, VR, TJVMK, TJVMV, TJVMVR}-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KeyValueMapper{K, V, VR, TJVMK, TJVMV, TJVMVR}"/></param>
        /// <typeparam name="KR"></typeparam>
        /// <typeparam name="TJVMKR">The JVM type of <typeparamref name="KR"/></typeparam>
        /// <typeparam name="Arg0objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="KGroupedStream{K, V, TJVMK, TJVMV}"/></returns>
        public KGroupedStream<KR, V, TJVMKR, TJVMV> GroupBy<KR, TJVMKR, Arg0objectSuperK, Arg0objectSuperV>(KeyValueMapper<Arg0objectSuperK, Arg0objectSuperV, KR, TJVMK, TJVMV, TJVMKR> arg0) where Arg0objectSuperK : K where Arg0objectSuperV : V
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KGroupedStream<KR, V, TJVMKR, TJVMV>(_factory, _inner.GroupBy<TJVMKR, TJVMK, TJVMV>(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#selectKey-KeyValueMapper{K, V, VR, TJVMK, TJVMV, TJVMVR}-org.apache.kafka.streams.kstream.Named-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KeyValueMapper{K, V, VR, TJVMK, TJVMV, TJVMVR}"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <typeparam name="KR"></typeparam>
        /// <typeparam name="TJVMKR">The JVM type of <typeparamref name="KR"/></typeparam>
        /// <typeparam name="Arg0objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg0ExtendsKR"><typeparamref name="KR"/></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<KR, V, TJVMKR, TJVMV> SelectKey<KR, TJVMKR, Arg0objectSuperK, Arg0objectSuperV, Arg0ExtendsKR>(KeyValueMapper<Arg0objectSuperK, Arg0objectSuperV, Arg0ExtendsKR, TJVMK, TJVMV, TJVMKR> arg0, Org.Apache.Kafka.Streams.Kstream.Named arg1) where Arg0objectSuperK : K where Arg0objectSuperV : V where Arg0ExtendsKR : KR
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KStream<KR, V, TJVMKR, TJVMV>(_factory, _inner.SelectKey<TJVMKR, TJVMK, TJVMV, TJVMKR>(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#selectKey-KeyValueMapper{K, V, VR, TJVMK, TJVMV, TJVMVR}-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KeyValueMapper{K, V, VR, TJVMK, TJVMV, TJVMVR}"/></param>
        /// <typeparam name="KR"></typeparam>
        /// <typeparam name="TJVMKR">The JVM type of <typeparamref name="KR"/></typeparam>
        /// <typeparam name="Arg0objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg0ExtendsKR"><typeparamref name="KR"/></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<KR, V, TJVMKR, TJVMV> SelectKey<KR, TJVMKR, Arg0objectSuperK, Arg0objectSuperV, Arg0ExtendsKR>(KeyValueMapper<Arg0objectSuperK, Arg0objectSuperV, Arg0ExtendsKR, TJVMK, TJVMV, TJVMKR> arg0) where Arg0objectSuperK : K where Arg0objectSuperV : V where Arg0ExtendsKR : KR
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KStream<KR, V, TJVMKR, TJVMV>(_factory, _inner.SelectKey<TJVMKR, TJVMK, TJVMV, TJVMKR>(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#join-org.apache.kafka.streams.kstream.KStream-org.apache.kafka.streams.kstream.ValueJoiner-org.apache.kafka.streams.kstream.JoinWindows-org.apache.kafka.streams.kstream.StreamJoined-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KStream{K, V, TJVMK, TJVMV}"/></param>
        /// <param name="arg1"><see cref="ValueJoiner{V1, V2, VR, TJVMV1, TJVMV2, TJVMVR}"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Kstream.JoinWindows"/></param>
        /// <param name="arg3"><see cref="StreamJoined{K, V1, V2, TJVMK, TJVMV1, TJVMV2}"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="VO"></typeparam>
        /// <typeparam name="TJVMVR">The JVM type of <typeparamref name="VR"/></typeparam>
        /// <typeparam name="TJVMVO">The JVM type of <typeparamref name="VO"/></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg1objectSuperVO"><typeparamref name="VO"/></typeparam>
        /// <typeparam name="Arg1ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, VR, TJVMK, TJVMVR> Join<VR, VO, TJVMVR, TJVMVO, Arg1objectSuperV, Arg1objectSuperVO, Arg1ExtendsVR>(KStream<K, VO, TJVMK, TJVMVO> arg0, ValueJoiner<Arg1objectSuperV, Arg1objectSuperVO, Arg1ExtendsVR, TJVMV, TJVMVO, TJVMVR> arg1, Org.Apache.Kafka.Streams.Kstream.JoinWindows arg2, StreamJoined<K, V, VO, TJVMK, TJVMV, TJVMVO> arg3) where Arg1objectSuperV : V where Arg1objectSuperVO : VO where Arg1ExtendsVR : VR
        {
            if (arg1 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg3 is IGenericSerDesFactoryApplier applier3) applier3.Factory = _factory;
            return new KStream<K, VR, TJVMK, TJVMVR>(_factory, _inner.Join<TJVMVR, TJVMVO, TJVMV, TJVMVO, TJVMVR>(arg0, arg1, arg2, arg3));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#join-org.apache.kafka.streams.kstream.KStream-org.apache.kafka.streams.kstream.ValueJoiner-org.apache.kafka.streams.kstream.JoinWindows-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KStream{K, VO, TJVMK, TJVMVO}"/></param>
        /// <param name="arg1"><see cref="ValueJoiner{V1, V2, VR, TJVMV1, TJVMV2, TJVMVR}"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Kstream.JoinWindows"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="VO"></typeparam>
        /// <typeparam name="TJVMVR">The JVM type of <typeparamref name="VR"/></typeparam>
        /// <typeparam name="TJVMVO">The JVM type of <typeparamref name="VO"/></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg1objectSuperVO"><typeparamref name="VO"/></typeparam>
        /// <typeparam name="Arg1ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="KStream{K, VR, TJVMK, TJVMVR}"/></returns>
        public KStream<K, VR, TJVMK, TJVMVR> Join<VR, VO, TJVMVR, TJVMVO, Arg1objectSuperV, Arg1objectSuperVO, Arg1ExtendsVR>(KStream<K, VO, TJVMK, TJVMVO> arg0, ValueJoiner<Arg1objectSuperV, Arg1objectSuperVO, Arg1ExtendsVR, TJVMV, TJVMVO, TJVMVR> arg1, Org.Apache.Kafka.Streams.Kstream.JoinWindows arg2) where Arg1objectSuperV : V where Arg1objectSuperVO : VO where Arg1ExtendsVR : VR
        {
            if (arg1 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KStream<K, VR, TJVMK, TJVMVR>(_factory, _inner.Join<TJVMVR, TJVMVO, TJVMV, TJVMVO, TJVMVR>(arg0, arg1, arg2));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#join-org.apache.kafka.streams.kstream.KStream-org.apache.kafka.streams.kstream.ValueJoinerWithKey-org.apache.kafka.streams.kstream.JoinWindows-org.apache.kafka.streams.kstream.StreamJoined-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KStream{K, VO, TJVMK, TJVMVO}"/></param>
        /// <param name="arg1"><see cref="ValueJoinerWithKey{K1, V1, V2, VR, TJVMK1, TJVMV1, TJVMV2, TJVMVR}"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Kstream.JoinWindows"/></param>
        /// <param name="arg3"><see cref="StreamJoined{K, V1, V2, TJVMK, TJVMV1, TJVMV2}"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="VO"></typeparam>
        /// <typeparam name="TJVMVR">The JVM type of <typeparamref name="VR"/></typeparam>
        /// <typeparam name="TJVMVO">The JVM type of <typeparamref name="VO"/></typeparam>
        /// <typeparam name="Arg1objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg1objectSuperVO"><typeparamref name="VO"/></typeparam>
        /// <typeparam name="Arg1ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="KStream{K, VR, TJVMK, TJVMVR}"/></returns>
        public KStream<K, VR, TJVMK, TJVMVR> Join<VR, VO, TJVMVR, TJVMVO, Arg1objectSuperK, Arg1objectSuperV, Arg1objectSuperVO, Arg1ExtendsVR>(KStream<K, VO, TJVMK, TJVMVO> arg0, ValueJoinerWithKey<Arg1objectSuperK, Arg1objectSuperV, Arg1objectSuperVO, Arg1ExtendsVR, TJVMK, TJVMV, TJVMVO, TJVMVR> arg1, Org.Apache.Kafka.Streams.Kstream.JoinWindows arg2, StreamJoined<K, V, VO, TJVMK, TJVMV, TJVMVO> arg3) where Arg1objectSuperK : K where Arg1objectSuperV : V where Arg1objectSuperVO : VO where Arg1ExtendsVR : VR
        {
            if (arg1 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg3 is IGenericSerDesFactoryApplier applier3) applier3.Factory = _factory;
            return new KStream<K, VR, TJVMK, TJVMVR>(_factory, _inner.Join<TJVMVR, TJVMVO, TJVMK, TJVMV, TJVMVO, TJVMVR>(arg0, arg1, arg2, arg3));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#join-org.apache.kafka.streams.kstream.KStream-org.apache.kafka.streams.kstream.ValueJoinerWithKey-org.apache.kafka.streams.kstream.JoinWindows-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KStream{K, V, TJVMK, TJVMV}"/></param>
        /// <param name="arg1"><see cref="ValueJoinerWithKey{K1, V1, V2, VR, TJVMK1, TJVMV1, TJVMV2, TJVMVR}"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Kstream.JoinWindows"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="VO"></typeparam>
        /// <typeparam name="TJVMVR">The JVM type of <typeparamref name="VR"/></typeparam>
        /// <typeparam name="TJVMVO">The JVM type of <typeparamref name="VO"/></typeparam>
        /// <typeparam name="Arg1objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg1objectSuperVO"><typeparamref name="VO"/></typeparam>
        /// <typeparam name="Arg1ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, VR, TJVMK, TJVMVR> Join<VR, VO, TJVMVR, TJVMVO, Arg1objectSuperK, Arg1objectSuperV, Arg1objectSuperVO, Arg1ExtendsVR>(KStream<K, VO, TJVMK, TJVMVO> arg0, ValueJoinerWithKey<Arg1objectSuperK, Arg1objectSuperV, Arg1objectSuperVO, Arg1ExtendsVR, TJVMK, TJVMV, TJVMVO, TJVMVR> arg1, Org.Apache.Kafka.Streams.Kstream.JoinWindows arg2) where Arg1objectSuperK : K where Arg1objectSuperV : V where Arg1objectSuperVO : VO where Arg1ExtendsVR : VR
        {
            if (arg1 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KStream<K, VR, TJVMK, TJVMVR>(_factory, _inner.LeftJoin<TJVMVR, TJVMVO, TJVMK, TJVMV, TJVMVO, TJVMVR>(arg0, arg1, arg2));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#leftJoin-org.apache.kafka.streams.kstream.KStream-org.apache.kafka.streams.kstream.ValueJoiner-org.apache.kafka.streams.kstream.JoinWindows-org.apache.kafka.streams.kstream.StreamJoined-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KStream{K, V, TJVMK, TJVMV}"/></param>
        /// <param name="arg1"><see cref="ValueJoiner{V1, V2, VR, TJVMV1, TJVMV2, TJVMVR}"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Kstream.JoinWindows"/></param>
        /// <param name="arg3"><see cref="StreamJoined{K, V1, V2, TJVMK, TJVMV1, TJVMV2}"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="VO"></typeparam>
        /// <typeparam name="TJVMVR">The JVM type of <typeparamref name="VR"/></typeparam>
        /// <typeparam name="TJVMVO">The JVM type of <typeparamref name="VO"/></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg1objectSuperVO"><typeparamref name="VO"/></typeparam>
        /// <typeparam name="Arg1ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, VR, TJVMK, TJVMVR> LeftJoin<VR, VO, TJVMVR, TJVMVO, Arg1objectSuperV, Arg1objectSuperVO, Arg1ExtendsVR>(KStream<K, VO, TJVMK, TJVMVO> arg0, ValueJoiner<Arg1objectSuperV, Arg1objectSuperVO, Arg1ExtendsVR, TJVMV, TJVMVO, TJVMVR> arg1, Org.Apache.Kafka.Streams.Kstream.JoinWindows arg2, StreamJoined<K, V, VO, TJVMK, TJVMV, TJVMVO> arg3) where Arg1objectSuperV : V where Arg1objectSuperVO : VO where Arg1ExtendsVR : VR
        {
            if (arg1 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg3 is IGenericSerDesFactoryApplier applier3) applier3.Factory = _factory;
            return new KStream<K, VR, TJVMK, TJVMVR>(_factory, _inner.LeftJoin<TJVMVR, TJVMVO, TJVMV, TJVMVO, TJVMVR>(arg0, arg1, arg2, arg3));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#leftJoin-org.apache.kafka.streams.kstream.KStream-org.apache.kafka.streams.kstream.ValueJoiner-org.apache.kafka.streams.kstream.JoinWindows-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KStream{K, V, TJVMK, TJVMV}"/></param>
        /// <param name="arg1"><see cref="ValueJoiner{V1, V2, VR, TJVMV1, TJVMV2, TJVMVR}"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Kstream.JoinWindows"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="VO"></typeparam>
        /// <typeparam name="TJVMVR">The JVM type of <typeparamref name="VR"/></typeparam>
        /// <typeparam name="TJVMVO">The JVM type of <typeparamref name="VO"/></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg1objectSuperVO"><typeparamref name="VO"/></typeparam>
        /// <typeparam name="Arg1ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, VR, TJVMK, TJVMVR> LeftJoin<VR, VO, TJVMVR, TJVMVO, Arg1objectSuperV, Arg1objectSuperVO, Arg1ExtendsVR>(KStream<K, VO, TJVMK, TJVMVO> arg0, ValueJoiner<Arg1objectSuperV, Arg1objectSuperVO, Arg1ExtendsVR, TJVMV, TJVMVO, TJVMVR> arg1, Org.Apache.Kafka.Streams.Kstream.JoinWindows arg2) where Arg1objectSuperV : V where Arg1objectSuperVO : VO where Arg1ExtendsVR : VR
        {
            if (arg1 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KStream<K, VR, TJVMK, TJVMVR>(_factory, _inner.LeftJoin<TJVMVR, TJVMVO, TJVMV, TJVMVO, TJVMVR>(arg0, arg1, arg2));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#leftJoin-org.apache.kafka.streams.kstream.KStream-org.apache.kafka.streams.kstream.ValueJoinerWithKey-org.apache.kafka.streams.kstream.JoinWindows-org.apache.kafka.streams.kstream.StreamJoined-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KStream{K, V, TJVMK, TJVMV}"/></param>
        /// <param name="arg1"><see cref="ValueJoinerWithKey{K1, V1, V2, VR, TJVMK1, TJVMV1, TJVMV2, TJVMVR}"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Kstream.JoinWindows"/></param>
        /// <param name="arg3"><see cref="StreamJoined{K, V1, V2, TJVMK, TJVMV1, TJVMV2}"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="VO"></typeparam>
        /// <typeparam name="TJVMVR">The JVM type of <typeparamref name="VR"/></typeparam>
        /// <typeparam name="TJVMVO">The JVM type of <typeparamref name="VO"/></typeparam>
        /// <typeparam name="Arg1objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg1objectSuperVO"><typeparamref name="VO"/></typeparam>
        /// <typeparam name="Arg1ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, VR, TJVMK, TJVMVR> LeftJoin<VR, VO, TJVMVR, TJVMVO, Arg1objectSuperK, Arg1objectSuperV, Arg1objectSuperVO, Arg1ExtendsVR>(KStream<K, VO, TJVMK, TJVMVO> arg0, ValueJoinerWithKey<Arg1objectSuperK, Arg1objectSuperV, Arg1objectSuperVO, Arg1ExtendsVR, TJVMK, TJVMV, TJVMVO, TJVMVR> arg1, Org.Apache.Kafka.Streams.Kstream.JoinWindows arg2, StreamJoined<K, V, VO, TJVMK, TJVMV, TJVMVO> arg3) where Arg1objectSuperK : K where Arg1objectSuperV : V where Arg1objectSuperVO : VO where Arg1ExtendsVR : VR
        {
            if (arg1 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg3 is IGenericSerDesFactoryApplier applier3) applier3.Factory = _factory;
            return new KStream<K, VR, TJVMK, TJVMVR>(_factory, _inner.LeftJoin<TJVMVR, TJVMVO, TJVMK, TJVMV, TJVMVO, TJVMVR>(arg0, arg1, arg2, arg3));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#leftJoin-org.apache.kafka.streams.kstream.KStream-org.apache.kafka.streams.kstream.ValueJoinerWithKey-org.apache.kafka.streams.kstream.JoinWindows-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KStream{K, V, TJVMK, TJVMV}"/></param>
        /// <param name="arg1"><see cref="ValueJoinerWithKey{K1, V1, V2, VR, TJVMK1, TJVMV1, TJVMV2, TJVMVR}"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Kstream.JoinWindows"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="VO"></typeparam>
        /// <typeparam name="TJVMVR">The JVM type of <typeparamref name="VR"/></typeparam>
        /// <typeparam name="TJVMVO">The JVM type of <typeparamref name="VO"/></typeparam>
        /// <typeparam name="Arg1objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg1objectSuperVO"><typeparamref name="VO"/></typeparam>
        /// <typeparam name="Arg1ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, VR, TJVMK, TJVMVR> LeftJoin<VR, VO, TJVMVR, TJVMVO, Arg1objectSuperK, Arg1objectSuperV, Arg1objectSuperVO, Arg1ExtendsVR>(KStream<K, VO, TJVMK, TJVMVO> arg0, ValueJoinerWithKey<Arg1objectSuperK, Arg1objectSuperV, Arg1objectSuperVO, Arg1ExtendsVR, TJVMK, TJVMV, TJVMVO, TJVMVR> arg1, Org.Apache.Kafka.Streams.Kstream.JoinWindows arg2) where Arg1objectSuperK : K where Arg1objectSuperV : V where Arg1objectSuperVO : VO where Arg1ExtendsVR : VR
        {
            if (arg1 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KStream<K, VR, TJVMK, TJVMVR>(_factory, _inner.LeftJoin<TJVMVR, TJVMVO, TJVMK, TJVMV, TJVMVO, TJVMVR>(arg0, arg1, arg2));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#outerJoin-org.apache.kafka.streams.kstream.KStream-org.apache.kafka.streams.kstream.ValueJoiner-org.apache.kafka.streams.kstream.JoinWindows-org.apache.kafka.streams.kstream.StreamJoined-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KStream{K, V, TJVMK, TJVMV}"/></param>
        /// <param name="arg1"><see cref="ValueJoiner{V1, V2, VR, TJVMV1, TJVMV2, TJVMVR}"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Kstream.JoinWindows"/></param>
        /// <param name="arg3"><see cref="StreamJoined{K, V1, V2, TJVMK, TJVMV1, TJVMV2}"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="VO"></typeparam>
        /// <typeparam name="TJVMVR">The JVM type of <typeparamref name="VR"/></typeparam>
        /// <typeparam name="TJVMVO">The JVM type of <typeparamref name="VO"/></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg1objectSuperVO"><typeparamref name="VO"/></typeparam>
        /// <typeparam name="Arg1ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, VR, TJVMK, TJVMVR> OuterJoin<VR, VO, TJVMVR, TJVMVO, Arg1objectSuperV, Arg1objectSuperVO, Arg1ExtendsVR>(KStream<K, VO, TJVMK, TJVMVO> arg0, ValueJoiner<Arg1objectSuperV, Arg1objectSuperVO, Arg1ExtendsVR, TJVMV, TJVMVO, TJVMVR> arg1, Org.Apache.Kafka.Streams.Kstream.JoinWindows arg2, StreamJoined<K, V, VO, TJVMK, TJVMV, TJVMVO> arg3) where Arg1objectSuperV : V where Arg1objectSuperVO : VO where Arg1ExtendsVR : VR
        {
            if (arg1 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg3 is IGenericSerDesFactoryApplier applier3) applier3.Factory = _factory;
            return new KStream<K, VR, TJVMK, TJVMVR>(_factory, _inner.OuterJoin<TJVMVR, TJVMVO, TJVMV, TJVMVO, TJVMVR>(arg0, arg1, arg2, arg3));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#outerJoin-org.apache.kafka.streams.kstream.KStream-org.apache.kafka.streams.kstream.ValueJoiner-org.apache.kafka.streams.kstream.JoinWindows-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KStream{K, V, TJVMK, TJVMV}"/></param>
        /// <param name="arg1"><see cref="ValueJoiner{V1, V2, VR, TJVMV1, TJVMV2, TJVMVR}"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Kstream.JoinWindows"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="VO"></typeparam>
        /// <typeparam name="TJVMVR">The JVM type of <typeparamref name="VR"/></typeparam>
        /// <typeparam name="TJVMVO">The JVM type of <typeparamref name="VO"/></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg1objectSuperVO"><typeparamref name="VO"/></typeparam>
        /// <typeparam name="Arg1ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, VR, TJVMK, TJVMVR> OuterJoin<VR, VO, TJVMVR, TJVMVO, Arg1objectSuperV, Arg1objectSuperVO, Arg1ExtendsVR>(KStream<K, VO, TJVMK, TJVMVO> arg0, ValueJoiner<Arg1objectSuperV, Arg1objectSuperVO, Arg1ExtendsVR, TJVMV, TJVMVO, TJVMVR> arg1, Org.Apache.Kafka.Streams.Kstream.JoinWindows arg2) where Arg1objectSuperV : V where Arg1objectSuperVO : VO where Arg1ExtendsVR : VR
        {
            if (arg1 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KStream<K, VR, TJVMK, TJVMVR>(_factory, _inner.OuterJoin<TJVMVR, TJVMVO, TJVMV, TJVMVO, TJVMVR>(arg0, arg1, arg2));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#outerJoin-org.apache.kafka.streams.kstream.KStream-org.apache.kafka.streams.kstream.ValueJoinerWithKey-org.apache.kafka.streams.kstream.JoinWindows-org.apache.kafka.streams.kstream.StreamJoined-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KStream{K, V, TJVMK, TJVMV}"/></param>
        /// <param name="arg1"><see cref="ValueJoinerWithKey{K1, V1, V2, VR, TJVMK1, TJVMV1, TJVMV2, TJVMVR}"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Kstream.JoinWindows"/></param>
        /// <param name="arg3"><see cref="StreamJoined{K, V1, V2, TJVMK, TJVMV1, TJVMV2}"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="VO"></typeparam>
        /// <typeparam name="TJVMVR">The JVM type of <typeparamref name="VR"/></typeparam>
        /// <typeparam name="TJVMVO">The JVM type of <typeparamref name="VO"/></typeparam>
        /// <typeparam name="Arg1objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg1objectSuperVO"><typeparamref name="VO"/></typeparam>
        /// <typeparam name="Arg1ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, VR, TJVMK, TJVMVR> OuterJoin<VR, VO, TJVMVR, TJVMVO, Arg1objectSuperK, Arg1objectSuperV, Arg1objectSuperVO, Arg1ExtendsVR>(KStream<K, VO, TJVMK, TJVMVO> arg0, ValueJoinerWithKey<Arg1objectSuperK, Arg1objectSuperV, Arg1objectSuperVO, Arg1ExtendsVR, TJVMK, TJVMV, TJVMVO, TJVMVR> arg1, Org.Apache.Kafka.Streams.Kstream.JoinWindows arg2, StreamJoined<K, V, VO, TJVMK, TJVMV, TJVMVO> arg3) where Arg1objectSuperK : K where Arg1objectSuperV : V where Arg1objectSuperVO : VO where Arg1ExtendsVR : VR
        {
            if (arg1 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg3 is IGenericSerDesFactoryApplier applier3) applier3.Factory = _factory;
            return new KStream<K, VR, TJVMK, TJVMVR>(_factory, _inner.OuterJoin<TJVMVR, TJVMVO, TJVMK, TJVMV, TJVMVO, TJVMVR>(arg0, arg1, arg2, arg3));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#outerJoin-org.apache.kafka.streams.kstream.KStream-org.apache.kafka.streams.kstream.ValueJoinerWithKey-org.apache.kafka.streams.kstream.JoinWindows-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KStream{K, V, TJVMK, TJVMV}"/></param>
        /// <param name="arg1"><see cref="ValueJoinerWithKey{K1, V1, V2, VR, TJVMK1, TJVMV1, TJVMV2, TJVMVR}"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Kstream.JoinWindows"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="VO"></typeparam>
        /// <typeparam name="TJVMVR">The JVM type of <typeparamref name="VR"/></typeparam>
        /// <typeparam name="TJVMVO">The JVM type of <typeparamref name="VO"/></typeparam>
        /// <typeparam name="Arg1objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg1objectSuperVO"><typeparamref name="VO"/></typeparam>
        /// <typeparam name="Arg1ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, VR, TJVMK, TJVMVR> OuterJoin<VR, VO, TJVMVR, TJVMVO, Arg1objectSuperK, Arg1objectSuperV, Arg1objectSuperVO, Arg1ExtendsVR>(KStream<K, VO, TJVMK, TJVMVO> arg0, ValueJoinerWithKey<Arg1objectSuperK, Arg1objectSuperV, Arg1objectSuperVO, Arg1ExtendsVR, TJVMK, TJVMV, TJVMVO, TJVMVR> arg1, Org.Apache.Kafka.Streams.Kstream.JoinWindows arg2) where Arg1objectSuperK : K where Arg1objectSuperV : V where Arg1objectSuperVO : VO where Arg1ExtendsVR : VR
        {
            if (arg1 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KStream<K, VR, TJVMK, TJVMVR>(_factory, _inner.OuterJoin<TJVMVR, TJVMVO, TJVMK, TJVMV, TJVMVO, TJVMVR>(arg0, arg1, arg2));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#flatMapValues-org.apache.kafka.streams.kstream.ValueMapper-org.apache.kafka.streams.kstream.Named-"/>
        /// </summary>
        /// <param name="arg0"><see cref="ValueMapper{V, VR, TJVMV, TJVMVR}"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="TJVMVR">The JVM type of <typeparamref name="VR"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg0ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, VR, TJVMK, TJVMVR> FlatMapValues<VR, TJVMVR, Arg0objectSuperV, Arg0ExtendsVR>(EnumerableValueMapper<Arg0objectSuperV, Arg0ExtendsVR, TJVMV, TJVMVR> arg0, Org.Apache.Kafka.Streams.Kstream.Named arg1) where Arg0objectSuperV : V where Arg0ExtendsVR : VR
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KStream<K, VR, TJVMK, TJVMVR>(_factory, _inner.FlatMapValues<TJVMVR, TJVMV, Java.Lang.Iterable<TJVMVR>, TJVMVR>(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#flatMapValues-org.apache.kafka.streams.kstream.ValueMapper-"/>
        /// </summary>
        /// <param name="arg0"><see cref="ValueMapper{V, VR, TJVMV, TJVMVR}"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="TJVMVR">The JVM type of <typeparamref name="VR"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg0ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, VR, TJVMK, TJVMVR> FlatMapValues<VR, TJVMVR, Arg0objectSuperV, Arg0ExtendsVR>(EnumerableValueMapper<Arg0objectSuperV, Arg0ExtendsVR, TJVMV, TJVMVR> arg0) where Arg0objectSuperV : V where Arg0ExtendsVR : VR
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KStream<K, VR, TJVMK, TJVMVR>(_factory, _inner.FlatMapValues<TJVMVR, TJVMV, Java.Lang.Iterable<TJVMVR>, TJVMVR>(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#flatMapValues-org.apache.kafka.streams.kstream.ValueMapperWithKey-org.apache.kafka.streams.kstream.Named-"/>
        /// </summary>
        /// <param name="arg0"><see cref="ValueMapperWithKey{K, V, VR, TJVMK, TJVMV, TJVMVR}"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="TJVMVR">The JVM type of <typeparamref name="VR"/></typeparam>
        /// <typeparam name="Arg0objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg0ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, VR, TJVMK, TJVMVR> FlatMapValues<VR, TJVMVR, Arg0objectSuperK, Arg0objectSuperV, Arg0ExtendsVR>(EnumerableValueMapperWithKey<Arg0objectSuperK, Arg0objectSuperV, Arg0ExtendsVR, TJVMK, TJVMV, TJVMVR> arg0, Org.Apache.Kafka.Streams.Kstream.Named arg1) where Arg0objectSuperK : K where Arg0objectSuperV : V where Arg0ExtendsVR : VR
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KStream<K, VR, TJVMK, TJVMVR>(_factory, _inner.FlatMapValues<TJVMVR, TJVMK, TJVMV, Java.Lang.Iterable<TJVMVR>, TJVMVR>(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#flatMapValues-org.apache.kafka.streams.kstream.ValueMapperWithKey-"/>
        /// </summary>
        /// <param name="arg0"><see cref="ValueMapperWithKey{K, V, VR, TJVMK, TJVMV, TJVMVR}"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="TJVMVR">The JVM type of <typeparamref name="VR"/></typeparam>
        /// <typeparam name="Arg0objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg0ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, VR, TJVMK, TJVMVR> FlatMapValues<VR, TJVMVR, Arg0objectSuperK, Arg0objectSuperV, Arg0ExtendsVR>(EnumerableValueMapperWithKey<Arg0objectSuperK, Arg0objectSuperV, Arg0ExtendsVR, TJVMK, TJVMV, TJVMVR> arg0) where Arg0objectSuperK : K where Arg0objectSuperV : V where Arg0ExtendsVR : VR
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KStream<K, VR, TJVMK, TJVMVR>(_factory, _inner.FlatMapValues<TJVMVR, TJVMK, TJVMV, Java.Lang.Iterable<TJVMVR>, TJVMVR>(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#mapValues-org.apache.kafka.streams.kstream.ValueMapper-org.apache.kafka.streams.kstream.Named-"/>
        /// </summary>
        /// <param name="arg0"><see cref="ValueMapper{V, VR, TJVMV, TJVMVR}"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="TJVMVR">The JVM type of <typeparamref name="VR"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg0ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, VR, TJVMK, TJVMVR> MapValues<VR, TJVMVR, Arg0objectSuperV, Arg0ExtendsVR>(ValueMapper<Arg0objectSuperV, Arg0ExtendsVR, TJVMV, TJVMVR> arg0, Org.Apache.Kafka.Streams.Kstream.Named arg1) where Arg0objectSuperV : V where Arg0ExtendsVR : VR
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KStream<K, VR, TJVMK, TJVMVR>(_factory, _inner.MapValues<TJVMVR, TJVMV, TJVMVR>(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#mapValues-org.apache.kafka.streams.kstream.ValueMapper-"/>
        /// </summary>
        /// <param name="arg0"><see cref="ValueMapper{V, VR, TJVMV, TJVMVR}"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="TJVMVR">The JVM type of <typeparamref name="VR"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg0ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, VR, TJVMK, TJVMVR> MapValues<VR, TJVMVR, Arg0objectSuperV, Arg0ExtendsVR>(ValueMapper<Arg0objectSuperV, Arg0ExtendsVR, TJVMV, TJVMVR> arg0) where Arg0objectSuperV : V where Arg0ExtendsVR : VR
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KStream<K, VR, TJVMK, TJVMVR>(_factory, _inner.MapValues<TJVMVR, TJVMV, TJVMVR>(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#mapValues-org.apache.kafka.streams.kstream.ValueMapperWithKey-org.apache.kafka.streams.kstream.Named-"/>
        /// </summary>
        /// <param name="arg0"><see cref="ValueMapperWithKey{K, V, VR, TJVMK, TJVMV, TJVMVR}"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="TJVMVR">The JVM type of <typeparamref name="VR"/></typeparam>
        /// <typeparam name="Arg0objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg0ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, VR, TJVMK, TJVMVR> MapValues<VR, TJVMVR, Arg0objectSuperK, Arg0objectSuperV, Arg0ExtendsVR>(ValueMapperWithKey<Arg0objectSuperK, Arg0objectSuperV, Arg0ExtendsVR, TJVMK, TJVMV, TJVMVR> arg0, Org.Apache.Kafka.Streams.Kstream.Named arg1) where Arg0objectSuperK : K where Arg0objectSuperV : V where Arg0ExtendsVR : VR
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KStream<K, VR, TJVMK, TJVMVR>(_factory, _inner.MapValues<TJVMVR, TJVMK, TJVMV, TJVMVR>(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#mapValues-org.apache.kafka.streams.kstream.ValueMapperWithKey-"/>
        /// </summary>
        /// <param name="arg0"><see cref="ValueMapperWithKey{K, V, VR, TJVMK, TJVMV, TJVMVR}"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="TJVMVR">The JVM type of <typeparamref name="VR"/></typeparam>
        /// <typeparam name="Arg0objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg0ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, VR, TJVMK, TJVMVR> MapValues<VR, TJVMVR, Arg0objectSuperK, Arg0objectSuperV, Arg0ExtendsVR>(ValueMapperWithKey<Arg0objectSuperK, Arg0objectSuperV, Arg0ExtendsVR, TJVMK, TJVMV, TJVMVR> arg0) where Arg0objectSuperK : K where Arg0objectSuperV : V where Arg0ExtendsVR : VR
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KStream<K, VR, TJVMK, TJVMVR>(_factory, _inner.MapValues<TJVMVR, TJVMK, TJVMV, TJVMVR>(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#join-org.apache.kafka.streams.kstream.KTable-org.apache.kafka.streams.kstream.ValueJoiner-org.apache.kafka.streams.kstream.Joined-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KTable{K, V, TJVMK, TJVMV}"/></param>
        /// <param name="arg1"><see cref="ValueJoiner{V1, V2, VR, TJVMV1, TJVMV2, TJVMVR}"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Kstream.Joined"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="VT"></typeparam>
        /// <typeparam name="TJVMVR">The JVM type of <typeparamref name="VR"/></typeparam>
        /// <typeparam name="TJVMVT">The JVM type of <typeparamref name="VT"/></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg1objectSuperVT"><typeparamref name="VT"/></typeparam>
        /// <typeparam name="Arg1ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, VR, TJVMK, TJVMVR> Join<VR, VT, TJVMVR, TJVMVT, Arg1objectSuperV, Arg1objectSuperVT, Arg1ExtendsVR>(KTable<K, VT, TJVMK, TJVMVT> arg0, ValueJoiner<Arg1objectSuperV, Arg1objectSuperVT, Arg1ExtendsVR, TJVMV, TJVMVT, TJVMVR> arg1, Joined<K, V, VT, TJVMK, TJVMV, TJVMVT> arg2) where Arg1objectSuperV : V where Arg1objectSuperVT : VT where Arg1ExtendsVR : VR
        {
            if (arg1 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg2 is IGenericSerDesFactoryApplier applier2) applier2.Factory = _factory;
            return new KStream<K, VR, TJVMK, TJVMVR>(_factory, _inner.Join<TJVMVR, TJVMVT, TJVMV, TJVMVT, TJVMVR>(arg0, arg1, arg2));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#join-org.apache.kafka.streams.kstream.KTable-org.apache.kafka.streams.kstream.ValueJoiner-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KTable{K, V, TJVMK, TJVMV}"/></param>
        /// <param name="arg1"><see cref="ValueJoiner{V1, V2, VR, TJVMV1, TJVMV2, TJVMVR}"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="VT"></typeparam>
        /// <typeparam name="TJVMVR">The JVM type of <typeparamref name="VR"/></typeparam>
        /// <typeparam name="TJVMVT">The JVM type of <typeparamref name="VT"/></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg1objectSuperVT"><typeparamref name="VT"/></typeparam>
        /// <typeparam name="Arg1ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, VR, TJVMK, TJVMVR> Join<VR, VT, TJVMVR, TJVMVT, Arg1objectSuperV, Arg1objectSuperVT, Arg1ExtendsVR>(KTable<K, VT, TJVMK, TJVMVT> arg0, ValueJoiner<Arg1objectSuperV, Arg1objectSuperVT, Arg1ExtendsVR, TJVMV, TJVMVT, TJVMVR> arg1) where Arg1objectSuperV : V where Arg1objectSuperVT : VT where Arg1ExtendsVR : VR
        {
            if (arg1 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KStream<K, VR, TJVMK, TJVMVR>(_factory, _inner.Join <TJVMVR, TJVMVT, TJVMV, TJVMVT, TJVMVR> (arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#join-org.apache.kafka.streams.kstream.KTable-org.apache.kafka.streams.kstream.ValueJoinerWithKey-org.apache.kafka.streams.kstream.Joined-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KTable{K, V, TJVMK, TJVMV}"/></param>
        /// <param name="arg1"><see cref="ValueJoinerWithKey{K1, V1, V2, VR, TJVMK1, TJVMV1, TJVMV2, TJVMVR}"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Kstream.Joined"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="VT"></typeparam>
        /// <typeparam name="TJVMVR">The JVM type of <typeparamref name="VR"/></typeparam>
        /// <typeparam name="TJVMVT">The JVM type of <typeparamref name="VT"/></typeparam>
        /// <typeparam name="Arg1objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg1objectSuperVT"><typeparamref name="VT"/></typeparam>
        /// <typeparam name="Arg1ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, VR, TJVMK, TJVMVR> Join<VR, VT, TJVMVR, TJVMVT, Arg1objectSuperK, Arg1objectSuperV, Arg1objectSuperVT, Arg1ExtendsVR>(KTable<K, VT, TJVMK, TJVMVT> arg0, ValueJoinerWithKey<Arg1objectSuperK, Arg1objectSuperV, Arg1objectSuperVT, Arg1ExtendsVR, TJVMK, TJVMV, TJVMVT, TJVMVR> arg1, Joined<K, V, VT, TJVMK, TJVMV, TJVMVT> arg2) where Arg1objectSuperK : K where Arg1objectSuperV : V where Arg1objectSuperVT : VT where Arg1ExtendsVR : VR
        {
            if (arg1 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg2 is IGenericSerDesFactoryApplier applier2) applier2.Factory = _factory;
            return new KStream<K, VR, TJVMK, TJVMVR>(_factory, _inner.Join<TJVMVR, TJVMVT, TJVMK, TJVMV, TJVMVT, TJVMVR>(arg0, arg1, arg2));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#join-org.apache.kafka.streams.kstream.KTable-org.apache.kafka.streams.kstream.ValueJoinerWithKey-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KTable{K, V, TJVMK, TJVMV}"/></param>
        /// <param name="arg1"><see cref="ValueJoinerWithKey{K1, V1, V2, VR, TJVMK1, TJVMV1, TJVMV2, TJVMVR}"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="VT"></typeparam>
        /// <typeparam name="TJVMVR">The JVM type of <typeparamref name="VR"/></typeparam>
        /// <typeparam name="TJVMVT">The JVM type of <typeparamref name="VT"/></typeparam>
        /// <typeparam name="Arg1objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg1objectSuperVT"><typeparamref name="VT"/></typeparam>
        /// <typeparam name="Arg1ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, VR, TJVMK, TJVMVR> Join<VR, VT, TJVMVR, TJVMVT, Arg1objectSuperK, Arg1objectSuperV, Arg1objectSuperVT, Arg1ExtendsVR>(KTable<K, VT, TJVMK, TJVMVT> arg0, ValueJoinerWithKey<Arg1objectSuperK, Arg1objectSuperV, Arg1objectSuperVT, Arg1ExtendsVR, TJVMK, TJVMV, TJVMVT, TJVMVR> arg1) where Arg1objectSuperK : K where Arg1objectSuperV : V where Arg1objectSuperVT : VT where Arg1ExtendsVR : VR
        {
            if (arg1 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KStream<K, VR, TJVMK, TJVMVR>(_factory, _inner.Join<TJVMVR, TJVMVT, TJVMK, TJVMV, TJVMVT, TJVMVR>(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#leftJoin-org.apache.kafka.streams.kstream.KTable-org.apache.kafka.streams.kstream.ValueJoiner-org.apache.kafka.streams.kstream.Joined-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KTable{K, V, TJVMK, TJVMV}"/></param>
        /// <param name="arg1"><see cref="ValueJoiner{V1, V2, VR, TJVMV1, TJVMV2, TJVMVR}"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Kstream.Joined"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="VT"></typeparam>
        /// <typeparam name="TJVMVR">The JVM type of <typeparamref name="VR"/></typeparam>
        /// <typeparam name="TJVMVT">The JVM type of <typeparamref name="VT"/></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg1objectSuperVT"><typeparamref name="VT"/></typeparam>
        /// <typeparam name="Arg1ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, VR, TJVMK, TJVMVR> LeftJoin<VR, VT, TJVMVR, TJVMVT, Arg1objectSuperV, Arg1objectSuperVT, Arg1ExtendsVR>(KTable<K, VT, TJVMK, TJVMVT> arg0, ValueJoiner<Arg1objectSuperV, Arg1objectSuperVT, Arg1ExtendsVR, TJVMV, TJVMVT, TJVMVR> arg1, Joined<K, V, VT, TJVMK, TJVMV, TJVMVT> arg2) where Arg1objectSuperV : V where Arg1objectSuperVT : VT where Arg1ExtendsVR : VR
        {
            if (arg1 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg2 is IGenericSerDesFactoryApplier applier2) applier2.Factory = _factory;
            return new KStream<K, VR, TJVMK, TJVMVR>(_factory, _inner.LeftJoin<TJVMVR, TJVMVT, TJVMV, TJVMVT, TJVMVR>(arg0, arg1, arg2));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#leftJoin-org.apache.kafka.streams.kstream.KTable-org.apache.kafka.streams.kstream.ValueJoiner-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KTable{K, V, TJVMK, TJVMV}"/></param>
        /// <param name="arg1"><see cref="ValueJoiner{V1, V2, VR, TJVMV1, TJVMV2, TJVMVR}"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="VT"></typeparam>
        /// <typeparam name="TJVMVR">The JVM type of <typeparamref name="VR"/></typeparam>
        /// <typeparam name="TJVMVT">The JVM type of <typeparamref name="VT"/></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg1objectSuperVT"><typeparamref name="VT"/></typeparam>
        /// <typeparam name="Arg1ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, VR, TJVMK, TJVMVR> LeftJoin<VR, VT, TJVMVR, TJVMVT, Arg1objectSuperV, Arg1objectSuperVT, Arg1ExtendsVR>(KTable<K, VT, TJVMK, TJVMVT> arg0, ValueJoiner<Arg1objectSuperV, Arg1objectSuperVT, Arg1ExtendsVR, TJVMV, TJVMVT, TJVMVR> arg1) where Arg1objectSuperV : V where Arg1objectSuperVT : VT where Arg1ExtendsVR : VR
        {
            if (arg1 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KStream<K, VR, TJVMK, TJVMVR>(_factory, _inner.LeftJoin<TJVMVR, TJVMVT, TJVMV, TJVMVT, TJVMVR>(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#leftJoin-org.apache.kafka.streams.kstream.KTable-org.apache.kafka.streams.kstream.ValueJoinerWithKey-org.apache.kafka.streams.kstream.Joined-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KTable{K, V, TJVMK, TJVMV}"/></param>
        /// <param name="arg1"><see cref="ValueJoinerWithKey{K1, V1, V2, VR, TJVMK1, TJVMV1, TJVMV2, TJVMVR}"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Kstream.Joined"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="VT"></typeparam>
        /// <typeparam name="TJVMVR">The JVM type of <typeparamref name="VR"/></typeparam>
        /// <typeparam name="TJVMVT">The JVM type of <typeparamref name="VT"/></typeparam>
        /// <typeparam name="Arg1objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg1objectSuperVT"><typeparamref name="VT"/></typeparam>
        /// <typeparam name="Arg1ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, VR, TJVMK, TJVMVR> LeftJoin<VR, VT, TJVMVR, TJVMVT, Arg1objectSuperK, Arg1objectSuperV, Arg1objectSuperVT, Arg1ExtendsVR>(KTable<K, VT, TJVMK, TJVMVT> arg0, ValueJoinerWithKey<Arg1objectSuperK, Arg1objectSuperV, Arg1objectSuperVT, Arg1ExtendsVR, TJVMK, TJVMV, TJVMVT, TJVMVR> arg1, Joined<K, V, VT, TJVMK, TJVMV, TJVMVT> arg2) where Arg1objectSuperK : K where Arg1objectSuperV : V where Arg1objectSuperVT : VT where Arg1ExtendsVR : VR
        {
            if (arg1 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KStream<K, VR, TJVMK, TJVMVR>(_factory, _inner.LeftJoin<TJVMVR, TJVMVT, TJVMK, TJVMV, TJVMVT, TJVMVR>(arg0, arg1, arg2));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#leftJoin-org.apache.kafka.streams.kstream.KTable-org.apache.kafka.streams.kstream.ValueJoinerWithKey-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KTable{K, VT, TJVMK, TJVMVT}"/></param>
        /// <param name="arg1"><see cref="ValueJoinerWithKey{K1, V1, V2, VR, TJVMK1, TJVMV1, TJVMV2, TJVMVR}"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="VT"></typeparam>
        /// <typeparam name="TJVMVR">The JVM type of <typeparamref name="VR"/></typeparam>
        /// <typeparam name="TJVMVT">The JVM type of <typeparamref name="VT"/></typeparam>
        /// <typeparam name="Arg1objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg1objectSuperVT"><typeparamref name="VT"/></typeparam>
        /// <typeparam name="Arg1ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, VR, TJVMK, TJVMVR> LeftJoin<VR, VT, TJVMVR, TJVMVT, Arg1objectSuperK, Arg1objectSuperV, Arg1objectSuperVT, Arg1ExtendsVR>(KTable<K, VT, TJVMK, TJVMVT> arg0, ValueJoinerWithKey<Arg1objectSuperK, Arg1objectSuperV, Arg1objectSuperVT, Arg1ExtendsVR, TJVMK, TJVMV, TJVMVT, TJVMVR> arg1) where Arg1objectSuperK : K where Arg1objectSuperV : V where Arg1objectSuperVT : VT where Arg1ExtendsVR : VR
        {
            if (arg1 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KStream<K, VR, TJVMK, TJVMVR>(_factory, _inner.LeftJoin<TJVMVR, TJVMVT, TJVMK, TJVMV, TJVMVT, TJVMVR>(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#split()"/>
        /// </summary>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.BranchedKStream"/></returns>
        public BranchedKStream<K, V, TJVMK, TJVMV> Split()
        {
            return new BranchedKStream<K, V, TJVMK, TJVMV>(_factory, _inner.Split());
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#split-org.apache.kafka.streams.kstream.Named-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.BranchedKStream"/></returns>
        public BranchedKStream<K, V, TJVMK, TJVMV> Split(Org.Apache.Kafka.Streams.Kstream.Named arg0)
        {
            return new BranchedKStream<K, V, TJVMK, TJVMV>(_factory, _inner.Split(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#groupByKey()"/>
        /// </summary>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KGroupedStream"/></returns>
        public KGroupedStream<K, V, TJVMK, TJVMV> GroupByKey()
        {
            return new KGroupedStream<K, V, TJVMK, TJVMV>(_factory, _inner.GroupByKey());
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#groupByKey-org.apache.kafka.streams.kstream.Grouped-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Grouped{K, V, TJVMK, TJVMV}"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KGroupedStream"/></returns>
        public KGroupedStream<K, V, TJVMK, TJVMV> GroupByKey(Grouped<K, V, TJVMK, TJVMV> arg0)
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KGroupedStream<K, V, TJVMK, TJVMV>(_factory, _inner.GroupByKey(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#filter-org.apache.kafka.streams.kstream.Predicate-org.apache.kafka.streams.kstream.Named-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Predicate{K, V, TJVMK, TJVMV}"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <typeparam name="Arg0objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, V, TJVMK, TJVMV> Filter<Arg0objectSuperK, Arg0objectSuperV>(Predicate<Arg0objectSuperK, Arg0objectSuperV, TJVMK, TJVMV> arg0, Org.Apache.Kafka.Streams.Kstream.Named arg1) where Arg0objectSuperK : K where Arg0objectSuperV : V
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KStream<K, V, TJVMK, TJVMV>(_factory, _inner.Filter(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#filter-org.apache.kafka.streams.kstream.Predicate-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Predicate{K, V, TJVMK, TJVMV}"/></param>
        /// <typeparam name="Arg0objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, V, TJVMK, TJVMV> Filter<Arg0objectSuperK, Arg0objectSuperV>(Predicate<Arg0objectSuperK, Arg0objectSuperV, TJVMK, TJVMV> arg0) where Arg0objectSuperK : K where Arg0objectSuperV : V
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KStream<K, V, TJVMK, TJVMV>(_factory, _inner.Filter(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#filterNot-org.apache.kafka.streams.kstream.Predicate-org.apache.kafka.streams.kstream.Named-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Predicate{K, V, TJVMK, TJVMV}"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <typeparam name="Arg0objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, V, TJVMK, TJVMV> FilterNot<Arg0objectSuperK, Arg0objectSuperV>(Predicate<Arg0objectSuperK, Arg0objectSuperV, TJVMK, TJVMV> arg0, Org.Apache.Kafka.Streams.Kstream.Named arg1) where Arg0objectSuperK : K where Arg0objectSuperV : V
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KStream<K, V, TJVMK, TJVMV>(_factory, _inner.FilterNot(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#filterNot-org.apache.kafka.streams.kstream.Predicate-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Predicate{K, V, TJVMK, TJVMV}"/></param>
        /// <typeparam name="Arg0objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, V, TJVMK, TJVMV> FilterNot<Arg0objectSuperK, Arg0objectSuperV>(Predicate<Arg0objectSuperK, Arg0objectSuperV, TJVMK, TJVMV> arg0) where Arg0objectSuperK : K where Arg0objectSuperV : V
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KStream<K, V, TJVMK, TJVMV>(_factory, _inner.FilterNot(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#merge-org.apache.kafka.streams.kstream.KStream-org.apache.kafka.streams.kstream.Named-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KStream{K, V, TJVMK, TJVMV}"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, V, TJVMK, TJVMV> Merge(KStream<K, V, TJVMK, TJVMV> arg0, Org.Apache.Kafka.Streams.Kstream.Named arg1)
        {
            return new KStream<K, V, TJVMK, TJVMV>(_factory, _inner.Merge(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#merge-org.apache.kafka.streams.kstream.KStream-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KStream{K, V, TJVMK, TJVMV}"/></param>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, V, TJVMK, TJVMV> Merge(KStream<K, V, TJVMK, TJVMV> arg0)
        {
            return new KStream<K, V, TJVMK, TJVMV>(_factory, _inner.Merge(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#peek-org.apache.kafka.streams.kstream.ForeachAction-org.apache.kafka.streams.kstream.Named-"/>
        /// </summary>
        /// <param name="arg0"><see cref="ForeachAction{K, V, TJVMK, TJVMV}"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <typeparam name="Arg0objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, V, TJVMK, TJVMV> Peek<Arg0objectSuperK, Arg0objectSuperV>(ForeachAction<Arg0objectSuperK, Arg0objectSuperV, TJVMK, TJVMV> arg0, Org.Apache.Kafka.Streams.Kstream.Named arg1) where Arg0objectSuperK : K where Arg0objectSuperV : V
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KStream<K, V, TJVMK, TJVMV>(_factory, _inner.Peek(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#peek-org.apache.kafka.streams.kstream.ForeachAction-"/>
        /// </summary>
        /// <param name="arg0"><see cref="ForeachAction{K, V, TJVMK, TJVMV}"/></param>
        /// <typeparam name="Arg0objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, V, TJVMK, TJVMV> Peek<Arg0objectSuperK, Arg0objectSuperV>(ForeachAction<Arg0objectSuperK, Arg0objectSuperV, TJVMK, TJVMV> arg0) where Arg0objectSuperK : K where Arg0objectSuperV : V
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KStream<K, V, TJVMK, TJVMV>(_factory, _inner.Peek(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#repartition()"/>
        /// </summary>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, V, TJVMK, TJVMV> Repartition()
        {
            return new KStream<K, V, TJVMK, TJVMV>(_factory, _inner.Repartition());
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#repartition-org.apache.kafka.streams.kstream.Repartitioned-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Repartitioned{K, V, TJVMK, TJVMV}"/></param>
        /// <returns><see cref="KStream{K, V, TJVMK, TJVMV}"/></returns>
        public KStream<K, V, TJVMK, TJVMV> Repartition(Repartitioned<K, V, TJVMK, TJVMV> arg0)
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KStream<K, V, TJVMK, TJVMV>(_factory, _inner.Repartition(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#toTable()"/>
        /// </summary>
        /// <returns><see cref="KTable{K, V, TJVMK, TJVMV}"/></returns>
        public KTable<K, V, TJVMK, TJVMV> ToTable()
        {
            return new KTable<K, V, TJVMK, TJVMV>(_factory, _inner.ToTable());
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#toTable-org.apache.kafka.streams.kstream.Materialized-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Materialized{K, V, TJVMK, TJVMV}"/></param>
        /// <returns><see cref="KTable{K, V, TJVMK, TJVMV}"/></returns>
        public KTable<K, V, TJVMK, TJVMV> ToTable(Materialized<K, V, TJVMK, TJVMV> arg0)
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KTable<K, V, TJVMK, TJVMV>(_factory, _inner.ToTable(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#toTable-org.apache.kafka.streams.kstream.Named-org.apache.kafka.streams.kstream.Materialized-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <param name="arg1"><see cref="Materialized{K, V, TJVMK, TJVMV}"/></param>
        /// <returns><see cref="KTable{K, V, TJVMK, TJVMV}"/></returns>
        public KTable<K, V, TJVMK, TJVMV> ToTable(Org.Apache.Kafka.Streams.Kstream.Named arg0, Materialized<K, V, TJVMK, TJVMV> arg1)
        {
            if (arg1 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KTable<K, V, TJVMK, TJVMV>(_factory, _inner.ToTable(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#toTable-org.apache.kafka.streams.kstream.Named-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <returns><see cref="KTable{K, V, TJVMK, TJVMV}"/></returns>
        public KTable<K, V, TJVMK, TJVMV> ToTable(Org.Apache.Kafka.Streams.Kstream.Named arg0)
        {
            return new KTable<K, V, TJVMK, TJVMV>(_factory, _inner.ToTable(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#foreach-org.apache.kafka.streams.kstream.ForeachAction-org.apache.kafka.streams.kstream.Named-"/>
        /// </summary>
        /// <param name="arg0"><see cref="ForeachAction{K, V, TJVMK, TJVMV}"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <typeparam name="Arg0objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        public void Foreach<Arg0objectSuperK, Arg0objectSuperV>(ForeachAction<Arg0objectSuperK, Arg0objectSuperV, TJVMK, TJVMV> arg0, Org.Apache.Kafka.Streams.Kstream.Named arg1) where Arg0objectSuperK : K where Arg0objectSuperV : V
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            _inner.Foreach(arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#foreach-org.apache.kafka.streams.kstream.ForeachAction-"/>
        /// </summary>
        /// <param name="arg0"><see cref="ForeachAction{K, V, TJVMK, TJVMV}"/></param>
        /// <typeparam name="Arg0objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        public void Foreach<Arg0objectSuperK, Arg0objectSuperV>(ForeachAction<Arg0objectSuperK, Arg0objectSuperV, TJVMK, TJVMV> arg0) where Arg0objectSuperK : K where Arg0objectSuperV : V
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            _inner.Foreach(arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#print-org.apache.kafka.streams.kstream.Printed-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Printed{K, V}"/></param>
        public void Print(Printed<K, V, TJVMK, TJVMV> arg0)
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            _inner.Print(arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#to-java.lang.String-org.apache.kafka.streams.kstream.Produced-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="Produced{K, V}"/></param>
        public void To(string arg0, Produced<K, V, TJVMK, TJVMV> arg1)
        {
            if (arg1 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            _inner.To(arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#to-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        public void To(string arg0)
        {
            _inner.To(arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#to-org.apache.kafka.streams.processor.TopicNameExtractor-org.apache.kafka.streams.kstream.Produced-"/>
        /// </summary>
        /// <param name="arg0"><see cref="TopicNameExtractor{K, V, TJVMK, TJVMV}"/></param>
        /// <param name="arg1"><see cref="Produced{K, V, TJVMK, TJVMV}"/></param>
        public void To(TopicNameExtractor<K, V, TJVMK, TJVMV> arg0, Produced<K, V, TJVMK, TJVMV> arg1)
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            _inner.To(arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/KStream.html#to-org.apache.kafka.streams.processor.TopicNameExtractor-"/>
        /// </summary>
        /// <param name="arg0"><see cref="TopicNameExtractor{K, V, TJVMK, TJVMV}"/></param>
        public void To(TopicNameExtractor<K, V, TJVMK, TJVMV> arg0)
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            _inner.To(arg0);
        }
    }
}
