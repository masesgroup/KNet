/*
*  Copyright (c) 2021-2025 MASES s.r.l.
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
using MASES.JCOBridge.C2JBridge.JVMInterop;
using MASES.JNet;
using MASES.JNet.Specific.Extensions;
using MASES.KNet;
using System;
using System.Reflection;

namespace MASES.KNet.Connect
{
    /// <summary>
    /// Internal class used to proxy and pairs data exchange with Java side
    /// </summary>
    public class KNetConnectProxy
    {
        static internal object RunningCore { get; set; } = null;

        static readonly object globalInstanceLock = new();
        static bool registrationDone = false;
        static KNetConnectProxy globalInstance = null;

        static KNetConnector SinkConnector = null;
        static KNetConnector SourceConnector = null;

        /// <summary>
        /// Initialize the proxy
        /// </summary>
        public static void Initialize<TIn>(TIn core) where TIn : KNetCore<TIn>
        {
            lock (globalInstanceLock)
            {
                if (globalInstance == null)
                {
                    RunningCore = core;
                    globalInstance = new KNetConnectProxy();
                }
            }
        }

        /// <summary>
        /// Initialize the proxy
        /// </summary>
        public static void RegisterCLRGlobal(string key, object value)
        {
            MASES.JCOBridge.C2JBridge.JCOBridge.Global.Management.RegisterCLRGlobal(key, value);
        }

        /// <summary>
        /// Initialize the proxy
        /// </summary>
        public static IJavaObject GetJVMGlobal(string key)
        {
            return MASES.JCOBridge.C2JBridge.JCOBridge.Global.Management.GetJVMGlobal(key);
        }

        /// <summary>
        /// Register the proxy
        /// </summary>
        public static void Register()
        {
            lock (globalInstanceLock)
            {
                if (globalInstance == null) throw new InvalidOperationException("Method Initialized was never called.");
                if (!registrationDone)
                {
                    RegisterCLRGlobal("KNetConnectProxy", globalInstance);
                    registrationDone = true;
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
                Type type;
                try
                {
                    type = Type.GetType(connectorClassName, true);
                }
                catch
                {
                    Org.Apache.Kafka.Common.Config.ConfigException.ThrowNew($"Unable to find {connectorClassName}");
                    return false;
                }

                try
                {
                    SinkConnector = Activator.CreateInstance(type) as KNetConnector;
                    if (SinkConnector == null) throw new InvalidCastException($"{connectorClassName} is not a class extending {nameof(KNetConnector)}");
                    SinkConnector.Register();
                }
                catch (Exception ex)
                {
                    Org.Apache.Kafka.Common.Config.ConfigException.ThrowNew($"Failed to create an instance of {connectorClassName}: {ex}");
                    return false;
                }

                try
                {
                    RegisterCLRGlobal(SinkConnector.ConnectorName, SinkConnector);
                    return true;
                }
                catch (Exception ex)
                {
                    Org.Apache.Kafka.Common.Config.ConfigException.ThrowNew($"Failed to register the instance of {connectorClassName}: {ex}");
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
                Type type;
                try
                {
                    type = Type.GetType(connectorClassName, true);
                }
                catch
                {
                    Org.Apache.Kafka.Common.Config.ConfigException.ThrowNew($"Unable to find {connectorClassName}");
                    return false;
                }

                try
                {
                    SourceConnector = Activator.CreateInstance(type) as KNetConnector;
                    if (SourceConnector == null) throw new InvalidCastException($"{connectorClassName} is not a class extending {nameof(KNetConnector)}");
                    SourceConnector.Register();
                }
                catch (Exception ex)
                {
                    Org.Apache.Kafka.Common.Config.ConfigException.ThrowNew($"Failed to create an instance of {connectorClassName}: {ex}");
                    return false;
                }

                try
                {
                    RegisterCLRGlobal(SourceConnector.ConnectorName, SourceConnector);
                    return true;
                }
                catch (Exception ex)
                {
                    Org.Apache.Kafka.Common.Config.ConfigException.ThrowNew($"Failed to register the instance of {connectorClassName}: {ex}");
                    return false;
                }
            }
        }

        /// <summary>
        /// Allocates a source connector
        /// </summary>
        /// <param name="connectorClassName">The class name read from Java within the configuration parameters</param>
        /// <param name="uniqueId">Unique identifier of the connector instance</param>
        /// <returns><see langword="true"/> if successfully</returns>
        public bool AllocateConnector(string connectorClassName, string uniqueId)
        {
            Type type;
            try
            {
                type = Type.GetType(connectorClassName, true);
            }
            catch
            {
                Org.Apache.Kafka.Common.Config.ConfigException.ThrowNew($"Unable to find {connectorClassName}");
                return false;
            }

            KNetConnector connector;

            try
            {
                connector = Activator.CreateInstance(type) as KNetConnector;
                if (connector == null) throw new InvalidCastException($"{connectorClassName} is not a class extending {nameof(KNetConnector)}");
                connector.Register(uniqueId);
            }
            catch (Exception ex)
            {
                Org.Apache.Kafka.Common.Config.ConfigException.ThrowNew($"Failed to create an instance of {connectorClassName}: {ex}");
                return false;
            }

            return true;
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
