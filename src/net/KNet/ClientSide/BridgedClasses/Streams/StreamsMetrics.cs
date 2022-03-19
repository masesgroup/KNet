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

using MASES.JCOBridge.C2JBridge;
using MASES.KNet.Common;
using MASES.KNet.Common.Metrics;
using Java.Util;

namespace MASES.KNet.Streams
{
    public interface IStreamsMetrics : IJVMBridgeBase
    {
        Map<MetricName, Metric> Metrics { get; }

        Sensor AddLatencyRateTotalSensor(string scopeName,
                                         string entityName,
                                         string operationName,
                                         Sensor.RecordingLevel recordingLevel,
                                         params string[] tags);

        Sensor AddRateTotalSensor(string scopeName,
                                  string entityName,
                                  string operationName,
                                  Sensor.RecordingLevel recordingLevel,
                                  params string[] tags);

        Sensor AddSensor(string name,
                         Sensor.RecordingLevel recordingLevel);

        Sensor AddSensor(string name,
                         Sensor.RecordingLevel recordingLevel,
                         params Sensor[] parents);

        void RemoveSensor(Sensor sensor);
    }

    public class StreamsMetrics : JVMBridgeBase<StreamsMetrics, IStreamsMetrics>, IStreamsMetrics
    {
        public override string ClassName => "org.apache.kafka.streams.StreamsMetrics";

        public Map<MetricName, Metric> Metrics => IExecute<Map<MetricName, Metric>>("metrics");

        public Sensor AddLatencyRateTotalSensor(string scopeName, string entityName, string operationName, Sensor.RecordingLevel recordingLevel, params string[] tags)
        {
            return IExecute<Sensor>("addLatencyRateTotalSensor", scopeName, entityName, operationName, recordingLevel, tags);
        }

        public Sensor AddRateTotalSensor(string scopeName, string entityName, string operationName, Sensor.RecordingLevel recordingLevel, params string[] tags)
        {
            return IExecute<Sensor>("addRateTotalSensor", scopeName, entityName, operationName, recordingLevel, tags);
        }

        public Sensor AddSensor(string name, Sensor.RecordingLevel recordingLevel)
        {
            return IExecute<Sensor>("addSensor", name, recordingLevel);
        }

        public Sensor AddSensor(string name, Sensor.RecordingLevel recordingLevel, params Sensor[] parents)
        {
            return IExecute<Sensor>("addSensor", name, recordingLevel, ((object[])parents).ToNative());
        }

        public void RemoveSensor(Sensor sensor)
        {
            IExecute("removeSensor", sensor);
        }
    }
}
