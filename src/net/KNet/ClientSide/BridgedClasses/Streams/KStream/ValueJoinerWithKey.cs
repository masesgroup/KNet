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

namespace Org.Apache.Kafka.Streams.Kstream
{
    /// <summary>
    /// Listener for Kafka ValueJoinerWithKey. Extends <see cref="IJVMBridgeBase"/>
    /// </summary>
    /// <typeparam name="K1">The data associated to the event</typeparam>
    /// <typeparam name="V1">The data associated to the event</typeparam>
    /// <typeparam name="V2">The data associated to the event</typeparam>
    /// <typeparam name="VR">Joined value</typeparam>
    public interface IValueJoinerWithKey<K1, V1, V2, VR> : IJVMBridgeBase
    {
        /// <summary>
        /// Executes the ValueJoinerWithKey action in the CLR
        /// </summary>
        /// <param name="readOnlyKey">The ValueJoinerWithKey object</param>
        /// <param name="value1">The ValueJoinerWithKey object</param>
        /// <param name="value2">The current aggregate value</param>
        /// <returns>The <typeparamref name="VR"/> apply evaluation</returns>
        VR Apply(K1 readOnlyKey, V1 value1, V2 value2);
    }

    /// <summary>
    /// Listener for Kafka ValueJoinerWithKey. Extends <see cref="JVMBridgeListener"/>, implements <see cref="IValueJoinerWithKey{K1, V1, V2, VR}"/>
    /// </summary>
    /// <typeparam name="K1">The data associated to the event</typeparam>
    /// <typeparam name="V1">The data associated to the event</typeparam>
    /// <typeparam name="V2">The data associated to the event</typeparam>
    /// <typeparam name="VR">Joined value</typeparam>
    /// <remarks>Dispose the object to avoid a resource leak, the object contains a reference to the corresponding JVM object</remarks>
    public partial class ValueJoinerWithKey<K1, V1, V2, VR> : IValueJoinerWithKey<K1, V1, V2, VR>
    {
        /// <inheritdoc cref="JVMBridgeListener.ClassName"/>
         public sealed override string BridgeClassName => "org.mases.knet.streams.kstream.ValueJoinerWithKeyImpl";

        readonly Func<K1, V1, V2, VR> executionFunction = null;
        /// <summary>
        /// The <see cref="Func{K1, V1, V2, VR}"/> to be executed
        /// </summary>
        public virtual Func<K1, V1, V2, VR> OnApply { get { return executionFunction; } }
        /// <summary>
        /// Initialize a new instance of <see cref="ValueJoinerWithKey{K1, V1, V2, VR}"/>
        /// </summary>
        /// <param name="func">The <see cref="Func{K, V, VA}"/> to be executed</param>
        /// <param name="attachEventHandler">Set to false to disable attach of <see cref="EventHandler"/> and set an own one</param>
        public ValueJoinerWithKey(Func<K1, V1, V2, VR> func = null, bool attachEventHandler = true)
        {
            if (func != null) executionFunction = func;
            else executionFunction = Apply;
            if (attachEventHandler)
            {
                AddEventHandler("apply", new EventHandler<CLRListenerEventArgs<CLREventData<K1>>>(EventHandler));
            }
        }

        void EventHandler(object sender, CLRListenerEventArgs<CLREventData<K1>> data)
        {
            var retVal = OnApply(data.EventData.TypedEventData, data.EventData.To<V1>(0), data.EventData.To<V2>(1));
            data.SetReturnValue(retVal);
        }
        /// <summary>
        /// Executes the ValueJoinerWithKey action in the CLR
        /// </summary>
        /// <param name="readOnlyKey">The ValueJoinerWithKey object</param>
        /// <param name="value1">The ValueJoinerWithKey object</param>
        /// <param name="value2">The current aggregate value</param>
        /// <returns>The <typeparamref name="VR"/> apply evaluation</returns>
        public virtual VR Apply(K1 readOnlyKey, V1 value1, V2 value2) { return default(VR); }
    }
    /*
    /// <summary>
    /// Listener for Kafka ValueJoinerWithKey. Extends <see cref="ValueJoinerWithKeyImpl{K1, V1, V2, VR}"/>
    /// </summary>
    /// <typeparam name="K1">The data associated to the event as an <see cref="JVMBridgeBase"/> object</typeparam>
    /// <typeparam name="V1">The data associated to the event as an <see cref="JVMBridgeBase"/> object</typeparam>
    /// <typeparam name="V2">The data associated to the event as an <see cref="JVMBridgeBase"/> object</typeparam>
    /// <typeparam name="VR">The aggregated data associated to the event as an <see cref="JVMBridgeBase"/> object</typeparam>
    /// <remarks>Dispose the object to avoid a resource leak, the object contains a reference to the corresponding JVM object</remarks>
    public class JVMBridgeValueJoinerWithKey<K1, V1, V2, VR> : ValueJoinerWithKeyImpl<K1, V1, V2, VR>
        where K1 : JVMBridgeBase, new()
        where V1 : JVMBridgeBase, new()
        where V2 : JVMBridgeBase, new()
        where VR : JVMBridgeBase, new()
    {
        /// <summary>
        /// Initialize a new instance of <see cref="JVMBridgeValueJoinerWithKey{K1, V1, V2, VR}"/>
        /// </summary>
        /// <param name="func">The <see cref="Func{K1, V1, V2, VR}"/> to be executed</param>
        public JVMBridgeValueJoinerWithKey(Func<K1, V1, V2, VR> func = null) : base(func, false)
        {
            AddEventHandler("apply", new EventHandler<CLRListenerEventArgs<JVMBridgeEventData<K1>>>(EventHandler));
        }

        void EventHandler(object sender, CLRListenerEventArgs<JVMBridgeEventData<K1>> data)
        {
            var retVal = OnApply(data.EventData.TypedEventData, data.EventData.To<V1>(0), data.EventData.To<V2>(1));
            data.CLRReturnValue = retVal?;
        }
    }
    */
}
