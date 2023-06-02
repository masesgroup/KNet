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

using MASES.JCOBridge.C2JBridge.JVMInterop;
using Org.Apache.Kafka.Common.Record;

namespace Org.Apache.Kafka.Clients.Consumer
{
    public partial class ConsumerRecord
    {
        public System.DateTime DateTime => System.DateTimeOffset.FromUnixTimeMilliseconds(Timestamp()).DateTime;

        // public TimestampType TimestampType => (TimestampType)System.Enum.Parse(typeof(TimestampType), IExecute<IJavaObject>("timestampType").Invoke<string>("name")); // (TimestampType)(int)IExecute<IJavaObject>("timestampType").GetField("id");
    }

    public partial class ConsumerRecord<K, V>
    {
        public System.DateTime DateTime => System.DateTimeOffset.FromUnixTimeMilliseconds(Timestamp()).DateTime;
    }
}
