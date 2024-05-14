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

using Java.Util;
using Org.Apache.Kafka.Common.Header;
using Org.Apache.Kafka.Clients.Producer;
using MASES.KNet.Serialization;
using Java.Util.Concurrent;
using MASES.JCOBridge.C2JBridge;
using System.Threading.Tasks;
using System;

namespace MASES.KNet.Producer
{
    /// <summary>
    /// Extends <see cref="Org.Apache.Kafka.Clients.Producer.IProducer{K, V}"/> adding less intrusive methods which performs better in high throughput applications
    /// </summary>
    /// <typeparam name="K">Same meaning of <see cref="Org.Apache.Kafka.Clients.Producer.IProducer{K, V}"/></typeparam>
    /// <typeparam name="V">Same meaning of <see cref="Org.Apache.Kafka.Clients.Producer.IProducer{K, V}"/></typeparam>
    public interface IProducer<K, V> : Org.Apache.Kafka.Clients.Producer.IProducer<byte[], byte[]>
    {
        /// <summary>
        /// Set <see cref="Callback"/> into instance of <see cref="IProducer{K, V}"/>
        /// </summary>
        /// <param name="callback">The <see cref="Callback"/></param>
        void SetCallback(Callback callback);
        /// <summary>
        /// KNet version of <see cref="Producer{K, V}.Send(Org.Apache.Kafka.Clients.Producer.ProducerRecord{K, V})"/>
        /// </summary>
        public Future<RecordMetadata> Send(ProducerRecord<K, V> record);
        /// <summary>
        /// KNet version of <see cref="Producer{K, V}.Send(Org.Apache.Kafka.Clients.Producer.ProducerRecord{K, V}, Callback)"/>
        /// </summary>
        public Future<RecordMetadata> Send(ProducerRecord<K, V> record, Callback callback);
        /// <summary>
        /// KNet version of <see cref="Producer{K, V}.Send(Org.Apache.Kafka.Clients.Producer.ProducerRecord{K, V})"/>
        /// </summary>
        void Send(string topic, int partition, long timestamp, K key, V value, Headers headers);
        /// <summary>
        /// KNet version of <see cref="Producer{K, V}.Send(Org.Apache.Kafka.Clients.Producer.ProducerRecord{K, V})"/>
        /// </summary>
        void Send(string topic, int partition, long timestamp, K key, V value);
        /// <summary>
        /// KNet version of <see cref="Producer{K, V}.Send(Org.Apache.Kafka.Clients.Producer.ProducerRecord{K, V})"/>
        /// </summary>
        void Send(string topic, int partition, K key, V value, Headers headers);
        /// <summary>
        /// KNet version of <see cref="Producer{K, V}.Send(Org.Apache.Kafka.Clients.Producer.ProducerRecord{K, V})"/>
        /// </summary>
        void Send(string topic, int partition, K key, V value);
        /// <summary>
        /// KNet version of <see cref="Producer{K, V}.Send(Org.Apache.Kafka.Clients.Producer.ProducerRecord{K, V})"/>
        /// </summary>
        void Send(string topic, K key, V value);
        /// <summary>
        /// KNet version of <see cref="Producer{K, V}.Send(Org.Apache.Kafka.Clients.Producer.ProducerRecord{K, V})"/>
        /// </summary>
        void Send(string topic, V value);
        /// <summary>
        /// KNet version of <see cref="Producer{K, V}.Send(Org.Apache.Kafka.Clients.Producer.ProducerRecord{K, V}, Callback)"/>
        /// </summary>
        void Produce(string topic, K key, V value, Action<RecordMetadata, JVMBridgeException> action = null);
        /// <summary>
        /// KNet version of <see cref="Producer{K, V}.Send(Org.Apache.Kafka.Clients.Producer.ProducerRecord{K, V}, Callback)"/>
        /// </summary>
        void Produce(string topic, int partition, K key, V value, Action<RecordMetadata, JVMBridgeException> action = null);
        /// <summary>
        /// KNet version of <see cref="Producer{K, V}.Send(Org.Apache.Kafka.Clients.Producer.ProducerRecord{K, V}, Callback)"/>
        /// </summary>
        void Produce(string topic, int partition, long timestamp, K key, V value, Action<RecordMetadata, JVMBridgeException> action = null);
        /// <summary>
        /// KNet version of <see cref="Producer{K, V}.Send(Org.Apache.Kafka.Clients.Producer.ProducerRecord{K, V}, Callback)"/>
        /// </summary>
        void Produce(string topic, int partition, DateTime timestamp, K key, V value, Action<RecordMetadata, JVMBridgeException> action = null);
        /// <summary>
        /// KNet version of <see cref="Producer{K, V}.Send(Org.Apache.Kafka.Clients.Producer.ProducerRecord{K, V}, Callback)"/>
        /// </summary>
        void Produce(ProducerRecord<K, V> record, Action<RecordMetadata, JVMBridgeException> action = null);
        /// <summary>
        /// KNet version of <see cref="Producer{K, V}.Send(Org.Apache.Kafka.Clients.Producer.ProducerRecord{K, V}, Callback)"/>
        /// </summary>
        Future<RecordMetadata> Produce(string topic, K key, V value, Callback cb = null);
        /// <summary>
        /// KNet version of <see cref="Producer{K, V}.Send(Org.Apache.Kafka.Clients.Producer.ProducerRecord{K, V}, Callback)"/>
        /// </summary>
        void ProduceAndWait(string topic, K key, V value, Callback cb = null);
        /// <summary>
        /// KNet version of <see cref="Producer{K, V}.Send(Org.Apache.Kafka.Clients.Producer.ProducerRecord{K, V}, Callback)"/>
        /// </summary>
        Future<RecordMetadata> Produce(string topic, int partition, K key, V value, Callback cb = null);
        /// <summary>
        /// KNet version of <see cref="Producer{K, V}.Send(Org.Apache.Kafka.Clients.Producer.ProducerRecord{K, V}, Callback)"/>
        /// </summary>
        void ProduceAndWait(string topic, int partition, K key, V value, Callback cb = null);
        /// <summary>
        /// KNet version of <see cref="Producer{K, V}.Send(Org.Apache.Kafka.Clients.Producer.ProducerRecord{K, V}, Callback)"/>
        /// </summary>
        Future<RecordMetadata> Produce(string topic, int partition, long timestamp, K key, V value, Callback cb = null);
        /// <summary>
        /// KNet version of <see cref="Producer{K, V}.Send(Org.Apache.Kafka.Clients.Producer.ProducerRecord{K, V}, Callback)"/>
        /// </summary>
        void ProduceAndWait(string topic, int partition, long timestamp, K key, V value, Callback cb = null);
        /// <summary>
        /// KNet version of <see cref="Producer{K, V}.Send(Org.Apache.Kafka.Clients.Producer.ProducerRecord{K, V}, Callback)"/>
        /// </summary>
        Future<RecordMetadata> Produce(string topic, int partition, DateTime timestamp, K key, V value, Callback cb = null);
        /// <summary>
        /// KNet version of <see cref="Producer{K, V}.Send(Org.Apache.Kafka.Clients.Producer.ProducerRecord{K, V}, Callback)"/>
        /// </summary>
        void ProduceAndWait(string topic, int partition, DateTime timestamp, K key, V value, Callback cb = null);
        /// <summary>
        /// KNet version of <see cref="Producer{K, V}.Send(Org.Apache.Kafka.Clients.Producer.ProducerRecord{K, V}, Callback)"/>
        /// </summary>
        Future<RecordMetadata> Produce(ProducerRecord<K, V> record, Callback cb = null);
        /// <summary>
        /// KNet version of <see cref="Producer{K, V}.Send(Org.Apache.Kafka.Clients.Producer.ProducerRecord{K, V}, Callback)"/>
        /// </summary>
        void ProduceAndWait(ProducerRecord<K, V> record, Callback cb = null);
        /// <summary>
        /// KNet async version of <see cref="Producer{K, V}.Send(Org.Apache.Kafka.Clients.Producer.ProducerRecord{K, V}, Callback)"/>
        /// </summary>
        Task ProduceAsync(string topic, K key, V value, Action<RecordMetadata, JVMBridgeException> action = null);
        /// <summary>
        /// KNet async version of <see cref="Producer{K, V}.Send(Org.Apache.Kafka.Clients.Producer.ProducerRecord{K, V}, Callback)"/>
        /// </summary>
        Task ProduceAsync(string topic, int partition, K key, V value, Action<RecordMetadata, JVMBridgeException> action = null);
        /// <summary>
        /// KNet async version of <see cref="Producer{K, V}.Send(Org.Apache.Kafka.Clients.Producer.ProducerRecord{K, V}, Callback)"/>
        /// </summary>
        Task ProduceAsync(string topic, int partition, long timestamp, K key, V value, Action<RecordMetadata, JVMBridgeException> action = null);
        /// <summary>
        /// KNet async version of <see cref="Producer{K, V}.Send(Org.Apache.Kafka.Clients.Producer.ProducerRecord{K, V}, Callback)"/>
        /// </summary>
        Task ProduceAsync(string topic, int partition, DateTime timestamp, K key, V value, Action<RecordMetadata, JVMBridgeException> action = null);
        /// <summary>
        /// KNet async version of <see cref="Producer{K, V}.Send(Org.Apache.Kafka.Clients.Producer.ProducerRecord{K, V}, Callback)"/>
        /// </summary>
        Task ProduceAsync(ProducerRecord<K, V> record, Action<RecordMetadata, JVMBridgeException> action = null);
    }

    /// <summary>
    /// Extends <see cref="KafkaProducer"/> adding less intrusive methods which performs better in high throughput applications
    /// </summary>
    /// <typeparam name="K">Same meaning of <see cref="KafkaProducer"/></typeparam>
    /// <typeparam name="V">Same meaning of <see cref="KafkaProducer"/></typeparam>
    public class KNetProducer<K, V> : KafkaProducer<byte[], byte[]>, IProducer<K, V>
    {
        /// <summary>
        /// <see href="https://www.jcobridge.com/api-clr/html/P_MASES_JCOBridge_C2JBridge_JVMBridgeBase_BridgeClassName.htm"/>
        /// </summary>
        public override string BridgeClassName => "org.mases.knet.clients.producer.KNetProducer";

        readonly bool _autoCreateSerDes = false;
        readonly ISerDes<K> _keySerializer;
        readonly ISerDes<V> _valueSerializer;

        internal KNetProducer(Properties props) : base(props) { }

        /// <summary>
        /// Initialize a new instance of <see cref="KNetProducer{K, V}"/>
        /// </summary>
        /// <param name="configBuilder">An instance of <see cref="ProducerConfigBuilder"/> </param>
        public KNetProducer(ProducerConfigBuilder configBuilder)
            : this(configBuilder, configBuilder.BuildKeySerDes<K>(), configBuilder.BuildValueSerDes<V>())
        {
        }
        /// <summary>
        /// Initialize a new instance of <see cref="KNetProducer{K, V}"/>
        /// </summary>
        /// <param name="props">The properties to use, see <see cref="ProducerConfigBuilder"/></param>
        /// <param name="keySerializer">Key serializer base on <see cref="SerDes{K}"/></param>
        /// <param name="valueSerializer">Value serializer base on <see cref="SerDes{K}"/></param>
        public KNetProducer(ProducerConfigBuilder props, ISerDes<K> keySerializer, ISerDes<V> valueSerializer)
            : base(CheckProperties(props), keySerializer.KafkaSerializer, valueSerializer.KafkaSerializer)
        {
            _keySerializer = keySerializer;
            _valueSerializer = valueSerializer;
        }

        static Properties CheckProperties(Properties props)
        {
            if (!props.ContainsKey(ProducerConfig.KEY_SERIALIZER_CLASS_CONFIG))
            {
                props.Put(ProducerConfig.KEY_SERIALIZER_CLASS_CONFIG, "org.apache.kafka.common.serialization.ByteArraySerializer");
            }
            else throw new InvalidOperationException($"KNetProducer auto manages configuration property {ProducerConfig.KEY_SERIALIZER_CLASS_CONFIG}, remove from configuration.");

            if (!props.ContainsKey(ProducerConfig.VALUE_SERIALIZER_CLASS_CONFIG))
            {
                props.Put(ProducerConfig.VALUE_SERIALIZER_CLASS_CONFIG, "org.apache.kafka.common.serialization.ByteArraySerializer");
            }
            else throw new InvalidOperationException($"KNetProducer auto manages configuration property {ProducerConfig.VALUE_SERIALIZER_CLASS_CONFIG}, remove from configuration.");

            return props;
        }
        /// <summary>
        /// Finalizer
        /// </summary>
        ~KNetProducer()
        {
            if (_autoCreateSerDes)
            {
                _keySerializer?.Dispose();
                _valueSerializer?.Dispose();
            }
        }

        static Org.Apache.Kafka.Clients.Producer.ProducerRecord<byte[], byte[]> ToProducerRecord(ProducerRecord<K, V> record, ISerializer<K> keySerializer, ISerializer<V> valueSerializer)
        {
            var headers = record.Headers;
            if ((keySerializer.UseHeaders || valueSerializer.UseHeaders) && headers == null)
            {
                headers = Headers.Create();
            }

            return new Org.Apache.Kafka.Clients.Producer.ProducerRecord<byte[], byte[]>(record.Topic, record.Partition, record.Timestamp,
                                                      record.Key == null ? null : DataSerialize(keySerializer, record.Topic, record.Key, headers),
                                                      record.Value == null ? null : DataSerialize(valueSerializer, record.Topic, record.Value, headers),
                                                      headers);
        }

        static byte[] DataSerialize<T>(ISerializer<T> serializer, string topic, T data, Headers headers)
        {
            if (serializer == null) return null;
            if (serializer.UseHeaders)
            {
                return serializer.SerializeWithHeaders(topic, headers, data);
            }
            return serializer.Serialize(topic, data);
        }
        /// <inheritdoc cref="IProducer{K, V}.SetCallback(Callback)"/>
        public void SetCallback(Callback callback) => IExecute("setCallback", callback);
        /// <inheritdoc cref="IProducer{K, V}.Send(ProducerRecord{K, V})"/>
        public Future<RecordMetadata> Send(ProducerRecord<K, V> record)
        {
            Org.Apache.Kafka.Clients.Producer.ProducerRecord<byte[], byte[]> kRecord = KNetProducer<K, V>.ToProducerRecord((Producer.ProducerRecord<K,V>)record, (ISerializer<K>)_keySerializer, (ISerializer<V>)_valueSerializer);
            try
            {
                GC.SuppressFinalize(kRecord);
                return Send(kRecord);
            }
            finally { GC.ReRegisterForFinalize(kRecord); }
        }
        /// <inheritdoc cref="IProducer{K, V}.Send(ProducerRecord{K, V}, Callback)"/>
        public Future<RecordMetadata> Send(ProducerRecord<K, V> record, Callback callback)
        {
            Org.Apache.Kafka.Clients.Producer.ProducerRecord<byte[], byte[]> kRecord = KNetProducer<K, V>.ToProducerRecord((Producer.ProducerRecord<K,V>)record, (ISerializer<K>)_keySerializer, (ISerializer<V>)_valueSerializer);
            try
            {
                GC.SuppressFinalize(kRecord);
                return Send(kRecord, callback);
            }
            finally { GC.ReRegisterForFinalize(kRecord); }
        }
        /// <inheritdoc cref="IProducer{K, V}.Send(string, int, long, K, V, Headers)"/>
        public void Send(string topic, int partition, long timestamp, K key, V value, Headers headers)
        {
            IExecute("send", topic, partition, timestamp, _keySerializer.SerializeWithHeaders(topic, headers, key), _valueSerializer.SerializeWithHeaders(topic, headers, value), headers);
        }
        /// <inheritdoc cref="IProducer{K, V}.Send(string, int, long, K, V)"/>
        public void Send(string topic, int partition, long timestamp, K key, V value)
        {
            IExecute("send", topic, partition, timestamp, _keySerializer.Serialize(topic, key), _valueSerializer.Serialize(topic, value));
        }
        /// <inheritdoc cref="IProducer{K, V}.Send(string, int, K, V, Headers)"/>
        public void Send(string topic, int partition, K key, V value, Headers headers)
        {
            IExecute("send", topic, partition, _keySerializer.SerializeWithHeaders(topic, headers, key), _valueSerializer.SerializeWithHeaders(topic, headers, value), headers);
        }
        /// <inheritdoc cref="IProducer{K, V}.Send(string, int, K, V, Headers)"/>
        public void Send(string topic, int partition, K key, V value)
        {
            IExecute("send", topic, partition, _keySerializer.Serialize(topic, key), _valueSerializer.Serialize(topic, value));
        }
        /// <inheritdoc cref="IProducer{K, V}.Send(string, K, V)"/>
        public void Send(string topic, K key, V value)
        {
            IExecute("send", topic, _keySerializer.Serialize(topic, key), _valueSerializer.Serialize(topic, value));
        }
        /// <inheritdoc cref="IProducer{K, V}.Send(string, V)"/>
        public void Send(string topic, V value)
        {
            IExecute("send", topic, _valueSerializer.Serialize(topic, value));
        }
        /// <inheritdoc cref="IProducer{K, V}.Produce(string, K, V, Action{RecordMetadata, JVMBridgeException})"/>
        public void Produce(string topic, K key, V value, Action<RecordMetadata, JVMBridgeException> action = null)
        {
            Produce(new ProducerRecord<K, V>(topic, key, value), action);
        }
        /// <inheritdoc cref="IProducer{K, V}.Produce(string, int, K, V, Action{RecordMetadata, JVMBridgeException})"/>
        public void Produce(string topic, int partition, K key, V value, Action<RecordMetadata, JVMBridgeException> action = null)
        {
            Produce(new ProducerRecord<K, V>(topic, partition, key, value), action);
        }
        /// <inheritdoc cref="IProducer{K, V}.Produce(string, int, long, K, V, Action{RecordMetadata, JVMBridgeException})"/>
        public void Produce(string topic, int partition, long timestamp, K key, V value, Action<RecordMetadata, JVMBridgeException> action = null)
        {
            Produce(new ProducerRecord<K, V>(topic, partition, timestamp, key, value), action);
        }
        /// <inheritdoc cref="IProducer{K, V}.Produce(string, int, long, K, V, Action{RecordMetadata, JVMBridgeException})"/>
        public void Produce(string topic, int partition, DateTime timestamp, K key, V value, Action<RecordMetadata, JVMBridgeException> action = null)
        {
            Produce(new ProducerRecord<K, V>(topic, partition, timestamp, key, value), action);
        }
        /// <inheritdoc cref="IProducer{K, V}.Produce(ProducerRecord{K, V}, Action{RecordMetadata, JVMBridgeException})"/>
        public void Produce(ProducerRecord<K, V> record, Action<RecordMetadata, JVMBridgeException> action = null)
        {
            Callback cb = null;

            try
            {
                if (action != null)
                {
                    cb = new Callback() { OnOnCompletion = action };
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
        /// <inheritdoc cref="IProducer{K, V}.Produce(string, K, V, Callback)"/>
        public Future<RecordMetadata> Produce(string topic, K key, V value, Callback cb = null)
        {
            return Produce(new ProducerRecord<K, V>(topic, key, value), cb);
        }
        /// <inheritdoc cref="IProducer{K, V}.ProduceAndWait(string, K, V, Callback)"/>
        public void ProduceAndWait(string topic, K key, V value, Callback cb = null)
        {
            ProduceAndWait(new ProducerRecord<K, V>(topic, key, value), cb);
        }
        /// <inheritdoc cref="IProducer{K, V}.Produce(string, int, K, V, Callback)"/>
        public Future<RecordMetadata> Produce(string topic, int partition, K key, V value, Callback cb = null)
        {
            return Produce(new ProducerRecord<K, V>(topic, partition, key, value), cb);
        }
        /// <inheritdoc cref="IProducer{K, V}.ProduceAndWait(string, int, K, V, Callback)"/>
        public void ProduceAndWait(string topic, int partition, K key, V value, Callback cb = null)
        {
            ProduceAndWait(new ProducerRecord<K, V>(topic, partition, key, value), cb);
        }
        /// <inheritdoc cref="IProducer{K, V}.Produce(string, int, long, K, V, Callback)"/>
        public Future<RecordMetadata> Produce(string topic, int partition, long timestamp, K key, V value, Callback cb = null)
        {
            return Produce(new ProducerRecord<K, V>(topic, partition, timestamp, key, value), cb);
        }
        /// <inheritdoc cref="IProducer{K, V}.ProduceAndWait(string, int, long, K, V, Callback)"/>
        public void ProduceAndWait(string topic, int partition, long timestamp, K key, V value, Callback cb = null)
        {
            ProduceAndWait(new ProducerRecord<K, V>(topic, partition, timestamp, key, value), cb);
        }
        /// <inheritdoc cref="IProducer{K, V}.Produce(string, int, DateTime, K, V, Callback)"/>
        public Future<RecordMetadata> Produce(string topic, int partition, DateTime timestamp, K key, V value, Callback cb = null)
        {
            return Produce(new ProducerRecord<K, V>(topic, partition, timestamp, key, value), cb);
        }
        /// <inheritdoc cref="IProducer{K, V}.ProduceAndWait(string, int, DateTime, K, V, Callback)"/>
        public void ProduceAndWait(string topic, int partition, DateTime timestamp, K key, V value, Callback cb = null)
        {
            ProduceAndWait(new ProducerRecord<K, V>(topic, partition, timestamp, key, value), cb);
        }
        /// <inheritdoc cref="IProducer{K, V}.Produce(ProducerRecord{K, V}, Callback)"/>
        public Future<RecordMetadata> Produce(ProducerRecord<K, V> record, Callback cb = null)
        {
            if (cb != null)
            {
                return this.Send(record, cb);
            }
            else
            {
                return this.Send(record);
            }
        }
        /// <inheritdoc cref="IProducer{K, V}.ProduceAndWait(ProducerRecord{K, V}, Callback)"/>
        public void ProduceAndWait(ProducerRecord<K, V> record, Callback cb = null)
        {
            try
            {
                Future<RecordMetadata> result = this.Produce(record, cb);
                result.Get();
            }
            catch (ExecutionException e)
            {
                throw e.InnerException;
            }
        }
        /// <inheritdoc cref="IProducer{K, V}.Produce(string, K, V, Action{RecordMetadata, JVMBridgeException})"/>
        public async Task ProduceAsync(string topic, K key, V value, Action<RecordMetadata, JVMBridgeException> action = null)
        {
            await ProduceAsync(new ProducerRecord<K, V>(topic, key, value), action);
        }
        /// <inheritdoc cref="IProducer{K, V}.Produce(string, int, K, V, Action{RecordMetadata, JVMBridgeException})"/>
        public async Task ProduceAsync(string topic, int partition, K key, V value, Action<RecordMetadata, JVMBridgeException> action = null)
        {
            await ProduceAsync(new ProducerRecord<K, V>(topic, partition, key, value), action);
        }
        /// <inheritdoc cref="IProducer{K, V}.Produce(string, int, long, K, V, Action{RecordMetadata, JVMBridgeException})"/>
        public async Task ProduceAsync(string topic, int partition, long timestamp, K key, V value, Action<RecordMetadata, JVMBridgeException> action = null)
        {
            await ProduceAsync(new ProducerRecord<K, V>(topic, partition, timestamp, key, value), action);
        }
        /// <inheritdoc cref="IProducer{K, V}.Produce(string, int, DateTime, K, V, Action{RecordMetadata, JVMBridgeException})"/>
        public async Task ProduceAsync(string topic, int partition, DateTime timestamp, K key, V value, Action<RecordMetadata, JVMBridgeException> action = null)
        {
            await ProduceAsync(new ProducerRecord<K, V>(topic, partition, timestamp, key, value), action);
        }
        /// <inheritdoc cref="IProducer{K, V}.Produce(ProducerRecord{K, V}, Action{RecordMetadata, JVMBridgeException})"/>
        public async Task ProduceAsync(ProducerRecord<K, V> record, Action<RecordMetadata, JVMBridgeException> action = null)
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
