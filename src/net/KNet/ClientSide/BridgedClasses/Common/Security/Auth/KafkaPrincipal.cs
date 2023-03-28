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

namespace Org.Apache.Kafka.Common.Security.Auth
{
    public class KafkaPrincipal : MASES.JCOBridge.C2JBridge.JVMBridgeBase<KafkaPrincipal>
    {
        public override string ClassName => "org.apache.kafka.common.security.auth.KafkaPrincipal";

        [System.Obsolete("This is not public in Apache Kafka API")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public KafkaPrincipal()
        {
        }

        public KafkaPrincipal(string principalType, string name)
            :base(principalType, name)
        {
        }

        public KafkaPrincipal(string principalType, string name, bool tokenAuthenticated)
           : base(principalType, name, tokenAuthenticated)
        {
        }

        public string Name => IExecute<string>("getName");

        public string PrincipalType => IExecute<string>("getPrincipalType");

        public bool TokenAuthenticated
        {
            get { return IExecute<bool>("tokenAuthenticated"); }
            set { IExecute("tokenAuthenticated", value); }
        }
    }
}
