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
using MASES.KNet.Streams.Processor;

namespace MASES.KNet.Streams.State
{
    public interface IQueryableStoreType<T> : IJVMBridgeBase
    {
        bool Accepts(StateStore stateStore);

        // T Create(StateStoreProvider storeProvider, string storeName); needs internal interface StateStoreProvider
    }

    public class QueryableStoreType<T> : JVMBridgeBase<QueryableStoreType<T>, IQueryableStoreType<T>>, IQueryableStoreType<T>
    {
        public override string BridgeClassName => "org.apache.kafka.streams.state.QueryableStoreType";

        public bool Accepts(StateStore stateStore)
        {
            return IExecute<bool>("accepts", stateStore);
        }

        /* needs internal interface StateStoreProvider
        public T Create(StateStoreProvider storeProvider, string storeName)
        {
            return IExecute<T>("create", storeProvider, storeName);
        }
        */
    }
}
