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

namespace Org.Apache.Kafka.Streams.State
{
    #region IVersionedBytesStore
    /// <summary>
    /// .NET interface for TO BE DEFINED FROM USER
    /// </summary>
    public partial interface IVersionedBytesStore
    {
        #region Instance methods

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion

    #region VersionedBytesStore
    public partial class VersionedBytesStore : Org.Apache.Kafka.Streams.State.IVersionedBytesStore, Org.Apache.Kafka.Streams.State.IKeyValueStore<Org.Apache.Kafka.Common.Utils.Bytes, byte[]>, Org.Apache.Kafka.Streams.State.ITimestampedBytesStore
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Streams.State.VersionedBytesStore"/> to <see cref="Org.Apache.Kafka.Streams.State.KeyValueStore"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.State.KeyValueStore(Org.Apache.Kafka.Streams.State.VersionedBytesStore t) => t.Cast<Org.Apache.Kafka.Streams.State.KeyValueStore>();
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Streams.State.VersionedBytesStore"/> to <see cref="Org.Apache.Kafka.Streams.State.TimestampedBytesStore"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.State.TimestampedBytesStore(Org.Apache.Kafka.Streams.State.VersionedBytesStore t) => t.Cast<Org.Apache.Kafka.Streams.State.TimestampedBytesStore>();

        #endregion

        #region Fields

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/VersionedBytesStore.html#delete-org.apache.kafka.common.utils.Bytes-long-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Utils.Bytes"/></param>
        /// <param name="arg1"><see cref="long"/></param>
        /// <returns><see cref="byte"/></returns>
        public byte[] Delete(Org.Apache.Kafka.Common.Utils.Bytes arg0, long arg1)
        {
            return IExecuteArray<byte>("delete", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/VersionedBytesStore.html#get-org.apache.kafka.common.utils.Bytes-long-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Utils.Bytes"/></param>
        /// <param name="arg1"><see cref="long"/></param>
        /// <returns><see cref="byte"/></returns>
        public byte[] Get(Org.Apache.Kafka.Common.Utils.Bytes arg0, long arg1)
        {
            return IExecuteArray<byte>("get", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/state/VersionedBytesStore.html#put-org.apache.kafka.common.utils.Bytes-byte[]-long-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Utils.Bytes"/></param>
        /// <param name="arg1"><see cref="byte"/></param>
        /// <param name="arg2"><see cref="long"/></param>
        /// <returns><see cref="long"/></returns>
        public long Put(Org.Apache.Kafka.Common.Utils.Bytes arg0, byte[] arg1, long arg2)
        {
            return IExecute<long>("put", arg0, arg1, arg2);
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}