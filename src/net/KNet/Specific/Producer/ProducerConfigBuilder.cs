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

using Java.Lang;
using Java.Util;
using Org.Apache.Kafka.Clients.Producer;

namespace MASES.KNet.Producer
{
    /// <summary>
    /// Builder for <see cref="ProducerConfig"/>
    /// </summary>
    public class ProducerConfigBuilder : CommonClientConfigsBuilder<ProducerConfigBuilder>
    {
        /// <summary>
        /// Used from <see cref="Acks"/> and <see cref="WithAcks(AcksTypes)"/>
        /// </summary>
        public enum AcksTypes
        {
            /// <summary>
            /// All
            /// </summary>
            All,
            /// <summary>
            /// -1
            /// </summary>
            MinusOne,
            /// <summary>
            /// None
            /// </summary>
            None,
            /// <summary>
            /// 1
            /// </summary>
            One
        }
        /// <summary>
        /// Used from <see cref="CompressionType"/> and <see cref="WithCompressionType(CompressionTypes)"/>
        /// </summary>
        public enum CompressionTypes
        {
            /// <summary>
            /// none
            /// </summary>
            none,
            /// <summary>
            /// gzip
            /// </summary>
            gzip,
            /// <summary>
            /// snappy
            /// </summary>
            snappy,
            /// <summary>
            /// lz4
            /// </summary>
            lz4,
            /// <summary>
            /// zstd
            /// </summary>
            zstd
        }
        /// <summary>
        /// Manages <see cref="ProducerConfig.METADATA_MAX_IDLE_CONFIG"/>
        /// </summary>
        public long MetadataMaxIdle { get { return GetProperty<long>(ProducerConfig.METADATA_MAX_IDLE_CONFIG); } set { SetProperty(ProducerConfig.METADATA_MAX_IDLE_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="ProducerConfig.METADATA_MAX_IDLE_CONFIG"/>
        /// </summary>
        public ProducerConfigBuilder WithMetadataMaxIdle(long metadataMaxIdle)
        {
            var clone = Clone();
            clone.MetadataMaxIdle = metadataMaxIdle;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="ProducerConfig.BATCH_SIZE_CONFIG"/>
        /// </summary>
        public int BatchSize { get { return GetProperty<int>(ProducerConfig.BATCH_SIZE_CONFIG); } set { SetProperty(ProducerConfig.BATCH_SIZE_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="ProducerConfig.BATCH_SIZE_CONFIG"/>
        /// </summary>
        public ProducerConfigBuilder WithBatchSize(int batchSize)
        {
            var clone = Clone();
            clone.BatchSize = batchSize;
            return clone;
        }

        /// <summary>
        /// Manages <see cref="ProducerConfig.PARTITIONER_IGNORE_KEYS_CONFIG"/>
        /// </summary>
        public bool PartitionerIgnoreKeys { get { return GetProperty<bool>(ProducerConfig.PARTITIONER_IGNORE_KEYS_CONFIG); } set { SetProperty(ProducerConfig.PARTITIONER_IGNORE_KEYS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="ProducerConfig.PARTITIONER_IGNORE_KEYS_CONFIG"/>
        /// </summary>
        public ProducerConfigBuilder WithPartitionerIgnoreKeys(bool partitionerIgnoreKeys)
        {
            var clone = Clone();
            clone.PartitionerIgnoreKeys = partitionerIgnoreKeys;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="ProducerConfig.ACKS_CONFIG"/>
        /// </summary>
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
        /// <summary>
        /// Manages <see cref="ProducerConfig.ACKS_CONFIG"/>
        /// </summary>
        public ProducerConfigBuilder WithAcks(ProducerConfigBuilder.AcksTypes acks)
        {
            var clone = Clone();
            clone.Acks = acks;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="ProducerConfig.LINGER_MS_CONFIG"/>
        /// </summary>
        public long LingerMs { get { return GetProperty<long>(ProducerConfig.LINGER_MS_CONFIG); } set { SetProperty(ProducerConfig.LINGER_MS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="ProducerConfig.LINGER_MS_CONFIG"/>
        /// </summary>
        public ProducerConfigBuilder WithLingerMs(long lingerMs)
        {
            var clone = Clone();
            clone.LingerMs = lingerMs;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="ProducerConfig.DELIVERY_TIMEOUT_MS_CONFIG"/>
        /// </summary>
        public int DeliveryTimeoutMs { get { return GetProperty<int>(ProducerConfig.DELIVERY_TIMEOUT_MS_CONFIG); } set { SetProperty(ProducerConfig.DELIVERY_TIMEOUT_MS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="ProducerConfig.DELIVERY_TIMEOUT_MS_CONFIG"/>
        /// </summary>
        public ProducerConfigBuilder WithDeliveryTimeoutMs(int deliveryTimeoutMs)
        {
            var clone = Clone();
            clone.DeliveryTimeoutMs = deliveryTimeoutMs;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="ProducerConfig.MAX_REQUEST_SIZE_CONFIG"/>
        /// </summary>
        public int MaxRequestSize { get { return GetProperty<int>(ProducerConfig.MAX_REQUEST_SIZE_CONFIG); } set { SetProperty(ProducerConfig.MAX_REQUEST_SIZE_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="ProducerConfig.MAX_REQUEST_SIZE_CONFIG"/>
        /// </summary>
        public ProducerConfigBuilder WithMaxRequestSize(int maxRequestSize)
        {
            var clone = Clone();
            clone.MaxRequestSize = maxRequestSize;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="ProducerConfig.MAX_BLOCK_MS_CONFIG"/>
        /// </summary>
        public long MaxBlockMs { get { return GetProperty<long>(ProducerConfig.MAX_BLOCK_MS_CONFIG); } set { SetProperty(ProducerConfig.MAX_BLOCK_MS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="ProducerConfig.MAX_BLOCK_MS_CONFIG"/>
        /// </summary>
        public ProducerConfigBuilder WithMaxBlockMs(long maxBlockMs)
        {
            var clone = Clone();
            clone.MaxBlockMs = maxBlockMs;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="ProducerConfig.BUFFER_MEMORY_CONFIG"/>
        /// </summary>
        public long BufferMemory { get { return GetProperty<long>(ProducerConfig.BUFFER_MEMORY_CONFIG); } set { SetProperty(ProducerConfig.BUFFER_MEMORY_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="ProducerConfig.BUFFER_MEMORY_CONFIG"/>
        /// </summary>
        public ProducerConfigBuilder WithBufferMemory(long bufferMemory)
        {
            var clone = Clone();
            clone.BufferMemory = bufferMemory;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="ProducerConfig.COMPRESSION_GZIP_LEVEL_CONFIG"/>
        /// </summary>
        public int CompressionGzipLevel { get { return GetProperty<int>(ProducerConfig.COMPRESSION_GZIP_LEVEL_CONFIG); } set { SetProperty(ProducerConfig.COMPRESSION_GZIP_LEVEL_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="ProducerConfig.COMPRESSION_GZIP_LEVEL_CONFIG"/>
        /// </summary>
        public ProducerConfigBuilder WithCompressionGzipLevel(int compressionGzipLevel)
        {
            var clone = Clone();
            clone.CompressionGzipLevel = compressionGzipLevel;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="ProducerConfig.COMPRESSION_LZ4_LEVEL_CONFIG"/>
        /// </summary>
        public int CompressionLz4Level { get { return GetProperty<int>(ProducerConfig.COMPRESSION_LZ4_LEVEL_CONFIG); } set { SetProperty(ProducerConfig.COMPRESSION_LZ4_LEVEL_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="ProducerConfig.COMPRESSION_LZ4_LEVEL_CONFIG"/>
        /// </summary>
        public ProducerConfigBuilder WithCompressionLz4Level(int compressionLz4Level)
        {
            var clone = Clone();
            clone.CompressionLz4Level = compressionLz4Level;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="ProducerConfig.COMPRESSION_TYPE_CONFIG"/>
        /// </summary>
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
        /// <summary>
        /// Manages <see cref="ProducerConfig.COMPRESSION_TYPE_CONFIG"/>
        /// </summary>
        public ProducerConfigBuilder WithCompressionType(ProducerConfigBuilder.CompressionTypes compressionType)
        {
            var clone = Clone();
            clone.CompressionType = compressionType;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="ProducerConfig.COMPRESSION_ZSTD_LEVEL_CONFIG"/>
        /// </summary>
        public int CompressionZstdLevel { get { return GetProperty<int>(ProducerConfig.COMPRESSION_ZSTD_LEVEL_CONFIG); } set { SetProperty(ProducerConfig.COMPRESSION_ZSTD_LEVEL_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="ProducerConfig.COMPRESSION_ZSTD_LEVEL_CONFIG"/>
        /// </summary>
        public ProducerConfigBuilder WithCompressionZstdLevel(int compressionZstdLevel)
        {
            var clone = Clone();
            clone.CompressionZstdLevel = compressionZstdLevel;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="ProducerConfig.MAX_IN_FLIGHT_REQUESTS_PER_CONNECTION"/>
        /// </summary>
        public int MaxInFlightRequestPerConnection { get { return GetProperty<int>(ProducerConfig.MAX_IN_FLIGHT_REQUESTS_PER_CONNECTION); } set { SetProperty(ProducerConfig.MAX_IN_FLIGHT_REQUESTS_PER_CONNECTION, value); } }
        /// <summary>
        /// Manages <see cref="ProducerConfig.MAX_IN_FLIGHT_REQUESTS_PER_CONNECTION"/>
        /// </summary>
        public ProducerConfigBuilder WithMaxInFlightRequestPerConnection(int maxInFlightRequestPerConnection)
        {
            var clone = Clone();
            clone.MaxInFlightRequestPerConnection = maxInFlightRequestPerConnection;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="ProducerConfig.KEY_SERIALIZER_CLASS_CONFIG"/>
        /// </summary>
        public string KeySerializerClass { get { return GetProperty<string>(ProducerConfig.KEY_SERIALIZER_CLASS_CONFIG); } set { SetProperty(ProducerConfig.KEY_SERIALIZER_CLASS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="ProducerConfig.KEY_SERIALIZER_CLASS_CONFIG"/>
        /// </summary>
        public ProducerConfigBuilder WithKeySerializerClass(string keySerializerClass)
        {
            var clone = Clone();
            clone.KeySerializerClass = keySerializerClass;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="ProducerConfig.VALUE_SERIALIZER_CLASS_CONFIG"/>
        /// </summary>
        public string ValueSerializerClass { get { return GetProperty<string>(ProducerConfig.VALUE_SERIALIZER_CLASS_CONFIG); } set { SetProperty(ProducerConfig.VALUE_SERIALIZER_CLASS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="ProducerConfig.VALUE_SERIALIZER_CLASS_CONFIG"/>
        /// </summary>
        public ProducerConfigBuilder WithValueSerializerClass(string valueSerializerClass)
        {
            var clone = Clone();
            clone.ValueSerializerClass = valueSerializerClass;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="ProducerConfig.PARTITIONER_ADPATIVE_PARTITIONING_ENABLE_CONFIG"/>
        /// </summary>
        public bool PartitionerAdaptivePartitioningEnable { get { return GetProperty<bool>(ProducerConfig.PARTITIONER_ADPATIVE_PARTITIONING_ENABLE_CONFIG); } set { SetProperty(ProducerConfig.PARTITIONER_ADPATIVE_PARTITIONING_ENABLE_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="ProducerConfig.PARTITIONER_ADPATIVE_PARTITIONING_ENABLE_CONFIG"/>
        /// </summary>
        public ProducerConfigBuilder WithPartitionerAdaptivePartitioningEnable(bool partitionerAdaptivePartitioningEnable)
        {
            var clone = Clone();
            clone.PartitionerAdaptivePartitioningEnable = partitionerAdaptivePartitioningEnable;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="ProducerConfig.PARTITIONER_AVAILABILITY_TIMEOUT_MS_CONFIG"/>
        /// </summary>
        public long PartitionerAvailabilityTimeoutMs { get { return GetProperty<long>(ProducerConfig.PARTITIONER_AVAILABILITY_TIMEOUT_MS_CONFIG); } set { SetProperty(ProducerConfig.PARTITIONER_AVAILABILITY_TIMEOUT_MS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="ProducerConfig.PARTITIONER_AVAILABILITY_TIMEOUT_MS_CONFIG"/>
        /// </summary>
        public ProducerConfigBuilder WithPartitionerAvailabilityTimeoutMs(long partitionerAvailabilityTimeoutMs)
        {
            var clone = Clone();
            clone.PartitionerAvailabilityTimeoutMs = partitionerAvailabilityTimeoutMs;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="ProducerConfig.PARTITIONER_CLASS_CONFIG"/>
        /// </summary>
        public Java.Lang.Class PartitionerClass { get => GetProperty<Java.Lang.Class>(ProducerConfig.PARTITIONER_CLASS_CONFIG); set { SetProperty(ProducerConfig.PARTITIONER_CLASS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="ProducerConfig.PARTITIONER_CLASS_CONFIG"/>
        /// </summary>
        public ProducerConfigBuilder WithPartitionerClass(Java.Lang.Class partitionerClass)
        {
            var clone = Clone();
            clone.PartitionerClass = partitionerClass;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="ProducerConfig.INTERCEPTOR_CLASSES_CONFIG"/>
        /// </summary>
        public List<Class> InterceptorClasses { get { return GetProperty<List<Class>>(ProducerConfig.INTERCEPTOR_CLASSES_CONFIG); } set { SetProperty(ProducerConfig.INTERCEPTOR_CLASSES_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="ProducerConfig.INTERCEPTOR_CLASSES_CONFIG"/>
        /// </summary>
        public ProducerConfigBuilder WithInterceptorClasses(List<Class> interceptorClasses)
        {
            var clone = Clone();
            clone.InterceptorClasses = interceptorClasses;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="ProducerConfig.ENABLE_IDEMPOTENCE_CONFIG"/>
        /// </summary>
        public bool EnableIdempotence { get { return GetProperty<bool>(ProducerConfig.ENABLE_IDEMPOTENCE_CONFIG); } set { SetProperty(ProducerConfig.ENABLE_IDEMPOTENCE_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="ProducerConfig.ENABLE_IDEMPOTENCE_CONFIG"/>
        /// </summary>
        public ProducerConfigBuilder WithEnableIdempotence(bool enableIdempotence)
        {
            var clone = Clone();
            clone.EnableIdempotence = enableIdempotence;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="ProducerConfig.TRANSACTION_TIMEOUT_CONFIG"/>
        /// </summary>
        public int TransactionTimeout { get { return GetProperty<int>(ProducerConfig.TRANSACTION_TIMEOUT_CONFIG); } set { SetProperty(ProducerConfig.TRANSACTION_TIMEOUT_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="ProducerConfig.TRANSACTION_TIMEOUT_CONFIG"/>
        /// </summary>
        public ProducerConfigBuilder WithTransactionTimeout(int transactionTimeout)
        {
            var clone = Clone();
            clone.TransactionTimeout = transactionTimeout;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="ProducerConfig.TRANSACTIONAL_ID_CONFIG"/>
        /// </summary>
        public string TransactionalId { get { return GetProperty<string>(ProducerConfig.TRANSACTIONAL_ID_CONFIG); } set { SetProperty(ProducerConfig.TRANSACTIONAL_ID_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="ProducerConfig.TRANSACTIONAL_ID_CONFIG"/>
        /// </summary>
        public ProducerConfigBuilder WithTransactionalId(string transactionalId)
        {
            var clone = Clone();
            clone.TransactionalId = transactionalId;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="ProducerConfig.SECURITY_PROVIDERS_CONFIG"/>
        /// </summary>
        public string SecurityProviders { get { return GetProperty<string>(ProducerConfig.SECURITY_PROVIDERS_CONFIG); } set { SetProperty(ProducerConfig.SECURITY_PROVIDERS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="ProducerConfig.SECURITY_PROVIDERS_CONFIG"/>
        /// </summary>
        public ProducerConfigBuilder WithSecurityProviders(string securityProviders)
        {
            var clone = Clone();
            clone.SecurityProviders = securityProviders;
            return clone;
        }
    }
}
