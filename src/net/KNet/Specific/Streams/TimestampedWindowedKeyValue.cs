﻿/*
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
using MASES.KNet.Streams.State;

namespace MASES.KNet.Streams
{
    /// <summary>
    /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.KeyValue{K, V}"/> 
    /// </summary>
    /// <typeparam name="TKey">The key type</typeparam>
    /// <typeparam name="TValue">The value type</typeparam>
    public sealed class TimestampedWindowedKeyValue<TKey, TValue> : IGenericSerDesFactoryApplier
    {
        readonly Org.Apache.Kafka.Streams.KeyValue<Org.Apache.Kafka.Streams.Kstream.Windowed<byte[]>, Org.Apache.Kafka.Streams.State.ValueAndTimestamp<byte[]>> _valueInner;
        Windowed<TKey> _key = null;
        ValueAndTimestamp<TValue> _value = null;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        internal TimestampedWindowedKeyValue(IGenericSerDesFactory factory,
                                                 Org.Apache.Kafka.Streams.KeyValue<Org.Apache.Kafka.Streams.Kstream.Windowed<byte[]>, Org.Apache.Kafka.Streams.State.ValueAndTimestamp<byte[]>> value)
        {
            _factory = factory;
            _valueInner = value;
        }

        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KeyValue.html#key"/>
        /// </summary>
        public Windowed<TKey> Key
        {
            get
            {
                _key ??= new Windowed<TKey>(_factory, _valueInner.key);
                return _key;
            }
        }
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KeyValue.html#value"/>
        /// </summary>
        public ValueAndTimestamp<TValue> Value
        {
            get
            {
                _value ??= new ValueAndTimestamp<TValue>(_factory, _valueInner.value);
                return _value;
            }
        }
    }
}
