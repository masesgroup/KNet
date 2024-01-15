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

using MASES.KNet.Serialization;
using MASES.KNet.Streams.Utils;
using System;

namespace MASES.KNet.Streams.Kstream
{
    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.KTable{K, V}"/>
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    public class KNetKTable<K, V> : IGenericSerDesFactoryApplier
    {
        Org.Apache.Kafka.Streams.Kstream.KTable<byte[], byte[]> _inner;
        Org.Apache.Kafka.Streams.Kstream.KTable<byte[], Java.Lang.Long> _inner2;

        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        internal KNetKTable(IGenericSerDesFactory factory, Org.Apache.Kafka.Streams.Kstream.KTable<byte[], byte[]> inner)
        {
            _factory = factory;
            _inner = inner;
        }

        internal KNetKTable(IGenericSerDesFactory factory, Org.Apache.Kafka.Streams.Kstream.KTable<byte[], Java.Lang.Long> inner)
        {
            _factory = factory;
            _inner2 = inner;
        }

        /// <summary>
        /// Converter from <see cref="KNetKTable{K, V}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.KTable{K, V}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.KTable<byte[], byte[]>(KNetKTable<K, V> t) => t._inner;

        /// <summary>
        /// Converter from <see cref="KNetKTable{K, V}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.KTable{K, V}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.KTable<byte[], Java.Lang.Long>(KNetKTable<K, V> t) => t._inner2;

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KTable.html#groupBy-org.apache.kafka.streams.kstream.KeyValueMapper-org.apache.kafka.streams.kstream.Grouped-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.KeyValueMapper"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Grouped"/></param>
        /// <typeparam name="KR"></typeparam>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="Arg0objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KGroupedTable"/></returns>
        public KNetKGroupedTable<KR, VR> GroupBy<KR, VR, Arg0objectSuperK, Arg0objectSuperV>(KNetKeyValueKeyValueMapper<Arg0objectSuperK, Arg0objectSuperV, KR, VR> arg0, KNetGrouped<KR, VR> arg1) where Arg0objectSuperK : K where Arg0objectSuperV : V
        {
            if (_inner == null && _inner2 != null) throw new InvalidOperationException("Current implementation does not manage KNetKTable generated from Count methods of KNetKGroupedTable");

            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            return new KNetKGroupedTable<KR, VR>(_factory, _inner.GroupBy<byte[], byte[], byte[], byte[]>(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KTable.html#groupBy-org.apache.kafka.streams.kstream.KeyValueMapper-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.KeyValueMapper"/></param>
        /// <typeparam name="KR"></typeparam>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="Arg0objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KGroupedTable"/></returns>
        public KNetKGroupedTable<KR, VR> GroupBy<KR, VR, Arg0objectSuperK, Arg0objectSuperV>(KNetKeyValueKeyValueMapper<Arg0objectSuperK, Arg0objectSuperV, KR, VR> arg0) where Arg0objectSuperK : K where Arg0objectSuperV : V
        {
            if (_inner == null && _inner2 != null) throw new InvalidOperationException("Current implementation does not manage KNetKTable generated from Count methods of KNetKGroupedTable");

            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KNetKGroupedTable<KR, VR>(_factory, _inner.GroupBy<byte[], byte[], byte[], byte[]>(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KTable.html#toStream-org.apache.kafka.streams.kstream.KeyValueMapper-org.apache.kafka.streams.kstream.Named-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.KeyValueMapper"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <typeparam name="KR"></typeparam>
        /// <typeparam name="Arg0objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg0ExtendsKR"><typeparamref name="KR"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KStream"/></returns>
        public KNetKStream<KR, V> ToStream<KR, Arg0objectSuperK, Arg0objectSuperV, Arg0ExtendsKR>(KNetKeyValueMapper<Arg0objectSuperK, Arg0objectSuperV, Arg0ExtendsKR> arg0, Org.Apache.Kafka.Streams.Kstream.Named arg1) where Arg0objectSuperK : K where Arg0objectSuperV : V where Arg0ExtendsKR : KR
        {
            if (_inner == null && _inner2 != null) throw new InvalidOperationException("Current implementation does not manage KNetKTable generated from Count methods of KNetKGroupedTable");

            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KNetKStream<KR, V>(_factory, _inner.ToStream<byte[], byte[], byte[], byte[]>(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KTable.html#toStream-org.apache.kafka.streams.kstream.KeyValueMapper-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.KeyValueMapper"/></param>
        /// <typeparam name="KR"></typeparam>
        /// <typeparam name="Arg0objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg0ExtendsKR"><typeparamref name="KR"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KStream"/></returns>
        public KNetKStream<KR, V> ToStream<KR, Arg0objectSuperK, Arg0objectSuperV, Arg0ExtendsKR>(KNetKeyValueMapper<Arg0objectSuperK, Arg0objectSuperV, Arg0ExtendsKR> arg0) where Arg0objectSuperK : K where Arg0objectSuperV : V where Arg0ExtendsKR : KR
        {
            if (_inner == null && _inner2 != null) throw new InvalidOperationException("Current implementation does not manage KNetKTable generated from Count methods of KNetKGroupedTable");

            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KNetKStream<KR, V>(_factory, _inner.ToStream<byte[], byte[], byte[], byte[]>(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KTable.html#join-org.apache.kafka.streams.kstream.KTable-org.apache.kafka.streams.kstream.ValueJoiner-org.apache.kafka.streams.kstream.Materialized-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.ValueJoiner"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="VO"></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg1objectSuperVO"><typeparamref name="VO"/></typeparam>
        /// <typeparam name="Arg1ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, VR> Join<VR, VO, Arg1objectSuperV, Arg1objectSuperVO, Arg1ExtendsVR>(KNetKTable<K, VO> arg0, KNetValueJoiner<Arg1objectSuperV, Arg1objectSuperVO, Arg1ExtendsVR> arg1, KNetMaterialized<K, VR> arg2) where Arg1objectSuperV : V where Arg1objectSuperVO : VO where Arg1ExtendsVR : VR
        {
            if (_inner == null && _inner2 != null) throw new InvalidOperationException("Current implementation does not manage KNetKTable generated from Count methods of KNetKGroupedTable");

            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            if (arg2 is IGenericSerDesFactoryApplier applier2) applier2.Factory = _factory;
            return new KNetKTable<K, VR>(_factory, _inner.Join<byte[], byte[], byte[], byte[], byte[]>(arg0, arg1, arg2));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KTable.html#join-org.apache.kafka.streams.kstream.KTable-org.apache.kafka.streams.kstream.ValueJoiner-org.apache.kafka.streams.kstream.Named-org.apache.kafka.streams.kstream.Materialized-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.ValueJoiner"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <param name="arg3"><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="VO"></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg1objectSuperVO"><typeparamref name="VO"/></typeparam>
        /// <typeparam name="Arg1ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, VR> Join<VR, VO, Arg1objectSuperV, Arg1objectSuperVO, Arg1ExtendsVR>(KNetKTable<K, VO> arg0, KNetValueJoiner<Arg1objectSuperV, Arg1objectSuperVO, Arg1ExtendsVR> arg1, Org.Apache.Kafka.Streams.Kstream.Named arg2, KNetMaterialized<K, VR> arg3) where Arg1objectSuperV : V where Arg1objectSuperVO : VO where Arg1ExtendsVR : VR
        {
            if (_inner == null && _inner2 != null) throw new InvalidOperationException("Current implementation does not manage KNetKTable generated from Count methods of KNetKGroupedTable");

            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            if (arg3 is IGenericSerDesFactoryApplier applier3) applier3.Factory = _factory;
            return new KNetKTable<K, VR>(_factory, _inner.Join<byte[], byte[], byte[], byte[], byte[]>(arg0, arg1, arg2, arg3));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KTable.html#join-org.apache.kafka.streams.kstream.KTable-org.apache.kafka.streams.kstream.ValueJoiner-org.apache.kafka.streams.kstream.Named-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.ValueJoiner"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="VO"></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg1objectSuperVO"><typeparamref name="VO"/></typeparam>
        /// <typeparam name="Arg1ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, VR> Join<VR, VO, Arg1objectSuperV, Arg1objectSuperVO, Arg1ExtendsVR>(KNetKTable<K, VO> arg0, KNetValueJoiner<Arg1objectSuperV, Arg1objectSuperVO, Arg1ExtendsVR> arg1, Org.Apache.Kafka.Streams.Kstream.Named arg2) where Arg1objectSuperV : V where Arg1objectSuperVO : VO where Arg1ExtendsVR : VR
        {
            if (_inner == null && _inner2 != null) throw new InvalidOperationException("Current implementation does not manage KNetKTable generated from Count methods of KNetKGroupedTable");

            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            return new KNetKTable<K, VR>(_factory, _inner.Join<byte[], byte[], byte[], byte[], byte[]>(arg0, arg1, arg2));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KTable.html#join-org.apache.kafka.streams.kstream.KTable-org.apache.kafka.streams.kstream.ValueJoiner-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.ValueJoiner"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="VO"></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg1objectSuperVO"><typeparamref name="VO"/></typeparam>
        /// <typeparam name="Arg1ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, VR> Join<VR, VO, Arg1objectSuperV, Arg1objectSuperVO, Arg1ExtendsVR>(KNetKTable<K, VO> arg0, KNetValueJoiner<Arg1objectSuperV, Arg1objectSuperVO, Arg1ExtendsVR> arg1) where Arg1objectSuperV : V where Arg1objectSuperVO : VO where Arg1ExtendsVR : VR
        {
            if (_inner == null && _inner2 != null) throw new InvalidOperationException("Current implementation does not manage KNetKTable generated from Count methods of KNetKGroupedTable");

            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            return new KNetKTable<K, VR>(_factory, _inner.Join<byte[], byte[], byte[], byte[], byte[]>(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KTable.html#leftJoin-org.apache.kafka.streams.kstream.KTable-org.apache.kafka.streams.kstream.ValueJoiner-org.apache.kafka.streams.kstream.Materialized-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.ValueJoiner"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="VO"></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg1objectSuperVO"><typeparamref name="VO"/></typeparam>
        /// <typeparam name="Arg1ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, VR> LeftJoin<VR, VO, Arg1objectSuperV, Arg1objectSuperVO, Arg1ExtendsVR>(KNetKTable<K, VO> arg0, KNetValueJoiner<Arg1objectSuperV, Arg1objectSuperVO, Arg1ExtendsVR> arg1, KNetMaterialized<K, VR> arg2) where Arg1objectSuperV : V where Arg1objectSuperVO : VO where Arg1ExtendsVR : VR
        {
            if (_inner == null && _inner2 != null) throw new InvalidOperationException("Current implementation does not manage KNetKTable generated from Count methods of KNetKGroupedTable");

            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            if (arg2 is IGenericSerDesFactoryApplier applier2) applier2.Factory = _factory;
            return new KNetKTable<K, VR>(_factory, _inner.LeftJoin<byte[], byte[], byte[], byte[], byte[]>(arg0, arg1, arg2));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KTable.html#leftJoin-org.apache.kafka.streams.kstream.KTable-org.apache.kafka.streams.kstream.ValueJoiner-org.apache.kafka.streams.kstream.Named-org.apache.kafka.streams.kstream.Materialized-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.ValueJoiner"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <param name="arg3"><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="VO"></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg1objectSuperVO"><typeparamref name="VO"/></typeparam>
        /// <typeparam name="Arg1ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, VR> LeftJoin<VR, VO, Arg1objectSuperV, Arg1objectSuperVO, Arg1ExtendsVR>(KNetKTable<K, VO> arg0, KNetValueJoiner<Arg1objectSuperV, Arg1objectSuperVO, Arg1ExtendsVR> arg1, Org.Apache.Kafka.Streams.Kstream.Named arg2, KNetMaterialized<K, VR> arg3) where Arg1objectSuperV : V where Arg1objectSuperVO : VO where Arg1ExtendsVR : VR
        {
            if (_inner == null && _inner2 != null) throw new InvalidOperationException("Current implementation does not manage KNetKTable generated from Count methods of KNetKGroupedTable");

            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            if (arg3 is IGenericSerDesFactoryApplier applier3) applier3.Factory = _factory;
            return new KNetKTable<K, VR>(_factory, _inner.LeftJoin<byte[], byte[], byte[], byte[], byte[]>(arg0, arg1, arg2, arg3));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KTable.html#leftJoin-org.apache.kafka.streams.kstream.KTable-org.apache.kafka.streams.kstream.ValueJoiner-org.apache.kafka.streams.kstream.Named-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.ValueJoiner"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="VO"></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg1objectSuperVO"><typeparamref name="VO"/></typeparam>
        /// <typeparam name="Arg1ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, VR> LeftJoin<VR, VO, Arg1objectSuperV, Arg1objectSuperVO, Arg1ExtendsVR>(KNetKTable<K, VO> arg0, KNetValueJoiner<Arg1objectSuperV, Arg1objectSuperVO, Arg1ExtendsVR> arg1, Org.Apache.Kafka.Streams.Kstream.Named arg2) where Arg1objectSuperV : V where Arg1objectSuperVO : VO where Arg1ExtendsVR : VR
        {
            if (_inner == null && _inner2 != null) throw new InvalidOperationException("Current implementation does not manage KNetKTable generated from Count methods of KNetKGroupedTable");

            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            return new KNetKTable<K, VR>(_factory, _inner.LeftJoin<byte[], byte[], byte[], byte[], byte[]>(arg0, arg1, arg2));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KTable.html#leftJoin-org.apache.kafka.streams.kstream.KTable-org.apache.kafka.streams.kstream.ValueJoiner-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.ValueJoiner"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="VO"></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg1objectSuperVO"><typeparamref name="VO"/></typeparam>
        /// <typeparam name="Arg1ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, VR> LeftJoin<VR, VO, Arg1objectSuperV, Arg1objectSuperVO, Arg1ExtendsVR>(KNetKTable<K, VO> arg0, KNetValueJoiner<Arg1objectSuperV, Arg1objectSuperVO, Arg1ExtendsVR> arg1) where Arg1objectSuperV : V where Arg1objectSuperVO : VO where Arg1ExtendsVR : VR
        {
            if (_inner == null && _inner2 != null) throw new InvalidOperationException("Current implementation does not manage KNetKTable generated from Count methods of KNetKGroupedTable");

            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            return new KNetKTable<K, VR>(_factory, _inner.LeftJoin<byte[], byte[], byte[], byte[], byte[]>(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KTable.html#outerJoin-org.apache.kafka.streams.kstream.KTable-org.apache.kafka.streams.kstream.ValueJoiner-org.apache.kafka.streams.kstream.Materialized-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.ValueJoiner"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="VO"></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg1objectSuperVO"><typeparamref name="VO"/></typeparam>
        /// <typeparam name="Arg1ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, VR> OuterJoin<VR, VO, Arg1objectSuperV, Arg1objectSuperVO, Arg1ExtendsVR>(KNetKTable<K, VO> arg0, KNetValueJoiner<Arg1objectSuperV, Arg1objectSuperVO, Arg1ExtendsVR> arg1, KNetMaterialized<K, VR> arg2) where Arg1objectSuperV : V where Arg1objectSuperVO : VO where Arg1ExtendsVR : VR
        {
            if (_inner == null && _inner2 != null) throw new InvalidOperationException("Current implementation does not manage KNetKTable generated from Count methods of KNetKGroupedTable");

            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            if (arg2 is IGenericSerDesFactoryApplier applier2) applier2.Factory = _factory;
            return new KNetKTable<K, VR>(_factory, _inner.OuterJoin<byte[], byte[], byte[], byte[], byte[]>(arg0, arg1, arg2));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KTable.html#outerJoin-org.apache.kafka.streams.kstream.KTable-org.apache.kafka.streams.kstream.ValueJoiner-org.apache.kafka.streams.kstream.Named-org.apache.kafka.streams.kstream.Materialized-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.ValueJoiner"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <param name="arg3"><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="VO"></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg1objectSuperVO"><typeparamref name="VO"/></typeparam>
        /// <typeparam name="Arg1ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, VR> OuterJoin<VR, VO, Arg1objectSuperV, Arg1objectSuperVO, Arg1ExtendsVR>(KNetKTable<K, VO> arg0, KNetValueJoiner<Arg1objectSuperV, Arg1objectSuperVO, Arg1ExtendsVR> arg1, Org.Apache.Kafka.Streams.Kstream.Named arg2, KNetMaterialized<K, VR> arg3) where Arg1objectSuperV : V where Arg1objectSuperVO : VO where Arg1ExtendsVR : VR
        {
            if (_inner == null && _inner2 != null) throw new InvalidOperationException("Current implementation does not manage KNetKTable generated from Count methods of KNetKGroupedTable");

            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            if (arg3 is IGenericSerDesFactoryApplier applier3) applier3.Factory = _factory;
            return new KNetKTable<K, VR>(_factory, _inner.OuterJoin<byte[], byte[], byte[], byte[], byte[]>(arg0, arg1, arg2, arg3));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KTable.html#outerJoin-org.apache.kafka.streams.kstream.KTable-org.apache.kafka.streams.kstream.ValueJoiner-org.apache.kafka.streams.kstream.Named-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.ValueJoiner"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="VO"></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg1objectSuperVO"><typeparamref name="VO"/></typeparam>
        /// <typeparam name="Arg1ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, VR> OuterJoin<VR, VO, Arg1objectSuperV, Arg1objectSuperVO, Arg1ExtendsVR>(KNetKTable<K, VO> arg0, KNetValueJoiner<Arg1objectSuperV, Arg1objectSuperVO, Arg1ExtendsVR> arg1, Org.Apache.Kafka.Streams.Kstream.Named arg2) where Arg1objectSuperV : V where Arg1objectSuperVO : VO where Arg1ExtendsVR : VR
        {
            if (_inner == null && _inner2 != null) throw new InvalidOperationException("Current implementation does not manage KNetKTable generated from Count methods of KNetKGroupedTable");

            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            return new KNetKTable<K, VR>(_factory, _inner.OuterJoin<byte[], byte[], byte[], byte[], byte[]>(arg0, arg1, arg2));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KTable.html#outerJoin-org.apache.kafka.streams.kstream.KTable-org.apache.kafka.streams.kstream.ValueJoiner-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.ValueJoiner"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="VO"></typeparam>
        /// <typeparam name="Arg1objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg1objectSuperVO"><typeparamref name="VO"/></typeparam>
        /// <typeparam name="Arg1ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, VR> OuterJoin<VR, VO, Arg1objectSuperV, Arg1objectSuperVO, Arg1ExtendsVR>(KNetKTable<K, VO> arg0, KNetValueJoiner<Arg1objectSuperV, Arg1objectSuperVO, Arg1ExtendsVR> arg1) where Arg1objectSuperV : V where Arg1objectSuperVO : VO where Arg1ExtendsVR : VR
        {
            if (_inner == null && _inner2 != null) throw new InvalidOperationException("Current implementation does not manage KNetKTable generated from Count methods of KNetKGroupedTable");

            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            return new KNetKTable<K, VR>(_factory, _inner.OuterJoin<byte[], byte[], byte[], byte[], byte[]>(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KTable.html#join-org.apache.kafka.streams.kstream.KTable-java.util.function.Function-org.apache.kafka.streams.kstream.ValueJoiner-org.apache.kafka.streams.kstream.Materialized-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></param>
        /// <param name="arg1"><see cref="Java.Util.Function.Function"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Kstream.ValueJoiner"/></param>
        /// <param name="arg3"><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="KO"></typeparam>
        /// <typeparam name="VO"></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, VR> Join<VR, KO, VO>(KNetKTable<KO, VO> arg0, KNetFunction<V, KO> arg1, KNetValueJoiner<V, VO, VR> arg2, KNetMaterialized<K, VR> arg3)
        {
            if (_inner == null && _inner2 != null) throw new InvalidOperationException("Current implementation does not manage KNetKTable generated from Count methods of KNetKGroupedTable");

            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            if (arg2 is IGenericSerDesFactoryApplier applier2) applier2.Factory = _factory;
            if (arg3 is IGenericSerDesFactoryApplier applier3) applier3.Factory = _factory;
            return new KNetKTable<K, VR>(_factory, _inner.Join<byte[], byte[], byte[]>(arg0, arg1, arg2, arg3));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KTable.html#join-org.apache.kafka.streams.kstream.KTable-java.util.function.Function-org.apache.kafka.streams.kstream.ValueJoiner-org.apache.kafka.streams.kstream.TableJoined-org.apache.kafka.streams.kstream.Materialized-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></param>
        /// <param name="arg1"><see cref="Java.Util.Function.Function"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Kstream.ValueJoiner"/></param>
        /// <param name="arg3"><see cref="Org.Apache.Kafka.Streams.Kstream.TableJoined"/></param>
        /// <param name="arg4"><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="KO"></typeparam>
        /// <typeparam name="VO"></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, VR> Join<VR, KO, VO>(KNetKTable<KO, VO> arg0, KNetFunction<V, KO> arg1, KNetValueJoiner<V, VO, VR> arg2, KNetTableJoined<K, KO> arg3, KNetMaterialized<K, VR> arg4)
        {
            if (_inner == null && _inner2 != null) throw new InvalidOperationException("Current implementation does not manage KNetKTable generated from Count methods of KNetKGroupedTable");

            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            if (arg2 is IGenericSerDesFactoryApplier applier2) applier2.Factory = _factory;
            if (arg3 is IGenericSerDesFactoryApplier applier3) applier3.Factory = _factory;
            if (arg4 is IGenericSerDesFactoryApplier applier4) applier4.Factory = _factory;
            return new KNetKTable<K, VR>(_factory, _inner.Join<byte[], byte[], byte[]>(arg0, arg1, arg2, arg3, arg4));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KTable.html#join-org.apache.kafka.streams.kstream.KTable-java.util.function.Function-org.apache.kafka.streams.kstream.ValueJoiner-org.apache.kafka.streams.kstream.TableJoined-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></param>
        /// <param name="arg1"><see cref="Java.Util.Function.Function"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Kstream.ValueJoiner"/></param>
        /// <param name="arg3"><see cref="Org.Apache.Kafka.Streams.Kstream.TableJoined"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="KO"></typeparam>
        /// <typeparam name="VO"></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, VR> Join<VR, KO, VO>(KNetKTable<KO, VO> arg0, KNetFunction<V, KO> arg1, KNetValueJoiner<V, VO, VR> arg2, KNetTableJoined<K, KO> arg3)
        {
            if (_inner == null && _inner2 != null) throw new InvalidOperationException("Current implementation does not manage KNetKTable generated from Count methods of KNetKGroupedTable");

            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            if (arg2 is IGenericSerDesFactoryApplier applier2) applier2.Factory = _factory;
            if (arg3 is IGenericSerDesFactoryApplier applier3) applier3.Factory = _factory;
            return new KNetKTable<K, VR>(_factory, _inner.Join<byte[], byte[], byte[]>(arg0, arg1, arg2, arg3));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KTable.html#join-org.apache.kafka.streams.kstream.KTable-java.util.function.Function-org.apache.kafka.streams.kstream.ValueJoiner-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></param>
        /// <param name="arg1"><see cref="Java.Util.Function.Function"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Kstream.ValueJoiner"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="KO"></typeparam>
        /// <typeparam name="VO"></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, VR> Join<VR, KO, VO>(KNetKTable<KO, VO> arg0, KNetFunction<V, KO> arg1, KNetValueJoiner<V, VO, VR> arg2)
        {
            if (_inner == null && _inner2 != null) throw new InvalidOperationException("Current implementation does not manage KNetKTable generated from Count methods of KNetKGroupedTable");

            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            if (arg2 is IGenericSerDesFactoryApplier applier2) applier2.Factory = _factory;
            return new KNetKTable<K, VR>(_factory, _inner.Join<byte[], byte[], byte[]>(arg0, arg1, arg2));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KTable.html#leftJoin-org.apache.kafka.streams.kstream.KTable-java.util.function.Function-org.apache.kafka.streams.kstream.ValueJoiner-org.apache.kafka.streams.kstream.Materialized-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></param>
        /// <param name="arg1"><see cref="Java.Util.Function.Function"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Kstream.ValueJoiner"/></param>
        /// <param name="arg3"><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="KO"></typeparam>
        /// <typeparam name="VO"></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, VR> LeftJoin<VR, KO, VO>(KNetKTable<KO, VO> arg0, KNetFunction<V, KO> arg1, KNetValueJoiner<V, VO, VR> arg2, KNetMaterialized<K, VR> arg3)
        {
            if (_inner == null && _inner2 != null) throw new InvalidOperationException("Current implementation does not manage KNetKTable generated from Count methods of KNetKGroupedTable");

            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            if (arg2 is IGenericSerDesFactoryApplier applier2) applier2.Factory = _factory;
            if (arg3 is IGenericSerDesFactoryApplier applier3) applier3.Factory = _factory;
            return new KNetKTable<K, VR>(_factory, _inner.LeftJoin<byte[], byte[], byte[]>(arg0, arg1, arg2, arg3));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KTable.html#leftJoin-org.apache.kafka.streams.kstream.KTable-java.util.function.Function-org.apache.kafka.streams.kstream.ValueJoiner-org.apache.kafka.streams.kstream.TableJoined-org.apache.kafka.streams.kstream.Materialized-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></param>
        /// <param name="arg1"><see cref="Java.Util.Function.Function"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Kstream.ValueJoiner"/></param>
        /// <param name="arg3"><see cref="Org.Apache.Kafka.Streams.Kstream.TableJoined"/></param>
        /// <param name="arg4"><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="KO"></typeparam>
        /// <typeparam name="VO"></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, VR> LeftJoin<VR, KO, VO>(KNetKTable<KO, VO> arg0, KNetFunction<V, KO> arg1, KNetValueJoiner<V, VO, VR> arg2, KNetTableJoined<K, KO> arg3, KNetMaterialized<K, VR> arg4)
        {
            if (_inner == null && _inner2 != null) throw new InvalidOperationException("Current implementation does not manage KNetKTable generated from Count methods of KNetKGroupedTable");

            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            if (arg2 is IGenericSerDesFactoryApplier applier2) applier2.Factory = _factory;
            if (arg3 is IGenericSerDesFactoryApplier applier3) applier3.Factory = _factory;
            if (arg4 is IGenericSerDesFactoryApplier applier4) applier4.Factory = _factory;
            return new KNetKTable<K, VR>(_factory, _inner.LeftJoin<byte[], byte[], byte[]>(arg0, arg1, arg2, arg3, arg4));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KTable.html#leftJoin-org.apache.kafka.streams.kstream.KTable-java.util.function.Function-org.apache.kafka.streams.kstream.ValueJoiner-org.apache.kafka.streams.kstream.TableJoined-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></param>
        /// <param name="arg1"><see cref="Java.Util.Function.Function"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Kstream.ValueJoiner"/></param>
        /// <param name="arg3"><see cref="Org.Apache.Kafka.Streams.Kstream.TableJoined"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="KO"></typeparam>
        /// <typeparam name="VO"></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, VR> LeftJoin<VR, KO, VO>(KNetKTable<KO, VO> arg0, KNetFunction<V, KO> arg1, KNetValueJoiner<V, VO, VR> arg2, KNetTableJoined<K, KO> arg3)
        {
            if (_inner == null && _inner2 != null) throw new InvalidOperationException("Current implementation does not manage KNetKTable generated from Count methods of KNetKGroupedTable");

            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            if (arg2 is IGenericSerDesFactoryApplier applier2) applier2.Factory = _factory;
            if (arg3 is IGenericSerDesFactoryApplier applier3) applier3.Factory = _factory;
            return new KNetKTable<K, VR>(_factory, _inner.LeftJoin<byte[], byte[], byte[]>(arg0, arg1, arg2, arg3));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KTable.html#leftJoin-org.apache.kafka.streams.kstream.KTable-java.util.function.Function-org.apache.kafka.streams.kstream.ValueJoiner-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></param>
        /// <param name="arg1"><see cref="Java.Util.Function.Function"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Kstream.ValueJoiner"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="KO"></typeparam>
        /// <typeparam name="VO"></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, VR> LeftJoin<VR, KO, VO>(KNetKTable<KO, VO> arg0, KNetFunction<V, KO> arg1, KNetValueJoiner<V, VO, VR> arg2)
        {
            if (_inner == null && _inner2 != null) throw new InvalidOperationException("Current implementation does not manage KNetKTable generated from Count methods of KNetKGroupedTable");

            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            if (arg2 is IGenericSerDesFactoryApplier applier2) applier2.Factory = _factory;
            return new KNetKTable<K, VR>(_factory, _inner.LeftJoin<byte[], byte[], byte[]>(arg0, arg1, arg2));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KTable.html#mapValues-org.apache.kafka.streams.kstream.ValueMapper-org.apache.kafka.streams.kstream.Materialized-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.ValueMapper"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg0ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, VR> MapValues<VR, Arg0objectSuperV, Arg0ExtendsVR>(KNetValueMapper<Arg0objectSuperV, Arg0ExtendsVR> arg0, KNetMaterialized<K, VR> arg1) where Arg0objectSuperV : V where Arg0ExtendsVR : VR
        {
            if (_inner == null && _inner2 != null) throw new InvalidOperationException("Current implementation does not manage KNetKTable generated from Count methods of KNetKGroupedTable");

            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            return new KNetKTable<K, VR>(_factory, _inner.MapValues<byte[], byte[], byte[]>(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KTable.html#mapValues-org.apache.kafka.streams.kstream.ValueMapper-org.apache.kafka.streams.kstream.Named-org.apache.kafka.streams.kstream.Materialized-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.ValueMapper"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg0ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, VR> MapValues<VR, Arg0objectSuperV, Arg0ExtendsVR>(KNetValueMapper<Arg0objectSuperV, Arg0ExtendsVR> arg0, Org.Apache.Kafka.Streams.Kstream.Named arg1, KNetMaterialized<K, VR> arg2) where Arg0objectSuperV : V where Arg0ExtendsVR : VR
        {
            if (_inner == null && _inner2 != null) throw new InvalidOperationException("Current implementation does not manage KNetKTable generated from Count methods of KNetKGroupedTable");

            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg2 is IGenericSerDesFactoryApplier applier2) applier2.Factory = _factory;
            return new KNetKTable<K, VR>(_factory, _inner.MapValues<byte[], byte[], byte[]>(arg0, arg1, arg2));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KTable.html#mapValues-org.apache.kafka.streams.kstream.ValueMapper-org.apache.kafka.streams.kstream.Named-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.ValueMapper"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg0ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, VR> MapValues<VR, Arg0objectSuperV, Arg0ExtendsVR>(KNetValueMapper<Arg0objectSuperV, Arg0ExtendsVR> arg0, Org.Apache.Kafka.Streams.Kstream.Named arg1) where Arg0objectSuperV : V where Arg0ExtendsVR : VR
        {
            if (_inner == null && _inner2 != null) throw new InvalidOperationException("Current implementation does not manage KNetKTable generated from Count methods of KNetKGroupedTable");

            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KNetKTable<K, VR>(_factory, _inner.MapValues<byte[], byte[], byte[]>(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KTable.html#mapValues-org.apache.kafka.streams.kstream.ValueMapper-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.ValueMapper"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg0ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, VR> MapValues<VR, Arg0objectSuperV, Arg0ExtendsVR>(KNetValueMapper<Arg0objectSuperV, Arg0ExtendsVR> arg0) where Arg0objectSuperV : V where Arg0ExtendsVR : VR
        {
            if (_inner == null && _inner2 != null) throw new InvalidOperationException("Current implementation does not manage KNetKTable generated from Count methods of KNetKGroupedTable");

            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KNetKTable<K, VR>(_factory, _inner.MapValues<byte[], byte[], byte[]>(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KTable.html#mapValues-org.apache.kafka.streams.kstream.ValueMapperWithKey-org.apache.kafka.streams.kstream.Materialized-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.ValueMapperWithKey"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="Arg0objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg0ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, VR> MapValues<VR, Arg0objectSuperK, Arg0objectSuperV, Arg0ExtendsVR>(KNetValueMapperWithKey<Arg0objectSuperK, Arg0objectSuperV, Arg0ExtendsVR> arg0, KNetMaterialized<K, VR> arg1) where Arg0objectSuperK : K where Arg0objectSuperV : V where Arg0ExtendsVR : VR
        {
            if (_inner == null && _inner2 != null) throw new InvalidOperationException("Current implementation does not manage KNetKTable generated from Count methods of KNetKGroupedTable");

            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            return new KNetKTable<K, VR>(_factory, _inner.MapValues<byte[], byte[], byte[], byte[]>(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KTable.html#mapValues-org.apache.kafka.streams.kstream.ValueMapperWithKey-org.apache.kafka.streams.kstream.Named-org.apache.kafka.streams.kstream.Materialized-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.ValueMapperWithKey"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="Arg0objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg0ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, VR> MapValues<VR, Arg0objectSuperK, Arg0objectSuperV, Arg0ExtendsVR>(KNetValueMapperWithKey<Arg0objectSuperK, Arg0objectSuperV, Arg0ExtendsVR> arg0, Org.Apache.Kafka.Streams.Kstream.Named arg1, KNetMaterialized<K, VR> arg2) where Arg0objectSuperK : K where Arg0objectSuperV : V where Arg0ExtendsVR : VR
        {
            if (_inner == null && _inner2 != null) throw new InvalidOperationException("Current implementation does not manage KNetKTable generated from Count methods of KNetKGroupedTable");

            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg2 is IGenericSerDesFactoryApplier applier2) applier2.Factory = _factory;
            return new KNetKTable<K, VR>(_factory, _inner.MapValues<byte[], byte[], byte[], byte[]>(arg0, arg1, arg2));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KTable.html#mapValues-org.apache.kafka.streams.kstream.ValueMapperWithKey-org.apache.kafka.streams.kstream.Named-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.ValueMapperWithKey"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="Arg0objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg0ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, VR> MapValues<VR, Arg0objectSuperK, Arg0objectSuperV, Arg0ExtendsVR>(KNetValueMapperWithKey<Arg0objectSuperK, Arg0objectSuperV, Arg0ExtendsVR> arg0, Org.Apache.Kafka.Streams.Kstream.Named arg1) where Arg0objectSuperK : K where Arg0objectSuperV : V where Arg0ExtendsVR : VR
        {
            if (_inner == null && _inner2 != null) throw new InvalidOperationException("Current implementation does not manage KNetKTable generated from Count methods of KNetKGroupedTable");

            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KNetKTable<K, VR>(_factory, _inner.MapValues<byte[], byte[], byte[], byte[]>(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KTable.html#mapValues-org.apache.kafka.streams.kstream.ValueMapperWithKey-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.ValueMapperWithKey"/></param>
        /// <typeparam name="VR"></typeparam>
        /// <typeparam name="Arg0objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <typeparam name="Arg0ExtendsVR"><typeparamref name="VR"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, VR> MapValues<VR, Arg0objectSuperK, Arg0objectSuperV, Arg0ExtendsVR>(KNetValueMapperWithKey<Arg0objectSuperK, Arg0objectSuperV, Arg0ExtendsVR> arg0) where Arg0objectSuperK : K where Arg0objectSuperV : V where Arg0ExtendsVR : VR
        {
            if (_inner == null && _inner2 != null) throw new InvalidOperationException("Current implementation does not manage KNetKTable generated from Count methods of KNetKGroupedTable");

            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KNetKTable<K, VR>(_factory, _inner.MapValues<byte[], byte[], byte[], byte[]>(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KTable.html#queryableStoreName--"/>
        /// </summary>
        /// <returns><see cref="string"/></returns>
        public string QueryableStoreName => _inner.QueryableStoreName();
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KTable.html#toStream--"/>
        /// </summary>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KStream"/></returns>
        public KNetKStream<K, V> ToStream()
        {
            if (_inner == null && _inner2 != null) throw new InvalidOperationException("Current implementation does not manage KNetKTable generated from Count methods of KNetKGroupedTable");

            return new KNetKStream<K, V>(_factory, _inner.ToStream());
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KTable.html#toStream-org.apache.kafka.streams.kstream.Named-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KStream"/></returns>
        public KNetKStream<K, V> ToStream(Org.Apache.Kafka.Streams.Kstream.Named arg0)
        {
            if (_inner == null && _inner2 != null) throw new InvalidOperationException("Current implementation does not manage KNetKTable generated from Count methods of KNetKGroupedTable");

            return new KNetKStream<K, V>(_factory, _inner.ToStream(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KTable.html#filter-org.apache.kafka.streams.kstream.Predicate-org.apache.kafka.streams.kstream.Materialized-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Predicate"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></param>
        /// <typeparam name="Arg0objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, V> Filter<Arg0objectSuperK, Arg0objectSuperV>(KNetPredicate<Arg0objectSuperK, Arg0objectSuperV> arg0, KNetMaterialized<K, V> arg1) where Arg0objectSuperK : K where Arg0objectSuperV : V
        {
            if (_inner == null && _inner2 != null) throw new InvalidOperationException("Current implementation does not manage KNetKTable generated from Count methods of KNetKGroupedTable");

            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            return new KNetKTable<K, V>(_factory, _inner.Filter<byte[], byte[]>(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KTable.html#filter-org.apache.kafka.streams.kstream.Predicate-org.apache.kafka.streams.kstream.Named-org.apache.kafka.streams.kstream.Materialized-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Predicate"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></param>
        /// <typeparam name="Arg0objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, V> Filter<Arg0objectSuperK, Arg0objectSuperV>(KNetPredicate<Arg0objectSuperK, Arg0objectSuperV> arg0, Org.Apache.Kafka.Streams.Kstream.Named arg1, KNetMaterialized<K, V> arg2) where Arg0objectSuperK : K where Arg0objectSuperV : V
        {
            if (_inner == null && _inner2 != null) throw new InvalidOperationException("Current implementation does not manage KNetKTable generated from Count methods of KNetKGroupedTable");

            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg2 is IGenericSerDesFactoryApplier applier2) applier2.Factory = _factory;
            return new KNetKTable<K, V>(_factory, _inner.Filter<byte[], byte[]>(arg0, arg1, arg2));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KTable.html#filter-org.apache.kafka.streams.kstream.Predicate-org.apache.kafka.streams.kstream.Named-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Predicate"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <typeparam name="Arg0objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, V> Filter<Arg0objectSuperK, Arg0objectSuperV>(KNetPredicate<Arg0objectSuperK, Arg0objectSuperV> arg0, Org.Apache.Kafka.Streams.Kstream.Named arg1) where Arg0objectSuperK : K where Arg0objectSuperV : V
        {
            if (_inner == null && _inner2 != null) throw new InvalidOperationException("Current implementation does not manage KNetKTable generated from Count methods of KNetKGroupedTable");

            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KNetKTable<K, V>(_factory, _inner.Filter<byte[], byte[]>(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KTable.html#filter-org.apache.kafka.streams.kstream.Predicate-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Predicate"/></param>
        /// <typeparam name="Arg0objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, V> Filter<Arg0objectSuperK, Arg0objectSuperV>(KNetPredicate<Arg0objectSuperK, Arg0objectSuperV> arg0) where Arg0objectSuperK : K where Arg0objectSuperV : V
        {
            if (_inner == null && _inner2 != null) throw new InvalidOperationException("Current implementation does not manage KNetKTable generated from Count methods of KNetKGroupedTable");

            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KNetKTable<K, V>(_factory, _inner.Filter<byte[], byte[]>(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KTable.html#filterNot-org.apache.kafka.streams.kstream.Predicate-org.apache.kafka.streams.kstream.Materialized-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Predicate"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></param>
        /// <typeparam name="Arg0objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, V> FilterNot<Arg0objectSuperK, Arg0objectSuperV>(KNetPredicate<Arg0objectSuperK, Arg0objectSuperV> arg0, KNetMaterialized<K, V> arg1) where Arg0objectSuperK : K where Arg0objectSuperV : V
        {
            if (_inner == null && _inner2 != null) throw new InvalidOperationException("Current implementation does not manage KNetKTable generated from Count methods of KNetKGroupedTable");

            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg1 is IGenericSerDesFactoryApplier applier1) applier1.Factory = _factory;
            return new KNetKTable<K, V>(_factory, _inner.FilterNot<byte[], byte[]>(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KTable.html#filterNot-org.apache.kafka.streams.kstream.Predicate-org.apache.kafka.streams.kstream.Named-org.apache.kafka.streams.kstream.Materialized-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Predicate"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Streams.Kstream.Materialized"/></param>
        /// <typeparam name="Arg0objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, V> FilterNot<Arg0objectSuperK, Arg0objectSuperV>(KNetPredicate<Arg0objectSuperK, Arg0objectSuperV> arg0, Org.Apache.Kafka.Streams.Kstream.Named arg1, KNetMaterialized<K, V> arg2) where Arg0objectSuperK : K where Arg0objectSuperV : V
        {
            if (_inner == null && _inner2 != null) throw new InvalidOperationException("Current implementation does not manage KNetKTable generated from Count methods of KNetKGroupedTable");

            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            if (arg2 is IGenericSerDesFactoryApplier applier2) applier2.Factory = _factory;
            return new KNetKTable<K, V>(_factory, _inner.FilterNot<byte[], byte[]>(arg0, arg1, arg2));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KTable.html#filterNot-org.apache.kafka.streams.kstream.Predicate-org.apache.kafka.streams.kstream.Named-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Predicate"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Named"/></param>
        /// <typeparam name="Arg0objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, V> FilterNot<Arg0objectSuperK, Arg0objectSuperV>(KNetPredicate<Arg0objectSuperK, Arg0objectSuperV> arg0, Org.Apache.Kafka.Streams.Kstream.Named arg1) where Arg0objectSuperK : K where Arg0objectSuperV : V
        {
            if (_inner == null && _inner2 != null) throw new InvalidOperationException("Current implementation does not manage KNetKTable generated from Count methods of KNetKGroupedTable");

            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KNetKTable<K, V>(_factory, _inner.FilterNot<byte[], byte[]>(arg0, arg1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KTable.html#filterNot-org.apache.kafka.streams.kstream.Predicate-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Predicate"/></param>
        /// <typeparam name="Arg0objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, V> FilterNot<Arg0objectSuperK, Arg0objectSuperV>(KNetPredicate<Arg0objectSuperK, Arg0objectSuperV> arg0) where Arg0objectSuperK : K where Arg0objectSuperV : V
        {
            if (_inner == null && _inner2 != null) throw new InvalidOperationException("Current implementation does not manage KNetKTable generated from Count methods of KNetKGroupedTable");

            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KNetKTable<K, V>(_factory, _inner.FilterNot<byte[], byte[]>(arg0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KTable.html#suppress-org.apache.kafka.streams.kstream.Suppressed-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Suppressed"/></param>
        /// <typeparam name="Arg0objectSuperK"><typeparamref name="K"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.KTable"/></returns>
        public KNetKTable<K, V> Suppress<Arg0objectSuperK>(KNetSuppressed<Arg0objectSuperK> arg0) where Arg0objectSuperK : K
        {
            if (_inner == null && _inner2 != null) throw new InvalidOperationException("Current implementation does not manage KNetKTable generated from Count methods of KNetKGroupedTable");

            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            return new KNetKTable<K, V>(_factory, _inner.Suppress<byte[]>(arg0));
        }
    }
}
