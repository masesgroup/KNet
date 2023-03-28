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
using Java.Util;
using Org.Apache.Kafka.Common.Config;
using Org.Apache.Kafka.Connect.Components;

namespace Org.Apache.Kafka.Connect.Connector
{
    public interface IConnector : IVersion
    {
        void Initialize(ConnectorContext ctx);

        void Initialize(ConnectorContext ctx, List<Map<string, string>> taskConfigs);

        void Start(Map<string, string> props);

        void Reconfigure(Map<string, string> props);

        Class TaskClass();

        List<Map<string, string>> TaskConfigs(int maxTasks);

        void Stop();

        Config Validate(Map<string, string> connectorConfigs);

        ConfigDef Config();
    }

    public class Connector : Versioned, IConnector
    {
        public override bool IsAbstract => true;
        public override string ClassName => "org.apache.kafka.connect.connector.Connector";

        public void Initialize(ConnectorContext ctx) => IExecute("initialize", ctx);

        public void Initialize(ConnectorContext ctx, List<Map<string, string>> taskConfigs) => IExecute("initialize", ctx, taskConfigs);

        public void Start(Map<string, string> props) => IExecute("start", props);

        public void Reconfigure(Map<string, string> props) => IExecute("reconfigure", props);

        public Class TaskClass() => IExecute<Class>("taskClass");

        public List<Map<string, string>> TaskConfigs(int maxTasks) => IExecute<List<Map<string, string>>>("taskConfigs", maxTasks);

        public void Stop() => IExecute("stop");

        public Config Validate(Map<string, string> connectorConfigs) => IExecute<Config>("validate", connectorConfigs);

        public ConfigDef Config() => IExecute<ConfigDef>("config");
    }
}
