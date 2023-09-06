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
    /// KNet extension of <see cref="ConsumerRecord{K, V}"/>
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    public class KNetConsumerRecord<K, V>
    {
        readonly IKNetDeserializer<K> _keyDeserializer;
        readonly IKNetDeserializer<V> _valueDeserializer;
        readonly ConsumerRecord<byte[], byte[]> _record;
        /// <summary>
        /// Initialize a new <see cref="KNetConsumerRecord{K, V}"/>
        /// </summary>
        /// <param name="record">The <see cref="ConsumerRecord{K, V}"/> to use for initialization</param>
        /// <param name="keyDeserializer">Key serializer base on <see cref="KNetSerDes{K}"/></param>
        /// <param name="valueDeserializer">Value serializer base on <see cref="KNetSerDes{K}"/></param>
        public KNetConsumerRecord(ConsumerRecord<byte[], byte[]> record, IKNetDeserializer<K> keyDeserializer, IKNetDeserializer<V> valueDeserializer)
        {
            _record = record;
            _keyDeserializer = keyDeserializer;
            _valueDeserializer = valueDeserializer;
        }
        /// <inheritdoc cref="ConsumerRecord{K, V}.Topic"/>
        public string Topic => _record.Topic();
        /// <inheritdoc cref="ConsumerRecord{K, V}.Partition"/>
        public int Partition => _record.Partition();
        /// <inheritdoc cref="ConsumerRecord{K, V}.Headers"/>
        public Headers Headers => _record.Headers();
        /// <inheritdoc cref="ConsumerRecord{K, V}.Offset"/>
        public long Offset => _record.Offset();
        /// <inheritdoc cref="ConsumerRecord{K, V}.DateTime"/>
        public System.DateTime DateTime => _record.DateTime;
        /// <inheritdoc cref="ConsumerRecord{K, V}.Timestamp"/>
        public long Timestamp => _record.Timestamp();
        /// <inheritdoc cref="ConsumerRecord{K, V}.TimestampType"/>
        public TimestampType TimestampType => _record.TimestampType();
        /// <inheritdoc cref="ConsumerRecord{K, V}.SerializedKeySize"/>
        public int SerializedKeySize => _record.SerializedKeySize();
        /// <inheritdoc cref="ConsumerRecord{K, V}.SerializedValueSize"/>
        public int SerializedValueSize => _record.SerializedValueSize();

        bool _localKeyDes = false;
        K _localKey = default;
        /// <inheritdoc cref="ConsumerRecord{K, V}.Key"/>
        public K Key
        {
            get
            {
                if (!_localKeyDes)
                {
                    _localKey = _keyDeserializer.UseHeaders ? _keyDeserializer.DeserializeWithHeaders(Topic, Headers, _record.Key()) : _keyDeserializer.Deserialize(Topic, _record.Key());
                    _localKeyDes = true;
                }
                return _localKey;
            }
        }

        bool _localValueDes = false;
        V _localValue = default;
        /// <inheritdoc cref="ConsumerRecord{K, V}.Value"/>
        public V Value
        {
            get
            {
                if (!_localValueDes)
                {
                    _localValue = _valueDeserializer.UseHeaders ? _valueDeserializer.DeserializeWithHeaders(Topic, Headers, _record.Value()) : _valueDeserializer.Deserialize(Topic, _record.Value());
                    _localValueDes = true;
                }
                return _localValue;
            }
        }
        /// <inheritdoc cref="object.ToString"/>
        public override string ToString()
        {
            return $"Topic: {Topic} - Partition {Partition} - Offset {Offset} - Key {Key} - Value {Value}";
        }
    }

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

    interface IKNetConsumerCallback<K, V> : IJVMBridgeBase
    {
        void RecordReady(KNetConsumerRecord<K, V> message);
    }

    class KNetConsumerCallback<K, V> : JVMBridgeListener, IKNetConsumerCallback<K, V>
    {
        readonly IKNetDeserializer<K> _keyDeserializer;
        readonly IKNetDeserializer<V> _valueDeserializer;
        /// <summary>
        /// <see href="https://www.jcobridge.com/api-clr/html/P_MASES_JCOBridge_C2JBridge_JVMBridgeListener_BridgeClassName.htm"/>
        /// </summary>
        public sealed override string BridgeClassName => "org.mases.knet.clients.consumer.KNetConsumerCallback";

        readonly Action<KNetConsumerRecord<K, V>> recordReadyFunction = null;
        public virtual Action<KNetConsumerRecord<K, V>> OnRecordReady { get { return recordReadyFunction; } }
        public KNetConsumerCallback(Action<KNetConsumerRecord<K, V>> recordReady, IKNetDeserializer<K> keyDeserializer, IKNetDeserializer<V> valueDeserializer)
        {
            if (recordReady != null) recordReadyFunction = recordReady;
            else recordReadyFunction = RecordReady;

            _keyDeserializer = keyDeserializer;
            _valueDeserializer = valueDeserializer;

            AddEventHandler("recordReady", new EventHandler<CLRListenerEventArgs<CLREventData>>(OnRecordReadyEventHandler));
        }

        void OnRecordReadyEventHandler(object sender, CLRListenerEventArgs<CLREventData> data)
        {
            var record = this.BridgeInstance.Invoke<ConsumerRecord<byte[], byte[]>>("getRecord");
            OnRecordReady(new KNetConsumerRecord<K, V>(record, _keyDeserializer, _valueDeserializer));
        }

        public virtual void RecordReady(KNetConsumerRecord<K, V> message) { }
    }
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
        /// <see langword="true"/> if the <see cref="IKNetConsumer{K, V}"/> instance has an empty setnof items in async operation
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
        void ConsumeAsync(long timeoutMs);
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
        readonly bool autoCreateSerDes = false;
        bool threadRunning = false;
        long dequeing = 0;
        readonly System.Threading.Thread consumeThread = null;
        readonly ConcurrentQueue<KNetConsumerRecords<K, V>> consumedRecords = null;
        readonly KNetConsumerCallback<K, V> consumerCallback = null;
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
            autoCreateSerDes = true;

            if (useJVMCallback)
            {
                consumerCallback = new KNetConsumerCallback<K, V>(CallbackMessage, _keyDeserializer, _valueDeserializer);
                IExecute("setCallback", consumerCallback);
            }
            else
            {
                consumedRecords = new();
                threadRunning = true;
                consumeThread = new(ConsumeHandler);
                consumeThread.Start();
            }
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
                consumerCallback = new KNetConsumerCallback<K, V>(CallbackMessage, _keyDeserializer, _valueDeserializer);
                IExecute("setCallback", consumerCallback);
            }
            else
            {
                consumedRecords = new();
                threadRunning = true;
                consumeThread = new(ConsumeHandler);
                consumeThread.Start();
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
            if (consumerCallback != null)
            {
                IExecute("setCallback", null);
                consumerCallback?.Dispose();
            }
            threadRunning = false;
            if (consumedRecords != null)
            {
                lock (consumedRecords)
                {
                    System.Threading.Monitor.Pulse(consumedRecords);
                }
                if (IsCompleting) { consumeThread?.Join(); };
                actionCallback = null;
            }
            if (autoCreateSerDes)
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
                while (threadRunning)
                {
                    if (consumedRecords.TryDequeue(out KNetConsumerRecords<K, V> records))
                    {
                        System.Threading.Interlocked.Increment(ref dequeing);
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
                            System.Threading.Interlocked.Decrement(ref dequeing);
                        }
                    }
                    else if (threadRunning)
                    {
                        lock (consumedRecords)
                        {
                            System.Threading.Monitor.Wait(consumedRecords);
                        }
                    }
                }
            }
            catch { }
        }
        /// <inheritdoc cref="IKNetConsumer{K, V}.IsCompleting"/>
        public bool IsCompleting => !consumedRecords.IsEmpty || System.Threading.Interlocked.Read(ref dequeing) != 0;
        /// <inheritdoc cref="IKNetConsumer{K, V}.IsEmpty"/>
        public bool IsEmpty => consumedRecords.IsEmpty;
        /// <inheritdoc cref="IKNetConsumer{K, V}.WaitingMessages"/>
        public int WaitingMessages => consumedRecords.Count;
        /// <inheritdoc cref="IKNetConsumer{K, V}.ConsumeAsync(long)"/>
        public void ConsumeAsync(long timeoutMs)
        {
            Duration duration = TimeSpan.FromMilliseconds(timeoutMs);
            if (consumedRecords == null) throw new ArgumentException("Cannot be used since constructor was called with useJVMCallback set to true.");
            if (!threadRunning) throw new InvalidOperationException("Dispatching thread is not running.");
            var results = this.Poll(duration);
            consumedRecords.Enqueue(results);
            lock (consumedRecords)
            {
                System.Threading.Monitor.Pulse(consumedRecords);
            }
        }
        /// <inheritdoc cref="IKNetConsumer{K, V}.Consume(long, Action{KNetConsumerRecord{K, V}})"/>
        public void Consume(long timeoutMs, Action<KNetConsumerRecord<K, V>> callback)
        {
            Duration duration = TimeSpan.FromMilliseconds(timeoutMs);
            if (consumerCallback == null) throw new ArgumentException("Cannot be used since constructor was called with useJVMCallback set to false.");
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
