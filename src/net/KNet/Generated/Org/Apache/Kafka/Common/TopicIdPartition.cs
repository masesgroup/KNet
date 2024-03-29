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

namespace Org.Apache.Kafka.Common
{
    #region TopicIdPartition
    public partial class TopicIdPartition
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/TopicIdPartition.html#org.apache.kafka.common.TopicIdPartition(org.apache.kafka.common.Uuid,int,java.lang.String)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Uuid"/></param>
        /// <param name="arg1"><see cref="int"/></param>
        /// <param name="arg2"><see cref="Java.Lang.String"/></param>
        public TopicIdPartition(Org.Apache.Kafka.Common.Uuid arg0, int arg1, Java.Lang.String arg2)
            : base(arg0, arg1, arg2)
        {
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/TopicIdPartition.html#org.apache.kafka.common.TopicIdPartition(org.apache.kafka.common.Uuid,org.apache.kafka.common.TopicPartition)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Uuid"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Common.TopicPartition"/></param>
        public TopicIdPartition(Org.Apache.Kafka.Common.Uuid arg0, Org.Apache.Kafka.Common.TopicPartition arg1)
            : base(arg0, arg1)
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
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/TopicIdPartition.html#partition--"/>
        /// </summary>

        /// <returns><see cref="int"/></returns>
        public int Partition()
        {
            return IExecuteWithSignature<int>("partition", "()I");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/TopicIdPartition.html#topic--"/>
        /// </summary>

        /// <returns><see cref="Java.Lang.String"/></returns>
        public Java.Lang.String Topic()
        {
            return IExecuteWithSignature<Java.Lang.String>("topic", "()Ljava/lang/String;");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/TopicIdPartition.html#topicPartition--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.TopicPartition"/></returns>
        public Org.Apache.Kafka.Common.TopicPartition TopicPartition()
        {
            return IExecuteWithSignature<Org.Apache.Kafka.Common.TopicPartition>("topicPartition", "()Lorg/apache/kafka/common/TopicPartition;");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/TopicIdPartition.html#topicId--"/>
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