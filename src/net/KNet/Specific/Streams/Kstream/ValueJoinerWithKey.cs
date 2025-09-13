/*
*  Copyright (c) 2021-2025 MASES s.r.l.
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

using MASES.KNet.Serialization;
using System;

namespace MASES.KNet.Streams.Kstream
{
    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.ValueJoinerWithKey{TJVMK1, TJVMV1, TJVMV2, TJVMVR}"/>
    /// </summary>
    /// <typeparam name="K1">key value type</typeparam>
    /// <typeparam name="V1">first value type</typeparam>
    /// <typeparam name="V2">second value type</typeparam>
    /// <typeparam name="VR">joined value type</typeparam>
    /// <typeparam name="TJVMK1">The JVM type of <typeparamref name="K1"/></typeparam>
    /// <typeparam name="TJVMV1">The JVM type of <typeparamref name="V1"/></typeparam>
    /// <typeparam name="TJVMV2">The JVM type of <typeparamref name="V2"/></typeparam>
    /// <typeparam name="TJVMVR">The JVM type of <typeparamref name="VR"/></typeparam>
    public class ValueJoinerWithKey<K1, V1, V2, VR, TJVMK1, TJVMV1, TJVMV2, TJVMVR> : Org.Apache.Kafka.Streams.Kstream.ValueJoinerWithKey<TJVMK1, TJVMV1, TJVMV2, TJVMVR>, IGenericSerDesFactoryApplier
    {
        TJVMK1 _arg0;
        TJVMV1 _arg1;
        TJVMV2 _arg2;
        K1 _key1;
        bool _key1Set = false;
        V1 _value1;
        bool _value1Set = false;
        V2 _value2;
        bool _value2Set = false;
        ISerDes<K1, TJVMK1> _k1Serializer = null;
        ISerDes<V1, TJVMV1> _v1Serializer = null;
        ISerDes<V2, TJVMV2> _v2Serializer = null;
        ISerDes<VR, TJVMVR> _vrSerializer = null;

        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set => _factory = value; }
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
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/kstream/ValueJoinerWithKey.html#apply(java.lang.Object,java.lang.Object,java.lang.Object)"/>
        /// </summary>
        /// <remarks>If <see cref="OnApply"/> has a value it takes precedence over corresponding <see cref="Apply()"/> class method</remarks>
        public new System.Func<ValueJoinerWithKey<K1, V1, V2, VR, TJVMK1, TJVMV1, TJVMV2, TJVMVR>, VR> OnApply { get; set; } = null;
        /// <summary>
        /// The <typeparamref name="K1"/> content
        /// </summary>
        public virtual K1 Key { get { if (!_key1Set) { _k1Serializer ??= Factory?.BuildKeySerDes<K1, TJVMK1>(); _key1 = _k1Serializer.Deserialize(null, _arg0); _key1Set = true; } return _key1; } }
        /// <summary>
        /// The <typeparamref name="V1"/> content
        /// </summary>
        public virtual V1 Value1 { get { if (!_value1Set) { _v1Serializer ??= Factory?.BuildValueSerDes<V1, TJVMV1>(); _value1 = _v1Serializer.Deserialize(null, _arg1); _value1Set = true; } return _value1; } }
        /// <summary>
        /// The <typeparamref name="V2"/> content
        /// </summary>
        public virtual V2 Value2 { get { if (!_value2Set) { _v2Serializer ??= Factory?.BuildValueSerDes<V2, TJVMV2>(); _value2 = _v2Serializer.Deserialize(null, _arg2); _value2Set = true; } return _value2; } }
        /// <inheritdoc/>
        public override TJVMVR Apply(TJVMK1 arg0, TJVMV1 arg1, TJVMV2 arg2)
        {
            _key1Set = _value1Set = _value2Set = false;
            _arg0 = arg0;
            _arg1 = arg1;
            _arg2 = arg2;

            VR res = (OnApply != null) ? OnApply(this) : Apply();
            _vrSerializer ??= Factory?.BuildValueSerDes<VR, TJVMVR>();
            return _vrSerializer.Serialize(null, res);
        }
        /// <inheritdoc cref="Org.Apache.Kafka.Streams.Kstream.ValueJoinerWithKey{K1, V1, V2, VR}.Apply(K1, V1, V2)"/>
        public virtual VR Apply()
        {
            return default;
        }
    }

    /// <summary>
    /// KNet extension of <see cref="ValueJoinerWithKey{K1, V1, V2, VR, TJVMK1, TJVMV1, TJVMV2, TJVMVR}"/>
    /// </summary>
    /// <typeparam name="K1">key value type</typeparam>
    /// <typeparam name="V1">first value type</typeparam>
    /// <typeparam name="V2">second value type</typeparam>
    /// <typeparam name="VR">joined value type</typeparam>
    public class ValueJoinerWithKey<K1, V1, V2, VR> : ValueJoinerWithKey<K1, V1, V2, VR, byte[], byte[], byte[], byte[]>
    {
    }
}
