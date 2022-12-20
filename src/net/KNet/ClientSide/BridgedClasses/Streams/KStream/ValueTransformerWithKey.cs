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
using MASES.KNet.Streams.Processor;

namespace MASES.KNet.Streams.KStream
{
    public interface IValueTransformerWithKey<K, V, VR> : IJVMBridgeBase
    {
        void Init(IProcessorContext context);

        VR Transform(K readOnlyKey, V value);

        void Close();
    }

    public class ValueTransformerWithKey<K, V, VR> : JVMBridgeBase<ValueTransformerWithKey<K, V, VR>, IValueTransformerWithKey<K, V, VR>>, IValueTransformerWithKey<K, V, VR>
    {
        public override string ClassName => "org.apache.kafka.streams.kstream.ValueTransformerWithKey";

        public void Close()
        {
            IExecute("close");
        }

        public void Init(IProcessorContext context)
        {
            IExecute("init", context);
        }

        public VR Transform(K readOnlyKey, V value)
        {
            return IExecute<VR>("transform", readOnlyKey, value);
        }
    }
}
