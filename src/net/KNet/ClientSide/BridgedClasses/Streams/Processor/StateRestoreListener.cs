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
using MASES.KNet.Common;
using System;

namespace MASES.KNet.Streams.Processor
{
    /// <summary>
    /// Listener for Kafka StateRestoreListener. Extends <see cref="IJVMBridgeBase"/>
    /// </summary>
    public interface IStateRestoreListener : IJVMBridgeBase
    {
        void OnRestoreStart(TopicPartition topicPartition,
                               string storeName,
                               long startingOffset,
                               long endingOffset);


        void OnBatchRestored(TopicPartition topicPartition,
                              string storeName,
                              long batchEndOffset,
                              long numRestored);

        void OnRestoreEnd(TopicPartition topicPartition,
                           string storeName,
                           long totalRestored);
    }

    /// <summary>
    /// Listener for Kafka StateRestoreListener. Extends <see cref="JVMBridgeListener"/>, implements <see cref="IStateRestoreListener"/>
    /// </summary>
    /// <remarks>Dispose the object to avoid a resource leak, the object contains a reference to the corresponding JVM object</remarks>
    public class StateRestoreListener : JVMBridgeListener, IStateRestoreListener
    {
        /// <inheritdoc cref="JVMBridgeListener.ClassName"/>
        public sealed override string ClassName => "org.mases.knet.streams.processor.StateRestoreListenerImpl";

        readonly Action<TopicPartition, string, long, long> OnRestoreStartFunction = null;
        readonly Action<TopicPartition, string, long, long> OnBatchRestoredFunction = null;
        readonly Action<TopicPartition, string, long> OnRestoreEndFunction = null;
        /// <summary>
        /// The <see cref="Action{TopicPartition, string, long, long}"/> to be executed
        /// </summary>
        public virtual Action<TopicPartition, string, long, long> OnOnRestoreStart { get { return OnRestoreStartFunction; } }
        /// <summary>
        /// The <see cref="Action{TopicPartition, string, long, long}"/> to be executed
        /// </summary>
        public virtual Action<TopicPartition, string, long, long> OnOnBatchRestored { get { return OnBatchRestoredFunction; } }
        /// <summary>
        /// The <see cref="Action{TopicPartition, string, long}"/> to be executed
        /// </summary>
        public virtual Action<TopicPartition, string, long> OnOnRestoreEnd { get { return OnRestoreEndFunction; } }
        /// <summary>
        /// Initialize a new instance of <see cref="StateRestoreListener"/>
        /// </summary>
        /// <param name="onRestoreStartFunction">The <see cref="Action{TopicPartition, string, long, long}"/> to be executed</param>
        /// <param name="onBatchRestoredFunction">The <see cref="Action{TopicPartition, string, long, long}"/> to be executed</param>
        /// <param name="onRestoreEndFunction">The <see cref="Action{TopicPartition, string, long}"/> to be executed</param>
        /// <param name="attachEventHandler">Set to false to disable attach of <see cref="EventHandler"/> and set an own one</param>
        public StateRestoreListener(Action<TopicPartition, string, long, long> onRestoreStartFunction = null,
                                        Action<TopicPartition, string, long, long> onBatchRestoredFunction = null,
                                        Action<TopicPartition, string, long> onRestoreEndFunction = null,
                                        bool attachEventHandler = true)
        {
            if (onRestoreStartFunction != null) OnRestoreStartFunction = onRestoreStartFunction;
            else OnRestoreStartFunction = OnRestoreStart;

            if (onBatchRestoredFunction != null) OnBatchRestoredFunction = onBatchRestoredFunction;
            else OnBatchRestoredFunction = OnBatchRestored;

            if (onRestoreEndFunction != null) OnRestoreEndFunction = onRestoreEndFunction;
            else OnRestoreEndFunction = OnRestoreEnd;

            if (attachEventHandler)
            {
                AddEventHandler("onRestoreStart", new EventHandler<CLRListenerEventArgs<CLREventData<TopicPartition>>>(EventHandler_onRestoreStart));
                AddEventHandler("onBatchRestored", new EventHandler<CLRListenerEventArgs<CLREventData<TopicPartition>>>(EventHandler_onBatchRestored));
                AddEventHandler("onRestoreEnd", new EventHandler<CLRListenerEventArgs<CLREventData<TopicPartition>>>(EventHandler_onRestoreEnd));
            }
        }

        void EventHandler_onRestoreStart(object sender, CLRListenerEventArgs<CLREventData<TopicPartition>> data)
        {
            OnOnRestoreStart(data.EventData.TypedEventData, data.EventData.To<string>(0), data.EventData.To<long>(1), data.EventData.To<long>(2));
        }

        void EventHandler_onBatchRestored(object sender, CLRListenerEventArgs<CLREventData<TopicPartition>> data)
        {
            OnOnBatchRestored(data.EventData.TypedEventData, data.EventData.To<string>(0), data.EventData.To<long>(1), data.EventData.To<long>(2));
        }

        void EventHandler_onRestoreEnd(object sender, CLRListenerEventArgs<CLREventData<TopicPartition>> data)
        {
            OnOnRestoreEnd(data.EventData.TypedEventData, data.EventData.To<string>(0), data.EventData.To<long>(1));
        }

        public virtual void OnRestoreStart(TopicPartition topicPartition, string storeName, long startingOffset, long endingOffset)
        {

        }

        public virtual void OnBatchRestored(TopicPartition topicPartition, string storeName, long batchEndOffset, long numRestored)
        {

        }

        public virtual void OnRestoreEnd(TopicPartition topicPartition, string storeName, long totalRestored)
        {

        }
    }
}
