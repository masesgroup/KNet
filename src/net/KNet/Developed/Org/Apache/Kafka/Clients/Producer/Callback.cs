/*
*  Copyright 2025 MASES s.r.l.
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

namespace Org.Apache.Kafka.Clients.Producer
{
    /// <summary>
    /// Listener for Kafka Callback. Extends <see cref="IJVMBridgeBase"/>
    /// </summary>
    public partial interface ICallback : IJVMBridgeBase
    {
        /// <summary>
        /// Executes the Callback action in the CLR
        /// </summary>
        /// <param name="metadata">The <see cref="RecordMetadata"/> object</param>
        /// <param name="exception">The <see cref="JVMBridgeException"/> object</param>
        void OnCompletion(RecordMetadata metadata, JVMBridgeException exception);
    }

    /// <summary>
    /// Listener for Kafka Callback. Extends <see cref="JVMBridgeListener"/>, implements <see cref="ICallback"/>
    /// </summary>
    /// <remarks>Dispose the object to avoid a resource leak, the object contains a reference to the corresponding JVM object</remarks>
    public partial class Callback : ICallback
    {

    }
}
