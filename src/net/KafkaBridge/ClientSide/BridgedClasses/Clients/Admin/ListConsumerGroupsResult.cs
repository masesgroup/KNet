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
using MASES.KafkaBridge.Java.Lang;
using MASES.KafkaBridge.Java.Util;

namespace MASES.KafkaBridge.Clients.Admin
{
    public class ListConsumerGroupsResult : JCOBridge.C2JBridge.JVMBridgeBase<ListConsumerGroupsResult>
    {
        public override string ClassName => "org.apache.kafka.clients.admin.ListConsumerGroupsResult";

        public KafkaFuture<Collection<ConsumerGroupListing>> All => IExecute<KafkaFuture<Collection<ConsumerGroupListing>>>("all");

        public KafkaFuture<Collection<ConsumerGroupListing>> Valid => IExecute<KafkaFuture<Collection<ConsumerGroupListing>>>("all");

        public KafkaFuture<Collection<Throwable>> Errors => IExecute<KafkaFuture<Collection<Throwable>>>("errors");
    }
}
