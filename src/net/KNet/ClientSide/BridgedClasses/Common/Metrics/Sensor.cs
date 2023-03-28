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

namespace Org.Apache.Kafka.Common.Metrics
{
    public class Sensor : MASES.JCOBridge.C2JBridge.JVMBridgeBase<Sensor>
    {
        public override string ClassName => "org.apache.kafka.common.metrics.Sensor";

        public enum RecordingLevel
        {
            INFO = 0,
            DEBUG = 1,
            TRACE = 2
        }

        public string Name => IExecute<string>("name");

        List<Sensor> Parents => IExecute<List<Sensor>>("parents");

        public bool ShouldRecord => IExecute<bool>("shouldRecord");

        public bool HasMetrics => IExecute<bool>("hasMetrics");

        public bool HasExpired => IExecute<bool>("hasExpired");

        public void Record()
        {
            IExecute("record");
        }

        public void Record(double value)
        {
            IExecute("record", value);
        }

        public void record(double value, long timeMs)
        {
            IExecute("record", value, timeMs);
        }

        public void Record(double value, long timeMs, bool checkQuotas)
        {
            IExecute("record", value, timeMs, checkQuotas);
        }

        public void CheckQuotas()
        {
            IExecute("checkQuotas");
        }

        public void CheckQuotas(long timeMs)
        {
            IExecute("checkQuotas", timeMs);
        }

        public bool Add(CompoundStat stat)
        {
            return IExecute<bool>("add", stat);
        }

        public bool Add(CompoundStat stat, MetricConfig config)
        {
            return IExecute<bool>("add", stat, config);
        }

        public bool Add(MetricName metricName, MeasurableStat stat)
        {
            return IExecute<bool>("add", metricName, stat);
        }

        public bool Add(MetricName metricName, MeasurableStat stat, MetricConfig config)
        {
            return IExecute<bool>("add", metricName, stat, config);
        }
    }
}
