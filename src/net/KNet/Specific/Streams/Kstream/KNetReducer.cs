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
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.Reducer{TJVMV}"/>
    /// </summary>
    /// <typeparam name="V">value type</typeparam>
    public abstract class KNetReducer<V, TJVMV> : Org.Apache.Kafka.Streams.Kstream.Reducer<TJVMV>, IGenericSerDesFactoryApplier
    {
        protected IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }
        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/ValueMapperWithKey.html#apply-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <remarks>If <see cref="OnApply"/> has a value it takes precedence over corresponding <see cref="Apply()"/> class method</remarks>
        public new System.Func<KNetReducer<V>, V> OnApply { get; set; } = null;

        /// <summary>
        /// The <typeparamref name="V"/> content
        /// </summary>
        public abstract V Value1 { get; }

        /// <summary>
        /// The <typeparamref name="V"/> content
        /// </summary>
        public abstract V Value2 { get; }

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Reducer.html#apply-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <returns><typeparamref name="V"/></returns>
        public virtual V Apply()
        {
            return default;
        }
    }


    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.Reducer{V}"/>
    /// </summary>
    /// <typeparam name="V">value type</typeparam>
    public class KNetReducer<V> : KNetReducer<V, byte[]>
    {
        byte[] _arg0, _arg1;
        V _value1;
        bool _value1Set;
        V _value2;
        bool _value2Set;
        IKNetSerDes<V> _vSerializer = null;
        /// <summary>
        /// Default initializer
        /// </summary>
        public KNetReducer()
        {
            _vSerializer = _factory.BuildValueSerDes<V>();
        }

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/ValueMapperWithKey.html#apply-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <remarks>If <see cref="OnApply"/> has a value it takes precedence over corresponding <see cref="KNetReducer{V, TJVMV}.Apply()"/> class method</remarks>
        public new System.Func<KNetReducer<V>, V> OnApply { get; set; } = null;
        /// <inheritdoc/>
        public override  V Value1 { get { if (!_value1Set) { _value1 = _vSerializer.Deserialize(null, _arg0); _value1Set = true; } return _value1; } }
        /// <inheritdoc/>
        public override V Value2 { get { if (!_value2Set) { _value2 = _vSerializer.Deserialize(null, _arg1); _value2Set = true; } return _value2; } }
        /// <inheritdoc/>
        public sealed override byte[] Apply(byte[] arg0, byte[] arg1)
        {
            _value1Set = _value2Set = false;
            _arg0 = arg0;
            _arg1 = arg1;

            V res = (OnApply != null) ? OnApply(this) : Apply();
            _vSerializer ??= _factory.BuildValueSerDes<V>();
            return _vSerializer.Serialize(null, res);
        }
    }
}
