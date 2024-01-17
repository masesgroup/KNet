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
*  using connect-api-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Connect.Data
{
    #region ConnectSchema
    public partial class ConnectSchema
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.1/org/apache/kafka/connect/data/ConnectSchema.html#org.apache.kafka.connect.data.ConnectSchema(org.apache.kafka.connect.data.Schema.Type,boolean,java.lang.Object,java.lang.String,java.lang.Integer,java.lang.String,java.util.Map,java.util.List,org.apache.kafka.connect.data.Schema,org.apache.kafka.connect.data.Schema)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Connect.Data.Schema.Type"/></param>
        /// <param name="arg1"><see cref="bool"/></param>
        /// <param name="arg2"><see cref="object"/></param>
        /// <param name="arg3"><see cref="string"/></param>
        /// <param name="arg4"><see cref="Java.Lang.Integer"/></param>
        /// <param name="arg5"><see cref="string"/></param>
        /// <param name="arg6"><see cref="Java.Util.Map"/></param>
        /// <param name="arg7"><see cref="Java.Util.List"/></param>
        /// <param name="arg8"><see cref="Org.Apache.Kafka.Connect.Data.Schema"/></param>
        /// <param name="arg9"><see cref="Org.Apache.Kafka.Connect.Data.Schema"/></param>
        public ConnectSchema(Org.Apache.Kafka.Connect.Data.Schema.Type arg0, bool arg1, object arg2, string arg3, Java.Lang.Integer arg4, string arg5, Java.Util.Map<string, string> arg6, Java.Util.List<Org.Apache.Kafka.Connect.Data.Field> arg7, Org.Apache.Kafka.Connect.Data.Schema arg8, Org.Apache.Kafka.Connect.Data.Schema arg9)
            : base(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9)
        {
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.1/org/apache/kafka/connect/data/ConnectSchema.html#org.apache.kafka.connect.data.ConnectSchema(org.apache.kafka.connect.data.Schema.Type,boolean,java.lang.Object,java.lang.String,java.lang.Integer,java.lang.String)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Connect.Data.Schema.Type"/></param>
        /// <param name="arg1"><see cref="bool"/></param>
        /// <param name="arg2"><see cref="object"/></param>
        /// <param name="arg3"><see cref="string"/></param>
        /// <param name="arg4"><see cref="Java.Lang.Integer"/></param>
        /// <param name="arg5"><see cref="string"/></param>
        public ConnectSchema(Org.Apache.Kafka.Connect.Data.Schema.Type arg0, bool arg1, object arg2, string arg3, Java.Lang.Integer arg4, string arg5)
            : base(arg0, arg1, arg2, arg3, arg4, arg5)
        {
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.1/org/apache/kafka/connect/data/ConnectSchema.html#org.apache.kafka.connect.data.ConnectSchema(org.apache.kafka.connect.data.Schema.Type)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Connect.Data.Schema.Type"/></param>
        public ConnectSchema(Org.Apache.Kafka.Connect.Data.Schema.Type arg0)
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
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.1/org/apache/kafka/connect/data/ConnectSchema.html#schemaType-java.lang.Class-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.Class"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Connect.Data.Schema.Type"/></returns>
        public static Org.Apache.Kafka.Connect.Data.Schema.Type SchemaType(Java.Lang.Class arg0)
        {
            return SExecute<Org.Apache.Kafka.Connect.Data.Schema.Type>(LocalBridgeClazz, "schemaType", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.1/org/apache/kafka/connect/data/ConnectSchema.html#validateValue-java.lang.String-org.apache.kafka.connect.data.Schema-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Connect.Data.Schema"/></param>
        /// <param name="arg2"><see cref="object"/></param>
        public static void ValidateValue(string arg0, Org.Apache.Kafka.Connect.Data.Schema arg1, object arg2)
        {
            SExecute(LocalBridgeClazz, "validateValue", arg0, arg1, arg2);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.1/org/apache/kafka/connect/data/ConnectSchema.html#validateValue-org.apache.kafka.connect.data.Schema-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Connect.Data.Schema"/></param>
        /// <param name="arg1"><see cref="object"/></param>
        public static void ValidateValue(Org.Apache.Kafka.Connect.Data.Schema arg0, object arg1)
        {
            SExecute(LocalBridgeClazz, "validateValue", arg0, arg1);
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.1/org/apache/kafka/connect/data/ConnectSchema.html#isOptional--"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool IsOptional()
        {
            return IExecute<bool>("isOptional");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.1/org/apache/kafka/connect/data/ConnectSchema.html#version--"/>
        /// </summary>

        /// <returns><see cref="Java.Lang.Integer"/></returns>
        public Java.Lang.Integer Version()
        {
            return IExecute<Java.Lang.Integer>("version");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.1/org/apache/kafka/connect/data/ConnectSchema.html#defaultValue--"/>
        /// </summary>

        /// <returns><see cref="object"/></returns>
        public object DefaultValue()
        {
            return IExecute("defaultValue");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.1/org/apache/kafka/connect/data/ConnectSchema.html#doc--"/>
        /// </summary>

        /// <returns><see cref="string"/></returns>
        public string Doc()
        {
            return IExecute<string>("doc");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.1/org/apache/kafka/connect/data/ConnectSchema.html#name--"/>
        /// </summary>

        /// <returns><see cref="string"/></returns>
        public string Name()
        {
            return IExecute<string>("name");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.1/org/apache/kafka/connect/data/ConnectSchema.html#fields--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.List"/></returns>
        public Java.Util.List<Org.Apache.Kafka.Connect.Data.Field> Fields()
        {
            return IExecute<Java.Util.List<Org.Apache.Kafka.Connect.Data.Field>>("fields");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.1/org/apache/kafka/connect/data/ConnectSchema.html#parameters--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Map"/></returns>
        public Java.Util.Map<string, string> Parameters()
        {
            return IExecute<Java.Util.Map<string, string>>("parameters");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.1/org/apache/kafka/connect/data/ConnectSchema.html#field-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Connect.Data.Field"/></returns>
        public Org.Apache.Kafka.Connect.Data.Field Field(string arg0)
        {
            return IExecute<Org.Apache.Kafka.Connect.Data.Field>("field", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.1/org/apache/kafka/connect/data/ConnectSchema.html#keySchema--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Connect.Data.Schema"/></returns>
        public Org.Apache.Kafka.Connect.Data.Schema KeySchema()
        {
            return IExecute<Org.Apache.Kafka.Connect.Data.Schema>("keySchema");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.1/org/apache/kafka/connect/data/ConnectSchema.html#schema--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Connect.Data.Schema"/></returns>
        public Org.Apache.Kafka.Connect.Data.Schema Schema()
        {
            return IExecute<Org.Apache.Kafka.Connect.Data.Schema>("schema");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.1/org/apache/kafka/connect/data/ConnectSchema.html#valueSchema--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Connect.Data.Schema"/></returns>
        public Org.Apache.Kafka.Connect.Data.Schema ValueSchema()
        {
            return IExecute<Org.Apache.Kafka.Connect.Data.Schema>("valueSchema");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.1/org/apache/kafka/connect/data/ConnectSchema.html#type--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Connect.Data.Schema.Type"/></returns>
        public Org.Apache.Kafka.Connect.Data.Schema.Type Type()
        {
            return IExecute<Org.Apache.Kafka.Connect.Data.Schema.Type>("type");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.1/org/apache/kafka/connect/data/ConnectSchema.html#validateValue-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><see cref="object"/></param>
        public void ValidateValue(object arg0)
        {
            IExecute("validateValue", arg0);
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}