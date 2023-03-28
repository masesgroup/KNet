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

namespace Org.Apache.Kafka.Common.Security.Token.Delegation
{
    public class TokenInformation : MASES.JCOBridge.C2JBridge.JVMBridgeBase<TokenInformation>
    {
        public override string ClassName => "org.apache.kafka.common.security.token.delegation.TokenInformation";

        [System.Obsolete("This is not public in Apache Kafka API")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public TokenInformation()
        {
        }

        public TokenInformation(string tokenId, KafkaPrincipal owner, Collection<KafkaPrincipal> renewers, long issueTimestamp, long maxTimestamp, long expiryTimestamp)
            : base(tokenId, owner, renewers, issueTimestamp, maxTimestamp, expiryTimestamp)
        {
        }

        public TokenInformation(string tokenId, KafkaPrincipal owner, KafkaPrincipal tokenRequester, Collection<KafkaPrincipal> renewers, long issueTimestamp, long maxTimestamp, long expiryTimestamp)
            : base(tokenId, owner, tokenRequester, renewers, issueTimestamp, maxTimestamp, expiryTimestamp)
        {
        }

        public KafkaPrincipal Owner => IExecute<KafkaPrincipal>("owner");

        public KafkaPrincipal TokenRequester => IExecute<KafkaPrincipal>("tokenRequester");

        public string OwnerAsString => IExecute<string>("ownerAsString");

        public Collection<KafkaPrincipal> Renewers => IExecute<Collection<KafkaPrincipal>>("renewers");

        public Collection<string> RenewersAsString => IExecute<Collection<string>>("renewersAsString");

        public long IssueTimestamp => IExecute<long>("issueTimestamp");

        public long ExpiryTimestamp
        {
            get { return IExecute<long>("expiryTimestamp"); }
            set { IExecute("setExpiryTimestamp", value); }
        }

        public string TokenId => IExecute<string>("tokenId");

        public long MaxTimestamp => IExecute<long>("maxTimestamp");

        public bool OwnerOrRenewer(KafkaPrincipal principal)
        {
            return IExecute<bool>("ownerOrRenewer", principal);
        }
    }
}
