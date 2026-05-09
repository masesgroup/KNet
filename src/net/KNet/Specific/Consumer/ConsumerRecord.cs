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

using MASES.KNet.Serialization;
using System;
using System.Threading;

namespace MASES.KNet.Consumer
{
    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Clients.Consumer.ConsumerRecord{TJVMK, TJVMV}"/>
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
    /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
    public class ConsumerRecord<K, V, TJVMK, TJVMV> : IGenericSerDesFactoryApplier, IDisposable
    {
        IDeserializer<K, TJVMK> _keyDeserializer;
        IDeserializer<V, TJVMV> _valueDeserializer;
        readonly Org.Apache.Kafka.Clients.Consumer.ConsumerRecord<TJVMK, TJVMV> _record;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set => _factory = value; }
        /// <summary>
        /// Initialize a new <see cref="ConsumerRecord{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        /// <param name="record">The <see cref="Org.Apache.Kafka.Clients.Consumer.ConsumerRecord{TJVMK, TJVMV}"/> to use for initialization</param>
        /// <param name="keyDeserializer">Key serializer base on <see cref="SerDes{K, TJVMK}"/></param>
        /// <param name="valueDeserializer">Value serializer base on <see cref="SerDes{V, TJVMV}"/></param>
        /// <param name="fromPrefetched">True if the initialization comes from the prefetch iterator</param>
        internal ConsumerRecord(Org.Apache.Kafka.Clients.Consumer.ConsumerRecord<TJVMK, TJVMV> record, IDeserializer<K, TJVMK> keyDeserializer, IDeserializer<V, TJVMV> valueDeserializer, bool fromPrefetched)
        {
            _record = record;
            _keyDeserializer = keyDeserializer;
            _valueDeserializer = valueDeserializer;
            if (fromPrefetched)
            {
                // the following lines will read and prepares Key, Value, Topic, Headers
                _ = Key;
                _ = Value;
            }
        }
        /// <summary>
        /// Initialize a new <see cref="ConsumerRecord{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        /// <param name="record">The <see cref="Org.Apache.Kafka.Clients.Consumer.ConsumerRecord{TJVMK, TJVMV}"/> to use for initialization</param>
        /// <param name="factory"><see cref="IGenericSerDesFactory"/></param>
        internal ConsumerRecord(Org.Apache.Kafka.Clients.Consumer.ConsumerRecord<TJVMK, TJVMV> record, IGenericSerDesFactory factory)
        {
            _record = record;
            _factory = factory;
        }

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
            }
        }

        string _topic = null;
        /// <inheritdoc cref="Org.Apache.Kafka.Clients.Consumer.ConsumerRecord{K, V}.Topic"/>
        public string Topic
        {
            get
            {
                CheckDisposed(); 
                if (_topic == null)
                {
                    using var topic = _record.Topic();
                    _topic = topic;
                }
                return _topic;
            }
        }
        /// <inheritdoc cref="Org.Apache.Kafka.Clients.Consumer.ConsumerRecord{K, V}.LeaderEpoch"/>
        public int? LeaderEpoch
        {
            get
            {
                CheckDisposed();
                using var epoch = _record.LeaderEpoch();
                if (epoch.IsPresent())
                {
                    using var integer = epoch.Get();
                    return integer.IntValue();
                }
                return null;
            }
        }
        int? _partition = null;
        /// <inheritdoc cref="Org.Apache.Kafka.Clients.Consumer.ConsumerRecord{K, V}.Partition"/>
        public int Partition
        {
            get
            {
                CheckDisposed(); return _partition ??= _record.Partition();
            }
        }
        Org.Apache.Kafka.Common.Header.Headers _headers = null;
        /// <inheritdoc cref="Org.Apache.Kafka.Clients.Consumer.ConsumerRecord{K, V}.Headers"/>
        public Org.Apache.Kafka.Common.Header.Headers Headers
        {
            get
            {
                CheckDisposed(); return _headers ??= _record.Headers();
            }
        }
        long? _offset = null;
        /// <inheritdoc cref="Org.Apache.Kafka.Clients.Consumer.ConsumerRecord{K, V}.Offset"/>
        public long Offset
        {
            get
            {
                CheckDisposed(); return _offset ??= _record.Offset();
            }
        }
        /// <inheritdoc cref="Org.Apache.Kafka.Clients.Consumer.ConsumerRecord{K, V}.DateTime"/>
        public System.DateTime DateTime
        {
            get
            {
                CheckDisposed(); return _record.DateTime;
            }
        }
        long? _timestamp = null;
        /// <inheritdoc cref="Org.Apache.Kafka.Clients.Consumer.ConsumerRecord{K, V}.Timestamp"/>
        public long Timestamp
        {
            get
            {
                CheckDisposed(); return _timestamp ??= _record.Timestamp();
            }
        }
        Org.Apache.Kafka.Common.Record.TimestampType _timestampType = null;
        /// <inheritdoc cref="Org.Apache.Kafka.Clients.Consumer.ConsumerRecord{K, V}.TimestampType"/>
        public Org.Apache.Kafka.Common.Record.TimestampType TimestampType
        {
            get
            {
                CheckDisposed(); return _timestampType ??= _record.TimestampType();
            }
        }
        int? _serializedKeySize = null;
        /// <inheritdoc cref="Org.Apache.Kafka.Clients.Consumer.ConsumerRecord{K, V}.SerializedKeySize"/>
        public int SerializedKeySize
        {
            get
            {
                CheckDisposed(); return _serializedKeySize ??= _record.SerializedKeySize();
            }
        }
        int? _serializedValueSize = null;
        /// <inheritdoc cref="Org.Apache.Kafka.Clients.Consumer.ConsumerRecord{K, V}.SerializedValueSize"/>
        public int SerializedValueSize
        {
            get
            {
                CheckDisposed(); return _serializedValueSize ??= _record.SerializedValueSize();
            }
        }

        bool _localKeyDes = false;
        K _localKey = default;
        /// <inheritdoc cref="Org.Apache.Kafka.Clients.Consumer.ConsumerRecord{K, V}.Key"/>
        public K Key
        {
            get
            {
                CheckDisposed();
                if (!_localKeyDes)
                {
                    _keyDeserializer ??= _factory?.BuildKeySerDes<K, TJVMK>();
                    var key = _record.Key();
                    using var disposable = key as IDisposable;
                    _localKey = _keyDeserializer.UseHeaders ? _keyDeserializer.DeserializeWithHeaders(Topic, Headers, key)
                                                            : _keyDeserializer.Deserialize(Topic, key);
                    _localKeyDes = true;
                }
                return _localKey;
            }
        }

        bool _localValueDes = false;
        V _localValue = default;
        /// <inheritdoc cref="Org.Apache.Kafka.Clients.Consumer.ConsumerRecord{K, V}.Value"/>
        public V Value
        {
            get
            {
                CheckDisposed();
                if (!_localValueDes)
                {
                    _valueDeserializer ??= _factory?.BuildValueSerDes<V, TJVMV>();
                    var value = _record.Value();
                    using var disposable = value as IDisposable;
                    _localValue = _valueDeserializer.UseHeaders ? _valueDeserializer.DeserializeWithHeaders(Topic, Headers, value)
                                                                : _valueDeserializer.Deserialize(Topic, value);
                    _localValueDes = true;
                }
                return _localValue;
            }
        }
        /// <inheritdoc cref="object.ToString"/>
        public override string ToString()
        {
            return $"Topic: {Topic} - Partition {Partition} - Offset {Offset} - Key {Key} - Value {Value}";
        }
    }
}
