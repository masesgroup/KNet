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
using MASES.JCOBridge.C2JBridge;
using MASES.JCOBridge.C2JBridge.JVMInterop;
using System;

namespace MASES.KNet.Common.Metrics
{
    /// <summary>
    /// Listener for Kafka MetricsReporter. Extends <see cref="IJVMBridgeBase"/>
    /// </summary>
    public interface IMetricsReporter : IJVMBridgeBase
    {
        void Init(List<KafkaMetric> metrics);

        void MetricChange(KafkaMetric metric);

        void MetricRemoval(KafkaMetric metric);

        void Close();

        Set<string> ReconfigurableConfigs();

        void Configure(Map<string, object> configs);

        void Reconfigure(Map<string, object> configs);

        void ValidateReconfiguration(Map<string, object> configs);

        void ContextChange(MetricsContext metricsContext);
    }

    /// <summary>
    /// Listener for Kafka MetricsReporter. Extends <see cref="JVMBridgeListener"/>, implements <see cref="IMetricsReporter"/>
    /// </summary>
    /// <remarks>Dispose the object to avoid a resource leak, the object contains a reference to the corresponding JVM object</remarks>
    public abstract class MetricsReporter : JVMBridgeListener, IMetricsReporter
    {
        /// <inheritdoc cref="JVMBridgeListener.ClassName"/>
         public sealed override string BridgeClassName => "org.mases.knet.clients.producer.MetricsReporterImpl";
        /// <summary>
        /// Initialize a new instance of <see cref="MetricsReporter"/>
        /// </summary>
        public MetricsReporter()
        {
            AddEventHandler("init", new EventHandler<CLRListenerEventArgs<CLREventData<List<KafkaMetric>>>>(InitEventHandler));
            AddEventHandler("metricChange", new EventHandler<CLRListenerEventArgs<CLREventData<KafkaMetric>>>(MetricChangeEventHandler));
            AddEventHandler("metricRemoval", new EventHandler<CLRListenerEventArgs<CLREventData<KafkaMetric>>>(MetricRemovalEventHandler));
            AddEventHandler("close", new EventHandler<CLRListenerEventArgs<CLREventData>>(CloseEventHandler));
            AddEventHandler("reconfigurableConfigs", new EventHandler<CLRListenerEventArgs<CLREventData>>(ReconfigurableConfigsEventHandler));
            AddEventHandler("configure", new EventHandler<CLRListenerEventArgs<CLREventData<Map<string, object>>>>(ConfigureEventHandler));
            AddEventHandler("reconfigure", new EventHandler<CLRListenerEventArgs<CLREventData<Map<string, object>>>>(ReconfigureEventHandler));
            AddEventHandler("validateReconfiguration", new EventHandler<CLRListenerEventArgs<CLREventData<Map<string, object>>>>(ValidateReconfigurationEventHandler));
            AddEventHandler("contextChange", new EventHandler<CLRListenerEventArgs<CLREventData<MetricsContext>>>(ContextChangeEventHandler));
        }

        void InitEventHandler(object sender, CLRListenerEventArgs<CLREventData<List<KafkaMetric>>> data)
        {
            Init(data.EventData.TypedEventData);
        }

        void MetricChangeEventHandler(object sender, CLRListenerEventArgs<CLREventData<KafkaMetric>> data)
        {
            MetricChange(data.EventData.TypedEventData);
        }

        void MetricRemovalEventHandler(object sender, CLRListenerEventArgs<CLREventData<KafkaMetric>> data)
        {
            MetricRemoval(data.EventData.TypedEventData);
        }

        void CloseEventHandler(object sender, CLRListenerEventArgs<CLREventData> data)
        {
            Close();
        }

        void ReconfigurableConfigsEventHandler(object sender, CLRListenerEventArgs<CLREventData> data)
        {
            var result = ReconfigurableConfigs();
            data.SetReturnValue(result);
        }

        void ConfigureEventHandler(object sender, CLRListenerEventArgs<CLREventData<Map<string, object>>> data)
        {
            Configure(data.EventData.TypedEventData);
        }

        void ReconfigureEventHandler(object sender, CLRListenerEventArgs<CLREventData<Map<string, object>>> data)
        {
            Reconfigure(data.EventData.TypedEventData);
        }

        void ValidateReconfigurationEventHandler(object sender, CLRListenerEventArgs<CLREventData<Map<string, object>>> data)
        {
            ValidateReconfiguration(data.EventData.TypedEventData);
        }

        void ContextChangeEventHandler(object sender, CLRListenerEventArgs<CLREventData<MetricsContext>> data)
        {
            ContextChange(data.EventData.TypedEventData);
        }

        public virtual void Init(List<KafkaMetric> metrics)
        {

        }

        public virtual void MetricChange(KafkaMetric metric)
        {

        }

        public virtual void MetricRemoval(KafkaMetric metric)
        {

        }

        public virtual void Close()
        {

        }

        public virtual Set<string> ReconfigurableConfigs()
        {
            return Wraps<Set<string>>(Collections.DynBridgeClazz.emptySet() as IJavaObject);
        }

        public virtual void Configure(Map<string, object> configs)
        {

        }

        public virtual void Reconfigure(Map<string, object> configs)
        {

        }

        public virtual void ValidateReconfiguration(Map<string, object> configs)
        {

        }

        public virtual void ContextChange(MetricsContext metricsContext)
        {

        }
    }
}
