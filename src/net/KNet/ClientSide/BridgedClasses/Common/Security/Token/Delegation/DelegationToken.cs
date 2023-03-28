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

namespace Org.Apache.Kafka.Common.Security.Token.Delegation
{
    public class DelegationToken : MASES.JCOBridge.C2JBridge.JVMBridgeBase<DelegationToken>
    {
        public override string ClassName => "org.apache.kafka.common.security.token.delegation.DelegationToken";

        [System.Obsolete("This is not public in Apache Kafka API")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public DelegationToken()
        {
        }

        public DelegationToken(TokenInformation tokenInformation, byte[] hmac)
            : base(tokenInformation, hmac)
        {
        }

        public TokenInformation TokenInfo => IExecute<TokenInformation>("tokenInfo");

        public byte[] Hmac => IExecute<byte[]>("hmac");

        public string HmacAsBase64String => IExecute<string>("hmacAsBase64String");
    }
}
