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

using MASES.KNet;
using MASES.KNet.Connect;
using System;
using System.Collections.Generic;
using System.IO;

namespace MASES.KNetCLI
{
    /// <summary>
    /// Directly usable implementation of <see cref="KNetCore{T}"/>
    /// </summary>
    internal class KNetConnectCore : KNetCore<KNetConnectCore>
    {
        protected override string[] ProcessCommandLine()
        {
            var result = base.ProcessCommandLine();

            if (!string.IsNullOrEmpty(ClassToRun))
            {
                Type type = null;

                foreach (var item in typeof(KNetConnectCore).Assembly.ExportedTypes)
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
                case "ConnectStandalone":
                    {
                        KNetConnectProxy.Initialize(this);
                        ApplicationLog4JPath = Path.Combine(Const.AssemblyLocation, "config", "connect-log4j.properties");
                        ApplicationHeapSize = "2G";
                        ApplicationInitialHeapSize = "256M";
                        if (result == null || result.Length == 0) Console.WriteLine($"USAGE: MASES.KNetCLI -ClassToRun {ClassToRun} [-daemon] connect-standalone.properties");
                        else
                        {
                            var tmpResult = new List<string>(result);
                            if (tmpResult.Contains("-daemon"))
                            {
                                tmpResult.Add("-name");
                                tmpResult.Add("connectStandalone");
                            }
                            result = tmpResult.ToArray();
                        }
                    }
                    break;
                case "ConnectDistributed":
                    {
                        KNetConnectProxy.Initialize(this);
                        ApplicationLog4JPath = Path.Combine(Const.AssemblyLocation, "config", "connect-log4j.properties");
                        ApplicationHeapSize = "2G";
                        ApplicationInitialHeapSize = "256M";
                        if (result == null || result.Length == 0) Console.WriteLine($"USAGE: MASES.KNetCLI -ClassToRun {ClassToRun} [-daemon] connect-distributed.properties");
                        else
                        {
                            var tmpResult = new List<string>(result);
                            if (tmpResult.Contains("-daemon"))
                            {
                                tmpResult.Add("-name");
                                tmpResult.Add("connectDistributed");
                            }
                            result = tmpResult.ToArray();
                        }
                    }
                    break;
                default:
                    throw new ArgumentException($"Use KNetCLI to run {ClassToRun}");
            }

            return result;
        }

    }
}
