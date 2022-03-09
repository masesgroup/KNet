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

using MASES.KafkaBridge.Common;
using MASES.KafkaBridge.Common.Acl;
using Java.Util;

namespace MASES.KafkaBridge.Clients.Admin
{
    public class TopicDescription : JCOBridge.C2JBridge.JVMBridgeBase<TopicDescription>
    {
        public override string ClassName => "org.apache.kafka.clients.admin.TopicDescription";

        [System.Obsolete("This is not public in Apache Kafka API")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public TopicDescription() { }

        public TopicDescription(string name, bool _internal, List<TopicPartitionInfo> partitions)
            : base(name, _internal, partitions)
        {
        }

        public TopicDescription(string name, bool _internal, List<TopicPartitionInfo> partitions, Set<AclOperation> authorizedOperations)
            : base(name, _internal, partitions, authorizedOperations)
        {
        }

        public TopicDescription(string name, bool _internal, List<TopicPartitionInfo> partitions, Set<AclOperation> authorizedOperations, Uuid topicId)
            : base(name, _internal, partitions, authorizedOperations, topicId)
        {
        }

        public string Name => IExecute<string>("name");

        public bool IsInternal => IExecute<bool>("isInternal");

        public Uuid TopicId => IExecute<Uuid>("topicId");

        public List<TopicPartitionInfo> Partitions => IExecute<List<TopicPartitionInfo>>("partitions");

        public Set<AclOperation> AuthorizedOperations => IExecute<Set<AclOperation>>("authorizedOperations");
    }
}

