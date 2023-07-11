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

/*
*  This file is generated by MASES.JNetReflector (ver. 2.0.1.0)
*  using kafka-clients-3.5.0.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Common.Metrics
{
    #region MetricConfig
    public partial class MetricConfig
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
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/metrics/MetricConfig.html#samples--"/>
        /// </summary>

        /// <returns><see cref="int"/></returns>
        public int Samples()
        {
            return IExecute<int>("samples");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/metrics/MetricConfig.html#tags--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Map"/></returns>
        public Java.Util.Map<string, string> Tags()
        {
            return IExecute<Java.Util.Map<string, string>>("tags");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/metrics/MetricConfig.html#eventWindow--"/>
        /// </summary>

        /// <returns><see cref="long"/></returns>
        public long EventWindow()
        {
            return IExecute<long>("eventWindow");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/metrics/MetricConfig.html#timeWindowMs--"/>
        /// </summary>

        /// <returns><see cref="long"/></returns>
        public long TimeWindowMs()
        {
            return IExecute<long>("timeWindowMs");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/metrics/MetricConfig.html#eventWindow-long-"/>
        /// </summary>
        /// <param name="arg0"><see cref="long"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Metrics.MetricConfig"/></returns>
        public Org.Apache.Kafka.Common.Metrics.MetricConfig EventWindow(long arg0)
        {
            return IExecute<Org.Apache.Kafka.Common.Metrics.MetricConfig>("eventWindow", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/metrics/MetricConfig.html#quota-org.apache.kafka.common.metrics.Quota-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Metrics.Quota"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Metrics.MetricConfig"/></returns>
        public Org.Apache.Kafka.Common.Metrics.MetricConfig Quota(Org.Apache.Kafka.Common.Metrics.Quota arg0)
        {
            return IExecute<Org.Apache.Kafka.Common.Metrics.MetricConfig>("quota", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/metrics/MetricConfig.html#recordLevel-org.apache.kafka.common.metrics.Sensor.RecordingLevel-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Metrics.Sensor.RecordingLevel"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Metrics.MetricConfig"/></returns>
        public Org.Apache.Kafka.Common.Metrics.MetricConfig RecordLevel(Org.Apache.Kafka.Common.Metrics.Sensor.RecordingLevel arg0)
        {
            return IExecute<Org.Apache.Kafka.Common.Metrics.MetricConfig>("recordLevel", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/metrics/MetricConfig.html#samples-int-"/>
        /// </summary>
        /// <param name="arg0"><see cref="int"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Metrics.MetricConfig"/></returns>
        public Org.Apache.Kafka.Common.Metrics.MetricConfig Samples(int arg0)
        {
            return IExecute<Org.Apache.Kafka.Common.Metrics.MetricConfig>("samples", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/metrics/MetricConfig.html#tags-java.util.Map-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Map"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Metrics.MetricConfig"/></returns>
        public Org.Apache.Kafka.Common.Metrics.MetricConfig Tags(Java.Util.Map<string, string> arg0)
        {
            return IExecute<Org.Apache.Kafka.Common.Metrics.MetricConfig>("tags", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/metrics/MetricConfig.html#timeWindow-long-java.util.concurrent.TimeUnit-"/>
        /// </summary>
        /// <param name="arg0"><see cref="long"/></param>
        /// <param name="arg1"><see cref="Java.Util.Concurrent.TimeUnit"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Metrics.MetricConfig"/></returns>
        public Org.Apache.Kafka.Common.Metrics.MetricConfig TimeWindow(long arg0, Java.Util.Concurrent.TimeUnit arg1)
        {
            return IExecute<Org.Apache.Kafka.Common.Metrics.MetricConfig>("timeWindow", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/metrics/MetricConfig.html#quota--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Metrics.Quota"/></returns>
        public Org.Apache.Kafka.Common.Metrics.Quota Quota()
        {
            return IExecute<Org.Apache.Kafka.Common.Metrics.Quota>("quota");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.5.0/org/apache/kafka/common/metrics/MetricConfig.html#recordLevel--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Metrics.Sensor.RecordingLevel"/></returns>
        public Org.Apache.Kafka.Common.Metrics.Sensor.RecordingLevel RecordLevel()
        {
            return IExecute<Org.Apache.Kafka.Common.Metrics.Sensor.RecordingLevel>("recordLevel");
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}