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

namespace MASES.KNet.Clients.Admin
{
    public class ListTopicsOptions : AbstractOptions<ListTopicsOptions>
    {
        public override string ClassName => "org.apache.kafka.clients.admin.ListTopicsOptions";

        public new ListTopicsOptions TimeoutMs(int timeoutMs)
        {
            return IExecute<ListTopicsOptions>("timeoutMs", timeoutMs);
        }

        public ListTopicsOptions ListInternal(bool listInternal)
        {
            return IExecute<ListTopicsOptions>("listInternal", listInternal);
        }

        public bool ShouldListInternal => IExecute<bool>("shouldListInternal");
    }
}
