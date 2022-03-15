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
using MASES.JCOBridge.C2JBridge.JVMInterop;
using MASES.KafkaBridge.Common;
using MASES.KafkaBridge.Common.Serialization;
using MASES.KafkaBridge.Common.Utils;
using Java.Time;
using Java.Util;
using MASES.KafkaBridge.Streams.Errors;
using MASES.KafkaBridge.Streams.Processor;
using System;

namespace MASES.KafkaBridge.Streams
{
    public enum StateType
    {
        CREATED,            // 0
        REBALANCING,        // 1
        RUNNING,            // 2
        PENDING_SHUTDOWN,   // 3
        NOT_RUNNING,        // 4
        PENDING_ERROR,      // 5
        ERROR,              // 6
    }

    public interface IStateListener : IJVMBridgeBase
    {
        void OnChange(StateType newState, StateType oldState);
    }

    /// <summary>
    /// Listener for Kafka StateListener. Extends <see cref="JVMBridgeListener"/>, implements <see cref="IStateListener"/>
    /// </summary>
    /// <remarks>Remember to Dispose the object otherwise there is a resource leak, the object contains a reference to the the corresponding JVM object</remarks>
    public class StateListener : JVMBridgeListener, IStateListener
    {
        /// <inheritdoc cref="JVMBridgeListener.ClassName"/>
        public sealed override string ClassName => "org.mases.kafkabridge.streams.StateListenerImpl";

        readonly Action<StateType, StateType> executionFunction = null;
        /// <summary>
        /// The <see cref="Action{StateType, StateType}"/> to be executed
        /// </summary>
        public virtual Action<StateType, StateType> OnOnChange { get { return executionFunction; } }
        /// <summary>
        /// Initialize a new instance of <see cref="StateListener"/>
        /// </summary>
        /// <param name="func">The <see cref="Action{StateType, StateType}"/> to be executed</param>
        /// <param name="attachEventHandler">Set to false to disable attach of <see cref="EventHandler"/> and set an own one</param>
        public StateListener(Action<StateType, StateType> func = null, bool attachEventHandler = true)
        {
            if (func != null) executionFunction = func;
            else executionFunction = OnChange;

            if (attachEventHandler)
            {
                AddEventHandler("onChange", new EventHandler<CLRListenerEventArgs<CLREventData<StateType>>>(EventHandler));
            }
        }

        void EventHandler(object sender, CLRListenerEventArgs<CLREventData<StateType>> data)
        {
            OnOnChange(data.EventData.TypedEventData, data.EventData.To<StateType>(0));
        }

        public virtual void OnChange(StateType newState, StateType oldState) { }
    }

    public class KafkaStreams : JVMBridgeBase<KafkaStreams>
    {
        public override bool IsCloseable => true;

        public override string ClassName => "org.apache.kafka.streams.KafkaStreams";

        [System.Obsolete("This is not public in Apache Kafka API")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public KafkaStreams() { }

        public KafkaStreams(Topology topology, Properties props) : base(topology, props) { }

        public KafkaStreams(Topology topology, Properties props, KafkaClientSupplier clientSupplier) : base(topology, props, clientSupplier) { }

        public KafkaStreams(Topology topology, Properties props, Time time) : base(topology, props, time) { }

        public KafkaStreams(Topology topology, Properties props, KafkaClientSupplier clientSupplier, Time time) : base(topology, props, clientSupplier, time) { }

        public KafkaStreams(Topology topology, StreamsConfig config) : base(topology, config) { }

        public KafkaStreams(Topology topology, StreamsConfig config, KafkaClientSupplier clientSupplier) : base(topology, config, clientSupplier) { }

        public KafkaStreams(Topology topology, StreamsConfig config, Time time) : base(topology, config, time) { }

        public StateType State => (StateType)Enum.Parse(typeof(StateType), IExecute<IJavaObject>("state").Invoke<string>("name"));

        public void SetStateListener(StateListener listener)
        {
            IExecute("setStateListener", listener);
        }

        public void SetUncaughtExceptionHandler(StreamsUncaughtExceptionHandler streamsUncaughtExceptionHandler)
        {
            IExecute("setUncaughtExceptionHandler", streamsUncaughtExceptionHandler);
        }

        public void SetGlobalStateRestoreListener(StateRestoreListener globalStateRestoreListener)
        {
            IExecute("setGlobalStateRestoreListener", globalStateRestoreListener);
        }

        public Map<MetricName, Metric> Metrics => IExecute<Map<MetricName, Metric>>("metrics");

        public Optional<string> AddStreamThread() { return IExecute<Optional<string>>("addStreamThread"); }

        public Optional<string> RemoveStreamThread() { return IExecute<Optional<string>>("removeStreamThread"); }

        public Optional<string> RemoveStreamThread(Duration timeout) { return IExecute<Optional<string>>("removeStreamThread", timeout); }

        public void Start() { IExecute("start"); }

        public void Close()
        {
            IExecute("close");
        }

        public bool Close(Duration timeout)
        {
            return IExecute<bool>("close", timeout);
        }

        public void CleanUp() { IExecute("cleanUp"); }

        public Collection<StreamsMetadata> MetadataForAllStreamsClients => IExecute<Collection<StreamsMetadata>>("metadataForAllStreamsClients");

        public Collection<StreamsMetadata> StreamsMetadataForStore(string storeName)
        {
            return IExecute<Collection<StreamsMetadata>>("streamsMetadataForStore", storeName);
        }

        public KeyQueryMetadata QueryMetadataForKey<K>(string storeName, K key, Serializer<K> keySerializer)
        {
            return IExecute<KeyQueryMetadata>("queryMetadataForKey", storeName, key, keySerializer);
        }

        public KeyQueryMetadata QueryMetadataForKey<K, TResult>(string storeName, K key, StreamPartitioner<K, TResult> partitioner)
        {
            return IExecute<KeyQueryMetadata>("queryMetadataForKey", storeName, key, partitioner);
        }

        public T Store<T>(StoreQueryParameters<T> storeQueryParameters)
        {
            return IExecute<T>("store", storeQueryParameters);
        }

        public Set<TaskMetadata> MetadataForLocalThreads => IExecute<Set<TaskMetadata>>("metadataForLocalThreads");

        public Map<string, Map<int, LagInfo>> AllLocalStorePartitionLags => IExecute<Map<string, Map<int, LagInfo>>>("allLocalStorePartitionLags");
    }
}

