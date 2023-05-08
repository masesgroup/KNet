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
using Java.Util;

namespace MASES.KNet.Common.Metrics
{
    public class NamedMeasurable : JVMBridgeBase<NamedMeasurable>
    {
        public override string BridgeClassName => "org.apache.kafka.common.metrics.CompoundStat.NamedMeasurable";

        [System.Obsolete("This is not public in Apache Kafka API")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public NamedMeasurable()
        {
        }

        public NamedMeasurable(MetricName name, Measurable stat)
            : base(name, stat)
        {
        }

        public MetricName Name => IExecute<MetricName>("name");

        public Measurable Stat => IExecute<Measurable>("stat");
    }


    public interface ICompoundStat : IStat
    {
        List<NamedMeasurable> Stats { get; }
    }

    public class CompoundStat : Stat, ICompoundStat
    {
        public override string BridgeClassName => "org.apache.kafka.common.metrics.CompoundStat";

        public List<NamedMeasurable> Stats => IExecute<List<NamedMeasurable>>("stats");
    }
}
