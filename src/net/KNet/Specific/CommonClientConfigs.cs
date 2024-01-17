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

using Org.Apache.Kafka.Common.Metrics;
using Java.Util;
using Org.Apache.Kafka.Clients;
using Java.Lang;

namespace MASES.KNet
{
    /// <summary>
    /// Common builder for <see cref="CommonClientConfigs"/>
    /// </summary>
    /// <typeparam name="T">A tpe implementing <see cref="CommonClientConfigsBuilder{T}"/></typeparam>
    public abstract class CommonClientConfigsBuilder<T> : GenericConfigBuilder<T>
        where T : CommonClientConfigsBuilder<T>, new()
    {
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.BOOTSTRAP_SERVERS_CONFIG"/>
        /// </summary>
        public string BootstrapServers { get { return GetProperty<string>(CommonClientConfigs.BOOTSTRAP_SERVERS_CONFIG); } set { SetProperty(CommonClientConfigs.BOOTSTRAP_SERVERS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.BOOTSTRAP_SERVERS_CONFIG"/>
        /// </summary>
        public T WithBootstrapServers(string bootstrapServers)
        {
            var clone = Clone();
            clone.BootstrapServers = bootstrapServers;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.CLIENT_DNS_LOOKUP_CONFIG"/>
        /// </summary>
        public string ClientDnsLookup { get { return GetProperty<string>(CommonClientConfigs.CLIENT_DNS_LOOKUP_CONFIG); } set { SetProperty(CommonClientConfigs.CLIENT_DNS_LOOKUP_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.CLIENT_DNS_LOOKUP_CONFIG"/>
        /// </summary>
        public T WithClientDnsLookup(string clientDnsLookup)
        {
            var clone = Clone();
            clone.ClientDnsLookup = clientDnsLookup;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.METADATA_MAX_AGE_CONFIG"/>
        /// </summary>
        public long MetadataMaxAge { get { return GetProperty<long>(CommonClientConfigs.METADATA_MAX_AGE_CONFIG); } set { SetProperty(CommonClientConfigs.METADATA_MAX_AGE_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.METADATA_MAX_AGE_CONFIG"/>
        /// </summary>
        public T WithMetadataMaxAge(long metadataMaxAge)
        {
            var clone = Clone();
            clone.MetadataMaxAge = metadataMaxAge;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.SEND_BUFFER_CONFIG"/>
        /// </summary>
        public int SendBuffer { get { return GetProperty<int>(CommonClientConfigs.SEND_BUFFER_CONFIG); } set { SetProperty(CommonClientConfigs.SEND_BUFFER_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.SEND_BUFFER_CONFIG"/>
        /// </summary>
        public T WithSendBuffer(int sendBuffer)
        {
            var clone = Clone();
            clone.SendBuffer = sendBuffer;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.RECEIVE_BUFFER_CONFIG"/>
        /// </summary>
        public int ReceiveBuffer { get { return GetProperty<int>(CommonClientConfigs.RECEIVE_BUFFER_CONFIG); } set { SetProperty(CommonClientConfigs.RECEIVE_BUFFER_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.RECEIVE_BUFFER_CONFIG"/>
        /// </summary>
        public T WithReceiveBuffer(int receiveBuffer)
        {
            var clone = Clone();
            clone.ReceiveBuffer = receiveBuffer;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.CLIENT_ID_CONFIG"/>
        /// </summary>
        public string ClientId { get { return GetProperty<string>(CommonClientConfigs.CLIENT_ID_CONFIG); } set { SetProperty(CommonClientConfigs.CLIENT_ID_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.CLIENT_ID_CONFIG"/>
        /// </summary>
        public T WithClientId(string clientId)
        {
            var clone = Clone();
            clone.ClientId = clientId;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.CLIENT_RACK_CONFIG"/>
        /// </summary>
        public string ClientRack { get { return GetProperty<string>(CommonClientConfigs.CLIENT_RACK_CONFIG); } set { SetProperty(CommonClientConfigs.CLIENT_RACK_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.CLIENT_RACK_CONFIG"/>
        /// </summary>
        public T WithClientRack(string clientRack)
        {
            var clone = Clone();
            clone.ClientRack = clientRack;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.RECONNECT_BACKOFF_MS_CONFIG"/>
        /// </summary>
        public long ReconnectBackoffMs { get { return GetProperty<long>(CommonClientConfigs.RECONNECT_BACKOFF_MS_CONFIG); } set { SetProperty(CommonClientConfigs.RECONNECT_BACKOFF_MS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.RECONNECT_BACKOFF_MS_CONFIG"/>
        /// </summary>
        public T WithReconnectBackoffMs(long reconnectBackoffMs)
        {
            var clone = Clone();
            clone.ReconnectBackoffMs = reconnectBackoffMs;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.RECONNECT_BACKOFF_MAX_MS_CONFIG"/>
        /// </summary>
        public long ReconnectBackoffMaxMs { get { return GetProperty<long>(CommonClientConfigs.RECONNECT_BACKOFF_MAX_MS_CONFIG); } set { SetProperty(CommonClientConfigs.RECONNECT_BACKOFF_MAX_MS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.RECONNECT_BACKOFF_MAX_MS_CONFIG"/>
        /// </summary>
        public T WithReconnectBackoffMaxMs(long reconnectBackoffMaxMs)
        {
            var clone = Clone();
            clone.ReconnectBackoffMaxMs = reconnectBackoffMaxMs;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.RETRIES_CONFIG"/>
        /// </summary>
        public int Retries { get { return GetProperty<int>(CommonClientConfigs.RETRIES_CONFIG); } set { SetProperty(CommonClientConfigs.RETRIES_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.RETRIES_CONFIG"/>
        /// </summary>
        public T WithRetries(int retries)
        {
            var clone = Clone();
            clone.Retries = retries;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.RETRY_BACKOFF_MS_CONFIG"/>
        /// </summary>
        public long RetryBackoffMs { get { return GetProperty<long>(CommonClientConfigs.RETRY_BACKOFF_MS_CONFIG); } set { SetProperty(CommonClientConfigs.RETRY_BACKOFF_MS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.RETRY_BACKOFF_MS_CONFIG"/>
        /// </summary>
        public T WithRetryBackoffMs(long retryBackoffMs)
        {
            var clone = Clone();
            clone.RetryBackoffMs = retryBackoffMs;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.METRICS_SAMPLE_WINDOW_MS_CONFIG"/>
        /// </summary>
        public long MetricSampleWindowMs { get { return GetProperty<long>(CommonClientConfigs.METRICS_SAMPLE_WINDOW_MS_CONFIG); } set { SetProperty(CommonClientConfigs.METRICS_SAMPLE_WINDOW_MS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.METRICS_SAMPLE_WINDOW_MS_CONFIG"/>
        /// </summary>
        public T WithMetricSampleWindowMs(long metricSampleWindowMs)
        {
            var clone = Clone();
            clone.MetricSampleWindowMs = metricSampleWindowMs;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.METRICS_NUM_SAMPLES_CONFIG"/>
        /// </summary>
        public int MetricNumSample { get { return GetProperty<int>(CommonClientConfigs.METRICS_NUM_SAMPLES_CONFIG); } set { SetProperty(CommonClientConfigs.METRICS_NUM_SAMPLES_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.METRICS_NUM_SAMPLES_CONFIG"/>
        /// </summary>
        public T WithMetricNumSample(int metricNumSample)
        {
            var clone = Clone();
            clone.MetricNumSample = metricNumSample;
            return clone;
        }

        /// <summary>
        /// Manages <see cref="CommonClientConfigs.METRICS_RECORDING_LEVEL_CONFIG"/>
        /// </summary>
        public Sensor.RecordingLevel MetricRecordingLevel { get { return GetProperty<Sensor.RecordingLevel>(CommonClientConfigs.METRICS_RECORDING_LEVEL_CONFIG); } set { SetProperty(CommonClientConfigs.METRICS_RECORDING_LEVEL_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.METRICS_RECORDING_LEVEL_CONFIG"/>
        /// </summary>
        public T WithMetricRecordingLevel(Sensor.RecordingLevel metricRecordingLevel)
        {
            var clone = Clone();
            clone.MetricRecordingLevel = metricRecordingLevel;
            return clone;
        }

        /// <summary>
        /// Manages <see cref="CommonClientConfigs.METRIC_REPORTER_CLASSES_CONFIG"/>
        /// </summary>
        public List<Class> MetricReporterClasses { get { return GetProperty<List<Class>>(CommonClientConfigs.METRIC_REPORTER_CLASSES_CONFIG); } set { SetProperty(CommonClientConfigs.METRIC_REPORTER_CLASSES_CONFIG, value); } }

        /// <summary>
        /// Manages <see cref="CommonClientConfigs.METRIC_REPORTER_CLASSES_CONFIG"/>
        /// </summary>
        public T WithMetricReporterClasses(List<Class> metricReporterClasses)
        {
            var clone = Clone();
            clone.MetricReporterClasses = metricReporterClasses;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.SECURITY_PROTOCOL_CONFIG"/>
        /// </summary>
        public string SecurityProtocol { get { return GetProperty<string>(CommonClientConfigs.SECURITY_PROTOCOL_CONFIG); } set { SetProperty(CommonClientConfigs.SECURITY_PROTOCOL_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.SECURITY_PROTOCOL_CONFIG"/>
        /// </summary>
        public T WithSecurityProtocol(string securityProtocol)
        {
            var clone = Clone();
            clone.SecurityProtocol = securityProtocol;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.SOCKET_CONNECTION_SETUP_TIMEOUT_MS_CONFIG"/>
        /// </summary>
        public long SocketConnectionSetupTimeoutMs { get { return GetProperty<long>(CommonClientConfigs.SOCKET_CONNECTION_SETUP_TIMEOUT_MS_CONFIG); } set { SetProperty(CommonClientConfigs.SOCKET_CONNECTION_SETUP_TIMEOUT_MS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.SOCKET_CONNECTION_SETUP_TIMEOUT_MS_CONFIG"/>
        /// </summary>
        public T WithSocketConnectionSetupTimeoutMs(long socketConnectionSetupTimeoutMs)
        {
            var clone = Clone();
            clone.SocketConnectionSetupTimeoutMs = socketConnectionSetupTimeoutMs;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.SOCKET_CONNECTION_SETUP_TIMEOUT_MAX_MS_CONFIG"/>
        /// </summary>
        public long SocketConnectionSetupTimeoutMaxMs { get { return GetProperty<long>(CommonClientConfigs.SOCKET_CONNECTION_SETUP_TIMEOUT_MAX_MS_CONFIG); } set { SetProperty(CommonClientConfigs.SOCKET_CONNECTION_SETUP_TIMEOUT_MAX_MS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.SOCKET_CONNECTION_SETUP_TIMEOUT_MAX_MS_CONFIG"/>
        /// </summary>
        public T WithSocketConnectionSetupTimeoutMaxMs(long socketConnectionSetupTimeoutMaxMs)
        {
            var clone = Clone();
            clone.SocketConnectionSetupTimeoutMaxMs = socketConnectionSetupTimeoutMaxMs;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.CONNECTIONS_MAX_IDLE_MS_CONFIG"/>
        /// </summary>
        public long ConnectionMaxIdleMs { get { return GetProperty<long>(CommonClientConfigs.CONNECTIONS_MAX_IDLE_MS_CONFIG); } set { SetProperty(CommonClientConfigs.CONNECTIONS_MAX_IDLE_MS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.CONNECTIONS_MAX_IDLE_MS_CONFIG"/>
        /// </summary>
        public T WithConnectionMaxIdleMs(long connectionMaxIdleMs)
        {
            var clone = Clone();
            clone.ConnectionMaxIdleMs = connectionMaxIdleMs;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.REQUEST_TIMEOUT_MS_CONFIG"/>
        /// </summary>
        public int RequestTimeoutMs { get { return GetProperty<int>(CommonClientConfigs.REQUEST_TIMEOUT_MS_CONFIG); } set { SetProperty(CommonClientConfigs.REQUEST_TIMEOUT_MS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.REQUEST_TIMEOUT_MS_CONFIG"/>
        /// </summary>
        public T WithRequestTimeoutMs(int requestTimeoutMs)
        {
            var clone = Clone();
            clone.RequestTimeoutMs = requestTimeoutMs;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.DEFAULT_LIST_KEY_SERDE_INNER_CLASS"/>
        /// </summary>
        public Java.Lang.Class DefaultListKeySerdeInnerClass { get { return GetProperty<Java.Lang.Class>(CommonClientConfigs.DEFAULT_LIST_KEY_SERDE_INNER_CLASS); } set { SetProperty(CommonClientConfigs.DEFAULT_LIST_KEY_SERDE_INNER_CLASS, value); } }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.DEFAULT_LIST_KEY_SERDE_INNER_CLASS"/>
        /// </summary>
        public T WithDefaultListKeySerdeInnerClass(Java.Lang.Class defaultListKeySerdeInnerClass)
        {
            var clone = Clone();
            clone.DefaultListKeySerdeInnerClass = defaultListKeySerdeInnerClass;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.DEFAULT_LIST_VALUE_SERDE_INNER_CLASS"/>
        /// </summary>
        public Java.Lang.Class DefaultListValueSerdeInnerClass { get { return GetProperty<Java.Lang.Class>(CommonClientConfigs.DEFAULT_LIST_VALUE_SERDE_INNER_CLASS); } set { SetProperty(CommonClientConfigs.DEFAULT_LIST_VALUE_SERDE_INNER_CLASS, value); } }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.DEFAULT_LIST_VALUE_SERDE_INNER_CLASS"/>
        /// </summary>
        public T WithDefaultListValueSerdeInnerClass(Java.Lang.Class defaultListValueSerdeInnerClass)
        {
            var clone = Clone();
            clone.DefaultListValueSerdeInnerClass = defaultListValueSerdeInnerClass;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.DEFAULT_LIST_KEY_SERDE_TYPE_CLASS"/>
        /// </summary>
        public Java.Lang.Class DefaultListKeySerdeTypeClass { get { return GetProperty<Java.Lang.Class>(CommonClientConfigs.DEFAULT_LIST_KEY_SERDE_TYPE_CLASS); } set { SetProperty(CommonClientConfigs.DEFAULT_LIST_KEY_SERDE_TYPE_CLASS, value); } }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.DEFAULT_LIST_KEY_SERDE_TYPE_CLASS"/>
        /// </summary>
        public T WithDefaultListKeySerdeTypeClass(Java.Lang.Class defaultListKeySerdeTypeClass)
        {
            var clone = Clone();
            clone.DefaultListKeySerdeTypeClass = defaultListKeySerdeTypeClass;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.DEFAULT_LIST_VALUE_SERDE_TYPE_CLASS"/>
        /// </summary>
        public Java.Lang.Class DefaultListValueSerdeTypeClass { get { return GetProperty<Java.Lang.Class>(CommonClientConfigs.DEFAULT_LIST_VALUE_SERDE_TYPE_CLASS); } set { SetProperty(CommonClientConfigs.DEFAULT_LIST_VALUE_SERDE_TYPE_CLASS, value); } }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.DEFAULT_LIST_VALUE_SERDE_TYPE_CLASS"/>
        /// </summary>
        public T WithDefaultListValueSerdeTypeClass(Java.Lang.Class defaultListValueSerdeTypeClass)
        {
            var clone = Clone();
            clone.DefaultListValueSerdeTypeClass = defaultListValueSerdeTypeClass;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.GROUP_ID_CONFIG"/>
        /// </summary>
        public string GroupId { get { return GetProperty<string>(CommonClientConfigs.GROUP_ID_CONFIG); } set { SetProperty(CommonClientConfigs.GROUP_ID_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.GROUP_ID_CONFIG"/>
        /// </summary>
        public T WithGroupId(string groupId)
        {
            var clone = Clone();
            clone.GroupId = groupId;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.GROUP_INSTANCE_ID_CONFIG"/>
        /// </summary>
        public string GroupInstanceId { get { return GetProperty<string>(CommonClientConfigs.GROUP_INSTANCE_ID_CONFIG); } set { SetProperty(CommonClientConfigs.GROUP_INSTANCE_ID_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.GROUP_INSTANCE_ID_CONFIG"/>
        /// </summary>
        public T WithGroupInstanceId(string groupInstanceId)
        {
            var clone = Clone();
            clone.GroupInstanceId = groupInstanceId;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.MAX_POLL_INTERVAL_MS_CONFIG"/>
        /// </summary>
        public int MaxPollIntervalMs { get { return GetProperty<int>(CommonClientConfigs.MAX_POLL_INTERVAL_MS_CONFIG); } set { SetProperty(CommonClientConfigs.MAX_POLL_INTERVAL_MS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.MAX_POLL_INTERVAL_MS_CONFIG"/>
        /// </summary>
        public T WithMaxPollIntervalMs(int maxPollIntervalMs)
        {
            var clone = Clone();
            clone.MaxPollIntervalMs = maxPollIntervalMs;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.REBALANCE_TIMEOUT_MS_CONFIG"/>
        /// </summary>
        public int RebalanceTimeoutMs { get { return GetProperty<int>(CommonClientConfigs.REBALANCE_TIMEOUT_MS_CONFIG); } set { SetProperty(CommonClientConfigs.REBALANCE_TIMEOUT_MS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.REBALANCE_TIMEOUT_MS_CONFIG"/>
        /// </summary>
        public T WithRebalanceTimeoutMs(int rebalanceTimeoutMs)
        {
            var clone = Clone();
            clone.RebalanceTimeoutMs = rebalanceTimeoutMs;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.SESSION_TIMEOUT_MS_CONFIG"/>
        /// </summary>
        public int SessionTimeoutMs { get { return GetProperty<int>(CommonClientConfigs.SESSION_TIMEOUT_MS_CONFIG); } set { SetProperty(CommonClientConfigs.SESSION_TIMEOUT_MS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.SESSION_TIMEOUT_MS_CONFIG"/>
        /// </summary>
        public T WithSessionTimeoutMs(int sessionTimeoutMs)
        {
            var clone = Clone();
            clone.SessionTimeoutMs = sessionTimeoutMs;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.HEARTBEAT_INTERVAL_MS_CONFIG"/>
        /// </summary>
        public int HeartbeatIntervalMs { get { return GetProperty<int>(CommonClientConfigs.HEARTBEAT_INTERVAL_MS_CONFIG); } set { SetProperty(CommonClientConfigs.HEARTBEAT_INTERVAL_MS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.HEARTBEAT_INTERVAL_MS_CONFIG"/>
        /// </summary>
        public T WithHeartbeatIntervalMs(int heartbeatIntervalMs)
        {
            var clone = Clone();
            clone.HeartbeatIntervalMs = heartbeatIntervalMs;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.DEFAULT_API_TIMEOUT_MS_CONFIG"/>
        /// </summary>
        public long DefaultApiTimeoutMs { get { return GetProperty<long>(CommonClientConfigs.DEFAULT_API_TIMEOUT_MS_CONFIG); } set { SetProperty(CommonClientConfigs.DEFAULT_API_TIMEOUT_MS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="CommonClientConfigs.DEFAULT_API_TIMEOUT_MS_CONFIG"/>
        /// </summary>
        public T WithDefaultApiTimeoutMs(long defaultApiTimeoutMs)
        {
            var clone = Clone();
            clone.DefaultApiTimeoutMs = defaultApiTimeoutMs;
            return clone;
        }
    }
}
