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
using MASES.KNet.Common.Serialization;
using MASES.KNet.Streams.State;

namespace MASES.KNet.Streams.KStream
{
    public class StreamJoined<K, V1, V2> : JVMBridgeBase<StreamJoined<K, V1, V2>>, INamedOperation<StreamJoined<K, V1, V2>>
    {
        public override string ClassName => "org.apache.kafka.streams.kstream.StreamJoined";


        public static StreamJoined<K, V1, V2> With(WindowBytesStoreSupplier storeSupplier,
                                                   WindowBytesStoreSupplier otherStoreSupplier)
        {
            return SExecute<StreamJoined<K, V1, V2>>("with", storeSupplier, otherStoreSupplier);
        }

        public static StreamJoined<K, V1, V2> As(string storeName)
        {
            return SExecute<StreamJoined<K, V1, V2>>("as", storeName);
        }

        public static StreamJoined<K, V1, V2> With(Serde<K> keySerde,
                                                   Serde<V1> valueSerde,
                                                   Serde<V2> otherValueSerde)
        {
            return SExecute<StreamJoined<K, V1, V2>>("with", keySerde, valueSerde, otherValueSerde);
        }

        public StreamJoined<K, V1, V2> WithName(string name)
        {
            return IExecute<StreamJoined<K, V1, V2>>("withName", name);
        }

        public StreamJoined<K, V1, V2> WithStoreName(string storeName)
        {
            return IExecute<StreamJoined<K, V1, V2>>("withStoreName", storeName);
        }
    }
}
