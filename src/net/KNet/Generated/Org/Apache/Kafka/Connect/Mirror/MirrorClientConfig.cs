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
*  using connect-mirror-client-3.5.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Connect.Mirror
{
    #region MirrorClientConfig
    public partial class MirrorClientConfig
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror-client/3.5.1/org/apache/kafka/connect/mirror/MirrorClientConfig.html#FORWARDING_ADMIN_CLASS_DEFAULT"/>
        /// </summary>
        public static Java.Lang.Class FORWARDING_ADMIN_CLASS_DEFAULT { get { return SGetField<Java.Lang.Class>(LocalBridgeClazz, "FORWARDING_ADMIN_CLASS_DEFAULT"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror-client/3.5.1/org/apache/kafka/connect/mirror/MirrorClientConfig.html#REPLICATION_POLICY_CLASS_DEFAULT"/>
        /// </summary>
        public static Java.Lang.Class REPLICATION_POLICY_CLASS_DEFAULT { get { return SGetField<Java.Lang.Class>(LocalBridgeClazz, "REPLICATION_POLICY_CLASS_DEFAULT"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror-client/3.5.1/org/apache/kafka/connect/mirror/MirrorClientConfig.html#ADMIN_CLIENT_PREFIX"/>
        /// </summary>
        public static string ADMIN_CLIENT_PREFIX { get { return SGetField<string>(LocalBridgeClazz, "ADMIN_CLIENT_PREFIX"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror-client/3.5.1/org/apache/kafka/connect/mirror/MirrorClientConfig.html#CONSUMER_CLIENT_PREFIX"/>
        /// </summary>
        public static string CONSUMER_CLIENT_PREFIX { get { return SGetField<string>(LocalBridgeClazz, "CONSUMER_CLIENT_PREFIX"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror-client/3.5.1/org/apache/kafka/connect/mirror/MirrorClientConfig.html#FORWARDING_ADMIN_CLASS"/>
        /// </summary>
        public static string FORWARDING_ADMIN_CLASS { get { return SGetField<string>(LocalBridgeClazz, "FORWARDING_ADMIN_CLASS"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror-client/3.5.1/org/apache/kafka/connect/mirror/MirrorClientConfig.html#FORWARDING_ADMIN_CLASS_DOC"/>
        /// </summary>
        public static string FORWARDING_ADMIN_CLASS_DOC { get { return SGetField<string>(LocalBridgeClazz, "FORWARDING_ADMIN_CLASS_DOC"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror-client/3.5.1/org/apache/kafka/connect/mirror/MirrorClientConfig.html#PRODUCER_CLIENT_PREFIX"/>
        /// </summary>
        public static string PRODUCER_CLIENT_PREFIX { get { return SGetField<string>(LocalBridgeClazz, "PRODUCER_CLIENT_PREFIX"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror-client/3.5.1/org/apache/kafka/connect/mirror/MirrorClientConfig.html#REPLICATION_POLICY_CLASS"/>
        /// </summary>
        public static string REPLICATION_POLICY_CLASS { get { return SGetField<string>(LocalBridgeClazz, "REPLICATION_POLICY_CLASS"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror-client/3.5.1/org/apache/kafka/connect/mirror/MirrorClientConfig.html#REPLICATION_POLICY_SEPARATOR"/>
        /// </summary>
        public static string REPLICATION_POLICY_SEPARATOR { get { return SGetField<string>(LocalBridgeClazz, "REPLICATION_POLICY_SEPARATOR"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror-client/3.5.1/org/apache/kafka/connect/mirror/MirrorClientConfig.html#REPLICATION_POLICY_SEPARATOR_DEFAULT"/>
        /// </summary>
        public static string REPLICATION_POLICY_SEPARATOR_DEFAULT { get { return SGetField<string>(LocalBridgeClazz, "REPLICATION_POLICY_SEPARATOR_DEFAULT"); } }

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror-client/3.5.1/org/apache/kafka/connect/mirror/MirrorClientConfig.html#adminConfig--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Map"/></returns>
        public Java.Util.Map<string, object> AdminConfig()
        {
            return IExecute<Java.Util.Map<string, object>>("adminConfig");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror-client/3.5.1/org/apache/kafka/connect/mirror/MirrorClientConfig.html#consumerConfig--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Map"/></returns>
        public Java.Util.Map<string, object> ConsumerConfig()
        {
            return IExecute<Java.Util.Map<string, object>>("consumerConfig");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror-client/3.5.1/org/apache/kafka/connect/mirror/MirrorClientConfig.html#producerConfig--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Map"/></returns>
        public Java.Util.Map<string, object> ProducerConfig()
        {
            return IExecute<Java.Util.Map<string, object>>("producerConfig");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror-client/3.5.1/org/apache/kafka/connect/mirror/MirrorClientConfig.html#replicationPolicy--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Connect.Mirror.ReplicationPolicy"/></returns>
        public Org.Apache.Kafka.Connect.Mirror.ReplicationPolicy ReplicationPolicy()
        {
            return IExecute<Org.Apache.Kafka.Connect.Mirror.ReplicationPolicy>("replicationPolicy");
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}