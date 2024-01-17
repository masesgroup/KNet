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
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.Produced{K, V}"/>
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    public class KNetProduced<K, V> : IGenericSerDesFactoryApplier
    {
        KNetStreamPartitioner<K, V> _streamPartitioner = null;
        readonly Org.Apache.Kafka.Streams.Kstream.Produced<byte[], byte[]> _inner;
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

        KNetProduced(Org.Apache.Kafka.Streams.Kstream.Produced<byte[], byte[]> inner, KNetStreamPartitioner<K, V> streamPartitioner = null)
        {
            _inner = inner;
            _streamPartitioner = streamPartitioner;
        }

        /// <summary>
        /// Converter from <see cref="KNetProduced{K, V}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.Produced{K, V}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.Produced<byte[], byte[]>(KNetProduced<K, V> t) => t._inner;

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Produced.html#as-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="KNetProduced{K, V}"/></returns>
        public static KNetProduced<K, V> As(string arg0)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Produced<byte[], byte[]>.As(arg0);
            return new KNetProduced<K, V>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Produced.html#keySerde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="IKNetSerDes{T}"/></param>
        /// <returns><see cref="KNetProduced{K, V}"/></returns>
        public static KNetProduced<K, V> KeySerde(IKNetSerDes<K> arg0)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Produced<byte[], byte[]>.KeySerde(arg0.KafkaSerde);
            return new KNetProduced<K, V>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Produced.html#streamPartitioner-org.apache.kafka.streams.processor.StreamPartitioner-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KNetStreamPartitioner{TKey, TValue}"/></param>
        /// <typeparam name="Arg0objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="KNetProduced{K, V}"/></returns>
        public static KNetProduced<K, V> StreamPartitioner(KNetStreamPartitioner<K, V> arg0)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Produced<byte[], byte[]>.StreamPartitioner(arg0);
            return new KNetProduced<K, V>(cons, arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Produced.html#valueSerde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="IKNetSerDes{V}"/></param>
        /// <returns><see cref="KNetProduced{K, V}"/></returns>
        public static KNetProduced<K, V> ValueSerde(IKNetSerDes<V> arg0)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Produced<byte[], byte[]>.ValueSerde(arg0.KafkaSerde);
            return new KNetProduced<K, V>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Produced.html#with-org.apache.kafka.common.serialization.Serde-org.apache.kafka.common.serialization.Serde-org.apache.kafka.streams.processor.StreamPartitioner-"/>
        /// </summary>
        /// <param name="arg0"><see cref="IKNetSerDes{K}"/></param>
        /// <param name="arg1"><see cref="IKNetSerDes{V}"/></param>
        /// <param name="arg2"><see cref="KNetStreamPartitioner{TKey, TValue}"/></param>
        /// <returns><see cref="KNetProduced{K, V}"/></returns>
        public static KNetProduced<K, V> With(IKNetSerDes<K> arg0, IKNetSerDes<V> arg1, KNetStreamPartitioner<K, V> arg2)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Produced<byte[], byte[]>.With(arg0.KafkaSerde, arg1.KafkaSerde, arg2);
            return new KNetProduced<K, V>(cons, arg2);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Produced.html#with-org.apache.kafka.common.serialization.Serde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="IKNetSerDes{K}"/></param>
        /// <param name="arg1"><see cref="IKNetSerDes{V}"/></param>
        /// <returns><see cref="KNetProduced{K, V}"/></returns>
        public static KNetProduced<K, V> With(IKNetSerDes<K> arg0, IKNetSerDes<V> arg1)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Produced<byte[], byte[]>.With(arg0.KafkaSerde, arg1.KafkaSerde);
            return new KNetProduced<K, V>(cons);
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Produced.html#withKeySerde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="IKNetSerDes{K}"/></param>
        /// <returns><see cref="KNetProduced{K, V}"/></returns>
        public KNetProduced<K, V> WithKeySerde(IKNetSerDes<K> arg0)
        {
            _inner?.WithKeySerde(arg0.KafkaSerde);
            return this;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Produced.html#withStreamPartitioner-org.apache.kafka.streams.processor.StreamPartitioner-"/>
        /// </summary>
        /// <param name="arg0"><see cref="KNetStreamPartitioner{K, V}"/></param>
        /// <returns><see cref="KNetProduced{K, V}"/></returns>
        public KNetProduced<K, V> WithStreamPartitioner(KNetStreamPartitioner<K, V> arg0)
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            _streamPartitioner = arg0;
            _inner?.WithStreamPartitioner(arg0);
            return this;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Produced.html#withValueSerde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="IKNetSerDes{V}"/></param>
        /// <returns><see cref="KNetProduced{K, V}"/></returns>
        public KNetProduced<K, V> WithValueSerde(IKNetSerDes<V> arg0)
        {
            _inner?.WithValueSerde(arg0.KafkaSerde);
            return this;
        }

        #endregion
    }
}
