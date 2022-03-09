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

namespace MASES.KafkaBridge.Streams.KStream
{
    /// <summary>
    /// Listener for Kafka Merger. Extends <see cref="IJVMBridgeBase"/>
    /// </summary>
    /// <typeparam name="K">The data associated to the event</typeparam>
    /// <typeparam name="V">The data associated to the event</typeparam>
    public interface IMerger<K, V> : IJVMBridgeBase
    {
        /// <summary>
        /// Executes the Merger action in the CLR
        /// </summary>
        /// <param name="aggKey">The Merger object</param>
        /// <param name="aggOne">The Merger object</param>
        /// <param name="aggTwo">The current aggregate value</param>
        /// <returns>The <typeparamref name="V"/> apply evaluation</returns>
        V Apply(K aggKey, V aggOne, V aggTwo);
    }
    /// <summary>
    /// Listener for Kafka Merger. Extends <see cref="JVMBridgeListener"/>
    /// </summary>
    /// <typeparam name="K">The data associated to the event</typeparam>
    /// <typeparam name="V">The data associated to the event</typeparam>
    /// <remarks>Remember to Dispose the object otherwise there is a resource leak, the object contains a reference to the the corresponding JVM object</remarks>
    public class Merger<K, V> : JVMBridgeListener, IMerger<K, V>
    {
        /// <inheritdoc cref="JVMBridgeListener.ClassName"/>
        public sealed override string ClassName => "org.mases.kafkabridge.streams.kstream.MergerImpl";

        readonly Func<K, V, V, V> executionFunction = null;
        /// <summary>
        /// The <see cref="Func{K, V, V, V}"/> to be executed
        /// </summary>
        public virtual Func<K, V, V, V> OnApply { get { return executionFunction; } }
        /// <summary>
        /// Initialize a new instance of <see cref="Merger{K, V}"/>
        /// </summary>
        /// <param name="func">The <see cref="Func{K, V, V, V}"/> to be executed</param>
        /// <param name="attachEventHandler">Set to false to disable attach of <see cref="EventHandler"/> and set an own one</param>
        public Merger(Func<K, V, V, V> func = null, bool attachEventHandler = true)
        {
            if (func != null) executionFunction = func;
            else executionFunction = Apply;
            if (attachEventHandler)
            {
                AddEventHandler("apply", new EventHandler<CLRListenerEventArgs<CLREventData<K>>>(EventHandler));
            }
        }

        void EventHandler(object sender, CLRListenerEventArgs<CLREventData<K>> data)
        {
            var retVal = OnApply(data.EventData.TypedEventData, data.EventData.To<V>(0), data.EventData.To<V>(1));
            data.SetReturnValue(retVal);
        }
        /// <summary>
        /// Executes the Merger action in the CLR
        /// </summary>
        /// <param name="aggKey">The Merger object</param>
        /// <param name="aggOne">The Merger object</param>
        /// <param name="aggTwo">The current aggregate value</param>
        /// <returns>The <typeparamref name="V"/> apply evaluation</returns>
        public virtual V Apply(K aggKey, V aggOne, V aggTwo) { return default(V); }
    }
    /*
    /// <summary>
    /// Listener for Kafka Merger. Extends <see cref="MergerImpl{K, V, VA}"/>
    /// </summary>
    /// <typeparam name="K">The data associated to the event as an <see cref="JVMBridgeBase"/> object</typeparam>
    /// <typeparam name="V">The data associated to the event as an <see cref="JVMBridgeBase"/> object</typeparam>
    /// <remarks>Remember to Dispose the object otherwise there is a resource leak, the object contains a reference to the the corresponding JVM object</remarks>
    public class JVMBridgeMerger<K, V> : MergerImpl<K, V>
        where K : JVMBridgeBase, new()
        where V : JVMBridgeBase, new()
    {
        /// <summary>
        /// Initialize a new instance of <see cref="JVMBridgeMerger{K, V}"/>
        /// </summary>
        /// <param name="func">The <see cref="Func{K, V, V, V}"/> to be executed</param>
        public JVMBridgeMerger(Func<K, V, V, V> func = null) : base(func, false)
        {
            AddEventHandler("apply", new EventHandler<CLRListenerEventArgs<JVMBridgeEventData<K>>>(EventHandler));
        }

        void EventHandler(object sender, CLRListenerEventArgs<JVMBridgeEventData<K>> data)
        {
            var retVal = OnApply(data.EventData.TypedEventData, data.EventData.To<V>(0), data.EventData.To<V>(1));
            data.CLRReturnValue = retVal?;
        }
    }
    */
}
