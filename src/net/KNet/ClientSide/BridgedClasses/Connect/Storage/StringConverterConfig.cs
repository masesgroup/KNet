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
using Org.Apache.Kafka.Common.Config;

namespace Org.Apache.Kafka.Connect.Storage
{
    public class StringConverterConfig : ConverterConfig
    {
        public override string ClassName => "org.apache.kafka.connect.storage.StringConverterConfig";

        public static string ENCODING_CONFIG = SExecute<string>("ENCODING_CONFIG");
        public static string ENCODING_DEFAULT = SExecute<string>("ENCODING_DEFAULT");

        public static ConfigDef ConfigDef => SExecute<ConfigDef>("configDef");

        [System.Obsolete("This is not public in Apache Kafka API")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public StringConverterConfig() { }

        public StringConverterConfig(Map<string, object> props) : base(props)
        {
        }

        public string Encoding => IExecute<string>("encoding");
    }
}
