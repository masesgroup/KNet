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

namespace MASES.KafkaBridge.Clients.Consumer
{
    public class ConsumerConfig : JCOBridge.C2JBridge.JVMBridgeBase<ConsumerConfig>
    {
        public override bool IsStatic => true;
        public override string ClassName => "org.apache.kafka.clients.consumer.ConsumerConfig";

        public static readonly string GROUP_ID_CONFIG = Clazz.GetField<string>("GROUP_ID_CONFIG");

        public static readonly string GROUP_INSTANCE_ID_CONFIG = Clazz.GetField<string>("GROUP_INSTANCE_ID_CONFIG");

        public static readonly string MAX_POLL_RECORDS_CONFIG = Clazz.GetField<string>("MAX_POLL_RECORDS_CONFIG");

        public static readonly string MAX_POLL_INTERVAL_MS_CONFIG = Clazz.GetField<string>("MAX_POLL_INTERVAL_MS_CONFIG");

        public static readonly string SESSION_TIMEOUT_MS_CONFIG = Clazz.GetField<string>("SESSION_TIMEOUT_MS_CONFIG");

        public static readonly string HEARTBEAT_INTERVAL_MS_CONFIG = Clazz.GetField<string>("HEARTBEAT_INTERVAL_MS_CONFIG");

        public static readonly string BOOTSTRAP_SERVERS_CONFIG = Clazz.GetField<string>("BOOTSTRAP_SERVERS_CONFIG");

        public static readonly string CLIENT_DNS_LOOKUP_CONFIG = Clazz.GetField<string>("CLIENT_DNS_LOOKUP_CONFIG");

        public static readonly string ENABLE_AUTO_COMMIT_CONFIG = Clazz.GetField<string>("ENABLE_AUTO_COMMIT_CONFIG");

        public static readonly string AUTO_COMMIT_INTERVAL_MS_CONFIG = Clazz.GetField<string>("AUTO_COMMIT_INTERVAL_MS_CONFIG");

        public static readonly string PARTITION_ASSIGNMENT_STRATEGY_CONFIG = Clazz.GetField<string>("PARTITION_ASSIGNMENT_STRATEGY_CONFIG");

        public static readonly string AUTO_OFFSET_RESET_CONFIG = Clazz.GetField<string>("AUTO_OFFSET_RESET_CONFIG");

        public static readonly string FETCH_MIN_BYTES_CONFIG = Clazz.GetField<string>("FETCH_MIN_BYTES_CONFIG");

        public static readonly string FETCH_MAX_BYTES_CONFIG = Clazz.GetField<string>("FETCH_MAX_BYTES_CONFIG");

        public static readonly int DEFAULT_FETCH_MAX_BYTES = Clazz.GetField<int>("DEFAULT_FETCH_MAX_BYTES");


        public static readonly string FETCH_MAX_WAIT_MS_CONFIG = Clazz.GetField<string>("FETCH_MAX_WAIT_MS_CONFIG");

        public static readonly string METADATA_MAX_AGE_CONFIG = Clazz.GetField<string>("METADATA_MAX_AGE_CONFIG");

        public static readonly string MAX_PARTITION_FETCH_BYTES_CONFIG = Clazz.GetField<string>("MAX_PARTITION_FETCH_BYTES_CONFIG");

        public static readonly int DEFAULT_MAX_PARTITION_FETCH_BYTES = Clazz.GetField<int>("DEFAULT_MAX_PARTITION_FETCH_BYTES");

        public static readonly string SEND_BUFFER_CONFIG = Clazz.GetField<string>("SEND_BUFFER_CONFIG");

        public static readonly string RECEIVE_BUFFER_CONFIG = Clazz.GetField<string>("RECEIVE_BUFFER_CONFIG");

        public static readonly string CLIENT_ID_CONFIG = Clazz.GetField<string>("CLIENT_ID_CONFIG");

        public static readonly string CLIENT_RACK_CONFIG = Clazz.GetField<string>("CLIENT_RACK_CONFIG");

        public static readonly string RECONNECT_BACKOFF_MS_CONFIG = Clazz.GetField<string>("RECONNECT_BACKOFF_MS_CONFIG");

        public static readonly string RECONNECT_BACKOFF_MAX_MS_CONFIG = Clazz.GetField<string>("RECONNECT_BACKOFF_MAX_MS_CONFIG");

        public static readonly string RETRY_BACKOFF_MS_CONFIG = Clazz.GetField<string>("RETRY_BACKOFF_MS_CONFIG");

        public static readonly string METRICS_SAMPLE_WINDOW_MS_CONFIG = Clazz.GetField<string>("METRICS_SAMPLE_WINDOW_MS_CONFIG");

        public static readonly string METRICS_NUM_SAMPLES_CONFIG = Clazz.GetField<string>("METRICS_NUM_SAMPLES_CONFIG");

        public static readonly string METRICS_RECORDING_LEVEL_CONFIG = Clazz.GetField<string>("METRICS_RECORDING_LEVEL_CONFIG");

        public static readonly string METRIC_REPORTER_CLASSES_CONFIG = Clazz.GetField<string>("METRIC_REPORTER_CLASSES_CONFIG");

        public static readonly string CHECK_CRCS_CONFIG = Clazz.GetField<string>("CHECK_CRCS_CONFIG");

        public static readonly string KEY_DESERIALIZER_CLASS_CONFIG = Clazz.GetField<string>("KEY_DESERIALIZER_CLASS_CONFIG");

        public static readonly string VALUE_DESERIALIZER_CLASS_CONFIG = Clazz.GetField<string>("VALUE_DESERIALIZER_CLASS_CONFIG");

        public static readonly string SOCKET_CONNECTION_SETUP_TIMEOUT_MS_CONFIG = Clazz.GetField<string>("SOCKET_CONNECTION_SETUP_TIMEOUT_MS_CONFIG");

        public static readonly string SOCKET_CONNECTION_SETUP_TIMEOUT_MAX_MS_CONFIG = Clazz.GetField<string>("SOCKET_CONNECTION_SETUP_TIMEOUT_MAX_MS_CONFIG");

        public static readonly string CONNECTIONS_MAX_IDLE_MS_CONFIG = Clazz.GetField<string>("CONNECTIONS_MAX_IDLE_MS_CONFIG");

        public static readonly string REQUEST_TIMEOUT_MS_CONFIG = Clazz.GetField<string>("REQUEST_TIMEOUT_MS_CONFIG");

        public static readonly string DEFAULT_API_TIMEOUT_MS_CONFIG = Clazz.GetField<string>("DEFAULT_API_TIMEOUT_MS_CONFIG");

        public static readonly string INTERCEPTOR_CLASSES_CONFIG = Clazz.GetField<string>("INTERCEPTOR_CLASSES_CONFIG");

        public static readonly string EXCLUDE_INTERNAL_TOPICS_CONFIG = Clazz.GetField<string>("EXCLUDE_INTERNAL_TOPICS_CONFIG");

        public static readonly bool DEFAULT_EXCLUDE_INTERNAL_TOPICS = Clazz.GetField<bool>("DEFAULT_EXCLUDE_INTERNAL_TOPICS");

        public static readonly string ISOLATION_LEVEL_CONFIG = Clazz.GetField<string>("ISOLATION_LEVEL_CONFIG");
        public static readonly string DEFAULT_ISOLATION_LEVEL = Clazz.GetField<string>("DEFAULT_ISOLATION_LEVEL");

        public static readonly string ALLOW_AUTO_CREATE_TOPICS_CONFIG = Clazz.GetField<string>("ALLOW_AUTO_CREATE_TOPICS_CONFIG");

        public static readonly bool DEFAULT_ALLOW_AUTO_CREATE_TOPICS = Clazz.GetField<bool>("DEFAULT_ALLOW_AUTO_CREATE_TOPICS");

        public static readonly string SECURITY_PROVIDERS_CONFIG = Clazz.GetField<string>("SECURITY_PROVIDERS_CONFIG");
    }
}
