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

namespace Org.Apache.Kafka.Snapshot
{
    #region IRawSnapshotReader
    /// <summary>
    /// .NET interface for TO BE DEFINED FROM USER
    /// </summary>
    public partial interface IRawSnapshotReader
    {
        #region Instance methods

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion

    #region RawSnapshotReader
    public partial class RawSnapshotReader : Org.Apache.Kafka.Snapshot.IRawSnapshotReader
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.1/org/apache/kafka/snapshot/RawSnapshotReader.html#sizeInBytes--"/>
        /// </summary>

        /// <returns><see cref="long"/></returns>
        public long SizeInBytes()
        {
            return IExecute<long>("sizeInBytes");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.1/org/apache/kafka/snapshot/RawSnapshotReader.html#slice-long-int-"/>
        /// </summary>
        /// <param name="arg0"><see cref="long"/></param>
        /// <param name="arg1"><see cref="int"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Record.UnalignedRecords"/></returns>
        public Org.Apache.Kafka.Common.Record.UnalignedRecords Slice(long arg0, int arg1)
        {
            return IExecute<Org.Apache.Kafka.Common.Record.UnalignedRecords>("slice", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.1/org/apache/kafka/snapshot/RawSnapshotReader.html#snapshotId--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Raft.OffsetAndEpoch"/></returns>
        public Org.Apache.Kafka.Raft.OffsetAndEpoch SnapshotId()
        {
            return IExecute<Org.Apache.Kafka.Raft.OffsetAndEpoch>("snapshotId");
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}