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

namespace Org.Apache.Kafka.Common.Metrics
{
    public interface IMeasurable : IMetricValueProvider<double>
    {
        double Measure(MetricConfig config, long now);
    }

    public class Measurable : MetricValueProvider<double>, IMeasurable
    {
        public double Measure(MetricConfig config, long now)
        {
            return IExecute<double>("measure", config, now);
        }
    }
}
