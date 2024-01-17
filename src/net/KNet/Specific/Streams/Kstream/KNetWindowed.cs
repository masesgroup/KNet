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
    /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.Kstream.Windowed{K}"/>
    /// </summary>
    /// <typeparam name="TKey">The key type</typeparam>
    public class KNetWindowed<TKey> : IGenericSerDesFactoryApplier
    {
        readonly Org.Apache.Kafka.Streams.Kstream.Windowed<byte[]> _inner;
        readonly IKNetSerDes<TKey> _keySerDes;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        internal KNetWindowed(IGenericSerDesFactory factory, Org.Apache.Kafka.Streams.Kstream.Windowed<byte[]> windowed)
        {
            _factory = factory;
            _keySerDes = _factory.BuildKeySerDes<TKey>();
            _inner = windowed;
        }

        /// <summary>
        /// Converter from <see cref="KNetWindowed{K}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.Windowed{K}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.Windowed<byte[]>(KNetWindowed<TKey> t) => t._inner;

        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Windowed.html#key--"/>
        /// </summary>
        /// <returns><typeparamref name="TKey"/></returns>
        public TKey Key => _keySerDes.Deserialize(null, _inner.Key());
        /// <summary>
        /// KNet implementation of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/Windowed.html#window--"/>
        /// </summary>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.Window"/></returns>
        public Org.Apache.Kafka.Streams.Kstream.Window Window => _inner.Window();
    }
}
