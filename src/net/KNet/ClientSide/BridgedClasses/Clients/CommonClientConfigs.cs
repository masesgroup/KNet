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

using MASES.KNet.Common.Metrics;
using Java.Util;

namespace MASES.KNet.Clients
{
    public class CommonClientConfigs : JCOBridge.C2JBridge.JVMBridgeBase<CommonClientConfigs>
    {
        public override string ClassName => "org.apache.kafka.clients.CommonClientConfigs";

        public static readonly string BOOTSTRAP_SERVERS_CONFIG = Clazz.GetField<string>("BOOTSTRAP_SERVERS_CONFIG");

        public static readonly string CLIENT_DNS_LOOKUP_CONFIG = Clazz.GetField<string>("CLIENT_DNS_LOOKUP_CONFIG");

        public static readonly string METADATA_MAX_AGE_CONFIG = Clazz.GetField<string>("METADATA_MAX_AGE_CONFIG");

        public static readonly string SEND_BUFFER_CONFIG = Clazz.GetField<string>("SEND_BUFFER_CONFIG");

        public static readonly string RECEIVE_BUFFER_CONFIG = Clazz.GetField<string>("RECEIVE_BUFFER_CONFIG");

        public static readonly string CLIENT_ID_CONFIG = Clazz.GetField<string>("CLIENT_ID_CONFIG");

        public static readonly string CLIENT_RACK_CONFIG = Clazz.GetField<string>("CLIENT_RACK_CONFIG");

        public static readonly string RECONNECT_BACKOFF_MS_CONFIG = Clazz.GetField<string>("RECONNECT_BACKOFF_MS_CONFIG");

        public static readonly string RECONNECT_BACKOFF_MAX_MS_CONFIG = Clazz.GetField<string>("RECONNECT_BACKOFF_MAX_MS_CONFIG");

        public static readonly string RETRIES_CONFIG = Clazz.GetField<string>("RETRIES_CONFIG");

        public static readonly string RETRY_BACKOFF_MS_CONFIG = Clazz.GetField<string>("RETRY_BACKOFF_MS_CONFIG");

        public static readonly string METRICS_SAMPLE_WINDOW_MS_CONFIG = Clazz.GetField<string>("METRICS_SAMPLE_WINDOW_MS_CONFIG");

        public static readonly string METRICS_NUM_SAMPLES_CONFIG = Clazz.GetField<string>("METRICS_NUM_SAMPLES_CONFIG");

        public static readonly string METRICS_RECORDING_LEVEL_CONFIG = Clazz.GetField<string>("METRICS_RECORDING_LEVEL_CONFIG");

        public static readonly string METRIC_REPORTER_CLASSES_CONFIG = Clazz.GetField<string>("METRIC_REPORTER_CLASSES_CONFIG");

        public static readonly string SECURITY_PROTOCOL_CONFIG = Clazz.GetField<string>("SECURITY_PROTOCOL_CONFIG");

        public static readonly string SOCKET_CONNECTION_SETUP_TIMEOUT_MS_CONFIG = Clazz.GetField<string>("SOCKET_CONNECTION_SETUP_TIMEOUT_MS_CONFIG");

        public static readonly string SOCKET_CONNECTION_SETUP_TIMEOUT_MAX_MS_CONFIG = Clazz.GetField<string>("SOCKET_CONNECTION_SETUP_TIMEOUT_MAX_MS_CONFIG");

        public static readonly string CONNECTIONS_MAX_IDLE_MS_CONFIG = Clazz.GetField<string>("CONNECTIONS_MAX_IDLE_MS_CONFIG");

        public static readonly string REQUEST_TIMEOUT_MS_CONFIG = Clazz.GetField<string>("REQUEST_TIMEOUT_MS_CONFIG");

        public static readonly string DEFAULT_LIST_KEY_SERDE_INNER_CLASS = Clazz.GetField<string>("DEFAULT_LIST_KEY_SERDE_INNER_CLASS");

        public static readonly string DEFAULT_LIST_VALUE_SERDE_INNER_CLASS = Clazz.GetField<string>("DEFAULT_LIST_VALUE_SERDE_INNER_CLASS");

        public static readonly string DEFAULT_LIST_KEY_SERDE_TYPE_CLASS = Clazz.GetField<string>("DEFAULT_LIST_KEY_SERDE_TYPE_CLASS");

        public static readonly string DEFAULT_LIST_VALUE_SERDE_TYPE_CLASS = Clazz.GetField<string>("DEFAULT_LIST_VALUE_SERDE_TYPE_CLASS");

        public static readonly string GROUP_ID_CONFIG = Clazz.GetField<string>("GROUP_ID_CONFIG");

        public static readonly string GROUP_INSTANCE_ID_CONFIG = Clazz.GetField<string>("GROUP_INSTANCE_ID_CONFIG");

        public static readonly string MAX_POLL_INTERVAL_MS_CONFIG = Clazz.GetField<string>("MAX_POLL_INTERVAL_MS_CONFIG");

        public static readonly string REBALANCE_TIMEOUT_MS_CONFIG = Clazz.GetField<string>("REBALANCE_TIMEOUT_MS_CONFIG");

        public static readonly string SESSION_TIMEOUT_MS_CONFIG = Clazz.GetField<string>("SESSION_TIMEOUT_MS_CONFIG");

        public static readonly string HEARTBEAT_INTERVAL_MS_CONFIG = Clazz.GetField<string>("HEARTBEAT_INTERVAL_MS_CONFIG");

        public static readonly string DEFAULT_API_TIMEOUT_MS_CONFIG = Clazz.GetField<string>("DEFAULT_API_TIMEOUT_MS_CONFIG");
    }

    public abstract class CommonClientConfigsBuilder<T> : GenericConfigBuilder<T>
        where T : CommonClientConfigsBuilder<T>, new()
    {
        public string BootstrapServers { get { return GetProperty<string>(CommonClientConfigs.BOOTSTRAP_SERVERS_CONFIG); } set { SetProperty(CommonClientConfigs.BOOTSTRAP_SERVERS_CONFIG, value); } }

        public T WithBootstrapServers(string bootstrapServers)
        {
            var clone = Clone();
            clone.BootstrapServers = bootstrapServers;
            return clone;
        }

        public string ClientDnsLookup { get { return GetProperty<string>(CommonClientConfigs.CLIENT_DNS_LOOKUP_CONFIG); } set { SetProperty(CommonClientConfigs.CLIENT_DNS_LOOKUP_CONFIG, value); } }

        public T WithClientDnsLookup(string clientDnsLookup)
        {
            var clone = Clone();
            clone.ClientDnsLookup = clientDnsLookup;
            return clone;
        }

        public long MetadataMaxAge { get { return GetProperty<long>(CommonClientConfigs.METADATA_MAX_AGE_CONFIG); } set { SetProperty(CommonClientConfigs.METADATA_MAX_AGE_CONFIG, value); } }

        public T WithMetadataMaxAge(long metadataMaxAge)
        {
            var clone = Clone();
            clone.MetadataMaxAge = metadataMaxAge;
            return clone;
        }

        public int SendBuffer { get { return GetProperty<int>(CommonClientConfigs.SEND_BUFFER_CONFIG); } set { SetProperty(CommonClientConfigs.SEND_BUFFER_CONFIG, value); } }

        public T WithSendBuffer(int sendBuffer)
        {
            var clone = Clone();
            clone.SendBuffer = sendBuffer;
            return clone;
        }

        public int ReceiveBuffer { get { return GetProperty<int>(CommonClientConfigs.RECEIVE_BUFFER_CONFIG); } set { SetProperty(CommonClientConfigs.RECEIVE_BUFFER_CONFIG, value); } }

        public T WithReceiveBuffer(int receiveBuffer)
        {
            var clone = Clone();
            clone.ReceiveBuffer = receiveBuffer;
            return clone;
        }

        public string ClientId { get { return GetProperty<string>(CommonClientConfigs.CLIENT_ID_CONFIG); } set { SetProperty(CommonClientConfigs.CLIENT_ID_CONFIG, value); } }

        public T WithClientId(string clientId)
        {
            var clone = Clone();
            clone.ClientId = clientId;
            return clone;
        }

        public string ClientRack { get { return GetProperty<string>(CommonClientConfigs.CLIENT_RACK_CONFIG); } set { SetProperty(CommonClientConfigs.CLIENT_RACK_CONFIG, value); } }

        public T WithClientRack(string clientRack)
        {
            var clone = Clone();
            clone.ClientRack = clientRack;
            return clone;
        }

        public long ReconnectBackoffMs { get { return GetProperty<long>(CommonClientConfigs.RECONNECT_BACKOFF_MS_CONFIG); } set { SetProperty(CommonClientConfigs.RECONNECT_BACKOFF_MS_CONFIG, value); } }

        public T WithReconnectBackoffMs(long reconnectBackoffMs)
        {
            var clone = Clone();
            clone.ReconnectBackoffMs = reconnectBackoffMs;
            return clone;
        }

        public long ReconnectBackoffMaxMs { get { return GetProperty<long>(CommonClientConfigs.RECONNECT_BACKOFF_MAX_MS_CONFIG); } set { SetProperty(CommonClientConfigs.RECONNECT_BACKOFF_MAX_MS_CONFIG, value); } }

        public T WithReconnectBackoffMaxMs(long reconnectBackoffMaxMs)
        {
            var clone = Clone();
            clone.ReconnectBackoffMaxMs = reconnectBackoffMaxMs;
            return clone;
        }

        public int Retries { get { return GetProperty<int>(CommonClientConfigs.RETRIES_CONFIG); } set { SetProperty(CommonClientConfigs.RETRIES_CONFIG, value); } }

        public T WithRetries(int retries)
        {
            var clone = Clone();
            clone.Retries = retries;
            return clone;
        }

        public long RetryBackoffMs { get { return GetProperty<long>(CommonClientConfigs.RETRY_BACKOFF_MS_CONFIG); } set { SetProperty(CommonClientConfigs.RETRY_BACKOFF_MS_CONFIG, value); } }

        public T WithRetryBackoffMs(long retryBackoffMs)
        {
            var clone = Clone();
            clone.RetryBackoffMs = retryBackoffMs;
            return clone;
        }

        public long MetricSampleWindowMs { get { return GetProperty<long>(CommonClientConfigs.METRICS_SAMPLE_WINDOW_MS_CONFIG); } set { SetProperty(CommonClientConfigs.METRICS_SAMPLE_WINDOW_MS_CONFIG, value); } }

        public T WithMetricSampleWindowMs(long metricSampleWindowMs)
        {
            var clone = Clone();
            clone.MetricSampleWindowMs = metricSampleWindowMs;
            return clone;
        }

        public int MetricNumSample { get { return GetProperty<int>(CommonClientConfigs.METRICS_NUM_SAMPLES_CONFIG); } set { SetProperty(CommonClientConfigs.METRICS_NUM_SAMPLES_CONFIG, value); } }

        public T WithMetricNumSample(int metricNumSample)
        {
            var clone = Clone();
            clone.MetricNumSample = metricNumSample;
            return clone;
        }

        // Sensor.RecordingLevel.INFO.toString(), Sensor.RecordingLevel.DEBUG.toString(), Sensor.RecordingLevel.TRACE.toString()
        public Sensor.RecordingLevel MetricRecordingLevel
        {
            get
            {
                var strName = GetProperty<string>(CommonClientConfigs.METRICS_RECORDING_LEVEL_CONFIG);
                if (System.Enum.GetName(typeof(Sensor.RecordingLevel), Sensor.RecordingLevel.DEBUG) == strName)
                    return Sensor.RecordingLevel.DEBUG;
                else if (System.Enum.GetName(typeof(Sensor.RecordingLevel), Sensor.RecordingLevel.INFO) == strName)
                    return Sensor.RecordingLevel.INFO;
                else if (System.Enum.GetName(typeof(Sensor.RecordingLevel), Sensor.RecordingLevel.TRACE) == strName)
                    return Sensor.RecordingLevel.TRACE;
                else return Sensor.RecordingLevel.INFO;
            }
            set
            {
                SetProperty(CommonClientConfigs.METRICS_RECORDING_LEVEL_CONFIG, System.Enum.GetName(typeof(Sensor.RecordingLevel), value));
            }
        }

        public T WithMetricRecordingLevel(Sensor.RecordingLevel metricRecordingLevel)
        {
            var clone = Clone();
            clone.MetricRecordingLevel = metricRecordingLevel;
            return clone;
        }

        [System.Obsolete("To be checked")]
        public List MetricReporterClasses { get { return GetProperty<List>(CommonClientConfigs.METRIC_REPORTER_CLASSES_CONFIG); } set { SetProperty(CommonClientConfigs.METRIC_REPORTER_CLASSES_CONFIG, value); } }

        [System.Obsolete("To be checked")]
        public T WithMetricReporterClasses(List metricReporterClasses)
        {
            var clone = Clone();
            clone.MetricReporterClasses = metricReporterClasses;
            return clone;
        }

        public string SecurityProtocol { get { return GetProperty<string>(CommonClientConfigs.SECURITY_PROTOCOL_CONFIG); } set { SetProperty(CommonClientConfigs.SECURITY_PROTOCOL_CONFIG, value); } }

        public T WithSecurityProtocol(string securityProtocol)
        {
            var clone = Clone();
            clone.SecurityProtocol = securityProtocol;
            return clone;
        }

        public long SocketConnectionSetupTimeoutMs { get { return GetProperty<long>(CommonClientConfigs.SOCKET_CONNECTION_SETUP_TIMEOUT_MS_CONFIG); } set { SetProperty(CommonClientConfigs.SOCKET_CONNECTION_SETUP_TIMEOUT_MS_CONFIG, value); } }

        public T WithSocketConnectionSetupTimeoutMs(long socketConnectionSetupTimeoutMs)
        {
            var clone = Clone();
            clone.SocketConnectionSetupTimeoutMs = socketConnectionSetupTimeoutMs;
            return clone;
        }

        public long SocketConnectionSetupTimeoutMaxMs { get { return GetProperty<long>(CommonClientConfigs.SOCKET_CONNECTION_SETUP_TIMEOUT_MAX_MS_CONFIG); } set { SetProperty(CommonClientConfigs.SOCKET_CONNECTION_SETUP_TIMEOUT_MAX_MS_CONFIG, value); } }

        public T WithSocketConnectionSetupTimeoutMaxMs(long socketConnectionSetupTimeoutMaxMs)
        {
            var clone = Clone();
            clone.SocketConnectionSetupTimeoutMaxMs = socketConnectionSetupTimeoutMaxMs;
            return clone;
        }

        public long ConnectionMaxIdleMs { get { return GetProperty<long>(CommonClientConfigs.CONNECTIONS_MAX_IDLE_MS_CONFIG); } set { SetProperty(CommonClientConfigs.CONNECTIONS_MAX_IDLE_MS_CONFIG, value); } }

        public T WithConnectionMaxIdleMs(long connectionMaxIdleMs)
        {
            var clone = Clone();
            clone.ConnectionMaxIdleMs = connectionMaxIdleMs;
            return clone;
        }

        public int RequestTimeoutMs { get { return GetProperty<int>(CommonClientConfigs.REQUEST_TIMEOUT_MS_CONFIG); } set { SetProperty(CommonClientConfigs.REQUEST_TIMEOUT_MS_CONFIG, value); } }

        public T WithRequestTimeoutMs(int requestTimeoutMs)
        {
            var clone = Clone();
            clone.RequestTimeoutMs = requestTimeoutMs;
            return clone;
        }

        [System.Obsolete("To be checked")]
        public dynamic DefaultListKeySerdeInnerClass { get { return GetProperty<dynamic>(CommonClientConfigs.DEFAULT_LIST_KEY_SERDE_INNER_CLASS); } set { SetProperty(CommonClientConfigs.DEFAULT_LIST_KEY_SERDE_INNER_CLASS, value); } }

        [System.Obsolete("To be checked")]
        public T WithDefaultListKeySerdeInnerClass(dynamic defaultListKeySerdeInnerClass)
        {
            var clone = Clone();
            clone.DefaultListKeySerdeInnerClass = defaultListKeySerdeInnerClass;
            return clone;
        }

        [System.Obsolete("To be checked")]
        public dynamic DefaultListValueSerdeInnerClass { get { return GetProperty<dynamic>(CommonClientConfigs.DEFAULT_LIST_VALUE_SERDE_INNER_CLASS); } set { SetProperty(CommonClientConfigs.DEFAULT_LIST_VALUE_SERDE_INNER_CLASS, value); } }

        [System.Obsolete("To be checked")]
        public T WithDefaultListValueSerdeInnerClass(dynamic defaultListValueSerdeInnerClass)
        {
            var clone = Clone();
            clone.DefaultListValueSerdeInnerClass = defaultListValueSerdeInnerClass;
            return clone;
        }

        [System.Obsolete("To be checked")]
        public dynamic DefaultListKeySerdeTypeClass { get { return GetProperty<dynamic>(CommonClientConfigs.DEFAULT_LIST_KEY_SERDE_TYPE_CLASS); } set { SetProperty(CommonClientConfigs.DEFAULT_LIST_KEY_SERDE_TYPE_CLASS, value); } }

        [System.Obsolete("To be checked")]
        public T WithDefaultListKeySerdeTypeClass(dynamic defaultListKeySerdeTypeClass)
        {
            var clone = Clone();
            clone.DefaultListKeySerdeTypeClass = defaultListKeySerdeTypeClass;
            return clone;
        }

        [System.Obsolete("To be checked")]
        public dynamic DefaultListValueSerdeTypeClass { get { return GetProperty<dynamic>(CommonClientConfigs.DEFAULT_LIST_VALUE_SERDE_TYPE_CLASS); } set { SetProperty(CommonClientConfigs.DEFAULT_LIST_VALUE_SERDE_TYPE_CLASS, value); } }

        [System.Obsolete("To be checked")]
        public T WithDefaultListValueSerdeTypeClass(dynamic defaultListValueSerdeTypeClass)
        {
            var clone = Clone();
            clone.DefaultListValueSerdeTypeClass = defaultListValueSerdeTypeClass;
            return clone;
        }

        public string GroupId { get { return GetProperty<string>(CommonClientConfigs.GROUP_ID_CONFIG); } set { SetProperty(CommonClientConfigs.GROUP_ID_CONFIG, value); } }

        public T WithGroupId(string groupId)
        {
            var clone = Clone();
            clone.GroupId = groupId;
            return clone;
        }

        public string GroupInstanceId { get { return GetProperty<string>(CommonClientConfigs.GROUP_INSTANCE_ID_CONFIG); } set { SetProperty(CommonClientConfigs.GROUP_INSTANCE_ID_CONFIG, value); } }

        public T WithGroupInstanceId(string groupInstanceId)
        {
            var clone = Clone();
            clone.GroupInstanceId = groupInstanceId;
            return clone;
        }

        public int MaxPollIntervalMs { get { return GetProperty<int>(CommonClientConfigs.MAX_POLL_INTERVAL_MS_CONFIG); } set { SetProperty(CommonClientConfigs.MAX_POLL_INTERVAL_MS_CONFIG, value); } }

        public T WithMaxPollIntervalMs(int maxPollIntervalMs)
        {
            var clone = Clone();
            clone.MaxPollIntervalMs = maxPollIntervalMs;
            return clone;
        }

        public int RebalanceTimeoutMs { get { return GetProperty<int>(CommonClientConfigs.REBALANCE_TIMEOUT_MS_CONFIG); } set { SetProperty(CommonClientConfigs.REBALANCE_TIMEOUT_MS_CONFIG, value); } }

        public T WithRebalanceTimeoutMs(int rebalanceTimeoutMs)
        {
            var clone = Clone();
            clone.RebalanceTimeoutMs = rebalanceTimeoutMs;
            return clone;
        }

        public int SessionTimeoutMs { get { return GetProperty<int>(CommonClientConfigs.SESSION_TIMEOUT_MS_CONFIG); } set { SetProperty(CommonClientConfigs.SESSION_TIMEOUT_MS_CONFIG, value); } }

        public T WithSessionTimeoutMs(int sessionTimeoutMs)
        {
            var clone = Clone();
            clone.SessionTimeoutMs = sessionTimeoutMs;
            return clone;
        }

        public int HeartbeatIntervalMs { get { return GetProperty<int>(CommonClientConfigs.HEARTBEAT_INTERVAL_MS_CONFIG); } set { SetProperty(CommonClientConfigs.HEARTBEAT_INTERVAL_MS_CONFIG, value); } }

        public T WithHeartbeatIntervalMs(int heartbeatIntervalMs)
        {
            var clone = Clone();
            clone.HeartbeatIntervalMs = heartbeatIntervalMs;
            return clone;
        }

        public long DefaultApiTimeoutMs { get { return GetProperty<long>(CommonClientConfigs.DEFAULT_API_TIMEOUT_MS_CONFIG); } set { SetProperty(CommonClientConfigs.DEFAULT_API_TIMEOUT_MS_CONFIG, value); } }

        public T WithDefaultApiTimeoutMs(long defaultApiTimeoutMs)
        {
            var clone = Clone();
            clone.DefaultApiTimeoutMs = defaultApiTimeoutMs;
            return clone;
        }
    }
}
