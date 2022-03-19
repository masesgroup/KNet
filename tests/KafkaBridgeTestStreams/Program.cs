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

using Java.Util;
using MASES.JCOBridge.C2JBridge;
using MASES.KafkaBridge;
using MASES.KafkaBridge.Clients.Consumer;
using MASES.KafkaBridge.Common.Serialization;
using MASES.KafkaBridge.Streams;
using MASES.KafkaBridge.Streams.Errors;
using MASES.KafkaBridge.Streams.KStream;
using System;
using System.Text.RegularExpressions;
using System.Threading;

namespace MASES.KafkaBridgeTest
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
            KafkaBridgeCore.CreateGlobalInstance();
            var appArgs = KafkaBridgeCore.FilteredArgs;

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

            Thread.Sleep(20000);
            resetEvent.Set();
            Thread.Sleep(2000);
        }

        static void PipeDemo()
        {
            try
            {
                var props = new Properties();

                props.Put(StreamsConfig.APPLICATION_ID_CONFIG, "streams-pipe");
                props.Put(StreamsConfig.BOOTSTRAP_SERVERS_CONFIG, serverToUse);
                props.Put(StreamsConfig.DEFAULT_KEY_SERDE_CLASS_CONFIG, Serdes.String.Dyn().getClass());
                props.Put(StreamsConfig.DEFAULT_VALUE_SERDE_CLASS_CONFIG, Serdes.String.Dyn().getClass());

                // setting offset reset to earliest so that we can re-run the demo code with the same pre-loaded data
                props.Put(ConsumerConfig.AUTO_OFFSET_RESET_CONFIG, "earliest");

                var builder = new StreamsBuilder();

                builder.Stream<string, string>(topicToUse).To("streams-pipe-output");

                using (var streams = new KafkaStreams(builder.Build(), props))
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
                var props = new Properties();

                props.Put(StreamsConfig.APPLICATION_ID_CONFIG, "WordCountDemo");
                props.Put(StreamsConfig.BOOTSTRAP_SERVERS_CONFIG, serverToUse);
                props.Put(StreamsConfig.CACHE_MAX_BYTES_BUFFERING_CONFIG, 0);
                props.Put(StreamsConfig.DEFAULT_KEY_SERDE_CLASS_CONFIG, Serdes.String.Dyn().getClass());
                props.Put(StreamsConfig.DEFAULT_VALUE_SERDE_CLASS_CONFIG, Serdes.String.Dyn().getClass());

                // setting offset reset to earliest so that we can re-run the demo code with the same pre-loaded data
                props.Put(ConsumerConfig.AUTO_OFFSET_RESET_CONFIG, "earliest");

                ValueMapper<string, Java.Lang.Iterable<string>> valueMapper = null;
                KeyValueMapper<string, string, string> keyValuemapper = null;
                StreamsUncaughtExceptionHandler errorHandler = null;

                try
                {
                    var builder = new StreamsBuilder();

                    KStream<string, string> source = builder.Stream<string, string>(topicToUse);

                    valueMapper = new ValueMapper<string, Java.Lang.Iterable<string>>((value) =>
                    {
                        Regex regex = new("\\W+");

                        ArrayList<string> arrayList = new();

                        foreach (var item in regex.Split(value))
                        {
                            arrayList.Add(item);
                        }

                        return arrayList; // value->Arrays.asList(value.toLowerCase(Locale.getDefault()).split("\\W+"))
                    });

                    keyValuemapper = new KeyValueMapper<string, string, string>((key, value) =>
                    {
                        return value;
                    });
                    
                    KTable<string, long> counts = source.FlatMapValues(valueMapper)
                                                        .GroupBy(keyValuemapper)
                                                        .Count();
                    
                    /***** version using Dynamic engine ******
                    
                    KTable<string, long> counts = JVMBridgeBase.Wraps<KTable<string, long>>(source.Dyn()
                        .flatMapValues(valueMapper)
                        .groupBy(keyValuemapper)
                        .count() as IJavaObject);
                    ******************************************/

                    // need to override value serde to Long type
                    counts.ToStream().To(OUTPUT_TOPIC, Produced<string, long>.With(Serdes.String, Serdes.Long));

                    using (var streams = new KafkaStreams(builder.Build(), props))
                    {
                        errorHandler = new StreamsUncaughtExceptionHandler((exception) =>
                        {
                            Console.WriteLine(exception.ToString());
                            return StreamThreadExceptionResponse.SHUTDOWN_APPLICATION;
                        });
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
                    if (valueMapper != null) valueMapper.Dispose();
                    if (keyValuemapper != null) keyValuemapper.Dispose();
                    if (errorHandler != null) errorHandler.Dispose();
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
