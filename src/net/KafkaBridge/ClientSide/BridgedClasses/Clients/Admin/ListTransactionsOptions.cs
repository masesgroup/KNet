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

using MASES.KafkaBridge.Java.Util;

namespace MASES.KafkaBridge.Clients.Admin
{
    public class ListTransactionsOptions : AbstractOptions<ListTransactionsOptions>
    {
        public override string ClassName => "org.apache.kafka.clients.admin.ListTransactionsOptions";

        public ListTransactionsOptions FilterStates(Collection<TransactionState> states)
        {
            return IExecute<ListTransactionsOptions>("filterStates", states);
        }

        public ListTransactionsOptions FilterProducerIds(Collection<long> producerIdFilters)
        {
            return IExecute<ListTransactionsOptions>("filterProducerIds", producerIdFilters);
        }

        public Set<TransactionState> FilteredStates => IExecute<Set<TransactionState>>("filteredStates");

        public Set<long> FilteredProducerIds => IExecute<Set<long>>("filteredProducerIds");
    }
}
