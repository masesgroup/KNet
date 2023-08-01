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
*  using kafka-clients-3.5.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Clients.Admin
{
    #region AdminClientConfig
    public partial class AdminClientConfig
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/clients/admin/AdminClientConfig.html#org.apache.kafka.clients.admin.AdminClientConfig(java.util.Map)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Map"/></param>
        public AdminClientConfig(Java.Util.Map<object, object> arg0)
            : base(arg0)
        {
        }

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/clients/admin/AdminClientConfig.html#AUTO_INCLUDE_JMX_REPORTER_DOC"/>
        /// </summary>
        public static string AUTO_INCLUDE_JMX_REPORTER_DOC { get { return SGetField<string>(LocalBridgeClazz, "AUTO_INCLUDE_JMX_REPORTER_DOC"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/clients/admin/AdminClientConfig.html#BOOTSTRAP_SERVERS_CONFIG"/>
        /// </summary>
        public static string BOOTSTRAP_SERVERS_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "BOOTSTRAP_SERVERS_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/clients/admin/AdminClientConfig.html#CLIENT_DNS_LOOKUP_CONFIG"/>
        /// </summary>
        public static string CLIENT_DNS_LOOKUP_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "CLIENT_DNS_LOOKUP_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/clients/admin/AdminClientConfig.html#CLIENT_ID_CONFIG"/>
        /// </summary>
        public static string CLIENT_ID_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "CLIENT_ID_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/clients/admin/AdminClientConfig.html#CONNECTIONS_MAX_IDLE_MS_CONFIG"/>
        /// </summary>
        public static string CONNECTIONS_MAX_IDLE_MS_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "CONNECTIONS_MAX_IDLE_MS_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/clients/admin/AdminClientConfig.html#DEFAULT_API_TIMEOUT_MS_CONFIG"/>
        /// </summary>
        public static string DEFAULT_API_TIMEOUT_MS_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "DEFAULT_API_TIMEOUT_MS_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/clients/admin/AdminClientConfig.html#DEFAULT_SECURITY_PROTOCOL"/>
        /// </summary>
        public static string DEFAULT_SECURITY_PROTOCOL { get { return SGetField<string>(LocalBridgeClazz, "DEFAULT_SECURITY_PROTOCOL"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/clients/admin/AdminClientConfig.html#METADATA_MAX_AGE_CONFIG"/>
        /// </summary>
        public static string METADATA_MAX_AGE_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "METADATA_MAX_AGE_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/clients/admin/AdminClientConfig.html#METRIC_REPORTER_CLASSES_CONFIG"/>
        /// </summary>
        public static string METRIC_REPORTER_CLASSES_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "METRIC_REPORTER_CLASSES_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/clients/admin/AdminClientConfig.html#METRICS_NUM_SAMPLES_CONFIG"/>
        /// </summary>
        public static string METRICS_NUM_SAMPLES_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "METRICS_NUM_SAMPLES_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/clients/admin/AdminClientConfig.html#METRICS_RECORDING_LEVEL_CONFIG"/>
        /// </summary>
        public static string METRICS_RECORDING_LEVEL_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "METRICS_RECORDING_LEVEL_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/clients/admin/AdminClientConfig.html#METRICS_SAMPLE_WINDOW_MS_CONFIG"/>
        /// </summary>
        public static string METRICS_SAMPLE_WINDOW_MS_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "METRICS_SAMPLE_WINDOW_MS_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/clients/admin/AdminClientConfig.html#RECEIVE_BUFFER_CONFIG"/>
        /// </summary>
        public static string RECEIVE_BUFFER_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "RECEIVE_BUFFER_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/clients/admin/AdminClientConfig.html#RECONNECT_BACKOFF_MAX_MS_CONFIG"/>
        /// </summary>
        public static string RECONNECT_BACKOFF_MAX_MS_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "RECONNECT_BACKOFF_MAX_MS_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/clients/admin/AdminClientConfig.html#RECONNECT_BACKOFF_MS_CONFIG"/>
        /// </summary>
        public static string RECONNECT_BACKOFF_MS_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "RECONNECT_BACKOFF_MS_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/clients/admin/AdminClientConfig.html#REQUEST_TIMEOUT_MS_CONFIG"/>
        /// </summary>
        public static string REQUEST_TIMEOUT_MS_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "REQUEST_TIMEOUT_MS_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/clients/admin/AdminClientConfig.html#RETRIES_CONFIG"/>
        /// </summary>
        public static string RETRIES_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "RETRIES_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/clients/admin/AdminClientConfig.html#RETRY_BACKOFF_MS_CONFIG"/>
        /// </summary>
        public static string RETRY_BACKOFF_MS_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "RETRY_BACKOFF_MS_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/clients/admin/AdminClientConfig.html#SECURITY_PROTOCOL_CONFIG"/>
        /// </summary>
        public static string SECURITY_PROTOCOL_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "SECURITY_PROTOCOL_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/clients/admin/AdminClientConfig.html#SECURITY_PROVIDERS_CONFIG"/>
        /// </summary>
        public static string SECURITY_PROVIDERS_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "SECURITY_PROVIDERS_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/clients/admin/AdminClientConfig.html#SEND_BUFFER_CONFIG"/>
        /// </summary>
        public static string SEND_BUFFER_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "SEND_BUFFER_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/clients/admin/AdminClientConfig.html#SOCKET_CONNECTION_SETUP_TIMEOUT_MAX_MS_CONFIG"/>
        /// </summary>
        public static string SOCKET_CONNECTION_SETUP_TIMEOUT_MAX_MS_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "SOCKET_CONNECTION_SETUP_TIMEOUT_MAX_MS_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/clients/admin/AdminClientConfig.html#SOCKET_CONNECTION_SETUP_TIMEOUT_MS_CONFIG"/>
        /// </summary>
        public static string SOCKET_CONNECTION_SETUP_TIMEOUT_MS_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "SOCKET_CONNECTION_SETUP_TIMEOUT_MS_CONFIG"); } }

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/clients/admin/AdminClientConfig.html#configNames--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Set"/></returns>
        public static Java.Util.Set<string> ConfigNames()
        {
            return SExecute<Java.Util.Set<string>>(LocalBridgeClazz, "configNames");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/clients/admin/AdminClientConfig.html#configDef--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Config.ConfigDef"/></returns>
        public static Org.Apache.Kafka.Common.Config.ConfigDef ConfigDef()
        {
            return SExecute<Org.Apache.Kafka.Common.Config.ConfigDef>(LocalBridgeClazz, "configDef");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/clients/admin/AdminClientConfig.html#main-java.lang.String[]-"/>
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