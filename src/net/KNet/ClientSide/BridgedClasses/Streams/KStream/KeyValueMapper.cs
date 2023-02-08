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

namespace MASES.KNet.Streams.KStream
{
    /// <summary>
    /// Listener for Kafka KeyValueMapper. Extends <see cref="IJVMBridgeBase"/>
    /// </summary>
    /// <typeparam name="T">The data associated to the event</typeparam>
    /// <typeparam name="U">The data associated to the event</typeparam>
    /// <typeparam name="VR">The result value</typeparam>
    public interface IKeyValueMapper<T, U, VR> : IJVMBridgeBase
    {
        /// <summary>
        /// Executes the KeyValueMapper action in the CLR
        /// </summary>
        /// <param name="o1">The KeyValueMapper object</param>
        /// <param name="o2">The KeyValueMapper object</param>
        /// <returns>The <typeparamref name="VR"/> apply evaluation</returns>
        VR Apply(T o1, U o2);
    }

    /// <summary>
    /// Listener for Kafka KeyValueMapper. Extends <see cref="JVMBridgeListener"/>, implements <see cref="IKeyValueMapper{T, U, VR}"/>
    /// </summary>
    /// <typeparam name="T">The data associated to the event</typeparam>
    /// <typeparam name="U">The data associated to the event</typeparam>
    /// <typeparam name="VR">The result value</typeparam>
    /// <remarks>Dispose the object to avoid a resource leak, the object contains a reference to the corresponding JVM object</remarks>
    public class KeyValueMapper<T, U, VR> : JVMBridgeListener, IKeyValueMapper<T, U, VR>
    {
        /// <inheritdoc cref="JVMBridgeListener.ClassName"/>
        public sealed override string ClassName => "org.mases.knet.streams.kstream.KeyValueMapperImpl";

        readonly Func<T, U, VR> executionFunction = null;
        /// <summary>
        /// The <see cref="Func{T, U, VR}"/> to be executed
        /// </summary>
        public virtual Func<T, U, VR> OnApply { get { return executionFunction; } }
        /// <summary>
        /// Initialize a new instance of <see cref="KeyValueMapper{T, U, VR}"/>
        /// </summary>
        /// <param name="func">The <see cref="Func{T, U, VR}"/> to be executed</param>
        /// <param name="attachEventHandler">Set to false to disable attach of <see cref="EventHandler"/> and set an own one</param>
        public KeyValueMapper(Func<T, U, VR> func = null, bool attachEventHandler = true)
        {
            if (func != null) executionFunction = func;
            else executionFunction = Apply;
            if (attachEventHandler)
            {
                AddEventHandler("apply", new EventHandler<CLRListenerEventArgs<CLREventData<T>>>(EventHandler));
            }
        }

        void EventHandler(object sender, CLRListenerEventArgs<CLREventData<T>> data)
        {
            var retVal = OnApply(data.EventData.TypedEventData, data.EventData.To<U>(0));
            data.SetReturnValue(retVal);
        }
        /// <summary>
        /// Executes the KeyValueMapper action in the CLR
        /// </summary>
        /// <param name="o1">The KeyValueMapper object</param>
        /// <param name="o2">The KeyValueMapper object</param>
        /// <returns>The <typeparamref name="VR"/> apply evaluation</returns>
        public virtual VR Apply(T o1, U o2) { return default(VR); }
    }
    /*
    /// <summary>
    /// Listener for Kafka KeyValueMapper. Extends <see cref="KeyValueMapperImpl{T, U, VR}"/>
    /// </summary>
    /// <typeparam name="T">The data associated to the event as an <see cref="JVMBridgeBase"/> object</typeparam>
    /// <typeparam name="U">The data associated to the event as an <see cref="JVMBridgeBase"/> object</typeparam>
    /// <typeparam name="VR">The result data associated to the event as an <see cref="JVMBridgeBase"/> object</typeparam>
    /// <remarks>Dispose the object to avoid a resource leak, the object contains a reference to the corresponding JVM object</remarks>
    public class JVMBridgeKeyValueMapper<T, U, VR> : KeyValueMapperImpl<T, U, VR>
        where T : JVMBridgeBase, new()
        where U : JVMBridgeBase, new()
        where VR : JVMBridgeBase, new()
    {
        /// <summary>
        /// Initialize a new instance of <see cref="JVMBridgeKeyValueMapper{T, U, VR}"/>
        /// </summary>
        /// <param name="func">The <see cref="Func{T, U, VR}"/> to be executed</param>
        public JVMBridgeKeyValueMapper(Func<T, U, VR> func = null) : base(func, false)
        {
            AddEventHandler("apply", new EventHandler<CLRListenerEventArgs<JVMBridgeEventData<T>>>(EventHandler));
        }

        void EventHandler(object sender, CLRListenerEventArgs<JVMBridgeEventData<T>> data)
        {
            var retVal = OnApply(data.EventData.TypedEventData, data.EventData.To<U>(0));
            data.CLRReturnValue = retVal?;
        }
    }
    */
}
