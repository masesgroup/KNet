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
    /// <summary>
    /// Base type for <see cref="MASES.KNet.Connect.Sink.SinkRecord"/> and <see cref="MASES.KNet.Connect.Source.SourceRecord"/>
    /// </summary>
    /// <typeparam name="R">The class extending <see cref="ConnectRecord{R}"/></typeparam>
    public partial class ConnectRecord<R>
    {
        /// <summary>
        /// Timestamp
        /// </summary>
        public DateTime DateTime => DateTimeOffset.FromUnixTimeMilliseconds((long)Timestamp()).DateTime;
    }

    /// <summary>
    /// Base type for <see cref="MASES.KNet.Connect.Sink.SinkRecord{TKey, TValue}"/> and <see cref="MASES.KNet.Connect.Source.SourceRecord{TKey, TValue}"/>
    /// </summary>
    /// <typeparam name="R">The class extending <see cref="ConnectRecord{R, TKey, TValue}"/></typeparam>
    /// <typeparam name="TKey">The type of the key to be inserted in Kafka</typeparam>
    /// <typeparam name="TValue">The type of value to be inserted in Kafka</typeparam>
    public class ConnectRecord<R, TKey, TValue> : JVMBridgeBase<ConnectRecord<R, TKey, TValue>> where R : ConnectRecord<R, TKey, TValue>
    {
        public override bool IsBridgeAbstract => true;
        public override string BridgeClassName => "org.apache.kafka.connect.connector.ConnectRecord";

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public ConnectRecord()
        {
        }

        public ConnectRecord(string topic, int kafkaPartition,
                              Schema keySchema, TKey key,
                              Schema valueSchema, TValue value,
                              DateTime timestamp)
            : base(topic, kafkaPartition, keySchema, key, valueSchema, value, new DateTimeOffset(timestamp).ToUnixTimeMilliseconds())
        {
        }

        public ConnectRecord(string topic, int kafkaPartition,
                             Schema keySchema, TKey key,
                             Schema valueSchema, TValue value,
                             DateTime timestamp, Headers headers)
             : base(topic, kafkaPartition, keySchema, key, valueSchema, value, new DateTimeOffset(timestamp).ToUnixTimeMilliseconds(), headers)
        {
        }

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

        public R NewRecord(string topic, int kafkaPartition, Schema keySchema, TKey key, Schema valueSchema, TValue value, DateTime timestamp) => IExecute<R>("newRecord", topic, kafkaPartition, keySchema, key, valueSchema, value, new DateTimeOffset(timestamp).ToUnixTimeMilliseconds());

        public R NewRecord(string topic, int kafkaPartition, Schema keySchema, TKey key, Schema valueSchema, TValue value, DateTime timestamp, Headers headers) => IExecute<R>("newRecord", topic, kafkaPartition, keySchema, key, valueSchema, value, new DateTimeOffset(timestamp).ToUnixTimeMilliseconds(), headers);
    }
}
