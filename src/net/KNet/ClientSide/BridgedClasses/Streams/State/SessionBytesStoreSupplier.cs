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
using MASES.KNet.Common.Utils;

namespace MASES.KNet.Streams.State
{
    public interface ISessionBytesStoreSupplier : IStoreSupplier<SessionStore<Bytes, byte[]>>
    {
        long SegmentIntervalMs { get; }

        long RetentionPeriod { get; }
    }

    public class SessionBytesStoreSupplier : JVMBridgeBase<SessionBytesStoreSupplier, ISessionBytesStoreSupplier>, ISessionBytesStoreSupplier
    {
        public override string BridgeClassName => "org.apache.kafka.streams.state.SessionBytesStoreSupplier";

        public string Name => IExecute<string>("name");

        public SessionStore<Bytes, byte[]> Get => IExecute<SessionStore<Bytes, byte[]>>("get");

        public string MetricsScope => IExecute<string>("metricsScope");

        public long SegmentIntervalMs => IExecute<long>("segmentIntervalMs");

        public long RetentionPeriod => IExecute<long>("retentionPeriod");
    }
}
