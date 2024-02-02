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
using MASES.KNet;
using MASES.KNet.Connect;
using Org.Apache.Kafka.Connect;
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
                    new ArgumentMetadata<object>()
                    {
                        Name = CLIParam.KNetVersion,
                        ShortName = CLIParam.KNetVersion[0].ToString(),
                        Type = ArgumentType.Single,
                        Help = "Connect will run using KNet version of Standalone or Distributed.",
                    },
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
                _classToRun = ParsedArgs.Exist(CLIParam.KNetVersion) ? "KNetConnectStandalone" : "ConnectStandalone";
                KNetConnectProxy.Initialize(this);
                ApplicationLog4JPath = Path.Combine(Const.AssemblyLocation, "config", "connect-log4j.properties");
                ApplicationHeapSize = "2G";
                ApplicationInitialHeapSize = "256M";
                if (result == null || result.Length == 0) Console.WriteLine($"USAGE: MASES.KNetConnect -[s|d] [-k] [-daemon] <connect-standalone.properties or env variable with connect-standalone.properties> [<connector1.properties or env variable with connector1.properties> <connector2.properties or env variable with connector2.properties> ...]");
                else
                {
                    var tmpResult = new List<string>(result);
                    if (tmpResult.Contains("-daemon"))
                    {
                        tmpResult.Add("-name");
                        tmpResult.Add(ParsedArgs.Exist(CLIParam.KNetVersion) ? "kNetConnectStandalone" : "connectStandalone");
                    }
                    result = tmpResult.ToArray();
                }
            }

            if (ParsedArgs.Exist(CLIParam.Distributed))
            {
                _classToRun = ParsedArgs.Exist(CLIParam.KNetVersion) ? "KNetConnectDistributed" : "ConnectDistributed";
                KNetConnectProxy.Initialize(this);
                ApplicationLog4JPath = Path.Combine(Const.AssemblyLocation, "config", "connect-log4j.properties");
                ApplicationHeapSize = "2G";
                ApplicationInitialHeapSize = "256M";
                if (result == null || result.Length == 0) Console.WriteLine($"USAGE: MASES.KNetConnect -[s|d] [-k] [-daemon] <connect-distributed.properties or env variable with connect-distributed.properties>");
                else
                {
                    var tmpResult = new List<string>(result);
                    if (tmpResult.Contains("-daemon"))
                    {
                        tmpResult.Add("-name");
                        tmpResult.Add(ParsedArgs.Exist(CLIParam.KNetVersion) ? "kNetConnectDistributed" : "connectDistributed");
                    }
                    result = tmpResult.ToArray();
                }
            }

            PrepareMainClassToRun(_classToRun);

            return result;
        }
    }
}
