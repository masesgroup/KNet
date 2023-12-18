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
*  This file is generated by MASES.JNetReflector (ver. 2.1.1.0)
*  using kafka-clients-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Clients.Producer
{
    #region IPartitioner
    /// <summary>
    /// .NET interface for org.mases.knet.generated.org.apache.kafka.clients.producer.Partitioner implementing <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/Partitioner.html"/>
    /// </summary>
    public partial interface IPartitioner
    {
        #region Instance methods

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion

    #region Partitioner
    public partial class Partitioner : Org.Apache.Kafka.Clients.Producer.IPartitioner, Org.Apache.Kafka.Common.IConfigurable, Java.Io.ICloseable
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
        /// Handlers initializer for <see cref="Partitioner"/>
        /// </summary>
        protected virtual void InitializeHandlers()
        {
            AddEventHandler("partition", new System.EventHandler<CLRListenerEventArgs<CLREventData<string>>>(PartitionEventHandler));
            AddEventHandler("close", new System.EventHandler<CLRListenerEventArgs<CLREventData>>(CloseEventHandler));
            AddEventHandler("configure", new System.EventHandler<CLRListenerEventArgs<CLREventData<Java.Util.Map<string, object>>>>(ConfigureEventHandler));

        }

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/Partitioner.html#partition-java.lang.String-java.lang.Object-byte[]-java.lang.Object-byte[]-org.apache.kafka.common.Cluster-"/>
        /// </summary>
        /// <remarks>If <see cref="OnPartition"/> has a value it takes precedence over corresponding class method</remarks>
        public System.Func<string, object, byte[], object, byte[], Org.Apache.Kafka.Common.Cluster, int> OnPartition { get; set; } = null;

        void PartitionEventHandler(object sender, CLRListenerEventArgs<CLREventData<string>> data)
        {
            var methodToExecute = (OnPartition != null) ? OnPartition : Partition;
            var executionResult = methodToExecute.Invoke(data.EventData.TypedEventData, data.EventData.GetAt<object>(0), data.EventData.GetAt<byte[]>(1), data.EventData.GetAt<object>(2), data.EventData.GetAt<byte[]>(3), data.EventData.GetAt<Org.Apache.Kafka.Common.Cluster>(4));
            data.SetReturnValue(executionResult);
        }

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/Partitioner.html#partition-java.lang.String-java.lang.Object-byte[]-java.lang.Object-byte[]-org.apache.kafka.common.Cluster-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="object"/></param>
        /// <param name="arg2"><see cref="byte"/></param>
        /// <param name="arg3"><see cref="object"/></param>
        /// <param name="arg4"><see cref="byte"/></param>
        /// <param name="arg5"><see cref="Org.Apache.Kafka.Common.Cluster"/></param>
        /// <returns><see cref="int"/></returns>
        public virtual int Partition(string arg0, object arg1, byte[] arg2, object arg3, byte[] arg4, Org.Apache.Kafka.Common.Cluster arg5)
        {
            return default;
        }

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/Partitioner.html#close--"/>
        /// </summary>
        /// <remarks>If <see cref="OnClose"/> has a value it takes precedence over corresponding class method</remarks>
        public System.Action OnClose { get; set; } = null;

        void CloseEventHandler(object sender, CLRListenerEventArgs<CLREventData> data)
        {
            var methodToExecute = (OnClose != null) ? OnClose : Close;
            methodToExecute.Invoke();
        }

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/Partitioner.html#close--"/>
        /// </summary>
        public virtual void Close()
        {
            
        }

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/Configurable.html#configure-java.util.Map-"/>
        /// </summary>
        /// <remarks>If <see cref="OnConfigure"/> has a value it takes precedence over corresponding class method</remarks>
        public System.Action<Java.Util.Map<string, object>> OnConfigure { get; set; } = null;

        void ConfigureEventHandler(object sender, CLRListenerEventArgs<CLREventData<Java.Util.Map<string, object>>> data)
        {
            var methodToExecute = (OnConfigure != null) ? OnConfigure : Configure;
            methodToExecute.Invoke(data.EventData.TypedEventData);
        }

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/Configurable.html#configure-java.util.Map-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Map"/></param>
        public virtual void Configure(Java.Util.Map<string, object> arg0)
        {
            
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}