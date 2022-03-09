﻿/*
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
using MASES.JCOBridge.C2JBridge.JVMInterop;

namespace Java.Util
{
    public class Map : JVMBridgeBase<Map>
    {
        public override string ClassName => "java.util.Map";

        public Map()
        {
        }

        public Map(params object[] args)
            : base(args)
        {
        }
    }

    public class Map<K, V> : Map
    {
        public override string ClassName => "java.util.Map";

        public Map()
        {
        }

        public Map(params object[] args)
            : base(args)
        {
        }

        public virtual V Get​(K key) { return IExecute<V>("get", key); }

        public virtual V Put​(K key, V value)
        {
            var obj = IExecute<V>("put", key, value);
            if (value is IJVMBridgeBase)
            {
                return Wraps<V>(obj as IJavaObject);
            }
            else return obj;
        }
    }
}