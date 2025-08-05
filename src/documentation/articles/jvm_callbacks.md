---
title: JVM™ callbacks within .NET suite for Apache Kafka™ powered code
_description: Describes how to manage callbacks from JVM™ using the .NET suite for Apache Kafka™
---

# KNet: JVM™ callbacks

One of the features of [JCOBridge](https://www.jcobridge.com/), used in KNet, is the callback management from JVM™.
Many applications use the callback mechanism to be informed about events which happens during execution.
Apache Kakfa exposes many API which have callbacks in the parameters.
The Java™ code of a callback can be written with lambda expressions, but KNet cannot, it needs an object.

## KNet Callback internals

KNet is based on [JCOBridge](https://www.jcobridge.com/). JCOBridge as per its name is a bridge between the CLR (CoreCLR) and the JVM™.
Events, generally are expressed as interfaces in Java™, and a lambda expression is translated into an object at compile time. Otherwise the developer can implement a Java™ class which **implements** the interface: with JCOBridge the developer needs to follow a seamless approach.
In KNet some callbacks are ready made. In this tutorial the **Callback** interface (org.apache.kafka.clients.producer.Callback) will be taken as an example.
The concrete class implementing the interface is the following one:

```java
public final class CallbackImpl extends JCListener implements Callback {
    public CallbackImpl(String key) throws JCNativeException {
        super(key);
    }

    @Override
    public void onCompletion(org.apache.kafka.clients.producer.RecordMetadata metadata, Exception exception) {
        raiseEvent("onCompletion", metadata, exception);
    }
}
```

The structure follows the guidelines of JCOBridge:
* It **must** `extends` the base class `JCListener` (or `implements` the interface `IJCListener`): this is a constraint of JCOBridge; `JCListener` has many ready made methods; if the callback is not based on an interface the developer can `implements` the `IJCListener`;
* The concrete class **must** have at least a constructor accepting a String;
* Within the implementation of the interface method (in this case the method `onCompletion` of the `Callback` interface) the method `raiseEvent` informs the CLR that a method was raised using the specific key (**onCompletion** in this case) along with all associated objects:
  * If the interface has many methods each one must have its own `raiseEvent` call;
  * The key used from raiseEvent is not mandatory to be equal to the name of the calling method, it is only a convention for the mapping: this will be more clear looking at the C# code.

Now there is a concrete class within the JVM™ space. 
Going on to the CLR side a possible concrete class in C# is as the following one:

```c#
public class Callback : CLRListener
{
	public sealed override string JniClass => "org.mases.kafkabridge.clients.producer.CallbackImpl";

	readonly Action<RecordMetadata, JVMBridgeException> executionFunction = null;
	public virtual Action<RecordMetadata, JVMBridgeException> Execute { get { return executionFunction; } }
	public Callback(Action<RecordMetadata, JVMBridgeException> func = null)
	{
		if (func != null) executionFunction = func;
		else executionFunction = OnCompletion;

		AddEventHandler("onCompletion", new EventHandler<CLRListenerEventArgs<JVMBridgeEventData<RecordMetadata>>>(EventHandler));
	}

	void EventHandler(object sender, CLRListenerEventArgs<JVMBridgeEventData<RecordMetadata>> data)
	{
		var exception = data.EventData.ExtraData.Get(0) as IJavaObject;
		Execute(data.EventData.TypedEventData, JVMBridgeException.New(exception));
	}
	public virtual void OnCompletion(RecordMetadata metadata, JVMBridgeException exception) { }
}
```

The structure follows the guidelines of JCOBridge:
* It **must** `extends` the base class `CLRListener` : this is a constraint of JCOBridge; `CLRListener` contains all the functionality to handle events from the JVM™;
* The `JniClass` property informs the base class about the concrete class in JVM™ associated to this event handler;
* Within the constructor the method `AddEventHandler` registers a .NET `EventHandler` associated to the method in JVM™; look at the key string: **it is the same used from the JVM™**;
  * The costructor of the code above accept in input an `Action` which permits to write lambda expression in C#;
  * The code above associate a private handler with specific data type:
    * `CLRListenerEventArgs` is mandatory and it is used from `CLRListener`;
    * `JVMBridgeEventData` informs the subsystem that the first parameter inherits from a `JVMBridgeBase` class and must be treated accordingly;
    * `RecordMetadata` represents the CLR version of the corresponding `RecordMetadata` within the JVM™;
* On callback invocation (`onCompletion` in this case) the CLR will invoke `EventHandler`:
  * The first parameter is directly reported using the `TypedEventData` property;
  * The second parameter shall be managed differently in this case because it is an `Exception`:
    * JCOBridge has its own mechanism to translate the exception from the JVM™;
	* Parameters raised from JVM™, beyond the first, are available within `ExtraData` property;
	* The code extracts the first object (the second of the event) and converts it into a generic `IJavaObject`;
	* Invoking `JVMBridgeException.New(exception)` the subsystem reads the data from the real JVM™ exception and try to instantiate a valid exception, otherwise returns a generic `JVMBridgeException`;
	  * `JVMBridgeException.New(exception)` can return null if the extracted data is not an `IJavaObject` or it is null within the JVM™;
* Other pieces of the class are useful in other condition:
  * Creating a new class extending `Callback` class, the method `OnCompletion` can be overridden;
  * Otherwise to the property `Execute` can be associated to an handler;
    	
## KNet Callback lifecycle

The lifecycle of the callback managed from JCOBridge is slightly different from the standard one.
A `CLRListener` to be able to live without to be recovered from the Garbage Collector shall be registered. `CLRListener` do this automatically within the initialization (this behavior can be avoided with the property `AutoInit`).
So at the end of its use it must be disposed to avoid a resource leak. In the [Producer with Callback](usage.md) example there is a **using** clause and the class is instantiated only one time.
A correct approach is like the following:

```c#
using (var callback = new Callback((o1, o2) =>
{
	if (o2 != null) Console.WriteLine(o2.ToString());
	else Console.WriteLine($"Produced on topic {o1.Topic} at offset {o1.Offset}");
}))
{
	while (!resetEvent.WaitOne(0))
	{
		var record = new ProducerRecord<string, string>(topicToUse, i.ToString(), i.ToString());
		var result = producer.Send(record, callback);
		Console.WriteLine($"Producing: {record} with result: {result.Get()}");
		producer.Flush();
		i++;
	}
}
```

while an approach like the following one: 

```c#
var result = producer.Send(record, new Callback((o1, o2) =>
{
	if (o2 != null) Console.WriteLine(o2.ToString());
	else Console.WriteLine($"Produced on topic {o1.Topic} at offset {o1.Offset}");
}));
```

there are two main drawbacks:
* it creates a resource leak because the object cannot be programmatically disposed;
* on each cycle, the engine shall allocate the infrastructure to handle events from the JVM™.


 