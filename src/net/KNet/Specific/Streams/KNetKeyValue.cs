/*
*  Copyright 2023 MASES s.r.l.
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

namespace MASES.KNet.Streams
{
    /// <summary>
    /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.KeyValue{K, V}"/> 
    /// </summary>
    /// <typeparam name="TKey">The key type</typeparam>
    /// <typeparam name="TValue">The value type</typeparam>
    public class KNetKeyValue<TKey, TValue> : IGenericSerDesFactoryApplier
    {
        readonly byte[] _key = null;
        readonly long? _keyLong = null;
        readonly byte[] _value = null;
        readonly IKNetSerDes<TKey> _keySerDes;
        readonly IKNetSerDes<TValue> _valueSerDes;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        internal KNetKeyValue(IGenericSerDesFactory factory, Org.Apache.Kafka.Streams.KeyValue<byte[], byte[]> value)
        {
#pragma warning disable CA1816
            GC.SuppressFinalize(value);
#pragma warning restore CA1816
            _factory = factory;
            _keySerDes = _factory.BuildKeySerDes<TKey>();
            _valueSerDes = _factory.BuildValueSerDes<TValue>();
            _key = value.key;
            _value = value.value;
            GC.ReRegisterForFinalize(value);
        }

        internal KNetKeyValue(IGenericSerDesFactory factory, Org.Apache.Kafka.Streams.KeyValue<Java.Lang.Long, byte[]> value)
        {
#pragma warning disable CA1816
            GC.SuppressFinalize(value);
#pragma warning restore CA1816
            _factory = factory;
            _keySerDes = _factory.BuildKeySerDes<TKey>();
            _valueSerDes = _factory.BuildValueSerDes<TValue>();
            _keyLong = value.key?.LongValue();
            _value = value.value;
            GC.ReRegisterForFinalize(value);
        }

        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KeyValue.html#key"/>
        /// </summary>
        public TKey Key => _key != null ? _keySerDes.Deserialize(null, _key) : (TKey)(object)_keyLong;
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/KeyValue.html#value"/>
        /// </summary>
        public TValue Value =>  _valueSerDes.Deserialize(null, _value);
    }
}
