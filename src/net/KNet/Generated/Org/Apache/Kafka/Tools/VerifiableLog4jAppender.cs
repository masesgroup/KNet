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
*  This file is generated by MASES.JNetReflector (ver. 2.1.0.0)
*  using kafka-tools-3.6.0.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Tools
{
    #region VerifiableLog4jAppender
    public partial class VerifiableLog4jAppender
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-tools/3.6.0/org/apache/kafka/tools/VerifiableLog4jAppender.html#org.apache.kafka.tools.VerifiableLog4jAppender(java.util.Properties,int)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Properties"/></param>
        /// <param name="arg1"><see cref="int"/></param>
        public VerifiableLog4jAppender(Java.Util.Properties arg0, int arg1)
            : base(arg0, arg1)
        {
        }

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-tools/3.6.0/org/apache/kafka/tools/VerifiableLog4jAppender.html#loadProps-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="Java.Util.Properties"/></returns>
        /// <exception cref="Java.Io.IOException"/>
        public static Java.Util.Properties LoadProps(string arg0)
        {
            return SExecute<Java.Util.Properties>(LocalBridgeClazz, "loadProps", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-tools/3.6.0/org/apache/kafka/tools/VerifiableLog4jAppender.html#createFromArgs-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Tools.VerifiableLog4jAppender"/></returns>
        public static Org.Apache.Kafka.Tools.VerifiableLog4jAppender CreateFromArgs(string[] arg0)
        {
            return SExecute<Org.Apache.Kafka.Tools.VerifiableLog4jAppender>(LocalBridgeClazz, "createFromArgs", new object[] { arg0 });
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-tools/3.6.0/org/apache/kafka/tools/VerifiableLog4jAppender.html#main-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        public static void Main(string[] arg0)
        {
            SExecute(LocalBridgeClazz, "main", new object[] { arg0 });
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