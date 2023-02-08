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
using MASES.KNet.Common.Serialization;
using Java.Lang;

namespace MASES.KNet.Streams.KStream
{
    public class WindowedSerdes : JVMBridgeBase<WindowedSerdes>
    {
        public override string ClassName => "org.apache.kafka.streams.kstream.WindowedSerdes";


        public static Serde<Windowed<T>> TimeWindowedSerdeFrom<T>(Class<T> type, long windowSize) where T : IJVMBridgeBase, new()
        {
            return SExecute<Serde<Windowed<T>>>("timeWindowedSerdeFrom", type, windowSize);
        }

        public static Serde<Windowed<T>> SessionWindowedSerdeFrom<T>(Class<T> type) where T : IJVMBridgeBase, new()
        {
            return SExecute<Serde<Windowed<T>>>("sessionWindowedSerdeFrom", type);
        }
    }
}
