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
*  This file is generated by MASES.JNetReflector (ver. 2.0.2.0)
*  using kafka-clients-3.6.0.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Clients.Producer
{
    #region ProducerConfig
    public partial class ProducerConfig
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#org.apache.kafka.clients.producer.ProducerConfig(java.util.Map)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Map"/></param>
        public ProducerConfig(Java.Util.Map<string, object> arg0)
            : base(arg0)
        {
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#org.apache.kafka.clients.producer.ProducerConfig(java.util.Properties)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Properties"/></param>
        public ProducerConfig(Java.Util.Properties arg0)
            : base(arg0)
        {
        }

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#ACKS_CONFIG"/>
        /// </summary>
        public static string ACKS_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "ACKS_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#BATCH_SIZE_CONFIG"/>
        /// </summary>
        public static string BATCH_SIZE_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "BATCH_SIZE_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#BOOTSTRAP_SERVERS_CONFIG"/>
        /// </summary>
        public static string BOOTSTRAP_SERVERS_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "BOOTSTRAP_SERVERS_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#BUFFER_MEMORY_CONFIG"/>
        /// </summary>
        public static string BUFFER_MEMORY_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "BUFFER_MEMORY_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#CLIENT_DNS_LOOKUP_CONFIG"/>
        /// </summary>
        public static string CLIENT_DNS_LOOKUP_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "CLIENT_DNS_LOOKUP_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#CLIENT_ID_CONFIG"/>
        /// </summary>
        public static string CLIENT_ID_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "CLIENT_ID_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#COMPRESSION_TYPE_CONFIG"/>
        /// </summary>
        public static string COMPRESSION_TYPE_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "COMPRESSION_TYPE_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#CONNECTIONS_MAX_IDLE_MS_CONFIG"/>
        /// </summary>
        public static string CONNECTIONS_MAX_IDLE_MS_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "CONNECTIONS_MAX_IDLE_MS_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#DELIVERY_TIMEOUT_MS_CONFIG"/>
        /// </summary>
        public static string DELIVERY_TIMEOUT_MS_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "DELIVERY_TIMEOUT_MS_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#ENABLE_IDEMPOTENCE_CONFIG"/>
        /// </summary>
        public static string ENABLE_IDEMPOTENCE_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "ENABLE_IDEMPOTENCE_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#ENABLE_IDEMPOTENCE_DOC"/>
        /// </summary>
        public static string ENABLE_IDEMPOTENCE_DOC { get { return SGetField<string>(LocalBridgeClazz, "ENABLE_IDEMPOTENCE_DOC"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#INTERCEPTOR_CLASSES_CONFIG"/>
        /// </summary>
        public static string INTERCEPTOR_CLASSES_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "INTERCEPTOR_CLASSES_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#INTERCEPTOR_CLASSES_DOC"/>
        /// </summary>
        public static string INTERCEPTOR_CLASSES_DOC { get { return SGetField<string>(LocalBridgeClazz, "INTERCEPTOR_CLASSES_DOC"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#KEY_SERIALIZER_CLASS_CONFIG"/>
        /// </summary>
        public static string KEY_SERIALIZER_CLASS_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "KEY_SERIALIZER_CLASS_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#KEY_SERIALIZER_CLASS_DOC"/>
        /// </summary>
        public static string KEY_SERIALIZER_CLASS_DOC { get { return SGetField<string>(LocalBridgeClazz, "KEY_SERIALIZER_CLASS_DOC"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#LINGER_MS_CONFIG"/>
        /// </summary>
        public static string LINGER_MS_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "LINGER_MS_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#MAX_BLOCK_MS_CONFIG"/>
        /// </summary>
        public static string MAX_BLOCK_MS_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "MAX_BLOCK_MS_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#MAX_IN_FLIGHT_REQUESTS_PER_CONNECTION"/>
        /// </summary>
        public static string MAX_IN_FLIGHT_REQUESTS_PER_CONNECTION { get { return SGetField<string>(LocalBridgeClazz, "MAX_IN_FLIGHT_REQUESTS_PER_CONNECTION"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#MAX_REQUEST_SIZE_CONFIG"/>
        /// </summary>
        public static string MAX_REQUEST_SIZE_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "MAX_REQUEST_SIZE_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#METADATA_MAX_AGE_CONFIG"/>
        /// </summary>
        public static string METADATA_MAX_AGE_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "METADATA_MAX_AGE_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#METADATA_MAX_IDLE_CONFIG"/>
        /// </summary>
        public static string METADATA_MAX_IDLE_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "METADATA_MAX_IDLE_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#METRIC_REPORTER_CLASSES_CONFIG"/>
        /// </summary>
        public static string METRIC_REPORTER_CLASSES_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "METRIC_REPORTER_CLASSES_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#METRICS_NUM_SAMPLES_CONFIG"/>
        /// </summary>
        public static string METRICS_NUM_SAMPLES_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "METRICS_NUM_SAMPLES_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#METRICS_RECORDING_LEVEL_CONFIG"/>
        /// </summary>
        public static string METRICS_RECORDING_LEVEL_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "METRICS_RECORDING_LEVEL_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#METRICS_SAMPLE_WINDOW_MS_CONFIG"/>
        /// </summary>
        public static string METRICS_SAMPLE_WINDOW_MS_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "METRICS_SAMPLE_WINDOW_MS_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#PARTITIONER_ADPATIVE_PARTITIONING_ENABLE_CONFIG"/>
        /// </summary>
        public static string PARTITIONER_ADPATIVE_PARTITIONING_ENABLE_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "PARTITIONER_ADPATIVE_PARTITIONING_ENABLE_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#PARTITIONER_AVAILABILITY_TIMEOUT_MS_CONFIG"/>
        /// </summary>
        public static string PARTITIONER_AVAILABILITY_TIMEOUT_MS_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "PARTITIONER_AVAILABILITY_TIMEOUT_MS_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#PARTITIONER_CLASS_CONFIG"/>
        /// </summary>
        public static string PARTITIONER_CLASS_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "PARTITIONER_CLASS_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#PARTITIONER_IGNORE_KEYS_CONFIG"/>
        /// </summary>
        public static string PARTITIONER_IGNORE_KEYS_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "PARTITIONER_IGNORE_KEYS_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#RECEIVE_BUFFER_CONFIG"/>
        /// </summary>
        public static string RECEIVE_BUFFER_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "RECEIVE_BUFFER_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#RECONNECT_BACKOFF_MAX_MS_CONFIG"/>
        /// </summary>
        public static string RECONNECT_BACKOFF_MAX_MS_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "RECONNECT_BACKOFF_MAX_MS_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#RECONNECT_BACKOFF_MS_CONFIG"/>
        /// </summary>
        public static string RECONNECT_BACKOFF_MS_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "RECONNECT_BACKOFF_MS_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#REQUEST_TIMEOUT_MS_CONFIG"/>
        /// </summary>
        public static string REQUEST_TIMEOUT_MS_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "REQUEST_TIMEOUT_MS_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#RETRIES_CONFIG"/>
        /// </summary>
        public static string RETRIES_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "RETRIES_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#RETRY_BACKOFF_MS_CONFIG"/>
        /// </summary>
        public static string RETRY_BACKOFF_MS_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "RETRY_BACKOFF_MS_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#SECURITY_PROVIDERS_CONFIG"/>
        /// </summary>
        public static string SECURITY_PROVIDERS_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "SECURITY_PROVIDERS_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#SEND_BUFFER_CONFIG"/>
        /// </summary>
        public static string SEND_BUFFER_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "SEND_BUFFER_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#SOCKET_CONNECTION_SETUP_TIMEOUT_MAX_MS_CONFIG"/>
        /// </summary>
        public static string SOCKET_CONNECTION_SETUP_TIMEOUT_MAX_MS_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "SOCKET_CONNECTION_SETUP_TIMEOUT_MAX_MS_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#SOCKET_CONNECTION_SETUP_TIMEOUT_MS_CONFIG"/>
        /// </summary>
        public static string SOCKET_CONNECTION_SETUP_TIMEOUT_MS_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "SOCKET_CONNECTION_SETUP_TIMEOUT_MS_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#TRANSACTION_TIMEOUT_CONFIG"/>
        /// </summary>
        public static string TRANSACTION_TIMEOUT_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "TRANSACTION_TIMEOUT_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#TRANSACTION_TIMEOUT_DOC"/>
        /// </summary>
        public static string TRANSACTION_TIMEOUT_DOC { get { return SGetField<string>(LocalBridgeClazz, "TRANSACTION_TIMEOUT_DOC"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#TRANSACTIONAL_ID_CONFIG"/>
        /// </summary>
        public static string TRANSACTIONAL_ID_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "TRANSACTIONAL_ID_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#TRANSACTIONAL_ID_DOC"/>
        /// </summary>
        public static string TRANSACTIONAL_ID_DOC { get { return SGetField<string>(LocalBridgeClazz, "TRANSACTIONAL_ID_DOC"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#VALUE_SERIALIZER_CLASS_CONFIG"/>
        /// </summary>
        public static string VALUE_SERIALIZER_CLASS_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "VALUE_SERIALIZER_CLASS_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#VALUE_SERIALIZER_CLASS_DOC"/>
        /// </summary>
        public static string VALUE_SERIALIZER_CLASS_DOC { get { return SGetField<string>(LocalBridgeClazz, "VALUE_SERIALIZER_CLASS_DOC"); } }

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#configNames--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Set"/></returns>
        public static Java.Util.Set<string> ConfigNames()
        {
            return SExecute<Java.Util.Set<string>>(LocalBridgeClazz, "configNames");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#configDef--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Config.ConfigDef"/></returns>
        public static Org.Apache.Kafka.Common.Config.ConfigDef ConfigDef()
        {
            return SExecute<Org.Apache.Kafka.Common.Config.ConfigDef>(LocalBridgeClazz, "configDef");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/org/apache/kafka/clients/producer/ProducerConfig.html#main-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        public static void Main(string[] arg0)
        {
            SExecute(LocalBridgeClazz, "main", new object[] { arg0 });
        }

        #endregion

        #region Instance methods

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}