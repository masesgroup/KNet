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

using Java.Util;
using MASES.KNet.Serialization;
using System;
using System.Collections.Generic;

namespace MASES.KNet.Streams.Kstream
{
    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.KeyValueMapper{K, V, VR}"/>
    /// </summary>
    /// <typeparam name="K">key value type</typeparam>
    /// <typeparam name="V">first value type</typeparam>
    /// <typeparam name="VR">joined value type</typeparam>
    public class KNetKeyValueMapper<K, V, VR> : Org.Apache.Kafka.Streams.Kstream.KeyValueMapper<byte[], byte[], byte[]>, IGenericSerDesFactoryApplier
    {
        byte[] _arg0, _arg1;
        K _key;
        bool _keySet = false;
        V _value;
        bool _valueSet = false;
        IKNetSerDes<K> _kSerializer = null;
        IKNetSerDes<V> _vSerializer = null;
        IKNetSerDes<VR> _vrSerializer = null;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }
        /// <summary>
        /// Default initializer
        /// </summary>
        public KNetKeyValueMapper()
        {
            _kSerializer = _factory.BuildKeySerDes<K>();
            _vSerializer = _factory.BuildValueSerDes<V>();
            _vrSerializer = _factory.BuildValueSerDes<VA>();
        }
        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KeyValueMapper.html#apply-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <remarks>If <see cref="OnApply"/> has a value it takes precedence over corresponding <see cref="Apply()"/> class method</remarks>
        public new System.Func<KNetKeyValueMapper<K, V, VR>, VR> OnApply { get; set; } = null;
        /// <summary>
        /// The <typeparamref name="K"/> content
        /// </summary>
        public K Key { get { if (!_keySet) { _key = _kSerializer.Deserialize(null, _arg0); _keySet = true; } return _key; } }
        /// <summary>
        /// The <typeparamref name="V"/> content
        /// </summary>
        public V Value { get { if (!_valueSet) { _value = _vSerializer.Deserialize(null, _arg1); _valueSet = true; } return _value; } }
        /// <inheritdoc/>
        public sealed override byte[] Apply(byte[] arg0, byte[] arg1)
        {
            _kSerializer ??= _factory.BuildKeySerDes<K>();
            _vSerializer ??= _factory.BuildValueSerDes<V>();
            _vrSerializer ??= _factory.BuildValueSerDes<VR>();

            _arg0 = arg0;
            _arg1 = arg1;

            VR res = (OnApply != null) ? OnApply(this) : Apply();
            return _vrSerializer.Serialize(null, res);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KeyValueMapper.html#apply-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <returns><typeparamref name="VR"/></returns>
        public virtual VR Apply()
        {
            return default;
        }
    }

    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.KeyValueMapper{K, V, VR}"/>
    /// </summary>
    /// <typeparam name="K">key value type</typeparam>
    /// <typeparam name="V">first value type</typeparam>
    /// <typeparam name="KR">first value type</typeparam>
    /// <typeparam name="VR">joined value type</typeparam>
    public class KNetKeyValueKeyValueMapper<K, V, KR, VR> : Org.Apache.Kafka.Streams.Kstream.KeyValueMapper<byte[], byte[], Org.Apache.Kafka.Streams.KeyValue<byte[], byte[]>>, IGenericSerDesFactoryApplier
    {
        byte[] _arg0, _arg1;
        K _key;
        bool _keySet = false;
        V _value;
        bool _valueSet = false;
        IKNetSerDes<K> _kSerializer = null;
        IKNetSerDes<V> _vSerializer = null;
        IKNetSerDes<KR> _krSerializer = null;
        IKNetSerDes<VR> _vrSerializer = null;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }
        /// <summary>
        /// Default initializer
        /// </summary>
        public KNetKeyValueKeyValueMapper()
        {
            _kSerializer = _factory.BuildKeySerDes<K>();
            _vSerializer = _factory.BuildValueSerDes<V>();
            _krSerializer = _factory.BuildValueSerDes<KR>();
            _vrSerializer = _factory.BuildValueSerDes<VR>();
        }
        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KeyValueMapper.html#apply-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <remarks>If <see cref="OnApply"/> has a value it takes precedence over corresponding <see cref="Apply()"/> class method</remarks>
        public new System.Func<KNetKeyValueKeyValueMapper<K, V, KR, VR>, (KR, VR)> OnApply { get; set; } = null;
        /// <summary>
        /// The <typeparamref name="K"/> content
        /// </summary>
        public K Key { get { if (!_keySet) { _kSerializer ??= _factory.BuildKeySerDes<K>(); _key = _kSerializer.Deserialize(null, _arg0); _keySet = true; } return _key; } }
        /// <summary>
        /// The <typeparamref name="V"/> content
        /// </summary>
        public V Value { get { if (!_valueSet) { _vSerializer ??= _factory.BuildValueSerDes<V>(); _value = _vSerializer.Deserialize(null, _arg1); _valueSet = true; } return _value; } }
        /// <inheritdoc/>
        public sealed override Org.Apache.Kafka.Streams.KeyValue<byte[], byte[]> Apply(byte[] arg0, byte[] arg1)
        {
            _keySet = _valueSet = false;
            _arg0 = arg0;
            _arg1 = arg1;

            (KR, VR) res = (OnApply != null) ? OnApply(this) : Apply();
            _krSerializer ??= _factory.BuildValueSerDes<KR>();
            _vrSerializer ??= _factory.BuildValueSerDes<VR>();
            return new Org.Apache.Kafka.Streams.KeyValue<byte[], byte[]>(_krSerializer.Serialize(null, res.Item1), _vrSerializer.Serialize(null, res.Item2)); ;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KeyValueMapper.html#apply-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <returns><see cref="Tuple"/> of <typeparamref name="KR"/> and <typeparamref name="VR"/></returns>
        public virtual (KR, VR) Apply()
        {
            return default;
        }
    }

    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.KeyValueMapper{K, V, VR}"/>
    /// </summary>
    /// <typeparam name="K">key value type</typeparam>
    /// <typeparam name="V">first value type</typeparam>
    /// <typeparam name="KR">first value type</typeparam>
    /// <typeparam name="VR">joined value type</typeparam>
    public class KNetEnumerableKeyValueMapper<K, V, KR, VR> : Org.Apache.Kafka.Streams.Kstream.KeyValueMapper<byte[], byte[], Java.Lang.Iterable<Org.Apache.Kafka.Streams.KeyValue<byte[], byte[]>>>, IGenericSerDesFactoryApplier
    {
        byte[] _arg0, _arg1;
        K _key;
        bool _keySet = false;
        V _value;
        bool _valueSet = false;
        IKNetSerDes<K> _kSerializer = null;
        IKNetSerDes<V> _vSerializer = null;
        IKNetSerDes<KR> _krSerializer = null;
        IKNetSerDes<VR> _vrSerializer = null;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }
        /// <summary>
        /// Default initializer
        /// </summary>
        public KNetEnumerableKeyValueMapper()
        {
            _kSerializer = _factory.BuildKeySerDes<K>();
            _vSerializer = _factory.BuildValueSerDes<V>();
            _krSerializer = _factory.BuildValueSerDes<KR>();
            _vrSerializer = _factory.BuildValueSerDes<VR>();
        }
        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KeyValueMapper.html#apply-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <remarks>If <see cref="OnApply"/> has a value it takes precedence over corresponding <see cref="Apply()"/> class method</remarks>
        public new System.Func<KNetEnumerableKeyValueMapper<K, V, KR, VR>, IEnumerable<(KR, VR)>> OnApply { get; set; } = null;
        /// <summary>
        /// The <typeparamref name="K"/> content
        /// </summary>
        public K Key { get { if (!_keySet) { _key = _kSerializer.Deserialize(null, _arg0); _keySet = true; } return _key; } }
        /// <summary>
        /// The <typeparamref name="V"/> content
        /// </summary>
        public V Value { get { if (!_valueSet) { _value = _vSerializer.Deserialize(null, _arg1); _valueSet = true; } return _value; } }
        /// <inheritdoc/>
        public sealed override Java.Lang.Iterable<Org.Apache.Kafka.Streams.KeyValue<byte[], byte[]>> Apply(byte[] arg0, byte[] arg1)
        {
            _kSerializer ??= _factory.BuildKeySerDes<K>();
            _vSerializer ??= _factory.BuildValueSerDes<V>();
            _krSerializer ??= _factory.BuildValueSerDes<KR>();
            _vrSerializer ??= _factory.BuildValueSerDes<VR>();

            _arg0 = arg0;
            _arg1 = arg1;

            IEnumerable<(KR, VR)> res = (OnApply != null) ? OnApply(this) : Apply();
            var result = new ArrayList<Org.Apache.Kafka.Streams.KeyValue<byte[], byte[]>>();
            foreach (var item in res)
            {
                var data = new Org.Apache.Kafka.Streams.KeyValue<byte[], byte[]>(_krSerializer.Serialize(null, item.Item1), _vrSerializer.Serialize(null, item.Item2));
                result.Add(data);
            }
            return result;
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/KeyValueMapper.html#apply-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <returns><typeparamref name="VR"/></returns>
        public virtual IEnumerable<(KR, VR)> Apply()
        {
            return default;
        }
    }
}
