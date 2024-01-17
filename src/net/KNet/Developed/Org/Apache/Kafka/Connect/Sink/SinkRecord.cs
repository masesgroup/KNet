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

using MASES.JCOBridge.C2JBridge;
using Org.Apache.Kafka.Common.Record;
using Org.Apache.Kafka.Connect.Connector;
using Org.Apache.Kafka.Connect.Data;
using Org.Apache.Kafka.Connect.Header;
using System;

namespace Org.Apache.Kafka.Connect.Sink
{
    /// <summary>
    /// Extension of <see cref="ConnectRecord{R, TKey, TValue}"/>
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class SinkRecord<TKey, TValue> : ConnectRecord<SinkRecord<TKey, TValue>, TKey, TValue>
    {
        /// <summary>
        /// <see href="https://www.jcobridge.com/api-clr/html/P_MASES_JCOBridge_C2JBridge_JVMBridgeBase_IsBridgeAbstract.htm"/>
        /// </summary>
        public override bool IsBridgeAbstract => false;
        /// <summary>
        /// <see href="https://www.jcobridge.com/api-clr/html/P_MASES_JCOBridge_C2JBridge_JVMBridgeBase_BridgeClassName.htm"/>
        /// </summary>
        public override string BridgeClassName => "org.apache.kafka.connect.sink.SinkRecord";

        /// <summary>
        /// Converts an <see cref="SinkRecord{TKey, TValue}"/> in <see cref="SinkRecord"/>
        /// </summary>
        /// <param name="source">The <see cref="SinkRecord{TKey, TValue}"/> to convert</param>
        public static implicit operator SinkRecord(SinkRecord<TKey, TValue> source) => source.Cast<SinkRecord>();
        /// <summary>
        /// Default constructor: even if the corresponding Java class does not have one, it is mandatory for JCOBridge
        /// </summary>
        public SinkRecord()
        {
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.5.0/org/apache/kafka/connect/connector/ConnectRecord.html#org.apache.kafka.connect.connector.ConnectRecord(java.lang.String,java.lang.Integer,org.apache.kafka.connect.data.Schema,java.lang.Object,org.apache.kafka.connect.data.Schema,java.lang.Object,java.lang.Long)"/>
        /// </summary>
        public SinkRecord(string topic, int partition, Schema keySchema, TKey key, Schema valueSchema, TValue value, long kafkaOffset)
            : base(topic, partition, keySchema, key, valueSchema, value, kafkaOffset)
        {
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.5.0/org/apache/kafka/connect/connector/ConnectRecord.html#org.apache.kafka.connect.connector.ConnectRecord(java.lang.String,java.lang.Integer,org.apache.kafka.connect.data.Schema,java.lang.Object,org.apache.kafka.connect.data.Schema,java.lang.Object,java.lang.Long)"/>
        /// </summary>
        public SinkRecord(string topic, int partition, Schema keySchema, TKey key, Schema valueSchema, TValue value, long kafkaOffset,
                          DateTime timestamp, TimestampType timestampType)
            : base(topic, partition, keySchema, key, valueSchema, value, kafkaOffset, timestamp, timestampType)
        {
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.5.0/org/apache/kafka/connect/connector/ConnectRecord.html#org.apache.kafka.connect.connector.ConnectRecord(java.lang.String,java.lang.Integer,org.apache.kafka.connect.data.Schema,java.lang.Object,org.apache.kafka.connect.data.Schema,java.lang.Object,java.lang.Long)"/>
        /// </summary>
        public SinkRecord(string topic, int partition, Schema keySchema, TKey key, Schema valueSchema, TValue value, long kafkaOffset,
                          DateTime timestamp, TimestampType timestampType, Headers headers)
            : base(topic, partition, keySchema, key, valueSchema, value, kafkaOffset, timestamp, timestampType, headers)
        {
        }
        /// <summary>
        /// Offset in Kafka
        /// </summary>
        public long KafkaOffset => IExecute<long>("kafkaOffset");
        /// <summary>
        /// The <see cref="Org.Apache.Kafka.Common.Record.TimestampType"/>
        /// </summary>
        public TimestampType TimestampType => IExecute<TimestampType>("timestampType");
    }
}