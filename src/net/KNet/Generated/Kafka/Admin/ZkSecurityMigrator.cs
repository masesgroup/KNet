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
*  using kafka_2.13-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Kafka.Admin
{
    #region ZkSecurityMigrator
    public partial class ZkSecurityMigrator
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/ZkSecurityMigrator.html#tlsConfigFileOption--"/>
        /// </summary>

        /// <returns><see cref="Java.Lang.String"/></returns>
        public static Java.Lang.String TlsConfigFileOption()
        {
            return SExecuteWithSignature<Java.Lang.String>(LocalBridgeClazz, "tlsConfigFileOption", "()Ljava/lang/String;");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/ZkSecurityMigrator.html#usageMessage--"/>
        /// </summary>

        /// <returns><see cref="Java.Lang.String"/></returns>
        public static Java.Lang.String UsageMessage()
        {
            return SExecuteWithSignature<Java.Lang.String>(LocalBridgeClazz, "usageMessage", "()Ljava/lang/String;");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/ZkSecurityMigrator.html#main-java.lang.String[]-"/>
        /// </summary>
        /// <param name="args"><see cref="Java.Lang.String"/></param>
        public static void Main(Java.Lang.String[] args)
        {
            SExecuteWithSignature(LocalBridgeClazz, "main", "([Ljava/lang/String;)V", new object[] { args });
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/ZkSecurityMigrator.html#run-java.lang.String[]-"/>
        /// </summary>
        /// <param name="args"><see cref="Java.Lang.String"/></param>
        public static void Run(Java.Lang.String[] args)
        {
            SExecuteWithSignature(LocalBridgeClazz, "run", "([Ljava/lang/String;)V", new object[] { args });
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/ZkSecurityMigrator.html#isDebugEnabled--"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool IsDebugEnabled()
        {
            return IExecuteWithSignature<bool>("isDebugEnabled", "()Z");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/ZkSecurityMigrator.html#isTraceEnabled--"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool IsTraceEnabled()
        {
            return IExecuteWithSignature<bool>("isTraceEnabled", "()Z");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/ZkSecurityMigrator.html#loggerName--"/>
        /// </summary>

        /// <returns><see cref="Java.Lang.String"/></returns>
        public Java.Lang.String LoggerName()
        {
            return IExecuteWithSignature<Java.Lang.String>("loggerName", "()Ljava/lang/String;");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/ZkSecurityMigrator.html#logIdent--"/>
        /// </summary>

        /// <returns><see cref="Java.Lang.String"/></returns>
        public Java.Lang.String LogIdent()
        {
            return IExecuteWithSignature<Java.Lang.String>("logIdent", "()Ljava/lang/String;");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/ZkSecurityMigrator.html#msgWithLogIdent-java.lang.String-"/>
        /// </summary>
        /// <param name="msg"><see cref="Java.Lang.String"/></param>
        /// <returns><see cref="Java.Lang.String"/></returns>
        public Java.Lang.String MsgWithLogIdent(Java.Lang.String msg)
        {
            return IExecuteWithSignature<Java.Lang.String>("msgWithLogIdent", "(Ljava/lang/String;)Ljava/lang/String;", msg);
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}