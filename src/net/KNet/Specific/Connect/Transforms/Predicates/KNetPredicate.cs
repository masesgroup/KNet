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

namespace MASES.KNet.Connect.Transforms
{
    /// <summary>
    /// .NET interface for <see cref="IVersion"/>
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
    public interface ITransformation : IVersion
    {
        /// <inheritdoc cref="Org.Apache.Kafka.Connect.Transforms.Transformation.Apply(ConnectRecord)"/>
        ConnectRecord Apply(ConnectRecord record);
        /// <inheritdoc cref="Org.Apache.Kafka.Common.Configurable.Configure(Map{Java.Lang.String, object})"/>
        void Configure(Map<Java.Lang.String, object> props);
        /// <inheritdoc cref="Org.Apache.Kafka.Connect.Transforms.Transforms.Transform.Close"/>
        void Close();
        /// <inheritdoc cref="Org.Apache.Kafka.Connect.Transforms.Transforms.Transform.Config"/>
        ConfigDef Config();
    }

    /// <summary>
    /// Specific implementation of <see cref="IConnector"/> to support KNet Connect SDK
    /// </summary>
    public interface IKNetTransform : ITransform
    {
        /// <summary>
        /// The properties retrieved from <see cref="KNetTransform.Configure(Map{Java.Lang.String, object})"/>
        /// </summary>
        IReadOnlyDictionary<string, object> Properties { get; }
        /// <summary>
        /// Implement the method to execute the start action
        /// </summary>
        /// <param name="props">The set of properties returned from Apache Kafka Connect framework: the <see cref="IReadOnlyDictionary{TKey, TValue}"/> contains the same info from configuration file.</param>
        void Configure(IReadOnlyDictionary<string, object> props);
    }
    /// <summary>
    /// The generic class which is the base of both source or sink connectors
    /// </summary>
    public abstract class KNetTransform : KNetCommon, IKNetTransform
    {
        /// <inheritdoc cref="IKNetConnector.Properties"/>
        public IReadOnlyDictionary<string, object> Properties { get; private set; }

        /// <summary>
        /// Public method used from Java to trigger <see cref="Test(ConnectRecord)"/>
        /// </summary>
        public bool TestInternal()
        {
            var record = DataToExchange<ConnectRecord>();
            return Test(record);
        }
        
        /// <inheritdoc cref="ITransform.Test(ConnectRecord)"/>
        public abstract bool Test(ConnectRecord record);

        /// <summary>
        /// Public method used from Java to trigger <see cref="Configure(Map{Java.Lang.String, object})"/>
        /// </summary>
        public void ConfigureInternal()
        {
            Map<Java.Lang.String, object> props = DataToExchange<Map<Java.Lang.String, object>>();
            Configure(props);
            var dict = new System.Collections.Generic.Dictionary<string, object>();
            foreach (var item in props.EntrySet())
            {
                dict.Add(item.Key, item.Value);
            }
            Properties = dict;
            Configure(Properties);
        }
        /// <summary>
        /// Not implemented
        /// </summary>
        /// <exception cref="NotImplementedException">Local version with a different signature</exception>
        public virtual void Configure(Map<Java.Lang.String, object> props)
        {

        }

        /// <inheritdoc cref="IKNetConnector.Start(IReadOnlyDictionary{string, string})"/>
        public abstract void Configure(IReadOnlyDictionary<string, object> props);

        /// <summary>
        /// Public method used from Java to trigger <see cref="Close"/>
        /// </summary>
        public void CloseInternal()
        {
            Close();
        }
        /// <summary>
        /// Implement the method to execute the stop action
        /// </summary>
        public virtual void Close() { }
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
    }
}
