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

namespace MASES.KNet.Streams.State
{
    /// <summary>
    /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.State.KeyValueIterator{K, V}"/> 
    /// </summary>
    /// <typeparam name="TKey">The key type</typeparam>
    /// <typeparam name="TValue">The value type</typeparam>
    public class KNetKeyValueIterator<TKey, TValue> : IGenericSerDesFactoryApplier
    {
#if NET7_0_OR_GREATER
        class PrefetchableLocalEnumerator(bool isVersion2,
                                          IGenericSerDesFactory factory,
                                          IJavaObject obj,
                                          IKNetSerDes<TKey> keySerDes,
                                          IKNetSerDes<TValue> valueSerDes)
            : JVMBridgeBasePrefetchableEnumerator<KNetKeyValue<TKey, TValue>>(obj, new PrefetchableEnumeratorSettings()), IGenericSerDesFactoryApplier
        {
            class PrefetchableEnumeratorSettings : IEnumerableExtension
            {
                public PrefetchableEnumeratorSettings()
                {
                    UsePrefetch = true;
                    UseThread = true;
                }
                public bool UsePrefetch { get; set; }
                public bool UseThread { get; set; }
                public IConverterBridge ConverterBridge { get; set; }
            }

            readonly bool _isVersion2 = isVersion2;
            IGenericSerDesFactory _factory = factory;
            IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

            protected override object ConvertObject(object input)
            {
                if (input is IJavaObject obj)
                {
                    return _isVersion2 ? new KNetKeyValue<TKey, TValue>(factory,
                                                                        JVMBridgeBase.Wraps<Org.Apache.Kafka.Streams.KeyValue<Java.Lang.Long, byte[]>>(obj),
                                                                        keySerDes, valueSerDes, true)
                                       : new KNetKeyValue<TKey, TValue>(factory,
                                                                        JVMBridgeBase.Wraps<Org.Apache.Kafka.Streams.KeyValue<byte[], byte[]>>(obj),
                                                                        keySerDes, valueSerDes, true);
                }
                throw new InvalidCastException($"input is not a valid IJavaObject");
            }
        }
#endif
        class StandardLocalEnumerator : JVMBridgeBaseEnumerator<KNetKeyValue<TKey, TValue>>, IGenericSerDesFactoryApplier
        {
            IKNetSerDes<TKey> _keySerDes = null;
            IKNetSerDes<TValue> _valueSerDes = null;
            readonly bool _isVersion2;
            IGenericSerDesFactory _factory;
            IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

            public StandardLocalEnumerator(bool isVersion2,
                                           IGenericSerDesFactory factory,
                                           IJavaObject obj,
                                           IKNetSerDes<TKey> keySerDes,
                                           IKNetSerDes<TValue> valueSerDes)
                : base(obj)
            {
                _isVersion2 = isVersion2;
                _factory = factory;
                _keySerDes = keySerDes;
                _valueSerDes = valueSerDes;
            }

            protected override object ConvertObject(object input)
            {
                if (input is IJavaObject obj)
                {
                    return _isVersion2 ? new KNetKeyValue<TKey, TValue>(_factory,
                                                                        JVMBridgeBase.Wraps<Org.Apache.Kafka.Streams.KeyValue<Java.Lang.Long, byte[]>>(obj),
                                                                        _keySerDes,
                                                                        _valueSerDes,
                                                                        false)
                                       : new KNetKeyValue<TKey, TValue>(_factory,
                                                                        JVMBridgeBase.Wraps<Org.Apache.Kafka.Streams.KeyValue<byte[], byte[]>>(obj),
                                                                        _keySerDes,
                                                                        _valueSerDes,
                                                                        false);
                }
                throw new InvalidCastException($"input is not a valid IJavaObject");
            }
        }

        readonly Org.Apache.Kafka.Streams.State.KeyValueIterator<byte[], byte[]> _iterator;
        readonly Org.Apache.Kafka.Streams.State.KeyValueIterator<Java.Lang.Long, byte[]> _iterator2;
        IKNetSerDes<TKey> _keySerDes = null;
        IKNetSerDes<TValue> _valueSerDes = null;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        internal KNetKeyValueIterator(IGenericSerDesFactory factory, Org.Apache.Kafka.Streams.State.KeyValueIterator<byte[], byte[]> iterator)
        {
            _factory = factory;
            _iterator = iterator;
        }

        internal KNetKeyValueIterator(IGenericSerDesFactory factory, Org.Apache.Kafka.Streams.State.KeyValueIterator<Java.Lang.Long, byte[]> iterator)
        {
            _factory = factory;
            _iterator2 = iterator;
        }
        /// <summary>
        /// KNet implementation of <see href="https://docs.oracle.com/en/java/javase/11/docs/api/java.base/java/util/Iterator.html#hasNext()"/> 
        /// </summary>
        public bool HasNext => _iterator.HasNext;
        /// <summary>
        /// KNet implementation of <see href="https://docs.oracle.com/en/java/javase/11/docs/api/java.base/java/util/Iterator.html#next()"/> 
        /// </summary>
        public KNetKeyValue<TKey, TValue> Next
        {
            get
            {
                _keySerDes ??= _factory.BuildKeySerDes<TKey>();
                _valueSerDes ??= _factory.BuildValueSerDes<TValue>();
                return _iterator != null ? new KNetKeyValue<TKey, TValue>(_factory, _iterator.Next, _keySerDes, _valueSerDes, false)
                                         : new KNetKeyValue<TKey, TValue>(_factory, _iterator2.Next, _keySerDes, _valueSerDes, false);
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
        /// Returns an <see cref="IEnumerator{E}"/> of <see cref="KNetKeyValue{TKey, TValue}"/>
        /// </summary>
        /// <param name="usePrefetch"><see langword="true"/> to return an <see cref="IEnumerator{T}"/> making preparation of <see cref="KNetKeyValue{TKey, TValue}"/> in parallel</param>
        /// <returns>An <see cref="IEnumerator{T}"/> of <see cref="KNetKeyValue{TKey, TValue}"/></returns>
        /// <remarks><paramref name="usePrefetch"/> is not considered with .NET 6 and .NET Framework</remarks>
        public IEnumerator<KNetKeyValue<TKey, TValue>> ToIEnumerator(bool usePrefetch = true)
        {
            _keySerDes ??= _factory.BuildKeySerDes<TKey>();
            _valueSerDes ??= _factory.BuildValueSerDes<TValue>();
#if NET7_0_OR_GREATER
            if (usePrefetch)
            {
                return _iterator != null ? new PrefetchableLocalEnumerator(false, _factory, _iterator.BridgeInstance, _keySerDes, _valueSerDes)
                                         : new PrefetchableLocalEnumerator(true, _factory, _iterator2.BridgeInstance, _keySerDes, _valueSerDes);
            }
#endif
            return _iterator != null ? new StandardLocalEnumerator(false, _factory, _iterator.BridgeInstance, _keySerDes, _valueSerDes)
                                     : new StandardLocalEnumerator(true, _factory, _iterator2.BridgeInstance, _keySerDes, _valueSerDes);
        }
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/KeyValueIterator.html#peekNextKey--"/>
        /// </summary>
        /// <returns><typeparamref name="TKey"/></returns>
        public TKey PeekNextKey
        {
            get
            {
                if (_iterator2 != null) return (TKey)(object)_iterator2.PeekNextKey();
                _keySerDes ??= _factory.BuildKeySerDes<TKey>();
                var kk = _iterator.PeekNextKey();
                return _keySerDes.Deserialize(null, kk);
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
