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
        readonly Org.Apache.Kafka.Streams.Kstream.Produced<byte[], byte[]> _produced;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        KNetProduced(Org.Apache.Kafka.Streams.Kstream.Produced<byte[], byte[]> produced)
        {
            _produced = produced;
        }

        /// <summary>
        /// Converter from <see cref="KNetProduced{K, V}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.Produced{K, V}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.Produced<byte[], byte[]>(KNetProduced<K, V> t) => t._produced;

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
        public static KNetProduced<K, V> StreamPartitioner<Arg0objectSuperK, Arg0objectSuperV>(KNetStreamPartitioner<Arg0objectSuperK, Arg0objectSuperV> arg0) where Arg0objectSuperK : K where Arg0objectSuperV : V
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Produced<byte[], byte[]>.StreamPartitioner(arg0);
            return new KNetProduced<K, V>(cons);
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
        /// <typeparam name="Arg2objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg2objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="KNetProduced{K, V}"/></returns>
        public static KNetProduced<K, V> With<Arg2objectSuperK, Arg2objectSuperV>(IKNetSerDes<K> arg0, IKNetSerDes<V> arg1, KNetStreamPartitioner<Arg2objectSuperK, Arg2objectSuperV> arg2) where Arg2objectSuperK : K where Arg2objectSuperV : V
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Produced<byte[], byte[]>.With(arg0.KafkaSerde, arg1.KafkaSerde, arg2);
            return new KNetProduced<K, V>(cons);
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
            _produced?.WithKeySerde(arg0.KafkaSerde);
            return this;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Produced.html#withStreamPartitioner-org.apache.kafka.streams.processor.StreamPartitioner-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Processor.StreamPartitioner"/></param>
        /// <typeparam name="Arg0objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="KNetProduced{K, V}"/></returns>
        public KNetProduced<K, V> WithStreamPartitioner<Arg0objectSuperK, Arg0objectSuperV>(KNetStreamPartitioner<Arg0objectSuperK, Arg0objectSuperV> arg0) where Arg0objectSuperK : K where Arg0objectSuperV : V
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            _produced?.WithStreamPartitioner(arg0);
            return this;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Produced.html#withValueSerde-org.apache.kafka.common.serialization.Serde-"/>
        /// </summary>
        /// <param name="arg0"><see cref="IKNetSerDes{V}"/></param>
        /// <returns><see cref="KNetProduced{K, V}"/></returns>
        public KNetProduced<K, V> WithValueSerde(IKNetSerDes<V> arg0)
        {
            _produced?.WithValueSerde(arg0.KafkaSerde);
            return this;
        }

        #endregion
    }
}
