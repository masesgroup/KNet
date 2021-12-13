/*
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

using MASES.KafkaBridge.Common;
using MASES.KafkaBridge.Java.Util;

namespace MASES.KafkaBridge.Clients.Consumer
{
    public class KafkaConsumer<K, V> : JCOBridge.C2JBridge.JVMBridgeBase<KafkaConsumer<K, V>>
    {
        public override bool IsCloseable => true;

        public override string ClassName => "org.apache.kafka.clients.consumer.KafkaConsumer";

        public KafkaConsumer()
        {
        }

        public KafkaConsumer(Properties props)
            : base(props)
        {
        }

        public void Subscribe(Collection<string> topics)
        {
            IExecute("subscribe", topics.Instance);
        }

        public void Unsubscribe()
        {
            IExecute("unsubscribe");
        }

        public void Assign(Collection<TopicPartition> partitions)
        {
            IExecute("assign", partitions.Instance);
        }

        public ConsumerRecords<K, V> Poll(long timeoutMs)
        {
            return New<ConsumerRecords<K, V>>("poll", timeoutMs);
        }
    }

    public class KafkaConsumer : KafkaConsumer<object, object>
    {

    }
}
