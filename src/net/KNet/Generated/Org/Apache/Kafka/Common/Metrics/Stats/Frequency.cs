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
*  using kafka-clients-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Common.Metrics.Stats
{
    #region Frequency
    public partial class Frequency
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/metrics/stats/Frequency.html#org.apache.kafka.common.metrics.stats.Frequency(org.apache.kafka.common.MetricName,double)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.MetricName"/></param>
        /// <param name="arg1"><see cref="double"/></param>
        public Frequency(Org.Apache.Kafka.Common.MetricName arg0, double arg1)
            : base(arg0, arg1)
        {
        }

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/metrics/stats/Frequency.html#centerValue--"/>
        /// </summary>

        /// <returns><see cref="double"/></returns>
        public double CenterValue()
        {
            return IExecuteWithSignature<double>("centerValue", "()D");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/metrics/stats/Frequency.html#name--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.MetricName"/></returns>
        public Org.Apache.Kafka.Common.MetricName Name()
        {
            return IExecuteWithSignature<Org.Apache.Kafka.Common.MetricName>("name", "()Lorg/apache/kafka/common/MetricName;");
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}