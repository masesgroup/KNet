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
    public class NewPartitions : JCOBridge.C2JBridge.JVMBridgeBase<NewPartitions>
    {
        public override string ClassName => "org.apache.kafka.clients.admin.NewPartitions";

        public static NewPartitions IncreaseTo(int totalCount)
        {
            return SExecute<NewPartitions>("increaseTo", totalCount);
        }

        public static NewPartitions IncreaseTo(int totalCount, List<List<int>> newAssignments)
        {
            return SExecute<NewPartitions>("increaseTo", totalCount, newAssignments);
        }

        public int TotalCount => IExecute<int>("totalCount");

        public List<List<int>> Assignments => IExecute<List<List<int>>>("assignments");
    }
}

