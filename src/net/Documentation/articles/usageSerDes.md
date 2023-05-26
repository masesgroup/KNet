# KNet: Serializer/Deserializer

KNet comes with a base set of serializer and deserializer. Most of them are usable with primitives types (bool, int, etc) and array of bytes.

If the user wants to use structures types there are two ways:
  1. Creates types in Java and reflects them in C#
  2. Creates types in C# and extend the available serializer/deserializer

KNet suite offers some ready made serializer/deserializer usable with the specific APIs (KNetProducer/KNetConsumer).

The current available packages are:
  - [MASES.KNet.Serialization.Avro](https://www.nuget.org/packages/MASES.KNet.Serialization.Avro/): it is a serdes which uses [AVRO](https://en.wikipedia.org/wiki/Apache_Avro); till now is not ready.
  - [MASES.KNet.Serialization.Json](https://www.nuget.org/packages/MASES.KNet.Serialization.Json/): it is a serdes which uses [Json](https://en.wikipedia.org/wiki/JSON); till now it is at its first stage and it is based on general purpose API from:
    - .NET Framework: it uses [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json) package
    - .NET 6/7: it uses the Json which comes with the frameworks
  - [MASES.KNet.Serialization.MessagePack](https://www.nuget.org/packages/MASES.KNet.Serialization.MessagePack/): it is a serdes which uses [MessagePack](https://en.wikipedia.org/wiki/MessagePack); till now it is at its first stage and it is based on general purpose API from [MessagePack](https://www.nuget.org/packages/MessagePack) package
  - [MASES.KNet.Serialization.Protobuf](https://www.nuget.org/packages/MASES.KNet.Serialization.Protobuf/): it is a serdes which uses [Google.Protobuf](https://en.wikipedia.org/wiki/Protocol_Buffers); till now it is at its first stage and it is based on general purpose API from [Google.Protobuf](https://www.nuget.org/packages/Google.Protobuf) package

Let consider a type defined like the following one:

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
KNetSerDes<TestType> serializer = new KNetSerDes<TestType>((topic, type) => { return new byte[0]; });
```
- deserializer (the body must be updated with the user deserializer):
```c#
KNetSerDes<TestType> deserializer = new KNetSerDes<TestType>((topic, data) => { return new TestType(0); });
```

Otherwise can use ready made classes like the following:

```c#
KNetSerDes<TestType> serdes = new JsonSerDes<TestType>();
```
which can be used in serialization and deserialization, and produce Json serialized data.

