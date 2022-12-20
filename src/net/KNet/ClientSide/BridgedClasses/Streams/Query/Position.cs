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

namespace MASES.KNet.Streams.Query
{
    public class Position : JCOBridge.C2JBridge.JVMBridgeBase<Position>
    {
        public override string ClassName => "org.apache.kafka.streams.query.Position";

        public static Position EmptyPosition => SExecute<Position>("emptyPosition");

        public static Position FromMap(Map<string, Map<int, long>> map) => SExecute<Position>("fromMap", map);

        public Position WithComponent(string topic, int partition, long offset) => IExecute<Position>("withComponent", topic, partition, offset);

        public Position Copy() => IExecute<Position>("copy");

        public Position Merge(Position other) => IExecute<Position>("merge", other);

        public Set<string> Topics => IExecute<Set<string>>("getTopics");

        public Map<int, long> GetPartitionPositions(string topic) => IExecute<Map<int, long>>("getPartitionPositions", topic);
    }
}
