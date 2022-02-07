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
using MASES.KafkaBridge.Streams.State;

namespace MASES.KafkaBridge.Streams
{
    public class StoreQueryParameters<T> : JVMBridgeBase<StoreQueryParameters<T>>
    {
        public override string ClassName => "org.apache.kafka.streams.StoreQueryParameters";

        public StoreQueryParameters()
        {
        }

        public static StoreQueryParameters<TIn> FromNameAndType<TIn>(string storeName, QueryableStoreType<TIn> queryableStoreType)
        {
            return SExecute<StoreQueryParameters<TIn>>("fromNameAndType", storeName, queryableStoreType);
        }

        public StoreQueryParameters<T> WithPartition(int partition)
        {
            return IExecute<StoreQueryParameters<T>>("withPartition", partition);
        }

        public StoreQueryParameters<T> EnableStaleStores => IExecute<StoreQueryParameters<T>>("enableStaleStores");

        public string StoreName => IExecute<string>("storeName");

        public QueryableStoreType<T> QueryableStoreType => IExecute<QueryableStoreType<T>>("queryableStoreType");

        public int Partition => IExecute<int>("partition");

        public bool StaleStoresEnabled => IExecute<bool>("staleStoresEnabled");

    }
}
