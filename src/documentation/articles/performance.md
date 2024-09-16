---
title: Performance of .NET suite for Apache Kafka™
_description: Describes the performance evaluation of .NET suite for Apache Kafka™
---

# KNet: performance evaluation

To measure KNet performance specifc projects are available under the `tests` folder of the repository. The following chapters describe some initial considerations, the benchmark test programs, benchmark approach, results and final considerations.
The benchmarks are:
1. [Produce and Consume Benchmark](#produce-and-consume-benchmark)
2. [Roundtrip benchmark](#roundtrip-benchmark)

## Initial considerations

Apache Kafka™ is a client-server architecture which relies on the network for communication. 
The entire infrastructure performance depends on some elements:
  1. The HW where Apache Kafka™ server is running on: see https://kafka.apache.org/documentation/#hwandos for further information
  2. The settings of Apache Kafka™ server installation
  3. The network between clients and servers
  4. The client library with its configuration parameters
  5. The user application

All elements listed before have their relevance in the evaluation of the performance: surely the first 3 points are the ones with maximum impact.
The benchmark made in KNet try to focus on the point 3: the benchmarks of the points 1 and 2 are covered from other player. To concentrate on point 3:
- For points 1 and 2 the tests were done using an infrastructure based on SSD disks, high number of processors and LAN Gigabit ethernet connections: with this configuration the impact on tests from external conditions is reduced and statistically distributed.
- For point 4: it is covered creating an application that performs the same steps and each time apply the same configuration parameters.

With the considerations made in the previous chapter we are going to focus on the point 3: client library. 
An absolute approach cannot be followed: as stated before HW and network have an high impact, so the benchmark test program was designed with a compare approach.
Looking in the Apache Kafka™ clients page the client library which is under development is the one mantained from Confluent.
The benchmark was designed to compare performances between KNet and Confluent.Kafka™. The comparison between both libraries is listed below:
- KNet uses official JARs from The Apache Foundation while Confluent.Kafka™ is a layer over librdkafka;
- thread model and data enqueing is different;
- serializer/deserializer are different;
- the libraries share many configuration parameters.

## Produce and Consume Benchmark

The test analyze both produce and consume capability of KNet and Confluent.Kafka™, then compares results.

### Produce and Consume Benchmark test program

To create a well-done comparison some configuration parameters are set in the same way during each test: e.g. linger time, batch size, etc.
Others have different meaning: KNet use the concept of memory pool to store messages (bytes that fills the buffer), while Confluent.Kafka™ (i.e. librdkafka) can configure how many messages stores (maximum messages to be stored); to reduce the impact from these specific parameters the tests were made to finalize the send/receive so all messages shall be sent or received.

The tests:
- are divided in two different main areas: produce and consume;
- uses their own topic to avoid impacts from the previous tests: schema is {TopicPrefix}__{testName}__{length}__{testNum} where 
  - **TopicPrefix** is an user definible string (default is _testTopic_)
  - **testName** is KNET or CONF
  - **packets** is the number of packets
  - **length** is the payload length
  - **testNum** is the actual execution repetition
- to reduce impacts from different implementations of serializer/deserializer the most simple data types are used in the messages:
  - **key** is a long and represents the incremental ordinal of the message sent starting from 0 which is the first message sent;
  - **value** (payload) is a byte array of data built from the application so the data does not have to be manipulated from the library;
- the tests are repeated multiple times (with a command line specific option: Repeat) and alternate the usage of KNet and Confluent.Kafka™ to statistically distribute external effects;
- stores info in a CSV for other external processing;
- finally reports an aggregated info comparing total execution time of the overall tests done.

Many configuration parameters can be applied in the command-line to manipulate both configuration parameters and how tests are executed.

### Approach

The approach followed in the benchmark test is to:
1. create a topic
2. produce on it measuring the time elapsed; the produce cycle ends always with a flush to be sure that all data produced are sent to the server before stops any measure;
3. then consume the data produced in step 2 (checking or not the received data) until the number of records expected are received.

The produce cycle is like the following one:
- create an array with random data within it (note: the time elapsed in data creation is not measured to avoid to add application time on library measures);
- create message and send it: both of these are measured to verify how they impact on the test;
- finally execute a _flush_ and then stops the measure.

The consume cycle is like the following one:
- subscribe on topic;
- when the callback informs the application that the topic was assigned the measures are started;
- on every consume cycle the messages conuter is updated;
- when the number of expected messages are received the consumer is unsubscribe and the measures are stopped.

The cycles are repeated many times; the test repetition has a dual meaning: it creates a population of data for statistics purpose, meanwhile it represents burst of data produced/consumed from an user application.
Meanwhile many information are measured like the number of JNI calls (this is important for KNet) and, finally, an aggregated info related to the overrall time needed to perform the operations (produce/consume) of both libraies.
The information collected are analyzed with statistics in mind; for every test the application reports:
- Max value
- Min value
- Average
- Standard deviation
- Coefficient of Variation

These values are absolute and affected from the external conditions. To have a compare vision the application reports the percentile ratio between previous listed values:
- **a value less than 100% means a better performance of KNet**
- **a value higher than 100% means a better performance of Confluent.Kafka™**
- **a value around 100% means comparable performance of KNet and Confluent.Kafka™**

The most important are Average, Standard deviation and Coefficient of Variation.

### Benchmark results

The tests was done with:
- different payload length: from 100 bytes to 100 kbytes
- a set of 1000/10000 messages to have enough statistics data; we cannot go over: using 100000 messages Confluent.Kafka™ reports the same error of https://github.com/confluentinc/confluent-kafka-dotnet/issues/703 and KNet uses a lot of memeory;
- for each benchmark execution the tests are repeated at least 20 times.

The configuration is:
- Acks: None to avoid performance impacts from server side
- LingerMs: 100 ms
- BatchSize: 1000000
- MaxInFlight: 1000000
- SendBuffer: 32 Mb
- ReceiveBuffer: 32 Mb
- FetchMinBytes: 100000

Here below a set of results using 1000/10000 messages, in bold the results which are better using KNet 2.4.3:

- KNet/Confluent.Kafka™ Produce Average ratio percentage (SD ratio percentage):

|  | 100 bytes | 1000 bytes | 10000 bytes | 100000 bytes |
|:---:	|:---:	|:---:	|:---:	|:---:	|
| 1000 messages | 217,8 (193,16) | **82,5 (158,72)** | **84,45 (65,53)** | **86,78 (115,88)** |
| 10000 messages | 251,97 (357,5) | **73,4 (164,51)** | 104,41 (32,73) | **90,28 (155,2)** |

- KNet/Confluent.Kafka™ Consume Average ratio percentage (SD ratio percentage):

|  | 100 bytes | 1000 bytes | 10000 bytes | 100000 bytes |
|:---:	|:---:	|:---:	|:---:	|:---:	|
| 1000 messages | **22,09 (263,38)** | **6,39 (547,69)** | **67,44 (22,85)** | 122,77 (270,27) |
| 10000 messages | **30,51 (203,03)** | **17,88 (9,14)** | 117,37 (281,25) | 135,35 (828,3) |

#### Analysis

KNet Produce is more efficient when the length of packets is high: this is related to the overhead introduced from JVM method invocations. With 10000 messages and 10000 bytes the result is better with Confluent.Kafka™, we have not yet identified if some parameters are limiting KNet or really Conflent.Kafka™ is more efficient.

KNet Consume is more efficient when the length of packets is small; when the length of packets is higher Confluent.Kafka™ becomes more efficient, however less are the packets better KNet performs, so there is a kind of bottleneck to be identified which limits KNet efficency.

> [!NOTE]
> These are results from some tests done using the configuration reported in previous chapter. With different combination of parameters Confluent.Kafka™ can perform better than KNet in all tests. 

## Roundtrip Benchmark

The test analyze the ability of KNet and Confluent.Kafka™ to produce and consume from a topic. The test is done within the same process using different threads becuase it is based on the machine [TSC](https://en.wikipedia.org/wiki/Time_Stamp_Counter).

### Roundtrip Benchmark test program

To create a well-done comparison some configuration parameters are set in the same way during each test: e.g. linger time, batch size, etc.
Others have different meaning: KNet use the concept of memory pool to store messages (bytes that fills the buffer), while Confluent.Kafka™ (i.e. librdkafka) can configure how many messages stores (maximum messages to be stored); to reduce the impact from these specific parameters the tests were made to finalize the send/receive so all messages shall be sent or received.

The tests:
- are divided in two different main areas: produce and consume;
- uses their own topic to avoid impacts from the previous tests: schema is {TopicPrefix}__{testName}__{length}__{testNum} where 
  - **TopicPrefix** is an user definible string (default is _testTopic_)
  - **testName** is KNET or CONF
  - **packets** is the number of packets
  - **length** is the payload length
  - **testNum** is the actual execution repetition
- to reduce impacts from different implementations of serializer/deserializer the most simple data types are used in the messages:
  - **key** is a long and represents the machine tick counter when the message is generated, this value will be compared with the tick counter when the message will be received during consume;
  - **value** (payload) is a byte array of data built from the application so the data does not have to be manipulated from the library;
- the tests are repeated multiple times (with a command line specific option: Repeat) and alternate the usage of KNet and Confluent.Kafka™ to statistically distribute external effects;
- stores info in a CSV for other external processing;
- finally reports an aggregated info comparing total execution time of the overall tests done.

Many configuration parameters can be applied in the command-line to manipulate both configuration parameters and how tests are executed.

### Approach

The approach followed in the benchmark test is to:
1. create a topic
2. start consumption from the topic in a separated thread
3. when the assignment is done from Apache Kafka™ the produce starts
4. the produce cycle produces messages and put in the key the current TSC ticks, the cycle produces the number of messages set on command line then waits the end of consumption
5. the consumer thread receives the messages from Apache Kafka™ and, for each message, compares the key (originating ticks) with current system ticks: **this measure represents the ticks elapsed from produce to consume**
6. the measures are stored in a list to be analyzed later

The produce cycle is like the following one:
- create an array with random data within it;
- create message, associated current ticks to the key and send it;
- finally execute a _flush_ and then wait the end of consumption.

The consume cycle is like the following one:
- subscribe on topic;
- when the callback informs the application that the topic was assigned the produce cycle starts;
- on every consume cycle:
  - the ticks elapsed are measured and stored;
  - the messages conuter is updated;
- when the number of expected messages are received the consumer is unsubscribe and the measures are stopped.

The cycles are repeated many times; the test repetition has a dual meaning: it creates a population of data for statistics purpose, meanwhile it represents burst of data produced/consumed from an user application.
Meanwhile many information are measured like the number of JNI calls (this is important for KNet) and, finally, an aggregated info related to the overrall time needed to perform the operations (produce/consume) of both libraies.
The information collected are analyzed with statistics in mind; for every test the application reports:
- Max value
- Min value
- Average
- Standard deviation
- Coefficient of Variation

These values are absolute and affected from the external conditions. To have a compare vision the application reports the percentile ratio between previous listed values:
- **a value less than 100% means a better performance of KNet**
- **a value higher than 100% means a better performance of Confluent.Kafka™**
- **a value around 100% means comparable performance of KNet and Confluent.Kafka™**

The most important are Average, Standard deviation and Coefficient of Variation.

### Benchmark results

The tests was done with:
- different payload length: from 100 bytes to 100 kbytes
- a set of 1000/10000 messages to have enough statistics data; we cannot go over: using 100000 messages Confluent.Kafka™ reports the same error of https://github.com/confluentinc/confluent-kafka-dotnet/issues/703 and KNet uses a lot of memeory;
- for each benchmark execution the tests are repeated at least 20 times.

The configuration is:
- Acks: None to avoid performance impacts from server side
- LingerMs: 100 ms
- BatchSize: 1000000
- MaxInFlight: 1000000
- SendBuffer: 32 Mb
- ReceiveBuffer: 32 Mb
- FetchMinBytes: 100000

Here below a set of results using 1000/10000 messages, in bold the results which are better using KNet 2.4.3:

- KNet/Confluent.Kafka™ Roundtrip Average ratio percentage (SD ratio percentage):

|  | 100 bytes | 1000 bytes | 10000 bytes | 100000 bytes |
|:---:	|:---:	|:---:	|:---:	|:---:	|
| 1000 messages | **3,82 (6,86)** | **4,37 (7,34)** | **9,08 (12,33)** | **26,68 (20,42)** |
| 10000 messages | **18,49 (21,33)** | **16,78 (33,28)** | **32,28 (34,64)** | **48,28 (53,39)** |

#### Analysis

Looking at the above table KNet performs better than Confluent.Kafka™.

> [!NOTE]
> These are results from some tests done using the configuration reported in previous chapter. With different combination of parameters Confluent.Kafka™ can perform better than KNet in all tests. 

## Final considerations

The KNet library performs better when the massages are larger; when the messages are small Confluent.Kafka™ performs better.
KNet suffers the JNI interface overhead needed to performs the operations (the user can activate JNI calls measurement): the evidence comes from the difference between KNetProducer and KafkaProducer (without _UseKNetProducer_ command-line switch).
Using KNetProducer the numbers of JNI invocation are less than using KafkaProducer, so reducing the number of JNI calls have a great impact on overall performance.
The same consideration can be applied on the consume side: KNetConsumer does not reduce the impact of JNI interface and it does not give any great improvement.
The JNI interface has an impact even when the number of messages is high because during processing the Garbage Collector is activated many times increasing the JNI overhead.

Another option to be considered in consumption is related to _UsePrefetch_: it activates an external thread to execute the methods on JVM while the main thread iterates over records; this behavior helps to reduce the impact on main iterator coming from the JVM invocations:
```C#
var records = consumer.Poll(duration);
if (UsePrefetch)
{
    foreach (var item in records.WithPrefetch().WithThread())
    {
        // executes stuff on item
    }
}
```
