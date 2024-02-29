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
*  using connect-mirror-3.6.1.jar as reference
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
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorConnectorConfig.html#INTERNAL_TOPIC_SEPARATOR_ENABLED_DEFAULT"/>
        /// </summary>
        public static Java.Lang.Boolean INTERNAL_TOPIC_SEPARATOR_ENABLED_DEFAULT { get { if (!_INTERNAL_TOPIC_SEPARATOR_ENABLED_DEFAULTReady) { _INTERNAL_TOPIC_SEPARATOR_ENABLED_DEFAULTContent = SGetField<Java.Lang.Boolean>(LocalBridgeClazz, "INTERNAL_TOPIC_SEPARATOR_ENABLED_DEFAULT"); _INTERNAL_TOPIC_SEPARATOR_ENABLED_DEFAULTReady = true; } return _INTERNAL_TOPIC_SEPARATOR_ENABLED_DEFAULTContent; } }
        private static Java.Lang.Boolean _INTERNAL_TOPIC_SEPARATOR_ENABLED_DEFAULTContent = default;
        private static bool _INTERNAL_TOPIC_SEPARATOR_ENABLED_DEFAULTReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorConnectorConfig.html#FORWARDING_ADMIN_CLASS_DEFAULT"/>
        /// </summary>
        public static Java.Lang.Class FORWARDING_ADMIN_CLASS_DEFAULT { get { if (!_FORWARDING_ADMIN_CLASS_DEFAULTReady) { _FORWARDING_ADMIN_CLASS_DEFAULTContent = SGetField<Java.Lang.Class>(LocalBridgeClazz, "FORWARDING_ADMIN_CLASS_DEFAULT"); _FORWARDING_ADMIN_CLASS_DEFAULTReady = true; } return _FORWARDING_ADMIN_CLASS_DEFAULTContent; } }
        private static Java.Lang.Class _FORWARDING_ADMIN_CLASS_DEFAULTContent = default;
        private static bool _FORWARDING_ADMIN_CLASS_DEFAULTReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorConnectorConfig.html#REPLICATION_POLICY_CLASS_DEFAULT"/>
        /// </summary>
        public static Java.Lang.Class REPLICATION_POLICY_CLASS_DEFAULT { get { if (!_REPLICATION_POLICY_CLASS_DEFAULTReady) { _REPLICATION_POLICY_CLASS_DEFAULTContent = SGetField<Java.Lang.Class>(LocalBridgeClazz, "REPLICATION_POLICY_CLASS_DEFAULT"); _REPLICATION_POLICY_CLASS_DEFAULTReady = true; } return _REPLICATION_POLICY_CLASS_DEFAULTContent; } }
        private static Java.Lang.Class _REPLICATION_POLICY_CLASS_DEFAULTContent = default;
        private static bool _REPLICATION_POLICY_CLASS_DEFAULTReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorConnectorConfig.html#TOPIC_FILTER_CLASS_DEFAULT"/>
        /// </summary>
        public static Java.Lang.Class TOPIC_FILTER_CLASS_DEFAULT { get { if (!_TOPIC_FILTER_CLASS_DEFAULTReady) { _TOPIC_FILTER_CLASS_DEFAULTContent = SGetField<Java.Lang.Class>(LocalBridgeClazz, "TOPIC_FILTER_CLASS_DEFAULT"); _TOPIC_FILTER_CLASS_DEFAULTReady = true; } return _TOPIC_FILTER_CLASS_DEFAULTContent; } }
        private static Java.Lang.Class _TOPIC_FILTER_CLASS_DEFAULTContent = default;
        private static bool _TOPIC_FILTER_CLASS_DEFAULTReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorConnectorConfig.html#ADMIN_TASK_TIMEOUT_MILLIS"/>
        /// </summary>
        public static Java.Lang.String ADMIN_TASK_TIMEOUT_MILLIS { get { if (!_ADMIN_TASK_TIMEOUT_MILLISReady) { _ADMIN_TASK_TIMEOUT_MILLISContent = SGetField<Java.Lang.String>(LocalBridgeClazz, "ADMIN_TASK_TIMEOUT_MILLIS"); _ADMIN_TASK_TIMEOUT_MILLISReady = true; } return _ADMIN_TASK_TIMEOUT_MILLISContent; } }
        private static Java.Lang.String _ADMIN_TASK_TIMEOUT_MILLISContent = default;
        private static bool _ADMIN_TASK_TIMEOUT_MILLISReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorConnectorConfig.html#FORWARDING_ADMIN_CLASS"/>
        /// </summary>
        public static Java.Lang.String FORWARDING_ADMIN_CLASS { get { if (!_FORWARDING_ADMIN_CLASSReady) { _FORWARDING_ADMIN_CLASSContent = SGetField<Java.Lang.String>(LocalBridgeClazz, "FORWARDING_ADMIN_CLASS"); _FORWARDING_ADMIN_CLASSReady = true; } return _FORWARDING_ADMIN_CLASSContent; } }
        private static Java.Lang.String _FORWARDING_ADMIN_CLASSContent = default;
        private static bool _FORWARDING_ADMIN_CLASSReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorConnectorConfig.html#OFFSET_SYNCS_TOPIC_LOCATION"/>
        /// </summary>
        public static Java.Lang.String OFFSET_SYNCS_TOPIC_LOCATION { get { if (!_OFFSET_SYNCS_TOPIC_LOCATIONReady) { _OFFSET_SYNCS_TOPIC_LOCATIONContent = SGetField<Java.Lang.String>(LocalBridgeClazz, "OFFSET_SYNCS_TOPIC_LOCATION"); _OFFSET_SYNCS_TOPIC_LOCATIONReady = true; } return _OFFSET_SYNCS_TOPIC_LOCATIONContent; } }
        private static Java.Lang.String _OFFSET_SYNCS_TOPIC_LOCATIONContent = default;
        private static bool _OFFSET_SYNCS_TOPIC_LOCATIONReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorConnectorConfig.html#OFFSET_SYNCS_TOPIC_LOCATION_DEFAULT"/>
        /// </summary>
        public static Java.Lang.String OFFSET_SYNCS_TOPIC_LOCATION_DEFAULT { get { if (!_OFFSET_SYNCS_TOPIC_LOCATION_DEFAULTReady) { _OFFSET_SYNCS_TOPIC_LOCATION_DEFAULTContent = SGetField<Java.Lang.String>(LocalBridgeClazz, "OFFSET_SYNCS_TOPIC_LOCATION_DEFAULT"); _OFFSET_SYNCS_TOPIC_LOCATION_DEFAULTReady = true; } return _OFFSET_SYNCS_TOPIC_LOCATION_DEFAULTContent; } }
        private static Java.Lang.String _OFFSET_SYNCS_TOPIC_LOCATION_DEFAULTContent = default;
        private static bool _OFFSET_SYNCS_TOPIC_LOCATION_DEFAULTReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorConnectorConfig.html#OFFSET_SYNCS_TOPIC_LOCATION_DOC"/>
        /// </summary>
        public static Java.Lang.String OFFSET_SYNCS_TOPIC_LOCATION_DOC { get { if (!_OFFSET_SYNCS_TOPIC_LOCATION_DOCReady) { _OFFSET_SYNCS_TOPIC_LOCATION_DOCContent = SGetField<Java.Lang.String>(LocalBridgeClazz, "OFFSET_SYNCS_TOPIC_LOCATION_DOC"); _OFFSET_SYNCS_TOPIC_LOCATION_DOCReady = true; } return _OFFSET_SYNCS_TOPIC_LOCATION_DOCContent; } }
        private static Java.Lang.String _OFFSET_SYNCS_TOPIC_LOCATION_DOCContent = default;
        private static bool _OFFSET_SYNCS_TOPIC_LOCATION_DOCReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorConnectorConfig.html#REPLICATION_POLICY_CLASS"/>
        /// </summary>
        public static Java.Lang.String REPLICATION_POLICY_CLASS { get { if (!_REPLICATION_POLICY_CLASSReady) { _REPLICATION_POLICY_CLASSContent = SGetField<Java.Lang.String>(LocalBridgeClazz, "REPLICATION_POLICY_CLASS"); _REPLICATION_POLICY_CLASSReady = true; } return _REPLICATION_POLICY_CLASSContent; } }
        private static Java.Lang.String _REPLICATION_POLICY_CLASSContent = default;
        private static bool _REPLICATION_POLICY_CLASSReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorConnectorConfig.html#REPLICATION_POLICY_SEPARATOR"/>
        /// </summary>
        public static Java.Lang.String REPLICATION_POLICY_SEPARATOR { get { if (!_REPLICATION_POLICY_SEPARATORReady) { _REPLICATION_POLICY_SEPARATORContent = SGetField<Java.Lang.String>(LocalBridgeClazz, "REPLICATION_POLICY_SEPARATOR"); _REPLICATION_POLICY_SEPARATORReady = true; } return _REPLICATION_POLICY_SEPARATORContent; } }
        private static Java.Lang.String _REPLICATION_POLICY_SEPARATORContent = default;
        private static bool _REPLICATION_POLICY_SEPARATORReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorConnectorConfig.html#REPLICATION_POLICY_SEPARATOR_DEFAULT"/>
        /// </summary>
        public static Java.Lang.String REPLICATION_POLICY_SEPARATOR_DEFAULT { get { if (!_REPLICATION_POLICY_SEPARATOR_DEFAULTReady) { _REPLICATION_POLICY_SEPARATOR_DEFAULTContent = SGetField<Java.Lang.String>(LocalBridgeClazz, "REPLICATION_POLICY_SEPARATOR_DEFAULT"); _REPLICATION_POLICY_SEPARATOR_DEFAULTReady = true; } return _REPLICATION_POLICY_SEPARATOR_DEFAULTContent; } }
        private static Java.Lang.String _REPLICATION_POLICY_SEPARATOR_DEFAULTContent = default;
        private static bool _REPLICATION_POLICY_SEPARATOR_DEFAULTReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorConnectorConfig.html#SOURCE_CLUSTER_ALIAS"/>
        /// </summary>
        public static Java.Lang.String SOURCE_CLUSTER_ALIAS { get { if (!_SOURCE_CLUSTER_ALIASReady) { _SOURCE_CLUSTER_ALIASContent = SGetField<Java.Lang.String>(LocalBridgeClazz, "SOURCE_CLUSTER_ALIAS"); _SOURCE_CLUSTER_ALIASReady = true; } return _SOURCE_CLUSTER_ALIASContent; } }
        private static Java.Lang.String _SOURCE_CLUSTER_ALIASContent = default;
        private static bool _SOURCE_CLUSTER_ALIASReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorConnectorConfig.html#SOURCE_CLUSTER_ALIAS_DEFAULT"/>
        /// </summary>
        public static Java.Lang.String SOURCE_CLUSTER_ALIAS_DEFAULT { get { if (!_SOURCE_CLUSTER_ALIAS_DEFAULTReady) { _SOURCE_CLUSTER_ALIAS_DEFAULTContent = SGetField<Java.Lang.String>(LocalBridgeClazz, "SOURCE_CLUSTER_ALIAS_DEFAULT"); _SOURCE_CLUSTER_ALIAS_DEFAULTReady = true; } return _SOURCE_CLUSTER_ALIAS_DEFAULTContent; } }
        private static Java.Lang.String _SOURCE_CLUSTER_ALIAS_DEFAULTContent = default;
        private static bool _SOURCE_CLUSTER_ALIAS_DEFAULTReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorConnectorConfig.html#TARGET_CLUSTER_ALIAS"/>
        /// </summary>
        public static Java.Lang.String TARGET_CLUSTER_ALIAS { get { if (!_TARGET_CLUSTER_ALIASReady) { _TARGET_CLUSTER_ALIASContent = SGetField<Java.Lang.String>(LocalBridgeClazz, "TARGET_CLUSTER_ALIAS"); _TARGET_CLUSTER_ALIASReady = true; } return _TARGET_CLUSTER_ALIASContent; } }
        private static Java.Lang.String _TARGET_CLUSTER_ALIASContent = default;
        private static bool _TARGET_CLUSTER_ALIASReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorConnectorConfig.html#TARGET_CLUSTER_ALIAS_DEFAULT"/>
        /// </summary>
        public static Java.Lang.String TARGET_CLUSTER_ALIAS_DEFAULT { get { if (!_TARGET_CLUSTER_ALIAS_DEFAULTReady) { _TARGET_CLUSTER_ALIAS_DEFAULTContent = SGetField<Java.Lang.String>(LocalBridgeClazz, "TARGET_CLUSTER_ALIAS_DEFAULT"); _TARGET_CLUSTER_ALIAS_DEFAULTReady = true; } return _TARGET_CLUSTER_ALIAS_DEFAULTContent; } }
        private static Java.Lang.String _TARGET_CLUSTER_ALIAS_DEFAULTContent = default;
        private static bool _TARGET_CLUSTER_ALIAS_DEFAULTReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorConnectorConfig.html#TASK_INDEX"/>
        /// </summary>
        public static Java.Lang.String TASK_INDEX { get { if (!_TASK_INDEXReady) { _TASK_INDEXContent = SGetField<Java.Lang.String>(LocalBridgeClazz, "TASK_INDEX"); _TASK_INDEXReady = true; } return _TASK_INDEXContent; } }
        private static Java.Lang.String _TASK_INDEXContent = default;
        private static bool _TASK_INDEXReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorConnectorConfig.html#TOPIC_FILTER_CLASS"/>
        /// </summary>
        public static Java.Lang.String TOPIC_FILTER_CLASS { get { if (!_TOPIC_FILTER_CLASSReady) { _TOPIC_FILTER_CLASSContent = SGetField<Java.Lang.String>(LocalBridgeClazz, "TOPIC_FILTER_CLASS"); _TOPIC_FILTER_CLASSReady = true; } return _TOPIC_FILTER_CLASSContent; } }
        private static Java.Lang.String _TOPIC_FILTER_CLASSContent = default;
        private static bool _TOPIC_FILTER_CLASSReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorConnectorConfig.html#TOPIC_FILTER_CLASS_DOC"/>
        /// </summary>
        public static Java.Lang.String TOPIC_FILTER_CLASS_DOC { get { if (!_TOPIC_FILTER_CLASS_DOCReady) { _TOPIC_FILTER_CLASS_DOCContent = SGetField<Java.Lang.String>(LocalBridgeClazz, "TOPIC_FILTER_CLASS_DOC"); _TOPIC_FILTER_CLASS_DOCReady = true; } return _TOPIC_FILTER_CLASS_DOCContent; } }
        private static Java.Lang.String _TOPIC_FILTER_CLASS_DOCContent = default;
        private static bool _TOPIC_FILTER_CLASS_DOCReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorConnectorConfig.html#ADMIN_TASK_TIMEOUT_MILLIS_DEFAULT"/>
        /// </summary>
        public static long ADMIN_TASK_TIMEOUT_MILLIS_DEFAULT { get { if (!_ADMIN_TASK_TIMEOUT_MILLIS_DEFAULTReady) { _ADMIN_TASK_TIMEOUT_MILLIS_DEFAULTContent = SGetField<long>(LocalBridgeClazz, "ADMIN_TASK_TIMEOUT_MILLIS_DEFAULT"); _ADMIN_TASK_TIMEOUT_MILLIS_DEFAULTReady = true; } return _ADMIN_TASK_TIMEOUT_MILLIS_DEFAULTContent; } }
        private static long _ADMIN_TASK_TIMEOUT_MILLIS_DEFAULTContent = default;
        private static bool _ADMIN_TASK_TIMEOUT_MILLIS_DEFAULTReady = false; // this is used because in case of generics 

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorConnectorConfig.html#main-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        public static void Main(Java.Lang.String[] arg0)
        {
            SExecuteWithSignature(LocalBridgeClazz, "main", "([Ljava/lang/String;)V", new object[] { arg0 });
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