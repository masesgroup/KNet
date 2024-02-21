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

using MASES.KNet.Serialization;

namespace MASES.KNet.Streams.Kstream
{
    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.ValueJoiner{TJVMV1, TJVMV2, TJVMVR}"/>
    /// </summary>
    /// <typeparam name="V1">first value type</typeparam>
    /// <typeparam name="V2">second value type</typeparam>
    /// <typeparam name="VR">joined value type</typeparam>
    public abstract class KNetValueJoiner<V1, V2, VR, TJVMV1, TJVMV2, TJVMVR> : Org.Apache.Kafka.Streams.Kstream.ValueJoiner<TJVMV1, TJVMV2, TJVMVR>, IGenericSerDesFactoryApplier
    {
        protected IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/ValueJoinerWithKey.html#apply-java.lang.Object-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <remarks>If <see cref="OnApply"/> has a value it takes precedence over corresponding <see cref="Apply()"/> class method</remarks>
        public new System.Func<KNetValueJoiner<V1, V2, VR, TJVMV1, TJVMV2, TJVMVR>, VR> OnApply { get; set; } = null;
        /// <summary>
        /// The <typeparamref name="V1"/> content
        /// </summary>
        public abstract V1 Value1 { get; }
        /// <summary>
        /// The <typeparamref name="V2"/> content
        /// </summary>
        public abstract V2 Value2 { get; }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/ValueJoinerWithKey.html#apply-java.lang.Object-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <returns><typeparamref name="VR"/></returns>
        public virtual VR Apply()
        {
            return default;
        }
    }

    /// <summary>
    /// KNet extension of <see cref="KNetValueJoiner{V1, V2, VR, TJVMV1, TJVMV2, TJVMVR}"/>
    /// </summary>
    /// <typeparam name="V1">first value type</typeparam>
    /// <typeparam name="V2">second value type</typeparam>
    /// <typeparam name="VR">joined value type</typeparam>
    public class KNetValueJoiner<V1, V2, VR> : KNetValueJoiner<V1, V2, VR, byte[], byte[], byte[]>
    {
        byte[] _arg0, _arg1;
        V1 _value1;
        bool _value1Set = false;
        V2 _value2;
        bool _value2Set = false;
        IKNetSerDes<V1> _v1Serializer = null;
        IKNetSerDes<V2> _v2Serializer = null;
        IKNetSerDes<VR> _vrSerializer = null;

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/ValueJoinerWithKey.html#apply-java.lang.Object-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <remarks>If <see cref="OnApply"/> has a value it takes precedence over corresponding <see cref="Apply()"/> class method</remarks>
        public new System.Func<KNetValueJoiner<V1, V2, VR>, VR> OnApply { get; set; } = null;
        /// <inheritdoc/>
        public override V1 Value1 { get { if (!_value1Set) { _v1Serializer ??= _factory.BuildValueSerDes<V1>(); _value1 = _v1Serializer.Deserialize(null, _arg0); _value1Set = true; } return _value1; } }
        /// <inheritdoc/>
        public override V2 Value2 { get { if (!_value2Set) { _v2Serializer ??= _factory.BuildValueSerDes<V2>(); _value2 = _v2Serializer.Deserialize(null, _arg1); _value2Set = true; } return _value2; } }
        /// <inheritdoc/>
        public sealed override byte[] Apply(byte[] arg0, byte[] arg1)
        {
            _value1Set = _value2Set = false;
            _arg0 = arg0;
            _arg1 = arg1;

            VR res = (OnApply != null) ? OnApply(this) : Apply();
            _vrSerializer ??= _factory.BuildValueSerDes<VR>();
            return _vrSerializer.Serialize(null, res);
        }
    }
}
