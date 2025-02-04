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
using System;

namespace Org.Apache.Kafka.Streams.Processor
{
    /// <summary>
    /// Listener for Kafka StateRestoreListener. Extends <see cref="IJVMBridgeBase"/>
    /// </summary>
    public partial interface IStateRestoreListener : IJVMBridgeBase
    {
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.5.0/org/apache/kafka/streams/processor/StateRestoreListener.html#onRestoreStart-org.apache.kafka.common.TopicPartition-java.lang.String-long-long-"/>
        /// </summary>
        void OnRestoreStart(TopicPartition topicPartition,
                               Java.Lang.String storeName,
                               long startingOffset,
                               long endingOffset);

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.5.0/org/apache/kafka/streams/processor/StateRestoreListener.html#onBatchRestored-org.apache.kafka.common.TopicPartition-java.lang.String-long-long-"/>
        /// </summary>
        void OnBatchRestored(TopicPartition topicPartition,
                              Java.Lang.String storeName,
                              long batchEndOffset,
                              long numRestored);
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.5.0/org/apache/kafka/streams/processor/StateRestoreListener.html#onRestoreEnd-org.apache.kafka.common.TopicPartition-java.lang.String-long-"/>
        /// </summary>
        void OnRestoreEnd(TopicPartition topicPartition,
                           Java.Lang.String storeName,
                           long totalRestored);
    }

    /// <summary>
    /// Listener for Kafka StateRestoreListener. Extends <see cref="JVMBridgeListener"/>, implements <see cref="IStateRestoreListener"/>
    /// </summary>
    /// <remarks>Dispose the object to avoid a resource leak, the object contains a reference to the corresponding JVM object</remarks>
    public partial class StateRestoreListener : IStateRestoreListener
    {

    }
}
