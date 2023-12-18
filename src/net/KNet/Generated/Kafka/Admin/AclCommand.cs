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
*  This file is generated by MASES.JNetReflector (ver. 2.1.1.0)
*  using kafka_2.13-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Kafka.Admin
{
    #region AclCommand
    public partial class AclCommand
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/AclCommand.html#isDebugEnabled--"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public static bool IsDebugEnabled()
        {
            return SExecute<bool>(LocalBridgeClazz, "isDebugEnabled");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/AclCommand.html#isTraceEnabled--"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public static bool IsTraceEnabled()
        {
            return SExecute<bool>(LocalBridgeClazz, "isTraceEnabled");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/AclCommand.html#AuthorizerDeprecationMessage--"/>
        /// </summary>

        /// <returns><see cref="string"/></returns>
        public static string AuthorizerDeprecationMessage()
        {
            return SExecute<string>(LocalBridgeClazz, "AuthorizerDeprecationMessage");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/AclCommand.html#ClusterResourceFilter--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Resource.ResourcePatternFilter"/></returns>
        public static Org.Apache.Kafka.Common.Resource.ResourcePatternFilter ClusterResourceFilter()
        {
            return SExecute<Org.Apache.Kafka.Common.Resource.ResourcePatternFilter>(LocalBridgeClazz, "ClusterResourceFilter");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/AclCommand.html#main-java.lang.String[]-"/>
        /// </summary>
        /// <param name="args"><see cref="string"/></param>
        public static void Main(string[] args)
        {
            SExecute(LocalBridgeClazz, "main", new object[] { args });
        }

        #endregion

        #region Instance methods

        #endregion

        #region Nested classes
        #region AclCommandOptions
        public partial class AclCommandOptions
        {
            #region Constructors
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/AclCommand.AclCommandOptions.html#kafka.admin.AclCommand$AclCommandOptions(java.lang.String[])"/>
            /// </summary>
            /// <param name="args"><see cref="string"/></param>
            public AclCommandOptions(string[] args)
                : base(args)
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
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/AclCommand.AclCommandOptions.html#CommandConfigDoc--"/>
            /// </summary>

            /// <returns><see cref="string"/></returns>
            public string CommandConfigDoc()
            {
                return IExecute<string>("CommandConfigDoc");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/AclCommand.AclCommandOptions.html#checkArgs--"/>
            /// </summary>
            public void CheckArgs()
            {
                IExecute("checkArgs");
            }

            #endregion

            #region Nested classes

            #endregion

            // TODO: complete the class
        }
        #endregion

        #region AclCommandService
        public partial class AclCommandService
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
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/AclCommand.AclCommandService.html#addAcls--"/>
            /// </summary>
            public void AddAcls()
            {
                IExecute("addAcls");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/AclCommand.AclCommandService.html#listAcls--"/>
            /// </summary>
            public void ListAcls()
            {
                IExecute("listAcls");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/AclCommand.AclCommandService.html#removeAcls--"/>
            /// </summary>
            public void RemoveAcls()
            {
                IExecute("removeAcls");
            }

            #endregion

            #region Nested classes

            #endregion

            // TODO: complete the class
        }
        #endregion

        #region AdminClientService
        public partial class AdminClientService
        {
            #region Constructors
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/AclCommand.AdminClientService.html#kafka.admin.AclCommand$AdminClientService(kafka.admin.AclCommand.AclCommandOptions)"/>
            /// </summary>
            /// <param name="opts"><see cref="Kafka.Admin.AclCommand.AclCommandOptions"/></param>
            public AdminClientService(Kafka.Admin.AclCommand.AclCommandOptions opts)
                : base(opts)
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
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/AclCommand.AdminClientService.html#isDebugEnabled--"/>
            /// </summary>

            /// <returns><see cref="bool"/></returns>
            public bool IsDebugEnabled()
            {
                return IExecute<bool>("isDebugEnabled");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/AclCommand.AdminClientService.html#isTraceEnabled--"/>
            /// </summary>

            /// <returns><see cref="bool"/></returns>
            public bool IsTraceEnabled()
            {
                return IExecute<bool>("isTraceEnabled");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/AclCommand.AdminClientService.html#loggerName--"/>
            /// </summary>

            /// <returns><see cref="string"/></returns>
            public string LoggerName()
            {
                return IExecute<string>("loggerName");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/AclCommand.AdminClientService.html#logIdent--"/>
            /// </summary>

            /// <returns><see cref="string"/></returns>
            public string LogIdent()
            {
                return IExecute<string>("logIdent");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/AclCommand.AdminClientService.html#msgWithLogIdent-java.lang.String-"/>
            /// </summary>
            /// <param name="msg"><see cref="string"/></param>
            /// <returns><see cref="string"/></returns>
            public string MsgWithLogIdent(string msg)
            {
                return IExecute<string>("msgWithLogIdent", msg);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/AclCommand.AdminClientService.html#opts--"/>
            /// </summary>

            /// <returns><see cref="Kafka.Admin.AclCommand.AclCommandOptions"/></returns>
            public Kafka.Admin.AclCommand.AclCommandOptions Opts()
            {
                return IExecute<Kafka.Admin.AclCommand.AclCommandOptions>("opts");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/AclCommand.AdminClientService.html#addAcls--"/>
            /// </summary>
            public void AddAcls()
            {
                IExecute("addAcls");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/AclCommand.AdminClientService.html#listAcls--"/>
            /// </summary>
            public void ListAcls()
            {
                IExecute("listAcls");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/AclCommand.AdminClientService.html#removeAcls--"/>
            /// </summary>
            public void RemoveAcls()
            {
                IExecute("removeAcls");
            }

            #endregion

            #region Nested classes

            #endregion

            // TODO: complete the class
        }
        #endregion

        #region AuthorizerService
        public partial class AuthorizerService
        {
            #region Constructors
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/AclCommand.AuthorizerService.html#kafka.admin.AclCommand$AuthorizerService(java.lang.String,kafka.admin.AclCommand.AclCommandOptions)"/>
            /// </summary>
            /// <param name="authorizerClassName"><see cref="string"/></param>
            /// <param name="opts"><see cref="Kafka.Admin.AclCommand.AclCommandOptions"/></param>
            public AuthorizerService(string authorizerClassName, Kafka.Admin.AclCommand.AclCommandOptions opts)
                : base(authorizerClassName, opts)
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
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/AclCommand.AuthorizerService.html#isDebugEnabled--"/>
            /// </summary>

            /// <returns><see cref="bool"/></returns>
            public bool IsDebugEnabled()
            {
                return IExecute<bool>("isDebugEnabled");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/AclCommand.AuthorizerService.html#isTraceEnabled--"/>
            /// </summary>

            /// <returns><see cref="bool"/></returns>
            public bool IsTraceEnabled()
            {
                return IExecute<bool>("isTraceEnabled");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/AclCommand.AuthorizerService.html#authorizerClassName--"/>
            /// </summary>

            /// <returns><see cref="string"/></returns>
            public string AuthorizerClassName()
            {
                return IExecute<string>("authorizerClassName");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/AclCommand.AuthorizerService.html#loggerName--"/>
            /// </summary>

            /// <returns><see cref="string"/></returns>
            public string LoggerName()
            {
                return IExecute<string>("loggerName");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/AclCommand.AuthorizerService.html#logIdent--"/>
            /// </summary>

            /// <returns><see cref="string"/></returns>
            public string LogIdent()
            {
                return IExecute<string>("logIdent");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/AclCommand.AuthorizerService.html#msgWithLogIdent-java.lang.String-"/>
            /// </summary>
            /// <param name="msg"><see cref="string"/></param>
            /// <returns><see cref="string"/></returns>
            public string MsgWithLogIdent(string msg)
            {
                return IExecute<string>("msgWithLogIdent", msg);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/AclCommand.AuthorizerService.html#opts--"/>
            /// </summary>

            /// <returns><see cref="Kafka.Admin.AclCommand.AclCommandOptions"/></returns>
            public Kafka.Admin.AclCommand.AclCommandOptions Opts()
            {
                return IExecute<Kafka.Admin.AclCommand.AclCommandOptions>("opts");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/AclCommand.AuthorizerService.html#addAcls--"/>
            /// </summary>
            public void AddAcls()
            {
                IExecute("addAcls");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/AclCommand.AuthorizerService.html#listAcls--"/>
            /// </summary>
            public void ListAcls()
            {
                IExecute("listAcls");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/AclCommand.AuthorizerService.html#removeAcls--"/>
            /// </summary>
            public void RemoveAcls()
            {
                IExecute("removeAcls");
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