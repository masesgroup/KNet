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

using Java.Lang;

namespace MASES.KNet.Common.Header
{
    public class Headers : Iterable<Header>
    {
        public override string BridgeClassName => "org.apache.kafka.common.header.Headers";

        public Headers Add(Header header)
        {
            return IExecute<Headers>("add", header);
        }

        public Headers Add(string key, byte[] value)
        {
            return IExecute<Headers>("add", key, value);
        }

        public Headers Remove(string key)
        {
            return IExecute<Headers>("remove", key);
        }

        public Header LastHeader(string key)
        {
            return IExecute<Header>("lastHeader", key);
        }

        public System.Collections.Generic.IEnumerable<Header> headers(string key)
        {
            return IExecute<Headers>("headers", key);
        }

        public Header[] ToArray()
        {
            return IExecute<Headers>("toArray").ToArray();
        }
    }
}
