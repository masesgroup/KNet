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

/*
*  This file is generated by MASES.JNetReflector (ver. 2.0.1.0)
*  using kafka-streams-3.5.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Streams.Kstream
{
    #region ValueTransformerWithKey
    public partial class ValueTransformerWithKey
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
        /// Handlers initializer for <see cref="ValueTransformerWithKey"/>
        /// </summary>
        protected virtual void InitializeHandlers()
        {
            AddEventHandler("close", new System.EventHandler<CLRListenerEventArgs<CLREventData>>(CloseEventHandler)); OnClose = Close;
            AddEventHandler("init", new System.EventHandler<CLRListenerEventArgs<CLREventData<Org.Apache.Kafka.Streams.Processor.ProcessorContext>>>(InitEventHandler)); OnInit = Init;
            AddEventHandler("transform", new System.EventHandler<CLRListenerEventArgs<CLREventData<object>>>(TransformEventHandler)); OnTransform = Transform;

        }

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.5.1/org/apache/kafka/streams/kstream/ValueTransformerWithKey.html#close--"/>
        /// </summary>
        public System.Action OnClose { get; set; }

        void CloseEventHandler(object sender, CLRListenerEventArgs<CLREventData> data)
        {
            if (OnClose != null) OnClose.Invoke();
        }

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.5.1/org/apache/kafka/streams/kstream/ValueTransformerWithKey.html#close--"/>
        /// </summary>
        public virtual void Close()
        {
            
        }

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.5.1/org/apache/kafka/streams/kstream/ValueTransformerWithKey.html#init-org.apache.kafka.streams.processor.ProcessorContext-"/>
        /// </summary>
        public System.Action<Org.Apache.Kafka.Streams.Processor.ProcessorContext> OnInit { get; set; }

        void InitEventHandler(object sender, CLRListenerEventArgs<CLREventData<Org.Apache.Kafka.Streams.Processor.ProcessorContext>> data)
        {
            if (OnInit != null) OnInit.Invoke(data.EventData.TypedEventData);
        }

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.5.1/org/apache/kafka/streams/kstream/ValueTransformerWithKey.html#init-org.apache.kafka.streams.processor.ProcessorContext-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Processor.ProcessorContext"/></param>
        public virtual void Init(Org.Apache.Kafka.Streams.Processor.ProcessorContext arg0)
        {
            
        }

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.5.1/org/apache/kafka/streams/kstream/ValueTransformerWithKey.html#transform-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        public System.Func<object, object, object> OnTransform { get; set; }

        void TransformEventHandler(object sender, CLRListenerEventArgs<CLREventData<object>> data)
        {
            if (OnTransform != null)
            {
                var executionResult = OnTransform.Invoke(data.EventData.TypedEventData, data.EventData.GetAt<object>(0));
                data.SetReturnValue(executionResult);
            }
        }

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.5.1/org/apache/kafka/streams/kstream/ValueTransformerWithKey.html#transform-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><see cref="object"/></param>
        /// <param name="arg1"><see cref="object"/></param>
        /// <returns><see cref="object"/></returns>
        public virtual object Transform(object arg0, object arg1)
        {
            return default;
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion

    #region IValueTransformerWithKey<K, V, VR>
    /// <summary>
    /// .NET interface for org.mases.knet.generated.org.apache.kafka.streams.kstream.ValueTransformerWithKey implementing <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.5.1/org/apache/kafka/streams/kstream/ValueTransformerWithKey.html"/>
    /// </summary>
    public partial interface IValueTransformerWithKey<K, V, VR>
    {
        #region Instance methods

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion

    #region ValueTransformerWithKey<K, V, VR>
    public partial class ValueTransformerWithKey<K, V, VR> : Org.Apache.Kafka.Streams.Kstream.IValueTransformerWithKey<K, V, VR>
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
        /// Handlers initializer for <see cref="ValueTransformerWithKey"/>
        /// </summary>
        protected virtual void InitializeHandlers()
        {
            AddEventHandler("close", new System.EventHandler<CLRListenerEventArgs<CLREventData>>(CloseEventHandler)); OnClose = Close;
            AddEventHandler("init", new System.EventHandler<CLRListenerEventArgs<CLREventData<Org.Apache.Kafka.Streams.Processor.ProcessorContext>>>(InitEventHandler)); OnInit = Init;
            AddEventHandler("transform", new System.EventHandler<CLRListenerEventArgs<CLREventData<K>>>(TransformEventHandler)); OnTransform = Transform;

        }

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.5.1/org/apache/kafka/streams/kstream/ValueTransformerWithKey.html#close--"/>
        /// </summary>
        public System.Action OnClose { get; set; }

        void CloseEventHandler(object sender, CLRListenerEventArgs<CLREventData> data)
        {
            if (OnClose != null) OnClose.Invoke();
        }

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.5.1/org/apache/kafka/streams/kstream/ValueTransformerWithKey.html#close--"/>
        /// </summary>
        public virtual void Close()
        {
            
        }

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.5.1/org/apache/kafka/streams/kstream/ValueTransformerWithKey.html#init-org.apache.kafka.streams.processor.ProcessorContext-"/>
        /// </summary>
        public System.Action<Org.Apache.Kafka.Streams.Processor.ProcessorContext> OnInit { get; set; }

        void InitEventHandler(object sender, CLRListenerEventArgs<CLREventData<Org.Apache.Kafka.Streams.Processor.ProcessorContext>> data)
        {
            if (OnInit != null) OnInit.Invoke(data.EventData.TypedEventData);
        }

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.5.1/org/apache/kafka/streams/kstream/ValueTransformerWithKey.html#init-org.apache.kafka.streams.processor.ProcessorContext-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Processor.ProcessorContext"/></param>
        public virtual void Init(Org.Apache.Kafka.Streams.Processor.ProcessorContext arg0)
        {
            
        }

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.5.1/org/apache/kafka/streams/kstream/ValueTransformerWithKey.html#transform-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        public System.Func<K, V, VR> OnTransform { get; set; }

        void TransformEventHandler(object sender, CLRListenerEventArgs<CLREventData<K>> data)
        {
            if (OnTransform != null)
            {
                var executionResult = OnTransform.Invoke(data.EventData.TypedEventData, data.EventData.GetAt<V>(0));
                data.SetReturnValue(executionResult);
            }
        }

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.5.1/org/apache/kafka/streams/kstream/ValueTransformerWithKey.html#transform-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="K"/></param>
        /// <param name="arg1"><typeparamref name="V"/></param>
        /// <returns><typeparamref name="VR"/></returns>
        public virtual VR Transform(K arg0, V arg1)
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