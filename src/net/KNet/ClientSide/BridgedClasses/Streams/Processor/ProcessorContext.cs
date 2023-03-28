/*
*  Copyright 2023 MASES s.r.l.
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
using Org.Apache.Kafka.Common.Header;
using Org.Apache.Kafka.Common.Serialization;
using Java.Io;
using Java.Time;
using Java.Util;

namespace Org.Apache.Kafka.Streams.Processor
{
    public interface IProcessorContext : IJVMBridgeBase
    {
        string ApplicationId { get; }

        TaskId TaskId { get; }

        Serde KeySerde { get; }

        Serde ValueSerde { get; }

        File StateDir { get; }

        StreamsMetrics Metrics { get; }

        void Register(StateStore store,
                      StateRestoreCallback stateRestoreCallback);

        StateStore GetStateStore(string name);

        Cancellable Schedule(Duration interval,
                             PunctuationType type,
                             Punctuator callback);

        void Forward<K, V>(K key, V value);

        void Forward<K, V>(K key, V value, To to);

        void Commit();

        string Topic { get; }

        int Partition { get; }

        long Offset { get; }

        Headers Headers { get; }

        long Timestamp { get; }

        Map<string, object> AppConfigs { get; }

        Map<string, object> AppConfigsWithPrefix(string prefix);

        long CurrentSystemTimeMs { get; }

        long CurrentStreamTimeMs { get; }
    }

    public class ProcessorContext : JVMBridgeBase<ProcessorContext, IProcessorContext>, IProcessorContext
    {
        public override string ClassName => "org.apache.kafka.streams.processor.ProcessorContext";

        public string ApplicationId => IExecute<string>("applicationId");

        public TaskId TaskId => IExecute<TaskId>("taskId");

        public Serde KeySerde => IExecute<Serde>("keySerde");

        public Serde ValueSerde => IExecute<Serde>("valueSerde");

        public File StateDir => IExecute<File>("stateDir");

        public StreamsMetrics Metrics => IExecute<StreamsMetrics>("metrics");

        public string Topic => IExecute<string>("topic");

        public int Partition => IExecute<int>("partition");

        public long Offset => IExecute<long>("offset");

        public Headers Headers => IExecute<Headers>("headers");

        public long Timestamp => IExecute<long>("timestamp");

        public Map<string, object> AppConfigs => IExecute<Map<string, object>>("appConfigs");

        public long CurrentSystemTimeMs => IExecute<long>("currentSystemTimeMs");

        public long CurrentStreamTimeMs => IExecute<long>("currentStreamTimeMs");

        public Map<string, object> AppConfigsWithPrefix(string prefix)
        {
            return IExecute<Map<string, object>>("appConfigsWithPrefix", prefix);
        }

        public void Commit()
        {
            IExecute("commit");
        }

        public void Forward<K, V>(K key, V value)
        {
            IExecute("forward", key, value);
        }

        public void Forward<K, V>(K key, V value, To to)
        {
            IExecute("forward", key, value, to);
        }

        public StateStore GetStateStore(string name)
        {
            return IExecute<StateStore>("getStateStore", name);
        }

        public void Register(StateStore store, StateRestoreCallback stateRestoreCallback)
        {
            IExecute("register", store, stateRestoreCallback);
        }

        public Cancellable Schedule(Duration interval, PunctuationType type, Punctuator callback)
        {
            return IExecute<Cancellable>("schedule", interval, type, callback);
        }
    }
}
