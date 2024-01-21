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
using MASES.KNet.Streams.State;

namespace MASES.KNet.Streams
{
    /// <summary>
    /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.State.ValueAndTimestamp{V}"/> 
    /// </summary>
    /// <typeparam name="TKey">The key type</typeparam>
    /// <typeparam name="TValue">The value type</typeparam>
    public class KNetTimestampedKeyValue<TKey, TValue> : IGenericSerDesFactoryApplier
    {
        readonly Org.Apache.Kafka.Streams.KeyValue<byte[], Org.Apache.Kafka.Streams.State.ValueAndTimestamp<byte[]>> _valueInner1 = null;
        readonly Org.Apache.Kafka.Streams.KeyValue<Java.Lang.Long, Org.Apache.Kafka.Streams.State.ValueAndTimestamp<byte[]>> _valueInner2 = null;
        readonly bool _fromAsync;
        readonly TKey _key;
        IKNetSerDes<TKey> _keySerDes = null;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        internal KNetTimestampedKeyValue(IGenericSerDesFactory factory, 
                                         Org.Apache.Kafka.Streams.KeyValue<byte[], Org.Apache.Kafka.Streams.State.ValueAndTimestamp<byte[]>> value,
                                         IKNetSerDes<TKey> keySerDes,
                                         bool fromAsync)
        {
            _factory = factory;
            _valueInner1 = value;
            _keySerDes = keySerDes;
            _fromAsync = fromAsync;
            if (_fromAsync)
            {
                _keySerDes ??= _factory.BuildKeySerDes<TKey>();
                _key = _keySerDes.Deserialize(null, _valueInner1.key);
            }
        }

        internal KNetTimestampedKeyValue(IGenericSerDesFactory factory, 
                                         Org.Apache.Kafka.Streams.KeyValue<Java.Lang.Long, Org.Apache.Kafka.Streams.State.ValueAndTimestamp<byte[]>> value,
                                         IKNetSerDes<TKey> keySerDes,
                                         bool fromAsync)
        {
            _factory = factory;
            _valueInner2 = value;
            _keySerDes = keySerDes;
            _fromAsync = fromAsync;
            if (_fromAsync)
            {
                _keySerDes ??= _factory.BuildKeySerDes<TKey>();
                _key = (TKey)(object)_valueInner2.key.LongValue();
            }
        }

        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KeyValue.html#key"/>
        /// </summary>
        public TKey Key
        {
            get
            {
                if (_fromAsync) return _key;
                if (_valueInner2 != null && _valueInner2.key != null) { var ll = _valueInner2.key; return (TKey)(object)ll.LongValue(); }
                _keySerDes ??= _factory.BuildKeySerDes<TKey>();
                return _keySerDes.Deserialize(null, _valueInner1.key);
            }
        }
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KeyValue.html#value"/>
        /// </summary>
        public KNetValueAndTimestamp<TValue> Value => new KNetValueAndTimestamp<TValue>(_factory, _valueInner1 != null ? _valueInner1.value : _valueInner2.value);
    }
}
