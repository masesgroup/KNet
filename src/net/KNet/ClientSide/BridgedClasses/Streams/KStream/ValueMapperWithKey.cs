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
    /// Listener for Kafka ValueMapperWithKey. Extends <see cref="IJVMBridgeBase"/>
    /// </summary>
    /// <typeparam name="K">The key data associated to the event</typeparam>
    /// <typeparam name="V">The value data associated to the event</typeparam>
    /// <typeparam name="VR">The result data associated to the event</typeparam>
    public interface IValueMapperWithKey<K, V, VR> : IJVMBridgeBase
    {
        /// <summary>
        /// Executes the ValueMapperWithKey action in the CLR
        /// </summary>
        /// <param name="readOnlyKey">The ValueMapperWithKey readOnlyKey</param>
        /// <param name="value">The ValueMapperWithKey value</param>
        /// <returns>The apply evaluation</returns>
        VR Apply(K readOnlyKey, V value);
    }

    /// <summary>
    /// Listener for Kafka ValueMapperWithKey. Extends <see cref="JVMBridgeListener"/>, implements <see cref="IValueMapperWithKey{K, V, VR}"/>
    /// </summary>
    /// <typeparam name="K">The key data associated to the event</typeparam>
    /// <typeparam name="V">The value data associated to the event</typeparam>
    /// <typeparam name="VR">The result data associated to the event</typeparam>
    /// <remarks>Dispose the object to avoid a resource leak, the object contains a reference to the corresponding JVM object</remarks>
    public class ValueMapperWithKey<K, V, VR> : JVMBridgeListener, IValueMapperWithKey<K, V, VR>
    {
        /// <inheritdoc cref="JVMBridgeListener.ClassName"/>
        public sealed override string ClassName => "org.mases.knet.streams.kstream.ValueMapperWithKeyImpl";

        readonly Func<K, V, VR> executionFunction = null;
        /// <summary>
        /// The <see cref="Func{K, V, VR}"/> to be executed
        /// </summary>
        public virtual Func<K, V, VR> OnApply { get { return executionFunction; } }
        /// <summary>
        /// Initialize a new instance of <see cref="ValueMapperWithKey{K, V, VR}"/>
        /// </summary>
        /// <param name="func">The <see cref="Func{K, V, VR}"/> to be executed</param>
        /// <param name="attachEventHandler">Set to false to disable attach of <see cref="EventHandler"/> and set an own one</param>
        public ValueMapperWithKey(Func<K, V, VR> func = null, bool attachEventHandler = true)
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
            var retVal = OnApply(data.EventData.TypedEventData, data.EventData.To<V>(0));
            data.SetReturnValue(retVal);
        }
        /// <summary>
        /// Executes the ValueMapperWithKey action in the CLR
        /// </summary>
        /// <param name="readOnlyKey">The ValueMapperWithKey readOnlyKey</param>
        /// <param name="value">The ValueMapperWithKey value</param>
        /// <returns>The apply evaluation</returns>
        public virtual VR Apply(K readOnlyKey, V value) { return default(VR); }
    }
    /*
    /// <summary>
    /// Listener for Kafka ValueMapperWithKey. Extends <see cref="ValueMapperWithKeyImpl{K, V, VR}"/>
    /// </summary>
    /// <typeparam name="K">The key data associated to the event as an <see cref="JVMBridgeBase"/> object</typeparam>
    /// <typeparam name="V">The value data associated to the event as an <see cref="JVMBridgeBase"/> object</typeparam>
    /// <typeparam name="VR">The result data associated to the event as an <see cref="JVMBridgeBase"/> object</typeparam>
    /// <remarks>Dispose the object to avoid a resource leak, the object contains a reference to the corresponding JVM object</remarks>
    public class JVMBridgeValueMapperWithKey<K, V, VR> : ValueMapperWithKeyImpl<K, V, VR>
        where K : JVMBridgeBase, new()
        where V : JVMBridgeBase, new()
        where VR : JVMBridgeBase, new()
    {
        /// <summary>
        /// Initialize a new instance of <see cref="JVMBridgeValueMapperWithKey{K, V, VR}"/>
        /// </summary>
        /// <param name="func">The <see cref="Func{K, V, VR}"/> to be executed</param>
        public JVMBridgeValueMapperWithKey(Func<K, V, VR> func = null) : base(func, false)
        {
            AddEventHandler("apply", new EventHandler<CLRListenerEventArgs<JVMBridgeEventData<K>>>(EventHandler));
        }

        void EventHandler(object sender, CLRListenerEventArgs<JVMBridgeEventData<K>> data)
        {
            var retVal = OnApply(data.EventData.TypedEventData, data.EventData.To<V>(0));
            data.CLRReturnValue = retVal?;
        }
    }
    */
}
