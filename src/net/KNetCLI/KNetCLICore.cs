/*
*  Copyright 2025 MASES s.r.l.
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
using MASES.JNet;
using MASES.KNet;
using System;
using System.Collections.Generic;
using System.IO;

namespace MASES.KNetCLI
{
    /// <summary>
    /// Overridable implementation of <see cref="KNetCore{T}"/>
    /// </summary>
    public class KNetCLICore<T> : KNetCore<T>
        where T : KNetCLICore<T>
    {
        class CLIParam
        {
            // ReflectorArgs
            public static string[] Interactive = new string[] { "Interactive", "i" };
            public static string[] NoLogo = new string[] { "NoLogo", "nl" };
            public static string[] Script = new string[] { "Script", "s" };
            public static string[] JarList = new string[] { "JarList", "jl" };
            public static string[] NamespaceList = new string[] { "NamespaceList", "nl" };
            public static string[] ImportList = new string[] { "ImportList", "il" };
        }

        static bool _Interactive;
        public static bool Interactive => _Interactive;

        static bool _NoLogo;
        public static bool NoLogo => _NoLogo;

        static string _Script;
        public static string Script => _Script;

        static IEnumerable<string> _JarList;
        public static IEnumerable<string> JarList => _JarList;

        static IEnumerable<string> _NamespaceList;
        public static IEnumerable<string> NamespaceList => _NamespaceList;

        static IEnumerable<string> _ImportList;
        public static IEnumerable<string> ImportList => _ImportList;

        /// <summary>
        /// Public ctor
        /// </summary>
        public KNetCLICore()
        {
            foreach (var item in ImportList)
            {
                ImportPackage(item);
            }
        }

        protected override string DefaultLog4JConfiguration()
        {
            return Path.Combine(Const.DefaultConfigurationPath, "tools-log4j.properties");
        }

        public override IEnumerable<IArgumentMetadata> CommandLineArguments
        {
            get
            {
                var lst = new List<IArgumentMetadata>(base.CommandLineArguments);
                lst.AddRange(new IArgumentMetadata[]
                {
                    new ArgumentMetadata<string>()
                    {
                        Name = CLIParam.Interactive[0],
                        ShortName = CLIParam.Interactive[1],
                        Type = ArgumentType.Single,
                        Help = "Activate an interactive shell",
                    },
                    new ArgumentMetadata<string>()
                    {
                        Name = CLIParam.NoLogo[0],
                        ShortName = CLIParam.NoLogo[1],
                        Type = ArgumentType.Single,
                        Help = "Do not display initial informative string",
                    },
                    new ArgumentMetadata<string>()
                    {
                        Name = CLIParam.Script[0],
                        ShortName = CLIParam.Script[1],
                        Type = ArgumentType.Double,
                        Help = "Run the script code and exit, the argument is the path to the file containing the script",
                    },
                    new ArgumentMetadata<string>()
                    {
                        Name = CLIParam.JarList[0],
                        ShortName = CLIParam.JarList[1],
                        Type = ArgumentType.Double,
                        Help = "A CSV list of JAR to be used or folders containing the JARs",
                    },
                    new ArgumentMetadata<string>()
                    {
                        Name = CLIParam.NamespaceList[0],
                        ShortName = CLIParam.NamespaceList[1],
                        Type = ArgumentType.Double,
                        Help = "A CSV list of namespace to be used for interactive shell, JNet/KNet namespaces are added automatically",
                    },
                    new ArgumentMetadata<string>()
                    {
                        Name = CLIParam.ImportList[0],
                        ShortName = CLIParam.ImportList[1],
                        Type = ArgumentType.Double,
                        Help = "A CSV list of import to be used",
                    },
                });
                return lst;
            }
        }

        protected override string[] ProcessCommandLine()
        {
            var result = base.ProcessCommandLine(); // returns the filtered args till now

            if (string.IsNullOrWhiteSpace(_classToRun) && result != null && result.Length > 0)
            {
                // try to use first argument as ClassToRun
                _classToRun = result[0];
                int remaining = result.Length - 1;
                if (remaining != 0)
                {
                    string[] tmp_result = new string[remaining];
                    Array.Copy(result, 1, tmp_result, 0, remaining); // remove first argument
                    result = tmp_result;
                }
            }

            _Interactive = ParsedArgs.Exist(CLIParam.Interactive[0]);
            _NoLogo = ParsedArgs.Exist(CLIParam.NoLogo[0]);

            _Script = ParsedArgs.Get<string>(CLIParam.Script[0]);

            List<string> jarList = new List<string>();
            if (ParsedArgs.Exist(CLIParam.JarList[0]))
            {
                var jars = ParsedArgs.Get<string>(CLIParam.JarList[0]).Split(',', ';');
                jarList.AddRange(jars);
            }
            _JarList = jarList;

            List<string> namespaceList = new List<string>();

            var jnetAssembly = typeof(JNetCoreBase<>).Assembly;
            foreach (var item in jnetAssembly.GetExportedTypes())
            {
                if (item.IsPublic)
                {
                    if (!namespaceList.Contains(item.Namespace)) namespaceList.Add(item.Namespace);
                }
            }
            var knetAssembly = typeof(KNetCore<>).Assembly;
            foreach (var item in knetAssembly.GetExportedTypes())
            {
                if (item.IsPublic)
                {
                    if (!namespaceList.Contains(item.Namespace)) namespaceList.Add(item.Namespace);
                }
            }
            if (ParsedArgs.Exist(CLIParam.NamespaceList[0]))
            {
                var namespaces = ParsedArgs.Get<string>(CLIParam.JarList[0]).Split(',', ';');
                foreach (var item in namespaces)
                {
                    if (!namespaceList.Contains(item)) namespaceList.Add(item);
                }
            }
            _NamespaceList = namespaceList;

            List<string> importList = new List<string>();
            if (ParsedArgs.Exist(CLIParam.ImportList[0]))
            {
                var imports = ParsedArgs.Get<string>(CLIParam.JarList[0]).Split(',', ';');
                foreach (var item in imports)
                {
                    if (!importList.Contains(item)) importList.Add(item);
                }
            }
            _ImportList = importList;

            PrepareMainClassToRun(ClassToRun);

            switch (ClassToRun?.ToLowerInvariant())
            {
                case "verifiableconsumer":
                    ApplicationHeapSize = "512M";
                    break;
                case "verifiableproducer":
                    ApplicationHeapSize = "512M";
                    break;
                case "streamsresetter":
                    ApplicationHeapSize = "512M";
                    break;
                case "zookeeperstart":
                    ApplicationHeapSize = "512M";
                    ApplicationInitialHeapSize = "512M";
                    break;
                case "zookeepershell":
                    ApplicationHeapSize = "512M";
                    ApplicationInitialHeapSize = "512M";
                    break;
                case "kafkastart":
                    ApplicationHeapSize = Environment.Is64BitOperatingSystem ? "1G" : "512M";
                    ApplicationInitialHeapSize = Environment.Is64BitOperatingSystem ? "1G" : "512M";
                    break;
                case "connectstandalone":
                case "connectdistributed":
                case "knetconnectstandalone":
                case "knetconnectdistributed":
                    {
                        throw new ArgumentException($"Use KNetConnect to run KNet Connect SDK");
                    }
                case "mirrormaker2":
                    {
                        ApplicationLog4JPath = Path.Combine(Const.AssemblyLocation, "config", "connect-log4j.properties");
                        ApplicationHeapSize = "2G";
                        ApplicationInitialHeapSize = "256M";
                        if (result == null || result.Length == 0) Console.WriteLine($"USAGE: MASES.KNetCLI -ClassToRun {ClassToRun} [-daemon] mm2.properties");
                        else
                        {
                            var tmpResult = new List<string>(result);
                            if (tmpResult.Contains("-daemon"))
                            {
                                tmpResult.Add("-name");
                                tmpResult.Add("mirrorMaker");
                            }
                            result = tmpResult.ToArray();
                        }
                    }
                    break;
                default:
                    ApplicationHeapSize ??= "256M";
                    break;
            }

            return result;
        }

        /// <inheritdoc cref="JNetCoreBase{T}.PathToParse"/>
        protected override IList<string> PathToParse
        {
            get
            {
                var lst = base.PathToParse;
                foreach (var item in _JarList)
                {
                    lst.Add(Path.GetFullPath(item));
                }
                return lst;
            }
        }
    }

    /// <summary>
    /// Directly usable implementation of <see cref="KNetCLICore{T}"/>
    /// </summary>
    internal class KNetCLICore : KNetCLICore<KNetCLICore>
    {
    }
}
