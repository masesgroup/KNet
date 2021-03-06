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

namespace MASES.KNet.Streams.State
{
    public class ValueAndTimestamp<V> : JCOBridge.C2JBridge.JVMBridgeBase<ValueAndTimestamp<V>>
    {
        public override string ClassName => "org.apache.kafka.streams.state.ValueAndTimestamp";

        public static ValueAndTimestamp<V> Make(V value, long timestamp)
        {
            return SExecute<ValueAndTimestamp<V>>("make", value, timestamp);
        }

        public static V GetValueOrNull(ValueAndTimestamp<V> valueAndTimestamp)
        {
            return (V)SExecute("getValueOrNull", valueAndTimestamp);
        }

        public V Value => IExecute<V>("value");

        public long Timestamp => IExecute<long>("timestamp");
    }
}
