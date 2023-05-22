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

using Java.Util;
using MASES.KNet.Common.Header;
using MASES.KNet.Serialization;
using Java.Util.Concurrent;
using MASES.JCOBridge.C2JBridge;
using System.Threading.Tasks;
using System;

namespace MASES.KNet.Clients.Producer
{
    public class KNetProducerRecord<K, V>
    {
        public KNetProducerRecord()
        {
        }

        public KNetProducerRecord(string topic, int partition, long timestamp, K key, V value, Headers headers)
        {
            Topic = topic;
            Partition = partition;
            Timestamp = timestamp;
            Key = key;
            Value = value;
            Headers = headers;
        }

        public KNetProducerRecord(string topic, int partition, System.DateTime timestamp, K key, V value, Headers headers)
        {
            Topic = topic;
            Partition = partition;
            Timestamp = new System.DateTimeOffset(timestamp).ToUnixTimeMilliseconds();
            Key = key;
            Value = value;
            Headers = headers;
        }

        public KNetProducerRecord(string topic, int partition, long timestamp, K key, V value)
        {
            Topic = topic;
            Partition = partition;
            Timestamp = timestamp;
            Key = key;
            Value = value;
        }

        public KNetProducerRecord(string topic, int partition, System.DateTime timestamp, K key, V value)
        {
            Topic = topic;
            Partition = partition;
            Timestamp = new System.DateTimeOffset(timestamp).ToUnixTimeMilliseconds();
            Key = key;
            Value = value;
        }

        public KNetProducerRecord(string topic, int partition, K key, V value, Headers headers)
        {
            Topic = topic;
            Partition = partition;
            Key = key;
            Value = value;
        }

        public KNetProducerRecord(string topic, int partition, K key, V value)
        {
            Topic = topic;
            Partition = partition;
            Key = key;
            Value = value;
        }

        public KNetProducerRecord(string topic, K key, V value)
        {
            Topic = topic;
            Key = key;
            Value = value;
        }

        public KNetProducerRecord(string topic, V value)
        {
            Topic = topic;
            Value = value;
        }

        public string Topic { get; private set; }

        public int Partition { get; private set; }

        public K Key { get; private set; }

        public V Value { get; private set; }

        public long Timestamp { get; private set; }

        public System.DateTime DateTime => System.DateTimeOffset.FromUnixTimeMilliseconds(Timestamp).DateTime;

        public Headers Headers { get; private set; }
    }

    /// <summary>
    /// Extends <see cref="IProducer{K, V}"/> adding less intrusive methods which performs better in high throughput applications
    /// </summary>
    /// <typeparam name="K">Same meaning of <see cref="IProducer{K, V}"/></typeparam>
    /// <typeparam name="V">Same meaning of <see cref="IProducer{K, V}"/></typeparam>
    public interface IKNetProducer<K, V> : IProducer<byte[], byte[]>
    {
        void SetCallback(Callback callback);

        public Future<RecordMetadata> Send(KNetProducerRecord<K, V> record);

        public Future<RecordMetadata> Send(KNetProducerRecord<K, V> record, Callback callback);

        void Send(string topic, int partition, long timestamp, K key, V value, Headers headers);

        void Send(string topic, int partition, long timestamp, K key, V value);

        void Send(string topic, int partition, K key, V value, Headers headers);

        void Send(string topic, int partition, K key, V value);

        void Send(string topic, K key, V value);

        void Send(string topic, V value);

        void Produce(string topic, K key, V value, Action<RecordMetadata, JVMBridgeException> action = null);

        void Produce(string topic, int partition, K key, V value, Action<RecordMetadata, JVMBridgeException> action = null);

        void Produce(string topic, int partition, long timestamp, K key, V value, Action<RecordMetadata, JVMBridgeException> action = null);

        void Produce(string topic, int partition, DateTime timestamp, K key, V value, Action<RecordMetadata, JVMBridgeException> action = null);

        void Produce(KNetProducerRecord<K, V> record, Action<RecordMetadata, JVMBridgeException> action = null);

        void Produce(string topic, K key, V value, Callback cb = null);

        void Produce(string topic, int partition, K key, V value, Callback cb = null);

        void Produce(string topic, int partition, long timestamp, K key, V value, Callback cb = null);

        void Produce(string topic, int partition, DateTime timestamp, K key, V value, Callback cb = null);

        void Produce(KNetProducerRecord<K, V> record, Callback cb = null);

        Task ProduceAsync(string topic, K key, V value, Action<RecordMetadata, JVMBridgeException> action = null);

        Task ProduceAsync(string topic, int partition, K key, V value, Action<RecordMetadata, JVMBridgeException> action = null);

        Task ProduceAsync(string topic, int partition, long timestamp, K key, V value, Action<RecordMetadata, JVMBridgeException> action = null);

        Task ProduceAsync(string topic, int partition, DateTime timestamp, K key, V value, Action<RecordMetadata, JVMBridgeException> action = null);

        Task ProduceAsync(KNetProducerRecord<K, V> record, Action<RecordMetadata, JVMBridgeException> action = null);
    }

    /// <summary>
    /// Extends <see cref="KafkaProducer"/> adding less intrusive methods which performs better in high throughput applications
    /// </summary>
    /// <typeparam name="K">Same meaning of <see cref="KafkaProducer"/></typeparam>
    /// <typeparam name="V">Same meaning of <see cref="KafkaProducer"/></typeparam>
    public class KNetProducer<K, V> : KafkaProducer<byte[], byte[]>, IKNetProducer<K, V>
    {
        public override string BridgeClassName => "org.mases.knet.clients.producer.KNetProducer";

        readonly IKNetSerializer<K> _keySerializer;
        readonly IKNetSerializer<V> _valueSerializer;

        public KNetProducer(Properties props, IKNetSerializer<K> keySerializer, IKNetSerializer<V> valueSerializer)
            : base(props, keySerializer.KafkaSerializer, valueSerializer.KafkaSerializer)
        {
            _keySerializer = keySerializer;
            _valueSerializer = valueSerializer;
        }

        static ProducerRecord<byte[], byte[]> ToProducerRecord(KNetProducerRecord<K, V> record, IKNetSerializer<K> keySerializer, IKNetSerializer<V> valueSerializer)
        {
            return new ProducerRecord<byte[], byte[]>(record.Topic, record.Partition, record.Timestamp,
                                                      record.Key == null ? null : keySerializer?.SerializeWithHeaders(record.Topic, record.Headers, record.Key),
                                                      record.Value == null ? null : valueSerializer?.SerializeWithHeaders(record.Topic, record.Headers, record.Value),
                                                      record.Headers);
        }

        public void SetCallback(Callback callback) => IExecute("setCallback", callback);

        public Future<RecordMetadata> Send(KNetProducerRecord<K, V> record)
        {
            ProducerRecord<byte[], byte[]> kRecord = ToProducerRecord(record, _keySerializer, _valueSerializer);
            return Send(kRecord);
        }

        public Future<RecordMetadata> Send(KNetProducerRecord<K, V> record, Callback callback)
        {
            ProducerRecord<byte[], byte[]> kRecord = ToProducerRecord(record, _keySerializer, _valueSerializer);
            return Send(kRecord, callback);
        }

        public void Send(string topic, int partition, long timestamp, K key, V value, Headers headers)
        {
            IExecute("send", topic, partition, timestamp, _keySerializer.SerializeWithHeaders(topic, headers, key), _valueSerializer.SerializeWithHeaders(topic, headers, value), headers);
        }

        public void Send(string topic, int partition, long timestamp, K key, V value)
        {
            IExecute("send", topic, partition, timestamp, _keySerializer.Serialize(topic, key), _valueSerializer.Serialize(topic, value));
        }

        public void Send(string topic, int partition, K key, V value, Headers headers)
        {
            IExecute("send", topic, partition, _keySerializer.SerializeWithHeaders(topic, headers, key), _valueSerializer.SerializeWithHeaders(topic, headers, value), headers);
        }

        public void Send(string topic, int partition, K key, V value)
        {
            IExecute("send", topic, partition, _keySerializer.Serialize(topic, key), _valueSerializer.Serialize(topic, value));
        }

        public void Send(string topic, K key, V value)
        {
            IExecute("send", topic, _keySerializer.Serialize(topic, key), _valueSerializer.Serialize(topic, value));
        }

        public void Send(string topic, V value)
        {
            IExecute("send", topic, _valueSerializer.Serialize(topic, value));
        }

        public void Produce(string topic, K key, V value, Action<RecordMetadata, JVMBridgeException> action = null)
        {
            Produce(new KNetProducerRecord<K, V>(topic, key, value), action);
        }

        public void Produce(string topic, int partition, K key, V value, Action<RecordMetadata, JVMBridgeException> action = null)
        {
            Produce(new KNetProducerRecord<K, V>(topic, partition, key, value), action);
        }

        public void Produce(string topic, int partition, long timestamp, K key, V value, Action<RecordMetadata, JVMBridgeException> action = null)
        {
            Produce(new KNetProducerRecord<K, V>(topic, partition, timestamp, key, value), action);
        }

        public void Produce(string topic, int partition, DateTime timestamp, K key, V value, Action<RecordMetadata, JVMBridgeException> action = null)
        {
            Produce(new KNetProducerRecord<K, V>(topic, partition, timestamp, key, value), action);
        }

        public void Produce(KNetProducerRecord<K, V> record, Action<RecordMetadata, JVMBridgeException> action = null)
        {
            Callback cb = null;

            try
            {
                if (action != null)
                {
                    cb = new Callback(action);
                }
                Produce(record, cb);
            }
            catch (ExecutionException e)
            {
                throw e.InnerException;
            }
            finally
            {
                cb?.Dispose();
            }
        }

        public void Produce(string topic, K key, V value, Callback cb = null)
        {
            Produce(new KNetProducerRecord<K, V>(topic, key, value), cb);
        }

        public void Produce(string topic, int partition, K key, V value, Callback cb = null)
        {
            Produce(new KNetProducerRecord<K, V>(topic, partition, key, value), cb);
        }

        public void Produce(string topic, int partition, long timestamp, K key, V value, Callback cb = null)
        {
            Produce(new KNetProducerRecord<K, V>(topic, partition, timestamp, key, value), cb);
        }

        public void Produce(string topic, int partition, DateTime timestamp, K key, V value, Callback cb = null)
        {
            Produce(new KNetProducerRecord<K, V>(topic, partition, timestamp, key, value), cb);
        }

        public void Produce(KNetProducerRecord<K, V> record, Callback cb = null)
        {
            try
            {
                Future<RecordMetadata> result;
                if (cb != null)
                {
                    result = this.Send(record, cb);
                }
                else
                {
                    result = this.Send(record);
                }
                result.Get();
            }
            catch (ExecutionException e)
            {
                throw e.InnerException;
            }
            finally
            {
                cb?.Dispose();
            }
        }

        public async Task ProduceAsync(string topic, K key, V value, Action<RecordMetadata, JVMBridgeException> action = null)
        {
            await ProduceAsync(new KNetProducerRecord<K, V>(topic, key, value), action);
        }

        public async Task ProduceAsync(string topic, int partition, K key, V value, Action<RecordMetadata, JVMBridgeException> action = null)
        {
            await ProduceAsync(new KNetProducerRecord<K, V>(topic, partition, key, value), action);
        }

        public async Task ProduceAsync(string topic, int partition, long timestamp, K key, V value, Action<RecordMetadata, JVMBridgeException> action = null)
        {
            await ProduceAsync(new KNetProducerRecord<K, V>(topic, partition, timestamp, key, value), action);
        }

        public async Task ProduceAsync(string topic, int partition, DateTime timestamp, K key, V value, Action<RecordMetadata, JVMBridgeException> action = null)
        {
            await ProduceAsync(new KNetProducerRecord<K, V>(topic, partition, timestamp, key, value), action);
        }

        public async Task ProduceAsync(KNetProducerRecord<K, V> record, Action<RecordMetadata, JVMBridgeException> action = null)
        {
            Task<Task> task = Task.Factory.StartNew(() =>
            {
                Produce(record, action);
                return Task.CompletedTask;
            });

            await task;
            if (task.Result.Status == TaskStatus.Faulted && task.Result.Exception != null)
            {
                throw task.Result.Exception.Flatten().InnerException;
            }
        }
    }
}
