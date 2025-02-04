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

using MASES.JCOBridge.C2JBridge;
using MASES.JNet.Specific;
using MASES.JNet;
using MASES.KNet;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace MASES.KNetCLI
{
    class Program
    {
        static Assembly _assembly = typeof(Program).Assembly;

        static async Task Main(string[] args)
        {
            try
            {
                KNetCLICore.CreateGlobalInstance();

                if (KNetCLICore.MainClassToRun != null)
                {
                    try
                    {
                        KNetCLICore.Launch(KNetCLICore.MainClassToRun, KNetCLICore.FilteredArgs);
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
                else if (KNetCLICore.Interactive)
                {
                    ShowLogo("Interactive shell");

                    ScriptOptions options = ScriptOptions.Default.WithReferences(typeof(JNetCoreBase<>).Assembly)
                                                                 .WithImports(KNetCLICore.NamespaceList);
                    ScriptState<object> state = null;
                    while (true)
                    {
                        try
                        {
                            var codeToEval = Console.ReadLine();
                            if (state == null)
                            {
                                state = await CSharpScript.RunAsync(codeToEval, options);
                            }
                            else
                            {
                                state = await state.ContinueWithAsync(codeToEval, options, (o) =>
                                {
                                    if (o is CompilationErrorException)
                                    {
                                        Console.WriteLine(o);
                                        return true;
                                    }
                                    else if (o is JVMBridgeException jvmbe)
                                    {
                                        Console.WriteLine($"{jvmbe.BridgeClassName}: {jvmbe.Message}");
                                        return true;
                                    }
                                    return false;
                                });
                            }
                            if (state.ReturnValue != null) Console.WriteLine(state.ReturnValue);
                        }
                        catch (JVMBridgeException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (CompilationErrorException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }
                else if (!string.IsNullOrEmpty(KNetCLICore.Script))
                {
                    ShowLogo("Script mode");

                    if (!File.Exists(KNetCLICore.Script)) throw new FileNotFoundException("A valid file must be provided", KNetCLICore.Script);

                    var scriptCode = File.ReadAllText(KNetCLICore.Script);

                    ScriptOptions options = ScriptOptions.Default.WithReferences(typeof(JNetCoreBase<>).Assembly, typeof(KNetCore<>).Assembly)
                                                                 .WithImports(KNetCLICore.NamespaceList);

                    var script = CSharpScript.Create(scriptCode, options);
                    var result = await script.RunAsync();
                    if (result.ReturnValue != null) Console.WriteLine(result.ReturnValue);
                }
                else ShowHelp();
            }
            catch (TargetInvocationException tie)
            {
                StringBuilder sb = new StringBuilder();
                Exception e = tie.InnerException;
                sb.AppendLine(e.Message);
                Exception innerException = e.InnerException;
                while (innerException != null)
                {
                    sb.AppendLine(innerException.Message);
                    innerException = innerException.InnerException;
                }
                ShowHelp(sb.ToString());
            }
            catch (JVMBridgeException e)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(e.Message);
                Exception innerException = e.InnerException;
                while (innerException != null)
                {
                    sb.AppendLine(innerException.Message);
                    innerException = innerException.InnerException;
                }
                ShowHelp(sb.ToString());
            }
            catch (Exception e)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(e.Message);
                Exception innerException = e.InnerException;
                while (innerException != null)
                {
                    sb.AppendLine(innerException.Message);
                    innerException = innerException.InnerException;
                }
                ShowHelp(sb.ToString());
            }
        }

        static void ShowLogo(string logoTrailer)
        {
            if (!KNetCLICore.NoLogo)
            {
                Console.WriteLine($"KNetCLI - CLI interface for KNet - Version {_assembly.GetName().Version} - {logoTrailer}");
            }
        }

        static void ShowHelp(string errorString = null)
        {
            if (!string.IsNullOrEmpty(errorString))
            {
                Console.WriteLine("Error: {0}", errorString);
            }
            IDictionary<string, Type> implementedClasses = KNetCLICore.GetMainClasses(typeof(KNetCore<>).Assembly);
            StringBuilder avTypes = new();
            foreach (var item in implementedClasses.Keys)
            {
                avTypes.AppendFormat("{0}, ", item);
            }
            Console.WriteLine(_assembly.GetName().Name + " -ClassToRun classname [-KafkaLocation kafkaFolder] <JCOBridgeArguments> <ClassArguments>");
            Console.WriteLine();
            Console.WriteLine("ClassToRun: the class to be invoked ({0}...). ", avTypes.ToString());
            Console.WriteLine("KafkaLocation: The folder where Kafka package is available. Default consider this application uses the package jars folder.");
            Console.WriteLine("ScalaVersion: the scala version to be used. The default version (2.13.6) is binded to the deafult Apache Kafka version available in the package.");
            Console.WriteLine("Log4JConfiguration: the log4j configuration file; the default uses the file within the package.");
            Console.WriteLine("JCOBridgeArguments: the arguments of JCOBridge (see online at https://www.jcobridge.com/net-examples/command-line-options/ for the possible values). ");
            Console.WriteLine("ClassArguments: the arguments of the class. Depends on the ClassToRun value, to obtain them runs the application or look at Apache Kafka documentation.");
            Console.WriteLine();
            Console.WriteLine("Examples:");
            Console.WriteLine(_assembly.GetName().Name + " -ClassToRun ConsoleConsumer --bootstrap-server SERVER-ADDRESS:9093 --topic topic_name --from-beginning");
        }
    }
}