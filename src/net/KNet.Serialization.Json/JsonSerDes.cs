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
    /// Base class to define extensions of <see cref="SerDes{T, TJVMT}"/> for Json, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
    /// </summary>
    public static class JsonSerDes
    {
        /// <summary>
        /// Json extension of <see cref="SerDes{T, TJVMT}"/> for Key, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class KeyRaw<T> : SerDes<T, byte[]>
        {
            readonly byte[] keySerDesName = Encoding.UTF8.GetBytes(typeof(KeyRaw<>).ToAssemblyQualified());
            readonly byte[] keyTypeName = null;
            readonly ISerDes<T, byte[]> _defaultSerDes = default!;
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
            public KeyRaw()
            {
                if (KNetSerialization.IsInternalManaged<T>())
                {
                    _defaultSerDes = new SerDes<T, byte[]>();
                    keyTypeName = Encoding.UTF8.GetBytes(typeof(T).FullName!);
                }
                else
                {
                    keyTypeName = Encoding.UTF8.GetBytes(typeof(T).ToAssemblyQualified());
                }
            }
            /// <inheritdoc cref="SerDes{T, TJVMT}.Serialize(string, T)"/>
            public override byte[] Serialize(string topic, T data)
            {
                return SerializeWithHeaders(topic, null, data);
            }
            /// <inheritdoc cref="SerDes{T, TJVMT}.SerializeWithHeaders(string, Headers, T)"/>
            public override byte[] SerializeWithHeaders(string topic, Headers headers, T data)
            {
                headers?.Add(KNetSerialization.KeyTypeIdentifier, keyTypeName);
                headers?.Add(KNetSerialization.KeySerializerIdentifier, keySerDesName);

                if (_defaultSerDes != null) return _defaultSerDes.SerializeWithHeaders(topic, headers, data);

#if NET462_OR_GREATER
                var jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(data, Options);
                return Encoding.UTF8.GetBytes(jsonStr);
#else
                var jsonStr = System.Text.Json.JsonSerializer.Serialize<T>(data, Options);
                return Encoding.UTF8.GetBytes(jsonStr);
#endif
            }
            /// <inheritdoc cref="SerDes{T, TJVMT}.Deserialize(string, TJVMT)"/>
            public override T Deserialize(string topic, byte[] data)
            {
                return DeserializeWithHeaders(topic, null, data);
            }
            /// <inheritdoc cref="SerDes{T, TJVMT}.DeserializeWithHeaders(string, Headers, TJVMT)"/>
            public override T DeserializeWithHeaders(string topic, Headers headers, byte[] data)
            {
                if (_defaultSerDes != null) return _defaultSerDes.DeserializeWithHeaders(topic, headers, data);
                if (data == null) return default;
#if NET462_OR_GREATER
                var jsonStr = Encoding.UTF8.GetString(data);
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonStr, Options);
#else
                return System.Text.Json.JsonSerializer.Deserialize<T>(data, Options)!;
#endif
            }
        }

        /// <summary>
        /// Json extension of <see cref="SerDes{T, TJVMT}"/> for Key, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class KeyBuffered<T> : SerDesBuffered<T>
        {
#if NET462_OR_GREATER
            readonly Newtonsoft.Json.JsonSerializer _serializer;
#endif
            readonly byte[] keySerDesName = Encoding.UTF8.GetBytes(typeof(KeyBuffered<>).ToAssemblyQualified());
            readonly byte[] keyTypeName = null;
            readonly ISerDesBuffered<T> _defaultSerDes = default!;
#if NET462_OR_GREATER
            /// <summary>
            /// When set to <see langword="true"/> the oprion forces <see cref="ValueBuffered{T}"/> to use <see cref="System.IO.Stream"/> with <see cref="Java.Nio.ByteBuffer"/> to reduce memory copy
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
            public KeyBuffered()
            {
                if (KNetSerialization.IsInternalManaged<T>())
                {
                    _defaultSerDes = new SerDesBuffered<T>();
                    keyTypeName = Encoding.UTF8.GetBytes(typeof(T).FullName!);
                }
                else
                {
#if NET462_OR_GREATER
                    _serializer = new Newtonsoft.Json.JsonSerializer();
                    _serializer.Formatting = Newtonsoft.Json.Formatting.None;
#endif
                    keyTypeName = Encoding.UTF8.GetBytes(typeof(T).ToAssemblyQualified());
                }
            }
            /// <inheritdoc cref="SerDes{T, TJVMT}.Serialize(string, T)"/>
            public override Java.Nio.ByteBuffer Serialize(string topic, T data)
            {
                return SerializeWithHeaders(topic, null, data);
            }
            /// <inheritdoc cref="SerDes{T, TJVMT}.SerializeWithHeaders(string, Headers, T)"/>
            public override Java.Nio.ByteBuffer SerializeWithHeaders(string topic, Headers headers, T data)
            {
                headers?.Add(KNetSerialization.KeyTypeIdentifier, keyTypeName);
                headers?.Add(KNetSerialization.KeySerializerIdentifier, keySerDesName);

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
                System.Text.Json.JsonSerializer.Serialize<T>(ms, data, Options);
                return ByteBuffer.From(ms);
#endif
            }
            /// <inheritdoc cref="SerDes{T, TJVMT}.Deserialize(string, TJVMT)"/>
            public override T Deserialize(string topic, Java.Nio.ByteBuffer data)
            {
                return DeserializeWithHeaders(topic, null, data);
            }
            /// <inheritdoc cref="SerDes{T, TJVMT}.DeserializeWithHeaders(string, Headers, TJVMT)"/>
            public override T DeserializeWithHeaders(string topic, Headers headers, Java.Nio.ByteBuffer data)
            {
                if (_defaultSerDes != null) return _defaultSerDes.DeserializeWithHeaders(topic, headers, data);
                if (data == null) return default;
#if NET462_OR_GREATER
                if (UseStreamWithByteBuffer)
                {
                    using (StreamReader sw = new StreamReader(data.ToStream()))
                    using (Newtonsoft.Json.JsonReader reader = new Newtonsoft.Json.JsonTextReader(sw))
                    {
                        return _serializer.Deserialize<T>(reader);
                    }
                }
                else
                {
                    var jsonStr = Encoding.UTF8.GetString((byte[])data);
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonStr, Options);
                }
#else
                return System.Text.Json.JsonSerializer.Deserialize<T>(data.ToStream(), Options)!;
#endif
            }
        }

        /// <summary>
        /// Json extension of <see cref="SerDes{T, TJVMT}"/> for Value, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class ValueRaw<T> : SerDesRaw<T>
        {
            readonly byte[] valueSerDesName = Encoding.UTF8.GetBytes(typeof(ValueRaw<>).ToAssemblyQualified());
            readonly byte[] valueTypeName = null!;
            readonly ISerDes<T, byte[]> _defaultSerDes = default!;
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
            public ValueRaw()
            {
                if (KNetSerialization.IsInternalManaged<T>())
                {
                    _defaultSerDes = new SerDesRaw<T>();
                    valueTypeName = Encoding.UTF8.GetBytes(typeof(T).FullName!);
                }
                else
                {
                    valueTypeName = Encoding.UTF8.GetBytes(typeof(T).ToAssemblyQualified());
                }
            }
            /// <inheritdoc cref="SerDes{T, TJVMT}.Serialize(string, T)"/>
            public override byte[] Serialize(string topic, T data)
            {
                return SerializeWithHeaders(topic, null, data);
            }
            /// <inheritdoc cref="SerDes{T, TJVMT}.SerializeWithHeaders(string, Headers, T)"/>
            public override byte[] SerializeWithHeaders(string topic, Headers headers, T data)
            {
                headers?.Add(KNetSerialization.ValueSerializerIdentifier, valueSerDesName);
                headers?.Add(KNetSerialization.ValueTypeIdentifier, valueTypeName);

                if (_defaultSerDes != null) return _defaultSerDes.SerializeWithHeaders(topic, headers, data);

#if NET462_OR_GREATER
                var jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(data, Options);
                return Encoding.UTF8.GetBytes(jsonStr);
#else
                var jsonStr = System.Text.Json.JsonSerializer.Serialize<T>(data, Options);
                return Encoding.UTF8.GetBytes(jsonStr);
#endif
            }
            /// <inheritdoc cref="SerDes{T, TJVMT}.Deserialize(string, TJVMT)"/>
            public override T Deserialize(string topic, byte[] data)
            {
                return DeserializeWithHeaders(topic, null, data);
            }
            /// <inheritdoc cref="SerDes{T, TJVMT}.DeserializeWithHeaders(string, Headers, TJVMT)"/>
            public override T DeserializeWithHeaders(string topic, Headers headers, byte[] data)
            {
                if (_defaultSerDes != null) return _defaultSerDes.DeserializeWithHeaders(topic, headers, data);

                if (data == null) return default;
#if NET462_OR_GREATER
                var jsonStr = Encoding.UTF8.GetString(data);
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonStr, Options);
#else
                return System.Text.Json.JsonSerializer.Deserialize<T>(data, Options)!;
#endif
            }
        }

        /// <summary>
        /// Json extension of <see cref="SerDes{T, TJVMT}"/> for Value, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class ValueBuffered<T> : SerDesBuffered<T>
        {
#if NET462_OR_GREATER
            readonly Newtonsoft.Json.JsonSerializer _serializer;
#endif
            readonly byte[] valueSerDesName = Encoding.UTF8.GetBytes(typeof(ValueBuffered<>).ToAssemblyQualified());
            readonly byte[] valueTypeName = null!;
            readonly ISerDesBuffered<T> _defaultSerDes = default!;
#if NET462_OR_GREATER
            /// <summary>
            /// When set to <see langword="true"/> the oprion forces <see cref="ValueBuffered{T}"/> to use <see cref="System.IO.Stream"/> with <see cref="Java.Nio.ByteBuffer"/> to reduce memory copy
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
            public ValueBuffered()
            {
                if (KNetSerialization.IsInternalManaged<T>())
                {
                    _defaultSerDes = new SerDesBuffered<T>();
                    valueTypeName = Encoding.UTF8.GetBytes(typeof(T).FullName!);
                }
                else
                {
#if NET462_OR_GREATER
                    _serializer = new Newtonsoft.Json.JsonSerializer();
                    _serializer.Formatting = Newtonsoft.Json.Formatting.None;
#endif
                    valueTypeName = Encoding.UTF8.GetBytes(typeof(T).ToAssemblyQualified());
                }
            }
            /// <inheritdoc cref="SerDes{T, TJVMT}.Serialize(string, T)"/>
            public override Java.Nio.ByteBuffer Serialize(string topic, T data)
            {
                return SerializeWithHeaders(topic, null, data);
            }
            /// <inheritdoc cref="SerDes{T, TJVMT}.SerializeWithHeaders(string, Headers, T)"/>
            public override Java.Nio.ByteBuffer SerializeWithHeaders(string topic, Headers headers, T data)
            {
                headers?.Add(KNetSerialization.ValueSerializerIdentifier, valueSerDesName);
                headers?.Add(KNetSerialization.ValueTypeIdentifier, valueTypeName);

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
                System.Text.Json.JsonSerializer.Serialize<T>(ms, data, Options);
                return ByteBuffer.From(ms);
#endif
            }
            /// <inheritdoc cref="SerDes{T, TJVMT}.Deserialize(string, TJVMT)"/>
            public override T Deserialize(string topic, Java.Nio.ByteBuffer data)
            {
                return DeserializeWithHeaders(topic, null, data);
            }
            /// <inheritdoc cref="SerDes{T, TJVMT}.DeserializeWithHeaders(string, Headers, TJVMT)"/>
            public override T DeserializeWithHeaders(string topic, Headers headers, Java.Nio.ByteBuffer data)
            {
                if (_defaultSerDes != null) return _defaultSerDes.DeserializeWithHeaders(topic, headers, data);

                if (data == null) return default;
#if NET462_OR_GREATER
                if (UseByteBufferWithStream)
                {
                    using (StreamReader sw = new StreamReader(data.ToStream()))
                    using (Newtonsoft.Json.JsonReader reader = new Newtonsoft.Json.JsonTextReader(sw))
                    {
                        return _serializer.Deserialize<T>(reader);
                    }
                }
                else
                {
                    var jsonStr = Encoding.UTF8.GetString((byte[])data);
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonStr, Options);
                }
#else
                return System.Text.Json.JsonSerializer.Deserialize<T>(data.ToStream(), Options)!;
#endif
            }
        }
    }
}
