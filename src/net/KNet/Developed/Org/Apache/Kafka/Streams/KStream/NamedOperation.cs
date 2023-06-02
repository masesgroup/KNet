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

namespace Org.Apache.Kafka.Streams.Kstream
{
    /// <see href="https://kafka.apache.org/30/javadoc/org/apache/kafka/streams/kstream/NamedOperation.html">
    public interface INamedOperation<T> : IJVMBridgeBase
        where T: INamedOperation<T>
    {
        T WithName(string name);
    }

    public class NamedOperation<T> : JVMBridgeBase<NamedOperation<T>, INamedOperation<T>>, INamedOperation<T>
        where T : NamedOperation<T>
    {
        public override string BridgeClassName => "org.apache.kafka.streams.kstream.NamedOperation";

        public T WithName(string name)
        {
            return IExecute<T>("withName", name);
        }
    }
}
