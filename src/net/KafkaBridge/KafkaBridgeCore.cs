/*
*  Copyright 2021 MASES s.r.l.
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
using MASES.JCOBridge.C2JBridge;
using MASES.JCOBridge.C2JBridge.JVMInterop;
using System;
using System.Collections.Generic;
using System.IO;

namespace MASES.KafkaBridge
{
    /// <summary>
    /// Public entry point of <see cref="KafkaBridgeCore"/>
    /// </summary>
    public class KafkaBridgeCore : SetupJVMWrapper<KafkaBridgeCore>
    {
        static readonly Parser parser = Parser.CreateInstance(new Settings()
        {
            DefaultType = ArgumentType.Double
        });

        static IArgumentMetadata[] prepareArguments()
        {
            return new IArgumentMetadata[]
            {
                new ArgumentMetadata<string>()
                {
                    Name = CLIParam.ClassToRun,
                    Help = "The class to be instantiated.",
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
                    Help = "The folder where Kafka package is available. Default consider the application use the Jars in the package.",
                },
                new ArgumentMetadata<string>()
                {
                    Name = CLIParam.Log4JConfiguration,
                    Default = Const.DefaultLog4JPath,
                    Help = "The file containing the configuration of log4j.",
                },
            };
        }

        static IEnumerable<IArgumentMetadataParsed> _parsedArgs = null;

        static KafkaBridgeCore()
        {
            GlobalScalaVersion = Const.DefaultScalaVersion;
            GlobalRootPath = Const.DefaultRootPath;
            GlobalHeapSize = "256M";

            parser.Add(prepareArguments());

            List<string> args = new List<string>(Environment.GetCommandLineArgs());
            args.RemoveAt(0);
            _parsedArgs = parser.Parse(args.ToArray());
            MainClassToRun = _parsedArgs.Get<string>(CLIParam.ClassToRun);
            ApplicationArgs = parser.UnparsedArgs.FilterJCOBridgeArguments();

            GlobalRootPath = _parsedArgs.Get<string>(CLIParam.KafkaLocation);
            GlobalLog4JPath = _parsedArgs.Get<string>(CLIParam.Log4JConfiguration);
            GlobalScalaVersion = _parsedArgs.Get<string>(CLIParam.ScalaVersion);

            new KafkaBridgeCore();
        }

        KafkaBridgeCore()
        {
        }

        /// <summary>
        /// Sets the global value of root path
        /// </summary>
        public static string MainClassToRun { get; protected set; }

        /// <summary>
        /// The filtered application arguments 
        /// </summary>
        public static string[] ApplicationArgs { get; private set; }

        /// <summary>
        /// Sets the global value of root path
        /// </summary>
        public static string GlobalRootPath { get; set; }

        /// <summary>
        /// Sets the global value of log4j path
        /// </summary>
        public static string GlobalLog4JPath { get; set; }

        /// <summary>
        /// Sets the global value of root path
        /// </summary>
        public static string GlobalScalaVersion { get; set; }

        /// <summary>
        /// Sets the global heap size
        /// </summary>
        public static string GlobalHeapSize { get; set; }

        /// <summary>
        /// Sets the initial heap size
        /// </summary>
        public static string InitialHeapSize { get; set; }

        /// <summary>
        /// The Scala version to be used
        /// </summary>
        public virtual string ScalaVersion { get { return GlobalScalaVersion; } }

        /// <summary>
        /// The Scala binary version to be used
        /// </summary>
        public virtual string ScalaBinaryVersion { get { var ver = Version.Parse(ScalaVersion); return (ver.Revision == 0) ? string.Format("{0}", ver.Minor) : string.Format("{0}.{1}", ver.Minor, ver.Revision); } }

        /// <summary>
        /// The root path where Apache Kafka is installed
        /// </summary>
        public virtual string RootPath { get { return GlobalRootPath; } }

        /// <summary>
        /// The log folder
        /// </summary>
        public virtual string LogDir { get { return Path.Combine(RootPath, "logs"); } }

        /// <summary>
        /// The log4j configuration
        /// </summary>
        public virtual string Log4JOpts { get { return string.Format("file:{0}", Path.Combine(RootPath, "config", "tools-log4j.properties")); } }

        /// <summary>
        /// The JMX Port to use
        /// </summary>
        public virtual short? JmxPort { get; }

        /// <summary>
        /// Enables Debug 
        /// </summary>
        public virtual bool EnableDebug { get { return false; } }

        /// <summary>
        /// Java Debug Port
        /// </summary>
        public virtual short JavaDebugPort { get { return 5005; } }

        /// <summary>
        /// Enables Debug 
        /// </summary>
        public virtual string DebugSuspendFlag { get { return "n"; } }

        /// <summary>
        /// Java Debug options used if <see cref="EnableDebug"/> is true
        /// </summary>
        public virtual string JavaDebugOpts { get { return $"-agentlib:jdwp=transport=dt_socket,server=y,suspend={DebugSuspendFlag},address={JavaDebugPort}"; } }

        /// <summary>
        /// Default performance options used in initialization
        /// </summary>
        public virtual IDictionary<string, string> PerformanceOptions
        {
            get
            {
                var dict = new Dictionary<string, string>
                {
                   // { "-server", null }, <- Disabled because it avoids starts of embedded JVM
                    { "-XX:+UseG1GC", null },
                    { "-XX:MaxGCPauseMillis=20", null },
                    { "-XX:InitiatingHeapOccupancyPercent=35", null },
                    { "-XX:+ExplicitGCInvokesConcurrent", null },
                    { "java.awt.headless", "true" }
                };

                return dict;
            }
        }

        /// <summary>
        /// The path where Apache Kafka core dependencies Jars are installed
        /// </summary>
        public virtual string CoreDependenciesPath { get { return Path.Combine(RootPath, "core", "build", "dependant-libs-" + ScalaVersion, "*.jar"); } }

        /// <summary>
        /// The path where Apache Kafka examples Jars are installed
        /// </summary>
        public virtual string ExamplesPath { get { return Path.Combine(RootPath, "examples", "build", "libs", "kafka-examples*.jar"); } }

        /// <summary>
        /// The path where Apache Kafka clients Jars are installed
        /// </summary>
        public virtual string ClientsPath { get { return Path.Combine(RootPath, "clients", "build", "libs", "kafka-clients*.jar"); } }
        /// <summary>
        /// The path where Apache Kafka Streams Jars are installed
        /// </summary>
        public virtual string StreamsPath { get { return Path.Combine(RootPath, "streams", "build", "libs", "kafka-streams*.jar"); } }

        /// <summary>
        /// The path where Apache Kafka Streams examples Jars are installed
        /// </summary>
        public virtual string StreamsExamplePath { get { return Path.Combine(RootPath, "streams", "examples", "build", "libs", "kafka-streams-examples*.jar"); } }

        /// <summary>
        /// The path where Apache Kafka Streams dependencies Jars are installed
        /// </summary>
        public virtual string StreamsDependenciesPath { get { return Path.Combine(RootPath, "streams", "build", "dependant-libs-" + ScalaVersion, "rocksdb*.jar"); } }

        /// <summary>
        /// The path where Apache Kafka tools Jars are installed
        /// </summary>
        public virtual string ToolsPath { get { return Path.Combine(RootPath, "tools", "build", "libs", "kafka-tools*.jar"); } }

        /// <summary>
        /// The path where Apache Kafka tools Jars are installed
        /// </summary>
        public virtual string ToolsDependenciesPath { get { return Path.Combine(RootPath, "tools", "build", "dependant-libs-" + ScalaVersion, "*.jar"); } }

        /// <summary>
        /// The path where Apache Kafka Connect API Jars are installed
        /// </summary>
        public virtual string ConnectApiPath { get { return Path.Combine(RootPath, "connect", "api", "build", "libs", "connect-api*.jar"); } }

        /// <summary>
        /// The path where Apache Kafka Connect API dependencies Jars are installed
        /// </summary>
        public virtual string ConnectApiDependenciesPath { get { return Path.Combine(RootPath, "connect", "api", "build", "dependant-libs", "*"); } }

        /// <summary>
        /// The path where Apache Kafka Connect runtime Jars are installed
        /// </summary>
        public virtual string ConnectRuntimePath { get { return Path.Combine(RootPath, "connect", "runtime", "build", "libs", "connect-runtime*.jar"); } }

        /// <summary>
        /// The path where Apache Kafka Connect runtime dependencies Jars are installed
        /// </summary>
        public virtual string ConnectRuntimeDependenciesPath { get { return Path.Combine(RootPath, "connect", "runtime", "build", "dependant-libs", "*"); } }

        /// <summary>
        /// The path where Apache Kafka Connect file Jars are installed
        /// </summary>
        public virtual string ConnectFilePath { get { return Path.Combine(RootPath, "connect", "file", "build", "libs", "connect-file*.jar"); } }

        /// <summary>
        /// The path where Apache Kafka Connect file dependencies Jars are installed
        /// </summary>
        public virtual string ConnectFileDependenciesPath { get { return Path.Combine(RootPath, "connect", "file", "build", "dependant-libs", "*"); } }

        /// <summary>
        /// The path where Apache Kafka Connect json Jars are installed
        /// </summary>
        public virtual string ConnectJsonPath { get { return Path.Combine(RootPath, "connect", "json", "build", "libs", "connect-json*.jar"); } }

        /// <summary>
        /// The path where Apache Kafka Connect json dependencies Jars are installed
        /// </summary>
        public virtual string ConnectJsonDependenciesPath { get { return Path.Combine(RootPath, "connect", "json", "build", "dependant-libs", "*"); } }

        /// <summary>
        /// The path where Apache Kafka Connect tools Jars are installed
        /// </summary>
        public virtual string ConnectToolsPath { get { return Path.Combine(RootPath, "connect", "tools", "build", "libs", "connect-tools*.jar"); } }

        /// <summary>
        /// The path where Apache Kafka Connect tools dependencies Jars are installed
        /// </summary>
        public virtual string ConnectToolsDependenciesPath { get { return Path.Combine(RootPath, "connect", "tools", "build", "dependant-libs", "*"); } }

        /// <summary>
        /// The path where Apache Kafka tools Jars are installed
        /// </summary>
        public virtual string ExtraClassPath { get { return string.Empty; } }

        /// <summary>
        /// The path where Apache Kafka libs Jars are installed
        /// </summary>
        public virtual string ReleasePath { get { return Path.Combine(RootPath, "libs", "*"); } }

        /// <summary>
        /// The path where Apache Kafka additional Jars are installed
        /// </summary>
        public virtual string ReleaseAdditionalPath { get { return Path.Combine(RootPath, "core", "build", "libs", "kafka_" + ScalaBinaryVersion + "*.jar"); } }

        public sealed override IEnumerable<KeyValuePair<string, string>> JVMOptions => Options;

        protected virtual IDictionary<string, string> Options
        {
            get
            {
                if (!Directory.Exists(LogDir)) Directory.CreateDirectory(LogDir);

                IDictionary<string, string> options = new Dictionary<string, string>(PerformanceOptions)
                {
                    { "-Dcom.sun.management.jmxremote", null },
                    { "com.sun.management.jmxremote.authenticate", "false" },
                    { "com.sun.management.jmxremote.ssl", "false" },
                    { "log4j.configuration", string.IsNullOrEmpty(GlobalLog4JPath) ? ((GlobalRootPath == Const.DefaultRootPath) ? Log4JOpts : null) : $"file:{GlobalLog4JPath}"},
                    { "kafka.logs.dir", LogDir},
                    { "-Xmx" + GlobalHeapSize, null},
                };

                if (!string.IsNullOrEmpty(InitialHeapSize))
                {
                    options.Add("-Xms" + InitialHeapSize, null);
                }

                if (JmxPort.HasValue)
                {
                    options.Add("com.sun.management.jmxremote.port", JmxPort.Value.ToString());
                }

                if (EnableDebug)
                {
                    options.Add(JavaDebugOpts, null);
                }

                return options;
            }
        }

        string classPath = string.Empty;
        public sealed override string ClassPath => buildClassPath();
        /// <inheritdoc cref="IKafkaBridgeCore.DynJVM"/>
        public new dynamic DynJVM { get { return base.DynJVM; } }
        /// <inheritdoc cref="IKafkaBridgeCore.JVM"/>
        public new IJVMWrapperDirect JVM { get { return base.JVM; } }

        string buildClassPath()
        {
#if DEBUG
            Console.WriteLine("RootPath is: {0}", RootPath);
#endif

            classPath = string.Empty;
            buildClassPath(RootPath, "*.jar");
            buildClassPath(CoreDependenciesPath);
            buildClassPath(ExamplesPath);
            buildClassPath(ClientsPath);
            buildClassPath(StreamsPath);
            buildClassPath(StreamsExamplePath);
            buildClassPath(StreamsDependenciesPath);
            buildClassPath(ToolsPath);
            buildClassPath(ToolsDependenciesPath);
            buildClassPath(ConnectApiPath);
            buildClassPath(ConnectApiDependenciesPath);
            buildClassPath(ConnectRuntimePath);
            buildClassPath(ConnectRuntimeDependenciesPath);
            buildClassPath(ConnectFilePath);
            buildClassPath(ConnectFileDependenciesPath);
            buildClassPath(ConnectJsonPath);
            buildClassPath(ConnectJsonDependenciesPath);
            buildClassPath(ConnectToolsPath);
            buildClassPath(ConnectToolsDependenciesPath);
            buildClassPath(ReleasePath);
            buildClassPath(ReleaseAdditionalPath);

            classPath += !string.IsNullOrEmpty(ExtraClassPath) ? InternalConst.PathSeparator + ExtraClassPath : string.Empty;

#if DEBUG
            Console.WriteLine("ClassPath is: {0}", classPath);
#endif
            return classPath;
        }

        string buildClassPath(string path, string pattern = null)
        {
            var folder = Path.GetDirectoryName(path);
            if (pattern == null) pattern = Path.GetFileName(path);
#if DEBUG
            Console.WriteLine("Search on {0} with pattern {1}", folder, pattern);
#endif
            if (Directory.Exists(folder))
            {
                foreach (var item in Directory.GetFiles(folder, pattern, SearchOption.TopDirectoryOnly))
                {
                    classPath += InternalConst.PathSeparator + item;
                }
            }
            if (classPath.StartsWith(InternalConst.PathSeparator.ToString()))
            {
                classPath = classPath.Substring(1);
            }

            return classPath;
        }
    }
}