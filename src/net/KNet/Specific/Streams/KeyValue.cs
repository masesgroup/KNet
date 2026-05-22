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

namespace MASES.KNet.Streams
{
    /// <summary>
    /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.KeyValue{K, V}"/> 
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
    /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
    public sealed class KeyValue<K, V, TJVMK, TJVMV> : IKNetInnerReference<KeyValueSupport<TJVMK, TJVMV>>, IGenericSerDesFactoryApplier, IDisposable
    {
        readonly KeyValueSupport<TJVMK, TJVMV> _inner = null;
        K _key;
        bool _keyStored;
        V _value;
        bool _valueStored;
        ISerDes<K, TJVMK> _keySerDes = null;
        ISerDes<V, TJVMV> _valueSerDes = null;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set => _factory = value; }

        internal KeyValue(IGenericSerDesFactory factory,
                          KeyValueSupport<TJVMK, TJVMV> value,
                          ISerDes<K, TJVMK> keySerDes,
                          ISerDes<V, TJVMV> valueSerDes,
                          bool fromPrefetched)
        {
            _factory = factory;
            _inner = value;
            _keySerDes = keySerDes;
            _valueSerDes = valueSerDes;
            if (fromPrefetched)
            {
                _keySerDes ??= _factory?.BuildKeySerDes<K, TJVMK>();
                if (_keySerDes == null) throw new InvalidOperationException("Unable to resolve key serializer/deserializer for prefetched KeyValue.");
                var jKey = _inner.Key;
                using var disposable = jKey as IDisposable;
                _key = _keySerDes.Deserialize(null, jKey);
                _keyStored = true;
                _valueSerDes ??= _factory?.BuildValueSerDes<V, TJVMV>();
                if (_valueSerDes == null) throw new InvalidOperationException("Unable to resolve value serializer/deserializer for prefetched KeyValue.");
                var jValue = _inner.Value;
                using var disposable2 = jValue as IDisposable;
                _value = _valueSerDes.Deserialize(null, jValue);
                _valueStored = true;
            }
        }

        /// <inheritdoc/>
        public KeyValueSupport<TJVMK, TJVMV> InnerReference => _inner;

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
                _inner?.Dispose();
            }
        }

        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/KeyValue.html#key"/>
        /// </summary>
        public K Key
        {
            get
            {
                CheckDisposed();
                if (!_keyStored)
                {
                    _keySerDes ??= _factory?.BuildKeySerDes<K, TJVMK>() ?? throw new InvalidOperationException("Key serializer/deserializer is not available.");
                    var key = _inner.Key;
                    using var disposable = key as IDisposable;
                    _key = _keySerDes.Deserialize(null, key);
                    _keyStored = true;
                }
                return _key;
            }
        }
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/KeyValue.html#value"/>
        /// </summary>
        public V Value
        {
            get
            {
                CheckDisposed();
                if (!_valueStored)
                {
                    _valueSerDes ??= _factory?.BuildValueSerDes<V, TJVMV>() ?? throw new InvalidOperationException("Value serializer/deserializer is not available.");
                    var value = _inner.Value;
                    using var disposable = value as IDisposable;
                    _value = _valueSerDes.Deserialize(null, value);
                    _valueStored = true;
                }
                return _value;
            }
        }
    }
}
