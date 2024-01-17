---
title: Streams SDK of .NET suite for Apache Kafka
_description: Describes how to use Streams SDK of .NET suite for Apache Kafka
---

# KNet: Streams SDK

This is only a quick introduction to KNet Streams SDK, many other information related to Apache Kafka Streams can be found at the following links: https://kafka.apache.org/documentation/#streams and https://kafka.apache.org/documentation/streams/

## General 

The KNet Streams SDK is a set of API which expose, in .NET, the one available in Apache Kafka Streams and adds the feature to directly manages serializable types of .NET:
- The implementation is backed by a standard Apache Kafka Streams which is instructed to work with raw data (i.e. array of bytes).
- The data are exposed, in .NET, using the types assigned, most of translation jobs are supported by [KNet serializers](usageSerDes.md).

## API set

The available classes are under the following namespaces:
- **MASES.KNet.Streams**: covers _org.apache.kafka.streams_ Java package
- **MASES.KNet.Streams.Kstream**: covers _org.apache.kafka.streams.kstream_ Java package
- **MASES.KNet.Streams.Processor**: covers _org.apache.kafka.streams.processor_ Java package
- **MASES.KNet.Streams.Processor.Api**: covers _org.apache.kafka.streams.processor.api_ Java package
- **MASES.KNet.Streams.State**: covers _org.apache.kafka.streams.state_ Java package
- **MASES.KNet.Streams.Utils**: adds some useful functions

All KNet Streams SDK APIs starts with the KNet prefix to avoid confusion during development; some examples are:
- _org.apache.kafka.streams.KafkaStreams_ is managed from **MASES.KNet.Streams.KNetStreams**
- _org.apache.kafka.streams.state.KeyValueIterator<K, V>_ is managed from **MASES.KNet.Streams.State.KNetStreamsKNetKeyValueIterator<TKey, TValue>** applying byte[] on both K and V on _org.apache.kafka.streams.state.KeyValueIterator<K, V>_; there are special cases for this, and other classes, to manage different JVM types:
  - **MASES.KNet.Streams.State.KNetTimestampedKeyValueIterator<TKey, TValue>** uses an _org.apache.kafka.streams.state.KeyValueIterator<K, V>_ applying byte[] on K and _org.apache.kafka.streams.state.ValueAndTimestamp<byte[]>_ on V;
  - **MASES.KNet.Streams.State.KNetTimestampedWindowedKeyValueIterator<TKey, TValue>** uses an _org.apache.kafka.streams.state.KeyValueIterator<K, V>_ applying _org.apache.kafka.streams.kstream.Windowed<byte[]>_ on K and _org.apache.kafka.streams.state.ValueAndTimestamp<byte[]>_ on V;

**Current APIs cover a subset of the full APIs available in Apache Kafka Streams and some classes are only placeholder for some implemented APIs.**

## Examples

### Simple types example

Below a simple usage example of the APIs available till now:

```C#
string topicName = "topic-input";
string storageId = "myStorage";

StreamsConfigBuilder streamsConfig = StreamsConfigBuilder.Create();
KNetStreamsBuilder builder = new KNetStreamsBuilder(streamsConfig);

Org.Apache.Kafka.Streams.State.KeyValueBytesStoreSupplier storeSupplier = Org.Apache.Kafka.Streams.State.Stores.InMemoryKeyValueStore(storageId);
KNetMaterialized<string, string> materialized = KNetMaterialized<string, string>.As(storeSupplier);
KNetGlobalKTable<string, string> globalTable = builder.GlobalTable(topicName, materialized);
KNetTopology topology = builder.Build();
KNetStreams streams = new KNetStreams(topology, streamsConfig);

streams.Start();

```

The above example uses simple type, i.e. `string`, as data stored within the topic.

### Complex types example

A more complex example is the one below where the value is a serializable .NET class:

```C#
public class TestType
{
    public TestType(int i)
    {
        name = description = value = i.ToString();
    }

    public string name;
    public string description;
    public string value;

    public override string ToString()
    {
        return $"name {name} - description {description} - value {value}";
    }
}


string topicName = "topic-input";
string storageId = "myStorage";

StreamsConfigBuilder streamsConfig = StreamsConfigBuilder.Create();
// streamsConfig.KNetKeySerDes = typeof(JsonSerDes.Key<>); // needed for complex keys
streamsConfig.KNetValueSerDes = typeof(JsonSerDes.Value<>);

KNetStreamsBuilder builder = new KNetStreamsBuilder(streamsConfig);

Org.Apache.Kafka.Streams.State.KeyValueBytesStoreSupplier storeSupplier = Org.Apache.Kafka.Streams.State.Stores.InMemoryKeyValueStore(storageId);
KNetMaterialized<int, TestType> materialized = KNetMaterialized<int, TestType>.As(storeSupplier);
KNetGlobalKTable<int, TestType> globalTable = builder.GlobalTable(topicName, materialized);
KNetTopology topology = builder.Build();
KNetStreams streams = new KNetStreams(topology, streamsConfig);

streams.Start();

```

The above example uses a complex type for value, i.e. `TestType`, as data stored within the topic. The selected serializer is the JSON serializer (`JsonSerDes.Value<V>`) applied over `StreamsConfigBuilder` instance.
If even the key needs a complex type just uncomment the line with `streamsConfig.KNetKeySerDes = typeof(JsonSerDes.Key<>);` and replace the key type with your custom key type.
