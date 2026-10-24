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
using MASES.JNet.Specific.Extensions;
using MASES.KNet.Serialization;
using MASES.KNet.Streams.Processor.Api;
using MASES.KNet.Streams.State;
using Org.Apache.Kafka.Streams.State;
using System;
using System.Threading;

namespace MASES.KNet.Streams
{
    /// <summary>
    /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.State.ValueTimestampHeaders{V}"/> 
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
    /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
    public sealed class TimestampedKeyValueHeaders<K, V, TJVMK, TJVMV> : IKNetInnerReference<Org.Apache.Kafka.Streams.KeyValue<TJVMK, Org.Apache.Kafka.Streams.State.ValueTimestampHeaders<TJVMV>>>, IGenericSerDesFactoryApplier, IDisposable
    {
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        static TimestampedKeyValueHeaders<K, V, TJVMK, TJVMV> Allocate() => new TimestampedKeyValueHeaders<K, V, TJVMK, TJVMV>();
        static JCOBridgeObjectPool<TimestampedKeyValueHeaders<K, V, TJVMK, TJVMV>> _pool = new JCOBridgeObjectPool<TimestampedKeyValueHeaders<K, V, TJVMK, TJVMV>>(Allocate);

        struct TimestampedKeyValueHeadersState
        {
            public TimestampedKeyValueHeadersState(IGenericSerDesFactory factory, Org.Apache.Kafka.Streams.KeyValue<TJVMK, Org.Apache.Kafka.Streams.State.ValueTimestampHeaders<TJVMV>> inner, ISerDes<K, TJVMK> keySerDes, bool fromPrefetch, bool fromPool)
            {
                Factory = factory;
                Inner = inner;
                KeySerDes = keySerDes;
                FromPrefetch = fromPrefetch;
                FromPool = fromPool;
            }

            public bool FromPrefetch;
            public bool FromPool;

            public Org.Apache.Kafka.Streams.KeyValue<TJVMK, Org.Apache.Kafka.Streams.State.ValueTimestampHeaders<TJVMV>> Inner = null;

            public K Key;
            public bool KeyStored = false;
            public ValueTimestampHeaders<V, TJVMV> Value = null;
            public ISerDes<K, TJVMK> KeySerDes = null;
            public IGenericSerDesFactory Factory;

            public void Dispose()
            {
                Inner?.Dispose();
            }
        }

        TimestampedKeyValueHeadersState _state;

        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _state.Factory; set => _state.Factory = value; }

        internal static TimestampedKeyValueHeaders<K, V, TJVMK, TJVMV> Create(IGenericSerDesFactory factory,
                                                                              Org.Apache.Kafka.Streams.KeyValue<TJVMK, Org.Apache.Kafka.Streams.State.ValueTimestampHeaders<TJVMV>> value,
                                                                              ISerDes<K, TJVMK> keySerDes,
                                                                              bool fromPrefetch)
        {
            bool fromPool = false;
            var instance = fromPrefetch ? Allocate() : _pool.Rent(ref fromPool);
            instance.Setup(factory, value, keySerDes, fromPrefetch, fromPool);
            return instance;
        }

        void Setup(IGenericSerDesFactory factory,
                   Org.Apache.Kafka.Streams.KeyValue<TJVMK, Org.Apache.Kafka.Streams.State.ValueTimestampHeaders<TJVMV>> inner,
                   ISerDes<K, TJVMK> keySerDes,
                   bool fromPrefetch,
                   bool fromPool)
        {
            if (fromPool)
            {
                Interlocked.Exchange(ref _disposed, 0);
                GC.ReRegisterForFinalize(this);
            }
            _state = new TimestampedKeyValueHeadersState(factory, inner, keySerDes, fromPrefetch, fromPool);
            if (fromPrefetch)
            {
                _state.KeySerDes ??= _state.Factory?.BuildKeySerDes<K, TJVMK>();
                var key = _state.Inner.key;
                using var disposable = key as IDisposable;
                _state.Key = _state.KeySerDes.Deserialize((Java.Lang.String)null, key);
                _state.KeyStored = true;
            }
        }

        /// <inheritdoc/>
        public Org.Apache.Kafka.Streams.KeyValue<TJVMK, Org.Apache.Kafka.Streams.State.ValueTimestampHeaders<TJVMV>> InnerReference => _state.Inner;

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
                bool fromPrefetch = _state.FromPrefetch;
                _state.Dispose();
                _state = default;
                if (!fromPrefetch) _pool.Return(this);
            }
        }

        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.3.1/org/apache/kafka/streams/KeyValue.html#key"/>
        /// </summary>
        public K Key
        {
            get
            {
                CheckDisposed();
                if (!_state.KeyStored)
                {
                    _state.KeySerDes ??= _state.Factory?.BuildKeySerDes<K, TJVMK>();
                    var key = _state.Inner.key;
                    using var disposable = key as IDisposable;
                    _state.Key = _state.KeySerDes.Deserialize((Java.Lang.String)null, key);
                    _state.KeyStored = true;
                }
                return _state.Key;
            }
        }
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.3.1/org/apache/kafka/streams/KeyValue.html#value"/>
        /// </summary>
        public ValueTimestampHeaders<V, TJVMV> Value
        {
            get
            {
                CheckDisposed();
                _state.Value ??= ValueTimestampHeaders<V, TJVMV>.Create(_state.Factory, _state.Inner.value);
                return _state.Value;
            }
        }
    }
}
