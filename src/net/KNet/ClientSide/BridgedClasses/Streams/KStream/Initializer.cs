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
    /// Listener for Kafka Initializer. Extends <see cref="IJVMBridgeBase"/>
    /// </summary>
    /// <typeparam name="VA">The Initialized data associated to the event</typeparam>
    public interface IInitializer<VA> : IJVMBridgeBase
    {
        /// <summary>
        /// Executes the Initializer action in the CLR
        /// </summary>
        /// <returns>The <typeparamref name="VA"/> apply evaluation</returns>
        VA Apply();
    }

    /// <summary>
    /// Listener for Kafka Initializer. Extends <see cref="JVMBridgeListener"/>, implements <see cref="IInitializer{VA}"/>
    /// </summary>
    /// <typeparam name="VA">The Initialized data associated to the event</typeparam>
    /// <remarks>Remember to Dispose the object otherwise there is a resource leak, the object contains a reference to the the corresponding JVM object</remarks>
    public class Initializer<VA> : JVMBridgeListener, IInitializer<VA>
    {
        /// <inheritdoc cref="JVMBridgeListener.ClassName"/>
        public sealed override string ClassName => "org.mases.knet.streams.kstream.InitializerImpl";

        readonly Func<VA> executionFunction = null;
        /// <summary>
        /// The <see cref="Func{VA}"/> to be executed
        /// </summary>
        public virtual Func<VA> OnApply { get { return executionFunction; } }
        /// <summary>
        /// Initialize a new instance of <see cref="Initializer{VA}"/>
        /// </summary>
        /// <param name="func">The <see cref="Func{VA}"/> to be executed</param>
        /// <param name="attachEventHandler">Set to false to disable attach of <see cref="EventHandler"/> and set an own one</param>
        public Initializer(Func<VA> func = null, bool attachEventHandler = true)
        {
            if (func != null) executionFunction = func;
            else executionFunction = Apply;
            if (attachEventHandler)
            {
                AddEventHandler("apply", new EventHandler<CLRListenerEventArgs<CLREventData>>(EventHandler));
            }
        }

        void EventHandler(object sender, CLRListenerEventArgs<CLREventData> data)
        {
            var retVal = OnApply();
            data.SetReturnValue(retVal);
        }
        /// <summary>
        /// Executes the Initializer action in the CLR
        /// </summary>
        /// <returns>The <typeparamref name="VA"/> apply evaluation</returns>
        public virtual VA Apply() { return default(VA); }
    }
/*
    /// <summary>
    /// Listener for Kafka Initializer. Extends <see cref="InitializerImpl{VA}"/>
    /// </summary>
    /// <typeparam name="VA">The aggregated data associated to the event as an <see cref="JVMBridgeBase"/> object</typeparam>
    /// <remarks>Remember to Dispose the object otherwise there is a resource leak, the object contains a reference to the the corresponding JVM object</remarks>
    public class JVMBridgeInitializer<VA> : InitializerImpl<VA>
        where VA : JVMBridgeBase, new()
    {
        /// <summary>
        /// Initialize a new instance of <see cref="JVMBridgeInitializer{VA}"/>
        /// </summary>
        /// <param name="func">The <see cref="Func{VA}"/> to be executed</param>
        public JVMBridgeInitializer(Func<VA> func = null) : base(func, false)
        {
            AddEventHandler("apply", new EventHandler<CLRListenerEventArgs<CLREventData>>(EventHandler));
        }

        void EventHandler(object sender, CLRListenerEventArgs<CLREventData> data)
        {
            var retVal = OnApply();
            data.CLRReturnValue = retVal?;
        }
    }
*/
}
