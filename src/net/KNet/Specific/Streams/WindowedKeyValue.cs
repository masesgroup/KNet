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
using MASES.KNet.Streams.Kstream;
using MASES.KNet.Streams.Processor.Api;
using System;
using System.Threading;

namespace MASES.KNet.Streams
{
    /// <summary>
    /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.KeyValue{K, V}"/> where the key is <see cref="Org.Apache.Kafka.Streams.Kstream.Windowed{K}"/>
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
    /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
    public sealed class WindowedKeyValue<K, V, TJVMK, TJVMV> : IKNetInnerReference<Org.Apache.Kafka.Streams.KeyValue<Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, TJVMV>>, IGenericSerDesFactoryApplier, IDisposable
    {
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        static WindowedKeyValue<K, V, TJVMK, TJVMV> Allocate() => new WindowedKeyValue<K, V, TJVMK, TJVMV>();
        static JCOBridgeObjectPool<WindowedKeyValue<K, V, TJVMK, TJVMV>> _pool = new JCOBridgeObjectPool<WindowedKeyValue<K, V, TJVMK, TJVMV>>(Allocate);

        struct WindowedKeyValueState
        {
            public WindowedKeyValueState(IGenericSerDesFactory factory, Org.Apache.Kafka.Streams.KeyValue<Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, TJVMV> inner, ISerDes<V, TJVMV> valueSerDes, bool fromPrefetch, bool fromPool)
            {
                Factory = factory;
                Inner = inner;
                ValueSerDes = valueSerDes;
                FromPrefetch = fromPrefetch;
                FromPool = fromPool;
            }

            public bool FromPrefetch;
            public bool FromPool;
            public Org.Apache.Kafka.Streams.KeyValue<Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, TJVMV> Inner;
            public Windowed<K, TJVMK> Key = null;
            public V Value;
            public bool ValueStored;
            public ISerDes<V, TJVMV> ValueSerDes = null;
            public IGenericSerDesFactory Factory;

            public void Dispose()
            {
                Inner?.Dispose();
            }
        }

        WindowedKeyValueState _state;

        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _state.Factory; set => _state.Factory = value; }

        internal static WindowedKeyValue<K, V, TJVMK, TJVMV> Create(IGenericSerDesFactory factory,
                                                                    Org.Apache.Kafka.Streams.KeyValue<Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, TJVMV> value,
                                                                    ISerDes<V, TJVMV> valueSerDes,
                                                                    bool fromPrefetch)
        {
            bool fromPool = false;
            var instance = fromPrefetch ? Allocate() : _pool.Rent(ref fromPool);
            instance.Setup(factory, value, valueSerDes, fromPrefetch, fromPool);
            return instance;
        }

        void Setup(IGenericSerDesFactory factory,
                   Org.Apache.Kafka.Streams.KeyValue<Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, TJVMV> value,
                   ISerDes<V, TJVMV> valueSerDes,
                   bool fromPrefetch,
                   bool fromPool)
        {
            if (fromPool)
            {
                Interlocked.Exchange(ref _disposed, 0);
                GC.ReRegisterForFinalize(this);
            }
            _state = new WindowedKeyValueState(factory, value, valueSerDes, fromPrefetch, fromPool);
            if (fromPrefetch)
            {
                _state.ValueSerDes ??= _state.Factory?.BuildValueSerDes<V, TJVMV>();
                _state.Value = _state.ValueSerDes.Deserialize((Java.Lang.String)null, _state.Inner.value);
                _state.ValueStored = true;
            }
        }

        /// <inheritdoc/>
        public Org.Apache.Kafka.Streams.KeyValue<Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, TJVMV> InnerReference => _state.Inner;

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
        public Windowed<K, TJVMK> Key
        {
            get
            {
                CheckDisposed();
                _state.Key ??= Windowed<K, TJVMK>.Create(_state.Factory, _state.Inner.key);
                return _state.Key;
            }
        }
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.3.1/org/apache/kafka/streams/KeyValue.html#value"/>
        /// </summary>
        public V Value
        {
            get
            {
                CheckDisposed();
                if (!_state.ValueStored)
                {
                    _state.ValueSerDes ??= _state.Factory?.BuildValueSerDes<V, TJVMV>();
                    var kk = _state.Inner.value;
                    using var disposable = kk as IDisposable;
                    _state.Value = _state.ValueSerDes.Deserialize((Java.Lang.String)null, kk);
                    _state.ValueStored = true;
                }
                return _state.Value;
            }
        }
    }
}
