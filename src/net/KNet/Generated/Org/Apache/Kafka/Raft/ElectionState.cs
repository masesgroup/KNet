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
*  using kafka-raft-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Raft
{
    #region ElectionState
    public partial class ElectionState
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.1/org/apache/kafka/raft/ElectionState.html#epoch"/>
        /// </summary>
        public int epoch { get { if (!_epochReady) { _epochContent = IGetField<int>("epoch"); _epochReady = true; } return _epochContent; } }
        private int _epochContent = default;
        private bool _epochReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.1/org/apache/kafka/raft/ElectionState.html#leaderIdOpt"/>
        /// </summary>
        public Java.Util.OptionalInt leaderIdOpt { get { if (!_leaderIdOptReady) { _leaderIdOptContent = IGetField<Java.Util.OptionalInt>("leaderIdOpt"); _leaderIdOptReady = true; } return _leaderIdOptContent; } }
        private Java.Util.OptionalInt _leaderIdOptContent = default;
        private bool _leaderIdOptReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.1/org/apache/kafka/raft/ElectionState.html#votedIdOpt"/>
        /// </summary>
        public Java.Util.OptionalInt votedIdOpt { get { if (!_votedIdOptReady) { _votedIdOptContent = IGetField<Java.Util.OptionalInt>("votedIdOpt"); _votedIdOptReady = true; } return _votedIdOptContent; } }
        private Java.Util.OptionalInt _votedIdOptContent = default;
        private bool _votedIdOptReady = false; // this is used because in case of generics 

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.1/org/apache/kafka/raft/ElectionState.html#withElectedLeader-int-int-java.util.Set-"/>
        /// </summary>
        /// <param name="arg0"><see cref="int"/></param>
        /// <param name="arg1"><see cref="int"/></param>
        /// <param name="arg2"><see cref="Java.Util.Set"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Raft.ElectionState"/></returns>
        public static Org.Apache.Kafka.Raft.ElectionState WithElectedLeader(int arg0, int arg1, Java.Util.Set<Java.Lang.Integer> arg2)
        {
            return SExecute<Org.Apache.Kafka.Raft.ElectionState>(LocalBridgeClazz, "withElectedLeader", arg0, arg1, arg2);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.1/org/apache/kafka/raft/ElectionState.html#withUnknownLeader-int-java.util.Set-"/>
        /// </summary>
        /// <param name="arg0"><see cref="int"/></param>
        /// <param name="arg1"><see cref="Java.Util.Set"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Raft.ElectionState"/></returns>
        public static Org.Apache.Kafka.Raft.ElectionState WithUnknownLeader(int arg0, Java.Util.Set<Java.Lang.Integer> arg1)
        {
            return SExecute<Org.Apache.Kafka.Raft.ElectionState>(LocalBridgeClazz, "withUnknownLeader", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.1/org/apache/kafka/raft/ElectionState.html#withVotedCandidate-int-int-java.util.Set-"/>
        /// </summary>
        /// <param name="arg0"><see cref="int"/></param>
        /// <param name="arg1"><see cref="int"/></param>
        /// <param name="arg2"><see cref="Java.Util.Set"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Raft.ElectionState"/></returns>
        public static Org.Apache.Kafka.Raft.ElectionState WithVotedCandidate(int arg0, int arg1, Java.Util.Set<Java.Lang.Integer> arg2)
        {
            return SExecute<Org.Apache.Kafka.Raft.ElectionState>(LocalBridgeClazz, "withVotedCandidate", arg0, arg1, arg2);
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.1/org/apache/kafka/raft/ElectionState.html#hasLeader--"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool HasLeader()
        {
            return IExecuteWithSignature<bool>("hasLeader", "()Z");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.1/org/apache/kafka/raft/ElectionState.html#hasVoted--"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool HasVoted()
        {
            return IExecuteWithSignature<bool>("hasVoted", "()Z");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.1/org/apache/kafka/raft/ElectionState.html#isLeader-int-"/>
        /// </summary>
        /// <param name="arg0"><see cref="int"/></param>
        /// <returns><see cref="bool"/></returns>
        public bool IsLeader(int arg0)
        {
            return IExecuteWithSignature<bool>("isLeader", "(I)Z", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.1/org/apache/kafka/raft/ElectionState.html#isVotedCandidate-int-"/>
        /// </summary>
        /// <param name="arg0"><see cref="int"/></param>
        /// <returns><see cref="bool"/></returns>
        public bool IsVotedCandidate(int arg0)
        {
            return IExecuteWithSignature<bool>("isVotedCandidate", "(I)Z", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.1/org/apache/kafka/raft/ElectionState.html#leaderId--"/>
        /// </summary>

        /// <returns><see cref="int"/></returns>
        public int LeaderId()
        {
            return IExecuteWithSignature<int>("leaderId", "()I");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.1/org/apache/kafka/raft/ElectionState.html#leaderIdOrSentinel--"/>
        /// </summary>

        /// <returns><see cref="int"/></returns>
        public int LeaderIdOrSentinel()
        {
            return IExecuteWithSignature<int>("leaderIdOrSentinel", "()I");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.1/org/apache/kafka/raft/ElectionState.html#votedId--"/>
        /// </summary>

        /// <returns><see cref="int"/></returns>
        public int VotedId()
        {
            return IExecuteWithSignature<int>("votedId", "()I");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.1/org/apache/kafka/raft/ElectionState.html#voters--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Set"/></returns>
        public Java.Util.Set<Java.Lang.Integer> Voters()
        {
            return IExecuteWithSignature<Java.Util.Set<Java.Lang.Integer>>("voters", "()Ljava/util/Set;");
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}