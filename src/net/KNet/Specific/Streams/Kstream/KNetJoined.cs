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
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.Joined{TJVMK, TJVMV, TJVMVO}"/>
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <typeparam name="VO"></typeparam>
    public class KNetJoined<K, V, VO, TJVMK, TJVMV, TJVMVO> : IGenericSerDesFactoryApplier
    {
        readonly Org.Apache.Kafka.Streams.Kstream.Joined<TJVMK, TJVMV, TJVMVO> _inner;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        protected KNetJoined(Org.Apache.Kafka.Streams.Kstream.Joined<TJVMK, TJVMV, TJVMVO> inner)
        {
            _inner = inner;
        }

        /// <summary>
        /// Converter from <see cref="KNetJoined{K, V, VO, TJVMK, TJVMV, TJVMVO}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.Joined{TJVMK, TJVMV, TJVMVO}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.Joined<TJVMK, TJVMV, TJVMVO>(KNetJoined<K, V, VO, TJVMK, TJVMV, TJVMVO> t) => t._inner;

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Joined.html#as-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="KNetJoined{K, V, VO, TJVMK, TJVMV, TJVMVO}"/></returns>
        public static KNetJoined<K, V, VO, TJVMK, TJVMV, TJVMVO> As(string arg0)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Joined<TJVMK, TJVMV, TJVMVO>.As(arg0);
            return new KNetJoined<K, V, VO, TJVMK, TJVMV, TJVMVO>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Joined.html#keySerde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="IKNetSerDes{K, TJVMK}"/></param>
        /// <returns><see cref="KNetJoined{K, V, VO, TJVMK, TJVMV, TJVMVO}"/></returns>
        public static KNetJoined<K, V, VO, TJVMK, TJVMV, TJVMVO> KeySerde(IKNetSerDes<K, TJVMK> arg0)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Joined<TJVMK, TJVMV, TJVMVO>.KeySerde(arg0.KafkaSerde);
            return new KNetJoined<K, V, VO, TJVMK, TJVMV, TJVMVO>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Joined.html#otherValueSerde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="IKNetSerDes{VO, TJVMVO}"/></param>
        /// <returns><see cref="KNetJoined{K, V, VO, TJVMK, TJVMV, TJVMVO}"/></returns>
        public static KNetJoined<K, V, VO, TJVMK, TJVMV, TJVMVO> OtherValueSerde(IKNetSerDes<VO, TJVMVO> arg0)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Joined<TJVMK, TJVMV, TJVMVO>.OtherValueSerde(arg0.KafkaSerde);
            return new KNetJoined<K, V, VO, TJVMK, TJVMV, TJVMVO>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Joined.html#valueSerde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="IKNetSerDes{V, TJVMV}"/></param>
        /// <returns><see cref="KNetJoined{K, V, VO, TJVMK, TJVMV, TJVMVO}"/></returns>
        public static KNetJoined<K, V, VO, TJVMK, TJVMV, TJVMVO> ValueSerde(IKNetSerDes<V, TJVMV> arg0)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Joined<TJVMK, TJVMV, TJVMVO>.ValueSerde(arg0.KafkaSerde);
            return new KNetJoined<K, V, VO, TJVMK, TJVMV, TJVMVO>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Joined.html#with-org.apache.kafka.common.serialization.Serde-org.apache.kafka.common.serialization.Serde-org.apache.kafka.common.serialization.Serde-java.lang.String-java.time.Duration-"/>
        /// </summary>
        /// <param name="arg0"><see cref="IKNetSerDes{K}"/></param>
        /// <param name="arg1"><see cref="IKNetSerDes{V}"/></param>
        /// <param name="arg2"><see cref="IKNetSerDes{VO}"/></param>
        /// <param name="arg3"><see cref="string"/></param>
        /// <param name="arg4"><see cref="System.TimeSpan"/></param>
        /// <returns><see cref="KNetJoined{K, V, VO, TJVMK, TJVMV, TJVMVO}"/></returns>
        public static KNetJoined<K, V, VO, TJVMK, TJVMV, TJVMVO> With(IKNetSerDes<K, TJVMK> arg0, IKNetSerDes<V, TJVMV> arg1, IKNetSerDes<VO, TJVMVO> arg2, string arg3, System.TimeSpan arg4)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Joined<TJVMK, TJVMV, TJVMVO>.With(arg0.KafkaSerde, arg1.KafkaSerde, arg2.KafkaSerde, arg3, arg4);
            return new KNetJoined<K, V, VO, TJVMK, TJVMV, TJVMVO>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Joined.html#with-org.apache.kafka.common.serialization.Serde-org.apache.kafka.common.serialization.Serde-org.apache.kafka.common.serialization.Serde-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="IKNetSerDes{K, TJVMK}"/></param>
        /// <param name="arg1"><see cref="IKNetSerDes{V, TJVMV}"/></param>
        /// <param name="arg2"><see cref="IKNetSerDes{VO, TJVMVO}"/></param>
        /// <param name="arg3"><see cref="string"/></param>
        /// <returns><see cref="KNetJoined{K, V, VO, TJVMK, TJVMV, TJVMVO}"/></returns>
        public static KNetJoined<K, V, VO, TJVMK, TJVMV, TJVMVO> With(IKNetSerDes<K, TJVMK> arg0, IKNetSerDes<V, TJVMV> arg1, IKNetSerDes<VO, TJVMVO> arg2, string arg3)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Joined<TJVMK, TJVMV, TJVMVO>.With(arg0.KafkaSerde, arg1.KafkaSerde, arg2.KafkaSerde, arg3);
            return new KNetJoined<K, V, VO, TJVMK, TJVMV, TJVMVO>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Joined.html#with-org.apache.kafka.common.serialization.Serde-org.apache.kafka.common.serialization.Serde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="IKNetSerDes{K, TJVMK}"/></param>
        /// <param name="arg1"><see cref="IKNetSerDes{V, TJVMV}"/></param>
        /// <param name="arg2"><see cref="IKNetSerDes{VO, TJVMVO}"/></param>
        /// <returns><see cref="KNetJoined{K, V, VO, TJVMK, TJVMV, TJVMVO}"/></returns>
        public static KNetJoined<K, V, VO, TJVMK, TJVMV, TJVMVO> With(IKNetSerDes<K, TJVMK> arg0, IKNetSerDes<V, TJVMV> arg1, IKNetSerDes<VO, TJVMVO> arg2)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Joined<TJVMK, TJVMV, TJVMVO>.With(arg0.KafkaSerde, arg1.KafkaSerde, arg2.KafkaSerde);
            return new KNetJoined<K, V, VO, TJVMK, TJVMV, TJVMVO>(cons);
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
        /// <returns><see cref="KNetJoined{K, V, VO, TJVMK, TJVMV, TJVMVO}"/></returns>
        public KNetJoined<K, V, VO, TJVMK, TJVMV, TJVMVO> WithGracePeriod(System.TimeSpan arg0)
        {
            _inner?.WithGracePeriod(arg0);
            return this;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Joined.html#withKeySerde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="IKNetSerDes{K}"/></param>
        /// <returns><see cref="KNetJoined{K, V, VO, TJVMK, TJVMV, TJVMVO}"/></returns>
        public KNetJoined<K, V, VO, TJVMK, TJVMV, TJVMVO> WithKeySerde(IKNetSerDes<K, TJVMK> arg0)
        {
            _inner?.WithKeySerde(arg0.KafkaSerde);
            return this;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Joined.html#withOtherValueSerde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="IKNetSerDes{VO, TJVMVO}"/></param>
        /// <returns><see cref="KNetJoined{K, V, VO, TJVMK, TJVMV, TJVMVO}"/></returns>
        public KNetJoined<K, V, VO, TJVMK, TJVMV, TJVMVO> WithOtherValueSerde(IKNetSerDes<VO, TJVMVO> arg0)
        {
            _inner?.WithOtherValueSerde(arg0.KafkaSerde);
            return this;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Joined.html#withValueSerde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="IKNetSerDes{V, TJVMV}"/></param>
        /// <returns><see cref="KNetJoined{K, V, VO, TJVMK, TJVMV, TJVMVO}"/></returns>
        public KNetJoined<K, V, VO, TJVMK, TJVMV, TJVMVO> WithValueSerde(IKNetSerDes<V, TJVMV> arg0)
        {
            _inner?.WithValueSerde(arg0.KafkaSerde);
            return this;
        }

        #endregion
    }

    /// <summary>
    /// KNet extension of <see cref="KNetJoined{K, V, VO, TJVMK, TJVMV, TJVMVO}"/>
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <typeparam name="VO"></typeparam>
    public class KNetJoined<K, V, VO> : KNetJoined<K, V, VO, byte[], byte[], byte[]>
    {
        KNetJoined(Org.Apache.Kafka.Streams.Kstream.Joined<byte[], byte[], byte[]> inner) : base(inner)
        {

        }
    }
}
