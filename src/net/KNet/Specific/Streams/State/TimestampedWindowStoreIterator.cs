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

namespace MASES.KNet.Streams.State
{
    /// <summary>
    /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.State.WindowStoreIterator"/> 
    /// </summary>
    /// <typeparam name="V">The value type</typeparam>
    /// <typeparam name="TJVMV">The JVM value type</typeparam>
    public sealed class TimestampedWindowStoreIterator<V, TJVMV> : IGenericSerDesFactoryApplier, IDisposable
    {
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        static TimestampedWindowStoreIterator<V, TJVMV> Allocate() => new TimestampedWindowStoreIterator<V, TJVMV>();
        static JCOBridgeObjectPool<TimestampedWindowStoreIterator<V, TJVMV>> _pool = new JCOBridgeObjectPool<TimestampedWindowStoreIterator<V, TJVMV>>(Allocate);

        Org.Apache.Kafka.Streams.State.WindowStoreIterator<Org.Apache.Kafka.Streams.State.ValueAndTimestamp<TJVMV>> _iterator;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set => _factory = value; }

        internal static TimestampedWindowStoreIterator<V, TJVMV> Create(IGenericSerDesFactory factory, Org.Apache.Kafka.Streams.State.WindowStoreIterator<Org.Apache.Kafka.Streams.State.ValueAndTimestamp<TJVMV>> iterator)
        {
            bool fromPool = false;
            var instance = _pool.Rent(ref fromPool);
            instance.Setup(factory, iterator, fromPool);
            return instance;
        }

        void Setup(IGenericSerDesFactory factory, Org.Apache.Kafka.Streams.State.WindowStoreIterator<Org.Apache.Kafka.Streams.State.ValueAndTimestamp<TJVMV>> iterator, bool fromPool)
        {
            if (fromPool)
            {
                Interlocked.Exchange(ref _disposed, 0);
                GC.ReRegisterForFinalize(this);
            }
            _factory = factory;
            _iterator = iterator;
        }

        /// <summary>
        /// Converter from <see cref="TimestampedWindowStoreIterator{V, TJVMV}"/> to <see cref="KeyValueIterator{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        public static implicit operator TimestampedKeyValueIterator<long, V, Java.Lang.Long, TJVMV>(TimestampedWindowStoreIterator<V, TJVMV> t) => TimestampedKeyValueIterator<long, V, Java.Lang.Long, TJVMV>.Create(t._factory, t._iterator.Cast<Org.Apache.Kafka.Streams.State.KeyValueIterator<Java.Lang.Long, Org.Apache.Kafka.Streams.State.ValueAndTimestamp<TJVMV>>>());

        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.3.1/org/apache/kafka/streams/state/KeyValueIterator.html#close()"/>
        /// </summary>
        public void Close()
        {
            _iterator.Close();
        }

        volatile int _disposed; // 0 = live, 1 = disposed
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
                _factory = null;
                _iterator?.Dispose();
                _iterator = null;
                _pool.Return(this);
            }
        }
    }
}
