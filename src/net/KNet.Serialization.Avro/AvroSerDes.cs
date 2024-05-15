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

using global::Avro;
using global::Avro.IO;
using global::Avro.Specific;
using Java.Nio;
using Org.Apache.Kafka.Common.Header;
using System;
using System.IO;
using System.Text;

namespace MASES.KNet.Serialization.Avro
{
    /// <summary>
    /// Base class to define extensions of <see cref="SerDes{T, TJVMT}"/> for Avro, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
    /// </summary>
    public static class AvroSerDes
    {
        /// <summary>
        /// Compiler support to build C# files from Avro schema files
        /// </summary>
        public static class CompilerSupport
        {
            /// <summary>
            /// Builds schema files into <paramref name="outputFolder"/> from schema strings in <paramref name="schemas"/>
            /// </summary>
            /// <param name="outputFolder">The output folder</param>
            /// <param name="schemas">The Avro schemas</param>
            public static void BuildSchemaClasses(string outputFolder, params string[] schemas)
            {
                var codegen = new CodeGen();
                foreach (var schema in schemas)
                {
                    codegen.AddSchema(schema);
                }
                codegen.GenerateCode();
                codegen.WriteTypes(outputFolder, true);
            }
            /// <summary>
            /// Builds schema files into <paramref name="outputFolder"/> from schema files in <paramref name="schemaFiles"/>
            /// </summary>
            /// <param name="outputFolder">The output folder</param>
            /// <param name="schemaFiles">The Avro schema files</param>
            public static void BuildSchemaClassesFromFiles(string outputFolder, params string[] schemaFiles)
            {
                var codegen = new CodeGen();
                foreach (var schemaFile in schemaFiles)
                {
                    var schema = File.ReadAllText(schemaFile);
                    codegen.AddSchema(schema);
                }
                codegen.GenerateCode();
                codegen.WriteTypes(outputFolder, true);
            }
        }

        /// <summary>
        /// Base class to define Key extensions of <see cref="SerDes{T, TJVMT}"/>, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
        /// </summary>
        public static class Key
        {
            /// <summary>
            /// Avro Key extension of <see cref="SerDes{T, TJVMT}"/> for Binary encoding, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
            /// </summary>
            /// <typeparam name="T"></typeparam>
            public class BinaryRaw<T> : SerDes<T, byte[]> where T : global::Avro.Specific.ISpecificRecord, new()
            {
                global::Avro.Schema _schema;
                /// <summary>
                /// Use this property to get the <see cref="global::Avro.Schema"/> of <typeparamref name="T"/>
                /// </summary>
                public global::Avro.Schema Schema
                {
                    get { return _schema; }
                    private set
                    {
                        _schema = value;
                        SpecificWriter = new SpecificDefaultWriter(_schema);
                        SpecificReader = new SpecificDefaultReader(_schema, _schema);
                    }
                }

                SpecificDefaultWriter SpecificWriter = null;
                SpecificDefaultReader SpecificReader = null;

                readonly byte[] keySerDesName = Encoding.UTF8.GetBytes(typeof(BinaryRaw<>).ToAssemblyQualified());
                readonly byte[] keyTypeName = Encoding.UTF8.GetBytes(typeof(T).ToAssemblyQualified());
                /// <inheritdoc/>
                public override bool UseHeaders => true;
                /// <summary>
                /// Default initializer
                /// </summary>
                public BinaryRaw()
                {
                    var tRecord = new T();
                    Schema = tRecord.Schema;
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

                    using MemoryStream memStream = new();
                    BinaryEncoder encoder = new(memStream);
                    SpecificWriter.Write(data, encoder);
                    return memStream.ToArray();
                }
                /// <inheritdoc cref="SerDes{T, TJVMT}.Deserialize(string, TJVMT)"/>
                public override T Deserialize(string topic, byte[] data)
                {
                    return DeserializeWithHeaders(topic, null, data);
                }
                /// <inheritdoc cref="SerDes{T, TJVMT}.DeserializeWithHeaders(string, Headers, TJVMT)"/>
                public override T DeserializeWithHeaders(string topic, Headers headers, byte[] data)
                {
                    if (data == null) return default;

                    using MemoryStream memStream = new(data);
                    BinaryDecoder decoder = new(memStream);
                    T t = new T();
                    t = SpecificReader.Read(t!, decoder);
                    return t;
                }
            }
            /// <summary>
            /// Avro Key extension of <see cref="SerDes{T, TJVMT}"/> for Binary encoding, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
            /// </summary>
            /// <typeparam name="T"></typeparam>
            public class BinaryBuffered<T> : SerDes<T, Java.Nio.ByteBuffer> where T : global::Avro.Specific.ISpecificRecord, new()
            {
                global::Avro.Schema _schema;
                /// <summary>
                /// Use this property to get the <see cref="global::Avro.Schema"/> of <typeparamref name="T"/>
                /// </summary>
                public global::Avro.Schema Schema
                {
                    get { return _schema; }
                    private set
                    {
                        _schema = value;
                        SpecificWriter = new SpecificDefaultWriter(_schema);
                        SpecificReader = new SpecificDefaultReader(_schema, _schema);
                    }
                }

                SpecificDefaultWriter SpecificWriter = null;
                SpecificDefaultReader SpecificReader = null;

                readonly byte[] keySerDesName = Encoding.UTF8.GetBytes(typeof(BinaryBuffered<>).ToAssemblyQualified());
                readonly byte[] keyTypeName = Encoding.UTF8.GetBytes(typeof(T).ToAssemblyQualified());
                /// <inheritdoc/>
                public override bool UseHeaders => true;
                /// <inheritdoc/>
                public override bool IsDirectBuffered => true;
                /// <summary>
                /// Default initializer
                /// </summary>
                public BinaryBuffered()
                {
                    var tRecord = new T();
                    Schema = tRecord.Schema;
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

                    MemoryStream memStream = new();
                    BinaryEncoder encoder = new(memStream);
                    SpecificWriter.Write(data, encoder);
                    return ByteBuffer.From(memStream);
                }
                /// <inheritdoc cref="SerDes{T, TJVMT}.Deserialize(string, TJVMT)"/>
                public override T Deserialize(string topic, Java.Nio.ByteBuffer data)
                {
                    return DeserializeWithHeaders(topic, null, data);
                }
                /// <inheritdoc cref="SerDes{T, TJVMT}.DeserializeWithHeaders(string, Headers, TJVMT)"/>
                public override T DeserializeWithHeaders(string topic, Headers headers, Java.Nio.ByteBuffer data)
                {
                    if (data == null) return default;

                    BinaryDecoder decoder = new(data.ToStream());
                    T t = new T();
                    t = SpecificReader.Read(t!, decoder);
                    return t;
                }
            }
            /// <summary>
            /// Avro Key extension of <see cref="SerDes{T, TJVMT}"/> for Json encoding, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
            /// </summary>
            /// <typeparam name="T"></typeparam>
            public class JsonRaw<T> : SerDes<T, byte[]> where T : global::Avro.Specific.ISpecificRecord, new()
            {
                global::Avro.Schema _schema;
                /// <summary>
                /// Use this property to get the <see cref="global::Avro.Schema"/> of <typeparamref name="T"/>
                /// </summary>
                public global::Avro.Schema Schema
                {
                    get { return _schema; }
                    private set
                    {
                        _schema = value;
                        SpecificWriter = new SpecificDefaultWriter(_schema);
                        SpecificReader = new SpecificDefaultReader(_schema, _schema);
                    }
                }

                SpecificDefaultWriter SpecificWriter = null;
                SpecificDefaultReader SpecificReader = null;

                readonly byte[] keySerDesName = Encoding.UTF8.GetBytes(typeof(JsonRaw<>).ToAssemblyQualified());
                readonly byte[] keyTypeName = Encoding.UTF8.GetBytes(typeof(T).ToAssemblyQualified());
                /// <inheritdoc/>
                public override bool UseHeaders => true;
                /// <summary>
                /// Default initializer
                /// </summary>
                public JsonRaw()
                {
                    var tRecord = new T();
                    Schema = tRecord.Schema;
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

                    using MemoryStream memStream = new();
                    JsonEncoder encoder = new(Schema, memStream);
                    SpecificWriter.Write(data, encoder);
                    return memStream.ToArray();
                }
                /// <inheritdoc cref="SerDes{T, TJVMT}.Deserialize(string, TJVMT)"/>
                public override T Deserialize(string topic, byte[] data)
                {
                    return DeserializeWithHeaders(topic, null, data);
                }
                /// <inheritdoc cref="SerDes{T, TJVMT}.DeserializeWithHeaders(string, Headers, TJVMT)"/>
                public override T DeserializeWithHeaders(string topic, Headers headers, byte[] data)
                {
                    if (data == null) return default;

                    using MemoryStream memStream = new(data);
                    JsonDecoder decoder = new(Schema, memStream);
                    T t = new T();
                    t = SpecificReader.Read(t!, decoder);
                    return t;
                }
            }
            /// <summary>
            /// Avro Key extension of <see cref="SerDes{T, TJVMT}"/> for Json encoding, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
            /// </summary>
            /// <typeparam name="T"></typeparam>
            public class JsonBuffered<T> : SerDes<T, Java.Nio.ByteBuffer> where T : global::Avro.Specific.ISpecificRecord, new()
            {
                global::Avro.Schema _schema;
                /// <summary>
                /// Use this property to get the <see cref="global::Avro.Schema"/> of <typeparamref name="T"/>
                /// </summary>
                public global::Avro.Schema Schema
                {
                    get { return _schema; }
                    private set
                    {
                        _schema = value;
                        SpecificWriter = new SpecificDefaultWriter(_schema);
                        SpecificReader = new SpecificDefaultReader(_schema, _schema);
                    }
                }

                SpecificDefaultWriter SpecificWriter = null;
                SpecificDefaultReader SpecificReader = null;

                readonly byte[] keySerDesName = Encoding.UTF8.GetBytes(typeof(JsonBuffered<>).ToAssemblyQualified());
                readonly byte[] keyTypeName = Encoding.UTF8.GetBytes(typeof(T).ToAssemblyQualified());
                /// <inheritdoc/>
                public override bool UseHeaders => true;
                /// <inheritdoc/>
                public override bool IsDirectBuffered => true;
                /// <summary>
                /// Default initializer
                /// </summary>
                public JsonBuffered()
                {
                    var tRecord = new T();
                    Schema = tRecord.Schema;
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

                    MemoryStream memStream = new();
                    JsonEncoder encoder = new(Schema, memStream);
                    SpecificWriter.Write(data, encoder);
                    return ByteBuffer.From(memStream);
                }
                /// <inheritdoc cref="SerDes{T, TJVMT}.Deserialize(string, TJVMT)"/>
                public override T Deserialize(string topic, Java.Nio.ByteBuffer data)
                {
                    return DeserializeWithHeaders(topic, null, data);
                }
                /// <inheritdoc cref="SerDes{T, TJVMT}.DeserializeWithHeaders(string, Headers, TJVMT)"/>
                public override T DeserializeWithHeaders(string topic, Headers headers, Java.Nio.ByteBuffer data)
                {
                    if (data == null) return default;

                    JsonDecoder decoder = new(Schema, data.ToStream());
                    T t = new T();
                    t = SpecificReader.Read(t!, decoder);
                    return t;
                }
            }
        }

        /// <summary>
        /// Base class to define Value extensions of <see cref="SerDes{T, TJVMT}"/>, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
        /// </summary>
        public static class Value
        {
            /// <summary>
            /// Avro Value extension of <see cref="SerDes{T, TJVMT}"/> for Binary encoding, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
            /// </summary>
            /// <typeparam name="T"></typeparam>
            public class BinaryRaw<T> : SerDes<T, byte[]> where T : global::Avro.Specific.ISpecificRecord, new()
            {
                global::Avro.Schema _schema;
                /// <summary>
                /// Use this property to get the <see cref="global::Avro.Schema"/> of <typeparamref name="T"/>
                /// </summary>
                public global::Avro.Schema Schema
                {
                    get { return _schema; }
                    private set
                    {
                        _schema = value;
                        SpecificWriter = new SpecificDefaultWriter(_schema);
                        SpecificReader = new SpecificDefaultReader(_schema, _schema);
                    }
                }

                SpecificDefaultWriter SpecificWriter = null;
                SpecificDefaultReader SpecificReader = null;

                readonly byte[] valueSerDesName = Encoding.UTF8.GetBytes(typeof(BinaryRaw<>).ToAssemblyQualified());
                readonly byte[] valueTypeName = Encoding.UTF8.GetBytes(typeof(T).ToAssemblyQualified());
                /// <inheritdoc/>
                public override bool UseHeaders => true;
                /// <summary>
                /// Default initializer
                /// </summary>
                public BinaryRaw()
                {
                    var tRecord = new T();
                    Schema = tRecord.Schema;
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

                    MemoryStream memStream = new();
                    BinaryEncoder encoder = new(memStream);
                    SpecificWriter.Write(data, encoder);
                    return memStream.ToArray();
                }
                /// <inheritdoc cref="SerDes{T, TJVMT}.Deserialize(string, TJVMT)"/>
                public override T Deserialize(string topic, byte[] data)
                {
                    return DeserializeWithHeaders(topic, null, data);
                }
                /// <inheritdoc cref="SerDes{T, TJVMT}.DeserializeWithHeaders(string, Headers, TJVMT)"/>
                public override T DeserializeWithHeaders(string topic, Headers headers, byte[] data)
                {
                    if (data == null) return default;

                    using MemoryStream memStream = new(data);
                    BinaryDecoder decoder = new(memStream);
                    T t = new T();
                    t = SpecificReader.Read(t!, decoder);
                    return t;
                }
            }
            /// <summary>
            /// Avro Value extension of <see cref="SerDes{T, TJVMT}"/> for Binary encoding, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
            /// </summary>
            /// <typeparam name="T"></typeparam>
            public class BinaryBuffered<T> : SerDes<T, Java.Nio.ByteBuffer> where T : global::Avro.Specific.ISpecificRecord, new()
            {
                global::Avro.Schema _schema;
                /// <summary>
                /// Use this property to get the <see cref="global::Avro.Schema"/> of <typeparamref name="T"/>
                /// </summary>
                public global::Avro.Schema Schema
                {
                    get { return _schema; }
                    private set
                    {
                        _schema = value;
                        SpecificWriter = new SpecificDefaultWriter(_schema);
                        SpecificReader = new SpecificDefaultReader(_schema, _schema);
                    }
                }

                SpecificDefaultWriter SpecificWriter = null;
                SpecificDefaultReader SpecificReader = null;

                readonly byte[] valueSerDesName = Encoding.UTF8.GetBytes(typeof(BinaryBuffered<>).ToAssemblyQualified());
                readonly byte[] valueTypeName = Encoding.UTF8.GetBytes(typeof(T).ToAssemblyQualified());
                /// <inheritdoc/>
                public override bool UseHeaders => true;
                /// <inheritdoc/>
                public override bool IsDirectBuffered => true;
                /// <summary>
                /// Default initializer
                /// </summary>
                public BinaryBuffered()
                {
                    var tRecord = new T();
                    Schema = tRecord.Schema;
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

                    MemoryStream memStream = new();
                    BinaryEncoder encoder = new(memStream);
                    SpecificWriter.Write(data, encoder);
                    return ByteBuffer.From(memStream);
                }
                /// <inheritdoc cref="SerDes{T, TJVMT}.Deserialize(string, TJVMT)"/>
                public override T Deserialize(string topic, Java.Nio.ByteBuffer data)
                {
                    return DeserializeWithHeaders(topic, null, data);
                }
                /// <inheritdoc cref="SerDes{T, TJVMT}.DeserializeWithHeaders(string, Headers, TJVMT)"/>
                public override T DeserializeWithHeaders(string topic, Headers headers, Java.Nio.ByteBuffer data)
                {
                    if (data == null) return default;

                    BinaryDecoder decoder = new(data.ToStream());
                    T t = new T();
                    t = SpecificReader.Read(t!, decoder);
                    return t;
                }
            }
            /// <summary>
            /// Avro Value extension of <see cref="SerDes{T, TJVMT}"/> for Json encoding, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
            /// </summary>
            /// <typeparam name="T"></typeparam>
            public class JsonRaw<T> : SerDes<T, byte[]> where T : global::Avro.Specific.ISpecificRecord, new()
            {
                global::Avro.Schema _schema;
                /// <summary>
                /// Use this property to get the <see cref="global::Avro.Schema"/> of <typeparamref name="T"/>
                /// </summary>
                public global::Avro.Schema Schema
                {
                    get { return _schema; }
                    private set
                    {
                        _schema = value;
                        SpecificWriter = new SpecificDefaultWriter(_schema);
                        SpecificReader = new SpecificDefaultReader(_schema, _schema);
                    }
                }

                SpecificDefaultWriter SpecificWriter = null;
                SpecificDefaultReader SpecificReader = null;

                readonly byte[] valueSerDesName = Encoding.UTF8.GetBytes(typeof(JsonRaw<>).ToAssemblyQualified());
                readonly byte[] valueTypeName = Encoding.UTF8.GetBytes(typeof(T).ToAssemblyQualified());
                /// <inheritdoc/>
                public override bool UseHeaders => true;
                /// <summary>
                /// Default initializer
                /// </summary>
                public JsonRaw()
                {
                    var tRecord = new T();
                    Schema = tRecord.Schema;
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

                    using MemoryStream memStream = new();
                    JsonEncoder encoder = new(Schema, memStream);
                    SpecificWriter.Write(data, encoder);
                    return memStream.ToArray();
                }
                /// <inheritdoc cref="SerDes{T, TJVMT}.Deserialize(string, TJVMT)"/>
                public override T Deserialize(string topic, byte[] data)
                {
                    return DeserializeWithHeaders(topic, null, data);
                }
                /// <inheritdoc cref="SerDes{T, TJVMT}.DeserializeWithHeaders(string, Headers, TJVMT)"/>
                public override T DeserializeWithHeaders(string topic, Headers headers, byte[] data)
                {
                    if (data == null) return default;

                    using MemoryStream memStream = new(data);
                    JsonDecoder decoder = new(Schema, memStream);
                    T t = new T();
                    t = SpecificReader.Read(t!, decoder);
                    return t;
                }
            }
            /// <summary>
            /// Avro Value extension of <see cref="SerDes{T, TJVMT}"/> for Json encoding, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
            /// </summary>
            /// <typeparam name="T"></typeparam>
            public class JsonBuffered<T> : SerDes<T, Java.Nio.ByteBuffer> where T : global::Avro.Specific.ISpecificRecord, new()
            {
                global::Avro.Schema _schema;
                /// <summary>
                /// Use this property to get the <see cref="global::Avro.Schema"/> of <typeparamref name="T"/>
                /// </summary>
                public global::Avro.Schema Schema
                {
                    get { return _schema; }
                    private set
                    {
                        _schema = value;
                        SpecificWriter = new SpecificDefaultWriter(_schema);
                        SpecificReader = new SpecificDefaultReader(_schema, _schema);
                    }
                }

                SpecificDefaultWriter SpecificWriter = null;
                SpecificDefaultReader SpecificReader = null;

                readonly byte[] valueSerDesName = Encoding.UTF8.GetBytes(typeof(JsonBuffered<>).ToAssemblyQualified());
                readonly byte[] valueTypeName = Encoding.UTF8.GetBytes(typeof(T).ToAssemblyQualified());
                /// <inheritdoc/>
                public override bool UseHeaders => true;
                /// <inheritdoc/>
                public override bool IsDirectBuffered => true;
                /// <summary>
                /// Default initializer
                /// </summary>
                public JsonBuffered()
                {
                    var tRecord = new T();
                    Schema = tRecord.Schema;
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

                    MemoryStream memStream = new();
                    JsonEncoder encoder = new(Schema, memStream);
                    SpecificWriter.Write(data, encoder);
                    return ByteBuffer.From(memStream);
                }
                /// <inheritdoc cref="SerDes{T, TJVMT}.Deserialize(string, TJVMT)"/>
                public override T Deserialize(string topic, Java.Nio.ByteBuffer data)
                {
                    return DeserializeWithHeaders(topic, null, data);
                }
                /// <inheritdoc cref="SerDes{T, TJVMT}.DeserializeWithHeaders(string, Headers, TJVMT)"/>
                public override T DeserializeWithHeaders(string topic, Headers headers, Java.Nio.ByteBuffer data)
                {
                    if (data == null) return default;

                    JsonDecoder decoder = new(Schema, data.ToStream());
                    T t = new T();
                    t = SpecificReader.Read(t!, decoder);
                    return t;
                }
            }
        }
    }
}
