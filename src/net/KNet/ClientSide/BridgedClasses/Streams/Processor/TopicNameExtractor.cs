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

namespace MASES.KNet.Streams.Processor
{
    /// <summary>
    /// Listener for Kafka TopicNameExtractor. Extends <see cref="IJVMBridgeBase"/>
    /// </summary>
    public interface ITopicNameExtractor : IJVMBridgeBase
    {
    }

    /// <summary>
    /// Listener for Kafka TopicNameExtractor. Extends <see cref="ITopicNameExtractor"/>
    /// </summary>
    public interface ITopicNameExtractor<K, V> : ITopicNameExtractor
    {
        /// <summary>
        /// Executes the TopicNameExtractor action in the CLR
        /// </summary>
        /// <param name="key">the record key</param>
        /// <param name="value">the record value</param>
        /// <param name="recordContext">current context metadata of the record</param>
        /// <returns>the topic name this record should be sent to</returns>
        string Extract(K key, V value, RecordContext recordContext);
    }

    /// <summary>
    /// Listener for Kafka TopicNameExtractor. Extends <see cref="JVMBridgeListener"/>, implements <see cref="ITopicNameExtractor{K, V}"/>
    /// </summary>
    /// <remarks>Dispose the object to avoid a resource leak, the object contains a reference to the corresponding JVM object</remarks>
    public class TopicNameExtractor<K, V> : JVMBridgeListener, ITopicNameExtractor<K, V>
    {
        /// <inheritdoc cref="JVMBridgeListener.ClassName"/>
        public sealed override string ClassName => "org.mases.knet.streams.processor.TopicNameExtractorImpl";

        readonly Func<K, V, RecordContext, string> executionFunction = null;
        /// <summary>
        /// The <see cref="Func{K, V, RecordContext, string}"/> to be executed
        /// </summary>
        public virtual Func<K, V, RecordContext, string> OnExtract { get { return executionFunction; } }
        /// <summary>
        /// Initialize a new instance of <see cref="TopicNameExtractor"/>
        /// </summary>
        /// <param name="func">The <see cref="Func{K, V, RecordContext, string}"/> to be executed</param>
        /// <param name="attachEventHandler">Set to false to disable attach of <see cref="EventHandler"/> and set an own one</param>
        public TopicNameExtractor(Func<K, V, RecordContext, string> func = null, bool attachEventHandler = true)
        {
            if (func != null) executionFunction = func;
            else executionFunction = Extract;
            if (attachEventHandler)
            {
                AddEventHandler("extract", new EventHandler<CLRListenerEventArgs<CLREventData<K>>>(EventHandler));
            }
        }

        void EventHandler(object sender, CLRListenerEventArgs<CLREventData<K>> data)
        {
            var retVal = OnExtract(data.EventData.TypedEventData, data.EventData.To<V>(0), data.EventData.To<RecordContext>(1));
            data.SetReturnValue(retVal);
        }
        /// <summary>
        /// Executes the TopicNameExtractor action in the CLR
        /// </summary>
        /// <param name="key">the record key</param>
        /// <param name="value">the record value</param>
        /// <param name="recordContext">current context metadata of the record</param>
        /// <returns>the topic name this record should be sent to</returns>
        public virtual string Extract(K key, V value, RecordContext recordContext) { return null; }
    }
    /*
    /// <summary>
    /// Listener for Kafka TopicNameExtractor. Extends <see cref="TopicNameExtractorImpl{K, V}"/>
    /// </summary>
    /// <typeparam name="T">The data associated to the event as an <see cref="JVMBridgeBase"/> object</typeparam>
    /// <typeparam name="U">The data associated to the event as an <see cref="JVMBridgeBase"/> object</typeparam>
    /// <typeparam name="VR">The result data associated to the event as an <see cref="JVMBridgeBase"/> object</typeparam>
    /// <remarks>Dispose the object to avoid a resource leak, the object contains a reference to the corresponding JVM object</remarks>
    public class JVMBridgeTopicNameExtractor<K, V> : TopicNameExtractorImpl<K, V>
        where K : JVMBridgeBase, new()
        where V : JVMBridgeBase, new()
    {
        /// <summary>
        /// Initialize a new instance of <see cref="JVMBridgeTopicNameExtractor{K, V}"/>
        /// </summary>
        /// <param name="func">The <see cref="Func{K, V, RecordContext, string}"/> to be executed</param>
        public JVMBridgeTopicNameExtractor(Func<K, V, RecordContext, string> func = null) : base(func, false)
        {
            AddEventHandler("extract", new EventHandler<CLRListenerEventArgs<JVMBridgeEventData<K>>>(EventHandler));
        }

        void EventHandler(object sender, CLRListenerEventArgs<JVMBridgeEventData<K>> data)
        {
            var retVal = OnExtract(data.EventData.TypedEventData, data.EventData.To<V>(0), data.EventData.To<RecordContext>(1));
            data.CLRReturnValue = retVal;
        }
    }
    */
}
