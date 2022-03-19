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

using MASES.JCOBridge.C2JBridge.JVMInterop;
using MASES.KNet.Common;
using MASES.KNet.Common.Errors;
using Java.Util;

namespace MASES.KNet.Clients.Admin
{
    public class LogDirDescription : JCOBridge.C2JBridge.JVMBridgeBase<LogDirDescription>
    {
        public override string ClassName => "org.apache.kafka.clients.admin.LogDirDescription";

        [System.Obsolete("This is not public in Apache Kafka API")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public LogDirDescription()
        {
        }

        public LogDirDescription(ApiException error, Map<TopicPartition, ReplicaInfo> replicaInfos)
            : base(error, replicaInfos)
        {
        }

        public ApiException Error
        {
            get { return JCOBridge.C2JBridge.JVMBridgeException.New(IExecute<IJavaObject>("error")) as ApiException; }
        }

        public Map<TopicPartition, ReplicaInfo> ReplicaInfos => IExecute<Map<TopicPartition, ReplicaInfo>>("replicaInfos");
    }
}
