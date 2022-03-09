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

using Java.Util;

namespace MASES.KafkaBridge.Common
{
    public class MetricName : JCOBridge.C2JBridge.JVMBridgeBase<MetricName>
    {
        public override string ClassName => "org.apache.kafka.common.MetricName";

        [System.Obsolete("This is not public in Apache Kafka API")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public MetricName() { }

        public MetricName(string name, string group, string description, Map<string, string> tags)
            : base(name, group, description, tags)
        {
        }

        public string Name => IExecute<string>("name");

        public string Group => IExecute<string>("group");

        public Map<string, string> Tags => IExecute<Map<string, string>>("tags");

        public string Description => IExecute<string>("description");
    }
}
