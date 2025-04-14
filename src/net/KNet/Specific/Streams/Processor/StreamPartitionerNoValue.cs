/*
*  Copyright 2025 MASES s.r.l.
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
using System;

namespace MASES.KNet.Streams.Processor
{
    /// <summary>
    /// KNet implementation of <see cref="StreamPartitioner{K, V, TJVMK, TJVMV}"/>
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
    public class StreamPartitionerNoValue<K, TJVMK> : StreamPartitioner<K, string, TJVMK, Java.Lang.Void>
    {
        string _arg0;
        TJVMK _arg1;
        int _arg3;
        K _key;
        bool _keySet = false;
        ISerDes<K, TJVMK> _kSerializer = null;

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/processor/StreamPartitioner.html#partitions-java.lang.String-java.lang.Object-java.lang.Object-int-"/>
        /// </summary>
        /// <remarks>If <see cref="StreamPartitionerNoValue{K, TJVMK}.OnPartitions"/> has a value it takes precedence over corresponding class method</remarks>
        public new System.Func<string, K, int, System.Collections.Generic.ICollection<int?>> OnPartitions { get; set; } = null;

        /// <inheritdoc/>
        public override string Topic => _arg0;
        /// <inheritdoc/>
        public override K Key { get { if (!_keySet) { _kSerializer ??= Factory?.BuildKeySerDes<K, TJVMK>(); _key = _kSerializer.Deserialize(null, _arg1); _keySet = true; } return _key; } }
        /// <inheritdoc/>
        public override string Value { get { throw new InvalidOperationException("Value type is Java.Lang.Void"); } }
        /// <inheritdoc/>
        public override int NumPartitions => _arg3;
        /// <inheritdoc/>
        public override Optional<Set<Integer>> Partitions(Java.Lang.String arg0, TJVMK arg1, Java.Lang.Void arg2, int arg3)
        {
            _kSerializer ??= Factory?.BuildKeySerDes<K, TJVMK>();
            _keySet = false;
            _arg0 = arg0;
            _arg1 = arg1;
            _arg3 = arg3;

            var methodToExecute = (OnPartitions != null) ? OnPartitions : Partitions;

            var res = methodToExecute(arg0, _kSerializer.Deserialize(arg0, arg1), arg3);
            if (res == null || res.Count == 0) return Optional<Set<Integer>>.Empty();
            HashSet<Integer> result = new HashSet<Integer>();
            foreach (var item in res)
            {
                result.Add(item.HasValue ? Integer.ValueOf(item.Value) : null);
            }
            return Optional<Set<Integer>>.Of(result);
        }
        /// <summary>
        /// KNet override of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/4.0.0/org/apache/kafka/streams/processor/StreamPartitioner.html#partitions-java.lang.String-java.lang.Object-java.lang.Object-int-"/>
        /// </summary>
        /// <param name="arg0">The topic name this record is sent to</param>
        /// <param name="arg1">The key of the record</param>
        /// <param name="arg2">The total number of partitions</param>
        /// <returns>An <see cref="Optional"/> of <see cref="Set"/> of <see cref="Integer"/>s between 0 and numPartitions-1, Empty optional means using default partitioner <see cref="Optional"/> of an empty set means the record won't be sent to any partitions i.e drop it. Optional of Set of integers means the partitions to which the record should be sent to.</returns>
        public virtual System.Collections.Generic.ICollection<int?> Partitions(string arg0, K arg1, int arg2)
        {
            return default;
        }
    }

    /// <summary>
    /// KNet implementation of <see cref="StreamPartitionerNoValue{K, TJVMK}"/>
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    public class StreamPartitionerNoValue<K> : StreamPartitionerNoValue<K, byte[]>
    {
    }
}
