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
using Java.Util.Concurrent;

namespace Org.Apache.Kafka.Common.Metrics
{
    public class MetricConfig : MASES.JCOBridge.C2JBridge.JVMBridgeBase<MetricConfig>
    {
        public override string ClassName => "org.apache.kafka.common.metrics.MetricConfig";

        public MetricConfig Quota()
        {
            return IExecute<MetricConfig>("quota");
        }

        public MetricConfig Quota(Quota quota)
        {
            return IExecute<MetricConfig>("quota", quota);
        }

        public long EventWindow()
        {
            return IExecute<long>("eventWindow");
        }

        public MetricConfig EventWindow(long window)
        {
            return IExecute<MetricConfig>("eventWindow", window);
        }

        public long TimeWindowMs()
        {
            return IExecute<long>("timeWindowMs");
        }

        public MetricConfig TimeWindow(long window, TimeUnit unit)
        {
            return IExecute<MetricConfig>("timeWindow", window, unit);
        }

        public Map<string, string> Tags()
        {
            return IExecute<Map<string, string>>("tags");
        }

        public MetricConfig Tags(Map<string, string> tags)
        {
            return IExecute<MetricConfig>("tags", tags);
        }

        public int Samples()
        {
            return IExecute<int>("samples");
        }

        public MetricConfig Samples(int samples)
        {
            return IExecute<MetricConfig>("samples", samples);
        }

        public Sensor.RecordingLevel RecordLevel()
        {
            return IExecute<Sensor.RecordingLevel>("recordLevel");
        }

        public MetricConfig RecordLevel(Sensor.RecordingLevel recordingLevel)
        {
            return IExecute<MetricConfig>("recordLevel", recordingLevel);
        }
    }
}
