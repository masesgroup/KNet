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

using MASES.KNet.Common;
using Java.Util;

namespace MASES.KNet.Clients.Admin
{
    public class DescribeTopicsResult : JCOBridge.C2JBridge.JVMBridgeBase<DescribeTopicsResult>
    {
        public override string BridgeClassName => "org.apache.kafka.clients.admin.DescribeTopicsResult";

        public Map<Uuid, KafkaFuture<TopicDescription>> TopicIdValues => IExecute<Map<Uuid, KafkaFuture<TopicDescription>>>("topicIdValues");

        public Map<string, KafkaFuture<TopicDescription>> TopicNameValues => IExecute<Map<string, KafkaFuture<TopicDescription>>>("topicNameValues");

        public KafkaFuture<Map<string, TopicDescription>> AllTopicNames => IExecute<KafkaFuture<Map<string, TopicDescription>>>("allTopicNames");

        public KafkaFuture<Map<Uuid, TopicDescription>> AllTopicIds => IExecute<KafkaFuture<Map<Uuid, TopicDescription>>>("allTopicIds");
    }
}
