/*
*  Copyright 2022 MASES s.r.l.
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
using MASES.KafkaBridge.Clients.Consumer;
using System;

namespace MASES.KafkaBridge.Streams.Processor
{
    /// <summary>
    /// Listerner for Kafka TimestampExtractor. Extends <see cref="IJVMBridgeBase"/>
    /// </summary>
    public interface ITimestampExtractor : IJVMBridgeBase
    {
        /// <summary>
        /// Executes the TimestampExtractor action in the CLR
        /// </summary>
        /// <param name="record">a data record</param>
        /// <param name="partitionTime">the highest extracted valid timestamp of the current record's partition˙ (could be -1 if unknown)</param>
        /// <returns>the timestamp of the record</returns>
        long Extract(ConsumerRecord<object, object> record, long partitionTime);
    }

    /// <summary>
    /// Listerner for Kafka TimestampExtractor. Extends <see cref="CLRListener"/>, implements <see cref="ITimestampExtractor"/>
    /// </summary>
    /// <remarks>Remember to Dispose the object otherwise there is a resource leak, the object contains a reference to the the corresponding JVM object</remarks>
    public class TimestampExtractor : CLRListener, ITimestampExtractor
    {
        /// <inheritdoc cref="CLRListener.ClassName"/>
        public sealed override string ClassName => "org.mases.kafkabridge.streams.processor.TimestampExtractorImpl";

        readonly Func<ConsumerRecord<object, object>, long, long> executionFunction = null;
        /// <summary>
        /// The <see cref="Func{ConsumerRecord{object, object}, long, long}"/> to be executed
        /// </summary>
        public virtual Func<ConsumerRecord<object, object>, long, long> OnExtract { get { return executionFunction; } }
        /// <summary>
        /// Initialize a new instance of <see cref="TimestampExtractor"/>
        /// </summary>
        /// <param name="func">The <see cref="Func{ConsumerRecord{object, object}, long, long}"/> to be executed</param>
        /// <param name="attachEventHandler">Set to false to disable attach of <see cref="EventHandler"/> and set an own one</param>
        public TimestampExtractor(Func<ConsumerRecord<object, object>, long, long> func = null, bool attachEventHandler = true)
        {
            if (func != null) executionFunction = func;
            else executionFunction = Extract;
            if (attachEventHandler)
            {
                AddEventHandler("extract", new EventHandler<CLRListenerEventArgs<CLREventData<ConsumerRecord<object, object>>>>(EventHandler));
            }
        }

        void EventHandler(object sender, CLRListenerEventArgs<CLREventData<ConsumerRecord<object, object>>> data)
        {
            var retVal = OnExtract(data.EventData.TypedEventData, data.EventData.To<long>(0));
            data.SetReturnValue(retVal);
        }
        /// <summary>
        /// Executes the TimestampExtractor action in the CLR
        /// </summary>
        /// <param name="record">a data record</param>
        /// <param name="partitionTime">the highest extracted valid timestamp of the current record's partition˙ (could be -1 if unknown)</param>
        /// <returns>the timestamp of the record</returns>
        public virtual long Extract(ConsumerRecord<object, object> record, long partitionTime) { return 0; }
    }
}
