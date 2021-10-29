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
using MASES.KafkaBridge;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace MASES.KafkaBridgeCLI
{
    class Program
    {
        class CLIParam
        {
            // CommonArgs
            public const string ClassToRun = "ClassToRun";
            public const string KafkaLocation = "KafkaLocation";
        }

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
                    IsMandatory = true,
                    Help = "The class to be instantiated.",
                },
                new ArgumentMetadata<string>()
                {
                    Name = CLIParam.KafkaLocation,
                    Default = "..",
                    Help = "The folder where Kafka package is available. Default consider this application running in bin folder.",
                },
            };
        }

        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0) { showHelp(); return; }

                parser.Add(prepareArguments());

                var arguments = parser.Parse(args);

                var className = arguments.Get<string>(CLIParam.ClassToRun);

                Type type = null;

                foreach (var item in typeof(KafkaBridgeCore).Assembly.ExportedTypes)
                {
                    if (item.Name == className || item.FullName == className)
                    {
                        type = item;
                        break;
                    }
                }

                if (type == null) throw new ArgumentException($"Requested class {className} is not a valid class name.");

                try
                {
                    var core = Activator.CreateInstance(type) as KafkaBridgeMain;
                    if (core == null) throw new ArgumentException("Requested class is not a child of KafkaBridgeMain.");

                    core.Execute(parser.UnparsedArgs);
                }
                catch (TargetInvocationException tie)
                {
                    throw tie.InnerException;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void showHelp(string errorString = null)
        {
            var assembly = typeof(Program).Assembly;

            Console.WriteLine("KafkaBridgeCLI - CLI interface for KafkaBridge - Version " + assembly.GetName().Version.ToString());
            Console.WriteLine(assembly.GetName().Name + " -ClassToRun classname [-KafkaLocation kafkaFolder] <JCOBridgeArguments> <ClassArguments>");
            Console.WriteLine();
            if (!string.IsNullOrEmpty(errorString))
            {
                Console.WriteLine("Error: {0}", errorString);
            }
            Console.WriteLine("ClassToRun: the class to be invoked (ConsoleConsumer, ConsoleProducer, ...). ");
            Console.WriteLine("KafkaLocation: The folder where Kafka package is available. Default consider this application running in bin folder.");
            Console.WriteLine("JCOBridgeArguments: the arguments of JCOBridge (see online for the possible values). ");
            Console.WriteLine("ClassArguments: the arguments of the class. Depends on the ClassToRun value, to obtain them runs the application or look at Apache Kafka documentation.");
            Console.WriteLine();
            Console.WriteLine("Examples:");
            Console.WriteLine(assembly.GetName().Name + " -ClassToRun ConsoleConsumer --bootstrap-server SERVER-ADDRESS:9093 --topic topic_name --from-beginning");
        }
    }
}