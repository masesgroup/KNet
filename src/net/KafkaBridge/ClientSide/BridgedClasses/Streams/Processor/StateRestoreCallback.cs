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

namespace MASES.KafkaBridge.Streams.Processor
{
    /// <summary>
    /// Listener for Kafka StateRestoreCallback. Extends <see cref="IJVMBridgeBase"/>
    /// </summary>
    public interface IStateRestoreCallback : IJVMBridgeBase
    {
        /// <summary>
        /// Executes the StateRestoreCallback action in the CLR
        /// </summary>
        /// <param name="key">The StateRestoreCallback key</param>
        /// <param name="value">The StateRestoreCallback value</param>
        /// <returns>The <typeparamref name="VR"/> apply evaluation</returns>
        void Restore(byte[] key, byte[] value);
    }

    /// <summary>
    /// Listener for Kafka StateRestoreCallback. Extends <see cref="JVMBridgeListener"/>, implements <see cref="IStateRestoreCallback"/>
    /// </summary>
    /// <remarks>Remember to Dispose the object otherwise there is a resource leak, the object contains a reference to the the corresponding JVM object</remarks>
    public class StateRestoreCallback : JVMBridgeListener, IStateRestoreCallback
    {
        /// <inheritdoc cref="JVMBridgeListener.ClassName"/>
        public sealed override string ClassName => "org.mases.kafkabridge.streams.processor.StateRestoreCallbackImpl";

        readonly Action<byte[], byte[]> executionFunction = null;
        /// <summary>
        /// The <see cref="Action{byte[], byte[]}"/> to be executed
        /// </summary>
        public virtual Action<byte[], byte[]> OnRestore { get { return executionFunction; } }
        /// <summary>
        /// Initialize a new instance of <see cref="StateRestoreCallback"/>
        /// </summary>
        /// <param name="func">The <see cref="Action{byte[], byte[]}"/> to be executed</param>
        /// <param name="attachEventHandler">Set to false to disable attach of <see cref="EventHandler"/> and set an own one</param>
        public StateRestoreCallback(Action<byte[], byte[]> func = null, bool attachEventHandler = true)
        {
            if (func != null) executionFunction = func;
            else executionFunction = Restore;
            if (attachEventHandler)
            {
                AddEventHandler("restore", new EventHandler<CLRListenerEventArgs<CLREventData<byte[]>>>(EventHandler));
            }
        }

        void EventHandler(object sender, CLRListenerEventArgs<CLREventData<byte[]>> data)
        {
            OnRestore(data.EventData.TypedEventData, data.EventData.To<byte[]>(0));
        }
        /// <summary>
        /// Executes the StateRestoreCallback action in the CLR
        /// </summary>
        /// <param name="key">The StateRestoreCallback key</param>
        /// <param name="value">The StateRestoreCallback value</param>
        /// <returns>The <typeparamref name="VR"/> apply evaluation</returns>
        public virtual void Restore(byte[] key, byte[] value) { }
    }
}
