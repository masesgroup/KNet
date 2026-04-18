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
using MASES.KNet.Streams.Utils;
using System;
using System.Threading;

namespace MASES.KNet.Streams.Kstream
{
    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.Branched{TJVMK, TJVMV}"/>
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
    /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
    public class Branched<K, V, TJVMK, TJVMV> : IGenericSerDesFactoryApplier, IDisposable
    {
        readonly Org.Apache.Kafka.Streams.Kstream.Branched<TJVMK, TJVMV> _inner;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set => _factory = value; }

        Branched(Org.Apache.Kafka.Streams.Kstream.Branched<TJVMK, TJVMV> inner)
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
        /// Converter from <see cref="Branched{K, V, TJVMK, TJVMV}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.Branched{TJVMK, TJVMV}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.Branched<TJVMK, TJVMV>(Branched<K, V, TJVMK, TJVMV> t) => t._inner;

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/kstream/Branched.html#as(java.lang.String)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="Branched{K, V, TJVMK, TJVMV}"/></returns>
        public static Branched<K, V, TJVMK, TJVMV> As(string arg0)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Branched<TJVMK, TJVMV>.As(arg0);
            return new Branched<K, V, TJVMK, TJVMV>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/kstream/Branched.html#withConsumer(java.util.function.Consumer,java.lang.String)"/>
        /// </summary>
        /// <param name="arg0"><see cref="KStreamConsumer{K, V, TJVMK, TJVMV}"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <returns><see cref="Branched{K, V, TJVMK, TJVMV}"/></returns>
        public static Branched<K, V, TJVMK, TJVMV> WithConsumer(KStreamConsumer<K, V, TJVMK, TJVMV> arg0, string arg1)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Branched<TJVMK, TJVMV>.WithConsumer(arg0, arg1);
            return new Branched<K, V, TJVMK, TJVMV>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/kstream/Branched.html#withConsumer(java.util.function.Consumer)"/>
        /// </summary>
        /// <param name="arg0"><see cref="KStreamConsumer{K, V}"/></param>
        /// <returns><see cref="Branched{K, V, TJVMK, TJVMV}"/></returns>
        public static Branched<K, V, TJVMK, TJVMV> WithConsumer(KStreamConsumer<K, V, TJVMK, TJVMV> arg0)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Branched<TJVMK, TJVMV>.WithConsumer(arg0);
            return new Branched<K, V, TJVMK, TJVMV>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/kstream/Branched.html#withFunction(java.util.function.Function,java.lang.String)"/>
        /// </summary>
        /// <param name="arg0"><see cref="KStreamFunction{K, V}"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <returns><see cref="Branched{K, V, TJVMK, TJVMV}"/></returns>
        public static Branched<K, V, TJVMK, TJVMV> WithFunction(KStreamFunction<K, V, TJVMK, TJVMV> arg0, string arg1)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Branched<TJVMK, TJVMV>.WithFunction(arg0, arg1);
            return new Branched<K, V, TJVMK, TJVMV>(cons);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/kstream/Branched.html#withFunction(java.util.function.Function)"/>
        /// </summary>
        /// <param name="arg0"><see cref="KStreamFunction{K, V, TJVMK, TJVMV}"/></param>
        /// <returns><see cref="Branched{K, V, TJVMK, TJVMV}"/></returns>
        public static Branched<K, V, TJVMK, TJVMV> WithFunction(KStreamFunction<K, V, TJVMK, TJVMV> arg0)
        {
            var cons = Org.Apache.Kafka.Streams.Kstream.Branched<TJVMK, TJVMV>.WithFunction(arg0);
            return new Branched<K, V, TJVMK, TJVMV>(cons);
        }

        #endregion
    }
}
