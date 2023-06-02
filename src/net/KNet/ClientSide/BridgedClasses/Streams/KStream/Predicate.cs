﻿/*
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

namespace Org.Apache.Kafka.Streams.Kstream
{
    /// <summary>
    /// Listener for Kafka Predicate. Extends <see cref="IJVMBridgeBase"/>
    /// </summary>
    /// <typeparam name="T">The data associated to the event</typeparam>
    /// <typeparam name="V">The data associated to the event</typeparam>
    public interface IPredicate<K, V> : IJVMBridgeBase
    {
        /// <summary>
        /// Executes the Predicate action in the CLR
        /// </summary>
        /// <param name="o1">The Predicate object</param>
        /// <param name="o2">The Predicate object</param>
        /// <returns>The test evaluation</returns>
        bool Test(K o1, V o2);
    }

    /// <summary>
    /// Listener for Kafka Predicate. Extends <see cref="JVMBridgeListener"/>, implements <see cref="IPredicate{K, V}"/>
    /// </summary>
    /// <typeparam name="K">The data associated to the event</typeparam>
    /// <typeparam name="V">The data associated to the event</typeparam>
    /// <remarks>Dispose the object to avoid a resource leak, the object contains a reference to the corresponding JVM object</remarks>
    public partial class Predicate<K, V> : IPredicate<K, V>
    {
        /// <inheritdoc cref="JVMBridgeListener.ClassName"/>
         public sealed override string BridgeClassName => "org.mases.knet.streams.kstream.PredicateImpl";

        readonly Func<K, V, bool> executionFunction = null;
        /// <summary>
        /// The <see cref="Func{K, V, Boolean}"/> to be executed
        /// </summary>
        public virtual Func<K, V, bool> OnTest { get { return executionFunction; } }
        /// <summary>
        /// Initialize a new instance of <see cref="Predicate{T, V}"/>
        /// </summary>
        /// <param name="func">The <see cref="Func{K, V, Boolean}"/> to be executed</param>
        /// <param name="attachEventHandler">Set to false to disable attach of <see cref="EventHandler"/> and set an own one</param>
        public Predicate(Func<K, V, bool> func = null, bool attachEventHandler = true)
        {
            if (func != null) executionFunction = func;
            else executionFunction = Test;

            if (attachEventHandler)
            {
                AddEventHandler("test", new EventHandler<CLRListenerEventArgs<CLREventData<K>>>(EventHandler));
            }
        }

        void EventHandler(object sender, CLRListenerEventArgs<CLREventData<K>> data)
        {
            var retVal = OnTest(data.EventData.TypedEventData, data.EventData.To<V>(0));
            data.SetReturnValue(retVal);
        }
        /// <summary>
        /// Executes the Predicate action in the CLR
        /// </summary>
        /// <param name="o1">The Predicate object</param>
        /// <param name="o2">The Predicate object</param>
        /// <returns>The test evaluation</returns>
        public virtual bool Test(K o1, V o2) { return false; }
    }
}
