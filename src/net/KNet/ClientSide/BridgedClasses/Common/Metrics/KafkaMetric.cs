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

namespace MASES.KNet.Common.Metrics
{
    public class KafkaMetric : JCOBridge.C2JBridge.JVMBridgeBase<KafkaMetric>
    {
        public override string ClassName => "org.apache.kafka.common.metrics.KafkaMetric";

        public MetricConfig Config
        {
            get { return IExecute<MetricConfig>("config"); }
            set { IExecute("config", value); }
        }

        public MetricName MetricName => IExecute<MetricName>("metricName");

        public object MetricValue => IExecute("metricValue");

        public Measurable Measurable => IExecute<Measurable>("measurable");
    }
}
