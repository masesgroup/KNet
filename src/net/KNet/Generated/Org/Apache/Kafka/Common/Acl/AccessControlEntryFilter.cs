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
*  using kafka-clients-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Common.Acl
{
    #region AccessControlEntryFilter
    public partial class AccessControlEntryFilter
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/acl/AccessControlEntryFilter.html#org.apache.kafka.common.acl.AccessControlEntryFilter(java.lang.String,java.lang.String,org.apache.kafka.common.acl.AclOperation,org.apache.kafka.common.acl.AclPermissionType)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Common.Acl.AclOperation"/></param>
        /// <param name="arg3"><see cref="Org.Apache.Kafka.Common.Acl.AclPermissionType"/></param>
        public AccessControlEntryFilter(string arg0, string arg1, Org.Apache.Kafka.Common.Acl.AclOperation arg2, Org.Apache.Kafka.Common.Acl.AclPermissionType arg3)
            : base(arg0, arg1, arg2, arg3)
        {
        }

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/acl/AccessControlEntryFilter.html#ANY"/>
        /// </summary>
        public static Org.Apache.Kafka.Common.Acl.AccessControlEntryFilter ANY { get { return SGetField<Org.Apache.Kafka.Common.Acl.AccessControlEntryFilter>(LocalBridgeClazz, "ANY"); } }

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/acl/AccessControlEntryFilter.html#isUnknown--"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool IsUnknown()
        {
            return IExecute<bool>("isUnknown");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/acl/AccessControlEntryFilter.html#matches-org.apache.kafka.common.acl.AccessControlEntry-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Acl.AccessControlEntry"/></param>
        /// <returns><see cref="bool"/></returns>
        public bool Matches(Org.Apache.Kafka.Common.Acl.AccessControlEntry arg0)
        {
            return IExecute<bool>("matches", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/acl/AccessControlEntryFilter.html#matchesAtMostOne--"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool MatchesAtMostOne()
        {
            return IExecute<bool>("matchesAtMostOne");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/acl/AccessControlEntryFilter.html#findIndefiniteField--"/>
        /// </summary>

        /// <returns><see cref="string"/></returns>
        public string FindIndefiniteField()
        {
            return IExecute<string>("findIndefiniteField");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/acl/AccessControlEntryFilter.html#host--"/>
        /// </summary>

        /// <returns><see cref="string"/></returns>
        public string Host()
        {
            return IExecute<string>("host");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/acl/AccessControlEntryFilter.html#principal--"/>
        /// </summary>

        /// <returns><see cref="string"/></returns>
        public string Principal()
        {
            return IExecute<string>("principal");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/acl/AccessControlEntryFilter.html#operation--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Acl.AclOperation"/></returns>
        public Org.Apache.Kafka.Common.Acl.AclOperation Operation()
        {
            return IExecute<Org.Apache.Kafka.Common.Acl.AclOperation>("operation");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/acl/AccessControlEntryFilter.html#permissionType--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Acl.AclPermissionType"/></returns>
        public Org.Apache.Kafka.Common.Acl.AclPermissionType PermissionType()
        {
            return IExecute<Org.Apache.Kafka.Common.Acl.AclPermissionType>("permissionType");
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}