/*
*  Copyright 2023 MASES s.r.l.
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
        protected override string[] ProcessCommandLine()
        {
            var result = base.ProcessCommandLine();

            if (!string.IsNullOrEmpty(ClassToRun))
            {
                Type type = null;

                foreach (var item in typeof(KNetCore<>).Assembly.ExportedTypes)
                {
                    if (item.Name == ClassToRun || item.FullName == ClassToRun)
                    {
                        type = item;
                        break;
                    }
                }
                MainClassToRun = type ?? throw new ArgumentException($"Requested class {ClassToRun} is not a valid class name.");
            }

            switch (ClassToRun)
            {
                case "VerifiableConsumer":
                    ApplicationHeapSize = "512M";
                    break;
                case "VerifiableProducer":
                    ApplicationHeapSize = "512M";
                    break;
                case "StreamsResetter":
                    ApplicationHeapSize = "512M";
                    break;
                case "ZooKeeperStart":
                    ApplicationHeapSize = "512M";
                    ApplicationInitialHeapSize = "512M";
                    break;
                case "ZooKeeperShell":
                    ApplicationHeapSize = "512M";
                    ApplicationInitialHeapSize = "512M";
                    break;
                case "KafkaStart":
                    ApplicationHeapSize = Environment.Is64BitOperatingSystem ? "1G" : "512M";
                    ApplicationInitialHeapSize = Environment.Is64BitOperatingSystem ? "1G" : "512M";
                    break;
                case "ConnectStandalone":
                case "ConnectDistributed":
                case "KNetConnectStandalone":
                case "KNetConnectDistributed":
                    {
                        throw new ArgumentException($"Use KNetConnect to run KNet Connect SDK");
                    }
                case "MirrorMaker2":
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
    }

    /// <summary>
    /// Directly usable implementation of <see cref="KNetCLICore{T}"/>
    /// </summary>
    internal class KNetCLICore : KNetCLICore<KNetCLICore>
    {
    }
}
