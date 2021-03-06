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
using Java.Util;

namespace MASES.KNet.Clients.Admin
{
    public class ListTopicsResult : JCOBridge.C2JBridge.JVMBridgeBase<ListTopicsResult>
    {
        public override string ClassName => "org.apache.kafka.clients.admin.ListTopicsResult";

        public KafkaFuture<Map<string, TopicListing>> NamesToListings => IExecute<KafkaFuture<Map<string, TopicListing>>>("namesToListings");

        public KafkaFuture<Collection<TopicListing>> Listings => IExecute<KafkaFuture<Collection<TopicListing>>>("listings");

        public KafkaFuture<Set<string>> Names => IExecute<KafkaFuture<Set<string>>>("names");
    }
}
