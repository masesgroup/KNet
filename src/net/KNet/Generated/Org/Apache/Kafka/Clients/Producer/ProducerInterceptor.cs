/*
*  Copyright 2024 MASES s.r.l.
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

/*
*  This file is generated by MASES.JNetReflector (ver. 2.4.0.0)
*  using kafka-clients-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Clients.Producer
{
    #region ProducerInterceptor
    public partial class ProducerInterceptor
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// Handlers initializer for <see cref="ProducerInterceptor"/>
        /// </summary>
        protected virtual void InitializeHandlers()
        {
            AddEventHandler("onSend", new System.EventHandler<CLRListenerEventArgs<CLREventData<Org.Apache.Kafka.Clients.Producer.ProducerRecord>>>(OnSendEventHandler));
            AddEventHandler("close", new System.EventHandler<CLRListenerEventArgs<CLREventData>>(CloseEventHandler));
            AddEventHandler("onAcknowledgement", new System.EventHandler<CLRListenerEventArgs<CLREventData<Org.Apache.Kafka.Clients.Producer.RecordMetadata>>>(OnAcknowledgementEventHandler));
            AddEventHandler("configure", new System.EventHandler<CLRListenerEventArgs<CLREventData<Java.Util.Map>>>(ConfigureEventHandler));

        }

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerInterceptor.html#onSend-org.apache.kafka.clients.producer.ProducerRecord-"/>
        /// </summary>
        /// <remarks>If <see cref="OnOnSend"/> has a value it takes precedence over corresponding class method</remarks>
        public System.Func<Org.Apache.Kafka.Clients.Producer.ProducerRecord, Org.Apache.Kafka.Clients.Producer.ProducerRecord> OnOnSend { get; set; } = null;

        void OnSendEventHandler(object sender, CLRListenerEventArgs<CLREventData<Org.Apache.Kafka.Clients.Producer.ProducerRecord>> data)
        {
            var methodToExecute = (OnOnSend != null) ? OnOnSend : OnSend;
            var executionResult = methodToExecute.Invoke(data.EventData.TypedEventData);
            data.SetReturnValue(executionResult);
        }

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerInterceptor.html#onSend-org.apache.kafka.clients.producer.ProducerRecord-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Clients.Producer.ProducerRecord"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Clients.Producer.ProducerRecord"/></returns>
        public virtual Org.Apache.Kafka.Clients.Producer.ProducerRecord OnSend(Org.Apache.Kafka.Clients.Producer.ProducerRecord arg0)
        {
            return default;
        }

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerInterceptor.html#close--"/>
        /// </summary>
        /// <remarks>If <see cref="OnClose"/> has a value it takes precedence over corresponding class method</remarks>
        public System.Action OnClose { get; set; } = null;

        void CloseEventHandler(object sender, CLRListenerEventArgs<CLREventData> data)
        {
            var methodToExecute = (OnClose != null) ? OnClose : Close;
            methodToExecute.Invoke();
        }

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerInterceptor.html#close--"/>
        /// </summary>
        public virtual void Close()
        {
            
        }

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerInterceptor.html#onAcknowledgement-org.apache.kafka.clients.producer.RecordMetadata-java.lang.Exception-"/>
        /// </summary>
        /// <remarks>If <see cref="OnOnAcknowledgement"/> has a value it takes precedence over corresponding class method</remarks>
        public System.Action<Org.Apache.Kafka.Clients.Producer.RecordMetadata, MASES.JCOBridge.C2JBridge.JVMBridgeException> OnOnAcknowledgement { get; set; } = null;

        void OnAcknowledgementEventHandler(object sender, CLRListenerEventArgs<CLREventData<Org.Apache.Kafka.Clients.Producer.RecordMetadata>> data)
        {
            var methodToExecute = (OnOnAcknowledgement != null) ? OnOnAcknowledgement : OnAcknowledgement;
            methodToExecute.Invoke(data.EventData.TypedEventData, JVMBridgeException.New(data.EventData.ExtraData.Get(0) as MASES.JCOBridge.C2JBridge.JVMInterop.IJavaObject));
        }

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerInterceptor.html#onAcknowledgement-org.apache.kafka.clients.producer.RecordMetadata-java.lang.Exception-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Clients.Producer.RecordMetadata"/></param>
        /// <param name="arg1"><see cref="Java.Lang.Exception"/></param>
        public virtual void OnAcknowledgement(Org.Apache.Kafka.Clients.Producer.RecordMetadata arg0, MASES.JCOBridge.C2JBridge.JVMBridgeException arg1)
        {
            
        }

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/Configurable.html#configure-java.util.Map-"/>
        /// </summary>
        /// <remarks>If <see cref="OnConfigure"/> has a value it takes precedence over corresponding class method</remarks>
        public System.Action<Java.Util.Map> OnConfigure { get; set; } = null;

        void ConfigureEventHandler(object sender, CLRListenerEventArgs<CLREventData<Java.Util.Map>> data)
        {
            var methodToExecute = (OnConfigure != null) ? OnConfigure : Configure;
            methodToExecute.Invoke(data.EventData.TypedEventData);
        }

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/Configurable.html#configure-java.util.Map-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Map"/></param>
        public virtual void Configure(Java.Util.Map arg0)
        {
            
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion

    #region IProducerInterceptor<K, V>
    /// <summary>
    /// .NET interface for org.mases.knet.generated.org.apache.kafka.clients.producer.ProducerInterceptor implementing <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerInterceptor.html"/>
    /// </summary>
    public partial interface IProducerInterceptor<K, V>
    {
        #region Instance methods

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion

    #region ProducerInterceptor<K, V>
    public partial class ProducerInterceptor<K, V> : Org.Apache.Kafka.Clients.Producer.IProducerInterceptor<K, V>, Org.Apache.Kafka.Common.IConfigurable, Java.Lang.IAutoCloseable
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// Handlers initializer for <see cref="ProducerInterceptor"/>
        /// </summary>
        protected virtual void InitializeHandlers()
        {
            AddEventHandler("onSend", new System.EventHandler<CLRListenerEventArgs<CLREventData<Org.Apache.Kafka.Clients.Producer.ProducerRecord<K, V>>>>(OnSendEventHandler));
            AddEventHandler("close", new System.EventHandler<CLRListenerEventArgs<CLREventData>>(CloseEventHandler));
            AddEventHandler("onAcknowledgement", new System.EventHandler<CLRListenerEventArgs<CLREventData<Org.Apache.Kafka.Clients.Producer.RecordMetadata>>>(OnAcknowledgementEventHandler));
            AddEventHandler("configure", new System.EventHandler<CLRListenerEventArgs<CLREventData<Java.Util.Map<Java.Lang.String, object>>>>(ConfigureEventHandler));

        }

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerInterceptor.html#onSend-org.apache.kafka.clients.producer.ProducerRecord-"/>
        /// </summary>
        /// <remarks>If <see cref="OnOnSend"/> has a value it takes precedence over corresponding class method</remarks>
        public System.Func<Org.Apache.Kafka.Clients.Producer.ProducerRecord<K, V>, Org.Apache.Kafka.Clients.Producer.ProducerRecord<K, V>> OnOnSend { get; set; } = null;

        void OnSendEventHandler(object sender, CLRListenerEventArgs<CLREventData<Org.Apache.Kafka.Clients.Producer.ProducerRecord<K, V>>> data)
        {
            var methodToExecute = (OnOnSend != null) ? OnOnSend : OnSend;
            var executionResult = methodToExecute.Invoke(data.EventData.TypedEventData);
            data.SetReturnValue(executionResult);
        }

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerInterceptor.html#onSend-org.apache.kafka.clients.producer.ProducerRecord-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Clients.Producer.ProducerRecord"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Clients.Producer.ProducerRecord"/></returns>
        public virtual Org.Apache.Kafka.Clients.Producer.ProducerRecord<K, V> OnSend(Org.Apache.Kafka.Clients.Producer.ProducerRecord<K, V> arg0)
        {
            return default;
        }

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerInterceptor.html#close--"/>
        /// </summary>
        /// <remarks>If <see cref="OnClose"/> has a value it takes precedence over corresponding class method</remarks>
        public System.Action OnClose { get; set; } = null;

        void CloseEventHandler(object sender, CLRListenerEventArgs<CLREventData> data)
        {
            var methodToExecute = (OnClose != null) ? OnClose : Close;
            methodToExecute.Invoke();
        }

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerInterceptor.html#close--"/>
        /// </summary>
        public virtual void Close()
        {
            
        }

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerInterceptor.html#onAcknowledgement-org.apache.kafka.clients.producer.RecordMetadata-java.lang.Exception-"/>
        /// </summary>
        /// <remarks>If <see cref="OnOnAcknowledgement"/> has a value it takes precedence over corresponding class method</remarks>
        public System.Action<Org.Apache.Kafka.Clients.Producer.RecordMetadata, MASES.JCOBridge.C2JBridge.JVMBridgeException> OnOnAcknowledgement { get; set; } = null;

        void OnAcknowledgementEventHandler(object sender, CLRListenerEventArgs<CLREventData<Org.Apache.Kafka.Clients.Producer.RecordMetadata>> data)
        {
            var methodToExecute = (OnOnAcknowledgement != null) ? OnOnAcknowledgement : OnAcknowledgement;
            methodToExecute.Invoke(data.EventData.TypedEventData, JVMBridgeException.New(data.EventData.ExtraData.Get(0) as MASES.JCOBridge.C2JBridge.JVMInterop.IJavaObject));
        }

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerInterceptor.html#onAcknowledgement-org.apache.kafka.clients.producer.RecordMetadata-java.lang.Exception-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Clients.Producer.RecordMetadata"/></param>
        /// <param name="arg1"><see cref="Java.Lang.Exception"/></param>
        public virtual void OnAcknowledgement(Org.Apache.Kafka.Clients.Producer.RecordMetadata arg0, MASES.JCOBridge.C2JBridge.JVMBridgeException arg1)
        {
            
        }

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/Configurable.html#configure-java.util.Map-"/>
        /// </summary>
        /// <remarks>If <see cref="OnConfigure"/> has a value it takes precedence over corresponding class method</remarks>
        public System.Action<Java.Util.Map<Java.Lang.String, object>> OnConfigure { get; set; } = null;

        void ConfigureEventHandler(object sender, CLRListenerEventArgs<CLREventData<Java.Util.Map<Java.Lang.String, object>>> data)
        {
            var methodToExecute = (OnConfigure != null) ? OnConfigure : Configure;
            methodToExecute.Invoke(data.EventData.TypedEventData);
        }

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/Configurable.html#configure-java.util.Map-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Map"/></param>
        public virtual void Configure(Java.Util.Map<Java.Lang.String, object> arg0)
        {
            
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}