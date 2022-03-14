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

using Java.Lang;
using Java.Util;
using MASES.KafkaBridge.Common;

namespace MASES.KafkaBridge.Clients.Consumer
{
    public class ConsumerRecords<K, V> : JCOBridge.C2JBridge.JVMBridgeBaseEnumerable<ConsumerRecords<K, V>, ConsumerRecord<K, V>>
    {
        public override string ClassName => "org.apache.kafka.clients.consumer.ConsumerRecords";

        public List<ConsumerRecord<K, V>> Records(TopicPartition partition)
        {
            return IExecute<List<ConsumerRecord<K, V>>>("records", partition);
        }

        public Iterable<ConsumerRecord<K, V>> Records(String topic)
        {
            return IExecute<Iterable<ConsumerRecord<K, V>>>("records", topic);
        }

        public Set<TopicPartition> partitions => IExecute<Set<TopicPartition>>("partitions");

        public Iterator<ConsumerRecord<K, V>> Iterator => IExecute<Iterator<ConsumerRecord<K, V>>>("iterator");

        public int Count => IExecute<int>("count");
    }
}
