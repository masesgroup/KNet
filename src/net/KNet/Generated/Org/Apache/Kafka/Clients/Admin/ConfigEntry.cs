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
*  using kafka-clients-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Clients.Admin
{
    #region ConfigEntry
    public partial class ConfigEntry
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/ConfigEntry.html#org.apache.kafka.clients.admin.ConfigEntry(java.lang.String,java.lang.String,org.apache.kafka.clients.admin.ConfigEntry.ConfigSource,boolean,boolean,java.util.List,org.apache.kafka.clients.admin.ConfigEntry.ConfigType,java.lang.String)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigSource"/></param>
        /// <param name="arg3"><see cref="bool"/></param>
        /// <param name="arg4"><see cref="bool"/></param>
        /// <param name="arg5"><see cref="Java.Util.List"/></param>
        /// <param name="arg6"><see cref="Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigType"/></param>
        /// <param name="arg7"><see cref="string"/></param>
        public ConfigEntry(string arg0, string arg1, Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigSource arg2, bool arg3, bool arg4, Java.Util.List<Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigSynonym> arg5, Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigType arg6, string arg7)
            : base(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7)
        {
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/ConfigEntry.html#org.apache.kafka.clients.admin.ConfigEntry(java.lang.String,java.lang.String)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        public ConfigEntry(string arg0, string arg1)
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
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/ConfigEntry.html#isDefault--"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool IsDefault()
        {
            return IExecute<bool>("isDefault");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/ConfigEntry.html#isReadOnly--"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool IsReadOnly()
        {
            return IExecute<bool>("isReadOnly");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/ConfigEntry.html#isSensitive--"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool IsSensitive()
        {
            return IExecute<bool>("isSensitive");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/ConfigEntry.html#documentation--"/>
        /// </summary>

        /// <returns><see cref="string"/></returns>
        public string Documentation()
        {
            return IExecute<string>("documentation");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/ConfigEntry.html#name--"/>
        /// </summary>

        /// <returns><see cref="string"/></returns>
        public string Name()
        {
            return IExecute<string>("name");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/ConfigEntry.html#value--"/>
        /// </summary>

        /// <returns><see cref="string"/></returns>
        public string Value()
        {
            return IExecute<string>("value");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/ConfigEntry.html#synonyms--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.List"/></returns>
        public Java.Util.List<Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigSynonym> Synonyms()
        {
            return IExecute<Java.Util.List<Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigSynonym>>("synonyms");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/ConfigEntry.html#source--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigSource"/></returns>
        public Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigSource Source()
        {
            return IExecute<Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigSource>("source");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/ConfigEntry.html#type--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigType"/></returns>
        public Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigType Type()
        {
            return IExecute<Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigType>("type");
        }

        #endregion

        #region Nested classes
        #region ConfigSource
        public partial class ConfigSource
        {
            #region Constructors

            #endregion

            #region Class/Interface conversion operators

            #endregion

            #region Fields
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/ConfigEntry.ConfigSource.html#DEFAULT_CONFIG"/>
            /// </summary>
            public static Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigSource DEFAULT_CONFIG { get { return SGetField<Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigSource>(LocalBridgeClazz, "DEFAULT_CONFIG"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/ConfigEntry.ConfigSource.html#DYNAMIC_BROKER_CONFIG"/>
            /// </summary>
            public static Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigSource DYNAMIC_BROKER_CONFIG { get { return SGetField<Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigSource>(LocalBridgeClazz, "DYNAMIC_BROKER_CONFIG"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/ConfigEntry.ConfigSource.html#DYNAMIC_BROKER_LOGGER_CONFIG"/>
            /// </summary>
            public static Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigSource DYNAMIC_BROKER_LOGGER_CONFIG { get { return SGetField<Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigSource>(LocalBridgeClazz, "DYNAMIC_BROKER_LOGGER_CONFIG"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/ConfigEntry.ConfigSource.html#DYNAMIC_DEFAULT_BROKER_CONFIG"/>
            /// </summary>
            public static Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigSource DYNAMIC_DEFAULT_BROKER_CONFIG { get { return SGetField<Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigSource>(LocalBridgeClazz, "DYNAMIC_DEFAULT_BROKER_CONFIG"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/ConfigEntry.ConfigSource.html#DYNAMIC_TOPIC_CONFIG"/>
            /// </summary>
            public static Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigSource DYNAMIC_TOPIC_CONFIG { get { return SGetField<Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigSource>(LocalBridgeClazz, "DYNAMIC_TOPIC_CONFIG"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/ConfigEntry.ConfigSource.html#STATIC_BROKER_CONFIG"/>
            /// </summary>
            public static Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigSource STATIC_BROKER_CONFIG { get { return SGetField<Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigSource>(LocalBridgeClazz, "STATIC_BROKER_CONFIG"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/ConfigEntry.ConfigSource.html#UNKNOWN"/>
            /// </summary>
            public static Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigSource UNKNOWN { get { return SGetField<Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigSource>(LocalBridgeClazz, "UNKNOWN"); } }

            #endregion

            #region Static methods
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/ConfigEntry.ConfigSource.html#valueOf-java.lang.String-"/>
            /// </summary>
            /// <param name="arg0"><see cref="string"/></param>
            /// <returns><see cref="Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigSource"/></returns>
            public static Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigSource ValueOf(string arg0)
            {
                return SExecute<Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigSource>(LocalBridgeClazz, "valueOf", arg0);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/ConfigEntry.ConfigSource.html#values--"/>
            /// </summary>

            /// <returns><see cref="Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigSource"/></returns>
            public static Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigSource[] Values()
            {
                return SExecuteArray<Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigSource>(LocalBridgeClazz, "values");
            }

            #endregion

            #region Instance methods

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

            #endregion

            #region Class/Interface conversion operators

            #endregion

            #region Fields

            #endregion

            #region Static methods

            #endregion

            #region Instance methods
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/ConfigEntry.ConfigSynonym.html#name--"/>
            /// </summary>

            /// <returns><see cref="string"/></returns>
            public string Name()
            {
                return IExecute<string>("name");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/ConfigEntry.ConfigSynonym.html#value--"/>
            /// </summary>

            /// <returns><see cref="string"/></returns>
            public string Value()
            {
                return IExecute<string>("value");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/ConfigEntry.ConfigSynonym.html#source--"/>
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

        #region ConfigType
        public partial class ConfigType
        {
            #region Constructors

            #endregion

            #region Class/Interface conversion operators

            #endregion

            #region Fields
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/ConfigEntry.ConfigType.html#BOOLEAN"/>
            /// </summary>
            public static Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigType BOOLEAN { get { return SGetField<Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigType>(LocalBridgeClazz, "BOOLEAN"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/ConfigEntry.ConfigType.html#CLASS"/>
            /// </summary>
            public static Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigType CLASS { get { return SGetField<Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigType>(LocalBridgeClazz, "CLASS"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/ConfigEntry.ConfigType.html#DOUBLE"/>
            /// </summary>
            public static Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigType DOUBLE { get { return SGetField<Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigType>(LocalBridgeClazz, "DOUBLE"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/ConfigEntry.ConfigType.html#INT"/>
            /// </summary>
            public static Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigType INT { get { return SGetField<Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigType>(LocalBridgeClazz, "INT"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/ConfigEntry.ConfigType.html#LIST"/>
            /// </summary>
            public static Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigType LIST { get { return SGetField<Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigType>(LocalBridgeClazz, "LIST"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/ConfigEntry.ConfigType.html#LONG"/>
            /// </summary>
            public static Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigType LONG { get { return SGetField<Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigType>(LocalBridgeClazz, "LONG"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/ConfigEntry.ConfigType.html#PASSWORD"/>
            /// </summary>
            public static Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigType PASSWORD { get { return SGetField<Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigType>(LocalBridgeClazz, "PASSWORD"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/ConfigEntry.ConfigType.html#SHORT"/>
            /// </summary>
            public static Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigType SHORT { get { return SGetField<Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigType>(LocalBridgeClazz, "SHORT"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/ConfigEntry.ConfigType.html#STRING"/>
            /// </summary>
            public static Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigType STRING { get { return SGetField<Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigType>(LocalBridgeClazz, "STRING"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/ConfigEntry.ConfigType.html#UNKNOWN"/>
            /// </summary>
            public static Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigType UNKNOWN { get { return SGetField<Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigType>(LocalBridgeClazz, "UNKNOWN"); } }

            #endregion

            #region Static methods
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/ConfigEntry.ConfigType.html#valueOf-java.lang.String-"/>
            /// </summary>
            /// <param name="arg0"><see cref="string"/></param>
            /// <returns><see cref="Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigType"/></returns>
            public static Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigType ValueOf(string arg0)
            {
                return SExecute<Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigType>(LocalBridgeClazz, "valueOf", arg0);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/ConfigEntry.ConfigType.html#values--"/>
            /// </summary>

            /// <returns><see cref="Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigType"/></returns>
            public static Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigType[] Values()
            {
                return SExecuteArray<Org.Apache.Kafka.Clients.Admin.ConfigEntry.ConfigType>(LocalBridgeClazz, "values");
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