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

namespace Org.Apache.Kafka.Streams.KStream
{
    public class Window : MASES.JCOBridge.C2JBridge.JVMBridgeBase<Window>
    {
        public override string ClassName => "org.apache.kafka.streams.kstream.Window";

        [System.Obsolete("This is not public in Apache Kafka API")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public Window() { }

        public Window(long startMs, long endMs)
            : base(startMs, endMs)
        {
        }

        public virtual long Start => IExecute<long>("start");

        public virtual long End => IExecute<long>("end");

        public virtual Instant StartTime => IExecute<Instant>("startTime");

        public virtual Instant EndTime => IExecute<Instant>("endTime");

        public bool Overlap(Window other)
        {
            return IExecute<bool>("overlap", other);
        }
    }
}
