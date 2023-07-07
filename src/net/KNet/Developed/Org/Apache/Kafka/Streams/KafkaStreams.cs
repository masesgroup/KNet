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
using MASES.JCOBridge.C2JBridge.JVMInterop;
using Org.Apache.Kafka.Common;
using Org.Apache.Kafka.Common.Serialization;
using Org.Apache.Kafka.Common.Utils;
using Java.Time;
using Java.Util;
using Org.Apache.Kafka.Streams.Errors;
using Org.Apache.Kafka.Streams.Processor;
using Org.Apache.Kafka.Streams.Query;
using Java.Lang;
using System;

namespace Org.Apache.Kafka.Streams
{
    public partial class KafkaStreams
    {
        /// <summary>
        /// .NET interface for <see cref="StateListener"/>
        /// </summary>
        public interface IStateListener : IJVMBridgeBase
        {
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.5.0/org/apache/kafka/streams/KafkaStreams.StateListener.html#onChange-org.apache.kafka.streams.KafkaStreams.State-org.apache.kafka.streams.KafkaStreams.State-"/>
            /// </summary>
            void OnChange(Org.Apache.Kafka.Streams.KafkaStreams.State newState, Org.Apache.Kafka.Streams.KafkaStreams.State oldState);
        }

        /// <summary>
        /// Listener for Kafka StateListener. Extends <see cref="JVMBridgeListener"/>, implements <see cref="IStateListener"/>
        /// </summary>
        /// <remarks>Dispose the object to avoid a resource leak, the object contains a reference to the corresponding JVM object</remarks>
        public partial class StateListener : IStateListener
        {

        }
    }
}

