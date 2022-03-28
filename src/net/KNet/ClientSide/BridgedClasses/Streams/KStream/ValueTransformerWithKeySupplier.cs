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
using Java.Util.Function;
using MASES.JCOBridge.C2JBridge.JVMInterop;
using MASES.KNet.Streams.Processor;

namespace MASES.KNet.Streams.KStream
{
    public interface IValueTransformerWithKeySupplier<K, V, VR> : IConnectedStoreProvider, ISupplier<ValueTransformerWithKey<K, V, VR>>
    {
    }

    public class ValueTransformerWithKeySupplier<K, V, VR> : Supplier<ValueTransformerWithKey<K, V, VR>>, IValueTransformerWithKeySupplier<K, V, VR>
    {
        public Java.Util.Set<State.StoreBuilder> Stores => throw new System.NotImplementedException();
    }
}
