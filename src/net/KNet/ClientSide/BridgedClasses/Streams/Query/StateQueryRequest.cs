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

namespace MASES.KNet.Streams.Query
{
    public class StateQueryRequest<R> : JCOBridge.C2JBridge.JVMBridgeBase<StateQueryRequest<R>>
    {
        public override string ClassName => "org.apache.kafka.streams.query.StateQueryRequest";

        public static InStore WithInStore(string name) => SExecute<InStore>(name);

        public StateQueryRequest<R> WithPositionBound(PositionBound positionBound) => IExecute<StateQueryRequest<R>>("withPositionBound", positionBound);

        public StateQueryRequest<R> WithAllPartitions() => IExecute<StateQueryRequest<R>>("withAllPartitions");

        public StateQueryRequest<R> WithPartitions(Set<int> partitions) => IExecute<StateQueryRequest<R>>("withPartitions", partitions);

        public StateQueryRequest<R> EnableExecutionInfo() => IExecute<StateQueryRequest<R>>("enableExecutionInfo");

        public StateQueryRequest<R> RequireActive() => IExecute<StateQueryRequest<R>>("requireActive");

        public string StoreName => IExecute<string>("getStoreName");

        public PositionBound PositionBound => IExecute<PositionBound>("getPositionBound");

        public Query<R> Query => IExecute<Query<R>>("getQuery");

        public bool IsAllPartitions => IExecute<bool>("isAllPartitions");

        public Set<int> Partitions => IExecute<Set<int>>("getPartitions");

        public bool ExecutionInfoEnabled => IExecute<bool>("executionInfoEnabled");

        public bool IsRequireActive => IExecute<bool>("isRequireActive");

        public class InStore : JCOBridge.C2JBridge.JVMBridgeBase<StateQueryRequest<R>>
        {
            public override string ClassName => "org.apache.kafka.streams.query.StateQueryRequest$InStore";

            public StateQueryRequest<T> WithQuery<T>(Query<T> query) => SExecute<StateQueryRequest<T>>("withQuery", query);
        }
    }
}
