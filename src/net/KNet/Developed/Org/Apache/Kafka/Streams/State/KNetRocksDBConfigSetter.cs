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
using MASES.KNet;
using MASES.KNet.Streams;
using Org.Rocksdb;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Org.Apache.Kafka.Streams.State
{
    #region IRocksDbLifecycleHandler
    /// <summary>
    /// Defines the RocksDB lifecycle callbacks invoked by KEFCore for a Kafka Streams state store.
    /// </summary>
    /// <remarks>
    /// Implementations are resolved once during bootstrap and then reused from the
    /// storage-id runtime map, so they should be thread-safe.
    /// </remarks>
    public interface IRocksDbLifecycleHandler
    {
        /// <summary>
        /// Invoked when RocksDB is configuring the state store associated to the current entity storage.
        /// </summary>
        /// <param name="options">The RocksDB <see cref="Org.Rocksdb.Options"/> instance to be configured.</param>
        /// <param name="configuration">The KNet <see cref="IKNetConfigurationFromMap"/> map associated to the callback.</param>
        /// <param name="data">
        /// A per-store dictionary used to keep managed objects alive for the whole lifetime of the
        /// underlying RocksDB store instance.
        /// </param>
        /// <remarks>
        /// Any managed object created during configuration and referenced natively by RocksDB
        /// (for example <see cref="LRUCache"/>, <see cref="BlockBasedTableConfig"/>, or similar objects)
        /// must be stored in <paramref name="data"/>. Otherwise the .NET GC may collect it while
        /// RocksDB is still holding the native reference, causing non-deterministic crashes.
        /// <para>
        /// The same dictionary instance is later passed back to <see cref="OnClose(Org.Rocksdb.Options, IDictionary{string, object})"/>,
        /// so implementations can retrieve and explicitly dispose the resources that were stored here.
        /// </para>
        /// </remarks>
        void OnSetConfig(Org.Rocksdb.Options options, IKNetConfigurationFromMap configuration, IDictionary<string, object> data);

        /// <summary>
        /// Invoked when RocksDB is closing the state store associated to the current entity storage.
        /// </summary>
        /// <param name="options">The RocksDB <see cref="Org.Rocksdb.Options"/> instance associated to the store.</param>
        /// <param name="data">
        /// The same per-store dictionary previously provided to
        /// <see cref="OnSetConfig(Org.Rocksdb.Options, IKNetConfigurationFromMap, IDictionary{string, object})"/>.
        /// </param>
        /// <remarks>
        /// Implementations should retrieve from <paramref name="data"/> any resource created during
        /// <see cref="OnSetConfig(Org.Rocksdb.Options, IKNetConfigurationFromMap, IDictionary{string, object})"/>
        /// and dispose it explicitly if needed.
        /// </remarks>
        void OnClose(Org.Rocksdb.Options options, IDictionary<string, object> data);
    }
    #endregion

    #region NullRocksDbLifecycleHandler
    /// <summary>
    /// A no-op implementation of <see cref="IRocksDbLifecycleHandler"/>.
    /// </summary>
    /// <remarks>
    /// This instance can be used when no explicit RocksDB lifecycle behavior is configured
    /// for the entity type, avoiding null checks in the runtime callback path.
    /// </remarks>
    sealed class NullRocksDbLifecycleHandler : IRocksDbLifecycleHandler
    {
        /// <summary>
        /// Gets the singleton no-op instance.
        /// </summary>
        public static NullRocksDbLifecycleHandler Instance { get; } = new();

        private NullRocksDbLifecycleHandler()
        {
        }

        /// <inheritdoc />
        public void OnSetConfig(Org.Rocksdb.Options options, IKNetConfigurationFromMap configuration, IDictionary<string, object> data)
        {
        }

        /// <inheritdoc />
        public void OnClose(Org.Rocksdb.Options options, IDictionary<string, object> data)
        {
        }
    }
    #endregion

    #region RocksDbLifecycleDelegateHandler

    /// <summary>
    /// Internal <see cref="IRocksDbLifecycleHandler"/> implementation wrapping
    /// the callback handlers configured through Fluent API.
    /// </summary>
    /// <remarks>
    /// This type is used to unify callback-based configuration and type-based configuration
    /// behind the same runtime contract, <see cref="IRocksDbLifecycleHandler"/>.
    /// </remarks>
    /// <remarks>
    /// Initializes a new instance of <see cref="RocksDbLifecycleDelegateHandler"/>.
    /// </remarks>
    /// <param name="onSetConfig">
    /// Callback invoked when RocksDB configures the state store.
    /// The <c>data</c> dictionary supplied to this callback is the per-store lifetime
    /// container that must retain any managed object still referenced by native
    /// RocksDB components for the whole lifetime of the store.
    /// </param>
    /// <param name="onClose">
    /// Callback invoked when RocksDB closes the state store.
    /// The same per-store lifetime dictionary previously supplied to the
    /// <paramref name="onSetConfig"/> callback is passed back so that retained
    /// resources can be retrieved and disposed explicitly.
    /// </param>
    public sealed class RocksDbLifecycleDelegateHandler(
        Action<Org.Rocksdb.Options, IKNetConfigurationFromMap, IDictionary<string, object>> onSetConfig,
        Action<Org.Rocksdb.Options, IDictionary<string, object>> onClose) : IRocksDbLifecycleHandler
    {
        /// <summary>
        /// Returns a no-op implementation of <see cref="IRocksDbLifecycleHandler"/>
        /// </summary>
        public static readonly IRocksDbLifecycleHandler Null = NullRocksDbLifecycleHandler.Instance;

        private readonly Action<Org.Rocksdb.Options, IKNetConfigurationFromMap, IDictionary<string, object>> _onSetConfig = onSetConfig;
        private readonly Action<Org.Rocksdb.Options, IDictionary<string, object>> _onClose = onClose;

        /// <inheritdoc />
        public void OnSetConfig(Org.Rocksdb.Options options, IKNetConfigurationFromMap configuration, IDictionary<string, object> data)
            => _onSetConfig?.Invoke(options, configuration, data);

        /// <inheritdoc />
        public void OnClose(Org.Rocksdb.Options options, IDictionary<string, object> data)
            => _onClose?.Invoke(options, data);
    }

    #endregion

    /// <summary>
    /// Extends <see cref="RocksDBConfigSetter"/>
    /// </summary>
    public class KNetRocksDBConfigSetter : RocksDBConfigSetter
    {
        class KNetRocksDBConfigSetterCallbackImpl(Action<string, Org.Rocksdb.Options, IKNetConfigurationFromMap, IDictionary<string, object>> onSetConfig,
                                                          Action<string, Org.Rocksdb.Options, IDictionary<string, object>> onClose) : KNetRocksDBConfigSetterCallback
        {
            readonly ConcurrentDictionary<IntPtr, IDictionary<string, object>> _localStorage = new();

            public override void OnSetConfig(KNetRocksDBConfigSetter setter, string store, Org.Rocksdb.Options options, Map<Java.Lang.String, object> map)
            {
                if (_localStorage.ContainsKey(setter.BridgeInstance.Pointer)) throw new InvalidOperationException($"{nameof(OnSetConfig)} invoked twice from the same object.");
                IDictionary<string, object> keyValuePairs = new System.Collections.Generic.Dictionary<string, object>();
                onSetConfig?.Invoke(store, options, new KNetConfigurationFromMap(map), keyValuePairs);
                if (!_localStorage.TryAdd(setter.BridgeInstance.Pointer, keyValuePairs))
                {
                    throw new InvalidOperationException($"{nameof(OnSetConfig)} is unable to add configured information in local dictionary. A double invocation to {nameof(OnSetConfig)} was made by subsystem?");
                }
            }

            public override void OnClose(KNetRocksDBConfigSetter setter, string store, Org.Rocksdb.Options options)
            {
                if (_localStorage.TryRemove(setter.BridgeInstance.Pointer, out IDictionary<string, object> keyValuePairs))
                {
                    onClose?.Invoke(store, options, keyValuePairs);
                }
            }
        }

        static readonly object _callbackLock = new();
        static KNetRocksDBConfigSetterCallbackImpl _callback = null;
        /// <summary>
        /// <see langword="true"/> if a previous invocation of <see cref="SetRocksDBConfigSetterCallback"/> succeded
        /// </summary>
        public static bool RocksDBConfigSetterCallbackSet => _callback != null;

        /// <summary>
        /// Sets the global <see cref="KNetRocksDBConfigSetterCallback"/> will be shared across all requests of <see cref="KNetRocksDBConfigSetter"/>
        /// </summary>
        /// <param name="onSetConfig">Invoked when a new <see cref="KNetRocksDBConfigSetter"/> is requested and needs to be configured: the parameters are the same of <see cref="RocksDBConfigSetter.SetConfig(Java.Lang.String, Options, Map{Java.Lang.String, object})"/> with an extra parameter can be filled in with used specific information will be received back on <paramref name="onClose"/> invocation</param>
        /// <param name="onClose">Invoked when a previously configured instance of <see cref="KNetRocksDBConfigSetter"/> shall be closed: the parameters are the same of <see cref="RocksDBConfigSetter.Close(Java.Lang.String, Options)"/> with an extra parameter filled in when <paramref name="onSetConfig"/> was invoked</param>
        /// <remarks>The callbacks will be in effect only registering <see cref="KNetRocksDBConfigSetter"/> as <see cref="Java.Lang.Class"/> used from <see cref="StreamsConfigBuilder.RocksDbConfigSetterClass"/> or a property associated to <see cref="StreamsConfig.ROCKSDB_CONFIG_SETTER_CLASS_CONFIG"/>:
        /// <code>
        /// StreamsConfigBuilder builder = StreamsConfigBuilder.Create();
        /// builder.RocksDbConfigSetterClass = KNetRocksDBConfigSetter.KNetRocksDBConfigSetterClass;
        /// ...
        /// builder.Build();
        /// </code>
        /// In general the fourth parameter of <paramref name="onSetConfig"/> can be used to store the reference to objects needs to be closed when <paramref name="onClose"/> is invoked.
        /// The example in <see href="https://docs.confluent.io/platform/current/streams/developer-guide/config-streams.html#rocksdb-config-setter"/> translates into:
        /// <code>
        /// void OnSetConfig(string store, Org.Rocksdb.Options options, IKNetConfigurationFromMap configs, IDictionary&lt;string, object&gt; data)
        /// {
        ///     Org.Rocksdb.Cache cache = new Org.Rocksdb.LRUCache(16 * 1024L * 1024L);
        ///     data.Add("cache", cache);
        ///     // See #1 in https://docs.confluent.io/platform/current/streams/developer-guide/config-streams.html#rocksdb-config-setter.
        ///     BlockBasedTableConfig tableConfig = options.TableFormatConfig().Cast&lt;BlockBasedTableConfig&gt;();
        ///     tableConfig.SetBlockCache(cache);
        ///     // See #2 in https://docs.confluent.io/platform/current/streams/developer-guide/config-streams.html#rocksdb-config-setter.
        ///     tableConfig.SetBlockSize(16 * 1024L);
        ///     // See #3 in https://docs.confluent.io/platform/current/streams/developer-guide/config-streams.html#rocksdb-config-setter.
        ///     tableConfig.SetCacheIndexAndFilterBlocks(true);
        ///     options.SetTableFormatConfig(tableConfig);
        ///     // See #4 in https://docs.confluent.io/platform/current/streams/developer-guide/config-streams.html#rocksdb-config-setter.
        ///     options.SetMaxWriteBufferNumber(2);
        /// }
        /// 
        /// void OnClose(string store, Org.Rocksdb.Options options, IDictionary&lt;string, object&gt; data)
        /// {
        ///     if (data.TryGetValue("cache", out var obj) &amp;&amp; obj is Org.Rocksdb.Cache cache)
        ///     {
        ///         // See #5 in https://docs.confluent.io/platform/current/streams/developer-guide/config-streams.html#rocksdb-config-setter.
        ///         cache.Close();
        ///     }
        /// }
        /// </code>
        /// </remarks>
        /// <exception cref="InvalidOperationException">If <see cref="SetRocksDBConfigSetterCallback"/> is invoked twice without an invocation to <see cref="ResetRocksDBConfigSetterCallback"/></exception>
        public static void SetRocksDBConfigSetterCallback(Action<string, Org.Rocksdb.Options, IKNetConfigurationFromMap, IDictionary<string, object>> onSetConfig,
                                                          Action<string, Org.Rocksdb.Options, IDictionary<string, object>> onClose)
        {
            lock (_callbackLock)
            {
                if (_callback != null)
                {
                    throw new InvalidOperationException("The callbacks can be set only once per application.");
                }
                _callback = new KNetRocksDBConfigSetterCallbackImpl(onSetConfig, onClose);
                KNetRocksDBConfigSetter.SetCallback(_callback);
            }
        }
        /// <summary>
        /// Set the default behavior; the user shall not invoked this method directly, see remarks.
        /// </summary>
        /// <remarks>Default behavior is set by default; this method can be used if the user invoked <see cref="ResetRocksDBConfigSetterCallback"/> and needs to return to the default</remarks>
        public static void SetRocksDBConfigSetterCallbackDefault()
        {
            SetRocksDBConfigSetterCallback(OnSetConfig, OnClose);
        }
        /// <summary>
        /// Resets the callbacks and handler registered in <see cref="SetRocksDBConfigSetterCallback(Action{string, Options, IKNetConfigurationFromMap, IDictionary{string, object}}, Action{string, Options, IDictionary{string, object}})"/>
        /// </summary>
        public static void ResetRocksDBConfigSetterCallback()
        {
            lock (_callbackLock)
            {
                KNetRocksDBConfigSetter.SetCallback(null);
                _callback?.Dispose();
                _callback = null;
            }
        }

        private static readonly ConcurrentDictionary<string, IRocksDbLifecycleHandler> _entityByStorageId = new();

        static void OnSetConfig(string store, Org.Rocksdb.Options options, IKNetConfigurationFromMap configuration, IDictionary<string, object> data)
        {
            if (_entityByStorageId.TryGetValue(store, out var handler))
            {
                handler.OnSetConfig(options, configuration, data);
            }
        }

        static void OnClose(string store, Org.Rocksdb.Options options, IDictionary<string, object> data)
        {
            if (_entityByStorageId.TryGetValue(store, out var handler))
            {
                handler.OnClose(options, data);
            }
        }

        static KNetRocksDBConfigSetter()
        {
            SetRocksDBConfigSetterCallbackDefault();
        }
        /// <summary>
        /// Current registered storage id, i.e. the list of storages where it was invoked <see cref="Register(string, IRocksDbLifecycleHandler, bool)"/>
        /// </summary>
        public static IReadOnlyList<string> RegisteredStorageId => new System.Collections.Generic.List<string>(_entityByStorageId.Keys);

        /// <summary>
        /// Register <paramref name="handler"/> associated to <paramref name="storageId"/>
        /// </summary>
        /// <param name="storageId">The id used when the RocksDb storage was requested</param>
        /// <param name="handler">The <see cref="IRocksDbLifecycleHandler"/> will be invoked or <see langword="null"/> to use defaults</param>
        /// <param name="silent"><see langword="true"/> to silently bypass the condition of previous registration of <paramref name="storageId"/></param>
        /// <returns><see langword="true"/> if the operation succeded, <see langword="false"/> otherwise if <paramref name="silent"/> is <see langword="true"/></returns>
        /// <exception cref="InvalidOperationException">If <paramref name="storageId"/> is already registered</exception>
        /// <remarks>This method works only in conjunction with <see cref="SetRocksDBConfigSetterCallbackDefault"/>, which is the default one.</remarks>
        public static bool Register(string storageId, IRocksDbLifecycleHandler handler = null, bool silent = false)
        {
            if (string.IsNullOrWhiteSpace(storageId)) throw new ArgumentException($"Parameter cannot be null, empty or contain only white spaces", nameof(storageId));

            var result = _entityByStorageId.TryAdd(storageId, handler == null ? handler : NullRocksDbLifecycleHandler.Instance);
            if (silent) return result;
            if (!result)
            {
                throw new InvalidOperationException($"StorageId {storageId} was registered in global storage, cannot add it again. Try with {nameof(Unregister)} before call this method again.");
            }
            return result;
        }
        /// <summary>
        /// Unregister the <see cref="IRocksDbLifecycleHandler"/> associated to <paramref name="storageId"/>
        /// </summary>
        /// <param name="storageId">The id used when the RocksDb storage was requested</param>
        /// <param name="silent"><see langword="true"/> to silently bypass the condition of missing registration of <paramref name="storageId"/></param>
        /// <returns><see langword="true"/> if the operation succeded, <see langword="false"/> otherwise if <paramref name="silent"/> is <see langword="true"/></returns>
        /// <exception cref="InvalidOperationException">If <paramref name="storageId"/> is not available</exception>
        /// <remarks>This method works only in conjunction with <see cref="SetRocksDBConfigSetterCallbackDefault"/>, which is the default one.</remarks>
        public static bool Unregister(string storageId, bool silent = false)
        {
            var result = _entityByStorageId.TryRemove(storageId, out _);
            if (silent) return result;
            if (!result)
            {
                throw new InvalidOperationException($"StorageId {storageId} is not available in global storage, have you forget to invoke {nameof(Register)}?");
            }
            return result;
        }

        const string _bridgeClassName = "org.mases.knet.developed.streams.state.KNetRocksDBConfigSetter";

        /// <summary>
        /// Default constructor: even if the corresponding Java class does not have one, it is mandatory for JCOBridge
        /// </summary>
        [global::System.Obsolete("KNetRocksDBConfigSetter class represents, in .NET, an instance of a JVM interface or abstract class. This public initializer is needed for JCOBridge internal use, other uses can produce unidentible behaviors.")]
        public KNetRocksDBConfigSetter() { }
        /// <summary>
        /// Internal constructor: used internally from JCOBridge
        /// </summary>
        [global::System.Obsolete("This public initializer is needed for JCOBridge internal use, other uses can produce unidentible behaviors.")]
        public KNetRocksDBConfigSetter(IJVMBridgeBaseInitializer initializer) : base(initializer) { }
        /// <summary>
        /// Generic constructor: it is useful for JCOBridge when there is a derived class which needs to pass arguments to the highest JVMBridgeBase class
        /// </summary>
        [global::System.Obsolete("KNetRocksDBConfigSetter class represents, in .NET, an instance of a JVM interface or abstract class. This public initializer is needed for JCOBridge internal use, other uses can produce unidentible behaviors.")]
        public KNetRocksDBConfigSetter(params object[] args) : base(args) { }

        private static readonly global::System.Exception _LocalBridgeClazzException = null;
        private static readonly MASES.JCOBridge.C2JBridge.JVMInterop.IJavaType _LocalBridgeClazz = JVMBridgeCore.ClazzOf(_bridgeClassName, out _LocalBridgeClazzException, false);
        private static MASES.JCOBridge.C2JBridge.JVMInterop.IJavaType LocalBridgeClazz => _LocalBridgeClazz ?? throw _LocalBridgeClazzException ?? new global::System.InvalidOperationException($"Class {_bridgeClassName} was not found.");

        /// <inheritdoc/>
        public override string BridgeClassName => _bridgeClassName;
        /// <inheritdoc/>
        public override bool IsBridgeAbstract => false;
        /// <inheritdoc/>
        public override bool IsBridgeInterface => false;
        /// <summary>
        /// Set the <see cref="KNetRocksDBConfigSetterCallback"/> used from the instances of <see cref="KNetRocksDBConfigSetter"/>
        /// </summary>
        /// <param name="callback">The allocated <see cref="KNetRocksDBConfigSetterCallback"/></param>
        public static void SetCallback(KNetRocksDBConfigSetterCallback callback)
        {
            SExecute(LocalBridgeClazz, "setCallback", callback);
        }
        /// <summary>
        /// The <see cref="Java.Lang.Class"/> to be used to set the value of <see cref="StreamsConfigBuilder.RocksDbConfigSetterClass"/> or <see cref="StreamsConfig.ROCKSDB_CONFIG_SETTER_CLASS_CONFIG"/>
        /// </summary>
        public static Java.Lang.Class KNetRocksDBConfigSetterClass => Class.ForName(_bridgeClassName, true, Class.SystemClassLoader);
    }
}
