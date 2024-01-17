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
*  using connect-mirror-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Connect.Mirror
{
    #region MirrorSourceConfig
    public partial class MirrorSourceConfig
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorSourceConfig.html#org.apache.kafka.connect.mirror.MirrorSourceConfig(java.util.Map)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Map"/></param>
        public MirrorSourceConfig(Java.Util.Map<string, string> arg0)
            : base(arg0)
        {
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorSourceConfig.html#org.apache.kafka.connect.mirror.MirrorSourceConfig(org.apache.kafka.common.config.ConfigDef,java.util.Map)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Config.ConfigDef"/></param>
        /// <param name="arg1"><see cref="Java.Util.Map"/></param>
        public MirrorSourceConfig(Org.Apache.Kafka.Common.Config.ConfigDef arg0, Java.Util.Map<string, string> arg1)
            : base(arg0, arg1)
        {
        }

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorSourceConfig.html#ADD_SOURCE_ALIAS_TO_METRICS_DEFAULT"/>
        /// </summary>
        public static bool ADD_SOURCE_ALIAS_TO_METRICS_DEFAULT { get { return SGetField<bool>(LocalBridgeClazz, "ADD_SOURCE_ALIAS_TO_METRICS_DEFAULT"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorSourceConfig.html#REFRESH_TOPICS_ENABLED_DEFAULT"/>
        /// </summary>
        public static bool REFRESH_TOPICS_ENABLED_DEFAULT { get { return SGetField<bool>(LocalBridgeClazz, "REFRESH_TOPICS_ENABLED_DEFAULT"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorSourceConfig.html#SYNC_TOPIC_ACLS_ENABLED_DEFAULT"/>
        /// </summary>
        public static bool SYNC_TOPIC_ACLS_ENABLED_DEFAULT { get { return SGetField<bool>(LocalBridgeClazz, "SYNC_TOPIC_ACLS_ENABLED_DEFAULT"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorSourceConfig.html#SYNC_TOPIC_CONFIGS_ENABLED_DEFAULT"/>
        /// </summary>
        public static bool SYNC_TOPIC_CONFIGS_ENABLED_DEFAULT { get { return SGetField<bool>(LocalBridgeClazz, "SYNC_TOPIC_CONFIGS_ENABLED_DEFAULT"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorSourceConfig.html#REPLICATION_FACTOR_DEFAULT"/>
        /// </summary>
        public static int REPLICATION_FACTOR_DEFAULT { get { return SGetField<int>(LocalBridgeClazz, "REPLICATION_FACTOR_DEFAULT"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorSourceConfig.html#CONFIG_PROPERTY_FILTER_CLASS_DEFAULT"/>
        /// </summary>
        public static Java.Lang.Class CONFIG_PROPERTY_FILTER_CLASS_DEFAULT { get { return SGetField<Java.Lang.Class>(LocalBridgeClazz, "CONFIG_PROPERTY_FILTER_CLASS_DEFAULT"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorSourceConfig.html#ADD_SOURCE_ALIAS_TO_METRICS"/>
        /// </summary>
        public static string ADD_SOURCE_ALIAS_TO_METRICS { get { return SGetField<string>(LocalBridgeClazz, "ADD_SOURCE_ALIAS_TO_METRICS"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorSourceConfig.html#CONFIG_PROPERTIES_EXCLUDE"/>
        /// </summary>
        public static string CONFIG_PROPERTIES_EXCLUDE { get { return SGetField<string>(LocalBridgeClazz, "CONFIG_PROPERTIES_EXCLUDE"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorSourceConfig.html#CONFIG_PROPERTIES_EXCLUDE_ALIAS"/>
        /// </summary>
        public static string CONFIG_PROPERTIES_EXCLUDE_ALIAS { get { return SGetField<string>(LocalBridgeClazz, "CONFIG_PROPERTIES_EXCLUDE_ALIAS"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorSourceConfig.html#CONFIG_PROPERTIES_EXCLUDE_DEFAULT"/>
        /// </summary>
        public static string CONFIG_PROPERTIES_EXCLUDE_DEFAULT { get { return SGetField<string>(LocalBridgeClazz, "CONFIG_PROPERTIES_EXCLUDE_DEFAULT"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorSourceConfig.html#CONFIG_PROPERTY_FILTER_CLASS"/>
        /// </summary>
        public static string CONFIG_PROPERTY_FILTER_CLASS { get { return SGetField<string>(LocalBridgeClazz, "CONFIG_PROPERTY_FILTER_CLASS"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorSourceConfig.html#CONSUMER_POLL_TIMEOUT_MILLIS"/>
        /// </summary>
        public static string CONSUMER_POLL_TIMEOUT_MILLIS { get { return SGetField<string>(LocalBridgeClazz, "CONSUMER_POLL_TIMEOUT_MILLIS"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorSourceConfig.html#NEVER_USE_INCREMENTAL_ALTER_CONFIGS"/>
        /// </summary>
        public static string NEVER_USE_INCREMENTAL_ALTER_CONFIGS { get { return SGetField<string>(LocalBridgeClazz, "NEVER_USE_INCREMENTAL_ALTER_CONFIGS"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorSourceConfig.html#OFFSET_LAG_MAX"/>
        /// </summary>
        public static string OFFSET_LAG_MAX { get { return SGetField<string>(LocalBridgeClazz, "OFFSET_LAG_MAX"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorSourceConfig.html#OFFSET_SYNCS_SOURCE_ADMIN_ROLE"/>
        /// </summary>
        public static string OFFSET_SYNCS_SOURCE_ADMIN_ROLE { get { return SGetField<string>(LocalBridgeClazz, "OFFSET_SYNCS_SOURCE_ADMIN_ROLE"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorSourceConfig.html#OFFSET_SYNCS_SOURCE_PRODUCER_ROLE"/>
        /// </summary>
        public static string OFFSET_SYNCS_SOURCE_PRODUCER_ROLE { get { return SGetField<string>(LocalBridgeClazz, "OFFSET_SYNCS_SOURCE_PRODUCER_ROLE"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorSourceConfig.html#OFFSET_SYNCS_TARGET_ADMIN_ROLE"/>
        /// </summary>
        public static string OFFSET_SYNCS_TARGET_ADMIN_ROLE { get { return SGetField<string>(LocalBridgeClazz, "OFFSET_SYNCS_TARGET_ADMIN_ROLE"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorSourceConfig.html#OFFSET_SYNCS_TARGET_PRODUCER_ROLE"/>
        /// </summary>
        public static string OFFSET_SYNCS_TARGET_PRODUCER_ROLE { get { return SGetField<string>(LocalBridgeClazz, "OFFSET_SYNCS_TARGET_PRODUCER_ROLE"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorSourceConfig.html#OFFSET_SYNCS_TOPIC_REPLICATION_FACTOR"/>
        /// </summary>
        public static string OFFSET_SYNCS_TOPIC_REPLICATION_FACTOR { get { return SGetField<string>(LocalBridgeClazz, "OFFSET_SYNCS_TOPIC_REPLICATION_FACTOR"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorSourceConfig.html#OFFSET_SYNCS_TOPIC_REPLICATION_FACTOR_DOC"/>
        /// </summary>
        public static string OFFSET_SYNCS_TOPIC_REPLICATION_FACTOR_DOC { get { return SGetField<string>(LocalBridgeClazz, "OFFSET_SYNCS_TOPIC_REPLICATION_FACTOR_DOC"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorSourceConfig.html#REFRESH_TOPICS_ENABLED"/>
        /// </summary>
        public static string REFRESH_TOPICS_ENABLED { get { return SGetField<string>(LocalBridgeClazz, "REFRESH_TOPICS_ENABLED"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorSourceConfig.html#REFRESH_TOPICS_INTERVAL_SECONDS"/>
        /// </summary>
        public static string REFRESH_TOPICS_INTERVAL_SECONDS { get { return SGetField<string>(LocalBridgeClazz, "REFRESH_TOPICS_INTERVAL_SECONDS"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorSourceConfig.html#REPLICATION_FACTOR"/>
        /// </summary>
        public static string REPLICATION_FACTOR { get { return SGetField<string>(LocalBridgeClazz, "REPLICATION_FACTOR"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorSourceConfig.html#REQUEST_INCREMENTAL_ALTER_CONFIGS"/>
        /// </summary>
        public static string REQUEST_INCREMENTAL_ALTER_CONFIGS { get { return SGetField<string>(LocalBridgeClazz, "REQUEST_INCREMENTAL_ALTER_CONFIGS"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorSourceConfig.html#REQUIRE_INCREMENTAL_ALTER_CONFIGS"/>
        /// </summary>
        public static string REQUIRE_INCREMENTAL_ALTER_CONFIGS { get { return SGetField<string>(LocalBridgeClazz, "REQUIRE_INCREMENTAL_ALTER_CONFIGS"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorSourceConfig.html#SYNC_TOPIC_ACLS_ENABLED"/>
        /// </summary>
        public static string SYNC_TOPIC_ACLS_ENABLED { get { return SGetField<string>(LocalBridgeClazz, "SYNC_TOPIC_ACLS_ENABLED"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorSourceConfig.html#SYNC_TOPIC_ACLS_INTERVAL_SECONDS"/>
        /// </summary>
        public static string SYNC_TOPIC_ACLS_INTERVAL_SECONDS { get { return SGetField<string>(LocalBridgeClazz, "SYNC_TOPIC_ACLS_INTERVAL_SECONDS"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorSourceConfig.html#SYNC_TOPIC_CONFIGS_ENABLED"/>
        /// </summary>
        public static string SYNC_TOPIC_CONFIGS_ENABLED { get { return SGetField<string>(LocalBridgeClazz, "SYNC_TOPIC_CONFIGS_ENABLED"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorSourceConfig.html#SYNC_TOPIC_CONFIGS_INTERVAL_SECONDS"/>
        /// </summary>
        public static string SYNC_TOPIC_CONFIGS_INTERVAL_SECONDS { get { return SGetField<string>(LocalBridgeClazz, "SYNC_TOPIC_CONFIGS_INTERVAL_SECONDS"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorSourceConfig.html#TOPICS"/>
        /// </summary>
        public static string TOPICS { get { return SGetField<string>(LocalBridgeClazz, "TOPICS"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorSourceConfig.html#TOPICS_DEFAULT"/>
        /// </summary>
        public static string TOPICS_DEFAULT { get { return SGetField<string>(LocalBridgeClazz, "TOPICS_DEFAULT"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorSourceConfig.html#TOPICS_EXCLUDE"/>
        /// </summary>
        public static string TOPICS_EXCLUDE { get { return SGetField<string>(LocalBridgeClazz, "TOPICS_EXCLUDE"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorSourceConfig.html#TOPICS_EXCLUDE_ALIAS"/>
        /// </summary>
        public static string TOPICS_EXCLUDE_ALIAS { get { return SGetField<string>(LocalBridgeClazz, "TOPICS_EXCLUDE_ALIAS"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorSourceConfig.html#TOPICS_EXCLUDE_DEFAULT"/>
        /// </summary>
        public static string TOPICS_EXCLUDE_DEFAULT { get { return SGetField<string>(LocalBridgeClazz, "TOPICS_EXCLUDE_DEFAULT"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorSourceConfig.html#CONSUMER_POLL_TIMEOUT_MILLIS_DEFAULT"/>
        /// </summary>
        public static long CONSUMER_POLL_TIMEOUT_MILLIS_DEFAULT { get { return SGetField<long>(LocalBridgeClazz, "CONSUMER_POLL_TIMEOUT_MILLIS_DEFAULT"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorSourceConfig.html#OFFSET_LAG_MAX_DEFAULT"/>
        /// </summary>
        public static long OFFSET_LAG_MAX_DEFAULT { get { return SGetField<long>(LocalBridgeClazz, "OFFSET_LAG_MAX_DEFAULT"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorSourceConfig.html#REFRESH_TOPICS_INTERVAL_SECONDS_DEFAULT"/>
        /// </summary>
        public static long REFRESH_TOPICS_INTERVAL_SECONDS_DEFAULT { get { return SGetField<long>(LocalBridgeClazz, "REFRESH_TOPICS_INTERVAL_SECONDS_DEFAULT"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorSourceConfig.html#SYNC_TOPIC_ACLS_INTERVAL_SECONDS_DEFAULT"/>
        /// </summary>
        public static long SYNC_TOPIC_ACLS_INTERVAL_SECONDS_DEFAULT { get { return SGetField<long>(LocalBridgeClazz, "SYNC_TOPIC_ACLS_INTERVAL_SECONDS_DEFAULT"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorSourceConfig.html#SYNC_TOPIC_CONFIGS_INTERVAL_SECONDS_DEFAULT"/>
        /// </summary>
        public static long SYNC_TOPIC_CONFIGS_INTERVAL_SECONDS_DEFAULT { get { return SGetField<long>(LocalBridgeClazz, "SYNC_TOPIC_CONFIGS_INTERVAL_SECONDS_DEFAULT"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.1/org/apache/kafka/connect/mirror/MirrorSourceConfig.html#OFFSET_SYNCS_TOPIC_REPLICATION_FACTOR_DEFAULT"/>
        /// </summary>
        public static short OFFSET_SYNCS_TOPIC_REPLICATION_FACTOR_DEFAULT { get { return SGetField<short>(LocalBridgeClazz, "OFFSET_SYNCS_TOPIC_REPLICATION_FACTOR_DEFAULT"); } }

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