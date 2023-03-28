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

using MASES.JCOBridge.C2JBridge;
using System;

namespace Org.Apache.Kafka.Streams.KStream
{
    /// <summary>
    /// Listener for Kafka Aggregator. Extends <see cref="IJVMBridgeBase"/>
    /// </summary>
    /// <typeparam name="K">The data associated to the event</typeparam>
    /// <typeparam name="V">The data associated to the event</typeparam>
    /// <typeparam name="VA">Aggregated value</typeparam>
    public interface IAggregator<K, V, VA> : IJVMBridgeBase
    {
        /// <summary>
        /// Executes the Aggregator action in the CLR
        /// </summary>
        /// <param name="o1">The Aggregator object</param>
        /// <param name="o2">The Aggregator object</param>
        /// <param name="aggregate">The current aggregate value</param>
        /// <returns>The <typeparamref name="VA"/> apply evaluation</returns>
        VA Apply(K o1, V o2, VA aggregate);
    }

    /// <summary>
    /// Listener for Kafka Aggregator. Extends <see cref="JVMBridgeListener"/>, implements <see cref="IAggregator{K, V, VA}"/>
    /// </summary>
    /// <typeparam name="K">The data associated to the event</typeparam>
    /// <typeparam name="V">The data associated to the event</typeparam>
    /// <typeparam name="VA">Aggregated value</typeparam>
    /// <remarks>Dispose the object to avoid a resource leak, the object contains a reference to the corresponding JVM object</remarks>
    public class Aggregator<K, V, VA> : JVMBridgeListener, IAggregator<K, V, VA>
    {
        /// <inheritdoc cref="JVMBridgeListener.ClassName"/>
        public sealed override string ClassName => "org.mases.knet.streams.kstream.AggregatorImpl";

        readonly Func<K, V, VA, VA> executionFunction = null;
        /// <summary>
        /// The <see cref="Func{K, V, VA, VA}"/> to be executed
        /// </summary>
        public virtual Func<K, V, VA, VA> OnApply { get { return executionFunction; } }
        /// <summary>
        /// Initialize a new instance of <see cref="Aggregator{K, V, VA}"/>
        /// </summary>
        /// <param name="func">The <see cref="Func{K, V, VA}"/> to be executed</param>
        /// <param name="attachEventHandler">Set to false to disable attach of <see cref="EventHandler"/> and set an own one</param>
        public Aggregator(Func<K, V, VA, VA> func = null, bool attachEventHandler = true)
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
            var retVal = OnApply(data.EventData.TypedEventData, data.EventData.To<V>(0), data.EventData.To<VA>(1));
            data.SetReturnValue(retVal);
        }
        /// <summary>
        /// Executes the Aggregator action in the CLR
        /// </summary>
        /// <param name="o1">The Aggregator object</param>
        /// <param name="o2">The Aggregator object</param>
        /// <param name="aggregate">The current aggregate value</param>
        /// <returns>The <typeparamref name="VA"/> apply evaluation</returns>
        public virtual VA Apply(K o1, V o2, VA aggregate) { return default(VA); }
    }
    /*
    /// <summary>
    /// Listener for Kafka Aggregator. Extends <see cref="AggregatorImpl{K, V, VA}"/>
    /// </summary>
    /// <typeparam name="K">The data associated to the event as an <see cref="JVMBridgeBase"/> object</typeparam>
    /// <typeparam name="V">The data associated to the event as an <see cref="JVMBridgeBase"/> object</typeparam>
    /// <typeparam name="VA">The aggregated data associated to the event as an <see cref="JVMBridgeBase"/> object</typeparam>
    /// <remarks>Dispose the object to avoid a resource leak, the object contains a reference to the corresponding JVM object</remarks>
    public class JVMBridgeAggregator<K, V, VA> : AggregatorImpl<K, V, VA>
        where K : JVMBridgeBase, new()
        where V : JVMBridgeBase, new()
        where VA : JVMBridgeBase, new()
    {
        /// <summary>
        /// Initialize a new instance of <see cref="JVMBridgeAggregator{K, V, VA}"/>
        /// </summary>
        /// <param name="func">The <see cref="Func{K, V, VA, VA}"/> to be executed</param>
        public JVMBridgeAggregator(Func<K, V, VA, VA> func = null) : base(func, false)
        {
            AddEventHandler("apply", new EventHandler<CLRListenerEventArgs<JVMBridgeEventData<K>>>(EventHandler));
        }

        void EventHandler(object sender, CLRListenerEventArgs<JVMBridgeEventData<K>> data)
        {
            var retVal = OnApply(data.EventData.TypedEventData, data.EventData.To<V>(0), data.EventData.To<VA>(1));
            data.CLRReturnValue = retVal?;
        }
    }
    */
}
