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
using System;

namespace MASES.KafkaBridge.Streams.Processor
{
    /// <summary>
    /// Listerner for Kafka StreamPartitioner. Extends <see cref="IJVMBridgeBase"/>
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
    }

    /// <summary>
    /// Listerner for Kafka StreamPartitioner. Extends <see cref="CLRListener"/>, implements <see cref="IStreamPartitioner{K, V}"/>
    /// </summary>
    /// <typeparam name="K">The data associated to the event</typeparam>
    /// <typeparam name="V">The data associated to the event</typeparam>
    /// <remarks>Remember to Dispose the object otherwise there is a resource leak, the object contains a reference to the the corresponding JVM object</remarks>
    public class StreamPartitioner<K, V> : CLRListener, IStreamPartitioner<K, V>
    {
        /// <inheritdoc cref="CLRListener.ClassName"/>
        public sealed override string ClassName => "org.mases.kafkabridge.streams.kstream.StreamPartitionerImpl";

        readonly Func<string, K, V, int, int> executionFunction = null;
        /// <summary>
        /// The <see cref="Func{string, K, V, int, int}"/> to be executed
        /// </summary>
        public virtual Func<string, K, V, int, int> OnPartition { get { return executionFunction; } }
        /// <summary>
        /// Initialize a new instance of <see cref="StreamPartitioner{K, V}"/>
        /// </summary>
        /// <param name="func">The <see cref="Func{string, K, V, int, int}"/> to be executed</param>
        /// <param name="attachEventHandler">Set to false to disable attach of <see cref="EventHandler"/> and set an own one</param>
        public StreamPartitioner(Func<string, K, V, int, int> func = null, bool attachEventHandler = true)
        {
            if (func != null) executionFunction = func;
            else executionFunction = Partition;
            if (attachEventHandler)
            {
                AddEventHandler("partition", new EventHandler<CLRListenerEventArgs<CLREventData<string>>>(EventHandler));
            }
        }

        void EventHandler(object sender, CLRListenerEventArgs<CLREventData<string>> data)
        {
            var retVal = OnPartition(data.EventData.TypedEventData, data.EventData.To<K>(0), data.EventData.To<V>(1), data.EventData.To<int>(2));
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
    }
    /*
    /// <summary>
    /// Listerner for Kafka StreamPartitioner. Extends <see cref="StreamPartitionerImpl{K, V}"/>
    /// </summary>
    /// <typeparam name="T">The data associated to the event as an <see cref="JVMBridgeBase"/> object</typeparam>
    /// <typeparam name="U">The data associated to the event as an <see cref="JVMBridgeBase"/> object</typeparam>
    /// <typeparam name="VR">The result data associated to the event as an <see cref="JVMBridgeBase"/> object</typeparam>
    /// <remarks>Remember to Dispose the object otherwise there is a resource leak, the object contains a reference to the the corresponding JVM object</remarks>
    public class JVMBridgeStreamPartitioner<K, V> : StreamPartitionerImpl<K, V>
        where K : JVMBridgeBase, new()
        where V : JVMBridgeBase, new()
    {
        /// <summary>
        /// Initialize a new instance of <see cref="JVMBridgeStreamPartitioner{K, V}"/>
        /// </summary>
        /// <param name="func">The <see cref="Func{string, K, V, int, int}"/> to be executed</param>
        public JVMBridgeStreamPartitioner(Func<string, K, V, int, int> func = null) : base(func, false)
        {
            AddEventHandler("partition", new EventHandler<CLRListenerEventArgs<CLREventData<string>>>(EventHandler));
        }

        void EventHandler(object sender, CLRListenerEventArgs<CLREventData<string>> data)
        {
            var retVal = OnPartition(data.EventData.TypedEventData, data.EventData.To<K>(0), data.EventData.To<V>(1), data.EventData.To<int>(2));
            data.CLRReturnValue = retVal;
        }
    }
    */
}
