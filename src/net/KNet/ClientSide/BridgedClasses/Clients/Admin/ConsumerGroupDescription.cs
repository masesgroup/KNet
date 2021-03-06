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

using MASES.KNet.Common;
using MASES.KNet.Common.Acl;
using Java.Util;

namespace MASES.KNet.Clients.Admin
{
    public class ConsumerGroupDescription : JCOBridge.C2JBridge.JVMBridgeBase<ConsumerGroupDescription>
    {
        public override string ClassName => "org.apache.kafka.clients.admin.ConsumerGroupDescription";

        public string GroupId => IExecute<string>("groupId");

        public bool IsSimpleConsumerGroup => IExecute<bool>("isSimpleConsumerGroup");

        public Collection<MemberDescription> members => IExecute<Collection<MemberDescription>>("members");

        public string PartitionAssignor => IExecute<string>("partitionAssignor");

        public ConsumerGroupState State => IExecute<ConsumerGroupState>("state");

        public Node Coordinator => IExecute<Node>("coordinator");

        public Set<AclOperation> AuthorizedOperations => IExecute<Set<AclOperation>>("authorizedOperations");
    }
}
