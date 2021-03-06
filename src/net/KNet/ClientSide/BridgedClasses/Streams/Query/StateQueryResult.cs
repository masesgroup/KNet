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
    public class StateQueryResult<R> : JCOBridge.C2JBridge.JVMBridgeBase<StateQueryResult<R>>
    {
        public override string ClassName => "org.apache.kafka.streams.query.StateQueryResult";

        public void SetGlobalResult(QueryResult<R> r) => IExecute("setGlobalResult", r);

        public void AddResult(int partition, QueryResult<R> r) => IExecute("addResult", partition, r);

        public Map<int, QueryResult<R>> PartitionResults => IExecute<Map<int, QueryResult<R>>>("getPartitionResults");

        public QueryResult<R> OnlyPartitionResult => IExecute<QueryResult<R>>("getOnlyPartitionResult");

        public QueryResult<R> GlobalResult => IExecute<QueryResult<R>>("getGlobalResult");

        public Position Position => IExecute<Position>("position");
    }
}
