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
*  This file is generated by MASES.JNetReflector (ver. 2.2.3.0)
*  using kafka-clients-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Clients.Producer
{
    #region ProducerConfig
    public partial class ProducerConfig
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#org.apache.kafka.clients.producer.ProducerConfig(java.util.Map)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Map"/></param>
        public ProducerConfig(Java.Util.Map<string, object> arg0)
            : base(arg0)
        {
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#org.apache.kafka.clients.producer.ProducerConfig(java.util.Properties)"/>
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
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#ACKS_CONFIG"/>
        /// </summary>
        public static string ACKS_CONFIG { get { if (!_ACKS_CONFIGReady) { _ACKS_CONFIGContent = SGetField<string>(LocalBridgeClazz, "ACKS_CONFIG"); _ACKS_CONFIGReady = true; } return _ACKS_CONFIGContent; } }
        private static string _ACKS_CONFIGContent = default;
        private static bool _ACKS_CONFIGReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#BATCH_SIZE_CONFIG"/>
        /// </summary>
        public static string BATCH_SIZE_CONFIG { get { if (!_BATCH_SIZE_CONFIGReady) { _BATCH_SIZE_CONFIGContent = SGetField<string>(LocalBridgeClazz, "BATCH_SIZE_CONFIG"); _BATCH_SIZE_CONFIGReady = true; } return _BATCH_SIZE_CONFIGContent; } }
        private static string _BATCH_SIZE_CONFIGContent = default;
        private static bool _BATCH_SIZE_CONFIGReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#BOOTSTRAP_SERVERS_CONFIG"/>
        /// </summary>
        public static string BOOTSTRAP_SERVERS_CONFIG { get { if (!_BOOTSTRAP_SERVERS_CONFIGReady) { _BOOTSTRAP_SERVERS_CONFIGContent = SGetField<string>(LocalBridgeClazz, "BOOTSTRAP_SERVERS_CONFIG"); _BOOTSTRAP_SERVERS_CONFIGReady = true; } return _BOOTSTRAP_SERVERS_CONFIGContent; } }
        private static string _BOOTSTRAP_SERVERS_CONFIGContent = default;
        private static bool _BOOTSTRAP_SERVERS_CONFIGReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#BUFFER_MEMORY_CONFIG"/>
        /// </summary>
        public static string BUFFER_MEMORY_CONFIG { get { if (!_BUFFER_MEMORY_CONFIGReady) { _BUFFER_MEMORY_CONFIGContent = SGetField<string>(LocalBridgeClazz, "BUFFER_MEMORY_CONFIG"); _BUFFER_MEMORY_CONFIGReady = true; } return _BUFFER_MEMORY_CONFIGContent; } }
        private static string _BUFFER_MEMORY_CONFIGContent = default;
        private static bool _BUFFER_MEMORY_CONFIGReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#CLIENT_DNS_LOOKUP_CONFIG"/>
        /// </summary>
        public static string CLIENT_DNS_LOOKUP_CONFIG { get { if (!_CLIENT_DNS_LOOKUP_CONFIGReady) { _CLIENT_DNS_LOOKUP_CONFIGContent = SGetField<string>(LocalBridgeClazz, "CLIENT_DNS_LOOKUP_CONFIG"); _CLIENT_DNS_LOOKUP_CONFIGReady = true; } return _CLIENT_DNS_LOOKUP_CONFIGContent; } }
        private static string _CLIENT_DNS_LOOKUP_CONFIGContent = default;
        private static bool _CLIENT_DNS_LOOKUP_CONFIGReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#CLIENT_ID_CONFIG"/>
        /// </summary>
        public static string CLIENT_ID_CONFIG { get { if (!_CLIENT_ID_CONFIGReady) { _CLIENT_ID_CONFIGContent = SGetField<string>(LocalBridgeClazz, "CLIENT_ID_CONFIG"); _CLIENT_ID_CONFIGReady = true; } return _CLIENT_ID_CONFIGContent; } }
        private static string _CLIENT_ID_CONFIGContent = default;
        private static bool _CLIENT_ID_CONFIGReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#COMPRESSION_TYPE_CONFIG"/>
        /// </summary>
        public static string COMPRESSION_TYPE_CONFIG { get { if (!_COMPRESSION_TYPE_CONFIGReady) { _COMPRESSION_TYPE_CONFIGContent = SGetField<string>(LocalBridgeClazz, "COMPRESSION_TYPE_CONFIG"); _COMPRESSION_TYPE_CONFIGReady = true; } return _COMPRESSION_TYPE_CONFIGContent; } }
        private static string _COMPRESSION_TYPE_CONFIGContent = default;
        private static bool _COMPRESSION_TYPE_CONFIGReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#CONNECTIONS_MAX_IDLE_MS_CONFIG"/>
        /// </summary>
        public static string CONNECTIONS_MAX_IDLE_MS_CONFIG { get { if (!_CONNECTIONS_MAX_IDLE_MS_CONFIGReady) { _CONNECTIONS_MAX_IDLE_MS_CONFIGContent = SGetField<string>(LocalBridgeClazz, "CONNECTIONS_MAX_IDLE_MS_CONFIG"); _CONNECTIONS_MAX_IDLE_MS_CONFIGReady = true; } return _CONNECTIONS_MAX_IDLE_MS_CONFIGContent; } }
        private static string _CONNECTIONS_MAX_IDLE_MS_CONFIGContent = default;
        private static bool _CONNECTIONS_MAX_IDLE_MS_CONFIGReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#DELIVERY_TIMEOUT_MS_CONFIG"/>
        /// </summary>
        public static string DELIVERY_TIMEOUT_MS_CONFIG { get { if (!_DELIVERY_TIMEOUT_MS_CONFIGReady) { _DELIVERY_TIMEOUT_MS_CONFIGContent = SGetField<string>(LocalBridgeClazz, "DELIVERY_TIMEOUT_MS_CONFIG"); _DELIVERY_TIMEOUT_MS_CONFIGReady = true; } return _DELIVERY_TIMEOUT_MS_CONFIGContent; } }
        private static string _DELIVERY_TIMEOUT_MS_CONFIGContent = default;
        private static bool _DELIVERY_TIMEOUT_MS_CONFIGReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#ENABLE_IDEMPOTENCE_CONFIG"/>
        /// </summary>
        public static string ENABLE_IDEMPOTENCE_CONFIG { get { if (!_ENABLE_IDEMPOTENCE_CONFIGReady) { _ENABLE_IDEMPOTENCE_CONFIGContent = SGetField<string>(LocalBridgeClazz, "ENABLE_IDEMPOTENCE_CONFIG"); _ENABLE_IDEMPOTENCE_CONFIGReady = true; } return _ENABLE_IDEMPOTENCE_CONFIGContent; } }
        private static string _ENABLE_IDEMPOTENCE_CONFIGContent = default;
        private static bool _ENABLE_IDEMPOTENCE_CONFIGReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#ENABLE_IDEMPOTENCE_DOC"/>
        /// </summary>
        public static string ENABLE_IDEMPOTENCE_DOC { get { if (!_ENABLE_IDEMPOTENCE_DOCReady) { _ENABLE_IDEMPOTENCE_DOCContent = SGetField<string>(LocalBridgeClazz, "ENABLE_IDEMPOTENCE_DOC"); _ENABLE_IDEMPOTENCE_DOCReady = true; } return _ENABLE_IDEMPOTENCE_DOCContent; } }
        private static string _ENABLE_IDEMPOTENCE_DOCContent = default;
        private static bool _ENABLE_IDEMPOTENCE_DOCReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#INTERCEPTOR_CLASSES_CONFIG"/>
        /// </summary>
        public static string INTERCEPTOR_CLASSES_CONFIG { get { if (!_INTERCEPTOR_CLASSES_CONFIGReady) { _INTERCEPTOR_CLASSES_CONFIGContent = SGetField<string>(LocalBridgeClazz, "INTERCEPTOR_CLASSES_CONFIG"); _INTERCEPTOR_CLASSES_CONFIGReady = true; } return _INTERCEPTOR_CLASSES_CONFIGContent; } }
        private static string _INTERCEPTOR_CLASSES_CONFIGContent = default;
        private static bool _INTERCEPTOR_CLASSES_CONFIGReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#INTERCEPTOR_CLASSES_DOC"/>
        /// </summary>
        public static string INTERCEPTOR_CLASSES_DOC { get { if (!_INTERCEPTOR_CLASSES_DOCReady) { _INTERCEPTOR_CLASSES_DOCContent = SGetField<string>(LocalBridgeClazz, "INTERCEPTOR_CLASSES_DOC"); _INTERCEPTOR_CLASSES_DOCReady = true; } return _INTERCEPTOR_CLASSES_DOCContent; } }
        private static string _INTERCEPTOR_CLASSES_DOCContent = default;
        private static bool _INTERCEPTOR_CLASSES_DOCReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#KEY_SERIALIZER_CLASS_CONFIG"/>
        /// </summary>
        public static string KEY_SERIALIZER_CLASS_CONFIG { get { if (!_KEY_SERIALIZER_CLASS_CONFIGReady) { _KEY_SERIALIZER_CLASS_CONFIGContent = SGetField<string>(LocalBridgeClazz, "KEY_SERIALIZER_CLASS_CONFIG"); _KEY_SERIALIZER_CLASS_CONFIGReady = true; } return _KEY_SERIALIZER_CLASS_CONFIGContent; } }
        private static string _KEY_SERIALIZER_CLASS_CONFIGContent = default;
        private static bool _KEY_SERIALIZER_CLASS_CONFIGReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#KEY_SERIALIZER_CLASS_DOC"/>
        /// </summary>
        public static string KEY_SERIALIZER_CLASS_DOC { get { if (!_KEY_SERIALIZER_CLASS_DOCReady) { _KEY_SERIALIZER_CLASS_DOCContent = SGetField<string>(LocalBridgeClazz, "KEY_SERIALIZER_CLASS_DOC"); _KEY_SERIALIZER_CLASS_DOCReady = true; } return _KEY_SERIALIZER_CLASS_DOCContent; } }
        private static string _KEY_SERIALIZER_CLASS_DOCContent = default;
        private static bool _KEY_SERIALIZER_CLASS_DOCReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#LINGER_MS_CONFIG"/>
        /// </summary>
        public static string LINGER_MS_CONFIG { get { if (!_LINGER_MS_CONFIGReady) { _LINGER_MS_CONFIGContent = SGetField<string>(LocalBridgeClazz, "LINGER_MS_CONFIG"); _LINGER_MS_CONFIGReady = true; } return _LINGER_MS_CONFIGContent; } }
        private static string _LINGER_MS_CONFIGContent = default;
        private static bool _LINGER_MS_CONFIGReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#MAX_BLOCK_MS_CONFIG"/>
        /// </summary>
        public static string MAX_BLOCK_MS_CONFIG { get { if (!_MAX_BLOCK_MS_CONFIGReady) { _MAX_BLOCK_MS_CONFIGContent = SGetField<string>(LocalBridgeClazz, "MAX_BLOCK_MS_CONFIG"); _MAX_BLOCK_MS_CONFIGReady = true; } return _MAX_BLOCK_MS_CONFIGContent; } }
        private static string _MAX_BLOCK_MS_CONFIGContent = default;
        private static bool _MAX_BLOCK_MS_CONFIGReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#MAX_IN_FLIGHT_REQUESTS_PER_CONNECTION"/>
        /// </summary>
        public static string MAX_IN_FLIGHT_REQUESTS_PER_CONNECTION { get { if (!_MAX_IN_FLIGHT_REQUESTS_PER_CONNECTIONReady) { _MAX_IN_FLIGHT_REQUESTS_PER_CONNECTIONContent = SGetField<string>(LocalBridgeClazz, "MAX_IN_FLIGHT_REQUESTS_PER_CONNECTION"); _MAX_IN_FLIGHT_REQUESTS_PER_CONNECTIONReady = true; } return _MAX_IN_FLIGHT_REQUESTS_PER_CONNECTIONContent; } }
        private static string _MAX_IN_FLIGHT_REQUESTS_PER_CONNECTIONContent = default;
        private static bool _MAX_IN_FLIGHT_REQUESTS_PER_CONNECTIONReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#MAX_REQUEST_SIZE_CONFIG"/>
        /// </summary>
        public static string MAX_REQUEST_SIZE_CONFIG { get { if (!_MAX_REQUEST_SIZE_CONFIGReady) { _MAX_REQUEST_SIZE_CONFIGContent = SGetField<string>(LocalBridgeClazz, "MAX_REQUEST_SIZE_CONFIG"); _MAX_REQUEST_SIZE_CONFIGReady = true; } return _MAX_REQUEST_SIZE_CONFIGContent; } }
        private static string _MAX_REQUEST_SIZE_CONFIGContent = default;
        private static bool _MAX_REQUEST_SIZE_CONFIGReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#METADATA_MAX_AGE_CONFIG"/>
        /// </summary>
        public static string METADATA_MAX_AGE_CONFIG { get { if (!_METADATA_MAX_AGE_CONFIGReady) { _METADATA_MAX_AGE_CONFIGContent = SGetField<string>(LocalBridgeClazz, "METADATA_MAX_AGE_CONFIG"); _METADATA_MAX_AGE_CONFIGReady = true; } return _METADATA_MAX_AGE_CONFIGContent; } }
        private static string _METADATA_MAX_AGE_CONFIGContent = default;
        private static bool _METADATA_MAX_AGE_CONFIGReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#METADATA_MAX_IDLE_CONFIG"/>
        /// </summary>
        public static string METADATA_MAX_IDLE_CONFIG { get { if (!_METADATA_MAX_IDLE_CONFIGReady) { _METADATA_MAX_IDLE_CONFIGContent = SGetField<string>(LocalBridgeClazz, "METADATA_MAX_IDLE_CONFIG"); _METADATA_MAX_IDLE_CONFIGReady = true; } return _METADATA_MAX_IDLE_CONFIGContent; } }
        private static string _METADATA_MAX_IDLE_CONFIGContent = default;
        private static bool _METADATA_MAX_IDLE_CONFIGReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#METRIC_REPORTER_CLASSES_CONFIG"/>
        /// </summary>
        public static string METRIC_REPORTER_CLASSES_CONFIG { get { if (!_METRIC_REPORTER_CLASSES_CONFIGReady) { _METRIC_REPORTER_CLASSES_CONFIGContent = SGetField<string>(LocalBridgeClazz, "METRIC_REPORTER_CLASSES_CONFIG"); _METRIC_REPORTER_CLASSES_CONFIGReady = true; } return _METRIC_REPORTER_CLASSES_CONFIGContent; } }
        private static string _METRIC_REPORTER_CLASSES_CONFIGContent = default;
        private static bool _METRIC_REPORTER_CLASSES_CONFIGReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#METRICS_NUM_SAMPLES_CONFIG"/>
        /// </summary>
        public static string METRICS_NUM_SAMPLES_CONFIG { get { if (!_METRICS_NUM_SAMPLES_CONFIGReady) { _METRICS_NUM_SAMPLES_CONFIGContent = SGetField<string>(LocalBridgeClazz, "METRICS_NUM_SAMPLES_CONFIG"); _METRICS_NUM_SAMPLES_CONFIGReady = true; } return _METRICS_NUM_SAMPLES_CONFIGContent; } }
        private static string _METRICS_NUM_SAMPLES_CONFIGContent = default;
        private static bool _METRICS_NUM_SAMPLES_CONFIGReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#METRICS_RECORDING_LEVEL_CONFIG"/>
        /// </summary>
        public static string METRICS_RECORDING_LEVEL_CONFIG { get { if (!_METRICS_RECORDING_LEVEL_CONFIGReady) { _METRICS_RECORDING_LEVEL_CONFIGContent = SGetField<string>(LocalBridgeClazz, "METRICS_RECORDING_LEVEL_CONFIG"); _METRICS_RECORDING_LEVEL_CONFIGReady = true; } return _METRICS_RECORDING_LEVEL_CONFIGContent; } }
        private static string _METRICS_RECORDING_LEVEL_CONFIGContent = default;
        private static bool _METRICS_RECORDING_LEVEL_CONFIGReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#METRICS_SAMPLE_WINDOW_MS_CONFIG"/>
        /// </summary>
        public static string METRICS_SAMPLE_WINDOW_MS_CONFIG { get { if (!_METRICS_SAMPLE_WINDOW_MS_CONFIGReady) { _METRICS_SAMPLE_WINDOW_MS_CONFIGContent = SGetField<string>(LocalBridgeClazz, "METRICS_SAMPLE_WINDOW_MS_CONFIG"); _METRICS_SAMPLE_WINDOW_MS_CONFIGReady = true; } return _METRICS_SAMPLE_WINDOW_MS_CONFIGContent; } }
        private static string _METRICS_SAMPLE_WINDOW_MS_CONFIGContent = default;
        private static bool _METRICS_SAMPLE_WINDOW_MS_CONFIGReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#PARTITIONER_ADPATIVE_PARTITIONING_ENABLE_CONFIG"/>
        /// </summary>
        public static string PARTITIONER_ADPATIVE_PARTITIONING_ENABLE_CONFIG { get { if (!_PARTITIONER_ADPATIVE_PARTITIONING_ENABLE_CONFIGReady) { _PARTITIONER_ADPATIVE_PARTITIONING_ENABLE_CONFIGContent = SGetField<string>(LocalBridgeClazz, "PARTITIONER_ADPATIVE_PARTITIONING_ENABLE_CONFIG"); _PARTITIONER_ADPATIVE_PARTITIONING_ENABLE_CONFIGReady = true; } return _PARTITIONER_ADPATIVE_PARTITIONING_ENABLE_CONFIGContent; } }
        private static string _PARTITIONER_ADPATIVE_PARTITIONING_ENABLE_CONFIGContent = default;
        private static bool _PARTITIONER_ADPATIVE_PARTITIONING_ENABLE_CONFIGReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#PARTITIONER_AVAILABILITY_TIMEOUT_MS_CONFIG"/>
        /// </summary>
        public static string PARTITIONER_AVAILABILITY_TIMEOUT_MS_CONFIG { get { if (!_PARTITIONER_AVAILABILITY_TIMEOUT_MS_CONFIGReady) { _PARTITIONER_AVAILABILITY_TIMEOUT_MS_CONFIGContent = SGetField<string>(LocalBridgeClazz, "PARTITIONER_AVAILABILITY_TIMEOUT_MS_CONFIG"); _PARTITIONER_AVAILABILITY_TIMEOUT_MS_CONFIGReady = true; } return _PARTITIONER_AVAILABILITY_TIMEOUT_MS_CONFIGContent; } }
        private static string _PARTITIONER_AVAILABILITY_TIMEOUT_MS_CONFIGContent = default;
        private static bool _PARTITIONER_AVAILABILITY_TIMEOUT_MS_CONFIGReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#PARTITIONER_CLASS_CONFIG"/>
        /// </summary>
        public static string PARTITIONER_CLASS_CONFIG { get { if (!_PARTITIONER_CLASS_CONFIGReady) { _PARTITIONER_CLASS_CONFIGContent = SGetField<string>(LocalBridgeClazz, "PARTITIONER_CLASS_CONFIG"); _PARTITIONER_CLASS_CONFIGReady = true; } return _PARTITIONER_CLASS_CONFIGContent; } }
        private static string _PARTITIONER_CLASS_CONFIGContent = default;
        private static bool _PARTITIONER_CLASS_CONFIGReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#PARTITIONER_IGNORE_KEYS_CONFIG"/>
        /// </summary>
        public static string PARTITIONER_IGNORE_KEYS_CONFIG { get { if (!_PARTITIONER_IGNORE_KEYS_CONFIGReady) { _PARTITIONER_IGNORE_KEYS_CONFIGContent = SGetField<string>(LocalBridgeClazz, "PARTITIONER_IGNORE_KEYS_CONFIG"); _PARTITIONER_IGNORE_KEYS_CONFIGReady = true; } return _PARTITIONER_IGNORE_KEYS_CONFIGContent; } }
        private static string _PARTITIONER_IGNORE_KEYS_CONFIGContent = default;
        private static bool _PARTITIONER_IGNORE_KEYS_CONFIGReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#RECEIVE_BUFFER_CONFIG"/>
        /// </summary>
        public static string RECEIVE_BUFFER_CONFIG { get { if (!_RECEIVE_BUFFER_CONFIGReady) { _RECEIVE_BUFFER_CONFIGContent = SGetField<string>(LocalBridgeClazz, "RECEIVE_BUFFER_CONFIG"); _RECEIVE_BUFFER_CONFIGReady = true; } return _RECEIVE_BUFFER_CONFIGContent; } }
        private static string _RECEIVE_BUFFER_CONFIGContent = default;
        private static bool _RECEIVE_BUFFER_CONFIGReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#RECONNECT_BACKOFF_MAX_MS_CONFIG"/>
        /// </summary>
        public static string RECONNECT_BACKOFF_MAX_MS_CONFIG { get { if (!_RECONNECT_BACKOFF_MAX_MS_CONFIGReady) { _RECONNECT_BACKOFF_MAX_MS_CONFIGContent = SGetField<string>(LocalBridgeClazz, "RECONNECT_BACKOFF_MAX_MS_CONFIG"); _RECONNECT_BACKOFF_MAX_MS_CONFIGReady = true; } return _RECONNECT_BACKOFF_MAX_MS_CONFIGContent; } }
        private static string _RECONNECT_BACKOFF_MAX_MS_CONFIGContent = default;
        private static bool _RECONNECT_BACKOFF_MAX_MS_CONFIGReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#RECONNECT_BACKOFF_MS_CONFIG"/>
        /// </summary>
        public static string RECONNECT_BACKOFF_MS_CONFIG { get { if (!_RECONNECT_BACKOFF_MS_CONFIGReady) { _RECONNECT_BACKOFF_MS_CONFIGContent = SGetField<string>(LocalBridgeClazz, "RECONNECT_BACKOFF_MS_CONFIG"); _RECONNECT_BACKOFF_MS_CONFIGReady = true; } return _RECONNECT_BACKOFF_MS_CONFIGContent; } }
        private static string _RECONNECT_BACKOFF_MS_CONFIGContent = default;
        private static bool _RECONNECT_BACKOFF_MS_CONFIGReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#REQUEST_TIMEOUT_MS_CONFIG"/>
        /// </summary>
        public static string REQUEST_TIMEOUT_MS_CONFIG { get { if (!_REQUEST_TIMEOUT_MS_CONFIGReady) { _REQUEST_TIMEOUT_MS_CONFIGContent = SGetField<string>(LocalBridgeClazz, "REQUEST_TIMEOUT_MS_CONFIG"); _REQUEST_TIMEOUT_MS_CONFIGReady = true; } return _REQUEST_TIMEOUT_MS_CONFIGContent; } }
        private static string _REQUEST_TIMEOUT_MS_CONFIGContent = default;
        private static bool _REQUEST_TIMEOUT_MS_CONFIGReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#RETRIES_CONFIG"/>
        /// </summary>
        public static string RETRIES_CONFIG { get { if (!_RETRIES_CONFIGReady) { _RETRIES_CONFIGContent = SGetField<string>(LocalBridgeClazz, "RETRIES_CONFIG"); _RETRIES_CONFIGReady = true; } return _RETRIES_CONFIGContent; } }
        private static string _RETRIES_CONFIGContent = default;
        private static bool _RETRIES_CONFIGReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#RETRY_BACKOFF_MS_CONFIG"/>
        /// </summary>
        public static string RETRY_BACKOFF_MS_CONFIG { get { if (!_RETRY_BACKOFF_MS_CONFIGReady) { _RETRY_BACKOFF_MS_CONFIGContent = SGetField<string>(LocalBridgeClazz, "RETRY_BACKOFF_MS_CONFIG"); _RETRY_BACKOFF_MS_CONFIGReady = true; } return _RETRY_BACKOFF_MS_CONFIGContent; } }
        private static string _RETRY_BACKOFF_MS_CONFIGContent = default;
        private static bool _RETRY_BACKOFF_MS_CONFIGReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#SECURITY_PROVIDERS_CONFIG"/>
        /// </summary>
        public static string SECURITY_PROVIDERS_CONFIG { get { if (!_SECURITY_PROVIDERS_CONFIGReady) { _SECURITY_PROVIDERS_CONFIGContent = SGetField<string>(LocalBridgeClazz, "SECURITY_PROVIDERS_CONFIG"); _SECURITY_PROVIDERS_CONFIGReady = true; } return _SECURITY_PROVIDERS_CONFIGContent; } }
        private static string _SECURITY_PROVIDERS_CONFIGContent = default;
        private static bool _SECURITY_PROVIDERS_CONFIGReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#SEND_BUFFER_CONFIG"/>
        /// </summary>
        public static string SEND_BUFFER_CONFIG { get { if (!_SEND_BUFFER_CONFIGReady) { _SEND_BUFFER_CONFIGContent = SGetField<string>(LocalBridgeClazz, "SEND_BUFFER_CONFIG"); _SEND_BUFFER_CONFIGReady = true; } return _SEND_BUFFER_CONFIGContent; } }
        private static string _SEND_BUFFER_CONFIGContent = default;
        private static bool _SEND_BUFFER_CONFIGReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#SOCKET_CONNECTION_SETUP_TIMEOUT_MAX_MS_CONFIG"/>
        /// </summary>
        public static string SOCKET_CONNECTION_SETUP_TIMEOUT_MAX_MS_CONFIG { get { if (!_SOCKET_CONNECTION_SETUP_TIMEOUT_MAX_MS_CONFIGReady) { _SOCKET_CONNECTION_SETUP_TIMEOUT_MAX_MS_CONFIGContent = SGetField<string>(LocalBridgeClazz, "SOCKET_CONNECTION_SETUP_TIMEOUT_MAX_MS_CONFIG"); _SOCKET_CONNECTION_SETUP_TIMEOUT_MAX_MS_CONFIGReady = true; } return _SOCKET_CONNECTION_SETUP_TIMEOUT_MAX_MS_CONFIGContent; } }
        private static string _SOCKET_CONNECTION_SETUP_TIMEOUT_MAX_MS_CONFIGContent = default;
        private static bool _SOCKET_CONNECTION_SETUP_TIMEOUT_MAX_MS_CONFIGReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#SOCKET_CONNECTION_SETUP_TIMEOUT_MS_CONFIG"/>
        /// </summary>
        public static string SOCKET_CONNECTION_SETUP_TIMEOUT_MS_CONFIG { get { if (!_SOCKET_CONNECTION_SETUP_TIMEOUT_MS_CONFIGReady) { _SOCKET_CONNECTION_SETUP_TIMEOUT_MS_CONFIGContent = SGetField<string>(LocalBridgeClazz, "SOCKET_CONNECTION_SETUP_TIMEOUT_MS_CONFIG"); _SOCKET_CONNECTION_SETUP_TIMEOUT_MS_CONFIGReady = true; } return _SOCKET_CONNECTION_SETUP_TIMEOUT_MS_CONFIGContent; } }
        private static string _SOCKET_CONNECTION_SETUP_TIMEOUT_MS_CONFIGContent = default;
        private static bool _SOCKET_CONNECTION_SETUP_TIMEOUT_MS_CONFIGReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#TRANSACTION_TIMEOUT_CONFIG"/>
        /// </summary>
        public static string TRANSACTION_TIMEOUT_CONFIG { get { if (!_TRANSACTION_TIMEOUT_CONFIGReady) { _TRANSACTION_TIMEOUT_CONFIGContent = SGetField<string>(LocalBridgeClazz, "TRANSACTION_TIMEOUT_CONFIG"); _TRANSACTION_TIMEOUT_CONFIGReady = true; } return _TRANSACTION_TIMEOUT_CONFIGContent; } }
        private static string _TRANSACTION_TIMEOUT_CONFIGContent = default;
        private static bool _TRANSACTION_TIMEOUT_CONFIGReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#TRANSACTION_TIMEOUT_DOC"/>
        /// </summary>
        public static string TRANSACTION_TIMEOUT_DOC { get { if (!_TRANSACTION_TIMEOUT_DOCReady) { _TRANSACTION_TIMEOUT_DOCContent = SGetField<string>(LocalBridgeClazz, "TRANSACTION_TIMEOUT_DOC"); _TRANSACTION_TIMEOUT_DOCReady = true; } return _TRANSACTION_TIMEOUT_DOCContent; } }
        private static string _TRANSACTION_TIMEOUT_DOCContent = default;
        private static bool _TRANSACTION_TIMEOUT_DOCReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#TRANSACTIONAL_ID_CONFIG"/>
        /// </summary>
        public static string TRANSACTIONAL_ID_CONFIG { get { if (!_TRANSACTIONAL_ID_CONFIGReady) { _TRANSACTIONAL_ID_CONFIGContent = SGetField<string>(LocalBridgeClazz, "TRANSACTIONAL_ID_CONFIG"); _TRANSACTIONAL_ID_CONFIGReady = true; } return _TRANSACTIONAL_ID_CONFIGContent; } }
        private static string _TRANSACTIONAL_ID_CONFIGContent = default;
        private static bool _TRANSACTIONAL_ID_CONFIGReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#TRANSACTIONAL_ID_DOC"/>
        /// </summary>
        public static string TRANSACTIONAL_ID_DOC { get { if (!_TRANSACTIONAL_ID_DOCReady) { _TRANSACTIONAL_ID_DOCContent = SGetField<string>(LocalBridgeClazz, "TRANSACTIONAL_ID_DOC"); _TRANSACTIONAL_ID_DOCReady = true; } return _TRANSACTIONAL_ID_DOCContent; } }
        private static string _TRANSACTIONAL_ID_DOCContent = default;
        private static bool _TRANSACTIONAL_ID_DOCReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#VALUE_SERIALIZER_CLASS_CONFIG"/>
        /// </summary>
        public static string VALUE_SERIALIZER_CLASS_CONFIG { get { if (!_VALUE_SERIALIZER_CLASS_CONFIGReady) { _VALUE_SERIALIZER_CLASS_CONFIGContent = SGetField<string>(LocalBridgeClazz, "VALUE_SERIALIZER_CLASS_CONFIG"); _VALUE_SERIALIZER_CLASS_CONFIGReady = true; } return _VALUE_SERIALIZER_CLASS_CONFIGContent; } }
        private static string _VALUE_SERIALIZER_CLASS_CONFIGContent = default;
        private static bool _VALUE_SERIALIZER_CLASS_CONFIGReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#VALUE_SERIALIZER_CLASS_DOC"/>
        /// </summary>
        public static string VALUE_SERIALIZER_CLASS_DOC { get { if (!_VALUE_SERIALIZER_CLASS_DOCReady) { _VALUE_SERIALIZER_CLASS_DOCContent = SGetField<string>(LocalBridgeClazz, "VALUE_SERIALIZER_CLASS_DOC"); _VALUE_SERIALIZER_CLASS_DOCReady = true; } return _VALUE_SERIALIZER_CLASS_DOCContent; } }
        private static string _VALUE_SERIALIZER_CLASS_DOCContent = default;
        private static bool _VALUE_SERIALIZER_CLASS_DOCReady = false; // this is used because in case of generics 

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#configNames--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Set"/></returns>
        public static Java.Util.Set<string> ConfigNames()
        {
            return SExecute<Java.Util.Set<string>>(LocalBridgeClazz, "configNames");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#configDef--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Config.ConfigDef"/></returns>
        public static Org.Apache.Kafka.Common.Config.ConfigDef ConfigDef()
        {
            return SExecute<Org.Apache.Kafka.Common.Config.ConfigDef>(LocalBridgeClazz, "configDef");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/producer/ProducerConfig.html#main-java.lang.String[]-"/>
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