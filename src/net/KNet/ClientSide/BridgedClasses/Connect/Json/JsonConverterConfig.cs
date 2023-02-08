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

using Java.Util;
using MASES.JCOBridge.C2JBridge;
using MASES.KNet.Common.Config;
using MASES.KNet.Connect.Storage;

namespace MASES.KNet.Connect.Json
{
    public class JsonConverterConfig : ConverterConfig
    {
        public override string ClassName => "org.apache.kafka.connect.json.JsonConverterConfig";

        public static string SCHEMAS_ENABLE_CONFIG => SExecute<string>("SCHEMAS_ENABLE_CONFIG");

        public static bool SCHEMAS_ENABLE_DEFAULT => SExecute<bool>("SCHEMAS_ENABLE_DEFAULT");

        public static string SCHEMAS_CACHE_SIZE_CONFIG => SExecute<string>("SCHEMAS_CACHE_SIZE_CONFIG");

        public static int SCHEMAS_CACHE_SIZE_DEFAULT => SExecute<int>("SCHEMAS_CACHE_SIZE_DEFAULT");

        public static string DECIMAL_FORMAT_CONFIG => SExecute<string>("DECIMAL_FORMAT_CONFIG");

        public static string DECIMAL_FORMAT_DEFAULT => SExecute<string>("DECIMAL_FORMAT_DEFAULT");

        public static ConfigDef ConfigDef => SExecute<ConfigDef>("configDef");

        public JsonConverterConfig(Map<string, object> props) : base(props)
        {
        }

        public bool SchemasEnabled => IExecute<bool>("schemasEnabled");

        public int SchemaCacheSize => IExecute<int>("schemaCacheSize");

        public DecimalFormat DecimalFormat => IExecute<DecimalFormat>("decimalFormat");
    }
}
