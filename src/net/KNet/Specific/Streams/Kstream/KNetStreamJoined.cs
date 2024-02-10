﻿/*
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
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.StreamJoined{K, V1, V2}"/>
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V1"></typeparam>
    /// <typeparam name="V2"></typeparam>
    public class KNetStreamJoined<K, V1, V2> : IGenericSerDesFactoryApplier
    {
        readonly Org.Apache.Kafka.Streams.Kstream.StreamJoined<byte[], byte[], byte[]> _inner;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        KNetStreamJoined(Org.Apache.Kafka.Streams.Kstream.StreamJoined<byte[], byte[], byte[]> inner)
        {
            _inner = inner;
        }

        /// <summary>
        /// Converter from <see cref="KNetGrouped{K, V}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.StreamJoined{K, V1, V2}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.StreamJoined<byte[], byte[], byte[]>(KNetStreamJoined<K, V1, V2> t) => t._inner;

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/StreamJoined.html#as-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="KNetStreamJoined{K, V1, V2}"/></returns>
        public static KNetStreamJoined<K, V1, V2> As(string arg0)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.StreamJoined<byte[], byte[], byte[]>.As(arg0);
            return new KNetStreamJoined<K, V1, V2>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/StreamJoined.html#with-org.apache.kafka.common.serialization.Serde-org.apache.kafka.common.serialization.Serde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="IKNetSerDes{K}"/></param>
        /// <param name="arg1"><see cref="IKNetSerDes{V1}"/></param>
        /// <param name="arg2"><see cref="IKNetSerDes{V2}"/></param>
        /// <returns><see cref="KNetStreamJoined{K, V1, V2}"/></returns>
        public static KNetStreamJoined<K, V1, V2> With(IKNetSerDes<K> arg0, IKNetSerDes<V1> arg1, IKNetSerDes<V2> arg2)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.StreamJoined<byte[], byte[], byte[]>.With(arg0.KafkaSerde, arg1.KafkaSerde, arg2.KafkaSerde);
            return new KNetStreamJoined<K, V1, V2>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/StreamJoined.html#with-org.apache.kafka.streams.state.WindowBytesStoreSupplier-org.apache.kafka.streams.state.WindowBytesStoreSupplier-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.State.WindowBytesStoreSupplier"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.State.WindowBytesStoreSupplier"/></param>
        /// <returns><see cref="KNetStreamJoined{K, V1, V2}"/></returns>
        public static KNetStreamJoined<K, V1, V2> With(Org.Apache.Kafka.Streams.State.WindowBytesStoreSupplier arg0, Org.Apache.Kafka.Streams.State.WindowBytesStoreSupplier arg1)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.StreamJoined<byte[], byte[], byte[]>.With(arg0, arg1);
            return new KNetStreamJoined<K, V1, V2>(cons);
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/StreamJoined.html#withKeySerde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="IKNetSerDes{K}"/></param>
        /// <returns><see cref="KNetStreamJoined{K, V1, V2}"/></returns>
        public KNetStreamJoined<K, V1, V2> WithKeySerde(IKNetSerDes<K> arg0)
        {
            _inner?.WithKeySerde(arg0.KafkaSerde);
            return this;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/StreamJoined.html#withLoggingDisabled--"/>
        /// </summary>
        /// <returns><see cref="KNetStreamJoined{K, V1, V2}"/></returns>
        public KNetStreamJoined<K, V1, V2> WithLoggingDisabled()
        {
            _inner?.WithLoggingDisabled();
            return this;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/StreamJoined.html#withLoggingEnabled-java.util.Map-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Map"/></param>
        /// <returns><see cref="KNetStreamJoined{K, V1, V2}"/></returns>
        public KNetStreamJoined<K, V1, V2> WithLoggingEnabled(Java.Util.Map<string, string> arg0)
        {
            _inner?.WithLoggingEnabled(arg0);
            return this;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/StreamJoined.html#withOtherStoreSupplier-org.apache.kafka.streams.state.WindowBytesStoreSupplier-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.State.WindowBytesStoreSupplier"/></param>
        /// <returns><see cref="KNetStreamJoined{K, V1, V2}"/></returns>
        public KNetStreamJoined<K, V1, V2> WithOtherStoreSupplier(Org.Apache.Kafka.Streams.State.WindowBytesStoreSupplier arg0)
        {
            _inner?.WithOtherStoreSupplier(arg0);
            return this;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/StreamJoined.html#withOtherValueSerde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="IKNetSerDes{V2}"/></param>
        /// <returns><see cref="KNetStreamJoined{K, V1, V2}"/></returns>
        public KNetStreamJoined<K, V1, V2> WithOtherValueSerde(IKNetSerDes<V2> arg0)
        {
            _inner?.WithOtherValueSerde(arg0.KafkaSerde);
            return this;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/StreamJoined.html#withStoreName-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="KNetStreamJoined{K, V1, V2}"/></returns>
        public KNetStreamJoined<K, V1, V2> WithStoreName(string arg0)
        {
            _inner?.WithStoreName(arg0);
            return this;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/StreamJoined.html#withThisStoreSupplier-org.apache.kafka.streams.state.WindowBytesStoreSupplier-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.State.WindowBytesStoreSupplier"/></param>
        /// <returns><see cref="KNetStreamJoined{K, V1, V2}"/></returns>
        public KNetStreamJoined<K, V1, V2> WithThisStoreSupplier(Org.Apache.Kafka.Streams.State.WindowBytesStoreSupplier arg0)
        {
            _inner?.WithThisStoreSupplier(arg0);
            return this;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/StreamJoined.html#withValueSerde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="IKNetSerDes{V1}"/></param>
        /// <returns><see cref="KNetStreamJoined{K, V1, V2}"/></returns>
        public KNetStreamJoined<K, V1, V2> WithValueSerde(IKNetSerDes<V1> arg0)
        {
            _inner?.WithValueSerde(arg0.KafkaSerde);
            return this;
        }

        #endregion
    }
}
