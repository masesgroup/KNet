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

using MASES.JCOBridge.C2JBridge.JVMInterop;
using MASES.JCOBridge.C2JBridge;
using MASES.KNet.Serialization;
using MASES.KNet.Streams.Kstream;
using System.Collections.Generic;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MASES.KNet.Streams.State
{
    /// <summary>
    /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.State.KeyValueIterator{K, V}"/> where K is <see cref="Org.Apache.Kafka.Streams.Kstream.Windowed{K}"/>
    /// </summary>
    /// <typeparam name="TKey">The key type</typeparam>
    /// <typeparam name="TValue">The value type</typeparam>
    public class KNetWindowedKeyValueIterator<TKey, TValue> : CommonIterator<KNetWindowedKeyValue<TKey, TValue>>
    {
#if NET7_0_OR_GREATER
        class PrefetchableLocalEnumerator(IGenericSerDesFactory factory,
                                          IJavaObject obj,
                                          IKNetSerDes<TValue> valueSerDes,
                                          bool isAsync, CancellationToken token = default)
            : JVMBridgeBasePrefetchableEnumerator<KNetWindowedKeyValue<TKey, TValue>>(obj, new PrefetchableEnumeratorSettings()),
              IGenericSerDesFactoryApplier,
              IAsyncEnumerator<KNetWindowedKeyValue<TKey, TValue>>
        {
            IGenericSerDesFactory _factory = factory;
            IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

            protected override object ConvertObject(object input)
            {
                if (input is IJavaObject obj)
                {
                    return new KNetWindowedKeyValue<TKey, TValue>(_factory,
                                                                  JVMBridgeBase.Wraps<Org.Apache.Kafka.Streams.KeyValue<Org.Apache.Kafka.Streams.Kstream.Windowed<byte[]>, byte[]>>(obj),
                                                                  valueSerDes, true);
                }
                throw new InvalidCastException($"input is not a valid IJavaObject");
            }

            protected override bool DoWorkCycle()
            {
                return isAsync ? !token.IsCancellationRequested : base.DoWorkCycle();
            }

            public KNetWindowedKeyValue<TKey, TValue> Current => (this as IEnumerator<KNetWindowedKeyValue<TKey, TValue>>).Current;

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
        class StandardLocalEnumerator : JVMBridgeBaseEnumerator<KNetWindowedKeyValue<TKey, TValue>>, IGenericSerDesFactoryApplier, IAsyncEnumerator<KNetWindowedKeyValue<TKey, TValue>>
        {
            IKNetSerDes<TValue> _valueSerDes = null;
            IGenericSerDesFactory _factory;
            IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

            public StandardLocalEnumerator(IGenericSerDesFactory factory,
                                           IJavaObject obj,
                                           IKNetSerDes<TValue> valueSerDes)
                : base(obj)
            {
                _factory = factory;
                _valueSerDes = valueSerDes;
            }

            protected override object ConvertObject(object input)
            {
                if (input is IJavaObject obj)
                {
                    return new KNetWindowedKeyValue<TKey, TValue>(_factory,
                                                                  JVMBridgeBase.Wraps<Org.Apache.Kafka.Streams.KeyValue<Org.Apache.Kafka.Streams.Kstream.Windowed<byte[]>, byte[]>>(obj),
                                                                  _valueSerDes, false);
                }
                throw new InvalidCastException($"input is not a valid IJavaObject");
            }

            public KNetWindowedKeyValue<TKey, TValue> Current => (this as IEnumerator<KNetWindowedKeyValue<TKey, TValue>>).Current;

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

        readonly Org.Apache.Kafka.Streams.State.KeyValueIterator<Org.Apache.Kafka.Streams.Kstream.Windowed<byte[]>, byte[]> _iterator;
        IKNetSerDes<TValue> _valueSerDes = null;

        internal KNetWindowedKeyValueIterator(IGenericSerDesFactory factory, Org.Apache.Kafka.Streams.State.KeyValueIterator<Org.Apache.Kafka.Streams.Kstream.Windowed<byte[]>, byte[]> iterator)
            :base(factory)
        {
            _iterator = iterator;
        }

        /// <inheritdoc/>
        protected override object GetEnumerator(bool isAsync, CancellationToken cancellationToken = default)
        {
            _valueSerDes ??= _factory.BuildValueSerDes<TValue>();
#if NET7_0_OR_GREATER
            if (UsePrefetch)
            {
                return new PrefetchableLocalEnumerator(_factory, _iterator.BridgeInstance, _valueSerDes, isAsync, cancellationToken);
            }
#endif
            return new StandardLocalEnumerator(_factory, _iterator.BridgeInstance, _valueSerDes);
        }
        /// <summary>
        /// KNet implementation of <see href="https://docs.oracle.com/en/java/javase/11/docs/api/java.base/java/util/Iterator.html#hasNext()"/> 
        /// </summary>
        public bool HasNext => _iterator.HasNext;
        /// <summary>
        /// KNet implementation of <see href="https://docs.oracle.com/en/java/javase/11/docs/api/java.base/java/util/Iterator.html#next()"/> 
        /// </summary>
        public KNetWindowedKeyValue<TKey, TValue> Next
        {
            get
            {
                _valueSerDes ??= _factory.BuildValueSerDes<TValue>();
                return new KNetWindowedKeyValue<TKey, TValue>(_factory, _iterator.Next, _valueSerDes, false);
            }
        }
        /// <summary>
        /// <see href="https://docs.oracle.com/en/java/javase/11/docs/api/java.base/java/util/Iterator.html#remove()"/>
        /// </summary>
        public void Remove()
        {
            _iterator.Remove();
        }
        /// <summary>
        /// Returns an <see cref="IEnumerator{E}"/> of <see cref="KNetWindowedKeyValue{TKey, TValue}"/>
        /// </summary>
        /// <param name="usePrefetch"><see langword="true"/> to return an <see cref="IEnumerator{T}"/> making preparation of <see cref="KNetWindowedKeyValue{TKey, TValue}"/> in parallel</param>
        /// <returns>An <see cref="IEnumerator{T}"/> of <see cref="KNetWindowedKeyValue{TKey, TValue}"/></returns>
        /// <remarks><paramref name="usePrefetch"/> is not considered with .NET 6 and .NET Framework</remarks>
        public IEnumerator<KNetWindowedKeyValue<TKey, TValue>> ToIEnumerator(bool usePrefetch = true)
        {
            UsePrefetch = usePrefetch;
            return GetEnumerator(false) as IEnumerator<KNetWindowedKeyValue<TKey, TValue>>;
        }
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/KeyValueIterator.html#peekNextKey--"/>
        /// </summary>
        /// <returns><typeparamref name="TKey"/></returns>
        public KNetWindowed<TKey> PeekNextKey
        {
            get
            {
                var kk = _iterator.PeekNextKey();
                return new KNetWindowed<TKey>(_factory, kk);
            }
        }
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/KeyValueIterator.html#close--"/>
        /// </summary>
        public void Close()
        {
            _iterator.Close();
        }
    }
}
