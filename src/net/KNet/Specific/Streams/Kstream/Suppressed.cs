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

namespace MASES.KNet.Streams.Kstream
{
    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.Suppressed{TJVMK}"/>
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
    public class Suppressed<K, TJVMK> : IGenericSerDesFactoryApplier, IDisposable
    {
        readonly Org.Apache.Kafka.Streams.Kstream.Suppressed<TJVMK> _inner;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set => _factory = value; }

        internal Suppressed(Org.Apache.Kafka.Streams.Kstream.Suppressed<TJVMK> inner)
        {
            _inner = inner;
        }

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
                _inner?.Dispose();
            }
        }

        #endregion

        /// <summary>
        /// Converter from <see cref="Suppressed{K, TJVMK}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.Suppressed{TJVMK}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.Suppressed<TJVMK>(Suppressed<K, TJVMK> t) => t._inner;

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/kstream/Suppressed.html#untilTimeLimit(java.time.Duration,org.apache.kafka.streams.kstream.Suppressed.BufferConfig)"/>
        /// </summary>
        /// <param name="arg0"><see cref="TimeSpan"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Suppressed.BufferConfig"/></param>
        /// <returns><see cref="Suppressed{K, TJVMK}"/></returns>
        public static Suppressed<K, TJVMK> UntilTimeLimit(TimeSpan arg0, Org.Apache.Kafka.Streams.Kstream.Suppressed.BufferConfig arg1)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Suppressed<TJVMK>.UntilTimeLimit(arg0, arg1);
            return new Suppressed<K, TJVMK>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/kstream/Suppressed.html#untilWindowCloses(org.apache.kafka.streams.kstream.Suppressed.StrictBufferConfig)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Suppressed.StrictBufferConfig"/></param>
        /// <returns><see cref="Suppressed{K, TJVMK}"/> with <see cref="Org.Apache.Kafka.Streams.Kstream.Windowed"/></returns>
        public static Suppressed<Org.Apache.Kafka.Streams.Kstream.Windowed<object>, Org.Apache.Kafka.Streams.Kstream.Windowed<object>> UntilWindowCloses(Org.Apache.Kafka.Streams.Kstream.Suppressed.StrictBufferConfig arg0)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Suppressed<Org.Apache.Kafka.Streams.Kstream.Windowed>.UntilWindowCloses(arg0);
            return new Suppressed<Org.Apache.Kafka.Streams.Kstream.Windowed<object>, Org.Apache.Kafka.Streams.Kstream.Windowed<object>>(cons);
        }

        #endregion
    }

    /// <summary>
    /// KNet extension of <see cref="Suppressed{K, TJVMK}"/>
    /// </summary>
    /// <typeparam name="K"></typeparam>
    public class Suppressed<K> : Suppressed<K, byte[]>
    {
        Suppressed(Org.Apache.Kafka.Streams.Kstream.Suppressed<byte[]> inner) : base(inner)
        {

        }
    }
}
