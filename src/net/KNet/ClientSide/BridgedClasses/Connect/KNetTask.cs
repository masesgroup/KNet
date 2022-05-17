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
    /// <summary>
    /// Specific implementation of <see cref="ITask"/> to support KNet Connect SDK
    /// </summary>
    public interface IKNetTask : ITask
    {
        /// <summary>
        /// The associated <see cref="IConnector"/>
        /// </summary>
        IKNetConnector Connector { get; }
        /// <summary>
        /// The id received during initialization
        /// </summary>
        long TaskId { get; }
    }
    /// <summary>
    /// The generic class which is the base of both source or sink task
    /// </summary>
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
        /// <summary>
        /// An helper function to read the data from Java side
        /// </summary>
        /// <typeparam name="T">The expected return <see cref="Type"/></typeparam>
        /// <returns>The <typeparamref name="T"/></returns>
        /// <exception cref="InvalidOperationException"> </exception>
        protected T DataToExchange<T>()
        {
            return (reflectedTask != null) ? reflectedTask.Invoke<T>("getDataToExchange") : throw new InvalidOperationException($"{ReflectedTaskClassName} was not registered in global JVM");
        }
        /// <summary>
        /// An helper function to read the data from Java side
        /// </summary>
        /// <typeparam name="T">The expected return <see cref="Type"/></typeparam>
        /// <returns>The <typeparamref name="T"/></returns>
        /// <exception cref="InvalidOperationException"> </exception>
        protected void DataToExchange(object data)
        {
            if (reflectedTask != null)
            {
                JCOBridge.C2JBridge.IJVMBridgeBase jvmBBD = data as JCOBridge.C2JBridge.IJVMBridgeBase;
                reflectedTask.Invoke("setDataToExchange", jvmBBD != null ? jvmBBD.Instance : data);
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
            return (reflectedTask != null) ? reflectedTask.Invoke<T>("getContext") : throw new InvalidOperationException($"{ReflectedTaskClassName} was not registered in global JVM");
        }
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
            Start(props);
        }
        /// <summary>
        /// Implement the method to execute the start action
        /// </summary>
        /// <param name="props">The set of properties returned from Apache Kafka Connect framework: the <see cref="Map{string, string}"/> contains the info from <see cref="IKNetConnector.TaskConfigs(int, Map{string, string})"/>.</param>
        public abstract void Start(Map<string, string> props);
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
    }
}
