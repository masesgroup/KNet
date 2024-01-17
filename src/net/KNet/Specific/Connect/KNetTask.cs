/*
*  Copyright 2024 MASES s.r.l.
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
using MASES.JCOBridge.C2JBridge.JVMInterop;
using MASES.JNet.Specific.Extensions;
using Org.Apache.Kafka.Connect.Connector;
using System;
using System.Collections.Generic;

namespace MASES.KNet.Connect
{
    /// <summary>
    /// Task interface for KNet Connect SDK
    /// </summary>
    public interface ITask
    {
        /// <summary>
        /// Version
        /// </summary>
        /// <returns></returns>
        string Version();
        /// <summary>
        /// Start task
        /// </summary>
        /// <param name="props"><see cref="Map{K, V}"/> of preperties to use</param>
        void Start(Map<string, string> props);
        /// <summary>
        /// Stop task
        /// </summary>
        void Stop();
    }

    /// <summary>
    /// Specific implementation of <see cref="ITask"/> to support KNet Connect SDK
    /// </summary>
    public interface IKNetTask : ITask
    {
        /// <summary>
        /// The properties retrieved from <see cref="KNetTask.StartInternal"/>
        /// </summary>
        IReadOnlyDictionary<string, string> Properties { get; }
        /// <summary>
        /// The associated <see cref="IConnector"/>
        /// </summary>
        IKNetConnector Connector { get; }
        /// <summary>
        /// The id received during initialization
        /// </summary>
        long TaskId { get; }
        /// <summary>
        /// Implement the method to execute the start action
        /// </summary>
        /// <param name="props">The set of properties returned from Apache Kafka Connect framework: the <see cref="IReadOnlyDictionary{TKey, TValue}"/> contains the info from <see cref="KNetConnector.TaskConfigs(int, IDictionary{string, string})"/>.</param>
        void Start(IReadOnlyDictionary<string, string> props);
    }
    /// <summary>
    /// The generic class which is the base of both source or sink task
    /// </summary>
    public abstract class KNetTask : IKNetTask, IKNetConnectLogging
    {
        IKNetConnector connector;
        long taskId;
        IJavaObject reflectedTask = null;

        internal void Initialize(IKNetConnector connector, long taskId)
        {
            this.connector = connector;
            this.taskId = taskId;
            reflectedTask = KNetConnectProxy.GetJVMGlobal($"{ReflectedTaskClassName}_{taskId}");
        }
        /// <summary>
        /// An helper function to read the data from Java side
        /// </summary>
        /// <param name="method">Method name to be invoked</param>
        /// <param name="args">Arguments of the <paramref name="method"/> to be invoked</param>
        /// <exception cref="InvalidOperationException"> </exception>
        protected void ExecuteOnTask(string method, params object[] args)
        {
            if (reflectedTask != null) reflectedTask.Invoke(method, args);
            else throw new InvalidOperationException($"{ReflectedTaskClassName} was not registered in global JVM");
        }
        /// <summary>
        /// An helper function to read the data from Java side
        /// </summary>
        /// <typeparam name="T">The expected return <see cref="Type"/></typeparam>
        /// <param name="method">Method name to be invoked</param>
        /// <param name="args">Arguments of the <paramref name="method"/> to be invoked</param>
        /// <returns>The <typeparamref name="T"/></returns>
        /// <exception cref="InvalidOperationException"> </exception>
        protected T ExecuteOnTask<T>(string method, params object[] args)
        {
            return (reflectedTask != null) ? reflectedTask.Invoke<T>(method, args) : throw new InvalidOperationException($"{ReflectedTaskClassName} was not registered in global JVM");
        }
        /// <summary>
        /// An helper function to read the data from Java side
        /// </summary>
        /// <typeparam name="T">The expected return <see cref="Type"/></typeparam>
        /// <returns>The <typeparamref name="T"/></returns>
        /// <exception cref="InvalidOperationException"> </exception>
        protected T DataToExchange<T>()
        {
            return ExecuteOnTask<T>("getDataToExchange");
        }
        /// <summary>
        /// An helper function to read the data from Java side
        /// </summary>
        /// <exception cref="InvalidOperationException"> </exception>
        protected void DataToExchange(object data)
        {
            if (reflectedTask != null)
            {
                IJVMBridgeBase jvmBBD = data as IJVMBridgeBase;
                reflectedTask.Invoke("setDataToExchange", jvmBBD != null ? jvmBBD.BridgeInstance : data);
            }
            else
            {
                throw new InvalidOperationException($"{ReflectedTaskClassName} was not registered in global JVM");
            }
        }
        /// <summary>
        /// An helper function to read the data from Java side
        /// </summary>
        /// <typeparam name="T">The expected return <see cref="Type"/></typeparam>
        /// <returns>The <typeparamref name="T"/></returns>
        /// <exception cref="InvalidOperationException"> </exception>
        protected T Context<T>()
        {
            return ExecuteOnTask<T>("getContext");
        }

        /// <inheritdoc cref="IKNetTask.Properties"/>
        public IReadOnlyDictionary<string, string> Properties { get; private set; }
        /// <inheritdoc cref="IKNetTask.Connector"/>
        public IKNetConnector Connector => connector;
        /// <inheritdoc cref="IKNetTask.TaskId"/>
        public long TaskId => taskId;
        /// <summary>
        /// The unique name used to map objects between JVM and .NET
        /// </summary>
        public abstract string ReflectedTaskClassName { get; }
        /// <summary>
        /// Public method used from Java to trigger <see cref="Start(Map{string, string})"/>
        /// </summary>
        public void StartInternal()
        {
            Map<string, string> props = DataToExchange<Map<string, string>>();
            Properties = props.ToDictiony();
            Start(Properties);
        }
        /// <summary>
        /// Not implemented
        /// </summary>
        /// <exception cref="NotImplementedException">Local version with a different signature</exception>
        public void Start(Map<string, string> props) => throw new NotImplementedException("Local version with a different signature");

        /// <inheritdoc cref="IKNetTask.Start(IReadOnlyDictionary{string, string})"/>
        public abstract void Start(IReadOnlyDictionary<string, string> props);
        /// <summary>
        /// Public method used from Java to trigger <see cref="Stop"/>
        /// </summary>
        public void StopInternal()
        {
            Stop();
        }
        /// <summary>
        /// Implement the method to execute the stop action
        /// </summary>
        public abstract void Stop();
        /// <summary>
        /// Public method used from Java to trigger <see cref="Version"/>
        /// </summary>
        public object VersionInternal()
        {
            return Version();
        }
        /// <summary>
        /// Implement the method to execute the version action
        /// </summary>
        public abstract string Version();

        #region IKNetConnectLogging
        /// <inheritdoc cref="IKNetConnectLogging.IsTraceEnabled"/>
        public bool IsTraceEnabled => ExecuteOnTask<bool>("isTraceEnabled");
        /// <inheritdoc cref="IKNetConnectLogging.IsDebugEnabled"/>
        public bool IsDebugEnabled => ExecuteOnTask<bool>("isDebugEnabled");
        /// <inheritdoc cref="IKNetConnectLogging.IsInfoEnabled"/>
        public bool IsInfoEnabled => ExecuteOnTask<bool>("isInfoEnabled");
        /// <inheritdoc cref="IKNetConnectLogging.IsWarnEnabled"/>
        public bool IsWarnEnabled => ExecuteOnTask<bool>("isWarnEnabled");
        /// <inheritdoc cref="IKNetConnectLogging.IsErrorEnabled"/>
        public bool IsErrorEnabled => ExecuteOnTask<bool>("isErrorEnabled");
        /// <inheritdoc cref="IKNetConnectLogging.LogTrace(string)"/>
        public void LogTrace(string var1) => ExecuteOnTask("trace", var1);
        /// <inheritdoc cref="IKNetConnectLogging.LogTrace(string, JVMBridgeException)"/>
        public void LogTrace(string var1, JVMBridgeException var2) => ExecuteOnTask("trace", var1, var2.BridgeInstance);
        /// <inheritdoc cref="IKNetConnectLogging.LogDebug(string)"/>
        public void LogDebug(string var1) => ExecuteOnTask("debug", var1);
        /// <inheritdoc cref="IKNetConnectLogging.LogDebug(string, JVMBridgeException)"/>
        public void LogDebug(string var1, JVMBridgeException var2) => ExecuteOnTask("debug", var1, var2.BridgeInstance);
        /// <inheritdoc cref="IKNetConnectLogging.LogInfo(string)"/>
        public void LogInfo(string var1) => ExecuteOnTask("info", var1);
        /// <inheritdoc cref="IKNetConnectLogging.LogInfo(string, JVMBridgeException)"/>
        public void LogInfo(string var1, JVMBridgeException var2) => ExecuteOnTask("info", var1, var2.BridgeInstance);
        /// <inheritdoc cref="IKNetConnectLogging.LogWarn(string)"/>
        public void LogWarn(string var1) => ExecuteOnTask("warn", var1);
        /// <inheritdoc cref="IKNetConnectLogging.LogWarn(string, JVMBridgeException)"/>
        public void LogWarn(string var1, JVMBridgeException var2) => ExecuteOnTask("warn", var1, var2.BridgeInstance);
        /// <inheritdoc cref="IKNetConnectLogging.LogError(string)"/>
        public void LogError(string var1) => ExecuteOnTask("error", var1);
        /// <inheritdoc cref="IKNetConnectLogging.LogError(string, JVMBridgeException)"/>
        public void LogError(string var1, JVMBridgeException var2) => ExecuteOnTask("error", var1, var2.BridgeInstance);
        #endregion
    }
    /// <summary>
    /// The base task class which is the base of both source or sink task and receives information about implementing class with <typeparamref name="TTask"/> 
    /// </summary>
    /// <typeparam name="TTask">The class which extends <see cref="KNetTask{TTask}"/></typeparam>
    public abstract class KNetTask<TTask> : KNetTask
        where TTask : KNetTask<TTask>
    {
        /// <summary>
        /// Set the <see cref="KNetTask.Version"/> of the task to the value defined from <typeparamref name="TTask"/>
        /// </summary>
        public override string Version() => typeof(TTask).Assembly.GetName().Version.ToString();
    }
}
