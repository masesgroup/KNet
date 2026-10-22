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
using MASES.KNet.Streams.State;
using System;
using System.Threading;

namespace MASES.KNet.Streams
{
    /// <summary>
    /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.KeyValue{TJVMK, TJVMV}"/> 
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
    /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
    public sealed class TimestampedWindowedKeyValueWithHeaders<K, V, TJVMK, TJVMV> : IKNetInnerReference<Org.Apache.Kafka.Streams.KeyValue<Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, Org.Apache.Kafka.Streams.State.ValueTimestampHeaders<TJVMV>>>, IGenericSerDesFactoryApplier, IDisposable
    {
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        static TimestampedWindowedKeyValueWithHeaders<K, V, TJVMK, TJVMV> Allocate() => new TimestampedWindowedKeyValueWithHeaders<K, V, TJVMK, TJVMV>();
        static JCOBridgeObjectPool<TimestampedWindowedKeyValueWithHeaders<K, V, TJVMK, TJVMV>> _pool = new JCOBridgeObjectPool<TimestampedWindowedKeyValueWithHeaders<K, V, TJVMK, TJVMV>>(Allocate);

        Org.Apache.Kafka.Streams.KeyValue<Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, Org.Apache.Kafka.Streams.State.ValueTimestampHeaders<TJVMV>> _valueInner;
        Windowed<K, TJVMK> _key = null;
        ValueTimestampHeaders<V, TJVMV> _value = null;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set => _factory = value; }

        internal static TimestampedWindowedKeyValueWithHeaders<K, V, TJVMK, TJVMV> Create(IGenericSerDesFactory factory,
                                                                                          Org.Apache.Kafka.Streams.KeyValue<Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, Org.Apache.Kafka.Streams.State.ValueTimestampHeaders<TJVMV>> value)
        {
            bool fromPool = false;
            _pool.Rent(ref fromPool);
            var instance = _pool.Rent(ref fromPool);
            instance.Setup(factory, value, fromPool);
            return instance;
        }

        void Setup(IGenericSerDesFactory factory,
                   Org.Apache.Kafka.Streams.KeyValue<Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, Org.Apache.Kafka.Streams.State.ValueTimestampHeaders<TJVMV>> value,
                   bool fromPool)
        {
            _factory = factory;
            _valueInner = value;
        }

        /// <inheritdoc/>
        public Org.Apache.Kafka.Streams.KeyValue<Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, Org.Apache.Kafka.Streams.State.ValueTimestampHeaders<TJVMV>> InnerReference => _valueInner;

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
                _valueInner?.Dispose();
                _valueInner = default;
                _key?.Dispose();
                _key = null;
                _value?.Dispose();
                _value = null;
                _pool.Return(this);
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
                _key ??= Windowed<K, TJVMK>.Create(_factory, _valueInner.key);
                return _key;
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
                _value ??= ValueTimestampHeaders<V, TJVMV>.Create(_factory, _valueInner.value);
                return _value;
            }
        }
    }
}
