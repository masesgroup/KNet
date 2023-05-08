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

namespace MASES.KNet.Clients.Admin
{
    public class DescribeConfigsOptions : AbstractOptions<DescribeConfigsOptions>
    {
        public override string BridgeClassName => "org.apache.kafka.clients.admin.DescribeConfigsOptions";

        public new DescribeConfigsOptions TimeoutMs(int timeoutMs)
        {
            return IExecute<DescribeConfigsOptions>("timeoutMs", timeoutMs);
        }

        public bool IncludeSynonyms() => IExecute<bool>("includeSynonyms");

        public bool IncludeDocumentation() => IExecute<bool>("includeDocumentation");

        public DescribeConfigsOptions IncludeSynonyms(bool includeSynonyms)
        {
            return IExecute<DescribeConfigsOptions>("includeSynonyms", includeSynonyms);
        }

        public DescribeConfigsOptions IncludeDocumentation(bool includeDocumentation)
        {
            return IExecute<DescribeConfigsOptions>("includeDocumentation", includeDocumentation);
        }
    }
}
