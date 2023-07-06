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
using Org.Apache.Kafka.Clients.Producer;

namespace MASES.KNet.Producer
{
    public class ProducerConfigBuilder : CommonClientConfigsBuilder<ProducerConfigBuilder>
    {
        public enum AcksTypes
        {
            All,
            MinusOne,
            None,
            One
        }

        public enum CompressionTypes
        {
            none,
            gzip,
            snappy,
            lz4,
            zstd
        }

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

        public long PartitionerAvailabilityTimeoutMs { get { return GetProperty<long>(ProducerConfig.PARTITIONER_AVAILABILITY_TIMEOUT_MS_CONFIG); } set { SetProperty(ProducerConfig.PARTITIONER_AVAILABILITY_TIMEOUT_MS_CONFIG, value); } }

        public ProducerConfigBuilder WithPartitionerAvailabilityTimeoutMs(long partitionerAvailabilityTimeoutMs)
        {
            var clone = Clone();
            clone.PartitionerAvailabilityTimeoutMs = partitionerAvailabilityTimeoutMs;
            return clone;
        }

        public bool PartitionerIgnoreKeys { get { return GetProperty<bool>(ProducerConfig.PARTITIONER_IGNORE_KEYS_CONFIG); } set { SetProperty(ProducerConfig.PARTITIONER_IGNORE_KEYS_CONFIG, value); } }

        public ProducerConfigBuilder WithPartitionerIgnoreKeys(bool partitionerIgnoreKeys)
        {
            var clone = Clone();
            clone.PartitionerIgnoreKeys = partitionerIgnoreKeys;
            return clone;
        }

        // "all", "-1", "0", "1"
        public ProducerConfigBuilder.AcksTypes Acks
        {
            get
            {
                var strName = GetProperty<string>(ProducerConfig.ACKS_CONFIG);
                if (strName == "all") return ProducerConfigBuilder.AcksTypes.All;
                else if (strName == "-1") return ProducerConfigBuilder.AcksTypes.MinusOne;
                else if (strName == "0") return ProducerConfigBuilder.AcksTypes.None;
                else if (strName == "1") return ProducerConfigBuilder.AcksTypes.One;

                return ProducerConfigBuilder.AcksTypes.None;
            }
            set
            {
                string str = value switch
                {
                    ProducerConfigBuilder.AcksTypes.All => "all",
                    ProducerConfigBuilder.AcksTypes.MinusOne => "-1",
                    ProducerConfigBuilder.AcksTypes.None => "0",
                    ProducerConfigBuilder.AcksTypes.One => "1",
                    _ => "all",
                };
                SetProperty(ProducerConfig.ACKS_CONFIG, str);
            }
        }

        public ProducerConfigBuilder WithAcks(ProducerConfigBuilder.AcksTypes acks)
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

        public ProducerConfigBuilder.CompressionTypes CompressionType
        {
            get
            {
                var strName = GetProperty<string>(ProducerConfig.COMPRESSION_TYPE_CONFIG);
                if (System.Enum.TryParse<ProducerConfigBuilder.CompressionTypes>(strName, out var rest))
                {
                    return rest;
                }
                return ProducerConfigBuilder.CompressionTypes.none;
            }
            set
            {
                SetProperty(ProducerConfig.COMPRESSION_TYPE_CONFIG, System.Enum.GetName(typeof(ProducerConfigBuilder.CompressionTypes), value).ToLowerInvariant());
            }
        }

        public ProducerConfigBuilder WithCompressionType(ProducerConfigBuilder.CompressionTypes compressionType)
        {
            var clone = Clone();
            clone.CompressionType = compressionType;
            return clone;
        }

        public int MaxInFlightRequestPerConnection { get { return GetProperty<int>(ProducerConfig.MAX_IN_FLIGHT_REQUESTS_PER_CONNECTION); } set { SetProperty(ProducerConfig.MAX_IN_FLIGHT_REQUESTS_PER_CONNECTION, value); } }

        public ProducerConfigBuilder WithMaxInFlightRequestPerConnection(int maxInFlightRequestPerConnection)
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

        public Java.Lang.Class PartitionerClass { get => GetProperty<Java.Lang.Class>(ProducerConfig.PARTITIONER_CLASS_CONFIG); set { SetProperty(ProducerConfig.PARTITIONER_CLASS_CONFIG, value); } }

        public ProducerConfigBuilder WithPartitionerClass(Java.Lang.Class partitionerClass)
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

        public ProducerConfigBuilder WithTransactionTimeout(int transactionTimeout)
        {
            var clone = Clone();
            clone.TransactionTimeout = transactionTimeout;
            return clone;
        }

        public string TransactionalId { get { return GetProperty<string>(ProducerConfig.TRANSACTIONAL_ID_CONFIG); } set { SetProperty(ProducerConfig.TRANSACTIONAL_ID_CONFIG, value); } }

        public ProducerConfigBuilder WithTransactionalId(string transactionalId)
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
