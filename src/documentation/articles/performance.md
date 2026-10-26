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
| 100 messages | **55,03 (76,35)** | **38,86 (6,76)** | **50,43 (12,53)** | **24,00 (24,14)** |
| 1,000 messages | **51,35 (8,07)** | **46,85 (32,53)** | **47,93 (49,50)** | **20,47 (31,95)** |
| 10,000 messages | 315,93 (210,86) | 156,98 (117,90) | **48,05 (63,97)** | **19,15 (31,53)** |

_Using **KafkaProducer** and **KafkaConsumer**_ (standard JNI wrappers):

|  | 100 bytes | 1,000 bytes | 10,000 bytes | 100,000 bytes |
|:---:	|:---:	|:---:	|:---:	|:---:	|
| 100 messages | **37,46 (39,69)** | **30,93 (5,02)** | **50,80 (7,29)** | **20,96 (10,09)** |
| 1,000 messages | **72,83 (24,23)** | **36,58 (7,94)** | **41,28 (14,08)** | **34,35 (40,73)** |
| 10,000 messages | 229,30 (40,48) | 140,09 (57,12) | **48,06 (59,58)** | **48,27 (53,30)** |


> Results automatically updated by CI run [#63](https://github.com/masesgroup/KNet/actions/runs/40290453957) · commit `e49088c` · 2026-10-26 11:25 UTC

- KNet/Confluent.Kafka™ Consume Average ratio percentage (SD ratio percentage):


_Using **KNetProducer** and **KNetConsumer**_ (`-UseKNetProducer -UseKNetConsumer`):

|  | 100 bytes | 1,000 bytes | 10,000 bytes | 100,000 bytes |
|:---:	|:---:	|:---:	|:---:	|:---:	|
| 100 messages | 101,33 (803,58) | 102,83 (120,93) | 102,32 (164,24) | 103,88 (152,52) |
| 1,000 messages | 101,06 (94,33) | 100,79 (106,32) | 108,23 (243,17) | **98,33 (73,82)** |
| 10,000 messages | 136,85 (1631,93) | 125,06 (74,51) | 137,60 (199,46) | **19,41 (24,45)** |

_Using **KafkaProducer** and **KafkaConsumer**_ (standard JNI wrappers):

|  | 100 bytes | 1,000 bytes | 10,000 bytes | 100,000 bytes |
|:---:	|:---:	|:---:	|:---:	|:---:	|
| 100 messages | **85,70 (4972,34)** | **4,61 (227,34)** | **4,78 (147,34)** | **12,13 (138,46)** |
| 1,000 messages | **3,78 (154,07)** | **4,00 (120,57)** | **10,67 (130,02)** | **40,24 (44,08)** |
| 10,000 messages | **4,78 (46,89)** | **9,71 (69,93)** | **43,16 (63,37)** | **35,22 (29,14)** |


> Results automatically updated by CI run [#63](https://github.com/masesgroup/KNet/actions/runs/40290453957) · commit `e49088c` · 2026-10-26 11:25 UTC

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
| 100 messages | **7,10 (739,40)** | **4,70 (848,58)** | **5,46 (313,12)** | **9,17 (862,78)** |
| 1,000 messages | **10,03 (1184,90)** | **10,52 (1082,27)** | **15,43 (1027,50)** | **38,31 (48,95)** |
| 10,000 messages | **45,59 (2197,22)** | **45,36 (1851,15)** | **77,49 (125,45)** | **42,94 (38,60)** |

_Using **KafkaProducer** and **KafkaConsumer**_ (standard JNI wrappers):

|  | 100 bytes | 1,000 bytes | 10,000 bytes | 100,000 bytes |
|:---:	|:---:	|:---:	|:---:	|:---:	|
| 100 messages | **5,02 (753,96)** | **3,36 (546,54)** | **4,32 (259,53)** | **10,52 (292,55)** |
| 1,000 messages | **6,70 (136,72)** | **7,97 (491,78)** | **10,49 (609,38)** | **40,19 (55,34)** |
| 10,000 messages | **16,79 (146,10)** | **19,92 (307,54)** | **26,85 (40,59)** | **48,74 (46,44)** |


> Results automatically updated by CI run [#63](https://github.com/masesgroup/KNet/actions/runs/40290453957) · commit `e49088c` · 2026-10-26 11:25 UTC

#### Analysis

KNet shows significantly lower latency in this test. The result reflects the architectural difference: KNet's consumer receives the record in the JVM and the round-trip completes there, while Confluent.Kafka™ must also deserialise the payload into a CLR object before the application can read the key. The KNet number here is therefore a lower bound — it does not include the cost of making the value available in .NET.

#### With `-CheckOnConsume` — CLR data availability latency

`item.Value.SequenceEqual(data)` is called for each message, forcing full JNI payload transfer. This is the fair comparison with Confluent.Kafka™.

- KNet/Confluent.Kafka™ Roundtrip with CheckOnConsume Average ratio percentage (SD ratio percentage):


_Using **KNetProducer** and **KNetConsumer**_ (`-UseKNetProducer -UseKNetConsumer -CheckOnConsume`):

|  | 100 bytes | 1,000 bytes | 10,000 bytes | 100,000 bytes |
|:---:	|:---:	|:---:	|:---:	|:---:	|
| 100 messages | **6,44 (564,96)** | **4,31 (617,84)** | **5,40 (414,77)** | **11,79 (518,26)** |
| 1,000 messages | **9,69 (1927,15)** | **10,37 (921,72)** | **15,62 (507,69)** | **50,66 (75,59)** |
| 10,000 messages | **41,50 (298,63)** | **46,74 (3805,81)** | **78,62 (122,12)** | **59,15 (63,68)** |

_Using **KafkaProducer** and **KafkaConsumer**_ (standard JNI wrappers -CheckOnConsume):

|  | 100 bytes | 1,000 bytes | 10,000 bytes | 100,000 bytes |
|:---:	|:---:	|:---:	|:---:	|:---:	|
| 100 messages | **5,65 (492,85)** | **3,38 (283,26)** | **4,17 (251,44)** | **10,53 (379,01)** |
| 1,000 messages | **6,77 (427,57)** | **7,89 (817,02)** | **13,23 (513,57)** | **47,88 (50,78)** |
| 10,000 messages | **20,84 (555,69)** | **23,30 (159,81)** | **39,49 (27,18)** | **51,65 (51,54)** |


> Results automatically updated by CI run [#63](https://github.com/masesgroup/KNet/actions/runs/40290453957) · commit `e49088c` · 2026-10-26 11:25 UTC

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