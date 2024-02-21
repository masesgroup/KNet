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
*  This file is generated by MASES.JNetReflector (ver. 2.2.5.0)
*  using kafka_2.13-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Kafka.Admin
{
    #region LeaderElectionCommand
    public partial class LeaderElectionCommand
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/LeaderElectionCommand.html#isDebugEnabled--"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public static bool IsDebugEnabled()
        {
            return SExecute<bool>(LocalBridgeClazz, "isDebugEnabled");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/LeaderElectionCommand.html#isTraceEnabled--"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public static bool IsTraceEnabled()
        {
            return SExecute<bool>(LocalBridgeClazz, "isTraceEnabled");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.1/kafka/admin/LeaderElectionCommand.html#main-java.lang.String[]-"/>
        /// </summary>
        /// <param name="args"><see cref="Java.Lang.String"/></param>
        public static void Main(Java.Lang.String[] args)
        {
            SExecute(LocalBridgeClazz, "main", new object[] { args });
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