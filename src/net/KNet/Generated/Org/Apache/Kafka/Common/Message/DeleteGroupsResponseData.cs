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
    #region DeleteGroupsResponseData
    public partial class DeleteGroupsResponseData
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/DeleteGroupsResponseData.html#%3Cinit%3E(org.apache.kafka.common.protocol.Readable,short)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Protocol.Readable"/></param>
        /// <param name="arg1"><see cref="short"/></param>
        public DeleteGroupsResponseData(Org.Apache.Kafka.Common.Protocol.Readable arg0, short arg1)
            : base(arg0, arg1)
        {
        }

        #endregion

        #region Class/Interface conversion operators
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Common.Message.DeleteGroupsResponseData"/> to <see cref="Org.Apache.Kafka.Common.Protocol.ApiMessage"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Common.Protocol.ApiMessage(Org.Apache.Kafka.Common.Message.DeleteGroupsResponseData t) => t.Cast<Org.Apache.Kafka.Common.Protocol.ApiMessage>();

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/DeleteGroupsResponseData.html#SCHEMA_0"/>
        /// </summary>
        public static Org.Apache.Kafka.Common.Protocol.Types.Schema SCHEMA_0 { get { return SGetField<Org.Apache.Kafka.Common.Protocol.Types.Schema>(LocalBridgeClazz, "SCHEMA_0"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/DeleteGroupsResponseData.html#SCHEMA_1"/>
        /// </summary>
        public static Org.Apache.Kafka.Common.Protocol.Types.Schema SCHEMA_1 { get { return SGetField<Org.Apache.Kafka.Common.Protocol.Types.Schema>(LocalBridgeClazz, "SCHEMA_1"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/DeleteGroupsResponseData.html#SCHEMA_2"/>
        /// </summary>
        public static Org.Apache.Kafka.Common.Protocol.Types.Schema SCHEMA_2 { get { return SGetField<Org.Apache.Kafka.Common.Protocol.Types.Schema>(LocalBridgeClazz, "SCHEMA_2"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/DeleteGroupsResponseData.html#SCHEMAS"/>
        /// </summary>
        public static Org.Apache.Kafka.Common.Protocol.Types.Schema[] SCHEMAS { get { return SGetFieldArray<Org.Apache.Kafka.Common.Protocol.Types.Schema>(LocalBridgeClazz, "SCHEMAS"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/DeleteGroupsResponseData.html#HIGHEST_SUPPORTED_VERSION"/>
        /// </summary>
        public static short HIGHEST_SUPPORTED_VERSION { get { return SGetField<short>(LocalBridgeClazz, "HIGHEST_SUPPORTED_VERSION"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/DeleteGroupsResponseData.html#LOWEST_SUPPORTED_VERSION"/>
        /// </summary>
        public static short LOWEST_SUPPORTED_VERSION { get { return SGetField<short>(LocalBridgeClazz, "LOWEST_SUPPORTED_VERSION"); } }

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/DeleteGroupsResponseData.html#throttleTimeMs()"/>
        /// </summary>

        /// <returns><see cref="int"/></returns>
        public int ThrottleTimeMs()
        {
            return IExecute<int>("throttleTimeMs");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/DeleteGroupsResponseData.html#unknownTaggedFields()"/>
        /// </summary>

        /// <returns><see cref="Java.Util.List"/></returns>
        public Java.Util.List<Org.Apache.Kafka.Common.Protocol.Types.RawTaggedField> UnknownTaggedFields()
        {
            return IExecute<Java.Util.List<Org.Apache.Kafka.Common.Protocol.Types.RawTaggedField>>("unknownTaggedFields");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/DeleteGroupsResponseData.html#setResults(org.apache.kafka.common.message.DeleteGroupsResponseData.DeletableGroupResultCollection)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Message.DeleteGroupsResponseData.DeletableGroupResultCollection"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Message.DeleteGroupsResponseData"/></returns>
        public Org.Apache.Kafka.Common.Message.DeleteGroupsResponseData SetResults(Org.Apache.Kafka.Common.Message.DeleteGroupsResponseData.DeletableGroupResultCollection arg0)
        {
            return IExecute<Org.Apache.Kafka.Common.Message.DeleteGroupsResponseData>("setResults", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/DeleteGroupsResponseData.html#setThrottleTimeMs(int)"/>
        /// </summary>
        /// <param name="arg0"><see cref="int"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Message.DeleteGroupsResponseData"/></returns>
        public Org.Apache.Kafka.Common.Message.DeleteGroupsResponseData SetThrottleTimeMs(int arg0)
        {
            return IExecute<Org.Apache.Kafka.Common.Message.DeleteGroupsResponseData>("setThrottleTimeMs", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/DeleteGroupsResponseData.html#results()"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Message.DeleteGroupsResponseData.DeletableGroupResultCollection"/></returns>
        public Org.Apache.Kafka.Common.Message.DeleteGroupsResponseData.DeletableGroupResultCollection Results()
        {
            return IExecute<Org.Apache.Kafka.Common.Message.DeleteGroupsResponseData.DeletableGroupResultCollection>("results");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/DeleteGroupsResponseData.html#duplicate()"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Protocol.Message"/></returns>
        public Org.Apache.Kafka.Common.Protocol.Message Duplicate()
        {
            return IExecute<Org.Apache.Kafka.Common.Protocol.Message>("duplicate");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/DeleteGroupsResponseData.html#apiKey()"/>
        /// </summary>

        /// <returns><see cref="short"/></returns>
        public short ApiKey()
        {
            return IExecute<short>("apiKey");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/DeleteGroupsResponseData.html#highestSupportedVersion()"/>
        /// </summary>

        /// <returns><see cref="short"/></returns>
        public short HighestSupportedVersion()
        {
            return IExecute<short>("highestSupportedVersion");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/DeleteGroupsResponseData.html#lowestSupportedVersion()"/>
        /// </summary>

        /// <returns><see cref="short"/></returns>
        public short LowestSupportedVersion()
        {
            return IExecute<short>("lowestSupportedVersion");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/DeleteGroupsResponseData.html#addSize(org.apache.kafka.common.protocol.MessageSizeAccumulator,org.apache.kafka.common.protocol.ObjectSerializationCache,short)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Protocol.MessageSizeAccumulator"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Common.Protocol.ObjectSerializationCache"/></param>
        /// <param name="arg2"><see cref="short"/></param>
        public void AddSize(Org.Apache.Kafka.Common.Protocol.MessageSizeAccumulator arg0, Org.Apache.Kafka.Common.Protocol.ObjectSerializationCache arg1, short arg2)
        {
            IExecute("addSize", arg0, arg1, arg2);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/DeleteGroupsResponseData.html#read(org.apache.kafka.common.protocol.Readable,short)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Protocol.Readable"/></param>
        /// <param name="arg1"><see cref="short"/></param>
        public void Read(Org.Apache.Kafka.Common.Protocol.Readable arg0, short arg1)
        {
            IExecute("read", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/DeleteGroupsResponseData.html#write(org.apache.kafka.common.protocol.Writable,org.apache.kafka.common.protocol.ObjectSerializationCache,short)"/>
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
        #region DeletableGroupResult
        public partial class DeletableGroupResult
        {
            #region Constructors
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/DeleteGroupsResponseData.DeletableGroupResult.html#%3Cinit%3E(org.apache.kafka.common.protocol.Readable,short)"/>
            /// </summary>
            /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Protocol.Readable"/></param>
            /// <param name="arg1"><see cref="short"/></param>
            public DeletableGroupResult(Org.Apache.Kafka.Common.Protocol.Readable arg0, short arg1)
                : base(arg0, arg1)
            {
            }

            #endregion

            #region Class/Interface conversion operators
            /// <summary>
            /// Converter from <see cref="Org.Apache.Kafka.Common.Message.DeleteGroupsResponseData.DeletableGroupResult"/> to <see cref="Org.Apache.Kafka.Common.Protocol.Message"/>
            /// </summary>
            public static implicit operator Org.Apache.Kafka.Common.Protocol.Message(Org.Apache.Kafka.Common.Message.DeleteGroupsResponseData.DeletableGroupResult t) => t.Cast<Org.Apache.Kafka.Common.Protocol.Message>();

            #endregion

            #region Fields
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/DeleteGroupsResponseData.DeletableGroupResult.html#SCHEMA_0"/>
            /// </summary>
            public static Org.Apache.Kafka.Common.Protocol.Types.Schema SCHEMA_0 { get { return SGetField<Org.Apache.Kafka.Common.Protocol.Types.Schema>(LocalBridgeClazz, "SCHEMA_0"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/DeleteGroupsResponseData.DeletableGroupResult.html#SCHEMA_1"/>
            /// </summary>
            public static Org.Apache.Kafka.Common.Protocol.Types.Schema SCHEMA_1 { get { return SGetField<Org.Apache.Kafka.Common.Protocol.Types.Schema>(LocalBridgeClazz, "SCHEMA_1"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/DeleteGroupsResponseData.DeletableGroupResult.html#SCHEMA_2"/>
            /// </summary>
            public static Org.Apache.Kafka.Common.Protocol.Types.Schema SCHEMA_2 { get { return SGetField<Org.Apache.Kafka.Common.Protocol.Types.Schema>(LocalBridgeClazz, "SCHEMA_2"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/DeleteGroupsResponseData.DeletableGroupResult.html#SCHEMAS"/>
            /// </summary>
            public static Org.Apache.Kafka.Common.Protocol.Types.Schema[] SCHEMAS { get { return SGetFieldArray<Org.Apache.Kafka.Common.Protocol.Types.Schema>(LocalBridgeClazz, "SCHEMAS"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/DeleteGroupsResponseData.DeletableGroupResult.html#HIGHEST_SUPPORTED_VERSION"/>
            /// </summary>
            public static short HIGHEST_SUPPORTED_VERSION { get { return SGetField<short>(LocalBridgeClazz, "HIGHEST_SUPPORTED_VERSION"); } }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/DeleteGroupsResponseData.DeletableGroupResult.html#LOWEST_SUPPORTED_VERSION"/>
            /// </summary>
            public static short LOWEST_SUPPORTED_VERSION { get { return SGetField<short>(LocalBridgeClazz, "LOWEST_SUPPORTED_VERSION"); } }

            #endregion

            #region Static methods

            #endregion

            #region Instance methods
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/DeleteGroupsResponseData.DeletableGroupResult.html#elementKeysAreEqual(java.lang.Object)"/>
            /// </summary>
            /// <param name="arg0"><see cref="object"/></param>
            /// <returns><see cref="bool"/></returns>
            public bool ElementKeysAreEqual(object arg0)
            {
                return IExecute<bool>("elementKeysAreEqual", arg0);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/DeleteGroupsResponseData.DeletableGroupResult.html#next()"/>
            /// </summary>

            /// <returns><see cref="int"/></returns>
            public int Next()
            {
                return IExecute<int>("next");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/DeleteGroupsResponseData.DeletableGroupResult.html#prev()"/>
            /// </summary>

            /// <returns><see cref="int"/></returns>
            public int Prev()
            {
                return IExecute<int>("prev");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/DeleteGroupsResponseData.DeletableGroupResult.html#groupId()"/>
            /// </summary>

            /// <returns><see cref="string"/></returns>
            public string GroupId()
            {
                return IExecute<string>("groupId");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/DeleteGroupsResponseData.DeletableGroupResult.html#unknownTaggedFields()"/>
            /// </summary>

            /// <returns><see cref="Java.Util.List"/></returns>
            public Java.Util.List<Org.Apache.Kafka.Common.Protocol.Types.RawTaggedField> UnknownTaggedFields()
            {
                return IExecute<Java.Util.List<Org.Apache.Kafka.Common.Protocol.Types.RawTaggedField>>("unknownTaggedFields");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/DeleteGroupsResponseData.DeletableGroupResult.html#setErrorCode(short)"/>
            /// </summary>
            /// <param name="arg0"><see cref="short"/></param>
            /// <returns><see cref="Org.Apache.Kafka.Common.Message.DeleteGroupsResponseData.DeletableGroupResult"/></returns>
            public Org.Apache.Kafka.Common.Message.DeleteGroupsResponseData.DeletableGroupResult SetErrorCode(short arg0)
            {
                return IExecute<Org.Apache.Kafka.Common.Message.DeleteGroupsResponseData.DeletableGroupResult>("setErrorCode", arg0);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/DeleteGroupsResponseData.DeletableGroupResult.html#setGroupId(java.lang.String)"/>
            /// </summary>
            /// <param name="arg0"><see cref="string"/></param>
            /// <returns><see cref="Org.Apache.Kafka.Common.Message.DeleteGroupsResponseData.DeletableGroupResult"/></returns>
            public Org.Apache.Kafka.Common.Message.DeleteGroupsResponseData.DeletableGroupResult SetGroupId(string arg0)
            {
                return IExecute<Org.Apache.Kafka.Common.Message.DeleteGroupsResponseData.DeletableGroupResult>("setGroupId", arg0);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/DeleteGroupsResponseData.DeletableGroupResult.html#duplicate()"/>
            /// </summary>

            /// <returns><see cref="Org.Apache.Kafka.Common.Protocol.Message"/></returns>
            public Org.Apache.Kafka.Common.Protocol.Message Duplicate()
            {
                return IExecute<Org.Apache.Kafka.Common.Protocol.Message>("duplicate");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/DeleteGroupsResponseData.DeletableGroupResult.html#errorCode()"/>
            /// </summary>

            /// <returns><see cref="short"/></returns>
            public short ErrorCode()
            {
                return IExecute<short>("errorCode");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/DeleteGroupsResponseData.DeletableGroupResult.html#highestSupportedVersion()"/>
            /// </summary>

            /// <returns><see cref="short"/></returns>
            public short HighestSupportedVersion()
            {
                return IExecute<short>("highestSupportedVersion");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/DeleteGroupsResponseData.DeletableGroupResult.html#lowestSupportedVersion()"/>
            /// </summary>

            /// <returns><see cref="short"/></returns>
            public short LowestSupportedVersion()
            {
                return IExecute<short>("lowestSupportedVersion");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/DeleteGroupsResponseData.DeletableGroupResult.html#addSize(org.apache.kafka.common.protocol.MessageSizeAccumulator,org.apache.kafka.common.protocol.ObjectSerializationCache,short)"/>
            /// </summary>
            /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Protocol.MessageSizeAccumulator"/></param>
            /// <param name="arg1"><see cref="Org.Apache.Kafka.Common.Protocol.ObjectSerializationCache"/></param>
            /// <param name="arg2"><see cref="short"/></param>
            public void AddSize(Org.Apache.Kafka.Common.Protocol.MessageSizeAccumulator arg0, Org.Apache.Kafka.Common.Protocol.ObjectSerializationCache arg1, short arg2)
            {
                IExecute("addSize", arg0, arg1, arg2);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/DeleteGroupsResponseData.DeletableGroupResult.html#read(org.apache.kafka.common.protocol.Readable,short)"/>
            /// </summary>
            /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Protocol.Readable"/></param>
            /// <param name="arg1"><see cref="short"/></param>
            public void Read(Org.Apache.Kafka.Common.Protocol.Readable arg0, short arg1)
            {
                IExecute("read", arg0, arg1);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/DeleteGroupsResponseData.DeletableGroupResult.html#setNext(int)"/>
            /// </summary>
            /// <param name="arg0"><see cref="int"/></param>
            public void SetNext(int arg0)
            {
                IExecute("setNext", arg0);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/DeleteGroupsResponseData.DeletableGroupResult.html#setPrev(int)"/>
            /// </summary>
            /// <param name="arg0"><see cref="int"/></param>
            public void SetPrev(int arg0)
            {
                IExecute("setPrev", arg0);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/DeleteGroupsResponseData.DeletableGroupResult.html#write(org.apache.kafka.common.protocol.Writable,org.apache.kafka.common.protocol.ObjectSerializationCache,short)"/>
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

        #region DeletableGroupResultCollection
        public partial class DeletableGroupResultCollection
        {
            #region Constructors
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/DeleteGroupsResponseData.DeletableGroupResultCollection.html#%3Cinit%3E(int)"/>
            /// </summary>
            /// <param name="arg0"><see cref="int"/></param>
            public DeletableGroupResultCollection(int arg0)
                : base(arg0)
            {
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/DeleteGroupsResponseData.DeletableGroupResultCollection.html#%3Cinit%3E(java.util.Iterator)"/>
            /// </summary>
            /// <param name="arg0"><see cref="Java.Util.Iterator"/></param>
            public DeletableGroupResultCollection(Java.Util.Iterator<Org.Apache.Kafka.Common.Message.DeleteGroupsResponseData.DeletableGroupResult> arg0)
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
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/DeleteGroupsResponseData.DeletableGroupResultCollection.html#findAll(java.lang.String)"/>
            /// </summary>
            /// <param name="arg0"><see cref="string"/></param>
            /// <returns><see cref="Java.Util.List"/></returns>
            public Java.Util.List<Org.Apache.Kafka.Common.Message.DeleteGroupsResponseData.DeletableGroupResult> FindAll(string arg0)
            {
                return IExecute<Java.Util.List<Org.Apache.Kafka.Common.Message.DeleteGroupsResponseData.DeletableGroupResult>>("findAll", arg0);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/DeleteGroupsResponseData.DeletableGroupResultCollection.html#find(java.lang.String)"/>
            /// </summary>
            /// <param name="arg0"><see cref="string"/></param>
            /// <returns><see cref="Org.Apache.Kafka.Common.Message.DeleteGroupsResponseData.DeletableGroupResult"/></returns>
            public Org.Apache.Kafka.Common.Message.DeleteGroupsResponseData.DeletableGroupResult Find(string arg0)
            {
                return IExecute<Org.Apache.Kafka.Common.Message.DeleteGroupsResponseData.DeletableGroupResult>("find", arg0);
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/message/DeleteGroupsResponseData.DeletableGroupResultCollection.html#duplicate()"/>
            /// </summary>

            /// <returns><see cref="Org.Apache.Kafka.Common.Message.DeleteGroupsResponseData.DeletableGroupResultCollection"/></returns>
            public Org.Apache.Kafka.Common.Message.DeleteGroupsResponseData.DeletableGroupResultCollection Duplicate()
            {
                return IExecute<Org.Apache.Kafka.Common.Message.DeleteGroupsResponseData.DeletableGroupResultCollection>("duplicate");
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