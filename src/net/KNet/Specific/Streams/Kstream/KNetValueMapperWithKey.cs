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
using MASES.JCOBridge.C2JBridge;
using MASES.KNet.Serialization;
using System.Collections.Generic;

namespace MASES.KNet.Streams.Kstream
{
    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.ValueMapperWithKey{TJVMK, TJVMV, TJVMVR}"/>
    /// </summary>
    /// <typeparam name="K">key value type</typeparam>
    /// <typeparam name="V">first value type</typeparam>
    /// <typeparam name="VR">joined value type</typeparam>
    public abstract class KNetValueMapperWithKey<K, V, VR, TJVMK, TJVMV, TJVMVR> : Org.Apache.Kafka.Streams.Kstream.ValueMapperWithKey<TJVMK, TJVMV, TJVMVR>, IGenericSerDesFactoryApplier
    {
        protected IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/ValueMapperWithKey.html#apply-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <remarks>If <see cref="OnApply"/> has a value it takes precedence over corresponding <see cref="Apply()"/> class method</remarks>
        public new System.Func<KNetValueMapperWithKey<K, V, VR, TJVMK, TJVMV, TJVMVR>, VR> OnApply { get; set; } = null;
        /// <summary>
        /// The <typeparamref name="K"/> content
        /// </summary>
        public abstract K Key { get; }
        /// <summary>
        /// The <typeparamref name="V"/> content
        /// </summary>
        public abstract V Value { get; }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/ValueMapperWithKey.html#apply-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <returns><typeparamref name="VR"/></returns>
        public virtual VR Apply()
        {
            return default;
        }
    }

    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.ValueMapperWithKey{K, V, VR}"/>
    /// </summary>
    /// <typeparam name="K">key value type</typeparam>
    /// <typeparam name="V">first value type</typeparam>
    /// <typeparam name="VR">joined value type</typeparam>
    public class KNetValueMapperWithKey<K, V, VR> : KNetValueMapperWithKey<K, V, VR, byte[], byte[], byte[]>
    {
        byte[] _arg0, _arg1;
        K _key;
        bool _keySet = false;
        V _value;
        bool _valueSet = false;
        IKNetSerDes<K> _kSerializer = null;
        IKNetSerDes<V> _vSerializer = null;
        IKNetSerDes<VR> _vrSerializer = null;

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/ValueMapperWithKey.html#apply-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <remarks>If <see cref="OnApply"/> has a value it takes precedence over corresponding <see cref="KNetValueMapperWithKey{K, V, VR, TJVMK, TJVMV, TJVMVR}.Apply()"/> class method</remarks>
        public new System.Func<KNetValueMapperWithKey<K, V, VR>, VR> OnApply { get; set; } = null;
        /// <inheritdoc/>
        public override K Key { get { if (!_keySet) { _kSerializer ??= _factory.BuildKeySerDes<K>(); _key = _kSerializer.Deserialize(null, _arg0); _keySet = true; } return _key; } }
        /// <inheritdoc/>
        public override V Value { get { if (!_valueSet) { _vSerializer ??= _factory.BuildValueSerDes<V>(); _value = _vSerializer.Deserialize(null, _arg1); _valueSet = true; } return _value; } }
        /// <inheritdoc/>
        public sealed override byte[] Apply(byte[] arg0, byte[] arg1)
        {
            _keySet = _valueSet = false;
            _arg0 = arg0;
            _arg1 = arg1;

            VR res = (OnApply != null) ? OnApply(this) : Apply();
            _vrSerializer ??= _factory.BuildValueSerDes<VR>();
            return _vrSerializer.Serialize(null, res);
        }
    }

    /// <summary>
    /// KNet extension of <see cref="KNetValueMapperWithKey{K, V, VR, TJVMK, TJVMV, TJVMVR}"/>
    /// </summary>
    /// <typeparam name="K">key value type</typeparam>
    /// <typeparam name="V">first value type</typeparam>
    /// <typeparam name="VR">joined value type</typeparam>
    public abstract class KNetEnumerableValueMapperWithKey<K, V, VR, TJVMK, TJVMV, TJVMVR> : KNetValueMapperWithKey<K, V, VR, TJVMK, TJVMV, Java.Lang.Iterable<TJVMVR>>
    {
        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/ValueMapperWithKey.html#apply-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <remarks>If <see cref="OnApply"/> has a value it takes precedence over corresponding <see cref="Apply()"/> class method</remarks>
        public new System.Func<KNetEnumerableValueMapperWithKey<K, V, VR>, IEnumerable<VR>> OnApply { get; set; } = null;

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/ValueMapperWithKey.html#apply-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <returns><typeparamref name="VR"/></returns>
        public new virtual IEnumerable<VR> Apply()
        {
            return default;
        }
    }

    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.ValueMapperWithKey{K, V, VR}"/>
    /// </summary>
    /// <typeparam name="K">key value type</typeparam>
    /// <typeparam name="V">first value type</typeparam>
    /// <typeparam name="VR">joined value type</typeparam>
    public class KNetEnumerableValueMapperWithKey<K, V, VR> : KNetEnumerableValueMapperWithKey<K, V, VR, byte[], byte[], byte[]>
    {
        byte[] _arg0, _arg1;
        K _key;
        bool _keySet = false;
        V _value;
        bool _valueSet = false;
        IKNetSerDes<K> _kSerializer = null;
        IKNetSerDes<V> _vSerializer = null;
        IKNetSerDes<VR> _vrSerializer = null;

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/ValueMapperWithKey.html#apply-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <remarks>If <see cref="OnApply"/> has a value it takes precedence over corresponding <see cref="Apply()"/> class method</remarks>
        public new System.Func<KNetEnumerableValueMapperWithKey<K, V, VR>, IEnumerable<VR>> OnApply { get; set; } = null;
        /// <inheritdoc/>
        public override K Key { get { if (!_keySet) { _kSerializer ??= _factory.BuildKeySerDes<K>(); _key = _kSerializer.Deserialize(null, _arg0); _keySet = true; } return _key; } }
        /// <inheritdoc/>
        public override V Value { get { if (!_valueSet) { _vSerializer ??= _factory.BuildValueSerDes<V>(); _value = _vSerializer.Deserialize(null, _arg1); _valueSet = true; } return _value; } }
        /// <inheritdoc/>
        public sealed override Java.Lang.Iterable<byte[]> Apply(byte[] arg0, byte[] arg1)
        {
            _keySet = _valueSet = false;
            _arg0 = arg0;
            _arg1 = arg1;

            IEnumerable<VR> res = (OnApply != null) ? OnApply(this) : Apply();
            _vrSerializer ??= _factory.BuildValueSerDes<VR>();
            var result = new ArrayList<byte[]>();
            foreach (var item in res)
            {
                result.Add(_vrSerializer.Serialize(null, item));
            }
            return result;
        }

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/ValueMapperWithKey.html#apply-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <returns><typeparamref name="VR"/></returns>
        public new virtual IEnumerable<VR> Apply()
        {
            return default;
        }
    }
}
