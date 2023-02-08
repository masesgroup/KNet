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

namespace MASES.KNet.Common
{
    public class MetricNameTemplate : JCOBridge.C2JBridge.JVMBridgeBase<MetricNameTemplate>
    {
        public override string ClassName => "org.apache.kafka.common.MetricNameTemplate";

        [System.Obsolete("This is not public in Apache Kafka API")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public MetricNameTemplate() { }

        public MetricNameTemplate(string name, string group, string description, Set<string> tagsNames)
            : base(name, group, description, tagsNames)
        {
        }

        public MetricNameTemplate(string name, string group, string description, params string[] tagsNames)
            : base(name, group, description, tagsNames)
        {
        }

        public string Name => IExecute<string>("name");

        public string Group => IExecute<string>("group");

        public string Description => IExecute<string>("description");

        public Set<string> Tags => IExecute<Set<string>>("tags");
    }
}
