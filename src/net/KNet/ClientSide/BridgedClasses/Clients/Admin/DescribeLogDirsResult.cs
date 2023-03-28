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
using Org.Apache.Kafka.Common.Requests;
using Java.Util;

namespace Org.Apache.Kafka.Clients.Admin
{
    public class DescribeLogDirsResult : MASES.JCOBridge.C2JBridge.JVMBridgeBase<DescribeLogDirsResult>
    {
        public override string ClassName => "org.apache.kafka.clients.admin.DescribeLogDirsResult";

        public Map<int, KafkaFuture<Map<string, DescribeLogDirsResponse.LogDirInfo>>> Values => IExecute<Map<int, KafkaFuture<Map<string, DescribeLogDirsResponse.LogDirInfo>>>>("descriptions");

        public Map<int, KafkaFuture<Map<string, LogDirDescription>>> Descriptions => IExecute<Map<int, KafkaFuture<Map<string, LogDirDescription>>>>("descriptions");

        public KafkaFuture<Map<int, Map<string, LogDirDescription>>> AllDescriptions => IExecute<KafkaFuture<Map<int, Map<string, LogDirDescription>>>>("allDescriptions");
    }
}
