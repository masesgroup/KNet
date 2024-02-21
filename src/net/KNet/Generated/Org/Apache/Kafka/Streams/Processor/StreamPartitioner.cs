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
*  This file is generated by MASES.JNetReflector (ver. 2.2.5.0)
*  using kafka-streams-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Streams.Processor
{
    #region StreamPartitioner
    public partial class StreamPartitioner
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
        /// Handlers initializer for <see cref="StreamPartitioner"/>
        /// </summary>
        protected virtual void InitializeHandlers()
        {
            AddEventHandler("partitions", new System.EventHandler<CLRListenerEventArgs<CLREventData<Java.Lang.String>>>(PartitionsEventHandler));

        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/StreamPartitioner.html#partitions-java.lang.String-java.lang.Object-java.lang.Object-int-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <param name="arg1"><see cref="object"/></param>
        /// <param name="arg2"><see cref="object"/></param>
        /// <param name="arg3"><see cref="int"/></param>
        /// <returns><see cref="Java.Util.Optional"/></returns>
        /// <remarks>The method invokes the default implementation in the JVM interface</remarks>
        public Java.Util.Optional PartitionsDefault(Java.Lang.String arg0, object arg1, object arg2, int arg3)
        {
            return IExecute<Java.Util.Optional>("partitionsDefault", arg0, arg1, arg2, arg3);
        }

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/StreamPartitioner.html#partitions-java.lang.String-java.lang.Object-java.lang.Object-int-"/>
        /// </summary>
        /// <remarks>If <see cref="OnPartitions"/> has a value it takes precedence over corresponding class method</remarks>
        public System.Func<Java.Lang.String, object, object, int, Java.Util.Optional> OnPartitions { get; set; } = null;

        void PartitionsEventHandler(object sender, CLRListenerEventArgs<CLREventData<Java.Lang.String>> data)
        {
            var methodToExecute = (OnPartitions != null) ? OnPartitions : Partitions;
            var executionResult = methodToExecute.Invoke(data.EventData.TypedEventData, data.EventData.GetAt<object>(0), data.EventData.GetAt<object>(1), data.EventData.GetAt<int>(2));
            data.SetReturnValue(executionResult);
        }

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/StreamPartitioner.html#partitions-java.lang.String-java.lang.Object-java.lang.Object-int-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <param name="arg1"><see cref="object"/></param>
        /// <param name="arg2"><see cref="object"/></param>
        /// <param name="arg3"><see cref="int"/></param>
        /// <returns><see cref="Java.Util.Optional"/></returns>
        /// <remarks>The method invokes the default implementation in the JVM interface using <see cref="PartitionsDefault"/>; override the method to implement a different behavior</remarks>
        public virtual Java.Util.Optional Partitions(Java.Lang.String arg0, object arg1, object arg2, int arg3)
        {
            return PartitionsDefault(arg0, arg1, arg2, arg3);
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion

    #region IStreamPartitioner<K, V>
    /// <summary>
    /// .NET interface for org.mases.knet.generated.org.apache.kafka.streams.processor.StreamPartitioner implementing <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/StreamPartitioner.html"/>
    /// </summary>
    public partial interface IStreamPartitioner<K, V>
    {
        #region Instance methods

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion

    #region StreamPartitioner<K, V>
    public partial class StreamPartitioner<K, V> : Org.Apache.Kafka.Streams.Processor.IStreamPartitioner<K, V>
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
        /// Handlers initializer for <see cref="StreamPartitioner"/>
        /// </summary>
        protected virtual void InitializeHandlers()
        {
            AddEventHandler("partitions", new System.EventHandler<CLRListenerEventArgs<CLREventData<Java.Lang.String>>>(PartitionsEventHandler));

        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/StreamPartitioner.html#partitions-java.lang.String-java.lang.Object-java.lang.Object-int-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <param name="arg1"><typeparamref name="K"/></param>
        /// <param name="arg2"><typeparamref name="V"/></param>
        /// <param name="arg3"><see cref="int"/></param>
        /// <returns><see cref="Java.Util.Optional"/></returns>
        /// <remarks>The method invokes the default implementation in the JVM interface</remarks>
        public Java.Util.Optional<Java.Util.Set<Java.Lang.Integer>> PartitionsDefault(Java.Lang.String arg0, K arg1, V arg2, int arg3)
        {
            return IExecute<Java.Util.Optional<Java.Util.Set<Java.Lang.Integer>>>("partitionsDefault", arg0, arg1, arg2, arg3);
        }

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/StreamPartitioner.html#partitions-java.lang.String-java.lang.Object-java.lang.Object-int-"/>
        /// </summary>
        /// <remarks>If <see cref="OnPartitions"/> has a value it takes precedence over corresponding class method</remarks>
        public System.Func<Java.Lang.String, K, V, int, Java.Util.Optional<Java.Util.Set<Java.Lang.Integer>>> OnPartitions { get; set; } = null;

        void PartitionsEventHandler(object sender, CLRListenerEventArgs<CLREventData<Java.Lang.String>> data)
        {
            var methodToExecute = (OnPartitions != null) ? OnPartitions : Partitions;
            var executionResult = methodToExecute.Invoke(data.EventData.TypedEventData, data.EventData.GetAt<K>(0), data.EventData.GetAt<V>(1), data.EventData.GetAt<int>(2));
            data.SetReturnValue(executionResult);
        }

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/StreamPartitioner.html#partitions-java.lang.String-java.lang.Object-java.lang.Object-int-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <param name="arg1"><typeparamref name="K"/></param>
        /// <param name="arg2"><typeparamref name="V"/></param>
        /// <param name="arg3"><see cref="int"/></param>
        /// <returns><see cref="Java.Util.Optional"/></returns>
        /// <remarks>The method invokes the default implementation in the JVM interface using <see cref="PartitionsDefault"/>; override the method to implement a different behavior</remarks>
        public virtual Java.Util.Optional<Java.Util.Set<Java.Lang.Integer>> Partitions(Java.Lang.String arg0, K arg1, V arg2, int arg3)
        {
            return PartitionsDefault(arg0, arg1, arg2, arg3);
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}