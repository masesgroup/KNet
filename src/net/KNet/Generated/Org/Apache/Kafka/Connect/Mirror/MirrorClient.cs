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
*  using connect-mirror-client-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Connect.Mirror
{
    #region MirrorClient
    public partial class MirrorClient
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror-client/3.6.1/org/apache/kafka/connect/mirror/MirrorClient.html#org.apache.kafka.connect.mirror.MirrorClient(java.util.Map)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Map"/></param>
        public MirrorClient(Java.Util.Map<string, object> arg0)
            : base(arg0)
        {
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror-client/3.6.1/org/apache/kafka/connect/mirror/MirrorClient.html#org.apache.kafka.connect.mirror.MirrorClient(org.apache.kafka.connect.mirror.MirrorClientConfig)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Connect.Mirror.MirrorClientConfig"/></param>
        public MirrorClient(Org.Apache.Kafka.Connect.Mirror.MirrorClientConfig arg0)
            : base(arg0)
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
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror-client/3.6.1/org/apache/kafka/connect/mirror/MirrorClient.html#replicationHops-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="int"/></returns>
        /// <exception cref="Java.Lang.InterruptedException"/>
        public int ReplicationHops(string arg0)
        {
            return IExecute<int>("replicationHops", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror-client/3.6.1/org/apache/kafka/connect/mirror/MirrorClient.html#remoteConsumerOffsets-java.lang.String-java.lang.String-java.time.Duration-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <param name="arg2"><see cref="Java.Time.Duration"/></param>
        /// <returns><see cref="Java.Util.Map"/></returns>
        public Java.Util.Map<Org.Apache.Kafka.Common.TopicPartition, Org.Apache.Kafka.Clients.Consumer.OffsetAndMetadata> RemoteConsumerOffsets(string arg0, string arg1, Java.Time.Duration arg2)
        {
            return IExecute<Java.Util.Map<Org.Apache.Kafka.Common.TopicPartition, Org.Apache.Kafka.Clients.Consumer.OffsetAndMetadata>>("remoteConsumerOffsets", arg0, arg1, arg2);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror-client/3.6.1/org/apache/kafka/connect/mirror/MirrorClient.html#checkpointTopics--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Set"/></returns>
        /// <exception cref="Java.Lang.InterruptedException"/>
        public Java.Util.Set<string> CheckpointTopics()
        {
            return IExecute<Java.Util.Set<string>>("checkpointTopics");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror-client/3.6.1/org/apache/kafka/connect/mirror/MirrorClient.html#heartbeatTopics--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Set"/></returns>
        /// <exception cref="Java.Lang.InterruptedException"/>
        public Java.Util.Set<string> HeartbeatTopics()
        {
            return IExecute<Java.Util.Set<string>>("heartbeatTopics");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror-client/3.6.1/org/apache/kafka/connect/mirror/MirrorClient.html#remoteTopics--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Set"/></returns>
        /// <exception cref="Java.Lang.InterruptedException"/>
        public Java.Util.Set<string> RemoteTopics()
        {
            return IExecute<Java.Util.Set<string>>("remoteTopics");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror-client/3.6.1/org/apache/kafka/connect/mirror/MirrorClient.html#remoteTopics-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="Java.Util.Set"/></returns>
        /// <exception cref="Java.Lang.InterruptedException"/>
        public Java.Util.Set<string> RemoteTopics(string arg0)
        {
            return IExecute<Java.Util.Set<string>>("remoteTopics", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror-client/3.6.1/org/apache/kafka/connect/mirror/MirrorClient.html#upstreamClusters--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Set"/></returns>
        /// <exception cref="Java.Lang.InterruptedException"/>
        public Java.Util.Set<string> UpstreamClusters()
        {
            return IExecute<Java.Util.Set<string>>("upstreamClusters");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror-client/3.6.1/org/apache/kafka/connect/mirror/MirrorClient.html#replicationPolicy--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Connect.Mirror.ReplicationPolicy"/></returns>
        public Org.Apache.Kafka.Connect.Mirror.ReplicationPolicy ReplicationPolicy()
        {
            return IExecute<Org.Apache.Kafka.Connect.Mirror.ReplicationPolicy>("replicationPolicy");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-mirror-client/3.6.1/org/apache/kafka/connect/mirror/MirrorClient.html#close--"/>
        /// </summary>
        public void Close()
        {
            IExecute("close");
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}