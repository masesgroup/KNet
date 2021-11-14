﻿/*
*  Copyright 2021 MASES s.r.l.
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

namespace MASES.KafkaBridge.Clients.Producer
{
    public class ProducerRecord<K, V> : JCOBridge.C2JBridge.JVMBridgeBase<ProducerRecord<K, V>>
    {
        public override string ClassName => "org.apache.kafka.clients.producer.ProducerRecord";

        public ProducerRecord()
        {
        }

        public ProducerRecord(string topic, int partition, long timestamp, K key, V value)
            : base(topic, partition, timestamp, key, value)
        {
        }

        public ProducerRecord(string topic, int partition, K key, V value)
            : base(topic, partition, key, value)
        {
        }

        public ProducerRecord(string topic, K key, V value)
            : base(topic, key, value)
        {
        }

        public ProducerRecord(string topic, V value)
            : base(topic, value)
        {
        }

        public string Topic => (string)IExecute("topic");

        public K Key => (K)IExecute("key");

        public V Value => (V)IExecute("value");

        public long Timestamp => (long)IExecute("timestamp");

        /// <inheritdoc cref="object.ToString"/>
        public override string ToString()
        {
            if (Instance != null)
            {
                return (string) (IExecute("toString") as MASES.JCOBridge.C2JBridge.JVMInterop.IJavaObject).ToPrimitive();
            }

            return base.ToString();
        }
    }

    public class ProducerRecord : ProducerRecord<object, object>
    {
        public ProducerRecord()
        {
        }

        public ProducerRecord(string topic, int partition, long timestamp, object key, object value)
            : base(topic, partition, timestamp, key, value)
        {
        }

        public ProducerRecord(string topic, int partition, object key, object value)
            : base(topic, partition, key, value)
        {
        }

        public ProducerRecord(string topic, object key, object value)
            : base(topic, key, value)
        {
        }

        public ProducerRecord(string topic, object value)
            : base(topic, value)
        {
        }
    }
}

