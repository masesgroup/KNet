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

using MASES.CLIParser;
using Org.Apache.Kafka.Clients.Consumer;
using Org.Apache.Kafka.Clients.Producer;
using Org.Apache.Kafka.Common;
using Org.Apache.Kafka.Common.Errors;
using Org.Apache.Kafka.Connect.Errors;
using Org.Apache.Kafka.Streams.Errors;
using System;
using System.Collections.Generic;
using System.IO;
using MASES.JNet;
using Org.Apache.Kafka.Common.Config;

namespace MASES.KNet
{
    /// <summary>
    /// Public entry point of <see cref="KNetCore{T}"/>
    /// </summary>
    /// <typeparam name="T">A class which inherits from <see cref="KNetCore{T}"/></typeparam>
    public class KNetCore<T> : JNetCore<T>
        where T : KNetCore<T>
    {
        /// <inheritdoc cref="JNetCoreBase{T}.CommandLineArguments"/>
        public override IEnumerable<IArgumentMetadata> CommandLineArguments
        {
            get
            {
                var lst = new List<IArgumentMetadata>(base.CommandLineArguments);
                lst.AddRange(new IArgumentMetadata[]
                {
                    new ArgumentMetadata<string>()
                    {
                        Name = CLIParam.ClassToRun,
                        Help = "The class to be instantiated from CLI.",
                    },
                    new ArgumentMetadata<string>()
                    {
                        Name = CLIParam.ScalaVersion,
                        Default = Const.DefaultScalaVersion,
                        Help = "The version of scala to be used.",
                    },
                    new ArgumentMetadata<string>()
                    {
                        Name = CLIParam.KafkaLocation,
                        Default = Const.DefaultRootPath,
                        Help = "The folder where Kafka package are stored. Default consider the application use the Jars in the package.",
                    },
                    new ArgumentMetadata<string>()
                    {
                        Name = CLIParam.Log4JConfiguration,
                        Default = Const.DefaultLog4JPath,
                        Help = "The file containing the configuration of log4j.",
                    },
                    new ArgumentMetadata<string>()
                    {
                        Name = CLIParam.LogPath,
                        Default = Const.DefaultLogPath,
                        Help = "The path where log will be stored.",
                    },
                    new ArgumentMetadata<string>()
                    {
                        Name = CLIParam.DisableJMX,
                        Type = ArgumentType.Single,
                        Help = "Disable JMX. Default is JMX enabled without security.",
                    },
                    /* hide until other arguments will be added
                    new ArgumentMetadata<string>()
                    {
                        Name = CLIParam.EnableJMXAuth,
                        Type = ArgumentType.Single,
                        Help = "Enable authenticate on JMX. Default is not enabled",
                    },
                    new ArgumentMetadata<string>()
                    {
                        Name = CLIParam.EnableJMXSSL,
                        Type = ArgumentType.Single,
                        Help = "Enable SSL on JMX. Default is not enabled.",
                    },
                    */
                });
                return lst;
            }
        }
        /// <summary>
        /// Public initializer
        /// </summary>
        public KNetCore()
        {
            JCOBridge.C2JBridge.JCOBridge.RegisterExceptions(typeof(KNetCore<>).Assembly);
        }

        /// <inheritdoc cref="JNetCoreBase{T}.ProcessCommandLine" />
        protected override string[] ProcessCommandLine()
        {
            var result = base.ProcessCommandLine();

            _classToRun = ParsedArgs.Get<string>(CLIParam.ClassToRun);
            _JarRootPath = ParsedArgs.Get<string>(CLIParam.KafkaLocation);
            _log4JPath = ParsedArgs.Get<string>(CLIParam.Log4JConfiguration);
            _logPath = ParsedArgs.Get<string>(CLIParam.LogPath);
            _scalaVersion = ParsedArgs.Get<string>(CLIParam.ScalaVersion);
            _disableJMX = ParsedArgs.Exist(CLIParam.DisableJMX);
            return result;
        }

        /// <summary>
        /// Sets the <see cref="Type"/> to be invoked at startup
        /// </summary>
        public static Type MainClassToRun { get; protected set; }

        /// <summary>
        /// Sets the global value of class to run
        /// </summary>
        public static string ApplicationClassToRun { get; set; }

        /// <summary>
        /// Sets the global value of Jar root path
        /// </summary>
        public static string ApplicationJarRootPath { get; set; }

        /// <summary>
        /// Sets the global value of log4j path
        /// </summary>
        public static string ApplicationLog4JPath { get; set; }

        /// <summary>
        /// Sets the global value of log path
        /// </summary>
        public static string ApplicationLogPath { get; set; }

        /// <summary>
        /// Sets the global value of scala version
        /// </summary>
        public static string ApplicationScalaVersion { get; set; }

        /// <summary>
        /// Sets the global value to disable JMX
        /// </summary>
        public static bool? ApplicationDisableJMX { get; set; }

        string _classToRun;
        /// <summary>
        /// The class to run in CLI version
        /// </summary>
        public virtual string ClassToRun { get { return ApplicationClassToRun ?? _classToRun; } }

        string _scalaVersion;
        /// <summary>
        /// The Scala version to be used
        /// </summary>
        public virtual string ScalaVersion { get { return ApplicationScalaVersion ?? _scalaVersion; } }

        /// <summary>
        /// The Scala binary version to be used
        /// </summary>
        public virtual string ScalaBinaryVersion { get { var ver = Version.Parse(ScalaVersion); return (ver.Revision == 0) ? string.Format("{0}", ver.Minor) : string.Format("{0}.{1}", ver.Minor, ver.Revision); } }

        string _JarRootPath;
        /// <summary>
        /// The root path where Apache Kafka is installed
        /// </summary>
        public virtual string JarRootPath { get { return ApplicationJarRootPath ?? _JarRootPath; } }

        string _log4JPath;
        /// <summary>
        /// The log4j folder
        /// </summary>
        public virtual string Log4JPath { get { return ApplicationLog4JPath ?? _log4JPath; } }

        string _logPath;
        /// <summary>
        /// The log folder
        /// </summary>
        public virtual string LogDir { get { return ApplicationLogPath ?? _logPath; } }

        /// <summary>
        /// The log4j configuration
        /// </summary>
        public virtual string Log4JOpts { get { return string.Format("file:{0}", Path.Combine(JarRootPath, "config", "tools-log4j.properties")); } }

        bool _disableJMX;
        /// <summary>
        /// Disable JMX
        /// </summary>
        public virtual bool DisableJMX { get { return ApplicationDisableJMX ?? _disableJMX; } }

        /// <inheritdoc cref="JNetCore{T}.PerformanceOptions"/>
        protected override IList<string> PerformanceOptions
        {
            get
            {
                var lst = new List<string>(base.PerformanceOptions);
                lst.AddRange(new string[]
                {
                    // "-server", <- Disabled because it avoids starts of embedded JVM
                    "-XX:+UseG1GC",
                    "-XX:MaxGCPauseMillis=20",
                    "-XX:InitiatingHeapOccupancyPercent=35",
                    "-XX:+ExplicitGCInvokesConcurrent",
                });
                return lst;
            }
        }

        /// <inheritdoc cref="JNetCore{T}.Options"/>
        protected override IDictionary<string, string> Options
        {
            get
            {
                if (!Directory.Exists(LogDir)) Directory.CreateDirectory(LogDir);

                IDictionary<string, string> options = new Dictionary<string, string>(base.Options)
                {
                    { "log4j.configuration", string.IsNullOrEmpty(Log4JPath) ? ((JarRootPath == Const.DefaultRootPath) ? Log4JOpts : null) : $"file:{Log4JPath}"},
                    { "kafka.logs.dir", LogDir},
                    { "java.awt.headless", "true" },
                };

                if (!_disableJMX)
                {
                    options.Add("-Dcom.sun.management.jmxremote", null);
                    options.Add("com.sun.management.jmxremote.authenticate", ParsedArgs.Exist(CLIParam.EnableJMXAuth) ? "true" : "false");
                    options.Add("com.sun.management.jmxremote.ssl", ParsedArgs.Exist(CLIParam.EnableJMXSSL) ? "true" : "false");
                }

                return options;
            }
        }

        /// <inheritdoc cref="JNetCore{T}.PathToParse"/>
        protected override IList<string> PathToParse
        {
            get
            {
                var lst = new List<string>(base.PathToParse);
                var assembly = typeof(KNetCore<>).Assembly;
                var version = assembly.GetName().Version.ToString();
                // 1. check first full version
                var knetFile = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(assembly.Location), JARsSubFolder, $"knet-{version}.jar");
                if (!System.IO.File.Exists(knetFile) && version.EndsWith(".0"))
                {
                    // 2. if not exist remove last part of version
                    version = version.Substring(0, version.LastIndexOf(".0"));
                    knetFile = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(assembly.Location), JARsSubFolder, $"knet-{version}.jar");
                }
                // 3. add knet at this version first...
                lst.Add(knetFile);
                // 2. ...then add everything else
                lst.Add(JarRootPath != null ? Path.Combine(JarRootPath, "*.jar") : JarRootPath);
                return lst;
            }
        }

#if DEBUG
        /// <inheritdoc cref="JNetCoreBase{T}.EnableDebug"/>
        public override bool EnableDebug => true;
#endif
    }
}