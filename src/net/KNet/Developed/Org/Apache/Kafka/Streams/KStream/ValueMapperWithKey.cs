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
using System;

namespace Org.Apache.Kafka.Streams.Kstream
{
    /// <summary>
    /// Listener for Kafka ValueMapperWithKey. Extends <see cref="IJVMBridgeBase"/>
    /// </summary>
    /// <typeparam name="K">The key data associated to the event</typeparam>
    /// <typeparam name="V">The value data associated to the event</typeparam>
    /// <typeparam name="VR">The result data associated to the event</typeparam>
    public partial interface IValueMapperWithKey<K, V, VR> : IJVMBridgeBase
    {
        /// <summary>
        /// Executes the ValueMapperWithKey action in the CLR
        /// </summary>
        /// <param name="readOnlyKey">The ValueMapperWithKey readOnlyKey</param>
        /// <param name="value">The ValueMapperWithKey value</param>
        /// <returns>The apply evaluation</returns>
        VR Apply(K readOnlyKey, V value);
    }

    /// <summary>
    /// Listener for Kafka ValueMapperWithKey. Extends <see cref="JVMBridgeListener"/>, implements <see cref="IValueMapperWithKey{K, V, VR}"/>
    /// </summary>
    /// <remarks>Dispose the object to avoid a resource leak, the object contains a reference to the corresponding JVM object</remarks>
    public partial class ValueMapperWithKey<K, V, VR> : IValueMapperWithKey<K, V, VR>
    {

    }
}
