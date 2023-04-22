% KNet performance

# KNet: performance evaluation

To measure KNet performance specifc projects are available under the `tests` folder of the repository. The following chapters describe some initial considerations, the benchmark test programs, benchmark approach, results and final considerations.
The benchmarks are:
1. [Produce and Consume Benchmark](#produce-and-consume-benchmark)
2. [Roundtrip benchmark](#roundtrip-benchmark)

## Initial considerations

Apache Kafka is a client-server architecture which relies on the network for communication. 
The entire infrastructure performance depends on some elements:
  1. The HW where Apache Kafka server is running on: see https://kafka.apache.org/documentation/#hwandos for further information
  2. The settings of Apache Kafka server installation
  3. The network between clients and servers
  4. The client library with its configuration parameters
  5. The user application

All elements listed before have their relevance in the evaluation of the performance: surely the first 3 points are the ones with maximum impact.
The benchmark made in KNet try to focus on the point 3: the benchmarks of the points 1 and 2 are covered from other player. To concentrate on point 3:
- For points 1 and 2 the tests were done using an infrastructure based on SSD disks, high number of processors and LAN Gigabit ethernet connections: with this configuration the impact on tests from external conditions is reduced and statistically distributed.
- For point 4: it is covered creating an application that performs the same steps and each time apply the same configuration parameters.

With the considerations made in the previous chapter we are going to focus on the point 3: client library. 
An absolute approach cannot be followed: as stated before HW and network have an high impact, so the benchmark test program was designed with a compare approach.
Looking in the Apache Kafka clients page the client library which is under development is the one mantained from Confluent.
The benchmark was designed to compare performances between KNet and Confluent.Kafka. The comparison between both libraries is listed below:
- KNet uses official JARs from The Apache Foundation while Confluent.Kafka is a layer over librdkafka;
- thread model and data enqueing is different;
- serializer/deserializer are different;
- the libraries share many configuration parameters.

## Produce and Consume Benchmark

The test analyze both produce and consume capability of KNet and Confluent.Kafka, then compares results.

### Produce and Consume Benchmark test program

To create a well-done comparison some configuration parameters are set in the same way during each test: e.g. linger time, batch size, etc.
Others have different meaning: KNet use the concept of memory pool to store messages (bytes that fills the buffer), while Confluent.Kafka (i.e. librdkafka) can configure how many messages stores (maximum messages to be stored); to reduce the impact from these specific parameters the tests were made to finalize the send/receive so all messages shall be sent or received.

The tests:
- are divided in two different main areas: produce and consume;
- uses their own topic to avoid impacts from the previous tests: schema is {TopicPrefix}__{testName}__{length}__{testNum} where 
  - **TopicPrefix** is an user definible string (default is _testTopic_)
  - **testName** is KNET or CONF
  - **length** is the payload length
  - **testNum** is the actual execution repetition
- to reduce impacts from different implementations of serializer/deserializer the most simple data types are used in the messages:
  - **key** is a long and represents the incremental ordinal of the message sent starting from 0 which is the first message sent;
  - **value** (payload) is a byte array of data built from the application so the data does not have to be manipulated from the library;
- the tests are repeated multiple times (with a command line specific option: Repeat) and alternate the usage of KNet and Confluent.Kafka to statistically distribute external effects;
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
- **a value higher than 100% means a better performance of Confluent.Kafka**
- **a value around 100% means comparable performance of KNet and Confluent.Kafka**

The most important are Average, Standard deviation and Coefficient of Variation.

### Benchmark results

The tests was done with:
- different messages length varying the payload length: from 10 bytes to 100 kbytes
- different number of messages for each benchmark execution: from 10 to 10000 messages;
- for each benchmark execution the tests are repeated at least 20 times.

The configuration is:
- Acks: None to avoid performance impacts from server side
- LingerMs: 100 ms
- BatchSize: 1000000
- MaxInFlight: 1000000
- SendBuffer: 32 Mb
- ReceiveBuffer: 32 Mb
- FetchMinBytes: 100000

Here below a set of results, in bold the results which are better using KNet (the table reports the changes from previous tests and current tests done with JNet 1.5.2 and JCOBridge 2.5.3):

- KNet/Confluent.Kafka Produce Average ratio percentage (SD ratio percentage):

|  | 10 bytes | 100 bytes | 1000 bytes | 10000 bytes | 100000 bytes |
|:---:	|:---:	|:---:	|:---:	|:---:	|:---:	|
| 10 messages | **9,04 (4,34)** -> **4,26 (0,57)** | **5,47 (3,1)** -> **6,94 (0,8)** | **15,45 (5,29)** -> **10,9 (2,27)** | **7,54 (4,38)** -> **2,78 (0,55)** | **19,73 (4,23)** -> **13,81 (4,07)** |
| 100 messages | **18,9 (6,29)** -> **11,58 (1,43)** | **38,1 (8,1)** -> **11,23 (1,7)** | **30,34 (5,44)** -> **15,22 (3,69)** | **26 (3,04)** -> **13,69 (1,64)** | **69,4 (13,09)** -> **41,13 (12,36)** |
| 1000 messages | 197,73 (10,54) -> **33,69 (3,6)** | 109,92 (6,13) -> **48,05 (6,08)** | **57,6 (7,32)** -> **25,03 (3,66)** | **52,71 (8,17)** -> **34,57 (16,43)** | **75,76 (43,7)** -> **74,46 (43,53)** |
| 10000 messages | 2102,28 (736,54) -> 1172,54 (534,18) | 796,84 (514,28) -> 545,73 (356,43) | 173,39 (401,76) -> 100,34 (289,93) | 123,62 (620,46) ->  **88,14 (150,15)** | **99,5 (108,3)** -> **91,52 (88,36)** |

- KNet/Confluent.Kafka Consume Average ratio percentage (SD ratio percentage):

|  | 10 bytes | 100 bytes | 1000 bytes | 10000 bytes | 100000 bytes |
|:---:	|:---:	|:---:	|:---:	|:---:	|:---:	|
| 10 messages | **85,93 (399,84)** -> **84,38 (160,69)** | **85,41 (282,85)** -> **83,68 (25,15)** | **85,14 (297,98)** -> **83,79 (106,68)** | **24,07 (229,23)** -> **13,69 (36,18)** | **36,23 (285,77)** -> **29,18 (137,24)** |
| 100 messages | **94,54 (479,13)** -> **85,32 (265,09)** | **94,7 (287,78)** -> **85,56 (432,38)** | **68,49 (389,25)** -> **17,63 (30,98)** | **71,97 (276,56)** -> **33,44 (150,89)** | 108,57 (89,45) -> 144,57 (133,34) |
| 1000 messages | 192,27 (906,94) -> **92,3 (237,25)** | 521,86 (867,93) -> **87,52 (668,81)** | 103,62 (1854,84) -> **16,54 (232,94)** | 255,52 (287,33) -> 183,56 (146,66) | 163,24 (124,23) -> 154,91 (246,38) |
| 10000 messages | 9153,56 (77543,04) -> 654,7 (962) | 7948,76 (69701,75) -> 641,17 (1653,94) | 3848,12 (23910,64) -> 401,69 (485,42) | 706,83 (3905,89) -> 186,48 (187,41) | 213,46 (1013,16) -> 147,41 (197,52) |

#### Average ratio percentage 

Looking at the above table KNet performs better than Confluent.Kafka with burst of few messages (10/100 messages); if the number of messages is higher (e.g. 1000/10000) KNet performs better when the size of the messages is large.
The best produce performance was obtained with 10 messages of 100, or 10000, bytes: KNet is 20 times fast than Confluent.Kafka.
The best consume performance was obtained with 10 messages of 10000 bytes: KNet is 4 times fast than Confluent.Kafka.

#### SD ratio percentage

Looking at value within the brackets, that represents the ratio of the SD, it is possible to highlight that:
- in produce KNet has more stable measures except when the number of messages is high (10000 messages);
- in consume KNet has less stable measures.

## Roundtrip Benchmark

The test analyze the ability of KNet and Confluent.Kafka to produce and consume from a topic. The test is done within the same process using different threads becuase it is based on the machine [TSC](https://en.wikipedia.org/wiki/Time_Stamp_Counter).

### Roundtrip Benchmark test program

To create a well-done comparison some configuration parameters are set in the same way during each test: e.g. linger time, batch size, etc.
Others have different meaning: KNet use the concept of memory pool to store messages (bytes that fills the buffer), while Confluent.Kafka (i.e. librdkafka) can configure how many messages stores (maximum messages to be stored); to reduce the impact from these specific parameters the tests were made to finalize the send/receive so all messages shall be sent or received.

The tests:
- are divided in two different main areas: produce and consume;
- uses their own topic to avoid impacts from the previous tests: schema is {TopicPrefix}__{testName}__{length}__{testNum} where 
  - **TopicPrefix** is an user definible string (default is _testTopic_)
  - **testName** is KNET or CONF
  - **length** is the payload length
  - **testNum** is the actual execution repetition
- to reduce impacts from different implementations of serializer/deserializer the most simple data types are used in the messages:
  - **key** is a long and represents the machine tick counter when the message is generated, this value will be compared with the tick counter when the message will be received during consume;
  - **value** (payload) is a byte array of data built from the application so the data does not have to be manipulated from the library;
- the tests are repeated multiple times (with a command line specific option: Repeat) and alternate the usage of KNet and Confluent.Kafka to statistically distribute external effects;
- stores info in a CSV for other external processing;
- finally reports an aggregated info comparing total execution time of the overall tests done.

Many configuration parameters can be applied in the command-line to manipulate both configuration parameters and how tests are executed.

### Approach

The approach followed in the benchmark test is to:
1. create a topic
2. start consumption from the topic in a separated thread
3. when the assignment is done from Apache Kafka the produce starts
4. the produce cycle produces messages and put in the key the current TSC ticks, the cycle produces the number of messages set on command line then waits the end of consumption
5. the consumer thread receives the messages from Apache Kafka and, for each message, compares the key (originating ticks) with current system ticks: **this measure represents the ticks elapsed from produce to consume**
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
- **a value higher than 100% means a better performance of Confluent.Kafka**
- **a value around 100% means comparable performance of KNet and Confluent.Kafka**

The most important are Average, Standard deviation and Coefficient of Variation.

### Benchmark results

The tests was done with:
- different messages length varying the payload length: from 10 bytes to 100 kbytes
- a set of 10000 messages to have enough statistics data;
- for each benchmark execution the tests are repeated at least 20 times.

The configuration is:
- Acks: None to avoid performance impacts from server side
- LingerMs: 100 ms
- BatchSize: 1000000
- MaxInFlight: 1000000
- SendBuffer: 32 Mb
- ReceiveBuffer: 32 Mb
- FetchMinBytes: 100000

Here below a set of results, in bold the results which are better using KNet:

- KNet/Confluent.Kafka Roundtrip Average ratio percentage (SD ratio percentage):

|  | 10 bytes | 100 bytes | 1000 bytes | 10000 bytes | 100000 bytes |
|:---:	|:---:	|:---:	|:---:	|:---:	|:---:	|
| 10000 messages | **61,35 (54,26)** | **56,73 (120,86)** | **36,18 (39,18)** | **27,77 (15,69)** | **46,61 (28,11)** |


#### Average ratio percentage 

Looking at the above table KNet performs better than Confluent.Kafka.

#### SD ratio percentage

Looking at value within the brackets, that represents the ratio of the SD, it is possible to highlight that the more stable values are available with packet size higher than 100 bytes.



## Final considerations

The KNet library performs better when the massages are larger; when the messages are small Confluent.Kafka performs better.
From some measurement done KNet suffers the JNI interface overhead needed to performs the operations (the user can activate JNI calls measurement): the evidence comes from the difference between KNetProducer and KafkaProducer (without _UseKNetProducer_ command-line switch).
Using KNetProducer the numbers of JNI invocation are less than using KafkaProducer, so reducing the number of JNI calls have a great impact on overall performance.
The same consideration can be applied on the consume side: KNetConsumer does not reduce the impact of JNI interface and it does not give any great improvement.
The JNI interface has an impact even when the number of messages is high because during processing the Garbage Collector is activated many times increasing the JNI overhead.