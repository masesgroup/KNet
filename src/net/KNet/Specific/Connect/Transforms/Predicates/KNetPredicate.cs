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
using Org.Apache.Kafka.Connect.Errors;
using Org.Apache.Kafka.Connect.Sink;
using Org.Apache.Kafka.Connect.Source;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace MASES.KNet.Connect.Transforms.Predicates
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
    public interface IPredicate : IVersion
    {
        /// <inheritdoc cref="Org.Apache.Kafka.Connect.Transforms.Predicates.Predicate.Test(ConnectRecord)"/>
        bool Test(ConnectRecord record);
        /// <inheritdoc cref="Org.Apache.Kafka.Common.Configurable.Configure(Map{Java.Lang.String, object})"/>
        void Configure(Map<Java.Lang.String, object> props);
        /// <inheritdoc cref="Org.Apache.Kafka.Connect.Transforms.Predicates.Predicate.Close"/>
        void Close();
        /// <inheritdoc cref="Org.Apache.Kafka.Connect.Transforms.Predicates.Predicate.Config"/>
        ConfigDef Config();
        /// <summary>
        /// Returns a formatted string used from <see cref="Org.Apache.Kafka.Connect.Transforms.Predicates.Predicate"/>
        /// </summary>
        /// <returns>The formatted string</returns>
        string ToStringPredicate();
    }

    /// <summary>
    /// Specific implementation of <see cref="IConnector"/> to support KNet Connect SDK
    /// </summary>
    public interface IKNetPredicate : IPredicate
    {
        /// <summary>
        /// Implements the behavior of <see cref="IPredicate.Test(ConnectRecord)"/> for <paramref name="record"/>
        /// </summary>
        /// <param name="record">The <see cref="SourceRecord"/> to test</param>
        /// <returns>Follow specifications of <see cref="Org.Apache.Kafka.Connect.Transforms.Predicates.Predicate.Test(ConnectRecord)"/></returns>
        /// <remarks>If the method is overridden never invoke the base method othrwise an exception is raised within the JVM.</remarks>
        bool Test(SourceRecord record);
        /// <summary>
        /// Implements the behavior of <see cref="IPredicate.Test(ConnectRecord)"/> for <paramref name="record"/>
        /// </summary>
        /// <param name="record">The <see cref="SinkRecord"/> to test</param>
        /// <returns>Follow specifications of <see cref="Org.Apache.Kafka.Connect.Transforms.Predicates.Predicate.Test(ConnectRecord)"/></returns>
        /// <remarks>If the method is overridden never invoke the base method othrwise an exception is raised within the JVM.</remarks>
        bool Test(SinkRecord record);
        /// <summary>
        /// Implement the method to execute the start action
        /// </summary>
        /// <param name="configuration">The <see cref="IKNetConfigurationFromMap"/> to access the properties returned from Apache Kafka Connect framework: the <see cref="IKNetCommon.Properties"/> contains the same info from configuration file.</param>
        void Configure(IKNetConfigurationFromMap configuration);
    }
    /// <summary>
    /// The generic class which is the base of all predicates in .NET
    /// </summary>
    public abstract class KNetPredicate : KNetCommon, IKNetPredicate
    {
        /// <summary>
        /// Set the <see cref="ReflectedRemoteObjectClassName"/> of the connector to a fixed value
        /// </summary>
        protected sealed override string ReflectedRemoteObjectClassName => "KNetPredicate";

        /// <summary>
        /// Public method used from Java to trigger <see cref="Test(ConnectRecord)"/>
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool TestInternal()
        {
            try
            {
                using var record = DataToExchange<ConnectRecord>();
                return Test(record);
            }
            catch (System.Exception e)
            {
                LogError($"TestInternal failed with {e}");
                throw;
            }
        }

        /// <inheritdoc cref="IPredicate.Test(ConnectRecord)"/>
        public virtual bool Test(ConnectRecord record)
        {
            if (record is null) return false;

            if (record.IsInstanceOf<SourceRecord>())
            {
                return Test(record.CastDirectAndDetach<SourceRecord>());
            }
            else if (record.IsInstanceOf<SinkRecord>())
            {
                return Test(record.CastDirectAndDetach<SinkRecord>());
            }
            else JVMBridgeException.Throw<ConnectException>($"Cannot manage directly the input, override the method {nameof(Test)} with generic {nameof(ConnectRecord)} parameter.");
            return false;
        }

        /// <inheritdoc cref="IKNetPredicate.Test(SourceRecord)"/>
        public virtual bool Test(SourceRecord record)
        {
            JVMBridgeException.Throw<ConnectException>($"Not implemented for {nameof(SourceRecord)}");
            return false;
        }

        /// <inheritdoc cref="IKNetPredicate.Test(SinkRecord)"/>
        public virtual bool Test(SinkRecord record)
        {
            JVMBridgeException.Throw<ConnectException>($"Not implemented for {nameof(SinkRecord)}");
            return false;
        }

        /// <summary>
        /// Public method used from Java to trigger <see cref="ToStringInternal"/>
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public string ToStringInternal()
        {
            try
            {
                return ToStringPredicate();
            }
            catch (System.Exception e)
            {
                LogError($"ToStringInternal failed with {e}");
                throw;
            }
        }

        /// <inheritdoc cref="IPredicate.ToStringPredicate"/>
        public virtual string ToStringPredicate() { return null; }

        /// <summary>
        /// Public method used from Java to trigger <see cref="Configure(Map{Java.Lang.String, object})"/>
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ConfigureInternal()
        {
            try
            {
                Map<Java.Lang.String, object> props = DataToExchange<Map<Java.Lang.String, object>>();
                Configure(props);
                Properties = new KNetConfigurationFromMap(props);
                Configure(Properties);
            }
            catch (System.Exception e)
            {
                LogError($"ConfigureInternal failed with {e}");
                throw;
            }
        }
        /// <summary>
        /// Not implemented
        /// </summary>
        /// <exception cref="NotImplementedException">Local version with a different signature</exception>
        public virtual void Configure(Map<Java.Lang.String, object> props)
        {

        }

        /// <inheritdoc cref="IKNetPredicate.Configure(IKNetConfigurationFromMap)"/>
        public abstract void Configure(IKNetConfigurationFromMap configuration);

        /// <summary>
        /// Public method used from Java to trigger <see cref="Close"/>
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void CloseInternal()
        {
            try
            {
                Close();
            }
            catch (System.Exception e)
            {
                LogError($"CloseInternal failed with {e}");
            }

            try
            {
                Unregister();
            }
            catch { }
        }
        /// <summary>
        /// Implement the method to execute the close action
        /// </summary>
        public virtual void Close() { }
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
}
