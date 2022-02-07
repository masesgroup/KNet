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
using MASES.KafkaBridge.Streams.Processor;

namespace MASES.KafkaBridge.Streams.KStream
{
    public interface ITransformer<K, V, R> : IJVMBridgeBase
    {
        void Init(IProcessorContext context);

        R Transform(K key, V value);

        void Close();
    }

    public class Transformer<K, V, R> : JVMBridgeBase<Transformer<K, V, R>, ITransformer<K, V, R>>, ITransformer<K, V, R>
    {
        public override string ClassName => "org.apache.kafka.streams.kstream.Transformer";

        public void Close()
        {
            IExecute("close");
        }

        public void Init(IProcessorContext context)
        {
            IExecute("init", context);
        }

        public R Transform(K key, V value)
        {
            return IExecute<R>("transform", key, value);
        }
    }
}
