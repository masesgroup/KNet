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
using MASES.KNet.Streams.Processor.Api;
using MASES.KNet.Streams.State;
using Org.Apache.Kafka.Streams.State;
using System;
using System.Threading;

namespace MASES.KNet.Streams
{
    /// <summary>
    /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.State.ValueAndTimestamp{V}"/> 
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
    /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
    public sealed class TimestampedKeyValue<K, V, TJVMK, TJVMV> : IKNetInnerReference<KeyValueSupport<TJVMK, Org.Apache.Kafka.Streams.State.ValueAndTimestamp<TJVMV>>>, IGenericSerDesFactoryApplier, IDisposable
    {
        KeyValueSupport<TJVMK, Org.Apache.Kafka.Streams.State.ValueAndTimestamp<TJVMV>> _inner = null;

        K _key;
        bool _keyStored = false;
        ValueAndTimestamp<V, TJVMV> _value = null;
        ISerDes<K, TJVMK> _keySerDes = null;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set => _factory = value; }

        internal TimestampedKeyValue(IGenericSerDesFactory factory,
                                     KeyValueSupport<TJVMK, Org.Apache.Kafka.Streams.State.ValueAndTimestamp<TJVMV>> value,
                                     ISerDes<K, TJVMK> keySerDes,
                                     bool fromPrefetched)
        {
            _factory = factory;
            _inner = value;
            _keySerDes = keySerDes;
            if (fromPrefetched)
            {
                _keySerDes ??= _factory?.BuildKeySerDes<K, TJVMK>();
                var key = _inner.Key;
                using var disposable = key as IDisposable;
                _key = _keySerDes.Deserialize((Java.Lang.String)null, key);
                _keyStored = true;
            }
        }

        /// <inheritdoc/>
        public KeyValueSupport<TJVMK, Org.Apache.Kafka.Streams.State.ValueAndTimestamp<TJVMV>> InnerReference => _inner;

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
                _inner = null;
                _key = default;
                _keyStored = false;
                _value = null;
                _keySerDes = null;
            }
        }

        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.2.0/org/apache/kafka/streams/KeyValue.html#key"/>
        /// </summary>
        public K Key
        {
            get
            {
                CheckDisposed();
                if (!_keyStored)
                {
                    _keySerDes ??= _factory?.BuildKeySerDes<K, TJVMK>();
                    var key = _inner.Key;
                    using var disposable = key as IDisposable;
                    _key = _keySerDes.Deserialize((Java.Lang.String)null, key);
                    _keyStored = true;
                }
                return _key;
            }
        }
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.2.0/org/apache/kafka/streams/KeyValue.html#value"/>
        /// </summary>
        public ValueAndTimestamp<V, TJVMV> Value
        {
            get
            {
                CheckDisposed();
                _value ??= new ValueAndTimestamp<V, TJVMV>(_factory, _inner.Value);
                return _value;
            }
        }
    }
}
