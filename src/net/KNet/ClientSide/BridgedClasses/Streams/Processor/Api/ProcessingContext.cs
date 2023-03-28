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
using Org.Apache.Kafka.Clients.Producer;
using Org.Apache.Kafka.Common.Serialization;
using Java.Io;
using Java.Time;
using Java.Util;

namespace Org.Apache.Kafka.Streams.Processor.Api
{
    public interface IProcessingContext : IJVMBridgeBase
    {
        string ApplicationId { get; }

        TaskId TaskId { get; }

        Optional<RecordMetadata> RecordMetadata { get; }

        Serde KeySerde { get; }

        Serde ValueSerde { get; }

        File StateDir { get; }

        StreamsMetrics Metrics { get; }

        StateStore GetStateStore(string name);

        Cancellable Schedule(Duration interval,
                             PunctuationType type,
                             Punctuator callback);

        void Commit();

        Map<string, object> AppConfigs { get; }

        Map<string, object> AppConfigsWithPrefix(string prefix);

        long CurrentSystemTimeMs { get; }

        long CurrentStreamTimeMs { get; }
    }

    public class ProcessingContext : JVMBridgeBase<ProcessingContext, IProcessingContext>, IProcessingContext
    {
        public override bool IsInterface => true;

        public override string ClassName => "org.apache.kafka.streams.processor.api.ProcessingContext";

        public string ApplicationId => IExecute<string>("applicationId");

        public TaskId TaskId => IExecute<TaskId>("taskId");

        public Optional<RecordMetadata> RecordMetadata => IExecute<Optional<RecordMetadata>>("recordMetadata");

        public Serde KeySerde => IExecute<Serde>("keySerde");

        public Serde ValueSerde => IExecute<Serde>("valueSerde");

        public File StateDir => IExecute<File>("stateDir");

        public StreamsMetrics Metrics => IExecute<StreamsMetrics>("metrics");

        public Map<string, object> AppConfigs => IExecute<Map<string, object>>("appConfigs");

        public Map<string, object> AppConfigsWithPrefix(string prefix)
        {
            return IExecute<Map<string, object>>("appConfigsWithPrefix", prefix);
        }

        public void Commit()
        {
            IExecute("commit");
        }

        public Cancellable Schedule(Duration interval, PunctuationType type, Punctuator callback)
        {
            return IExecute<Cancellable>("schedule", interval, type, callback);
        }

        public StateStore GetStateStore(string name)
        {
            return IExecute<StateStore>("setStateStore", name);
        }

        public long CurrentSystemTimeMs => IExecute<long>("currentSystemTimeMs");

        public long CurrentStreamTimeMs => IExecute<long>("currentStreamTimeMs");
    }
}
