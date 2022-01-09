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

using System;

namespace MASES.KafkaBridge.Java.Time
{
    public sealed class Duration : JCOBridge.C2JBridge.JVMBridgeBase<Duration>
    {
        public override string ClassName => "java.time.Duration";

        // to be extended; add a single method related to TimeSpan of .NET: Duration and Timespan are similar

        public static implicit operator Duration(TimeSpan timespan)
        {
            var milli = timespan.TotalMilliseconds;
            return SExecute<Duration>("ofMillis", (long)milli);
        }
    }
}
