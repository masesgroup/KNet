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

using MASES.JCOBridge.C2JBridge;
using MASES.KNet.Connect.Data;
using MASES.KNet.Connect.Header;
using System;

namespace MASES.KNet.Connect.Connector
{
    /// <summary>
    /// Base type for <see cref="MASES.KNet.Connect.Sink.SinkRecord"/> and <see cref="MASES.KNet.Connect.Source.SourceRecord"/>
    /// </summary>
    /// <typeparam name="R">The class extending <see cref="ConnectRecord{R}"/></typeparam>
    public class ConnectRecord<R> : JVMBridgeBase<ConnectRecord<R>> where R : ConnectRecord<R>
    {
        public override bool IsAbstract => true;
        public override string ClassName => "org.apache.kafka.connect.connector.ConnectRecord";

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
        public object Key => IExecute("key");
        /// <summary>
        /// KeySchema
        /// </summary>
        public Schema KeySchema => IExecute<Schema>("keySchema");
        /// <summary>
        /// Value
        /// </summary>
        public object Value => IExecute("value");
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
    }

    /// <summary>
    /// Base type for <see cref="MASES.KNet.Connect.Sink.SinkRecord{TKey, TValue}"/> and <see cref="MASES.KNet.Connect.Source.SourceRecord{TKey, TValue}"/>
    /// </summary>
    /// <typeparam name="R">The class extending <see cref="ConnectRecord{R, TKey, TValue}"/></typeparam>
    /// <typeparam name="TKey">The type of the key to be inserted in Kafka</typeparam>
    /// <typeparam name="TValue">The type of value to be inserted in Kafka</typeparam>
    public class ConnectRecord<R, TKey, TValue> : JVMBridgeBase<ConnectRecord<R, TKey, TValue>> where R : ConnectRecord<R, TKey, TValue>
    {
        public override bool IsAbstract => true;
        public override string ClassName => "org.apache.kafka.connect.connector.ConnectRecord";

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

    //public class ConnectRecord<R> : JVMBridgeBase<ConnectRecord<R>> where R : ConnectRecord<R>
    //{
    //    public override bool IsAbstract => true;
    //    public override string ClassName => "org.apache.kafka.connect.connector.ConnectRecord";

    //    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    //    public ConnectRecord()
    //    {

    //    }

    //    public ConnectRecord(string topic, int kafkaPartition,
    //                          Schema keySchema, object key,
    //                          Schema valueSchema, object value,
    //                          long timestamp)
    //        : base(topic, kafkaPartition, keySchema, key, valueSchema, value, timestamp)
    //    {
    //    }

    //    public ConnectRecord(string topic, int kafkaPartition,
    //                         Schema keySchema, object key,
    //                         Schema valueSchema, object value,
    //                         long timestamp, Iterable<Header.Header> headers)
    //         : base(topic, kafkaPartition, keySchema, key, valueSchema, value, timestamp, headers)
    //    {
    //    }

    //    protected ConnectRecord(params object[] args) : base(args)
    //    {
    //    }
    //    /// <summary>
    //    /// Topic
    //    /// </summary>
    //    public string Topic => IExecute<string>("topic");
    //    /// <summary>
    //    /// Partition
    //    /// </summary>
    //    public int KafkaPartition => IExecute<int>("kafkaPartition");
    //    /// <summary>
    //    /// Key
    //    /// </summary>
    //    public object Key => IExecute("key");
    //    /// <summary>
    //    /// KeySchema
    //    /// </summary>
    //    public Schema KeySchema => IExecute<Schema>("keySchema");
    //    /// <summary>
    //    /// Value
    //    /// </summary>
    //    public object Value => IExecute("value");
    //    /// <summary>
    //    /// ValueSchema
    //    /// </summary>
    //    public Schema ValueSchema => IExecute<Schema>("valueSchema");
    //    /// <summary>
    //    /// Timestamp
    //    /// </summary>
    //    public DateTime Timestamp => DateTimeOffset.FromUnixTimeMilliseconds(IExecute<long>("timestamp")).DateTime;
    //    /// <summary>
    //    /// The <see cref="Headers"/>
    //    /// </summary>
    //    public Headers Headers => IExecute<Headers>("headers");

    //    public R NewRecord(string topic, int kafkaPartition, Schema keySchema, object key, Schema valueSchema, object value, long timestamp) => IExecute<R>("newRecord", topic, kafkaPartition, keySchema, key, valueSchema, value, timestamp);

    //    public R NewRecord(string topic, int kafkaPartition, Schema keySchema, object key, Schema valueSchema, object value, long timestamp, Iterable<Header.Header> headers) => IExecute<R>("newRecord", topic, kafkaPartition, keySchema, key, valueSchema, value, timestamp, headers);
    //}
}
