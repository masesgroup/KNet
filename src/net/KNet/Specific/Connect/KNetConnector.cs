/*
*  Copyright (c) 2021-2026 MASES s.r.l.
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
    #region IVersion
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
    #endregion

    #region IConnector
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
        void Start(Map<Java.Lang.String, object> props);
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
    #endregion

    #region IKNetConnector
    /// <summary>
    /// Specific implementation of <see cref="IConnector"/> to support KNet Connect SDK
    /// </summary>
    public interface IKNetConnector : IKNetCommon, IConnector
    {
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
        /// <param name="configuration">The <see cref="IKNetConnectConfiguration"/> to access the properties returned from Apache Kafka Connect framework: the <see cref="IKNetCommon.Properties"/> contains the same info from configuration file.</param>
        void Start(IKNetConnectConfiguration configuration);
        /// <summary>
        /// Invoked during allocation of tasks from Apache Kafka Connect
        /// </summary>
        /// <param name="currentTask">The actual task index</param>
        /// <param name="maxTasks">Max tasks as defined from Apache Kafka Connect framework</param>
        /// <param name="config">The <see cref="IKNetTaskConfiguration"/> to be filled in with properties for the task: the same will be received from <see cref="KNetTask.Start(IKNetConnectConfiguration)"/></param>
        /// <returns><see langword="true"/> to avoid any further invocation of the method, otherwise <see langword="false"/>.</returns>
        /// <remarks>If the connector needs a single task and <paramref name="maxTasks"/> is higher than 1, returning <see langword="true"/> immediately only one configuration is returned to Apache Kafka Connect framework. 
        /// In other word it is possible to stop the configuration requests at any time; only the first one is reported in any case since at least one shall be available.
        /// To configure all <paramref name="maxTasks"/> return always <see langword="false"/>.</remarks>
        bool TaskConfigs(int currentTask, int maxTasks, IKNetTaskConfiguration config);
    }
    #endregion

    #region KNetConnector
    /// <summary>
    /// The generic class which is the base of both source or sink connectors
    /// </summary>
    public abstract class KNetConnector : KNetCommon, IKNetConnector
    {
        /// <summary>
        /// The set of allocated <see cref="KNetTask"/> with their associated identifiers
        /// </summary>
        protected ConcurrentDictionary<long, KNetTask> taskDictionary = new();

        /// <summary>
        /// An helper function to read context data from Java side
        /// </summary>
        /// <typeparam name="T">The expected return <see cref="Type"/></typeparam>
        /// <returns>The <typeparamref name="T"/></returns>
        /// <exception cref="InvalidOperationException"> </exception>
        protected T Context<T>()
        {
            return ExecuteOnRemote<T>("getContext");
        }

        /// <inheritdoc cref="IKNetConnector.AllocateTask(long)"/>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public object AllocateTask(long taskId)
        {
            return taskDictionary.GetOrAdd(taskId, (id) =>
            {
                KNetTask knetTask = Activator.CreateInstance(TaskClassType) as KNetTask;
                knetTask.Initialize(this, id);
                return knetTask;
            });
        }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        internal void DeallocateTask(long taskId)
        {
            taskDictionary.TryRemove(taskId, out var knetTask);
        }

        /// <inheritdoc cref="IKNetConnector.ConnectorName"/>
        public abstract string ConnectorName { get; }
        /// <inheritdoc cref="IKNetConnector.TaskClassType"/>
        public abstract Type TaskClassType { get; }
        /// <summary>
        /// Not implemented
        /// </summary>
        /// <exception cref="NotImplementedException">Invoked in Java before any initialization</exception>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void Initialize(ConnectorContext ctx) => throw new NotImplementedException("Invoked in Java before any initialization.");
        /// <summary>
        /// Not implemented
        /// </summary>
        /// <exception cref="NotImplementedException">Invoked in Java before any initialization</exception>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void Initialize(ConnectorContext ctx, Java.Util.List<Map<Java.Lang.String, Java.Lang.String>> taskConfigs) => throw new NotImplementedException("Invoked in Java before any initialization.");
        /// <summary>
        /// Public method used from Java to trigger <see cref="Start(Map{Java.Lang.String, object})"/>
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void StartInternal()
        {
            try
            {
                Map<Java.Lang.String, object> props = DataToExchange<Map<Java.Lang.String, object>>();
                Start(props);
                Properties = new KNetConnectConfiguration(props);
                Start(Properties);
            }
            catch (System.Exception e)
            {
                LogError($"StartInternal failed with {e}");
                throw;
            }
        }
        /// <summary>
        /// Not implemented
        /// </summary>
        /// <exception cref="NotImplementedException">Local version with a different signature</exception>
        public virtual void Start(Map<Java.Lang.String, object> props)
        {

        }

        /// <inheritdoc cref="IKNetConnector.Start(IKNetConnectConfiguration)"/>
        public abstract void Start(IKNetConnectConfiguration configuration);
        /// <summary>
        /// Not implemented
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void Reconfigure(Map<Java.Lang.String, Java.Lang.String> props) => throw new NotImplementedException("Invoked in Java before any initialization.");
        /// <summary>
        /// Not implemented
        /// </summary>
        /// <exception cref="NotImplementedException">Invoked in Java before any initialization</exception>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public Class TaskClass() => throw new NotImplementedException("Invoked in Java before any initialization.");
        /// <summary>
        /// Public method used from Java to trigger <see cref="TaskConfigs(int, int, IKNetTaskConfiguration)"/>
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool TaskConfigsInternal(int currentTask, int maxTasks)
        {
            try
            {
                Map<Java.Lang.String, Java.Lang.String> props = DataToExchange<Map<Java.Lang.String, Java.Lang.String>>();
                return TaskConfigs(currentTask, maxTasks, props);
            }
            catch (System.Exception e)
            {
                LogError($"TaskConfigsInternal failed with {e}");
                throw;
            }
        }
        /// <summary>
        /// Direct implementation can be used instead of <see cref="TaskConfigs(int, int, IKNetTaskConfiguration)"/>
        /// </summary>
        /// <param name="currentTask"></param>
        /// <param name="maxTasks"></param>
        /// <param name="props"></param>
        /// <returns></returns>
        public virtual bool TaskConfigs(int currentTask, int maxTasks, Map<Java.Lang.String, Java.Lang.String> props)
        {
            var dict = new System.Collections.Generic.Dictionary<string, string>(props.ToNetDictiony<string, string, Java.Lang.String, Java.Lang.String>());
            bool retVal = TaskConfigs(currentTask, maxTasks, new KNetTaskConfiguration(dict));
            props.Clear();
            foreach (var item in dict)
            {
                props.Put(item.Key, item.Value);
            }
            return retVal;
        }

        /// <inheritdoc cref="IKNetConnector.TaskConfigs(int, int, IKNetTaskConfiguration)"/>
        public abstract bool TaskConfigs(int currentTask, int maxTasks, IKNetTaskConfiguration config);
        /// <summary>
        /// Not implemented
        /// </summary>
        /// <exception cref="NotImplementedException">Invoked using the other signature</exception>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public Java.Util.List<Map<Java.Lang.String, Java.Lang.String>> TaskConfigs(int maxTasks) => throw new NotImplementedException("Invoked using the other signature.");
        /// <summary>
        /// Public method used from Java to trigger <see cref="Stop"/>
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void StopInternal()
        {
            try
            {
                Stop();
            }
            catch (System.Exception e)
            {
                LogError($"StopInternal failed with {e}");
                throw;
            }
        }
        /// <summary>
        /// Implement the method to execute the stop action
        /// </summary>
        public abstract void Stop();
        /// <summary>
        /// Not implemented
        /// </summary>
        /// <exception cref="NotImplementedException">Invoked in Java before any initialization</exception>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)] 
        public Config Validate(Map<Java.Lang.String, Java.Lang.String> connectorConfigs) => throw new NotImplementedException("Invoked in Java before any initialization.");
        /// <summary>
        /// Not implemented
        /// </summary>
        /// <exception cref="NotImplementedException">Invoked in Java before any initialization</exception>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public ConfigDef Config() => throw new NotImplementedException("Invoked in Java before any initialization.");
        /// <summary>
        /// Not implemented
        /// </summary>
        /// <exception cref="NotImplementedException">Invoked in Java before any initialization</exception>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)] 
        public string Version() => throw new NotImplementedException("Invoked in Java before any initialization.");
    }
    #endregion

    #region KNetConnector<TConnector>

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
    #endregion
}
