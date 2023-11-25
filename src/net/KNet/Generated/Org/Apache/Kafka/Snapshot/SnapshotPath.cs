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
*  using kafka-raft-3.6.0.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Snapshot
{
    #region SnapshotPath
    public partial class SnapshotPath
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/snapshot/SnapshotPath.html#org.apache.kafka.snapshot.SnapshotPath(java.nio.file.Path,org.apache.kafka.raft.OffsetAndEpoch,boolean,boolean)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Nio.File.Path"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Raft.OffsetAndEpoch"/></param>
        /// <param name="arg2"><see cref="bool"/></param>
        /// <param name="arg3"><see cref="bool"/></param>
        public SnapshotPath(Java.Nio.File.Path arg0, Org.Apache.Kafka.Raft.OffsetAndEpoch arg1, bool arg2, bool arg3)
            : base(arg0, arg1, arg2, arg3)
        {
        }

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/snapshot/SnapshotPath.html#deleted"/>
        /// </summary>
        public bool deleted { get { return IGetField<bool>("deleted"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/snapshot/SnapshotPath.html#partial"/>
        /// </summary>
        public bool partial { get { return IGetField<bool>("partial"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/snapshot/SnapshotPath.html#path"/>
        /// </summary>
        public Java.Nio.File.Path path { get { return IGetField<Java.Nio.File.Path>("path"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/snapshot/SnapshotPath.html#snapshotId"/>
        /// </summary>
        public Org.Apache.Kafka.Raft.OffsetAndEpoch snapshotId { get { return IGetField<Org.Apache.Kafka.Raft.OffsetAndEpoch>("snapshotId"); } }

        #endregion

        #region Static methods

        #endregion

        #region Instance methods

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}