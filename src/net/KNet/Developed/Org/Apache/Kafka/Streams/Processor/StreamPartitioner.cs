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

using Java.Util;
using MASES.JCOBridge.C2JBridge;
using System;

namespace Org.Apache.Kafka.Streams.Processor
{
    /// <summary>
    /// Listener for Kafka StreamPartitioner. Extends <see cref="IJVMBridgeBase"/>
    /// </summary>
    /// <typeparam name="K">The data associated to the event</typeparam>
    /// <typeparam name="V">The data associated to the event</typeparam>
    public partial interface IStreamPartitioner<K, V> : IJVMBridgeBase
    {
        /// <summary>
        /// Executes the StreamPartitioner action in the CLR
        /// </summary>
        /// <param name="topic">The StreamPartitioner object</param>
        /// <param name="key">The StreamPartitioner object</param>
        /// <param name="value">The StreamPartitioner object</param>
        /// <param name="numPartitions">The StreamPartitioner object</param>
        /// <returns>an integer between 0 and <paramref name="numPartitions"/> -1, or -1 if the default partitioning logic should be used</returns>
        int Partition(string topic, K key, V value, int numPartitions);

        /// <summary>
        /// Executes the StreamPartitioner action in the CLR
        /// </summary>
        /// <param name="topic">The StreamPartitioner object</param>
        /// <param name="key">The StreamPartitioner object</param>
        /// <param name="value">The StreamPartitioner object</param>
        /// <param name="numPartitions">The StreamPartitioner object</param>
        /// <returns>an Optional of Set of integers between 0 and <paramref name="numPartitions"/> -1, Empty optional means using default partitioner</returns>
        Optional<Set<int?>> Partitions(string topic, K key, V value, int numPartitions);
    }

    /// <summary>
    /// Listener for Kafka StreamPartitioner. Extends <see cref="JVMBridgeListener"/>, implements <see cref="IStreamPartitioner{K, V}"/>
    /// </summary>
    /// <typeparam name="K">The data associated to the event</typeparam>
    /// <typeparam name="V">The data associated to the event</typeparam>
    /// <remarks>Dispose the object to avoid a resource leak, the object contains a reference to the corresponding JVM object</remarks>
    public partial class StreamPartitioner<K, V> : IStreamPartitioner<K, V>
    {
        /// <summary>
        /// Executes the StreamPartitioner action in the CLR
        /// </summary>
        /// <param name="topic">The StreamPartitioner object</param>
        /// <param name="key">The StreamPartitioner object</param>
        /// <param name="value">The StreamPartitioner object</param>
        /// <param name="numPartitions">The StreamPartitioner object</param>
        /// <returns>an integer between 0 and <paramref name="numPartitions"/> -1, or -1 if the default partitioning logic should be used</returns>
        public virtual int Partition(string topic, K key, V value, int numPartitions) { return -1; }
    }
}
