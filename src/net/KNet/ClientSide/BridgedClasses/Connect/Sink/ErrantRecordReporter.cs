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

using Java.Lang;
using Java.Util.Concurrent;
using MASES.JCOBridge.C2JBridge;

namespace MASES.KNet.Connect.Sink
{
    public class ErrantRecordReporter : JVMBridgeBase<ErrantRecordReporter>
    {
        public override bool IsInterface => false;

        public override string ClassName => "org.apache.kafka.connect.sink.ErrantRecordReporter";

        public Future<Void> Report(SinkRecord record, Throwable error) => IExecute<Future<Void>>("report", record, error);
    }
}