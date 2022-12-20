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

using Java.Util.Function;
using Java.Util;
using MASES.KNet.Streams.State;

namespace MASES.KNet.Streams.Processor.Api
{
    public interface IFixedKeyProcessorSupplier<KIn, VIn, VOut> : IConnectedStoreProvider, ISupplier<FixedKeyProcessorSupplier<KIn, VIn, VOut>>
    {
    }

    public class FixedKeyProcessorSupplier<KIn, VIn, VOut> : Supplier<FixedKeyProcessorSupplier<KIn, VIn, VOut>>, IFixedKeyProcessorSupplier<KIn, VIn, VOut>
    {
        public Set<StoreBuilder> Stores => throw new System.NotImplementedException();
    }
}
