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

using Java.Time;
using MASES.KNet.Streams.KStream.Internals;

namespace MASES.KNet.Streams.KStream
{
    public class TimeWindows : Windows<TimeWindow>
    {
        public override string ClassName => "org.apache.kafka.streams.kstream.TimeWindows";

        public static TimeWindows OfSizeWithNoGrace(Duration size)
        {
            return SExecute<TimeWindows>("ofSizeWithNoGrace", size);
        }

        public static TimeWindows OfSizeAndGrace(Duration size, Duration afterWindowEnd)
        {
            return SExecute<TimeWindows>("ofSizeAndGrace", size, afterWindowEnd);
        }

        public TimeWindows AdvanceBy(Duration advance)
        {
            return IExecute<TimeWindows>("advanceBy", advance);
        }
    }
}
