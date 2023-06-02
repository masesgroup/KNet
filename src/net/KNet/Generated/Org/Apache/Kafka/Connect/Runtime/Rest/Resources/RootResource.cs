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
*  This file is generated by MASES.JNetReflector (ver. 1.5.5.0)
*  using connect-runtime-3.4.0.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Connect.Runtime.Rest.Resources
{
    #region RootResource
    public partial class RootResource
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/rest/resources/RootResource.html#%3Cinit%3E(org.apache.kafka.connect.runtime.Herder)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Connect.Runtime.Herder"/></param>
        public RootResource(Org.Apache.Kafka.Connect.Runtime.Herder arg0)
            : base(arg0)
        {
        }

        #endregion

        #region Class/Interface conversion operators
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Connect.Runtime.Rest.Resources.RootResource"/> to <see cref="Org.Apache.Kafka.Connect.Runtime.Rest.Resources.ConnectResource"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Connect.Runtime.Rest.Resources.ConnectResource(Org.Apache.Kafka.Connect.Runtime.Rest.Resources.RootResource t) => t.Cast<Org.Apache.Kafka.Connect.Runtime.Rest.Resources.ConnectResource>();

        #endregion

        #region Fields

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/rest/resources/RootResource.html#serverInfo()"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Connect.Runtime.Rest.Entities.ServerInfo"/></returns>
        public Org.Apache.Kafka.Connect.Runtime.Rest.Entities.ServerInfo ServerInfo()
        {
            return IExecute<Org.Apache.Kafka.Connect.Runtime.Rest.Entities.ServerInfo>("serverInfo");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/rest/resources/RootResource.html#requestTimeout(long)"/>
        /// </summary>
        /// <param name="arg0"><see cref="long"/></param>
        public void RequestTimeout(long arg0)
        {
            IExecute("requestTimeout", arg0);
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}