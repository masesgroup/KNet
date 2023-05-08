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

using MASES.JCOBridge.C2JBridge;
using MASES.KNet.Connect.Data;

namespace MASES.KNet.Connect.Header
{
    public class Header : JVMBridgeBase<Header>
    {
        public override bool IsBridgeInterface => true;
        public override string BridgeClassName => "org.apache.kafka.connect.header.Header";

        public string Key => IExecute<string>("key");

        public Schema Schema => IExecute<Schema>("schema");

        public object Value => IExecute("value");

        public Header With(Schema schema, object value) => IExecute<Header>("with", schema, value);

        public Header Rename(string key) => IExecute<Header>("rename", key);
    }
}
