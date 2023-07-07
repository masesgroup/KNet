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
    /// Listener for Kafka Aggregator. Extends <see cref="IJVMBridgeBase"/>
    /// </summary>
    /// <typeparam name="K">The data associated to the event</typeparam>
    /// <typeparam name="V">The data associated to the event</typeparam>
    /// <typeparam name="VA">Aggregated value</typeparam>
    public partial interface IAggregator<K, V, VA> : IJVMBridgeBase
    {
        /// <summary>
        /// Executes the Aggregator action in the CLR
        /// </summary>
        /// <param name="o1">The Aggregator object</param>
        /// <param name="o2">The Aggregator object</param>
        /// <param name="aggregate">The current aggregate value</param>
        /// <returns>The <typeparamref name="VA"/> apply evaluation</returns>
        VA Apply(K o1, V o2, VA aggregate);
    }

    /// <summary>
    /// Listener for Kafka Aggregator. Extends <see cref="JVMBridgeListener"/>, implements <see cref="IAggregator{K, V, VA}"/>
    /// </summary>
    /// <remarks>Dispose the object to avoid a resource leak, the object contains a reference to the corresponding JVM object</remarks>
    public partial class Aggregator<K, V, VA> : IAggregator<K, V, VA>
    {

    }
}
