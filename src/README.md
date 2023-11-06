## Generated classes

The command used to build the classes is the following:

```cmd
MASES.JNetReflector.exe -TraceLevel 0 -OriginRootPath .\jars -DestinationRootPath .\src\ -ConfigurationFile .\src\configuration.json
```

The configuration is:

```json
{
  "RelativeDestinationCSharpClassPath": "net\\KNet\\Generated",
  "RelativeDestinationJavaListenerPath": "jvm\\knet\\src\\main\\java",
  "JavaListenerBasePackage": "org.mases.knet.generated",
  "OnlyPropertiesForGetterSetter": true,
  "DisableInterfaceMethodGeneration": true,
  "CreateInterfaceInheritance": true,
  "JarList": [
    "kafka_2.13-3.6.0.jar",
    "kafka-clients-3.6.0.jar",
    "kafka-streams-3.6.0.jar",
    "kafka-tools-3.6.0.jar",
    "kafka-raft-3.6.0.jar",
    "connect-api-3.6.0.jar",
    "connect-basic-auth-extension-3.6.0.jar",
    "connect-json-3.6.0.jar",
    "connect-mirror-3.6.0.jar",
    "connect-mirror-client-3.6.0.jar",
    "connect-runtime-3.6.0.jar",
    "connect-transforms-3.6.0.jar"
  ],
  "OriginJavadocJARVersionAndUrls": [
    {
      "Version": 8,
      "Url": "https://www.javadoc.io/doc/org.apache.kafka/kafka_2.13/3.6.0/"
    },
    {
      "Version": 8,
      "Url": "https://www.javadoc.io/doc/org.apache.kafka/kafka-clients/3.6.0/"
    },
    {
      "Version": 8,
      "Url": "https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.0/"
    },
    {
      "Version": 8,
      "Url": "https://www.javadoc.io/doc/org.apache.kafka/kafka-tools/3.6.0/"
    },
    {
      "Version": 8,
      "Url": "https://www.javadoc.io/doc/org.apache.kafka/kafka-raft/3.6.0/"
    },
    {
      "Version": 8,
      "Url": "https://www.javadoc.io/doc/org.apache.kafka/connect-api/3.6.0/"
    },
    {
      "Version": 8,
      "Url": "https://www.javadoc.io/doc/org.apache.kafka/connect-basic-auth-extension/3.6.0/"
    },
    {
      "Version": 8,
      "Url": "https://www.javadoc.io/doc/org.apache.kafka/connect-json/3.6.0/"
    },
    {
      "Version": 8,
      "Url": "https://www.javadoc.io/doc/org.apache.kafka/connect-mirror/3.6.0/"
    },
    {
      "Version": 8,
      "Url": "https://www.javadoc.io/doc/org.apache.kafka/connect-mirror-client/3.6.0/"
    },
    {
      "Version": 8,
      "Url": "https://www.javadoc.io/doc/org.apache.kafka/connect-runtime/3.6.0/"
    },
    {
      "Version": 8,
      "Url": "https://www.javadoc.io/doc/org.apache.kafka/connect-transforms/3.6.0/"
    }
  ],
  "NamespacesToAvoid": [
    "scala",
    "joptsimple",
    "org.rocksdb",
    "com.typesafe",
    "com.fasterxml",
    "javax.ws.rs",
    "kafka.api",
    "kafka.cluster",
    "kafka.common",
    "kafka.consumer",
    "kafka.controller",
    "kafka.coordinator",
    "kafka.internals",
    "kafka.log",
    "kafka.message",
    "kafka.metrics",
    "kafka.migration",
    "kafka.network",
    "kafka.raft",
    "kafka.security",
    "kafka.serializer",
    "kafka.server",
    "kafka.tools",
    "kafka.utils",
    "kafka.zk",
    "kafka.zookeeper",
    "net.sourceforge",
    "org.apache.kafka.clients.admin.internals",
    "org.apache.kafka.clients.consumer.internals",
    "org.apache.kafka.clients.producer.internals",
    "org.apache.kafka.common.config.internals",
    "org.apache.kafka.common.feature",
    "org.apache.kafka.common.header.internals",
    "org.apache.kafka.common.internals",
    "org.apache.kafka.common.message",
    "org.apache.kafka.common.metrics.internals",
    "org.apache.kafka.common.network",
    "org.apache.kafka.common.protocol",
    "org.apache.kafka.common.requests",
    "org.apache.kafka.common.security.kerberos",
    "org.apache.kafka.common.security.oauthbearer.internals",
    "org.apache.kafka.common.security.scram.internals",
    "org.apache.kafka.common.security.token.delegation.internals",
    "org.apache.kafka.connect.connector.policy",
    "org.apache.kafka.connect.mirror.rest",
    "org.apache.kafka.connect.runtime",
    "org.apache.kafka.connect.storage",
    "org.apache.kafka.connect.tools",
	"org.apache.kafka.raft.internals",
    "org.apache.kafka.server",
    "org.apache.kafka.streams.internals",
    "org.apache.kafka.streams.processor.internals",
    "org.apache.kafka.streams.state.internals",
    "org.apache.kafka.streams.kstream.internals",
    "org.apache.kafka.streams.query.internals",
    "org.apache.zookeeper.client",
    "org.eclipse.jetty",
    "org.glassfish",
    "org.slf4j"
  ],
  "ClassesToBeListener": [
    "org.apache.kafka.clients.consumer.OffsetCommitCallback",
    "org.apache.kafka.clients.consumer.ConsumerInterceptor",
    "org.apache.kafka.clients.consumer.ConsumerPartitionAssignor",
    "org.apache.kafka.clients.producer.Callback",
    "org.apache.kafka.clients.producer.Partitioner",
    "org.apache.kafka.clients.producer.ProducerInterceptor",
    "org.apache.kafka.common.config.ConfigChangeCallback",
    "org.apache.kafka.common.metrics.MetricsReporter",
    "org.apache.kafka.common.serialization.Deserializer",
    "org.apache.kafka.common.serialization.Serializer",
    "org.apache.kafka.streams.KafkaClientSupplier",
    "org.apache.kafka.streams.errors.StreamsUncaughtExceptionHandler",
    "org.apache.kafka.streams.kstream.Aggregator",
    "org.apache.kafka.streams.kstream.ForeachAction",
    "org.apache.kafka.streams.kstream.Predicate",
    "org.apache.kafka.streams.kstream.Reducer",
    "org.apache.kafka.streams.kstream.Merger",
    "org.apache.kafka.streams.kstream.Initializer",
    "org.apache.kafka.streams.kstream.KeyValueMapper",
    "org.apache.kafka.streams.kstream.Transformer",
    "org.apache.kafka.streams.kstream.ValueJoiner",
    "org.apache.kafka.streams.kstream.ValueJoinerWithKey",
    "org.apache.kafka.streams.kstream.ValueMapper",
    "org.apache.kafka.streams.kstream.ValueMapperWithKey",
    "org.apache.kafka.streams.kstream.ValueTransformer",
    "org.apache.kafka.streams.kstream.ValueTransformerWithKey",
    "org.apache.kafka.streams.processor.BatchingStateRestoreCallback",
    "org.apache.kafka.streams.processor.StateRestoreCallback",
    "org.apache.kafka.streams.processor.TimestampExtractor",
    "org.apache.kafka.streams.processor.TopicNameExtractor",
    "org.apache.kafka.streams.processor.StreamPartitioner",
    "org.apache.kafka.streams.processor.api.FixedKeyProcessor",
    "org.apache.kafka.streams.processor.api.Processor"
  ],
  "ClassesToAvoid": [
    "kafka.Kafka",
    "kafka.admin.ElectionTypeConverter",
    "kafka.admin.PatternTypeConverter",
    "kafka.admin.ZkSecurityMigrator$ZkSecurityMigratorOptions",
    "org.apache.kafka.clients.ClientRequest",
    "org.apache.kafka.clients.FetchSessionHandler",
    "org.apache.kafka.clients.KafkaClient",
    "org.apache.kafka.clients.NetworkClient",
    "org.apache.kafka.common.serialization.VoidSerializer",
    "org.apache.kafka.common.utils.Bytes$ByteArrayComparator",
    "org.apache.kafka.common.utils.ImplicitLinkedHashCollection",
    "org.apache.kafka.common.utils.ImplicitLinkedHashMultiCollection",
    "org.apache.kafka.common.utils.Java",
    "org.apache.kafka.common.metrics.stats.SampledStat$Sample",
    "org.apache.kafka.common.record.AbstractRecords",
    "org.apache.kafka.common.record.BaseRecords",
    "org.apache.kafka.common.record.CompressionRatioEstimator",
    "org.apache.kafka.common.record.ConvertedRecords",
    "org.apache.kafka.common.record.DefaultRecord",
    "org.apache.kafka.common.record.DefaultRecordsSend",
    "org.apache.kafka.common.record.EndTransactionMarker",
    "org.apache.kafka.common.record.FileRecords",
    "org.apache.kafka.common.record.LazyDownConversionRecordsSend",
    "org.apache.kafka.common.record.MemoryRecords",
    "org.apache.kafka.common.record.PartialDefaultRecord",
    "org.apache.kafka.common.record.Records",
    "org.apache.kafka.common.record.RecordsSend",
    "org.apache.kafka.connect.cli.AbstractConnectCli",
    "org.apache.kafka.connect.rest.ConnectRestExtensionContext",
    "org.apache.kafka.connect.rest.ConnectRestExtension",
    "org.apache.kafka.connect.storage.HeaderConverter",
    "org.apache.kafka.connect.storage.SimpleHeaderConverter",
    "org.apache.kafka.connect.util.SharedTopicAdmin",
    "org.apache.kafka.streams.kstream.NamedOperation",
    "org.apache.kafka.streams.kstream.TransformerSupplier",
    "org.apache.kafka.streams.kstream.ValueMapperWithKeySupplier",
    "org.apache.kafka.streams.kstream.ValueTransformerSupplier",
    "org.apache.kafka.streams.kstream.ValueTransformerWithKeySupplier",
    "org.apache.kafka.streams.processor.api.FixedKeyProcessorSupplier",
    "org.apache.kafka.streams.processor.api.ProcessorSupplier",
    "org.apache.kafka.tools.ClientCompatibilityTest$ClientCompatibilityTestDeserializer",
    "org.apache.kafka.tools.ConsumerPerformance$ConsumerPerfRebListener",
    "org.apache.kafka.tools.ThroughputThrottler",
    "org.apache.kafka.tools.VerifiableConsumer$RecordData",
    "org.apache.kafka.tools.VerifiableConsumer$RecordsConsumed",
    "org.apache.kafka.tools.reassign.LogDirMoveState",
    "org.apache.kafka.tools.reassign.PartitionReassignmentState",
    "org.apache.zookeeper.ZooKeeperMainWithTlsSupportForKafka",
    "org.apache.zookeeper.server.quorum.QuorumPeerMain"
  ]
}
```
