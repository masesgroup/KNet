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

using Java.Util;
using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Connect.Storage
{
    public class OffsetStorageReader : JVMBridgeBase<OffsetStorageReader>
    {
        public override bool IsInterface => true;

        public override string ClassName => "org.apache.kafka.connect.storage.OffsetStorageReader";

        public Map<string, object> Offset<T>(Map<string, T> partition) => IExecute<Map<string, object>>("offset", partition);

        public Map<Map<string, T>, Map<string, object>> Offset<T>(Collection<Map<string, T>> partitions) => IExecute<Map<Map<string, T>, Map<string, object>>>("offset", partitions);
    }
}
