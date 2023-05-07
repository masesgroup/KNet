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

using MASES.KNet.Common.Utils;

namespace MASES.KNet.Streams.State
{
    public interface IWindowBytesStoreSupplier : IStoreSupplier<WindowStore<Bytes, byte[]>>
    {
        long SegmentIntervalMs { get; }

        long WindowSize { get; }

        bool RetainDuplicates { get; }

        long RetentionPeriod { get; }
    }

    public class WindowBytesStoreSupplier : StoreSupplier<WindowStore<Bytes, byte[]>>, IWindowBytesStoreSupplier
    {
        public override string BridgeClassName => "org.apache.kafka.streams.state.WindowBytesStoreSupplier";

        public new WindowStore<Bytes, byte[]> Get => IExecute<WindowStore<Bytes, byte[]>>("get");

        public long SegmentIntervalMs => IExecute<long>("segmentIntervalMs");

        public long WindowSize => IExecute<long>("windowSize");

        public bool RetainDuplicates => IExecute<bool>("retainDuplicates");

        public long RetentionPeriod => IExecute<long>("retentionPeriod");
    }
}
