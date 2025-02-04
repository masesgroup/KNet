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
using System;

namespace Org.Apache.Kafka.Streams.Kstream
{
    /// <summary>
    /// Listener for Kafka ValueJoiner. Extends <see cref="IJVMBridgeBase"/>
    /// </summary>
    /// <typeparam name="V1">The data associated to the event</typeparam>
    /// <typeparam name="V2">The data associated to the event</typeparam>
    /// <typeparam name="VR">Aggregated value</typeparam>
    public partial interface IValueJoiner<V1, V2, VR> : IJVMBridgeBase
    {
        /// <summary>
        /// Executes the ValueJoiner action in the CLR
        /// </summary>
        /// <param name="value1">The ValueJoiner object</param>
        /// <param name="value2">The ValueJoiner object</param>
        /// <returns>The <typeparamref name="VR"/> apply evaluation</returns>
        VR Apply(V1 value1, V2 value2);
    }

    /// <summary>
    /// Listener for Kafka ValueJoiner. Extends <see cref="JVMBridgeListener"/>, implements <see cref="IValueJoiner{V1, V2, VR}"/>
    /// </summary>
    /// <remarks>Dispose the object to avoid a resource leak, the object contains a reference to the corresponding JVM object</remarks>
    public partial class ValueJoiner<V1, V2, VR> : IValueJoiner<V1, V2, VR>
    {

    }
}
