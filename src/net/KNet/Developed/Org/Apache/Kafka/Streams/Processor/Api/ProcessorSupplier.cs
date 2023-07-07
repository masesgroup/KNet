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
using System.Collections.Generic;

namespace Org.Apache.Kafka.Streams.Processor.Api
{
    #region IProcessorSupplier<KIn, VIn, KOut, VOut>
    /// <summary>
    /// .NET interface for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.4.0/org/apache/kafka/streams/processor/api/ProcessorSupplier.html"/>
    /// </summary>
    public partial interface IProcessorSupplier<KIn, VIn, KOut, VOut>
    {
        #region Instance methods

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion

    #region ProcessorSupplier<KIn, VIn, KOut, VOut>
    /// <summary>
    /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.4.0/org/apache/kafka/streams/processor/api/ProcessorSupplier.html"/>
    /// </summary>
    public partial class ProcessorSupplier<KIn, VIn, KOut, VOut> : JVMBridgeListener, Org.Apache.Kafka.Streams.Processor.Api.IProcessorSupplier<KIn, VIn, KOut, VOut>, Org.Apache.Kafka.Streams.Processor.IConnectedStoreProvider, Java.Util.Function.ISupplier<Org.Apache.Kafka.Streams.Processor.Api.Processor<KIn, VIn, KOut, VOut>>
    {
        #region Private
        readonly List<JVMBridgeListener> m_list = new List<JVMBridgeListener>();
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor: even if the corresponding Java class does not have one, it is mandatory for JCOBridge
        /// </summary>
        public ProcessorSupplier() { InitializeHandlers(); }

        /// <summary>
        /// <see href="https://www.jcobridge.com/api-clr/html/P_MASES_JCOBridge_C2JBridge_JVMBridgeListener_BridgeClassName.htm"/>
        /// </summary>
        public override string BridgeClassName => "org.mases.knet.streams.processor.api.ProcessorSupplier";
        #endregion

        #region Instance methods

        /// <summary>
        /// Handlers initializer for <see cref="ProcessorSupplier{KIn, VIn, KOut, VOut}"/>
        /// </summary>
        protected virtual void InitializeHandlers()
        {
            AddEventHandler("get", new System.EventHandler<CLRListenerEventArgs<CLREventData>>(GetEventHandler)); OnGet = Get;
        }

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.4.0/org/apache/kafka/streams/processor/api/Processor.html#init(org.apache.kafka.streams.processor.api.ProcessorContext)"/>
        /// </summary>
        public System.Action<Org.Apache.Kafka.Streams.Processor.Api.ProcessorContext<KOut, VOut>> OnInit { get; set; }

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.4.0/org/apache/kafka/streams/processor/api/Processor.html#process(org.apache.kafka.streams.processor.api.Record)"/>
        /// </summary>
        public System.Action<Org.Apache.Kafka.Streams.Processor.Api.Record<KIn, VIn>> OnProcess { get; set; }

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.4.0/org/apache/kafka/streams/processor/api/ProcessorSupplier.html#get()"/>
        /// </summary>
        public System.Func<Org.Apache.Kafka.Streams.Processor.Api.Processor<KIn, VIn, KOut, VOut>> OnGet { get; set; }

        void GetEventHandler(object sender, CLRListenerEventArgs<CLREventData> data)
        {
            if (OnGet != null)
            {
                var executionResult = OnGet.Invoke();
                executionResult.OnClose = () =>
                {
                    lock (m_list)
                    {
                        executionResult?.Dispose();
                        m_list.Remove(executionResult);
                    }
                };
                lock (m_list)
                {
                    m_list.Add(executionResult);
                }
                data.SetReturnValue(executionResult);
            }
        }


        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.4.0/org/apache/kafka/streams/processor/api/ProcessorSupplier.html#get()"/>
        /// </summary>
        /// <returns><see cref="object"/></returns>
        public virtual Org.Apache.Kafka.Streams.Processor.Api.Processor<KIn, VIn, KOut, VOut> Get()
        {
            return new Processor<KIn, VIn, KOut, VOut>()
            {
                OnInit = OnInit,
                OnProcess = OnProcess
            };
        }

        #endregion
    }
    #endregion
}