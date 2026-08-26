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
using MASES.JCOBridge.C2JBridge.JVMInterop;
using MASES.KNet.Serialization;
using MASES.KNet.Streams.Kstream;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MASES.KNet.Streams.State
{
    /// <summary>
    /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.State.AggregationWithHeaders{AGG}"/>
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="AGG">The key type</typeparam>
    /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
    /// <typeparam name="TJVMAGG">The JVM type of <typeparamref name="AGG"/></typeparam>
    public sealed class AggregationWithHeadersIterator<K, AGG, TJVMK, TJVMAGG> : CommonIterator<AggregationWithHeaders<AGG, TJVMAGG>>, IKNetInnerReference<Org.Apache.Kafka.Streams.State.KeyValueIterator<Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, Org.Apache.Kafka.Streams.State.AggregationWithHeaders<TJVMAGG>>>
    {
#if NET7_0_OR_GREATER
        sealed class PrefetchableLocalEnumerator(IGenericSerDesFactory factory,
                                                 IJavaObject obj,
                                                 bool isAsync, CancellationToken token = default)
            : JVMBridgeBasePrefetchableEnumerator<AggregationWithHeaders<AGG, TJVMAGG>>(obj, new PrefetchableEnumeratorSettings()),
              IGenericSerDesFactoryApplier,
              IAsyncEnumerator<AggregationWithHeaders<AGG, TJVMAGG>>
        {
            IGenericSerDesFactory _factory = factory;
            IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

            protected override object ConvertObject(object input)
            {
                if (input is IJavaObject obj)
                {
                    return new AggregationWithHeaders<AGG, TJVMAGG>(_factory,
                                                                    JVMBridgeBase.WrapsDirect<Org.Apache.Kafka.Streams.State.AggregationWithHeaders<TJVMAGG>>(obj));
                }
                throw new InvalidCastException($"input is not a valid IJavaObject");
            }
            protected override bool DoWorkCycle()
            {
                return isAsync ? !token.IsCancellationRequested : base.DoWorkCycle();
            }

            public AggregationWithHeaders<AGG, TJVMAGG> Current => (this as IEnumerator<AggregationWithHeaders<AGG, TJVMAGG>>).Current;

            public ValueTask<bool> MoveNextAsync()
            {
                return new ValueTask<bool>(MoveNext());
            }

            public ValueTask DisposeAsync()
            {
                Dispose();
                return new ValueTask();
            }
        }
#endif
        sealed class StandardLocalEnumerator : JVMBridgeBaseEnumerator<AggregationWithHeaders<AGG, TJVMAGG>>, IGenericSerDesFactoryApplier, IAsyncEnumerator<AggregationWithHeaders<AGG, TJVMAGG>>
        {
            IGenericSerDesFactory _factory;
            IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

            public StandardLocalEnumerator(IGenericSerDesFactory factory,
                                           IJavaObject obj)
                : base(obj)
            {
                _factory = factory;
            }

            protected override object ConvertObject(object input)
            {
                if (input is IJavaObject obj)
                {
                    return new AggregationWithHeaders<AGG, TJVMAGG>(_factory,
                                                                    JVMBridgeBase.WrapsDirect<Org.Apache.Kafka.Streams.State.AggregationWithHeaders<TJVMAGG>>(obj));
                }
                throw new InvalidCastException($"input is not a valid IJavaObject");
            }

            public AggregationWithHeaders<AGG, TJVMAGG> Current => (this as IEnumerator<AggregationWithHeaders<AGG, TJVMAGG>>).Current;

            public ValueTask<bool> MoveNextAsync()
            {
                return new ValueTask<bool>(MoveNext());
            }

            public ValueTask DisposeAsync()
            {
                Dispose();
                return new ValueTask();
            }
        }

        Org.Apache.Kafka.Streams.State.KeyValueIterator<Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, Org.Apache.Kafka.Streams.State.AggregationWithHeaders<TJVMAGG>> _iterator = null;
        ISerDes<K, TJVMK> _keySerDes;

        internal AggregationWithHeadersIterator(IGenericSerDesFactory factory, Org.Apache.Kafka.Streams.State.KeyValueIterator<Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, Org.Apache.Kafka.Streams.State.AggregationWithHeaders<TJVMAGG>> iterator)
            : base(factory)
        {
            _iterator = iterator;
        }

        /// <inheritdoc/>
        public Org.Apache.Kafka.Streams.State.KeyValueIterator<Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, Org.Apache.Kafka.Streams.State.AggregationWithHeaders<TJVMAGG>> InnerReference => _iterator;

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            _iterator?.Dispose();
            _iterator = null;
            base.Dispose(disposing);
        }

        /// <inheritdoc/>
        protected sealed override object GetEnumerator(bool isAsync, bool usePrefetch, CancellationToken cancellationToken = default)
        {
            IGenericSerDesFactory _factory = Factory;
#if NET7_0_OR_GREATER
            if (usePrefetch)
            {
                return new PrefetchableLocalEnumerator(_factory, _iterator.BridgeInstance, isAsync, cancellationToken);
            }
#endif
            return new StandardLocalEnumerator(_factory, _iterator.BridgeInstance);
        }
        /// <summary>
        /// KNet implementation of <see href="https://docs.oracle.com/en/java/javase/11/docs/api/java.base/java/util/Iterator.html#hasNext()"/> 
        /// </summary>
        public bool HasNext() => _iterator.HasNext();
        /// <summary>
        /// KNet implementation of <see href="https://docs.oracle.com/en/java/javase/11/docs/api/java.base/java/util/Iterator.html#next()"/> 
        /// </summary>
        public AggregationWithHeaders<AGG, TJVMAGG> Next()
        {
            IGenericSerDesFactory factory = Factory;
            var kv = _iterator.Next();
            if (kv == null) return null;
            return new AggregationWithHeaders<AGG, TJVMAGG>(factory, kv.value);
        }
        /// <summary>
        /// <see href="https://docs.oracle.com/en/java/javase/11/docs/api/java.base/java/util/Iterator.html#remove()"/>
        /// </summary>
        public void Remove()
        {
            _iterator.Remove();
        }
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.3.1/org/apache/kafka/streams/state/KeyValueIterator.html#peekNextKey()"/>
        /// </summary>
        /// <returns><typeparamref name="K"/></returns>
        public Windowed<K, TJVMK> PeekNextKey()
        {
            var kk = _iterator.PeekNextKey();
            using var disposable0 = kk as IDisposable;
            _keySerDes ??= Factory?.BuildKeySerDes<K, TJVMK>();
            return new Windowed<K, TJVMK>(Factory, kk);
        }
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.3.1/org/apache/kafka/streams/state/KeyValueIterator.html#close()"/>
        /// </summary>
        public void Close()
        {
            _iterator.Close();
        }
    }
}
