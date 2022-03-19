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
    public class SlidingWindows : JCOBridge.C2JBridge.JVMBridgeBase<SlidingWindows>
    {
        public override string ClassName => "org.apache.kafka.streams.kstream.SlidingWindows";

        public static SlidingWindows OfTimeDifferenceWithNoGrace(Duration timeDifference)
        {
            return SExecute<SlidingWindows>("ofTimeDifferenceWithNoGrace", timeDifference);
        }

        public static SlidingWindows OfTimeDifferenceAndGrace(Duration timeDifference, Duration afterWindowEnd)
        {
            return SExecute<SlidingWindows>("ofTimeDifferenceAndGrace", timeDifference, afterWindowEnd);
        }

        public long TimeDifferenceMs => IExecute<long>("timeDifferenceMs");

        public long GracePeriodMs => IExecute<long>("gracePeriodMs");

    }
}
