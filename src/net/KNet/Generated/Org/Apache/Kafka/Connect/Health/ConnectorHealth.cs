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
*  using connect-api-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Connect.Health
{
    #region ConnectorHealth
    public partial class ConnectorHealth
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.1/org/apache/kafka/connect/health/ConnectorHealth.html#org.apache.kafka.connect.health.ConnectorHealth(java.lang.String,org.apache.kafka.connect.health.ConnectorState,java.util.Map,org.apache.kafka.connect.health.ConnectorType)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Connect.Health.ConnectorState"/></param>
        /// <param name="arg2"><see cref="Java.Util.Map"/></param>
        /// <param name="arg3"><see cref="Org.Apache.Kafka.Connect.Health.ConnectorType"/></param>
        public ConnectorHealth(Java.Lang.String arg0, Org.Apache.Kafka.Connect.Health.ConnectorState arg1, Java.Util.Map<Java.Lang.Integer, Org.Apache.Kafka.Connect.Health.TaskState> arg2, Org.Apache.Kafka.Connect.Health.ConnectorType arg3)
            : base(arg0, arg1, arg2, arg3)
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
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.1/org/apache/kafka/connect/health/ConnectorHealth.html#name--"/>
        /// </summary>

        /// <returns><see cref="Java.Lang.String"/></returns>
        public Java.Lang.String Name()
        {
            return IExecuteWithSignature<Java.Lang.String>("name", "()Ljava/lang/String;");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.1/org/apache/kafka/connect/health/ConnectorHealth.html#tasksState--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Map"/></returns>
        public Java.Util.Map<Java.Lang.Integer, Org.Apache.Kafka.Connect.Health.TaskState> TasksState()
        {
            return IExecuteWithSignature<Java.Util.Map<Java.Lang.Integer, Org.Apache.Kafka.Connect.Health.TaskState>>("tasksState", "()Ljava/util/Map;");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.1/org/apache/kafka/connect/health/ConnectorHealth.html#connectorState--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Connect.Health.ConnectorState"/></returns>
        public Org.Apache.Kafka.Connect.Health.ConnectorState ConnectorState()
        {
            return IExecuteWithSignature<Org.Apache.Kafka.Connect.Health.ConnectorState>("connectorState", "()Lorg/apache/kafka/connect/health/ConnectorState;");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.1/org/apache/kafka/connect/health/ConnectorHealth.html#type--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Connect.Health.ConnectorType"/></returns>
        public Org.Apache.Kafka.Connect.Health.ConnectorType Type()
        {
            return IExecuteWithSignature<Org.Apache.Kafka.Connect.Health.ConnectorType>("type", "()Lorg/apache/kafka/connect/health/ConnectorType;");
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}