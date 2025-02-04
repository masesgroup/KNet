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

using Java.Lang;
using MASES.JCOBridge.C2JBridge.JVMInterop;

namespace Org.Apache.Kafka.Common.Header
{
    public partial class Headers
    {
        /// <summary>
        /// Helper to create <see cref="Headers"/>
        /// </summary>
        public static Headers Create()
        {
            var obj = MASES.JCOBridge.C2JBridge.JCOBridge.Global.JVM.New("org.apache.kafka.common.header.internals.RecordHeaders") as IJavaObject;
            return WrapsDirect<Headers>(obj);
        }
        /// <summary>
        /// Helper to create <see cref="Headers"/>
        /// </summary>
        public static Headers Create(Header[] headers)
        {
            var obj = MASES.JCOBridge.C2JBridge.JCOBridge.Global.JVM.New("org.apache.kafka.common.header.internals.RecordHeaders", headers) as IJavaObject;
            return WrapsDirect<Headers>(obj);
        }
        /// <summary>
        /// Helper to create <see cref="Headers"/>
        /// </summary>
        public static Headers Create(Iterable<Header> headers)
        {
            var obj = MASES.JCOBridge.C2JBridge.JCOBridge.Global.JVM.New("org.apache.kafka.common.header.internals.RecordHeaders", headers) as IJavaObject;
            return WrapsDirect<Headers>(obj);
        }
    }
}
