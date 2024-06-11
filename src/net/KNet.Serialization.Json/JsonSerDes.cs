/*
*  Copyright 2024 MASES s.r.l.
*
*  Licensed under the Apache License, Version 2.0 (the "License");
*  you may not use this file except in compliance with the License.
*  You may obtain a copy of the License at
*
*  http://www.apache.org/licenses/LICENSE-2.0
*
*  Unless required by applicable law or agreed to in writing, software
*  distributed under the License is distributed on an "AS IS" BASIS,
*  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
*  See the License for the specific language governing permissions and
*  limitations under the License.
*
*  Refer to LICENSE for more information.
*/

using Java.Nio;
using Org.Apache.Kafka.Common.Header;
using System;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Text;
#if NET462_OR_GREATER
using Newtonsoft.Json;
#else
using System.Text.Json;
#endif

namespace MASES.KNet.Serialization.Json
{
    /// <summary>
    /// Base class to define extensions of <see cref="ISerDesSelector{T}"/> for Json, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
    /// </summary>
    public static class JsonSerDes
    {
        /// <summary>
        /// Json extension of <see cref="ISerDesSelector{T}"/> for Key, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class Key<T> : ISerDesSelector<T>
        {
            /// <summary>
            /// Returns a new instance of <see cref="Key{T}"/>
            /// </summary>
            /// <returns>The <see cref="ISerDesSelector{T}"/> of <see cref="Key{T}"/></returns>
            public static ISerDesSelector<T> NewInstance() => new Key<T>();
            /// <inheritdoc cref="ISerDesSelector.SelectorTypeName"/>
            public static string SelectorTypeName => typeof(Key<>).ToAssemblyQualified();
            /// <inheritdoc cref="ISerDesSelector.ByteArraySerDes"/>
            public static Type ByteArraySerDes => typeof(KeyRaw<T>);
            /// <inheritdoc cref="ISerDesSelector.ByteBufferSerDes"/>
            public static Type ByteBufferSerDes => typeof(KeyBuffered<T>);
            /// <inheritdoc cref="ISerDesSelector{T}.NewSerDes{TJVM}"/>
            public static ISerDes<T, TJVM> NewSerDes<TJVM>()
            {
                if (typeof(TJVM) == typeof(Java.Nio.ByteBuffer)) return NewByteBufferSerDes() as ISerDes<T, TJVM>;
                return NewByteArraySerDes() as ISerDes<T, TJVM>;
            }
            /// <inheritdoc cref="ISerDesSelector{T}.NewByteArraySerDes"/>
            public static ISerDesRaw<T> NewByteArraySerDes() { return new KeyRaw<T>(SelectorTypeName); }
            /// <inheritdoc cref="ISerDesSelector{T}.NewByteBufferSerDes"/>
            public static ISerDesBuffered<T> NewByteBufferSerDes() { return new KeyBuffered<T>(SelectorTypeName); }

            /// <inheritdoc cref="ISerDesSelector.SelectorTypeName"/>
            string ISerDesSelector.SelectorTypeName => SelectorTypeName;
            /// <inheritdoc cref="ISerDesSelector.ByteArraySerDes"/>
            Type ISerDesSelector.ByteArraySerDes => ByteArraySerDes;
            /// <inheritdoc cref="ISerDesSelector.ByteBufferSerDes"/>
            Type ISerDesSelector.ByteBufferSerDes => ByteBufferSerDes;
            /// <inheritdoc cref="ISerDesSelector{T}.NewSerDes{TJVM}"/>
            ISerDes<T, TJVM> ISerDesSelector<T>.NewSerDes<TJVM>() => NewSerDes<TJVM>();
            /// <inheritdoc cref="ISerDesSelector{T}.NewByteArraySerDes"/>
            ISerDesRaw<T> ISerDesSelector<T>.NewByteArraySerDes() => NewByteArraySerDes();
            /// <inheritdoc cref="ISerDesSelector{T}.NewByteBufferSerDes"/>
            ISerDesBuffered<T> ISerDesSelector<T>.NewByteBufferSerDes() => NewByteBufferSerDes();

            /// <summary>
            /// Json extension of <see cref="SerDes{TData, TJVMT}"/> for Key, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
            /// </summary>
            /// <typeparam name="TData"></typeparam>
            sealed class KeyRaw<TData> : SerDesRaw<TData>
            {
                readonly byte[] keySerDesName;
                readonly byte[] keyTypeName = null;
                readonly ISerDesRaw<TData> _defaultSerDes = default!;
#if NET462_OR_GREATER
                /// <summary>
                /// Settings used from <see cref="JsonConvert.DeserializeObject(string, JsonSerializerSettings)"/> and <see cref="JsonConvert.SerializeObject(object?, JsonSerializerSettings?)"/>
                /// </summary>
                public JsonSerializerSettings Options { get; set; } = new JsonSerializerSettings();
#else
                /// <summary>
                /// Settings used from <see cref="JsonSerializer.Deserialize(Stream, JsonSerializerOptions?)"/> and <see cref="JsonSerializer.Serialize{TValue}(TValue, JsonSerializerOptions?)"/>
                /// </summary>
                public JsonSerializerOptions Options { get; set; } = new JsonSerializerOptions();
#endif
                /// <inheritdoc/>
                public override bool UseHeaders => true;
                /// <summary>
                /// Default initializer
                /// </summary>
                public KeyRaw(string selectorName)
                {
                    keySerDesName = Encoding.UTF8.GetBytes(selectorName);
                    if (KNetSerialization.IsInternalManaged<TData>())
                    {
                        _defaultSerDes = new SerDesRaw<TData>();
                        keyTypeName = Encoding.UTF8.GetBytes(typeof(TData).FullName!);
                    }
                    else
                    {
                        keyTypeName = Encoding.UTF8.GetBytes(typeof(TData).ToAssemblyQualified());
                    }
                }
                /// <inheritdoc cref="SerDes{TData, TJVMT}.Serialize(string, TData)"/>
                public override byte[] Serialize(string topic, TData data)
                {
                    return SerializeWithHeaders(topic, null, data);
                }
                /// <inheritdoc cref="SerDes{TData, TJVMT}.SerializeWithHeaders(string, Headers, TData)"/>
                public override byte[] SerializeWithHeaders(string topic, Headers headers, TData data)
                {
                    headers?.Add(KNetSerialization.KeyTypeIdentifierJVM, keyTypeName);
                    headers?.Add(KNetSerialization.KeySerializerIdentifierJVM, keySerDesName);

                    if (_defaultSerDes != null) return _defaultSerDes.SerializeWithHeaders(topic, headers, data);

#if NET462_OR_GREATER
                    var jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(data, Options);
                    return Encoding.UTF8.GetBytes(jsonStr);
#else
                    var jsonStr = System.Text.Json.JsonSerializer.Serialize<TData>(data, Options);
                    return Encoding.UTF8.GetBytes(jsonStr);
#endif
                }
                /// <inheritdoc cref="SerDes{TData, TJVMT}.Deserialize(string, TJVMT)"/>
                public override TData Deserialize(string topic, byte[] data)
                {
                    return DeserializeWithHeaders(topic, null, data);
                }
                /// <inheritdoc cref="SerDes{TData, TJVMT}.DeserializeWithHeaders(string, Headers, TJVMT)"/>
                public override TData DeserializeWithHeaders(string topic, Headers headers, byte[] data)
                {
                    if (_defaultSerDes != null) return _defaultSerDes.DeserializeWithHeaders(topic, headers, data);
                    if (data == null) return default;
#if NET462_OR_GREATER
                    var jsonStr = Encoding.UTF8.GetString(data);
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<TData>(jsonStr, Options);
#else
                    return System.Text.Json.JsonSerializer.Deserialize<TData>(data, Options)!;
#endif
                }
            }

            /// <summary>
            /// Json extension of <see cref="SerDes{TData, TJVMT}"/> for Key, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
            /// </summary>
            /// <typeparam name="TData"></typeparam>
            sealed class KeyBuffered<TData> : SerDesBuffered<TData>
            {
#if NET462_OR_GREATER
                readonly Newtonsoft.Json.JsonSerializer _serializer;
#endif
                readonly byte[] keySerDesName;
                readonly byte[] keyTypeName = null;
                readonly ISerDesBuffered<TData> _defaultSerDes = default!;
#if NET462_OR_GREATER
                /// <summary>
                /// When set to <see langword="true"/> the oprion forces <see cref="ValueBuffered{TData}"/> to use <see cref="System.IO.Stream"/> with <see cref="Java.Nio.ByteBuffer"/> to reduce memory copy
                /// </summary>
                /// <remarks>Added specifically to .NET Framework because NewtonSoft JSon seems to have problems with large streams</remarks>
                public bool UseStreamWithByteBuffer { get; set; } = true;
                /// <summary>
                /// Settings used from <see cref="JsonConvert.DeserializeObject(string, JsonSerializerSettings)"/> and <see cref="JsonConvert.SerializeObject(object?, JsonSerializerSettings?)"/>
                /// </summary>
                public JsonSerializerSettings Options { get; set; } = new JsonSerializerSettings();
#else
                /// <summary>
                /// Settings used from <see cref="JsonSerializer.Deserialize(Stream, JsonSerializerOptions?)"/> and <see cref="JsonSerializer.Serialize{TValue}(TValue, JsonSerializerOptions?)"/>
                /// </summary>
                public JsonSerializerOptions Options { get; set; } = new JsonSerializerOptions();
#endif
                /// <inheritdoc/>
                public override bool UseHeaders => true;
                /// <summary>
                /// Default initializer
                /// </summary>
                public KeyBuffered(string selectorName)
                {
                    keySerDesName = Encoding.UTF8.GetBytes(selectorName);
                    if (KNetSerialization.IsInternalManaged<TData>())
                    {
                        _defaultSerDes = new SerDesBuffered<TData>();
                        keyTypeName = Encoding.UTF8.GetBytes(typeof(TData).FullName!);
                    }
                    else
                    {
#if NET462_OR_GREATER
                    _serializer = new Newtonsoft.Json.JsonSerializer();
                    _serializer.Formatting = Newtonsoft.Json.Formatting.None;
#endif
                        keyTypeName = Encoding.UTF8.GetBytes(typeof(TData).ToAssemblyQualified());
                    }
                }
                /// <inheritdoc cref="SerDes{TData, TJVMT}.Serialize(string, TData)"/>
                public override Java.Nio.ByteBuffer Serialize(string topic, TData data)
                {
                    return SerializeWithHeaders(topic, null, data);
                }
                /// <inheritdoc cref="SerDes{TData, TJVMT}.SerializeWithHeaders(string, Headers, TData)"/>
                public override Java.Nio.ByteBuffer SerializeWithHeaders(string topic, Headers headers, TData data)
                {
                    headers?.Add(KNetSerialization.KeyTypeIdentifierJVM, keyTypeName);
                    headers?.Add(KNetSerialization.KeySerializerIdentifierJVM, keySerDesName);

                    if (_defaultSerDes != null) return _defaultSerDes.SerializeWithHeaders(topic, headers, data);

#if NET462_OR_GREATER
                if (UseStreamWithByteBuffer)
                {
                    var ms = new MemoryStream();
                    using (StreamWriter sw = new StreamWriter(ms, new UTF8Encoding(false), 128, true))
                    using (Newtonsoft.Json.JsonWriter writer = new Newtonsoft.Json.JsonTextWriter(sw))
                    {
                        _serializer.Serialize(writer, data);
                    }
                    return ByteBuffer.From(ms);
                }
                else
                {
                    var jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(data, Options);
                    return ByteBuffer.From(Encoding.UTF8.GetBytes(jsonStr));
                }
#else
                    var ms = new MemoryStream();
                    System.Text.Json.JsonSerializer.Serialize<TData>(ms, data, Options);
                    return ByteBuffer.From(ms);
#endif
                }
                /// <inheritdoc cref="SerDes{TData, TJVMT}.Deserialize(string, TJVMT)"/>
                public override TData Deserialize(string topic, Java.Nio.ByteBuffer data)
                {
                    return DeserializeWithHeaders(topic, null, data);
                }
                /// <inheritdoc cref="SerDes{TData, TJVMT}.DeserializeWithHeaders(string, Headers, TJVMT)"/>
                public override TData DeserializeWithHeaders(string topic, Headers headers, Java.Nio.ByteBuffer data)
                {
                    if (_defaultSerDes != null) return _defaultSerDes.DeserializeWithHeaders(topic, headers, data);
                    if (data == null) return default;
#if NET462_OR_GREATER
                if (UseStreamWithByteBuffer)
                {
                    using (StreamReader sw = new StreamReader(data.ToStream()))
                    using (Newtonsoft.Json.JsonReader reader = new Newtonsoft.Json.JsonTextReader(sw))
                    {
                        return _serializer.Deserialize<TData>(reader);
                    }
                }
                else
                {
                    var jsonStr = Encoding.UTF8.GetString((byte[])data);
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<TData>(jsonStr, Options);
                }
#else
                    return System.Text.Json.JsonSerializer.Deserialize<TData>(data.ToStream(), Options)!;
#endif
                }
            }
        }

        /// <summary>
        /// Json extension of <see cref="ISerDesSelector{T}"/> for Value, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class Value<T> : ISerDesSelector<T>
        {
            /// <summary>
            /// Returns a new instance of <see cref="Value{T}"/>
            /// </summary>
            /// <returns>The <see cref="ISerDesSelector{T}"/> of <see cref="Value{T}"/></returns>
            public static ISerDesSelector<T> NewInstance() => new Value<T>();
            /// <inheritdoc cref="ISerDesSelector.SelectorTypeName"/>
            public static string SelectorTypeName => typeof(Value<>).ToAssemblyQualified();
            /// <inheritdoc cref="ISerDesSelector.ByteArraySerDes"/>
            public static Type ByteArraySerDes => typeof(ValueRaw<T>);
            /// <inheritdoc cref="ISerDesSelector.ByteBufferSerDes"/>
            public static Type ByteBufferSerDes => typeof(ValueBuffered<T>);
            /// <inheritdoc cref="ISerDesSelector{T}.NewSerDes{TJVM}"/>
            public static ISerDes<T, TJVM> NewSerDes<TJVM>()
            {
                if (typeof(TJVM) == typeof(Java.Nio.ByteBuffer)) return NewByteBufferSerDes() as ISerDes<T, TJVM>;
                return NewByteArraySerDes() as ISerDes<T, TJVM>;
            }
            /// <inheritdoc cref="ISerDesSelector{T}.NewByteArraySerDes"/>
            public static ISerDesRaw<T> NewByteArraySerDes() { return new ValueRaw<T>(SelectorTypeName); }
            /// <inheritdoc cref="ISerDesSelector{T}.NewByteBufferSerDes"/>
            public static ISerDesBuffered<T> NewByteBufferSerDes() { return new ValueBuffered<T>(SelectorTypeName); }

            /// <inheritdoc cref="ISerDesSelector.SelectorTypeName"/>
            string ISerDesSelector.SelectorTypeName => SelectorTypeName;
            /// <inheritdoc cref="ISerDesSelector.ByteArraySerDes"/>
            Type ISerDesSelector.ByteArraySerDes => ByteArraySerDes;
            /// <inheritdoc cref="ISerDesSelector.ByteBufferSerDes"/>
            Type ISerDesSelector.ByteBufferSerDes => ByteBufferSerDes;
            /// <inheritdoc cref="ISerDesSelector{T}.NewSerDes{TJVM}"/>
            ISerDes<T, TJVM> ISerDesSelector<T>.NewSerDes<TJVM>() => NewSerDes<TJVM>();
            /// <inheritdoc cref="ISerDesSelector{T}.NewByteArraySerDes"/>
            ISerDesRaw<T> ISerDesSelector<T>.NewByteArraySerDes() => NewByteArraySerDes();
            /// <inheritdoc cref="ISerDesSelector{T}.NewByteBufferSerDes"/>
            ISerDesBuffered<T> ISerDesSelector<T>.NewByteBufferSerDes() => NewByteBufferSerDes();

            /// <summary>
            /// Json extension of <see cref="SerDes{TData, TJVMT}"/> for Value, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
            /// </summary>
            /// <typeparam name="TData"></typeparam>
            sealed class ValueRaw<TData> : SerDesRaw<TData>
            {
                readonly byte[] valueSerDesName;
                readonly byte[] valueTypeName = null!;
                readonly ISerDesRaw<TData> _defaultSerDes = default!;
#if NET462_OR_GREATER
                /// <summary>
                /// Settings used from <see cref="JsonConvert.DeserializeObject(string, JsonSerializerSettings)"/> and <see cref="JsonConvert.SerializeObject(object?, JsonSerializerSettings?)"/>
                /// </summary>
                public JsonSerializerSettings Options { get; set; } = new JsonSerializerSettings();
#else
                /// <summary>
                /// Settings used from <see cref="JsonSerializer.Deserialize(Stream, JsonSerializerOptions?)"/> and <see cref="JsonSerializer.Serialize{TValue}(TValue, JsonSerializerOptions?)"/>
                /// </summary>
                public JsonSerializerOptions Options { get; set; } = new JsonSerializerOptions();
#endif
                /// <inheritdoc/>
                public override bool UseHeaders => true;
                /// <summary>
                /// Default initializer
                /// </summary>
                public ValueRaw(string selectorName)
                {
                    valueSerDesName = Encoding.UTF8.GetBytes(selectorName);
                    if (KNetSerialization.IsInternalManaged<TData>())
                    {
                        _defaultSerDes = new SerDesRaw<TData>();
                        valueTypeName = Encoding.UTF8.GetBytes(typeof(TData).FullName!);
                    }
                    else
                    {
                        valueTypeName = Encoding.UTF8.GetBytes(typeof(TData).ToAssemblyQualified());
                    }
                }
                /// <inheritdoc cref="SerDes{TData, TJVMT}.Serialize(string, TData)"/>
                public override byte[] Serialize(string topic, TData data)
                {
                    return SerializeWithHeaders(topic, null, data);
                }
                /// <inheritdoc cref="SerDes{TData, TJVMT}.SerializeWithHeaders(string, Headers, TData)"/>
                public override byte[] SerializeWithHeaders(string topic, Headers headers, TData data)
                {
                    headers?.Add(KNetSerialization.ValueSerializerIdentifierJVM, valueSerDesName);
                    headers?.Add(KNetSerialization.ValueTypeIdentifierJVM, valueTypeName);

                    if (_defaultSerDes != null) return _defaultSerDes.SerializeWithHeaders(topic, headers, data);

#if NET462_OR_GREATER
                    var jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(data, Options);
                    return Encoding.UTF8.GetBytes(jsonStr);
#else
                    var jsonStr = System.Text.Json.JsonSerializer.Serialize<TData>(data, Options);
                    return Encoding.UTF8.GetBytes(jsonStr);
#endif
                }
                /// <inheritdoc cref="SerDes{TData, TJVMT}.Deserialize(string, TJVMT)"/>
                public override TData Deserialize(string topic, byte[] data)
                {
                    return DeserializeWithHeaders(topic, null, data);
                }
                /// <inheritdoc cref="SerDes{TData, TJVMT}.DeserializeWithHeaders(string, Headers, TJVMT)"/>
                public override TData DeserializeWithHeaders(string topic, Headers headers, byte[] data)
                {
                    if (_defaultSerDes != null) return _defaultSerDes.DeserializeWithHeaders(topic, headers, data);

                    if (data == null) return default;
#if NET462_OR_GREATER
                    var jsonStr = Encoding.UTF8.GetString(data);
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<TData>(jsonStr, Options);
#else
                    return System.Text.Json.JsonSerializer.Deserialize<TData>(data, Options)!;
#endif
                }
            }

            /// <summary>
            /// Json extension of <see cref="SerDes{TData, TJVMT}"/> for Value, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
            /// </summary>
            /// <typeparam name="TData"></typeparam>
            sealed class ValueBuffered<TData> : SerDesBuffered<TData>
            {
#if NET462_OR_GREATER
                readonly Newtonsoft.Json.JsonSerializer _serializer;
#endif
                readonly byte[] valueSerDesName;
                readonly byte[] valueTypeName = null!;
                readonly ISerDesBuffered<TData> _defaultSerDes = default!;
#if NET462_OR_GREATER
                /// <summary>
                /// When set to <see langword="true"/> the oprion forces <see cref="ValueBuffered{TData}"/> to use <see cref="System.IO.Stream"/> with <see cref="Java.Nio.ByteBuffer"/> to reduce memory copy
                /// </summary>
                /// <remarks>Added specifically to .NET Framework because NewtonSoft JSon seems to have problems with large streams</remarks>
                public bool UseByteBufferWithStream { get; set; } = true;
                /// <summary>
                /// Settings used from <see cref="JsonConvert.DeserializeObject(string, JsonSerializerSettings)"/> and <see cref="JsonConvert.SerializeObject(object?, JsonSerializerSettings?)"/>
                /// </summary>
                public JsonSerializerSettings Options { get; set; } = new JsonSerializerSettings();
#else
                /// <summary>
                /// Settings used from <see cref="JsonSerializer.Deserialize(Stream, JsonSerializerOptions?)"/> and <see cref="JsonSerializer.Serialize{TValue}(TValue, JsonSerializerOptions?)"/>
                /// </summary>
                public JsonSerializerOptions Options { get; set; } = new JsonSerializerOptions();
#endif
                /// <inheritdoc/>
                public override bool UseHeaders => true;
                /// <summary>
                /// Default initializer
                /// </summary>
                public ValueBuffered(string selectorName)
                {
                    valueSerDesName = Encoding.UTF8.GetBytes(selectorName);
                    if (KNetSerialization.IsInternalManaged<TData>())
                    {
                        _defaultSerDes = new SerDesBuffered<TData>();
                        valueTypeName = Encoding.UTF8.GetBytes(typeof(TData).FullName!);
                    }
                    else
                    {
#if NET462_OR_GREATER
                        _serializer = new Newtonsoft.Json.JsonSerializer();
                        _serializer.Formatting = Newtonsoft.Json.Formatting.None;
#endif
                        valueTypeName = Encoding.UTF8.GetBytes(typeof(TData).ToAssemblyQualified());
                    }
                }
                /// <inheritdoc cref="SerDes{TData, TJVMT}.Serialize(string, TData)"/>
                public override Java.Nio.ByteBuffer Serialize(string topic, TData data)
                {
                    return SerializeWithHeaders(topic, null, data);
                }
                /// <inheritdoc cref="SerDes{TData, TJVMT}.SerializeWithHeaders(string, Headers, TData)"/>
                public override Java.Nio.ByteBuffer SerializeWithHeaders(string topic, Headers headers, TData data)
                {
                    headers?.Add(KNetSerialization.ValueSerializerIdentifierJVM, valueSerDesName);
                    headers?.Add(KNetSerialization.ValueTypeIdentifierJVM, valueTypeName);

                    if (_defaultSerDes != null) return _defaultSerDes.SerializeWithHeaders(topic, headers, data);

#if NET462_OR_GREATER
                    if (UseByteBufferWithStream)
                    {
                        var ms = new MemoryStream();
                        using (StreamWriter sw = new StreamWriter(ms, new UTF8Encoding(false), 128, true))
                        using (Newtonsoft.Json.JsonWriter writer = new Newtonsoft.Json.JsonTextWriter(sw))
                        {
                            _serializer.Serialize(writer, data);
                        }
                        return ByteBuffer.From(ms);
                    }
                    else
                    {
                        var jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(data, Options);
                        return ByteBuffer.From(Encoding.UTF8.GetBytes(jsonStr));
                    }
#else
                    var ms = new MemoryStream();
                    System.Text.Json.JsonSerializer.Serialize<TData>(ms, data, Options);
                    return ByteBuffer.From(ms);
#endif
                }
                /// <inheritdoc cref="SerDes{TData, TJVMT}.Deserialize(string, TJVMT)"/>
                public override TData Deserialize(string topic, Java.Nio.ByteBuffer data)
                {
                    return DeserializeWithHeaders(topic, null, data);
                }
                /// <inheritdoc cref="SerDes{TData, TJVMT}.DeserializeWithHeaders(string, Headers, TJVMT)"/>
                public override TData DeserializeWithHeaders(string topic, Headers headers, Java.Nio.ByteBuffer data)
                {
                    if (_defaultSerDes != null) return _defaultSerDes.DeserializeWithHeaders(topic, headers, data);

                    if (data == null) return default;
#if NET462_OR_GREATER
                    if (UseByteBufferWithStream)
                    {
                        using (StreamReader sw = new StreamReader(data.ToStream()))
                        using (Newtonsoft.Json.JsonReader reader = new Newtonsoft.Json.JsonTextReader(sw))
                        {
                            return _serializer.Deserialize<TData>(reader);
                        }
                    }
                    else
                    {
                        var jsonStr = Encoding.UTF8.GetString((byte[])data);
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<TData>(jsonStr, Options);
                    }
#else
                    return System.Text.Json.JsonSerializer.Deserialize<TData>(data.ToStream(), Options)!;
#endif
                }
            }
        }
    }
}
