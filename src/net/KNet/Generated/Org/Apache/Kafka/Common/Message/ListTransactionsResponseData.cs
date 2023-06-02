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
*  using kafka-clients-3.4.0.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Common.Message
{
    #region ListTransactionsResponseData
    public partial class ListTransactionsResponseData
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/ListTransactionsResponseData.html#%3Cinit%3E(org.apache.kafka.common.protocol.Readable,short)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Protocol.Readable"/></param>
        /// <param name="arg1"><see cref="short"/></param>
        public ListTransactionsResponseData(Org.Apache.Kafka.Common.Protocol.Readable arg0, short arg1)
            : base(arg0, arg1)
        {
        }

        #endregion

        #region Class/Interface conversion operators
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Common.Message.ListTransactionsResponseData"/> to <see cref="Org.Apache.Kafka.Common.Protocol.ApiMessage"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Common.Protocol.ApiMessage(Org.Apache.Kafka.Common.Message.ListTransactionsResponseData t) => t.Cast<Org.Apache.Kafka.Common.Protocol.ApiMessage>();

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/ListTransactionsResponseData.html#SCHEMA_0"/>
        /// </summary>
        public static Org.Apache.Kafka.Common.Protocol.Types.Schema SCHEMA_0 { get { return SGetField<Org.Apache.Kafka.Common.Protocol.Types.Schema>(LocalBridgeClazz, "SCHEMA_0"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/ListTransactionsResponseData.html#SCHEMAS"/>
        /// </summary>
        public static Org.Apache.Kafka.Common.Protocol.Types.Schema[] SCHEMAS { get { return SGetFieldArray<Org.Apache.Kafka.Common.Protocol.Types.Schema>(LocalBridgeClazz, "SCHEMAS"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/ListTransactionsResponseData.html#HIGHEST_SUPPORTED_VERSION"/>
        /// </summary>
        public static short HIGHEST_SUPPORTED_VERSION { get { return SGetField<short>(LocalBridgeClazz, "HIGHEST_SUPPORTED_VERSION"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/ListTransactionsResponseData.html#LOWEST_SUPPORTED_VERSION"/>
        /// </summary>
        public static short LOWEST_SUPPORTED_VERSION { get { return SGetField<short>(LocalBridgeClazz, "LOWEST_SUPPORTED_VERSION"); } }

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/ListTransactionsResponseData.html#throttleTimeMs()"/>
        /// </summary>

        /// <returns><see cref="int"/></returns>
        public int ThrottleTimeMs()
        {
            return IExecute<int>("throttleTimeMs");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/ListTransactionsResponseData.html#unknownStateFilters()"/>
        /// </summary>

        /// <returns><see cref="Java.Util.List"/></returns>
        public Java.Util.List<string> UnknownStateFilters()
        {
            return IExecute<Java.Util.List<string>>("unknownStateFilters");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/ListTransactionsResponseData.html#transactionStates()"/>
        /// </summary>

        /// <returns><see cref="Java.Util.List"/></returns>
        public Java.Util.List<Org.Apache.Kafka.Common.Message.ListTransactionsResponseData.TransactionState> TransactionStates()
        {
            return IExecute<Java.Util.List<Org.Apache.Kafka.Common.Message.ListTransactionsResponseData.TransactionState>>("transactionStates");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/ListTransactionsResponseData.html#unknownTaggedFields()"/>
        /// </summary>

        /// <returns><see cref="Java.Util.List"/></returns>
        public Java.Util.List<Org.Apache.Kafka.Common.Protocol.Types.RawTaggedField> UnknownTaggedFields()
        {
            return IExecute<Java.Util.List<Org.Apache.Kafka.Common.Protocol.Types.RawTaggedField>>("unknownTaggedFields");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/ListTransactionsResponseData.html#setErrorCode(short)"/>
        /// </summary>
        /// <param name="arg0"><see cref="short"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Message.ListTransactionsResponseData"/></returns>
        public Org.Apache.Kafka.Common.Message.ListTransactionsResponseData SetErrorCode(short arg0)
        {
            return IExecute<Org.Apache.Kafka.Common.Message.ListTransactionsResponseData>("setErrorCode", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/ListTransactionsResponseData.html#setThrottleTimeMs(int)"/>
        /// </summary>
        /// <param name="arg0"><see cref="int"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Message.ListTransactionsResponseData"/></returns>
        public Org.Apache.Kafka.Common.Message.ListTransactionsResponseData SetThrottleTimeMs(int arg0)
        {
            return IExecute<Org.Apache.Kafka.Common.Message.ListTransactionsResponseData>("setThrottleTimeMs", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/ListTransactionsResponseData.html#setTransactionStates(java.util.List)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.List"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Message.ListTransactionsResponseData"/></returns>
        public Org.Apache.Kafka.Common.Message.ListTransactionsResponseData SetTransactionStates(Java.Util.List<Org.Apache.Kafka.Common.Message.ListTransactionsResponseData.TransactionState> arg0)
        {
            return IExecute<Org.Apache.Kafka.Common.Message.ListTransactionsResponseData>("setTransactionStates", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/ListTransactionsResponseData.html#setUnknownStateFilters(java.util.List)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.List"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Message.ListTransactionsResponseData"/></returns>
        public Org.Apache.Kafka.Common.Message.ListTransactionsResponseData SetUnknownStateFilters(Java.Util.List<string> arg0)
        {
            return IExecute<Org.Apache.Kafka.Common.Message.ListTransactionsResponseData>("setUnknownStateFilters", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/ListTransactionsResponseData.html#duplicate()"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Protocol.Message"/></returns>
        public Org.Apache.Kafka.Common.Protocol.Message Duplicate()
        {
            return IExecute<Org.Apache.Kafka.Common.Protocol.Message>("duplicate");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/ListTransactionsResponseData.html#apiKey()"/>
        /// </summary>

        /// <returns><see cref="short"/></returns>
        public short ApiKey()
        {
            return IExecute<short>("apiKey");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/ListTransactionsResponseData.html#errorCode()"/>
        /// </summary>

        /// <returns><see cref="short"/></returns>
        public short ErrorCode()
        {
            return IExecute<short>("errorCode");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/ListTransactionsResponseData.html#highestSupportedVersion()"/>
        /// </summary>

        /// <returns><see cref="short"/></returns>
        public short HighestSupportedVersion()
        {
            return IExecute<short>("highestSupportedVersion");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/ListTransactionsResponseData.html#lowestSupportedVersion()"/>
        /// </summary>

        /// <returns><see cref="short"/></returns>
        public short LowestSupportedVersion()
        {
            return IExecute<short>("lowestSupportedVersion");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/ListTransactionsResponseData.html#addSize(org.apache.kafka.common.protocol.MessageSizeAccumulator,org.apache.kafka.common.protocol.ObjectSerializationCache,short)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Protocol.MessageSizeAccumulator"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Common.Protocol.ObjectSerializationCache"/></param>
        /// <param name="arg2"><see cref="short"/></param>
        public void AddSize(Org.Apache.Kafka.Common.Protocol.MessageSizeAccumulator arg0, Org.Apache.Kafka.Common.Protocol.ObjectSerializationCache arg1, short arg2)
        {
            IExecute("addSize", arg0, arg1, arg2);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/ListTransactionsResponseData.html#read(org.apache.kafka.common.protocol.Readable,short)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Protocol.Readable"/></param>
        /// <param name="arg1"><see cref="short"/></param>
        public void Read(Org.Apache.Kafka.Common.Protocol.Readable arg0, short arg1)
        {
            IExecute("read", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/ListTransactionsResponseData.html#write(org.apache.kafka.common.protocol.Writable,org.apache.kafka.common.protocol.ObjectSerializationCache,short)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Protocol.Writable"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Common.Protocol.ObjectSerializationCache"/></param>
        /// <param name="arg2"><see cref="short"/></param>
        public void Write(Org.Apache.Kafka.Common.Protocol.Writable arg0, Org.Apache.Kafka.Common.Protocol.ObjectSerializationCache arg1, short arg2)
        {
            IExecute("write", arg0, arg1, arg2);
        }

        #endregion

        #region Nested classes
        #region TransactionState
        public partial class TransactionState
        {
            #region Constructors
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/ListTransactionsResponseData.TransactionState.html#%3Cinit%3E(org.apache.kafka.common.protocol.Readable,short)"/>
            /// </summary>
            /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Protocol.Readable"/></param>
            /// <param name="arg1"><see cref="short"/></param>
            public TransactionState(Org.Apache.Kafka.Common.Protocol.Readable arg0, short arg1)
                : base(arg0, arg1)
            {
            }

            #endregion

            #region Class/Interface conversion operators
            /// <summary>
            /// Converter from <see cref="Org.Apache.Kafka.Common.Message.ListTransactionsResponseData.TransactionState"/> to <see cref="Org.Apache.Kafka.Common.Protocol.Message"/>
            /// </summary>
            public static implicit operator Org.Apache.Kafka.Common.Protocol.Message(Org.Apache.Kafka.Common.Message.ListTransactionsResponseData.TransactionState t) => t.Cast<Org.Apache.Kafka.Common.Protocol.Message>();

            #endregion

            #region Fields
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/ListTransactionsResponseData.TransactionState.html#SCHEMA_0"/>
            /// </summary>
            public static Org.Apache.Kafka.Common.Protocol.Types.Schema SCHEMA_0 { get { return SGetField<Org.Apache.Kafka.Common.Protocol.Types.Schema>(LocalBridgeClazz, "SCHEMA_0"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/ListTransactionsResponseData.TransactionState.html#SCHEMAS"/>
            /// </summary>
            public static Org.Apache.Kafka.Common.Protocol.Types.Schema[] SCHEMAS { get { return SGetFieldArray<Org.Apache.Kafka.Common.Protocol.Types.Schema>(LocalBridgeClazz, "SCHEMAS"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/ListTransactionsResponseData.TransactionState.html#HIGHEST_SUPPORTED_VERSION"/>
            /// </summary>
            public static short HIGHEST_SUPPORTED_VERSION { get { return SGetField<short>(LocalBridgeClazz, "HIGHEST_SUPPORTED_VERSION"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/ListTransactionsResponseData.TransactionState.html#LOWEST_SUPPORTED_VERSION"/>
            /// </summary>
            public static short LOWEST_SUPPORTED_VERSION { get { return SGetField<short>(LocalBridgeClazz, "LOWEST_SUPPORTED_VERSION"); } }

            #endregion

            #region Static methods

            #endregion

            #region Instance methods
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/ListTransactionsResponseData.TransactionState.html#transactionalId()"/>
            /// </summary>

            /// <returns><see cref="string"/></returns>
            public string TransactionalId()
            {
                return IExecute<string>("transactionalId");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/ListTransactionsResponseData.TransactionState.html#transactionState()"/>
            /// </summary>

            /// <returns><see cref="string"/></returns>
            public string TransactionStateMethod()
            {
                return IExecute<string>("transactionState");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/ListTransactionsResponseData.TransactionState.html#unknownTaggedFields()"/>
            /// </summary>

            /// <returns><see cref="Java.Util.List"/></returns>
            public Java.Util.List<Org.Apache.Kafka.Common.Protocol.Types.RawTaggedField> UnknownTaggedFields()
            {
                return IExecute<Java.Util.List<Org.Apache.Kafka.Common.Protocol.Types.RawTaggedField>>("unknownTaggedFields");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/ListTransactionsResponseData.TransactionState.html#producerId()"/>
            /// </summary>

            /// <returns><see cref="long"/></returns>
            public long ProducerId()
            {
                return IExecute<long>("producerId");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/ListTransactionsResponseData.TransactionState.html#setProducerId(long)"/>
            /// </summary>
            /// <param name="arg0"><see cref="long"/></param>
            /// <returns><see cref="Org.Apache.Kafka.Common.Message.ListTransactionsResponseData.TransactionState"/></returns>
            public Org.Apache.Kafka.Common.Message.ListTransactionsResponseData.TransactionState SetProducerId(long arg0)
            {
                return IExecute<Org.Apache.Kafka.Common.Message.ListTransactionsResponseData.TransactionState>("setProducerId", arg0);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/ListTransactionsResponseData.TransactionState.html#setTransactionalId(java.lang.String)"/>
            /// </summary>
            /// <param name="arg0"><see cref="string"/></param>
            /// <returns><see cref="Org.Apache.Kafka.Common.Message.ListTransactionsResponseData.TransactionState"/></returns>
            public Org.Apache.Kafka.Common.Message.ListTransactionsResponseData.TransactionState SetTransactionalId(string arg0)
            {
                return IExecute<Org.Apache.Kafka.Common.Message.ListTransactionsResponseData.TransactionState>("setTransactionalId", arg0);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/ListTransactionsResponseData.TransactionState.html#setTransactionState(java.lang.String)"/>
            /// </summary>
            /// <param name="arg0"><see cref="string"/></param>
            /// <returns><see cref="Org.Apache.Kafka.Common.Message.ListTransactionsResponseData.TransactionState"/></returns>
            public Org.Apache.Kafka.Common.Message.ListTransactionsResponseData.TransactionState SetTransactionState(string arg0)
            {
                return IExecute<Org.Apache.Kafka.Common.Message.ListTransactionsResponseData.TransactionState>("setTransactionState", arg0);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/ListTransactionsResponseData.TransactionState.html#duplicate()"/>
            /// </summary>

            /// <returns><see cref="Org.Apache.Kafka.Common.Protocol.Message"/></returns>
            public Org.Apache.Kafka.Common.Protocol.Message Duplicate()
            {
                return IExecute<Org.Apache.Kafka.Common.Protocol.Message>("duplicate");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/ListTransactionsResponseData.TransactionState.html#highestSupportedVersion()"/>
            /// </summary>

            /// <returns><see cref="short"/></returns>
            public short HighestSupportedVersion()
            {
                return IExecute<short>("highestSupportedVersion");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/ListTransactionsResponseData.TransactionState.html#lowestSupportedVersion()"/>
            /// </summary>

            /// <returns><see cref="short"/></returns>
            public short LowestSupportedVersion()
            {
                return IExecute<short>("lowestSupportedVersion");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/ListTransactionsResponseData.TransactionState.html#addSize(org.apache.kafka.common.protocol.MessageSizeAccumulator,org.apache.kafka.common.protocol.ObjectSerializationCache,short)"/>
            /// </summary>
            /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Protocol.MessageSizeAccumulator"/></param>
            /// <param name="arg1"><see cref="Org.Apache.Kafka.Common.Protocol.ObjectSerializationCache"/></param>
            /// <param name="arg2"><see cref="short"/></param>
            public void AddSize(Org.Apache.Kafka.Common.Protocol.MessageSizeAccumulator arg0, Org.Apache.Kafka.Common.Protocol.ObjectSerializationCache arg1, short arg2)
            {
                IExecute("addSize", arg0, arg1, arg2);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/ListTransactionsResponseData.TransactionState.html#read(org.apache.kafka.common.protocol.Readable,short)"/>
            /// </summary>
            /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Protocol.Readable"/></param>
            /// <param name="arg1"><see cref="short"/></param>
            public void Read(Org.Apache.Kafka.Common.Protocol.Readable arg0, short arg1)
            {
                IExecute("read", arg0, arg1);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/ListTransactionsResponseData.TransactionState.html#write(org.apache.kafka.common.protocol.Writable,org.apache.kafka.common.protocol.ObjectSerializationCache,short)"/>
            /// </summary>
            /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Protocol.Writable"/></param>
            /// <param name="arg1"><see cref="Org.Apache.Kafka.Common.Protocol.ObjectSerializationCache"/></param>
            /// <param name="arg2"><see cref="short"/></param>
            public void Write(Org.Apache.Kafka.Common.Protocol.Writable arg0, Org.Apache.Kafka.Common.Protocol.ObjectSerializationCache arg1, short arg2)
            {
                IExecute("write", arg0, arg1, arg2);
            }

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