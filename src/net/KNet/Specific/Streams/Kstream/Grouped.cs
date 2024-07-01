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
using MASES.KNet.Streams.Processor;

namespace MASES.KNet.Streams.Kstream
{
    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.Grouped{TJVMK, TJVMV}"/>
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    /// <typeparam name="TJVMK">The JVM key typ</typeparam>
    /// <typeparam name="TJVMV">The JVM value type</typeparam>
    public class Grouped<K, V, TJVMK, TJVMV> : IGenericSerDesFactoryApplier
    {
        readonly Org.Apache.Kafka.Streams.Kstream.Grouped<TJVMK, TJVMV> _inner;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        internal Grouped(Org.Apache.Kafka.Streams.Kstream.Grouped<TJVMK, TJVMV> inner)
        {
            _inner = inner;
        }

        /// <summary>
        /// Converter from <see cref="Grouped{K, V, TJVMK, TJVMV}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.Grouped{K, V}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.Grouped<TJVMK, TJVMV>(Grouped<K, V, TJVMK, TJVMV> t) => t._inner;

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.7.0/org/apache/kafka/streams/kstream/Grouped.html#as-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="Grouped{K, V, TJVMK, TJVMV}"/></returns>
        public static Grouped<K, V, TJVMK, TJVMV> As(string arg0)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Grouped<TJVMK, TJVMV>.As(arg0);
            return new Grouped<K, V, TJVMK, TJVMV>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.7.0/org/apache/kafka/streams/kstream/Grouped.html#keySerde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="ISerDes{K, TJVMK}"/></param>
        /// <returns><see cref="Grouped{K, V, TJVMK, TJVMV}"/></returns>
        public static Grouped<K, V, TJVMK, TJVMV> KeySerde(ISerDes<K, TJVMK> arg0)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Grouped<TJVMK, TJVMV>.KeySerde(arg0.KafkaSerde);
            return new Grouped<K, V, TJVMK, TJVMV>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.7.0/org/apache/kafka/streams/kstream/Grouped.html#valueSerde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="ISerDes{V, TJVMV}"/></param>
        /// <returns><see cref="Grouped{K, V, TJVMK, TJVMV}"/></returns>
        public static Grouped<K, V, TJVMK, TJVMV> ValueSerde(ISerDes<V, TJVMV> arg0)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Grouped<TJVMK, TJVMV>.ValueSerde(arg0.KafkaSerde);
            return new Grouped<K, V, TJVMK, TJVMV>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.7.0/org/apache/kafka/streams/kstream/Grouped.html#with-java.lang.String-org.apache.kafka.common.serialization.Serde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="ISerDes{K, TJVMK}"/></param>
        /// <param name="arg2"><see cref="ISerDes{V, TJVMV}"/></param>
        /// <returns><see cref="Grouped{K, V, TJVMK, TJVMV}"/></returns>
        public static Grouped<K, V, TJVMK, TJVMV> With(string arg0, ISerDes<K, TJVMK> arg1, ISerDes<V, TJVMV> arg2)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Grouped<TJVMK, TJVMV>.With(arg0, arg1.KafkaSerde, arg2.KafkaSerde);
            return new Grouped<K, V, TJVMK, TJVMV>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.7.0/org/apache/kafka/streams/kstream/Grouped.html#with-org.apache.kafka.common.serialization.Serde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="ISerDes{K, TJVMK}"/></param>
        /// <param name="arg1"><see cref="ISerDes{V, TJVMV}"/></param>
        /// <returns><see cref="Grouped{K, V, TJVMK, TJVMV}"/></returns>
        public static Grouped<K, V, TJVMK, TJVMV> With(ISerDes<K, TJVMK> arg0, ISerDes<V, TJVMV> arg1)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Grouped<TJVMK, TJVMV>.With(arg0.KafkaSerde, arg1.KafkaSerde);
            return new Grouped<K, V, TJVMK, TJVMV>(cons);
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.7.0/org/apache/kafka/streams/kstream/Grouped.html#withKeySerde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="ISerDes{K, TJVMK}"/></param>
        /// <returns><see cref="Grouped{K, V, TJVMK, TJVMV}"/></returns>
        public Grouped<K, V, TJVMK, TJVMV> WithKeySerde(ISerDes<K, TJVMK> arg0)
        {
            _inner?.WithKeySerde(arg0.KafkaSerde);
            return this;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.7.0/org/apache/kafka/streams/kstream/Grouped.html#withValueSerde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="ISerDes{V, TJVMV}"/></param>
        /// <returns><see cref="Grouped{K, V, TJVMK, TJVMV}"/></returns>
        public Grouped<K, V, TJVMK, TJVMV> WithValueSerde(ISerDes<V, TJVMV> arg0)
        {
            _inner?.WithValueSerde(arg0.KafkaSerde);
            return this;
        }

        #endregion
    }

    /// <summary>
    /// KNet extension of <see cref="Grouped{K, V, TJVMK, TJVMV}"/>
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    public class Grouped<K, V> : Grouped<K, V, byte[], byte[]>
    {
        Grouped(Org.Apache.Kafka.Streams.Kstream.Grouped<byte[], byte[]> inner) : base(inner)
        {
        }
    }
}
