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

using Org.Apache.Kafka.Common.Header;

namespace MASES.KNet.Producer
{
    #region ProducerRecord<K, V, TJVMK, TJVMV>
    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Clients.Producer.ProducerRecord{K, V}"/>
    /// </summary>
    public class ProducerRecord<K, V, TJVMK, TJVMV>
    {
        /// <summary>
        /// Initialize a new <see cref="ProducerRecord{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        public ProducerRecord()
        {
        }
        /// <summary>
        /// Initialize a new <see cref="ProducerRecord{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        public ProducerRecord(string topic, int partition, long timestamp, K key, V value, Headers headers)
        {
            Topic = topic;
            Partition = partition;
            Timestamp = timestamp;
            Key = key;
            Value = value;
            Headers = headers;
        }
        /// <summary>
        /// Initialize a new <see cref="ProducerRecord{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        public ProducerRecord(string topic, int partition, System.DateTime timestamp, K key, V value, Headers headers)
        {
            Topic = topic;
            Partition = partition;
            Timestamp = new System.DateTimeOffset(timestamp).ToUnixTimeMilliseconds();
            Key = key;
            Value = value;
            Headers = headers;
        }
        /// <summary>
        /// Initialize a new <see cref="ProducerRecord{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        public ProducerRecord(string topic, int partition, long timestamp, K key, V value)
        {
            Topic = topic;
            Partition = partition;
            Timestamp = timestamp;
            Key = key;
            Value = value;
        }
        /// <summary>
        /// Initialize a new <see cref="ProducerRecord{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        public ProducerRecord(string topic, int partition, System.DateTime timestamp, K key, V value)
        {
            Topic = topic;
            Partition = partition;
            Timestamp = new System.DateTimeOffset(timestamp).ToUnixTimeMilliseconds();
            Key = key;
            Value = value;
        }
        /// <summary>
        /// Initialize a new <see cref="ProducerRecord{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        public ProducerRecord(string topic, int partition, K key, V value, Headers headers)
        {
            Topic = topic;
            Partition = partition;
            Key = key;
            Value = value;
            Headers = headers;
        }
        /// <summary>
        /// Initialize a new <see cref="ProducerRecord{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        public ProducerRecord(string topic, int partition, K key, V value)
        {
            Topic = topic;
            Partition = partition;
            Key = key;
            Value = value;
        }
        /// <summary>
        /// Initialize a new <see cref="ProducerRecord{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        public ProducerRecord(string topic, K key, V value)
        {
            Topic = topic;
            Key = key;
            Value = value;
        }
        /// <summary>
        /// Initialize a new <see cref="ProducerRecord{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        public ProducerRecord(string topic, V value)
        {
            Topic = topic;
            Value = value;
        }
        /// <inheritdoc cref="Org.Apache.Kafka.Clients.Producer.ProducerRecord{K, V}.Topic"/>
        public string Topic { get; private set; }
        /// <inheritdoc cref="Org.Apache.Kafka.Clients.Producer.ProducerRecord{K, V}.Partition"/>
        public int? Partition { get; private set; }
        /// <inheritdoc cref="Org.Apache.Kafka.Clients.Producer.ProducerRecord{K, V}.Key"/>
        public K Key { get; private set; }
        /// <inheritdoc cref="Org.Apache.Kafka.Clients.Producer.ProducerRecord{K, V}.Value"/>
        public V Value { get; private set; }
        /// <inheritdoc cref="Org.Apache.Kafka.Clients.Producer.ProducerRecord{K, V}.Timestamp"/>
        public long? Timestamp { get; private set; }
        /// <inheritdoc cref="Org.Apache.Kafka.Clients.Producer.ProducerRecord{K, V}.DateTime"/>
        public System.DateTime? DateTime => Timestamp.HasValue ? System.DateTimeOffset.FromUnixTimeMilliseconds(Timestamp.Value).DateTime : null;
        /// <inheritdoc cref="Org.Apache.Kafka.Clients.Producer.ProducerRecord{K, V}.Headers"/>
        public Headers Headers { get; private set; }
        /// <inheritdoc cref="object.ToString"/>
        public override string ToString()
        {
            return $"Topic: {Topic} - Partition {Partition} - Key {Key} - Value {Value}";
        }
    }

    #endregion

    #region ProducerRecord<K, V>
    /// <summary>
    /// Extends <see cref="ProducerRecord{K, V, TJVMK, TJVMV}"/> using array of <see cref="byte"/>
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    public class ProducerRecord<K, V> : ProducerRecord<K, V, byte[], byte[]>
    {
        /// <inheritdoc/>
        public ProducerRecord()
        {
        }
        /// <inheritdoc/>
        public ProducerRecord(string topic, int partition, long timestamp, K key, V value, Headers headers)
            : base(topic, partition, timestamp, key, value, headers)
        {
        }
        /// <inheritdoc/>
        public ProducerRecord(string topic, int partition, System.DateTime timestamp, K key, V value, Headers headers)
            : base(topic, partition, timestamp, key, value, headers)
        {
        }
        /// <inheritdoc/>
        public ProducerRecord(string topic, int partition, long timestamp, K key, V value)
            : base(topic, partition, timestamp, key, value)
        {
        }
        /// <inheritdoc/>
        public ProducerRecord(string topic, int partition, System.DateTime timestamp, K key, V value)
            : base(topic, partition, timestamp, key, value)
        {
        }
        /// <inheritdoc/>
        public ProducerRecord(string topic, int partition, K key, V value, Headers headers)
            : base(topic, partition, key, value, headers)
        {
        }
        /// <inheritdoc/>
        public ProducerRecord(string topic, int partition, K key, V value)
            : base(topic, partition, key, value)
        {
        }
        /// <inheritdoc/>
        public ProducerRecord(string topic, K key, V value)
            : base(topic, key, value)
        {
        }
        /// <inheritdoc/>
        public ProducerRecord(string topic, V value)
            :base(topic, value)
        {
        }
    }

    #endregion

    #region ProducerRecordBuffered<K, V>
    /// <summary>
    /// Extends <see cref="ProducerRecord{K, V, TJVMK, TJVMV}"/> using <see cref="Java.Nio.ByteBuffer"/>
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    public class ProducerRecordBuffered<K, V> : ProducerRecord<K, V, Java.Nio.ByteBuffer, Java.Nio.ByteBuffer>
    {
        /// <inheritdoc/>
        public ProducerRecordBuffered()
        {
        }
        /// <inheritdoc/>
        public ProducerRecordBuffered(string topic, int partition, long timestamp, K key, V value, Headers headers)
            : base(topic, partition, timestamp, key, value, headers)
        {
        }
        /// <inheritdoc/>
        public ProducerRecordBuffered(string topic, int partition, System.DateTime timestamp, K key, V value, Headers headers)
            : base(topic, partition, timestamp, key, value, headers)
        {
        }
        /// <inheritdoc/>
        public ProducerRecordBuffered(string topic, int partition, long timestamp, K key, V value)
            : base(topic, partition, timestamp, key, value)
        {
        }
        /// <inheritdoc/>
        public ProducerRecordBuffered(string topic, int partition, System.DateTime timestamp, K key, V value)
            : base(topic, partition, timestamp, key, value)
        {
        }
        /// <inheritdoc/>
        public ProducerRecordBuffered(string topic, int partition, K key, V value, Headers headers)
            : base(topic, partition, key, value, headers)
        {
        }
        /// <inheritdoc/>
        public ProducerRecordBuffered(string topic, int partition, K key, V value)
            : base(topic, partition, key, value)
        {
        }
        /// <inheritdoc/>
        public ProducerRecordBuffered(string topic, K key, V value)
            : base(topic, key, value)
        {
        }
        /// <inheritdoc/>
        public ProducerRecordBuffered(string topic, V value)
            : base(topic, value)
        {
        }
    }
    #endregion
}
