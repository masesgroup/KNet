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
*  using kafka-clients-3.5.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Common.Record
{
    #region RecordVersion
    public partial class RecordVersion
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/common/record/RecordVersion.html#value"/>
        /// </summary>
        public byte value { get { return IGetField<byte>("value"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/common/record/RecordVersion.html#V0"/>
        /// </summary>
        public static Org.Apache.Kafka.Common.Record.RecordVersion V0 { get { return SGetField<Org.Apache.Kafka.Common.Record.RecordVersion>(LocalBridgeClazz, "V0"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/common/record/RecordVersion.html#V1"/>
        /// </summary>
        public static Org.Apache.Kafka.Common.Record.RecordVersion V1 { get { return SGetField<Org.Apache.Kafka.Common.Record.RecordVersion>(LocalBridgeClazz, "V1"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/common/record/RecordVersion.html#V2"/>
        /// </summary>
        public static Org.Apache.Kafka.Common.Record.RecordVersion V2 { get { return SGetField<Org.Apache.Kafka.Common.Record.RecordVersion>(LocalBridgeClazz, "V2"); } }

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/common/record/RecordVersion.html#current--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Record.RecordVersion"/></returns>
        public static Org.Apache.Kafka.Common.Record.RecordVersion Current()
        {
            return SExecute<Org.Apache.Kafka.Common.Record.RecordVersion>(LocalBridgeClazz, "current");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/common/record/RecordVersion.html#lookup-byte-"/>
        /// </summary>
        /// <param name="arg0"><see cref="byte"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Record.RecordVersion"/></returns>
        public static Org.Apache.Kafka.Common.Record.RecordVersion Lookup(byte arg0)
        {
            return SExecute<Org.Apache.Kafka.Common.Record.RecordVersion>(LocalBridgeClazz, "lookup", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/common/record/RecordVersion.html#valueOf-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Record.RecordVersion"/></returns>
        public static Org.Apache.Kafka.Common.Record.RecordVersion ValueOf(string arg0)
        {
            return SExecute<Org.Apache.Kafka.Common.Record.RecordVersion>(LocalBridgeClazz, "valueOf", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/common/record/RecordVersion.html#values--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Record.RecordVersion"/></returns>
        public static Org.Apache.Kafka.Common.Record.RecordVersion[] Values()
        {
            return SExecuteArray<Org.Apache.Kafka.Common.Record.RecordVersion>(LocalBridgeClazz, "values");
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.1/org/apache/kafka/common/record/RecordVersion.html#precedes-org.apache.kafka.common.record.RecordVersion-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Record.RecordVersion"/></param>
        /// <returns><see cref="bool"/></returns>
        public bool Precedes(Org.Apache.Kafka.Common.Record.RecordVersion arg0)
        {
            return IExecute<bool>("precedes", arg0);
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}