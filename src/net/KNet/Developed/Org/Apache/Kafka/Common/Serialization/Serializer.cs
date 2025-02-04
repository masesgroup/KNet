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
using Org.Apache.Kafka.Common.Header;
using System;

namespace Org.Apache.Kafka.Common.Serialization
{
    /// <summary>
    /// Listener for Kafka Serializer. Extends <see cref="IJVMBridgeBase"/>
    /// </summary>
    public partial interface ISerializer : IJVMBridgeBase
    {
    }

    /// <summary>
    /// Listener for Kafka Serializer. Extends <see cref="Serializer"/>
    /// </summary>
    /// <typeparam name="T">The data associated to the event</typeparam>
    public partial interface ISerializer<T> : ISerializer
    {
        /// <summary>
        /// Executes the Serializer action in the CLR
        /// </summary>
        /// <param name="topic">topic associated with the data</param>
        /// <param name="data"><typeparamref name="T"/> data</param>
        /// <returns>serialized bytes</returns>
        byte[] Serialize(Java.Lang.String topic, T data);
        /// <summary>
        /// Executes the Serializer action in the CLR
        /// </summary>
        /// <param name="topic">topic associated with the data</param>
        /// <param name="headers"><see cref="Headers"/> associated with the record; may be empty.</param>
        /// <param name="data"><typeparamref name="T"/> data</param>
        /// <returns>serialized bytes</returns>
        byte[] Serialize(Java.Lang.String topic, Headers headers, T data);
    }
    /// <summary>
    /// Listener for Kafka Serializer. Extends <see cref="JVMBridgeListener"/>. Implements <see cref="ISerializer{T}"/>
    /// </summary>
    /// <remarks>Dispose the object to avoid a resource leak, the object contains a reference to the corresponding JVM object</remarks>
    public partial class Serializer<T> : ISerializer<T>
    {
    }
}
