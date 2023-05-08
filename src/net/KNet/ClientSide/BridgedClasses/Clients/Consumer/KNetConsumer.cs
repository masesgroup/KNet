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

using MASES.KNet.Common.Serialization;
using Java.Time;
using Java.Util;
using MASES.JCOBridge.C2JBridge;
using System;
using System.Collections.Concurrent;

namespace MASES.KNet.Clients.Consumer
{
    public class Message<K, V>
    {
        readonly ConsumerRecord<K, V> record;
        readonly KNetConsumerCallback<K, V> obj;
        internal Message(KNetConsumerCallback<K, V> obj)
        {
            this.obj = obj;
        }
        internal Message(ConsumerRecord<K, V> record)
        {
            this.record = record;
        }

        public string Topic => record != null ? record.Topic : obj.BridgeInstance.Invoke<string>("getTopic");

        public int Partition => record != null ? record.Partition : obj.BridgeInstance.Invoke<int>("getPartition");

        public K Key => record != null ? record.Key : obj.BridgeInstance.Invoke<K>("getKey");

        public V Value => record != null ? record.Value : obj.BridgeInstance.Invoke<V>("getValue");
    }

    public interface IKNetConsumerCallback<K, V> : IJVMBridgeBase
    {
        void RecordReady(Message<K, V> message);
    }

    public class KNetConsumerCallback<K, V> : JVMBridgeListener, IKNetConsumerCallback<K, V>
    {
        /// <inheritdoc cref="JVMBridgeListener.ClassName"/>
         public sealed override string BridgeClassName => "org.mases.knet.clients.consumer.KNetConsumerCallback";

        readonly Action<Message<K, V>> recordReadyFunction = null;
        public virtual Action<Message<K, V>> OnRecordReady { get { return recordReadyFunction; } }
        public KNetConsumerCallback(Action<Message<K, V>> recordReady = null)
        {
            if (recordReady != null) recordReadyFunction = recordReady;
            else recordReadyFunction = RecordReady;

            AddEventHandler("recordReady", new EventHandler<CLRListenerEventArgs<CLREventData>>(OnRecordReadyEventHandler));
        }

        void OnRecordReadyEventHandler(object sender, CLRListenerEventArgs<CLREventData> data)
        {
            OnRecordReady(new Message<K, V>(this));
        }

        public virtual void RecordReady(Message<K, V> message) { }
    }

    public interface IKNetConsumer<K, V> : IConsumer<K, V>
    {
        bool IsCompleting { get; }

        bool IsEmpty { get; }

        int WaitingMessages { get; }

        void SetCallback(Action<Message<K, V>> cb);

        void ConsumeAsync(long timeoutMs);

        void Consume(long timeoutMs, Action<Message<K, V>> callback);
    }

    public class KNetConsumer<K, V> : KafkaConsumer<K, V>, IKNetConsumer<K, V>
    {
        bool threadRunning = false;
        long dequeing = 0;
        readonly System.Threading.Thread consumeThread = null;
        readonly System.Threading.ManualResetEvent threadExited = null;
        readonly ConcurrentQueue<ConsumerRecords<K, V>> consumedRecords = null;
        readonly KNetConsumerCallback<K, V> consumerCallback = null;

        public override string BridgeClassName => "org.mases.knet.clients.consumer.KNetConsumer";

        public KNetConsumer()
        {
        }

        public KNetConsumer(Properties props, bool useJVMCallback = false)
            : base(props)
        {
            if (useJVMCallback)
            {
                consumerCallback = new KNetConsumerCallback<K, V>(CallbackMessage);
                IExecute("setCallback", consumerCallback);
            }
            else
            {
                consumedRecords = new();
                threadRunning = true;
                threadExited = new(false);
                consumeThread = new(ConsumeHandler);
                consumeThread.Start();
            }
        }

        public KNetConsumer(Properties props, Deserializer<K> keyDeserializer, Deserializer<V> valueDeserializer, bool useJVMCallback = false)
            : base(props, keyDeserializer, valueDeserializer)
        {
            if (useJVMCallback)
            {
                consumerCallback = new KNetConsumerCallback<K, V>(CallbackMessage);
                IExecute("setCallback", consumerCallback);
            }
            else
            {
                consumedRecords = new();
                threadRunning = true;
                threadExited = new(false);
                consumeThread = new(ConsumeHandler);
                consumeThread.Start();
            }
        }

        Action<Message<K, V>> actionCallback = null;

        void CallbackMessage(Message<K, V> message)
        {
            actionCallback?.Invoke(message);
        }

        public override void Dispose()
        {
            base.Dispose();
            IExecute("setCallback", null);
            consumerCallback?.Dispose();
            threadRunning = false;
            if (consumedRecords != null)
            {
                lock (consumedRecords)
                {
                    System.Threading.Monitor.Pulse(consumedRecords);
                }
                while (IsCompleting) { threadExited.WaitOne(100); };
                actionCallback = null;
            }
        }

        public void SetCallback(Action<Message<K, V>> cb)
        {
            actionCallback = cb;
        }

        void ConsumeHandler(object o)
        {
            try
            {
                while (threadRunning)
                {
                    if (consumedRecords.TryDequeue(out ConsumerRecords<K, V> records))
                    {
                        System.Threading.Interlocked.Increment(ref dequeing);
                        try
                        {
                            foreach (var item in records)
                            {
                                actionCallback?.Invoke(new Message<K, V>(item));
                            }
                        }
                        catch { }
                        finally
                        {
                            System.Threading.Interlocked.Decrement(ref dequeing);
                        }
                    }
                    else
                    {
                        lock (consumedRecords)
                        {
                            System.Threading.Monitor.Wait(consumedRecords);
                        }
                    }
                }
            }
            catch { }
            finally { threadExited.Set(); threadRunning = false; }
        }

        public bool IsCompleting => !consumedRecords.IsEmpty || System.Threading.Interlocked.Read(ref dequeing) != 0;

        public bool IsEmpty => consumedRecords.IsEmpty;

        public int WaitingMessages => consumedRecords.Count;

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

        public void Consume(long timeoutMs, Action<Message<K, V>> callback)
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
