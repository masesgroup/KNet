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

namespace MASES.KNet.Streams.KStream
{
    /// <summary>
    /// Listener for Kafka ForeachAction. Extends <see cref="IJVMBridgeBase"/>
    /// </summary>
    /// <typeparam name="K">The data associated to the event</typeparam>
    /// <typeparam name="V">The data associated to the event</typeparam>
    public interface IForeachAction<K, V> : IJVMBridgeBase
    {
        /// <summary>
        /// Executes the ForeachAction action in the CLR
        /// </summary>
        /// <param name="o1">The ForeachAction object</param>
        /// <param name="o2">The ForeachAction object</param>
        /// <returns>The <typeparamref name="VR"/> apply evaluation</returns>
        void Apply(K o1, V o2);
    }


    /// <summary>
    /// Listener for Kafka ForeachAction. Extends <see cref="JVMBridgeListener"/>, implements <see cref="IForeachAction{K, V}"/>
    /// </summary>
    /// <typeparam name="K">The data associated to the event</typeparam>
    /// <typeparam name="V">The data associated to the event</typeparam>
    /// <remarks>Dispose the object to avoid a resource leak, the object contains a reference to the corresponding JVM object</remarks>
    public class ForeachAction<K, V> : JVMBridgeListener, IForeachAction<K, V>
    {
        /// <inheritdoc cref="JVMBridgeListener.ClassName"/>
        public sealed override string ClassName => "org.mases.knet.streams.kstream.ForeachActionImpl";

        readonly Action<K, V> executionFunction = null;
        /// <summary>
        /// The <see cref="Action{K, V}"/> to be executed
        /// </summary>
        public virtual Action<K, V> OnApply { get { return executionFunction; } }
        /// <summary>
        /// Initialize a new instance of <see cref="ForeachAction{K, V}"/>
        /// </summary>
        /// <param name="func">The <see cref="Action{K, V}"/> to be executed</param>
        /// <param name="attachEventHandler">Set to false to disable attach of <see cref="EventHandler"/> and set an own one</param>
        public ForeachAction(Action<K, V> func = null, bool attachEventHandler = true)
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
            OnApply(data.EventData.TypedEventData, data.EventData.To<V>(0));
        }
        /// <summary>
        /// Executes the ForeachAction action in the CLR
        /// </summary>
        /// <param name="o1">The ForeachAction object</param>
        /// <param name="o2">The ForeachAction object</param>
        /// <returns>The <typeparamref name="VR"/> apply evaluation</returns>
        public virtual void Apply(K o1, V o2) { }
    }
    /*
    /// <summary>
    /// Listener for Kafka ForeachAction. Extends <see cref="ForeachActionImpl{K, V}"/>
    /// </summary>
    /// <typeparam name="K">The data associated to the event as an <see cref="JVMBridgeBase"/> object</typeparam>
    /// <typeparam name="V">The data associated to the event as an <see cref="JVMBridgeBase"/> object</typeparam>
    /// <remarks>Dispose the object to avoid a resource leak, the object contains a reference to the corresponding JVM object</remarks>
    public class JVMBridgeForeachAction<K, V> : ForeachActionImpl<K, V>
        where K : IJVMBridgeBase, new()
        where V : IJVMBridgeBase, new()
    {
        /// <summary>
        /// Initialize a new instance of <see cref="JVMBridgeForeachAction{K, V}"/>
        /// </summary>
        /// <param name="func">The <see cref="Action{K, V}"/> to be executed</param>
        public JVMBridgeForeachAction(Action<K, V> func = null) : base(func, false)
        {
            AddEventHandler("apply", new EventHandler<CLRListenerEventArgs<JVMBridgeEventData<K>>>(EventHandler));
        }

        void EventHandler(object sender, CLRListenerEventArgs<JVMBridgeEventData<K>> data)
        {
            OnApply(data.EventData.TypedEventData, data.EventData.To<V>(0));
        }
    }
    */
}
