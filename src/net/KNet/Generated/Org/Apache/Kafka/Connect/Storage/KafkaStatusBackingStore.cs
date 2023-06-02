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
*  This file is generated by MASES.JNetReflector (ver. 1.5.5.0)
*  using connect-runtime-3.4.0.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Connect.Storage
{
    #region KafkaStatusBackingStore
    public partial class KafkaStatusBackingStore
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/storage/KafkaStatusBackingStore.html#%3Cinit%3E(org.apache.kafka.common.utils.Time,org.apache.kafka.connect.storage.Converter,java.util.function.Supplier,java.lang.String)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Utils.Time"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Connect.Storage.Converter"/></param>
        /// <param name="arg2"><see cref="Java.Util.Function.Supplier"/></param>
        /// <param name="arg3"><see cref="string"/></param>
        public KafkaStatusBackingStore(Org.Apache.Kafka.Common.Utils.Time arg0, Org.Apache.Kafka.Connect.Storage.Converter arg1, Java.Util.Function.Supplier<Org.Apache.Kafka.Connect.Util.TopicAdmin> arg2, string arg3)
            : base(arg0, arg1, arg2, arg3)
        {
        }

        #endregion

        #region Class/Interface conversion operators
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Connect.Storage.KafkaStatusBackingStore"/> to <see cref="Org.Apache.Kafka.Connect.Storage.StatusBackingStore"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Connect.Storage.StatusBackingStore(Org.Apache.Kafka.Connect.Storage.KafkaStatusBackingStore t) => t.Cast<Org.Apache.Kafka.Connect.Storage.StatusBackingStore>();

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/storage/KafkaStatusBackingStore.html#CONNECTOR_STATUS_PREFIX"/>
        /// </summary>
        public static string CONNECTOR_STATUS_PREFIX { get { return SGetField<string>(LocalBridgeClazz, "CONNECTOR_STATUS_PREFIX"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/storage/KafkaStatusBackingStore.html#GENERATION_KEY_NAME"/>
        /// </summary>
        public static string GENERATION_KEY_NAME { get { return SGetField<string>(LocalBridgeClazz, "GENERATION_KEY_NAME"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/storage/KafkaStatusBackingStore.html#STATE_KEY_NAME"/>
        /// </summary>
        public static string STATE_KEY_NAME { get { return SGetField<string>(LocalBridgeClazz, "STATE_KEY_NAME"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/storage/KafkaStatusBackingStore.html#TASK_STATUS_PREFIX"/>
        /// </summary>
        public static string TASK_STATUS_PREFIX { get { return SGetField<string>(LocalBridgeClazz, "TASK_STATUS_PREFIX"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/storage/KafkaStatusBackingStore.html#TOPIC_CONNECTOR_KEY"/>
        /// </summary>
        public static string TOPIC_CONNECTOR_KEY { get { return SGetField<string>(LocalBridgeClazz, "TOPIC_CONNECTOR_KEY"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/storage/KafkaStatusBackingStore.html#TOPIC_DISCOVER_TIMESTAMP_KEY"/>
        /// </summary>
        public static string TOPIC_DISCOVER_TIMESTAMP_KEY { get { return SGetField<string>(LocalBridgeClazz, "TOPIC_DISCOVER_TIMESTAMP_KEY"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/storage/KafkaStatusBackingStore.html#TOPIC_NAME_KEY"/>
        /// </summary>
        public static string TOPIC_NAME_KEY { get { return SGetField<string>(LocalBridgeClazz, "TOPIC_NAME_KEY"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/storage/KafkaStatusBackingStore.html#TOPIC_STATE_KEY"/>
        /// </summary>
        public static string TOPIC_STATE_KEY { get { return SGetField<string>(LocalBridgeClazz, "TOPIC_STATE_KEY"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/storage/KafkaStatusBackingStore.html#TOPIC_STATUS_PREFIX"/>
        /// </summary>
        public static string TOPIC_STATUS_PREFIX { get { return SGetField<string>(LocalBridgeClazz, "TOPIC_STATUS_PREFIX"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/storage/KafkaStatusBackingStore.html#TOPIC_STATUS_SEPARATOR"/>
        /// </summary>
        public static string TOPIC_STATUS_SEPARATOR { get { return SGetField<string>(LocalBridgeClazz, "TOPIC_STATUS_SEPARATOR"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/storage/KafkaStatusBackingStore.html#TOPIC_TASK_KEY"/>
        /// </summary>
        public static string TOPIC_TASK_KEY { get { return SGetField<string>(LocalBridgeClazz, "TOPIC_TASK_KEY"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/storage/KafkaStatusBackingStore.html#TRACE_KEY_NAME"/>
        /// </summary>
        public static string TRACE_KEY_NAME { get { return SGetField<string>(LocalBridgeClazz, "TRACE_KEY_NAME"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/storage/KafkaStatusBackingStore.html#WORKER_ID_KEY_NAME"/>
        /// </summary>
        public static string WORKER_ID_KEY_NAME { get { return SGetField<string>(LocalBridgeClazz, "WORKER_ID_KEY_NAME"); } }

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/storage/KafkaStatusBackingStore.html#getAllTopics(java.lang.String)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="Java.Util.Collection"/></returns>
        public Java.Util.Collection<Org.Apache.Kafka.Connect.Runtime.TopicStatus> GetAllTopics(string arg0)
        {
            return IExecute<Java.Util.Collection<Org.Apache.Kafka.Connect.Runtime.TopicStatus>>("getAllTopics", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/storage/KafkaStatusBackingStore.html#getTopic(java.lang.String,java.lang.String)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Connect.Runtime.TopicStatus"/></returns>
        public Org.Apache.Kafka.Connect.Runtime.TopicStatus GetTopic(string arg0, string arg1)
        {
            return IExecute<Org.Apache.Kafka.Connect.Runtime.TopicStatus>("getTopic", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/storage/KafkaStatusBackingStore.html#getAll(java.lang.String)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="Java.Util.Collection"/></returns>
        public Java.Util.Collection<Org.Apache.Kafka.Connect.Runtime.TaskStatus> GetAll(string arg0)
        {
            return IExecute<Java.Util.Collection<Org.Apache.Kafka.Connect.Runtime.TaskStatus>>("getAll", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/storage/KafkaStatusBackingStore.html#connectors()"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Set"/></returns>
        public Java.Util.Set<string> Connectors()
        {
            return IExecute<Java.Util.Set<string>>("connectors");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/storage/KafkaStatusBackingStore.html#get(java.lang.String)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Connect.Runtime.ConnectorStatus"/></returns>
        public Org.Apache.Kafka.Connect.Runtime.ConnectorStatus Get(string arg0)
        {
            return IExecute<Org.Apache.Kafka.Connect.Runtime.ConnectorStatus>("get", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/storage/KafkaStatusBackingStore.html#get(org.apache.kafka.connect.util.ConnectorTaskId)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Connect.Util.ConnectorTaskId"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Connect.Runtime.TaskStatus"/></returns>
        public Org.Apache.Kafka.Connect.Runtime.TaskStatus Get(Org.Apache.Kafka.Connect.Util.ConnectorTaskId arg0)
        {
            return IExecute<Org.Apache.Kafka.Connect.Runtime.TaskStatus>("get", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/storage/KafkaStatusBackingStore.html#configure(org.apache.kafka.connect.runtime.WorkerConfig)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Connect.Runtime.WorkerConfig"/></param>
        public void Configure(Org.Apache.Kafka.Connect.Runtime.WorkerConfig arg0)
        {
            IExecute("configure", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/storage/KafkaStatusBackingStore.html#deleteTopic(java.lang.String,java.lang.String)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        public void DeleteTopic(string arg0, string arg1)
        {
            IExecute("deleteTopic", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/storage/KafkaStatusBackingStore.html#flush()"/>
        /// </summary>
        public void Flush()
        {
            IExecute("flush");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/storage/KafkaStatusBackingStore.html#put(org.apache.kafka.connect.runtime.ConnectorStatus)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Connect.Runtime.ConnectorStatus"/></param>
        public void Put(Org.Apache.Kafka.Connect.Runtime.ConnectorStatus arg0)
        {
            IExecute("put", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/storage/KafkaStatusBackingStore.html#put(org.apache.kafka.connect.runtime.TaskStatus)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Connect.Runtime.TaskStatus"/></param>
        public void Put(Org.Apache.Kafka.Connect.Runtime.TaskStatus arg0)
        {
            IExecute("put", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/storage/KafkaStatusBackingStore.html#put(org.apache.kafka.connect.runtime.TopicStatus)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Connect.Runtime.TopicStatus"/></param>
        public void Put(Org.Apache.Kafka.Connect.Runtime.TopicStatus arg0)
        {
            IExecute("put", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/storage/KafkaStatusBackingStore.html#putSafe(org.apache.kafka.connect.runtime.ConnectorStatus)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Connect.Runtime.ConnectorStatus"/></param>
        public void PutSafe(Org.Apache.Kafka.Connect.Runtime.ConnectorStatus arg0)
        {
            IExecute("putSafe", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/storage/KafkaStatusBackingStore.html#putSafe(org.apache.kafka.connect.runtime.TaskStatus)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Connect.Runtime.TaskStatus"/></param>
        public void PutSafe(Org.Apache.Kafka.Connect.Runtime.TaskStatus arg0)
        {
            IExecute("putSafe", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/storage/KafkaStatusBackingStore.html#start()"/>
        /// </summary>
        public void Start()
        {
            IExecute("start");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/storage/KafkaStatusBackingStore.html#stop()"/>
        /// </summary>
        public void Stop()
        {
            IExecute("stop");
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}