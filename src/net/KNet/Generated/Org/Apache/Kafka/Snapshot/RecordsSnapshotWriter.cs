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
    #region RecordsSnapshotWriter
    public partial class RecordsSnapshotWriter
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
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.1/org/apache/kafka/snapshot/RecordsSnapshotWriter.html#isFrozen--"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool IsFrozen()
        {
            return IExecute<bool>("isFrozen");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.1/org/apache/kafka/snapshot/RecordsSnapshotWriter.html#lastContainedLogEpoch--"/>
        /// </summary>

        /// <returns><see cref="int"/></returns>
        public int LastContainedLogEpoch()
        {
            return IExecute<int>("lastContainedLogEpoch");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.1/org/apache/kafka/snapshot/RecordsSnapshotWriter.html#freeze--"/>
        /// </summary>

        /// <returns><see cref="long"/></returns>
        public long Freeze()
        {
            return IExecute<long>("freeze");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.1/org/apache/kafka/snapshot/RecordsSnapshotWriter.html#lastContainedLogOffset--"/>
        /// </summary>

        /// <returns><see cref="long"/></returns>
        public long LastContainedLogOffset()
        {
            return IExecute<long>("lastContainedLogOffset");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.1/org/apache/kafka/snapshot/RecordsSnapshotWriter.html#snapshotId--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Raft.OffsetAndEpoch"/></returns>
        public Org.Apache.Kafka.Raft.OffsetAndEpoch SnapshotId()
        {
            return IExecute<Org.Apache.Kafka.Raft.OffsetAndEpoch>("snapshotId");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.1/org/apache/kafka/snapshot/RecordsSnapshotWriter.html#append-java.util.List-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.List"/></param>
        public void Append(Java.Util.List arg0)
        {
            IExecute("append", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.1/org/apache/kafka/snapshot/RecordsSnapshotWriter.html#close--"/>
        /// </summary>
        public void Close()
        {
            IExecute("close");
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion

    #region RecordsSnapshotWriter<T>
    public partial class RecordsSnapshotWriter<T>
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Snapshot.RecordsSnapshotWriter{T}"/> to <see cref="Org.Apache.Kafka.Snapshot.RecordsSnapshotWriter"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Snapshot.RecordsSnapshotWriter(Org.Apache.Kafka.Snapshot.RecordsSnapshotWriter<T> t) => t.Cast<Org.Apache.Kafka.Snapshot.RecordsSnapshotWriter>();

        #endregion

        #region Fields

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.1/org/apache/kafka/snapshot/RecordsSnapshotWriter.html#isFrozen--"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool IsFrozen()
        {
            return IExecute<bool>("isFrozen");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.1/org/apache/kafka/snapshot/RecordsSnapshotWriter.html#lastContainedLogEpoch--"/>
        /// </summary>

        /// <returns><see cref="int"/></returns>
        public int LastContainedLogEpoch()
        {
            return IExecute<int>("lastContainedLogEpoch");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.1/org/apache/kafka/snapshot/RecordsSnapshotWriter.html#freeze--"/>
        /// </summary>

        /// <returns><see cref="long"/></returns>
        public long Freeze()
        {
            return IExecute<long>("freeze");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.1/org/apache/kafka/snapshot/RecordsSnapshotWriter.html#lastContainedLogOffset--"/>
        /// </summary>

        /// <returns><see cref="long"/></returns>
        public long LastContainedLogOffset()
        {
            return IExecute<long>("lastContainedLogOffset");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.1/org/apache/kafka/snapshot/RecordsSnapshotWriter.html#snapshotId--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Raft.OffsetAndEpoch"/></returns>
        public Org.Apache.Kafka.Raft.OffsetAndEpoch SnapshotId()
        {
            return IExecute<Org.Apache.Kafka.Raft.OffsetAndEpoch>("snapshotId");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.1/org/apache/kafka/snapshot/RecordsSnapshotWriter.html#append-java.util.List-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.List"/></param>
        public void Append(Java.Util.List<T> arg0)
        {
            IExecute("append", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.1/org/apache/kafka/snapshot/RecordsSnapshotWriter.html#close--"/>
        /// </summary>
        public void Close()
        {
            IExecute("close");
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}