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
using MASES.JCOBridge.C2JBridge.JVMInterop;
using Org.Apache.Kafka.Common.Header;
using System;

namespace Org.Apache.Kafka.Common.Serialization
{
    /// <summary>
    /// Listener for Kafka Deserializer. Extends <see cref="IJVMBridgeBase"/>
    /// </summary>
    public partial interface IDeserializer : IJVMBridgeBase
    {
    }

    /// <summary>
    /// Listener for Kafka Deserializer. Extends <see cref="Deserializer"/>
    /// </summary>
    /// <typeparam name="T">The data associated to the event</typeparam>
    public partial interface IDeserializer<T> : IDeserializer
    {
        /// <summary>
        /// Executes the Deserializer action in the CLR
        /// </summary>
        /// <param name="topic">topic associated with the data</param>
        /// <param name="data">serialized bytes; may be null; implementations are recommended to handle null by returning a value or null rather than throwing an exception</param>
        /// <returns>The deserialized <typeparamref name="T"/></returns>
        T Deserialize(Java.Lang.String topic, byte[] data);
        /// <summary>
        /// Executes the Deserializer action in the CLR
        /// </summary>
        /// <param name="topic">topic associated with the data</param>
        /// <param name="headers"><see cref="Headers"/> associated with the record; may be empty.</param>
        /// <param name="data">serialized bytes; may be null; implementations are recommended to handle null by returning a value or null rather than throwing an exception</param>
        /// <returns>The deserialized <typeparamref name="T"/></returns>
        T Deserialize(Java.Lang.String topic, Headers headers, byte[] data);
    }

    /// <summary>
    /// Listener for Kafka Deserializer. Extends <see cref="IDeserializer{E}"/>
    /// </summary>
    /// <remarks>Dispose the object to avoid a resource leak, the object contains a reference to the corresponding JVM object</remarks>
    public partial class Deserializer<T> : IDeserializer<T>
    {

    }
}
