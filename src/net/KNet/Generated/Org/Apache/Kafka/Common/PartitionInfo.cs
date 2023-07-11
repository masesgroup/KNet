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
*  using kafka-clients-3.5.0.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Common
{
    #region PartitionInfo
    public partial class PartitionInfo
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/PartitionInfo.html#org.apache.kafka.common.PartitionInfo(java.lang.String,int,org.apache.kafka.common.Node,org.apache.kafka.common.Node[],org.apache.kafka.common.Node[],org.apache.kafka.common.Node[])"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="int"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Common.Node"/></param>
        /// <param name="arg3"><see cref="Org.Apache.Kafka.Common.Node"/></param>
        /// <param name="arg4"><see cref="Org.Apache.Kafka.Common.Node"/></param>
        /// <param name="arg5"><see cref="Org.Apache.Kafka.Common.Node"/></param>
        public PartitionInfo(string arg0, int arg1, Org.Apache.Kafka.Common.Node arg2, Org.Apache.Kafka.Common.Node[] arg3, Org.Apache.Kafka.Common.Node[] arg4, Org.Apache.Kafka.Common.Node[] arg5)
            : base(arg0, arg1, arg2, arg3, arg4, arg5)
        {
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/PartitionInfo.html#org.apache.kafka.common.PartitionInfo(java.lang.String,int,org.apache.kafka.common.Node,org.apache.kafka.common.Node[],org.apache.kafka.common.Node[])"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="int"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Common.Node"/></param>
        /// <param name="arg3"><see cref="Org.Apache.Kafka.Common.Node"/></param>
        /// <param name="arg4"><see cref="Org.Apache.Kafka.Common.Node"/></param>
        public PartitionInfo(string arg0, int arg1, Org.Apache.Kafka.Common.Node arg2, Org.Apache.Kafka.Common.Node[] arg3, Org.Apache.Kafka.Common.Node[] arg4)
            : base(arg0, arg1, arg2, arg3, arg4)
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
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/PartitionInfo.html#partition--"/>
        /// </summary>

        /// <returns><see cref="int"/></returns>
        public int Partition()
        {
            return IExecute<int>("partition");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/PartitionInfo.html#topic--"/>
        /// </summary>

        /// <returns><see cref="string"/></returns>
        public string Topic()
        {
            return IExecute<string>("topic");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/PartitionInfo.html#leader--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Node"/></returns>
        public Org.Apache.Kafka.Common.Node Leader()
        {
            return IExecute<Org.Apache.Kafka.Common.Node>("leader");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/PartitionInfo.html#inSyncReplicas--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Node"/></returns>
        public Org.Apache.Kafka.Common.Node[] InSyncReplicas()
        {
            return IExecuteArray<Org.Apache.Kafka.Common.Node>("inSyncReplicas");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/PartitionInfo.html#offlineReplicas--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Node"/></returns>
        public Org.Apache.Kafka.Common.Node[] OfflineReplicas()
        {
            return IExecuteArray<Org.Apache.Kafka.Common.Node>("offlineReplicas");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/PartitionInfo.html#replicas--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Node"/></returns>
        public Org.Apache.Kafka.Common.Node[] Replicas()
        {
            return IExecuteArray<Org.Apache.Kafka.Common.Node>("replicas");
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}