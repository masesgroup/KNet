---
title: Streams SDK of .NET suite for Apache Kafka™
_description: Describes how to setup RocksDb in Streams SDK of .NET suite for Apache Kafka™
---

# KNet: RocksDB configuration

Apache Kafka™ Streams uses [RocksDB](https://rocksdb.org/) as its default storage engine for persistent state stores. KNet Streams SDK exposes the ability to configure RocksDB from .NET via `KNetRocksDBConfigSetter.SetRocksDBConfigSetterCallback`; 
the default implementation defined from `KNetRocksDBConfigSetter.SetRocksDBConfigSetterCallbackDefault` enables the usage of per-store handlers based on `IRocksDbLifecycleHandler`

## How it works

The callback mechanism is built on two methods of `KNetRocksDBConfigSetter`:

* **`SetRocksDBConfigSetterCallback(onSetConfig, onClose)`** — registers a process-wide callback pair. The callback is unique per process: calling this method a second time without a prior `ResetRocksDBConfigSetterCallback` throws an `InvalidOperationException`.
* **`SetRocksDBConfigSetterCallbackDefault()`** — registers a process-wide callback pair managed from `KNetRocksDBConfigSetter` enabling `KNetRocksDBConfigSetter.Register` and `KNetRocksDBConfigSetter.Unregister`.
* **`ResetRocksDBConfigSetterCallback()`** — deregisters the callbacks and disposes the internal state.
* **`RocksDBConfigSetterCallbackSet`** — returns `true` if a callback is currently registered.

When a Kafka Streams instance initializes a RocksDB state store it invokes `onSetConfig`; when the store is closed it invokes `onClose`.
Inside this callback you can adjust the RocksDB `Options` instance and place any required .NET objects into a per-store dictionary.  
Objects stored in this dictionary remain alive until the close callback is invoked, which receives the same dictionary so that resources can be cleaned up.

> [!WARNING]
> Any RocksDB object created in `onSetConfig` that is **not** stored in the `IDictionary<string, object>` parameter may be collected by the .NET GC while RocksDB is still referencing it, causing unpredictable crashes. Always store all native-referenced objects in the provided dictionary.

> [!IMPORTANT]
> `SetRocksDBConfigSetterCallback` registers a single callback shared across all state stores in all `Streams` instances in the process. If multiple topologies with different RocksDB configurations are needed in the same process, use the `store` name parameter to dispatch the configuration logic within a single `onSetConfig` implementation.
> Previous limitation is superseded from `KNetRocksDBConfigSetter.Register` and `KNetRocksDBConfigSetter.Unregister`.

### Global configuration example

```csharp
KNetRocksDBConfigSetter.SetRocksDBConfigSetterCallback(
    (store, options, config, data) =>
    {
        var cache = new LRUCache(16 * 1024 * 1024);
        data["cache"] = cache;

        var table = options.TableFormatConfig().Cast<BlockBasedTableConfig>();
        table.SetBlockCache(cache);
        options.SetTableFormatConfig(table);
    },
    (store, options, data) =>
    {
        if (data.TryGetValue("cache", out var x) && x is Cache cache)
            cache.Close();
    });
```

### Per-store customization

For scenarios where specific state stores require different RocksDB settings, you can associate a lifecycle handler to a given storage ID:

```csharp
KNetRocksDBConfigSetter.Register("myStore", new MyRocksDbHandler());
```

The handler receives configuration and close notifications only for the associated store and uses the same per-store dictionary to retain any managed objects required by RocksDB.

To remove a handler:

```csharp
KNetRocksDBConfigSetter.Unregister("myStore");
```

This unified mechanism replaces the implementation seen in [Global configuration example](#global-configuration-example) and is the default way to customize RocksDB behavior in KNet Streams SDK: `KNetRocksDBConfigSetter.SetRocksDBConfigSetterCallbackDefault` is invoked in the static constructor of `KNetRocksDBConfigSetter` to ensure the infrastructure is ready.

## Object lifetime and the data dictionary

RocksDB objects created during configuration (e.g. `LRUCache`, `BlockBasedTableConfig`) must remain alive for the entire lifetime of the state store — they are referenced natively by RocksDB. If the .NET GC collects them, RocksDB will crash in a non-deterministic way.

To manage this, the framework provides each `onSetConfig` invocation with a dedicated `IDictionary<string, object>` parameter. Objects stored in this dictionary are held alive by the framework until the corresponding `onClose` is invoked, at which point the same dictionary is passed back to `onClose` so the user can dispose resources explicitly.

The dictionary is keyed internally by the JVM reference pointer of the `KNetRocksDBConfigSetter` instance — not by store name — so each state store instance gets its own independent dictionary. The store name can however be used as a key *within* the user dictionary if `setConfig` is called only once per instance before `close`.

## Activation

The callbacks are invoked only when `KNetRocksDBConfigSetter` is registered as the RocksDB config setter class:

- using `StreamsConfigBuilder`:

```csharp
StreamsConfigBuilder builder = StreamsConfigBuilder.Create();
builder.RocksDbConfigSetterClass = KNetRocksDBConfigSetter.KNetRocksDBConfigSetterClass;
```

- using `Properties`:

```csharp
var properties = new Java.Util.Properties();
properties.Put(StreamsConfig.ROCKSDB_CONFIG_SETTER_CLASS_CONFIG, KNetRocksDBConfigSetter.KNetRocksDBConfigSetterClass);
```

## Examples

The following example corresponds to the [Confluent RocksDB config setter guide](https://docs.confluent.io/platform/current/streams/developer-guide/config-streams.html#rocksdb-config-setter):

### Process wide example

```csharp
void OnSetConfig(string store, Org.Rocksdb.Options options, IKNetConfigurationFromMap configs, IDictionary<string, object> data)
{
    // Create a cache and store a reference in data to keep it alive
    Org.Rocksdb.Cache cache = new Org.Rocksdb.LRUCache(16 * 1024L * 1024L);
    data.Add("cache", cache);

    // See #1 in https://docs.confluent.io/platform/current/streams/developer-guide/config-streams.html#rocksdb-config-setter.
    // Options.TableFormatConfig() returns the abstract base type TableFormatConfig.
    // Since no implicit/explicit cast operator is generated by JNetReflector for this hierarchy,
    // use the JCOBridge Cast<T>() method to obtain the concrete BlockBasedTableConfig instance.
    BlockBasedTableConfig tableConfig = options.TableFormatConfig().Cast<BlockBasedTableConfig>();
    tableConfig.SetBlockCache(cache);
    // See #2 in https://docs.confluent.io/platform/current/streams/developer-guide/config-streams.html#rocksdb-config-setter.
    tableConfig.SetBlockSize(16 * 1024L);
    // See #3 in https://docs.confluent.io/platform/current/streams/developer-guide/config-streams.html#rocksdb-config-setter.
    tableConfig.SetCacheIndexAndFilterBlocks(true);
    options.SetTableFormatConfig(tableConfig);
    // See #4 in https://docs.confluent.io/platform/current/streams/developer-guide/config-streams.html#rocksdb-config-setter.
    options.SetMaxWriteBufferNumber(2);
}

void OnClose(string store, Org.Rocksdb.Options options, IDictionary<string, object> data)
{
    // Retrieve and dispose the cache that was stored during OnSetConfig
    if (data.TryGetValue("cache", out var obj) && obj is Org.Rocksdb.Cache cache)
    {
        cache.Close();
    }
}

// Register callbacks — process-wide, call only once
KNetRocksDBConfigSetter.SetRocksDBConfigSetterCallback(OnSetConfig, OnClose);

StreamsConfigBuilder builder = StreamsConfigBuilder.Create();
builder.RocksDbConfigSetterClass = KNetRocksDBConfigSetter.KNetRocksDBConfigSetterClass;
// ... rest of topology setup ...
Streams streams = new Streams(topology, builder);
streams.Start();

// When done, deregister
KNetRocksDBConfigSetter.ResetRocksDBConfigSetterCallback();
```

#### Per-store example

```csharp
var handler = new RocksDbLifecycleDelegateHandler((options, configs, data) =>
{
    // Create a cache and store a reference in data to keep it alive
    Org.Rocksdb.Cache cache = new Org.Rocksdb.LRUCache(16 * 1024L * 1024L);
    data.Add("cache", cache);

    // See #1 in https://docs.confluent.io/platform/current/streams/developer-guide/config-streams.html#rocksdb-config-setter.
    // Options.TableFormatConfig() returns the abstract base type TableFormatConfig.
    // Since no implicit/explicit cast operator is generated by JNetReflector for this hierarchy,
    // use the JCOBridge Cast<T>() method to obtain the concrete BlockBasedTableConfig instance.
    BlockBasedTableConfig tableConfig = options.TableFormatConfig().Cast<BlockBasedTableConfig>();
    tableConfig.SetBlockCache(cache);
    // See #2 in https://docs.confluent.io/platform/current/streams/developer-guide/config-streams.html#rocksdb-config-setter.
    tableConfig.SetBlockSize(16 * 1024L);
    // See #3 in https://docs.confluent.io/platform/current/streams/developer-guide/config-streams.html#rocksdb-config-setter.
    tableConfig.SetCacheIndexAndFilterBlocks(true);
    options.SetTableFormatConfig(tableConfig);
    // See #4 in https://docs.confluent.io/platform/current/streams/developer-guide/config-streams.html#rocksdb-config-setter.
    options.SetMaxWriteBufferNumber(2);
},
(options, data) =>
{
    // Retrieve and dispose the cache that was stored during OnSetConfig
    if (data.TryGetValue("cache", out var obj) && obj is Org.Rocksdb.Cache cache)
    {
        cache.Close();
    }
});

// Register callbacks — per-store, call only once
KNetRocksDBConfigSetter.Register("myStore", handler);

StreamsConfigBuilder builder = StreamsConfigBuilder.Create();
builder.RocksDbConfigSetterClass = KNetRocksDBConfigSetter.KNetRocksDBConfigSetterClass;
// ... rest of topology setup ...
Streams streams = new Streams(topology, builder);
streams.Start();

// When done, deregister
KNetRocksDBConfigSetter.Unregister("myStore");
```