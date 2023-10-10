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

using Org.Apache.Kafka.Clients.Consumer;
using MASES.KNet.Serialization;
using Org.Apache.Kafka.Common.Header;
using Org.Apache.Kafka.Common.Record;

namespace MASES.KNet.Consumer
{
    /// <summary>
    /// KNet extension of <see cref="ConsumerRecord{K, V}"/>
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    public class KNetConsumerRecord<K, V>
    {
        readonly IKNetDeserializer<K> _keyDeserializer;
        readonly IKNetDeserializer<V> _valueDeserializer;
        readonly ConsumerRecord<byte[], byte[]> _record;
        /// <summary>
        /// Initialize a new <see cref="KNetConsumerRecord{K, V}"/>
        /// </summary>
        /// <param name="record">The <see cref="ConsumerRecord{K, V}"/> to use for initialization</param>
        /// <param name="keyDeserializer">Key serializer base on <see cref="KNetSerDes{K}"/></param>
        /// <param name="valueDeserializer">Value serializer base on <see cref="KNetSerDes{K}"/></param>
        public KNetConsumerRecord(ConsumerRecord<byte[], byte[]> record, IKNetDeserializer<K> keyDeserializer, IKNetDeserializer<V> valueDeserializer)
        {
            _record = record;
            _keyDeserializer = keyDeserializer;
            _valueDeserializer = valueDeserializer;
        }
        /// <inheritdoc cref="ConsumerRecord{K, V}.Topic"/>
        public string Topic => _record.Topic();
        /// <inheritdoc cref="ConsumerRecord{K, V}.LeaderEpoch"/>
        public int? LeaderEpoch { get { var epoch = _record.LeaderEpoch(); return epoch.IsEmpty() ? null : epoch.Get(); } }
        /// <inheritdoc cref="ConsumerRecord{K, V}.Partition"/>
        public int Partition => _record.Partition();
        /// <inheritdoc cref="ConsumerRecord{K, V}.Headers"/>
        public Headers Headers => _record.Headers();
        /// <inheritdoc cref="ConsumerRecord{K, V}.Offset"/>
        public long Offset => _record.Offset();
        /// <inheritdoc cref="ConsumerRecord{K, V}.DateTime"/>
        public System.DateTime DateTime => _record.DateTime;
        /// <inheritdoc cref="ConsumerRecord{K, V}.Timestamp"/>
        public long Timestamp => _record.Timestamp();
        /// <inheritdoc cref="ConsumerRecord{K, V}.TimestampType"/>
        public TimestampType TimestampType => _record.TimestampType();
        /// <inheritdoc cref="ConsumerRecord{K, V}.SerializedKeySize"/>
        public int SerializedKeySize => _record.SerializedKeySize();
        /// <inheritdoc cref="ConsumerRecord{K, V}.SerializedValueSize"/>
        public int SerializedValueSize => _record.SerializedValueSize();

        bool _localKeyDes = false;
        K _localKey = default;
        /// <inheritdoc cref="ConsumerRecord{K, V}.Key"/>
        public K Key
        {
            get
            {
                if (!_localKeyDes)
                {
                    _localKey = _keyDeserializer.UseHeaders ? _keyDeserializer.DeserializeWithHeaders(Topic, Headers, _record.Key()) : _keyDeserializer.Deserialize(Topic, _record.Key());
                    _localKeyDes = true;
                }
                return _localKey;
            }
        }

        bool _localValueDes = false;
        V _localValue = default;
        /// <inheritdoc cref="ConsumerRecord{K, V}.Value"/>
        public V Value
        {
            get
            {
                if (!_localValueDes)
                {
                    _localValue = _valueDeserializer.UseHeaders ? _valueDeserializer.DeserializeWithHeaders(Topic, Headers, _record.Value()) : _valueDeserializer.Deserialize(Topic, _record.Value());
                    _localValueDes = true;
                }
                return _localValue;
            }
        }
        /// <inheritdoc cref="object.ToString"/>
        public override string ToString()
        {
            return $"Topic: {Topic} - Partition {Partition} - Offset {Offset} - Key {Key} - Value {Value}";
        }
    }
}
