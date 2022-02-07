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
using MASES.KafkaBridge.Java.Time;
using MASES.KafkaBridge.Java.Util;

namespace MASES.KafkaBridge.Streams.KStream
{
    public interface IStrictBufferConfig : IBufferConfig<StrictBufferConfig>
    {
    }

    public class StrictBufferConfig : BufferConfig<StrictBufferConfig>, IStrictBufferConfig
    {
    }

    public interface IEagerBufferConfig : IBufferConfig<EagerBufferConfig>
    {
    }

    public class EagerBufferConfig : BufferConfig<EagerBufferConfig>, IEagerBufferConfig
    {
    }

    public interface IBufferConfig : IJVMBridgeBase
    {
        StrictBufferConfig WithNoBound();

        StrictBufferConfig ShutDownWhenFull();

        EagerBufferConfig EmitEarlyWhenFull();
    }

    public interface IBufferConfig<BC> : IBufferConfig where BC : IBufferConfig<BC>
    {
        BC WithMaxRecords(long recordLimit);

        BC WithMaxBytes(long byteLimit);

        BC WithLoggingDisabled();

        BC WithLoggingEnabled(Map<string, string> config);
    }

    public class BufferConfig<BC> : JVMBridgeBase<BufferConfig<BC>>, IBufferConfig<BC>
        where BC : IBufferConfig<BC>
    {
        public override string ClassName => "org.apache.kafka.streams.kstream.Suppressed";

        public static EagerBufferConfig MaxRecords(long recordLimit)
        {
            return SExecute<EagerBufferConfig>("maxRecords", recordLimit);
        }

        public static EagerBufferConfig MaxBytes(long byteLimit)
        {
            return SExecute<EagerBufferConfig>("maxBytes", byteLimit);
        }

        public static StrictBufferConfig Unbounded()
        {
            return SExecute<StrictBufferConfig>("unbounded");
        }

        public EagerBufferConfig EmitEarlyWhenFull()
        {
            return IExecute<EagerBufferConfig>("emitEarlyWhenFull");
        }

        public StrictBufferConfig ShutDownWhenFull()
        {
            return IExecute<StrictBufferConfig>("shutDownWhenFull");
        }

        public BC WithLoggingDisabled()
        {
            return IExecute<BC>("withLoggingDisabled");
        }

        public BC WithLoggingEnabled(Map<string, string> config)
        {
            return IExecute<BC>("withLoggingEnabled", config);
        }

        public BC WithMaxBytes(long byteLimit)
        {
            return IExecute<BC>("withMaxBytes", byteLimit);
        }

        public BC WithMaxRecords(long recordLimit)
        {
            return IExecute<BC>("withMaxRecords", recordLimit);
        }

        public StrictBufferConfig WithNoBound()
        {
            return IExecute<StrictBufferConfig>("withNoBound");
        }
    }

    public interface ISuppressed<K> : INamedOperation<Suppressed<K>>
    {
    }

    public class Suppressed<K> : JVMBridgeBase<Suppressed<K>>, ISuppressed<K>
    {
        public override string ClassName => "org.apache.kafka.streams.kstream.Suppressed";

        public static Suppressed<Windowed> UntilWindowCloses(StrictBufferConfig bufferConfig)
        {
            return SExecute<Suppressed<Windowed>>("untilWindowCloses", bufferConfig);
        }

        public static Suppressed<K> UntilTimeLimit(Duration timeToWaitForMoreEvents, IBufferConfig bufferConfig)
        {
            return SExecute<Suppressed<K>>("untilTimeLimit", timeToWaitForMoreEvents, bufferConfig);
        }

        public Suppressed<K> WithName(string name)
        {
            return IExecute<Suppressed<K>>("withName", name);
        }
    }
}
