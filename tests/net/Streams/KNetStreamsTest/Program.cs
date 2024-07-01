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

using MASES.KNet.TestCommon;
using System;
using System.Text.RegularExpressions;
using System.Threading;
using MASES.KNet.Streams;
using MASES.KNet.Streams.Kstream;
using Org.Apache.Kafka.Streams.Errors;
using MASES.KNet.Serialization;
using Org.Apache.Kafka.Streams.State;

namespace MASES.KNetTestKNetStreams
{
    class Program
    {
        static bool withBigExtraValue = false;
        static bool withBigBigExtraValue = false;
        static bool consoleOutput = System.Diagnostics.Debugger.IsAttached ? true : false;
        static bool runBuffered = false;
        static bool useProduceCallback = false;
        static bool useConsumeCallback = false;
        static bool onlyProduce = false;
        static bool flushWhileSend = false;
        static bool withAck = false;
        static bool runInParallel = false;
        static bool avoidThrows = false;
        static bool randomizeTopicName = false;

        const string INPUT_TOPIC = "streams-plaintext-input";
        const string OUTPUT_TOPIC = "streams-wordcount-output";

        const string theServer = "localhost:9092";
        const string theTopic = "myTopic";

        static string serverToUse = theServer;
        static string topicToUse = theTopic;
        static readonly ManualResetEvent resetEvent = new(false);

        static void Main(string[] args)
        {
            SharedKNetCore.Create();
            var appArgs = SharedKNetCore.FilteredArgs;

            if (appArgs.Length != 0)
            {
                serverToUse = args[0];
                if (args.Length > 1)
                {
                    for (int i = 1; i < args.Length; i++)
                    {
                        if (args[i] == "runBuffered") { runBuffered = true; continue; }
                        if (args[i] == "consoleOutput") { consoleOutput = true; continue; }
                        if (args[i] == "useProduceCallback") { useProduceCallback = true; continue; }
                        if (args[i] == "useConsumeCallback") { useConsumeCallback = true; continue; }
                        if (args[i] == "withBigExtraValue") { withBigExtraValue = true; continue; }
                        if (args[i] == "withBigBigExtraValue") { withBigBigExtraValue = true; continue; }
                        if (args[i] == "onlyProduce") { onlyProduce = true; continue; }
                        if (args[i] == "flushWhileSend") { flushWhileSend = true; continue; }
                        if (args[i] == "withAck") { withAck = true; continue; }
                        if (args[i] == "runInParallel") { runInParallel = true; continue; }
                        if (args[i] == "avoidThrows") { avoidThrows = true; continue; }
                        if (args[i] == "randomizeTopicName") { randomizeTopicName = true; continue; }
                        Console.WriteLine($"Unknown {args[i]}");
                    }
                }
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



        static void WordCountDemo()
        {
            StreamsConfigBuilder _streamsConfig = null;
            StreamsBuilder _builder = null;
            Topology _topology = null;
            KNetStreams _streams = null;

            bool _useEnumeratorWithPrefetch;
            bool _usePersistentStorage;
            string _topicName;
            string _storageId;

            _streamsConfig = new();
            StreamsConfigBuilder builder = StreamsConfigBuilder.CreateFrom(_streamsConfig);

            builder.KeySerDesSelector = typeof(KNet.Serialization.Json.JsonSerDes.Key<>);
            builder.ValueSerDesSelector = typeof(KNet.Serialization.Json.JsonSerDes.Value<>);

            builder.ApplicationId = "ApplicationId-" + topicToUse;
            builder.BootstrapServers = serverToUse;

            string baSerdesName = Java.Lang.Class.ClassNameOf<Org.Apache.Kafka.Common.Serialization.Serdes.ByteArraySerde>();
            string bbSerdesName = Java.Lang.Class.ClassNameOf<MASES.KNet.Serialization.Serdes.ByteBufferSerde>();

            builder.DefaultKeySerdeClass = Java.Lang.Class.ForName(baSerdesName, true, Java.Lang.Class.SystemClassLoader);
            builder.DefaultValueSerdeClass = Java.Lang.Class.ForName(bbSerdesName, true, Java.Lang.Class.SystemClassLoader);
            builder.DSLStoreSuppliersClass = Java.Lang.Class.ForName(Java.Lang.Class.ClassNameOf<BuiltInDslStoreSuppliers.InMemoryDslStoreSuppliers>(), true, Java.Lang.Class.SystemClassLoader);

            _builder ??= new StreamsBuilder(_streamsConfig);
            _topicName = topicToUse;
            _useEnumeratorWithPrefetch = true;

            Java.Util.Properties props = builder;

            if (props.ContainsKey(Org.Apache.Kafka.Clients.Consumer.ConsumerConfig.AUTO_OFFSET_RESET_CONFIG))
            {
                props.Remove(Org.Apache.Kafka.Clients.Consumer.ConsumerConfig.AUTO_OFFSET_RESET_CONFIG);
            }
            props.Put(Org.Apache.Kafka.Clients.Consumer.ConsumerConfig.AUTO_OFFSET_RESET_CONFIG, "earliest");

            string storageId = $"Table_{_topicName}"; ;
            _storageId =  System.Diagnostics.Process.GetCurrentProcess().ProcessName + "-" + storageId;



            lock (_managedEntities)
            {
                if (!_managedEntities.ContainsKey(_entityType))
                {
                    var storeSupplier = Org.Apache.Kafka.Streams.State.Stores.InMemoryKeyValueStore(_storageId);
                    var materialized = Materialized<TKey, TValue, TJVMKey, TJVMValue>.As(storeSupplier);
                    var globalTable = _builder.GlobalTable(_topicName, materialized);
                    _managedEntities.Add(_entityType, _entityType);
                    _storagesForEntities.Add(_entityType, new StreamsAssociatedData(storeSupplier, materialized, globalTable));

                    _topology = _builder.Build();
                    _streams = new(_topology, _streamsConfig);
                    StartTopology(_streams);
                }
            }


            try
            {
                string baSerdesName = Java.Lang.Class.ClassNameOf<Org.Apache.Kafka.Common.Serialization.Serdes.ByteArraySerde>();
                var keyValueSerde = Java.Lang.Class.ForName(baSerdesName, true, Java.Lang.Class.SystemClassLoader);
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
