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

namespace MASES.KNet.Clients.Admin
{
    public class ConfigEntry : JCOBridge.C2JBridge.JVMBridgeBase<Config>
    {
        public override string ClassName => "org.apache.kafka.clients.admin.ConfigEntry";

        [System.Obsolete("This is not public in Apache Kafka API")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public ConfigEntry()
        {
        }

        public string Name => IExecute<string>("name");

        public string Value => IExecute<string>("value");

        public ConfigSource Source => IExecute<ConfigSource>("source");

        public bool IsDefault => IExecute<bool>("isDefault");

        public bool IsSensitive => IExecute<bool>("isSensitive");

        public bool IsReadOnly => IExecute<bool>("isReadOnly");

        public List<ConfigSynonym> Synonyms => IExecute<List<ConfigSynonym>>("synonyms");

        public ConfigType Type => IExecute<ConfigType>("type");

        public string Documentation => IExecute<string>("documentation");

        public enum ConfigType
        {
            UNKNOWN,
            BOOLEAN,
            STRING,
            INT,
            SHORT,
            LONG,
            DOUBLE,
            LIST,
            CLASS,
            PASSWORD
        }

        public enum ConfigSource
        {
            DYNAMIC_TOPIC_CONFIG,           // dynamic topic config that is configured for a specific topic
            DYNAMIC_BROKER_LOGGER_CONFIG,   // dynamic broker logger config that is configured for a specific broker
            DYNAMIC_BROKER_CONFIG,          // dynamic broker config that is configured for a specific broker
            DYNAMIC_DEFAULT_BROKER_CONFIG,  // dynamic broker config that is configured as default for all brokers in the cluster
            STATIC_BROKER_CONFIG,           // static broker config provided as broker properties at start up (e.g. server.properties file)
            DEFAULT_CONFIG,                 // built-in default configuration for configs that have a default value
            UNKNOWN                         // source unknown e.g. in the ConfigEntry used for alter requests where source is not set
        }

        public class ConfigSynonym : JCOBridge.C2JBridge.JVMBridgeBase<Config>
        {
            public override string ClassName => "org.apache.kafka.clients.admin.ConfigEntry$ConfigSynonym";

            public string Name => IExecute<string>("name");

            public string Value => IExecute<string>("value");

            public ConfigSource Source => IExecute<ConfigSource>("source");
        }
    }
}

