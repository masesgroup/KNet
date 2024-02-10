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
using System;

namespace MASES.KNet.Streams.Kstream
{
    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.Joined{K, V, VO}"/>
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <typeparam name="VO"></typeparam>
    public class KNetJoined<K, V, VO> : IGenericSerDesFactoryApplier
    {
        readonly Org.Apache.Kafka.Streams.Kstream.Joined<byte[], byte[], byte[]> _inner;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        KNetJoined(Org.Apache.Kafka.Streams.Kstream.Joined<byte[], byte[], byte[]> inner)
        {
            _inner = inner;
        }

        /// <summary>
        /// Converter from <see cref="KNetJoined{K, V, VO}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.Joined{K, V, VO}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.Joined<byte[], byte[], byte[]>(KNetJoined<K, V, VO> t) => t._inner;

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Joined.html#as-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="KNetJoined{K, V, VO}"/></returns>
        public static KNetJoined<K, V, VO> As(string arg0)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Joined<byte[], byte[], byte[]>.As(arg0);
            return new KNetJoined<K, V, VO>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Joined.html#keySerde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="IKNetSerDes{K}"/></param>
        /// <returns><see cref="KNetJoined{K, V, VO}"/></returns>
        public static KNetJoined<K, V, VO> KeySerde(IKNetSerDes<K> arg0)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Joined<byte[], byte[], byte[]>.KeySerde(arg0.KafkaSerde);
            return new KNetJoined<K, V, VO>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Joined.html#otherValueSerde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="IKNetSerDes{VO}"/></param>
        /// <returns><see cref="KNetJoined{K, V, VO}"/></returns>
        public static KNetJoined<K, V, VO> OtherValueSerde(IKNetSerDes<VO> arg0)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Joined<byte[], byte[], byte[]>.OtherValueSerde(arg0.KafkaSerde);
            return new KNetJoined<K, V, VO>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Joined.html#valueSerde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="IKNetSerDes{V}"/></param>
        /// <returns><see cref="KNetJoined{K, V, VO}"/></returns>
        public static KNetJoined<K, V, VO> ValueSerde(IKNetSerDes<V> arg0)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Joined<byte[], byte[], byte[]>.ValueSerde(arg0.KafkaSerde);
            return new KNetJoined<K, V, VO>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Joined.html#with-org.apache.kafka.common.serialization.Serde-org.apache.kafka.common.serialization.Serde-org.apache.kafka.common.serialization.Serde-java.lang.String-java.time.Duration-"/>
        /// </summary>
        /// <param name="arg0"><see cref="IKNetSerDes{K}"/></param>
        /// <param name="arg1"><see cref="IKNetSerDes{V}"/></param>
        /// <param name="arg2"><see cref="IKNetSerDes{VO}"/></param>
        /// <param name="arg3"><see cref="string"/></param>
        /// <param name="arg4"><see cref="System.TimeSpan"/></param>
        /// <returns><see cref="KNetJoined{K, V, VO}"/></returns>
        public static KNetJoined<K, V, VO> With(IKNetSerDes<K> arg0, IKNetSerDes<V> arg1, IKNetSerDes<VO> arg2, string arg3, System.TimeSpan arg4)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Joined<byte[], byte[], byte[]>.With(arg0.KafkaSerde, arg1.KafkaSerde, arg2.KafkaSerde, arg3, arg4);
            return new KNetJoined<K, V, VO>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Joined.html#with-org.apache.kafka.common.serialization.Serde-org.apache.kafka.common.serialization.Serde-org.apache.kafka.common.serialization.Serde-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="IKNetSerDes{K}"/></param>
        /// <param name="arg1"><see cref="IKNetSerDes{V}"/></param>
        /// <param name="arg2"><see cref="IKNetSerDes{VO}"/></param>
        /// <param name="arg3"><see cref="string"/></param>
        /// <returns><see cref="KNetJoined{K, V, VO}"/></returns>
        public static KNetJoined<K, V, VO> With(IKNetSerDes<K> arg0, IKNetSerDes<V> arg1, IKNetSerDes<VO> arg2, string arg3)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Joined<byte[], byte[], byte[]>.With(arg0.KafkaSerde, arg1.KafkaSerde, arg2.KafkaSerde, arg3);
            return new KNetJoined<K, V, VO>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Joined.html#with-org.apache.kafka.common.serialization.Serde-org.apache.kafka.common.serialization.Serde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="IKNetSerDes{K}"/></param>
        /// <param name="arg1"><see cref="IKNetSerDes{V}"/></param>
        /// <param name="arg2"><see cref="IKNetSerDes{VO}"/></param>
        /// <returns><see cref="KNetJoined{K, V, VO}"/></returns>
        public static KNetJoined<K, V, VO> With(IKNetSerDes<K> arg0, IKNetSerDes<V> arg1, IKNetSerDes<VO> arg2)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Joined<byte[], byte[], byte[]>.With(arg0.KafkaSerde, arg1.KafkaSerde, arg2.KafkaSerde);
            return new KNetJoined<K, V, VO>(cons);
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Joined.html#gracePeriod--"/>
        /// </summary>
        /// <returns><see cref="System.TimeSpan"/></returns>
        public System.TimeSpan GracePeriod => TimeSpan.FromMilliseconds(_inner.GracePeriod().ToMillis());
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Joined.html#withGracePeriod-java.time.Duration-"/>
        /// </summary>
        /// <param name="arg0"><see cref="System.TimeSpan"/></param>
        /// <returns><see cref="KNetJoined{K, V, VO}"/></returns>
        public KNetJoined<K, V, VO> WithGracePeriod(System.TimeSpan arg0)
        {
            _inner?.WithGracePeriod(arg0);
            return this;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Joined.html#withKeySerde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="IKNetSerDes{K}"/></param>
        /// <returns><see cref="KNetJoined{K, V, VO}"/></returns>
        public KNetJoined<K, V, VO> WithKeySerde(IKNetSerDes<K> arg0)
        {
            _inner?.WithKeySerde(arg0.KafkaSerde);
            return this;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Joined.html#withOtherValueSerde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="IKNetSerDes{VO}"/></param>
        /// <returns><see cref="KNetJoined{K, V, VO}"/></returns>
        public KNetJoined<K, V, VO> WithOtherValueSerde(IKNetSerDes<VO> arg0)
        {
            _inner?.WithOtherValueSerde(arg0.KafkaSerde);
            return this;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Joined.html#withValueSerde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="IKNetSerDes{V}"/></param>
        /// <returns><see cref="KNetJoined{K, V, VO}"/></returns>
        public KNetJoined<K, V, VO> WithValueSerde(IKNetSerDes<V> arg0)
        {
            _inner?.WithValueSerde(arg0.KafkaSerde);
            return this;
        }

        #endregion
    }
}
