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

namespace MASES.KNet.Streams
{
    /// <summary>
    /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.KeyValue{K, V}"/> 
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
    /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
    public sealed class KeyValue<K, V, TJVMK, TJVMV> : IGenericSerDesFactoryApplier
    {
        readonly KeyValueSupport<TJVMK, TJVMV> _inner = null;
        K _key;
        bool _keyStored;
        V _value;
        bool _valueStored;
        ISerDes<K, TJVMK> _keySerDes = null;
        ISerDes<V, TJVMV> _valueSerDes = null;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        internal KeyValue(IGenericSerDesFactory factory,
                          KeyValueSupport<TJVMK, TJVMV> value,
                          ISerDes<K, TJVMK> keySerDes,
                          ISerDes<V, TJVMV> valueSerDes,
                          bool fromPrefetched)
        {
            _factory = factory;
            _inner = value;
            _keySerDes = keySerDes;
            _valueSerDes = valueSerDes;
            if (fromPrefetched)
            {
                _keySerDes ??= _factory?.BuildKeySerDes<K, TJVMK>();
                _key = _keySerDes.Deserialize(null, _inner.Key);
                _keyStored = true;
                _valueSerDes ??= _factory?.BuildValueSerDes<V, TJVMV>();
                _value = _valueSerDes.Deserialize(null, _inner.Value);
                _valueStored = true;
            }
        }

        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.7.1/org/apache/kafka/streams/KeyValue.html#key"/>
        /// </summary>
        public K Key
        {
            get
            {
                if (!_keyStored)
                {
                    _keySerDes ??= _factory?.BuildKeySerDes<K, TJVMK>();
                    _key = _keySerDes.Deserialize(null, _inner.Key);
                    _keyStored = true;
                }
                return _key;
            }
        }
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.7.1/org/apache/kafka/streams/KeyValue.html#value"/>
        /// </summary>
        public V Value
        {
            get
            {
                if (!_valueStored)
                {
                    _valueSerDes ??= _factory?.BuildValueSerDes<V, TJVMV>();
                    _value = _valueSerDes.Deserialize(null, _inner.Value);
                    _valueStored = true;
                }
                return _value;
            }
        }
    }
}
