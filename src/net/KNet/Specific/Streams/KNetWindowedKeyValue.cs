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
using MASES.KNet.Streams.Kstream;

namespace MASES.KNet.Streams
{
    /// <summary>
    /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.KeyValue{K, V}"/> where the key is <see cref="Org.Apache.Kafka.Streams.Kstream.Windowed{K}"/>
    /// </summary>
    /// <typeparam name="TKey">The key type</typeparam>
    /// <typeparam name="TValue">The value type</typeparam>
    public class KNetWindowedKeyValue<TKey, TValue> : IGenericSerDesFactoryApplier
    {
        readonly Org.Apache.Kafka.Streams.KeyValue<Org.Apache.Kafka.Streams.Kstream.Windowed<byte[]>, byte[]> _valueInner;
        KNetWindowed<TKey> _key = null;
        TValue _value;
        bool _valueStored;
        IKNetSerDes<TValue> _valueSerDes = null;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        internal KNetWindowedKeyValue(IGenericSerDesFactory factory,
                                      Org.Apache.Kafka.Streams.KeyValue<Org.Apache.Kafka.Streams.Kstream.Windowed<byte[]>, byte[]> value,
                                      IKNetSerDes<TValue> valueSerDes,
                                      bool fromAsync)
        {
            _factory = factory;
            _valueInner = value;
            _valueSerDes = valueSerDes;
            if (fromAsync)
            {
                _valueSerDes ??= _factory.BuildValueSerDes<TValue>();
                _value = _valueSerDes.Deserialize(null, _valueInner.value);
                _valueStored = true;
            }
        }

        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KeyValue.html#key"/>
        /// </summary>
        public KNetWindowed<TKey> Key
        {
            get
            {
                _key ??= new KNetWindowed<TKey>(_factory, _valueInner.key);
                return _key;
            }
        }
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KeyValue.html#value"/>
        /// </summary>
        public TValue Value
        {
            get
            {
                if (!_valueStored)
                {
                    _valueSerDes ??= _factory.BuildValueSerDes<TValue>();
                    var kk = _valueInner.value;
                    _value = _valueSerDes.Deserialize(null, kk);
                    _valueStored = true;
                }
                return _value;
            }
        }
    }
}
