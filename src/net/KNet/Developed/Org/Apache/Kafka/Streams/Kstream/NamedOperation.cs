/*
*  Copyright (c) 2021-2025 MASES s.r.l.
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
    /// <summary>
    /// <see href="https://kafka.apache.org/34/javadoc/org/apache/kafka/streams/kstream/NamedOperation.html"/>
    /// </summary>
    public interface INamedOperation<T> : IJVMBridgeBase where T: INamedOperation<T>
    {
    }
    /// <summary>
    /// <see href="https://kafka.apache.org/34/javadoc/org/apache/kafka/streams/kstream/NamedOperation.html"/>
    /// </summary>
    public class NamedOperation : JVMBridgeBase<NamedOperation>
    {
        /// <summary>
        /// <see href="https://www.jcobridge.com/api-clr/html/P_MASES_JCOBridge_C2JBridge_JVMBridgeBase_BridgeClassName.htm"/>
        /// </summary>
        public override string BridgeClassName => "org.apache.kafka.streams.kstream.NamedOperation";

        /// <summary>
        /// Default constructor: even if the corresponding Java class does not have one, it is mandatory for JCOBridge
        /// </summary>
        public NamedOperation() { }
        /// <summary>
        /// Generic constructor: it is useful for JCOBridge when there is a derived class which needs to pass arguments to the highest JVMBridgeBase class
        /// </summary>
        public NamedOperation(params object[] args) : base(args) { }
    }
    /// <summary>
    /// <see href="https://kafka.apache.org/34/javadoc/org/apache/kafka/streams/kstream/NamedOperation.html"/>
    /// </summary>
    public class NamedOperation<T> : NamedOperation, INamedOperation<T> where T : NamedOperation<T>
    {
        /// <summary>
        /// Default constructor: even if the corresponding Java class does not have one, it is mandatory for JCOBridge
        /// </summary>
        public NamedOperation() { }
        /// <summary>
        /// Generic constructor: it is useful for JCOBridge when there is a derived class which needs to pass arguments to the highest JVMBridgeBase class
        /// </summary>
        public NamedOperation(params object[] args) : base(args) { }
    }
}
