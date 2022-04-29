/*
*  Copyright 2022 MASES s.r.l.
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

using MASES.KNet.Common;
using MASES.KNet.Common.Serialization;
using Java.Time;
using Java.Util;
using Java.Util.Regex;
using MASES.JCOBridge.C2JBridge;
using System;

namespace MASES.KNet.Clients.Consumer
{
    public class Message<K, V>
    {
        readonly KNetConsumerCallback<K, V> obj;
        internal Message(KNetConsumerCallback<K, V> obj)
        {
            this.obj = obj;
        }

        //public string Topic => data.TypedEventData;

        //public int Partition => data.GetAt<int>(0);

        public K Key => obj.Instance.Invoke<K>("getKey");

        public V Value => obj.Instance.Invoke<V>("getValue");
    }

    public interface IKNetConsumerCallback<K, V> : IJVMBridgeBase
    {
        void RecordReady(Message<K, V> message);
    }

    public class KNetConsumerCallback<K, V> : JVMBridgeListener, IKNetConsumerCallback<K, V>
    {
        /// <inheritdoc cref="JVMBridgeListener.ClassName"/>
        public sealed override string ClassName => "org.mases.knet.clients.consumer.KNetConsumerCallback";

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
        void Consume(long timeoutMs, Action<Message<K, V>> callback);
    }

    public class KNetConsumer<K, V> : KafkaConsumer<K, V>, IKNetConsumer<K, V>
    {
        readonly KNetConsumerCallback<K, V> consumerCallback = null;

        public override string ClassName => "org.mases.knet.clients.consumer.KNetConsumer";

        public KNetConsumer()
        {
        }

        public KNetConsumer(Properties props)
            : base(props)
        {
            consumerCallback = new KNetConsumerCallback<K, V>(CallbackMessage);
            IExecute("setCallback", consumerCallback);
        }

        public KNetConsumer(Properties props, Deserializer<K> keyDeserializer, Deserializer<V> valueDeserializer)
            : base(props, keyDeserializer, valueDeserializer)
        {
            consumerCallback = new KNetConsumerCallback<K, V>(CallbackMessage);
            IExecute("setCallback", consumerCallback);
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
        }

        public void Consume(long timeoutMs, Action<Message<K, V>> callback)
        {
            Duration duration = TimeSpan.FromMilliseconds(timeoutMs);
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
