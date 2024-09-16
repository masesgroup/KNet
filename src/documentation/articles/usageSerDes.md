---
title: Serialization usage of .NET suite for Apache Kafka™
_description: Describes how to use serialization of .NET suite for Apache Kafka™
---

# KNet: Serializer/Deserializer

KNet comes with a base set of serializer and deserializer. Most of them are usable with primitives types (`bool`, `int`, etc) and array of `byte`s.

If the user wants to use structures types there are two ways:
  1. Creates types in Java and reflects them in C#
  2. Creates types in C# and extend the available serializer/deserializer

KNet suite offers some ready made serializer/deserializer usable with the specific APIs (KNetProducer/KNetConsumer).

The current available packages are:
  - [MASES.KNet.Serialization.Avro](https://www.nuget.org/packages/MASES.KNet.Serialization.Avro/): it is a serdes which uses [AVRO](https://en.wikipedia.org/wiki/Apache_Avro); till now is not ready.
  - [MASES.KNet.Serialization.Json](https://www.nuget.org/packages/MASES.KNet.Serialization.Json/): it is a serdes which uses [Json](https://en.wikipedia.org/wiki/JSON); till now it is at its first stage and it is based on general purpose API from:
    - .NET Framework: it uses [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json) package
    - .NET 6/8: it uses the Json which comes with the frameworks
  - [MASES.KNet.Serialization.MessagePack](https://www.nuget.org/packages/MASES.KNet.Serialization.MessagePack/): it is a serdes which uses [MessagePack](https://en.wikipedia.org/wiki/MessagePack); till now it is at its first stage and it is based on general purpose API from [MessagePack](https://www.nuget.org/packages/MessagePack) package
  - [MASES.KNet.Serialization.Protobuf](https://www.nuget.org/packages/MASES.KNet.Serialization.Protobuf/): it is a serdes which uses [Google.Protobuf](https://en.wikipedia.org/wiki/Protocol_Buffers); till now it is at its first stage and it is based on general purpose API from [Google.Protobuf](https://www.nuget.org/packages/Google.Protobuf) package

Starting from version 2.7.0, KNet comes with two kind of data exchange mechanisms:
- **Raw**: data exchanges, across JVM-CLR boundary, using `byte` array transfer and this is the standard used since last version
- **Buffered**: data exchanges, across JVM-CLR boundary, using `ByteBuffer` objects:
  - this version avoids a real data move, only references to `ByteBuffer` are exchanged
  - the serializer/deserializer shares, with the `ByteBuffer`, the memory pointers originating the information and the counterpart reads that memory without make copies

All available packages listed at the beginning comes with both versions and the user can choose its preferred one.

As example, let consider a type defined like the following one:

```c#
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
```

To manage it within C#, without create `TestType` in Java, an user can create:

- serializer (the body must be updated with the user serializer):
```c#
SerDesRaw<TestType> serializer = new SerDesRaw<TestType>()
{
    OnSerialize = (topic, type) => { return Array.Empty<byte>(); }
};
```
- deserializer (the body must be updated with the user deserializer):
```c#
SerDesRaw<TestType> deserializer = new SerDesRaw<TestType>()
{
    OnDeserialize = (topic, data) => { return new TestType(0); }
};
```

Otherwise the user can use a ready made class like in the following snippet:

```c#
ISerDesRaw<TestType> serdes = JsonSerDes.Value<TestType>.NewByteArraySerDes();
```

A single `JsonSerDes.ValueRaw` can be used in serialization and deserialization, and produce Json serialized data.

## Key and Value versions

The reader noticed that in the example was used `JsonSerDes.Value<T>().NewByteArraySerDes()`. It is a serializer/deserializer, based on `byte` array, generally used for values because it stores, within the record `Headers` information related to the value itself.

All packages listed above have multiple types based on the scope and data exchange mechanism:
- [Serialization Format].Key: key serializer/deserializer can manages data transfer using both `byte` array and `ByteBuffer`
- [Serialization Format].Value: value serializer/deserializer can manages data transfer using both `byte` array and `ByteBuffer`

where [Serialization format] depends on the serializatin package in use and the selection of the data transfer can be made from underlying code or can be requested from the user:
- `[Serialization Format].[Key or Value]<TData>.NewByteArraySerDes()`: returns an `ISerDesRaw<TData>`
- `[Serialization Format].[Key or Value]<TData>.NewByteBufferSerDes()`: returns an `ISerDesBuffered<TData>`

> [!TIP]
> As specified above, each serializer stores info within the `Headers` and this behavior is controlled from a property named `UseHeaders`.
> If the user writes a code like:
>
>```c#
> ISerDesRaw<TestType> serdes = JsonSerDes.Value<TestType>.NewByteArraySerDes();
> serdes.UseHeader = false;
>```
> The `ISerDesRaw<TestType>` instance does not writes the `Headers` and can be used both for key and value.

## Specific cases

Some kind of serializers extension have specific needs will be listed below.

### Avro serializer

The Avro serializer is based on [Apache.Avro](https://www.nuget.org/packages/Apache.Avro) package. The types managed are:
- Avro types managed using the Avro library are Avro **record**s which:
  - Shall have a parameterless constructor
  - Shall conform to [ISpecificRecord](https://avro.apache.org/docs/1.11.1/api/csharp/html/interfaceAvro_1_1Specific_1_1ISpecificRecord.html)

**NOTE**: simple types (the one that have an Apache Kafka™ default serializer) are not managed and will be refused

### MessagePack serializer

The MessagePack serializer is based on [MessagePack](https://www.nuget.org/packages/MessagePack) package. The types managed are:
- MessagePack types managed using the MessagePack library shall be MessagePack types.

**NOTE**: simple types (the one that have an Apche Kafka™ default serializer) are not managed and will be refused

### Protobuf serializer

The Protobuf serializer is based on [Google.Protobuf](https://www.nuget.org/packages/Google.Protobuf) package. The types managed are:
- Protobuf types managed using the Protobuf library shall be messages types which:
  - Shall have a parameterless constructor
  - Shall conform to [`IMessage<T>`](https://cloud.google.com/dotnet/docs/reference/Google.Protobuf/latest/Google.Protobuf.IMessage-1)

**NOTE**: simple types (the one that have an Apche Kafka™ default serializer) are not managed and will be refused
