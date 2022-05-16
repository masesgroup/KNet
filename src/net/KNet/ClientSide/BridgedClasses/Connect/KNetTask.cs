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

using Java.Util;
using MASES.JCOBridge.C2JBridge.JVMInterop;
using MASES.KNet.Connect.Connector;
using System;

namespace MASES.KNet.Connect
{
    public interface IKNetTask : ITask
    {
        IKNetConnector Connector { get; }

        long TaskId { get; }
    }

    public abstract class KNetTask : IKNetTask
    {
        IKNetConnector connector;
        long taskId;
        IJavaObject reflectedTask = null;

        internal void Initialize(IKNetConnector connector, long taskId)
        {
            this.connector = connector;
            this.taskId = taskId;
            reflectedTask = KNetCore.GlobalInstance.GetJVMGlobal($"{ReflectedTaskClassName}_{taskId}");
        }

        protected T DataToExchange<T>()
        {
            return (reflectedTask != null) ? reflectedTask.Invoke<T>("getDataToExchange") : throw new InvalidOperationException($"{ReflectedTaskClassName} was not registered in global JVM");
        }

        public IKNetConnector Connector => connector;

        public long TaskId => taskId;

        public abstract string ReflectedTaskClassName { get; }

        public void StartInternal()
        {
            Map<string, string> props = DataToExchange<Map<string, string>>();
            Start(props);
        }

        public abstract void Start(Map<string, string> props);

        public void StopInternal()
        {
            Stop();
        }

        public abstract void Stop();

        public object VersionInternal()
        {
            return Version();
        }

        public abstract string Version();
    }
}
