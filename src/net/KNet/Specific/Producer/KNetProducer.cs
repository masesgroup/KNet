/*
*  Copyright (c) 2021-2025 MASES s.r.l.
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
using System.Collections.Concurrent;

namespace MASES.KNet.Producer
{
    #region IProducer<K, V, TJVMK, TJVMV>

    /// <summary>
    /// Extends <see cref="Org.Apache.Kafka.Clients.Producer.IProducer{TJVMK, TJVMV}"/> adding less intrusive methods which performs better in high throughput applications
    /// </summary>
    /// <typeparam name="K">Same meaning of <see cref="Org.Apache.Kafka.Clients.Producer.IProducer{TJVMK, TJVMV}"/></typeparam>
    /// <typeparam name="V">Same meaning of <see cref="Org.Apache.Kafka.Clients.Producer.IProducer{TJVMK, TJVMV}"/></typeparam>
    /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
    /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
    public interface IProducer<K, V, TJVMK, TJVMV> : Org.Apache.Kafka.Clients.Producer.IProducer<TJVMK, TJVMV>
    {
        /// <summary>
        /// Set <see cref="Callback"/> into instance of <see cref="IProducer{K, V}"/>
        /// </summary>
        /// <param name="callback">The <see cref="Callback"/></param>
        void SetCallback(Callback callback);
        /// <summary>
        /// KNet version of <see cref="Producer{K, V}.Send(Org.Apache.Kafka.Clients.Producer.ProducerRecord{K, V})"/>
        /// </summary>
        public Future<RecordMetadata> Send(ProducerRecord<K, V, TJVMK, TJVMV> record);
        /// <summary>
        /// KNet version of <see cref="Producer{K, V}.Send(Org.Apache.Kafka.Clients.Producer.ProducerRecord{K, V}, Callback)"/>
        /// </summary>
        public Future<RecordMetadata> Send(ProducerRecord<K, V, TJVMK, TJVMV> record, Callback callback);
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
        void Produce(ProducerRecord<K, V, TJVMK, TJVMV> record, Action<RecordMetadata, JVMBridgeException> action = null);
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
        Future<RecordMetadata> Produce(ProducerRecord<K, V, TJVMK, TJVMV> record, Callback cb = null);
        /// <summary>
        /// KNet version of <see cref="Producer{K, V}.Send(Org.Apache.Kafka.Clients.Producer.ProducerRecord{K, V}, Callback)"/>
        /// </summary>
        void ProduceAndWait(ProducerRecord<K, V, TJVMK, TJVMV> record, Callback cb = null);
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
        Task ProduceAsync(ProducerRecord<K, V, TJVMK, TJVMV> record, Action<RecordMetadata, JVMBridgeException> action = null);
        /// <summary>
        /// Initialize a new <see cref="ProducerRecord{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        public ProducerRecord<K, V, TJVMK, TJVMV> NewRecord();
        /// <summary>
        /// Initialize a new <see cref="ProducerRecord{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        public ProducerRecord<K, V, TJVMK, TJVMV> NewRecord(string topic, int partition, long timestamp, K key, V value, Headers headers);
        /// <summary>
        /// Initialize a new <see cref="ProducerRecord{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        public ProducerRecord<K, V, TJVMK, TJVMV> NewRecord(string topic, int partition, System.DateTime timestamp, K key, V value, Headers headers);
        /// <summary>
        /// Initialize a new <see cref="ProducerRecord{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        public ProducerRecord<K, V, TJVMK, TJVMV> NewRecord(string topic, int partition, long timestamp, K key, V value);
        /// <summary>
        /// Initialize a new <see cref="ProducerRecord{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        public ProducerRecord<K, V, TJVMK, TJVMV> NewRecord(string topic, int partition, System.DateTime timestamp, K key, V value);
        /// <summary>
        /// Initialize a new <see cref="ProducerRecord{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        public ProducerRecord<K, V, TJVMK, TJVMV> NewRecord(string topic, int partition, K key, V value, Headers headers);
        /// <summary>
        /// Initialize a new <see cref="ProducerRecord{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        public ProducerRecord<K, V, TJVMK, TJVMV> NewRecord(string topic, int partition, K key, V value);
        /// <summary>
        /// Initialize a new <see cref="ProducerRecord{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        public ProducerRecord<K, V, TJVMK, TJVMV> NewRecord(string topic, K key, V value);
        /// <summary>
        /// Initialize a new <see cref="ProducerRecord{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        public ProducerRecord<K, V, TJVMK, TJVMV> NewRecord(string topic, V value);
    }

    #endregion

    #region KNetProducer<K, V, TJVMK, TJVMV>

    /// <summary>
    /// Extends <see cref="KafkaProducer"/> adding less intrusive methods which performs better in high throughput applications
    /// </summary>
    /// <typeparam name="K">Same meaning of <see cref="KafkaProducer"/></typeparam>
    /// <typeparam name="V">Same meaning of <see cref="KafkaProducer"/></typeparam>
    /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
    /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
    public class KNetProducer<K, V, TJVMK, TJVMV> : KafkaProducer<TJVMK, TJVMV>, IProducer<K, V, TJVMK, TJVMV>
    {
        /// <summary>
        /// <see href="https://www.jcobridge.com/api-clr/html/P_MASES_JCOBridge_C2JBridge_JVMBridgeBase_BridgeClassName.htm"/>
        /// </summary>
        public override string BridgeClassName => "org.mases.knet.developed.clients.producer.KNetProducer";

        readonly bool _autoCreateSerDes = false;
        readonly ISerDes<K, TJVMK> _keySerializer;
        readonly ISerDes<V, TJVMV> _valueSerializer;

        internal KNetProducer(Properties props) : base(props) { }

        /// <summary>
        /// Initialize a new instance of <see cref="KNetProducer{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        /// <param name="configBuilder">An instance of <see cref="ProducerConfigBuilder"/> </param>
        public KNetProducer(ProducerConfigBuilder configBuilder)
            : this(configBuilder, configBuilder.BuildKeySerDes<K, TJVMK>(), configBuilder.BuildValueSerDes<V, TJVMV>())
        {
        }
        /// <summary>
        /// Initialize a new instance of <see cref="KNetProducer{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        /// <param name="props">The properties to use, see <see cref="ProducerConfigBuilder"/></param>
        /// <param name="keySerializer">Key serializer base on <see cref="SerDes{K, TJVMK}"/></param>
        /// <param name="valueSerializer">Value serializer base on <see cref="SerDes{V, TJVMV}"/></param>
        public KNetProducer(ProducerConfigBuilder props, ISerDes<K, TJVMK> keySerializer, ISerDes<V, TJVMV> valueSerializer)
            : base(CheckProperties(props, keySerializer, valueSerializer), keySerializer.KafkaSerializer, valueSerializer.KafkaSerializer)
        {
            _keySerializer = keySerializer;
            _valueSerializer = valueSerializer;
        }

        static Properties CheckProperties(Properties props, ISerDes keySerializer, ISerDes valueSerializer)
        {
            if (!props.ContainsKey(ProducerConfig.KEY_SERIALIZER_CLASS_CONFIG))
            {
                props.Put(ProducerConfig.KEY_SERIALIZER_CLASS_CONFIG, keySerializer.JVMSerializerClassName);
            }
            else throw new InvalidOperationException($"KNetProducer auto manages configuration property {ProducerConfig.KEY_SERIALIZER_CLASS_CONFIG}, remove from configuration.");

            if (!props.ContainsKey(ProducerConfig.VALUE_SERIALIZER_CLASS_CONFIG))
            {
                props.Put(ProducerConfig.VALUE_SERIALIZER_CLASS_CONFIG, valueSerializer.JVMSerializerClassName);
            }
            else throw new InvalidOperationException($"KNetProducer auto manages configuration property {ProducerConfig.VALUE_SERIALIZER_CLASS_CONFIG}, remove from configuration.");

            return props;
        }
        /// <summary>
        /// Finalizer
        /// </summary>
        ~KNetProducer()
        {
            Dispose();
        }

        object _disposedLock = new object();
        bool _disposed = false;

        /// <inheritdoc cref="IDisposable.Dispose"/>
        public override void Dispose()
        {
            lock (_disposedLock)
            {
                if (_disposed) return;
                try
                {
                    base.Dispose();
                    if (_autoCreateSerDes)
                    {
                        _keySerializer?.Dispose();
                        _valueSerializer?.Dispose();
                    }
                }
                finally { _disposed = true; }
            }
        }

        static Org.Apache.Kafka.Clients.Producer.ProducerRecord<TJVMK, TJVMV> ToProducerRecord(ProducerRecord<K, V, TJVMK, TJVMV> record, ISerializer<K, TJVMK> keySerializer, ISerializer<V, TJVMV> valueSerializer)
        {
            var headers = record.Headers;
            if ((keySerializer.UseHeaders || valueSerializer.UseHeaders) && headers == null)
            {
                headers = Headers.Create();
            }

            return new Org.Apache.Kafka.Clients.Producer.ProducerRecord<TJVMK, TJVMV>(record.Topic, record.Partition, record.Timestamp,
                                                      record.Key == null ? null : DataSerialize(keySerializer, record.Topic, record.Key, headers),
                                                      record.Value == null ? null : DataSerialize(valueSerializer, record.Topic, record.Value, headers),
                                                      headers);
        }

        static TJVMT DataSerialize<T, TJVMT>(ISerializer<T, TJVMT> serializer, string topic, T data, Headers headers)
        {
            if (serializer == null) return default;
            if (serializer.UseHeaders)
            {
                return serializer.SerializeWithHeaders(topic, headers, data);
            }
            return serializer.Serialize(topic, data);
        }
        /// <inheritdoc cref="IProducer{K, V, TJVMK, TJVMV}.SetCallback(Callback)"/>
        public void SetCallback(Callback callback) => IExecute("setCallback", callback);
        /// <inheritdoc cref="IProducer{K, V, TJVMK, TJVMV}.Send(ProducerRecord{K, V, TJVMK, TJVMV})"/>
        public Future<RecordMetadata> Send(ProducerRecord<K, V, TJVMK, TJVMV> record)
        {
            Org.Apache.Kafka.Clients.Producer.ProducerRecord<TJVMK, TJVMV> kRecord = KNetProducer<K, V, TJVMK, TJVMV>.ToProducerRecord(record, _keySerializer, _valueSerializer);
            try
            {
                GC.SuppressFinalize(kRecord);
                return Send(kRecord);
            }
            finally { GC.ReRegisterForFinalize(kRecord); }
        }
        /// <inheritdoc cref="IProducer{K, V, TJVMK, TJVMV}.Send(ProducerRecord{K, V, TJVMK, TJVMV}, Callback)"/>
        public Future<RecordMetadata> Send(ProducerRecord<K, V, TJVMK, TJVMV> record, Callback callback)
        {
            Org.Apache.Kafka.Clients.Producer.ProducerRecord<TJVMK, TJVMV> kRecord = KNetProducer<K, V, TJVMK, TJVMV>.ToProducerRecord(record, _keySerializer, _valueSerializer);
            try
            {
                GC.SuppressFinalize(kRecord);
                return Send(kRecord, callback);
            }
            finally { GC.ReRegisterForFinalize(kRecord); }
        }
        /// <inheritdoc cref="IProducer{K, V, TJVMK, TJVMV}.Send(string, int, long, K, V, Headers)"/>
        public void Send(string topic, int partition, long timestamp, K key, V value, Headers headers)
        {
            IExecute("send", topic, partition, timestamp, _keySerializer.SerializeWithHeaders(topic, headers, key), _valueSerializer.SerializeWithHeaders(topic, headers, value), headers);
        }
        /// <inheritdoc cref="IProducer{K, V, TJVMK, TJVMV}.Send(string, int, long, K, V)"/>
        public void Send(string topic, int partition, long timestamp, K key, V value)
        {
            IExecute("send", topic, partition, timestamp, _keySerializer.Serialize(topic, key), _valueSerializer.Serialize(topic, value));
        }
        /// <inheritdoc cref="IProducer{K, V, TJVMK, TJVMV}.Send(string, int, K, V, Headers)"/>
        public void Send(string topic, int partition, K key, V value, Headers headers)
        {
            IExecute("send", topic, partition, _keySerializer.SerializeWithHeaders(topic, headers, key), _valueSerializer.SerializeWithHeaders(topic, headers, value), headers);
        }
        /// <inheritdoc cref="IProducer{K, V, TJVMK, TJVMV}.Send(string, int, K, V, Headers)"/>
        public void Send(string topic, int partition, K key, V value)
        {
            IExecute("send", topic, partition, _keySerializer.Serialize(topic, key), _valueSerializer.Serialize(topic, value));
        }
        /// <inheritdoc cref="IProducer{K, V, TJVMK, TJVMV}.Send(string, K, V)"/>
        public void Send(string topic, K key, V value)
        {
            IExecute("send", topic, _keySerializer.Serialize(topic, key), _valueSerializer.Serialize(topic, value));
        }
        /// <inheritdoc cref="IProducer{K, V, TJVMK, TJVMV}.Send(string, V)"/>
        public void Send(string topic, V value)
        {
            IExecute("send", topic, _valueSerializer.Serialize(topic, value));
        }
        /// <inheritdoc cref="IProducer{K, V, TJVMK, TJVMV}.Produce(string, K, V, Action{RecordMetadata, JVMBridgeException})"/>
        public void Produce(string topic, K key, V value, Action<RecordMetadata, JVMBridgeException> action = null)
        {
            Produce(new ProducerRecord<K, V, TJVMK, TJVMV>(topic, key, value), action);
        }
        /// <inheritdoc cref="IProducer{K, V, TJVMK, TJVMV}.Produce(string, int, K, V, Action{RecordMetadata, JVMBridgeException})"/>
        public void Produce(string topic, int partition, K key, V value, Action<RecordMetadata, JVMBridgeException> action = null)
        {
            Produce(new ProducerRecord<K, V, TJVMK, TJVMV>(topic, partition, key, value), action);
        }
        /// <inheritdoc cref="IProducer{K, V, TJVMK, TJVMV}.Produce(string, int, long, K, V, Action{RecordMetadata, JVMBridgeException})"/>
        public void Produce(string topic, int partition, long timestamp, K key, V value, Action<RecordMetadata, JVMBridgeException> action = null)
        {
            Produce(new ProducerRecord<K, V, TJVMK, TJVMV>(topic, partition, timestamp, key, value), action);
        }
        /// <inheritdoc cref="IProducer{K, V, TJVMK, TJVMV}.Produce(string, int, long, K, V, Action{RecordMetadata, JVMBridgeException})"/>
        public void Produce(string topic, int partition, DateTime timestamp, K key, V value, Action<RecordMetadata, JVMBridgeException> action = null)
        {
            Produce(new ProducerRecord<K, V, TJVMK, TJVMV>(topic, partition, timestamp, key, value), action);
        }
        /// <inheritdoc cref="IProducer{K, V, TJVMK, TJVMV}.Produce(ProducerRecord{K, V, TJVMK, TJVMV}, Action{RecordMetadata, JVMBridgeException})"/>
        public void Produce(ProducerRecord<K, V, TJVMK, TJVMV> record, Action<RecordMetadata, JVMBridgeException> action = null)
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
        /// <inheritdoc cref="IProducer{K, V, TJVMK, TJVMV}.Produce(string, K, V, Callback)"/>
        public Future<RecordMetadata> Produce(string topic, K key, V value, Callback cb = null)
        {
            return Produce(new ProducerRecord<K, V, TJVMK, TJVMV>(topic, key, value), cb);
        }
        /// <inheritdoc cref="IProducer{K, V, TJVMK, TJVMV}.ProduceAndWait(string, K, V, Callback)"/>
        public void ProduceAndWait(string topic, K key, V value, Callback cb = null)
        {
            ProduceAndWait(new ProducerRecord<K, V, TJVMK, TJVMV>(topic, key, value), cb);
        }
        /// <inheritdoc cref="IProducer{K, V, TJVMK, TJVMV}.Produce(string, int, K, V, Callback)"/>
        public Future<RecordMetadata> Produce(string topic, int partition, K key, V value, Callback cb = null)
        {
            return Produce(new ProducerRecord<K, V, TJVMK, TJVMV>(topic, partition, key, value), cb);
        }
        /// <inheritdoc cref="IProducer{K, V, TJVMK, TJVMV}.ProduceAndWait(string, int, K, V, Callback)"/>
        public void ProduceAndWait(string topic, int partition, K key, V value, Callback cb = null)
        {
            ProduceAndWait(new ProducerRecord<K, V, TJVMK, TJVMV>(topic, partition, key, value), cb);
        }
        /// <inheritdoc cref="IProducer{K, V, TJVMK, TJVMV}.Produce(string, int, long, K, V, Callback)"/>
        public Future<RecordMetadata> Produce(string topic, int partition, long timestamp, K key, V value, Callback cb = null)
        {
            return Produce(new ProducerRecord<K, V, TJVMK, TJVMV>(topic, partition, timestamp, key, value), cb);
        }
        /// <inheritdoc cref="IProducer{K, V, TJVMK, TJVMV}.ProduceAndWait(string, int, long, K, V, Callback)"/>
        public void ProduceAndWait(string topic, int partition, long timestamp, K key, V value, Callback cb = null)
        {
            ProduceAndWait(new ProducerRecord<K, V, TJVMK, TJVMV>(topic, partition, timestamp, key, value), cb);
        }
        /// <inheritdoc cref="IProducer{K, V, TJVMK, TJVMV}.Produce(string, int, DateTime, K, V, Callback)"/>
        public Future<RecordMetadata> Produce(string topic, int partition, DateTime timestamp, K key, V value, Callback cb = null)
        {
            return Produce(new ProducerRecord<K, V, TJVMK, TJVMV>(topic, partition, timestamp, key, value), cb);
        }
        /// <inheritdoc cref="IProducer{K, V, TJVMK, TJVMV}.ProduceAndWait(string, int, DateTime, K, V, Callback)"/>
        public void ProduceAndWait(string topic, int partition, DateTime timestamp, K key, V value, Callback cb = null)
        {
            ProduceAndWait(new ProducerRecord<K, V, TJVMK, TJVMV>(topic, partition, timestamp, key, value), cb);
        }
        /// <inheritdoc cref="IProducer{K, V, TJVMK, TJVMV}.Produce(ProducerRecord{K, V, TJVMK, TJVMV}, Callback)"/>
        public Future<RecordMetadata> Produce(ProducerRecord<K, V, TJVMK, TJVMV> record, Callback cb = null)
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
        /// <inheritdoc cref="IProducer{K, V, TJVMK, TJVMV}.ProduceAndWait(ProducerRecord{K, V, TJVMK, TJVMV}, Callback)"/>
        public void ProduceAndWait(ProducerRecord<K, V, TJVMK, TJVMV> record, Callback cb = null)
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
        /// <inheritdoc cref="IProducer{K, V, TJVMK, TJVMV}.Produce(string, K, V, Action{RecordMetadata, JVMBridgeException})"/>
        public async Task ProduceAsync(string topic, K key, V value, Action<RecordMetadata, JVMBridgeException> action = null)
        {
            await ProduceAsync(new ProducerRecord<K, V, TJVMK, TJVMV>(topic, key, value), action);
        }
        /// <inheritdoc cref="IProducer{K, V, TJVMK, TJVMV}.Produce(string, int, K, V, Action{RecordMetadata, JVMBridgeException})"/>
        public async Task ProduceAsync(string topic, int partition, K key, V value, Action<RecordMetadata, JVMBridgeException> action = null)
        {
            await ProduceAsync(new ProducerRecord<K, V, TJVMK, TJVMV>(topic, partition, key, value), action);
        }
        /// <inheritdoc cref="IProducer{K, V, TJVMK, TJVMV}.Produce(string, int, long, K, V, Action{RecordMetadata, JVMBridgeException})"/>
        public async Task ProduceAsync(string topic, int partition, long timestamp, K key, V value, Action<RecordMetadata, JVMBridgeException> action = null)
        {
            await ProduceAsync(new ProducerRecord<K, V, TJVMK, TJVMV>(topic, partition, timestamp, key, value), action);
        }
        /// <inheritdoc cref="IProducer{K, V, TJVMK, TJVMV}.Produce(string, int, DateTime, K, V, Action{RecordMetadata, JVMBridgeException})"/>
        public async Task ProduceAsync(string topic, int partition, DateTime timestamp, K key, V value, Action<RecordMetadata, JVMBridgeException> action = null)
        {
            await ProduceAsync(new ProducerRecord<K, V, TJVMK, TJVMV>(topic, partition, timestamp, key, value), action);
        }
        /// <inheritdoc cref="IProducer{K, V, TJVMK, TJVMV}.Produce(ProducerRecord{K, V, TJVMK, TJVMV}, Action{RecordMetadata, JVMBridgeException})"/>
        public async Task ProduceAsync(ProducerRecord<K, V, TJVMK, TJVMV> record, Action<RecordMetadata, JVMBridgeException> action = null)
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

        /// <inheritdoc cref="IProducer{K, V, TJVMK, TJVMV}.NewRecord()"/>
        public ProducerRecord<K, V, TJVMK, TJVMV> NewRecord()
        {
            return new ProducerRecord<K, V, TJVMK, TJVMV>();
        }
        /// <inheritdoc cref="IProducer{K, V, TJVMK, TJVMV}.NewRecord(string, int, long, K, V, Headers)"/>
        public ProducerRecord<K, V, TJVMK, TJVMV> NewRecord(string topic, int partition, long timestamp, K key, V value, Headers headers)
        {
            return new ProducerRecord<K, V, TJVMK, TJVMV>(topic, partition, timestamp, key, value, headers);
        }
        /// <inheritdoc cref="IProducer{K, V, TJVMK, TJVMV}.NewRecord(string, int, DateTime, K, V, Headers)"/>
        public ProducerRecord<K, V, TJVMK, TJVMV> NewRecord(string topic, int partition, System.DateTime timestamp, K key, V value, Headers headers)
        {
            return new ProducerRecord<K, V, TJVMK, TJVMV>(topic, partition, timestamp, key, value, headers);
        }
        /// <inheritdoc cref="IProducer{K, V, TJVMK, TJVMV}.NewRecord(string, int, long, K, V)"/>
        public ProducerRecord<K, V, TJVMK, TJVMV> NewRecord(string topic, int partition, long timestamp, K key, V value)
        {
            return new ProducerRecord<K, V, TJVMK, TJVMV>(topic, partition, timestamp, key, value);
        }
        /// <inheritdoc cref="IProducer{K, V, TJVMK, TJVMV}.NewRecord(string, int, DateTime, K, V)"/>
        public ProducerRecord<K, V, TJVMK, TJVMV> NewRecord(string topic, int partition, System.DateTime timestamp, K key, V value)
        {
            return new ProducerRecord<K, V, TJVMK, TJVMV>(topic, partition, timestamp, key, value);
        }
        /// <inheritdoc cref="IProducer{K, V, TJVMK, TJVMV}.NewRecord(string, int, K, V, Headers)"/>
        public ProducerRecord<K, V, TJVMK, TJVMV> NewRecord(string topic, int partition, K key, V value, Headers headers)
        {
            return new ProducerRecord<K, V, TJVMK, TJVMV>(topic, partition, key, value, headers);
        }
        /// <inheritdoc cref="IProducer{K, V, TJVMK, TJVMV}.NewRecord(string, int, K, V)"/>
        public ProducerRecord<K, V, TJVMK, TJVMV> NewRecord(string topic, int partition, K key, V value)
        {
            return new ProducerRecord<K, V, TJVMK, TJVMV>(topic, partition, key, value);
        }
        /// <inheritdoc cref="IProducer{K, V, TJVMK, TJVMV}.NewRecord(string, K, V)"/>
        public ProducerRecord<K, V, TJVMK, TJVMV> NewRecord(string topic, K key, V value)
        {
            return new ProducerRecord<K, V, TJVMK, TJVMV>(topic, key, value);
        }
        /// <inheritdoc cref="IProducer{K, V, TJVMK, TJVMV}.NewRecord(string, V)"/>
        public ProducerRecord<K, V, TJVMK, TJVMV> NewRecord(string topic, V value)
        {
            return new ProducerRecord<K, V, TJVMK, TJVMV>(topic, value);
        }
    }

    #endregion

    #region KNetProducer<K, V>
    /// <summary>
    /// Extends <see cref="KafkaProducer"/> adding less intrusive methods which performs better in high throughput applications, extends <see cref="KNetProducer{K, V, TJVMK, TJVMV}"/> using array of <see cref="byte"/>
    /// </summary>
    /// <typeparam name="K">Same meaning of <see cref="KafkaProducer"/></typeparam>
    /// <typeparam name="V">Same meaning of <see cref="KafkaProducer"/></typeparam>
    public class KNetProducer<K, V> : KNetProducer<K, V, byte[], byte[]>
    {
        /// <summary>
        /// Initialize a new instance of <see cref="KNetProducer{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        /// <param name="configBuilder">An instance of <see cref="ProducerConfigBuilder"/> </param>
        public KNetProducer(ProducerConfigBuilder configBuilder)
            : base(configBuilder)
        {
        }
        /// <summary>
        /// Initialize a new instance of <see cref="KNetProducer{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        /// <param name="props">The properties to use, see <see cref="ProducerConfigBuilder"/></param>
        /// <param name="keySerializer">Key serializer base on <see cref="SerDes{K, TJVMK}"/></param>
        /// <param name="valueSerializer">Value serializer base on <see cref="SerDes{V, TJVMV}"/></param>
        public KNetProducer(ProducerConfigBuilder props, ISerDes<K, byte[]> keySerializer, ISerDes<V, byte[]> valueSerializer)
            : base(props, keySerializer, valueSerializer)
        {
        }
    }

    #endregion

    #region KNetProducerBuffered<K, V>
    /// <summary>
    /// Extends <see cref="KafkaProducer"/> adding less intrusive methods which performs better in high throughput applications, extends <see cref="KNetProducer{K, V, TJVMK, TJVMV}"/> using <see cref="Java.Nio.ByteBuffer"/>
    /// </summary>
    /// <typeparam name="K">Same meaning of <see cref="KafkaProducer"/></typeparam>
    /// <typeparam name="V">Same meaning of <see cref="KafkaProducer"/></typeparam>
    public class KNetProducerBuffered<K, V> : KNetProducer<K, V, Java.Nio.ByteBuffer, Java.Nio.ByteBuffer>
    {
        /// <summary>
        /// Initialize a new instance of <see cref="KNetProducer{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        /// <param name="configBuilder">An instance of <see cref="ProducerConfigBuilder"/> </param>
        public KNetProducerBuffered(ProducerConfigBuilder configBuilder)
            : base(configBuilder)
        {
        }
        /// <summary>
        /// Initialize a new instance of <see cref="KNetProducer{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        /// <param name="props">The properties to use, see <see cref="ProducerConfigBuilder"/></param>
        /// <param name="keySerializer">Key serializer base on <see cref="SerDes{K, TJVMK}"/></param>
        /// <param name="valueSerializer">Value serializer base on <see cref="SerDes{V, TJVMV}"/></param>
        public KNetProducerBuffered(ProducerConfigBuilder props, ISerDes<K, Java.Nio.ByteBuffer> keySerializer, ISerDes<V, Java.Nio.ByteBuffer> valueSerializer)
            : base(props, keySerializer, valueSerializer)
        {
        }
    }

    #endregion

    #region KNetProducerKeyBuffered<K, V>
    /// <summary>
    /// Extends <see cref="KafkaProducer"/> adding less intrusive methods which performs better in high throughput applications, extends <see cref="KNetProducer{K, V, TJVMK, TJVMV}"/> using <see cref="Java.Nio.ByteBuffer"/> for key
    /// </summary>
    /// <typeparam name="K">Same meaning of <see cref="KafkaProducer"/></typeparam>
    /// <typeparam name="V">Same meaning of <see cref="KafkaProducer"/></typeparam>
    public class KNetProducerKeyBuffered<K, V> : KNetProducer<K, V, Java.Nio.ByteBuffer, byte[]>
    {
        /// <summary>
        /// Initialize a new instance of <see cref="KNetProducer{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        /// <param name="configBuilder">An instance of <see cref="ProducerConfigBuilder"/> </param>
        public KNetProducerKeyBuffered(ProducerConfigBuilder configBuilder)
            : base(configBuilder)
        {
        }
        /// <summary>
        /// Initialize a new instance of <see cref="KNetProducer{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        /// <param name="props">The properties to use, see <see cref="ProducerConfigBuilder"/></param>
        /// <param name="keySerializer">Key serializer base on <see cref="SerDes{K, TJVMK}"/></param>
        /// <param name="valueSerializer">Value serializer base on <see cref="SerDes{V, TJVMV}"/></param>
        public KNetProducerKeyBuffered(ProducerConfigBuilder props, ISerDes<K, Java.Nio.ByteBuffer> keySerializer, ISerDes<V, byte[]> valueSerializer)
            : base(props, keySerializer, valueSerializer)
        {
        }
    }

    #endregion

    #region KNetProducerValueBuffered<K, V>
    /// <summary>
    /// Extends <see cref="KafkaProducer"/> adding less intrusive methods which performs better in high throughput applications, extends <see cref="KNetProducer{K, V, TJVMK, TJVMV}"/> using <see cref="Java.Nio.ByteBuffer"/> for value
    /// </summary>
    /// <typeparam name="K">Same meaning of <see cref="KafkaProducer"/></typeparam>
    /// <typeparam name="V">Same meaning of <see cref="KafkaProducer"/></typeparam>
    public class KNetProducerValueBuffered<K, V> : KNetProducer<K, V, byte[], Java.Nio.ByteBuffer>
    {
        /// <summary>
        /// Initialize a new instance of <see cref="KNetProducer{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        /// <param name="configBuilder">An instance of <see cref="ProducerConfigBuilder"/> </param>
        public KNetProducerValueBuffered(ProducerConfigBuilder configBuilder)
            : base(configBuilder)
        {
        }
        /// <summary>
        /// Initialize a new instance of <see cref="KNetProducer{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        /// <param name="props">The properties to use, see <see cref="ProducerConfigBuilder"/></param>
        /// <param name="keySerializer">Key serializer base on <see cref="SerDes{K, TJVMK}"/></param>
        /// <param name="valueSerializer">Value serializer base on <see cref="SerDes{V, TJVMV}"/></param>
        public KNetProducerValueBuffered(ProducerConfigBuilder props, ISerDes<K, byte[]> keySerializer, ISerDes<V, Java.Nio.ByteBuffer> valueSerializer)
            : base(props, keySerializer, valueSerializer)
        {
        }
    }

    #endregion
}
