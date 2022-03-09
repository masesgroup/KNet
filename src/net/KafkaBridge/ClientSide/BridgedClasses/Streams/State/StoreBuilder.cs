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
using Java.Util;
using MASES.KafkaBridge.Streams.Processor;

namespace MASES.KafkaBridge.Streams.State
{
    public interface IStoreBuilder : IJVMBridgeBase
    {
        Map<string, string> LogConfig { get; }

        bool LoggingEnabled { get; }

        string Name { get; }
    }

    public class StoreBuilder : JVMBridgeBase<StoreBuilder, IStoreBuilder>, IStoreBuilder
    {
        public override string ClassName => "org.apache.kafka.streams.state.StoreBuilder";

        public Map<string, string> LogConfig => IExecute<Map<string, string>>("logConfig");

        public bool LoggingEnabled => IExecute<bool>("loggingEnabled");

        public string Name => IExecute<string>("name");
    }

    public interface IStoreBuilder<T> : IStoreBuilder
        where T : StateStore
    {
        StoreBuilder<T> WithCachingEnabled();

        StoreBuilder<T> WithCachingDisabled();

        StoreBuilder<T> WithLoggingEnabled(Map<string, string> config);

        StoreBuilder<T> WithLoggingDisabled();

        T Build();
    }

    public class StoreBuilder<T> : StoreBuilder, IStoreBuilder<T>
        where T : StateStore
    {
        public override string ClassName => "org.apache.kafka.streams.state.StoreBuilder";

        public bool Persistent => IExecute<bool>("persistent");

        public bool IsOpen => IExecute<bool>("isOpen");

        public T Build()
        {
            return IExecute<T>("build");
        }

        public StoreBuilder<T> WithCachingDisabled()
        {
            return IExecute<StoreBuilder<T>>("withCachingDisabled");
        }

        public StoreBuilder<T> WithCachingEnabled()
        {
            return IExecute<StoreBuilder<T>>("withCachingEnabled");
        }

        public StoreBuilder<T> WithLoggingDisabled()
        {
            return IExecute<StoreBuilder<T>>("withLoggingDisabled");
        }

        public StoreBuilder<T> WithLoggingEnabled(Map<string, string> config)
        {
            return IExecute<StoreBuilder<T>>("withLoggingEnabled", config);
        }
    }
}
