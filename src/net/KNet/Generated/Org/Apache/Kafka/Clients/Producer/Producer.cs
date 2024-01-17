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
*  This file is generated by MASES.JNetReflector (ver. 2.2.0.0)
*  using kafka-clients-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Clients.Producer
{
    #region Producer
    public partial class Producer
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
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/Producer.html#send-org.apache.kafka.clients.producer.ProducerRecord-org.apache.kafka.clients.producer.Callback-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Clients.Producer.ProducerRecord"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Clients.Producer.Callback"/></param>
        /// <returns><see cref="Java.Util.Concurrent.Future"/></returns>
        public Java.Util.Concurrent.Future Send(Org.Apache.Kafka.Clients.Producer.ProducerRecord arg0, Org.Apache.Kafka.Clients.Producer.Callback arg1)
        {
            return IExecute<Java.Util.Concurrent.Future>("send", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/Producer.html#send-org.apache.kafka.clients.producer.ProducerRecord-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Clients.Producer.ProducerRecord"/></param>
        /// <returns><see cref="Java.Util.Concurrent.Future"/></returns>
        public Java.Util.Concurrent.Future Send(Org.Apache.Kafka.Clients.Producer.ProducerRecord arg0)
        {
            return IExecute<Java.Util.Concurrent.Future>("send", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/Producer.html#partitionsFor-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="Java.Util.List"/></returns>
        public Java.Util.List PartitionsFor(string arg0)
        {
            return IExecute<Java.Util.List>("partitionsFor", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/Producer.html#metrics--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Map"/></returns>
        public Java.Util.Map Metrics()
        {
            return IExecute<Java.Util.Map>("metrics");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/Producer.html#abortTransaction--"/>
        /// </summary>

        /// <exception cref="Org.Apache.Kafka.Common.Errors.ProducerFencedException"/>
        public void AbortTransaction()
        {
            IExecute("abortTransaction");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/Producer.html#beginTransaction--"/>
        /// </summary>

        /// <exception cref="Org.Apache.Kafka.Common.Errors.ProducerFencedException"/>
        public void BeginTransaction()
        {
            IExecute("beginTransaction");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/Producer.html#close--"/>
        /// </summary>
        public void Close()
        {
            IExecute("close");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/Producer.html#close-java.time.Duration-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Time.Duration"/></param>
        public void Close(Java.Time.Duration arg0)
        {
            IExecute("close", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/Producer.html#commitTransaction--"/>
        /// </summary>

        /// <exception cref="Org.Apache.Kafka.Common.Errors.ProducerFencedException"/>
        public void CommitTransaction()
        {
            IExecute("commitTransaction");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/Producer.html#flush--"/>
        /// </summary>
        public void Flush()
        {
            IExecute("flush");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/Producer.html#initTransactions--"/>
        /// </summary>
        public void InitTransactions()
        {
            IExecute("initTransactions");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/Producer.html#sendOffsetsToTransaction-java.util.Map-org.apache.kafka.clients.consumer.ConsumerGroupMetadata-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Map"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Clients.Consumer.ConsumerGroupMetadata"/></param>
        /// <exception cref="Org.Apache.Kafka.Common.Errors.ProducerFencedException"/>
        public void SendOffsetsToTransaction(Java.Util.Map arg0, Org.Apache.Kafka.Clients.Consumer.ConsumerGroupMetadata arg1)
        {
            IExecute("sendOffsetsToTransaction", arg0, arg1);
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion

    #region IProducer<K, V>
    /// <summary>
    /// .NET interface for TO BE DEFINED FROM USER
    /// </summary>
    public partial interface IProducer<K, V> : Java.Io.ICloseable
    {
        #region Instance methods

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion

    #region Producer<K, V>
    public partial class Producer<K, V> : Org.Apache.Kafka.Clients.Producer.IProducer<K, V>
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Clients.Producer.Producer{K, V}"/> to <see cref="Org.Apache.Kafka.Clients.Producer.Producer"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Clients.Producer.Producer(Org.Apache.Kafka.Clients.Producer.Producer<K, V> t) => t.Cast<Org.Apache.Kafka.Clients.Producer.Producer>();

        #endregion

        #region Fields

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/Producer.html#send-org.apache.kafka.clients.producer.ProducerRecord-org.apache.kafka.clients.producer.Callback-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Clients.Producer.ProducerRecord"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Clients.Producer.Callback"/></param>
        /// <returns><see cref="Java.Util.Concurrent.Future"/></returns>
        public Java.Util.Concurrent.Future<Org.Apache.Kafka.Clients.Producer.RecordMetadata> Send(Org.Apache.Kafka.Clients.Producer.ProducerRecord<K, V> arg0, Org.Apache.Kafka.Clients.Producer.Callback arg1)
        {
            return IExecute<Java.Util.Concurrent.Future<Org.Apache.Kafka.Clients.Producer.RecordMetadata>>("send", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/Producer.html#send-org.apache.kafka.clients.producer.ProducerRecord-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Clients.Producer.ProducerRecord"/></param>
        /// <returns><see cref="Java.Util.Concurrent.Future"/></returns>
        public Java.Util.Concurrent.Future<Org.Apache.Kafka.Clients.Producer.RecordMetadata> Send(Org.Apache.Kafka.Clients.Producer.ProducerRecord<K, V> arg0)
        {
            return IExecute<Java.Util.Concurrent.Future<Org.Apache.Kafka.Clients.Producer.RecordMetadata>>("send", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/Producer.html#partitionsFor-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="Java.Util.List"/></returns>
        public Java.Util.List<Org.Apache.Kafka.Common.PartitionInfo> PartitionsFor(string arg0)
        {
            return IExecute<Java.Util.List<Org.Apache.Kafka.Common.PartitionInfo>>("partitionsFor", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/Producer.html#metrics--"/>
        /// </summary>

        /// <typeparam name="ReturnExtendsOrg_Apache_Kafka_Common_Metric"><see cref="Org.Apache.Kafka.Common.Metric"/></typeparam>
        /// <returns><see cref="Java.Util.Map"/></returns>
        public Java.Util.Map<Org.Apache.Kafka.Common.MetricName, ReturnExtendsOrg_Apache_Kafka_Common_Metric> Metrics<ReturnExtendsOrg_Apache_Kafka_Common_Metric>() where ReturnExtendsOrg_Apache_Kafka_Common_Metric: Org.Apache.Kafka.Common.Metric
        {
            return IExecute<Java.Util.Map<Org.Apache.Kafka.Common.MetricName, ReturnExtendsOrg_Apache_Kafka_Common_Metric>>("metrics");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/Producer.html#abortTransaction--"/>
        /// </summary>

        /// <exception cref="Org.Apache.Kafka.Common.Errors.ProducerFencedException"/>
        public void AbortTransaction()
        {
            IExecute("abortTransaction");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/Producer.html#beginTransaction--"/>
        /// </summary>

        /// <exception cref="Org.Apache.Kafka.Common.Errors.ProducerFencedException"/>
        public void BeginTransaction()
        {
            IExecute("beginTransaction");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/Producer.html#close--"/>
        /// </summary>
        public void Close()
        {
            IExecute("close");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/Producer.html#close-java.time.Duration-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Time.Duration"/></param>
        public void Close(Java.Time.Duration arg0)
        {
            IExecute("close", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/Producer.html#commitTransaction--"/>
        /// </summary>

        /// <exception cref="Org.Apache.Kafka.Common.Errors.ProducerFencedException"/>
        public void CommitTransaction()
        {
            IExecute("commitTransaction");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/Producer.html#flush--"/>
        /// </summary>
        public void Flush()
        {
            IExecute("flush");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/Producer.html#initTransactions--"/>
        /// </summary>
        public void InitTransactions()
        {
            IExecute("initTransactions");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/Producer.html#sendOffsetsToTransaction-java.util.Map-org.apache.kafka.clients.consumer.ConsumerGroupMetadata-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Map"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Clients.Consumer.ConsumerGroupMetadata"/></param>
        /// <exception cref="Org.Apache.Kafka.Common.Errors.ProducerFencedException"/>
        public void SendOffsetsToTransaction(Java.Util.Map<Org.Apache.Kafka.Common.TopicPartition, Org.Apache.Kafka.Clients.Consumer.OffsetAndMetadata> arg0, Org.Apache.Kafka.Clients.Consumer.ConsumerGroupMetadata arg1)
        {
            IExecute("sendOffsetsToTransaction", arg0, arg1);
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}