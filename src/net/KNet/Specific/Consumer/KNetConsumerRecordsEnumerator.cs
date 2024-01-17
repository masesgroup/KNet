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

using Org.Apache.Kafka.Clients.Consumer;
using MASES.KNet.Serialization;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MASES.KNet.Consumer
{
    class KNetConsumerRecordsEnumerator<K, V> : IEnumerator<KNetConsumerRecord<K, V>>, IAsyncEnumerator<KNetConsumerRecord<K, V>>
    {
        readonly IKNetDeserializer<K> _keyDeserializer;
        readonly IKNetDeserializer<V> _valueDeserializer;
        readonly CancellationToken _cancellationToken;
        readonly ConsumerRecords<byte[], byte[]> _records;
        IEnumerator<ConsumerRecord<byte[], byte[]>> _recordEnumerator;
        IAsyncEnumerator<ConsumerRecord<byte[], byte[]>> _recordAsyncEnumerator;

        public KNetConsumerRecordsEnumerator(ConsumerRecords<byte[], byte[]> records, IKNetDeserializer<K> keyDeserializer, IKNetDeserializer<V> valueDeserializer)
        {
            _records = records;
            _recordEnumerator = _records.GetEnumerator();
            _keyDeserializer = keyDeserializer;
            _valueDeserializer = valueDeserializer;
        }

        public KNetConsumerRecordsEnumerator(ConsumerRecords<byte[], byte[]> records, IKNetDeserializer<K> keyDeserializer, IKNetDeserializer<V> valueDeserializer, CancellationToken cancellationToken)
        {
            _records = records;
            _recordAsyncEnumerator = _records.GetAsyncEnumerator(cancellationToken);
            _keyDeserializer = keyDeserializer;
            _valueDeserializer = valueDeserializer;
            _cancellationToken = cancellationToken;
        }

        KNetConsumerRecord<K, V> IAsyncEnumerator<KNetConsumerRecord<K, V>>.Current => new KNetConsumerRecord<K, V>(_recordAsyncEnumerator.Current, _keyDeserializer, _valueDeserializer);

        KNetConsumerRecord<K, V> IEnumerator<KNetConsumerRecord<K, V>>.Current => new KNetConsumerRecord<K, V>(_recordEnumerator.Current, _keyDeserializer, _valueDeserializer);

        object System.Collections.IEnumerator.Current => (_recordEnumerator as System.Collections.IEnumerator)?.Current;

        public void Dispose()
        {

        }

        public ValueTask DisposeAsync()
        {
            return _recordAsyncEnumerator.DisposeAsync();
        }

        public bool MoveNext()
        {
            return _recordEnumerator.MoveNext();
        }

        public ValueTask<bool> MoveNextAsync()
        {
            return _recordAsyncEnumerator.MoveNextAsync();
        }

        public void Reset()
        {
            _recordEnumerator = _records.GetEnumerator();
        }
    }
}
