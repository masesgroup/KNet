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
*  using kafka-raft-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Raft
{
    #region ValidOffsetAndEpoch
    public partial class ValidOffsetAndEpoch
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.1/org/apache/kafka/raft/ValidOffsetAndEpoch.html#diverging-org.apache.kafka.raft.OffsetAndEpoch-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Raft.OffsetAndEpoch"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Raft.ValidOffsetAndEpoch"/></returns>
        public static Org.Apache.Kafka.Raft.ValidOffsetAndEpoch Diverging(Org.Apache.Kafka.Raft.OffsetAndEpoch arg0)
        {
            return SExecute<Org.Apache.Kafka.Raft.ValidOffsetAndEpoch>(LocalBridgeClazz, "diverging", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.1/org/apache/kafka/raft/ValidOffsetAndEpoch.html#snapshot-org.apache.kafka.raft.OffsetAndEpoch-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Raft.OffsetAndEpoch"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Raft.ValidOffsetAndEpoch"/></returns>
        public static Org.Apache.Kafka.Raft.ValidOffsetAndEpoch Snapshot(Org.Apache.Kafka.Raft.OffsetAndEpoch arg0)
        {
            return SExecute<Org.Apache.Kafka.Raft.ValidOffsetAndEpoch>(LocalBridgeClazz, "snapshot", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.1/org/apache/kafka/raft/ValidOffsetAndEpoch.html#valid--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Raft.ValidOffsetAndEpoch"/></returns>
        public static Org.Apache.Kafka.Raft.ValidOffsetAndEpoch Valid()
        {
            return SExecute<Org.Apache.Kafka.Raft.ValidOffsetAndEpoch>(LocalBridgeClazz, "valid");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.1/org/apache/kafka/raft/ValidOffsetAndEpoch.html#valid-org.apache.kafka.raft.OffsetAndEpoch-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Raft.OffsetAndEpoch"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Raft.ValidOffsetAndEpoch"/></returns>
        public static Org.Apache.Kafka.Raft.ValidOffsetAndEpoch Valid(Org.Apache.Kafka.Raft.OffsetAndEpoch arg0)
        {
            return SExecute<Org.Apache.Kafka.Raft.ValidOffsetAndEpoch>(LocalBridgeClazz, "valid", arg0);
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.1/org/apache/kafka/raft/ValidOffsetAndEpoch.html#offsetAndEpoch--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Raft.OffsetAndEpoch"/></returns>
        public Org.Apache.Kafka.Raft.OffsetAndEpoch OffsetAndEpoch()
        {
            return IExecute<Org.Apache.Kafka.Raft.OffsetAndEpoch>("offsetAndEpoch");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.1/org/apache/kafka/raft/ValidOffsetAndEpoch.html#kind--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Raft.ValidOffsetAndEpoch.Kind"/></returns>
        public Org.Apache.Kafka.Raft.ValidOffsetAndEpoch.Kind KindMethod()
        {
            return IExecute<Org.Apache.Kafka.Raft.ValidOffsetAndEpoch.Kind>("kind");
        }

        #endregion

        #region Nested classes
        #region Kind
        public partial class Kind
        {
            #region Constructors

            #endregion

            #region Class/Interface conversion operators

            #endregion

            #region Fields
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.1/org/apache/kafka/raft/ValidOffsetAndEpoch.Kind.html#DIVERGING"/>
            /// </summary>
            public static Org.Apache.Kafka.Raft.ValidOffsetAndEpoch.Kind DIVERGING { get { return SGetField<Org.Apache.Kafka.Raft.ValidOffsetAndEpoch.Kind>(LocalBridgeClazz, "DIVERGING"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.1/org/apache/kafka/raft/ValidOffsetAndEpoch.Kind.html#SNAPSHOT"/>
            /// </summary>
            public static Org.Apache.Kafka.Raft.ValidOffsetAndEpoch.Kind SNAPSHOT { get { return SGetField<Org.Apache.Kafka.Raft.ValidOffsetAndEpoch.Kind>(LocalBridgeClazz, "SNAPSHOT"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.1/org/apache/kafka/raft/ValidOffsetAndEpoch.Kind.html#VALID"/>
            /// </summary>
            public static Org.Apache.Kafka.Raft.ValidOffsetAndEpoch.Kind VALID { get { return SGetField<Org.Apache.Kafka.Raft.ValidOffsetAndEpoch.Kind>(LocalBridgeClazz, "VALID"); } }

            #endregion

            #region Static methods
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.1/org/apache/kafka/raft/ValidOffsetAndEpoch.Kind.html#valueOf-java.lang.String-"/>
            /// </summary>
            /// <param name="arg0"><see cref="string"/></param>
            /// <returns><see cref="Org.Apache.Kafka.Raft.ValidOffsetAndEpoch.Kind"/></returns>
            public static Org.Apache.Kafka.Raft.ValidOffsetAndEpoch.Kind ValueOf(string arg0)
            {
                return SExecute<Org.Apache.Kafka.Raft.ValidOffsetAndEpoch.Kind>(LocalBridgeClazz, "valueOf", arg0);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.1/org/apache/kafka/raft/ValidOffsetAndEpoch.Kind.html#values--"/>
            /// </summary>

            /// <returns><see cref="Org.Apache.Kafka.Raft.ValidOffsetAndEpoch.Kind"/></returns>
            public static Org.Apache.Kafka.Raft.ValidOffsetAndEpoch.Kind[] Values()
            {
                return SExecuteArray<Org.Apache.Kafka.Raft.ValidOffsetAndEpoch.Kind>(LocalBridgeClazz, "values");
            }

            #endregion

            #region Instance methods

            #endregion

            #region Nested classes

            #endregion

            // TODO: complete the class
        }
        #endregion

    
        #endregion

        // TODO: complete the class
    }
    #endregion
}