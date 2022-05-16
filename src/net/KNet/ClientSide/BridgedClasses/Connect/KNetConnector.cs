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
    public interface IKNetConnector : IConnector
    {
        object AllocateTask(long taskId);

        string ConnectorName { get; }

        Type TaskClassType { get; }
    }

    public abstract class KNetConnector : IKNetConnector
    {
        protected ConnectorContext ctx;
        protected ConcurrentDictionary<long, KNetTask> taskDictionary = new();

        IJavaObject reflectedConnector = null;

        public KNetConnector()
        {
            KNetCore.GlobalInstance.RegisterCLRGlobal(ReflectedConnectorName, this);
        }

        protected T DataToExchange<T>()
        {
            if (reflectedConnector == null)
            {
                reflectedConnector = KNetCore.GlobalInstance.GetJVMGlobal(ReflectedConnectorName);
            }
            return (reflectedConnector != null) ? reflectedConnector.Invoke<T>("getDataToExchange") : throw new InvalidOperationException($"{ReflectedConnectorName} was not registered in global JVM");
        }

        public object AllocateTask(long taskId)
        {
            return taskDictionary.GetOrAdd(taskId, (id) =>
            {
                KNetTask knetTask = Activator.CreateInstance(TaskClassType) as KNetTask;
                knetTask.Initialize(this, id);
                return knetTask;
            });
        }

        public abstract string ReflectedConnectorName { get; }

        public abstract string ConnectorName { get; }

        public abstract Type TaskClassType { get; }

        public void Initialize(ConnectorContext ctx) => throw new NotImplementedException("Invoked in Java before any initialization.");

        public void Initialize(ConnectorContext ctx, List<Map<string, string>> taskConfigs) => throw new NotImplementedException("Invoked in Java before any initialization.");

        public void StartInternal()
        {
            Map<string, string> props = DataToExchange<Map<string, string>>();
            Start(props);
        }

        public abstract void Start(Map<string, string> props);

        public void Reconfigure(Map<string, string> props) { }

        public Class TaskClass() => throw new NotImplementedException("Invoked in Java before any initialization.");

        public void TaskConfigsInternal(int index)
        {
            Map<string, string> props = DataToExchange<Map<string, string>>();
            TaskConfigs(index, props);
        }

        public abstract void TaskConfigs(int index, Map<string, string> config);

        public List<Map<string, string>> TaskConfigs(int maxTasks) => throw new NotImplementedException("Invoked using the other signature.");

        public void StopInternal()
        {
            Stop();
        }

        public abstract void Stop();

        public object ValidateInternal(object connectorConfigsObj)
        {
            Map<string, string> connectorConfigs = DataToExchange<Map<string, string>>();
            return Validate(connectorConfigs);
        }

        public abstract Config Validate(Map<string, string> connectorConfigs);

        public ConfigDef Config() => throw new NotImplementedException("Invoked in Java before any initialization.");

        public string Version() => throw new NotImplementedException("Invoked in Java before any initialization.");
    }
}
