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
*  using kafka-clients-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Clients.Admin
{
    #region DeleteAclsResult
    public partial class DeleteAclsResult
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
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/DeleteAclsResult.html#values--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Map"/></returns>
        public Java.Util.Map<Org.Apache.Kafka.Common.Acl.AclBindingFilter, Org.Apache.Kafka.Common.KafkaFuture<Org.Apache.Kafka.Clients.Admin.DeleteAclsResult.FilterResults>> Values()
        {
            return IExecuteWithSignature<Java.Util.Map<Org.Apache.Kafka.Common.Acl.AclBindingFilter, Org.Apache.Kafka.Common.KafkaFuture<Org.Apache.Kafka.Clients.Admin.DeleteAclsResult.FilterResults>>>("values", "()Ljava/util/Map;");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/DeleteAclsResult.html#all--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.KafkaFuture"/></returns>
        public Org.Apache.Kafka.Common.KafkaFuture<Java.Util.Collection<Org.Apache.Kafka.Common.Acl.AclBinding>> All()
        {
            return IExecuteWithSignature<Org.Apache.Kafka.Common.KafkaFuture<Java.Util.Collection<Org.Apache.Kafka.Common.Acl.AclBinding>>>("all", "()Lorg/apache/kafka/common/KafkaFuture;");
        }

        #endregion

        #region Nested classes
        #region FilterResult
        public partial class FilterResult
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
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/DeleteAclsResult.FilterResult.html#binding--"/>
            /// </summary>

            /// <returns><see cref="Org.Apache.Kafka.Common.Acl.AclBinding"/></returns>
            public Org.Apache.Kafka.Common.Acl.AclBinding Binding()
            {
                return IExecuteWithSignature<Org.Apache.Kafka.Common.Acl.AclBinding>("binding", "()Lorg/apache/kafka/common/acl/AclBinding;");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/DeleteAclsResult.FilterResult.html#exception--"/>
            /// </summary>

            /// <returns><see cref="Org.Apache.Kafka.Common.Errors.ApiException"/></returns>
            public Org.Apache.Kafka.Common.Errors.ApiException Exception()
            {
                var obj = IExecuteWithSignature<MASES.JCOBridge.C2JBridge.JVMInterop.IJavaObject>("exception", "()Lorg/apache/kafka/common/errors/ApiException;"); return MASES.JCOBridge.C2JBridge.JVMBridgeException.New<Org.Apache.Kafka.Common.Errors.ApiException>(obj);
            }

            #endregion

            #region Nested classes

            #endregion

            // TODO: complete the class
        }
        #endregion

        #region FilterResults
        public partial class FilterResults
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
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/DeleteAclsResult.FilterResults.html#values--"/>
            /// </summary>

            /// <returns><see cref="Java.Util.List"/></returns>
            public Java.Util.List<Org.Apache.Kafka.Clients.Admin.DeleteAclsResult.FilterResult> Values()
            {
                return IExecuteWithSignature<Java.Util.List<Org.Apache.Kafka.Clients.Admin.DeleteAclsResult.FilterResult>>("values", "()Ljava/util/List;");
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