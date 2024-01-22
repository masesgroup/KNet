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
    /// <typeparam name="TKey">The key type</typeparam>
    /// <typeparam name="TValue">The value type</typeparam>
    public sealed class KNetKeyValue<TKey, TValue> : IGenericSerDesFactoryApplier
    {
        readonly Org.Apache.Kafka.Streams.KeyValue<byte[], byte[]> _valueInner1 = null;
        readonly Org.Apache.Kafka.Streams.KeyValue<Java.Lang.Long, byte[]> _valueInner2 = null;
        TKey _key;
        bool _keyStored;
        TValue _value;
        bool _valueStored;
        IKNetSerDes<TKey> _keySerDes = null;
        IKNetSerDes<TValue> _valueSerDes = null;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        internal KNetKeyValue(IGenericSerDesFactory factory,
                              Org.Apache.Kafka.Streams.KeyValue<byte[], byte[]> value,
                              IKNetSerDes<TKey> keySerDes,
                              IKNetSerDes<TValue> valueSerDes,
                              bool fromAsync)
        {
            _factory = factory;
            _valueInner1 = value;
            _keySerDes = keySerDes;
            _valueSerDes = valueSerDes;
            if (fromAsync)
            {
                _keySerDes ??= _factory.BuildKeySerDes<TKey>();
                _key = _keySerDes.Deserialize(null, _valueInner1.key);
                _keyStored = true;
                _valueSerDes ??= _factory.BuildValueSerDes<TValue>();
                _value = _valueSerDes.Deserialize(null, _valueInner1.value);
                _valueStored = true;
            }
        }

        internal KNetKeyValue(IGenericSerDesFactory factory,
                              Org.Apache.Kafka.Streams.KeyValue<Java.Lang.Long, byte[]> value,
                              IKNetSerDes<TKey> keySerDes,
                              IKNetSerDes<TValue> valueSerDes,
                              bool fromAsync)
        {
            _factory = factory;
            _valueInner2 = value;
            _keySerDes = keySerDes;
            _valueSerDes = valueSerDes;
            if (fromAsync)
            {
                _keySerDes ??= _factory.BuildKeySerDes<TKey>();
                _key = (TKey)(object)_valueInner2.key.LongValue();
                _keyStored = true;
                _valueSerDes ??= _factory.BuildValueSerDes<TValue>();
                _value = _valueSerDes.Deserialize(null, _valueInner1.value);
                _valueStored = true;
            }
        }

        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KeyValue.html#key"/>
        /// </summary>
        public TKey Key
        {
            get
            {
                if (!_keyStored)
                {
                    if (_valueInner2 != null && _valueInner2.key != null)
                    {
                        var ll = _valueInner2.key; 
                        _key = (TKey)(object)ll.LongValue();
                    }
                    else
                    {
                        _keySerDes ??= _factory.BuildKeySerDes<TKey>();
                        _key = _keySerDes.Deserialize(null, _valueInner1.key);
                    }
                    _keyStored = true;
                }
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
                    _value = _valueSerDes.Deserialize(null, _valueInner1 != null ? _valueInner1.value : _valueInner2.value);
                    _valueStored = true;
                }
                return _value;
            }
        }
    }
}
