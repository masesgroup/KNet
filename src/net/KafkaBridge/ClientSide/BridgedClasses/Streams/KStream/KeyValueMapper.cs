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
    /// Listerner for Kafka KeyValueMapper. Extends <see cref="CLRListener"/>
    /// </summary>
    /// <typeparam name="T">The data associated to the event</typeparam>
    /// <typeparam name="U">The data associated to the event</typeparam>
    /// <remarks>Remember to Dispose the object otherwise there is a resource leak, the object contains a reference to the the corresponding JVM object</remarks>
    public class KeyValueMapper<T, U, VR> : CLRListener
    {
        /// <inheritdoc cref="CLRListener.JniClass"/>
        public sealed override string JniClass => "org.mases.kafkabridge.streams.kstream.KeyValueMapperImpl";

        readonly Func<T, U, VR> executionFunction = null;
        /// <summary>
        /// The <see cref="Func{T, U, VR}"/> to be executed
        /// </summary>
        public virtual Func<T, U, VR> OnApply { get { return executionFunction; } }
        /// <summary>
        /// Initialize a new instance of <see cref="KeyValueMapper{T, U, VR}"/>
        /// </summary>
        /// <param name="func">The <see cref="Func{T, U, VR}"/> to be executed</param>
        public KeyValueMapper(Func<T, U, VR> func = null)
        {
            if (func != null) executionFunction = func;
            else executionFunction = Apply;

            AddEventHandler("apply", new EventHandler<CLRListenerEventArgs<CLREventData<T>>>(EventHandler));
        }

        void EventHandler(object sender, CLRListenerEventArgs<CLREventData<T>> data)
        {
            var retVal = OnApply(data.EventData.TypedEventData, data.EventData.To<U>(0));
            data.CLRReturnValue = retVal;
        }
        /// <summary>
        /// Executes the KeyValueMapper action in the CLR
        /// </summary>
        /// <param name="o1">The KeyValueMapper object</param>
        /// <param name="o2">The KeyValueMapper object</param>
        /// <returns>The <typeparamref name="VR"/> apply evaluation</returns>
        public virtual VR Apply(T o1, U o2) { return default(VR); }
    }

    /// <summary>
    /// Listerner for Kafka KeyValueMapper. Extends <see cref="KeyValueMapper{T, U, VR}"/>
    /// </summary>
    /// <typeparam name="T">The data associated to the event as an <see cref="JVMBridgeBase"/> object</typeparam>
    /// <typeparam name="U">The data associated to the event as an <see cref="JVMBridgeBase"/> object</typeparam>
    /// <remarks>Remember to Dispose the object otherwise there is a resource leak, the object contains a reference to the the corresponding JVM object</remarks>
    public class JVMBridgeKeyValueMapper<T, U, VR> : KeyValueMapper<T, U, VR>
        where T : JVMBridgeBase, new()
        where U : JVMBridgeBase, new()
        where VR : JVMBridgeBase, new()
    {
        /// <summary>
        /// Initialize a new instance of <see cref="JVMBridgeKeyValueMapper{T, U, VR}"/>
        /// </summary>
        /// <param name="func">The <see cref="Func{T, U, VR}"/> to be executed</param>
        public JVMBridgeKeyValueMapper(Func<T, U, VR> func = null) : base(func)
        {
            AddEventHandler("apply", new EventHandler<CLRListenerEventArgs<JVMBridgeEventData<T>>>(EventHandler));
        }

        void EventHandler(object sender, CLRListenerEventArgs<JVMBridgeEventData<T>> data)
        {
            var retVal = OnApply(data.EventData.TypedEventData, data.EventData.To<U>(0));
            data.CLRReturnValue = retVal;
        }
    }

}
