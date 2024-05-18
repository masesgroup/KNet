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

using Java.Util;
using MASES.JCOBridge.C2JBridge;

using MASES.KNet.TestCommon;
using System;
using System.Text.RegularExpressions;
using System.Threading;
using MASES.KNet.Streams;
using MASES.KNet.Streams.Kstream;
using Org.Apache.Kafka.Streams.Errors;
using MASES.KNet.Serialization;

namespace MASES.KNetTestKNetStreams
{
    class Program
    {
        const string INPUT_TOPIC = "streams-plaintext-input";
        const string OUTPUT_TOPIC = "streams-wordcount-output";

        static bool useSerdes = true;
        static bool useCallback = true;

        const string theServer = "localhost:9092";
        const string theTopic = "myTopic";

        static string serverToUse = theServer;
        static string topicToUse = theTopic;
        static readonly ManualResetEvent resetEvent = new(false);

        static void Main(string[] args)
        {
            SharedKNetCore.CreateGlobalInstance();
            var appArgs = SharedKNetCore.FilteredArgs;

            if (appArgs.Length != 0)
            {
                serverToUse = args[0];
            }

            //Thread threadConsume = new Thread(PipeDemo)
            Thread threadConsume = new(WordCountDemo)
            {
                Name = "DemoThread"
            };
            threadConsume.Start();

            Console.CancelKeyPress += Console_CancelKeyPress;
            Console.WriteLine("Press Ctrl-C to exit");
            resetEvent.WaitOne();
            Thread.Sleep(2000); // wait the threads exit
        }

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            if (e.Cancel) resetEvent.Set();
        }

        static void PipeDemo()
        {
            try
            {
                string baSerdesName = Java.Lang.Class.ClassNameOf<Org.Apache.Kafka.Common.Serialization.Serdes.ByteArraySerde>();
                var keyValueSerde = Java.Lang.Class.ForName(baSerdesName, true, Java.Lang.ClassLoader.SystemClassLoader);
                StreamsConfigBuilder configBuilder = StreamsConfigBuilder.Create()
                                                                         .WithApplicationId("streams-pipe")
                                                                         .WithBootstrapServers(serverToUse)
                                                                         .WithDefaultKeySerdeClass(keyValueSerde)
                                                                         .WithDefaultValueSerdeClass(keyValueSerde);

                var builder = new StreamsBuilder(configBuilder);

                builder.Stream<string, string, byte[], byte[]>(topicToUse).To("streams-pipe-output");

                var streams = new KNetStreams(builder.Build(), configBuilder);
                {
                    streams.Start();
                    while (!resetEvent.WaitOne(1000))
                    {
                        var state = streams.State;
                        Console.WriteLine($"KafkaStreams state: {state}");
                    }
                }
            }
            catch (Java.Util.Concurrent.ExecutionException ex)
            {
                Console.WriteLine("Streams ended with error: {0}", ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Streams ended with error: {0}", ex.Message);
            }
        }

        static void WordCountDemo()
        {
            try
            {
                string baSerdesName = Java.Lang.Class.ClassNameOf<Org.Apache.Kafka.Common.Serialization.Serdes.ByteArraySerde>();
                var keyValueSerde = Java.Lang.Class.ForName(baSerdesName, true, Java.Lang.ClassLoader.SystemClassLoader);
                StreamsConfigBuilder configBuilder = StreamsConfigBuilder.Create()
                                                                         .WithApplicationId("WordCountDemo")
                                                                         .WithBootstrapServers(serverToUse)
                                                                         .WithDefaultKeySerdeClass(keyValueSerde)
                                                                         .WithDefaultValueSerdeClass(keyValueSerde);

                EnumerableValueMapper<string, string> valueMapper = null;
                KeyValueMapper<string, string, string> keyValuemapper = null;
                StreamsUncaughtExceptionHandler errorHandler = null;

                try
                {
                    var builder = new StreamsBuilder(configBuilder);

                    var source = builder.Stream<string, string, byte[], byte[]>(topicToUse);

                    valueMapper = new EnumerableValueMapper<string, string>()
                    {
                        OnApply = (value) =>
                        {
                            Regex regex = new("\\W+");
                            return regex.Split(value); // value->Arrays.asList(value.toLowerCase(Locale.getDefault()).split("\\W+"))
                        }
                    };

                    keyValuemapper = new KeyValueMapper<string, string, string>()
                    {
                        OnApply = (key, value) =>
                        {
                            return value;
                        }
                    };

                    var counts = source.FlatMapValues<string, byte[], string, string>(valueMapper)
                                       .GroupBy(keyValuemapper)
                                       .Count();

                    /***** version using Dynamic engine ******
                    
                    KTable<string, long> counts = JVMBridgeBase.Wraps<KTable<string, long>>(source.Dyn()
                        .flatMapValues(valueMapper)
                        .groupBy(keyValuemapper)
                        .count() as IJavaObject);
                    ******************************************/

                    // need to override value serde to Long type
                    counts.ToStream().To(OUTPUT_TOPIC, Produced<string, long, byte[], Java.Lang.Long>.With(SerDes.String, SerDes.Long));

                    var streams = new KNetStreams(builder.Build(), configBuilder);
                    {
                        errorHandler = new StreamsUncaughtExceptionHandler()
                        {
                            OnHandle = (exception) =>
                            {
                                Console.WriteLine(exception.ToString());
                                return StreamsUncaughtExceptionHandler.StreamThreadExceptionResponse.SHUTDOWN_APPLICATION;
                            }
                        };
                        streams.SetUncaughtExceptionHandler(errorHandler);
                        streams.Start();
                        while (!resetEvent.WaitOne(1000))
                        {
                            var state = streams.State;
                            Console.WriteLine($"KafkaStreams state: {state}");
                        }
                    }
                }
                finally
                {
                    valueMapper?.Dispose();
                    keyValuemapper?.Dispose();
                    errorHandler?.Dispose();
                }
            }
            catch (Java.Util.Concurrent.ExecutionException ex)
            {
                Console.WriteLine("Streams ended with error: {0}", ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Streams ended with error: {0}", ex.Message);
            }
        }
    }
}
