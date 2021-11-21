/*
*  Copyright 2021 MASES s.r.l.
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

namespace MASES.KafkaBridge.Java.Util.Concurrent
{
    public class TimeUnit : JCOBridge.C2JBridge.JVMBridgeBase<TimeUnit>
    {
        public override string ClassName => "java.util.concurrent.TimeUnit";

        public static TimeUnit DAYS => SExecute<TimeUnit>("valueOf", "DAYS");
        public static TimeUnit HOURS => SExecute<TimeUnit>("valueOf", "HOURS");
        public static TimeUnit MICROSECONDS => SExecute<TimeUnit>("valueOf", "MICROSECONDS");
        public static TimeUnit MILLISECONDS => SExecute<TimeUnit>("valueOf", "MILLISECONDS");
        public static TimeUnit MINUTES => SExecute<TimeUnit>("valueOf", "MINUTES");
        public static TimeUnit NANOSECONDS => SExecute<TimeUnit>("valueOf", "NANOSECONDS");
        public static TimeUnit SECONDS => SExecute<TimeUnit>("valueOf", "SECONDS");
    }
}
