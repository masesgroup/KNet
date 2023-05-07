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
using MASES.KNet.Clients.Producer;
using MASES.KNet.Common.Serialization;
using Java.Io;
using Java.Time;
using Java.Util;

namespace MASES.KNet.Streams.Processor.Api
{
    public interface IProcessorContext<KForward, VForward> : IJVMBridgeBase
    {
        void Forward<K, V>(Record<K, V> record)
            where K : KForward
            where V : VForward;

        void Forward<K, V>(Record<K, V> record, string childName)
            where K : KForward
            where V : VForward;
    }

    public class ProcessorContext<KForward, VForward> : ProcessingContext, IProcessorContext<KForward, VForward>
    {
        public override bool IsBridgeInterface => true;

        public override string BridgeClassName => "org.apache.kafka.streams.processor.api.ProcessorContext";

        public void Forward<K, V>(Record<K, V> record)
            where K : KForward
            where V : VForward
        {
            IExecute("forward", record);
        }

        public void Forward<K, V>(Record<K, V> record, string childName)
            where K : KForward
            where V : VForward
        {
            IExecute("forward", record, childName);
        }
    }
}
