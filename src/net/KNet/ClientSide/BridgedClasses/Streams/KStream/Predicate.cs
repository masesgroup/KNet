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
    /// Listener for Kafka Predicate. Extends <see cref="IJVMBridgeBase"/>
    /// </summary>
    /// <typeparam name="T">The data associated to the event</typeparam>
    /// <typeparam name="U">The data associated to the event</typeparam>
    public interface IPredicate<T, U> : IJVMBridgeBase
    {
        /// <summary>
        /// Executes the Predicate action in the CLR
        /// </summary>
        /// <param name="o1">The Predicate object</param>
        /// <param name="o2">The Predicate object</param>
        /// <returns>The test evaluation</returns>
        bool Test(T o1, U o2);
    }

    /// <summary>
    /// Listener for Kafka Predicate. Extends <see cref="JVMBridgeListener"/>, implements <see cref="IPredicate{T, U}"/>
    /// </summary>
    /// <typeparam name="T">The data associated to the event</typeparam>
    /// <typeparam name="U">The data associated to the event</typeparam>
    /// <remarks>Remember to Dispose the object otherwise there is a resource leak, the object contains a reference to the the corresponding JVM object</remarks>
    public class Predicate<T, U> : JVMBridgeListener, IPredicate<T, U>
    {
        /// <inheritdoc cref="JVMBridgeListener.ClassName"/>
        public sealed override string ClassName => "org.mases.knet.streams.kstream.PredicateImpl";

        readonly Func<T, U, bool> executionFunction = null;
        /// <summary>
        /// The <see cref="Func{T, U, Boolean}"/> to be executed
        /// </summary>
        public virtual Func<T, U, bool> OnTest { get { return executionFunction; } }
        /// <summary>
        /// Initialize a new instance of <see cref="Predicate{T, U}"/>
        /// </summary>
        /// <param name="func">The <see cref="Func{T, U, Boolean}"/> to be executed</param>
        /// <param name="attachEventHandler">Set to false to disable attach of <see cref="EventHandler"/> and set an own one</param>
        public Predicate(Func<T, U, bool> func = null, bool attachEventHandler = true)
        {
            if (func != null) executionFunction = func;
            else executionFunction = Test;

            if (attachEventHandler)
            {
                AddEventHandler("test", new EventHandler<CLRListenerEventArgs<CLREventData<T>>>(EventHandler));
            }
        }

        void EventHandler(object sender, CLRListenerEventArgs<CLREventData<T>> data)
        {
            var retVal = OnTest(data.EventData.TypedEventData, data.EventData.To<U>(0));
            data.SetReturnValue(retVal);
        }
        /// <summary>
        /// Executes the Predicate action in the CLR
        /// </summary>
        /// <param name="o1">The Predicate object</param>
        /// <param name="o2">The Predicate object</param>
        /// <returns>The test evaluation</returns>
        public virtual bool Test(T o1, U o2) { return false; }
    }
    /*
    /// <summary>
    /// Listener for Kafka Predicate. Extends <see cref="PredicateImpl{T, U}"/>
    /// </summary>
    /// <typeparam name="T">The data associated to the event as an <see cref="JVMBridgeBase"/> object</typeparam>
    /// <typeparam name="U">The data associated to the event as an <see cref="JVMBridgeBase"/> object</typeparam>
    /// <remarks>Remember to Dispose the object otherwise there is a resource leak, the object contains a reference to the the corresponding JVM object</remarks>
    public class JVMBridgePredicate<T, U> : PredicateImpl<T, U>
        where T : JVMBridgeBase, new()
        where U : JVMBridgeBase, new()
    {
        /// <summary>
        /// Initialize a new instance of <see cref="JVMBridgePredicate{T, U}"/>
        /// </summary>
        /// <param name="func">The <see cref="Func{T, U, Boolean}"/> to be executed</param>
        public JVMBridgePredicate(Func<T, U, bool> func = null) : base(func, false)
        {
            AddEventHandler("test", new EventHandler<CLRListenerEventArgs<JVMBridgeEventData<T>>>(EventHandler));
        }

        void EventHandler(object sender, CLRListenerEventArgs<JVMBridgeEventData<T>> data)
        {
            var retVal = OnTest(data.EventData.TypedEventData, data.EventData.To<U>(0));
            data.CLRReturnValue = retVal;
        }
    }
    */
}
