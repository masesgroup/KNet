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

using MASES.CLIParser;
using MASES.JNet;
using MASES.JNet.Specific.CLI;
using System;
using System.Collections.Generic;
using System.IO;

namespace MASES.KNet.CLI
{
    /// <summary>
    /// Overridable implementation of <see cref="KNetCore{T}"/>
    /// </summary>
    public class KNetCLICore<T> : KNetCore<T>
        where T : KNetCLICore<T>
    {
        /// <inheritdoc cref="JNetCoreBase{T}.CommandLineArguments"/>
        public override IEnumerable<IArgumentMetadata> CommandLineArguments => base.CommandLineArguments.SetCLICommandLineArguments();

        /// <summary>
        /// Public ctor
        /// </summary>
        public KNetCLICore()
        {
            this.InitCLI();
        }

        protected override string DefaultLog4JConfiguration()
        {
            return Path.Combine(Const.DefaultConfigurationPath, "tools-log4j2.yaml");
        }

        protected override string[] ProcessCommandLine()
        {
            var result = base.ProcessCommandLine(); // returns the filtered args till now
            return this.ProcessCLIParsedArgs(result, settingsCallback: (className) =>
            {
                switch (className)
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
                            if (result == null || result.Length == 0) Console.WriteLine($"USAGE: MASES.KNetCLI -ClassToRun {className} [-daemon] mm2.properties");
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
            });
        }

        /// <inheritdoc cref="JNetCoreBase{T}.PathToParse"/>
        protected override IList<string> PathToParse => base.PathToParse.SetCLIPathToParse();
    }

    /// <summary>
    /// Directly usable implementation of <see cref="KNetCLICore{T}"/>
    /// </summary>
    internal class KNetCLICore : KNetCLICore<KNetCLICore>
    {
    }
}
