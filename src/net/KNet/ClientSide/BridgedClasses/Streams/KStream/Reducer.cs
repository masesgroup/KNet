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
    /// Listener for Kafka Reducer. Extends <see cref="IJVMBridgeBase"/>
    /// </summary>
    /// <typeparam name="V">The data associated to the event</typeparam>
    public interface IReducer<V> : IJVMBridgeBase
    {
        /// <summary>
        /// Executes the Reducer action in the CLR
        /// </summary>
        /// <param name="o1">The Reducer object</param>
        /// <param name="o2">The Reducer object</param>
        /// <returns>The <typeparamref name="VR"/> apply evaluation</returns>
        V Apply(V o1, V o2);
    }

    /// <summary>
    /// Listener for Kafka Reducer. Extends <see cref="JVMBridgeListener"/>, implements <see cref="IReducer{V}"/>
    /// </summary>
    /// <typeparam name="V">The data associated to the event</typeparam>
    /// <remarks>Dispose the object to avoid a resource leak, the object contains a reference to the corresponding JVM object</remarks>
    public class Reducer<V> : JVMBridgeListener, IReducer<V>
    {
        /// <inheritdoc cref="JVMBridgeListener.ClassName"/>
        public sealed override string ClassName => "org.mases.knet.streams.kstream.ReducerImpl";

        readonly Func<V, V, V> executionFunction = null;
        /// <summary>
        /// The <see cref="Func{V, V, V}"/> to be executed
        /// </summary>
        public virtual Func<V, V, V> OnApply { get { return executionFunction; } }
        /// <summary>
        /// Initialize a new instance of <see cref="Reducer{V}"/>
        /// </summary>
        /// <param name="func">The <see cref="Func{V, V, V}"/> to be executed</param>
        /// <param name="attachEventHandler">Set to false to disable attach of <see cref="EventHandler"/> and set an own one</param>
        public Reducer(Func<V, V, V> func = null, bool attachEventHandler = true)
        {
            if (func != null) executionFunction = func;
            else executionFunction = Apply;
            if (attachEventHandler)
            {
                AddEventHandler("apply", new EventHandler<CLRListenerEventArgs<CLREventData<V>>>(EventHandler));
            }
        }

        void EventHandler(object sender, CLRListenerEventArgs<CLREventData<V>> data)
        {
            var retVal = OnApply(data.EventData.TypedEventData, data.EventData.To<V>(0));
            data.SetReturnValue(retVal);
        }
        /// <summary>
        /// Executes the Reducer action in the CLR
        /// </summary>
        /// <param name="o1">The Reducer object</param>
        /// <param name="o2">The Reducer object</param>
        /// <returns>The <typeparamref name="VR"/> apply evaluation</returns>
        public virtual V Apply(V o1, V o2) { return default(V); }
    }
    /*
    /// <summary>
    /// Listener for Kafka Reducer. Extends <see cref="ReducerImpl{V}"/>
    /// </summary>
    /// <typeparam name="V">The data associated to the event as an <see cref="JVMBridgeBase"/> object</typeparam>
    /// <remarks>Dispose the object to avoid a resource leak, the object contains a reference to the corresponding JVM object</remarks>
    public class JVMBridgeReducer<V> : ReducerImpl<V>
        where V : IJVMBridgeBase, new()
    {
        /// <summary>
        /// Initialize a new instance of <see cref="JVMBridgeReducer{V}"/>
        /// </summary>
        /// <param name="func">The <see cref="Func{V, V, V}"/> to be executed</param>
        public JVMBridgeReducer(Func<V, V, V> func = null) : base(func, false)
        {
            AddEventHandler("apply", new EventHandler<CLRListenerEventArgs<JVMBridgeEventData<V>>>(EventHandler));
        }

        void EventHandler(object sender, CLRListenerEventArgs<JVMBridgeEventData<V>> data)
        {
            var retVal = OnApply(data.EventData.TypedEventData, data.EventData.To<V>(0));
            data.CLRReturnValue = retVal?;
        }
    }
    */
}
