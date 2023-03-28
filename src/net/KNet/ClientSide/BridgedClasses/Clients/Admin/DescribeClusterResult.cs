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

using Org.Apache.Kafka.Common;
using Org.Apache.Kafka.Common.Acl;
using Java.Util;

namespace Org.Apache.Kafka.Clients.Admin
{
    public class DescribeClusterResult : MASES.JCOBridge.C2JBridge.JVMBridgeBase<DescribeClusterResult>
    {
        public override string ClassName => "org.apache.kafka.clients.admin.DescribeClusterResult";

        public KafkaFuture<Collection<Common.Node>> Nodes => IExecute<KafkaFuture<Collection<Common.Node>>>("nodes");

        public KafkaFuture<Common.Node> Controller => IExecute<KafkaFuture<Common.Node>>("controller");

        public KafkaFuture<string> ClusterId => IExecute<KafkaFuture<string>>("clusterId");

        public KafkaFuture<Set<AclOperation>> AuthorizedOperations => IExecute<KafkaFuture<Set<AclOperation>>>("controller");
    }
}
