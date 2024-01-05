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

using Java.Time;
using Java.Util;
using MASES.JCOBridge.C2JBridge;
using System;
using System.Collections.Concurrent;
using Org.Apache.Kafka.Clients.Consumer;
using MASES.KNet.Serialization;
using Org.Apache.Kafka.Common.Header;
using Org.Apache.Kafka.Common.Record;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MASES.KNet.Consumer
{
    /// <summary>
    /// KNet extension of <see cref="IConsumer{K, V}"/>
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    public interface IKNetConsumer<K, V> : IConsumer<byte[], byte[]>
    {
        /// <summary>
        /// <see langword="true"/> if the <see cref="IKNetConsumer{K, V}"/> instance is completing async operation
        /// </summary>
        bool IsCompleting { get; }
        /// <summary>
        /// <see langword="true"/> if the <see cref="IKNetConsumer{K, V}"/> instance has an empty set of items in async operation
        /// </summary>
        bool IsEmpty { get; }
        /// <summary>
        /// Number of messages in the <see cref="IKNetConsumer{K, V}"/> instance waiting to be processed in async operation
        /// </summary>
        int WaitingMessages { get; }
        /// <summary>
        /// Sets the <see cref="Action{T}"/> to use to receive <see cref="KNetConsumerRecord{K, V}"/>
        /// </summary>
        /// <param name="cb">The callback <see cref="Action{T}"/></param>
        void SetCallback(Action<KNetConsumerRecord<K, V>> cb);
        /// <summary>
        /// KNet extension for <see cref="Org.Apache.Kafka.Clients.Consumer.Consumer.Poll(Duration)"/>
        /// </summary>
        /// <param name="timeoutMs">Timeout in milliseconds</param>
        /// <returns><see cref="KNetConsumerRecords{K, V}"/></returns>
        KNetConsumerRecords<K, V> Poll(long timeoutMs);
        /// <summary>
        /// KNet extension for <see cref="Org.Apache.Kafka.Clients.Consumer.Consumer.Poll(Duration)"/>
        /// </summary>
        /// <param name="timeout">Timeout expressed as <see cref="Duration"/></param>
        /// <returns><see cref="KNetConsumerRecords{K, V}"/></returns>
        new KNetConsumerRecords<K, V> Poll(Duration timeout);
        /// <summary>
        /// KNet async extension for <see cref="Org.Apache.Kafka.Clients.Consumer.Consumer.Poll(Duration)"/>
        /// </summary>
        /// <param name="timeoutMs">Timeout in milliseconds</param>
        /// <returns><see langword="true"/> if something was enqued for Async operations</returns>
        bool ConsumeAsync(long timeoutMs);
        /// <summary>
        /// KNet sync extension for <see cref="Org.Apache.Kafka.Clients.Consumer.Consumer.Poll(Duration)"/>
        /// </summary>
        /// <param name="timeoutMs">Timeout in milliseconds</param>
        /// <param name="callback">The <see cref="Action{T}"/> where receives <see cref="KNetConsumerRecord{K, V}"/></param>
        void Consume(long timeoutMs, Action<KNetConsumerRecord<K, V>> callback);
    }
    /// <summary>
    /// KNet extension of <see cref="KafkaConsumer{K, V}"/>
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    public class KNetConsumer<K, V> : KafkaConsumer<byte[], byte[]>, IKNetConsumer<K, V>
    {
        readonly bool _autoCreateSerDes = false;
        bool _threadRunning = false;
        long _dequeing = 0;
        readonly System.Threading.Thread _consumeThread = null;
        readonly ConcurrentQueue<KNetConsumerRecords<K, V>> _consumedRecords = null;
        readonly KNetConsumerCallback<K, V> _consumerCallback = null;
        readonly IKNetDeserializer<K> _keyDeserializer;
        readonly IKNetDeserializer<V> _valueDeserializer;
        /// <summary>
        /// <see href="https://www.jcobridge.com/api-clr/html/P_MASES_JCOBridge_C2JBridge_JVMBridgeBase_BridgeClassName.htm"/>
        /// </summary>
        public override string BridgeClassName => "org.mases.knet.clients.consumer.KNetConsumer";
        /// <summary>
        /// Initialize a new instance of <see cref="KNetConsumer{K, V}"/>
        /// </summary>
        /// <param name="props">The properties to use, see <see cref="ConsumerConfig"/> and <see cref="ConsumerConfigBuilder"/></param>
        /// <param name="useJVMCallback"><see langword="true"/> to active callback based mode</param>
        public KNetConsumer(Properties props, bool useJVMCallback = false)
            : this(props, new KNetSerDes<K>(), new KNetSerDes<V>(), useJVMCallback)
        {
            _autoCreateSerDes = true;

            if (useJVMCallback)
            {
                _consumerCallback = new KNetConsumerCallback<K, V>(CallbackMessage, _keyDeserializer, _valueDeserializer);
                IExecute("setCallback", _consumerCallback);
            }
            else
            {
                _consumedRecords = new();
                _threadRunning = true;
                _consumeThread = new(ConsumeHandler);
                _consumeThread.Start();
            }
        }
        /// <summary>
        /// Initialize a new instance of <see cref="KNetConsumer{K, V}"/>
        /// </summary>
        /// <param name="configBuilder">An instance of <see cref="ConsumerConfigBuilder"/> </param>
        /// <param name="useJVMCallback"><see langword="true"/> to active callback based mode</param>
        public KNetConsumer(ConsumerConfigBuilder configBuilder, bool useJVMCallback = false)
            : this(configBuilder, configBuilder.BuildKeySerDes<K>(), configBuilder.BuildValueSerDes<V>())
        {
            _autoCreateSerDes = true;
        }
        /// <summary>
        /// Initialize a new instance of <see cref="KNetConsumer{K, V}"/>
        /// </summary>
        /// <param name="props">The properties to use, see <see cref="ConsumerConfig"/> and <see cref="ConsumerConfigBuilder"/></param>
        /// <param name="keyDeserializer">Key serializer base on <see cref="KNetSerDes{K}"/></param>
        /// <param name="valueDeserializer">Value serializer base on <see cref="KNetSerDes{K}"/></param>
        /// <param name="useJVMCallback"><see langword="true"/> to active callback based mode</param>
        public KNetConsumer(Properties props, IKNetDeserializer<K> keyDeserializer, IKNetDeserializer<V> valueDeserializer, bool useJVMCallback = false)
            : base(CheckProperties(props), keyDeserializer.KafkaDeserializer, valueDeserializer.KafkaDeserializer)
        {
            _keyDeserializer = keyDeserializer;
            _valueDeserializer = valueDeserializer;

            if (useJVMCallback)
            {
                _consumerCallback = new KNetConsumerCallback<K, V>(CallbackMessage, _keyDeserializer, _valueDeserializer);
                IExecute("setCallback", _consumerCallback);
            }
            else
            {
                _consumedRecords = new();
                _threadRunning = true;
                _consumeThread = new(ConsumeHandler);
                _consumeThread.Start();
            }
        }

        static Properties CheckProperties(Properties props)
        {
            if (!props.ContainsKey(ConsumerConfig.KEY_DESERIALIZER_CLASS_CONFIG))
            {
                props.Put(ConsumerConfig.KEY_DESERIALIZER_CLASS_CONFIG, "org.apache.kafka.common.serialization.ByteArrayDeserializer");
            }
            else throw new InvalidOperationException($"KNetConsumer auto manages configuration property {ConsumerConfig.KEY_DESERIALIZER_CLASS_CONFIG}, remove from configuration.");

            if (!props.ContainsKey(ConsumerConfig.VALUE_DESERIALIZER_CLASS_CONFIG))
            {
                props.Put(ConsumerConfig.VALUE_DESERIALIZER_CLASS_CONFIG, "org.apache.kafka.common.serialization.ByteArrayDeserializer");
            }
            else throw new InvalidOperationException($"KNetConsumer auto manages configuration property {ConsumerConfig.VALUE_DESERIALIZER_CLASS_CONFIG}, remove from configuration.");

            return props;
        }
        /// <summary>
        /// Finalizer
        /// </summary>
        ~KNetConsumer()
        {
            this.Dispose();
        }

        /// <inheritdoc cref="IKNetConsumer{K, V}.Poll(long)"/>
        public new KNetConsumerRecords<K, V> Poll(long timeoutMs)
        {
            var records = IExecute<ConsumerRecords<byte[], byte[]>>("poll", timeoutMs);
            return new KNetConsumerRecords<K, V>(records, _keyDeserializer, _valueDeserializer);
        }
        /// <inheritdoc cref="IKNetConsumer{K, V}.Poll(Duration)"/>
        public new KNetConsumerRecords<K, V> Poll(Duration timeout)
        {
            var records = IExecute<ConsumerRecords<byte[], byte[]>>("poll", timeout);
            return new KNetConsumerRecords<K, V>(records, _keyDeserializer, _valueDeserializer);
        }

        Action<KNetConsumerRecord<K, V>> actionCallback = null;

        void CallbackMessage(KNetConsumerRecord<K, V> message)
        {
            actionCallback?.Invoke(message);
        }
        /// <inheritdoc cref="IDisposable.Dispose"/>
        public override void Dispose()
        {
            if (_consumerCallback != null)
            {
                IExecute("setCallback", null);
                _consumerCallback?.Dispose();
            }
            _threadRunning = false;
            if (_consumedRecords != null)
            {
                lock (_consumedRecords)
                {
                    System.Threading.Monitor.Pulse(_consumedRecords);
                }
                if (IsCompleting) { _consumeThread?.Join(); };
                actionCallback = null;
            }
            if (_autoCreateSerDes)
            {
                _keyDeserializer?.Dispose();
                _valueDeserializer?.Dispose();
            }
            base.Dispose();
        }
        /// <inheritdoc cref="IKNetConsumer{K, V}.SetCallback(Action{KNetConsumerRecord{K, V}})"/>
        public void SetCallback(Action<KNetConsumerRecord<K, V>> cb)
        {
            actionCallback = cb;
        }

        void ConsumeHandler(object o)
        {
            try
            {
                while (_threadRunning)
                {
                    if (_consumedRecords.TryDequeue(out KNetConsumerRecords<K, V> records))
                    {
                        System.Threading.Interlocked.Increment(ref _dequeing);
                        try
                        {
                            foreach (var item in records)
                            {
                                actionCallback?.Invoke(item);
                            }
                        }
                        catch { }
                        finally
                        {
                            System.Threading.Interlocked.Decrement(ref _dequeing);
                        }
                    }
                    else if (_threadRunning)
                    {
                        lock (_consumedRecords)
                        {
                            System.Threading.Monitor.Wait(_consumedRecords);
                        }
                    }
                }
            }
            catch { }
        }
        /// <inheritdoc cref="IKNetConsumer{K, V}.IsCompleting"/>
        public bool IsCompleting => !_consumedRecords.IsEmpty || System.Threading.Interlocked.Read(ref _dequeing) != 0;
        /// <inheritdoc cref="IKNetConsumer{K, V}.IsEmpty"/>
        public bool IsEmpty => _consumedRecords.IsEmpty;
        /// <inheritdoc cref="IKNetConsumer{K, V}.WaitingMessages"/>
        public int WaitingMessages => _consumedRecords.Count;
        /// <inheritdoc cref="IKNetConsumer{K, V}.ConsumeAsync(long)"/>
        public bool ConsumeAsync(long timeoutMs)
        {
            Duration duration = TimeSpan.FromMilliseconds(timeoutMs);
            if (_consumedRecords == null) throw new ArgumentException("Cannot be used since constructor was called with useJVMCallback set to true.");
            if (!_threadRunning) throw new InvalidOperationException("Dispatching thread is not running.");
            try
            {
                var results = this.Poll(duration);
                bool isEmpty = results.IsEmpty;
                if (!isEmpty)
                {
                    _consumedRecords.Enqueue(results);
                    lock (_consumedRecords)
                    {
                        System.Threading.Monitor.Pulse(_consumedRecords);
                    }
                }
                return !isEmpty;
            }
            finally
            {
                duration?.Dispose();
            }
        }
        /// <inheritdoc cref="IKNetConsumer{K, V}.Consume(long, Action{KNetConsumerRecord{K, V}})"/>
        public void Consume(long timeoutMs, Action<KNetConsumerRecord<K, V>> callback)
        {
            Duration duration = TimeSpan.FromMilliseconds(timeoutMs);
            if (_consumerCallback == null) throw new ArgumentException("Cannot be used since constructor was called with useJVMCallback set to false.");
            try
            {
                actionCallback = callback;
                IExecute("consume", duration);
            }
            finally
            {
                duration?.Dispose();
                actionCallback = null;
            }
        }
    }
}
