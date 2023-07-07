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

using MASES.JCOBridge.C2JBridge;
using Org.Apache.Kafka.Connect.Data;
using Org.Apache.Kafka.Connect.Header;
using System;

namespace Org.Apache.Kafka.Connect.Connector
{
    public partial class ConnectRecord<R>
    {
        /// <summary>
        /// Timestamp
        /// </summary>
        public DateTime DateTime => DateTimeOffset.FromUnixTimeMilliseconds(Timestamp()).DateTime;
    }

    /// <summary>
    /// KNet helper for <see cref="Org.Apache.Kafka.Connect.Connector.ConnectRecord"/>
    /// </summary>
    /// <typeparam name="R">The class extending <see cref="ConnectRecord{R, TKey, TValue}"/></typeparam>
    /// <typeparam name="TKey">The type of the key to be inserted in Kafka</typeparam>
    /// <typeparam name="TValue">The type of value to be inserted in Kafka</typeparam>
    public class ConnectRecord<R, TKey, TValue> : JVMBridgeBase<ConnectRecord<R, TKey, TValue>> where R : ConnectRecord<R, TKey, TValue>
    {
        /// <summary>
        /// <see href="https://www.jcobridge.com/api-clr/html/P_MASES_JCOBridge_C2JBridge_JVMBridgeBase_IsBridgeAbstract.htm"/>
        /// </summary>
        public override bool IsBridgeAbstract => true;
        /// <summary>
        /// <see href="https://www.jcobridge.com/api-clr/html/P_MASES_JCOBridge_C2JBridge_JVMBridgeBase_BridgeClassName.htm"/>
        /// </summary>
        public override string BridgeClassName => "org.apache.kafka.connect.connector.ConnectRecord";

        /// <summary>
        /// Default constructor: even if the corresponding Java class does not have one, it is mandatory for JCOBridge
        /// </summary>
        public ConnectRecord()
        {
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.5.0/org/apache/kafka/connect/connector/ConnectRecord.html#org.apache.kafka.connect.connector.ConnectRecord(java.lang.String,java.lang.Integer,org.apache.kafka.connect.data.Schema,java.lang.Object,org.apache.kafka.connect.data.Schema,java.lang.Object,java.lang.Long)"/>
        /// </summary>
        public ConnectRecord(string topic, int kafkaPartition,
                              Schema keySchema, TKey key,
                              Schema valueSchema, TValue value,
                              DateTime timestamp)
            : base(topic, kafkaPartition, keySchema, key, valueSchema, value, new DateTimeOffset(timestamp).ToUnixTimeMilliseconds())
        {
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.5.0/org/apache/kafka/connect/connector/ConnectRecord.html#org.apache.kafka.connect.connector.ConnectRecord(java.lang.String,java.lang.Integer,org.apache.kafka.connect.data.Schema,java.lang.Object,org.apache.kafka.connect.data.Schema,java.lang.Object,java.lang.Long,java.lang.Iterable)"/>
        /// </summary>
        public ConnectRecord(string topic, int kafkaPartition,
                             Schema keySchema, TKey key,
                             Schema valueSchema, TValue value,
                             DateTime timestamp, Headers headers)
             : base(topic, kafkaPartition, keySchema, key, valueSchema, value, new DateTimeOffset(timestamp).ToUnixTimeMilliseconds(), headers)
        {
        }
        /// <summary>
        /// Generic constructor: it is useful for JCOBridge when there is a derived class which needs to pass arguments to the highest JVMBridgeBase class
        /// </summary>
        protected ConnectRecord(params object[] args) : base(args)
        {
        }
        /// <summary>
        /// Topic
        /// </summary>
        public string Topic => IExecute<string>("topic");
        /// <summary>
        /// Partition
        /// </summary>
        public int KafkaPartition => IExecute<int>("kafkaPartition");
        /// <summary>
        /// Key
        /// </summary>
        public TKey Key => IExecute<TKey>("key");
        /// <summary>
        /// KeySchema
        /// </summary>
        public Schema KeySchema => IExecute<Schema>("keySchema");
        /// <summary>
        /// Value
        /// </summary>
        public TValue Value => IExecute< TValue>("value");
        /// <summary>
        /// ValueSchema
        /// </summary>
        public Schema ValueSchema => IExecute<Schema>("valueSchema");
        /// <summary>
        /// Timestamp
        /// </summary>
        public DateTime Timestamp => DateTimeOffset.FromUnixTimeMilliseconds(IExecute<long>("timestamp")).DateTime;
        /// <summary>
        /// The <see cref="Headers"/>
        /// </summary>
        public Headers Headers => IExecute<Headers>("headers");
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.5.0/org/apache/kafka/connect/connector/ConnectRecord.html#newRecord-java.lang.String-java.lang.Integer-org.apache.kafka.connect.data.Schema-java.lang.Object-org.apache.kafka.connect.data.Schema-java.lang.Object-java.lang.Long-"/>
        /// </summary>
        public R NewRecord(string topic, int kafkaPartition, Schema keySchema, TKey key, Schema valueSchema, TValue value, DateTime timestamp) => IExecute<R>("newRecord", topic, kafkaPartition, keySchema, key, valueSchema, value, new DateTimeOffset(timestamp).ToUnixTimeMilliseconds());
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.5.0/org/apache/kafka/connect/connector/ConnectRecord.html#newRecord-java.lang.String-java.lang.Integer-org.apache.kafka.connect.data.Schema-java.lang.Object-org.apache.kafka.connect.data.Schema-java.lang.Object-java.lang.Long-java.lang.Iterable-"/>
        /// </summary>
        public R NewRecord(string topic, int kafkaPartition, Schema keySchema, TKey key, Schema valueSchema, TValue value, DateTime timestamp, Headers headers) => IExecute<R>("newRecord", topic, kafkaPartition, keySchema, key, valueSchema, value, new DateTimeOffset(timestamp).ToUnixTimeMilliseconds(), headers);
    }
}
