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

using MASES.JCOBridge.C2JBridge;
using System;
using Org.Apache.Kafka.Clients.Consumer;
using MASES.KNet.Serialization;

namespace MASES.KNet.Consumer
{
    interface IKNetConsumerCallback<K, V, TJVMK, TJVMV> : IJVMBridgeBase
    {
        bool RecordReady(ConsumerRecord<K, V, TJVMK, TJVMV> message);
    }

    class KNetConsumerCallback<K, V, TJVMK, TJVMV> : JVMBridgeListener, IKNetConsumerCallback<K, V, TJVMK, TJVMV>
    {
        readonly IDeserializer<K, TJVMK> _keyDeserializer;
        readonly IDeserializer<V, TJVMV> _valueDeserializer;
        /// <inheritdoc/>
        public sealed override string BridgeClassName => "org.mases.knet.developed.clients.consumer.KNetConsumerCallback";

        readonly Func<ConsumerRecord<K, V, TJVMK, TJVMV>, bool> recordReadyFunction = null;
        public virtual Func<ConsumerRecord<K, V, TJVMK, TJVMV>, bool> OnRecordReady { get { return recordReadyFunction; } }
        public KNetConsumerCallback(Func<ConsumerRecord<K, V, TJVMK, TJVMV>, bool> recordReady, IDeserializer<K, TJVMK> keyDeserializer, IDeserializer<V, TJVMV> valueDeserializer)
        {
            if (recordReady != null) recordReadyFunction = recordReady;
            else recordReadyFunction = RecordReady;

            _keyDeserializer = keyDeserializer;
            _valueDeserializer = valueDeserializer;

            AddEventHandler("recordReady", new EventHandler<CLRListenerEventArgs<CLREventData>>(OnRecordReadyEventHandler));
        }

        void OnRecordReadyEventHandler(object sender, CLRListenerEventArgs<CLREventData> data)
        {
            var record = this.BridgeInstance.Invoke<Org.Apache.Kafka.Clients.Consumer.ConsumerRecord<TJVMK, TJVMV>>("getRecord");
            var knetRecord = new ConsumerRecord<K, V, TJVMK, TJVMV>(record, _keyDeserializer, _valueDeserializer, false);
            bool dispose = true;
            try
            {
                dispose = recordReadyFunction(knetRecord);
            }
            finally { if (dispose) knetRecord?.Dispose(); }
        }

        public virtual bool RecordReady(ConsumerRecord<K, V, TJVMK, TJVMV> message) { return true; }
    }
}
