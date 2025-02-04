/*
*  Copyright 2025 MASES s.r.l.
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
using MASES.JCOBridge.C2JBridge.JVMInterop;
using Java.Util;
using static System.Net.WebRequestMethods;

namespace Org.Apache.Kafka.Common.Errors
{
    public partial class InvalidTopicException
    {
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/latest/org/apache/kafka/common/errors/InvalidTopicException.html#invalidTopics--"/>
        /// </summary>
        public Set<string> InvalidTopics()
        {
            return JVMBridgeBase.WrapsDirect<Set<string>>(BridgeInstance.Invoke("invalidTopics") as IJavaObject);
        }
    }
}
