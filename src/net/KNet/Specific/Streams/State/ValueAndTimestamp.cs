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
using MASES.KNet.Streams.Processor.Api;
using System;
using System.Threading;

namespace MASES.KNet.Streams.State
{
    /// <summary>
    /// KNet Implementation of <see cref="Org.Apache.Kafka.Streams.State.ValueAndTimestamp{V}"/>
    /// </summary>
    /// <typeparam name="V">The value type</typeparam>
    /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
    public class ValueAndTimestamp<V, TJVMV> : IKNetInnerReference<Org.Apache.Kafka.Streams.State.ValueAndTimestamp<TJVMV>>, IGenericSerDesFactoryApplier, IDisposable
    {
        Org.Apache.Kafka.Streams.State.ValueAndTimestamp<TJVMV> _inner;
        ISerDes<V, TJVMV> _valueSerDes;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set => _factory = value; }

        internal ValueAndTimestamp(IGenericSerDesFactory factory, Org.Apache.Kafka.Streams.State.ValueAndTimestamp<TJVMV> valueAndTimestamp)
        {
            _factory = factory;
            _inner = valueAndTimestamp;
        }

        /// <inheritdoc/>
        public Org.Apache.Kafka.Streams.State.ValueAndTimestamp<TJVMV> InnerReference => _inner;

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
                _inner = null;
            }
        }

        #endregion

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/state/ValueAndTimestamp.html#timestamp()"/>
        /// </summary>
        /// <returns><see cref="long"/></returns>
        public long Timestamp { get { CheckDisposed(); return _inner.Timestamp(); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/state/ValueAndTimestamp.html#timestamp()"/>
        /// </summary>
        /// <returns><see cref="DateTime"/></returns>
        public DateTime DateTime => DateTimeOffset.FromUnixTimeMilliseconds(Timestamp).DateTime;
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.2/org/apache/kafka/streams/state/ValueAndTimestamp.html#value()"/>
        /// </summary>
        /// <returns><typeparamref name="V"/></returns>
        public V Value
        {
            get
            {
                CheckDisposed();
                _valueSerDes ??= _factory?.BuildKeySerDes<V, TJVMV>();
                var vv = _inner.Value();
                using var disposable0 = vv as IDisposable;

                return _valueSerDes.Deserialize((Java.Lang.String)null, vv);
            }
        }
    }
}
