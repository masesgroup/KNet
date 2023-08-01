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
*  using connect-api-3.5.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Connect.Data
{
    #region Struct
    public partial class Struct
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.5.1/org/apache/kafka/connect/data/Struct.html#org.apache.kafka.connect.data.Struct(org.apache.kafka.connect.data.Schema)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Connect.Data.Schema"/></param>
        public Struct(Org.Apache.Kafka.Connect.Data.Schema arg0)
            : base(arg0)
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
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.5.1/org/apache/kafka/connect/data/Struct.html#getMap-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <returns><see cref="Java.Util.Map"/></returns>
        public Java.Util.Map<K, V> GetMap<K, V>(string arg0)
        {
            return IExecute<Java.Util.Map<K, V>>("getMap", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.5.1/org/apache/kafka/connect/data/Struct.html#getArray-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <typeparam name="T"></typeparam>
        /// <returns><see cref="Java.Util.List"/></returns>
        public Java.Util.List<T> GetArray<T>(string arg0)
        {
            return IExecute<Java.Util.List<T>>("getArray", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.5.1/org/apache/kafka/connect/data/Struct.html#getBytes-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="byte"/></returns>
        public byte[] GetBytes(string arg0)
        {
            return IExecuteArray<byte>("getBytes", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.5.1/org/apache/kafka/connect/data/Struct.html#getBoolean-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="Java.Lang.Boolean"/></returns>
        public Java.Lang.Boolean GetBoolean(string arg0)
        {
            return IExecute<Java.Lang.Boolean>("getBoolean", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.5.1/org/apache/kafka/connect/data/Struct.html#getInt8-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="Java.Lang.Byte"/></returns>
        public Java.Lang.Byte GetInt8(string arg0)
        {
            return IExecute<Java.Lang.Byte>("getInt8", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.5.1/org/apache/kafka/connect/data/Struct.html#getFloat64-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="Java.Lang.Double"/></returns>
        public Java.Lang.Double GetFloat64(string arg0)
        {
            return IExecute<Java.Lang.Double>("getFloat64", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.5.1/org/apache/kafka/connect/data/Struct.html#getFloat32-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="Java.Lang.Float"/></returns>
        public Java.Lang.Float GetFloat32(string arg0)
        {
            return IExecute<Java.Lang.Float>("getFloat32", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.5.1/org/apache/kafka/connect/data/Struct.html#getInt32-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="Java.Lang.Integer"/></returns>
        public Java.Lang.Integer GetInt32(string arg0)
        {
            return IExecute<Java.Lang.Integer>("getInt32", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.5.1/org/apache/kafka/connect/data/Struct.html#getInt64-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="Java.Lang.Long"/></returns>
        public Java.Lang.Long GetInt64(string arg0)
        {
            return IExecute<Java.Lang.Long>("getInt64", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.5.1/org/apache/kafka/connect/data/Struct.html#get-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="object"/></returns>
        public object Get(string arg0)
        {
            return IExecute("get", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.5.1/org/apache/kafka/connect/data/Struct.html#get-org.apache.kafka.connect.data.Field-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Connect.Data.Field"/></param>
        /// <returns><see cref="object"/></returns>
        public object Get(Org.Apache.Kafka.Connect.Data.Field arg0)
        {
            return IExecute("get", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.5.1/org/apache/kafka/connect/data/Struct.html#getWithoutDefault-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="object"/></returns>
        public object GetWithoutDefault(string arg0)
        {
            return IExecute("getWithoutDefault", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.5.1/org/apache/kafka/connect/data/Struct.html#getInt16-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="Java.Lang.Short"/></returns>
        public Java.Lang.Short GetInt16(string arg0)
        {
            return IExecute<Java.Lang.Short>("getInt16", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.5.1/org/apache/kafka/connect/data/Struct.html#getString-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="string"/></returns>
        public string GetString(string arg0)
        {
            return IExecute<string>("getString", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.5.1/org/apache/kafka/connect/data/Struct.html#schema--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Connect.Data.Schema"/></returns>
        public Org.Apache.Kafka.Connect.Data.Schema Schema()
        {
            return IExecute<Org.Apache.Kafka.Connect.Data.Schema>("schema");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.5.1/org/apache/kafka/connect/data/Struct.html#getStruct-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Connect.Data.Struct"/></returns>
        public Org.Apache.Kafka.Connect.Data.Struct GetStruct(string arg0)
        {
            return IExecute<Org.Apache.Kafka.Connect.Data.Struct>("getStruct", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.5.1/org/apache/kafka/connect/data/Struct.html#put-java.lang.String-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="object"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Connect.Data.Struct"/></returns>
        public Org.Apache.Kafka.Connect.Data.Struct Put(string arg0, object arg1)
        {
            return IExecute<Org.Apache.Kafka.Connect.Data.Struct>("put", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.5.1/org/apache/kafka/connect/data/Struct.html#put-org.apache.kafka.connect.data.Field-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Connect.Data.Field"/></param>
        /// <param name="arg1"><see cref="object"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Connect.Data.Struct"/></returns>
        public Org.Apache.Kafka.Connect.Data.Struct Put(Org.Apache.Kafka.Connect.Data.Field arg0, object arg1)
        {
            return IExecute<Org.Apache.Kafka.Connect.Data.Struct>("put", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.5.1/org/apache/kafka/connect/data/Struct.html#validate--"/>
        /// </summary>
        public void Validate()
        {
            IExecute("validate");
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}