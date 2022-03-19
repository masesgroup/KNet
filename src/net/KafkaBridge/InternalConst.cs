/*
*  Copyright 2022 MASES s.r.l.
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

namespace MASES.KafkaBridge
{
    class CLIParam
    {
        // CommonArgs
        public const string ClassToRun = "ClassToRun";
        public const string ScalaVersion = "ScalaVersion";
        public const string KafkaLocation = "KafkaLocation";
        public const string Log4JConfiguration = "Log4JConfiguration";
        public const string LogClassPath = "LogClassPath";
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
        /// Default root path, i.e. consider installation within bin folder
        /// </summary>
        public static readonly string DefaultRootPath = Path.Combine(AssemblyLocation, "jars") + Path.DirectorySeparatorChar;
        /// <summary>
        /// Default log4j path, i.e. consider installation within bin folder
        /// </summary>
        public static readonly string DefaultLog4JPath = Path.Combine(AssemblyLocation, "config", "log4j.properties");
    }
}
