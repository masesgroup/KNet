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
*  using connect-transforms-3.5.0.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Connect.Transforms
{
    #region TimestampConverter
    public partial class TimestampConverter
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-transforms/3.5.0/org/apache/kafka/connect/transforms/TimestampConverter.html#FIELD_CONFIG"/>
        /// </summary>
        public static string FIELD_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "FIELD_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-transforms/3.5.0/org/apache/kafka/connect/transforms/TimestampConverter.html#FORMAT_CONFIG"/>
        /// </summary>
        public static string FORMAT_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "FORMAT_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-transforms/3.5.0/org/apache/kafka/connect/transforms/TimestampConverter.html#OVERVIEW_DOC"/>
        /// </summary>
        public static string OVERVIEW_DOC { get { return SGetField<string>(LocalBridgeClazz, "OVERVIEW_DOC"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-transforms/3.5.0/org/apache/kafka/connect/transforms/TimestampConverter.html#TARGET_TYPE_CONFIG"/>
        /// </summary>
        public static string TARGET_TYPE_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "TARGET_TYPE_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-transforms/3.5.0/org/apache/kafka/connect/transforms/TimestampConverter.html#UNIX_PRECISION_CONFIG"/>
        /// </summary>
        public static string UNIX_PRECISION_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "UNIX_PRECISION_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-transforms/3.5.0/org/apache/kafka/connect/transforms/TimestampConverter.html#CONFIG_DEF"/>
        /// </summary>
        public static Org.Apache.Kafka.Common.Config.ConfigDef CONFIG_DEF { get { return SGetField<Org.Apache.Kafka.Common.Config.ConfigDef>(LocalBridgeClazz, "CONFIG_DEF"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-transforms/3.5.0/org/apache/kafka/connect/transforms/TimestampConverter.html#OPTIONAL_DATE_SCHEMA"/>
        /// </summary>
        public static Org.Apache.Kafka.Connect.Data.Schema OPTIONAL_DATE_SCHEMA { get { return SGetField<Org.Apache.Kafka.Connect.Data.Schema>(LocalBridgeClazz, "OPTIONAL_DATE_SCHEMA"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-transforms/3.5.0/org/apache/kafka/connect/transforms/TimestampConverter.html#OPTIONAL_TIME_SCHEMA"/>
        /// </summary>
        public static Org.Apache.Kafka.Connect.Data.Schema OPTIONAL_TIME_SCHEMA { get { return SGetField<Org.Apache.Kafka.Connect.Data.Schema>(LocalBridgeClazz, "OPTIONAL_TIME_SCHEMA"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-transforms/3.5.0/org/apache/kafka/connect/transforms/TimestampConverter.html#OPTIONAL_TIMESTAMP_SCHEMA"/>
        /// </summary>
        public static Org.Apache.Kafka.Connect.Data.Schema OPTIONAL_TIMESTAMP_SCHEMA { get { return SGetField<Org.Apache.Kafka.Connect.Data.Schema>(LocalBridgeClazz, "OPTIONAL_TIMESTAMP_SCHEMA"); } }

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-transforms/3.5.0/org/apache/kafka/connect/transforms/TimestampConverter.html#config--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Config.ConfigDef"/></returns>
        public Org.Apache.Kafka.Common.Config.ConfigDef ConfigMethod()
        {
            return IExecute<Org.Apache.Kafka.Common.Config.ConfigDef>("config");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-transforms/3.5.0/org/apache/kafka/connect/transforms/TimestampConverter.html#apply-org.apache.kafka.connect.connector.ConnectRecord-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Connect.Connector.ConnectRecord"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Connect.Connector.ConnectRecord"/></returns>
        public Org.Apache.Kafka.Connect.Connector.ConnectRecord Apply(Org.Apache.Kafka.Connect.Connector.ConnectRecord arg0)
        {
            return IExecute<Org.Apache.Kafka.Connect.Connector.ConnectRecord>("apply", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-transforms/3.5.0/org/apache/kafka/connect/transforms/TimestampConverter.html#close--"/>
        /// </summary>
        public void Close()
        {
            IExecute("close");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-transforms/3.5.0/org/apache/kafka/connect/transforms/TimestampConverter.html#configure-java.util.Map-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Map"/></param>
        public void Configure(Java.Util.Map arg0)
        {
            IExecute("configure", arg0);
        }

        #endregion

        #region Nested classes
        #region Key
        public partial class Key
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

            #endregion

            #region Nested classes

            #endregion

            // TODO: complete the class
        }
        #endregion

        #region Key<R>
        public partial class Key<R>
        {
            #region Constructors

            #endregion

            #region Class/Interface conversion operators
            /// <summary>
            /// Converter from <see cref="Org.Apache.Kafka.Connect.Transforms.TimestampConverter.Key{R}"/> to <see cref="Org.Apache.Kafka.Connect.Transforms.TimestampConverter.Key"/>
            /// </summary>
            public static implicit operator Org.Apache.Kafka.Connect.Transforms.TimestampConverter.Key(Org.Apache.Kafka.Connect.Transforms.TimestampConverter.Key<R> t) => t.Cast<Org.Apache.Kafka.Connect.Transforms.TimestampConverter.Key>();

            #endregion

            #region Fields

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

        #region Value
        public partial class Value
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

            #endregion

            #region Nested classes

            #endregion

            // TODO: complete the class
        }
        #endregion

        #region Value<R>
        public partial class Value<R>
        {
            #region Constructors

            #endregion

            #region Class/Interface conversion operators
            /// <summary>
            /// Converter from <see cref="Org.Apache.Kafka.Connect.Transforms.TimestampConverter.Value{R}"/> to <see cref="Org.Apache.Kafka.Connect.Transforms.TimestampConverter.Value"/>
            /// </summary>
            public static implicit operator Org.Apache.Kafka.Connect.Transforms.TimestampConverter.Value(Org.Apache.Kafka.Connect.Transforms.TimestampConverter.Value<R> t) => t.Cast<Org.Apache.Kafka.Connect.Transforms.TimestampConverter.Value>();

            #endregion

            #region Fields

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

    
        #endregion

        // TODO: complete the class
    }
    #endregion

    #region TimestampConverter<R>
    public partial class TimestampConverter<R>
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Connect.Transforms.TimestampConverter{R}"/> to <see cref="Org.Apache.Kafka.Connect.Transforms.TimestampConverter"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Connect.Transforms.TimestampConverter(Org.Apache.Kafka.Connect.Transforms.TimestampConverter<R> t) => t.Cast<Org.Apache.Kafka.Connect.Transforms.TimestampConverter>();

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-transforms/3.5.0/org/apache/kafka/connect/transforms/TimestampConverter.html#FIELD_CONFIG"/>
        /// </summary>
        public static string FIELD_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "FIELD_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-transforms/3.5.0/org/apache/kafka/connect/transforms/TimestampConverter.html#FORMAT_CONFIG"/>
        /// </summary>
        public static string FORMAT_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "FORMAT_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-transforms/3.5.0/org/apache/kafka/connect/transforms/TimestampConverter.html#OVERVIEW_DOC"/>
        /// </summary>
        public static string OVERVIEW_DOC { get { return SGetField<string>(LocalBridgeClazz, "OVERVIEW_DOC"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-transforms/3.5.0/org/apache/kafka/connect/transforms/TimestampConverter.html#TARGET_TYPE_CONFIG"/>
        /// </summary>
        public static string TARGET_TYPE_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "TARGET_TYPE_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-transforms/3.5.0/org/apache/kafka/connect/transforms/TimestampConverter.html#UNIX_PRECISION_CONFIG"/>
        /// </summary>
        public static string UNIX_PRECISION_CONFIG { get { return SGetField<string>(LocalBridgeClazz, "UNIX_PRECISION_CONFIG"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-transforms/3.5.0/org/apache/kafka/connect/transforms/TimestampConverter.html#CONFIG_DEF"/>
        /// </summary>
        public static Org.Apache.Kafka.Common.Config.ConfigDef CONFIG_DEF { get { return SGetField<Org.Apache.Kafka.Common.Config.ConfigDef>(LocalBridgeClazz, "CONFIG_DEF"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-transforms/3.5.0/org/apache/kafka/connect/transforms/TimestampConverter.html#OPTIONAL_DATE_SCHEMA"/>
        /// </summary>
        public static Org.Apache.Kafka.Connect.Data.Schema OPTIONAL_DATE_SCHEMA { get { return SGetField<Org.Apache.Kafka.Connect.Data.Schema>(LocalBridgeClazz, "OPTIONAL_DATE_SCHEMA"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-transforms/3.5.0/org/apache/kafka/connect/transforms/TimestampConverter.html#OPTIONAL_TIME_SCHEMA"/>
        /// </summary>
        public static Org.Apache.Kafka.Connect.Data.Schema OPTIONAL_TIME_SCHEMA { get { return SGetField<Org.Apache.Kafka.Connect.Data.Schema>(LocalBridgeClazz, "OPTIONAL_TIME_SCHEMA"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-transforms/3.5.0/org/apache/kafka/connect/transforms/TimestampConverter.html#OPTIONAL_TIMESTAMP_SCHEMA"/>
        /// </summary>
        public static Org.Apache.Kafka.Connect.Data.Schema OPTIONAL_TIMESTAMP_SCHEMA { get { return SGetField<Org.Apache.Kafka.Connect.Data.Schema>(LocalBridgeClazz, "OPTIONAL_TIMESTAMP_SCHEMA"); } }

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-transforms/3.5.0/org/apache/kafka/connect/transforms/TimestampConverter.html#config--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Config.ConfigDef"/></returns>
        public Org.Apache.Kafka.Common.Config.ConfigDef ConfigMethod()
        {
            return IExecute<Org.Apache.Kafka.Common.Config.ConfigDef>("config");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-transforms/3.5.0/org/apache/kafka/connect/transforms/TimestampConverter.html#apply-org.apache.kafka.connect.connector.ConnectRecord-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="R"/></param>
        /// <returns><typeparamref name="R"/></returns>
        public R Apply(R arg0)
        {
            return IExecute<R>("apply", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-transforms/3.5.0/org/apache/kafka/connect/transforms/TimestampConverter.html#close--"/>
        /// </summary>
        public void Close()
        {
            IExecute("close");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-transforms/3.5.0/org/apache/kafka/connect/transforms/TimestampConverter.html#configure-java.util.Map-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Map"/></param>
        public void Configure(Java.Util.Map<string, object> arg0)
        {
            IExecute("configure", arg0);
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}