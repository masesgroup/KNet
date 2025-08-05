/*
*  Copyright (c) 2021-2025 MASES s.r.l.
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
using MASES.JCOBridge.C2JBridge;
using MASES.JCOBridge.C2JBridge.JVMInterop;
using System;

namespace Org.Apache.Kafka.Common.Metrics
{
    /// <summary>
    /// Listener for Kafka MetricsReporter. Extends <see cref="IJVMBridgeBase"/>
    /// </summary>
    public partial interface IMetricsReporter : IJVMBridgeBase
    {
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/4.0.0/org/apache/kafka/common/metrics/MetricsReporter.html#init(java.util.List)"/>
        /// </summary>
        void Init(List<KafkaMetric> metrics);
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/4.0.0/org/apache/kafka/common/metrics/MetricsReporter.html#metricChange(org.apache.kafka.common.metrics.KafkaMetric)"/>
        /// </summary>
        void MetricChange(KafkaMetric metric);
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/4.0.0/org/apache/kafka/common/metrics/MetricsReporter.html#metricRemoval(org.apache.kafka.common.metrics.KafkaMetric)"/>
        /// </summary>
        void MetricRemoval(KafkaMetric metric);
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/4.0.0/org/apache/kafka/common/metrics/MetricsReporter.html#close()"/>
        /// </summary>
        void Close();
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/4.0.0/org/apache/kafka/common/metrics/MetricsReporter.html#reconfigurableConfigs()"/>
        /// </summary>
        Set<Java.Lang.String> ReconfigurableConfigs();
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/4.0.0/org/apache/kafka/common/Configurable.html#configure(java.util.Map)"/>
        /// </summary>
        void Configure(Map<Java.Lang.String, object> configs);
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/4.0.0/org/apache/kafka/common/metrics/MetricsReporter.html#reconfigure(java.util.Map)"/>
        /// </summary>
        void Reconfigure(Map<Java.Lang.String, object> configs);
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/4.0.0/org/apache/kafka/common/metrics/MetricsReporter.html#validateReconfiguration(java.util.Map)"/>
        /// </summary>
        void ValidateReconfiguration(Map<Java.Lang.String, object> configs);
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/4.0.0/org/apache/kafka/common/metrics/MetricsReporter.html#contextChange(org.apache.kafka.common.metrics.MetricsContext)"/>
        /// </summary>
        void ContextChange(MetricsContext metricsContext);
    }

    /// <summary>
    /// Listener for Kafka MetricsReporter. Extends <see cref="JVMBridgeListener"/>, implements <see cref="IMetricsReporter"/>
    /// </summary>
    /// <remarks>Dispose the object to avoid a resource leak, the object contains a reference to the corresponding JVM object</remarks>
    public partial class MetricsReporter : IMetricsReporter
    {

    }
}
