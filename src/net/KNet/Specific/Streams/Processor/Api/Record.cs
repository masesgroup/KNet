/*
*  Copyright (c) 2021-2026 MASES s.r.l.
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

using Java.Util;
using MASES.KNet.Serialization;
using System;
using System.Threading;

namespace MASES.KNet.Streams.Processor.Api
{
    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Processor.Api.Record{K, V}"/>
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
    /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
    public class Record<K, V, TJVMK, TJVMV> : IDisposable
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

        #region IDisposable

        volatile int _disposed; // 0 = live, 1 = disposed
        /// <summary>
        /// Test if this instance was disposed
        /// </summary>
        /// <exception cref="ObjectDisposedException">When this instance was disposed</exception>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        protected void CheckDisposed() { if (_disposed != 0) throw new ObjectDisposedException(GetType().Name); }
        /// <inheritdoc cref="IDisposable.Dispose"/>
        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Implements the pattern described in https://learn.microsoft.com/en-en/dotnet/standard/garbage-collection/implementing-dispose
        /// </summary>
        /// <param name="disposing">The disposing parameter is a <see langword="bool"/> that indicates whether the method call comes from a <see cref="IDisposable.Dispose"/> method (its value is <see langword="true"/>) or from a finalizer (its value is <see langword="false"/>)</param>
        protected virtual void Dispose(bool disposing)
        {
            if (Interlocked.Exchange(ref _disposed, 1) != 0)
                return;

            if (disposing)
            {
                _record?.Dispose();
                _metadata?.Dispose();
            }
        }

        #endregion

        /// <summary>
        /// Converter from <see cref="Record{K, V, TJVMK, TJVMV}"/> to <see cref="Org.Apache.Kafka.Streams.Processor.Api.Record{K, V}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Processor.Api.Record<TJVMK, TJVMV>(Record<K, V, TJVMK, TJVMV> t) => t._record;

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/processor/api/Record.html#withKey(java.lang.Object)"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="NewK"/></param>
        /// <typeparam name="NewK"></typeparam>
        /// <typeparam name="TJVMNewK">The JVM type of <typeparamref name="NewK"/></typeparam>
        /// <returns><see cref="Record{NewK, V, TJVMNewK, TJVMV}"/></returns>
        public Record<NewK, V, TJVMNewK, TJVMV> WithKey<NewK, TJVMNewK>(NewK arg0)
        {
            CheckDisposed();
            var serDes = _builder.BuildKeySerDes<NewK, TJVMNewK>();
            using var topic = _metadata?.Topic();
            using var headers = _record.Headers();
            var key = serDes.SerializeWithHeaders(topic, headers, arg0);
            try
            {
                var record = _record.WithKey(key);
                return new Record<NewK, V, TJVMNewK, TJVMV>(_builder, record, _metadata);
            }
            finally { (key as IDisposable)?.Dispose(); }
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/processor/api/Record.html#withValue(java.lang.Object)"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="NewV"/></param>
        /// <typeparam name="NewV"></typeparam>
        /// <typeparam name="TJVMNewV">The JVM type of <typeparamref name="NewV"/></typeparam>
        /// <returns><see cref="Record{K, NewV, TJVMK, TJVMNewV}"/></returns>
        public Record<K, NewV, TJVMK, TJVMNewV> WithValue<NewV, TJVMNewV>(NewV arg0)
        {
            CheckDisposed();
            var serDes = _builder.BuildValueSerDes<NewV, TJVMNewV>();
            using var topic = _metadata?.Topic();
            using var headers = _record.Headers();
            var value = serDes.SerializeWithHeaders(topic, headers, arg0);
            try
            {
                var record = _record.WithValue(value);
                return new Record<K, NewV, TJVMK, TJVMNewV>(_builder, record, _metadata);
            }
            finally { (value as IDisposable)?.Dispose(); }
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/processor/api/Record.html#key()"/>
        /// </summary>
        /// <returns><typeparamref name="K"/></returns>
        public K Key
        {
            get
            {
                CheckDisposed();
                var serDes = _builder.BuildKeySerDes<K, TJVMK>();
                using var topic = _metadata?.Topic();
                using var headers = _record.Headers();
                var key = _record.Key();
                try
                {
                    return serDes.DeserializeWithHeaders(topic, headers, key);
                }
                finally
                {
                    (key as IDisposable)?.Dispose();
                }
            }
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/processor/api/Record.html#value()"/>
        /// </summary>
        /// <returns><typeparamref name="V"/></returns>
        public V Value
        {
            get
            {
                CheckDisposed();
                var serDes = _builder.BuildValueSerDes<V, TJVMV>();
                using var topic = _metadata?.Topic();
                using var headers = _record.Headers();
                var value = _record.Value();
                try
                {
                    return serDes.DeserializeWithHeaders(topic, headers, value);
                }
                finally
                {
                    (value as IDisposable)?.Dispose();
                }
            }
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/processor/api/Record.html#timestamp()"/>
        /// </summary>
        public long Timestamp { get { CheckDisposed(); return _record.Timestamp(); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/processor/api/Record.html#timestamp()"/>
        /// </summary>
        public DateTime DateTime { get { CheckDisposed(); return DateTimeOffset.FromUnixTimeMilliseconds(_record.Timestamp()).DateTime; } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/processor/api/Record.html#headers()"/>
        /// </summary>
        /// <returns><see cref="Org.Apache.Kafka.Common.Header.Headers"/></returns>
        public Org.Apache.Kafka.Common.Header.Headers Headers { get { CheckDisposed(); return _record.Headers(); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/processor/api/Record.html#withHeaders(org.apache.kafka.common.header.Headers)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Header.Headers"/></param>
        /// <returns><see cref="Record{K, V, TJVMK, TJVMV}"/></returns>
        public Record<K, V, TJVMK, TJVMV> WithHeaders(Org.Apache.Kafka.Common.Header.Headers arg0)
        {
            CheckDisposed();
            var record = _record.WithHeaders(arg0);
            return new Record<K, V, TJVMK, TJVMV>(_builder, record, _metadata);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/processor/api/Record.html#withTimestamp(long)"/>
        /// </summary>
        /// <param name="arg0"><see cref="long"/></param>
        /// <returns><see cref="Record{K, V, TJVMK, TJVMV}"/></returns>
        public Record<K, V, TJVMK, TJVMV> WithTimestamp(long arg0)
        {
            CheckDisposed();
            var record = _record.WithTimestamp(arg0);
            return new Record<K, V, TJVMK, TJVMV>(_builder, record, _metadata);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/processor/api/Record.html#withTimestamp(long)"/>
        /// </summary>
        /// <param name="arg0"><see cref="long"/></param>
        /// <returns><see cref="Record{K, V, TJVMK, TJVMV}"/></returns>
        public Record<K, V, TJVMK, TJVMV> WithDateTime(DateTime arg0)
        {
            CheckDisposed();
            return WithTimestamp(new DateTimeOffset(arg0).ToUnixTimeMilliseconds());
        }
    }
}
