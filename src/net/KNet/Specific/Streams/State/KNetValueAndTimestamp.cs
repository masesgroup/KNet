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
using System;

namespace MASES.KNet.Streams.State
{
    /// <summary>
    /// KNet Implementation of <see cref="Org.Apache.Kafka.Streams.State.ValueAndTimestamp{V}"/>
    /// </summary>
    /// <typeparam name="TValue">The value type</typeparam>
    public class KNetValueAndTimestamp<TValue> : IGenericSerDesFactoryApplier
    {
        readonly Org.Apache.Kafka.Streams.State.ValueAndTimestamp<byte[]> _valueAndTimestamp;
        IKNetSerDes<TValue> _valueSerDes;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        internal KNetValueAndTimestamp(IGenericSerDesFactory factory, Org.Apache.Kafka.Streams.State.ValueAndTimestamp<byte[]> valueAndTimestamp)
        {
            _factory = factory;
            _valueAndTimestamp = valueAndTimestamp;
        }

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ValueAndTimestamp.html#timestamp--"/>
        /// </summary>
        /// <returns><see cref="long"/></returns>
        public long Timestamp => _valueAndTimestamp.Timestamp();
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ValueAndTimestamp.html#timestamp--"/>
        /// </summary>
        /// <returns><see cref="DateTime"/></returns>
        public DateTime DateTime => DateTimeOffset.FromUnixTimeMilliseconds(Timestamp).DateTime;
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/ValueAndTimestamp.html#value--"/>
        /// </summary>
        /// <returns><typeparamref name="TValue"/></returns>
        public TValue Value
        {
            get
            {
                _valueSerDes ??= _factory?.BuildKeySerDes<TValue>();
                var vv = _valueAndTimestamp.Value();
                return _valueSerDes.Deserialize(null, vv);
            }
        }
    }
}
