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
    #region TopicDescription
    public partial class TopicDescription
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/TopicDescription.html#org.apache.kafka.clients.admin.TopicDescription(java.lang.String,boolean,java.util.List,java.util.Set,org.apache.kafka.common.Uuid)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <param name="arg1"><see cref="bool"/></param>
        /// <param name="arg2"><see cref="Java.Util.List"/></param>
        /// <param name="arg3"><see cref="Java.Util.Set"/></param>
        /// <param name="arg4"><see cref="Org.Apache.Kafka.Common.Uuid"/></param>
        public TopicDescription(Java.Lang.String arg0, bool arg1, Java.Util.List<Org.Apache.Kafka.Common.TopicPartitionInfo> arg2, Java.Util.Set<Org.Apache.Kafka.Common.Acl.AclOperation> arg3, Org.Apache.Kafka.Common.Uuid arg4)
            : base(arg0, arg1, arg2, arg3, arg4)
        {
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/TopicDescription.html#org.apache.kafka.clients.admin.TopicDescription(java.lang.String,boolean,java.util.List,java.util.Set)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <param name="arg1"><see cref="bool"/></param>
        /// <param name="arg2"><see cref="Java.Util.List"/></param>
        /// <param name="arg3"><see cref="Java.Util.Set"/></param>
        public TopicDescription(Java.Lang.String arg0, bool arg1, Java.Util.List<Org.Apache.Kafka.Common.TopicPartitionInfo> arg2, Java.Util.Set<Org.Apache.Kafka.Common.Acl.AclOperation> arg3)
            : base(arg0, arg1, arg2, arg3)
        {
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/TopicDescription.html#org.apache.kafka.clients.admin.TopicDescription(java.lang.String,boolean,java.util.List)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <param name="arg1"><see cref="bool"/></param>
        /// <param name="arg2"><see cref="Java.Util.List"/></param>
        public TopicDescription(Java.Lang.String arg0, bool arg1, Java.Util.List<Org.Apache.Kafka.Common.TopicPartitionInfo> arg2)
            : base(arg0, arg1, arg2)
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
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/TopicDescription.html#isInternal--"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool IsInternal()
        {
            return IExecuteWithSignature<bool>("isInternal", "()Z");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/TopicDescription.html#name--"/>
        /// </summary>

        /// <returns><see cref="Java.Lang.String"/></returns>
        public Java.Lang.String Name()
        {
            return IExecuteWithSignature<Java.Lang.String>("name", "()Ljava/lang/String;");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/TopicDescription.html#partitions--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.List"/></returns>
        public Java.Util.List<Org.Apache.Kafka.Common.TopicPartitionInfo> Partitions()
        {
            return IExecuteWithSignature<Java.Util.List<Org.Apache.Kafka.Common.TopicPartitionInfo>>("partitions", "()Ljava/util/List;");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/TopicDescription.html#authorizedOperations--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Set"/></returns>
        public Java.Util.Set<Org.Apache.Kafka.Common.Acl.AclOperation> AuthorizedOperations()
        {
            return IExecuteWithSignature<Java.Util.Set<Org.Apache.Kafka.Common.Acl.AclOperation>>("authorizedOperations", "()Ljava/util/Set;");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/clients/admin/TopicDescription.html#topicId--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Uuid"/></returns>
        public Org.Apache.Kafka.Common.Uuid TopicId()
        {
            return IExecuteWithSignature<Org.Apache.Kafka.Common.Uuid>("topicId", "()Lorg/apache/kafka/common/Uuid;");
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}