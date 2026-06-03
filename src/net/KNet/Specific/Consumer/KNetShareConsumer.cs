/*
*  Copyright (c) 2021-2026 MASES s.r.l.
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
using MASES.KNet.Serialization;
using System;
using System.Collections.Concurrent;
using System.Threading;

namespace MASES.KNet.Consumer
{
    #region IShareConsumer<K, V, TJVMK, TJVMV>

    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Clients.Consumer.IShareConsumer{K, V}"/>
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
    /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
    public interface IShareConsumer<K, V, TJVMK, TJVMV> : Org.Apache.Kafka.Clients.Consumer.IShareConsumer<TJVMK, TJVMV>
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
        /// <see langword="true"/> if the <see cref="IShareConsumer{K, V, TJVMK, TJVMV}"/> instance is completing async operation
        /// </summary>
        bool IsCompleting { get; }
        /// <summary>
        /// <see langword="true"/> if the <see cref="IShareConsumer{K, V, TJVMK, TJVMV}"/> instance has an empty set of items in async operation
        /// </summary>
        bool IsEmpty { get; }
        /// <summary>
        /// Number of messages in the <see cref="IConsumer{K, V, TJVMK, TJVMV}"/> instance waiting to be processed in async operation
        /// </summary>
        [Obsolete("Use WaitingBatches")]
        int WaitingMessages { get; }
        /// <summary>
        /// Number of message batches in the <see cref="IConsumer{K, V, TJVMK, TJVMV}"/> instance waiting to be processed in async operation
        /// </summary>
        int WaitingBatches { get; }
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
        /// Sets the <see cref="Func{T, TResult}"/> to use to receive the <see cref="ConsumerRecord{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        /// <param name="cb">The callback <see cref="Func{T, TResult}"/></param>
        /// <param name="exceptionCallback">The callback receiving <see cref="Exception"/> thrown in async operations</param>
        void SetCallback(Func<ConsumerRecord<K, V, TJVMK, TJVMV>, bool> cb, Action<Exception> exceptionCallback = null);
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
        /// <param name="callback">The <see cref="Func{T, TResult}"/> where receives <see cref="ConsumerRecord{K, V, TJVMK, TJVMV}"/>; return <see langword="true"/> from <paramref name="callback"/> to dispose the object</param>
        void Consume(long timeoutMs, Func<ConsumerRecord<K, V, TJVMK, TJVMV>, bool> callback);
    }

    #endregion

    #region KNetShareConsumer<K, V, TJVMK, TJVMV>

    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Clients.Consumer.KafkaConsumer{K, V}"/>
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
    /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
    public class KNetShareConsumer<K, V, TJVMK, TJVMV> : Org.Apache.Kafka.Clients.Consumer.KafkaShareConsumer<TJVMK, TJVMV>, IShareConsumer<K, V, TJVMK, TJVMV>
    {
        readonly bool _autoCreateSerDes = false;
        bool _threadRunning = false;
        long _dequeing = 0;
        readonly System.Threading.Thread _consumeThread = null;
        readonly ConcurrentQueue<ConsumerRecords<K, V, TJVMK, TJVMV>> _consumedRecords = null;
        readonly SemaphoreSlim _releaseSignal = new SemaphoreSlim(0);
        readonly KNetConsumerCallback<K, V, TJVMK, TJVMV> _consumerCallback = null;
        readonly ISerDes<K, TJVMK> _keyDeserializer;
        readonly ISerDes<V, TJVMV> _valueDeserializer;
        /// <inheritdoc/>
        public override string BridgeClassName => "org.mases.knet.developed.clients.consumer.KNetShareConsumer";

        internal KNetShareConsumer(Properties props) : base(props) { }

        /// <summary>
        /// Initialize a new instance of <see cref="KNetShareConsumer{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        /// <param name="configBuilder">An instance of <see cref="ConsumerConfigBuilder"/> </param>
        /// <param name="useJVMCallback"><see langword="true"/> to active callback based mode</param>
        public KNetShareConsumer(ConsumerConfigBuilder configBuilder, bool useJVMCallback = false)
            : this(configBuilder, configBuilder.BuildKeySerDes<K, TJVMK>(), configBuilder.BuildValueSerDes<V, TJVMV>(), useJVMCallback)
        {
        }
        /// <summary>
        /// Initialize a new instance of <see cref="KNetShareConsumer{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        /// <param name="props">The properties to use, see <see cref="ConsumerConfigBuilder"/></param>
        /// <param name="keyDeserializer">Key serializer base on <see cref="SerDes{K, TJVMK}"/></param>
        /// <param name="valueDeserializer">Value serializer base on <see cref="SerDes{ValueTuple, TJVMV}"/></param>
        /// <param name="useJVMCallback"><see langword="true"/> to active callback based mode</param>
        public KNetShareConsumer(ConsumerConfigBuilder props, ISerDes<K, TJVMK> keyDeserializer, ISerDes<V, TJVMV> valueDeserializer, bool useJVMCallback = false)
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
                _consumeThread.Name = "KNetShareConsumer Async Consume Thread";
                _consumeThread.IsBackground = true;
                _consumeThread.Start();
            }
        }

        static Properties CheckProperties(Properties props, ISerDes keyDeserializer, ISerDes valueDeserializer)
        {
            if (!props.ContainsKey(Org.Apache.Kafka.Clients.Consumer.ConsumerConfig.KEY_DESERIALIZER_CLASS_CONFIG))
            {
                using var _ = props.Put(Org.Apache.Kafka.Clients.Consumer.ConsumerConfig.KEY_DESERIALIZER_CLASS_CONFIG, keyDeserializer.JVMDeserializerClassName) as IDisposable;
            }
            else throw new InvalidOperationException($"KNetShareConsumer auto manages configuration property {Org.Apache.Kafka.Clients.Consumer.ConsumerConfig.KEY_DESERIALIZER_CLASS_CONFIG}, remove from configuration.");

            if (!props.ContainsKey(Org.Apache.Kafka.Clients.Consumer.ConsumerConfig.VALUE_DESERIALIZER_CLASS_CONFIG))
            {
                using var _ = props.Put(Org.Apache.Kafka.Clients.Consumer.ConsumerConfig.VALUE_DESERIALIZER_CLASS_CONFIG, valueDeserializer.JVMDeserializerClassName) as IDisposable;
            }
            else throw new InvalidOperationException($"KNetShareConsumer auto manages configuration property {Org.Apache.Kafka.Clients.Consumer.ConsumerConfig.VALUE_DESERIALIZER_CLASS_CONFIG}, remove from configuration.");

            return props;
        }

        /// <inheritdoc cref="IShareConsumer{K, V, TJVMK, TJVMV}.Poll(TimeSpan)"/>
        public ConsumerRecords<K, V, TJVMK, TJVMV> Poll(TimeSpan timeout)
        {
            using Duration duration = timeout;
            var records = base.Poll(duration);
            return new ConsumerRecords<K, V, TJVMK, TJVMV>(records, _keyDeserializer, _valueDeserializer);
        }

        Func<ConsumerRecord<K, V, TJVMK, TJVMV>, bool> _actionCallback = null;
        Action<Exception> _exceptionCallback = null;

        bool CallbackMessage(ConsumerRecord<K, V, TJVMK, TJVMV> message)
        {
            return _actionCallback == null || _actionCallback.Invoke(message);
        }

        volatile int _disposed; // 0 = live, 1 = disposed

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (Interlocked.Exchange(ref _disposed, 1) == 0)
            {
                if (_consumerCallback != null)
                {
                    IExecute("setCallback", null);
                    _consumerCallback.Dispose();
                }

                _threadRunning = false;
                if (_consumedRecords != null)
                {
                    _releaseSignal.Release();
                    if (IsCompleting) { _consumeThread?.Join(); }
                    _actionCallback = null;
                }

                if (_autoCreateSerDes)
                {
                    _keyDeserializer?.Dispose();
                    _valueDeserializer?.Dispose();
                }
            }

            base.Dispose(disposing);
        }
#if NET7_0_OR_GREATER
        /// <inheritdoc cref="IShareConsumer{K, V, TJVMK, TJVMV}.ApplyPrefetch(bool, int)"/>
        public void ApplyPrefetch(bool enablePrefetch = true, int prefetchThreshold = 10)
        {
            IsPrefecth = enablePrefetch;
            PrefetchThreshold = IsPrefecth ? prefetchThreshold : 10;
        }
#endif
        /// <inheritdoc cref="IShareConsumer{K, V, TJVMK, TJVMV}.SetCallback(Func{ConsumerRecord{K, V, TJVMK, TJVMV}, bool}, Action{Exception})"/>
        public void SetCallback(Func<ConsumerRecord<K, V, TJVMK, TJVMV>, bool> cb, Action<Exception> exceptionCallback = null)
        {
            _actionCallback = cb;
            _exceptionCallback = exceptionCallback;
        }

        void ConsumeHandler(object o)
        {
            try
            {
                while (_threadRunning)
                {
                    _releaseSignal.Wait();
                    System.Threading.Interlocked.Increment(ref _dequeing);
                    try
                    {
                        while (_consumedRecords.TryDequeue(out ConsumerRecords<K, V, TJVMK, TJVMV> records))
                        {
                            try
                            {
                                using var scope = new JCOBridgeDisposeFastScope();
                                using (records)
                                {
                                    if (_actionCallback == null) continue;
                                    bool dispose = true;
                                    foreach (var item in records)
                                    {
                                        try
                                        {
                                            dispose = _actionCallback.Invoke(item);
                                        }
                                        catch (Exception e) { _exceptionCallback?.Invoke(e); }
                                        using var itemToDispose = dispose ? item : null;
                                    }
                                }
                            }
                            catch (Exception e) { _exceptionCallback?.Invoke(e); }
                        }
                    }
                    finally
                    {
                        System.Threading.Interlocked.Decrement(ref _dequeing);
                    }
                }
            }
            catch { }
            finally { JCOBridge.C2JBridge.JCOBridge.Global.LowLevelOperations.DetachThread(); }
        }
#if NET7_0_OR_GREATER
        /// <inheritdoc cref="IShareConsumer{K, V, TJVMK, TJVMV}.IsPrefecth"/>
        public bool IsPrefecth { get; private set; } = !(typeof(K).IsValueType && typeof(V).IsValueType);
        /// <inheritdoc cref="IShareConsumer{K, V, TJVMK, TJVMV}.PrefetchThreshold"/>
        public int PrefetchThreshold { get; private set; } = 10;
#endif
        /// <inheritdoc cref="IShareConsumer{K, V, TJVMK, TJVMV}.IsCompleting"/>
        public bool IsCompleting => !_consumedRecords.IsEmpty || System.Threading.Interlocked.Read(ref _dequeing) != 0;
        /// <inheritdoc cref="IShareConsumer{K, V, TJVMK, TJVMV}.IsEmpty"/>
        public bool IsEmpty => _consumedRecords.IsEmpty;
        /// <inheritdoc cref="IShareConsumer{K, V, TJVMK, TJVMV}.WaitingMessages"/>
        public int WaitingMessages => _consumedRecords.Count;
        /// <inheritdoc cref="IShareConsumer{K, V, TJVMK, TJVMV}.WaitingBatches"/>
        public int WaitingBatches => _consumedRecords.Count;
        /// <inheritdoc cref="IShareConsumer{K, V, TJVMK, TJVMV}.ConsumeAsync(long)"/>
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
                _releaseSignal.Release();
            }
            else results.Dispose();
            return !isEmpty;
        }
        /// <inheritdoc cref="IShareConsumer{K, V, TJVMK, TJVMV}.Consume(long, Func{ConsumerRecord{K, V, TJVMK, TJVMV}, bool})"/>
        public void Consume(long timeoutMs, Func<ConsumerRecord<K, V, TJVMK, TJVMV>, bool> callback)
        {
            using Duration duration = TimeSpan.FromMilliseconds(timeoutMs);
            if (_consumerCallback == null) throw new ArgumentException("Cannot be used since constructor was called with useJVMCallback set to false.");
            try
            {
                _actionCallback = callback;
                IExecute("consume", duration);
            }
            finally
            {
                _actionCallback = null;
            }
        }
    }

    #endregion

    #region KNetShareConsumer<K, V>
    /// <summary>
    /// Extends <see cref="KNetShareConsumer{K, V, TJVMK, TJVMV}"/> using array of <see cref="byte"/>
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    public class KNetShareConsumer<K, V> : KNetShareConsumer<K, V, byte[], byte[]>
    {
        /// <summary>
        /// Initialize a new instance of <see cref="KNetShareConsumer{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        /// <param name="configBuilder">An instance of <see cref="ConsumerConfigBuilder"/> </param>
        /// <param name="useJVMCallback"><see langword="true"/> to active callback based mode</param>
        public KNetShareConsumer(ConsumerConfigBuilder configBuilder, bool useJVMCallback = false)
            : base(configBuilder, useJVMCallback)
        {
        }
        /// <summary>
        /// Initialize a new instance of <see cref="KNetShareConsumer{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        /// <param name="props">The properties to use, see <see cref="ConsumerConfigBuilder"/></param>
        /// <param name="keyDeserializer">Key serializer base on <see cref="SerDes{K, TJVMK}"/></param>
        /// <param name="valueDeserializer">Value serializer base on <see cref="SerDes{ValueTuple, TJVMV}"/></param>
        /// <param name="useJVMCallback"><see langword="true"/> to active callback based mode</param>
        public KNetShareConsumer(ConsumerConfigBuilder props, ISerDes<K, byte[]> keyDeserializer, ISerDes<V, byte[]> valueDeserializer, bool useJVMCallback = false)
            : base(props, keyDeserializer, valueDeserializer)
        {
        }
    }

    #endregion

    #region KNetShareConsumerBuffered<K, V>
    /// <summary>
    /// Extends <see cref="KNetShareConsumer{K, V, TJVMK, TJVMV}"/> using <see cref="Java.Nio.ByteBuffer"/>
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    public class KNetShareConsumerBuffered<K, V> : KNetShareConsumer<K, V, Java.Nio.ByteBuffer, Java.Nio.ByteBuffer>
    {
        /// <summary>
        /// Initialize a new instance of <see cref="KNetShareConsumer{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        /// <param name="configBuilder">An instance of <see cref="ConsumerConfigBuilder"/> </param>
        /// <param name="useJVMCallback"><see langword="true"/> to active callback based mode</param>
        public KNetShareConsumerBuffered(ConsumerConfigBuilder configBuilder, bool useJVMCallback = false)
            : base(configBuilder, useJVMCallback)
        {
        }
        /// <summary>
        /// Initialize a new instance of <see cref="KNetShareConsumer{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        /// <param name="props">The properties to use, see <see cref="ConsumerConfigBuilder"/></param>
        /// <param name="keyDeserializer">Key serializer base on <see cref="SerDes{K, TJVMK}"/></param>
        /// <param name="valueDeserializer">Value serializer base on <see cref="SerDes{ValueTuple, TJVMV}"/></param>
        /// <param name="useJVMCallback"><see langword="true"/> to active callback based mode</param>
        public KNetShareConsumerBuffered(ConsumerConfigBuilder props, ISerDes<K, Java.Nio.ByteBuffer> keyDeserializer, ISerDes<V, Java.Nio.ByteBuffer> valueDeserializer, bool useJVMCallback = false)
            : base(props, keyDeserializer, valueDeserializer)
        {
        }
    }
    #endregion

    #region KNetShareConsumerKeyBuffered<K, V>
    /// <summary>
    /// Extends <see cref="KNetShareConsumer{K, V, TJVMK, TJVMV}"/> using <see cref="Java.Nio.ByteBuffer"/> for key
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    public class KNetShareConsumerKeyBuffered<K, V> : KNetShareConsumer<K, V, Java.Nio.ByteBuffer, byte[]>
    {
        /// <summary>
        /// Initialize a new instance of <see cref="KNetShareConsumer{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        /// <param name="configBuilder">An instance of <see cref="ConsumerConfigBuilder"/> </param>
        /// <param name="useJVMCallback"><see langword="true"/> to active callback based mode</param>
        public KNetShareConsumerKeyBuffered(ConsumerConfigBuilder configBuilder, bool useJVMCallback = false)
            : base(configBuilder, useJVMCallback)
        {
        }
        /// <summary>
        /// Initialize a new instance of <see cref="KNetShareConsumer{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        /// <param name="props">The properties to use, see <see cref="ConsumerConfigBuilder"/></param>
        /// <param name="keyDeserializer">Key serializer base on <see cref="SerDes{K, TJVMK}"/></param>
        /// <param name="valueDeserializer">Value serializer base on <see cref="SerDes{ValueTuple, TJVMV}"/></param>
        /// <param name="useJVMCallback"><see langword="true"/> to active callback based mode</param>
        public KNetShareConsumerKeyBuffered(ConsumerConfigBuilder props, ISerDes<K, Java.Nio.ByteBuffer> keyDeserializer, ISerDes<V, byte[]> valueDeserializer, bool useJVMCallback = false)
            : base(props, keyDeserializer, valueDeserializer)
        {
        }
    }
    #endregion

    #region KNetShareConsumerValueBuffered<K, V>
    /// <summary>
    /// Extends <see cref="KNetShareConsumer{K, V, TJVMK, TJVMV}"/> using <see cref="Java.Nio.ByteBuffer"/> for value
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    public class KNetShareConsumerValueBuffered<K, V> : KNetShareConsumer<K, V, byte[], Java.Nio.ByteBuffer>
    {
        /// <summary>
        /// Initialize a new instance of <see cref="KNetShareConsumer{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        /// <param name="configBuilder">An instance of <see cref="ConsumerConfigBuilder"/> </param>
        /// <param name="useJVMCallback"><see langword="true"/> to active callback based mode</param>
        public KNetShareConsumerValueBuffered(ConsumerConfigBuilder configBuilder, bool useJVMCallback = false)
            : base(configBuilder, useJVMCallback)
        {
        }
        /// <summary>
        /// Initialize a new instance of <see cref="KNetShareConsumer{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        /// <param name="props">The properties to use, see <see cref="ConsumerConfigBuilder"/></param>
        /// <param name="keyDeserializer">Key serializer base on <see cref="SerDes{K, TJVMK}"/></param>
        /// <param name="valueDeserializer">Value serializer base on <see cref="SerDes{ValueTuple, TJVMV}"/></param>
        /// <param name="useJVMCallback"><see langword="true"/> to active callback based mode</param>
        public KNetShareConsumerValueBuffered(ConsumerConfigBuilder props, ISerDes<K, byte[]> keyDeserializer, ISerDes<V, Java.Nio.ByteBuffer> valueDeserializer, bool useJVMCallback = false)
            : base(props, keyDeserializer, valueDeserializer)
        {
        }
    }
    #endregion
}
