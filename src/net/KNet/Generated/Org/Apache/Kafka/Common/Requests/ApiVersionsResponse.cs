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
    #region ApiVersionsResponse
    public partial class ApiVersionsResponse
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/ApiVersionsResponse.html#%3Cinit%3E(org.apache.kafka.common.message.ApiVersionsResponseData)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Message.ApiVersionsResponseData"/></param>
        public ApiVersionsResponse(Org.Apache.Kafka.Common.Message.ApiVersionsResponseData arg0)
            : base(arg0)
        {
        }

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/ApiVersionsResponse.html#UNKNOWN_FINALIZED_FEATURES_EPOCH"/>
        /// </summary>
        public static long UNKNOWN_FINALIZED_FEATURES_EPOCH { get { return SGetField<long>(LocalBridgeClazz, "UNKNOWN_FINALIZED_FEATURES_EPOCH"); } }

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/ApiVersionsResponse.html#intersect(org.apache.kafka.common.message.ApiVersionsResponseData.ApiVersion,org.apache.kafka.common.message.ApiVersionsResponseData.ApiVersion)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Message.ApiVersionsResponseData.ApiVersion"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Common.Message.ApiVersionsResponseData.ApiVersion"/></param>
        /// <returns><see cref="Java.Util.Optional"/></returns>
        public static Java.Util.Optional<Org.Apache.Kafka.Common.Message.ApiVersionsResponseData.ApiVersion> Intersect(Org.Apache.Kafka.Common.Message.ApiVersionsResponseData.ApiVersion arg0, Org.Apache.Kafka.Common.Message.ApiVersionsResponseData.ApiVersion arg1)
        {
            return SExecute<Java.Util.Optional<Org.Apache.Kafka.Common.Message.ApiVersionsResponseData.ApiVersion>>(LocalBridgeClazz, "intersect", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/ApiVersionsResponse.html#toApiVersion(org.apache.kafka.common.protocol.ApiKeys)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Protocol.ApiKeys"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Message.ApiVersionsResponseData.ApiVersion"/></returns>
        public static Org.Apache.Kafka.Common.Message.ApiVersionsResponseData.ApiVersion ToApiVersion(Org.Apache.Kafka.Common.Protocol.ApiKeys arg0)
        {
            return SExecute<Org.Apache.Kafka.Common.Message.ApiVersionsResponseData.ApiVersion>(LocalBridgeClazz, "toApiVersion", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/ApiVersionsResponse.html#collectApis(java.util.Set)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Set"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Message.ApiVersionsResponseData.ApiVersionCollection"/></returns>
        public static Org.Apache.Kafka.Common.Message.ApiVersionsResponseData.ApiVersionCollection CollectApis(Java.Util.Set<Org.Apache.Kafka.Common.Protocol.ApiKeys> arg0)
        {
            return SExecute<Org.Apache.Kafka.Common.Message.ApiVersionsResponseData.ApiVersionCollection>(LocalBridgeClazz, "collectApis", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/ApiVersionsResponse.html#filterApis(org.apache.kafka.common.record.RecordVersion,org.apache.kafka.common.message.ApiMessageType.ListenerType)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Record.RecordVersion"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Common.Message.ApiMessageType.ListenerType"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Message.ApiVersionsResponseData.ApiVersionCollection"/></returns>
        public static Org.Apache.Kafka.Common.Message.ApiVersionsResponseData.ApiVersionCollection FilterApis(Org.Apache.Kafka.Common.Record.RecordVersion arg0, Org.Apache.Kafka.Common.Message.ApiMessageType.ListenerType arg1)
        {
            return SExecute<Org.Apache.Kafka.Common.Message.ApiVersionsResponseData.ApiVersionCollection>(LocalBridgeClazz, "filterApis", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/ApiVersionsResponse.html#intersectForwardableApis(org.apache.kafka.common.message.ApiMessageType.ListenerType,org.apache.kafka.common.record.RecordVersion,java.util.Map)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Message.ApiMessageType.ListenerType"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Common.Record.RecordVersion"/></param>
        /// <param name="arg2"><see cref="Java.Util.Map"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Message.ApiVersionsResponseData.ApiVersionCollection"/></returns>
        public static Org.Apache.Kafka.Common.Message.ApiVersionsResponseData.ApiVersionCollection IntersectForwardableApis(Org.Apache.Kafka.Common.Message.ApiMessageType.ListenerType arg0, Org.Apache.Kafka.Common.Record.RecordVersion arg1, Java.Util.Map<Org.Apache.Kafka.Common.Protocol.ApiKeys, Org.Apache.Kafka.Common.Message.ApiVersionsResponseData.ApiVersion> arg2)
        {
            return SExecute<Org.Apache.Kafka.Common.Message.ApiVersionsResponseData.ApiVersionCollection>(LocalBridgeClazz, "intersectForwardableApis", arg0, arg1, arg2);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/ApiVersionsResponse.html#createApiVersionsResponse(int,org.apache.kafka.common.message.ApiVersionsResponseData.ApiVersionCollection,org.apache.kafka.common.feature.Features,java.util.Map,long)"/>
        /// </summary>
        /// <param name="arg0"><see cref="int"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Common.Message.ApiVersionsResponseData.ApiVersionCollection"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Common.Feature.Features"/></param>
        /// <param name="arg3"><see cref="Java.Util.Map"/></param>
        /// <param name="arg4"><see cref="long"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Requests.ApiVersionsResponse"/></returns>
        public static Org.Apache.Kafka.Common.Requests.ApiVersionsResponse CreateApiVersionsResponse(int arg0, Org.Apache.Kafka.Common.Message.ApiVersionsResponseData.ApiVersionCollection arg1, Org.Apache.Kafka.Common.Feature.Features arg2, Java.Util.Map<string, short?> arg3, long arg4)
        {
            return SExecute<Org.Apache.Kafka.Common.Requests.ApiVersionsResponse>(LocalBridgeClazz, "createApiVersionsResponse", arg0, arg1, arg2, arg3, arg4);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/ApiVersionsResponse.html#createApiVersionsResponse(int,org.apache.kafka.common.message.ApiVersionsResponseData.ApiVersionCollection,org.apache.kafka.common.feature.Features)"/>
        /// </summary>
        /// <param name="arg0"><see cref="int"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Common.Message.ApiVersionsResponseData.ApiVersionCollection"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Common.Feature.Features"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Requests.ApiVersionsResponse"/></returns>
        public static Org.Apache.Kafka.Common.Requests.ApiVersionsResponse CreateApiVersionsResponse(int arg0, Org.Apache.Kafka.Common.Message.ApiVersionsResponseData.ApiVersionCollection arg1, Org.Apache.Kafka.Common.Feature.Features arg2)
        {
            return SExecute<Org.Apache.Kafka.Common.Requests.ApiVersionsResponse>(LocalBridgeClazz, "createApiVersionsResponse", arg0, arg1, arg2);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/ApiVersionsResponse.html#createApiVersionsResponse(int,org.apache.kafka.common.message.ApiVersionsResponseData.ApiVersionCollection)"/>
        /// </summary>
        /// <param name="arg0"><see cref="int"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Common.Message.ApiVersionsResponseData.ApiVersionCollection"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Requests.ApiVersionsResponse"/></returns>
        public static Org.Apache.Kafka.Common.Requests.ApiVersionsResponse CreateApiVersionsResponse(int arg0, Org.Apache.Kafka.Common.Message.ApiVersionsResponseData.ApiVersionCollection arg1)
        {
            return SExecute<Org.Apache.Kafka.Common.Requests.ApiVersionsResponse>(LocalBridgeClazz, "createApiVersionsResponse", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/ApiVersionsResponse.html#createApiVersionsResponse(int,org.apache.kafka.common.record.RecordVersion,org.apache.kafka.common.feature.Features,java.util.Map,long,org.apache.kafka.clients.NodeApiVersions,org.apache.kafka.common.message.ApiMessageType.ListenerType)"/>
        /// </summary>
        /// <param name="arg0"><see cref="int"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Common.Record.RecordVersion"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Common.Feature.Features"/></param>
        /// <param name="arg3"><see cref="Java.Util.Map"/></param>
        /// <param name="arg4"><see cref="long"/></param>
        /// <param name="arg5"><see cref="Org.Apache.Kafka.Clients.NodeApiVersions"/></param>
        /// <param name="arg6"><see cref="Org.Apache.Kafka.Common.Message.ApiMessageType.ListenerType"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Requests.ApiVersionsResponse"/></returns>
        public static Org.Apache.Kafka.Common.Requests.ApiVersionsResponse CreateApiVersionsResponse(int arg0, Org.Apache.Kafka.Common.Record.RecordVersion arg1, Org.Apache.Kafka.Common.Feature.Features arg2, Java.Util.Map<string, short?> arg3, long arg4, Org.Apache.Kafka.Clients.NodeApiVersions arg5, Org.Apache.Kafka.Common.Message.ApiMessageType.ListenerType arg6)
        {
            return SExecute<Org.Apache.Kafka.Common.Requests.ApiVersionsResponse>(LocalBridgeClazz, "createApiVersionsResponse", arg0, arg1, arg2, arg3, arg4, arg5, arg6);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/ApiVersionsResponse.html#defaultApiVersionsResponse(int,org.apache.kafka.common.message.ApiMessageType.ListenerType)"/>
        /// </summary>
        /// <param name="arg0"><see cref="int"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Common.Message.ApiMessageType.ListenerType"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Requests.ApiVersionsResponse"/></returns>
        public static Org.Apache.Kafka.Common.Requests.ApiVersionsResponse DefaultApiVersionsResponse(int arg0, Org.Apache.Kafka.Common.Message.ApiMessageType.ListenerType arg1)
        {
            return SExecute<Org.Apache.Kafka.Common.Requests.ApiVersionsResponse>(LocalBridgeClazz, "defaultApiVersionsResponse", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/ApiVersionsResponse.html#defaultApiVersionsResponse(org.apache.kafka.common.message.ApiMessageType.ListenerType)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Message.ApiMessageType.ListenerType"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Requests.ApiVersionsResponse"/></returns>
        public static Org.Apache.Kafka.Common.Requests.ApiVersionsResponse DefaultApiVersionsResponse(Org.Apache.Kafka.Common.Message.ApiMessageType.ListenerType arg0)
        {
            return SExecute<Org.Apache.Kafka.Common.Requests.ApiVersionsResponse>(LocalBridgeClazz, "defaultApiVersionsResponse", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/ApiVersionsResponse.html#parse(java.nio.ByteBuffer,short)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Nio.ByteBuffer"/></param>
        /// <param name="arg1"><see cref="short"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Requests.ApiVersionsResponse"/></returns>
        public static Org.Apache.Kafka.Common.Requests.ApiVersionsResponse Parse(Java.Nio.ByteBuffer arg0, short arg1)
        {
            return SExecute<Org.Apache.Kafka.Common.Requests.ApiVersionsResponse>(LocalBridgeClazz, "parse", arg0, arg1);
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/ApiVersionsResponse.html#zkMigrationReady()"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool ZkMigrationReady()
        {
            return IExecute<bool>("zkMigrationReady");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/ApiVersionsResponse.html#apiVersion(short)"/>
        /// </summary>
        /// <param name="arg0"><see cref="short"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Message.ApiVersionsResponseData.ApiVersion"/></returns>
        public Org.Apache.Kafka.Common.Message.ApiVersionsResponseData.ApiVersion ApiVersion(short arg0)
        {
            return IExecute<Org.Apache.Kafka.Common.Message.ApiVersionsResponseData.ApiVersion>("apiVersion", arg0);
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}