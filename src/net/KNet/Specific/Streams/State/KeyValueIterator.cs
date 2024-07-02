/*
*  Copyright 2024 MASES s.r.l.
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
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MASES.KNet.Streams.State
{
    /// <summary>
    /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.State.KeyValueIterator{TJVMK, TJVMV}"/> 
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
    /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
    public sealed class KeyValueIterator<K, V, TJVMK, TJVMV> : CommonIterator<KeyValue<K, V, TJVMK, TJVMV>>
    {
#if NET7_0_OR_GREATER
        sealed class PrefetchableLocalEnumerator(IGenericSerDesFactory factory,
                                                 IJavaObject obj,
                                                 ISerDes<K, TJVMK> keySerDes,
                                                 ISerDes<V, TJVMV> valueSerDes,
                                                 bool isAsync, CancellationToken token = default)
            : JVMBridgeBasePrefetchableEnumerator<KeyValue<K, V, TJVMK, TJVMV>>(obj, new PrefetchableEnumeratorSettings()),
              IGenericSerDesFactoryApplier,
              IAsyncEnumerator<KeyValue<K, V, TJVMK, TJVMV>>
        {
            IGenericSerDesFactory _factory = factory;
            IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

            protected override object ConvertObject(object input)
            {
                if (input is IJavaObject obj)
                {
                    return new KeyValue<K, V, TJVMK, TJVMV>(factory,
                                                            JVMBridgeBase.WrapsDirect<Org.Apache.Kafka.Streams.KeyValue<TJVMK, TJVMV>>(obj),
                                                            keySerDes, valueSerDes, true);
                }
                throw new InvalidCastException($"input is not a valid IJavaObject");
            }

            protected override bool DoWorkCycle()
            {
                return isAsync ? !token.IsCancellationRequested : base.DoWorkCycle();
            }

            public KeyValue<K, V, TJVMK, TJVMV> Current => (this as IEnumerator<KeyValue<K, V, TJVMK, TJVMV>>).Current;

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
        sealed class StandardLocalEnumerator : JVMBridgeBaseEnumerator<KeyValue<K, V, TJVMK, TJVMV>>, IGenericSerDesFactoryApplier, IAsyncEnumerator<KeyValue<K, V, TJVMK, TJVMV>>
        {
            readonly ISerDes<K, TJVMK> _keySerDes = null;
            readonly ISerDes<V, TJVMV> _valueSerDes = null;
            IGenericSerDesFactory _factory;
            IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

            public StandardLocalEnumerator(IGenericSerDesFactory factory,
                                           IJavaObject obj,
                                           ISerDes<K, TJVMK> keySerDes,
                                           ISerDes<V, TJVMV> valueSerDes)
                : base(obj)
            {
                _factory = factory;
                _keySerDes = keySerDes;
                _valueSerDes = valueSerDes;
            }

            protected override object ConvertObject(object input)
            {
                if (input is IJavaObject obj)
                {
                    return new KeyValue<K, V, TJVMK, TJVMV>(_factory,
                                                            JVMBridgeBase.WrapsDirect<Org.Apache.Kafka.Streams.KeyValue<TJVMK, TJVMV>>(obj),
                                                            _keySerDes,
                                                            _valueSerDes,
                                                            false);
                }
                throw new InvalidCastException($"input is not a valid IJavaObject");
            }

            public KeyValue<K, V, TJVMK, TJVMV> Current => (this as IEnumerator<KeyValue<K, V, TJVMK, TJVMV>>).Current;

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

        readonly Org.Apache.Kafka.Streams.State.KeyValueIterator<TJVMK, TJVMV> _iterator;
        ISerDes<K, TJVMK> _keySerDes = null;
        ISerDes<V, TJVMV> _valueSerDes = null;

        internal KeyValueIterator(IGenericSerDesFactory factory, Org.Apache.Kafka.Streams.State.KeyValueIterator<TJVMK, TJVMV> iterator)
            : base(factory)
        {
            _iterator = iterator;
        }

        /// <inheritdoc/>
        protected sealed override object GetEnumerator(bool isAsync, CancellationToken cancellationToken = default)
        {
            IGenericSerDesFactory factory = Factory;
            _keySerDes ??= factory?.BuildKeySerDes<K, TJVMK>();
            _valueSerDes ??= factory?.BuildValueSerDes<V, TJVMV>();
#if NET7_0_OR_GREATER
            if (UsePrefetch)
            {
                return new PrefetchableLocalEnumerator(factory, _iterator.BridgeInstance, _keySerDes, _valueSerDes, isAsync, cancellationToken);
            }
#endif
            return new StandardLocalEnumerator(factory, _iterator.BridgeInstance, _keySerDes, _valueSerDes);
        }

        /// <summary>
        /// KNet implementation of <see href="https://docs.oracle.com/en/java/javase/11/docs/api/java.base/java/util/Iterator.html#hasNext()"/> 
        /// </summary>
        public bool HasNext() => _iterator.HasNext();
        /// <summary>
        /// KNet implementation of <see href="https://docs.oracle.com/en/java/javase/11/docs/api/java.base/java/util/Iterator.html#next()"/> 
        /// </summary>
        public KeyValue<K, V, TJVMK, TJVMV> Next()
        {
            IGenericSerDesFactory factory = Factory;
            _keySerDes ??= factory?.BuildKeySerDes<K, TJVMK>();
            _valueSerDes ??= factory?.BuildValueSerDes<V, TJVMV>();
            return new KeyValue<K, V, TJVMK, TJVMV>(factory, _iterator.Next(), _keySerDes, _valueSerDes, false);
        }
        /// <summary>
        /// <see href="https://docs.oracle.com/en/java/javase/11/docs/api/java.base/java/util/Iterator.html#remove()"/>
        /// </summary>
        public void Remove()
        {
            _iterator.Remove();
        }
        /// <summary>
        /// Returns an <see cref="IEnumerator{E}"/> of <see cref="KeyValue{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        /// <param name="usePrefetch"><see langword="true"/> to return an <see cref="IEnumerator{T}"/> making preparation of <see cref="KeyValue{K, V, TJVMK, TJVMV}"/> in parallel</param>
        /// <returns>An <see cref="IEnumerator{T}"/> of <see cref="KeyValue{K, V, TJVMK, TJVMV}"/></returns>
        /// <remarks><paramref name="usePrefetch"/> is not considered with .NET 6 and .NET Framework</remarks>
        public IEnumerator<KeyValue<K, V, TJVMK, TJVMV>> ToIEnumerator(bool usePrefetch = true)
        {
            UsePrefetch = usePrefetch;
            return GetEnumerator(false) as IEnumerator<KeyValue<K, V, TJVMK, TJVMV>>;
        }
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.7.0/org/apache/kafka/streams/state/KeyValueIterator.html#peekNextKey--"/>
        /// </summary>
        /// <returns><typeparamref name="K"/></returns>
        public K PeekNextKey()
        {
            _keySerDes ??= Factory?.BuildKeySerDes<K, TJVMK>();
            var kk = _iterator.PeekNextKey();
            return _keySerDes.Deserialize(null, kk);
        }
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.7.0/org/apache/kafka/streams/state/KeyValueIterator.html#close--"/>
        /// </summary>
        public void Close()
        {
            _iterator.Close();
        }
    }
}
