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
using MASES.KafkaBridge.Common;
using MASES.KafkaBridge.Java.Util;
using System;

namespace MASES.KafkaBridge.Clients.Consumer
{
    /// <summary>
    /// Listerner for Kafka ConsumerRebalanceListener. Extends <see cref="IJVMBridgeBase"/>
    /// </summary>
    public interface IConsumerRebalanceListener : IJVMBridgeBase
    {
        /// <summary>
        /// Executes the Callback action in the CLR
        /// </summary>
        /// <param name="partitions">The <see cref="Collection{TopicPartition}"/> object</param>
        void OnPartitionsRevoked(Collection<TopicPartition> partitions);
        /// <summary>
        /// Executes the Callback action in the CLR
        /// </summary>
        /// <param name="partitions">The <see cref="Collection{TopicPartition}"/> object</param>
        void OnPartitionsAssigned(Collection<TopicPartition> partitions);
    }

    /// <summary>
    /// Listerner for Kafka ConsumerRebalanceListener. Extends <see cref="CLRListener"/>, implements <see cref="IConsumerRebalanceListener"/>
    /// </summary>
    /// <remarks>Remember to Dispose the object otherwise there is a resource leak, the object contains a reference to the the corresponding JVM object</remarks>
    public class ConsumerRebalanceListener : CLRListener, IConsumerRebalanceListener
    {
        /// <inheritdoc cref="CLRListener.ClassName"/>
        public sealed override string ClassName => "org.mases.kafkabridge.clients.consumer.ConsumerRebalanceListenerImpl";

        readonly Action<Collection<TopicPartition>> revokedFunction = null;
        readonly Action<Collection<TopicPartition>> assignedFunction = null;
        /// <summary>
        /// The <see cref="Action{Collection{TopicPartition}}"/> to be executed on Revoked partitions
        /// </summary>
        public virtual Action<Collection<TopicPartition>> OnOnPartitionsRevoked { get { return revokedFunction; } }
        /// <summary>
        /// The <see cref="Action{Collection{TopicPartition}}"/> to be executed on Revoked partitions
        /// </summary>
        public virtual Action<Collection<TopicPartition>> OnOnPartitionsAssigned { get { return assignedFunction; } }
        /// <summary>
        /// Initialize a new instance of <see cref="ConsumerRebalanceListener"/>
        /// </summary>
        /// <param name="revoked">The <see cref="Action{Collection{TopicPartition}}"/> to be executed on revoked partitions</param>
        /// <param name="assigned">The <see cref="Action{Collection{TopicPartition}}"/> to be executed on assigned partitions</param>
        public ConsumerRebalanceListener(Action<Collection<TopicPartition>> revoked = null, Action<Collection<TopicPartition>> assigned = null)
        {
            if (revoked != null) revokedFunction = revoked;
            else revokedFunction = OnPartitionsRevoked;
            if (assigned != null) assignedFunction = assigned;
            else assignedFunction = OnPartitionsAssigned;

            AddEventHandler("onPartitionsRevoked", new EventHandler<CLRListenerEventArgs<CLREventData<Collection<TopicPartition>>>>(EventHandlerRevoked));
            AddEventHandler("onPartitionsAssigned", new EventHandler<CLRListenerEventArgs<CLREventData<Collection<TopicPartition>>>>(EventHandlerAssigned));
        }

        void EventHandlerRevoked(object sender, CLRListenerEventArgs<CLREventData<Collection<TopicPartition>>> data)
        {
            OnOnPartitionsRevoked(data.EventData.TypedEventData);
        }

        void EventHandlerAssigned(object sender, CLRListenerEventArgs<CLREventData<Collection<TopicPartition>>> data)
        {
            OnOnPartitionsAssigned(data.EventData.TypedEventData);
        }
        /// <summary>
        /// Executes the Callback action in the CLR
        /// </summary>
        /// <param name="partitions">The <see cref="Collection{TopicPartition}"/> object</param>
        public virtual void OnPartitionsRevoked(Collection<TopicPartition> partitions) { }
        /// <summary>
        /// Executes the Callback action in the CLR
        /// </summary>
        /// <param name="partitions">The <see cref="Collection{TopicPartition}"/> object</param>
        public virtual void OnPartitionsAssigned(Collection<TopicPartition> partitions) { }
    }
}
