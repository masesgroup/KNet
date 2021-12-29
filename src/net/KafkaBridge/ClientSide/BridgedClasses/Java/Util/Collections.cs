/*
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

using MASES.JCOBridge.C2JBridge;

namespace MASES.KafkaBridge.Java.Util
{
    public class Collections : JCOBridge.C2JBridge.JVMBridgeBase<Collections>
    {
        public override bool IsStatic => true;
        public override string ClassName => "java.util.Collections";

        public static Set<E> singleton<E>(E element)
        {
            return SExecute<Set<E>>("singleton", 
                                    (typeof(JVMBridgeBase).IsAssignableFrom(typeof(E))) ? (object)(element as JVMBridgeBase).Instance : (object)element);
        }

        public static List<E> singletonList<E>(E element)
        {
            return SExecute<List<E>>("singleton", 
                                     (typeof(JVMBridgeBase).IsAssignableFrom(typeof(E))) ? (object)(element as JVMBridgeBase).Instance : (object)element);
        }

        public static Map<K, V> singletonMap<K, V>(K key, V value)
        {
            return SExecute<Map<K, V>>("singletonMap", 
                                       (typeof(JVMBridgeBase).IsAssignableFrom(typeof(K))) ? (object)(key as JVMBridgeBase).Instance : (object)key,
                                       (typeof(JVMBridgeBase).IsAssignableFrom(typeof(V))) ? (object)(value as JVMBridgeBase).Instance : (object)value);
        }
    }
}
