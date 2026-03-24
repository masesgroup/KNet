﻿/*
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
using System;
using System.Threading;

namespace MASES.KNet.Connect
{
    #region IKNetCommon
    /// <summary>
    /// Helper interface for <see cref="KNetCommon"/>
    /// </summary>
    public interface IKNetCommon : IKNetConnectLogging
    {
        /// <summary>
        /// The properties received during configuration step
        /// </summary>
        IKNetConfigurationFromMap Properties { get; }
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
        public IKNetConfigurationFromMap Properties { get; protected set; }

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