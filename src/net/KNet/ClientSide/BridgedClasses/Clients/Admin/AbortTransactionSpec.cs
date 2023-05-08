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

using MASES.KNet.Common;

namespace MASES.KNet.Clients.Admin
{
    public class AbortTransactionSpec : JCOBridge.C2JBridge.JVMBridgeBase<AbortTransactionSpec>
    {
        public override string BridgeClassName => "org.apache.kafka.clients.admin.AbortTransactionSpec";

        [System.Obsolete("This is not public in Apache Kafka API")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public AbortTransactionSpec()
        {
        }

        public AbortTransactionSpec(TopicPartition topicPartition, long producerId, short producerEpoch, int coordinatorEpoch)
            : base(topicPartition, producerId, producerEpoch, coordinatorEpoch)
        {
        }

        public TopicPartition TopicPartition => IExecute<TopicPartition>("topicPartition");

        public long ProducerId => IExecute<long>("producerId");

        public short ProducerEpoch => IExecute<short>("producerEpoch");

        public int CoordinatorEpoch => IExecute<int>("coordinatorEpoch");
    }
}
