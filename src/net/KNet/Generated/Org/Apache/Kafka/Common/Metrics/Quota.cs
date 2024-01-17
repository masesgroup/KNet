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
*  This file is generated by MASES.JNetReflector (ver. 2.2.0.0)
*  using kafka-clients-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Common.Metrics
{
    #region Quota
    public partial class Quota
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/metrics/Quota.html#org.apache.kafka.common.metrics.Quota(double,boolean)"/>
        /// </summary>
        /// <param name="arg0"><see cref="double"/></param>
        /// <param name="arg1"><see cref="bool"/></param>
        public Quota(double arg0, bool arg1)
            : base(arg0, arg1)
        {
        }

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/metrics/Quota.html#lowerBound-double-"/>
        /// </summary>
        /// <param name="arg0"><see cref="double"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Metrics.Quota"/></returns>
        public static Org.Apache.Kafka.Common.Metrics.Quota LowerBound(double arg0)
        {
            return SExecute<Org.Apache.Kafka.Common.Metrics.Quota>(LocalBridgeClazz, "lowerBound", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/metrics/Quota.html#upperBound-double-"/>
        /// </summary>
        /// <param name="arg0"><see cref="double"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Common.Metrics.Quota"/></returns>
        public static Org.Apache.Kafka.Common.Metrics.Quota UpperBound(double arg0)
        {
            return SExecute<Org.Apache.Kafka.Common.Metrics.Quota>(LocalBridgeClazz, "upperBound", arg0);
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/metrics/Quota.html#acceptable-double-"/>
        /// </summary>
        /// <param name="arg0"><see cref="double"/></param>
        /// <returns><see cref="bool"/></returns>
        public bool Acceptable(double arg0)
        {
            return IExecute<bool>("acceptable", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/metrics/Quota.html#isUpperBound--"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool IsUpperBound()
        {
            return IExecute<bool>("isUpperBound");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/metrics/Quota.html#bound--"/>
        /// </summary>

        /// <returns><see cref="double"/></returns>
        public double Bound()
        {
            return IExecute<double>("bound");
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}