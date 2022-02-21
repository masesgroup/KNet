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
using MASES.KafkaBridge.Common.Config;
using MASES.KafkaBridge.Java.Util;

namespace MASES.KafkaBridge.Clients.Admin
{
    public class DescribeConfigsResult : JCOBridge.C2JBridge.JVMBridgeBase<DescribeConfigsResult>
    {
        public override string ClassName => "org.apache.kafka.clients.admin.DescribeConfigsResult";

        public Map<ConfigResource, KafkaFuture<Config>> Values => IExecute<Map<ConfigResource, KafkaFuture<Config>>>("values");

        public KafkaFuture<Map<ConfigResource, Config>> All => IExecute<KafkaFuture<Map<ConfigResource, Config>>>("all");
    }
}
