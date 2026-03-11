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

using Java.Util;
using MASES.JCOBridge.C2JBridge;
using MASES.JCOBridge.C2JBridge.JVMInterop;
using MASES.JNet.Specific.Extensions;
using Org.Apache.Kafka.Connect.Connector;
using System;
using System.Collections.Generic;

namespace MASES.KNet.Connect
{
    #region ITask
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
        void Start(Map<Java.Lang.String, Java.Lang.String> props);
        /// <summary>
        /// Stop task
        /// </summary>
        void Stop();
    }
    #endregion

    #region IKNetTask

    /// <summary>
    /// Specific implementation of <see cref="ITask"/> to support KNet Connect SDK
    /// </summary>
    public interface IKNetTask : ITask, IKNetCommon
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
        /// <param name="props">The set of properties returned from Apache Kafka Connect framework: the <see cref="IReadOnlyDictionary{TKey, TValue}"/> contains the info from <see cref="KNetConnector.TaskConfigs(int, int, IDictionary{string, string})"/>.</param>
        void Start(IReadOnlyDictionary<string, string> props);
    }
    #endregion

    #region KNetTask

    /// <summary>
    /// The generic class which is the base of both source or sink task
    /// </summary>
    public abstract class KNetTask : KNetCommon, IKNetTask
    {
        KNetConnector _connector;
        long _taskId;
        string _thisId;

        internal void Initialize(KNetConnector connector, long taskId)
        {
            _connector = connector;
            _taskId = taskId;
            _thisId = $"{ReflectedTaskClassName}_{taskId}";
        }
        /// <inheritdoc/>
        protected sealed override string ReflectedRemoteObjectClassName => _thisId;

        /// <summary>
        /// An helper function to read the data from Java side
        /// </summary>
        /// <typeparam name="T">The expected return <see cref="Type"/></typeparam>
        /// <returns>The <typeparamref name="T"/></returns>
        /// <exception cref="InvalidOperationException"> </exception>
        protected T Context<T>()
        {
            return ExecuteOnRemote<T>("getContext");
        }

        /// <inheritdoc cref="IKNetTask.Properties"/>
        public IReadOnlyDictionary<string, string> Properties { get; private set; }
        /// <inheritdoc cref="IKNetTask.Connector"/>
        public IKNetConnector Connector => _connector;
        /// <inheritdoc cref="IKNetTask.TaskId"/>
        public long TaskId => _taskId;
        /// <summary>
        /// The unique name used to map objects between JVM and .NET
        /// </summary>
        protected abstract string ReflectedTaskClassName { get; }
        /// <summary>
        /// Public method used from Java to trigger <see cref="Start(Map{Java.Lang.String, Java.Lang.String})"/>
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
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

        /// <inheritdoc cref="IKNetTask.Start(IReadOnlyDictionary{string, string})"/>
        public abstract void Start(IReadOnlyDictionary<string, string> props);
        /// <summary>
        /// Public method used from Java to trigger <see cref="Stop"/>
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void StopInternal()
        {
            Stop();
            _connector.DeallocateTask(_taskId);
        }
        /// <summary>
        /// Implement the method to execute the stop action
        /// </summary>
        public abstract void Stop();
        /// <summary>
        /// Public method used from Java to trigger <see cref="Version"/>
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public object VersionInternal()
        {
            return Version();
        }
        /// <summary>
        /// Implement the method to execute the version action
        /// </summary>
        public abstract string Version();
    }
    #endregion

    #region KNetTask<TTask>
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
    #endregion
}
