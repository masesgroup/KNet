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
    /// <typeparam name="TKey">The key type</typeparam>
    public class KNetStreamPartitionerNoValue<TKey> : Org.Apache.Kafka.Streams.Processor.StreamPartitioner<byte[], Java.Lang.Void>, IGenericSerDesFactoryApplier
    {
        IKNetSerDes<TKey> _keySerializer = null;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }
        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/StreamPartitioner.html#partitions-java.lang.String-java.lang.Object-java.lang.Object-int-"/>
        /// </summary>
        /// <remarks>If <see cref="OnPartitions"/> has a value it takes precedence over corresponding class method</remarks>
        public new System.Func<string, TKey, int, Java.Util.Optional<Java.Util.Set<Java.Lang.Integer>>> OnPartitions { get; set; } = null;

        /// <inheritdoc/>
        public sealed override Optional<Set<Integer>> Partitions(string arg0, byte[] arg1, Java.Lang.Void arg2, int arg3)
        {
            _keySerializer ??= _factory.BuildKeySerDes<TKey>();
            var methodToExecute = (OnPartitions != null) ? OnPartitions : Partitions;
            return methodToExecute(arg0, _keySerializer.Deserialize(arg0, arg1), arg3);
        }
        /// <summary>
        /// KNet override of <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/StreamPartitioner.html#partitions-java.lang.String-java.lang.Object-java.lang.Object-int-"/>
        /// </summary>
        /// <param name="arg0">The topic name this record is sent to</param>
        /// <param name="arg1">The key of the record</param>
        /// <param name="arg2">The total number of partitions</param>
        /// <returns>An <see cref="Optional"/> of <see cref="Set"/> of <see cref="Integer"/>s between 0 and numPartitions-1, Empty optional means using default partitioner <see cref="Optional"/> of an empty set means the record won't be sent to any partitions i.e drop it. Optional of Set of integers means the partitions to which the record should be sent to.</returns>
        public virtual Optional<Set<Integer>> Partitions(string arg0, TKey arg1, int arg2)
        {
            return Optional<Set<Integer>>.Empty();
        }
    }
}
