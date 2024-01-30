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
*  This file is generated by MASES.JNetReflector (ver. 2.2.5.0)
*  using kafka-clients-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Common.Metrics
{
    #region JmxReporter
    public partial class JmxReporter
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Common.Metrics.JmxReporter"/> to <see cref="Org.Apache.Kafka.Common.Metrics.MetricsReporter"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Common.Metrics.MetricsReporter(Org.Apache.Kafka.Common.Metrics.JmxReporter t) => t.Cast<Org.Apache.Kafka.Common.Metrics.MetricsReporter>();

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/metrics/JmxReporter.html#DEFAULT_EXCLUDE"/>
        /// </summary>
        public static string DEFAULT_EXCLUDE { get { if (!_DEFAULT_EXCLUDEReady) { _DEFAULT_EXCLUDEContent = SGetField<string>(LocalBridgeClazz, "DEFAULT_EXCLUDE"); _DEFAULT_EXCLUDEReady = true; } return _DEFAULT_EXCLUDEContent; } }
        private static string _DEFAULT_EXCLUDEContent = default;
        private static bool _DEFAULT_EXCLUDEReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/metrics/JmxReporter.html#DEFAULT_INCLUDE"/>
        /// </summary>
        public static string DEFAULT_INCLUDE { get { if (!_DEFAULT_INCLUDEReady) { _DEFAULT_INCLUDEContent = SGetField<string>(LocalBridgeClazz, "DEFAULT_INCLUDE"); _DEFAULT_INCLUDEReady = true; } return _DEFAULT_INCLUDEContent; } }
        private static string _DEFAULT_INCLUDEContent = default;
        private static bool _DEFAULT_INCLUDEReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/metrics/JmxReporter.html#EXCLUDE_CONFIG"/>
        /// </summary>
        public static string EXCLUDE_CONFIG { get { if (!_EXCLUDE_CONFIGReady) { _EXCLUDE_CONFIGContent = SGetField<string>(LocalBridgeClazz, "EXCLUDE_CONFIG"); _EXCLUDE_CONFIGReady = true; } return _EXCLUDE_CONFIGContent; } }
        private static string _EXCLUDE_CONFIGContent = default;
        private static bool _EXCLUDE_CONFIGReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/metrics/JmxReporter.html#EXCLUDE_CONFIG_ALIAS"/>
        /// </summary>
        public static string EXCLUDE_CONFIG_ALIAS { get { if (!_EXCLUDE_CONFIG_ALIASReady) { _EXCLUDE_CONFIG_ALIASContent = SGetField<string>(LocalBridgeClazz, "EXCLUDE_CONFIG_ALIAS"); _EXCLUDE_CONFIG_ALIASReady = true; } return _EXCLUDE_CONFIG_ALIASContent; } }
        private static string _EXCLUDE_CONFIG_ALIASContent = default;
        private static bool _EXCLUDE_CONFIG_ALIASReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/metrics/JmxReporter.html#INCLUDE_CONFIG"/>
        /// </summary>
        public static string INCLUDE_CONFIG { get { if (!_INCLUDE_CONFIGReady) { _INCLUDE_CONFIGContent = SGetField<string>(LocalBridgeClazz, "INCLUDE_CONFIG"); _INCLUDE_CONFIGReady = true; } return _INCLUDE_CONFIGContent; } }
        private static string _INCLUDE_CONFIGContent = default;
        private static bool _INCLUDE_CONFIGReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/metrics/JmxReporter.html#INCLUDE_CONFIG_ALIAS"/>
        /// </summary>
        public static string INCLUDE_CONFIG_ALIAS { get { if (!_INCLUDE_CONFIG_ALIASReady) { _INCLUDE_CONFIG_ALIASContent = SGetField<string>(LocalBridgeClazz, "INCLUDE_CONFIG_ALIAS"); _INCLUDE_CONFIG_ALIASReady = true; } return _INCLUDE_CONFIG_ALIASContent; } }
        private static string _INCLUDE_CONFIG_ALIASContent = default;
        private static bool _INCLUDE_CONFIG_ALIASReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/metrics/JmxReporter.html#METRICS_CONFIG_PREFIX"/>
        /// </summary>
        public static string METRICS_CONFIG_PREFIX { get { if (!_METRICS_CONFIG_PREFIXReady) { _METRICS_CONFIG_PREFIXContent = SGetField<string>(LocalBridgeClazz, "METRICS_CONFIG_PREFIX"); _METRICS_CONFIG_PREFIXReady = true; } return _METRICS_CONFIG_PREFIXContent; } }
        private static string _METRICS_CONFIG_PREFIXContent = default;
        private static bool _METRICS_CONFIG_PREFIXReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/metrics/JmxReporter.html#RECONFIGURABLE_CONFIGS"/>
        /// </summary>
        public static Java.Util.Set RECONFIGURABLE_CONFIGS { get { if (!_RECONFIGURABLE_CONFIGSReady) { _RECONFIGURABLE_CONFIGSContent = SGetField<Java.Util.Set>(LocalBridgeClazz, "RECONFIGURABLE_CONFIGS"); _RECONFIGURABLE_CONFIGSReady = true; } return _RECONFIGURABLE_CONFIGSContent; } }
        private static Java.Util.Set _RECONFIGURABLE_CONFIGSContent = default;
        private static bool _RECONFIGURABLE_CONFIGSReady = false; // this is used because in case of generics 

        #endregion

        #region Static methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/metrics/JmxReporter.html#compilePredicate-java.util.Map-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Map"/></param>
        /// <returns><see cref="Java.Util.Function.Predicate"/></returns>
        public static Java.Util.Function.Predicate<string> CompilePredicate(Java.Util.Map<string, object> arg0)
        {
            return SExecute<Java.Util.Function.Predicate<string>>(LocalBridgeClazz, "compilePredicate", arg0);
        }

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/metrics/JmxReporter.html#containsMbean-java.lang.String-"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <returns><see cref="bool"/></returns>
        public bool ContainsMbean(string arg0)
        {
            return IExecute<bool>("containsMbean", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/metrics/JmxReporter.html#reconfigurableConfigs--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Set"/></returns>
        public Java.Util.Set<string> ReconfigurableConfigs()
        {
            return IExecute<Java.Util.Set<string>>("reconfigurableConfigs");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/metrics/JmxReporter.html#close--"/>
        /// </summary>
        public void Close()
        {
            IExecute("close");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/metrics/JmxReporter.html#configure-java.util.Map-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Map"/></param>
        public void Configure(Java.Util.Map<string, object> arg0)
        {
            IExecute("configure", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/metrics/JmxReporter.html#contextChange-org.apache.kafka.common.metrics.MetricsContext-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Metrics.MetricsContext"/></param>
        public void ContextChange(Org.Apache.Kafka.Common.Metrics.MetricsContext arg0)
        {
            IExecute("contextChange", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/metrics/JmxReporter.html#init-java.util.List-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.List"/></param>
        public void Init(Java.Util.List<Org.Apache.Kafka.Common.Metrics.KafkaMetric> arg0)
        {
            IExecute("init", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/metrics/JmxReporter.html#metricChange-org.apache.kafka.common.metrics.KafkaMetric-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Metrics.KafkaMetric"/></param>
        public void MetricChange(Org.Apache.Kafka.Common.Metrics.KafkaMetric arg0)
        {
            IExecute("metricChange", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/metrics/JmxReporter.html#metricRemoval-org.apache.kafka.common.metrics.KafkaMetric-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Metrics.KafkaMetric"/></param>
        public void MetricRemoval(Org.Apache.Kafka.Common.Metrics.KafkaMetric arg0)
        {
            IExecute("metricRemoval", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/metrics/JmxReporter.html#reconfigure-java.util.Map-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Map"/></param>
        public void Reconfigure(Java.Util.Map<string, object> arg0)
        {
            IExecute("reconfigure", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.1/org/apache/kafka/common/metrics/JmxReporter.html#validateReconfiguration-java.util.Map-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Map"/></param>
        /// <exception cref="Org.Apache.Kafka.Common.Config.ConfigException"/>
        public void ValidateReconfiguration(Java.Util.Map<string, object> arg0)
        {
            IExecute("validateReconfiguration", arg0);
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}