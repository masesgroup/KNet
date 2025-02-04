/*
*  Copyright 2025 MASES s.r.l.
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
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MASES.KNet.Consumer
{
    class ConsumerRecordsEnumerator<K, V, TJVMK, TJVMV> : IEnumerator<ConsumerRecord<K, V, TJVMK, TJVMV>>, IAsyncEnumerator<ConsumerRecord<K, V, TJVMK, TJVMV>>
    {
        readonly IDeserializer<K, TJVMK> _keyDeserializer;
        readonly IDeserializer<V, TJVMV> _valueDeserializer;
        readonly CancellationToken _cancellationToken;
        readonly Org.Apache.Kafka.Clients.Consumer.ConsumerRecords<TJVMK, TJVMV> _records;
        IEnumerator<Org.Apache.Kafka.Clients.Consumer.ConsumerRecord<TJVMK, TJVMV>> _recordEnumerator;
        IAsyncEnumerator<Org.Apache.Kafka.Clients.Consumer.ConsumerRecord<TJVMK, TJVMV>> _recordAsyncEnumerator;

        public ConsumerRecordsEnumerator(Org.Apache.Kafka.Clients.Consumer.ConsumerRecords<TJVMK, TJVMV> records, IDeserializer<K, TJVMK> keyDeserializer, IDeserializer<V, TJVMV> valueDeserializer)
        {
            _records = records;
            _recordEnumerator = _records.GetEnumerator();
            _keyDeserializer = keyDeserializer;
            _valueDeserializer = valueDeserializer;
        }

        public ConsumerRecordsEnumerator(Org.Apache.Kafka.Clients.Consumer.ConsumerRecords<TJVMK, TJVMV> records, IDeserializer<K, TJVMK> keyDeserializer, IDeserializer<V, TJVMV> valueDeserializer, CancellationToken cancellationToken)
        {
            _records = records;
            _recordAsyncEnumerator = _records.GetAsyncEnumerator(cancellationToken);
            _keyDeserializer = keyDeserializer;
            _valueDeserializer = valueDeserializer;
            _cancellationToken = cancellationToken;
        }

        ConsumerRecord<K, V, TJVMK, TJVMV> IAsyncEnumerator<ConsumerRecord<K, V, TJVMK, TJVMV>>.Current => new ConsumerRecord<K, V, TJVMK, TJVMV>(_recordAsyncEnumerator.Current, _keyDeserializer, _valueDeserializer, false);

        ConsumerRecord<K, V, TJVMK, TJVMV> IEnumerator<ConsumerRecord<K, V, TJVMK, TJVMV>>.Current => new ConsumerRecord<K, V, TJVMK, TJVMV>(_recordEnumerator.Current, _keyDeserializer, _valueDeserializer, false);

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
