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
using Java.Lang;
using Java.Util;

namespace MASES.KNet.Clients.Admin
{
    public class DeleteTopicsResult : JCOBridge.C2JBridge.JVMBridgeBase<DeleteTopicsResult>
    {
        public override string ClassName => "org.apache.kafka.clients.admin.DeleteTopicsResult";

        public Map<Uuid, KafkaFuture<Void>> TopicIdValues => IExecute<Map<Uuid, KafkaFuture<Void>>>("topicIdValues");

        public Map<string, KafkaFuture<Void>> TopicNameValues => IExecute<Map<string, KafkaFuture<Void>>>("topicNameValues");

        public KafkaFuture<Void> All => IExecute<KafkaFuture<Void>>("all");
    }
}
