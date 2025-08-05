/*
*  Copyright (c) 2021-2025 MASES s.r.l.
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

using Org.Apache.Kafka.Common.Header;

namespace Org.Apache.Kafka.Clients.Producer
{
    public partial class ProducerRecord<K, V>
    {
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/4.0.0/org/apache/kafka/clients/producer/ProducerRecord.html#org.apache.kafka.clients.producer.ProducerRecord(java.lang.String,java.lang.Integer,java.lang.Long,java.lang.Object,java.lang.Object,java.lang.Iterable)"/>
        /// </summary>
        public ProducerRecord(string topic, int partition, System.DateTime timestamp, K key, V value, Headers headers)
            : this(topic, partition, new System.DateTimeOffset(timestamp).ToUnixTimeMilliseconds(), key, value, headers)
        {
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/4.0.0/org/apache/kafka/clients/producer/ProducerRecord.html#org.apache.kafka.clients.producer.ProducerRecord(java.lang.String,java.lang.Integer,java.lang.Long,java.lang.Object,java.lang.Object)"/>
        /// </summary>
        public ProducerRecord(string topic, int partition, System.DateTime timestamp, K key, V value)
            : this(topic, partition, new System.DateTimeOffset(timestamp).ToUnixTimeMilliseconds(), key, value)
        {
        }
        /// <summary>
        /// <see cref="System.DateTime"/> of <see cref="Timestamp"/>
        /// </summary>
        public System.DateTime DateTime => System.DateTimeOffset.FromUnixTimeMilliseconds((long)Timestamp()).DateTime;
    }
}

