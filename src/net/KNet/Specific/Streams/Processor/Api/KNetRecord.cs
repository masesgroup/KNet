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
using Org.Apache.Kafka.Streams.Processor.Api;
using System;

namespace MASES.KNet.Streams.Processor.Api
{
    /// <summary>
    /// KNet extension of <see cref="Record{K, V}"/>
    /// </summary>
    /// <typeparam name="TKey">The key type</typeparam>
    /// <typeparam name="TValue">The value type</typeparam>
    public class KNetRecord<TKey, TValue>
    {
        internal KNetRecord(IGenericSerDesFactory builder, Record<byte[], byte[]> record, RecordMetadata metadata)
        {
            _builder = builder;
            _record = record;
            _metadata = metadata;
        }

        readonly IGenericSerDesFactory _builder;
        readonly Record<byte[], byte[]> _record;
        readonly RecordMetadata _metadata;

        /// <summary>
        /// Converter from <see cref="KNetRecord{TKey, TValue}"/> to <see cref="Org.Apache.Kafka.Streams.Processor.Api.Record{K, V}"/>
        /// </summary>
        public static implicit operator Record<byte[], byte[]>(KNetRecord<TKey, TValue> t) => t._record;

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/api/Record.html#withKey-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="NewK"/></param>
        /// <typeparam name="NewK"></typeparam>
        /// <returns><see cref="KNetRecord{NewK, TValue}"/></returns>
        public KNetRecord<NewK, TValue> WithKey<NewK>(NewK arg0)
        {
            var serDes = _builder.BuildKeySerDes<NewK>();
            var record = _record.WithKey(serDes.SerializeWithHeaders(_metadata?.Topic(), _record.Headers(), arg0));
            return new KNetRecord<NewK, TValue>(_builder, record, _metadata);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/api/Record.html#withValue-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="NewV"/></param>
        /// <typeparam name="NewV"></typeparam>
        /// <returns><see cref="KNetRecord{TKey, NewV}"/></returns>
        public KNetRecord<TKey, NewV> WithValue<NewV>(NewV arg0)
        {
            var serDes = _builder.BuildValueSerDes<NewV>();
            var record = _record.WithValue(serDes.SerializeWithHeaders(_metadata?.Topic(), _record.Headers(), arg0));
            return new KNetRecord<TKey, NewV>(_builder, record, _metadata);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/api/Record.html#key--"/>
        /// </summary>
        /// <returns><typeparamref name="TKey"/></returns>
        public TKey Key
        {
            get
            {
                var serDes = _builder.BuildKeySerDes<TKey>();
                return serDes.DeserializeWithHeaders(_metadata?.Topic(), _record.Headers(), _record.Key());
            }
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/api/Record.html#value--"/>
        /// </summary>
        /// <returns><typeparamref name="TValue"/></returns>
        public TValue Value
        {
            get
            {
                var serDes = _builder.BuildValueSerDes<TValue>();
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
        /// <returns><see cref="KNetRecord{TKey, TValue}"/></returns>
        public KNetRecord<TKey, TValue> WithHeaders(Org.Apache.Kafka.Common.Header.Headers arg0)
        {
            var record = _record.WithHeaders(arg0);
            return new KNetRecord<TKey, TValue>(_builder, record, _metadata);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/api/Record.html#withTimestamp-long-"/>
        /// </summary>
        /// <param name="arg0"><see cref="long"/></param>
        /// <returns><see cref="KNetRecord{TKey, TValue}"/></returns>
        public KNetRecord<TKey, TValue> WithTimestamp(long arg0)
        {
            var record = _record.WithTimestamp(arg0);
            return new KNetRecord<TKey, TValue>(_builder, record, _metadata);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/api/Record.html#withTimestamp-long-"/>
        /// </summary>
        /// <param name="arg0"><see cref="long"/></param>
        /// <returns><see cref="KNetRecord{TKey, TValue}"/></returns>
        public KNetRecord<TKey, TValue> WithDateTime(DateTime arg0)
        {
            return WithTimestamp(new DateTimeOffset(arg0).ToUnixTimeMilliseconds());
        }

    }
}
