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
using Org.Apache.Kafka.Common.Config.Types;
using Org.Apache.Kafka.Connect.Connector;
using System;
using System.Collections.Generic;

namespace MASES.KNet.Connect
{
    #region IKNetConnectConfiguration
    /// <summary>
    /// Interface to simplify access configuration information
    /// </summary>
    public interface IKNetTaskConfiguration
    {
        /// <summary>
        /// Adds <see langword="short"/> associated to <paramref name="key"/>
        /// </summary>
        /// <param name="key">The key to return</param>
        /// <param name="value">The <see langword="short"/> value associated to <paramref name="key"/></param>
        void Add(string key, short value);
        /// <summary>
        /// Adds <see langword="int"/> associated to <paramref name="key"/>
        /// </summary>
        /// <param name="key">The key to return</param>
        /// <param name="value">The <see langword="int"/> value associated to <paramref name="key"/></param>
        void Add(string key, int value);
        /// <summary>
        /// Adds <see langword="long"/> associated to <paramref name="key"/>
        /// </summary>
        /// <param name="key">The key to return</param>
        /// <param name="value">The <see langword="long"/> value associated to <paramref name="key"/></param>
        void Add(string key, long value);
        /// <summary>
        /// Adds <see langword="double"/> associated to <paramref name="key"/>
        /// </summary>
        /// <param name="key">The key to return</param>
        /// <param name="value">The <see langword="double"/> value associated to <paramref name="key"/></param>
        void Add(string key, double value);
        /// <summary>
        /// Adds <see langword="bool"/> associated to <paramref name="key"/>
        /// </summary>
        /// <param name="key">The key to return</param>
        /// <param name="value">The <see langword="bool"/> value associated to <paramref name="key"/></param>
        void Add(string key, bool value);
        /// <summary>
        /// Adds <see langword="string"/> associated to <paramref name="key"/>
        /// </summary>
        /// <param name="key">The key to return</param>
        /// <param name="value">The <see langword="string"/> value associated to <paramref name="key"/></param>
        void Add(string key, string value);
        /// <summary>
        /// Adds all values in <paramref name="values"/>
        /// </summary>
        /// <param name="values">The <see cref="IEnumerable{T}"/> containing key-value information</param>
        void Add(IEnumerable<KeyValuePair<string, object>> values);
    }

    #endregion

    #region KNetTaskConfiguration
    /// <summary>
    /// Interface to simplify access configuration information
    /// </summary>
    class KNetTaskConfiguration : IKNetTaskConfiguration
    {
        readonly System.Collections.Generic.IDictionary<string, string> _dict;

        public KNetTaskConfiguration(System.Collections.Generic.IDictionary<string, string> dict)
        {
            _dict = dict;
        }

        /// <inheritdoc/>
        public void Add(string key, short value)
        {
            _dict.Add(key, value.ToString());
        }
        /// <inheritdoc/>
        public void Add(string key, int value)
        {
            _dict.Add(key, value.ToString());
        }
        /// <inheritdoc/>
        public void Add(string key, long value)
        {
            _dict.Add(key, value.ToString());
        }
        /// <inheritdoc/>
        public void Add(string key, double value)
        {
            _dict.Add(key, value.ToString());
        }
        /// <inheritdoc/>
        public void Add(string key, bool value)
        {
            _dict.Add(key, value.ToString());
        }
        /// <inheritdoc/>
        public void Add(string key, string value)
        {
            _dict.Add(key, value);
        }
        /// <inheritdoc/>
        public void Add(IEnumerable<KeyValuePair<string, object>> values)
        {
            foreach (var item in values)
            {
                _dict.Add(item.Key, item.Value.ToString());
            }
        }
    }

    #endregion

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
        /// <param name="props">The <see cref="IKNetConnectConfiguration"/> to access the properties returned from Apache Kafka Connect framework: the <see cref="IKNetCommon.Properties"/> contains the info from <see cref="KNetConnector.TaskConfigs(int, int, IKNetTaskConfiguration)"/>.</param>
        void Start(IKNetConnectConfiguration props);
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
            Properties = new KNetConnectConfiguration(props);
            Start(Properties);
        }
        /// <summary>
        /// Not implemented
        /// </summary>
        /// <exception cref="NotImplementedException">Local version with a different signature</exception>
        public void Start(Map<Java.Lang.String, Java.Lang.String> props) => throw new NotImplementedException("Local version with a different signature");

        /// <inheritdoc cref="IKNetTask.Start(IKNetConnectConfiguration)"/>
        public abstract void Start(IKNetConnectConfiguration props);
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
