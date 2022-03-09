/*
 *  MIT License
 *
 *  Copyright (c) 2022 MASES s.r.l.
 *
 *  Permission is hereby granted, free of charge, to any person obtaining a copy
 *  of this software and associated documentation files (the "Software"), to deal
 *  in the Software without restriction, including without limitation the rights
 *  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 *  copies of the Software, and to permit persons to whom the Software is
 *  furnished to do so, subject to the following conditions:
 *
 *  The above copyright notice and this permission notice shall be included in all
 *  copies or substantial portions of the Software.
 *
 *  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 *  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 *  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 *  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 *  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 *  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 *  SOFTWARE.
 */

using MASES.JCOBridge.C2JBridge;
using MASES.KafkaBridge;
using MASES.KafkaBridge.Clients.Consumer;
using MASES.KafkaBridge.Common.Serialization;
using Java.Lang;
using MASES.KafkaBridge.Java.Util;
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
        static ManualResetEvent resetEvent = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            var appArgs = KafkaBridgeCore.ApplicationArgs;

            if (appArgs.Length != 0)
            {
                serverToUse = args[0];
            }

            //Thread threadConsume = new Thread(PipeDemo)
            System.Threading.Thread threadConsume = new System.Threading.Thread(WordCountDemo)
            {
                Name = "DemoThread"
            };
            threadConsume.Start();

            System.Threading.Thread.Sleep(20000);
            resetEvent.Set();
            System.Threading.Thread.Sleep(2000);
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
            catch (KafkaBridge.Java.Util.Concurrent.ExecutionException ex)
            {
                Console.WriteLine("Streams ended with error: {0}", ex.InnerException.Message);
            }
            catch (System.Exception ex)
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

                ValueMapper<string, Iterable<string>> valueMapper = null;
                KeyValueMapper<string, string, string> keyValuemapper = null;
                StreamsUncaughtExceptionHandler errorHandler = null;

                try
                {
                    var builder = new StreamsBuilder();

                    KStream<string, string> source = builder.Stream<string, string>(topicToUse);

                    valueMapper = new ValueMapper<string, Iterable<string>>((value) =>
                    {
                        Regex regex = new Regex("\\W+");

                        ArrayList<string> arrayList = new ArrayList<string>();

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
            catch (KafkaBridge.Java.Util.Concurrent.ExecutionException ex)
            {
                Console.WriteLine("Streams ended with error: {0}", ex.InnerException.Message);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Streams ended with error: {0}", ex.Message);
            }
        }
    }
}
