/*
*  Copyright 2024 MASES s.r.l.
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

using System;
using System.IO;

namespace MASES.KNet
{
    class CLIParam
    {
        // CommonArgs
        public const string ClassToRun = "ClassToRun";
        public const string ScalaVersion = "ScalaVersion";
        public const string KafkaLocation = "KafkaLocation";
        public const string Log4JConfiguration = "Log4JConfiguration";
        public const string LogPath = "LogPath";
        public const string DisableJMX = "DisableJMX";
        public const string EnableJMXAuth = "EnableJMXAuth";
        public const string EnableJMXSSL = "EnableJMXAuth";
    }

    /// <summary>
    /// Default constants
    /// </summary>
    public class Const
    {
        /// <summary>
        /// The location of this assembly
        /// </summary>
        public static readonly string AssemblyLocation = Path.GetDirectoryName(typeof(Const).Assembly.Location);
        /// <summary>
        /// Default Scala version
        /// </summary>
        public const string DefaultScalaVersion = "2.13.6";
        /// <summary>
        /// Default path location of configuration files
        /// </summary>
        public static readonly string DefaultConfigurationPath = Path.Combine(AssemblyLocation, "config");
        /// <summary>
        /// Default path location of Jars files
        /// </summary>
        public static readonly string DefaultJarsPath = Path.Combine(AssemblyLocation, "jars");
        /// <summary>
        /// Default root path, i.e. consider installation within bin folder
        /// </summary>
        public static readonly string DefaultRootPath = DefaultJarsPath + Path.DirectorySeparatorChar;
        /// <summary>
        /// Default log4j configuration file, i.e. considering a relative location to <see cref="DefaultConfigurationPath"/>
        /// </summary>
        public static readonly string DefaultLog4JConfigurationPath = Path.Combine(DefaultConfigurationPath, "knet-log4j.properties");
        /// <summary>
        /// Default log path, i.e. consider installation within bin folder
        /// </summary>
        public static readonly string DefaultLogPath = Path.Combine(AssemblyLocation, "logs") + Path.DirectorySeparatorChar;
    }
}
