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
    #region Values
    public partial class Values
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.1/org/apache/kafka/connect/data/Values.html#convertToBoolean-org.apache.kafka.connect.data.Schema-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Connect.Data.Schema"/></param>
        /// <param name="arg1"><see cref="object"/></param>
        /// <returns><see cref="Java.Lang.Boolean"/></returns>
        /// <exception cref="Org.Apache.Kafka.Connect.Errors.DataException"/>
        public static Java.Lang.Boolean ConvertToBoolean(Org.Apache.Kafka.Connect.Data.Schema arg0, object arg1)
        {
            return SExecute<Java.Lang.Boolean>(LocalBridgeClazz, "convertToBoolean", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.1/org/apache/kafka/connect/data/Values.html#convertToByte-org.apache.kafka.connect.data.Schema-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Connect.Data.Schema"/></param>
        /// <param name="arg1"><see cref="object"/></param>
        /// <returns><see cref="Java.Lang.Byte"/></returns>
        /// <exception cref="Org.Apache.Kafka.Connect.Errors.DataException"/>
        public static Java.Lang.Byte ConvertToByte(Org.Apache.Kafka.Connect.Data.Schema arg0, object arg1)
        {
            return SExecute<Java.Lang.Byte>(LocalBridgeClazz, "convertToByte", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.1/org/apache/kafka/connect/data/Values.html#convertToDouble-org.apache.kafka.connect.data.Schema-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Connect.Data.Schema"/></param>
        /// <param name="arg1"><see cref="object"/></param>
        /// <returns><see cref="Java.Lang.Double"/></returns>
        /// <exception cref="Org.Apache.Kafka.Connect.Errors.DataException"/>
        public static Java.Lang.Double ConvertToDouble(Org.Apache.Kafka.Connect.Data.Schema arg0, object arg1)
        {
            return SExecute<Java.Lang.Double>(LocalBridgeClazz, "convertToDouble", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.1/org/apache/kafka/connect/data/Values.html#convertToFloat-org.apache.kafka.connect.data.Schema-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Connect.Data.Schema"/></param>
        /// <param name="arg1"><see cref="object"/></param>
        /// <returns><see cref="Java.Lang.Float"/></returns>
        /// <exception cref="Org.Apache.Kafka.Connect.Errors.DataException"/>
        public static Java.Lang.Float ConvertToFloat(Org.Apache.Kafka.Connect.Data.Schema arg0, object arg1)
        {
            return SExecute<Java.Lang.Float>(LocalBridgeClazz, "convertToFloat", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.1/org/apache/kafka/connect/data/Values.html#convertToInteger-org.apache.kafka.connect.data.Schema-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Connect.Data.Schema"/></param>
        /// <param name="arg1"><see cref="object"/></param>
        /// <returns><see cref="Java.Lang.Integer"/></returns>
        /// <exception cref="Org.Apache.Kafka.Connect.Errors.DataException"/>
        public static Java.Lang.Integer ConvertToInteger(Org.Apache.Kafka.Connect.Data.Schema arg0, object arg1)
        {
            return SExecute<Java.Lang.Integer>(LocalBridgeClazz, "convertToInteger", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.1/org/apache/kafka/connect/data/Values.html#convertToLong-org.apache.kafka.connect.data.Schema-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Connect.Data.Schema"/></param>
        /// <param name="arg1"><see cref="object"/></param>
        /// <returns><see cref="Java.Lang.Long"/></returns>
        /// <exception cref="Org.Apache.Kafka.Connect.Errors.DataException"/>
        public static Java.Lang.Long ConvertToLong(Org.Apache.Kafka.Connect.Data.Schema arg0, object arg1)
        {
            return SExecute<Java.Lang.Long>(LocalBridgeClazz, "convertToLong", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.1/org/apache/kafka/connect/data/Values.html#convertToShort-org.apache.kafka.connect.data.Schema-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Connect.Data.Schema"/></param>
        /// <param name="arg1"><see cref="object"/></param>
        /// <returns><see cref="Java.Lang.Short"/></returns>
        /// <exception cref="Org.Apache.Kafka.Connect.Errors.DataException"/>
        public static Java.Lang.Short ConvertToShort(Org.Apache.Kafka.Connect.Data.Schema arg0, object arg1)
        {
            return SExecute<Java.Lang.Short>(LocalBridgeClazz, "convertToShort", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.1/org/apache/kafka/connect/data/Values.html#convertToString-org.apache.kafka.connect.data.Schema-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Connect.Data.Schema"/></param>
        /// <param name="arg1"><see cref="object"/></param>
        /// <returns><see cref="string"/></returns>
        public static string ConvertToString(Org.Apache.Kafka.Connect.Data.Schema arg0, object arg1)
        {
            return SExecute<string>(LocalBridgeClazz, "convertToString", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.1/org/apache/kafka/connect/data/Values.html#convertToDecimal-org.apache.kafka.connect.data.Schema-java.lang.Object-int-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Connect.Data.Schema"/></param>
        /// <param name="arg1"><see cref="object"/></param>
        /// <param name="arg2"><see cref="int"/></param>
        /// <returns><see cref="Java.Math.BigDecimal"/></returns>
        public static Java.Math.BigDecimal ConvertToDecimal(Org.Apache.Kafka.Connect.Data.Schema arg0, object arg1, int arg2)
        {
            return SExecute<Java.Math.BigDecimal>(LocalBridgeClazz, "convertToDecimal", arg0, arg1, arg2);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.1/org/apache/kafka/connect/data/Values.html#dateFormatFor-java.util.Date-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Date"/></param>
        /// <returns><see cref="Java.Text.DateFormat"/></returns>
        public static Java.Text.DateFormat DateFormatFor(Java.Util.Date arg0)
        {
            return SExecute<Java.Text.DateFormat>(LocalBridgeClazz, "dateFormatFor", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.1/org/apache/kafka/connect/data/Values.html#convertToDate-org.apache.kafka.connect.data.Schema-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Connect.Data.Schema"/></param>
        /// <param name="arg1"><see cref="object"/></param>
        /// <returns><see cref="Java.Util.Date"/></returns>
        public static Java.Util.Date ConvertToDate(Org.Apache.Kafka.Connect.Data.Schema arg0, object arg1)
        {
            return SExecute<Java.Util.Date>(LocalBridgeClazz, "convertToDate", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.1/org/apache/kafka/connect/data/Values.html#convertToTime-org.apache.kafka.connect.data.Schema-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Connect.Data.Schema"/></param>
        /// <param name="arg1"><see cref="object"/></param>
        /// <returns><see cref="Java.Util.Date"/></returns>
        public static Java.Util.Date ConvertToTime(Org.Apache.Kafka.Connect.Data.Schema arg0, object arg1)
        {
            return SExecute<Java.Util.Date>(LocalBridgeClazz, "convertToTime", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.1/org/apache/kafka/connect/data/Values.html#convertToTimestamp-org.apache.kafka.connect.data.Schema-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Connect.Data.Schema"/></param>
        /// <param name="arg1"><see cref="object"/></param>
        /// <returns><see cref="Java.Util.Date"/></returns>
        public static Java.Util.Date ConvertToTimestamp(Org.Apache.Kafka.Connect.Data.Schema arg0, object arg1)
        {
            return SExecute<Java.Util.Date>(LocalBridgeClazz, "convertToTimestamp", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.1/org/apache/kafka/connect/data/Values.html#convertToList-org.apache.kafka.connect.data.Schema-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Connect.Data.Schema"/></param>
        /// <param name="arg1"><see cref="object"/></param>
        /// <returns><see cref="Java.Util.List"/></returns>
        public static Java.Util.List<object> ConvertToList(Org.Apache.Kafka.Connect.Data.Schema arg0, object arg1)
        {
            return SExecute<Java.Util.List<object>>(LocalBridgeClazz, "convertToList", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.1/org/apache/kafka/connect/data/Values.html#convertToMap-org.apache.kafka.connect.data.Schema-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Connect.Data.Schema"/></param>
        /// <param name="arg1"><see cref="object"/></param>
        /// <returns><see cref="Java.Util.Map"/></returns>
        public static Java.Util.Map<object, object> ConvertToMap(Org.Apache.Kafka.Connect.Data.Schema arg0, object arg1)
        {
            return SExecute<Java.Util.Map<object, object>>(LocalBridgeClazz, "convertToMap", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.1/org/apache/kafka/connect/data/Values.html#inferSchema-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><see cref="object"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Connect.Data.Schema"/></returns>
        public static Org.Apache.Kafka.Connect.Data.Schema InferSchema(object arg0)
        {
            return SExecute<Org.Apache.Kafka.Connect.Data.Schema>(LocalBridgeClazz, "inferSchema", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.1/org/apache/kafka/connect/data/Values.html#parseString-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Connect.Data.SchemaAndValue"/></returns>
        public static Org.Apache.Kafka.Connect.Data.SchemaAndValue ParseString(string arg0)
        {
            return SExecute<Org.Apache.Kafka.Connect.Data.SchemaAndValue>(LocalBridgeClazz, "parseString", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.1/org/apache/kafka/connect/data/Values.html#convertToStruct-org.apache.kafka.connect.data.Schema-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Connect.Data.Schema"/></param>
        /// <param name="arg1"><see cref="object"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Connect.Data.Struct"/></returns>
        public static Org.Apache.Kafka.Connect.Data.Struct ConvertToStruct(Org.Apache.Kafka.Connect.Data.Schema arg0, object arg1)
        {
            return SExecute<Org.Apache.Kafka.Connect.Data.Struct>(LocalBridgeClazz, "convertToStruct", arg0, arg1);
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