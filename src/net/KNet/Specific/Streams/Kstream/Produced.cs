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
using MASES.KNet.Streams.Processor;

namespace MASES.KNet.Streams.Kstream
{
    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.Produced{TJVMK, TJVMV}"/>
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
    /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
    public class Produced<K, V, TJVMK, TJVMV> : IGenericSerDesFactoryApplier
    {
        StreamPartitioner<K, V, TJVMK, TJVMV> _streamPartitioner = null;
        readonly Org.Apache.Kafka.Streams.Kstream.Produced<TJVMK, TJVMV> _inner;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory
        {
            get => _factory;
            set
            {
                _factory = value;
                if (_streamPartitioner is IGenericSerDesFactoryApplier applier) applier.Factory = value;
            }
        }

        internal Produced(Org.Apache.Kafka.Streams.Kstream.Produced<TJVMK, TJVMV> inner, StreamPartitioner<K, V, TJVMK, TJVMV> streamPartitioner = null)
        {
            _inner = inner;
            _streamPartitioner = streamPartitioner;
        }

        /// <summary>
        /// Converter from <see cref="Produced{K, V, TJVMK, TJVMV}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.Produced{TJVMK, TJVMV}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.Produced<TJVMK, TJVMV>(Produced<K, V, TJVMK, TJVMV> t) => t._inner;

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.1/org/apache/kafka/streams/kstream/Produced.html#as(java.lang.String)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="Produced{K, V, TJVMK, TJVMV}"/></returns>
        public static Produced<K, V, TJVMK, TJVMV> As(string arg0)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Produced<TJVMK, TJVMV>.As(arg0);
            return new Produced<K, V, TJVMK, TJVMV>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.1/org/apache/kafka/streams/kstream/Produced.html#keySerde(org.apache.kafka.common.serialization.Serde)"/>
        /// </summary>
        /// <param name="arg0"><see cref="ISerDes{Kafka, TJVMK}"/></param>
        /// <returns><see cref="Produced{K, V, TJVMK, TJVMV}"/></returns>
        public static Produced<K, V, TJVMK, TJVMV> KeySerde(ISerDes<K, TJVMK> arg0)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Produced<TJVMK, TJVMV>.KeySerde(arg0.KafkaSerde);
            return new Produced<K, V, TJVMK, TJVMV>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.1/org/apache/kafka/streams/kstream/Produced.html#streamPartitioner(org.apache.kafka.streams.processor.StreamPartitioner)"/>
        /// </summary>
        /// <param name="arg0"><see cref="StreamPartitioner{TKey, TValue}"/></param>
        /// <returns><see cref="Produced{K, V, TJVMK, TJVMV}"/></returns>
        public static Produced<K, V, TJVMK, TJVMV> StreamPartitioner(StreamPartitioner<K, V, TJVMK, TJVMV> arg0)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Produced<TJVMK, TJVMV>.StreamPartitioner(arg0);
            return new Produced<K, V, TJVMK, TJVMV>(cons, arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.1/org/apache/kafka/streams/kstream/Produced.html#valueSerde(org.apache.kafka.common.serialization.Serde)"/>
        /// </summary>
        /// <param name="arg0"><see cref="ISerDes{V, TJVMV}"/></param>
        /// <returns><see cref="Produced{K, V, TJVMK, TJVMV}"/></returns>
        public static Produced<K, V, TJVMK, TJVMV> ValueSerde(ISerDes<V, TJVMV> arg0)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Produced<TJVMK, TJVMV>.ValueSerde(arg0.KafkaSerde);
            return new Produced<K, V, TJVMK, TJVMV>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.1/org/apache/kafka/streams/kstream/Produced.html#with(org.apache.kafka.common.serialization.Serde,org.apache.kafka.common.serialization.Serde,org.apache.kafka.streams.processor.StreamPartitioner)"/>
        /// </summary>
        /// <param name="arg0"><see cref="ISerDes{K, TJVMK}"/></param>
        /// <param name="arg1"><see cref="ISerDes{V, TJVMV}"/></param>
        /// <param name="arg2"><see cref="StreamPartitioner{TKey, TValue}"/></param>
        /// <returns><see cref="Produced{K, V, TJVMK, TJVMV}"/></returns>
        public static Produced<K, V, TJVMK, TJVMV> With(ISerDes<K, TJVMK> arg0, ISerDes<V, TJVMV> arg1, StreamPartitioner<K, V, TJVMK, TJVMV> arg2)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Produced<TJVMK, TJVMV>.With(arg0.KafkaSerde, arg1.KafkaSerde, arg2);
            return new Produced<K, V, TJVMK, TJVMV>(cons, arg2);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.1/org/apache/kafka/streams/kstream/Produced.html#with(org.apache.kafka.common.serialization.Serde,org.apache.kafka.common.serialization.Serde)"/>
        /// </summary>
        /// <param name="arg0"><see cref="ISerDes{K, TJVMK}"/></param>
        /// <param name="arg1"><see cref="ISerDes{V, TJVMV}"/></param>
        /// <returns><see cref="Produced{K, V, TJVMK, TJVMV}"/></returns>
        public static Produced<K, V, TJVMK, TJVMV> With(ISerDes<K, TJVMK> arg0, ISerDes<V, TJVMV> arg1)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Produced<TJVMK, TJVMV>.With(arg0.KafkaSerde, arg1.KafkaSerde);
            return new Produced<K, V, TJVMK, TJVMV>(cons);
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.1/org/apache/kafka/streams/kstream/Produced.html#withKeySerde(org.apache.kafka.common.serialization.Serde)"/>
        /// </summary>
        /// <param name="arg0"><see cref="ISerDes{K, TJVMK}"/></param>
        /// <returns><see cref="Produced{K, V, TJVMK, TJVMV}"/></returns>
        public Produced<K, V, TJVMK, TJVMV> WithKeySerde(ISerDes<K, TJVMK> arg0)
        {
            _inner?.WithKeySerde(arg0.KafkaSerde);
            return this;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.1/org/apache/kafka/streams/kstream/Produced.html#withStreamPartitioner(org.apache.kafka.streams.processor.StreamPartitioner)"/>
        /// </summary>
        /// <param name="arg0"><see cref="StreamPartitioner{K, V, TJVMK, TJVMV}"/></param>
        /// <returns><see cref="Produced{K, V, TJVMK, TJVMV}"/></returns>
        public Produced<K, V, TJVMK, TJVMV> WithStreamPartitioner(StreamPartitioner<K, V, TJVMK, TJVMV> arg0)
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            _streamPartitioner = arg0;
            _inner?.WithStreamPartitioner(arg0);
            return this;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.1/org/apache/kafka/streams/kstream/Produced.html#withValueSerde(org.apache.kafka.common.serialization.Serde)"/>
        /// </summary>
        /// <param name="arg0"><see cref="ISerDes{V, TJVMV}"/></param>
        /// <returns><see cref="Produced{K, V, TJVMK, TJVMV}"/></returns>
        public Produced<K, V, TJVMK, TJVMV> WithValueSerde(ISerDes<V, TJVMV> arg0)
        {
            _inner?.WithValueSerde(arg0.KafkaSerde);
            return this;
        }

        #endregion
    }
    /// <summary>
    /// KNet extension of <see cref="Produced{K, V, TJVMK, TJVMV}"/>
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    public class Produced<K, V> : Produced<K, V, byte[], byte[]>
    {
        Produced(Org.Apache.Kafka.Streams.Kstream.Produced<byte[], byte[]> inner, StreamPartitioner<K, V, byte[], byte[]> streamPartitioner = null)
            : base(inner, streamPartitioner)
        {

        }
    }
}
