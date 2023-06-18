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

using Java.Nio;
using MASES.JCOBridge.C2JBridge.JVMInterop;

namespace Org.Apache.Kafka.Common.Header
{
    public partial class Header
    {
        public static Header Create(string key, byte[] value)
        {
            var obj = MASES.JCOBridge.C2JBridge.JCOBridge.Global.JVM.New("org.apache.kafka.common.header.internals.RecordHeader", key, value) as IJavaObject;
            return Wraps<Header>(obj);
        }

        public static Header Create(ByteBuffer keyBuffer, ByteBuffer valueBuffer)
        {
            var obj = MASES.JCOBridge.C2JBridge.JCOBridge.Global.JVM.New("org.apache.kafka.common.header.internals.RecordHeader", keyBuffer, valueBuffer) as IJavaObject;
            return Wraps<Header>(obj);
        }
    }
}
