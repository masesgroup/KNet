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

namespace MASES.KNet.Connect
{
    class Program : ProgramBase<KNetConnectCore, Program>
    {
        /// <inheritdoc/>
        public override string ProjectName => "KNetConnect";
        /// <inheritdoc/>
        public override string EntryLine => $"{ProgramName} -[d|s] [-k] connect-standalone.properties [-KafkaLocation kafkaFolder] <JCOBridgeArguments> <ClassArguments>";
        /// <inheritdoc/>
        public override string SpecificArguments => "s: start Connect in standalone mode." + Environment.NewLine +
                                                    "d: start Connect in distributed mode." + Environment.NewLine +
                                                    "k: start Connect in distributed/standalone mode using KNet version." + Environment.NewLine +
                                                    "KafkaLocation: The folder where Kafka package is available. Default consider this application uses the package jars folder." + Environment.NewLine +
                                                    "ScalaVersion: the scala version to be used. The default version (2.13.6) is binded to the deafult Apache Kafka version available in the package." + Environment.NewLine +
                                                    "Log4JConfiguration: the log4j configuration file; the default uses the file within the package.";
        /// <inheritdoc/>
        public override string ExampleLines => $"{ProgramName} -s connect-standalone.properties specific-connector.properties" + Environment.NewLine +
                                               $"{ProgramName} -d connect-distributed.properties";
        /// <inheritdoc/>
        public override bool EnableInteractive => false;
        /// <inheritdoc/>
        public override bool EnableScript => false;
        /// <inheritdoc/>
        public override bool EnableRunCommand => false;

        static async Task Main(string[] args)
        {
            await InternalMain(args);
        }
    }
}