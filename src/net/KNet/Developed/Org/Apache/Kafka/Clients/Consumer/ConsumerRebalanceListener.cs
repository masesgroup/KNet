/*
*  Copyright (c) 2021-2025 MASES s.r.l.
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
using Org.Apache.Kafka.Common;
using Java.Util;
using System;

namespace Org.Apache.Kafka.Clients.Consumer
{
    /// <summary>
    /// Listener for Kafka ConsumerRebalanceListener. Extends <see cref="IJVMBridgeBase"/>
    /// </summary>
    public partial interface IConsumerRebalanceListener : IJVMBridgeBase
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
    /// Listener for Kafka ConsumerRebalanceListener. Extends <see cref="JVMBridgeListener"/>, implements <see cref="IConsumerRebalanceListener"/>
    /// </summary>
    /// <remarks>Dispose the object to avoid a resource leak, the object contains a reference to the corresponding JVM object</remarks>
    public partial class ConsumerRebalanceListener : IConsumerRebalanceListener
    {

    }
}
