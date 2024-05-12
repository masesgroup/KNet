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

namespace MASES.KNet.Streams.Processor.Api
{
    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Processor.Api.Record{K, V}"/>
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
    /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
    public class Record<K, V, TJVMK, TJVMV>
    {
        internal Record(IGenericSerDesFactory builder, Org.Apache.Kafka.Streams.Processor.Api.Record<TJVMK, TJVMV> record, Org.Apache.Kafka.Streams.Processor.Api.RecordMetadata metadata)
        {
            _builder = builder;
            _record = record;
            _metadata = metadata;
        }

        readonly IGenericSerDesFactory _builder;
        readonly Org.Apache.Kafka.Streams.Processor.Api.Record<TJVMK, TJVMV> _record;
        readonly Org.Apache.Kafka.Streams.Processor.Api.RecordMetadata _metadata;

        /// <summary>
        /// Converter from <see cref="Record{K, V, TJVMK, TJVMV}"/> to <see cref="Org.Apache.Kafka.Streams.Processor.Api.Record{K, V}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Processor.Api.Record<TJVMK, TJVMV>(Record<K, V, TJVMK, TJVMV> t) => t._record;

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/api/Record.html#withKey-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="NewK"/></param>
        /// <typeparam name="NewK"></typeparam>
        /// <typeparam name="TJVMNewK">The JVM type of <typeparamref name="NewK"/></typeparam>
        /// <returns><see cref="Record{NewK, V, TJVMNewK, TJVMV}"/></returns>
        public Record<NewK, V, TJVMNewK, TJVMV> WithKey<NewK, TJVMNewK>(NewK arg0)
        {
            var serDes = _builder.BuildKeySerDes<NewK, TJVMNewK>();
            var record = _record.WithKey(serDes.SerializeWithHeaders(_metadata?.Topic(), _record.Headers(), arg0));
            return new Record<NewK, V, TJVMNewK, TJVMV>(_builder, record, _metadata);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/api/Record.html#withValue-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="NewV"/></param>
        /// <typeparam name="NewV"></typeparam>
        /// <typeparam name="TJVMNewV">The JVM type of <typeparamref name="NewV"/></typeparam>
        /// <returns><see cref="Record{K, NewV, TJVMK, TJVMNewV}"/></returns>
        public Record<K, NewV, TJVMK, TJVMNewV> WithValue<NewV, TJVMNewV>(NewV arg0)
        {
            var serDes = _builder.BuildValueSerDes<NewV, TJVMNewV>();
            var record = _record.WithValue(serDes.SerializeWithHeaders(_metadata?.Topic(), _record.Headers(), arg0));
            return new Record<K, NewV, TJVMK, TJVMNewV>(_builder, record, _metadata);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/api/Record.html#key--"/>
        /// </summary>
        /// <returns><typeparamref name="K"/></returns>
        public K Key
        {
            get
            {
                var serDes = _builder.BuildKeySerDes<K, TJVMK>();
                return serDes.DeserializeWithHeaders(_metadata?.Topic(), _record.Headers(), _record.Key());
            }
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/api/Record.html#value--"/>
        /// </summary>
        /// <returns><typeparamref name="V"/></returns>
        public V Value
        {
            get
            {
                var serDes = _builder.BuildValueSerDes<V, TJVMV>();
                return serDes.DeserializeWithHeaders(_metadata?.Topic(), _record.Headers(), _record.Value());
            }
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/api/Record.html#timestamp--"/>
        /// </summary>
        public long Timestamp => _record.Timestamp();
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/api/Record.html#timestamp--"/>
        /// </summary>
        public DateTime DateTime => DateTimeOffset.FromUnixTimeMilliseconds(_record.Timestamp()).DateTime;
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/api/Record.html#headers--"/>
        /// </summary>
        /// <returns><see cref="Org.Apache.Kafka.Common.Header.Headers"/></returns>
        public Org.Apache.Kafka.Common.Header.Headers Headers => _record.Headers();
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/api/Record.html#withHeaders-org.apache.kafka.common.header.Headers-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Header.Headers"/></param>
        /// <returns><see cref="Record{K, V, TJVMK, TJVMV}"/></returns>
        public Record<K, V, TJVMK, TJVMV> WithHeaders(Org.Apache.Kafka.Common.Header.Headers arg0)
        {
            var record = _record.WithHeaders(arg0);
            return new Record<K, V, TJVMK, TJVMV>(_builder, record, _metadata);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/api/Record.html#withTimestamp-long-"/>
        /// </summary>
        /// <param name="arg0"><see cref="long"/></param>
        /// <returns><see cref="Record{K, V, TJVMK, TJVMV}"/></returns>
        public Record<K, V, TJVMK, TJVMV> WithTimestamp(long arg0)
        {
            var record = _record.WithTimestamp(arg0);
            return new Record<K, V, TJVMK, TJVMV>(_builder, record, _metadata);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/api/Record.html#withTimestamp-long-"/>
        /// </summary>
        /// <param name="arg0"><see cref="long"/></param>
        /// <returns><see cref="Record{K, V, TJVMK, TJVMV}"/></returns>
        public Record<K, V, TJVMK, TJVMV> WithDateTime(DateTime arg0)
        {
            return WithTimestamp(new DateTimeOffset(arg0).ToUnixTimeMilliseconds());
        }
    }
}
