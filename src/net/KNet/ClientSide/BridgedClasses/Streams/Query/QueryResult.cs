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

using Java.Util;
using Org.Apache.Kafka.Streams.Processor;

namespace Org.Apache.Kafka.Streams.Query
{
    public class QueryResult<R> : MASES.JCOBridge.C2JBridge.JVMBridgeBase<QueryResult<R>>
    {
        public override bool IsInterface => true;

        public override string ClassName => "org.apache.kafka.streams.query.QueryResult";

        public static QueryResult<T> ForResult<T>(T result) => SExecute<QueryResult<T>>("forResult", result);

        public static QueryResult<T> ForFailure<T>(FailureReason failureReason, string failureMessage) => SExecute<QueryResult<T>>("forFailure", failureReason, failureMessage);

        public static QueryResult<T> ForUnknownQueryType<T>(Query<T> query, StateStore store) => SExecute<QueryResult<T>>("forUnknownQueryType", query, store);

        public static QueryResult<T> NotUpToBound<T>(Position currentPosition, PositionBound positionBound, int partition) => SExecute<QueryResult<T>>("notUpToBound", currentPosition, positionBound, partition);

        public void AddExecutionInfo(string message) => IExecute("addExecutionInfo", message);

        public void SetPosition(Position position) => IExecute("setPosition", position);

        public bool IsSuccess => IExecute<bool>("isSuccess");

        public bool IsFailure => IExecute<bool>("isFailure");

        public List<string> ExecutionInfo => IExecute<List<string>>("getExecutionInfo");

        public Position Position => IExecute<Position>("getPosition");

        public FailureReason FailureReason => IExecute<FailureReason>("getFailureReason");

        public string FailureMessage => IExecute<string>("getFailureMessage");

        public R Result => IExecute<R>("getResult");
    }
}
