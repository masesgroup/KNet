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

using MASES.KNet.Common.Utils;

namespace MASES.KNet.Common.Serialization
{
    public class BytesSerializer : MASES.JCOBridge.C2JBridge.JVMBridgeBase<BytesSerializer>
    {
        public override string BridgeClassName => "org.apache.kafka.common.serialization.BytesSerializer";

        public byte[] Serialize(string topic, Bytes data) => IExecute<byte[]>("serialize", topic, data);

        public static implicit operator Serializer<Bytes>(BytesSerializer t) => t.CastTo<Serializer<Bytes>>();
    }
}
