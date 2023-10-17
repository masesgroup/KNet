/*
*  Copyright 2023 MASES s.r.l.
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

using global::Avro.IO;
using global::Avro.Specific;
using Org.Apache.Kafka.Common.Header;
using System;
using System.IO;
using System.Text;

namespace MASES.KNet.Serialization.Avro
{
    /// <summary>
    /// Base class to define extensions of <see cref="KNetSerDes{T}"/> for Avro, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
    /// </summary>
    public static class AvroSerDes
    {
        /// <summary>
        /// Base class to define Key extensions of <see cref="KNetSerDes{T}"/>, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
        /// </summary>
        public static class Key
        {
            /// <summary>
            /// Avro Key extension of <see cref="KNetSerDes{T}"/> for Binary encoding, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
            /// </summary>
            /// <typeparam name="T"></typeparam>
            public class Binary<T> : KNetSerDes<T> where T : class, new()
            {
                global::Avro.Schema _schema;
                /// <summary>
                /// Use this property to set the <see cref="global::Avro.Schema"/> of <typeparamref name="T"/>
                /// </summary>
                public global::Avro.Schema Schema
                {
                    get { return _schema; }
                    set
                    {
                        _schema = value;
                        SpecificWriter = new SpecificDefaultWriter(_schema); 
                        SpecificReader = new SpecificDefaultReader(_schema, _schema);
                    }
                }

                SpecificDefaultWriter SpecificWriter = null;
                SpecificDefaultReader SpecificReader = null;

                readonly byte[] keySerDesName = Encoding.UTF8.GetBytes(typeof(Binary<>).ToAssemblyQualified());
                readonly byte[] keyTypeName = null;
                readonly IKNetSerDes<T> _defaultSerDes = default!;
                /// <inheritdoc/>
                public override bool UseHeaders => true;
                /// <summary>
                /// Default initializer
                /// </summary>
                public Binary()
                {
                    if (KNetSerialization.IsInternalManaged<T>())
                    {
                        _defaultSerDes = new KNetSerDes<T>();
                        keyTypeName = Encoding.UTF8.GetBytes(typeof(T).FullName!);
                    }
                    else
                    {
                        keyTypeName = Encoding.UTF8.GetBytes(typeof(T).ToAssemblyQualified());
                    }
                }
                /// <inheritdoc cref="KNetSerDes{T}.Serialize(string, T)"/>
                public override byte[] Serialize(string topic, T data)
                {
                    return SerializeWithHeaders(topic, null, data);
                }
                /// <inheritdoc cref="KNetSerDes{T}.SerializeWithHeaders(string, Headers, T)"/>
                public override byte[] SerializeWithHeaders(string topic, Headers headers, T data)
                {
                    headers?.Add(KNetSerialization.KeyTypeIdentifier, keyTypeName);
                    headers?.Add(KNetSerialization.KeySerializerIdentifier, keySerDesName);

                    if (_defaultSerDes != null) return _defaultSerDes.SerializeWithHeaders(topic, headers, data);

                    if (SpecificWriter == null) throw new InvalidOperationException("Set property Schema before use this serializer");

                    using MemoryStream memStream = new();
                    BinaryEncoder encoder = new(memStream);
                    SpecificWriter.Write(data, encoder);
                    return memStream.ToArray();
                }
                /// <inheritdoc cref="KNetSerDes{T}.Deserialize(string, byte[])"/>
                public override T Deserialize(string topic, byte[] data)
                {
                    return DeserializeWithHeaders(topic, null, data);
                }
                /// <inheritdoc cref="KNetSerDes{T}.DeserializeWithHeaders(string, Headers, byte[])"/>
                public override T DeserializeWithHeaders(string topic, Headers headers, byte[] data)
                {
                    if (_defaultSerDes != null) return _defaultSerDes.DeserializeWithHeaders(topic, headers, data);
                    if (data == null) return default;

                    if (SpecificReader == null) throw new InvalidOperationException("Set property Schema before use this serializer");

                    using MemoryStream memStream = new(data);
                    BinaryDecoder decoder = new(memStream);
                    T t = new T();
                    t = SpecificReader.Read(t!, decoder);
                    return t;
                }
            }
            /// <summary>
            /// Avro Key extension of <see cref="KNetSerDes{T}"/> for Json encoding, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
            /// </summary>
            /// <typeparam name="T"></typeparam>
            public class Json<T> : KNetSerDes<T> where T : class, new()
            {
                global::Avro.Schema _schema;
                /// <summary>
                /// Use this property to set the <see cref="global::Avro.Schema"/> of <typeparamref name="T"/>
                /// </summary>
                public global::Avro.Schema Schema
                {
                    get { return _schema; }
                    set
                    {
                        _schema = value;
                        SpecificWriter = new SpecificDefaultWriter(_schema);
                        SpecificReader = new SpecificDefaultReader(_schema, _schema);
                    }
                }

                SpecificDefaultWriter SpecificWriter = null;
                SpecificDefaultReader SpecificReader = null;

                readonly byte[] keySerDesName = Encoding.UTF8.GetBytes(typeof(Json<>).ToAssemblyQualified());
                readonly byte[] keyTypeName = null;
                readonly IKNetSerDes<T> _defaultSerDes = default!;
                /// <inheritdoc/>
                public override bool UseHeaders => true;
                /// <summary>
                /// Default initializer
                /// </summary>
                public Json()
                {
                    if (KNetSerialization.IsInternalManaged<T>())
                    {
                        _defaultSerDes = new KNetSerDes<T>();
                        keyTypeName = Encoding.UTF8.GetBytes(typeof(T).FullName!);
                    }
                    else
                    {
                        keyTypeName = Encoding.UTF8.GetBytes(typeof(T).ToAssemblyQualified());
                    }
                }
                /// <inheritdoc cref="KNetSerDes{T}.Serialize(string, T)"/>
                public override byte[] Serialize(string topic, T data)
                {
                    return SerializeWithHeaders(topic, null, data);
                }
                /// <inheritdoc cref="KNetSerDes{T}.SerializeWithHeaders(string, Headers, T)"/>
                public override byte[] SerializeWithHeaders(string topic, Headers headers, T data)
                {
                    headers?.Add(KNetSerialization.KeyTypeIdentifier, keyTypeName);
                    headers?.Add(KNetSerialization.KeySerializerIdentifier, keySerDesName);

                    if (_defaultSerDes != null) return _defaultSerDes.SerializeWithHeaders(topic, headers, data);

                    if (SpecificWriter == null) throw new InvalidOperationException("Set property Schema before use this serializer");

                    using MemoryStream memStream = new();
                    JsonEncoder encoder = new(Schema, memStream);
                    SpecificWriter.Write(data, encoder);
                    return memStream.ToArray();
                }
                /// <inheritdoc cref="KNetSerDes{T}.Deserialize(string, byte[])"/>
                public override T Deserialize(string topic, byte[] data)
                {
                    return DeserializeWithHeaders(topic, null, data);
                }
                /// <inheritdoc cref="KNetSerDes{T}.DeserializeWithHeaders(string, Headers, byte[])"/>
                public override T DeserializeWithHeaders(string topic, Headers headers, byte[] data)
                {
                    if (_defaultSerDes != null) return _defaultSerDes.DeserializeWithHeaders(topic, headers, data);
                    if (data == null) return default;

                    if (SpecificReader == null) throw new InvalidOperationException("Set property Schema before use this serializer");

                    using MemoryStream memStream = new(data);
                    JsonDecoder decoder = new(Schema, memStream);
                    T t = new T();
                    t = SpecificReader.Read(t!, decoder);
                    return t;
                }
            }
        }

        /// <summary>
        /// Base class to define Value extensions of <see cref="KNetSerDes{T}"/>, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
        /// </summary>
        public static class Value
        {
            /// <summary>
            /// Avro Value extension of <see cref="KNetSerDes{T}"/> for Binary encoding, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
            /// </summary>
            /// <typeparam name="T"></typeparam>
            public class Binary<T> : KNetSerDes<T> where T : class, new()
            {
                global::Avro.Schema _schema;
                /// <summary>
                /// Use this property to set the <see cref="global::Avro.Schema"/> of <typeparamref name="T"/>
                /// </summary>
                public global::Avro.Schema Schema
                {
                    get { return _schema; }
                    set
                    {
                        _schema = value;
                        SpecificWriter = new SpecificDefaultWriter(_schema);
                        SpecificReader = new SpecificDefaultReader(_schema, _schema);
                    }
                }

                SpecificDefaultWriter SpecificWriter = null;
                SpecificDefaultReader SpecificReader = null;

                readonly byte[] valueSerDesName = Encoding.UTF8.GetBytes(typeof(Binary<>).ToAssemblyQualified());
                readonly byte[] valueTypeName = null!;
                readonly IKNetSerDes<T> _defaultSerDes = default!;
                /// <inheritdoc/>
                public override bool UseHeaders => true;
                /// <summary>
                /// Default initializer
                /// </summary>
                public Binary()
                {
                    if (KNetSerialization.IsInternalManaged<T>())
                    {
                        _defaultSerDes = new KNetSerDes<T>();
                        valueTypeName = Encoding.UTF8.GetBytes(typeof(T).FullName!);
                    }
                    else
                    {
                        valueTypeName = Encoding.UTF8.GetBytes(typeof(T).ToAssemblyQualified());
                    }
                }
                /// <inheritdoc cref="KNetSerDes{T}.Serialize(string, T)"/>
                public override byte[] Serialize(string topic, T data)
                {
                    return SerializeWithHeaders(topic, null, data);
                }
                /// <inheritdoc cref="KNetSerDes{T}.SerializeWithHeaders(string, Headers, T)"/>
                public override byte[] SerializeWithHeaders(string topic, Headers headers, T data)
                {
                    headers?.Add(KNetSerialization.ValueSerializerIdentifier, valueSerDesName);
                    headers?.Add(KNetSerialization.ValueTypeIdentifier, valueTypeName);

                    if (_defaultSerDes != null) return _defaultSerDes.SerializeWithHeaders(topic, headers, data);

                    if (SpecificWriter == null) throw new InvalidOperationException("Set property Schema before use this serializer");

                    using MemoryStream memStream = new();
                    BinaryEncoder encoder = new(memStream);
                    SpecificWriter.Write(data, encoder);
                    return memStream.ToArray();
                }
                /// <inheritdoc cref="KNetSerDes{T}.Deserialize(string, byte[])"/>
                public override T Deserialize(string topic, byte[] data)
                {
                    return DeserializeWithHeaders(topic, null, data);
                }
                /// <inheritdoc cref="KNetSerDes{T}.DeserializeWithHeaders(string, Headers, byte[])"/>
                public override T DeserializeWithHeaders(string topic, Headers headers, byte[] data)
                {
                    if (_defaultSerDes != null) return _defaultSerDes.DeserializeWithHeaders(topic, headers, data);

                    if (data == null) return default;

                    if (SpecificReader == null) throw new InvalidOperationException("Set property Schema before use this serializer");

                    using MemoryStream memStream = new(data);
                    BinaryDecoder decoder = new(memStream);
                    T t = new T();
                    t = SpecificReader.Read(t!, decoder);
                    return t;
                }
            }
            /// <summary>
            /// Avro Value extension of <see cref="KNetSerDes{T}"/> for Json encoding, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
            /// </summary>
            /// <typeparam name="T"></typeparam>
            public class Json<T> : KNetSerDes<T> where T : class, new()
            {
                global::Avro.Schema _schema;
                /// <summary>
                /// Use this property to set the <see cref="global::Avro.Schema"/> of <typeparamref name="T"/>
                /// </summary>
                public global::Avro.Schema Schema
                {
                    get { return _schema; }
                    set
                    {
                        _schema = value;
                        SpecificWriter = new SpecificDefaultWriter(_schema);
                        SpecificReader = new SpecificDefaultReader(_schema, _schema);
                    }
                }

                SpecificDefaultWriter SpecificWriter = null;
                SpecificDefaultReader SpecificReader = null;

                readonly byte[] valueSerDesName = Encoding.UTF8.GetBytes(typeof(Json<>).ToAssemblyQualified());
                readonly byte[] valueTypeName = null!;
                readonly IKNetSerDes<T> _defaultSerDes = default!;
                /// <inheritdoc/>
                public override bool UseHeaders => true;
                /// <summary>
                /// Default initializer
                /// </summary>
                public Json()
                {
                    if (KNetSerialization.IsInternalManaged<T>())
                    {
                        _defaultSerDes = new KNetSerDes<T>();
                        valueTypeName = Encoding.UTF8.GetBytes(typeof(T).FullName!);
                    }
                    else
                    {
                        valueTypeName = Encoding.UTF8.GetBytes(typeof(T).ToAssemblyQualified());
                    }
                }
                /// <inheritdoc cref="KNetSerDes{T}.Serialize(string, T)"/>
                public override byte[] Serialize(string topic, T data)
                {
                    return SerializeWithHeaders(topic, null, data);
                }
                /// <inheritdoc cref="KNetSerDes{T}.SerializeWithHeaders(string, Headers, T)"/>
                public override byte[] SerializeWithHeaders(string topic, Headers headers, T data)
                {
                    headers?.Add(KNetSerialization.ValueSerializerIdentifier, valueSerDesName);
                    headers?.Add(KNetSerialization.ValueTypeIdentifier, valueTypeName);

                    if (_defaultSerDes != null) return _defaultSerDes.SerializeWithHeaders(topic, headers, data);

                    if (SpecificWriter == null) throw new InvalidOperationException("Set property Schema before use this serializer");

                    using MemoryStream memStream = new();
                    JsonEncoder encoder = new(Schema, memStream);
                    SpecificWriter.Write(data, encoder);
                    return memStream.ToArray();
                }
                /// <inheritdoc cref="KNetSerDes{T}.Deserialize(string, byte[])"/>
                public override T Deserialize(string topic, byte[] data)
                {
                    return DeserializeWithHeaders(topic, null, data);
                }
                /// <inheritdoc cref="KNetSerDes{T}.DeserializeWithHeaders(string, Headers, byte[])"/>
                public override T DeserializeWithHeaders(string topic, Headers headers, byte[] data)
                {
                    if (_defaultSerDes != null) return _defaultSerDes.DeserializeWithHeaders(topic, headers, data);

                    if (data == null) return default;

                    if (SpecificReader == null) throw new InvalidOperationException("Set property Schema before use this serializer");

                    using MemoryStream memStream = new(data);
                    JsonDecoder decoder = new(Schema, memStream);
                    T t = new T();
                    t = SpecificReader.Read(t!, decoder);
                    return t;
                }
            }
        }
    }
}
