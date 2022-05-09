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

using MASES.KNet.Common;
using MASES.KNet.Common.Config;
using MASES.KNet.Connect.Data;

namespace MASES.KNet.Connect.Storage
{
    public class HeaderConverter : Configurable
    {
        public override bool IsInterface => true;

        public override string ClassName => "org.apache.kafka.connect.storage.HeaderConverter";

        public SchemaAndValue ToConnectHeader(string topic, string headerKey, byte[] value) => IExecute<SchemaAndValue>("toConnectHeader", topic, headerKey, value);

        public byte[] FromConnectHeader(string topic, string headerKey, Schema schema, object value) => IExecute<byte[]>("fromConnectHeader", topic, headerKey, schema, value);

        public ConfigDef Config => IExecute<ConfigDef>("config");
    }
}
