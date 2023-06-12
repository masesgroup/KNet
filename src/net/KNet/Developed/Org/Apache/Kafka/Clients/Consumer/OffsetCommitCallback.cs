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
using MASES.JCOBridge.C2JBridge.JVMInterop;
using Org.Apache.Kafka.Common;
using Java.Util;
using System;

namespace Org.Apache.Kafka.Clients.Consumer
{
    /// <summary>
    /// Listener for Kafka OffsetCommitCallback. Extends <see cref="IJVMBridgeBase"/>
    /// </summary>
    public partial interface IOffsetCommitCallback : IJVMBridgeBase
    {
        /// <summary>
        /// Executes the Callback action in the CLR
        /// </summary>
        /// <param name="offsets">The <see cref="Map{TopicPartition, OffsetAndMetadata}"/> object</param>
        /// <param name="exception">The <see cref="JVMBridgeException"/> object</param>
        void OnComplete(Map<TopicPartition, OffsetAndMetadata> offsets, JVMBridgeException exception);
    }

    /// <summary>
    /// Listener for Kafka OffsetCommitCallback. Extends <see cref="JVMBridgeListener"/>, implements <see cref="IOffsetCommitCallback"/>
    /// </summary>
    /// <remarks>Dispose the object to avoid a resource leak, the object contains a reference to the corresponding JVM object</remarks>
    public partial class OffsetCommitCallback : IOffsetCommitCallback
    {
        /// <inheritdoc cref="JVMBridgeListener.ClassName"/>
         public sealed override string BridgeClassName => "org.mases.knet.clients.consumer.OffsetCommitCallbackImpl";

        readonly Action<Map<TopicPartition, OffsetAndMetadata>, JVMBridgeException> executionFunction = null;
        /// <summary>
        /// The <see cref="Action{Map{TopicPartition, OffsetAndMetadata}, JVMBridgeException}"/> to be executed
        /// </summary>
        public virtual Action<Map<TopicPartition, OffsetAndMetadata>, JVMBridgeException> OnOnComplete { get { return executionFunction; } }
        /// <summary>
        /// Initialize a new instance of <see cref="OffsetCommitCallback"/>
        /// </summary>
        /// <param name="action">The <see cref="Action{Map{TopicPartition, OffsetAndMetadata}, JVMBridgeException}"/> to be executed</param>
        public OffsetCommitCallback(Action<Map<TopicPartition, OffsetAndMetadata>, JVMBridgeException> action = null)
        {
            if (action != null) executionFunction = action;
            else executionFunction = OnComplete;

            AddEventHandler("onComplete", new EventHandler<CLRListenerEventArgs<CLREventData<Map<TopicPartition, OffsetAndMetadata>>>>(EventHandler));
        }

        void EventHandler(object sender, CLRListenerEventArgs<CLREventData<Map<TopicPartition, OffsetAndMetadata>>> data)
        {
            var exception = data.EventData.ExtraData.Get(0) as IJavaObject;
            OnOnComplete(data.EventData.TypedEventData, JVMBridgeException.New(exception));
        }
    }
}
