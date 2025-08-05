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

using MASES.KNet.Serialization;

namespace MASES.KNet.Consumer
{
    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Clients.Consumer.ConsumerRecord{TJVMK, TJVMV}"/>
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
    /// <typeparam name="TJVMV">The JVM type of <typeparamref name="V"/></typeparam>
    public class ConsumerRecord<K, V, TJVMK, TJVMV>: IGenericSerDesFactoryApplier
    {
        IDeserializer<K, TJVMK> _keyDeserializer;
        IDeserializer<V, TJVMV> _valueDeserializer;
        readonly Org.Apache.Kafka.Clients.Consumer.ConsumerRecord<TJVMK, TJVMV> _record;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }
        /// <summary>
        /// Initialize a new <see cref="ConsumerRecord{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        /// <param name="record">The <see cref="Org.Apache.Kafka.Clients.Consumer.ConsumerRecord{TJVMK, TJVMV}"/> to use for initialization</param>
        /// <param name="keyDeserializer">Key serializer base on <see cref="SerDes{K, TJVMK}"/></param>
        /// <param name="valueDeserializer">Value serializer base on <see cref="SerDes{V, TJVMV}"/></param>
        /// <param name="fromPrefetched">True if the initialization comes from the prefetch iterator</param>
        internal ConsumerRecord(Org.Apache.Kafka.Clients.Consumer.ConsumerRecord<TJVMK, TJVMV> record, IDeserializer<K, TJVMK> keyDeserializer, IDeserializer<V, TJVMV> valueDeserializer, bool fromPrefetched)
        {
            _record = record;
            _keyDeserializer = keyDeserializer;
            _valueDeserializer = valueDeserializer;
            if (fromPrefetched)
            {
                // the following lines will read and prepares Key, Value, Topic, Headers
                _ = Key;
                _ = Value;
            }
        }
        /// <summary>
        /// Initialize a new <see cref="ConsumerRecord{K, V, TJVMK, TJVMV}"/>
        /// </summary>
        /// <param name="record">The <see cref="Org.Apache.Kafka.Clients.Consumer.ConsumerRecord{TJVMK, TJVMV}"/> to use for initialization</param>
        /// <param name="factory"><see cref="IGenericSerDesFactory"/></param>
        internal ConsumerRecord(Org.Apache.Kafka.Clients.Consumer.ConsumerRecord<TJVMK, TJVMV> record, IGenericSerDesFactory factory)
        {
            _record = record;
            _factory = factory;
        }

        string _topic = null;
        /// <inheritdoc cref="Org.Apache.Kafka.Clients.Consumer.ConsumerRecord{K, V}.Topic"/>
        public string Topic { get { _topic ??= _record.Topic(); return _topic; } }
        /// <inheritdoc cref="Org.Apache.Kafka.Clients.Consumer.ConsumerRecord{K, V}.LeaderEpoch"/>
        public int? LeaderEpoch { get { var epoch = _record.LeaderEpoch(); return epoch.IsEmpty() ? null : epoch.Get(); } }
        int? _partition = null;
        /// <inheritdoc cref="Org.Apache.Kafka.Clients.Consumer.ConsumerRecord{K, V}.Partition"/>
        public int Partition => _partition ??= _record.Partition();
        Org.Apache.Kafka.Common.Header.Headers _headers = null;
        /// <inheritdoc cref="Org.Apache.Kafka.Clients.Consumer.ConsumerRecord{K, V}.Headers"/>
        public Org.Apache.Kafka.Common.Header.Headers Headers => _headers ??= _record.Headers();
        long? _offset = null;
        /// <inheritdoc cref="Org.Apache.Kafka.Clients.Consumer.ConsumerRecord{K, V}.Offset"/>
        public long Offset => _offset ??= _record.Offset();
        /// <inheritdoc cref="Org.Apache.Kafka.Clients.Consumer.ConsumerRecord{K, V}.DateTime"/>
        public System.DateTime DateTime => _record.DateTime;
        long? _timestamp = null;
        /// <inheritdoc cref="Org.Apache.Kafka.Clients.Consumer.ConsumerRecord{K, V}.Timestamp"/>
        public long Timestamp => _timestamp ??= _record.Timestamp();
        Org.Apache.Kafka.Common.Record.TimestampType _timestampType = null;
        /// <inheritdoc cref="Org.Apache.Kafka.Clients.Consumer.ConsumerRecord{K, V}.TimestampType"/>
        public Org.Apache.Kafka.Common.Record.TimestampType TimestampType => _timestampType ??= _record.TimestampType();
        int? _serializedKeySize = null;
        /// <inheritdoc cref="Org.Apache.Kafka.Clients.Consumer.ConsumerRecord{K, V}.SerializedKeySize"/>
        public int SerializedKeySize => _serializedKeySize ??= _record.SerializedKeySize();
        int? _serializedValueSize = null;
        /// <inheritdoc cref="Org.Apache.Kafka.Clients.Consumer.ConsumerRecord{K, V}.SerializedValueSize"/>
        public int SerializedValueSize => _serializedValueSize ??= _record.SerializedValueSize();

        bool _localKeyDes = false;
        K _localKey = default;
        /// <inheritdoc cref="Org.Apache.Kafka.Clients.Consumer.ConsumerRecord{K, V}.Key"/>
        public K Key
        {
            get
            {
                if (!_localKeyDes)
                {
                    _keyDeserializer ??= _factory?.BuildKeySerDes<K, TJVMK>();
                    _localKey = _keyDeserializer.UseHeaders ? _keyDeserializer.DeserializeWithHeaders(Topic, Headers, _record.Key()) : _keyDeserializer.Deserialize(Topic, _record.Key());
                    _localKeyDes = true;
                }
                return _localKey;
            }
        }

        bool _localValueDes = false;
        V _localValue = default;
        /// <inheritdoc cref="Org.Apache.Kafka.Clients.Consumer.ConsumerRecord{K, V}.Value"/>
        public V Value
        {
            get
            {
                if (!_localValueDes)
                {
                    _valueDeserializer ??= _factory?.BuildKeySerDes<V, TJVMV>();
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
