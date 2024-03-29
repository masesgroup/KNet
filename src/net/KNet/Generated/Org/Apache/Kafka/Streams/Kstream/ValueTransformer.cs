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
*  using kafka-streams-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Streams.Kstream
{
    #region ValueTransformer
    public partial class ValueTransformer
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
        /// Handlers initializer for <see cref="ValueTransformer"/>
        /// </summary>
        protected virtual void InitializeHandlers()
        {
            AddEventHandler("close", new System.EventHandler<CLRListenerEventArgs<CLREventData>>(CloseEventHandler));
            AddEventHandler("init", new System.EventHandler<CLRListenerEventArgs<CLREventData<Org.Apache.Kafka.Streams.Processor.ProcessorContext>>>(InitEventHandler));
            AddEventHandler("transform", new System.EventHandler<CLRListenerEventArgs<CLREventData<object>>>(TransformEventHandler));

        }

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/ValueTransformer.html#close--"/>
        /// </summary>
        /// <remarks>If <see cref="OnClose"/> has a value it takes precedence over corresponding class method</remarks>
        public System.Action OnClose { get; set; } = null;

        void CloseEventHandler(object sender, CLRListenerEventArgs<CLREventData> data)
        {
            var methodToExecute = (OnClose != null) ? OnClose : Close;
            methodToExecute.Invoke();
        }

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/ValueTransformer.html#close--"/>
        /// </summary>
        public virtual void Close()
        {
            
        }

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/ValueTransformer.html#init-org.apache.kafka.streams.processor.ProcessorContext-"/>
        /// </summary>
        /// <remarks>If <see cref="OnInit"/> has a value it takes precedence over corresponding class method</remarks>
        public System.Action<Org.Apache.Kafka.Streams.Processor.ProcessorContext> OnInit { get; set; } = null;

        void InitEventHandler(object sender, CLRListenerEventArgs<CLREventData<Org.Apache.Kafka.Streams.Processor.ProcessorContext>> data)
        {
            var methodToExecute = (OnInit != null) ? OnInit : Init;
            methodToExecute.Invoke(data.EventData.TypedEventData);
        }

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/ValueTransformer.html#init-org.apache.kafka.streams.processor.ProcessorContext-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Processor.ProcessorContext"/></param>
        public virtual void Init(Org.Apache.Kafka.Streams.Processor.ProcessorContext arg0)
        {
            
        }

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/ValueTransformer.html#transform-java.lang.Object-"/>
        /// </summary>
        /// <remarks>If <see cref="OnTransform"/> has a value it takes precedence over corresponding class method</remarks>
        public System.Func<object, object> OnTransform { get; set; } = null;

        void TransformEventHandler(object sender, CLRListenerEventArgs<CLREventData<object>> data)
        {
            var methodToExecute = (OnTransform != null) ? OnTransform : Transform;
            var executionResult = methodToExecute.Invoke(data.EventData.TypedEventData);
            data.SetReturnValue(executionResult);
        }

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/ValueTransformer.html#transform-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><see cref="object"/></param>
        /// <returns><see cref="object"/></returns>
        public virtual object Transform(object arg0)
        {
            return default;
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion

    #region IValueTransformer<V, VR>
    /// <summary>
    /// .NET interface for org.mases.knet.generated.org.apache.kafka.streams.kstream.ValueTransformer implementing <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/ValueTransformer.html"/>
    /// </summary>
    public partial interface IValueTransformer<V, VR>
    {
        #region Instance methods

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion

    #region ValueTransformer<V, VR>
    public partial class ValueTransformer<V, VR> : Org.Apache.Kafka.Streams.Kstream.IValueTransformer<V, VR>
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
        /// Handlers initializer for <see cref="ValueTransformer"/>
        /// </summary>
        protected virtual void InitializeHandlers()
        {
            AddEventHandler("close", new System.EventHandler<CLRListenerEventArgs<CLREventData>>(CloseEventHandler));
            AddEventHandler("init", new System.EventHandler<CLRListenerEventArgs<CLREventData<Org.Apache.Kafka.Streams.Processor.ProcessorContext>>>(InitEventHandler));
            AddEventHandler("transform", new System.EventHandler<CLRListenerEventArgs<CLREventData<V>>>(TransformEventHandler));

        }

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/ValueTransformer.html#close--"/>
        /// </summary>
        /// <remarks>If <see cref="OnClose"/> has a value it takes precedence over corresponding class method</remarks>
        public System.Action OnClose { get; set; } = null;

        void CloseEventHandler(object sender, CLRListenerEventArgs<CLREventData> data)
        {
            var methodToExecute = (OnClose != null) ? OnClose : Close;
            methodToExecute.Invoke();
        }

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/ValueTransformer.html#close--"/>
        /// </summary>
        public virtual void Close()
        {
            
        }

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/ValueTransformer.html#init-org.apache.kafka.streams.processor.ProcessorContext-"/>
        /// </summary>
        /// <remarks>If <see cref="OnInit"/> has a value it takes precedence over corresponding class method</remarks>
        public System.Action<Org.Apache.Kafka.Streams.Processor.ProcessorContext> OnInit { get; set; } = null;

        void InitEventHandler(object sender, CLRListenerEventArgs<CLREventData<Org.Apache.Kafka.Streams.Processor.ProcessorContext>> data)
        {
            var methodToExecute = (OnInit != null) ? OnInit : Init;
            methodToExecute.Invoke(data.EventData.TypedEventData);
        }

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/ValueTransformer.html#init-org.apache.kafka.streams.processor.ProcessorContext-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Processor.ProcessorContext"/></param>
        public virtual void Init(Org.Apache.Kafka.Streams.Processor.ProcessorContext arg0)
        {
            
        }

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/ValueTransformer.html#transform-java.lang.Object-"/>
        /// </summary>
        /// <remarks>If <see cref="OnTransform"/> has a value it takes precedence over corresponding class method</remarks>
        public System.Func<V, VR> OnTransform { get; set; } = null;

        void TransformEventHandler(object sender, CLRListenerEventArgs<CLREventData<V>> data)
        {
            var methodToExecute = (OnTransform != null) ? OnTransform : Transform;
            var executionResult = methodToExecute.Invoke(data.EventData.TypedEventData);
            data.SetReturnValue(executionResult);
        }

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/ValueTransformer.html#transform-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="V"/></param>
        /// <returns><typeparamref name="VR"/></returns>
        public virtual VR Transform(V arg0)
        {
            return default;
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}