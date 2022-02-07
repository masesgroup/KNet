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
    /// Listerner for Kafka ValueMapper. Extends <see cref="IJVMBridgeBase"/>
    /// </summary>
    /// <typeparam name="V">The data associated to the event</typeparam>
    /// <typeparam name="VR">The result data associated to the event</typeparam>
    public interface IValueMapper<V, VR> : IJVMBridgeBase
    {
        /// <summary>
        /// Executes the ValueMapper action in the CLR
        /// </summary>
        /// <param name="o1">The ValueMapper object</param>
        /// <returns>The apply evaluation</returns>
        VR Apply(V o1);
    }
        /// <summary>
        /// Listerner for Kafka ValueMapper. Extends <see cref="CLRListener"/>, implements <see cref="IValueMapper{V, VR}"/>
        /// </summary>
        /// <typeparam name="V">The data associated to the event</typeparam>
        /// <typeparam name="VR">The result data associated to the event</typeparam>
        /// <remarks>Remember to Dispose the object otherwise there is a resource leak, the object contains a reference to the the corresponding JVM object</remarks>
        public class ValueMapper<V, VR> : CLRListener, IValueMapper<V, VR>
    {
        /// <inheritdoc cref="CLRListener.ClassName"/>
        public sealed override string ClassName => "org.mases.kafkabridge.streams.kstream.ValueMapperImpl";

        readonly Func<V, VR> executionFunction = null;
        /// <summary>
        /// The <see cref="Func{V, VR}"/> to be executed
        /// </summary>
        public virtual Func<V, VR> OnApply { get { return executionFunction; } }
        /// <summary>
        /// Initialize a new instance of <see cref="ValueMapper{V, VR}"/>
        /// </summary>
        /// <param name="func">The <see cref="Func{V, VR}"/> to be executed</param>
        /// <param name="attachEventHandler">Set to false to disable attach of <see cref="EventHandler"/> and set an own one</param>
        public ValueMapper(Func<V, VR> func = null, bool attachEventHandler = true)
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
            var retVal = OnApply(data.EventData.TypedEventData);
            data.SetReturnValue(retVal);
        }
        /// <summary>
        /// Executes the ValueMapper action in the CLR
        /// </summary>
        /// <param name="o1">The ValueMapper object</param>
        /// <returns>The apply evaluation</returns>
        public virtual VR Apply(V o1) { return default(VR); }
    }
    /*
    /// <summary>
    /// Listerner for Kafka ValueMapper. Extends <see cref="ValueMapperImpl{V, VR}"/>
    /// </summary>
    /// <typeparam name="V">The data associated to the event as an <see cref="JVMBridgeBase"/> object</typeparam>
    /// <typeparam name="VR">The result data associated to the event as an <see cref="JVMBridgeBase"/> object</typeparam>
    /// <remarks>Remember to Dispose the object otherwise there is a resource leak, the object contains a reference to the the corresponding JVM object</remarks>
    public class JVMBridgeValueMapper<V, VR> : ValueMapperImpl<V, VR>
        where V : JVMBridgeBase, new()
        where VR : JVMBridgeBase, new()
    {
        /// <summary>
        /// Initialize a new instance of <see cref="JVMBridgeValueMapper{V, VR}"/>
        /// </summary>
        /// <param name="func">The <see cref="Func{V, VR}"/> to be executed</param>
        public JVMBridgeValueMapper(Func<V, VR> func = null) : base(func, false)
        {
            AddEventHandler("apply", new EventHandler<CLRListenerEventArgs<JVMBridgeEventData<V>>>(EventHandler));
        }

        void EventHandler(object sender, CLRListenerEventArgs<JVMBridgeEventData<V>> data)
        {
            var retVal = OnApply(data.EventData.TypedEventData);
            data.CLRReturnValue = retVal?;
        }
    }
    */
}
