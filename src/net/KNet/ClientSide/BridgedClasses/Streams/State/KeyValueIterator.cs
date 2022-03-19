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
using Java.Util;
using System.Collections.Generic;

namespace MASES.KNet.Streams.State
{
    public class KeyValueIterator<K, V> : JVMBridgeBaseEnumerable<KeyValueIterator<K, V>, KeyValue<K, V>>
    {
        public override string ClassName => "org.apache.kafka.streams.state.KeyValueIterator";

        public override IEnumerator<KeyValue<K, V>> GetEnumerator()
        {
            return new JVMBridgeBaseEnumerator<KeyValue<K, V>>(Instance);
        }

        public static implicit operator Iterator<KeyValue<K, V>>(KeyValueIterator<K, V> keyValueIterator) { return Wraps<Iterator<KeyValue<K, V>>>(keyValueIterator.Instance); }

        public virtual K PeekNextKey => IExecute<K>("peekNextKey");
    }
}
