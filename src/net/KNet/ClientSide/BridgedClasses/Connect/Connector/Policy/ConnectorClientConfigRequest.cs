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
using MASES.JCOBridge.C2JBridge;
using MASES.KNet.Connect.Health;

namespace MASES.KNet.Connect.Connector.Policy
{
    public class ConnectorClientConfigRequest : JVMBridgeBase<ConnectorClientConfigRequest>
    {
        public enum ClientTypes
        {
            PRODUCER, CONSUMER, ADMIN
        }

        public override string BridgeClassName => "org.apache.kafka.connect.connector.policy.ConnectorClientConfigRequest";

        [System.Obsolete("This is not public in Apache Kafka API")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public ConnectorClientConfigRequest()
        {
        }

        public ConnectorClientConfigRequest(
             string connectorName,
             ConnectorType connectorType,
             Class connectorClass,
             Map<string, object> clientProps,
             ClientTypes clientType)
            : base(connectorName, connectorType, connectorClass, clientProps, clientType)
        {
        }

        public Map<string, object> ClientProps => IExecute<Map<string, object>>("clientProps");

        public ClientTypes ClientType => IExecute<ClientTypes>("clientType");

        public string ConnectorName => IExecute<string>("connectorName");

        public ConnectorType ConnectorType => IExecute<ConnectorType>("connectorType");

        public Class ConnectorClass => IExecute<Class>("connectorClass");
    }
}
