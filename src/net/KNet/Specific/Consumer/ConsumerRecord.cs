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

using MASES.JCOBridge.C2JBridge;
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
    public sealed class ConsumerRecord<K, V, TJVMK, TJVMV> : IKNetInnerReference<Org.Apache.Kafka.Clients.Consumer.ConsumerRecord<TJVMK, TJVMV>>, IGenericSerDesFactoryApplier, IDisposable
    {
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        static ConsumerRecord<K, V, TJVMK, TJVMV> Allocate() => new ConsumerRecord<K, V, TJVMK, TJVMV>();
        static JCOBridgeObjectPool<ConsumerRecord<K, V, TJVMK, TJVMV>> _pool = new JCOBridgeObjectPool<ConsumerRecord<K, V, TJVMK, TJVMV>>(Allocate);

        struct ConsumerRecordState
        {
            public ConsumerRecordState(Org.Apache.Kafka.Clients.Consumer.ConsumerRecord<TJVMK, TJVMV> record, IDeserializer<K, TJVMK> keyDeserializer, IDeserializer<V, TJVMV> valueDeserializer)
            {
                Record = record;
                KeyDeserializer = keyDeserializer;
                ValueDeserializer = valueDeserializer;
            }

            public ConsumerRecordState(Org.Apache.Kafka.Clients.Consumer.ConsumerRecord<TJVMK, TJVMV> record, IGenericSerDesFactory factory)
            {
                Record = record;
                Factory = factory;
            }

            public Org.Apache.Kafka.Clients.Consumer.ConsumerRecord<TJVMK, TJVMV> Record;
            public IDeserializer<K, TJVMK> KeyDeserializer;
            public IDeserializer<V, TJVMV> ValueDeserializer;

            public string Topic;
            public int? Partition;
            public Org.Apache.Kafka.Common.Header.Headers Headers;
            public long? Offset;
            public long? Timestamp;
            public Org.Apache.Kafka.Common.Record.TimestampType TimestampType;
            public int? SerializedKeySize;
            public int? SerializedValueSize;
            public bool LocalKeyDes;
            public K LocalKey;
            public bool LocalValueDes;
            public V LocalValue;

            public IGenericSerDesFactory Factory;

            public void Dispose()
            {
                Record?.Dispose();
            }
        }

        ConsumerRecordState _state;

        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _state.Factory; set => _state.Factory = value; }

        internal static ConsumerRecord<K, V, TJVMK, TJVMV> Create(Org.Apache.Kafka.Clients.Consumer.ConsumerRecord<TJVMK, TJVMV> record, IDeserializer<K, TJVMK> keyDeserializer, IDeserializer<V, TJVMV> valueDeserializer, bool fromPrefetched)
        {
            bool fromPool = false;
            var instance = _pool.Rent(ref fromPool);
            instance.Setup(record, keyDeserializer, valueDeserializer, fromPrefetched, fromPool);
            return instance;
        }

        /// <summary>
        /// Initialize a new <see cref="ConsumerRecord{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        /// <param name="record">The <see cref="Org.Apache.Kafka.Clients.Consumer.ConsumerRecord{TJVMK, TJVMV}"/> to use for initialization</param>
        /// <param name="keyDeserializer">Key serializer base on <see cref="SerDes{K, TJVMK}"/></param>
        /// <param name="valueDeserializer">Value serializer base on <see cref="SerDes{V, TJVMV}"/></param>
        /// <param name="fromPrefetched"><see langword="true"/> if the initialization comes from the prefetch iterator</param>
        /// <param name="fromPool"><see langword="true"/> if the instance comes from the object pool</param>
        void Setup(Org.Apache.Kafka.Clients.Consumer.ConsumerRecord<TJVMK, TJVMV> record, 
                   IDeserializer<K, TJVMK> keyDeserializer, IDeserializer<V, TJVMV> valueDeserializer, 
                   bool fromPrefetched, bool fromPool)
        {
            if (fromPool)
            {
                _disposed = 0;
                GC.ReRegisterForFinalize(this);
            }

            _state = new ConsumerRecordState(record, keyDeserializer, valueDeserializer);

            if (fromPrefetched)
            {
                // the following lines will read and prepares Key, Value, Topic, Headers
                _ = Key;
                _ = Value;
            }
        }

        internal static ConsumerRecord<K, V, TJVMK, TJVMV> Create(Org.Apache.Kafka.Clients.Consumer.ConsumerRecord<TJVMK, TJVMV> record, IGenericSerDesFactory factory)
        {
            bool fromPool = false;
            var instance = _pool.Rent(ref fromPool);
            instance.Setup(record, factory, fromPool);
            return instance;
        }

        /// <summary>
        /// Initialize a new <see cref="ConsumerRecord{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        /// <param name="record">The <see cref="Org.Apache.Kafka.Clients.Consumer.ConsumerRecord{TJVMK, TJVMV}"/> to use for initialization</param>
        /// <param name="factory"><see cref="IGenericSerDesFactory"/></param>
        /// <param name="fromPool"><see langword="true"/> if the instance comes from the object pool</param>
        void Setup(Org.Apache.Kafka.Clients.Consumer.ConsumerRecord<TJVMK, TJVMV> record, IGenericSerDesFactory factory, bool fromPool)
        {
            if (fromPool)
            {
                _disposed = 0;
                GC.ReRegisterForFinalize(this);
            }
            _state = new ConsumerRecordState(record, factory);
        }
        /// <inheritdoc/>
        public Org.Apache.Kafka.Clients.Consumer.ConsumerRecord<TJVMK, TJVMV> InnerReference => _state.Record;

        volatile int _disposed; // 0 = live, 1 = disposed
        /// <summary>
        /// Test if this instance was disposed
        /// </summary>
        /// <exception cref="ObjectDisposedException">When this instance was disposed</exception>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        void CheckDisposed() { if (_disposed != 0) throw new ObjectDisposedException(GetType().Name); }
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
        void Dispose(bool disposing)
        {
            if (Interlocked.Exchange(ref _disposed, 1) != 0)
                return;

            if (disposing)
            {
                _state.Dispose();
                _state = default;
                _pool.Return(this);
            }
        }

        /// <inheritdoc cref="Org.Apache.Kafka.Clients.Consumer.ConsumerRecord{K, V}.Topic"/>
        public string Topic
        {
            get
            {
                CheckDisposed(); 
                if (_state.Topic == null)
                {
                    using var topic = _state.Record.Topic();
                    _state.Topic = topic;
                }
                return _state.Topic;
            }
        }
        /// <inheritdoc cref="Org.Apache.Kafka.Clients.Consumer.ConsumerRecord{K, V}.LeaderEpoch"/>
        public int? LeaderEpoch
        {
            get
            {
                CheckDisposed();
                using var epoch = _state.Record.LeaderEpoch();
                if (epoch.IsPresent())
                {
                    using var integer = epoch.Get();
                    return integer.IntValue();
                }
                return null;
            }
        }
        /// <inheritdoc cref="Org.Apache.Kafka.Clients.Consumer.ConsumerRecord{K, V}.Partition"/>
        public int Partition
        {
            get
            {
                CheckDisposed(); return _state.Partition ??= _state.Record.Partition();
            }
        }
        /// <inheritdoc cref="Org.Apache.Kafka.Clients.Consumer.ConsumerRecord{K, V}.Headers"/>
        public Org.Apache.Kafka.Common.Header.Headers Headers
        {
            get
            {
                CheckDisposed(); return _state.Headers ??= _state.Record.Headers();
            }
        }
        /// <inheritdoc cref="Org.Apache.Kafka.Clients.Consumer.ConsumerRecord{K, V}.Offset"/>
        public long Offset
        {
            get
            {
                CheckDisposed(); return _state.Offset ??= _state.Record.Offset();
            }
        }
        /// <inheritdoc cref="Org.Apache.Kafka.Clients.Consumer.ConsumerRecord{K, V}.DateTime"/>
        public System.DateTime DateTime
        {
            get
            {
                CheckDisposed(); return _state.Record.DateTime;
            }
        }
        /// <inheritdoc cref="Org.Apache.Kafka.Clients.Consumer.ConsumerRecord{K, V}.Timestamp"/>
        public long Timestamp
        {
            get
            {
                CheckDisposed(); return _state.Timestamp ??= _state.Record.Timestamp();
            }
        }
        /// <inheritdoc cref="Org.Apache.Kafka.Clients.Consumer.ConsumerRecord{K, V}.TimestampType"/>
        public Org.Apache.Kafka.Common.Record.TimestampType TimestampType
        {
            get
            {
                CheckDisposed(); return _state.TimestampType ??= _state.Record.TimestampType();
            }
        }
        /// <inheritdoc cref="Org.Apache.Kafka.Clients.Consumer.ConsumerRecord{K, V}.SerializedKeySize"/>
        public int SerializedKeySize
        {
            get
            {
                CheckDisposed(); return _state.SerializedKeySize ??= _state.Record.SerializedKeySize();
            }
        }
        /// <inheritdoc cref="Org.Apache.Kafka.Clients.Consumer.ConsumerRecord{K, V}.SerializedValueSize"/>
        public int SerializedValueSize
        {
            get
            {
                CheckDisposed(); return _state.SerializedValueSize ??= _state.Record.SerializedValueSize();
            }
        }

        /// <inheritdoc cref="Org.Apache.Kafka.Clients.Consumer.ConsumerRecord{K, V}.Key"/>
        public K Key
        {
            get
            {
                CheckDisposed();
                if (!_state.LocalKeyDes)
                {
                    _state.KeyDeserializer ??= _state.Factory?.BuildKeySerDes<K, TJVMK>();
                    using var topic = _state.Record.Topic();
                    using var headers = _state.Record.Headers();
                    var key = _state.Record.Key();
                    using var disposable = key as IDisposable;
                    _state.LocalKey = _state.KeyDeserializer.UseHeaders ? _state.KeyDeserializer.DeserializeWithHeaders(topic, headers, key)
                                                                        : _state.KeyDeserializer.Deserialize(topic, key);
                    _state.LocalKeyDes = true;
                }
                return _state.LocalKey;
            }
        }

        /// <inheritdoc cref="Org.Apache.Kafka.Clients.Consumer.ConsumerRecord{K, V}.Value"/>
        public V Value
        {
            get
            {
                CheckDisposed();
                if (!_state.LocalValueDes)
                {
                    _state.ValueDeserializer ??= _state.Factory?.BuildValueSerDes<V, TJVMV>();
                    using var topic = _state.Record.Topic();
                    using var headers = _state.Record.Headers();
                    var value = _state.Record.Value();
                    using var disposable = value as IDisposable;
                    _state.LocalValue = _state.ValueDeserializer.UseHeaders ? _state.ValueDeserializer.DeserializeWithHeaders(topic, headers, value)
                                                                            : _state.ValueDeserializer.Deserialize(topic, value);
                    _state.LocalValueDes = true;
                }
                return _state.LocalValue;
            }
        }
        /// <inheritdoc cref="object.ToString"/>
        public override string ToString()
        {
            return $"Topic: {Topic} - Partition {Partition} - Offset {Offset} - Key {Key} - Value {Value}";
        }
    }
}
