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
    /// Listener for Kafka ValueJoinerWithKey. Extends <see cref="IJVMBridgeBase"/>
    /// </summary>
    /// <typeparam name="K1">The data associated to the event</typeparam>
    /// <typeparam name="V1">The data associated to the event</typeparam>
    /// <typeparam name="V2">The data associated to the event</typeparam>
    /// <typeparam name="VR">Joined value</typeparam>
    public partial interface IValueJoinerWithKey<K1, V1, V2, VR> : IJVMBridgeBase
    {
        /// <summary>
        /// Executes the ValueJoinerWithKey action in the CLR
        /// </summary>
        /// <param name="readOnlyKey">The ValueJoinerWithKey object</param>
        /// <param name="value1">The ValueJoinerWithKey object</param>
        /// <param name="value2">The current aggregate value</param>
        /// <returns>The <typeparamref name="VR"/> apply evaluation</returns>
        VR Apply(K1 readOnlyKey, V1 value1, V2 value2);
    }

    /// <summary>
    /// Listener for Kafka ValueJoinerWithKey. Extends <see cref="JVMBridgeListener"/>, implements <see cref="IValueJoinerWithKey{K1, V1, V2, VR}"/>
    /// </summary>
    /// <remarks>Dispose the object to avoid a resource leak, the object contains a reference to the corresponding JVM object</remarks>
    public partial class ValueJoinerWithKey<K1, V1, V2, VR> : IValueJoinerWithKey<K1, V1, V2, VR>
    {

    }
}
