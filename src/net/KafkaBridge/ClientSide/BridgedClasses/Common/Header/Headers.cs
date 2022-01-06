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

using System.Collections.Generic;

namespace MASES.KafkaBridge.Common.Header
{
    public class Headers : JCOBridge.C2JBridge.JVMBridgeBaseEnumerable<Headers, Header>
    {
        public override string ClassName => "org.apache.kafka.common.header.Headers";

        public Headers Add(Header header)
        {
            IExecute("add", header.Instance);
            return this;
        }

        public Headers Add(string key, byte[] value)
        {
            IExecute("add", key, value);
            return this;
        }

        public Headers Remove(string key)
        {
            IExecute("remove", key);
            return this;
        }

        public Header LastHeader(string key)
        {
            return New<Header>("lastHeader", key);
        }

        public IEnumerable<Header> headers(string key)
        {
            return New<Headers>("headers", key);
        }

        public Header[] ToArray()
        {
            return New<Headers>("toArray").ToArray();
        }
    }
}
