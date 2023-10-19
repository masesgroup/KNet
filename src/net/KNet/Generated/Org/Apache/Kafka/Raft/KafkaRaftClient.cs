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
*  This file is generated by MASES.JNetReflector (ver. 2.0.2.0)
*  using kafka-raft-3.6.0.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Raft
{
    #region KafkaRaftClient
    public partial class KafkaRaftClient
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/raft/KafkaRaftClient.html#MAX_BATCH_SIZE_BYTES"/>
        /// </summary>
        public static int MAX_BATCH_SIZE_BYTES { get { return SGetField<int>(LocalBridgeClazz, "MAX_BATCH_SIZE_BYTES"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/raft/KafkaRaftClient.html#MAX_FETCH_SIZE_BYTES"/>
        /// </summary>
        public static int MAX_FETCH_SIZE_BYTES { get { return SGetField<int>(LocalBridgeClazz, "MAX_FETCH_SIZE_BYTES"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/raft/KafkaRaftClient.html#MAX_FETCH_WAIT_MS"/>
        /// </summary>
        public static int MAX_FETCH_WAIT_MS { get { return SGetField<int>(LocalBridgeClazz, "MAX_FETCH_WAIT_MS"); } }

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/raft/KafkaRaftClient.html#isRunning--"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool IsRunning()
        {
            return IExecute<bool>("isRunning");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/raft/KafkaRaftClient.html#isShuttingDown--"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool IsShuttingDown()
        {
            return IExecute<bool>("isShuttingDown");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/raft/KafkaRaftClient.html#shutdown-int-"/>
        /// </summary>
        /// <param name="arg0"><see cref="int"/></param>
        /// <returns><see cref="Java.Util.Concurrent.CompletableFuture"/></returns>
        public Java.Util.Concurrent.CompletableFuture Shutdown(int arg0)
        {
            return IExecute<Java.Util.Concurrent.CompletableFuture>("shutdown", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/raft/KafkaRaftClient.html#latestSnapshotId--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Optional"/></returns>
        public Java.Util.Optional LatestSnapshotId()
        {
            return IExecute<Java.Util.Optional>("latestSnapshotId");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/raft/KafkaRaftClient.html#createSnapshot-org.apache.kafka.raft.OffsetAndEpoch-long-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Raft.OffsetAndEpoch"/></param>
        /// <param name="arg1"><see cref="long"/></param>
        /// <returns><see cref="Java.Util.Optional"/></returns>
        public Java.Util.Optional CreateSnapshot(Org.Apache.Kafka.Raft.OffsetAndEpoch arg0, long arg1)
        {
            return IExecute<Java.Util.Optional>("createSnapshot", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/raft/KafkaRaftClient.html#nodeId--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.OptionalInt"/></returns>
        public Java.Util.OptionalInt NodeId()
        {
            return IExecute<Java.Util.OptionalInt>("nodeId");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/raft/KafkaRaftClient.html#highWatermark--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.OptionalLong"/></returns>
        public Java.Util.OptionalLong HighWatermark()
        {
            return IExecute<Java.Util.OptionalLong>("highWatermark");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/raft/KafkaRaftClient.html#logEndOffset--"/>
        /// </summary>

        /// <returns><see cref="long"/></returns>
        public long LogEndOffset()
        {
            return IExecute<long>("logEndOffset");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/raft/KafkaRaftClient.html#scheduleAppend-int-java.util.List-"/>
        /// </summary>
        /// <param name="arg0"><see cref="int"/></param>
        /// <param name="arg1"><see cref="Java.Util.List"/></param>
        /// <returns><see cref="long"/></returns>
        public long ScheduleAppend(int arg0, Java.Util.List arg1)
        {
            return IExecute<long>("scheduleAppend", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/raft/KafkaRaftClient.html#scheduleAtomicAppend-int-java.util.OptionalLong-java.util.List-"/>
        /// </summary>
        /// <param name="arg0"><see cref="int"/></param>
        /// <param name="arg1"><see cref="Java.Util.OptionalLong"/></param>
        /// <param name="arg2"><see cref="Java.Util.List"/></param>
        /// <returns><see cref="long"/></returns>
        public long ScheduleAtomicAppend(int arg0, Java.Util.OptionalLong arg1, Java.Util.List arg2)
        {
            return IExecute<long>("scheduleAtomicAppend", arg0, arg1, arg2);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/raft/KafkaRaftClient.html#leaderAndEpoch--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Raft.LeaderAndEpoch"/></returns>
        public Org.Apache.Kafka.Raft.LeaderAndEpoch LeaderAndEpoch()
        {
            return IExecute<Org.Apache.Kafka.Raft.LeaderAndEpoch>("leaderAndEpoch");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/raft/KafkaRaftClient.html#close--"/>
        /// </summary>
        public void Close()
        {
            IExecute("close");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/raft/KafkaRaftClient.html#handle-org.apache.kafka.raft.RaftRequest.Inbound-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Raft.RaftRequest.Inbound"/></param>
        public void Handle(Org.Apache.Kafka.Raft.RaftRequest.Inbound arg0)
        {
            IExecute("handle", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/raft/KafkaRaftClient.html#initialize--"/>
        /// </summary>
        public void Initialize()
        {
            IExecute("initialize");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/raft/KafkaRaftClient.html#poll--"/>
        /// </summary>
        public void Poll()
        {
            IExecute("poll");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/raft/KafkaRaftClient.html#register-org.apache.kafka.raft.RaftClient.Listener-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Raft.RaftClient.Listener"/></param>
        public void Register(Org.Apache.Kafka.Raft.RaftClient.Listener arg0)
        {
            IExecute("register", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/raft/KafkaRaftClient.html#resign-int-"/>
        /// </summary>
        /// <param name="arg0"><see cref="int"/></param>
        public void Resign(int arg0)
        {
            IExecute("resign", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/raft/KafkaRaftClient.html#unregister-org.apache.kafka.raft.RaftClient.Listener-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Raft.RaftClient.Listener"/></param>
        public void Unregister(Org.Apache.Kafka.Raft.RaftClient.Listener arg0)
        {
            IExecute("unregister", arg0);
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion

    #region KafkaRaftClient<T>
    public partial class KafkaRaftClient<T>
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Raft.KafkaRaftClient{T}"/> to <see cref="Org.Apache.Kafka.Raft.KafkaRaftClient"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Raft.KafkaRaftClient(Org.Apache.Kafka.Raft.KafkaRaftClient<T> t) => t.Cast<Org.Apache.Kafka.Raft.KafkaRaftClient>();

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/raft/KafkaRaftClient.html#MAX_BATCH_SIZE_BYTES"/>
        /// </summary>
        public static int MAX_BATCH_SIZE_BYTES { get { return SGetField<int>(LocalBridgeClazz, "MAX_BATCH_SIZE_BYTES"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/raft/KafkaRaftClient.html#MAX_FETCH_SIZE_BYTES"/>
        /// </summary>
        public static int MAX_FETCH_SIZE_BYTES { get { return SGetField<int>(LocalBridgeClazz, "MAX_FETCH_SIZE_BYTES"); } }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/raft/KafkaRaftClient.html#MAX_FETCH_WAIT_MS"/>
        /// </summary>
        public static int MAX_FETCH_WAIT_MS { get { return SGetField<int>(LocalBridgeClazz, "MAX_FETCH_WAIT_MS"); } }

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/raft/KafkaRaftClient.html#isRunning--"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool IsRunning()
        {
            return IExecute<bool>("isRunning");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/raft/KafkaRaftClient.html#isShuttingDown--"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool IsShuttingDown()
        {
            return IExecute<bool>("isShuttingDown");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/raft/KafkaRaftClient.html#shutdown-int-"/>
        /// </summary>
        /// <param name="arg0"><see cref="int"/></param>
        /// <returns><see cref="Java.Util.Concurrent.CompletableFuture"/></returns>
        public Java.Util.Concurrent.CompletableFuture<Java.Lang.Void> Shutdown(int arg0)
        {
            return IExecute<Java.Util.Concurrent.CompletableFuture<Java.Lang.Void>>("shutdown", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/raft/KafkaRaftClient.html#latestSnapshotId--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Optional"/></returns>
        public Java.Util.Optional<Org.Apache.Kafka.Raft.OffsetAndEpoch> LatestSnapshotId()
        {
            return IExecute<Java.Util.Optional<Org.Apache.Kafka.Raft.OffsetAndEpoch>>("latestSnapshotId");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/raft/KafkaRaftClient.html#createSnapshot-org.apache.kafka.raft.OffsetAndEpoch-long-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Raft.OffsetAndEpoch"/></param>
        /// <param name="arg1"><see cref="long"/></param>
        /// <returns><see cref="Java.Util.Optional"/></returns>
        public Java.Util.Optional<Org.Apache.Kafka.Snapshot.SnapshotWriter<T>> CreateSnapshot(Org.Apache.Kafka.Raft.OffsetAndEpoch arg0, long arg1)
        {
            return IExecute<Java.Util.Optional<Org.Apache.Kafka.Snapshot.SnapshotWriter<T>>>("createSnapshot", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/raft/KafkaRaftClient.html#nodeId--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.OptionalInt"/></returns>
        public Java.Util.OptionalInt NodeId()
        {
            return IExecute<Java.Util.OptionalInt>("nodeId");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/raft/KafkaRaftClient.html#highWatermark--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.OptionalLong"/></returns>
        public Java.Util.OptionalLong HighWatermark()
        {
            return IExecute<Java.Util.OptionalLong>("highWatermark");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/raft/KafkaRaftClient.html#logEndOffset--"/>
        /// </summary>

        /// <returns><see cref="long"/></returns>
        public long LogEndOffset()
        {
            return IExecute<long>("logEndOffset");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/raft/KafkaRaftClient.html#scheduleAppend-int-java.util.List-"/>
        /// </summary>
        /// <param name="arg0"><see cref="int"/></param>
        /// <param name="arg1"><see cref="Java.Util.List"/></param>
        /// <returns><see cref="long"/></returns>
        public long ScheduleAppend(int arg0, Java.Util.List<T> arg1)
        {
            return IExecute<long>("scheduleAppend", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/raft/KafkaRaftClient.html#scheduleAtomicAppend-int-java.util.OptionalLong-java.util.List-"/>
        /// </summary>
        /// <param name="arg0"><see cref="int"/></param>
        /// <param name="arg1"><see cref="Java.Util.OptionalLong"/></param>
        /// <param name="arg2"><see cref="Java.Util.List"/></param>
        /// <returns><see cref="long"/></returns>
        public long ScheduleAtomicAppend(int arg0, Java.Util.OptionalLong arg1, Java.Util.List<T> arg2)
        {
            return IExecute<long>("scheduleAtomicAppend", arg0, arg1, arg2);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/raft/KafkaRaftClient.html#leaderAndEpoch--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Raft.LeaderAndEpoch"/></returns>
        public Org.Apache.Kafka.Raft.LeaderAndEpoch LeaderAndEpoch()
        {
            return IExecute<Org.Apache.Kafka.Raft.LeaderAndEpoch>("leaderAndEpoch");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/raft/KafkaRaftClient.html#close--"/>
        /// </summary>
        public void Close()
        {
            IExecute("close");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/raft/KafkaRaftClient.html#handle-org.apache.kafka.raft.RaftRequest.Inbound-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Raft.RaftRequest.Inbound"/></param>
        public void Handle(Org.Apache.Kafka.Raft.RaftRequest.Inbound arg0)
        {
            IExecute("handle", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/raft/KafkaRaftClient.html#initialize--"/>
        /// </summary>
        public void Initialize()
        {
            IExecute("initialize");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/raft/KafkaRaftClient.html#poll--"/>
        /// </summary>
        public void Poll()
        {
            IExecute("poll");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/raft/KafkaRaftClient.html#register-org.apache.kafka.raft.RaftClient.Listener-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Raft.RaftClient.Listener"/></param>
        public void Register(Org.Apache.Kafka.Raft.RaftClient.Listener<T> arg0)
        {
            IExecute("register", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/raft/KafkaRaftClient.html#resign-int-"/>
        /// </summary>
        /// <param name="arg0"><see cref="int"/></param>
        public void Resign(int arg0)
        {
            IExecute("resign", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/org/apache/kafka/raft/KafkaRaftClient.html#unregister-org.apache.kafka.raft.RaftClient.Listener-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Raft.RaftClient.Listener"/></param>
        public void Unregister(Org.Apache.Kafka.Raft.RaftClient.Listener<T> arg0)
        {
            IExecute("unregister", arg0);
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}