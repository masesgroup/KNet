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
using MASES.JCOBridge.C2JBridge.JVMInterop;
using System;

namespace MASES.KafkaBridge.Clients.Producer
{
    /// <summary>
    /// Listerner for Kafka Callback. Extends <see cref="CLRListener"/>
    /// </summary>
    /// <remarks>Remember to Dispose the object otherwise there is a resource leak, the object contains a reference to the the corresponding JVM object</remarks>
    public class Callback : CLRListener
    {
        /// <inheritdoc cref="CLRListener.JniClass"/>
        public sealed override string JniClass => "org.mases.kafkabridge.clients.producer.CallbackImpl";

        readonly Action<RecordMetadata, JVMBridgeException> executionFunction = null;
        /// <summary>
        /// The <see cref="Action{RecordMetadata, JVMBridgeException}"/> to be executed
        /// </summary>
        public virtual Action<RecordMetadata, JVMBridgeException> Execute { get { return executionFunction; } }
        /// <summary>
        /// Initialize a new instance of <see cref="Callback"/>
        /// </summary>
        /// <param name="action">The <see cref="Action{RecordMetadata, JVMBridgeException}"/> to be executed</param>
        public Callback(Action<RecordMetadata, JVMBridgeException> action = null)
        {
            if (action != null) executionFunction = action;
            else executionFunction = OnCompletion;

            AddEventHandler("onCompletion", new EventHandler<CLRListenerEventArgs<JVMBridgeEventData<RecordMetadata>>>(EventHandler));
        }

        void EventHandler(object sender, CLRListenerEventArgs<JVMBridgeEventData<RecordMetadata>> data)
        {
            var exception = data.EventData.ExtraData.Get(0) as IJavaObject;
            Execute(data.EventData.TypedEventData, JVMBridgeException.New(exception));
        }
        /// <summary>
        /// Executes the Callback action in the CLR
        /// </summary>
        /// <param name="metadata">The <see cref="RecordMetadata"/> object</param>
        /// <param name="exception">The <see cref="JVMBridgeException"/> object</param>
        /// <returns>The onCompletion evaluation</returns>
        public virtual void OnCompletion(RecordMetadata metadata, JVMBridgeException exception) { }
    }
}
