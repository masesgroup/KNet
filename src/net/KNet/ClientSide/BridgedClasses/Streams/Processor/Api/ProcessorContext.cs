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
using MASES.KNet.Clients.Producer;
using MASES.KNet.Common.Serialization;
using Java.Io;
using Java.Time;
using Java.Util;

namespace MASES.KNet.Streams.Processor.Api
{
    public interface IProcessorContext<KForward, VForward> : IJVMBridgeBase
    {
        string ApplicationId { get; }

        TaskId TaskId { get; }

        Optional<RecordMetadata> RecordMetadata { get; }

        Serde KeySerde { get; }

        Serde ValueSerde { get; }

        File StateDir { get; }

        StreamsMetrics Metrics { get; }

        StateStore SetStateStore(string name);

        Cancellable Schedule(Duration interval,
                             PunctuationType type,
                             Punctuator callback);

        void Forward<K, V>(Record<K, V> record)
            where K : KForward
            where V : VForward;

        void Forward<K, V>(Record<K, V> record, string childName)
            where K : KForward
            where V : VForward;

        void Commit();

        Map<string, object> AppConfigs { get; }

        Map<string, object> AppConfigsWithPrefix(string prefix);
    }

    public class ProcessorContext<KForward, VForward> : JVMBridgeBase<ProcessorContext<KForward, VForward>, IProcessorContext<KForward, VForward>>, IProcessorContext<KForward, VForward>
    {
        public override string ClassName => "org.apache.kafka.streams.processor.api.ProcessorContext";

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

        public void Forward<K, V>(Record<K, V> record)
            where K : KForward
            where V : VForward
        {
            IExecute("forward", record);
        }

        public void Forward<K, V>(Record<K, V> record, string childName)
            where K : KForward
            where V : VForward
        {
            IExecute("forward", record, childName);
        }

        public Cancellable Schedule(Duration interval, PunctuationType type, Punctuator callback)
        {
            return IExecute<Cancellable>("schedule", interval, type, callback);
        }

        public StateStore SetStateStore(string name)
        {
            return IExecute<StateStore>("setStateStore", name);
        }
    }
}
