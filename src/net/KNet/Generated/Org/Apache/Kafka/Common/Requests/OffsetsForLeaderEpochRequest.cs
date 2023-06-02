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
*  This file is generated by MASES.JNetReflector (ver. 1.5.5.0)
*  using kafka-clients-3.4.0.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Common.Requests
{
    #region OffsetsForLeaderEpochRequest
    public partial class OffsetsForLeaderEpochRequest
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/OffsetsForLeaderEpochRequest.html#%3Cinit%3E(org.apache.kafka.common.message.OffsetForLeaderEpochRequestData,short)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Message.OffsetForLeaderEpochRequestData"/></param>
        /// <param name="arg1"><see cref="short"/></param>
        public OffsetsForLeaderEpochRequest(Org.Apache.Kafka.Common.Message.OffsetForLeaderEpochRequestData arg0, short arg1)
            : base(arg0, arg1)
        {
        }

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/OffsetsForLeaderEpochRequest.html#CONSUMER_REPLICA_ID"/>
        /// </summary>
        public static int CONSUMER_REPLICA_ID { get { return SGetField<int>(LocalBridgeClazz, "CONSUMER_REPLICA_ID"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/OffsetsForLeaderEpochRequest.html#DEBUGGING_REPLICA_ID"/>
        /// </summary>
        public static int DEBUGGING_REPLICA_ID { get { return SGetField<int>(LocalBridgeClazz, "DEBUGGING_REPLICA_ID"); } }

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/OffsetsForLeaderEpochRequest.html#supportsTopicPermission(short)"/>
        /// </summary>
        /// <param name="arg0"><see cref="short"/></param>
        /// <returns><see cref="bool"/></returns>
        public static bool SupportsTopicPermission(short arg0)
        {
            return SExecute<bool>(LocalBridgeClazz, "supportsTopicPermission", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/OffsetsForLeaderEpochRequest.html#parse(java.nio.ByteBuffer,short)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Nio.ByteBuffer"/></param>
        /// <param name="arg1"><see cref="short"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Requests.OffsetsForLeaderEpochRequest"/></returns>
        public static Org.Apache.Kafka.Common.Requests.OffsetsForLeaderEpochRequest Parse(Java.Nio.ByteBuffer arg0, short arg1)
        {
            return SExecute<Org.Apache.Kafka.Common.Requests.OffsetsForLeaderEpochRequest>(LocalBridgeClazz, "parse", arg0, arg1);
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/OffsetsForLeaderEpochRequest.html#replicaId()"/>
        /// </summary>

        /// <returns><see cref="int"/></returns>
        public int ReplicaId()
        {
            return IExecute<int>("replicaId");
        }

        #endregion

        #region Nested classes
        #region Builder
        public partial class Builder
        {
            #region Constructors

            #endregion

            #region Class/Interface conversion operators

            #endregion

            #region Fields

            #endregion

            #region Static methods
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/OffsetsForLeaderEpochRequest.Builder.html#forConsumer(org.apache.kafka.common.message.OffsetForLeaderEpochRequestData.OffsetForLeaderTopicCollection)"/>
            /// </summary>
            /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Message.OffsetForLeaderEpochRequestData.OffsetForLeaderTopicCollection"/></param>
            /// <returns><see cref="Org.Apache.Kafka.Common.Requests.OffsetsForLeaderEpochRequest.Builder"/></returns>
            public static Org.Apache.Kafka.Common.Requests.OffsetsForLeaderEpochRequest.Builder ForConsumer(Org.Apache.Kafka.Common.Message.OffsetForLeaderEpochRequestData.OffsetForLeaderTopicCollection arg0)
            {
                return SExecute<Org.Apache.Kafka.Common.Requests.OffsetsForLeaderEpochRequest.Builder>(LocalBridgeClazz, "forConsumer", arg0);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/OffsetsForLeaderEpochRequest.Builder.html#forFollower(short,org.apache.kafka.common.message.OffsetForLeaderEpochRequestData.OffsetForLeaderTopicCollection,int)"/>
            /// </summary>
            /// <param name="arg0"><see cref="short"/></param>
            /// <param name="arg1"><see cref="Org.Apache.Kafka.Common.Message.OffsetForLeaderEpochRequestData.OffsetForLeaderTopicCollection"/></param>
            /// <param name="arg2"><see cref="int"/></param>
            /// <returns><see cref="Org.Apache.Kafka.Common.Requests.OffsetsForLeaderEpochRequest.Builder"/></returns>
            public static Org.Apache.Kafka.Common.Requests.OffsetsForLeaderEpochRequest.Builder ForFollower(short arg0, Org.Apache.Kafka.Common.Message.OffsetForLeaderEpochRequestData.OffsetForLeaderTopicCollection arg1, int arg2)
            {
                return SExecute<Org.Apache.Kafka.Common.Requests.OffsetsForLeaderEpochRequest.Builder>(LocalBridgeClazz, "forFollower", arg0, arg1, arg2);
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