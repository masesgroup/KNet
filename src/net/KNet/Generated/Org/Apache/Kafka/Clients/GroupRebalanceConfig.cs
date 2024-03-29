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
*  using kafka-clients-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Clients
{
    #region GroupRebalanceConfig
    public partial class GroupRebalanceConfig
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/GroupRebalanceConfig.html#org.apache.kafka.clients.GroupRebalanceConfig(int,int,int,java.lang.String,java.util.Optional,long,boolean)"/>
        /// </summary>
        /// <param name="arg0"><see cref="int"/></param>
        /// <param name="arg1"><see cref="int"/></param>
        /// <param name="arg2"><see cref="int"/></param>
        /// <param name="arg3"><see cref="Java.Lang.String"/></param>
        /// <param name="arg4"><see cref="Java.Util.Optional"/></param>
        /// <param name="arg5"><see cref="long"/></param>
        /// <param name="arg6"><see cref="bool"/></param>
        public GroupRebalanceConfig(int arg0, int arg1, int arg2, Java.Lang.String arg3, Java.Util.Optional<Java.Lang.String> arg4, long arg5, bool arg6)
            : base(arg0, arg1, arg2, arg3, arg4, arg5, arg6)
        {
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/GroupRebalanceConfig.html#org.apache.kafka.clients.GroupRebalanceConfig(org.apache.kafka.common.config.AbstractConfig,org.apache.kafka.clients.GroupRebalanceConfig.ProtocolType)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Config.AbstractConfig"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Clients.GroupRebalanceConfig.ProtocolType"/></param>
        public GroupRebalanceConfig(Org.Apache.Kafka.Common.Config.AbstractConfig arg0, Org.Apache.Kafka.Clients.GroupRebalanceConfig.ProtocolType arg1)
            : base(arg0, arg1)
        {
        }

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/GroupRebalanceConfig.html#leaveGroupOnClose"/>
        /// </summary>
        public bool leaveGroupOnClose { get { if (!_leaveGroupOnCloseReady) { _leaveGroupOnCloseContent = IGetField<bool>("leaveGroupOnClose"); _leaveGroupOnCloseReady = true; } return _leaveGroupOnCloseContent; } }
        private bool _leaveGroupOnCloseContent = default;
        private bool _leaveGroupOnCloseReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/GroupRebalanceConfig.html#heartbeatIntervalMs"/>
        /// </summary>
        public int heartbeatIntervalMs { get { if (!_heartbeatIntervalMsReady) { _heartbeatIntervalMsContent = IGetField<int>("heartbeatIntervalMs"); _heartbeatIntervalMsReady = true; } return _heartbeatIntervalMsContent; } }
        private int _heartbeatIntervalMsContent = default;
        private bool _heartbeatIntervalMsReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/GroupRebalanceConfig.html#rebalanceTimeoutMs"/>
        /// </summary>
        public int rebalanceTimeoutMs { get { if (!_rebalanceTimeoutMsReady) { _rebalanceTimeoutMsContent = IGetField<int>("rebalanceTimeoutMs"); _rebalanceTimeoutMsReady = true; } return _rebalanceTimeoutMsContent; } }
        private int _rebalanceTimeoutMsContent = default;
        private bool _rebalanceTimeoutMsReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/GroupRebalanceConfig.html#sessionTimeoutMs"/>
        /// </summary>
        public int sessionTimeoutMs { get { if (!_sessionTimeoutMsReady) { _sessionTimeoutMsContent = IGetField<int>("sessionTimeoutMs"); _sessionTimeoutMsReady = true; } return _sessionTimeoutMsContent; } }
        private int _sessionTimeoutMsContent = default;
        private bool _sessionTimeoutMsReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/GroupRebalanceConfig.html#groupId"/>
        /// </summary>
        public Java.Lang.String groupId { get { if (!_groupIdReady) { _groupIdContent = IGetField<Java.Lang.String>("groupId"); _groupIdReady = true; } return _groupIdContent; } }
        private Java.Lang.String _groupIdContent = default;
        private bool _groupIdReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/GroupRebalanceConfig.html#groupInstanceId"/>
        /// </summary>
        public Java.Util.Optional groupInstanceId { get { if (!_groupInstanceIdReady) { _groupInstanceIdContent = IGetField<Java.Util.Optional>("groupInstanceId"); _groupInstanceIdReady = true; } return _groupInstanceIdContent; } }
        private Java.Util.Optional _groupInstanceIdContent = default;
        private bool _groupInstanceIdReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/GroupRebalanceConfig.html#retryBackoffMs"/>
        /// </summary>
        public long retryBackoffMs { get { if (!_retryBackoffMsReady) { _retryBackoffMsContent = IGetField<long>("retryBackoffMs"); _retryBackoffMsReady = true; } return _retryBackoffMsContent; } }
        private long _retryBackoffMsContent = default;
        private bool _retryBackoffMsReady = false; // this is used because in case of generics 

        #endregion

        #region Static methods

        #endregion

        #region Instance methods

        #endregion

        #region Nested classes
        #region ProtocolType
        public partial class ProtocolType
        {
            #region Constructors

            #endregion

            #region Class/Interface conversion operators

            #endregion

            #region Fields
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/GroupRebalanceConfig.ProtocolType.html#CONNECT"/>
            /// </summary>
            public static Org.Apache.Kafka.Clients.GroupRebalanceConfig.ProtocolType CONNECT { get { if (!_CONNECTReady) { _CONNECTContent = SGetField<Org.Apache.Kafka.Clients.GroupRebalanceConfig.ProtocolType>(LocalBridgeClazz, "CONNECT"); _CONNECTReady = true; } return _CONNECTContent; } }
            private static Org.Apache.Kafka.Clients.GroupRebalanceConfig.ProtocolType _CONNECTContent = default;
            private static bool _CONNECTReady = false; // this is used because in case of generics 
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/GroupRebalanceConfig.ProtocolType.html#CONSUMER"/>
            /// </summary>
            public static Org.Apache.Kafka.Clients.GroupRebalanceConfig.ProtocolType CONSUMER { get { if (!_CONSUMERReady) { _CONSUMERContent = SGetField<Org.Apache.Kafka.Clients.GroupRebalanceConfig.ProtocolType>(LocalBridgeClazz, "CONSUMER"); _CONSUMERReady = true; } return _CONSUMERContent; } }
            private static Org.Apache.Kafka.Clients.GroupRebalanceConfig.ProtocolType _CONSUMERContent = default;
            private static bool _CONSUMERReady = false; // this is used because in case of generics 

            #endregion

            #region Static methods
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/GroupRebalanceConfig.ProtocolType.html#valueOf-java.lang.String-"/>
            /// </summary>
            /// <param name="arg0"><see cref="Java.Lang.String"/></param>
            /// <returns><see cref="Org.Apache.Kafka.Clients.GroupRebalanceConfig.ProtocolType"/></returns>
            public static Org.Apache.Kafka.Clients.GroupRebalanceConfig.ProtocolType ValueOf(Java.Lang.String arg0)
            {
                return SExecuteWithSignature<Org.Apache.Kafka.Clients.GroupRebalanceConfig.ProtocolType>(LocalBridgeClazz, "valueOf", "(Ljava/lang/String;)Lorg/apache/kafka/clients/GroupRebalanceConfig$ProtocolType;", arg0);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/GroupRebalanceConfig.ProtocolType.html#values--"/>
            /// </summary>

            /// <returns><see cref="Org.Apache.Kafka.Clients.GroupRebalanceConfig.ProtocolType"/></returns>
            public static Org.Apache.Kafka.Clients.GroupRebalanceConfig.ProtocolType[] Values()
            {
                return SExecuteWithSignatureArray<Org.Apache.Kafka.Clients.GroupRebalanceConfig.ProtocolType>(LocalBridgeClazz, "values", "()[Lorg/apache/kafka/clients/GroupRebalanceConfig$ProtocolType;");
            }

            #endregion

            #region Instance methods

            #endregion

            #region Nested classes

            #endregion

            // TODO: complete the class
        }
        #endregion

    
        #endregion

        // TODO: complete the class
    }
    #endregion
}