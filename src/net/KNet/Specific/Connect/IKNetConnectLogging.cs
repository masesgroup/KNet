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
using MASES.JCOBridge.C2JBridge;

namespace MASES.KNet.Connect
{
    /// <summary>
    /// Logging interface for KNet Connect SDK
    /// </summary>
    public interface IKNetConnectLogging
    {
        /// <summary>
        /// Reports if trace level is enabled
        /// </summary>
        bool IsTraceEnabled { get; }
        /// <summary>
        /// Write a trace
        /// </summary>
        /// <param name="var1">String to write</param>
        void LogTrace(string var1);
        /// <summary>
        /// Write a trace
        /// </summary>
        /// <param name="var1">String to write</param>
        /// <param name="var2">Associated <see cref="JVMBridgeException"/></param>
        void LogTrace(string var1, JVMBridgeException var2);
        /// <summary>
        /// Reports if debug level is enabled
        /// </summary>
        bool IsDebugEnabled { get; }
        /// <summary>
        /// Write a debug
        /// </summary>
        /// <param name="var1">String to write</param>
        void LogDebug(string var1);
        /// <summary>
        /// Write a debug
        /// </summary>
        /// <param name="var1">String to write</param>
        /// <param name="var2">Associated <see cref="JVMBridgeException"/></param>
        void LogDebug(string var1, JVMBridgeException var2);
        /// <summary>
        /// Reports if info level is enabled
        /// </summary>
        bool IsInfoEnabled { get; }
        /// <summary>
        /// Write a info
        /// </summary>
        /// <param name="var1">String to write</param>
        void LogInfo(string var1);
        /// <summary>
        /// Write a info
        /// </summary>
        /// <param name="var1">String to write</param>
        /// <param name="var2">Associated <see cref="JVMBridgeException"/></param>
        void LogInfo(string var1, JVMBridgeException var2);
        /// <summary>
        /// Reports if warning level is enabled
        /// </summary>
        bool IsWarnEnabled { get; }
        /// <summary>
        /// Write a warning
        /// </summary>
        /// <param name="var1">String to write</param>
        void LogWarn(string var1);
        /// <summary>
        /// Write a warning
        /// </summary>
        /// <param name="var1">String to write</param>
        /// <param name="var2">Associated <see cref="JVMBridgeException"/></param>
        void LogWarn(string var1, JVMBridgeException var2);
        /// <summary>
        /// Reports if error level is enabled
        /// </summary>
        bool IsErrorEnabled { get; }
        /// <summary>
        /// Write a error
        /// </summary>
        /// <param name="var1">String to write</param>
        void LogError(string var1);
        /// <summary>
        /// Write a error
        /// </summary>
        /// <param name="var1">String to write</param>
        /// <param name="var2">Associated <see cref="JVMBridgeException"/></param>
        void LogError(string var1, JVMBridgeException var2);
    }
}
