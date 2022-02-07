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

using MASES.JCOBridge.C2JBridge;
using MASES.KafkaBridge.Common.Header;

namespace MASES.KafkaBridge.Streams.Processor
{
    public interface IRecordContext : IJVMBridgeBase
    {
        string Topic { get; }

        int Partition { get; }

        long Offset { get; }

        long Timestamp { get; }

        Headers Headers { get; }
    }

    public class RecordContext : JVMBridgeBase<RecordContext, IRecordContext>, IRecordContext
    {
        public override string ClassName => "org.apache.kafka.streams.processor.RecordContext";

        public string Topic => IExecute<string>("topic");

        public int Partition => IExecute<int>("partition");

        public long Offset => IExecute<long>("offset");

        public long Timestamp => IExecute<long>("timestamp");

        public Headers Headers => IExecute<Headers>("headers");
    }
}
