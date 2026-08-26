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
    /// <typeparam name="AGG">The value type</typeparam>
    /// <typeparam name="TJVMAGG">The JVM type of <typeparamref name="AGG"/></typeparam>
    public class AggregationWithHeaders<AGG, TJVMAGG> : IKNetInnerReference<Org.Apache.Kafka.Streams.State.AggregationWithHeaders<TJVMAGG>>, IGenericSerDesFactoryApplier, IDisposable
    {
        Org.Apache.Kafka.Streams.State.AggregationWithHeaders<TJVMAGG> _inner;
        ISerDes<AGG, TJVMAGG> _aggreationSerDes;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set => _factory = value; }

        internal AggregationWithHeaders(IGenericSerDesFactory factory, Org.Apache.Kafka.Streams.State.AggregationWithHeaders<TJVMAGG> aggregatationHeaders)
        {
            _factory = factory;
            _inner = aggregatationHeaders;
        }

        /// <inheritdoc/>
        public Org.Apache.Kafka.Streams.State.AggregationWithHeaders<TJVMAGG> InnerReference => _inner;

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
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.3.1/org/apache/kafka/streams/state/AggregationWithHeaders.html#aggregation()"/>
        /// </summary>
        /// <returns><typeparamref name="AGG"/></returns>
        public AGG Aggregation
        {
            get
            {
                CheckDisposed();
                _aggreationSerDes ??= _factory?.BuildKeySerDes<AGG, TJVMAGG>();
                var vv = _inner.Aggregation();
                using var disposable0 = vv as IDisposable;

                return _aggreationSerDes.Deserialize((Java.Lang.String)null, vv);
            }
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.3.1/org/apache/kafka/streams/state/ValueTimestampHeaders.html#headers()"/>
        /// </summary>
        /// <returns><see cref="Org.Apache.Kafka.Common.Header.Headers"/></returns>
        public Org.Apache.Kafka.Common.Header.Headers Headers
        {
            get
            {
                CheckDisposed();
                return _inner.Headers();
            }
        }
    }
}
