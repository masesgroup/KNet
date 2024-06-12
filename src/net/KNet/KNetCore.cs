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
using System;
using System.Collections.Generic;
using System.IO;
using MASES.JNet;
using MASES.JCOBridge.C2JBridge;
using System.Linq;

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
                        Default = DefaultLog4JConfiguration(),
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
        /// Returns the default configuration file to use when initializing command line defaults
        /// </summary>
        /// <returns>The configuration file to use for logging</returns>
        /// <remarks>Overrides in derived classes to give another default file</remarks>
        protected virtual string DefaultLog4JConfiguration()
        {
            return Const.DefaultLog4JConfigurationPath;
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
            if (!Path.IsPathRooted(_log4JPath)) // it is not a full path
            {
                var absolutePath = Path.Combine(Const.DefaultConfigurationPath, _log4JPath);
                if (File.Exists(absolutePath))
                {
                    _log4JPath = absolutePath;
                }
                else
                {
                    throw new ArgumentException($"{_log4JPath} is not an absolute path and there is no file under {Const.DefaultConfigurationPath} whose absolute path is {absolutePath}");
                }
            }
            _logPath = ParsedArgs.Get<string>(CLIParam.LogPath);
            _scalaVersion = ParsedArgs.Get<string>(CLIParam.ScalaVersion);
            _disableJMX = ParsedArgs.Exist(CLIParam.DisableJMX);
            return result;
        }
        /// <summary>
        /// Prepare <see cref="MainClassToRun"/> property
        /// </summary>
        /// <param name="className">The class to search</param>
        /// <exception cref="ArgumentException">If <paramref name="className"/> does not have a corresponding implemented <see cref="Type"/></exception>
        protected virtual void PrepareMainClassToRun(string className)
        {
            if (string.IsNullOrEmpty(className)) return;
            Type type = null;
            foreach (var item in typeof(KNetCore<>).Assembly.ExportedTypes)
            {
                if (item.Name == className || item.FullName == className)
                {
                    type = item;
                    break;
                }
            }
            MainClassToRun = type ?? throw new ArgumentException($"Requested class {className} is not a valid class name.");
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

        /// <summary>
        /// Launch the <typeparamref name="TClass"/> class with the <paramref name="args"/> arguments
        /// </summary>
        /// <typeparam name="TClass">A type which is defined as Main-Class</typeparam>
        /// <param name="args">The arguments of the main method</param>
        public static new void Launch<TClass>(params string[] args)
            where TClass : IJVMBridgeMain
        {
            Launch(typeof(TClass), args);
        }

        /// <summary>
        /// Launch the <paramref name="type"/> with the <paramref name="args"/> arguments
        /// </summary>
        /// <param name="type">The <see cref="Type"/> extending <see cref="IJVMBridgeMain"/></param>
        /// <param name="args">The arguments of the main method</param>
        public static new void Launch(Type type, params string[] args)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            try
            {
                JNetCore<T>.Launch(type, args);
            }
            catch (ArgumentException)
            {
                if (type.GetInterface(typeof(IJVMBridgeMain).Name) == null) throw;
                var execType = type;
                do
                {
                    if (args.Length == 0)
                    {
                        System.Reflection.MethodInfo method = execType.GetMethods().FirstOrDefault(method => method.Name == "SExecute" & method.GetParameters().Length == 2 & method.IsGenericMethod == false);
                        if (method != null)
                        {
                            method.Invoke(null, new object[] { "main", new object[] { args } });
                            return;
                        }
                    }
                    else
                    {
                        System.Reflection.MethodInfo method = execType.GetMethod("Main", new Type[] { typeof(Java.Lang.String[]) });
                        if (method != null)
                        {
                            Java.Lang.String[] strings = new Java.Lang.String[args.Length];
                            for (int i = 0; i < args.Length; i++)
                            {
                                strings[i] = args[i];
                            }
                            method.Invoke(null, new object[] { strings });
                        }
                        return;
                    }
                    execType = execType.BaseType;
                }
                while (execType != null && execType != typeof(object));

            }
            throw new ArgumentException($"{type} does not define any IJVMBridgeMain type or interface", "type");
        }

#if DEBUG
        /// <inheritdoc cref="JNetCoreBase{T}.EnableDebug"/>
        public override bool EnableDebug => true;
#endif
    }
}