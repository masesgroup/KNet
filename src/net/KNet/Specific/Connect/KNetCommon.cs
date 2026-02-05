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

using Java.Lang;
using Java.Util;
using MASES.JCOBridge.C2JBridge;
using MASES.JCOBridge.C2JBridge.JVMInterop;
using MASES.JNet.Specific.Extensions;
using Org.Apache.Kafka.Common.Config;
using Org.Apache.Kafka.Connect.Connector;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace MASES.KNet.Connect
{
   
    /// <summary>
    /// The generic class which is the base of the KNet Connect SDK classes
    /// </summary>
    public abstract class KNetCommon : IKNetConnectLogging
    {
        string _uniqueId = null;

        IJavaObject reflectedConnector = null;

        /// <summary>
        /// Initialize the <paramref name="uniqueId"/> and register itself
        /// </summary>
        /// <param name="uniqueId"></param>
        public void Register(string uniqueId = null)
        {
            _uniqueId = uniqueId;
            KNetConnectProxy.RegisterCLRGlobal(UniqueId, this);
        }

        /// <summary>
        /// Unregister itself
        /// </summary>
        public void Unregister()
        {
            KNetConnectProxy.UnregisterCLRGlobal(UniqueId);
        }

        /// <summary>
        /// Returns the unique id of this instance
        /// </summary>
        protected string UniqueId => _uniqueId != null ? _uniqueId : ReflectedRemoteObjectClassName;

        /// <summary>
        /// An helper function to execute operation in the Java side
        /// </summary>
        /// <param name="method">Method name to be invoked</param>
        /// <param name="args">Arguments of the <paramref name="method"/> to be invoked</param>
        /// <exception cref="InvalidOperationException"> </exception>
        protected void ExecuteOnRemote(string method, params object[] args)
        {
            reflectedConnector ??= KNetConnectProxy.GetJVMGlobal(UniqueId);
            if (reflectedConnector != null) reflectedConnector.Invoke(method, args);
            else throw new InvalidOperationException($"{UniqueId} was not registered in global JVM");
        }

        /// <summary>
        /// An helper function to read the data from Java side
        /// </summary>
        /// <typeparam name="T">The expected return <see cref="Type"/></typeparam>
        /// <param name="method">Method name to be invoked</param>
        /// <param name="args">Arguments of the <paramref name="method"/> to be invoked</param>
        /// <returns>The <typeparamref name="T"/></returns>
        /// <exception cref="InvalidOperationException"> </exception>
        protected T ExecuteOnRemote<T>(string method, params object[] args)
        {
            reflectedConnector ??= KNetConnectProxy.GetJVMGlobal(UniqueId);
            return (reflectedConnector != null) ? reflectedConnector.Invoke<T>(method, args) : throw new InvalidOperationException($"{UniqueId} was not registered in global JVM");
        }

        /// <summary>
        /// An helper function to read the data from Java side
        /// </summary>
        /// <typeparam name="T">The expected return <see cref="Type"/></typeparam>
        /// <returns>The <typeparamref name="T"/></returns>
        /// <exception cref="InvalidOperationException"> </exception>
        protected T DataToExchange<T>()
        {
            return ExecuteOnRemote<T>("getDataToExchange");
        }
        /// <summary>
        /// An helper function to read the data from Java side
        /// </summary>
        /// <exception cref="InvalidOperationException"> </exception>
        protected void DataToExchange(object data)
        {
            reflectedConnector ??= KNetConnectProxy.GetJVMGlobal(UniqueId);
            if (reflectedConnector != null)
            {
                IJVMBridgeBase jvmBBD = data as IJVMBridgeBase;
                reflectedConnector.Invoke("setDataToExchange", jvmBBD != null ? jvmBBD.BridgeInstance : data);
            }
            else
            {
                throw new InvalidOperationException($"{UniqueId} was not registered in global JVM");
            }
        }

        /// <summary>
        /// The unique name used to map objects between JVM and .NET
        /// </summary>
        public abstract string ReflectedRemoteObjectClassName { get; }

        #region IKNetConnectLogging
        /// <inheritdoc cref="IKNetConnectLogging.IsTraceEnabled"/>
        public bool IsTraceEnabled => ExecuteOnRemote<bool>("isTraceEnabled");
        /// <inheritdoc cref="IKNetConnectLogging.IsDebugEnabled"/>
        public bool IsDebugEnabled => ExecuteOnRemote<bool>("isDebugEnabled");
        /// <inheritdoc cref="IKNetConnectLogging.IsInfoEnabled"/>
        public bool IsInfoEnabled => ExecuteOnRemote<bool>("isInfoEnabled");
        /// <inheritdoc cref="IKNetConnectLogging.IsWarnEnabled"/>
        public bool IsWarnEnabled => ExecuteOnRemote<bool>("isWarnEnabled");
        /// <inheritdoc cref="IKNetConnectLogging.IsErrorEnabled"/>
        public bool IsErrorEnabled => ExecuteOnRemote<bool>("isErrorEnabled");
        /// <inheritdoc cref="IKNetConnectLogging.LogTrace(string)"/>
        public void LogTrace(string var1) => ExecuteOnRemote("trace", var1);
        /// <inheritdoc cref="IKNetConnectLogging.LogTrace(string, JVMBridgeException)"/>
        public void LogTrace(string var1, JVMBridgeException var2) => ExecuteOnRemote("trace", var1, var2.BridgeInstance);
        /// <inheritdoc cref="IKNetConnectLogging.LogDebug(string)"/>
        public void LogDebug(string var1) => ExecuteOnRemote("debug", var1);
        /// <inheritdoc cref="IKNetConnectLogging.LogDebug(string, JVMBridgeException)"/>
        public void LogDebug(string var1, JVMBridgeException var2) => ExecuteOnRemote("debug", var1, var2.BridgeInstance);
        /// <inheritdoc cref="IKNetConnectLogging.LogInfo(string)"/>
        public void LogInfo(string var1) => ExecuteOnRemote("info", var1);
        /// <inheritdoc cref="IKNetConnectLogging.LogInfo(string, JVMBridgeException)"/>
        public void LogInfo(string var1, JVMBridgeException var2) => ExecuteOnRemote("info", var1, var2.BridgeInstance);
        /// <inheritdoc cref="IKNetConnectLogging.LogWarn(string)"/>
        public void LogWarn(string var1) => ExecuteOnRemote("warn", var1);
        /// <inheritdoc cref="IKNetConnectLogging.LogWarn(string, JVMBridgeException)"/>
        public void LogWarn(string var1, JVMBridgeException var2) => ExecuteOnRemote("warn", var1, var2.BridgeInstance);
        /// <inheritdoc cref="IKNetConnectLogging.LogError(string)"/>
        public void LogError(string var1) => ExecuteOnRemote("error", var1);
        /// <inheritdoc cref="IKNetConnectLogging.LogError(string, JVMBridgeException)"/>
        public void LogError(string var1, JVMBridgeException var2) => ExecuteOnRemote("error", var1, var2.BridgeInstance);
        #endregion
    }
}
