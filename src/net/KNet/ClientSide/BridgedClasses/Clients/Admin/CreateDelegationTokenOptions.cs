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

using Org.Apache.Kafka.Common.Security.Auth;
using Java.Util;

namespace Org.Apache.Kafka.Clients.Admin
{
    public class CreateDelegationTokenOptions : AbstractOptions<CreateDelegationTokenOptions>
    {
        public override string ClassName => "org.apache.kafka.clients.admin.CreateDelegationTokenOptions";

        public CreateDelegationTokenOptions Renewers(List<KafkaPrincipal> renewers)
        {
            return IExecute<CreateDelegationTokenOptions>("renewers", renewers);
        }

        public List<KafkaPrincipal> Renewers() => IExecute<List<KafkaPrincipal>>("renewers");

        public CreateDelegationTokenOptions MaxlifeTimeMs(long maxLifeTimeMs)
        {
            return IExecute<CreateDelegationTokenOptions>("maxlifeTimeMs", maxLifeTimeMs);
        }

        public CreateDelegationTokenOptions Owner(KafkaPrincipal owner) => IExecute<CreateDelegationTokenOptions>("owner", owner);

        public Optional<KafkaPrincipal> Owner() => IExecute<Optional<KafkaPrincipal>>("owner");

        public long MaxlifeTimeMs() => IExecute<long>("maxlifeTimeMs");
    }
}
