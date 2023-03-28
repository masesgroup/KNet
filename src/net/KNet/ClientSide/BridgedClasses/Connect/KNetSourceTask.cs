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

using Java.Lang;
using Java.Util;
using MASES.JNet.Extensions;
using Org.Apache.Kafka.Connect.Data;
using Org.Apache.Kafka.Connect.Header;
using Org.Apache.Kafka.Connect.Source;
using System;
using System.Collections.Generic;

namespace Org.Apache.Kafka.Connect
{
    /// <summary>
    /// An implementation of <see cref="KNetTask{TTask}"/> for source task
    /// </summary>
    /// <typeparam name="TTask">The class which extends <see cref="KNetSourceTask{TTask}"/></typeparam>
    public abstract class KNetSourceTask<TTask> : KNetTask<TTask>
        where TTask : KNetSourceTask<TTask>
    {
        /// <summary>
        /// Generates a <see cref="Map{string, T}"/> to be used in <see cref="SourceRecord"/>
        /// </summary>
        /// <typeparam name="T">The <paramref name="identifier"/> type</typeparam>
        /// <param name="identifier">The identifier to be associated in first, or second, parameter of a <see cref="SourceRecord"/></param>
        /// <param name="value">The value to be inserted and associated to the <paramref name="identifier"/></param>
        /// <returns>A <see cref="Map{string, K}"/></returns>
        protected Map<string, T> OffsetForKey<T>(string identifier, T value) => Collections.SingletonMap(identifier, value);
        /// <summary>
        /// Get the offset for the specified partition. If the data isn't already available locally, this gets it from the backing store, which may require some network round trips.
        /// </summary>
        /// <typeparam name="TKeySource">The type of the key set when was called <see cref="OffsetForKey{K}(string, K)"/> to generated first parameter of <see cref="SourceRecord"/></typeparam>
        /// <typeparam name="TOffset">The type of the offset set when was called <see cref="OffsetForKey{K}(string, K)"/> to generated second parameter of <see cref="SourceRecord"/></typeparam>
        /// <param name="keyName">The identifier used when was called <see cref="OffsetForKey{K}(string, K)"/></param>
        /// <param name="keyValue">The value used when was called <see cref="OffsetForKey{K}(string, K)"/></param>
        /// <returns>Return the <see cref="Map{string, TOffset}"/> associated to the element identified from <paramref name="keyName"/> and <paramref name="keyValue"/> which is an object uniquely identifying the offset in the partition of data</returns>
        protected Map<string, TOffset> OffsetAt<TKeySource, TOffset>(string keyName, TKeySource keyValue) => ExecuteOnTask<Map<string, TOffset>>("offsetAt", keyName, keyValue);

        /// <summary>
        /// The <see cref="SourceTaskContext"/>
        /// </summary>
        public SourceTaskContext Context => Context<SourceTaskContext>();
        /// <summary>
        /// Set the <see cref="ReflectedTaskClassName"/> of the connector to a fixed value
        /// </summary>
        public override string ReflectedTaskClassName => "KNetSourceTask";
        /// <summary>
        /// Public method used from Java to trigger <see cref="Poll"/>
        /// </summary>
        public void PollInternal()
        {
            var result = Poll();
            DataToExchange(result.ToJCollection());
        }
        /// <summary>
        /// Implement the method to execute the Poll action
        /// </summary>
        /// <returns>The list of <see cref="SourceRecord"/> to return to Apache Kafka Connect framework</returns>
        public abstract IList<SourceRecord> Poll();
        /// <summary>
        /// Creates a new <see cref="SourceRecord{TKey, TValue}"/>
        /// </summary>
        /// <typeparam name="TKey">The type of the key to be inserted in Kafka</typeparam>
        /// <typeparam name="TValue">The type of value to be inserted in Kafka</typeparam>
        /// <param name="topic">The name of the topic; may be null</param>
        /// <param name="partition">The partition number for the Kafka topic; may be null</param>
        /// <param name="valueSchema">The schema for the value; may be null</param>
        /// <param name="value">The value; may be null</param>
        /// <returns>A newvly allocated <see cref="SourceRecord{TKey, TValue}"/></returns>
        /// <remarks>These values can have arbitrary structure and should be represented using Org.Apache.Kafka.Connect.Data.* objects (or primitive values). 
        /// For example, a database connector might specify the <paramref name="sourcePartition"/> as a record containing { "db": "database_name", "table": "table_name"} and the <paramref name="sourceOffset"/> as a <see langword="long"/> containing the timestamp of the row.</remarks>
        public SourceRecord<TKey, TValue> CreateRecord<TKey, TValue>(string topic, int? partition, Schema valueSchema, TValue value)

        {
            return new SourceRecord<TKey, TValue>(null, null, topic, partition, valueSchema, value);
        }
        /// <summary>
        /// Creates a new <see cref="SourceRecord{TKey, TValue}"/>
        /// </summary>
        /// <typeparam name="TKey">The type of the key to be inserted in Kafka</typeparam>
        /// <typeparam name="TValue">The type of value to be inserted in Kafka</typeparam>
        /// <param name="topic">The name of the topic; may be null</param>
        /// <param name="valueSchema">The schema for the value; may be null</param>
        /// <param name="value">The value; may be null</param>
        /// <returns>A newvly allocated <see cref="SourceRecord{TKey, TValue}"/></returns>
        /// <remarks>These values can have arbitrary structure and should be represented using Org.Apache.Kafka.Connect.Data.* objects (or primitive values). 
        /// For example, a database connector might specify the <paramref name="sourcePartition"/> as a record containing { "db": "database_name", "table": "table_name"} and the <paramref name="sourceOffset"/> as a <see langword="long"/> containing the timestamp of the row.</remarks>
        public SourceRecord<TKey, TValue> CreateRecord<TKey, TValue>(string topic, Schema valueSchema, TValue value)

        {
            return new SourceRecord<TKey, TValue>(null, null, topic, valueSchema, value);
        }
        /// <summary>
        /// Creates a new <see cref="SourceRecord{TKey, TValue}"/>
        /// </summary>
        /// <typeparam name="TKey">The type of the key to be inserted in Kafka</typeparam>
        /// <typeparam name="TValue">The type of value to be inserted in Kafka</typeparam>
        /// <param name="topic">The name of the topic; may be null</param>
        /// <param name="keySchema">The schema for the key; may be null</param>
        /// <param name="key">The key; may be null</param>
        /// <param name="valueSchema">The schema for the value; may be null</param>
        /// <param name="value">The value; may be null</param>
        /// <returns>A newvly allocated <see cref="SourceRecord{TKey, TValue}"/></returns>
        /// <remarks>These values can have arbitrary structure and should be represented using Org.Apache.Kafka.Connect.Data.* objects (or primitive values). 
        /// For example, a database connector might specify the <paramref name="sourcePartition"/> as a record containing { "db": "database_name", "table": "table_name"} and the <paramref name="sourceOffset"/> as a <see langword="long"/> containing the timestamp of the row.</remarks>
        public SourceRecord<TKey, TValue> CreateRecord<TKey, TValue>(string topic, Schema keySchema, TKey key, Schema valueSchema, TValue value)

        {
            return new SourceRecord<TKey, TValue>(null, null, topic, keySchema, key, valueSchema, value);
        }
        /// <summary>
        /// Creates a new <see cref="SourceRecord{TKey, TValue}"/>
        /// </summary>
        /// <typeparam name="TKey">The type of the key to be inserted in Kafka</typeparam>
        /// <typeparam name="TValue">The type of value to be inserted in Kafka</typeparam>
        /// <param name="topic">The name of the topic; may be null</param>
        /// <param name="partition">The partition number for the Kafka topic; may be null</param>
        /// <param name="keySchema">The schema for the key; may be null</param>
        /// <param name="key">The key; may be null</param>
        /// <param name="valueSchema">The schema for the value; may be null</param>
        /// <param name="value">The value; may be null</param>
        /// <returns>A newvly allocated <see cref="SourceRecord{TKey, TValue}"/></returns>
        /// <remarks>These values can have arbitrary structure and should be represented using Org.Apache.Kafka.Connect.Data.* objects (or primitive values). 
        /// For example, a database connector might specify the <paramref name="sourcePartition"/> as a record containing { "db": "database_name", "table": "table_name"} and the <paramref name="sourceOffset"/> as a <see langword="long"/> containing the timestamp of the row.</remarks>
        public SourceRecord<TKey, TValue> CreateRecord<TKey, TValue>(string topic, int? partition, Schema keySchema, TKey key, Schema valueSchema, TValue value)

        {
            return new SourceRecord<TKey, TValue>(null, null, topic, partition, keySchema, key, valueSchema, value);
        }
        /// <summary>
        /// Creates a new <see cref="SourceRecord{TKey, TValue}"/>
        /// </summary>
        /// <typeparam name="TKey">The type of the key to be inserted in Kafka</typeparam>
        /// <typeparam name="TValue">The type of value to be inserted in Kafka</typeparam>
        /// <param name="topic">The name of the topic; may be null</param>
        /// <param name="valueSchema">The schema for the value; may be null</param>
        /// <param name="value">The value; may be null</param>
        /// <param name="timestamp">The timestamp; may be null</param>
        /// <returns>A newvly allocated <see cref="SourceRecord{TKey, TValue}"/></returns>
        /// <remarks>These values can have arbitrary structure and should be represented using Org.Apache.Kafka.Connect.Data.* objects (or primitive values). 
        /// For example, a database connector might specify the <paramref name="sourcePartition"/> as a record containing { "db": "database_name", "table": "table_name"} and the <paramref name="sourceOffset"/> as a <see langword="long"/> containing the timestamp of the row.</remarks>
        public SourceRecord<object, TValue> CreateRecord<TValue>(string topic, Schema valueSchema, TValue value, DateTime timestamp)

        {
            return new SourceRecord<object, TValue>(null, null, topic, null, null, null, valueSchema, value, timestamp);
        }
        /// <summary>
        /// Creates a new <see cref="SourceRecord{TKey, TValue}"/>
        /// </summary>
        /// <typeparam name="TKey">The type of the key to be inserted in Kafka</typeparam>
        /// <typeparam name="TValue">The type of value to be inserted in Kafka</typeparam>
        /// <param name="topic">The name of the topic; may be null</param>
        /// <param name="partition">The partition number for the Kafka topic; may be null</param>
        /// <param name="valueSchema">The schema for the value; may be null</param>
        /// <param name="value">The value; may be null</param>
        /// <param name="timestamp">The timestamp; may be null</param>
        /// <returns>A newvly allocated <see cref="SourceRecord{TKey, TValue}"/></returns>
        /// <remarks>These values can have arbitrary structure and should be represented using Org.Apache.Kafka.Connect.Data.* objects (or primitive values). 
        /// For example, a database connector might specify the <paramref name="sourcePartition"/> as a record containing { "db": "database_name", "table": "table_name"} and the <paramref name="sourceOffset"/> as a <see langword="long"/> containing the timestamp of the row.</remarks>
        public SourceRecord<object, TValue> CreateRecord<TValue>(string topic, int? partition,
                                                                     Schema valueSchema, TValue value,
                                                                     DateTime timestamp)

        {
            return new SourceRecord<object, TValue>(null, null, topic, partition, null, null, valueSchema, value, timestamp);
        }
        /// <summary>
        /// Creates a new <see cref="SourceRecord{TKey, TValue}"/>
        /// </summary>
        /// <typeparam name="TKey">The type of the key to be inserted in Kafka</typeparam>
        /// <typeparam name="TValue">The type of value to be inserted in Kafka</typeparam>
        /// <param name="topic">The name of the topic; may be null</param>
        /// <param name="partition">The partition number for the Kafka topic; may be null</param>
        /// <param name="keySchema">The schema for the key; may be null</param>
        /// <param name="key">The key; may be null</param>
        /// <param name="valueSchema">The schema for the value; may be null</param>
        /// <param name="value">The value; may be null</param>
        /// <param name="timestamp">The timestamp; may be null</param>
        /// <returns>A newvly allocated <see cref="SourceRecord{TKey, TValue}"/></returns>
        /// <remarks>These values can have arbitrary structure and should be represented using Org.Apache.Kafka.Connect.Data.* objects (or primitive values). 
        /// For example, a database connector might specify the <paramref name="sourcePartition"/> as a record containing { "db": "database_name", "table": "table_name"} and the <paramref name="sourceOffset"/> as a <see langword="long"/> containing the timestamp of the row.</remarks>
        public SourceRecord<TKey, TValue> CreateRecord<TKey, TValue>(string topic, int? partition,
                                                                     Schema keySchema, TKey key,
                                                                     Schema valueSchema, TValue value,
                                                                     DateTime timestamp)

        {
            return new SourceRecord<TKey, TValue>(null, null, topic, partition, keySchema, key, valueSchema, value, timestamp);
        }
        /// <summary>
        /// Creates a new <see cref="SourceRecord{TKey, TValue}"/>
        /// </summary>
        /// <typeparam name="TKey">The type of the key to be inserted in Kafka</typeparam>
        /// <typeparam name="TValue">The type of value to be inserted in Kafka</typeparam>
        /// <param name="topic">The name of the topic; may be null</param>
        /// <param name="partition">The partition number for the Kafka topic; may be null</param>
        /// <param name="keySchema">The schema for the key; may be null</param>
        /// <param name="key">The key; may be null</param>
        /// <param name="valueSchema">The schema for the value; may be null</param>
        /// <param name="value">The value; may be null</param>
        /// <param name="timestamp">The timestamp; may be null</param>
        /// <param name="headers">The <see cref="Headers"/>s; may be null or empty</param>
        /// <returns>A newvly allocated <see cref="SourceRecord{TKey, TValue}"/></returns>
        /// <remarks>These values can have arbitrary structure and should be represented using Org.Apache.Kafka.Connect.Data.* objects (or primitive values). 
        /// For example, a database connector might specify the <paramref name="sourcePartition"/> as a record containing { "db": "database_name", "table": "table_name"} and the <paramref name="sourceOffset"/> as a <see langword="long"/> containing the timestamp of the row.</remarks>
        public SourceRecord<TKey, TValue> CreateRecord<TKey, TValue>(string topic, int? partition,
                                                                     Schema keySchema, TKey key,
                                                                     Schema valueSchema, TValue value,
                                                                     DateTime timestamp, Headers headers)

        {
            return new SourceRecord<TKey, TValue>(null, null, topic, partition, keySchema, key, valueSchema, value, timestamp, headers);
        }

        /// <summary>
        /// Creates a new <see cref="SourceRecord{TKeySource, TOffset, TKey, TValue}"/>
        /// </summary>
        /// <typeparam name="TKeySource">The type within <see cref="Map{string, TKeySource}"/> of <paramref name="sourcePartition"/></typeparam>
        /// <typeparam name="TOffset">The type within <see cref="Map{string, TOffset}"/> of <paramref name="sourceOffset"/></typeparam>
        /// <param name="sourcePartition">The parameter represents a single input sourcePartition that the record came from (e.g. a filename, table name, or topic-partition).</param>
        /// <param name="sourceOffset">The parameter represents a position in that <paramref name="sourcePartition"/> which can be used to resume consumption of data.</param>
        /// <param name="topic">The name of the topic; may be null</param>
        /// <param name="partition">The partition number for the Kafka topic; may be null</param>
        /// <param name="valueSchema">The schema for the value; may be null</param>
        /// <param name="value">The value; may be null</param>
        /// <returns>A newvly allocated <see cref="SourceRecord{TKeySource, TOffset, TKey, TValue}"/></returns>
        /// <remarks>These values can have arbitrary structure and should be represented using Org.Apache.Kafka.Connect.Data.* objects (or primitive values). 
        /// For example, a database connector might specify the <paramref name="sourcePartition"/> as a record containing { "db": "database_name", "table": "table_name"} and the <paramref name="sourceOffset"/> as a <see langword="long"/> containing the timestamp of the row.</remarks>
        public SourceRecord<TKeySource, TOffset, TKey, TValue> CreateRecord<TKeySource, TOffset, TKey, TValue>(Map<string, TKeySource> sourcePartition, Map<string, TOffset> sourceOffset,
                                                                                                               string topic, int? partition, Schema valueSchema, TValue value)

        {
            return new SourceRecord<TKeySource, TOffset, TKey, TValue>(sourcePartition, sourceOffset, topic, partition, valueSchema, value);
        }
        /// <summary>
        /// Creates a new <see cref="SourceRecord{TKeySource, TOffset, TKey, TValue}"/>
        /// </summary>
        /// <typeparam name="TKey">The type within <see cref="Map{string, TKey}"/> of <paramref name="sourcePartition"/></typeparam>
        /// <typeparam name="TOffset">The type within <see cref="Map{string, TOffset}"/> of <paramref name="sourceOffset"/></typeparam>
        /// <param name="sourcePartition">The parameter represents a single input sourcePartition that the record came from (e.g. a filename, table name, or topic-partition).</param>
        /// <param name="sourceOffset">The parameter represents a position in that <paramref name="sourcePartition"/> which can be used to resume consumption of data.</param>
        /// <param name="topic">The name of the topic; may be null</param>
        /// <param name="valueSchema">The schema for the value; may be null</param>
        /// <param name="value">The value; may be null</param>
        /// <returns>A newvly allocated <see cref="SourceRecord{TKeySource, TOffset, TKey, TValue}"/></returns>
        /// <remarks>These values can have arbitrary structure and should be represented using Org.Apache.Kafka.Connect.Data.* objects (or primitive values). 
        /// For example, a database connector might specify the <paramref name="sourcePartition"/> as a record containing { "db": "database_name", "table": "table_name"} and the <paramref name="sourceOffset"/> as a <see langword="long"/> containing the timestamp of the row.</remarks>
        public SourceRecord<TKeySource, TOffset, TKey, TValue> CreateRecord<TKeySource, TOffset, TKey, TValue>(Map<string, TKeySource> sourcePartition, Map<string, TOffset> sourceOffset,
                                                                                                               string topic, Schema valueSchema, TValue value)

        {
            return new SourceRecord<TKeySource, TOffset, TKey, TValue>(sourcePartition, sourceOffset, topic, valueSchema, value);
        }
        /// <summary>
        /// Creates a new <see cref="SourceRecord{TKeySource, TOffset, TKey, TValue}"/>
        /// </summary>
        /// <typeparam name="TKey">The type within <see cref="Map{string, TKey}"/> of <paramref name="sourcePartition"/></typeparam>
        /// <typeparam name="TOffset">The type within <see cref="Map{string, TOffset}"/> of <paramref name="sourceOffset"/></typeparam>
        /// <param name="sourcePartition">The parameter represents a single input sourcePartition that the record came from (e.g. a filename, table name, or topic-partition).</param>
        /// <param name="sourceOffset">The parameter represents a position in that <paramref name="sourcePartition"/> which can be used to resume consumption of data.</param>
        /// <param name="topic">The name of the topic; may be null</param>
        /// <param name="keySchema">The schema for the key; may be null</param>
        /// <param name="key">The key; may be null</param>
        /// <param name="valueSchema">The schema for the value; may be null</param>
        /// <param name="value">The value; may be null</param>
        /// <returns>A newvly allocated <see cref="SourceRecord{TKeySource, TOffset, TKey, TValue}"/></returns>
        /// <remarks>These values can have arbitrary structure and should be represented using Org.Apache.Kafka.Connect.Data.* objects (or primitive values). 
        /// For example, a database connector might specify the <paramref name="sourcePartition"/> as a record containing { "db": "database_name", "table": "table_name"} and the <paramref name="sourceOffset"/> as a <see langword="long"/> containing the timestamp of the row.</remarks>
        public SourceRecord<TKeySource, TOffset, TKey, TValue> CreateRecord<TKeySource, TOffset, TKey, TValue>(Map<string, TKeySource> sourcePartition, Map<string, TOffset> sourceOffset,
                                                                                                               string topic, Schema keySchema, TKey key, 
                                                                                                               Schema valueSchema, TValue value)

        {
            return new SourceRecord<TKeySource, TOffset, TKey, TValue>(sourcePartition, sourceOffset, topic, keySchema, key, valueSchema, value);
        }
        /// <summary>
        /// Creates a new <see cref="SourceRecord{TKeySource, TOffset, TKey, TValue}"/>
        /// </summary>
        /// <typeparam name="TKey">The type within <see cref="Map{string, TKey}"/> of <paramref name="sourcePartition"/></typeparam>
        /// <typeparam name="TOffset">The type within <see cref="Map{string, TOffset}"/> of <paramref name="sourceOffset"/></typeparam>
        /// <param name="sourcePartition">The parameter represents a single input sourcePartition that the record came from (e.g. a filename, table name, or topic-partition).</param>
        /// <param name="sourceOffset">The parameter represents a position in that <paramref name="sourcePartition"/> which can be used to resume consumption of data.</param>
        /// <param name="topic">The name of the topic; may be null</param>
        /// <param name="partition">The partition number for the Kafka topic; may be null</param>
        /// <param name="keySchema">The schema for the key; may be null</param>
        /// <param name="key">The key; may be null</param>
        /// <param name="valueSchema">The schema for the value; may be null</param>
        /// <param name="value">The value; may be null</param>
        /// <returns>A newvly allocated <see cref="SourceRecord{TKeySource, TOffset, TKey, TValue}"/></returns>
        /// <remarks>These values can have arbitrary structure and should be represented using Org.Apache.Kafka.Connect.Data.* objects (or primitive values). 
        /// For example, a database connector might specify the <paramref name="sourcePartition"/> as a record containing { "db": "database_name", "table": "table_name"} and the <paramref name="sourceOffset"/> as a <see langword="long"/> containing the timestamp of the row.</remarks>
        public SourceRecord<TKeySource, TOffset, TKey, TValue> CreateRecord<TKeySource, TOffset, TKey, TValue>(Map<string, TKeySource> sourcePartition, Map<string, TOffset> sourceOffset,
                                                                                                               string topic, int? partition, Schema keySchema, TKey key, Schema valueSchema, TValue value)

        {
            return new SourceRecord<TKeySource, TOffset, TKey, TValue>(sourcePartition, sourceOffset, topic, partition, keySchema, key, valueSchema, value);
        }
        /// <summary>
        /// Creates a new <see cref="SourceRecord{TKeySource, TOffset, TKey, TValue}"/>
        /// </summary>
        /// <typeparam name="TKey">The type within <see cref="Map{string, TKey}"/> of <paramref name="sourcePartition"/></typeparam>
        /// <typeparam name="TOffset">The type within <see cref="Map{string, TOffset}"/> of <paramref name="sourceOffset"/></typeparam>
        /// <param name="sourcePartition">The parameter represents a single input sourcePartition that the record came from (e.g. a filename, table name, or topic-partition).</param>
        /// <param name="sourceOffset">The parameter represents a position in that <paramref name="sourcePartition"/> which can be used to resume consumption of data.</param>
        /// <param name="topic">The name of the topic; may be null</param>
        /// <param name="valueSchema">The schema for the value; may be null</param>
        /// <param name="value">The value; may be null</param>
        /// <param name="timestamp">The timestamp; may be null</param>
        /// <returns>A newvly allocated <see cref="SourceRecord{TKeySource, TOffset, TKey, TValue}"/></returns>
        /// <remarks>These values can have arbitrary structure and should be represented using Org.Apache.Kafka.Connect.Data.* objects (or primitive values). 
        /// For example, a database connector might specify the <paramref name="sourcePartition"/> as a record containing { "db": "database_name", "table": "table_name"} and the <paramref name="sourceOffset"/> as a <see langword="long"/> containing the timestamp of the row.</remarks>
        public SourceRecord<TKeySource, TOffset, object, TValue> CreateRecord<TKeySource, TOffset, TValue>(Map<string, TKeySource> sourcePartition, Map<string, TOffset> sourceOffset,
                                                                                                           string topic, Schema valueSchema, TValue value, DateTime timestamp)

        {
            return new SourceRecord<TKeySource, TOffset, object, TValue>(sourcePartition, sourceOffset, topic, null, null, null, valueSchema, value, timestamp);
        }
        /// <summary>
        /// Creates a new <see cref="SourceRecord{TKeySource, TOffset, TKey, TValue}"/>
        /// </summary>
        /// <typeparam name="TKey">The type within <see cref="Map{string, TKey}"/> of <paramref name="sourcePartition"/></typeparam>
        /// <typeparam name="TOffset">The type within <see cref="Map{string, TOffset}"/> of <paramref name="sourceOffset"/></typeparam>
        /// <param name="sourcePartition">The parameter represents a single input sourcePartition that the record came from (e.g. a filename, table name, or topic-partition).</param>
        /// <param name="sourceOffset">The parameter represents a position in that <paramref name="sourcePartition"/> which can be used to resume consumption of data.</param>
        /// <param name="topic">The name of the topic; may be null</param>
        /// <param name="partition">The partition number for the Kafka topic; may be null</param>
        /// <param name="valueSchema">The schema for the value; may be null</param>
        /// <param name="value">The value; may be null</param>
        /// <param name="timestamp">The timestamp; may be null</param>
        /// <returns>A newvly allocated <see cref="SourceRecord{TKeySource, TOffset, TKey, TValue}"/></returns>
        /// <remarks>These values can have arbitrary structure and should be represented using Org.Apache.Kafka.Connect.Data.* objects (or primitive values). 
        /// For example, a database connector might specify the <paramref name="sourcePartition"/> as a record containing { "db": "database_name", "table": "table_name"} and the <paramref name="sourceOffset"/> as a <see langword="long"/> containing the timestamp of the row.</remarks>
        public SourceRecord<TKeySource, TOffset, object, TValue> CreateRecord<TKeySource, TOffset, TValue>(Map<string, TKeySource> sourcePartition, Map<string, TOffset> sourceOffset,
                                                                                                           string topic, int? partition,
                                                                                                           Schema valueSchema, TValue value,
                                                                                                           DateTime timestamp)

        {
            return new SourceRecord<TKeySource, TOffset, object, TValue>(sourcePartition, sourceOffset, topic, partition, null, null, valueSchema, value, timestamp);
        }
        /// <summary>
        /// Creates a new <see cref="SourceRecord{TKeySource, TOffset, TKey, TValue}"/>
        /// </summary>
        /// <typeparam name="TKey">The type within <see cref="Map{string, TKey}"/> of <paramref name="sourcePartition"/></typeparam>
        /// <typeparam name="TOffset">The type within <see cref="Map{string, TOffset}"/> of <paramref name="sourceOffset"/></typeparam>
        /// <param name="sourcePartition">The parameter represents a single input sourcePartition that the record came from (e.g. a filename, table name, or topic-partition).</param>
        /// <param name="sourceOffset">The parameter represents a position in that <paramref name="sourcePartition"/> which can be used to resume consumption of data.</param>
        /// <param name="topic">The name of the topic; may be null</param>
        /// <param name="partition">The partition number for the Kafka topic; may be null</param>
        /// <param name="keySchema">The schema for the key; may be null</param>
        /// <param name="key">The key; may be null</param>
        /// <param name="valueSchema">The schema for the value; may be null</param>
        /// <param name="value">The value; may be null</param>
        /// <param name="timestamp">The timestamp; may be null</param>
        /// <returns>A newvly allocated <see cref="SourceRecord{TKeySource, TOffset, TKey, TValue}"/></returns>
        /// <remarks>These values can have arbitrary structure and should be represented using Org.Apache.Kafka.Connect.Data.* objects (or primitive values). 
        /// For example, a database connector might specify the <paramref name="sourcePartition"/> as a record containing { "db": "database_name", "table": "table_name"} and the <paramref name="sourceOffset"/> as a <see langword="long"/> containing the timestamp of the row.</remarks>
        public SourceRecord<TKeySource, TOffset, TKey, TValue> CreateRecord<TKeySource, TOffset, TKey, TValue>(Map<string, TKeySource> sourcePartition, Map<string, TOffset> sourceOffset,
                                                                                                               string topic, int? partition,
                                                                                                               Schema keySchema, TKey key,
                                                                                                               Schema valueSchema, TValue value,
                                                                                                               DateTime timestamp)

        {
            return new SourceRecord<TKeySource, TOffset, TKey, TValue>(sourcePartition, sourceOffset, topic, partition, keySchema, key, valueSchema, value, timestamp);
        }
        /// <summary>
        /// Creates a new <see cref="SourceRecord{TKeySource, TOffset, TKey, TValue}"/>
        /// </summary>
        /// <typeparam name="TKey">The type within <see cref="Map{string, TKey}"/> of <paramref name="sourcePartition"/></typeparam>
        /// <typeparam name="TOffset">The type within <see cref="Map{string, TOffset}"/> of <paramref name="sourceOffset"/></typeparam>
        /// <param name="sourcePartition">The parameter represents a single input sourcePartition that the record came from (e.g. a filename, table name, or topic-partition).</param>
        /// <param name="sourceOffset">The parameter represents a position in that <paramref name="sourcePartition"/> which can be used to resume consumption of data.</param>
        /// <param name="topic">The name of the topic; may be null</param>
        /// <param name="partition">The partition number for the Kafka topic; may be null</param>
        /// <param name="keySchema">The schema for the key; may be null</param>
        /// <param name="key">The key; may be null</param>
        /// <param name="valueSchema">The schema for the value; may be null</param>
        /// <param name="value">The value; may be null</param>
        /// <param name="timestamp">The timestamp; may be null</param>
        /// <param name="headers">The <see cref="Headers"/>s; may be null or empty</param>
        /// <returns>A newvly allocated <see cref="SourceRecord{TKeySource, TOffset, TKey, TValue}"/></returns>
        /// <remarks>These values can have arbitrary structure and should be represented using Org.Apache.Kafka.Connect.Data.* objects (or primitive values). 
        /// For example, a database connector might specify the <paramref name="sourcePartition"/> as a record containing { "db": "database_name", "table": "table_name"} and the <paramref name="sourceOffset"/> as a <see langword="long"/> containing the timestamp of the row.</remarks>
        public SourceRecord<TKeySource, TOffset, TKey, TValue> CreateRecord<TKeySource, TOffset, TKey, TValue>(Map<string, TKeySource> sourcePartition, Map<string, TOffset> sourceOffset,
                                                                                                               string topic, int? partition,
                                                                                                               Schema keySchema, TKey key,
                                                                                                               Schema valueSchema, TValue value,
                                                                                                               DateTime timestamp, Headers headers)

        {
            return new SourceRecord<TKeySource, TOffset, TKey, TValue>(sourcePartition, sourceOffset, topic, partition, keySchema, key, valueSchema, value, timestamp, headers);
        }
    }
}
