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

using Java.Util.Function;
using MASES.JCOBridge.C2JBridge;

namespace MASES.KafkaBridge.Common.Utils
{
    public interface ITime : IJVMBridgeBase
    {
        long Milliseconds { get; }

        long HiResClockMs { get; }

        long Nanoseconds { get; }

        void Sleep(long ms);

        void WaitObject(object obj, Supplier<bool> condition, long deadlineMs);
    }


    public class Time : JVMBridgeBase<Time, ITime>, ITime
    {
        public override string ClassName => "org.apache.kafka.common.utils.Time";

        public long Milliseconds => IExecute<long>("milliseconds");

        public long HiResClockMs => IExecute<long>("hiResClockMs");

        public long Nanoseconds => IExecute<long>("nanoseconds");

        public void Sleep(long ms)
        {
            IExecute("sleep", ms);
        }

        public void WaitObject(object obj, Supplier<bool> condition, long deadlineMs)
        {
            IExecute("waitObject", obj, condition, deadlineMs);
        }
    }
}
