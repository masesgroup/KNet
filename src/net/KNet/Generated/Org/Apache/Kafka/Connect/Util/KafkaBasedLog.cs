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
*  using connect-runtime-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Connect.Util
{
    #region KafkaBasedLog
    public partial class KafkaBasedLog
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/KafkaBasedLog.html#org.apache.kafka.connect.util.KafkaBasedLog(java.lang.String,java.util.Map,java.util.Map,java.util.function.Supplier,org.apache.kafka.connect.util.Callback,org.apache.kafka.common.utils.Time,java.util.function.Consumer)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <param name="arg1"><see cref="Java.Util.Map"/></param>
        /// <param name="arg2"><see cref="Java.Util.Map"/></param>
        /// <param name="arg3"><see cref="Java.Util.Function.Supplier"/></param>
        /// <param name="arg4"><see cref="Org.Apache.Kafka.Connect.Util.Callback"/></param>
        /// <param name="arg5"><see cref="Org.Apache.Kafka.Common.Utils.Time"/></param>
        /// <param name="arg6"><see cref="Java.Util.Function.Consumer"/></param>
        public KafkaBasedLog(Java.Lang.String arg0, Java.Util.Map arg1, Java.Util.Map arg2, Java.Util.Function.Supplier arg3, Org.Apache.Kafka.Connect.Util.Callback arg4, Org.Apache.Kafka.Common.Utils.Time arg5, Java.Util.Function.Consumer arg6)
            : base(arg0, arg1, arg2, arg3, arg4, arg5, arg6)
        {
        }

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/KafkaBasedLog.html#withExistingClients-java.lang.String-org.apache.kafka.clients.consumer.Consumer-org.apache.kafka.clients.producer.Producer-org.apache.kafka.connect.util.TopicAdmin-org.apache.kafka.connect.util.Callback-org.apache.kafka.common.utils.Time-java.util.function.Consumer-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Clients.Consumer.Consumer"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Clients.Producer.Producer"/></param>
        /// <param name="arg3"><see cref="Org.Apache.Kafka.Connect.Util.TopicAdmin"/></param>
        /// <param name="arg4"><see cref="Org.Apache.Kafka.Connect.Util.Callback"/></param>
        /// <param name="arg5"><see cref="Org.Apache.Kafka.Common.Utils.Time"/></param>
        /// <param name="arg6"><see cref="Java.Util.Function.Consumer"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Connect.Util.KafkaBasedLog"/></returns>
        public static Org.Apache.Kafka.Connect.Util.KafkaBasedLog WithExistingClients(Java.Lang.String arg0, Org.Apache.Kafka.Clients.Consumer.Consumer arg1, Org.Apache.Kafka.Clients.Producer.Producer arg2, Org.Apache.Kafka.Connect.Util.TopicAdmin arg3, Org.Apache.Kafka.Connect.Util.Callback arg4, Org.Apache.Kafka.Common.Utils.Time arg5, Java.Util.Function.Consumer arg6)
        {
            return SExecute<Org.Apache.Kafka.Connect.Util.KafkaBasedLog>(LocalBridgeClazz, "withExistingClients", arg0, arg1, arg2, arg3, arg4, arg5, arg6);
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/KafkaBasedLog.html#partitionCount--"/>
        /// </summary>

        /// <returns><see cref="int"/></returns>
        public int PartitionCount()
        {
            return IExecuteWithSignature<int>("partitionCount", "()I");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/KafkaBasedLog.html#readToEnd--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Concurrent.Future"/></returns>
        public Java.Util.Concurrent.Future ReadToEnd()
        {
            return IExecuteWithSignature<Java.Util.Concurrent.Future>("readToEnd", "()Ljava/util/concurrent/Future;");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/KafkaBasedLog.html#sendWithReceipt-java.lang.Object-java.lang.Object-org.apache.kafka.clients.producer.Callback-"/>
        /// </summary>
        /// <param name="arg0"><see cref="object"/></param>
        /// <param name="arg1"><see cref="object"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Clients.Producer.Callback"/></param>
        /// <returns><see cref="Java.Util.Concurrent.Future"/></returns>
        public Java.Util.Concurrent.Future SendWithReceipt(object arg0, object arg1, Org.Apache.Kafka.Clients.Producer.Callback arg2)
        {
            return IExecute<Java.Util.Concurrent.Future>("sendWithReceipt", arg0, arg1, arg2);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/KafkaBasedLog.html#sendWithReceipt-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><see cref="object"/></param>
        /// <param name="arg1"><see cref="object"/></param>
        /// <returns><see cref="Java.Util.Concurrent.Future"/></returns>
        public Java.Util.Concurrent.Future SendWithReceipt(object arg0, object arg1)
        {
            return IExecute<Java.Util.Concurrent.Future>("sendWithReceipt", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/KafkaBasedLog.html#flush--"/>
        /// </summary>
        public void Flush()
        {
            IExecuteWithSignature("flush", "()V");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/KafkaBasedLog.html#readToEnd-org.apache.kafka.connect.util.Callback-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Connect.Util.Callback"/></param>
        public void ReadToEnd(Org.Apache.Kafka.Connect.Util.Callback arg0)
        {
            IExecuteWithSignature("readToEnd", "(Lorg/apache/kafka/connect/util/Callback;)V", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/KafkaBasedLog.html#send-java.lang.Object-java.lang.Object-org.apache.kafka.clients.producer.Callback-"/>
        /// </summary>
        /// <param name="arg0"><see cref="object"/></param>
        /// <param name="arg1"><see cref="object"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Clients.Producer.Callback"/></param>
        public void Send(object arg0, object arg1, Org.Apache.Kafka.Clients.Producer.Callback arg2)
        {
            IExecute("send", arg0, arg1, arg2);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/KafkaBasedLog.html#send-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><see cref="object"/></param>
        /// <param name="arg1"><see cref="object"/></param>
        public void Send(object arg0, object arg1)
        {
            IExecute("send", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/KafkaBasedLog.html#start--"/>
        /// </summary>
        public void Start()
        {
            IExecuteWithSignature("start", "()V");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/KafkaBasedLog.html#stop--"/>
        /// </summary>
        public void Stop()
        {
            IExecuteWithSignature("stop", "()V");
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion

    #region KafkaBasedLog<K, V>
    public partial class KafkaBasedLog<K, V>
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/KafkaBasedLog.html#org.apache.kafka.connect.util.KafkaBasedLog(java.lang.String,java.util.Map,java.util.Map,java.util.function.Supplier,org.apache.kafka.connect.util.Callback,org.apache.kafka.common.utils.Time,java.util.function.Consumer)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <param name="arg1"><see cref="Java.Util.Map"/></param>
        /// <param name="arg2"><see cref="Java.Util.Map"/></param>
        /// <param name="arg3"><see cref="Java.Util.Function.Supplier"/></param>
        /// <param name="arg4"><see cref="Org.Apache.Kafka.Connect.Util.Callback"/></param>
        /// <param name="arg5"><see cref="Org.Apache.Kafka.Common.Utils.Time"/></param>
        /// <param name="arg6"><see cref="Java.Util.Function.Consumer"/></param>
        public KafkaBasedLog(Java.Lang.String arg0, Java.Util.Map<Java.Lang.String, object> arg1, Java.Util.Map<Java.Lang.String, object> arg2, Java.Util.Function.Supplier<Org.Apache.Kafka.Connect.Util.TopicAdmin> arg3, Org.Apache.Kafka.Connect.Util.Callback<Org.Apache.Kafka.Clients.Consumer.ConsumerRecord<K, V>> arg4, Org.Apache.Kafka.Common.Utils.Time arg5, Java.Util.Function.Consumer<Org.Apache.Kafka.Connect.Util.TopicAdmin> arg6)
            : base(arg0, arg1, arg2, arg3, arg4, arg5, arg6)
        {
        }

        #endregion

        #region Class/Interface conversion operators
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Connect.Util.KafkaBasedLog{K, V}"/> to <see cref="Org.Apache.Kafka.Connect.Util.KafkaBasedLog"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Connect.Util.KafkaBasedLog(Org.Apache.Kafka.Connect.Util.KafkaBasedLog<K, V> t) => t.Cast<Org.Apache.Kafka.Connect.Util.KafkaBasedLog>();

        #endregion

        #region Fields

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/KafkaBasedLog.html#withExistingClients-java.lang.String-org.apache.kafka.clients.consumer.Consumer-org.apache.kafka.clients.producer.Producer-org.apache.kafka.connect.util.TopicAdmin-org.apache.kafka.connect.util.Callback-org.apache.kafka.common.utils.Time-java.util.function.Consumer-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Clients.Consumer.Consumer"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Clients.Producer.Producer"/></param>
        /// <param name="arg3"><see cref="Org.Apache.Kafka.Connect.Util.TopicAdmin"/></param>
        /// <param name="arg4"><see cref="Org.Apache.Kafka.Connect.Util.Callback"/></param>
        /// <param name="arg5"><see cref="Org.Apache.Kafka.Common.Utils.Time"/></param>
        /// <param name="arg6"><see cref="Java.Util.Function.Consumer"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Connect.Util.KafkaBasedLog"/></returns>
        public static Org.Apache.Kafka.Connect.Util.KafkaBasedLog<K, V> WithExistingClients(Java.Lang.String arg0, Org.Apache.Kafka.Clients.Consumer.Consumer<K, V> arg1, Org.Apache.Kafka.Clients.Producer.Producer<K, V> arg2, Org.Apache.Kafka.Connect.Util.TopicAdmin arg3, Org.Apache.Kafka.Connect.Util.Callback<Org.Apache.Kafka.Clients.Consumer.ConsumerRecord<K, V>> arg4, Org.Apache.Kafka.Common.Utils.Time arg5, Java.Util.Function.Consumer<Org.Apache.Kafka.Connect.Util.TopicAdmin> arg6)
        {
            return SExecute<Org.Apache.Kafka.Connect.Util.KafkaBasedLog<K, V>>(LocalBridgeClazz, "withExistingClients", arg0, arg1, arg2, arg3, arg4, arg5, arg6);
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/KafkaBasedLog.html#partitionCount--"/>
        /// </summary>

        /// <returns><see cref="int"/></returns>
        public int PartitionCount()
        {
            return IExecuteWithSignature<int>("partitionCount", "()I");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/KafkaBasedLog.html#readToEnd--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Concurrent.Future"/></returns>
        public Java.Util.Concurrent.Future<Java.Lang.Void> ReadToEnd()
        {
            return IExecuteWithSignature<Java.Util.Concurrent.Future<Java.Lang.Void>>("readToEnd", "()Ljava/util/concurrent/Future;");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/KafkaBasedLog.html#sendWithReceipt-java.lang.Object-java.lang.Object-org.apache.kafka.clients.producer.Callback-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="K"/></param>
        /// <param name="arg1"><typeparamref name="V"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Clients.Producer.Callback"/></param>
        /// <returns><see cref="Java.Util.Concurrent.Future"/></returns>
        public Java.Util.Concurrent.Future<Org.Apache.Kafka.Clients.Producer.RecordMetadata> SendWithReceipt(K arg0, V arg1, Org.Apache.Kafka.Clients.Producer.Callback arg2)
        {
            return IExecute<Java.Util.Concurrent.Future<Org.Apache.Kafka.Clients.Producer.RecordMetadata>>("sendWithReceipt", arg0, arg1, arg2);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/KafkaBasedLog.html#sendWithReceipt-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="K"/></param>
        /// <param name="arg1"><typeparamref name="V"/></param>
        /// <returns><see cref="Java.Util.Concurrent.Future"/></returns>
        public Java.Util.Concurrent.Future<Org.Apache.Kafka.Clients.Producer.RecordMetadata> SendWithReceipt(K arg0, V arg1)
        {
            return IExecute<Java.Util.Concurrent.Future<Org.Apache.Kafka.Clients.Producer.RecordMetadata>>("sendWithReceipt", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/KafkaBasedLog.html#flush--"/>
        /// </summary>
        public void Flush()
        {
            IExecuteWithSignature("flush", "()V");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/KafkaBasedLog.html#readToEnd-org.apache.kafka.connect.util.Callback-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Connect.Util.Callback"/></param>
        public void ReadToEnd(Org.Apache.Kafka.Connect.Util.Callback<Java.Lang.Void> arg0)
        {
            IExecuteWithSignature("readToEnd", "(Lorg/apache/kafka/connect/util/Callback;)V", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/KafkaBasedLog.html#send-java.lang.Object-java.lang.Object-org.apache.kafka.clients.producer.Callback-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="K"/></param>
        /// <param name="arg1"><typeparamref name="V"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Clients.Producer.Callback"/></param>
        public void Send(K arg0, V arg1, Org.Apache.Kafka.Clients.Producer.Callback arg2)
        {
            IExecute("send", arg0, arg1, arg2);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/KafkaBasedLog.html#send-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="K"/></param>
        /// <param name="arg1"><typeparamref name="V"/></param>
        public void Send(K arg0, V arg1)
        {
            IExecute("send", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/KafkaBasedLog.html#start--"/>
        /// </summary>
        public void Start()
        {
            IExecuteWithSignature("start", "()V");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/KafkaBasedLog.html#stop--"/>
        /// </summary>
        public void Stop()
        {
            IExecuteWithSignature("stop", "()V");
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}