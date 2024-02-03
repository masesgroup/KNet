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
    /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.Kstream.Aggregator{K, V, VA}"/>
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <typeparam name="VA">The key type</typeparam>
    public class KNetAggregator<K, V, VA> : Org.Apache.Kafka.Streams.Kstream.Aggregator<byte[], byte[], byte[]>, IGenericSerDesFactoryApplier
    {
        byte[] _arg0, _arg1, _arg2;
        K _key;
        bool _keySet = false;
        V _value;
        bool _valueSet = false;
        VA _aggregate;
        bool _aggregateSet = false;
        IKNetSerDes<K> _kSerializer = null;
        IKNetSerDes<V> _vSerializer = null;
        IKNetSerDes<VA> _vaSerializer = null;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Aggregator.html#apply-java.lang.Object-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <remarks>If <see cref="OnApply"/> has a value it takes precedence over corresponding class method <see cref="Apply()"/></remarks>
        public new System.Func<KNetAggregator<K, V, VA>, VA> OnApply { get; set; } = null;
        /// <summary>
        /// The <typeparamref name="K"/> content
        /// </summary>
        public K Key { get { if (!_keySet) { _kSerializer ??= _factory.BuildKeySerDes<K>(); _key = _kSerializer.Deserialize(null, _arg0); _keySet = true; } return _key; } }
        /// <summary>
        /// The <typeparamref name="V"/> content
        /// </summary>
        public V Value { get { if (!_valueSet) { _vSerializer ??= _factory.BuildValueSerDes<V>(); _value = _vSerializer.Deserialize(null, _arg1); _valueSet = true; } return _value; } }
        /// <summary>
        /// The <typeparamref name="VA"/> content
        /// </summary>
        public VA Aggregate { get { if (!_aggregateSet) { _aggregate = _vaSerializer.Deserialize(null, _arg2); _aggregateSet = true; } return _aggregate; } }
        /// <inheritdoc/>
        public sealed override byte[] Apply(byte[] arg0, byte[] arg1, byte[] arg2)
        {
            _keySet = _valueSet = _aggregateSet = false;
            _arg0 = arg0;
            _arg1 = arg1;
            _arg2 = arg2;

            VA res = (OnApply != null) ? OnApply(this) : Apply();
            _vaSerializer ??= _factory.BuildValueSerDes<VA>();
            return _vaSerializer.Serialize(null, res);
        }

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Aggregator.html#apply-java.lang.Object-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <returns><typeparamref name="VA"/></returns>
        public virtual VA Apply()
        {
            return default;
        }
    }
}
