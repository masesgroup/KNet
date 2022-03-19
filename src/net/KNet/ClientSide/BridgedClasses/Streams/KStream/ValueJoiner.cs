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
    /// Listener for Kafka ValueJoiner. Extends <see cref="IJVMBridgeBase"/>
    /// </summary>
    /// <typeparam name="V1">The data associated to the event</typeparam>
    /// <typeparam name="V2">The data associated to the event</typeparam>
    /// <typeparam name="VR">Aggregated value</typeparam>
    public interface IValueJoiner<V1, V2, VR> : IJVMBridgeBase
    {
        /// <summary>
        /// Executes the ValueJoiner action in the CLR
        /// </summary>
        /// <param name="value1">The ValueJoiner object</param>
        /// <param name="value2">The ValueJoiner object</param>
        /// <returns>The <typeparamref name="VR"/> apply evaluation</returns>
        VR Apply(V1 value1, V2 value2);
    }

    /// <summary>
    /// Listener for Kafka ValueJoiner. Extends <see cref="JVMBridgeListener"/>, implements <see cref="IValueJoiner{V1, V2, VR}"/>
    /// </summary>
    /// <typeparam name="V1">The data associated to the event</typeparam>
    /// <typeparam name="V2">The data associated to the event</typeparam>
    /// <typeparam name="VR">Aggregated value</typeparam>
    /// <remarks>Remember to Dispose the object otherwise there is a resource leak, the object contains a reference to the the corresponding JVM object</remarks>
    public class ValueJoiner<V1, V2, VR> : JVMBridgeListener, IValueJoiner<V1, V2, VR>
    {
        /// <inheritdoc cref="JVMBridgeListener.ClassName"/>
        public sealed override string ClassName => "org.mases.knet.streams.kstream.ValueJoinerImpl";

        readonly Func<V1, V2, VR> executionFunction = null;
        /// <summary>
        /// The <see cref="Func{V1, V2, VR}"/> to be executed
        /// </summary>
        public virtual Func<V1, V2, VR> OnApply { get { return executionFunction; } }
        /// <summary>
        /// Initialize a new instance of <see cref="ValueJoiner{V1, V2, VR}"/>
        /// </summary>
        /// <param name="func">The <see cref="Func{V1, V2, VR}"/> to be executed</param>
        /// <param name="attachEventHandler">Set to false to disable attach of <see cref="EventHandler"/> and set an own one</param>
        public ValueJoiner(Func<V1, V2, VR> func = null, bool attachEventHandler = true)
        {
            if (func != null) executionFunction = func;
            else executionFunction = Apply;
            if (attachEventHandler)
            {
                AddEventHandler("apply", new EventHandler<CLRListenerEventArgs<CLREventData<V1>>>(EventHandler));
            }
        }

        void EventHandler(object sender, CLRListenerEventArgs<CLREventData<V1>> data)
        {
            var retVal = OnApply(data.EventData.TypedEventData, data.EventData.To<V2>(0));
            data.SetReturnValue(retVal);
        }
        /// <summary>
        /// Executes the ValueJoiner action in the CLR
        /// </summary>
        /// <param name="value1">The ValueJoiner object</param>
        /// <param name="value2">The ValueJoiner object</param>
        /// <returns>The <typeparamref name="VR"/> apply evaluation</returns>
        public virtual VR Apply(V1 value1, V2 value2) { return default(VR); }
    }
    /*
    /// <summary>
    /// Listener for Kafka ValueJoiner. Extends <see cref="ValueJoinerImpl{V1, V2, VR}"/>
    /// </summary>
    /// <typeparam name="V1">The data associated to the event as an <see cref="JVMBridgeBase"/> object</typeparam>
    /// <typeparam name="V2">The data associated to the event as an <see cref="JVMBridgeBase"/> object</typeparam>
    /// <typeparam name="VR">The aggregated data associated to the event as an <see cref="JVMBridgeBase"/> object</typeparam>
    /// <remarks>Remember to Dispose the object otherwise there is a resource leak, the object contains a reference to the the corresponding JVM object</remarks>
    public class JVMBridgeValueJoiner<V1, V2, VR> : ValueJoinerImpl<V1, V2, VR>
        where V1 : JVMBridgeBase, new()
        where V2 : JVMBridgeBase, new()
        where VR : JVMBridgeBase, new()
    {
        /// <summary>
        /// Initialize a new instance of <see cref="JVMBridgeValueJoiner{V1, V2, VR}"/>
        /// </summary>
        /// <param name="func">The <see cref="Func{V1, V2, VR}"/> to be executed</param>
        public JVMBridgeValueJoiner(Func<V1, V2, VR> func = null) : base(func, false)
        {
            AddEventHandler("apply", new EventHandler<CLRListenerEventArgs<JVMBridgeEventData<V1>>>(EventHandler));
        }

        void EventHandler(object sender, CLRListenerEventArgs<JVMBridgeEventData<V1>> data)
        {
            var retVal = OnApply(data.EventData.TypedEventData, data.EventData.To<V2>(0));
            data.CLRReturnValue = retVal?;
        }
    }
    */
}
