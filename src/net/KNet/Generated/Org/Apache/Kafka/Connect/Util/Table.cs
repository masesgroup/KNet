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
*  using connect-runtime-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Connect.Util
{
    #region Table
    public partial class Table
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
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/Table.html#isEmpty--"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool IsEmpty()
        {
            return IExecuteWithSignature<bool>("isEmpty", "()Z");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/Table.html#remove-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><see cref="object"/></param>
        /// <returns><see cref="Java.Util.Map"/></returns>
        public Java.Util.Map Remove(object arg0)
        {
            return IExecuteWithSignature<Java.Util.Map>("remove", "(Ljava/lang/Object;)Ljava/util/Map;", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/Table.html#row-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><see cref="object"/></param>
        /// <returns><see cref="Java.Util.Map"/></returns>
        public Java.Util.Map Row(object arg0)
        {
            return IExecuteWithSignature<Java.Util.Map>("row", "(Ljava/lang/Object;)Ljava/util/Map;", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/Table.html#get-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><see cref="object"/></param>
        /// <param name="arg1"><see cref="object"/></param>
        /// <returns><see cref="object"/></returns>
        public object Get(object arg0, object arg1)
        {
            return IExecute("get", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/Table.html#put-java.lang.Object-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><see cref="object"/></param>
        /// <param name="arg1"><see cref="object"/></param>
        /// <param name="arg2"><see cref="object"/></param>
        /// <returns><see cref="object"/></returns>
        public object Put(object arg0, object arg1, object arg2)
        {
            return IExecute("put", arg0, arg1, arg2);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/Table.html#remove-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><see cref="object"/></param>
        /// <param name="arg1"><see cref="object"/></param>
        /// <returns><see cref="object"/></returns>
        public object Remove(object arg0, object arg1)
        {
            return IExecute("remove", arg0, arg1);
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion

    #region Table<R, C, V>
    public partial class Table<R, C, V>
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Connect.Util.Table{R, C, V}"/> to <see cref="Org.Apache.Kafka.Connect.Util.Table"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Connect.Util.Table(Org.Apache.Kafka.Connect.Util.Table<R, C, V> t) => t.Cast<Org.Apache.Kafka.Connect.Util.Table>();

        #endregion

        #region Fields

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/Table.html#isEmpty--"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool IsEmpty()
        {
            return IExecuteWithSignature<bool>("isEmpty", "()Z");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/Table.html#remove-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="R"/></param>
        /// <returns><see cref="Java.Util.Map"/></returns>
        public Java.Util.Map<C, V> Remove(R arg0)
        {
            return IExecuteWithSignature<Java.Util.Map<C, V>>("remove", "(Ljava/lang/Object;)Ljava/util/Map;", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/Table.html#row-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="R"/></param>
        /// <returns><see cref="Java.Util.Map"/></returns>
        public Java.Util.Map<C, V> Row(R arg0)
        {
            return IExecuteWithSignature<Java.Util.Map<C, V>>("row", "(Ljava/lang/Object;)Ljava/util/Map;", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/Table.html#get-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="R"/></param>
        /// <param name="arg1"><typeparamref name="C"/></param>
        /// <returns><typeparamref name="V"/></returns>
        public V Get(R arg0, C arg1)
        {
            return IExecute<V>("get", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/Table.html#put-java.lang.Object-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="R"/></param>
        /// <param name="arg1"><typeparamref name="C"/></param>
        /// <param name="arg2"><typeparamref name="V"/></param>
        /// <returns><typeparamref name="V"/></returns>
        public V Put(R arg0, C arg1, V arg2)
        {
            return IExecute<V>("put", arg0, arg1, arg2);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.1/org/apache/kafka/connect/util/Table.html#remove-java.lang.Object-java.lang.Object-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="R"/></param>
        /// <param name="arg1"><typeparamref name="C"/></param>
        /// <returns><typeparamref name="V"/></returns>
        public V Remove(R arg0, C arg1)
        {
            return IExecute<V>("remove", arg0, arg1);
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}