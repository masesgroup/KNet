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

using Org.Apache.Kafka.Clients.Consumer;
using MASES.KNet.Serialization;
using System.Collections.Generic;
using System.Threading;

namespace MASES.KNet.Consumer
{
    /// <summary>
    /// KNet extension of <see cref="ConsumerRecords{K, V}"/>
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    public class KNetConsumerRecords<K, V> : IEnumerable<KNetConsumerRecord<K, V>>, IAsyncEnumerable<KNetConsumerRecord<K, V>>
    {
        readonly IKNetDeserializer<K> _keyDeserializer;
        readonly IKNetDeserializer<V> _valueDeserializer;
        readonly ConsumerRecords<byte[], byte[]> _records;
        /// <summary>
        /// Initialize a new <see cref="KNetConsumerRecord{K, V}"/>
        /// </summary>
        /// <param name="records">The <see cref="ConsumerRecords{K, V}"/> to use for initialization</param>
        /// <param name="keyDeserializer">Key serializer base on <see cref="KNetSerDes{K}"/></param>
        /// <param name="valueDeserializer">Value serializer base on <see cref="KNetSerDes{K}"/></param>
        public KNetConsumerRecords(ConsumerRecords<byte[], byte[]> records, IKNetDeserializer<K> keyDeserializer, IKNetDeserializer<V> valueDeserializer)
        {
            _records = records;
            _keyDeserializer = keyDeserializer;
            _valueDeserializer = valueDeserializer;
        }

        IEnumerator<KNetConsumerRecord<K, V>> IEnumerable<KNetConsumerRecord<K, V>>.GetEnumerator()
        {
            return new KNetConsumerRecordsEnumerator<K, V>(_records, _keyDeserializer, _valueDeserializer);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new KNetConsumerRecordsEnumerator<K, V>(_records, _keyDeserializer, _valueDeserializer);
        }

        IAsyncEnumerator<KNetConsumerRecord<K, V>> IAsyncEnumerable<KNetConsumerRecord<K, V>>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return new KNetConsumerRecordsEnumerator<K, V>(_records, _keyDeserializer, _valueDeserializer, cancellationToken);
        }
    }
}
