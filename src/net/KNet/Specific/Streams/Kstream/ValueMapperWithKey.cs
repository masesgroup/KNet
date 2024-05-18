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
using System;
using System.Collections.Generic;

namespace MASES.KNet.Streams.Kstream
{
    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.ValueMapperWithKey{TJVMK, TJVMV, TJVMVR}"/>
    /// </summary>
    /// <typeparam name="K">key value type</typeparam>
    /// <typeparam name="V">first value type</typeparam>
    /// <typeparam name="VR">joined value type</typeparam>
    /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
    /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
    /// <typeparam name="TJVMVR">The JVM type of <typeparamref name="VR"/></typeparam>
    public class ValueMapperWithKey<K, V, VR, TJVMK, TJVMV, TJVMVR> : Org.Apache.Kafka.Streams.Kstream.ValueMapperWithKey<TJVMK, TJVMV, TJVMVR>, IGenericSerDesFactoryApplier
    {
        TJVMK _arg0;
        TJVMV _arg1;
        K _key;
        bool _keySet = false;
        V _value;
        bool _valueSet = false;
        ISerDes<K, TJVMK> _kSerializer = null;
        ISerDes<V, TJVMV> _vSerializer = null;
        ISerDes<VR, TJVMVR> _vrSerializer = null;

        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }
        /// <summary>
        /// Returns the current <see cref="IGenericSerDesFactory"/>
        /// </summary>
        protected IGenericSerDesFactory Factory
        {
            get
            {
                IGenericSerDesFactory factory = null;
                if (this is IGenericSerDesFactoryApplier applier && (factory = applier.Factory) == null)
                {
                    throw new InvalidOperationException("The serialization factory instance was not set.");
                }
                return factory;
            }
        }
        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/ValueMapperWithKey.html#apply-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <remarks>If <see cref="OnApply"/> has a value it takes precedence over corresponding <see cref="Apply()"/> class method</remarks>
        public new System.Func<ValueMapperWithKey<K, V, VR, TJVMK, TJVMV, TJVMVR>, VR> OnApply { get; set; } = null;
        /// <summary>
        /// The <typeparamref name="K"/> content
        /// </summary>
        public virtual K Key { get { if (!_keySet) { _kSerializer ??= Factory?.BuildKeySerDes<K, TJVMK>(); _key = _kSerializer.Deserialize(null, _arg0); _keySet = true; } return _key; } }
        /// <summary>
        /// The <typeparamref name="V"/> content
        /// </summary>
        public virtual V Value { get { if (!_valueSet) { _vSerializer ??= Factory?.BuildValueSerDes<V, TJVMV>(); _value = _vSerializer.Deserialize(null, _arg1); _valueSet = true; } return _value; } }
        /// <inheritdoc/>
        public override TJVMVR Apply(TJVMK arg0, TJVMV arg1)
        {
            _keySet = _valueSet = false;
            _arg0 = arg0;
            _arg1 = arg1;

            VR res = (OnApply != null) ? OnApply(this) : Apply();
            _vrSerializer ??= Factory?.BuildValueSerDes<VR, TJVMVR>();
            return _vrSerializer.Serialize(null, res);
        }
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
    /// KNet extension of <see cref="ValueMapperWithKey{K, V, VR, TJVMK, TJVMV, TJVMVR}"/>
    /// </summary>
    /// <typeparam name="K">key value type</typeparam>
    /// <typeparam name="V">first value type</typeparam>
    /// <typeparam name="VR">joined value type</typeparam>
    public class ValueMapperWithKey<K, V, VR> : ValueMapperWithKey<K, V, VR, byte[], byte[], byte[]>
    {
    }

    /// <summary>
    /// KNet extension of <see cref="ValueMapperWithKey{K, V, VR, TJVMK, TJVMV, TJVMVR}"/>
    /// </summary>
    /// <typeparam name="K">key value type</typeparam>
    /// <typeparam name="V">first value type</typeparam>
    /// <typeparam name="VR">joined value type</typeparam>
    /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
    /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
    /// <typeparam name="TJVMVR">The JVM type of <typeparamref name="VR"/></typeparam>
    public class EnumerableValueMapperWithKey<K, V, VR, TJVMK, TJVMV, TJVMVR> : ValueMapperWithKey<K, V, VR, TJVMK, TJVMV, Java.Lang.Iterable<TJVMVR>>
    {
        TJVMK _arg0;
        TJVMV _arg1;
        K _key;
        bool _keySet = false;
        V _value;
        bool _valueSet = false;
        ISerDes<K, TJVMK> _kSerializer = null;
        ISerDes<V, TJVMV> _vSerializer = null;
        ISerDes<VR, TJVMVR> _vrSerializer = null;

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/ValueMapperWithKey.html#apply-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <remarks>If <see cref="OnApply"/> has a value it takes precedence over corresponding <see cref="Apply()"/> class method</remarks>
        public new System.Func<EnumerableValueMapperWithKey<K, V, VR, TJVMK, TJVMV, TJVMVR>, IEnumerable<VR>> OnApply { get; set; } = null;
        /// <inheritdoc/>
        public override K Key { get { if (!_keySet) { _kSerializer ??= Factory?.BuildKeySerDes<K, TJVMK>(); _key = _kSerializer.Deserialize(null, _arg0); _keySet = true; } return _key; } }
        /// <inheritdoc/>
        public override V Value { get { if (!_valueSet) { _vSerializer ??= Factory?.BuildValueSerDes<V, TJVMV>(); _value = _vSerializer.Deserialize(null, _arg1); _valueSet = true; } return _value; } }
        /// <inheritdoc/>
        public override Java.Lang.Iterable<TJVMVR> Apply(TJVMK arg0, TJVMV arg1)
        {
            _keySet = _valueSet = false;
            _arg0 = arg0;
            _arg1 = arg1;

            IEnumerable<VR> res = (OnApply != null) ? OnApply(this) : Apply();
            _vrSerializer ??= Factory?.BuildValueSerDes<VR, TJVMVR>();
            var result = new ArrayList<TJVMVR>();
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

    /// <summary>
    /// KNet extension of <see cref="EnumerableValueMapperWithKey{K, V, VR, TJVMK, TJVMV, TJVMVR}"/>
    /// </summary>
    /// <typeparam name="K">key value type</typeparam>
    /// <typeparam name="V">first value type</typeparam>
    /// <typeparam name="VR">joined value type</typeparam>
    public class EnumerableValueMapperWithKey<K, V, VR> : EnumerableValueMapperWithKey<K, V, VR, byte[], byte[], byte[]>
    {
    }
}
