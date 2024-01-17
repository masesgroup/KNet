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
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.GlobalKTable{K, V}"/>
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    public class KNetGlobalKTable<K, V> : IGenericSerDesFactoryApplier
    {
        Org.Apache.Kafka.Streams.Kstream.GlobalKTable<byte[], byte[]> _inner;

        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        internal KNetGlobalKTable(IGenericSerDesFactory factory, Org.Apache.Kafka.Streams.Kstream.GlobalKTable<byte[], byte[]> table)
        {
            _factory = factory;
            _inner = table;
        }

        /// <summary>
        /// Converter from <see cref="KNetGlobalKTable{K, V}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.GlobalKTable{K, V}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.GlobalKTable<byte[], byte[]>(KNetGlobalKTable<K, V> t) => t._inner;

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/GlobalKTable.html#queryableStoreName--"/>
        /// </summary>
        /// <returns><see cref="string"/></returns>
        public string QueryableStoreName => _inner.QueryableStoreName();
    }
}
