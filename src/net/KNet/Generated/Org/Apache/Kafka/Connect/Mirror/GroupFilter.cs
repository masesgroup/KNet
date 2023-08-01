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
*  using connect-mirror-3.5.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Connect.Mirror
{
    #region IGroupFilter
    /// <summary>
    /// .NET interface for TO BE DEFINED FROM USER
    /// </summary>
    public partial interface IGroupFilter
    {
        #region Instance methods

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion

    #region GroupFilter
    public partial class GroupFilter : Org.Apache.Kafka.Connect.Mirror.IGroupFilter, Org.Apache.Kafka.Common.IConfigurable, Java.Lang.IAutoCloseable
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Connect.Mirror.GroupFilter"/> to <see cref="Org.Apache.Kafka.Common.Configurable"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Common.Configurable(Org.Apache.Kafka.Connect.Mirror.GroupFilter t) => t.Cast<Org.Apache.Kafka.Common.Configurable>();
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Connect.Mirror.GroupFilter"/> to <see cref="Java.Lang.AutoCloseable"/>
        /// </summary>
        public static implicit operator Java.Lang.AutoCloseable(Org.Apache.Kafka.Connect.Mirror.GroupFilter t) => t.Cast<Java.Lang.AutoCloseable>();

        #endregion

        #region Fields

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.5.1/org/apache/kafka/connect/mirror/GroupFilter.html#shouldReplicateGroup-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="bool"/></returns>
        public bool ShouldReplicateGroup(string arg0)
        {
            return IExecute<bool>("shouldReplicateGroup", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.5.1/org/apache/kafka/connect/mirror/GroupFilter.html#close--"/>
        /// </summary>
        public void Close()
        {
            IExecute("close");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.5.1/org/apache/kafka/connect/mirror/GroupFilter.html#configure-java.util.Map-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Map"/></param>
        public void Configure(Java.Util.Map<string, object> arg0)
        {
            IExecute("configure", arg0);
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}