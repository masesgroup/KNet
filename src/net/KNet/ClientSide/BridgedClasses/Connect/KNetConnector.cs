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

using Java.Lang;
using Java.Util;
using MASES.JCOBridge.C2JBridge.JVMInterop;
using MASES.KNet.Common.Config;
using MASES.KNet.Connect.Connector;
using System;
using System.Collections.Concurrent;

namespace MASES.KNet.Connect
{
    /// <summary>
    /// Specific implementation of <see cref="IConnector"/> to support KNet Connect SDK
    /// </summary>
    public interface IKNetConnector : IConnector
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
        /// Invoked during allocation of tasks from Apache Kafka Connect
        /// </summary>
        /// <param name="index">The actual index</param>
        /// <param name="config">The <see cref="Map{string, string}"/> to be filled in with properties for the task: the same will be received from <see cref="KNetTask.Start(Map{string, string})"/></param>
        void TaskConfigs(int index, Map<string, string> config);
    }
    /// <summary>
    /// The generic class which is the base of both source or sink connectors
    /// </summary>
    public abstract class KNetConnector : IKNetConnector
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
            KNetCore.GlobalInstance.RegisterCLRGlobal(ReflectedConnectorClassName, this);
        }
        /// <summary>
        /// An helper function to read the data from Java side
        /// </summary>
        /// <typeparam name="T">The expected return <see cref="Type"/></typeparam>
        /// <returns>The <typeparamref name="T"/></returns>
        /// <exception cref="InvalidOperationException"> </exception>
        protected T DataToExchange<T>()
        {
            if (reflectedConnector == null)
            {
                reflectedConnector = KNetCore.GlobalInstance.GetJVMGlobal(ReflectedConnectorClassName);
            }
            return (reflectedConnector != null) ? reflectedConnector.Invoke<T>("getDataToExchange") : throw new InvalidOperationException($"{ReflectedConnectorClassName} was not registered in global JVM");
        }
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

        public void Initialize(ConnectorContext ctx) => throw new NotImplementedException("Invoked in Java before any initialization.");

        public void Initialize(ConnectorContext ctx, List<Map<string, string>> taskConfigs) => throw new NotImplementedException("Invoked in Java before any initialization.");
        /// <summary>
        /// Public method used from Java to trigger <see cref="Start(Map{string, string})"/>
        /// </summary>
        public void StartInternal()
        {
            Map<string, string> props = DataToExchange<Map<string, string>>();
            Start(props);
        }
        /// <summary>
        /// Implement the method to execute the start action
        /// </summary>
        /// <param name="props">The set of properties returned from Apache Kafka Connect framework: the <see cref="Map{string, string}"/> contains the same info from configuration file.</param>
        public abstract void Start(Map<string, string> props);

        public void Reconfigure(Map<string, string> props) => throw new NotImplementedException("Invoked in Java before any initialization.");

        public Class TaskClass() => throw new NotImplementedException("Invoked in Java before any initialization.");
        /// <summary>
        /// Public method used from Java to trigger <see cref="TaskConfigs(int, Map{string, string})"/>
        /// </summary>
        public void TaskConfigsInternal(int index)
        {
            Map<string, string> props = DataToExchange<Map<string, string>>();
            TaskConfigs(index, props);
        }
        /// <inheritdoc cref="IKNetConnector.TaskConfigs(int, Map{string, string})"/>
        public abstract void TaskConfigs(int index, Map<string, string> config);

        public List<Map<string, string>> TaskConfigs(int maxTasks) => throw new NotImplementedException("Invoked using the other signature.");
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

        public Config Validate(Map<string, string> connectorConfigs) => throw new NotImplementedException("Invoked in Java before any initialization.");

        public ConfigDef Config() => throw new NotImplementedException("Invoked in Java before any initialization.");

        public string Version() => throw new NotImplementedException("Invoked in Java before any initialization.");
    }
}
