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
    /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.Kstream.Predicate{K, V}"/>
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    public class KNetPredicate<K, V> : Org.Apache.Kafka.Streams.Kstream.Predicate<byte[], byte[]>, IGenericSerDesFactoryApplier
    {
        byte[] _arg0, _arg1;
        K _key;
        bool _keySet;
        V _value;
        bool _valueSet;
        IKNetSerDes<K> _kSerializer = null;
        IKNetSerDes<V> _vSerializer = null;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }
        /// <summary>
        /// Default initializer
        /// </summary>
        public KNetPredicate()
        {
            _kSerializer = _factory.BuildKeySerDes<K>();
            _vSerializer = _factory.BuildValueSerDes<V>();
        }
        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Predicate.html#test-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <remarks>If <see cref="OnTest"/> has a value it takes precedence over corresponding <see cref="Test()"/> class method</remarks>
        public new System.Func<KNetPredicate<K, V>, bool> OnTest { get; set; } = null;
        /// <summary>
        /// The <typeparamref name="K"/> content
        /// </summary>
        public K Key { get { if (!_keySet) { _kSerializer ??= _factory.BuildKeySerDes<K>(); _key = _kSerializer.Deserialize(null, _arg0); _keySet = true; } return _key; } }
        /// <summary>
        /// The <typeparamref name="V"/> content
        /// </summary>
        public V Value { get { if (!_valueSet) { _vSerializer ??= _factory.BuildValueSerDes<V>(); _value = _vSerializer.Deserialize(null, _arg1); _valueSet = true; } return _value; } }
        /// <inheritdoc/>
        public sealed override bool Test(byte[] arg0, byte[] arg1)
        {
            _keySet = _valueSet = false;
            _arg0 = arg0;
            _arg1 = arg1;

            return (OnTest != null) ? OnTest(this) : Test();
        }
        /// <summary>
        /// KNet override of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Predicate.html#test-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <returns><see cref="bool"/></returns>
        public virtual bool Test()
        {
            return default;
        }
    }
}
