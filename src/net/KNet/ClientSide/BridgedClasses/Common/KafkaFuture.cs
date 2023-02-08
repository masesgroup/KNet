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

using Java.Lang;
using Java.Util.Concurrent;

namespace MASES.KNet.Common
{
    public class KafkaFuture<E> : Future<E>
    {
        public override string ClassName => "org.apache.kafka.common.KafkaFuture";

        public static KafkaFuture<Void> AllOf<T>(params KafkaFuture<T>[] futures) where T : JCOBridge.C2JBridge.JVMBridgeBase, new()
        {
            return futures.Length == 0 ? SExecute<KafkaFuture<Void>>("allOf") : SExecute<KafkaFuture<Void>>("allOf", futures);
        }

        public bool IsCompletedExceptionally => IExecute<bool>("isCompletedExceptionally");
    }
}
