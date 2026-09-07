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
| 100 messages | **78,64 (102,39)** | **45,72 (6,79)** | **70,60 (77,65)** | **21,01 (9,69)** |
| 1,000 messages | 175,19 (70,80) | **58,46 (62,52)** | **47,83 (45,86)** | **24,83 (42,58)** |
| 10,000 messages | 336,12 (103,80) | 192,87 (43,19) | **48,69 (31,07)** | **23,70 (51,06)** |

_Using **KafkaProducer** and **KafkaConsumer**_ (standard JNI wrappers):

|  | 100 bytes | 1,000 bytes | 10,000 bytes | 100,000 bytes |
|:---:	|:---:	|:---:	|:---:	|:---:	|
| 100 messages | **45,05 (42,27)** | **28,95 (2,34)** | **61,96 (4,22)** | **28,39 (12,02)** |
| 1,000 messages | 148,81 (10,63) | **52,73 (14,33)** | **54,40 (68,27)** | **40,60 (39,12)** |
| 10,000 messages | 323,30 (137,53) | 189,17 (60,40) | **52,64 (35,87)** | **53,56 (93,13)** |


> Results automatically updated by CI run [#56](https://github.com/masesgroup/KNet/actions/runs/34096187779) · commit `e878c16` · 2026-09-07 11:18 UTC

- KNet/Confluent.Kafka™ Consume Average ratio percentage (SD ratio percentage):


_Using **KNetProducer** and **KNetConsumer**_ (`-UseKNetProducer -UseKNetConsumer`):

|  | 100 bytes | 1,000 bytes | 10,000 bytes | 100,000 bytes |
|:---:	|:---:	|:---:	|:---:	|:---:	|
| 100 messages | 101,53 (942,57) | 103,26 (251,22) | 102,41 (167,81) | 101,86 (843,36) |
| 1,000 messages | 101,00 (144,24) | 100,70 (131,47) | 109,50 (255,90) | 100,96 (18,54) |
| 10,000 messages | 184,58 (135,11) | 188,48 (221,76) | 153,83 (537,71) | **25,34 (8,37)** |

_Using **KafkaProducer** and **KafkaConsumer**_ (standard JNI wrappers):

|  | 100 bytes | 1,000 bytes | 10,000 bytes | 100,000 bytes |
|:---:	|:---:	|:---:	|:---:	|:---:	|
| 100 messages | **84,87 (1721,09)** | **5,07 (222,17)** | **5,28 (81,33)** | **14,38 (75,40)** |
| 1,000 messages | **3,88 (102,51)** | **4,29 (79,88)** | **12,80 (189,09)** | **52,45 (61,53)** |
| 10,000 messages | **4,78 (7,88)** | **11,50 (147,41)** | **53,89 (39,66)** | **63,29 (7,15)** |


> Results automatically updated by CI run [#56](https://github.com/masesgroup/KNet/actions/runs/34096187779) · commit `e878c16` · 2026-09-07 11:18 UTC

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
| 100 messages | **8,50 (146,07)** | **5,59 (196,25)** | **6,16 (102,68)** | **11,61 (150,00)** |
| 1,000 messages | **11,81 (478,54)** | **11,84 (413,67)** | **19,22 (964,88)** | **43,30 (29,53)** |
| 10,000 messages | **56,94 (1574,24)** | **60,57 (411,74)** | **87,07 (23,55)** | **44,96 (59,23)** |

_Using **KafkaProducer** and **KafkaConsumer**_ (standard JNI wrappers):

|  | 100 bytes | 1,000 bytes | 10,000 bytes | 100,000 bytes |
|:---:	|:---:	|:---:	|:---:	|:---:	|
| 100 messages | **6,08 (124,20)** | **3,78 (124,41)** | **4,79 (155,13)** | **11,99 (133,53)** |
| 1,000 messages | **6,90 (542,30)** | **8,34 (746,27)** | **13,54 (24,85)** | **44,55 (36,64)** |
| 10,000 messages | **19,85 (54,39)** | **23,01 (103,52)** | **29,52 (50,28)** | **47,90 (35,34)** |


> Results automatically updated by CI run [#56](https://github.com/masesgroup/KNet/actions/runs/34096187779) · commit `e878c16` · 2026-09-07 11:18 UTC

#### Analysis

KNet shows significantly lower latency in this test. The result reflects the architectural difference: KNet's consumer receives the record in the JVM and the round-trip completes there, while Confluent.Kafka™ must also deserialise the payload into a CLR object before the application can read the key. The KNet number here is therefore a lower bound — it does not include the cost of making the value available in .NET.

#### With `-CheckOnConsume` — CLR data availability latency

`item.Value.SequenceEqual(data)` is called for each message, forcing full JNI payload transfer. This is the fair comparison with Confluent.Kafka™.

- KNet/Confluent.Kafka™ Roundtrip with CheckOnConsume Average ratio percentage (SD ratio percentage):


_Using **KNetProducer** and **KNetConsumer**_ (`-UseKNetProducer -UseKNetConsumer -CheckOnConsume`):

|  | 100 bytes | 1,000 bytes | 10,000 bytes | 100,000 bytes |
|:---:	|:---:	|:---:	|:---:	|:---:	|
| 100 messages | **10,77 (2383,99)** | **5,23 (242,29)** | **6,04 (181,77)** | **13,48 (113,08)** |
| 1,000 messages | **12,38 (377,53)** | **11,76 (803,01)** | **17,80 (653,09)** | **53,94 (28,30)** |
| 10,000 messages | **55,85 (1423,90)** | **56,98 (466,89)** | **88,37 (72,14)** | **65,69 (18,51)** |

_Using **KafkaProducer** and **KafkaConsumer**_ (standard JNI wrappers -CheckOnConsume):

|  | 100 bytes | 1,000 bytes | 10,000 bytes | 100,000 bytes |
|:---:	|:---:	|:---:	|:---:	|:---:	|
| 100 messages | **5,76 (307,40)** | **3,82 (206,79)** | **4,81 (227,61)** | **12,24 (807,96)** |
| 1,000 messages | **8,36 (625,02)** | **9,15 (1134,08)** | **14,87 (433,70)** | **52,17 (37,82)** |
| 10,000 messages | **23,45 (711,56)** | **27,31 (164,01)** | **40,04 (36,02)** | **54,75 (50,78)** |


> Results automatically updated by CI run [#56](https://github.com/masesgroup/KNet/actions/runs/34096187779) · commit `e878c16` · 2026-09-07 11:18 UTC

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