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
| 100 messages | **78,55 (99,69)** | **36,52 (4,62)** | **46,98 (4,18)** | **22,01 (14,72)** |
| 1,000 messages | 167,92 (40,25) | **58,96 (101,73)** | **44,76 (32,81)** | **21,61 (43,23)** |
| 10,000 messages | 318,79 (53,95) | 163,79 (44,89) | **46,62 (46,73)** | **20,28 (76,07)** |

_Using **KafkaProducer** and **KafkaConsumer**_ (standard JNI wrappers):

|  | 100 bytes | 1,000 bytes | 10,000 bytes | 100,000 bytes |
|:---:	|:---:	|:---:	|:---:	|:---:	|
| 100 messages | **54,06 (58,26)** | **44,51 (4,79)** | **83,46 (35,34)** | **26,99 (11,63)** |
| 1,000 messages | 181,38 (57,52) | **58,03 (100,73)** | **49,06 (55,35)** | **36,67 (53,42)** |
| 10,000 messages | 344,50 (91,81) | 163,55 (27,55) | **47,89 (109,90)** | **49,15 (104,07)** |


> Results automatically updated by CI run [#57](https://github.com/masesgroup/KNet/actions/runs/34821241506) · commit `650e46d` · 2026-09-14 11:23 UTC

- KNet/Confluent.Kafka™ Consume Average ratio percentage (SD ratio percentage):


_Using **KNetProducer** and **KNetConsumer**_ (`-UseKNetProducer -UseKNetConsumer`):

|  | 100 bytes | 1,000 bytes | 10,000 bytes | 100,000 bytes |
|:---:	|:---:	|:---:	|:---:	|:---:	|
| 100 messages | 101,56 (956,31) | 103,07 (128,06) | 102,63 (152,81) | 104,63 (283,07) |
| 1,000 messages | 101,00 (195,74) | 100,66 (149,24) | 109,52 (269,03) | **97,59 (31,61)** |
| 10,000 messages | 182,85 (64,46) | 188,66 (166,29) | 147,94 (574,82) | **27,32 (5,50)** |

_Using **KafkaProducer** and **KafkaConsumer**_ (standard JNI wrappers):

|  | 100 bytes | 1,000 bytes | 10,000 bytes | 100,000 bytes |
|:---:	|:---:	|:---:	|:---:	|:---:	|
| 100 messages | **84,70 (1235,41)** | **5,48 (263,34)** | **5,58 (208,77)** | **14,26 (90,65)** |
| 1,000 messages | **4,17 (81,23)** | **4,51 (103,51)** | **12,91 (167,16)** | **48,57 (29,28)** |
| 10,000 messages | **5,32 (38,70)** | **10,68 (1,38)** | **49,84 (22,93)** | **59,16 (10,12)** |


> Results automatically updated by CI run [#57](https://github.com/masesgroup/KNet/actions/runs/34821241506) · commit `650e46d` · 2026-09-14 11:23 UTC

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
| 100 messages | **8,40 (558,90)** | **5,68 (78,06)** | **6,73 (38,33)** | **11,67 (436,22)** |
| 1,000 messages | **12,73 (812,01)** | **13,29 (656,21)** | **19,72 (425,26)** | **43,17 (93,12)** |
| 10,000 messages | **57,21 (1299,17)** | **62,94 (12565,07)** | **83,22 (44,14)** | **45,09 (18,43)** |

_Using **KafkaProducer** and **KafkaConsumer**_ (standard JNI wrappers):

|  | 100 bytes | 1,000 bytes | 10,000 bytes | 100,000 bytes |
|:---:	|:---:	|:---:	|:---:	|:---:	|
| 100 messages | **5,99 (187,20)** | **4,06 (163,41)** | **5,40 (222,77)** | **13,13 (98,70)** |
| 1,000 messages | **7,12 (137,94)** | **9,36 (381,96)** | **12,72 (495,25)** | **48,94 (38,38)** |
| 10,000 messages | **21,19 (231,57)** | **25,63 (50,55)** | **32,34 (46,83)** | **49,21 (47,72)** |


> Results automatically updated by CI run [#57](https://github.com/masesgroup/KNet/actions/runs/34821241506) · commit `650e46d` · 2026-09-14 11:23 UTC

#### Analysis

KNet shows significantly lower latency in this test. The result reflects the architectural difference: KNet's consumer receives the record in the JVM and the round-trip completes there, while Confluent.Kafka™ must also deserialise the payload into a CLR object before the application can read the key. The KNet number here is therefore a lower bound — it does not include the cost of making the value available in .NET.

#### With `-CheckOnConsume` — CLR data availability latency

`item.Value.SequenceEqual(data)` is called for each message, forcing full JNI payload transfer. This is the fair comparison with Confluent.Kafka™.

- KNet/Confluent.Kafka™ Roundtrip with CheckOnConsume Average ratio percentage (SD ratio percentage):


_Using **KNetProducer** and **KNetConsumer**_ (`-UseKNetProducer -UseKNetConsumer -CheckOnConsume`):

|  | 100 bytes | 1,000 bytes | 10,000 bytes | 100,000 bytes |
|:---:	|:---:	|:---:	|:---:	|:---:	|
| 100 messages | **8,31 (222,33)** | **5,69 (226,92)** | **7,52 (295,75)** | **17,28 (314,76)** |
| 1,000 messages | **13,47 (340,99)** | **13,37 (186,78)** | **20,56 (393,19)** | **53,96 (96,19)** |
| 10,000 messages | **64,51 (916,61)** | **69,20 (1131,04)** | **85,36 (79,05)** | **62,14 (72,02)** |

_Using **KafkaProducer** and **KafkaConsumer**_ (standard JNI wrappers -CheckOnConsume):

|  | 100 bytes | 1,000 bytes | 10,000 bytes | 100,000 bytes |
|:---:	|:---:	|:---:	|:---:	|:---:	|
| 100 messages | **6,51 (232,10)** | **4,03 (127,31)** | **5,08 (892,55)** | **13,18 (228,12)** |
| 1,000 messages | **9,41 (289,44)** | **9,88 (365,09)** | **16,40 (480,03)** | **48,90 (45,19)** |
| 10,000 messages | **26,61 (113,57)** | **29,55 (72,38)** | **40,79 (69,69)** | **53,83 (71,61)** |


> Results automatically updated by CI run [#57](https://github.com/masesgroup/KNet/actions/runs/34821241506) · commit `650e46d` · 2026-09-14 11:23 UTC

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