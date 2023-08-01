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
*  using connect-mirror-3.5.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Connect.Mirror
{
    #region MirrorConnectorConfig
    public partial class MirrorConnectorConfig
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.5.1/org/apache/kafka/connect/mirror/MirrorConnectorConfig.html#FORWARDING_ADMIN_CLASS_DEFAULT"/>
        /// </summary>
        public static Java.Lang.Class FORWARDING_ADMIN_CLASS_DEFAULT { get { return SGetField<Java.Lang.Class>(LocalBridgeClazz, "FORWARDING_ADMIN_CLASS_DEFAULT"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.5.1/org/apache/kafka/connect/mirror/MirrorConnectorConfig.html#REPLICATION_POLICY_CLASS_DEFAULT"/>
        /// </summary>
        public static Java.Lang.Class REPLICATION_POLICY_CLASS_DEFAULT { get { return SGetField<Java.Lang.Class>(LocalBridgeClazz, "REPLICATION_POLICY_CLASS_DEFAULT"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.5.1/org/apache/kafka/connect/mirror/MirrorConnectorConfig.html#TOPIC_FILTER_CLASS_DEFAULT"/>
        /// </summary>
        public static Java.Lang.Class TOPIC_FILTER_CLASS_DEFAULT { get { return SGetField<Java.Lang.Class>(LocalBridgeClazz, "TOPIC_FILTER_CLASS_DEFAULT"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.5.1/org/apache/kafka/connect/mirror/MirrorConnectorConfig.html#ADMIN_TASK_TIMEOUT_MILLIS"/>
        /// </summary>
        public static string ADMIN_TASK_TIMEOUT_MILLIS { get { return SGetField<string>(LocalBridgeClazz, "ADMIN_TASK_TIMEOUT_MILLIS"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.5.1/org/apache/kafka/connect/mirror/MirrorConnectorConfig.html#FORWARDING_ADMIN_CLASS"/>
        /// </summary>
        public static string FORWARDING_ADMIN_CLASS { get { return SGetField<string>(LocalBridgeClazz, "FORWARDING_ADMIN_CLASS"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.5.1/org/apache/kafka/connect/mirror/MirrorConnectorConfig.html#OFFSET_SYNCS_TOPIC_LOCATION"/>
        /// </summary>
        public static string OFFSET_SYNCS_TOPIC_LOCATION { get { return SGetField<string>(LocalBridgeClazz, "OFFSET_SYNCS_TOPIC_LOCATION"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.5.1/org/apache/kafka/connect/mirror/MirrorConnectorConfig.html#OFFSET_SYNCS_TOPIC_LOCATION_DEFAULT"/>
        /// </summary>
        public static string OFFSET_SYNCS_TOPIC_LOCATION_DEFAULT { get { return SGetField<string>(LocalBridgeClazz, "OFFSET_SYNCS_TOPIC_LOCATION_DEFAULT"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.5.1/org/apache/kafka/connect/mirror/MirrorConnectorConfig.html#OFFSET_SYNCS_TOPIC_LOCATION_DOC"/>
        /// </summary>
        public static string OFFSET_SYNCS_TOPIC_LOCATION_DOC { get { return SGetField<string>(LocalBridgeClazz, "OFFSET_SYNCS_TOPIC_LOCATION_DOC"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.5.1/org/apache/kafka/connect/mirror/MirrorConnectorConfig.html#REPLICATION_POLICY_CLASS"/>
        /// </summary>
        public static string REPLICATION_POLICY_CLASS { get { return SGetField<string>(LocalBridgeClazz, "REPLICATION_POLICY_CLASS"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.5.1/org/apache/kafka/connect/mirror/MirrorConnectorConfig.html#REPLICATION_POLICY_SEPARATOR"/>
        /// </summary>
        public static string REPLICATION_POLICY_SEPARATOR { get { return SGetField<string>(LocalBridgeClazz, "REPLICATION_POLICY_SEPARATOR"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.5.1/org/apache/kafka/connect/mirror/MirrorConnectorConfig.html#REPLICATION_POLICY_SEPARATOR_DEFAULT"/>
        /// </summary>
        public static string REPLICATION_POLICY_SEPARATOR_DEFAULT { get { return SGetField<string>(LocalBridgeClazz, "REPLICATION_POLICY_SEPARATOR_DEFAULT"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.5.1/org/apache/kafka/connect/mirror/MirrorConnectorConfig.html#SOURCE_CLUSTER_ALIAS"/>
        /// </summary>
        public static string SOURCE_CLUSTER_ALIAS { get { return SGetField<string>(LocalBridgeClazz, "SOURCE_CLUSTER_ALIAS"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.5.1/org/apache/kafka/connect/mirror/MirrorConnectorConfig.html#SOURCE_CLUSTER_ALIAS_DEFAULT"/>
        /// </summary>
        public static string SOURCE_CLUSTER_ALIAS_DEFAULT { get { return SGetField<string>(LocalBridgeClazz, "SOURCE_CLUSTER_ALIAS_DEFAULT"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.5.1/org/apache/kafka/connect/mirror/MirrorConnectorConfig.html#TARGET_CLUSTER_ALIAS"/>
        /// </summary>
        public static string TARGET_CLUSTER_ALIAS { get { return SGetField<string>(LocalBridgeClazz, "TARGET_CLUSTER_ALIAS"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.5.1/org/apache/kafka/connect/mirror/MirrorConnectorConfig.html#TARGET_CLUSTER_ALIAS_DEFAULT"/>
        /// </summary>
        public static string TARGET_CLUSTER_ALIAS_DEFAULT { get { return SGetField<string>(LocalBridgeClazz, "TARGET_CLUSTER_ALIAS_DEFAULT"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.5.1/org/apache/kafka/connect/mirror/MirrorConnectorConfig.html#TASK_INDEX"/>
        /// </summary>
        public static string TASK_INDEX { get { return SGetField<string>(LocalBridgeClazz, "TASK_INDEX"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.5.1/org/apache/kafka/connect/mirror/MirrorConnectorConfig.html#TOPIC_FILTER_CLASS"/>
        /// </summary>
        public static string TOPIC_FILTER_CLASS { get { return SGetField<string>(LocalBridgeClazz, "TOPIC_FILTER_CLASS"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.5.1/org/apache/kafka/connect/mirror/MirrorConnectorConfig.html#TOPIC_FILTER_CLASS_DOC"/>
        /// </summary>
        public static string TOPIC_FILTER_CLASS_DOC { get { return SGetField<string>(LocalBridgeClazz, "TOPIC_FILTER_CLASS_DOC"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.5.1/org/apache/kafka/connect/mirror/MirrorConnectorConfig.html#ADMIN_TASK_TIMEOUT_MILLIS_DEFAULT"/>
        /// </summary>
        public static long ADMIN_TASK_TIMEOUT_MILLIS_DEFAULT { get { return SGetField<long>(LocalBridgeClazz, "ADMIN_TASK_TIMEOUT_MILLIS_DEFAULT"); } }

        #endregion

        #region Static methods

        #endregion

        #region Instance methods

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}