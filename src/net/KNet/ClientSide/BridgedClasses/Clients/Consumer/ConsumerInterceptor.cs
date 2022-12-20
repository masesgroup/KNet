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
using Java.Util;
using System;

namespace MASES.KNet.Clients.Consumer
{
    /// <summary>
    /// Listener for Kafka ConsumerInterceptor. Extends <see cref="IJVMBridgeBase"/>
    /// </summary>
    public interface IConsumerInterceptor<K, V> : IJVMBridgeBase
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
    public class ConsumerInterceptor<K, V> : JVMBridgeListener, IConsumerInterceptor<K, V>
    {
        /// <inheritdoc cref="JVMBridgeListener.ClassName"/>
        public sealed override string ClassName => "org.mases.knet.clients.consumer.ConsumerInterceptorImpl";

        readonly Action<Map<string, Java.Lang.Object>> configureFunction = null;
        readonly Func<ConsumerRecords<K, V>, ConsumerRecords<K, V>> onConsumeFunction = null;
        readonly Action<Map<TopicPartition, OffsetAndMetadata>> onCommitFunction = null;
        readonly Action closeFunction = null;
        /// <summary>
        /// The <see cref="Action{Map{string, Java.Lang.Object}}"/> to be executed on Configure
        /// </summary>
        public virtual Action<Map<string, Java.Lang.Object>> OnConfigure { get { return configureFunction; } }
        /// <summary>
        /// The <see cref="Func{ConsumerRecords{K, V}, ConsumerRecords{K, V}}"/> to be executed on OnConsume
        /// </summary>
        public virtual Func<ConsumerRecords<K, V>, ConsumerRecords<K, V>> OnOnConsume { get { return onConsumeFunction; } }
        /// <summary>
        /// The <see cref="Action{Map{TopicPartition, OffsetAndMetadata}}"/> to be executed on OnCommit
        /// </summary>
        public virtual Action<Map<TopicPartition, OffsetAndMetadata>> OnOnCommit { get { return onCommitFunction; } }
        /// <summary>
        /// The <see cref="Action"/> to be executed on Close
        /// </summary>
        public virtual Action OnClose { get { return closeFunction; } }
        /// <summary>
        /// Initialize a new instance of <see cref="ConsumerInterceptor"/>
        /// </summary>
        /// <param name="onConsume">The <see cref="Action{Map{string, Java.Lang.Object}}"/> to be executed on Configure</param>
        /// <param name="onConsume">The <see cref="Func{ConsumerRecords{K, V}, ConsumerRecords{K, V}}"/> to be executed on OnConsume</param>
        /// <param name="onCommit">The <see cref="Action{Map{TopicPartition, OffsetAndMetadata}}"/> to be executed on OnCommit</param>
        /// <param name="onClose">The <see cref="Action"/> to be executed on Close</param>
        /// <param name="attachEventHandler">Set to false to disable attach of <see cref="EventHandler"/> and set an own one</param>
        public ConsumerInterceptor(Action<Map<string, Java.Lang.Object>> configure = null,
                                   Func<ConsumerRecords<K, V>, ConsumerRecords<K, V>> onConsume = null,
                                   Action<Map<TopicPartition, OffsetAndMetadata>> onCommit = null,
                                   Action onClose = null,
                                   bool attachEventHandler = true)
        {
            if (configure != null) configureFunction = configure;
            else configureFunction = Configure;
            if (onConsume != null) onConsumeFunction = onConsume;
            else onConsumeFunction = OnConsume;
            if (onCommit != null) onCommitFunction = onCommit;
            else onCommitFunction = OnCommit;
            if (onClose != null) closeFunction = onClose;
            else closeFunction = Close;

            if (attachEventHandler)
            {
                AddEventHandler("configure", new EventHandler<CLRListenerEventArgs<CLREventData<Map<string, Java.Lang.Object>>>>(EventHandlerConfigure));
                AddEventHandler("onConsume", new EventHandler<CLRListenerEventArgs<CLREventData<ConsumerRecords<K, V>>>>(EventHandlerOnConsume));
                AddEventHandler("onCommit", new EventHandler<CLRListenerEventArgs<CLREventData<Map<TopicPartition, OffsetAndMetadata>>>>(EventHandlerOnCommit));
                AddEventHandler("close", new EventHandler<CLRListenerEventArgs<CLREventData>>(EventHandlerClose));
            }
        }

        void EventHandlerConfigure(object sender, CLRListenerEventArgs<CLREventData<Map<string, Java.Lang.Object>>> data)
        {
            OnConfigure(data.EventData.TypedEventData);
        }

        void EventHandlerOnConsume(object sender, CLRListenerEventArgs<CLREventData<ConsumerRecords<K, V>>> data)
        {
            var result = OnOnConsume(data.EventData.TypedEventData);
            data.SetReturnValue(result);
        }

        void EventHandlerOnCommit(object sender, CLRListenerEventArgs<CLREventData<Map<TopicPartition, OffsetAndMetadata>>> data)
        {
            OnOnCommit(data.EventData.TypedEventData);
        }

        void EventHandlerClose(object sender, CLRListenerEventArgs<CLREventData> data)
        {
            OnClose();
        }

        /// <inheritdoc cref="IConsumerInterceptor{K, V}.Configure"/>
        public virtual void Configure(Map<string, Java.Lang.Object> configs)
        {

        }

        /// <inheritdoc cref="IConsumerInterceptor{K, V}.OnConsume"/>
        public virtual ConsumerRecords<K, V> OnConsume(ConsumerRecords<K, V> records)
        {
            return default;
        }

        /// <inheritdoc cref="IConsumerInterceptor{K, V}.OnCommit"/>
        public virtual void OnCommit(Map<TopicPartition, OffsetAndMetadata> offsets)
        {
        }

        /// <inheritdoc cref="IConsumerInterceptor{K, V}.Close"/>
        public virtual void Close()
        {
        }
    }
}
