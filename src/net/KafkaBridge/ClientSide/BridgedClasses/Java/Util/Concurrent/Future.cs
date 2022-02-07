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

namespace MASES.KafkaBridge.Java.Util.Concurrent
{
    public class Future<E> : JCOBridge.C2JBridge.JVMBridgeBase<Future<E>>
        where E : JCOBridge.C2JBridge.JVMBridgeBase, new()
    {
        public override string ClassName => "java.util.concurrent.Future";

        bool Cancel(bool mayInterruptIfRunning)
        {
            return IExecute<bool>("cancel", mayInterruptIfRunning);
        }

        public E Get()
        {
            return IExecute<E>("get");
        }

        public E Get(long timeout, TimeUnit unit)
        {
            return IExecute<E>("get", timeout, unit);
        }

        public bool IsCancelled => IExecute<bool>("isCancelled");

        public bool IsDone => IExecute<bool>("isDone");
    }
}
