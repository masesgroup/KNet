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

using Java.Util;

namespace MASES.KafkaBridge.Clients.Admin
{
    public class ProducerState : JCOBridge.C2JBridge.JVMBridgeBase<ProducerState>
    {
        public override string ClassName => "org.apache.kafka.clients.admin.ProducerState";

        public long ProducerId => IExecute<long>("producerId");

        public int ProducerEpoch => IExecute<int>("producerEpoch");

        public int LastSequence => IExecute<int>("lastSequence");

        public long LastTimestamp => IExecute<long>("lastTimestamp");

        public OptionalLong CurrentTransactionStartOffset => IExecute<OptionalLong>("producerId");

        public OptionalInt CoordinatorEpoch => IExecute<OptionalInt>("producerId");
    }
}

