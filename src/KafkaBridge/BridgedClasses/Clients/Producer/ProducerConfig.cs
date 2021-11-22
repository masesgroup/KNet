/*
*  Copyright 2021 MASES s.r.l.
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

namespace MASES.KafkaBridge.Clients.Producer
{
    public class ProducerConfig : JCOBridge.C2JBridge.JVMBridgeBase<ProducerConfig>
    {
        public override bool IsStatic => true;
        public override string ClassName => "org.apache.kafka.clients.producer.ProducerConfig";

        public static readonly string BOOTSTRAP_SERVERS_CONFIG = Clazz.GetField<string>("BOOTSTRAP_SERVERS_CONFIG");

        public static readonly string CLIENT_DNS_LOOKUP_CONFIG = Clazz.GetField<string>("CLIENT_DNS_LOOKUP_CONFIG");

        public static readonly string METADATA_MAX_AGE_CONFIG = Clazz.GetField<string>("METADATA_MAX_AGE_CONFIG");

        public static readonly string METADATA_MAX_IDLE_CONFIG = Clazz.GetField<string>("METADATA_MAX_IDLE_CONFIG");

        public static readonly string BATCH_SIZE_CONFIG = Clazz.GetField<string>("BATCH_SIZE_CONFIG");

        public static readonly string ACKS_CONFIG = Clazz.GetField<string>("ACKS_CONFIG");

        public static readonly string LINGER_MS_CONFIG = Clazz.GetField<string>("LINGER_MS_CONFIG");

        public static readonly string REQUEST_TIMEOUT_MS_CONFIG = Clazz.GetField<string>("REQUEST_TIMEOUT_MS_CONFIG");

        public static readonly string DELIVERY_TIMEOUT_MS_CONFIG = Clazz.GetField<string>("DELIVERY_TIMEOUT_MS_CONFIG");

        public static readonly string CLIENT_ID_CONFIG = Clazz.GetField<string>("CLIENT_ID_CONFIG");

        public static readonly string SEND_BUFFER_CONFIG = Clazz.GetField<string>("SEND_BUFFER_CONFIG");

        public static readonly string RECEIVE_BUFFER_CONFIG = Clazz.GetField<string>("RECEIVE_BUFFER_CONFIG");

        public static readonly string MAX_REQUEST_SIZE_CONFIG = Clazz.GetField<string>("MAX_REQUEST_SIZE_CONFIG");

        public static readonly string RECONNECT_BACKOFF_MS_CONFIG = Clazz.GetField<string>("RECONNECT_BACKOFF_MS_CONFIG");

        public static readonly string RECONNECT_BACKOFF_MAX_MS_CONFIG = Clazz.GetField<string>("RECONNECT_BACKOFF_MAX_MS_CONFIG");

        public static readonly string MAX_BLOCK_MS_CONFIG = Clazz.GetField<string>("MAX_BLOCK_MS_CONFIG");

        public static readonly string BUFFER_MEMORY_CONFIG = Clazz.GetField<string>("BUFFER_MEMORY_CONFIG");

        public static readonly string RETRY_BACKOFF_MS_CONFIG = Clazz.GetField<string>("RETRY_BACKOFF_MS_CONFIG");

        public static readonly string COMPRESSION_TYPE_CONFIG = Clazz.GetField<string>("COMPRESSION_TYPE_CONFIG");

        public static readonly string METRICS_SAMPLE_WINDOW_MS_CONFIG = Clazz.GetField<string>("METRICS_SAMPLE_WINDOW_MS_CONFIG");

        public static readonly string METRICS_NUM_SAMPLES_CONFIG = Clazz.GetField<string>("METRICS_NUM_SAMPLES_CONFIG");

        public static readonly string METRICS_RECORDING_LEVEL_CONFIG = Clazz.GetField<string>("METRICS_RECORDING_LEVEL_CONFIG");

        public static readonly string METRIC_REPORTER_CLASSES_CONFIG = Clazz.GetField<string>("METRIC_REPORTER_CLASSES_CONFIG");

        public static readonly string MAX_IN_FLIGHT_REQUESTS_PER_CONNECTION = Clazz.GetField<string>("MAX_IN_FLIGHT_REQUESTS_PER_CONNECTION");

        public static readonly string RETRIES_CONFIG = Clazz.GetField<string>("RETRIES_CONFIG");

        public static readonly string KEY_SERIALIZER_CLASS_CONFIG = Clazz.GetField<string>("KEY_SERIALIZER_CLASS_CONFIG");

        public static readonly string VALUE_SERIALIZER_CLASS_CONFIG = Clazz.GetField<string>("VALUE_SERIALIZER_CLASS_CONFIG");

        public static readonly string SOCKET_CONNECTION_SETUP_TIMEOUT_MS_CONFIG = Clazz.GetField<string>("SOCKET_CONNECTION_SETUP_TIMEOUT_MS_CONFIG");

        public static readonly string SOCKET_CONNECTION_SETUP_TIMEOUT_MAX_MS_CONFIG = Clazz.GetField<string>("SOCKET_CONNECTION_SETUP_TIMEOUT_MAX_MS_CONFIG");

        public static readonly string CONNECTIONS_MAX_IDLE_MS_CONFIG = Clazz.GetField<string>("CONNECTIONS_MAX_IDLE_MS_CONFIG");

        public static readonly string PARTITIONER_CLASS_CONFIG = Clazz.GetField<string>("PARTITIONER_CLASS_CONFIG");

        public static readonly string INTERCEPTOR_CLASSES_CONFIG = Clazz.GetField<string>("INTERCEPTOR_CLASSES_CONFIG");

        public static readonly string ENABLE_IDEMPOTENCE_CONFIG = Clazz.GetField<string>("ENABLE_IDEMPOTENCE_CONFIG");

        public static readonly string TRANSACTION_TIMEOUT_CONFIG = Clazz.GetField<string>("TRANSACTION_TIMEOUT_CONFIG");

        public static readonly string TRANSACTIONAL_ID_CONFIG = Clazz.GetField<string>("TRANSACTIONAL_ID_CONFIG");

        public static readonly string SECURITY_PROVIDERS_CONFIG = Clazz.GetField<string>("SECURITY_PROVIDERS_CONFIG");
    }
}
