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
using MASES.KNet.Common.Utils;

namespace MASES.KNet.Common.Metrics
{
    public class Metrics : JCOBridge.C2JBridge.JVMBridgeBase<Metrics>
    {
        public override bool IsCloseable => true;
        public override string ClassName => "org.apache.kafka.common.metrics.Metrics";

        public Metrics()
        {
        }

        public Metrics(Time time)
            : base(time)
        {
        }

        public Metrics(MetricConfig defaultConfig, Time time)
            : base(defaultConfig, time)
        {
        }

        public Metrics(MetricConfig defaultConfig)
            : base(defaultConfig)
        {
        }
        public Metrics(MetricConfig defaultConfig, List<MetricsReporter> reporters, Time time)
            : base(defaultConfig, reporters, time)
        {
        }

        public Metrics(MetricConfig defaultConfig, List<MetricsReporter> reporters, Time time, MetricsContext metricsContext)
            : base(defaultConfig, reporters, time, metricsContext)
        {
        }

        public Metrics(MetricConfig defaultConfig, List<MetricsReporter> reporters, Time time, bool enableExpiration)
            : base(defaultConfig, reporters, time, enableExpiration)
        {
        }

        public Metrics(MetricConfig defaultConfig, List<MetricsReporter> reporters, Time time, bool enableExpiration, MetricsContext metricsContext)
            : base(defaultConfig, reporters, time, enableExpiration, metricsContext)
        {
        }

        public static string ToHtmlTable(string domain, Java.Lang.Iterable<MetricNameTemplate> allMetrics)
        {
            return SExecute<string>(domain, allMetrics);
        }

        public MetricName MetricName(string name, string group, string description, Map<string, string> tags)
        {
            return IExecute<MetricName>("metricName", name, group, description, tags);
        }

        public MetricName MetricName(string name, string group, string description)
        {
            return IExecute<MetricName>("metricName", name, group, description);
        }

        public MetricName MetricName(string name, string group)
        {
            return IExecute<MetricName>("metricName", name, group);
        }

        public MetricName MetricName(string name, string group, string description, params string[] keyValue)
        {
            return IExecute<MetricName>("metricName", name, group, description, keyValue);
        }

        public MetricName MetricName(string name, string group, Map<string, string> tags)
        {
            return IExecute<MetricName>("metricName", name, group, tags);
        }

        public MetricConfig Config => IExecute<MetricConfig>("config");

        public Sensor GetSensor(string name) => IExecute<Sensor>("getSensor", name);

        public Sensor Sensor(string name) => IExecute<Sensor>("sensor", name);

        public Sensor Sensor(string name, Sensor.RecordingLevel recordingLevel) => IExecute<Sensor>("sensor", name, recordingLevel);

        public Sensor Sensor(string name, params Sensor[] parents) => IExecute<Sensor>("sensor", name, parents);

        public Sensor Sensor(string name, Sensor.RecordingLevel recordingLevel, params Sensor[] parents) => IExecute<Sensor>("sensor", name, recordingLevel, parents);

        public Sensor Sensor(string name, MetricConfig config, params Sensor[] parents) => IExecute<Sensor>("sensor", name, config, parents);

        public Sensor Sensor(string name, MetricConfig config, Sensor.RecordingLevel recordingLevel, params Sensor[] parents) => IExecute<Sensor>("sensor", name, config, recordingLevel, parents);

        public Sensor Sensor(string name, MetricConfig config, long inactiveSensorExpirationTimeSeconds, Sensor.RecordingLevel recordingLevel, params Sensor[] parents)
        {
            return IExecute<Sensor>("sensor", name, config, inactiveSensorExpirationTimeSeconds, recordingLevel, parents);
        }

        public Sensor Sensor(string name, MetricConfig config, long inactiveSensorExpirationTimeSeconds, params Sensor[] parents)
        {
            return IExecute<Sensor>("sensor", name, config, inactiveSensorExpirationTimeSeconds, parents);
        }

        public void RemoveSensor(string name)
        {
            IExecute("removeSensor", name);
        }

        public void AddMetric(MetricName metricName, Measurable measurable)
        {
            IExecute("addMetric", metricName, measurable);
        }

        public void AddMetric(MetricName metricName, MetricConfig config, Measurable measurable)
        {
            IExecute("addMetric", metricName, config, measurable);
        }

        public void AddMetric<T>(MetricName metricName, MetricConfig config, MetricValueProvider<T> metricValueProvider)
        {
            IExecute("addMetric", metricName, config, metricValueProvider);
        }

        public void AddMetric<T>(MetricName metricName, MetricValueProvider<T> metricValueProvider)
        {
            IExecute("addMetric", metricName, metricValueProvider);
        }

        public KafkaMetric AddMetricIfAbsent<T>(MetricName metricName, MetricConfig config, MetricValueProvider<T> metricValueProvider)
        {
            return IExecute<KafkaMetric>("addMetricIfAbsent", metricName, config, metricValueProvider);
        }

        public KafkaMetric RemoveMetric(MetricName metricName) => IExecute<KafkaMetric>("removeMetric", metricName);

        public void AddReporter(MetricsReporter reporter)
        {
            IExecute("addReporter", reporter);
        }

        public void RemoveReporter(MetricsReporter reporter)
        {
            IExecute("removeReporter", reporter);
        }

        public List<MetricsReporter> Reporters => IExecute<List<MetricsReporter>>("reporters");
        
        public Map<MetricName, KafkaMetric> AllMetrics => IExecute<Map<MetricName, KafkaMetric>>("metrics");

        public KafkaMetric Metric(MetricName metricName) => IExecute<KafkaMetric>("metric", metricName);

        public MetricName MetricInstance(MetricNameTemplate template, params string[] keyValue) => IExecute<MetricName>("metricInstance", template, keyValue);

        public MetricName MetricInstance(MetricNameTemplate template, Map<string, string> tags) => IExecute<MetricName>("metricInstance", template, tags);
    }
}
