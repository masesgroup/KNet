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
using MASES.JCOBridge.C2JBridge.JVMInterop;
using MASES.JNet.Specific.Extensions;
using MASES.KNet.Connect.Transforms;
using Org.Apache.Kafka.Common.Config;
using Org.Apache.Kafka.Common.Config.Types;
using Org.Apache.Kafka.Connect.Connector;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Xml;

namespace MASES.KNet.Connect
{
    #region IKNetConnectConfiguration
    /// <summary>
    /// Interface to simplify access configuration information
    /// </summary>
    public interface IKNetConnectConfiguration : IEnumerable<KeyValuePair<string, object>>
    {
        /// <summary>
        /// Returns <see langword="true"/> if the <paramref name="key"/> exist
        /// </summary>
        /// <param name="key">The key to check</param>
        /// <returns><see langword="short"/> if the <paramref name="key"/> exist</returns>
        bool Exist(string key);
        /// <summary>
        /// Returns <see langword="short"/> associated to <paramref name="key"/>
        /// </summary>
        /// <param name="key">The key to return</param>
        /// <returns>The <see langword="short"/> associated to <paramref name="key"/></returns>
        short GetShort(string key);
        /// <summary>
        /// Returns <see langword="int"/> associated to <paramref name="key"/>
        /// </summary>
        /// <param name="key">The key to return</param>
        /// <returns>The <see langword="int"/> associated to <paramref name="key"/></returns>
        int GetInt(string key);
        /// <summary>
        /// Returns <see langword="long"/> associated to <paramref name="key"/>
        /// </summary>
        /// <param name="key">The key to return</param>
        /// <returns>The <see langword="long"/> associated to <paramref name="key"/></returns>
        long GetLong(string key);
        /// <summary>
        /// Returns <see langword="double"/> associated to <paramref name="key"/>
        /// </summary>
        /// <param name="key">The key to return</param>
        /// <returns>The <see langword="double"/> associated to <paramref name="key"/></returns>
        double GetDouble(string key);
        /// <summary>
        /// Returns <see cref="System.Collections.Generic.List{T}"/> of <see langword="string"/> associated to <paramref name="key"/>
        /// </summary>
        /// <param name="key">The key to return</param>
        /// <returns>The <see cref="System.Collections.Generic.List{T}"/> of <see langword="string"/> associated to <paramref name="key"/></returns>
        System.Collections.Generic.List<string> GetList(string key);
        /// <summary>
        /// Returns <see langword="bool"/> associated to <paramref name="key"/>
        /// </summary>
        /// <param name="key">The key to return</param>
        /// <returns>The <see langword="bool"/> associated to <paramref name="key"/></returns>
        bool GetBoolean(string key);
        /// <summary>
        /// Returns <see langword="string"/> associated to <paramref name="key"/>
        /// </summary>
        /// <param name="key">The key to return</param>
        /// <returns>The <see langword="string"/> associated to <paramref name="key"/></returns>
        string GetString(string key);
        /// <summary>
        /// Returns <see cref="Password"/> associated to <paramref name="key"/>
        /// </summary>
        /// <param name="key">The key to return</param>
        /// <returns>The <see cref="Password"/> associated to <paramref name="key"/></returns>
        Password GetPassword(string key);
        /// <summary>
        /// Returns <see cref="Java.Lang.Class"/> associated to <paramref name="key"/>
        /// </summary>
        /// <param name="key">The key to return</param>
        /// <returns>The <see cref="Java.Lang.Class"/> associated to <paramref name="key"/></returns>
        Java.Lang.Class GetClass(string key);
    }

    #endregion

    #region KNetConnectConfiguration
    /// <summary>
    /// Interface to simplify access configuration information
    /// </summary>
    class KNetConnectConfiguration : IKNetConnectConfiguration
    {
        readonly Java.Util.Map<Java.Lang.String, object> _configuration;
        readonly Java.Util.Map<Java.Lang.String, Java.Lang.String> _configuration1;
        public KNetConnectConfiguration(Java.Util.Map<Java.Lang.String, object> configuration)
        {
            _configuration = configuration;
        }

        public KNetConnectConfiguration(Java.Util.Map<Java.Lang.String, Java.Lang.String> configuration)
        {
            _configuration1 = configuration;
        }

        object GetValue(string key)
        {
            if (_configuration != null && _configuration.ContainsKey(key))
            {
                return _configuration.Get(key);
            }
            else if (_configuration1 != null)
            {
                throw new InvalidOperationException($"Only string values can be read.");
            }
            throw new InvalidOperationException($"Configuration key \"{key}\" is not available.");
        }

        /// <inheritdoc/>
        public bool Exist(string key)
        {
            return (_configuration != null) ? _configuration.ContainsKey(key) : _configuration1.ContainsKey(key);
        }
        /// <inheritdoc/>
        public short GetShort(string key)
        {
            if (_configuration1 != null)
            {
                if (_configuration1.ContainsKey(key))
                {
                    var value = _configuration1.Get(key);
                    return short.TryParse(value, out var converted) ? converted
                                                                    : throw new InvalidCastException($"Key \"{key}\" returns a value {value} cannot be converted in short"); ;
                }
                throw new InvalidOperationException($"Configuration key \"{key}\" is not available.");
            }

            var result = GetValue(key);

            if (result is short data)
            {
                return data;
            }
            else if (result is IJavaObject obj)
            {
                return obj.Convert<short>();
            }
            else throw new InvalidCastException($"Key \"{key}\" returns a value {(result ?? "null")} cannot be converted in short");
        }
        /// <inheritdoc/>
        public int GetInt(string key)
        {
            if (_configuration1 != null)
            {
                if (_configuration1.ContainsKey(key))
                {
                    var value = _configuration1.Get(key);
                    return int.TryParse(value, out var converted) ? converted
                                                                  : throw new InvalidCastException($"Key \"{key}\" returns a value {value} cannot be converted in int"); ;
                }
                throw new InvalidOperationException($"Configuration key \"{key}\" is not available.");
            }

            var result = GetValue(key);

            if (result is int data)
            {
                return data;
            }
            else if (result is IJavaObject obj)
            {
                return obj.Convert<int>();
            }
            else throw new InvalidCastException($"Key \"{key}\" returns a value {(result ?? "null")} cannot be converted in int");
        }
        /// <inheritdoc/>
        public long GetLong(string key)
        {
            if (_configuration1 != null)
            {
                if (_configuration1.ContainsKey(key))
                {
                    var value = _configuration1.Get(key);
                    return long.TryParse(value, out var converted) ? converted
                                                                   : throw new InvalidCastException($"Key \"{key}\" returns a value {value} cannot be converted in long"); ;
                }
                throw new InvalidOperationException($"Configuration key \"{key}\" is not available.");
            }

            var result = GetValue(key);

            if (result is long data)
            {
                return data;
            }
            else if (result is IJavaObject obj)
            {
                return obj.Convert<long>();
            }
            else throw new InvalidCastException($"Key \"{key}\" returns a value {(result ?? "null")} cannot be converted in long");
        }
        /// <inheritdoc/>
        public double GetDouble(string key)
        {
            if (_configuration1 != null)
            {
                if (_configuration1.ContainsKey(key))
                {
                    var value = _configuration1.Get(key);
                    return double.TryParse(value, out var converted) ? converted
                                                                     : throw new InvalidCastException($"Key \"{key}\" returns a value {value} cannot be converted in double"); ;
                }
                throw new InvalidOperationException($"Configuration key \"{key}\" is not available.");
            }

            var result = GetValue(key);

            if (result is double data)
            {
                return data;
            }
            else if (result is IJavaObject obj)
            {
                return obj.Convert<double>();
            }
            else throw new InvalidCastException($"Key \"{key}\" returns a value {(result ?? "null")} cannot be converted in double");
        }
        /// <inheritdoc/>
        public System.Collections.Generic.List<string> GetList(string key)
        {
            if (_configuration1 != null)
            {
                throw new InvalidOperationException($"Cannot manage configuration key \"{key}\" as List.");
            }

            var result = GetValue(key);

            if (result is IJavaObject obj)
            {
                var lst = JVMBridgeBase.WrapsDirect<Java.Util.List<Java.Lang.String>>(obj);
                System.Collections.Generic.List<string> newLst = new System.Collections.Generic.List<string>();
                foreach (var item in lst)
                {
                    newLst.Add(item);
                }
                return newLst;
            }
            else throw new InvalidCastException($"Key \"{key}\" returns a value {(result ?? "null")} cannot be converted in short");
        }
        /// <inheritdoc/>
        public bool GetBoolean(string key)
        {
            if (_configuration1 != null)
            {
                if (_configuration1.ContainsKey(key))
                {
                    var value = _configuration1.Get(key);
                    return bool.TryParse(value, out var converted) ? converted
                                                                   : throw new InvalidCastException($"Key \"{key}\" returns a value {value} cannot be converted in bool"); ;
                }
                throw new InvalidOperationException($"Configuration key \"{key}\" is not available.");
            }

            var result = GetValue(key);

            if (result is bool data)
            {
                return data;
            }
            else if (result is IJavaObject obj)
            {
                return obj.Convert<bool>();
            }
            else throw new InvalidCastException($"Key \"{key}\" returns a value {(result ?? "null")} cannot be converted in bool");
        }
        /// <inheritdoc/>
        public string GetString(string key)
        {
            if (_configuration1 != null)
            {
                if (_configuration1.ContainsKey(key))
                {
                    return _configuration1.Get(key);
                }
                throw new InvalidOperationException($"Configuration key \"{key}\" is not available.");
            }

            var result = GetValue(key);

            if (result is string data)
            {
                return data;
            }
            else if (result is IJavaObject obj)
            {
                return obj.Convert<string>();
            }
            else throw new InvalidCastException($"Key \"{key}\" returns a value {(result ?? "null")} cannot be converted in string");
        }
        /// <inheritdoc/>
        public Password GetPassword(string key)
        {
            if (_configuration1 != null)
            {
                throw new InvalidOperationException($"Cannot manage configuration key \"{key}\" as Password.");
            }

            var result = GetValue(key);

            if (result is Password data)
            {
                return data;
            }
            else if (result is IJavaObject obj)
            {
                return JVMBridgeBase.WrapsDirect<Password>(obj);
            }
            else throw new InvalidCastException($"Key \"{key}\" returns a value {(result ?? "null")} cannot be converted in Password");
        }
        /// <inheritdoc/>
        public Java.Lang.Class GetClass(string key)
        {
            if (_configuration1 != null)
            {
                throw new InvalidOperationException($"Cannot manage configuration key \"{key}\" as Class.");
            }

            var result = GetValue(key);

            if (result is Java.Lang.Class data)
            {
                return data;
            }
            else if (result is IJavaObject obj)
            {
                return JVMBridgeBase.WrapsDirect<Java.Lang.Class>(obj);
            }
            else throw new InvalidCastException($"Key \"{key}\" returns a value {(result ?? "null")} cannot be converted in Class");
        }
        /// <inheritdoc/>
        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            if (_configuration != null)
            {
                foreach (var item in _configuration.EntrySet())
                {
                    yield return new KeyValuePair<string, object>(item.Key, item.Value);
                }
            }
            else if (_configuration1 != null)
            {
                foreach (var item in _configuration1.EntrySet())
                {
                    yield return new KeyValuePair<string, object>(item.Key, item.Value);
                }
            }
            else throw new InvalidOperationException("Unable to execute enumeration.");
        }
        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    #endregion

    #region IKNetCommon
    /// <summary>
    /// Helper interface for <see cref="KNetCommon"/>
    /// </summary>
    public interface IKNetCommon : IKNetConnectLogging
    {
        /// <summary>
        /// The properties received during configuration step
        /// </summary>
        IKNetConnectConfiguration Properties { get; }
        /// <summary>
        /// An helper function to execute operation in the Java side
        /// </summary>
        /// <param name="method">Method name to be invoked</param>
        /// <param name="args">Arguments of the <paramref name="method"/> to be invoked</param>
        /// <exception cref="InvalidOperationException"> </exception>
        void ExecuteOnRemote(string method, params object[] args);
        /// <summary>
        /// An helper function to operation in the Java side
        /// </summary>
        /// <typeparam name="T">The expected return <see cref="Type"/></typeparam>
        /// <param name="method">Method name to be invoked</param>
        /// <param name="args">Arguments of the <paramref name="method"/> to be invoked</param>
        /// <returns>The <typeparamref name="T"/></returns>
        /// <exception cref="InvalidOperationException"> </exception>
        T ExecuteOnRemote<T>(string method, params object[] args);
    }
    #endregion

    #region KNetCommon

    /// <summary>
    /// The generic class which is the base of the KNet Connect SDK classes
    /// </summary>
    public abstract class KNetCommon : IKNetCommon
    {
        /// <summary>
        /// Initializer
        /// </summary>
        protected KNetCommon()
        {
            _checkLogTimer = new System.Timers.Timer();
            _checkLogTimer.Elapsed += _checkLogTimer_Elapsed;
            _checkLogTimer.AutoReset = false;
            _checkLogTimer.Interval = _logCheckInterval;
            _checkLogTimer.Start();
        }

        double _logCheckInterval = 1000;
        readonly System.Timers.Timer _checkLogTimer;

        string _uniqueId = null;

        IJavaObject reflectedConnectorOrTask = null;

        /// <summary>
        /// Initialize the <paramref name="uniqueId"/> and register itself
        /// </summary>
        /// <param name="uniqueId"></param>
        internal void Register(string uniqueId = null)
        {
            _uniqueId = uniqueId;
            KNetConnectProxy.RegisterCLRGlobal(UniqueId, this);
        }

        /// <summary>
        /// Unregister itself
        /// </summary>
        internal void Unregister()
        {
            KNetConnectProxy.UnregisterCLRGlobal(UniqueId);
        }

        /// <summary>
        /// The interval, expressed in milliseconds, in which the enable status of the log is checked
        /// </summary>
        /// <remarks>The to zero the log check is disabled and enable verification is bypassed</remarks>
        protected double LogCheckInterval
        {
            get => _logCheckInterval;
            set
            {
                if (value <= 0)
                {
                    _checkLogTimer.Stop();
                    Interlocked.Exchange(ref _isTraceEnable, 0);
                    Interlocked.Exchange(ref _isDebugEnable, 0);
                    Interlocked.Exchange(ref _isInfoEnable, 0);
                    Interlocked.Exchange(ref _isWarnEnable, 0);
                    Interlocked.Exchange(ref _isErrorEnable, 0);
                }
                else if (System.Math.Abs(_logCheckInterval - value) > double.Epsilon)
                {
                    _checkLogTimer.Stop();

                    Interlocked.Exchange(ref _isTraceEnable, IsTraceEnabled ? 1 : 0);
                    Interlocked.Exchange(ref _isDebugEnable, IsDebugEnabled ? 1 : 0);
                    Interlocked.Exchange(ref _isInfoEnable, IsInfoEnabled ? 1 : 0);
                    Interlocked.Exchange(ref _isWarnEnable, IsWarnEnabled ? 1 : 0);
                    Interlocked.Exchange(ref _isErrorEnable, IsErrorEnabled ? 1 : 0);

                    _checkLogTimer.Interval = value;
                    _checkLogTimer.Start();
                }
                _logCheckInterval = value;
            }
        }

        /// <summary>
        /// Returns the unique id of this instance
        /// </summary>
        protected string UniqueId => _uniqueId != null ? _uniqueId : ReflectedRemoteObjectClassName;

        /// <summary>
        /// The properties received during configuration step
        /// </summary>
        public IKNetConnectConfiguration Properties { get; protected set; }

        /// <inheritdoc/>
        public void ExecuteOnRemote(string method, params object[] args)
        {
            reflectedConnectorOrTask ??= KNetConnectProxy.GetJVMGlobal(UniqueId);
            if (reflectedConnectorOrTask != null) reflectedConnectorOrTask.Invoke(method, args);
            else throw new InvalidOperationException($"{UniqueId} was not registered in global JVM");
        }

        /// <inheritdoc/>
        public T ExecuteOnRemote<T>(string method, params object[] args)
        {
            reflectedConnectorOrTask ??= KNetConnectProxy.GetJVMGlobal(UniqueId);
            return (reflectedConnectorOrTask != null) ? reflectedConnectorOrTask.Invoke<T>(method, args)
                                                      : throw new InvalidOperationException($"{UniqueId} was not registered in global JVM");
        }

        /// <summary>
        /// An helper function to read the data from Java side
        /// </summary>
        /// <typeparam name="T">The expected return <see cref="Type"/></typeparam>
        /// <returns>The <typeparamref name="T"/></returns>
        /// <exception cref="InvalidOperationException"> </exception>
        protected T DataToExchange<T>()
        {
            return ExecuteOnRemote<T>("getDataToExchange");
        }
        /// <summary>
        /// An helper function to read the data from Java side
        /// </summary>
        /// <exception cref="InvalidOperationException"> </exception>
        protected void DataToExchange(object data)
        {
            reflectedConnectorOrTask ??= KNetConnectProxy.GetJVMGlobal(UniqueId);
            if (reflectedConnectorOrTask != null)
            {
                IJVMBridgeBase jvmBBD = data as IJVMBridgeBase;
                reflectedConnectorOrTask.Invoke("setDataToExchange", jvmBBD != null ? jvmBBD.BridgeInstance : data);
            }
            else
            {
                throw new InvalidOperationException($"{UniqueId} was not registered in global JVM");
            }
        }

        /// <summary>
        /// The unique name used to map objects between JVM and .NET
        /// </summary>
        /// <remarks>This value is used when KNet Connect SDK is hosted in the CLR. When KNet Connect SDK starts from the JVM it is ignored.</remarks>
        protected abstract string ReflectedRemoteObjectClassName { get; }

        #region IKNetConnectLogging

        private void _checkLogTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                _checkLogTimer.Stop();
                LogTrace($"Checking log enable status");
                Interlocked.Exchange(ref _isTraceEnable, IsTraceEnabled ? 1 : 0);
                Interlocked.Exchange(ref _isDebugEnable, IsDebugEnabled ? 1 : 0);
                Interlocked.Exchange(ref _isInfoEnable, IsInfoEnabled ? 1 : 0);
                Interlocked.Exchange(ref _isWarnEnable, IsWarnEnabled ? 1 : 0);
                Interlocked.Exchange(ref _isErrorEnable, IsErrorEnabled ? 1 : 0);
            }
            catch (System.Exception ex)
            {
                // Intentionally catch all exceptions here to prevent the timer thread
                // from being terminated; failures are logged for diagnosis.
                try
                {
                    LogError($"Failed to check log enabled status: {ex}");
                }
                catch
                {
                    // Swallow any exception thrown while logging to avoid recursive failures.
                }
            }
            finally
            {
                _checkLogTimer.Interval = _logCheckInterval;
                _checkLogTimer.Start();
            }
        }

        /// <inheritdoc cref="IKNetConnectLogging.Name"/>
        public string Name => ExecuteOnRemote<string>("getName");

        long _isTraceEnable = 0;
        /// <inheritdoc cref="IKNetConnectLogging.IsTraceEnabled"/>
        public bool IsTraceEnabled => ExecuteOnRemote<bool>("isTraceEnabled");
        /// <inheritdoc cref="IKNetConnectLogging.LogTrace(string)"/>
        public void LogTrace(string var1)
        {
            if (_logCheckInterval <= 0
                || Interlocked.Read(ref _isTraceEnable) != 0)
            {
                ExecuteOnRemote("trace", var1);
            }
        }
        /// <inheritdoc cref="IKNetConnectLogging.LogTrace(string, JVMBridgeException)"/>
        public void LogTrace(string var1, JVMBridgeException var2)
        {
            if (_logCheckInterval <= 0
                || Interlocked.Read(ref _isTraceEnable) != 0)
            {
                ExecuteOnRemote("trace", var1, var2.BridgeInstance);
            }
        }
        /// <inheritdoc cref="IKNetConnectLogging.LogTrace(string, object[])"/>
        public void LogTrace(string var1, params object[] var2)
        {
            if (_logCheckInterval <= 0
                || Interlocked.Read(ref _isTraceEnable) != 0)
            {
                ExecuteOnRemote("trace", var2.VarArgRebuild(var1));
            }
        }

        long _isDebugEnable = 0;
        /// <inheritdoc cref="IKNetConnectLogging.IsDebugEnabled"/>
        public bool IsDebugEnabled => ExecuteOnRemote<bool>("isDebugEnabled");
        /// <inheritdoc cref="IKNetConnectLogging.LogDebug(string)"/>
        public void LogDebug(string var1)
        {
            if (_logCheckInterval <= 0
                || Interlocked.Read(ref _isDebugEnable) != 0)
            {
                ExecuteOnRemote("debug", var1);
            }
        }
        /// <inheritdoc cref="IKNetConnectLogging.LogDebug(string, JVMBridgeException)"/>
        public void LogDebug(string var1, JVMBridgeException var2)
        {
            if (_logCheckInterval <= 0
                || Interlocked.Read(ref _isDebugEnable) != 0)
            {
                ExecuteOnRemote("debug", var1, var2.BridgeInstance);
            }
        }
        /// <inheritdoc cref="IKNetConnectLogging.LogDebug(string, object[])"/>
        public void LogDebug(string var1, params object[] var2)
        {
            if (_logCheckInterval <= 0
                || Interlocked.Read(ref _isDebugEnable) != 0)
            {
                ExecuteOnRemote("debug", var1, var2.VarArgRebuild(var1));
            }
        }

        long _isInfoEnable = 0;
        /// <inheritdoc cref="IKNetConnectLogging.IsInfoEnabled"/>
        public bool IsInfoEnabled => ExecuteOnRemote<bool>("isInfoEnabled");
        /// <inheritdoc cref="IKNetConnectLogging.LogInfo(string)"/>
        public void LogInfo(string var1)
        {
            if (_logCheckInterval <= 0
                || Interlocked.Read(ref _isInfoEnable) != 0)
            {
                ExecuteOnRemote("info", var1);
            }
        }
        /// <inheritdoc cref="IKNetConnectLogging.LogInfo(string, JVMBridgeException)"/>
        public void LogInfo(string var1, JVMBridgeException var2)
        {
            if (_logCheckInterval <= 0
                || Interlocked.Read(ref _isInfoEnable) != 0)
            {
                ExecuteOnRemote("info", var1, var2.BridgeInstance);
            }
        }
        /// <inheritdoc cref="IKNetConnectLogging.LogInfo(string, object[])"/>
        public void LogInfo(string var1, params object[] var2)
        {
            if (_logCheckInterval <= 0
                || Interlocked.Read(ref _isInfoEnable) != 0)
            {
                ExecuteOnRemote("info", var1, var2.VarArgRebuild(var1));
            }
        }

        long _isWarnEnable = 0;
        /// <inheritdoc cref="IKNetConnectLogging.IsWarnEnabled"/>
        public bool IsWarnEnabled => ExecuteOnRemote<bool>("isWarnEnabled");
        /// <inheritdoc cref="IKNetConnectLogging.LogWarn(string)"/>
        public void LogWarn(string var1)
        {
            if (_logCheckInterval <= 0
                || Interlocked.Read(ref _isWarnEnable) != 0)
            {
                ExecuteOnRemote("warn", var1);
            }
        }
        /// <inheritdoc cref="IKNetConnectLogging.LogWarn(string, JVMBridgeException)"/>
        public void LogWarn(string var1, JVMBridgeException var2)
        {
            if (_logCheckInterval <= 0
                || Interlocked.Read(ref _isWarnEnable) != 0)
            {
                ExecuteOnRemote("warn", var1, var2.BridgeInstance);
            }
        }
        /// <inheritdoc cref="IKNetConnectLogging.LogWarn(string, object[])"/>
        public void LogWarn(string var1, params object[] var2)
        {
            if (_logCheckInterval <= 0
                || Interlocked.Read(ref _isWarnEnable) != 0)
            {
                ExecuteOnRemote("warn", var1, var2.VarArgRebuild(var1));
            }
        }

        long _isErrorEnable = 0;
        /// <inheritdoc cref="IKNetConnectLogging.IsErrorEnabled"/>
        public bool IsErrorEnabled => ExecuteOnRemote<bool>("isErrorEnabled");
        /// <inheritdoc cref="IKNetConnectLogging.LogError(string)"/>
        public void LogError(string var1)
        {
            if (_logCheckInterval <= 0
                || Interlocked.Read(ref _isErrorEnable) != 0)
            {
                ExecuteOnRemote("error", var1);
            }
        }
        /// <inheritdoc cref="IKNetConnectLogging.LogError(string, JVMBridgeException)"/>
        public void LogError(string var1, JVMBridgeException var2)
        {
            if (_logCheckInterval <= 0
                || Interlocked.Read(ref _isErrorEnable) != 0)
            {
                ExecuteOnRemote("error", var1, var2.BridgeInstance);
            }
        }
        /// <inheritdoc cref="IKNetConnectLogging.LogError(string, object[])"/>
        public void LogError(string var1, params object[] var2)
        {
            if (_logCheckInterval <= 0
                || Interlocked.Read(ref _isErrorEnable) != 0)
            {
                ExecuteOnRemote("error", var1, var2.VarArgRebuild(var1));
            }
        }
        #endregion
    }

    #endregion
}
