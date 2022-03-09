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
using System.Collections;
using System.Collections.Generic;

namespace MASES.KafkaBridge.Java.Util
{
    public class Iterator<E> : JVMBridgeBase<Iterator<E>>, IEnumerable<E>
    {
        public override string ClassName => "java.util.Iterator";

        public bool HasNext => IExecute<bool>("hasNext");

        public E Next => IExecute<E>("next");

        public IEnumerator<E> GetEnumerator()
        {
            return new JVMBridgeBaseEnumerator<E>(Instance);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}