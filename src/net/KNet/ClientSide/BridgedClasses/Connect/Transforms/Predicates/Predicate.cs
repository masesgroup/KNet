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

using Org.Apache.Kafka.Common;
using Org.Apache.Kafka.Common.Config;
using Org.Apache.Kafka.Connect.Connector;

namespace Org.Apache.Kafka.Connect.Transforms.Predicates
{
    public class Predicate<R> : Configurable where R : ConnectRecord<R>
    {
        public override bool IsBridgeInterface => true;

        public override string BridgeClassName => "org.apache.kafka.connect.transforms.predicates.Predicate";

        public ConfigDef Config => IExecute<ConfigDef>("config");

        public bool Test(R record) => IExecute<bool>("test", record);

        public void Close() => IExecute("close");
    }
}
