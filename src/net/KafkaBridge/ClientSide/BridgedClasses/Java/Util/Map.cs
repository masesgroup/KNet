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

namespace MASES.KafkaBridge.Java.Util
{
    public class Map<K, V> : JCOBridge.C2JBridge.JVMBridgeBase<Map<K, V>>
    {
        public override string ClassName => "java.util.Map";

        public virtual V Get​(K key) { return IExecute<V>("get", key); }

        public virtual V Put​(K key, V value) 
        {
            object val = value;
            if (typeof(JCOBridge.C2JBridge.JVMBridgeBase).IsAssignableFrom(typeof(V)))
            {
                val = (value as JCOBridge.C2JBridge.JVMBridgeBase).Instance;
            }

            return IExecute<V>("put", key, val); 
        }
    }

    public class Map2<K, V> : Map<K, V> where V : JCOBridge.C2JBridge.JVMBridgeBase, new()
    {
        public override V Get​(K key) { return New<V>("get", key); }
    }
}