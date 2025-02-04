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

namespace Org.Apache.Kafka.Streams.Processor
{
    /// <summary>
    /// Listener for Kafka TopicNameExtractor. Extends <see cref="IJVMBridgeBase"/>
    /// </summary>
    public partial interface ITopicNameExtractor : IJVMBridgeBase
    {
    }

    /// <summary>
    /// Listener for Kafka TopicNameExtractor. Extends <see cref="ITopicNameExtractor"/>
    /// </summary>
    public partial interface ITopicNameExtractor<K, V> : ITopicNameExtractor
    {
        /// <summary>
        /// Executes the TopicNameExtractor action in the CLR
        /// </summary>
        /// <param name="key">the record key</param>
        /// <param name="value">the record value</param>
        /// <param name="recordContext">current context metadata of the record</param>
        /// <returns>the topic name this record should be sent to</returns>
        Java.Lang.String Extract(K key, V value, RecordContext recordContext);
    }

    /// <summary>
    /// Listener for Kafka TopicNameExtractor. Extends <see cref="JVMBridgeListener"/>, implements <see cref="ITopicNameExtractor{K, V}"/>
    /// </summary>
    /// <remarks>Dispose the object to avoid a resource leak, the object contains a reference to the corresponding JVM object</remarks>
    public partial class TopicNameExtractor<K, V> : ITopicNameExtractor<K, V>
    {

    }
}
