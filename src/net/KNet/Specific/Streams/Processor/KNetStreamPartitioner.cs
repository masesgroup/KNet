﻿/*
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

using Java.Lang;
using Java.Util;
using MASES.KNet.Serialization;

namespace MASES.KNet.Streams.Processor
{
    /// <summary>
    /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.Processor.StreamPartitioner{K, V}"/>
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    public class KNetStreamPartitioner<K, V> : Org.Apache.Kafka.Streams.Processor.StreamPartitioner<byte[], byte[]>, IGenericSerDesFactoryApplier
    {
        string _arg0;
        byte[] _arg1, _arg2;
        int _arg3;
        K _key;
        bool _keySet = false;
        V _value;
        bool _valueSet = false;
        IKNetSerDes<K> _kSerializer = null;
        IKNetSerDes<V> _vSerializer = null;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }
        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/StreamPartitioner.html#partitions-java.lang.String-java.lang.Object-java.lang.Object-int-"/>
        /// </summary>
        /// <remarks>If <see cref="OnPartitions"/> has a value it takes precedence over corresponding <see cref="Partitions()"/> class method</remarks>
        public new System.Func<KNetStreamPartitioner<K, V>, System.Collections.Generic.ICollection<int?>> OnPartitions { get; set; } = null;
        /// <summary>
        /// The topic name this record is sent to
        /// </summary>
        public string Topic => _arg0;
        /// <summary>
        /// The <typeparamref name="K"/> content
        /// </summary>
        public K Key { get { if (!_keySet) { _kSerializer ??= _factory.BuildKeySerDes<K>(); _key = _kSerializer.Deserialize(null, _arg1); _keySet = true; } return _key; } }
        /// <summary>
        /// The <typeparamref name="V"/> content
        /// </summary>
        public V Value { get { if (!_valueSet) { _vSerializer ??= _factory.BuildValueSerDes<V>(); _value = _vSerializer.Deserialize(null, _arg2); _valueSet = true; } return _value; } }
        /// <summary>
        /// The total number of partitions
        /// </summary>
        public int NumPartitions => _arg3;
        /// <inheritdoc/>
        public sealed override Optional<Set<Integer>> Partitions(string arg0, byte[] arg1, byte[] arg2, int arg3)
        {
            _keySet = _valueSet = false;
            _arg0 = arg0;
            _arg1 = arg1;
            _arg2 = arg2;
            _arg3 = arg3;

            var res = (OnPartitions != null) ? OnPartitions(this) : Partitions();
            if (res == null || res.Count == 0) return Optional<Set<Integer>>.Empty();
            HashSet<Integer> result = new HashSet<Integer>();
            foreach (var item in res)
            {
                result.Add(item.HasValue ? Integer.ValueOf(item.Value) : null);
            }
            return Optional<Set<Integer>>.Of(result);
        }
        /// <summary>
        /// KNet override of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/StreamPartitioner.html#partitions-java.lang.String-java.lang.Object-java.lang.Object-int-"/>
        /// </summary>
        /// <returns>An <see cref="Optional"/> of <see cref="Set"/> of <see cref="Integer"/>s between 0 and numPartitions-1, Empty optional means using default partitioner <see cref="Optional"/> of an empty set means the record won't be sent to any partitions i.e drop it. Optional of Set of integers means the partitions to which the record should be sent to.</returns>
        public virtual System.Collections.Generic.ICollection<int?> Partitions()
        {
            return null;
        }
    }
}
