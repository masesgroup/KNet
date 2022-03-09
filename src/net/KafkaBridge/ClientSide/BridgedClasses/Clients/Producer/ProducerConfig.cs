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

using MASES.KafkaBridge.Common.Config;
using Java.Util;

namespace MASES.KafkaBridge.Clients.Producer
{
    public class ProducerConfig : AbstractConfig<ProducerConfig>
    {
        public enum Acks
        {
            All,
            MinusOne,
            None,
            One
        }

        public enum CompressionType
        {
            none,
            gzip,
            snappy,
            lz4,
            zstd
        }

        public override string ClassName => "org.apache.kafka.clients.producer.ProducerConfig";

        public static readonly string BOOTSTRAP_SERVERS_CONFIG = Clazz.GetField<string>("BOOTSTRAP_SERVERS_CONFIG");

        public static readonly string CLIENT_DNS_LOOKUP_CONFIG = Clazz.GetField<string>("CLIENT_DNS_LOOKUP_CONFIG");

        public static readonly string METADATA_MAX_AGE_CONFIG = Clazz.GetField<string>("METADATA_MAX_AGE_CONFIG");

        public static readonly string METADATA_MAX_IDLE_CONFIG = Clazz.GetField<string>("METADATA_MAX_IDLE_CONFIG");

        public static readonly string BATCH_SIZE_CONFIG = Clazz.GetField<string>("BATCH_SIZE_CONFIG");

        public static readonly string ACKS_CONFIG = Clazz.GetField<string>("ACKS_CONFIG");

        public static readonly string LINGER_MS_CONFIG = Clazz.GetField<string>("LINGER_MS_CONFIG");

        public static readonly string REQUEST_TIMEOUT_MS_CONFIG = Clazz.GetField<string>("REQUEST_TIMEOUT_MS_CONFIG");

        public static readonly string DELIVERY_TIMEOUT_MS_CONFIG = Clazz.GetField<string>("DELIVERY_TIMEOUT_MS_CONFIG");

        public static readonly string CLIENT_ID_CONFIG = Clazz.GetField<string>("CLIENT_ID_CONFIG");

        public static readonly string SEND_BUFFER_CONFIG = Clazz.GetField<string>("SEND_BUFFER_CONFIG");

        public static readonly string RECEIVE_BUFFER_CONFIG = Clazz.GetField<string>("RECEIVE_BUFFER_CONFIG");

        public static readonly string MAX_REQUEST_SIZE_CONFIG = Clazz.GetField<string>("MAX_REQUEST_SIZE_CONFIG");

        public static readonly string RECONNECT_BACKOFF_MS_CONFIG = Clazz.GetField<string>("RECONNECT_BACKOFF_MS_CONFIG");

        public static readonly string RECONNECT_BACKOFF_MAX_MS_CONFIG = Clazz.GetField<string>("RECONNECT_BACKOFF_MAX_MS_CONFIG");

        public static readonly string MAX_BLOCK_MS_CONFIG = Clazz.GetField<string>("MAX_BLOCK_MS_CONFIG");

        public static readonly string BUFFER_MEMORY_CONFIG = Clazz.GetField<string>("BUFFER_MEMORY_CONFIG");

        public static readonly string RETRY_BACKOFF_MS_CONFIG = Clazz.GetField<string>("RETRY_BACKOFF_MS_CONFIG");

        public static readonly string COMPRESSION_TYPE_CONFIG = Clazz.GetField<string>("COMPRESSION_TYPE_CONFIG");

        public static readonly string METRICS_SAMPLE_WINDOW_MS_CONFIG = Clazz.GetField<string>("METRICS_SAMPLE_WINDOW_MS_CONFIG");

        public static readonly string METRICS_NUM_SAMPLES_CONFIG = Clazz.GetField<string>("METRICS_NUM_SAMPLES_CONFIG");

        public static readonly string METRICS_RECORDING_LEVEL_CONFIG = Clazz.GetField<string>("METRICS_RECORDING_LEVEL_CONFIG");

        public static readonly string METRIC_REPORTER_CLASSES_CONFIG = Clazz.GetField<string>("METRIC_REPORTER_CLASSES_CONFIG");

        public static readonly string MAX_IN_FLIGHT_REQUESTS_PER_CONNECTION = Clazz.GetField<string>("MAX_IN_FLIGHT_REQUESTS_PER_CONNECTION");

        public static readonly string RETRIES_CONFIG = Clazz.GetField<string>("RETRIES_CONFIG");

        public static readonly string KEY_SERIALIZER_CLASS_CONFIG = Clazz.GetField<string>("KEY_SERIALIZER_CLASS_CONFIG");

        public static readonly string VALUE_SERIALIZER_CLASS_CONFIG = Clazz.GetField<string>("VALUE_SERIALIZER_CLASS_CONFIG");

        public static readonly string SOCKET_CONNECTION_SETUP_TIMEOUT_MS_CONFIG = Clazz.GetField<string>("SOCKET_CONNECTION_SETUP_TIMEOUT_MS_CONFIG");

        public static readonly string SOCKET_CONNECTION_SETUP_TIMEOUT_MAX_MS_CONFIG = Clazz.GetField<string>("SOCKET_CONNECTION_SETUP_TIMEOUT_MAX_MS_CONFIG");

        public static readonly string CONNECTIONS_MAX_IDLE_MS_CONFIG = Clazz.GetField<string>("CONNECTIONS_MAX_IDLE_MS_CONFIG");

        public static readonly string PARTITIONER_CLASS_CONFIG = Clazz.GetField<string>("PARTITIONER_CLASS_CONFIG");

        public static readonly string INTERCEPTOR_CLASSES_CONFIG = Clazz.GetField<string>("INTERCEPTOR_CLASSES_CONFIG");

        public static readonly string ENABLE_IDEMPOTENCE_CONFIG = Clazz.GetField<string>("ENABLE_IDEMPOTENCE_CONFIG");

        public static readonly string TRANSACTION_TIMEOUT_CONFIG = Clazz.GetField<string>("TRANSACTION_TIMEOUT_CONFIG");

        public static readonly string TRANSACTIONAL_ID_CONFIG = Clazz.GetField<string>("TRANSACTIONAL_ID_CONFIG");

        public static readonly string SECURITY_PROVIDERS_CONFIG = Clazz.GetField<string>("SECURITY_PROVIDERS_CONFIG");

        [System.Obsolete("This is not public in Apache Kafka API")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public ProducerConfig() { }

        public ProducerConfig(Properties props)
            : base(props)
        {
        }

        public ProducerConfig(Map<string, object> props)
            : base(props)
        {
        }
    }

    public class ProducerConfigBuilder : CommonClientConfigsBuilder<ProducerConfigBuilder>
    {
        public long MetadataMaxIdle { get { return GetProperty<long>(ProducerConfig.METADATA_MAX_IDLE_CONFIG); } set { SetProperty(ProducerConfig.METADATA_MAX_IDLE_CONFIG, value); } }

        public ProducerConfigBuilder WithMetadataMaxIdle(long metadataMaxIdle)
        {
            var clone = Clone();
            clone.MetadataMaxIdle = metadataMaxIdle;
            return clone;
        }

        public int BatchSize { get { return GetProperty<int>(ProducerConfig.BATCH_SIZE_CONFIG); } set { SetProperty(ProducerConfig.BATCH_SIZE_CONFIG, value); } }

        public ProducerConfigBuilder WithBatchSize(int batchSize)
        {
            var clone = Clone();
            clone.BatchSize = batchSize;
            return clone;
        }

        // "all", "-1", "0", "1"
        public ProducerConfig.Acks Acks
        {
            get
            {
                var strName = GetProperty<string>(ProducerConfig.ACKS_CONFIG);
                if (strName == "all") return ProducerConfig.Acks.All;
                else if (strName == "-1") return ProducerConfig.Acks.MinusOne;
                else if (strName == "0") return ProducerConfig.Acks.None;
                else if (strName == "1") return ProducerConfig.Acks.One;

                return ProducerConfig.Acks.None;
            }
            set
            {
                string str = value switch
                {
                    ProducerConfig.Acks.All => "all",
                    ProducerConfig.Acks.MinusOne => "-1",
                    ProducerConfig.Acks.None => "0",
                    ProducerConfig.Acks.One => "1",
                    _ => "all",
                };
                SetProperty(ProducerConfig.ACKS_CONFIG, str);
            }
        }

        public ProducerConfigBuilder WithAcks(ProducerConfig.Acks acks)
        {
            var clone = Clone();
            clone.Acks = acks;
            return clone;
        }

        public long LingerMs { get { return GetProperty<long>(ProducerConfig.LINGER_MS_CONFIG); } set { SetProperty(ProducerConfig.LINGER_MS_CONFIG, value); } }

        public ProducerConfigBuilder WithLingerMs(long lingerMs)
        {
            var clone = Clone();
            clone.LingerMs = lingerMs;
            return clone;
        }

        public int DeliveryTimeoutMs { get { return GetProperty<int>(ProducerConfig.DELIVERY_TIMEOUT_MS_CONFIG); } set { SetProperty(ProducerConfig.DELIVERY_TIMEOUT_MS_CONFIG, value); } }

        public ProducerConfigBuilder WithDeliveryTimeoutMs(int deliveryTimeoutMs)
        {
            var clone = Clone();
            clone.DeliveryTimeoutMs = deliveryTimeoutMs;
            return clone;
        }

        public int MaxRequestSize { get { return GetProperty<int>(ProducerConfig.MAX_REQUEST_SIZE_CONFIG); } set { SetProperty(ProducerConfig.MAX_REQUEST_SIZE_CONFIG, value); } }

        public ProducerConfigBuilder WithMaxRequestSize(int maxRequestSize)
        {
            var clone = Clone();
            clone.MaxRequestSize = maxRequestSize;
            return clone;
        }

        public long MaxBlockMs { get { return GetProperty<long>(ProducerConfig.MAX_BLOCK_MS_CONFIG); } set { SetProperty(ProducerConfig.MAX_BLOCK_MS_CONFIG, value); } }

        public ProducerConfigBuilder WithMaxBlockMs(long maxBlockMs)
        {
            var clone = Clone();
            clone.MaxBlockMs = maxBlockMs;
            return clone;
        }

        public long BufferMemory { get { return GetProperty<long>(ProducerConfig.BUFFER_MEMORY_CONFIG); } set { SetProperty(ProducerConfig.BUFFER_MEMORY_CONFIG, value); } }

        public ProducerConfigBuilder WithBufferMemory(long bufferMemory)
        {
            var clone = Clone();
            clone.BufferMemory = bufferMemory;
            return clone;
        }

        public ProducerConfig.CompressionType CompressionType
        {
            get
            {
                var strName = GetProperty<string>(ProducerConfig.COMPRESSION_TYPE_CONFIG);
                if (System.Enum.TryParse<ProducerConfig.CompressionType>(strName, out var rest))
                {
                    return rest;
                }
                return ProducerConfig.CompressionType.none;
            }
            set
            {
                SetProperty(ProducerConfig.COMPRESSION_TYPE_CONFIG, System.Enum.GetName(typeof(ProducerConfig.CompressionType), value).ToLowerInvariant());
            }
        }

        public ProducerConfigBuilder WithCompressionType(ProducerConfig.CompressionType compressionType)
        {
            var clone = Clone();
            clone.CompressionType = compressionType;
            return clone;
        }

        public int MaxInFlightRequestPerConnection { get { return GetProperty<int>(ProducerConfig.MAX_IN_FLIGHT_REQUESTS_PER_CONNECTION); } set { SetProperty(ProducerConfig.MAX_IN_FLIGHT_REQUESTS_PER_CONNECTION, value); } }

        public ProducerConfigBuilder WitMaxInFlightRequestPerConnection(int maxInFlightRequestPerConnection)
        {
            var clone = Clone();
            clone.MaxInFlightRequestPerConnection = maxInFlightRequestPerConnection;
            return clone;
        }

        public string KeySerializerClass { get { return GetProperty<string>(ProducerConfig.KEY_SERIALIZER_CLASS_CONFIG); } set { SetProperty(ProducerConfig.KEY_SERIALIZER_CLASS_CONFIG, value); } }

        public ProducerConfigBuilder WithKeySerializerClass(string keySerializerClass)
        {
            var clone = Clone();
            clone.KeySerializerClass = keySerializerClass;
            return clone;
        }

        public string ValueSerializerClass { get { return GetProperty<string>(ProducerConfig.VALUE_SERIALIZER_CLASS_CONFIG); } set { SetProperty(ProducerConfig.VALUE_SERIALIZER_CLASS_CONFIG, value); } }

        public ProducerConfigBuilder WithValueSerializerClass(string valueSerializerClass)
        {
            var clone = Clone();
            clone.ValueSerializerClass = valueSerializerClass;
            return clone;
        }

        public dynamic PartitionerClass { get => GetProperty<dynamic>(ProducerConfig.PARTITIONER_CLASS_CONFIG); set { SetProperty(ProducerConfig.PARTITIONER_CLASS_CONFIG, value); } }

        public ProducerConfigBuilder WithPartitionerClass(dynamic partitionerClass)
        {
            var clone = Clone();
            clone.PartitionerClass = partitionerClass;
            return clone;
        }

        [System.Obsolete("To be checked")]
        public List InterceptorClasses { get { return GetProperty<List>(ProducerConfig.INTERCEPTOR_CLASSES_CONFIG); } set { SetProperty(ProducerConfig.INTERCEPTOR_CLASSES_CONFIG, value); } }

        [System.Obsolete("To be checked")]
        public ProducerConfigBuilder WithInterceptorClasses(List interceptorClasses)
        {
            var clone = Clone();
            clone.InterceptorClasses = interceptorClasses;
            return clone;
        }

        public bool EnableIdempotence { get { return GetProperty<bool>(ProducerConfig.ENABLE_IDEMPOTENCE_CONFIG); } set { SetProperty(ProducerConfig.ENABLE_IDEMPOTENCE_CONFIG, value); } }

        public ProducerConfigBuilder WithEnableIdempotence(bool enableIdempotence)
        {
            var clone = Clone();
            clone.EnableIdempotence = enableIdempotence;
            return clone;
        }

        public int TransactionTimeout { get { return GetProperty<int>(ProducerConfig.TRANSACTION_TIMEOUT_CONFIG); } set { SetProperty(ProducerConfig.TRANSACTION_TIMEOUT_CONFIG, value); } }

        public ProducerConfigBuilder WitTransactionTimeout(int transactionTimeout)
        {
            var clone = Clone();
            clone.TransactionTimeout = transactionTimeout;
            return clone;
        }

        public string TransactionalId { get { return GetProperty<string>(ProducerConfig.TRANSACTIONAL_ID_CONFIG); } set { SetProperty(ProducerConfig.TRANSACTIONAL_ID_CONFIG, value); } }

        public ProducerConfigBuilder WitTransactionalId(string transactionalId)
        {
            var clone = Clone();
            clone.TransactionalId = transactionalId;
            return clone;
        }

        public string SecurityProviders { get { return GetProperty<string>(ProducerConfig.SECURITY_PROVIDERS_CONFIG); } set { SetProperty(ProducerConfig.SECURITY_PROVIDERS_CONFIG, value); } }

        public ProducerConfigBuilder WithSecurityProviders(string securityProviders)
        {
            var clone = Clone();
            clone.SecurityProviders = securityProviders;
            return clone;
        }
    }
}
