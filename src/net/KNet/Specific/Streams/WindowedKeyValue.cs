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
using MASES.KNet.Streams.Kstream;

namespace MASES.KNet.Streams
{
    /// <summary>
    /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.KeyValue{K, V}"/> where the key is <see cref="Org.Apache.Kafka.Streams.Kstream.Windowed{K}"/>
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
    /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
    public sealed class WindowedKeyValue<K, V, TJVMK, TJVMV> : IGenericSerDesFactoryApplier
    {
        readonly KeyValueSupport<Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, TJVMV> _valueInner;
        Windowed<K, TJVMK> _key = null;
        V _value;
        bool _valueStored;
        ISerDes<V, TJVMV> _valueSerDes = null;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        internal WindowedKeyValue(IGenericSerDesFactory factory,
                                  KeyValueSupport<Org.Apache.Kafka.Streams.Kstream.Windowed<TJVMK>, TJVMV> value,
                                  ISerDes<V, TJVMV> valueSerDes,
                                  bool fromPrefetched)
        {
            _factory = factory;
            _valueInner = value;
            _valueSerDes = valueSerDes;
            if (fromPrefetched)
            {
                _valueSerDes ??= _factory?.BuildValueSerDes<V, TJVMV>();
                _value = _valueSerDes.Deserialize(null, _valueInner.Value);
                _valueStored = true;
            }
        }

        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/KeyValue.html#key"/>
        /// </summary>
        public Windowed<K, TJVMK> Key
        {
            get
            {
                _key ??= new Windowed<K, TJVMK>(_factory, _valueInner.Key);
                return _key;
            }
        }
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/KeyValue.html#value"/>
        /// </summary>
        public V Value
        {
            get
            {
                if (!_valueStored)
                {
                    _valueSerDes ??= _factory?.BuildValueSerDes<V, TJVMV>();
                    var kk = _valueInner.Value;
                    _value = _valueSerDes.Deserialize(null, kk);
                    _valueStored = true;
                }
                return _value;
            }
        }
    }
}
