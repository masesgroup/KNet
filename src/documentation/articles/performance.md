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
| 100 messages | **20,91 (28,42)** | **37,65 (86,60)** | **24,85 (23,10)** | **34,64 (60,97)** |
| 1,000 messages | **28,50 (33,70)** | **50,24 (73,22)** | **50,75 (48,41)** | **33,21 (59,04)** |
| 10,000 messages | 169,41 (45,75) | **92,61 (46,25)** | **57,93 (126,72)** | **28,85 (33,17)** |

_Using **KafkaProducer** and **KafkaConsumer**_ (standard JNI wrappers):

|  | 100 bytes | 1,000 bytes | 10,000 bytes | 100,000 bytes |
|:---:	|:---:	|:---:	|:---:	|:---:	|
| 100 messages | **24,25 (23,69)** | **11,89 (20,03)** | **32,09 (14,77)** | **44,85 (77,42)** |
| 1,000 messages | **42,47 (58,86)** | **40,13 (56,19)** | **34,63 (19,70)** | **40,88 (63,67)** |
| 10,000 messages | 105,48 (85,02) | **88,23 (31,04)** | **54,13 (63,85)** | **55,20 (64,73)** |


> Results automatically updated by CI run [#50](https://github.com/masesgroup/KNet/actions/runs/30242074887) · commit `20323f5` · 2026-07-27 10:10 UTC

- KNet/Confluent.Kafka™ Consume Average ratio percentage (SD ratio percentage):


_Using **KNetProducer** and **KNetConsumer**_ (`-UseKNetProducer -UseKNetConsumer`):

|  | 100 bytes | 1,000 bytes | 10,000 bytes | 100,000 bytes |
|:---:	|:---:	|:---:	|:---:	|:---:	|
| 100 messages | 101,21 (132,65) | 103,16 (311,63) | 102,56 (104,00) | 106,30 (204,08) |
| 1,000 messages | 101,05 (129,44) | 104,04 (6807,17) | 108,58 (90,61) | 108,98 (39,51) |
| 10,000 messages | 158,71 (3288,44) | 157,29 (3409,68) | 151,38 (392,56) | **28,74 (42,48)** |

_Using **KafkaProducer** and **KafkaConsumer**_ (standard JNI wrappers):

|  | 100 bytes | 1,000 bytes | 10,000 bytes | 100,000 bytes |
|:---:	|:---:	|:---:	|:---:	|:---:	|
| 100 messages | **84,73 (674,94)** | **5,81 (155,35)** | **5,32 (26,18)** | **14,57 (56,86)** |
| 1,000 messages | **6,84 (4132,89)** | **4,44 (59,23)** | **15,33 (955,98)** | **50,91 (19,93)** |
| 10,000 messages | **4,84 (1,58)** | **11,09 (3,34)** | **54,90 (68,03)** | **55,18 (37,74)** |


> Results automatically updated by CI run [#50](https://github.com/masesgroup/KNet/actions/runs/30242074887) · commit `20323f5` · 2026-07-27 10:10 UTC

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
| 100 messages | **8,65 (4,41)** | **9,12 (824,03)** | **10,18 (857,35)** | **15,14 (177,54)** |
| 1,000 messages | **12,45 (310,42)** | **14,21 (114,72)** | **20,71 (131,82)** | **48,64 (16,72)** |
| 10,000 messages | **41,47 (1926,84)** | **43,19 (412,65)** | **84,72 (19,69)** | **47,78 (36,78)** |

_Using **KafkaProducer** and **KafkaConsumer**_ (standard JNI wrappers):

|  | 100 bytes | 1,000 bytes | 10,000 bytes | 100,000 bytes |
|:---:	|:---:	|:---:	|:---:	|:---:	|
| 100 messages | **6,91 (348,22)** | **7,06 (968,17)** | **8,88 (1372,64)** | **16,21 (487,88)** |
| 1,000 messages | **9,57 (433,94)** | **11,68 (245,68)** | **14,70 (324,53)** | **50,06 (27,46)** |
| 10,000 messages | **16,11 (160,35)** | **18,71 (477,34)** | **35,36 (10,50)** | **55,51 (22,39)** |


> Results automatically updated by CI run [#50](https://github.com/masesgroup/KNet/actions/runs/30242074887) · commit `20323f5` · 2026-07-27 10:10 UTC

#### Analysis

KNet shows significantly lower latency in this test. The result reflects the architectural difference: KNet's consumer receives the record in the JVM and the round-trip completes there, while Confluent.Kafka™ must also deserialise the payload into a CLR object before the application can read the key. The KNet number here is therefore a lower bound — it does not include the cost of making the value available in .NET.

#### With `-CheckOnConsume` — CLR data availability latency

`item.Value.SequenceEqual(data)` is called for each message, forcing full JNI payload transfer. This is the fair comparison with Confluent.Kafka™.

- KNet/Confluent.Kafka™ Roundtrip with CheckOnConsume Average ratio percentage (SD ratio percentage):


_Using **KNetProducer** and **KNetConsumer**_ (`-UseKNetProducer -UseKNetConsumer -CheckOnConsume`):

|  | 100 bytes | 1,000 bytes | 10,000 bytes | 100,000 bytes |
|:---:	|:---:	|:---:	|:---:	|:---:	|
| 100 messages | **9,12 (231,86)** | **7,79 (955,08)** | **9,95 (795,83)** | **17,82 (702,25)** |
| 1,000 messages | **12,70 (646,72)** | **13,36 (1273,77)** | **20,41 (324,82)** | **59,53 (24,72)** |
| 10,000 messages | **40,49 (1057,08)** | **48,72 (402,65)** | **81,54 (76,76)** | **60,41 (54,07)** |

_Using **KafkaProducer** and **KafkaConsumer**_ (standard JNI wrappers -CheckOnConsume):

|  | 100 bytes | 1,000 bytes | 10,000 bytes | 100,000 bytes |
|:---:	|:---:	|:---:	|:---:	|:---:	|
| 100 messages | **7,65 (35,42)** | **6,65 (681,20)** | **8,94 (847,94)** | **15,84 (665,27)** |
| 1,000 messages | **9,76 (13,21)** | **11,38 (92,96)** | **17,03 (277,13)** | **56,62 (35,96)** |
| 10,000 messages | **17,49 (659,91)** | **19,35 (174,95)** | **47,55 (50,20)** | **56,21 (51,43)** |


> Results automatically updated by CI run [#50](https://github.com/masesgroup/KNet/actions/runs/30242074887) · commit `20323f5` · 2026-07-27 10:10 UTC

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