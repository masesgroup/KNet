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

using Java.Util;
using MASES.JCOBridge.C2JBridge;
using MASES.KNet.Common.Config;
using MASES.KNet.Connect.Data;
using MASES.KNet.Connect.Header;

namespace MASES.KNet.Connect.Storage
{
    public class Converter : JVMBridgeBase<Converter>
    {
        public override bool IsInterface => true;

        public override string ClassName => "org.apache.kafka.connect.storage.Converter";

        public void Configure(Map<string, object> configs, bool isKey) => IExecute("configure", configs, isKey);

        public byte[] FromConnectData(string topic, Schema schema, object value) => IExecute<byte[]>("fromConnectData", topic, schema, value);

        public byte[] FromConnectData(string topic, Headers headers, Schema schema, object value) => IExecute<byte[]>("fromConnectData", topic, headers, schema, value);

        public SchemaAndValue ToConnectData(string topic, byte[] value) => IExecute<SchemaAndValue>("toConnectData", topic, value);

        public SchemaAndValue ToConnectData(string topic, Headers headers, byte[] value) => IExecute<SchemaAndValue>("toConnectData", topic, headers, value);

        public ConfigDef Config => IExecute<ConfigDef>("config");
    }
}
