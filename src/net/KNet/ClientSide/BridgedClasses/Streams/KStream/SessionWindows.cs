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

using Java.Time;

namespace MASES.KNet.Streams.KStream
{
    public class SessionWindows : JCOBridge.C2JBridge.JVMBridgeBase<SessionWindows>
    {
        public override string ClassName => "org.apache.kafka.streams.kstream.SessionWindows";

        public static SessionWindows OfInactivityGapWithNoGrace(Duration inactivityGap)
        {
            return SExecute<SessionWindows>("ofInactivityGapWithNoGrace", inactivityGap);
        }

        public static SessionWindows OfInactivityGapAndGrace(Duration inactivityGap, Duration afterWindowEnd)
        {
            return SExecute<SessionWindows>("ofInactivityGapAndGrace", inactivityGap, afterWindowEnd);
        }

        public long GracePeriodMs => IExecute<long>("gracePeriodMs");

        public long InactivityGap => IExecute<long>("inactivityGap");
    }
}
