---
title: APIs extendibility of .NET suite for Apache Kafka™
_description: Describes how to extend available APIs of .NET suite for Apache Kafka™
---

# KNet: APIs extendibility

What to do if an API was not yet implemented? The simplest answer is: help us to make this product reacher :-)
Anyway there is another answer which is not available with other products: Dynamic code and programmatically API access.

With **JCOBridge** a developer can use some properties to manage objects in the JVM™. 
Each KNet class implemented contains some methods and two properties: a direct and a dynamic accessor able to analyze the JVM™ class and executes the code.
So it is not necessary at all to have the methods be ready to be used.

## When a method is not available

Let's go with an example of a ready made API available in `KafkaProducer`:

```C#
public void BeginTransaction()
{
	IExecute("beginTransaction");
}
```

This is a void method, using **IExecute** the user of the library can invoke the `BeginTransaction` method on the class. Anyway the developer can invoke the internal method directly from the instance of the object:
```C#
KafkaProducer producer = new KafkaProducer(...);

producer.IExecute("beginTransaction");
```

`beginTransaction` can be replaced with any method (with or without parameters) of the class (`KafkaProducer` was only an example).

## When a class is not available

In a more compex scenario the method can return back objects. We start again from a ready made API:

```C#
public Future<RecordMetadata> Send(ProducerRecord record)
{
	return New<Future<RecordMetadata>>("send", record.Instance);
}
```

in this case the method accept in input a ready made class `ProducerRecord` and returns a ready made `Future<RecordMetadata>`. From a user point of view the C# and Java™ method behave the same.

### Return class is not available

Now consider that the returned data type (`Future<RecordMetadata>`) is not yet implemented; a solution on this problem is to use directly the `send` Java method like in the following code snippet does:
```C#
KafkaProducer producer = new KafkaProducer(...);
ProducerRecord record = new ProducerRecord(...);
var dynFuture = producer.IExecute("send", record.Instance); // the returned object is a dynamic object reference of the Future object in Java
var dynRecordMetadata = dynFuture.get();  // the returned object is a dynamic object reference of the RecordMetadata object in Java

// then the developer can access any method of the RecordMetadata using dynRecordMetadata

bool hasOffset = dynRecordMetadata.hasOffset();

```

The example above consider the classes `Future` and `RecordMetadata` not implemented yet. Anyway them exists in JVM™.

### Input and Return class are not available

If even the input class is not available the solution is like the following:

```C#
KafkaProducer producer = new KafkaProducer(...);
var dynProducerRecord = producer.JVM.New("ProducerRecord", ....); // the returned object is a dynamic object reference of the ProducerRecord object in Java
var dynFuture = producer.IExecute("send", dynProducerRecord); // the returned object is a dynamic object reference of the Future object in Java
var dynRecordMetadata = dynFuture.get();  // the returned object is a dynamic object reference of the RecordMetadata object in Java

// then the developer can access any method of the RecordMetadata using dynRecordMetadata

bool hasOffset = dynRecordMetadata.hasOffset();

```

The example above consider that even the class `ProducerRecord` is not implemented yet. Anyway it exists in JVM™.
Each object, like `KafkaProducer` instance, exposes (hidden in the editor) two properties:
* **JVM** which access the JVM™ using methods;
* **DynJVM** which access the JVM™ using the Dynamic engine.

Using the properties it is possible to instruct the JVM™ about the action to be done.

### Anything is not available

If no classes are available the solution comes from the global accessor available in JCOBridge and the code snippet is like the following one:

```C#
var dynKafkaProducer = JCOBridge.Global.JVM.New("KafkaProducer", ...); // the returned object is a dynamic object reference of the KafkaProducer object in Java
var dynProducerRecord = JCOBridge.Global.JVM.New("ProducerRecord", ....); // the returned object is a dynamic object reference of the ProducerRecord object in Java
var dynFuture = dynKafkaProducer.send(dynProducerRecord); // the returned object is a dynamic object reference of the Future object in Java
var dynRecordMetadata = dynFuture.get();  // the returned object is a dynamic object reference of the RecordMetadata object in Java

// then the developer can access any method of the RecordMetadata using dynRecordMetadata

bool hasOffset = dynRecordMetadata.hasOffset();

```

The example above consider that even the class `KafkaProducer` is not implemented yet. Anyway it exists in JVM™.
In previous chapter the tutorial reports about two hidden properties in each object; the properties on each class are just an useful reference to the real one available in `JCOBridge.Global`:
* **JVM** which access the JVM™ using methods;
* **DynJVM** which access the JVM™ using the Dynamic engine.

Using the properties it is possible to instruct the JVM™ about the action to be done.

### Call a method dynamically

Look at the simple example below:

```C#

var consumer = new KafkaConsumer<string, string>(props);
var topPart = consumer.JVM.New("TopicPartition", "myTopic", 0); // the returned object is a dynamic object reference of the TopicPartition object in Java
var result = consumer.DynInstance.committed(topPart); // this line invokes dynamically the committed on the instance of the KafkaConsumer
```

The example above consider the class `TopicPartition` not implemented yet. Anyway it exists in JVM™.
As exposed before, each object, like `KafkaConsumer` instance, exposes (hidden in the editor) two properties.

Explaining the code:
* The first line creates a JVM™ object in C# style: `KafkaConsumer` lives in the CLR and has its counterpart in the JVM™.
* The second line requests to the JVM™ to allocate a `TopicPartition` object with two parameters.
* This resulting object (`topPart`) is used in the third line as parameter of the `committed` method invocation.
* The `result` is a **dynamic** object that can be used to extract data or invokes other methods.

## API exendibility limitation

Starting from the assumption that JCOBridge does not make any code injection, or compilation, within JVM™ side, the actual limitation is related to something missing within the JVM™.
In the [JVM callbacks](jvm_callbacks.md) article there is an explanation of how works callbacks.
**The callback feature needs a concrete class in the JVM™ and if it does not exist there is no way to use it from KNet.**
