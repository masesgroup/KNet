/*
*  Copyright 2022 MASES s.r.l.
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

using Java.Util;

namespace MASES.KNet.Clients.Admin
{
    public class QuorumInfo : JCOBridge.C2JBridge.JVMBridgeBase<QuorumInfo>
    {
        public override string ClassName => "org.apache.kafka.clients.admin.QuorumInfo";

        public int LeaderId => IExecute<int>("leaderId");

        public long LeaderEpoch => IExecute<long>("leaderEpoch");

        public long HighWatermark => IExecute<long>("highWatermark");

        public List<ReplicaState> Voters => IExecute<List<ReplicaState>>("voters");

        public List<ReplicaState> Observers => IExecute<List<ReplicaState>>("observers");

        public class ReplicaState : JCOBridge.C2JBridge.JVMBridgeBase<ReplicaState>
        {
            public override string ClassName => "org.apache.kafka.clients.admin.QuorumInfo$ReplicaState";

            public int ReplicaId => IExecute<int>("replicaId");

            public long LogEndOffset => IExecute<long>("logEndOffset");

            public OptionalLong LastFetchTimestamp => IExecute<OptionalLong>("lastFetchTimestamp");

            public OptionalLong LastCaughtUpTimestamp => IExecute<OptionalLong>("lastCaughtUpTimestamp");
        }
    }
}
