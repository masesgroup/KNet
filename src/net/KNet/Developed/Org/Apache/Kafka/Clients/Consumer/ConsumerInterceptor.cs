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
using Org.Apache.Kafka.Common;
using Java.Util;
using System;

namespace Org.Apache.Kafka.Clients.Consumer
{
    /// <summary>
    /// Listener for Kafka ConsumerInterceptor. Extends <see cref="IJVMBridgeBase"/>
    /// </summary>
    public partial interface IConsumerInterceptor<K, V> : IJVMBridgeBase
    {
        /// <summary>
        /// Configure this class with the given key-value pairs
        /// </summary>
        /// <param name="configs">The configuration <see cref="Map"/></param>
        void Configure(Map<string, Java.Lang.Object> configs);
        /// <summary>
        /// This is called just before the records are returned by <see cref="KafkaConsumer{K,V}.Poll(Java.Time.Duration)"/>
        /// </summary>
        /// <param name="records">records records to be consumed by the client or records returned by the previous interceptors in the list</param>
        /// <returns>records that are either modified by the interceptor or same as records passed to this method</returns>
        ConsumerRecords<K, V> OnConsume(ConsumerRecords<K, V> records);
        /// <summary>
        /// This is called when offsets get committed.
        /// </summary>
        /// <param name="offsets">A <see cref="Map"/> of offsets by partition with associated metadata</param>
        void OnCommit(Map<TopicPartition, OffsetAndMetadata> offsets);
        /// <summary>
        /// This is called when interceptor is closed
        /// </summary>
        void Close();
    }

    /// <summary>
    /// Listener for Kafka ConsumerRebalanceListener. Extends <see cref="JVMBridgeListener"/>, implements <see cref="IConsumerInterceptor{K, V}"/>
    /// </summary>
    /// <remarks>Dispose the object to avoid a resource leak, the object contains a reference to the corresponding JVM object</remarks>
    public partial class ConsumerInterceptor<K, V> : IConsumerInterceptor<K, V>
    {
        /// <inheritdoc cref="IConsumerInterceptor{K, V}.Configure"/>
        public virtual void Configure(Map<string, Java.Lang.Object> configs)
        {

        }
    }
}
