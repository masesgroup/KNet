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
using System;

namespace Org.Apache.Kafka.Streams.Kstream
{
    /// <summary>
    /// Listener for Kafka KeyValueMapper. Extends <see cref="IJVMBridgeBase"/>
    /// </summary>
    /// <typeparam name="K">The data associated to the event</typeparam>
    /// <typeparam name="V">The data associated to the event</typeparam>
    /// <typeparam name="VR">The result value</typeparam>
    public partial interface IKeyValueMapper<K, V, VR> : IJVMBridgeBase
    {
        /// <summary>
        /// Executes the KeyValueMapper action in the CLR
        /// </summary>
        /// <param name="o1">The KeyValueMapper object</param>
        /// <param name="o2">The KeyValueMapper object</param>
        /// <returns>The <typeparamref name="VR"/> apply evaluation</returns>
        VR Apply(K o1, V o2);
    }

    /// <summary>
    /// Listener for Kafka KeyValueMapper. Extends <see cref="JVMBridgeListener"/>, implements <see cref="IKeyValueMapper{K, V, VR}"/>
    /// </summary>
    /// <remarks>Dispose the object to avoid a resource leak, the object contains a reference to the corresponding JVM object</remarks>
    public partial class KeyValueMapper<K, V, VR> : IKeyValueMapper<K, V, VR>
    {

    }
}
