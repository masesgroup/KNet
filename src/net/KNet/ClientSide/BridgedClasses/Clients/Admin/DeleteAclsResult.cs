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
using MASES.KNet.Common.Errors;
using Java.Util;

namespace MASES.KNet.Clients.Admin
{
    public class DeleteAclsResult : JCOBridge.C2JBridge.JVMBridgeBase<DeleteAclsResult>
    {
        public override string ClassName => "org.apache.kafka.clients.admin.DeleteAclsResult";

        public Map<AclBindingFilter, KafkaFuture<FilterResults>> Values => IExecute<Map<AclBindingFilter, KafkaFuture<FilterResults>>>("values");

        public KafkaFuture<Collection<AclBinding>> All => IExecute<KafkaFuture<Collection<AclBinding>>>("all");

        public class FilterResults : JCOBridge.C2JBridge.JVMBridgeBase<FilterResults>
        {
            public override string ClassName => "org.apache.kafka.clients.admin.DeleteAclsResult$FilterResults";

            public List<FilterResult> Values => IExecute<List<FilterResult>>("values");
        }

        public class FilterResult : JCOBridge.C2JBridge.JVMBridgeBase<FilterResult>
        {
            public override string ClassName => "org.apache.kafka.clients.admin.DeleteAclsResult$FilterResult";

            public AclBinding Binding => IExecute<AclBinding>("binding");

            public ApiException Exception => IExecute<ApiException>("exception");
        }
    }
}

