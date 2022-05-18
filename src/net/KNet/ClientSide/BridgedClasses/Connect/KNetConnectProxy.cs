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

using System;

namespace MASES.KNet.Connect
{
    /// <summary>
    /// Internal class used to proxy and pairs data exchange with Java side
    /// </summary>
    public class KNetConnectProxy
    {
        static readonly object globalInstanceLock = new();
        static KNetConnectProxy globalInstance = null;

        static KNetConnector SinkConnector = null;
        static KNetConnector SourceConnector = null;
        /// <summary>
        /// Register the proxy
        /// </summary>
        public static void Register()
        {
            lock (globalInstanceLock)
            {
                if (globalInstance == null)
                {
                    globalInstance = new KNetConnectProxy();
                    KNetCore.GlobalInstance.RegisterCLRGlobal("KNetConnectProxy", globalInstance);
                }
            }
        }
        /// <summary>
        /// Allocates a sink connector
        /// </summary>
        /// <param name="connectorClassName">The class name read from Java within the configuration parameters</param>
        /// <returns><see langword="true"/> if successfully</returns>
        public bool AllocateSinkConnector(string connectorClassName)
        {
            lock (globalInstanceLock)
            {
                try
                {
                    var type = Type.GetType(connectorClassName, true);
                    SinkConnector = Activator.CreateInstance(type) as KNetConnector;
                    KNetCore.GlobalInstance.RegisterCLRGlobal(SinkConnector.ConnectorName, SinkConnector);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// Allocates a source connector
        /// </summary>
        /// <param name="connectorClassName">The class name read from Java within the configuration parameters</param>
        /// <returns><see langword="true"/> if successfully</returns>
        public bool AllocateSourceConnector(string connectorClassName)
        {
            lock (globalInstanceLock)
            {
                try
                {
                    var type = Type.GetType(connectorClassName, true);
                    SourceConnector = Activator.CreateInstance(type) as KNetConnector;
                    KNetCore.GlobalInstance.RegisterCLRGlobal(SourceConnector.ConnectorName, SourceConnector);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// Returns the registration name of the sink connector
        /// </summary>
        /// <returns>The content of <see cref="IKNetConnector.ConnectorName"/></returns>
        public string SinkConnectorName()
        {
            lock (globalInstanceLock)
            {
                if (SinkConnector != null) return SinkConnector.ConnectorName;
                return null;
            }
        }
        /// <summary>
        /// Returns the registration name of the sourcce connector
        /// </summary>
        /// <returns>The content of <see cref="IKNetConnector.ConnectorName"/></returns>
        public string SourceConnectorName()
        {
            lock (globalInstanceLock)
            {
                if (SourceConnector != null) return SourceConnector.ConnectorName;
                return null;
            }
        }
    }
}
