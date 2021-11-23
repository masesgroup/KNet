﻿/*
*  Copyright 2021 MASES s.r.l.
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

using MASES.KafkaBridge.Java.Lang;
using MASES.KafkaBridge.Java.Util.Concurrent;

namespace MASES.KafkaBridge.Common
{
    public class KafkaFuture<E> : Future<E>
        where E : JCOBridge.C2JBridge.JVMBridgeBase, new()
    {
        public override string ClassName => "org.apache.kafka.common.KafkaFuture";

        public static KafkaFuture<Void> AllOf<T>(params KafkaFuture<T>[] futures) where T : JCOBridge.C2JBridge.JVMBridgeBase, new()
        {
            return SExecute<KafkaFuture<Void>>("allOf", futures);
        }

        public bool IsCompletedExceptionally => IExecute<bool>("isCompletedExceptionally");
    }
}