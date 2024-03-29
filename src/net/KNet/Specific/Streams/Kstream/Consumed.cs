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
using MASES.KNet.Streams.Processor;

namespace MASES.KNet.Streams.Kstream
{
    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.Consumed{K, V}"/>
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    public class Consumed<K, V> : IGenericSerDesFactoryApplier
    {
        TimestampExtractor<K, V> _timestampExtractor = null;
        readonly Org.Apache.Kafka.Streams.Kstream.Consumed<byte[], byte[]> _inner;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory
        {
            get => _factory;
            set
            {
                _factory = value;
                if (_timestampExtractor is IGenericSerDesFactoryApplier applier) applier.Factory = value;
            }
        }

        Consumed(Org.Apache.Kafka.Streams.Kstream.Consumed<byte[], byte[]> inner, TimestampExtractor<K, V> timestampExtractor = null)
        {
            _inner = inner;
            _timestampExtractor = timestampExtractor;
        }

        /// <summary>
        /// Converter from <see cref="Consumed{K, V}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.Consumed{K, V}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.Consumed<byte[], byte[]>(Consumed<K, V> t) => t._inner;

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Consumed.html#as-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="Consumed{K, V}"/></returns>
        public static Consumed<K, V> As(string arg0)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Consumed<byte[], byte[]>.As(arg0);
            return new Consumed<K, V>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Consumed.html#with-org.apache.kafka.common.serialization.Serde-org.apache.kafka.common.serialization.Serde-org.apache.kafka.streams.processor.TimestampExtractor-org.apache.kafka.streams.Topology.AutoOffsetReset-"/>
        /// </summary>
        /// <param name="arg0"><see cref="ISerDes{K}"/></param>
        /// <param name="arg1"><see cref="ISerDes{V}"/></param>
        /// <param name="arg2"><see cref="TimestampExtractor{K, V}"/></param>
        /// <param name="arg3"><see cref="Org.Apache.Kafka.Streams.Topology.AutoOffsetReset"/></param>
        /// <returns><see cref="Consumed{K, V}"/></returns>
        public static Consumed<K, V> With(ISerDes<K> arg0, ISerDes<V> arg1, TimestampExtractor<K, V> arg2, Org.Apache.Kafka.Streams.Topology.AutoOffsetReset arg3)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Consumed<byte[], byte[]>.With(arg0.KafkaSerde, arg1.KafkaSerde, arg2, arg3);
            return new Consumed<K, V>(cons, arg2);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Consumed.html#with-org.apache.kafka.common.serialization.Serde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="ISerDes{K}"/></param>
        /// <param name="arg1"><see cref="ISerDes{V}"/></param>
        /// <returns><see cref="Consumed{K, V}"/></returns>
        public static Consumed<K, V> With(ISerDes<K> arg0, ISerDes<V> arg1)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Consumed<byte[], byte[]>.With(arg0.KafkaSerde, arg1.KafkaSerde);
            return new Consumed<K, V>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Consumed.html#with-org.apache.kafka.streams.processor.TimestampExtractor-"/>
        /// </summary>
        /// <param name="arg0"><see cref="TimestampExtractor{K, V}"/></param>
        /// <returns><see cref="Consumed{K, V}"/></returns>
        public static Consumed<K, V> With(TimestampExtractor<K, V> arg0)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Consumed<byte[], byte[]>.With(arg0);
            return new Consumed<K, V>(cons, arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Consumed.html#with-org.apache.kafka.streams.Topology.AutoOffsetReset-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Topology.AutoOffsetReset"/></param>
        /// <returns><see cref="Consumed{K, V}"/></returns>
        public static Consumed<K, V> With(Org.Apache.Kafka.Streams.Topology.AutoOffsetReset arg0)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Consumed<byte[], byte[]>.With(arg0);
            return new Consumed<K, V>(cons);
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Consumed.html#withKeySerde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="ISerDes{K}"/></param>
        /// <returns><see cref="Consumed{K, V}"/></returns>
        public Consumed<K, V> WithKeySerde(ISerDes<K> arg0)
        {
            _inner?.WithKeySerde(arg0.KafkaSerde);
            return this;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Consumed.html#withOffsetResetPolicy-org.apache.kafka.streams.Topology.AutoOffsetReset-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Topology.AutoOffsetReset"/></param>
        /// <returns><see cref="Consumed{K, V}"/></returns>
        public Consumed<K, V> WithOffsetResetPolicy(Org.Apache.Kafka.Streams.Topology.AutoOffsetReset arg0)
        {
            _inner?.WithOffsetResetPolicy(arg0);
            return this;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Consumed.html#withTimestampExtractor-org.apache.kafka.streams.processor.TimestampExtractor-"/>
        /// </summary>
        /// <param name="arg0"><see cref="TimestampExtractor{K, V}"/></param>
        /// <returns><see cref="Consumed{K, V}"/></returns>
        public Consumed<K, V> WithTimestampExtractor(TimestampExtractor<K, V> arg0)
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            _timestampExtractor = arg0;
            _inner?.WithTimestampExtractor(arg0);
            return this;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Consumed.html#withValueSerde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="ISerDes{V}"/></param>
        /// <returns><see cref="Consumed{K, V}"/></returns>
        public Consumed<K, V> WithValueSerde(ISerDes<V> arg0)
        {
            _inner?.WithValueSerde(arg0.KafkaSerde);
            return this;
        }

        #endregion
    }
}
