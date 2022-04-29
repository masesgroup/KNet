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

using MASES.JCOBridge.C2JBridge;
using MASES.KNet;
using System;
using System.Reflection;
using System.Text;

namespace MASES.KNetCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0) { ShowHelp(); return; }

                KNetCore.CreateGlobalInstance();

                try
                {
                    var core = Activator.CreateInstance(KNetCore.MainClassToRun) as JVMBridgeBase;
                    if (core == null) throw new ArgumentException("Requested class is not a child of JVMBridgeBase.");

                    core.Execute(KNetCore.FilteredArgs);
                }
                catch (TargetInvocationException tie)
                {
                    throw tie.InnerException;
                }
                catch (JCOBridge.C2JBridge.JVMInterop.JavaException je)
                {
                    throw je.Convert();
                }
            }
            catch (JVMBridgeException e)
            {
                Console.WriteLine(e.Message);
                Exception innerException = e.InnerException;
                while (innerException != null)
                {
                    Console.WriteLine(innerException.Message);
                    innerException = innerException.InnerException;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Exception innerException = e.InnerException;
                while (innerException != null)
                {
                    Console.WriteLine(innerException.Message);
                    innerException = innerException.InnerException;
                }
            }
        }

        static void ShowHelp(string errorString = null)
        {
            var assembly = typeof(Program).Assembly;

            Console.WriteLine("KNetCLI - CLI interface for KNet - Version " + assembly.GetName().Version.ToString());
            Console.WriteLine(assembly.GetName().Name + " -ClassToRun classname [-KafkaLocation kafkaFolder] <JCOBridgeArguments> <ClassArguments>");
            Console.WriteLine();
            if (!string.IsNullOrEmpty(errorString))
            {
                Console.WriteLine("Error: {0}", errorString);
            }
            StringBuilder avTypes = new StringBuilder();
            foreach (var item in typeof(KNetCore).Assembly.ExportedTypes)
            {
                var baseType = item.GetTypeInfo().BaseType;
                if (baseType != null && baseType.IsGenericType && baseType.GetGenericTypeDefinition() == typeof(JVMBridgeMain<>))
                {
                    avTypes.AppendFormat("{0}, ", item.Name);
                }
            }

            Console.WriteLine("ClassToRun: the class to be invoked ({0}...). ", avTypes.ToString());
            Console.WriteLine("KafkaLocation: The folder where Kafka package is available. Default consider this application uses the package jars folder.");
            Console.WriteLine("ScalaVersion: the scala version to be used. The default version (2.13.6) is binded to the deafult Apache Kafka version available in the package.");
            Console.WriteLine("Log4JConfiguration: the log4j configuration file; the default uses the file within the package.");
            Console.WriteLine("JCOBridgeArguments: the arguments of JCOBridge (see online at https://www.jcobridge.com/net-examples/command-line-options/ for the possible values). ");
            Console.WriteLine("ClassArguments: the arguments of the class. Depends on the ClassToRun value, to obtain them runs the application or look at Apache Kafka documentation.");
            Console.WriteLine();
            Console.WriteLine("Examples:");
            Console.WriteLine(assembly.GetName().Name + " -ClassToRun ConsoleConsumer --bootstrap-server SERVER-ADDRESS:9093 --topic topic_name --from-beginning");
        }
    }
}