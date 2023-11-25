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
*  This file is generated by MASES.JNetReflector (ver. 2.1.0.0)
*  using kafka-streams-3.6.0.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Streams.Processor
{
    #region To
    public partial class To
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.0/org/apache/kafka/streams/processor/To.html#all--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Streams.Processor.To"/></returns>
        public static Org.Apache.Kafka.Streams.Processor.To All()
        {
            return SExecute<Org.Apache.Kafka.Streams.Processor.To>(LocalBridgeClazz, "all");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.0/org/apache/kafka/streams/processor/To.html#child-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Processor.To"/></returns>
        public static Org.Apache.Kafka.Streams.Processor.To Child(string arg0)
        {
            return SExecute<Org.Apache.Kafka.Streams.Processor.To>(LocalBridgeClazz, "child", arg0);
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.0/org/apache/kafka/streams/processor/To.html#withTimestamp-long-"/>
        /// </summary>
        /// <param name="arg0"><see cref="long"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Processor.To"/></returns>
        public Org.Apache.Kafka.Streams.Processor.To WithTimestamp(long arg0)
        {
            return IExecute<Org.Apache.Kafka.Streams.Processor.To>("withTimestamp", arg0);
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}