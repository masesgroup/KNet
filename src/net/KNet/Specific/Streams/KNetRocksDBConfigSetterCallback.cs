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

using MASES.JCOBridge.C2JBridge;
using Org.Apache.Kafka.Streams.State;

namespace MASES.KNet.Specific.Streams
{
    #region KNetRocksDBConfigSetterCallback declaration
    /// <summary>
    /// Used to manage <see cref="RocksDBConfigSetter"/>
    /// </summary>
    public partial class KNetRocksDBConfigSetterCallback : MASES.JCOBridge.C2JBridge.JVMBridgeListener
    {
        /// <summary>
        /// Default constructor: even if the corresponding Java class does not have one, it is mandatory for JCOBridge
        /// </summary>
        public KNetRocksDBConfigSetterCallback() { InitializeHandlers(); }
        /// <summary>
        /// Internal constructor: used internally from JCOBridge
        /// </summary>
        [global::System.Obsolete("This public initializer is needed for JCOBridge internal use, other uses can produce unidentible behaviors.")]
        public KNetRocksDBConfigSetterCallback(IJVMBridgeBaseInitializer initializer) : base(initializer) { }
        /// <summary>
        /// Generic constructor: it is useful for JCOBridge when there is a derived class which needs to pass arguments to the highest JVMBridgeBase class
        /// </summary>
        public KNetRocksDBConfigSetterCallback(params object[] args) : base(args) { InitializeHandlers(); }
        const string _bridgeClassName = "org.mases.knet.developed.streams.KNetRocksDBConfigSetterCallback";
        private static readonly global::System.Exception _LocalBridgeClazzException = null;
        private static readonly MASES.JCOBridge.C2JBridge.JVMInterop.IJavaType _LocalBridgeClazz = JVMBridgeBase.ClazzOf(_bridgeClassName, out _LocalBridgeClazzException, false);
        private static MASES.JCOBridge.C2JBridge.JVMInterop.IJavaType LocalBridgeClazz => _LocalBridgeClazz ?? throw _LocalBridgeClazzException ?? new global::System.InvalidOperationException($"Class {_bridgeClassName} was not found.");
        
        /// <inheritdoc />
        public override string BridgeClassName => _bridgeClassName;

    
        // TODO: complete the class

    }
    #endregion

    #region ClusterResourceListener implementation
    public partial class KNetRocksDBConfigSetterCallback
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// Handlers initializer for <see cref="KNetRocksDBConfigSetterCallback"/>
        /// </summary>
        protected virtual void InitializeHandlers()
        {
            AddEventHandler("onSetConfig", new global::System.EventHandler<CLRListenerEventArgs<CLREventData<MASES.JNet.Specific.JNetEventResult>>>(OnSetConfigEventHandler));
            AddEventHandler("onClose", new global::System.EventHandler<CLRListenerEventArgs<CLREventData<MASES.JNet.Specific.JNetEventResult>>>(OnCloseEventHandler));
        }

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/4.2.0/org/apache/kafka/common/ClusterResourceListener.html#onUpdate(org.apache.kafka.common.ClusterResource)"/>
        /// </summary>
        /// <remarks>If <see cref="OnOnSetConfig"/> has a value it takes precedence over corresponding class method</remarks>
        public global::System.Action<Org.Apache.Kafka.Common.ClusterResource> OnOnSetConfig { get; set; } = null;

        bool hasOverrideOnSetConfig = true;
        void OnSetConfigEventHandler(object sender, CLRListenerEventArgs<CLREventData<MASES.JNet.Specific.JNetEventResult>> data)
        {
            hasOverrideOnSetConfig = true;
            var methodToExecute = (OnOnSetConfig != null) ? OnOnSetConfig : OnSetConfig;
            methodToExecute.Invoke(data.EventData.GetAt<Org.Apache.Kafka.Common.ClusterResource>(0));
            data.EventData.TypedEventData.HasOverride = hasOverrideOnSetConfig;
        }

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/4.2.0/org/apache/kafka/common/ClusterResourceListener.html#onUpdate(org.apache.kafka.common.ClusterResource)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.ClusterResource"/></param>
        public virtual void OnSetConfig(Org.Apache.Kafka.Common.ClusterResource arg0)
        {
            hasOverrideOnSetConfig = false;
        }

        /// <summary>
        /// Handler for <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/4.2.0/org/apache/kafka/common/ClusterResourceListener.html#onUpdate(org.apache.kafka.common.ClusterResource)"/>
        /// </summary>
        /// <remarks>If <see cref="OnOnSetConfig"/> has a value it takes precedence over corresponding class method</remarks>
        public global::System.Action<Org.Apache.Kafka.Common.ClusterResource> OnOnClose { get; set; } = null;

        bool hasOverrideOnClose = true;
        void OnCloseEventHandler(object sender, CLRListenerEventArgs<CLREventData<MASES.JNet.Specific.JNetEventResult>> data)
        {
            hasOverrideOnClose = true;
            var methodToExecute = (OnOnSetConfig != null) ? OnOnClose : OnClose;
            methodToExecute.Invoke(data.EventData.GetAt<Org.Apache.Kafka.Common.ClusterResource>(0));
            data.EventData.TypedEventData.HasOverride = hasOverrideOnClose;
        }

        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/4.2.0/org/apache/kafka/common/ClusterResourceListener.html#onUpdate(org.apache.kafka.common.ClusterResource)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.ClusterResource"/></param>
        public virtual void OnClose(Org.Apache.Kafka.Common.ClusterResource arg0)
        {
            hasOverrideOnClose = false;
        }

        #endregion

        #region Nested classes

        #endregion
    }
    #endregion
}