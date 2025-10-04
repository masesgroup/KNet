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

using MASES.JNet.CLI;
using System;
using System.Threading.Tasks;

namespace MASES.KNet.CLI
{
    class Program : ProgramBase<KNetCLICore, Program>
    {
        /// <inheritdoc/>
        public override string ProjectName => "KNet";

        public override string SpecificArguments => "KafkaLocation: The folder where Kafka package is available. Default consider this application uses the package jars folder." + Environment.NewLine +
                                                    "ScalaVersion: the scala version to be used. The default version (2.13.6) is binded to the deafult Apache Kafka version available in the package." + Environment.NewLine +
                                                    "Log4JConfiguration: the log4j configuration file; the default uses the file within the package.";

        public override string ExampleLines => $"{ProgramName} -ClassToRun ConsoleConsumer --bootstrap-server SERVER-ADDRESS:9093 --topic topic_name --from-beginning";

        static async Task Main(string[] args)
        {
            await InternalMain(args);
        }
    }
}