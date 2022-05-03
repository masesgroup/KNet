# KNet performance

To measure KNet performance a specifc project is available under the `tests` folder of the repository. The following chapters describe some initial considerations, the benchmark test programs, benchmark approach, results and final considerations.

## Initial considerations

Apache Kafka is a client-server architecture which relies on the network for communication. 
The entire infrastructure performance depends on some elements:
  1. The HW where Apache Kafka server is running on: see https://kafka.apache.org/documentation/#hwandos for further information
  2. The network between clients and servers
  3. The client library with its configuration parameters
  4. The user application

All elements listed before have their relevance in the evaluation of the performance: surely the first 3 points are the ones with maximum impact.
The benchmark made in KNet try to focus on the point 3: the benchmarks of the points 1 and 2 are covered from other player. To concentrate on point 3:
- For points 1 and 2 the tests were done using an infrastructure based on SSD disks, high number of processors and LAN Gigabit ethernet connections: with this configuration the impact on tests from external conditions is reduced and statistically distributed.
- For point 4: it is covered creating an application that performs the same steps and each time apply the same configuration parameters.

## Benchmark test program

With the considerations made in the previous chapter we are going to focus on the point 3: client library. 
An absolute approach cannot be followed: as stated before HW and network have an high impact, so the benchmark test program was designed with a compare approach.
Looking in the Apche Kafka clients page the client library which is under development is the one mantained from Confluent.
The benchmark was designed to compare performances between KNet and Confluent.Kafka. The comparison between both libraries is listed below:
- KNet uses official JARs from The Apache Foundation while Confluent.Kafka is a layer over librdkafka;
- thread model and data enqueing is different;
- serializer/deserializer are different;
- the libraries share many configuration parameters;

To create a well-done comparison some configuration parameters are set in the same way during each test: e.g. linger time, batch size, etc.
Others have different meaning: KNet use the concept of memory pool to store messages (bytes that fills the buffer), while Confluent.Kafka (i.e. librdkafka) can configure how many messages stores (maximum messages to be stored); to reduce the impact from these specific parameters the tests were made to finalize the send/receive so all messages shall be sent or received.

The tests:
- are divided in two different main areas: produce and consume;
- uses their own topic to avoid impacts from the previous tests: schema is {TopicPrefix}__{testName}__{length}__{testNum} where 
  - **TopicPrefix** is an user definible string (default is _testTopic_
  - **testName** is KNET or CONF
  - **length** is the payload length
  - **testNum** is the actual execution repetition
- to reduce impacts from different implementations of serializer/deserializer the most simple data types are used in the messages:
  - **key** is an integer and represents the incremental ordinal of the message sent starting from 0 which is the first message sent;
  - **value** (payload) is a byte array of data built from the application so the data does not have to be manipulated from the library;
- the tests are repeated multiple times (with a command line specific option: Repeat) and alternate the usage of KNet and Confluent.Kafka to statistically distribute external effects;
- stores info in a CSV for other external processing;
- finally reports an aggregated info comparing total execution time of the overall tests done.

Many configuration parameters can be applied in the command-line to manipulate both configuration parameters and how tests are executed.

## Benchmark approach

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
Meanwhile are measured many information like the number of JNI calls (this is important for KNet) and, finally, an aggregated info related to the overrall time needed to perform the operations (produce/consume) of both libraies.
The information collected are analyzed with statistics in mind; for every test the application reports:
- Max value
- Min value
- Average
- Standard deviation
- Coefficient of Variation

These values are absolute and affected from the external conditions. To have a compare vision the application reports the percentile ratio between previous listed values:
- **a value less than 100% means a better performance of KNet**
- **a value higher than 100% means a better performance of Confluent.Kafka**
- **a value around 100% means comparable performance of KNet and Confluent.Kafka**

The most important are Average, Standard deviation and Coefficient of Variation.

## Benchmark results

The tests was done with:
- different messages length varying the payload length: from 10 bytes to 100 kbytes
- different number of messages for each benchmark execution: from 10 to 10000 messages;
- for each benchmark execution the tests are repeated at least 20 times.

The configuration is:
- LingerMs: 100 ms
- BatchSize: 1000000
- MaxInFlight: 1000000
- SendBuffer: 32 Mb
- ReceiveBuffer: 32 Mb
- FetchMinBytes: 100000

Here below a set of results, in bold the results which are better using KNet:

- KNet/Confluent.Kafka Produce Average ratio percentage (SD ratio percentage):

|  | 10 bytes | 100 bytes | 1000 bytes | 10000 bytes | 100000 bytes |
|---	|---	|---	|---	|---	|---	|
| 10 messages | **9,04 (4,34)** | **5,47 (3,1)** | **15,45 (5,29)** | **7,54 (4,38)** | **19,73 (4,23)** |
| 100 messages | **18,9 (6,29)** | **38,1 (8,1)** | **30,34 (5,44)** | **26 (3,04)** | **69,4 (13,09)** |
| 1000 messages | 197,73 (10,54) | 109,92 (6,13) | **57,6 (7,32)** | **52,71 (8,17)** | **75,76 (43,7)** |
| 10000 messages | 2102,28 (736,54) | 796,84 (514,28) | 173,39 (401,76) | 123,62 (620,46) | **99,5 (108,3)** |

- KNet/Confluent.Kafka Consume Average ratio percentage (SD ratio percentage):

|  | 10 bytes | 100 bytes | 1000 bytes | 10000 bytes | 100000 bytes |
|---	|---	|---	|---	|---	|---	|
| 10 messages | **85,93 (399,84)**| **85,41 (282,85)** | **85,14 (297,98)** | **24,07 (229,23)** | **36,23 (285,77)** |
| 100 messages | **94,54 (479,13)** | **94,7 (287,78)** | **68,49 (389,25)** | **71,97 (276,56)** | 108,57 (89,45) |
| 1000 messages | 192,27 (906,94) | 521,86 (867,93) | 103,62 (1854,84) | 255,52 (287,33) | 163,24 (124,23) |
| 10000 messages | 9153,56 (77543,04) | 7948,76 (69701,75) | 3848,12 (23910,64) | 706,83 (3905,89) | 213,46 (1013,16) |

### Average ratio percentage 

Looking at the above table KNet performs better than Confluent.Kafka with burst of few messages (10/100 messages); if the number of messages is higher (e.g. 1000/10000) KNet performs better when the size of the messages is large.
The best produce performance was obtained with 10 messages of 100, or 10000, bytes: KNet is 20 times fast than Confluent.Kafka.
The best consume performance was obtained with 10 messages of 10000 bytes: KNet is 4 times fast than Confluent.Kafka.

### SD ratio percentage

Looking at value within the brackets, that represents the ratio of the SD, it is possible to highlight that:
- in produce KNet has more stable measures except when the number of messages is high (10000 messages);
- in consume KNet has less stable measures.

## Final considerations

The KNet library performs better when the massages are larger; when the messages are small Confluent.Kafka performs better.
From some measurement done KNet suffers the JNI interface overhead needed to performs the operations (the user can activate JNI calls measurement): the evidence comes from the difference between KNetProducer and KafkaProducer (without _UseKNetProducer_ command-line switch).
Using KNetProducer the numbers of JNI invocation are less than using KafkaProducer, so reducing the number of JNI calls have a great impact on overall performance.
The same consideration can be applied on the consume side: KNetConsumer does not reduce the impact of JNI interface and it does not give any great improvement.
The JNI interface has an impact even when the number of messages is high because during processing the Garbage Collector is activated many times increasing the JNI overhead.

**With the upcoming JCOBridge major version the JNI impact will be reduced and KNet will get extra performance both in produce and in consume.**
