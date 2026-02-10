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
using System.Xml;

namespace MASES.KNet.Connect
{
    #region IKNetCommon
    /// <summary>
    /// Helper interface for <see cref="KNetCommon"/>
    /// </summary>
    public interface IKNetCommon : IKNetConnectLogging
    {
        /// <summary>
        /// An helper function to execute operation in the Java side
        /// </summary>
        /// <param name="method">Method name to be invoked</param>
        /// <param name="args">Arguments of the <paramref name="method"/> to be invoked</param>
        /// <exception cref="InvalidOperationException"> </exception>
        void ExecuteOnRemote(string method, params object[] args);

        /// <summary>
        /// An helper function to read the data from Java side
        /// </summary>
        /// <typeparam name="T">The expected return <see cref="Type"/></typeparam>
        /// <param name="method">Method name to be invoked</param>
        /// <param name="args">Arguments of the <paramref name="method"/> to be invoked</param>
        /// <returns>The <typeparamref name="T"/></returns>
        /// <exception cref="InvalidOperationException"> </exception>
        T ExecuteOnRemote<T>(string method, params object[] args);
    }
    #endregion

    #region KNetCommon

    /// <summary>
    /// The generic class which is the base of the KNet Connect SDK classes
    /// </summary>
    public abstract class KNetCommon : IKNetCommon
    {
        string _uniqueId = null;

        IJavaObject reflectedConnectorOrTask = null;

        /// <summary>
        /// Initialize the <paramref name="uniqueId"/> and register itself
        /// </summary>
        /// <param name="uniqueId"></param>
        internal void Register(string uniqueId = null)
        {
            _uniqueId = uniqueId;
            KNetConnectProxy.RegisterCLRGlobal(UniqueId, this);
        }

        /// <summary>
        /// Unregister itself
        /// </summary>
        internal void Unregister()
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
        public void ExecuteOnRemote(string method, params object[] args)
        {
            reflectedConnectorOrTask ??= KNetConnectProxy.GetJVMGlobal(UniqueId);
            if (reflectedConnectorOrTask != null) reflectedConnectorOrTask.Invoke(method, args);
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
        public T ExecuteOnRemote<T>(string method, params object[] args)
        {
            reflectedConnectorOrTask ??= KNetConnectProxy.GetJVMGlobal(UniqueId);
            return (reflectedConnectorOrTask != null) ? reflectedConnectorOrTask.Invoke<T>(method, args) 
                                                      : throw new InvalidOperationException($"{UniqueId} was not registered in global JVM");
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
            reflectedConnectorOrTask ??= KNetConnectProxy.GetJVMGlobal(UniqueId);
            if (reflectedConnectorOrTask != null)
            {
                IJVMBridgeBase jvmBBD = data as IJVMBridgeBase;
                reflectedConnectorOrTask.Invoke("setDataToExchange", jvmBBD != null ? jvmBBD.BridgeInstance : data);
            }
            else
            {
                throw new InvalidOperationException($"{UniqueId} was not registered in global JVM");
            }
        }

        /// <summary>
        /// The unique name used to map objects between JVM and .NET
        /// </summary>
        protected abstract string ReflectedRemoteObjectClassName { get; }

        #region IKNetConnectLogging
        /// <inheritdoc cref="IKNetConnectLogging.Name"/>
        public string Name => ExecuteOnRemote<string>("getName");

        /// <inheritdoc cref="IKNetConnectLogging.IsTraceEnabled"/>
        public bool IsTraceEnabled => ExecuteOnRemote<bool>("isTraceEnabled");
        /// <inheritdoc cref="IKNetConnectLogging.LogTrace(string)"/>
        public void LogTrace(string var1) => ExecuteOnRemote("trace", var1);
        /// <inheritdoc cref="IKNetConnectLogging.LogTrace(string, JVMBridgeException)"/>
        public void LogTrace(string var1, JVMBridgeException var2) => ExecuteOnRemote("trace", var1, var2.BridgeInstance);
        /// <inheritdoc cref="IKNetConnectLogging.LogTrace(string, object[])"/>
        public void LogTrace(string var1, params object[] var2) => ExecuteOnRemote("trace", var2.VarArgRebuild(var1));

        /// <inheritdoc cref="IKNetConnectLogging.IsDebugEnabled"/>
        public bool IsDebugEnabled => ExecuteOnRemote<bool>("isDebugEnabled");
        /// <inheritdoc cref="IKNetConnectLogging.LogDebug(string)"/>
        public void LogDebug(string var1) => ExecuteOnRemote("debug", var1);
        /// <inheritdoc cref="IKNetConnectLogging.LogDebug(string, JVMBridgeException)"/>
        public void LogDebug(string var1, JVMBridgeException var2) => ExecuteOnRemote("debug", var1, var2.BridgeInstance);
        /// <inheritdoc cref="IKNetConnectLogging.LogDebug(string, object[])"/>
        public void LogDebug(string var1, params object[] var2) => ExecuteOnRemote("debug", var1, var2.VarArgRebuild(var1));

        /// <inheritdoc cref="IKNetConnectLogging.IsInfoEnabled"/>
        public bool IsInfoEnabled => ExecuteOnRemote<bool>("isInfoEnabled");
        /// <inheritdoc cref="IKNetConnectLogging.LogInfo(string)"/>
        public void LogInfo(string var1) => ExecuteOnRemote("info", var1);
        /// <inheritdoc cref="IKNetConnectLogging.LogInfo(string, JVMBridgeException)"/>
        public void LogInfo(string var1, JVMBridgeException var2) => ExecuteOnRemote("info", var1, var2.BridgeInstance);
        /// <inheritdoc cref="IKNetConnectLogging.LogInfo(string, object[])"/>
        public void LogInfo(string var1, params object[] var2) => ExecuteOnRemote("info", var1, var2.VarArgRebuild(var1));

        /// <inheritdoc cref="IKNetConnectLogging.IsWarnEnabled"/>
        public bool IsWarnEnabled => ExecuteOnRemote<bool>("isWarnEnabled");
        /// <inheritdoc cref="IKNetConnectLogging.LogWarn(string)"/>
        public void LogWarn(string var1) => ExecuteOnRemote("warn", var1);
        /// <inheritdoc cref="IKNetConnectLogging.LogWarn(string, JVMBridgeException)"/>
        public void LogWarn(string var1, JVMBridgeException var2) => ExecuteOnRemote("warn", var1, var2.BridgeInstance);
        /// <inheritdoc cref="IKNetConnectLogging.LogWarn(string, object[])"/>
        public void LogWarn(string var1, params object[] var2) => ExecuteOnRemote("warn", var1, var2.VarArgRebuild(var1));

        /// <inheritdoc cref="IKNetConnectLogging.IsErrorEnabled"/>
        public bool IsErrorEnabled => ExecuteOnRemote<bool>("isErrorEnabled");
        /// <inheritdoc cref="IKNetConnectLogging.LogError(string)"/>
        public void LogError(string var1) => ExecuteOnRemote("error", var1);
        /// <inheritdoc cref="IKNetConnectLogging.LogError(string, JVMBridgeException)"/>
        public void LogError(string var1, JVMBridgeException var2) => ExecuteOnRemote("error", var1, var2.BridgeInstance);
        /// <inheritdoc cref="IKNetConnectLogging.LogError(string, object[])"/>
        public void LogError(string var1, params object[] var2) => ExecuteOnRemote("error", var1, var2.VarArgRebuild(var1));
        #endregion
    }

    #endregion
}
