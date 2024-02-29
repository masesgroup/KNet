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
    /// .NET interface for <see cref="IConnector"/>
    /// </summary>
    public interface IVersion
    {
        /// <summary>
        /// Returns version string
        /// </summary>
        string Version();
    }
    /// <summary>
    /// .NET interface for <see cref="Connector"/>
    /// </summary>
    public interface IConnector : IVersion
    {
        /// <inheritdoc cref="Connector.Initialize(ConnectorContext)"/>
        void Initialize(ConnectorContext ctx);
        /// <inheritdoc cref="Connector.Initialize(ConnectorContext, Java.Util.List{Map{Java.Lang.String, Java.Lang.String}})"/>
        void Initialize(ConnectorContext ctx, Java.Util.List<Map<Java.Lang.String, Java.Lang.String>> taskConfigs);
        /// <inheritdoc cref="Connector.Start(Map{Java.Lang.String, Java.Lang.String})"/>
        void Start(Map<Java.Lang.String, Java.Lang.String> props);
        /// <inheritdoc cref="Connector.Reconfigure(Map{Java.Lang.String, Java.Lang.String})"/>
        void Reconfigure(Map<Java.Lang.String, Java.Lang.String> props);
        /// <inheritdoc cref="Connector.TaskClass{ReturnExtendsOrg_Apache_Kafka_Connect_Connector_Task}"/>
        Class TaskClass();
        /// <inheritdoc cref="Connector.TaskConfigs(int)"/>
        Java.Util.List<Map<Java.Lang.String, Java.Lang.String>> TaskConfigs(int maxTasks);
        /// <inheritdoc cref="Connector.Stop"/>
        void Stop();
        /// <inheritdoc cref="Connector.Validate(Map{Java.Lang.String, Java.Lang.String})"/>
        Config Validate(Map<Java.Lang.String, Java.Lang.String> connectorConfigs);
        /// <inheritdoc cref="Connector.Config"/>
        ConfigDef Config();
    }

    /// <summary>
    /// Specific implementation of <see cref="IConnector"/> to support KNet Connect SDK
    /// </summary>
    public interface IKNetConnector : IConnector
    {
        /// <summary>
        /// The properties retrieved from <see cref="KNetConnector.StartInternal"/>
        /// </summary>
        IReadOnlyDictionary<string, string> Properties { get; }
        /// <summary>
        /// Allocates a task object based on <see cref="KNetTask"/>
        /// </summary>
        /// <param name="taskId">The unique id generated from JAva side</param>
        /// <returns>The local .NET object</returns>
        object AllocateTask(long taskId);
        /// <summary>
        /// The unique name of the connector
        /// </summary>
        string ConnectorName { get; }
        /// <summary>
        /// The <see cref="Type"/> of task to be allocated, it shall inherits from <see cref="KNetTask"/>
        /// </summary>
        Type TaskClassType { get; }
        /// <summary>
        /// Implement the method to execute the start action
        /// </summary>
        /// <param name="props">The set of properties returned from Apache Kafka Connect framework: the <see cref="IReadOnlyDictionary{TKey, TValue}"/> contains the same info from configuration file.</param>
        void Start(IReadOnlyDictionary<string, string> props);
        /// <summary>
        /// Invoked during allocation of tasks from Apache Kafka Connect
        /// </summary>
        /// <param name="index">The actual index</param>
        /// <param name="config">The <see cref="IDictionary{TKey, TValue}"/> to be filled in with properties for the task: the same will be received from <see cref="KNetTask.Start(IReadOnlyDictionary{string, string})"/></param>
        void TaskConfigs(int index, IDictionary<string, string> config);
    }
    /// <summary>
    /// The generic class which is the base of both source or sink connectors
    /// </summary>
    public abstract class KNetConnector : IKNetConnector, IKNetConnectLogging
    {
        /// <summary>
        /// The set of allocated <see cref="KNetTask"/> with their associated identifiers
        /// </summary>
        protected ConcurrentDictionary<long, KNetTask> taskDictionary = new();

        IJavaObject reflectedConnector = null;
        /// <summary>
        /// Initializer
        /// </summary>
        public KNetConnector()
        {
            KNetConnectProxy.RegisterCLRGlobal(ReflectedConnectorClassName, this);
        }

        /// <summary>
        /// An helper function to read the data from Java side
        /// </summary>
        /// <param name="method">Method name to be invoked</param>
        /// <param name="args">Arguments of the <paramref name="method"/> to be invoked</param>
        /// <exception cref="InvalidOperationException"> </exception>
        protected void ExecuteOnConnector(string method, params object[] args)
        {
            reflectedConnector ??= KNetConnectProxy.GetJVMGlobal(ReflectedConnectorClassName);
            if (reflectedConnector != null) reflectedConnector.Invoke(method, args);
            else throw new InvalidOperationException($"{ReflectedConnectorClassName} was not registered in global JVM");
        }

        /// <summary>
        /// An helper function to read the data from Java side
        /// </summary>
        /// <typeparam name="T">The expected return <see cref="Type"/></typeparam>
        /// <param name="method">Method name to be invoked</param>
        /// <param name="args">Arguments of the <paramref name="method"/> to be invoked</param>
        /// <returns>The <typeparamref name="T"/></returns>
        /// <exception cref="InvalidOperationException"> </exception>
        protected T ExecuteOnConnector<T>(string method, params object[] args)
        {
            reflectedConnector ??= KNetConnectProxy.GetJVMGlobal(ReflectedConnectorClassName);
            return (reflectedConnector != null) ? reflectedConnector.Invoke<T>(method, args) : throw new InvalidOperationException($"{ReflectedConnectorClassName} was not registered in global JVM");
        }

        /// <summary>
        /// An helper function to read the data from Java side
        /// </summary>
        /// <typeparam name="T">The expected return <see cref="Type"/></typeparam>
        /// <returns>The <typeparamref name="T"/></returns>
        /// <exception cref="InvalidOperationException"> </exception>
        protected T DataToExchange<T>()
        {
            return ExecuteOnConnector<T>("getDataToExchange");
        }
        /// <summary>
        /// An helper function to read the data from Java side
        /// </summary>
        /// <exception cref="InvalidOperationException"> </exception>
        protected void DataToExchange(object data)
        {
            reflectedConnector ??= KNetConnectProxy.GetJVMGlobal(ReflectedConnectorClassName);
            if (reflectedConnector != null)
            {
                IJVMBridgeBase jvmBBD = data as IJVMBridgeBase;
                reflectedConnector.Invoke("setDataToExchange", jvmBBD != null ? jvmBBD.BridgeInstance : data);
            }
            else
            {
                throw new InvalidOperationException($"{ReflectedConnectorClassName} was not registered in global JVM");
            }
        }

        /// <summary>
        /// An helper function to read context data from Java side
        /// </summary>
        /// <typeparam name="T">The expected return <see cref="Type"/></typeparam>
        /// <returns>The <typeparamref name="T"/></returns>
        /// <exception cref="InvalidOperationException"> </exception>
        protected T Context<T>()
        {
            return ExecuteOnConnector<T>("getContext");
        }

        /// <inheritdoc cref="IKNetConnector.Properties"/>
        public IReadOnlyDictionary<string, string> Properties { get; private set; }

        /// <inheritdoc cref="IKNetConnector.AllocateTask(long)"/>
        public object AllocateTask(long taskId)
        {
            return taskDictionary.GetOrAdd(taskId, (id) =>
            {
                KNetTask knetTask = Activator.CreateInstance(TaskClassType) as KNetTask;
                knetTask.Initialize(this, id);
                return knetTask;
            });
        }
        /// <summary>
        /// The unique name used to map objects between JVM and .NET
        /// </summary>
        public abstract string ReflectedConnectorClassName { get; }
        /// <inheritdoc cref="IKNetConnector.ConnectorName"/>
        public abstract string ConnectorName { get; }
        /// <inheritdoc cref="IKNetConnector.TaskClassType"/>
        public abstract Type TaskClassType { get; }
        /// <summary>
        /// Not implemented
        /// </summary>
        /// <exception cref="NotImplementedException">Invoked in Java before any initialization</exception>
        public void Initialize(ConnectorContext ctx) => throw new NotImplementedException("Invoked in Java before any initialization.");
        /// <summary>
        /// Not implemented
        /// </summary>
        /// <exception cref="NotImplementedException">Invoked in Java before any initialization</exception>
        public void Initialize(ConnectorContext ctx, Java.Util.List<Map<Java.Lang.String, Java.Lang.String>> taskConfigs) => throw new NotImplementedException("Invoked in Java before any initialization.");
        /// <summary>
        /// Public method used from Java to trigger <see cref="Start(Map{Java.Lang.String, Java.Lang.String})"/>
        /// </summary>
        public void StartInternal()
        {
            Map<Java.Lang.String, Java.Lang.String> props = DataToExchange<Map<Java.Lang.String, Java.Lang.String>>();
            Properties = new System.Collections.Generic.Dictionary<string, string>(props.ToNetDictiony<string, string, Java.Lang.String, Java.Lang.String>());
            Start(Properties);
        }
        /// <summary>
        /// Not implemented
        /// </summary>
        /// <exception cref="NotImplementedException">Local version with a different signature</exception>
        public void Start(Map<Java.Lang.String, Java.Lang.String> props) => throw new NotImplementedException("Local version with a different signature");

        /// <inheritdoc cref="IKNetConnector.Start(IReadOnlyDictionary{string, string})"/>
        public abstract void Start(IReadOnlyDictionary<string, string> props);
        /// <summary>
        /// Not implemented
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Reconfigure(Map<Java.Lang.String, Java.Lang.String> props) => throw new NotImplementedException("Invoked in Java before any initialization.");
        /// <summary>
        /// Not implemented
        /// </summary>
        /// <exception cref="NotImplementedException">Invoked in Java before any initialization</exception>
        public Class TaskClass() => throw new NotImplementedException("Invoked in Java before any initialization.");
        /// <summary>
        /// Public method used from Java to trigger <see cref="TaskConfigs(int, IDictionary{string, string})"/>
        /// </summary>
        public void TaskConfigsInternal(int index)
        {
            Map<Java.Lang.String, Java.Lang.String> props = DataToExchange<Map<Java.Lang.String, Java.Lang.String>>();
            System.Collections.Generic.Dictionary<string, string> dict = new System.Collections.Generic.Dictionary<string, string>(props.ToNetDictiony<string, string, Java.Lang.String, Java.Lang.String>());
            TaskConfigs(index, dict);
            props.Clear();
            foreach (var item in dict)
            {
                props.Put(item.Key, item.Value);
            }
        }
        /// <inheritdoc cref="IKNetConnector.TaskConfigs(int, IDictionary{string, string})"/>
        public abstract void TaskConfigs(int index, IDictionary<string, string> config);
        /// <summary>
        /// Not implemented
        /// </summary>
        /// <exception cref="NotImplementedException">Invoked using the other signature</exception>
        public Java.Util.List<Map<Java.Lang.String, Java.Lang.String>> TaskConfigs(int maxTasks) => throw new NotImplementedException("Invoked using the other signature.");
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
        /// Not implemented
        /// </summary>
        /// <exception cref="NotImplementedException">Invoked in Java before any initialization</exception>
        public Config Validate(Map<Java.Lang.String, Java.Lang.String> connectorConfigs) => throw new NotImplementedException("Invoked in Java before any initialization.");
        /// <summary>
        /// Not implemented
        /// </summary>
        /// <exception cref="NotImplementedException">Invoked in Java before any initialization</exception>
        public ConfigDef Config() => throw new NotImplementedException("Invoked in Java before any initialization.");
        /// <summary>
        /// Not implemented
        /// </summary>
        /// <exception cref="NotImplementedException">Invoked in Java before any initialization</exception>
        public string Version() => throw new NotImplementedException("Invoked in Java before any initialization.");

        #region IKNetConnectLogging
        /// <inheritdoc cref="IKNetConnectLogging.IsTraceEnabled"/>
        public bool IsTraceEnabled => ExecuteOnConnector<bool>("isTraceEnabled");
        /// <inheritdoc cref="IKNetConnectLogging.IsDebugEnabled"/>
        public bool IsDebugEnabled => ExecuteOnConnector<bool>("isDebugEnabled");
        /// <inheritdoc cref="IKNetConnectLogging.IsInfoEnabled"/>
        public bool IsInfoEnabled => ExecuteOnConnector<bool>("isInfoEnabled");
        /// <inheritdoc cref="IKNetConnectLogging.IsWarnEnabled"/>
        public bool IsWarnEnabled => ExecuteOnConnector<bool>("isWarnEnabled");
        /// <inheritdoc cref="IKNetConnectLogging.IsErrorEnabled"/>
        public bool IsErrorEnabled => ExecuteOnConnector<bool>("isErrorEnabled");
        /// <inheritdoc cref="IKNetConnectLogging.LogTrace(string)"/>
        public void LogTrace(string var1) => ExecuteOnConnector("trace", var1);
        /// <inheritdoc cref="IKNetConnectLogging.LogTrace(string, JVMBridgeException)"/>
        public void LogTrace(string var1, JVMBridgeException var2) => ExecuteOnConnector("trace", var1, var2.BridgeInstance);
        /// <inheritdoc cref="IKNetConnectLogging.LogDebug(string)"/>
        public void LogDebug(string var1) => ExecuteOnConnector("debug", var1);
        /// <inheritdoc cref="IKNetConnectLogging.LogDebug(string, JVMBridgeException)"/>
        public void LogDebug(string var1, JVMBridgeException var2) => ExecuteOnConnector("debug", var1, var2.BridgeInstance);
        /// <inheritdoc cref="IKNetConnectLogging.LogInfo(string)"/>
        public void LogInfo(string var1) => ExecuteOnConnector("info", var1);
        /// <inheritdoc cref="IKNetConnectLogging.LogInfo(string, JVMBridgeException)"/>
        public void LogInfo(string var1, JVMBridgeException var2) => ExecuteOnConnector("info", var1, var2.BridgeInstance);
        /// <inheritdoc cref="IKNetConnectLogging.LogWarn(string)"/>
        public void LogWarn(string var1) => ExecuteOnConnector("warn", var1);
        /// <inheritdoc cref="IKNetConnectLogging.LogWarn(string, JVMBridgeException)"/>
        public void LogWarn(string var1, JVMBridgeException var2) => ExecuteOnConnector("warn", var1, var2.BridgeInstance);
        /// <inheritdoc cref="IKNetConnectLogging.LogError(string)"/>
        public void LogError(string var1) => ExecuteOnConnector("error", var1);
        /// <inheritdoc cref="IKNetConnectLogging.LogError(string, JVMBridgeException)"/>
        public void LogError(string var1, JVMBridgeException var2) => ExecuteOnConnector("error", var1, var2.BridgeInstance);
        #endregion
    }
    /// <summary>
    /// The base connector class which is the base of both source or sink connectors and receives information about implementing class with <typeparamref name="TConnector"/> 
    /// </summary>
    /// <typeparam name="TConnector">The class which extends <see cref="KNetConnector{TConnector}"/></typeparam>
    public abstract class KNetConnector<TConnector> : KNetConnector
        where TConnector : KNetConnector<TConnector>
    {
        /// <summary>
        /// Set the <see cref="IKNetConnector.ConnectorName"/> of the connector to the value defined from <typeparamref name="TConnector"/>
        /// </summary>
        public override string ConnectorName => typeof(TConnector).FullName;
    }
}
