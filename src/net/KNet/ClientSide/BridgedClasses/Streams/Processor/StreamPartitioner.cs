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

namespace MASES.KNet.Streams.Processor
{
    /// <summary>
    /// Listener for Kafka StreamPartitioner. Extends <see cref="IJVMBridgeBase"/>
    /// </summary>
    /// <typeparam name="K">The data associated to the event</typeparam>
    /// <typeparam name="V">The data associated to the event</typeparam>
    public interface IStreamPartitioner<K, V> : IJVMBridgeBase
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
        Optional<Set<Java.Lang.Integer>> Partitions(string topic, K key, V value, int numPartitions);
    }

    /// <summary>
    /// Listener for Kafka StreamPartitioner. Extends <see cref="JVMBridgeListener"/>, implements <see cref="IStreamPartitioner{K, V}"/>
    /// </summary>
    /// <typeparam name="K">The data associated to the event</typeparam>
    /// <typeparam name="V">The data associated to the event</typeparam>
    /// <remarks>Dispose the object to avoid a resource leak, the object contains a reference to the corresponding JVM object</remarks>
    public class StreamPartitioner<K, V> : JVMBridgeListener, IStreamPartitioner<K, V>
    {
        /// <inheritdoc cref="JVMBridgeListener.ClassName"/>
         public sealed override string BridgeClassName => "org.mases.knet.streams.kstream.StreamPartitionerImpl";

        readonly Func<string, K, V, int, int> executionFunctionPartition = null;
        readonly Func<string, K, V, int, Optional<Set<Java.Lang.Integer>>> executionFunctionPartitions = null;
        /// <summary>
        /// The <see cref="Func{string, K, V, int, int}"/> to be executed
        /// </summary>
        public virtual Func<string, K, V, int, int> OnPartition { get { return executionFunctionPartition; } }
        /// <summary>
        /// The <see cref="Func{string, K, V, int, Optional{Set{Java.Lang.Integer}}}"/> to be executed
        /// </summary>
        public virtual Func<string, K, V, int, Optional<Set<Java.Lang.Integer>>> OnPartitions { get { return executionFunctionPartitions; } }
        /// <summary>
        /// Initialize a new instance of <see cref="StreamPartitioner{K, V}"/>
        /// </summary>
        /// <param name="partition">The <see cref="Func{string, K, V, int, int}"/> to be executed</param>
        /// <param name="partitions">The <see cref="Func{string, K, V, int, Optional{Set{Java.Lang.Integer}}}"/> to be executed</param>
        /// <param name="attachEventHandler">Set to false to disable attach of <see cref="EventHandler"/> and set an own one</param>
        public StreamPartitioner(Func<string, K, V, int, int> partition = null, Func<string, K, V, int, Optional<Set<Java.Lang.Integer>>> partitions = null, bool attachEventHandler = true)
        {
            if (partition != null) executionFunctionPartition = partition;
            else executionFunctionPartition = Partition;
            if (partitions != null) executionFunctionPartitions = partitions;
            else executionFunctionPartitions = Partitions;

            if (attachEventHandler)
            {
                AddEventHandler("partition", new EventHandler<CLRListenerEventArgs<CLREventData<string>>>(EventHandlerPartition));
                AddEventHandler("partitions", new EventHandler<CLRListenerEventArgs<CLREventData<string>>>(EventHandlerPartitions));
            }
        }

        void EventHandlerPartition(object sender, CLRListenerEventArgs<CLREventData<string>> data)
        {
            var retVal = OnPartition(data.EventData.TypedEventData, data.EventData.To<K>(0), data.EventData.To<V>(1), data.EventData.To<int>(2));
            data.SetReturnValue(retVal);
        }

        void EventHandlerPartitions(object sender, CLRListenerEventArgs<CLREventData<string>> data)
        {
            var retVal = OnPartitions(data.EventData.TypedEventData, data.EventData.To<K>(0), data.EventData.To<V>(1), data.EventData.To<int>(2));
            data.SetReturnValue(retVal);
        }
        /// <summary>
        /// Executes the StreamPartitioner action in the CLR
        /// </summary>
        /// <param name="topic">The StreamPartitioner object</param>
        /// <param name="key">The StreamPartitioner object</param>
        /// <param name="value">The StreamPartitioner object</param>
        /// <param name="numPartitions">The StreamPartitioner object</param>
        /// <returns>an integer between 0 and <paramref name="numPartitions"/> -1, or -1 if the default partitioning logic should be used</returns>
        public virtual int Partition(string topic, K key, V value, int numPartitions) { return -1; }

        public virtual Optional<Set<Java.Lang.Integer>> Partitions(string topic, K key, V value, int numPartitions)
        {
            return new Optional<Set<Java.Lang.Integer>>();
        }
    }
}
