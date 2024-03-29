/*
*  Copyright 2024 MASES s.r.l.
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

/*
*  This file is generated by MASES.JNetReflector (ver. 2.4.0.0)
*  using kafka-streams-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Streams
{
    #region IStreamsMetrics
    /// <summary>
    /// .NET interface for TO BE DEFINED FROM USER
    /// </summary>
    public partial interface IStreamsMetrics
    {
        #region Instance methods

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion

    #region StreamsMetrics
    public partial class StreamsMetrics : Org.Apache.Kafka.Streams.IStreamsMetrics
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/StreamsMetrics.html#metrics--"/>
        /// </summary>

        /// <typeparam name="ReturnExtendsOrg_Apache_Kafka_Common_Metric"><see cref="Org.Apache.Kafka.Common.Metric"/></typeparam>
        /// <returns><see cref="Java.Util.Map"/></returns>
        public Java.Util.Map<Org.Apache.Kafka.Common.MetricName, ReturnExtendsOrg_Apache_Kafka_Common_Metric> Metrics<ReturnExtendsOrg_Apache_Kafka_Common_Metric>() where ReturnExtendsOrg_Apache_Kafka_Common_Metric: Org.Apache.Kafka.Common.Metric
        {
            return IExecuteWithSignature<Java.Util.Map<Org.Apache.Kafka.Common.MetricName, ReturnExtendsOrg_Apache_Kafka_Common_Metric>>("metrics", "()Ljava/util/Map;");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/StreamsMetrics.html#addLatencyRateTotalSensor-java.lang.String-java.lang.String-java.lang.String-org.apache.kafka.common.metrics.Sensor.RecordingLevel-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <param name="arg1"><see cref="Java.Lang.String"/></param>
        /// <param name="arg2"><see cref="Java.Lang.String"/></param>
        /// <param name="arg3"><see cref="Org.Apache.Kafka.Common.Metrics.Sensor.RecordingLevel"/></param>
        /// <param name="arg4"><see cref="Java.Lang.String"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Metrics.Sensor"/></returns>
        public Org.Apache.Kafka.Common.Metrics.Sensor AddLatencyRateTotalSensor(Java.Lang.String arg0, Java.Lang.String arg1, Java.Lang.String arg2, Org.Apache.Kafka.Common.Metrics.Sensor.RecordingLevel arg3, params Java.Lang.String[] arg4)
        {
            if (arg4.Length == 0) return IExecute<Org.Apache.Kafka.Common.Metrics.Sensor>("addLatencyRateTotalSensor", arg0, arg1, arg2, arg3); else return IExecute<Org.Apache.Kafka.Common.Metrics.Sensor>("addLatencyRateTotalSensor", arg0, arg1, arg2, arg3, arg4);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/StreamsMetrics.html#addRateTotalSensor-java.lang.String-java.lang.String-java.lang.String-org.apache.kafka.common.metrics.Sensor.RecordingLevel-java.lang.String[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <param name="arg1"><see cref="Java.Lang.String"/></param>
        /// <param name="arg2"><see cref="Java.Lang.String"/></param>
        /// <param name="arg3"><see cref="Org.Apache.Kafka.Common.Metrics.Sensor.RecordingLevel"/></param>
        /// <param name="arg4"><see cref="Java.Lang.String"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Metrics.Sensor"/></returns>
        public Org.Apache.Kafka.Common.Metrics.Sensor AddRateTotalSensor(Java.Lang.String arg0, Java.Lang.String arg1, Java.Lang.String arg2, Org.Apache.Kafka.Common.Metrics.Sensor.RecordingLevel arg3, params Java.Lang.String[] arg4)
        {
            if (arg4.Length == 0) return IExecute<Org.Apache.Kafka.Common.Metrics.Sensor>("addRateTotalSensor", arg0, arg1, arg2, arg3); else return IExecute<Org.Apache.Kafka.Common.Metrics.Sensor>("addRateTotalSensor", arg0, arg1, arg2, arg3, arg4);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/StreamsMetrics.html#addSensor-java.lang.String-org.apache.kafka.common.metrics.Sensor.RecordingLevel-org.apache.kafka.common.metrics.Sensor[]-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Common.Metrics.Sensor.RecordingLevel"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Common.Metrics.Sensor"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Metrics.Sensor"/></returns>
        public Org.Apache.Kafka.Common.Metrics.Sensor AddSensor(Java.Lang.String arg0, Org.Apache.Kafka.Common.Metrics.Sensor.RecordingLevel arg1, params Org.Apache.Kafka.Common.Metrics.Sensor[] arg2)
        {
            if (arg2.Length == 0) return IExecute<Org.Apache.Kafka.Common.Metrics.Sensor>("addSensor", arg0, arg1); else return IExecute<Org.Apache.Kafka.Common.Metrics.Sensor>("addSensor", arg0, arg1, arg2);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/StreamsMetrics.html#addSensor-java.lang.String-org.apache.kafka.common.metrics.Sensor.RecordingLevel-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Common.Metrics.Sensor.RecordingLevel"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Metrics.Sensor"/></returns>
        public Org.Apache.Kafka.Common.Metrics.Sensor AddSensor(Java.Lang.String arg0, Org.Apache.Kafka.Common.Metrics.Sensor.RecordingLevel arg1)
        {
            return IExecute<Org.Apache.Kafka.Common.Metrics.Sensor>("addSensor", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/StreamsMetrics.html#removeSensor-org.apache.kafka.common.metrics.Sensor-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Metrics.Sensor"/></param>
        public void RemoveSensor(Org.Apache.Kafka.Common.Metrics.Sensor arg0)
        {
            IExecuteWithSignature("removeSensor", "(Lorg/apache/kafka/common/metrics/Sensor;)V", arg0);
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}