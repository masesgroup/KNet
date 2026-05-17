---
title: Performance of .NET suite for Apache Kafka™
_description: Describes the performance evaluation of .NET suite for Apache Kafka™
---

# KNet: performance evaluation

This document describes the benchmark approach used to evaluate KNet performance, presents results, and provides an interpretation of the data.
The benchmarks are:
1. [Produce and Consume Benchmark](#produce-and-consume-benchmark)
2. [Roundtrip Benchmark](#roundtrip-benchmark)

## Initial considerations

Apache Kafka™ is a client-server architecture that relies on the network for communication.
Overall infrastructure performance depends on several elements:
  1. The hardware running the Apache Kafka™ server: see https://kafka.apache.org/documentation/#hwandos for details
  2. The Apache Kafka™ server configuration
  3. The network between clients and servers
  4. The client library and its configuration parameters
  5. The user application

All elements above affect the results, with the first three typically having the highest impact.
The KNet benchmarks focus on point 4 — the client library — while controlling for the others:
- Points 1, 2 and 3 are addressed by using an infrastructure based on SSD storage, a high core count, and a Gigabit LAN, reducing the influence of external conditions and distributing their effects statistically.
- Point 5 is addressed by running identical application logic for both libraries in every test, applying the same configuration parameters each time.

Since absolute numbers are strongly influenced by hardware and network conditions that vary between environments, the benchmarks use a **relative comparison** approach: every result is expressed as a ratio between KNet and Confluent.Kafka™.

- **< 100% → KNet is faster**
- **> 100% → Confluent.Kafka™ is faster**
- **≈ 100% → comparable performance**

The reference library for comparison is Confluent.Kafka™, the actively maintained .NET client for Apache Kafka™. The two libraries differ in their architecture:
- KNet wraps the official Apache Kafka™ JARs via JNI; Confluent.Kafka™ wraps librdkafka, a native C library.
- Thread models and internal queuing differ.
- Serializers and deserializers differ.
- Many configuration parameters are shared.

## Produce and Consume Benchmark

This benchmark measures the throughput of KNet and Confluent.Kafka™ for produce and consume operations independently.

### Test program

To make the comparison meaningful, shared configuration parameters (linger time, batch size, buffer sizes, etc.) are set identically for both libraries.
Parameters that have different semantics across libraries (e.g. KNet's byte-based memory pool vs librdkafka's message-count-based queue limit) are tuned to minimise their influence by ensuring all messages are fully sent or received before stopping measurement.

Each test:
- runs produce and consume as two separate phases;
- uses a dedicated topic per test to avoid cross-test interference: `{TopicPrefix}_{testName}_{packets}_{length}_{testNum}`, where **TopicPrefix** is configurable (default `testTopic`), **testName** is `KNET` or `CONF`, and **testNum** is the repetition index;
- uses simple types to minimise serializer overhead: **key** is a `long` (incremental ordinal), **value** is a `byte[]` pre-built by the application;
- alternates between KNet and Confluent.Kafka™ across repetitions to distribute external effects;
- writes raw data to CSV for offline analysis;
- reports aggregated statistics at the end.

For each (repetitions × library) combination the test reports: Max, Min, Average, Standard Deviation, and Coefficient of Variation.
The ratio columns in the tables below are `KNet / Confluent.Kafka™ × 100` for Average and Standard Deviation.

### Approach

1. Create a topic.
2. Produce all messages, measuring elapsed time; the cycle ends with a flush to guarantee all data has been delivered before stopping the clock.
3. Consume the messages produced in step 2 until the expected count is received.

The produce cycle:
- allocates a random byte array (allocation time is excluded from measurement);
- creates and sends each message, measuring both operations;
- calls flush and stops the clock.

The consume cycle:
- subscribes to the topic;
- starts the clock when the partition assignment callback fires;
- increments a counter on each received message;
- unsubscribes and stops the clock when the expected count is reached.

### Configuration

| Parameter | Value |
|:---|:---|
| Acks | None (no server-side acknowledgement overhead) |
| LingerMs | 100 ms |
| BatchSize | 1 000 000 |
| MaxInFlight | 1 000 000 |
| SendBuffer | 32 MB |
| ReceiveBuffer | 32 MB |
| FetchMinBytes | 100 000 |

### Benchmark results

- KNet/Confluent.Kafka™ Produce Average ratio percentage (SD ratio percentage):


_Using **KNetProducer** and **KNetConsumer**_ (`-UseKNetProducer -UseKNetConsumer`):

|  | 100 bytes | 1,000 bytes | 10,000 bytes | 100,000 bytes |
|:---:	|:---:	|:---:	|:---:	|:---:	|
| 100 messages | **31,75 (41,63)** | **15,00 (2,11)** | **19,63 (2,05)** | **21,61 (25,15)** |
| 1,000 messages | **39,90 (40,21)** | **34,13 (9,76)** | **43,92 (52,07)** | **26,49 (30,50)** |
| 10,000 messages | 109,00 (7,61) | 103,20 (65,81) | **47,46 (72,54)** | **21,96 (31,61)** |

_Using **KafkaProducer** and **KafkaConsumer**_ (standard JNI wrappers):

|  | 100 bytes | 1,000 bytes | 10,000 bytes | 100,000 bytes |
|:---:	|:---:	|:---:	|:---:	|:---:	|
| 100 messages | **56,83 (87,01)** | **47,14 (6,70)** | **94,06 (41,06)** | **25,09 (9,55)** |
| 1,000 messages | 202,74 (49,71) | **58,18 (39,80)** | **55,48 (65,34)** | **40,32 (51,36)** |
| 10,000 messages | 361,04 (100,81) | 168,39 (76,54) | **53,99 (60,47)** | **56,09 (102,02)** |


> Results automatically updated by CI run [#39](https://github.com/masesgroup/KNet/actions/runs/25986535381) · commit `d48af75` · 2026-05-17 12:51 UTC

- KNet/Confluent.Kafka™ Consume Average ratio percentage (SD ratio percentage):


_Using **KNetProducer** and **KNetConsumer**_ (`-UseKNetProducer -UseKNetConsumer`):

|  | 100 bytes | 1,000 bytes | 10,000 bytes | 100,000 bytes |
|:---:	|:---:	|:---:	|:---:	|:---:	|
| 100 messages | 101,45 (867,52) | 106,44 (3885,65) | 101,37 (24,04) | 104,17 (235,58) |
| 1,000 messages | 101,21 (188,95) | 102,69 (3492,56) | 108,43 (231,41) | **98,71 (60,28)** |
| 10,000 messages | 175,08 (2645,00) | 181,57 (2619,14) | 145,80 (114,82) | **18,77 (26,54)** |

_Using **KafkaProducer** and **KafkaConsumer**_ (standard JNI wrappers):

|  | 100 bytes | 1,000 bytes | 10,000 bytes | 100,000 bytes |
|:---:	|:---:	|:---:	|:---:	|:---:	|
| 100 messages | **84,36 (506,34)** | **4,90 (83,63)** | **5,26 (90,38)** | **14,23 (71,90)** |
| 1,000 messages | **3,88 (122,09)** | **4,30 (69,78)** | **12,59 (178,98)** | **53,39 (108,09)** |
| 10,000 messages | **5,33 (14,77)** | **11,76 (49,59)** | **57,32 (161,13)** | **65,69 (12,31)** |


> Results automatically updated by CI run [#39](https://github.com/masesgroup/KNet/actions/runs/25986535381) · commit `d48af75` · 2026-05-17 12:51 UTC

#### Analysis

KNet produce performance improves as payload size grows. The JNI call overhead is amortised over larger payloads, making KNet increasingly competitive. With small messages (100 bytes) the per-message JNI cost dominates and Confluent.Kafka™ is faster.

KNet consume performance with small payloads is significantly faster, because the consumer receives messages that are already fully assembled in the JVM and only a lightweight reference crosses the JNI boundary. With larger payloads the picture is more mixed; see the [Roundtrip Benchmark](#roundtrip-benchmark) for a detailed explanation of what the consume numbers actually measure in KNet.

> [!NOTE]
> Results depend on the specific hardware and configuration used. With different parameters, Confluent.Kafka™ may outperform KNet in all combinations.

## Roundtrip Benchmark

This benchmark measures end-to-end latency: the time from when a message is produced until it is received by the consumer, expressed in microseconds. Producer and consumer run in the same process on separate threads, using the system tick counter (`DateTime.Now.Ticks`) as the timing reference.

### Test program

The setup follows the same design principles as the produce/consume benchmark: identical shared parameters, dedicated topics per test, simple key/value types, alternating library order across repetitions, CSV output, and aggregated statistics.

The **key** field carries the tick counter at produce time. The consumer subtracts that value from the current ticks on receipt to obtain the round-trip latency. The **value** is a pre-built `byte[]` payload.

### Approach

1. Create a topic.
2. Start a consumer thread and subscribe to the topic.
3. When the partition assignment callback fires, start the producer.
4. The producer sends all messages, embedding the current tick count in each key, then flushes and waits for the consumer thread to finish.
5. The consumer thread, on each received message, computes `(DateTime.Now.Ticks - item.Key)` and stores the result.
6. When the expected message count is reached, the consumer unsubscribes and the thread exits.

### What the latency number actually measures in KNet

This distinction is important for interpreting the results.

**Without `-CheckOnConsume`** (default): when a KNet consumer receives a message, the full record — key and value — has already been delivered to the JVM. The round-trip at the Kafka protocol level is complete. However, only `item.Key` (a `long`) is transferred across the JNI boundary to compute the latency delta. The `value` byte array stays in JVM heap and is never materialised in CLR. This measures **Kafka network + broker latency**, with minimal JNI overhead. It is the lower bound of what KNet can achieve.

**With `-CheckOnConsume`**: after computing the latency, the test calls `item.Value.SequenceEqual(data)`, which forces the full payload to cross the JNI boundary and be compared in CLR. This adds JNI transfer cost that scales with payload size, and makes the KNet measurement **directly comparable to Confluent.Kafka™**, where `Value` is already a CLR `byte[]` and `SequenceEqual` runs almost for free.

The gap between the two variants quantifies the JNI payload transfer cost, which is the practical overhead a real KNet application pays when it accesses message content in .NET.

### Configuration

| Parameter | Value |
|:---|:---|
| Acks | Default (reliable delivery required for accurate latency measurement) |
| LingerMs | 0 ms |
| BatchSize | 1 000 000 |
| MaxInFlight | 1 000 000 |
| SendBuffer | 32 MB |
| ReceiveBuffer | 32 MB |
| FetchMinBytes | 1 (deliver immediately without waiting to accumulate bytes) |

### Benchmark results

#### Without `-CheckOnConsume` — Kafka round-trip latency

The `Value` payload is not transferred to CLR. KNet latency reflects the Kafka network + broker round-trip only.

- KNet/Confluent.Kafka™ Roundtrip Average ratio percentage (SD ratio percentage):


_Using **KNetProducer** and **KNetConsumer**_ (`-UseKNetProducer -UseKNetConsumer`):

|  | 100 bytes | 1,000 bytes | 10,000 bytes | 100,000 bytes |
|:---:	|:---:	|:---:	|:---:	|:---:	|
| 100 messages | **8,19 (316,81)** | **6,09 (481,69)** | **7,20 (2955,49)** | **11,92 (1729,50)** |
| 1,000 messages | **13,45 (1796,47)** | **14,67 (4894,92)** | **19,38 (385,19)** | **42,80 (87,97)** |
| 10,000 messages | **59,60 (1610,68)** | **56,30 (539,77)** | **88,19 (123,17)** | **49,41 (18,90)** |

_Using **KafkaProducer** and **KafkaConsumer**_ (standard JNI wrappers):

|  | 100 bytes | 1,000 bytes | 10,000 bytes | 100,000 bytes |
|:---:	|:---:	|:---:	|:---:	|:---:	|
| 100 messages | **6,32 (568,53)** | **4,84 (1461,93)** | **6,15 (2027,49)** | **11,94 (249,02)** |
| 1,000 messages | **9,82 (2419,35)** | **11,23 (3460,57)** | **12,01 (107,51)** | **45,19 (60,42)** |
| 10,000 messages | **17,37 (65,56)** | **19,78 (237,57)** | **27,45 (33,66)** | **52,04 (151,13)** |


> Results automatically updated by CI run [#39](https://github.com/masesgroup/KNet/actions/runs/25986535381) · commit `d48af75` · 2026-05-17 12:51 UTC

#### Analysis

KNet shows significantly lower latency in this test. The result reflects the architectural difference: KNet's consumer receives the record in the JVM and the round-trip completes there, while Confluent.Kafka™ must also deserialise the payload into a CLR object before the application can read the key. The KNet number here is therefore a lower bound — it does not include the cost of making the value available in .NET.

#### With `-CheckOnConsume` — CLR data availability latency

`item.Value.SequenceEqual(data)` is called for each message, forcing full JNI payload transfer. This is the fair comparison with Confluent.Kafka™.

- KNet/Confluent.Kafka™ Roundtrip with CheckOnConsume Average ratio percentage (SD ratio percentage):


_Using **KNetProducer** and **KNetConsumer**_ (`-UseKNetProducer -UseKNetConsumer -CheckOnConsume`):

|  | 100 bytes | 1,000 bytes | 10,000 bytes | 100,000 bytes |
|:---:	|:---:	|:---:	|:---:	|:---:	|
| 100 messages | **8,27 (2964,37)** | **5,96 (3005,81)** | **7,09 (2132,06)** | **12,98 (663,31)** |
| 1,000 messages | **12,98 (3593,52)** | **14,60 (3700,60)** | **18,35 (332,25)** | **54,70 (33,90)** |
| 10,000 messages | **55,89 (1891,09)** | **54,74 (598,52)** | **89,12 (80,68)** | **63,53 (116,43)** |

_Using **KafkaProducer** and **KafkaConsumer**_ (standard JNI wrappers -CheckOnConsume):

|  | 100 bytes | 1,000 bytes | 10,000 bytes | 100,000 bytes |
|:---:	|:---:	|:---:	|:---:	|:---:	|
| 100 messages | **6,50 (261,55)** | **4,89 (5029,09)** | **6,16 (65,04)** | **12,49 (752,99)** |
| 1,000 messages | **10,05 (9224,53)** | **11,43 (7055,55)** | **15,65 (807,65)** | **49,01 (78,35)** |
| 10,000 messages | **22,23 (1714,12)** | **23,80 (104,05)** | **41,40 (38,96)** | **54,96 (63,26)** |


> Results automatically updated by CI run [#39](https://github.com/masesgroup/KNet/actions/runs/25986535381) · commit `d48af75` · 2026-05-17 12:51 UTC

#### Analysis

With `-CheckOnConsume` the JNI transfer cost is included. The gap relative to the previous table grows with payload size, directly quantifying the JNI overhead for payload materialisation. This is the most relevant comparison for applications that actually read message content in .NET code.

> [!NOTE]
> Results depend on the specific hardware and configuration used. With different parameters, Confluent.Kafka™ may outperform KNet in all combinations.

## Final considerations

KNet performs best when messages are large, because the JNI overhead per message is amortised over a larger payload. With small messages Confluent.Kafka™ has the advantage due to its native librdkafka implementation avoiding the JNI boundary entirely.

The JNI overhead is measurable and scales with the number of JNI calls. Two architectural choices in KNet directly reduce this overhead:

**KNetProducer** batches and pipelines JNI calls more efficiently than the standard `KafkaProducer` wrapper. Switching from `KafkaProducer` to `KNetProducer` (via `-UseKNetProducer`) reduces the JNI call count and improves produce throughput, especially at high message rates.

**Prefetch on consume** offloads JVM method invocations to a background thread, allowing the main iterator to proceed while the next record's JNI calls are in flight:

```csharp
var records = consumer.Poll(duration);
if (UsePrefetch)
{
    foreach (var item in records.WithPrefetch().WithThread())
    {
        // process item
    }
}
```

This reduces the effective JNI latency visible to the application and is particularly effective at high throughput with larger payloads.

The Garbage Collector is another factor: at high message rates the GC activates more frequently, increasing JNI overhead. The JCOBridge HPA (High Performance Application) Edition addresses this specifically by preventing premature GC collection of cross-boundary object references and reducing GC pressure through buffer pooling and deep caching of generic type resolution.