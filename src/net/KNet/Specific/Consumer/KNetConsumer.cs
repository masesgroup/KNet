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

using Java.Time;
using Java.Util;
using System;
using System.Collections.Concurrent;
using MASES.KNet.Serialization;
using System.Threading;

namespace MASES.KNet.Consumer
{
    #region IConsumer<K, V, TJVMK, TJVMV>

    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Clients.Consumer.IConsumer{K, V}"/>
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
    /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
    public interface IConsumer<K, V, TJVMK, TJVMV> : Org.Apache.Kafka.Clients.Consumer.IConsumer<TJVMK, TJVMV>
    {
#if NET7_0_OR_GREATER
        /// <summary>
        /// <see langword="true"/> if enumeration will use prefetch and the number of records is more than <see cref="PrefetchThreshold"/>, i.e. the preparation of <see cref="ConsumerRecord{K, V, TJVMK, TJVMV}"/> happens in an external thread
        /// </summary>
        /// <remarks>It is <see langword="true"/> by default if one of <typeparamref name="K"/> or <typeparamref name="V"/> are not <see cref="ValueType"/>, override the value using <see cref="ApplyPrefetch(bool, int)"/></remarks>
        bool IsPrefecth { get; }
        /// <summary>
        /// The minimum threshold to activate pretech, i.e. the preparation of <see cref="ConsumerRecord{K, V, TJVMK, TJVMV}"/> happens in external thread if <see cref="Org.Apache.Kafka.Clients.Consumer.ConsumerRecords{K, V}"/> contains more than <see cref="PrefetchThreshold"/> elements
        /// </summary>
        /// <remarks>The default value is 10, however it shall be chosen by the developer and in the decision shall be verified if external thread activation costs more than inline execution</remarks>
        int PrefetchThreshold { get; }
#endif
        /// <summary>
        /// <see langword="true"/> if the <see cref="IConsumer{K, V, TJVMK, TJVMV}"/> instance is completing async operation
        /// </summary>
        bool IsCompleting { get; }
        /// <summary>
        /// <see langword="true"/> if the <see cref="IConsumer{K, V, TJVMK, TJVMV}"/> instance has an empty set of items in async operation
        /// </summary>
        bool IsEmpty { get; }
        /// <summary>
        /// Number of messages in the <see cref="IConsumer{K, V, TJVMK, TJVMV}"/> instance waiting to be processed in async operation
        /// </summary>
        int WaitingMessages { get; }
#if NET7_0_OR_GREATER
        /// <summary>
        /// Set to <see langword="true"/> to enable enumeration with prefetch over <paramref name="prefetchThreshold"/> threshold, i.e. preparation of <see cref="ConsumerRecord{K, V, TJVMK, TJVMV}"/> in external thread 
        /// </summary>
        /// <param name="enablePrefetch"><see langword="true"/> to enable prefetch. See <see cref="IsPrefecth"/></param>
        /// <param name="prefetchThreshold">The minimum threshold to activate pretech, default is 10. See <see cref="PrefetchThreshold"/></param>
        /// <remarks>Setting <paramref name="prefetchThreshold"/> to a value less, or equal, to 0 and <paramref name="enablePrefetch"/> to <see langword="true"/>, the prefetch is always actived</remarks>
        void ApplyPrefetch(bool enablePrefetch = true, int prefetchThreshold = 10);
#endif
        /// <summary>
        /// Sets the <see cref="Action{T}"/> to use to receive <see cref="ConsumerRecord{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        /// <param name="cb">The callback <see cref="Action{T}"/></param>
        void SetCallback(Action<ConsumerRecord<K, V, TJVMK, TJVMV>> cb);
        /// <summary>
        /// KNet extension for <see cref="Org.Apache.Kafka.Clients.Consumer.Consumer.Poll(Duration)"/>
        /// </summary>
        /// <param name="timeoutMs">Timeout in milliseconds</param>
        /// <returns><see cref="ConsumerRecords{K, V, TJVMK, TJVMV}"/></returns>
        ConsumerRecords<K, V, TJVMK, TJVMV> Poll(long timeoutMs);
        /// <summary>
        /// KNet extension for <see cref="Org.Apache.Kafka.Clients.Consumer.Consumer.Poll(Duration)"/>
        /// </summary>
        /// <param name="timeout">Timeout expressed as <see cref="TimeSpan"/></param>
        /// <returns><see cref="ConsumerRecords{K, V, TJVMK, TJVMV}"/></returns>
        ConsumerRecords<K, V, TJVMK, TJVMV> Poll(TimeSpan timeout);
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
        /// <param name="callback">The <see cref="Action{T}"/> where receives <see cref="ConsumerRecord{K, V, TJVMK, TJVMV}"/></param>
        void Consume(long timeoutMs, Action<ConsumerRecord<K, V, TJVMK, TJVMV>> callback);
    }

    #endregion

    #region KNetConsumer<K, V, TJVMK, TJVMV>

    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Clients.Consumer.KafkaConsumer{K, V}"/>
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
    /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
    public class KNetConsumer<K, V, TJVMK, TJVMV> : Org.Apache.Kafka.Clients.Consumer.KafkaConsumer<TJVMK, TJVMV>, IConsumer<K, V, TJVMK, TJVMV>
    {
        readonly bool _autoCreateSerDes = false;
        bool _threadRunning = false;
        long _dequeing = 0;
        readonly System.Threading.Thread _consumeThread = null;
        readonly ConcurrentQueue<ConsumerRecords<K, V, TJVMK, TJVMV>> _consumedRecords = null;
        readonly KNetConsumerCallback<K, V, TJVMK, TJVMV> _consumerCallback = null;
        readonly ISerDes<K, TJVMK> _keyDeserializer;
        readonly ISerDes<V, TJVMV> _valueDeserializer;
        /// <summary>
        /// <see href="https://www.jcobridge.com/api-clr/html/P_MASES_JCOBridge_C2JBridge_JVMBridgeBase_BridgeClassName.htm"/>
        /// </summary>
        public override string BridgeClassName => "org.mases.knet.developed.clients.consumer.KNetConsumer";

        internal KNetConsumer(Properties props) : base(props) { }

        /// <summary>
        /// Initialize a new instance of <see cref="KNetConsumer{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        /// <param name="configBuilder">An instance of <see cref="ConsumerConfigBuilder"/> </param>
        /// <param name="useJVMCallback"><see langword="true"/> to active callback based mode</param>
        public KNetConsumer(ConsumerConfigBuilder configBuilder, bool useJVMCallback = false)
            : this(configBuilder, configBuilder.BuildKeySerDes<K, TJVMK>(), configBuilder.BuildValueSerDes<V, TJVMV>(), useJVMCallback)
        {
        }
        /// <summary>
        /// Initialize a new instance of <see cref="KNetConsumer{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        /// <param name="props">The properties to use, see <see cref="ConsumerConfigBuilder"/></param>
        /// <param name="keyDeserializer">Key serializer base on <see cref="SerDes{K, TJVMK}"/></param>
        /// <param name="valueDeserializer">Value serializer base on <see cref="SerDes{ValueTuple, TJVMV}"/></param>
        /// <param name="useJVMCallback"><see langword="true"/> to active callback based mode</param>
        public KNetConsumer(ConsumerConfigBuilder props, ISerDes<K, TJVMK> keyDeserializer, ISerDes<V, TJVMV> valueDeserializer, bool useJVMCallback = false)
            : base(CheckProperties(props, keyDeserializer, valueDeserializer), keyDeserializer.KafkaDeserializer, valueDeserializer.KafkaDeserializer)
        {
            _keyDeserializer = keyDeserializer;
            _valueDeserializer = valueDeserializer;

            if (useJVMCallback)
            {
                _consumerCallback = new KNetConsumerCallback<K, V, TJVMK, TJVMV>(CallbackMessage, _keyDeserializer, _valueDeserializer);
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

        static Properties CheckProperties(Properties props, ISerDes keyDeserializer, ISerDes valueDeserializer)
        {
            if (!props.ContainsKey(Org.Apache.Kafka.Clients.Consumer.ConsumerConfig.KEY_DESERIALIZER_CLASS_CONFIG))
            {
                props.Put(Org.Apache.Kafka.Clients.Consumer.ConsumerConfig.KEY_DESERIALIZER_CLASS_CONFIG, keyDeserializer.JVMDeserializerClassName);
            }
            else throw new InvalidOperationException($"KNetConsumer auto manages configuration property {Org.Apache.Kafka.Clients.Consumer.ConsumerConfig.KEY_DESERIALIZER_CLASS_CONFIG}, remove from configuration.");

            if (!props.ContainsKey(Org.Apache.Kafka.Clients.Consumer.ConsumerConfig.VALUE_DESERIALIZER_CLASS_CONFIG))
            {
                props.Put(Org.Apache.Kafka.Clients.Consumer.ConsumerConfig.VALUE_DESERIALIZER_CLASS_CONFIG, valueDeserializer.JVMDeserializerClassName);
            }
            else throw new InvalidOperationException($"KNetConsumer auto manages configuration property {Org.Apache.Kafka.Clients.Consumer.ConsumerConfig.VALUE_DESERIALIZER_CLASS_CONFIG}, remove from configuration.");

            return props;
        }
        /// <summary>
        /// Finalizer
        /// </summary>
        ~KNetConsumer()
        {
            this.Dispose();
        }

        /// <inheritdoc cref="IConsumer{K, V, TJVMK, TJVMV}.Poll(long)"/>
        public new ConsumerRecords<K, V, TJVMK, TJVMV> Poll(long timeoutMs)
        {
            var records = base.Poll(timeoutMs);
            return new ConsumerRecords<K, V, TJVMK, TJVMV>(records, _keyDeserializer, _valueDeserializer);
        }
        /// <inheritdoc cref="IConsumer{K, V, TJVMK, TJVMV}.Poll(TimeSpan)"/>
        public ConsumerRecords<K, V, TJVMK, TJVMV> Poll(TimeSpan timeout)
        {
            Duration duration = timeout;
            try
            {
                var records = base.Poll(duration);
                return new ConsumerRecords<K, V, TJVMK, TJVMV>(records, _keyDeserializer, _valueDeserializer);
            }
            finally { duration?.Dispose(); }
        }

        Action<ConsumerRecord<K, V, TJVMK, TJVMV>> actionCallback = null;

        void CallbackMessage(ConsumerRecord<K, V, TJVMK, TJVMV> message)
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
#if NET7_0_OR_GREATER
        /// <inheritdoc cref="IConsumer{K, V, TJVMK, TJVMV}.ApplyPrefetch(bool, int)"/>
        public void ApplyPrefetch(bool enablePrefetch = true, int prefetchThreshold = 10)
        {
            IsPrefecth = enablePrefetch;
            PrefetchThreshold = IsPrefecth ? prefetchThreshold : 10;
        }
#endif
        /// <inheritdoc cref="IConsumer{K, V, TJVMK, TJVMV}.SetCallback(Action{ConsumerRecord{K, V, TJVMK, TJVMV}})"/>
        public void SetCallback(Action<ConsumerRecord<K, V, TJVMK, TJVMV>> cb)
        {
            actionCallback = cb;
        }

        void ConsumeHandler(object o)
        {
            try
            {
                while (_threadRunning)
                {
                    if (_consumedRecords.TryDequeue(out ConsumerRecords<K, V, TJVMK, TJVMV> records))
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
#if NET7_0_OR_GREATER
        /// <inheritdoc cref="IConsumer{K, V, TJVMK, TJVMV}.IsPrefecth"/>
        public bool IsPrefecth { get; private set; } = !(typeof(K).IsValueType && typeof(V).IsValueType);
        /// <inheritdoc cref="IConsumer{K, V, TJVMK, TJVMV}.PrefetchThreshold"/>
        public int PrefetchThreshold { get; private set; } = 10;
#endif
        /// <inheritdoc cref="IConsumer{K, V, TJVMK, TJVMV}.IsCompleting"/>
        public bool IsCompleting => !_consumedRecords.IsEmpty || System.Threading.Interlocked.Read(ref _dequeing) != 0;
        /// <inheritdoc cref="IConsumer{K, V, TJVMK, TJVMV}.IsEmpty"/>
        public bool IsEmpty => _consumedRecords.IsEmpty;
        /// <inheritdoc cref="IConsumer{K, V, TJVMK, TJVMV}.WaitingMessages"/>
        public int WaitingMessages => _consumedRecords.Count;
        /// <inheritdoc cref="IConsumer{K, V, TJVMK, TJVMV}.ConsumeAsync(long)"/>
        public bool ConsumeAsync(long timeoutMs)
        {
            if (_consumedRecords == null) throw new ArgumentException("Cannot be used since constructor was called with useJVMCallback set to true.");
            if (!_threadRunning) throw new InvalidOperationException("Dispatching thread is not running.");
            var results = this.Poll(TimeSpan.FromMilliseconds(timeoutMs));
            bool isEmpty = results.IsEmpty;
            if (!isEmpty)
            {
#if NET7_0_OR_GREATER
                _consumedRecords.Enqueue(results.ApplyPrefetch(IsPrefecth, PrefetchThreshold));
#else
                _consumedRecords.Enqueue(results);
#endif
                lock (_consumedRecords)
                {
                    System.Threading.Monitor.Pulse(_consumedRecords);
                }
            }
            return !isEmpty;
        }
        /// <inheritdoc cref="IConsumer{K, V, TJVMK, TJVMV}.Consume(long, Action{ConsumerRecord{K, V, TJVMK, TJVMV}})"/>
        public void Consume(long timeoutMs, Action<ConsumerRecord<K, V, TJVMK, TJVMV>> callback)
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

    #endregion

    #region KNetConsumer<K, V>
    /// <summary>
    /// Extends <see cref="KNetConsumer{K, V, TJVMK, TJVMV}"/> using array of <see cref="byte"/>
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    public class KNetConsumer<K, V> : KNetConsumer<K, V, byte[], byte[]>
    {
        /// <summary>
        /// Initialize a new instance of <see cref="KNetConsumer{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        /// <param name="configBuilder">An instance of <see cref="ConsumerConfigBuilder"/> </param>
        /// <param name="useJVMCallback"><see langword="true"/> to active callback based mode</param>
        public KNetConsumer(ConsumerConfigBuilder configBuilder, bool useJVMCallback = false)
            : base(configBuilder, useJVMCallback)
        {
        }
        /// <summary>
        /// Initialize a new instance of <see cref="KNetConsumer{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        /// <param name="props">The properties to use, see <see cref="ConsumerConfigBuilder"/></param>
        /// <param name="keyDeserializer">Key serializer base on <see cref="SerDes{K, TJVMK}"/></param>
        /// <param name="valueDeserializer">Value serializer base on <see cref="SerDes{ValueTuple, TJVMV}"/></param>
        /// <param name="useJVMCallback"><see langword="true"/> to active callback based mode</param>
        public KNetConsumer(ConsumerConfigBuilder props, ISerDes<K, byte[]> keyDeserializer, ISerDes<V, byte[]> valueDeserializer, bool useJVMCallback = false)
            : base(props, keyDeserializer, valueDeserializer)
        {
        }
    }

    #endregion

    #region KNetConsumerBuffered<K, V>
    /// <summary>
    /// Extends <see cref="KNetConsumer{K, V, TJVMK, TJVMV}"/> using <see cref="Java.Nio.ByteBuffer"/>
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    public class KNetConsumerBuffered<K, V> : KNetConsumer<K, V, Java.Nio.ByteBuffer, Java.Nio.ByteBuffer>
    {
        /// <summary>
        /// Initialize a new instance of <see cref="KNetConsumer{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        /// <param name="configBuilder">An instance of <see cref="ConsumerConfigBuilder"/> </param>
        /// <param name="useJVMCallback"><see langword="true"/> to active callback based mode</param>
        public KNetConsumerBuffered(ConsumerConfigBuilder configBuilder, bool useJVMCallback = false)
            : base(configBuilder, useJVMCallback)
        {
        }
        /// <summary>
        /// Initialize a new instance of <see cref="KNetConsumer{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        /// <param name="props">The properties to use, see <see cref="ConsumerConfigBuilder"/></param>
        /// <param name="keyDeserializer">Key serializer base on <see cref="SerDes{K, TJVMK}"/></param>
        /// <param name="valueDeserializer">Value serializer base on <see cref="SerDes{ValueTuple, TJVMV}"/></param>
        /// <param name="useJVMCallback"><see langword="true"/> to active callback based mode</param>
        public KNetConsumerBuffered(ConsumerConfigBuilder props, ISerDes<K, Java.Nio.ByteBuffer> keyDeserializer, ISerDes<V, Java.Nio.ByteBuffer> valueDeserializer, bool useJVMCallback = false)
            : base(props, keyDeserializer, valueDeserializer)
        {
        }
    }
    #endregion

    #region KNetConsumerKeyBuffered<K, V>
    /// <summary>
    /// Extends <see cref="KNetConsumer{K, V, TJVMK, TJVMV}"/> using <see cref="Java.Nio.ByteBuffer"/> for key
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    public class KNetConsumerKeyBuffered<K, V> : KNetConsumer<K, V, Java.Nio.ByteBuffer, byte[]>
    {
        /// <summary>
        /// Initialize a new instance of <see cref="KNetConsumer{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        /// <param name="configBuilder">An instance of <see cref="ConsumerConfigBuilder"/> </param>
        /// <param name="useJVMCallback"><see langword="true"/> to active callback based mode</param>
        public KNetConsumerKeyBuffered(ConsumerConfigBuilder configBuilder, bool useJVMCallback = false)
            : base(configBuilder, useJVMCallback)
        {
        }
        /// <summary>
        /// Initialize a new instance of <see cref="KNetConsumer{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        /// <param name="props">The properties to use, see <see cref="ConsumerConfigBuilder"/></param>
        /// <param name="keyDeserializer">Key serializer base on <see cref="SerDes{K, TJVMK}"/></param>
        /// <param name="valueDeserializer">Value serializer base on <see cref="SerDes{ValueTuple, TJVMV}"/></param>
        /// <param name="useJVMCallback"><see langword="true"/> to active callback based mode</param>
        public KNetConsumerKeyBuffered(ConsumerConfigBuilder props, ISerDes<K, Java.Nio.ByteBuffer> keyDeserializer, ISerDes<V, byte[]> valueDeserializer, bool useJVMCallback = false)
            : base(props, keyDeserializer, valueDeserializer)
        {
        }
    }
    #endregion

    #region KNetConsumerValueBuffered<K, V>
    /// <summary>
    /// Extends <see cref="KNetConsumer{K, V, TJVMK, TJVMV}"/> using <see cref="Java.Nio.ByteBuffer"/> for value
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    public class KNetConsumerValueBuffered<K, V> : KNetConsumer<K, V, byte[], Java.Nio.ByteBuffer>
    {
        /// <summary>
        /// Initialize a new instance of <see cref="KNetConsumer{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        /// <param name="configBuilder">An instance of <see cref="ConsumerConfigBuilder"/> </param>
        /// <param name="useJVMCallback"><see langword="true"/> to active callback based mode</param>
        public KNetConsumerValueBuffered(ConsumerConfigBuilder configBuilder, bool useJVMCallback = false)
            : base(configBuilder, useJVMCallback)
        {
        }
        /// <summary>
        /// Initialize a new instance of <see cref="KNetConsumer{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        /// <param name="props">The properties to use, see <see cref="ConsumerConfigBuilder"/></param>
        /// <param name="keyDeserializer">Key serializer base on <see cref="SerDes{K, TJVMK}"/></param>
        /// <param name="valueDeserializer">Value serializer base on <see cref="SerDes{ValueTuple, TJVMV}"/></param>
        /// <param name="useJVMCallback"><see langword="true"/> to active callback based mode</param>
        public KNetConsumerValueBuffered(ConsumerConfigBuilder props, ISerDes<K, byte[]> keyDeserializer, ISerDes<V, Java.Nio.ByteBuffer> valueDeserializer, bool useJVMCallback = false)
            : base(props, keyDeserializer, valueDeserializer)
        {
        }
    }
    #endregion
}
