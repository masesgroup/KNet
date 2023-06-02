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
    #region DescribeConfigsResponse
    public partial class DescribeConfigsResponse
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/DescribeConfigsResponse.html#%3Cinit%3E(org.apache.kafka.common.message.DescribeConfigsResponseData)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Message.DescribeConfigsResponseData"/></param>
        public DescribeConfigsResponse(Org.Apache.Kafka.Common.Message.DescribeConfigsResponseData arg0)
            : base(arg0)
        {
        }

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/DescribeConfigsResponse.html#parse(java.nio.ByteBuffer,short)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Nio.ByteBuffer"/></param>
        /// <param name="arg1"><see cref="short"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse"/></returns>
        public static Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse Parse(Java.Nio.ByteBuffer arg0, short arg1)
        {
            return SExecute<Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse>(LocalBridgeClazz, "parse", arg0, arg1);
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/DescribeConfigsResponse.html#resultMap()"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Map"/></returns>
        public Java.Util.Map<Org.Apache.Kafka.Common.Config.ConfigResource, Org.Apache.Kafka.Common.Message.DescribeConfigsResponseData.DescribeConfigsResult> ResultMap()
        {
            return IExecute<Java.Util.Map<Org.Apache.Kafka.Common.Config.ConfigResource, Org.Apache.Kafka.Common.Message.DescribeConfigsResponseData.DescribeConfigsResult>>("resultMap");
        }

        #endregion

        #region Nested classes
        #region Config
        public partial class Config
        {
            #region Constructors
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/DescribeConfigsResponse.Config.html#%3Cinit%3E(org.apache.kafka.common.requests.ApiError,java.util.Collection)"/>
            /// </summary>
            /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Requests.ApiError"/></param>
            /// <param name="arg1"><see cref="Java.Util.Collection"/></param>
            public Config(Org.Apache.Kafka.Common.Requests.ApiError arg0, Java.Util.Collection<Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigEntry> arg1)
                : base(arg0, arg1)
            {
            }

            #endregion

            #region Class/Interface conversion operators

            #endregion

            #region Fields

            #endregion

            #region Static methods

            #endregion

            #region Instance methods
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/DescribeConfigsResponse.Config.html#entries()"/>
            /// </summary>

            /// <returns><see cref="Java.Util.Collection"/></returns>
            public Java.Util.Collection<Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigEntry> Entries()
            {
                return IExecute<Java.Util.Collection<Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigEntry>>("entries");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/DescribeConfigsResponse.Config.html#error()"/>
            /// </summary>

            /// <returns><see cref="Org.Apache.Kafka.Common.Requests.ApiError"/></returns>
            public Org.Apache.Kafka.Common.Requests.ApiError Error()
            {
                return IExecute<Org.Apache.Kafka.Common.Requests.ApiError>("error");
            }

            #endregion

            #region Nested classes

            #endregion

            // TODO: complete the class
        }
        #endregion

        #region ConfigEntry
        public partial class ConfigEntry
        {
            #region Constructors
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/DescribeConfigsResponse.ConfigEntry.html#%3Cinit%3E(java.lang.String,java.lang.String,org.apache.kafka.common.requests.DescribeConfigsResponse.ConfigSource,boolean,boolean,java.util.Collection,org.apache.kafka.common.requests.DescribeConfigsResponse.ConfigType,java.lang.String)"/>
            /// </summary>
            /// <param name="arg0"><see cref="string"/></param>
            /// <param name="arg1"><see cref="string"/></param>
            /// <param name="arg2"><see cref="Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigSource"/></param>
            /// <param name="arg3"><see cref="bool"/></param>
            /// <param name="arg4"><see cref="bool"/></param>
            /// <param name="arg5"><see cref="Java.Util.Collection"/></param>
            /// <param name="arg6"><see cref="Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigType"/></param>
            /// <param name="arg7"><see cref="string"/></param>
            public ConfigEntry(string arg0, string arg1, Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigSource arg2, bool arg3, bool arg4, Java.Util.Collection<Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigSynonym> arg5, Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigType arg6, string arg7)
                : base(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7)
            {
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/DescribeConfigsResponse.ConfigEntry.html#%3Cinit%3E(java.lang.String,java.lang.String,org.apache.kafka.common.requests.DescribeConfigsResponse.ConfigSource,boolean,boolean,java.util.Collection)"/>
            /// </summary>
            /// <param name="arg0"><see cref="string"/></param>
            /// <param name="arg1"><see cref="string"/></param>
            /// <param name="arg2"><see cref="Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigSource"/></param>
            /// <param name="arg3"><see cref="bool"/></param>
            /// <param name="arg4"><see cref="bool"/></param>
            /// <param name="arg5"><see cref="Java.Util.Collection"/></param>
            public ConfigEntry(string arg0, string arg1, Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigSource arg2, bool arg3, bool arg4, Java.Util.Collection<Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigSynonym> arg5)
                : base(arg0, arg1, arg2, arg3, arg4, arg5)
            {
            }

            #endregion

            #region Class/Interface conversion operators

            #endregion

            #region Fields

            #endregion

            #region Static methods

            #endregion

            #region Instance methods
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/DescribeConfigsResponse.ConfigEntry.html#isReadOnly()"/>
            /// </summary>

            /// <returns><see cref="bool"/></returns>
            public bool IsReadOnly()
            {
                return IExecute<bool>("isReadOnly");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/DescribeConfigsResponse.ConfigEntry.html#isSensitive()"/>
            /// </summary>

            /// <returns><see cref="bool"/></returns>
            public bool IsSensitive()
            {
                return IExecute<bool>("isSensitive");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/DescribeConfigsResponse.ConfigEntry.html#documentation()"/>
            /// </summary>

            /// <returns><see cref="string"/></returns>
            public string Documentation()
            {
                return IExecute<string>("documentation");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/DescribeConfigsResponse.ConfigEntry.html#name()"/>
            /// </summary>

            /// <returns><see cref="string"/></returns>
            public string Name()
            {
                return IExecute<string>("name");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/DescribeConfigsResponse.ConfigEntry.html#value()"/>
            /// </summary>

            /// <returns><see cref="string"/></returns>
            public string Value()
            {
                return IExecute<string>("value");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/DescribeConfigsResponse.ConfigEntry.html#synonyms()"/>
            /// </summary>

            /// <returns><see cref="Java.Util.Collection"/></returns>
            public Java.Util.Collection<Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigSynonym> Synonyms()
            {
                return IExecute<Java.Util.Collection<Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigSynonym>>("synonyms");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/DescribeConfigsResponse.ConfigEntry.html#source()"/>
            /// </summary>

            /// <returns><see cref="Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigSource"/></returns>
            public Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigSource Source()
            {
                return IExecute<Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigSource>("source");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/DescribeConfigsResponse.ConfigEntry.html#type()"/>
            /// </summary>

            /// <returns><see cref="Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigType"/></returns>
            public Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigType Type()
            {
                return IExecute<Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigType>("type");
            }

            #endregion

            #region Nested classes

            #endregion

            // TODO: complete the class
        }
        #endregion

        #region ConfigSource
        public partial class ConfigSource
        {
            #region Constructors

            #endregion

            #region Class/Interface conversion operators

            #endregion

            #region Fields
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/DescribeConfigsResponse.ConfigSource.html#DEFAULT_CONFIG"/>
            /// </summary>
            public static Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigSource DEFAULT_CONFIG { get { return SGetField<Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigSource>(LocalBridgeClazz, "DEFAULT_CONFIG"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/DescribeConfigsResponse.ConfigSource.html#DYNAMIC_BROKER_CONFIG"/>
            /// </summary>
            public static Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigSource DYNAMIC_BROKER_CONFIG { get { return SGetField<Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigSource>(LocalBridgeClazz, "DYNAMIC_BROKER_CONFIG"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/DescribeConfigsResponse.ConfigSource.html#DYNAMIC_BROKER_LOGGER_CONFIG"/>
            /// </summary>
            public static Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigSource DYNAMIC_BROKER_LOGGER_CONFIG { get { return SGetField<Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigSource>(LocalBridgeClazz, "DYNAMIC_BROKER_LOGGER_CONFIG"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/DescribeConfigsResponse.ConfigSource.html#DYNAMIC_DEFAULT_BROKER_CONFIG"/>
            /// </summary>
            public static Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigSource DYNAMIC_DEFAULT_BROKER_CONFIG { get { return SGetField<Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigSource>(LocalBridgeClazz, "DYNAMIC_DEFAULT_BROKER_CONFIG"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/DescribeConfigsResponse.ConfigSource.html#STATIC_BROKER_CONFIG"/>
            /// </summary>
            public static Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigSource STATIC_BROKER_CONFIG { get { return SGetField<Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigSource>(LocalBridgeClazz, "STATIC_BROKER_CONFIG"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/DescribeConfigsResponse.ConfigSource.html#TOPIC_CONFIG"/>
            /// </summary>
            public static Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigSource TOPIC_CONFIG { get { return SGetField<Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigSource>(LocalBridgeClazz, "TOPIC_CONFIG"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/DescribeConfigsResponse.ConfigSource.html#UNKNOWN"/>
            /// </summary>
            public static Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigSource UNKNOWN { get { return SGetField<Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigSource>(LocalBridgeClazz, "UNKNOWN"); } }

            #endregion

            #region Static methods
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/DescribeConfigsResponse.ConfigSource.html#forId(byte)"/>
            /// </summary>
            /// <param name="arg0"><see cref="byte"/></param>
            /// <returns><see cref="Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigSource"/></returns>
            public static Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigSource ForId(byte arg0)
            {
                return SExecute<Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigSource>(LocalBridgeClazz, "forId", arg0);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/DescribeConfigsResponse.ConfigSource.html#valueOf(java.lang.String)"/>
            /// </summary>
            /// <param name="arg0"><see cref="string"/></param>
            /// <returns><see cref="Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigSource"/></returns>
            public static Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigSource ValueOf(string arg0)
            {
                return SExecute<Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigSource>(LocalBridgeClazz, "valueOf", arg0);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/DescribeConfigsResponse.ConfigSource.html#values()"/>
            /// </summary>

            /// <returns><see cref="Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigSource"/></returns>
            public static Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigSource[] Values()
            {
                return SExecuteArray<Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigSource>(LocalBridgeClazz, "values");
            }

            #endregion

            #region Instance methods
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/DescribeConfigsResponse.ConfigSource.html#id()"/>
            /// </summary>

            /// <returns><see cref="byte"/></returns>
            public byte Id()
            {
                return IExecute<byte>("id");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/DescribeConfigsResponse.ConfigSource.html#source()"/>
            /// </summary>

            /// <returns><see cref="Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigSource"/></returns>
            public Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigSource Source()
            {
                return IExecute<Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigSource>("source");
            }

            #endregion

            #region Nested classes

            #endregion

            // TODO: complete the class
        }
        #endregion

        #region ConfigSynonym
        public partial class ConfigSynonym
        {
            #region Constructors
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/DescribeConfigsResponse.ConfigSynonym.html#%3Cinit%3E(java.lang.String,java.lang.String,org.apache.kafka.common.requests.DescribeConfigsResponse.ConfigSource)"/>
            /// </summary>
            /// <param name="arg0"><see cref="string"/></param>
            /// <param name="arg1"><see cref="string"/></param>
            /// <param name="arg2"><see cref="Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigSource"/></param>
            public ConfigSynonym(string arg0, string arg1, Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigSource arg2)
                : base(arg0, arg1, arg2)
            {
            }

            #endregion

            #region Class/Interface conversion operators

            #endregion

            #region Fields

            #endregion

            #region Static methods

            #endregion

            #region Instance methods
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/DescribeConfigsResponse.ConfigSynonym.html#name()"/>
            /// </summary>

            /// <returns><see cref="string"/></returns>
            public string Name()
            {
                return IExecute<string>("name");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/DescribeConfigsResponse.ConfigSynonym.html#value()"/>
            /// </summary>

            /// <returns><see cref="string"/></returns>
            public string Value()
            {
                return IExecute<string>("value");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/DescribeConfigsResponse.ConfigSynonym.html#source()"/>
            /// </summary>

            /// <returns><see cref="Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigSource"/></returns>
            public Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigSource Source()
            {
                return IExecute<Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigSource>("source");
            }

            #endregion

            #region Nested classes

            #endregion

            // TODO: complete the class
        }
        #endregion

        #region ConfigType
        public partial class ConfigType
        {
            #region Constructors

            #endregion

            #region Class/Interface conversion operators

            #endregion

            #region Fields
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/DescribeConfigsResponse.ConfigType.html#BOOLEAN"/>
            /// </summary>
            public static Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigType BOOLEAN { get { return SGetField<Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigType>(LocalBridgeClazz, "BOOLEAN"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/DescribeConfigsResponse.ConfigType.html#CLASS"/>
            /// </summary>
            public static Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigType CLASS { get { return SGetField<Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigType>(LocalBridgeClazz, "CLASS"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/DescribeConfigsResponse.ConfigType.html#DOUBLE"/>
            /// </summary>
            public static Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigType DOUBLE { get { return SGetField<Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigType>(LocalBridgeClazz, "DOUBLE"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/DescribeConfigsResponse.ConfigType.html#INT"/>
            /// </summary>
            public static Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigType INT { get { return SGetField<Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigType>(LocalBridgeClazz, "INT"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/DescribeConfigsResponse.ConfigType.html#LIST"/>
            /// </summary>
            public static Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigType LIST { get { return SGetField<Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigType>(LocalBridgeClazz, "LIST"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/DescribeConfigsResponse.ConfigType.html#LONG"/>
            /// </summary>
            public static Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigType LONG { get { return SGetField<Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigType>(LocalBridgeClazz, "LONG"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/DescribeConfigsResponse.ConfigType.html#PASSWORD"/>
            /// </summary>
            public static Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigType PASSWORD { get { return SGetField<Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigType>(LocalBridgeClazz, "PASSWORD"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/DescribeConfigsResponse.ConfigType.html#SHORT"/>
            /// </summary>
            public static Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigType SHORT { get { return SGetField<Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigType>(LocalBridgeClazz, "SHORT"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/DescribeConfigsResponse.ConfigType.html#STRING"/>
            /// </summary>
            public static Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigType STRING { get { return SGetField<Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigType>(LocalBridgeClazz, "STRING"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/DescribeConfigsResponse.ConfigType.html#UNKNOWN"/>
            /// </summary>
            public static Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigType UNKNOWN { get { return SGetField<Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigType>(LocalBridgeClazz, "UNKNOWN"); } }

            #endregion

            #region Static methods
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/DescribeConfigsResponse.ConfigType.html#forId(byte)"/>
            /// </summary>
            /// <param name="arg0"><see cref="byte"/></param>
            /// <returns><see cref="Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigType"/></returns>
            public static Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigType ForId(byte arg0)
            {
                return SExecute<Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigType>(LocalBridgeClazz, "forId", arg0);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/DescribeConfigsResponse.ConfigType.html#valueOf(java.lang.String)"/>
            /// </summary>
            /// <param name="arg0"><see cref="string"/></param>
            /// <returns><see cref="Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigType"/></returns>
            public static Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigType ValueOf(string arg0)
            {
                return SExecute<Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigType>(LocalBridgeClazz, "valueOf", arg0);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/DescribeConfigsResponse.ConfigType.html#values()"/>
            /// </summary>

            /// <returns><see cref="Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigType"/></returns>
            public static Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigType[] Values()
            {
                return SExecuteArray<Org.Apache.Kafka.Common.Requests.DescribeConfigsResponse.ConfigType>(LocalBridgeClazz, "values");
            }

            #endregion

            #region Instance methods
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/DescribeConfigsResponse.ConfigType.html#id()"/>
            /// </summary>

            /// <returns><see cref="byte"/></returns>
            public byte Id()
            {
                return IExecute<byte>("id");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/requests/DescribeConfigsResponse.ConfigType.html#type()"/>
            /// </summary>

            /// <returns><see cref="Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigType"/></returns>
            public Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigType Type()
            {
                return IExecute<Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigType>("type");
            }

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