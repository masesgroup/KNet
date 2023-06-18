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
*  using connect-mirror-client-3.4.0.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Connect.Mirror
{
    #region IReplicationPolicy
    /// <summary>
    /// .NET interface for TO BE DEFINED FROM USER
    /// </summary>
    public partial interface IReplicationPolicy
    {
        #region Instance methods

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion

    #region ReplicationPolicy
    public partial class ReplicationPolicy : Org.Apache.Kafka.Connect.Mirror.IReplicationPolicy
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
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror-client/3.4.0/org/apache/kafka/connect/mirror/ReplicationPolicy.html#formatRemoteTopic(java.lang.String,java.lang.String)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <returns><see cref="string"/></returns>
        public string FormatRemoteTopic(string arg0, string arg1)
        {
            return IExecute<string>("formatRemoteTopic", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror-client/3.4.0/org/apache/kafka/connect/mirror/ReplicationPolicy.html#topicSource(java.lang.String)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="string"/></returns>
        public string TopicSource(string arg0)
        {
            return IExecute<string>("topicSource", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror-client/3.4.0/org/apache/kafka/connect/mirror/ReplicationPolicy.html#upstreamTopic(java.lang.String)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="string"/></returns>
        public string UpstreamTopic(string arg0)
        {
            return IExecute<string>("upstreamTopic", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror-client/3.4.0/org/apache/kafka/connect/mirror/ReplicationPolicy.html#isCheckpointsTopic(java.lang.String)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="bool"/></returns>
        public bool IsCheckpointsTopic(string arg0)
        {
            return IExecute<bool>("isCheckpointsTopic", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror-client/3.4.0/org/apache/kafka/connect/mirror/ReplicationPolicy.html#isHeartbeatsTopic(java.lang.String)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="bool"/></returns>
        public bool IsHeartbeatsTopic(string arg0)
        {
            return IExecute<bool>("isHeartbeatsTopic", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror-client/3.4.0/org/apache/kafka/connect/mirror/ReplicationPolicy.html#isInternalTopic(java.lang.String)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="bool"/></returns>
        public bool IsInternalTopic(string arg0)
        {
            return IExecute<bool>("isInternalTopic", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror-client/3.4.0/org/apache/kafka/connect/mirror/ReplicationPolicy.html#isMM2InternalTopic(java.lang.String)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="bool"/></returns>
        public bool IsMM2InternalTopic(string arg0)
        {
            return IExecute<bool>("isMM2InternalTopic", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror-client/3.4.0/org/apache/kafka/connect/mirror/ReplicationPolicy.html#checkpointsTopic(java.lang.String)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="string"/></returns>
        public string CheckpointsTopic(string arg0)
        {
            return IExecute<string>("checkpointsTopic", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror-client/3.4.0/org/apache/kafka/connect/mirror/ReplicationPolicy.html#heartbeatsTopic()"/>
        /// </summary>

        /// <returns><see cref="string"/></returns>
        public string HeartbeatsTopic()
        {
            return IExecute<string>("heartbeatsTopic");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror-client/3.4.0/org/apache/kafka/connect/mirror/ReplicationPolicy.html#offsetSyncsTopic(java.lang.String)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="string"/></returns>
        public string OffsetSyncsTopic(string arg0)
        {
            return IExecute<string>("offsetSyncsTopic", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror-client/3.4.0/org/apache/kafka/connect/mirror/ReplicationPolicy.html#originalTopic(java.lang.String)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="string"/></returns>
        public string OriginalTopic(string arg0)
        {
            return IExecute<string>("originalTopic", arg0);
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}