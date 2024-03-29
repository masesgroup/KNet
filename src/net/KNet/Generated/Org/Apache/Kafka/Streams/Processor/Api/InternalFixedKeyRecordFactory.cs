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
*  using kafka-streams-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Streams.Processor.Api
{
    #region InternalFixedKeyRecordFactory
    public partial class InternalFixedKeyRecordFactory
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/processor/api/InternalFixedKeyRecordFactory.html#create-org.apache.kafka.streams.processor.api.Record-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Processor.Api.Record"/></param>
        /// <typeparam name="KIn"></typeparam>
        /// <typeparam name="VIn"></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Processor.Api.FixedKeyRecord"/></returns>
        public static Org.Apache.Kafka.Streams.Processor.Api.FixedKeyRecord<KIn, VIn> Create<KIn, VIn>(Org.Apache.Kafka.Streams.Processor.Api.Record<KIn, VIn> arg0)
        {
            return SExecute<Org.Apache.Kafka.Streams.Processor.Api.FixedKeyRecord<KIn, VIn>>(LocalBridgeClazz, "create", arg0);
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