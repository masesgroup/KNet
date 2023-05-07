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

using Java.Util;

namespace MASES.KNet.Common.Quota
{
    public class ClientQuotaEntity : JCOBridge.C2JBridge.JVMBridgeBase<ClientQuotaEntity>
    {
        public override string BridgeClassName => "org.apache.kafka.common.quota.ClientQuotaEntity";

        [System.Obsolete("This is not public in Apache Kafka API")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public ClientQuotaEntity()
        {
        }

        public ClientQuotaEntity(Map<string, string> entries)
            : base(entries)
        {
        }

        public static string USER => SExecute<string>("USER");

        public static string CLIENT_ID => SExecute<string>("CLIENT_ID");

        public static string IP => SExecute<string>("IP");

        public static bool IsValidEntityType(string entityType)
        {
            return SExecute<bool>("isValidEntityType", entityType);
        }

        public Map<string, string> Entries => IExecute<Map<string, string>>("entries");
    }
}
