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

using MASES.JCOBridge.C2JBridge;
using Java.Lang;
using MASES.KNet.Streams.Processor;

namespace MASES.KNet.Streams.KStream
{
    public class TableJoined<K, KO> : JVMBridgeBase<TableJoined<K, KO>>, INamedOperation<TableJoined<K, KO>>
    {
        public override string ClassName => "org.apache.kafka.streams.kstream.TableJoined";

        public static TableJoined<K, KO> With(StreamPartitioner<K, Void> partitioner, StreamPartitioner<KO, Void> otherPartitioner)
        {
            return SExecute<TableJoined<K, KO>>("with", partitioner, otherPartitioner);
        }

        public static TableJoined<K, KO> As(string name)
        {
            return SExecute<TableJoined<K, KO>>("as", name);
        }

        public TableJoined<K, KO> WithPartitioner(StreamPartitioner<K, Void> partitioner)
        {
            return IExecute<TableJoined<K, KO>>("withPartitioner", partitioner);
        }

        public TableJoined<K, KO> WithOtherPartitioner(StreamPartitioner<KO, Void> otherPartitioner)
        {
            return IExecute<TableJoined<K, KO>>("withOtherPartitioner", otherPartitioner);
        }

        public TableJoined<K, KO> WithName(string name)
        {
            return IExecute<TableJoined<K, KO>>("withName", name);
        }
    }
}
