﻿/*
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

using MASES.CLIParser;
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
        public override IEnumerable<IArgumentMetadata> CommandLineArguments
        {
            get
            {
                var lst = new List<IArgumentMetadata>(base.CommandLineArguments);
                lst.AddRange(new IArgumentMetadata[]
                {
                    new ArgumentMetadata<string>()
                    {
                        Name = CLIParam.Distributed,
                        ShortName = CLIParam.Distributed[0].ToString(),
                        Type = ArgumentType.Single,
                        Help = "Connect will run in distributed mode.",
                    },
                    new ArgumentMetadata<string>()
                    {
                        Name = CLIParam.Standalone,
                        ShortName = CLIParam.Standalone[0].ToString(),
                        Type = ArgumentType.Single,
                        Help = "Connect will run in standalone mode.",
                    },
                });
                return lst;
            }
        }

        protected override string[] ProcessCommandLine()
        {
            var result = base.ProcessCommandLine();

            if (!ParsedArgs.Exist(CLIParam.Distributed) && !ParsedArgs.Exist(CLIParam.Standalone))
            {
                throw new ArgumentException("Neighter Distributed nor Standalone was requested.");
            }
            else if (ParsedArgs.Exist(CLIParam.Distributed) && ParsedArgs.Exist(CLIParam.Standalone))
            {
                throw new ArgumentException("Cannote define both Distributed and Standalone.");
            }

            string _classToRun = string.Empty;

            if (ParsedArgs.Exist(CLIParam.Standalone))
            {
                _classToRun = "ConnectStandalone";
                KNetConnectProxy.Initialize(this);
                ApplicationLog4JPath = Path.Combine(Const.AssemblyLocation, "config", "connect-log4j.properties");
                ApplicationHeapSize = "2G";
                ApplicationInitialHeapSize = "256M";
                if (result == null || result.Length == 0) Console.WriteLine($"USAGE: MASES.KNetConnect -[s|d] [-daemon] connect-standalone.properties");
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

            if (ParsedArgs.Exist(CLIParam.Distributed))
            {
                _classToRun = "ConnectDistributed";
                KNetConnectProxy.Initialize(this);
                ApplicationLog4JPath = Path.Combine(Const.AssemblyLocation, "config", "connect-log4j.properties");
                ApplicationHeapSize = "2G";
                ApplicationInitialHeapSize = "256M";
                if (result == null || result.Length == 0) Console.WriteLine($"USAGE: MASES.KNetConnect -[s|d] [-daemon] connect-distributed.properties");
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

            Type type = null;

            foreach (var item in typeof(KNetCore<>).Assembly.ExportedTypes)
            {
                if (item.Name == _classToRun || item.FullName == _classToRun)
                {
                    type = item;
                    break;
                }
            }
            MainClassToRun = type ?? throw new ArgumentException($"Requested class {_classToRun} is not a valid class name.");

            return result;
        }
    }
}
