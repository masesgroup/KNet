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

using Javax.Management;
using MASES.KNet.Serialization;
using MASES.KNet.Streams.Processor;

namespace MASES.KNet.Streams.Kstream
{
    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.Consumed{K, V}"/>
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
    /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
    public class Consumed<K, V, TJVMK, TJVMV> : IGenericSerDesFactoryApplier
    {
        ISerDes<K, TJVMK> _keySerdes;
        ISerDes<V, TJVMV> _valueSerdes;

        TimestampExtractor<K, V, TJVMK, TJVMV> _timestampExtractor = null;
        readonly Org.Apache.Kafka.Streams.Kstream.Consumed<TJVMK, TJVMV> _inner;
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

        Consumed(Org.Apache.Kafka.Streams.Kstream.Consumed<TJVMK, TJVMV> inner)
        {
            _inner = inner;
        }

        /// <summary>
        /// Converter from <see cref="Consumed{K, V, TJVMK, TJVMV}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.Consumed{TJVMK, TJVMV}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.Consumed<TJVMK, TJVMV>(Consumed<K, V, TJVMK, TJVMV> t) => t._inner;

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/Consumed.html#as(java.lang.String)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="Consumed{K, V, TJVMK, TJVMV}"/></returns>
        public static Consumed<K, V, TJVMK, TJVMV> As(string arg0)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Consumed<TJVMK, TJVMV>.As(arg0);
            return new Consumed<K, V, TJVMK, TJVMV>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/Consumed.html#with(org.apache.kafka.common.serialization.Serde,org.apache.kafka.common.serialization.Serde,org.apache.kafka.streams.processor.TimestampExtractor,Org.Apache.Kafka.Streams.AutoOffsetReset)"/>
        /// </summary>
        /// <param name="arg0"><see cref="ISerDes{K, TJVMK}"/></param>
        /// <param name="arg1"><see cref="ISerDes{V, TJVMV}"/></param>
        /// <param name="arg2"><see cref="TimestampExtractor{K, V, TJVMK, TJVMV}"/></param>
        /// <param name="arg3"><see cref="Org.Apache.Kafka.Streams.AutoOffsetReset"/></param>
        /// <returns><see cref="Consumed{K, V, TJVMK, TJVMV}"/></returns>
        public static Consumed<K, V, TJVMK, TJVMV> With(ISerDes<K, TJVMK> arg0, ISerDes<V, TJVMV> arg1, TimestampExtractor<K, V, TJVMK, TJVMV> arg2, Org.Apache.Kafka.Streams.AutoOffsetReset arg3)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Consumed<TJVMK, TJVMV>.With(arg0.KafkaSerde, arg1.KafkaSerde, arg2, arg3);
            var instance = new Consumed<K, V, TJVMK, TJVMV>(cons);
            instance._keySerdes = arg0;
            instance._valueSerdes = arg1;
            instance._timestampExtractor = arg2;
            return instance;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/Consumed.html#with(org.apache.kafka.common.serialization.Serde,org.apache.kafka.common.serialization.Serde)"/>
        /// </summary>
        /// <param name="arg0"><see cref="ISerDes{K, TJVMK}"/></param>
        /// <param name="arg1"><see cref="ISerDes{V, TJVMV}"/></param>
        /// <returns><see cref="Consumed{K, V, TJVMK, TJVMV}"/></returns>
        public static Consumed<K, V, TJVMK, TJVMV> With(ISerDes<K, TJVMK> arg0, ISerDes<V, TJVMV> arg1)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Consumed<TJVMK, TJVMV>.With(arg0.KafkaSerde, arg1.KafkaSerde);
            var instance = new Consumed<K, V, TJVMK, TJVMV>(cons);
            instance._keySerdes = arg0;
            instance._valueSerdes = arg1;
            return instance;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/Consumed.html#with(org.apache.kafka.streams.processor.TimestampExtractor)"/>
        /// </summary>
        /// <param name="arg0"><see cref="TimestampExtractor{K, V, TJVMK, TJVMV}"/></param>
        /// <returns><see cref="Consumed{K, V, TJVMK, TJVMV}"/></returns>
        public static Consumed<K, V, TJVMK, TJVMV> With(TimestampExtractor<K, V, TJVMK, TJVMV> arg0)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Consumed<TJVMK, TJVMV>.With(arg0);
            var instance = new Consumed<K, V, TJVMK, TJVMV>(cons);
            instance._timestampExtractor = arg0;
            return instance;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/Consumed.html#with(Org.Apache.Kafka.Streams.AutoOffsetReset)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.AutoOffsetReset"/></param>
        /// <returns><see cref="Consumed{K, V, TJVMK, TJVMV}"/></returns>
        public static Consumed<K, V, TJVMK, TJVMV> With(Org.Apache.Kafka.Streams.AutoOffsetReset arg0)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Consumed<TJVMK, TJVMV>.With(arg0);
            return new Consumed<K, V, TJVMK, TJVMV>(cons);
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/Consumed.html#withKeySerde(org.apache.kafka.common.serialization.Serde)"/>
        /// </summary>
        /// <param name="arg0"><see cref="ISerDes{K, TJVMK}"/></param>
        /// <returns><see cref="Consumed{K, V, TJVMK, TJVMV}"/></returns>
        public Consumed<K, V, TJVMK, TJVMV> WithKeySerde(ISerDes<K, TJVMK> arg0)
        {
            _inner?.WithKeySerde(arg0.KafkaSerde);
            _keySerdes = arg0;
            return this;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/Consumed.html#withOffsetResetPolicy(Org.Apache.Kafka.Streams.AutoOffsetReset)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.AutoOffsetReset"/></param>
        /// <returns><see cref="Consumed{K, V, TJVMK, TJVMV}"/></returns>
        public Consumed<K, V, TJVMK, TJVMV> WithOffsetResetPolicy(Org.Apache.Kafka.Streams.AutoOffsetReset arg0)
        {
            _inner?.WithOffsetResetPolicy(arg0);
            return this;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/Consumed.html#withTimestampExtractor(org.apache.kafka.streams.processor.TimestampExtractor)"/>
        /// </summary>
        /// <param name="arg0"><see cref="TimestampExtractor{K, V, TJVMK, TJVMV}"/></param>
        /// <returns><see cref="Consumed{K, V, TJVMK, TJVMV}"/></returns>
        public Consumed<K, V, TJVMK, TJVMV> WithTimestampExtractor(TimestampExtractor<K, V, TJVMK, TJVMV> arg0)
        {
            if (arg0 is IGenericSerDesFactoryApplier applier) applier.Factory = _factory;
            _timestampExtractor = arg0;
            _inner?.WithTimestampExtractor(arg0);
            return this;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/Consumed.html#withValueSerde(org.apache.kafka.common.serialization.Serde)"/>
        /// </summary>
        /// <param name="arg0"><see cref="ISerDes{V, TJVMV}"/></param>
        /// <returns><see cref="Consumed{K, V, TJVMK, TJVMV}"/></returns>
        public Consumed<K, V, TJVMK, TJVMV> WithValueSerde(ISerDes<V, TJVMV> arg0)
        {
            _inner?.WithValueSerde(arg0.KafkaSerde);
            _valueSerdes = arg0;
            return this;
        }

        #endregion
    }
}
