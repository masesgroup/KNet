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
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.TableJoined{TJVMK, TJVMKO}"/>
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="KO"></typeparam>
    /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
    /// <typeparam name="TJVMKO">The JVM type of <typeparamref name="KO"/></typeparam>
    public class TableJoined<K, KO, TJVMK, TJVMKO> : IGenericSerDesFactoryApplier
    {
        readonly Org.Apache.Kafka.Streams.Kstream.TableJoined<TJVMK, TJVMKO> _inner;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        internal TableJoined(Org.Apache.Kafka.Streams.Kstream.TableJoined<TJVMK, TJVMKO> inner)
        {
            _inner = inner;
        }

        /// <summary>
        /// Converter from <see cref="TableJoined{K, KO, TJVMK, TJVMKO}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.TableJoined{TJVMK, TJVMKO}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.TableJoined<TJVMK, TJVMKO>(TableJoined<K, KO, TJVMK, TJVMKO> t) => t._inner;

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.7.0/org/apache/kafka/streams/kstream/TableJoined.html#as-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="TableJoined{K, KO, TJVMK, TJVMKO}"/></returns>
        public static TableJoined<K, KO, TJVMK, TJVMKO> As(string arg0)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.TableJoined<TJVMK, TJVMKO>.As(arg0);
            return new TableJoined<K, KO, TJVMK, TJVMKO>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.7.0/org/apache/kafka/streams/kstream/TableJoined.html#with-org.apache.kafka.streams.processor.StreamPartitioner-org.apache.kafka.streams.processor.StreamPartitioner-"/>
        /// </summary>
        /// <param name="arg0"><see cref="StreamPartitionerNoValue{K}"/></param>
        /// <param name="arg1"><see cref="StreamPartitionerNoValue{KO}"/></param>
        /// <returns><see cref="TableJoined{K, KO}"/></returns>
        public static TableJoined<K, KO, TJVMK, TJVMKO> With(StreamPartitionerNoValue<K, TJVMK> arg0, StreamPartitionerNoValue<KO, TJVMKO> arg1)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.TableJoined<TJVMK, TJVMKO>.With(arg0, arg1);
            return new TableJoined<K, KO, TJVMK, TJVMKO>(cons);
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.7.0/org/apache/kafka/streams/kstream/TableJoined.html#withOtherPartitioner-org.apache.kafka.streams.processor.StreamPartitioner-"/>
        /// </summary>
        /// <param name="arg0"><see cref="StreamPartitionerNoValue{KO, TJVMKO}"/></param>
        /// <returns><see cref="TableJoined{K, KO, TJVMK, TJVMKO}"/></returns>
        public TableJoined<K, KO, TJVMK, TJVMKO> WithOtherPartitioner(StreamPartitionerNoValue<KO, TJVMKO> arg0)
        {
            _inner?.WithOtherPartitioner(arg0);
            return this;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.7.0/org/apache/kafka/streams/kstream/TableJoined.html#withPartitioner-org.apache.kafka.streams.processor.StreamPartitioner-"/>
        /// </summary>
        /// <param name="arg0"><see cref="StreamPartitionerNoValue{K, TJVMK}"/></param>
        /// <returns><see cref="TableJoined{K, KO, TJVMK, TJVMKO}"/></returns>
        public TableJoined<K, KO, TJVMK, TJVMKO> WithPartitioner(StreamPartitionerNoValue<K, TJVMK> arg0)
        {
            _inner?.WithPartitioner(arg0);
            return this;
        }

        #endregion
    }

    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.TableJoined{K, KO}"/>
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="KO"></typeparam>
    public class TableJoined<K, KO> : TableJoined<K, KO, byte[], byte[]>
    {
        TableJoined(Org.Apache.Kafka.Streams.Kstream.TableJoined<byte[], byte[]> inner) : base(inner) { }
    }
}
