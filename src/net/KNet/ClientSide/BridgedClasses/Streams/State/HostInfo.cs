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

using MASES.JCOBridge.C2JBridge;

namespace MASES.KNet.Streams.State
{
    public class HostInfo : JVMBridgeBase<HostInfo>
    {
        public override string ClassName => "org.apache.kafka.streams.state.HostInfo";

        public HostInfo()
        {
        }

        public HostInfo(string host, int port)
            : base(host, port)
        {
        }

        public static HostInfo BuildFromEndpoint(string endPoint)
        {
            return SExecute<HostInfo>("buildFromEndpoint", endPoint);
        }

        public static HostInfo Unavailable()
        {
            return SExecute<HostInfo>("unavailable");
        }

        public string Host => IExecute<string>("host");

        public int Port => IExecute<int>("port");
    }
}
