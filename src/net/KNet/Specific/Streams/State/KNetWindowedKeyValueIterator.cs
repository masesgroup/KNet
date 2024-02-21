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
    public sealed class WindowedKeyValueIterator<TKey, TValue> : CommonIterator<WindowedKeyValue<TKey, TValue>>
    {
#if NET7_0_OR_GREATER
        sealed class PrefetchableLocalEnumerator(IGenericSerDesFactory factory,
                                                 IJavaObject obj,
                                                 ISerDes<TValue> valueSerDes,
                                                 bool isAsync, CancellationToken token = default)
            : JVMBridgeBasePrefetchableEnumerator<WindowedKeyValue<TKey, TValue>>(obj, new PrefetchableEnumeratorSettings()),
              IGenericSerDesFactoryApplier,
              IAsyncEnumerator<WindowedKeyValue<TKey, TValue>>
        {
            IGenericSerDesFactory _factory = factory;
            IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

            protected override object ConvertObject(object input)
            {
                if (input is IJavaObject obj)
                {
                    return new WindowedKeyValue<TKey, TValue>(_factory,
                                                                  JVMBridgeBase.Wraps<Org.Apache.Kafka.Streams.KeyValue<Org.Apache.Kafka.Streams.Kstream.Windowed<byte[]>, byte[]>>(obj),
                                                                  valueSerDes, true);
                }
                throw new InvalidCastException($"input is not a valid IJavaObject");
            }

            protected override bool DoWorkCycle()
            {
                return isAsync ? !token.IsCancellationRequested : base.DoWorkCycle();
            }

            public WindowedKeyValue<TKey, TValue> Current => (this as IEnumerator<WindowedKeyValue<TKey, TValue>>).Current;

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
        sealed class StandardLocalEnumerator : JVMBridgeBaseEnumerator<WindowedKeyValue<TKey, TValue>>, IGenericSerDesFactoryApplier, IAsyncEnumerator<WindowedKeyValue<TKey, TValue>>
        {
            ISerDes<TValue> _valueSerDes = null;
            IGenericSerDesFactory _factory;
            IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

            public StandardLocalEnumerator(IGenericSerDesFactory factory,
                                           IJavaObject obj,
                                           ISerDes<TValue> valueSerDes)
                : base(obj)
            {
                _factory = factory;
                _valueSerDes = valueSerDes;
            }

            protected override object ConvertObject(object input)
            {
                if (input is IJavaObject obj)
                {
                    return new WindowedKeyValue<TKey, TValue>(_factory,
                                                                  JVMBridgeBase.Wraps<Org.Apache.Kafka.Streams.KeyValue<Org.Apache.Kafka.Streams.Kstream.Windowed<byte[]>, byte[]>>(obj),
                                                                  _valueSerDes, false);
                }
                throw new InvalidCastException($"input is not a valid IJavaObject");
            }

            public WindowedKeyValue<TKey, TValue> Current => (this as IEnumerator<WindowedKeyValue<TKey, TValue>>).Current;

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
        ISerDes<TValue> _valueSerDes = null;

        internal WindowedKeyValueIterator(IGenericSerDesFactory factory, Org.Apache.Kafka.Streams.State.KeyValueIterator<Org.Apache.Kafka.Streams.Kstream.Windowed<byte[]>, byte[]> iterator)
            :base(factory)
        {
            _iterator = iterator;
        }

        /// <inheritdoc/>
        protected sealed override object GetEnumerator(bool isAsync, CancellationToken cancellationToken = default)
        {
            IGenericSerDesFactory factory = Factory;
            _valueSerDes ??= factory?.BuildValueSerDes<TValue>();
#if NET7_0_OR_GREATER
            if (UsePrefetch)
            {
                return new PrefetchableLocalEnumerator(factory, _iterator.BridgeInstance, _valueSerDes, isAsync, cancellationToken);
            }
#endif
            return new StandardLocalEnumerator(factory, _iterator.BridgeInstance, _valueSerDes);
        }
        /// <summary>
        /// KNet implementation of <see href="https://docs.oracle.com/en/java/javase/11/docs/api/java.base/java/util/Iterator.html#hasNext()"/> 
        /// </summary>
        public bool HasNext => _iterator.HasNext;
        /// <summary>
        /// KNet implementation of <see href="https://docs.oracle.com/en/java/javase/11/docs/api/java.base/java/util/Iterator.html#next()"/> 
        /// </summary>
        public WindowedKeyValue<TKey, TValue> Next
        {
            get
            {
                IGenericSerDesFactory factory = Factory;
                _valueSerDes ??= factory?.BuildValueSerDes<TValue>();
                return new WindowedKeyValue<TKey, TValue>(factory, _iterator.Next, _valueSerDes, false);
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
        /// Returns an <see cref="IEnumerator{E}"/> of <see cref="WindowedKeyValue{TKey, TValue}"/>
        /// </summary>
        /// <param name="usePrefetch"><see langword="true"/> to return an <see cref="IEnumerator{T}"/> making preparation of <see cref="WindowedKeyValue{TKey, TValue}"/> in parallel</param>
        /// <returns>An <see cref="IEnumerator{T}"/> of <see cref="WindowedKeyValue{TKey, TValue}"/></returns>
        /// <remarks><paramref name="usePrefetch"/> is not considered with .NET 6 and .NET Framework</remarks>
        public IEnumerator<WindowedKeyValue<TKey, TValue>> ToIEnumerator(bool usePrefetch = true)
        {
            UsePrefetch = usePrefetch;
            return GetEnumerator(false) as IEnumerator<WindowedKeyValue<TKey, TValue>>;
        }
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/KeyValueIterator.html#peekNextKey--"/>
        /// </summary>
        /// <returns><typeparamref name="TKey"/></returns>
        public Windowed<TKey> PeekNextKey
        {
            get
            {
                var kk = _iterator.PeekNextKey();
                return new Windowed<TKey>(Factory, kk);
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
