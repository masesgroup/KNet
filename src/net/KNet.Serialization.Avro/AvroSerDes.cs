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
    /// Base class to define extensions of <see cref="ISerDesSelector{T}"/> for Avro, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
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
        /// Base class to define Key extensions of <see cref="ISerDesSelector{T}"/>, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
        /// </summary>
        public static class Key
        {
            /// <summary>
            /// Avro Key extension of <see cref="ISerDesSelector{T}"/> for Binary encoding, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
            /// </summary>
            /// <typeparam name="T"></typeparam>
            public class Binary<T> : ISerDesSelector<T> where T : global::Avro.Specific.ISpecificRecord, new()
            {
                /// <summary>
                /// Returns a new instance of <see cref="Binary{T}"/>
                /// </summary>
                /// <returns>The <see cref="ISerDesSelector{T}"/> of <see cref="Binary{T}"/></returns>
                public static ISerDesSelector<T> NewInstance() => new Binary<T>();
                /// <inheritdoc cref="ISerDesSelector.SelectorTypeName"/>
                public static string SelectorTypeName => typeof(Binary<>).ToAssemblyQualified();
                /// <inheritdoc cref="ISerDesSelector.ByteArraySerDes"/>
                public static Type ByteArraySerDes => typeof(BinaryRaw<T>);
                /// <inheritdoc cref="ISerDesSelector.ByteBufferSerDes"/>
                public static Type ByteBufferSerDes => typeof(BinaryBuffered<T>);
                /// <inheritdoc cref="ISerDesSelector{T}.NewSerDes{TJVM}"/>
                public static ISerDes<T, TJVM> NewSerDes<TJVM>()
                {
                    if (typeof(TJVM) == typeof(Java.Nio.ByteBuffer)) return NewByteBufferSerDes() as ISerDes<T, TJVM>;
                    return NewByteArraySerDes() as ISerDes<T, TJVM>;
                }
                /// <inheritdoc cref="ISerDesSelector{T}.NewByteArraySerDes"/>
                public static ISerDesRaw<T> NewByteArraySerDes() { return new BinaryRaw<T>(SelectorTypeName); }
                /// <inheritdoc cref="ISerDesSelector{T}.NewByteBufferSerDes"/>
                public static ISerDesBuffered<T> NewByteBufferSerDes() { return new BinaryBuffered<T>(SelectorTypeName); }

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
                /// Avro Key extension of <see cref="SerDes{T, TJVMT}"/> for Binary encoding, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
                /// </summary>
                /// <typeparam name="TData"></typeparam>
                sealed class BinaryRaw<TData> : SerDesRaw<TData> where TData : global::Avro.Specific.ISpecificRecord, new()
                {
                    global::Avro.Schema _schema;
                    /// <summary>
                    /// Use this property to get the <see cref="global::Avro.Schema"/> of <typeparamref name="TData"/>
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

                    readonly byte[] keySerDesName;
                    readonly byte[] keyTypeName = Encoding.UTF8.GetBytes(typeof(T).ToAssemblyQualified());
                    /// <inheritdoc/>
                    public override bool UseHeaders => true;
                    /// <summary>
                    /// Default initializer
                    /// </summary>
                    public BinaryRaw(string selectorName)
                    {
                        keySerDesName = Encoding.UTF8.GetBytes(selectorName);
                        var tRecord = new TData();
                        Schema = tRecord.Schema;
                    }
                    /// <inheritdoc cref="SerDes{T, TJVMT}.Serialize(string, T)"/>
                    public override byte[] Serialize(string topic, TData data)
                    {
                        return SerializeWithHeaders(topic, null, data);
                    }
                    /// <inheritdoc cref="SerDes{T, TJVMT}.SerializeWithHeaders(string, Headers, T)"/>
                    public override byte[] SerializeWithHeaders(string topic, Headers headers, TData data)
                    {
                        headers?.Add(KNetSerialization.KeyTypeIdentifierJVM, keyTypeName);
                        headers?.Add(KNetSerialization.KeySerializerIdentifierJVM, keySerDesName);

                        using MemoryStream memStream = new();
                        BinaryEncoder encoder = new(memStream);
                        SpecificWriter.Write(data, encoder);
                        return memStream.ToArray();
                    }
                    /// <inheritdoc cref="SerDes{T, TJVMT}.Deserialize(string, TJVMT)"/>
                    public override TData Deserialize(string topic, byte[] data)
                    {
                        return DeserializeWithHeaders(topic, null, data);
                    }
                    /// <inheritdoc cref="SerDes{T, TJVMT}.DeserializeWithHeaders(string, Headers, TJVMT)"/>
                    public override TData DeserializeWithHeaders(string topic, Headers headers, byte[] data)
                    {
                        if (data == null) return default;

                        using MemoryStream memStream = new(data);
                        BinaryDecoder decoder = new(memStream);
                        TData t = new TData();
                        t = SpecificReader.Read(t!, decoder);
                        return t;
                    }
                }
                /// <summary>
                /// Avro Key extension of <see cref="SerDes{T, TJVMT}"/> for Binary encoding, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
                /// </summary>
                /// <typeparam name="TData"></typeparam>
                sealed class BinaryBuffered<TData> : SerDesBuffered<TData> where TData : global::Avro.Specific.ISpecificRecord, new()
                {
                    global::Avro.Schema _schema;
                    /// <summary>
                    /// Use this property to get the <see cref="global::Avro.Schema"/> of <typeparamref name="TData"/>
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

                    readonly byte[] keySerDesName;
                    readonly byte[] keyTypeName = Encoding.UTF8.GetBytes(typeof(T).ToAssemblyQualified());
                    /// <inheritdoc/>
                    public override bool UseHeaders => true;
                    /// <summary>
                    /// Default initializer
                    /// </summary>
                    public BinaryBuffered(string selectorName)
                    {
                        keySerDesName = Encoding.UTF8.GetBytes(selectorName);
                        var tRecord = new T();
                        Schema = tRecord.Schema;
                    }
                    /// <inheritdoc cref="SerDes{T, TJVMT}.Serialize(string, T)"/>
                    public override Java.Nio.ByteBuffer Serialize(string topic, TData data)
                    {
                        return SerializeWithHeaders(topic, null, data);
                    }
                    /// <inheritdoc cref="SerDes{T, TJVMT}.SerializeWithHeaders(string, Headers, T)"/>
                    public override Java.Nio.ByteBuffer SerializeWithHeaders(string topic, Headers headers, TData data)
                    {
                        headers?.Add(KNetSerialization.KeyTypeIdentifierJVM, keyTypeName);
                        headers?.Add(KNetSerialization.KeySerializerIdentifierJVM, keySerDesName);

                        MemoryStream memStream = new();
                        BinaryEncoder encoder = new(memStream);
                        SpecificWriter.Write(data, encoder);
                        return ByteBuffer.From(memStream);
                    }
                    /// <inheritdoc cref="SerDes{T, TJVMT}.Deserialize(string, TJVMT)"/>
                    public override TData Deserialize(string topic, Java.Nio.ByteBuffer data)
                    {
                        return DeserializeWithHeaders(topic, null, data);
                    }
                    /// <inheritdoc cref="SerDes{T, TJVMT}.DeserializeWithHeaders(string, Headers, TJVMT)"/>
                    public override TData DeserializeWithHeaders(string topic, Headers headers, Java.Nio.ByteBuffer data)
                    {
                        if (data == null) return default;

                        BinaryDecoder decoder = new(data.ToStream());
                        TData t = new TData();
                        t = SpecificReader.Read(t!, decoder);
                        return t;
                    }
                }
            }
            /// <summary>
            /// Avro Key extension of <see cref="ISerDesSelector{T}"/> for Json encoding, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
            /// </summary>
            /// <typeparam name="T"></typeparam>
            public class Json<T> : ISerDesSelector<T> where T : global::Avro.Specific.ISpecificRecord, new()
            {
                /// <summary>
                /// Returns a new instance of <see cref="Json{T}"/>
                /// </summary>
                /// <returns>The <see cref="ISerDesSelector{T}"/> of <see cref="Json{T}"/></returns>
                public static ISerDesSelector<T> NewInstance() => new Json<T>();
                /// <inheritdoc cref="ISerDesSelector.SelectorTypeName"/>
                public static string SelectorTypeName => typeof(Json<>).ToAssemblyQualified();
                /// <inheritdoc cref="ISerDesSelector.ByteArraySerDes"/>
                public static Type ByteArraySerDes => typeof(JsonRaw<T>);
                /// <inheritdoc cref="ISerDesSelector.ByteBufferSerDes"/>
                public static Type ByteBufferSerDes => typeof(JsonBuffered<T>);
                /// <inheritdoc cref="ISerDesSelector{T}.NewSerDes{TJVM}"/>
                public static ISerDes<T, TJVM> NewSerDes<TJVM>()
                {
                    if (typeof(TJVM) == typeof(Java.Nio.ByteBuffer)) return NewByteBufferSerDes() as ISerDes<T, TJVM>;
                    return NewByteArraySerDes() as ISerDes<T, TJVM>;
                }
                /// <inheritdoc cref="ISerDesSelector{T}.NewByteArraySerDes"/>
                public static ISerDesRaw<T> NewByteArraySerDes() { return new JsonRaw<T>(SelectorTypeName); }
                /// <inheritdoc cref="ISerDesSelector{T}.NewByteBufferSerDes"/>
                public static ISerDesBuffered<T> NewByteBufferSerDes() { return new JsonBuffered<T>(SelectorTypeName); }

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
                /// Avro Key extension of <see cref="SerDes{T, TJVMT}"/> for Json encoding, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
                /// </summary>
                /// <typeparam name="TData"></typeparam>
                sealed class JsonRaw<TData> : SerDesRaw<TData> where TData : global::Avro.Specific.ISpecificRecord, new()
                {
                    global::Avro.Schema _schema;
                    /// <summary>
                    /// Use this property to get the <see cref="global::Avro.Schema"/> of <typeparamref name="TData"/>
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

                    readonly byte[] keySerDesName;
                    readonly byte[] keyTypeName = Encoding.UTF8.GetBytes(typeof(T).ToAssemblyQualified());
                    /// <inheritdoc/>
                    public override bool UseHeaders => true;
                    /// <summary>
                    /// Default initializer
                    /// </summary>
                    public JsonRaw(string selectorName)
                    {
                        keySerDesName = Encoding.UTF8.GetBytes(selectorName);
                        var tRecord = new TData();
                        Schema = tRecord.Schema;
                    }
                    /// <inheritdoc cref="SerDes{T, TJVMT}.Serialize(string, T)"/>
                    public override byte[] Serialize(string topic, TData data)
                    {
                        return SerializeWithHeaders(topic, null, data);
                    }
                    /// <inheritdoc cref="SerDes{T, TJVMT}.SerializeWithHeaders(string, Headers, T)"/>
                    public override byte[] SerializeWithHeaders(string topic, Headers headers, TData data)
                    {
                        headers?.Add(KNetSerialization.KeyTypeIdentifierJVM, keyTypeName);
                        headers?.Add(KNetSerialization.KeySerializerIdentifierJVM, keySerDesName);

                        using MemoryStream memStream = new();
                        JsonEncoder encoder = new(Schema, memStream);
                        SpecificWriter.Write(data, encoder);
                        return memStream.ToArray();
                    }
                    /// <inheritdoc cref="SerDes{T, TJVMT}.Deserialize(string, TJVMT)"/>
                    public override TData Deserialize(string topic, byte[] data)
                    {
                        return DeserializeWithHeaders(topic, null, data);
                    }
                    /// <inheritdoc cref="SerDes{T, TJVMT}.DeserializeWithHeaders(string, Headers, TJVMT)"/>
                    public override TData DeserializeWithHeaders(string topic, Headers headers, byte[] data)
                    {
                        if (data == null) return default;

                        using MemoryStream memStream = new(data);
                        JsonDecoder decoder = new(Schema, memStream);
                        TData t = new TData();
                        t = SpecificReader.Read(t!, decoder);
                        return t;
                    }
                }
                /// <summary>
                /// Avro Key extension of <see cref="SerDes{T, TJVMT}"/> for Json encoding, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
                /// </summary>
                /// <typeparam name="TData"></typeparam>
                sealed class JsonBuffered<TData> : SerDesBuffered<TData> where TData : global::Avro.Specific.ISpecificRecord, new()
                {
                    global::Avro.Schema _schema;
                    /// <summary>
                    /// Use this property to get the <see cref="global::Avro.Schema"/> of <typeparamref name="TData"/>
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

                    readonly byte[] keySerDesName;
                    readonly byte[] keyTypeName = Encoding.UTF8.GetBytes(typeof(T).ToAssemblyQualified());
                    /// <inheritdoc/>
                    public override bool UseHeaders => true;
                    /// <summary>
                    /// Default initializer
                    /// </summary>
                    public JsonBuffered(string selectorName)
                    {
                        keySerDesName = Encoding.UTF8.GetBytes(selectorName);
                        var tRecord = new TData();
                        Schema = tRecord.Schema;
                    }
                    /// <inheritdoc cref="SerDes{T, TJVMT}.Serialize(string, T)"/>
                    public override Java.Nio.ByteBuffer Serialize(string topic, TData data)
                    {
                        return SerializeWithHeaders(topic, null, data);
                    }
                    /// <inheritdoc cref="SerDes{T, TJVMT}.SerializeWithHeaders(string, Headers, T)"/>
                    public override Java.Nio.ByteBuffer SerializeWithHeaders(string topic, Headers headers, TData data)
                    {
                        headers?.Add(KNetSerialization.KeyTypeIdentifierJVM, keyTypeName);
                        headers?.Add(KNetSerialization.KeySerializerIdentifierJVM, keySerDesName);

                        MemoryStream memStream = new();
                        JsonEncoder encoder = new(Schema, memStream);
                        SpecificWriter.Write(data, encoder);
                        return ByteBuffer.From(memStream);
                    }
                    /// <inheritdoc cref="SerDes{T, TJVMT}.Deserialize(string, TJVMT)"/>
                    public override TData Deserialize(string topic, Java.Nio.ByteBuffer data)
                    {
                        return DeserializeWithHeaders(topic, null, data);
                    }
                    /// <inheritdoc cref="SerDes{T, TJVMT}.DeserializeWithHeaders(string, Headers, TJVMT)"/>
                    public override TData DeserializeWithHeaders(string topic, Headers headers, Java.Nio.ByteBuffer data)
                    {
                        if (data == null) return default;

                        JsonDecoder decoder = new(Schema, data.ToStream());
                        TData t = new TData();
                        t = SpecificReader.Read(t!, decoder);
                        return t;
                    }
                }
            }
        }

        /// <summary>
        /// Base class to define Value extensions of <see cref="ISerDesSelector{T}"/>, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
        /// </summary>
        public static class Value
        {
            /// <summary>
            /// Avro Value extension of <see cref="ISerDesSelector{T}"/> for Binary encoding, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
            /// </summary>
            /// <typeparam name="T"></typeparam>
            public class Binary<T> : ISerDesSelector<T> where T : global::Avro.Specific.ISpecificRecord, new()
            {
                /// <summary>
                /// Returns a new instance of <see cref="Binary{T}"/>
                /// </summary>
                /// <returns>The <see cref="ISerDesSelector{T}"/> of <see cref="Binary{T}"/></returns>
                public static ISerDesSelector<T> NewInstance() => new Binary<T>();
                /// <inheritdoc cref="ISerDesSelector.SelectorTypeName"/>
                public static string SelectorTypeName => typeof(Binary<>).ToAssemblyQualified();
                /// <inheritdoc cref="ISerDesSelector.ByteArraySerDes"/>
                public static Type ByteArraySerDes => typeof(BinaryRaw<T>);
                /// <inheritdoc cref="ISerDesSelector.ByteBufferSerDes"/>
                public static Type ByteBufferSerDes => typeof(BinaryBuffered<T>);
                /// <inheritdoc cref="ISerDesSelector{T}.NewSerDes{TJVM}"/>
                public static ISerDes<T, TJVM> NewSerDes<TJVM>()
                {
                    if (typeof(TJVM) == typeof(Java.Nio.ByteBuffer)) return NewByteBufferSerDes() as ISerDes<T, TJVM>;
                    return NewByteArraySerDes() as ISerDes<T, TJVM>;
                }
                /// <inheritdoc cref="ISerDesSelector{T}.NewByteArraySerDes"/>
                public static ISerDesRaw<T> NewByteArraySerDes() { return new BinaryRaw<T>(SelectorTypeName); }
                /// <inheritdoc cref="ISerDesSelector{T}.NewByteBufferSerDes"/>
                public static ISerDesBuffered<T> NewByteBufferSerDes() { return new BinaryBuffered<T>(SelectorTypeName); }

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
                /// Avro Value extension of <see cref="SerDes{T, TJVMT}"/> for Binary encoding, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
                /// </summary>
                /// <typeparam name="TData"></typeparam>
                sealed class BinaryRaw<TData> : SerDesRaw<TData> where TData : global::Avro.Specific.ISpecificRecord, new()
                {
                    global::Avro.Schema _schema;
                    /// <summary>
                    /// Use this property to get the <see cref="global::Avro.Schema"/> of <typeparamref name="TData"/>
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

                    readonly byte[] valueSerDesName;
                    readonly byte[] valueTypeName = Encoding.UTF8.GetBytes(typeof(TData).ToAssemblyQualified());
                    /// <inheritdoc/>
                    public override bool UseHeaders => true;
                    /// <summary>
                    /// Default initializer
                    /// </summary>
                    public BinaryRaw(string selectorName)
                    {
                        valueSerDesName = Encoding.UTF8.GetBytes(selectorName);
                        var tRecord = new TData();
                        Schema = tRecord.Schema;
                    }
                    /// <inheritdoc cref="SerDes{T, TJVMT}.Serialize(string, T)"/>
                    public override byte[] Serialize(string topic, TData data)
                    {
                        return SerializeWithHeaders(topic, null, data);
                    }
                    /// <inheritdoc cref="SerDes{T, TJVMT}.SerializeWithHeaders(string, Headers, T)"/>
                    public override byte[] SerializeWithHeaders(string topic, Headers headers, TData data)
                    {
                        headers?.Add(KNetSerialization.ValueSerializerIdentifierJVM, valueSerDesName);
                        headers?.Add(KNetSerialization.ValueTypeIdentifierJVM, valueTypeName);

                        MemoryStream memStream = new();
                        BinaryEncoder encoder = new(memStream);
                        SpecificWriter.Write(data, encoder);
                        return memStream.ToArray();
                    }
                    /// <inheritdoc cref="SerDes{T, TJVMT}.Deserialize(string, TJVMT)"/>
                    public override TData Deserialize(string topic, byte[] data)
                    {
                        return DeserializeWithHeaders(topic, null, data);
                    }
                    /// <inheritdoc cref="SerDes{T, TJVMT}.DeserializeWithHeaders(string, Headers, TJVMT)"/>
                    public override TData DeserializeWithHeaders(string topic, Headers headers, byte[] data)
                    {
                        if (data == null) return default;

                        using MemoryStream memStream = new(data);
                        BinaryDecoder decoder = new(memStream);
                        TData t = new TData();
                        t = SpecificReader.Read(t!, decoder);
                        return t;
                    }
                }
                /// <summary>
                /// Avro Value extension of <see cref="SerDes{T, TJVMT}"/> for Binary encoding, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
                /// </summary>
                /// <typeparam name="TData"></typeparam>
                sealed class BinaryBuffered<TData> : SerDesBuffered<TData> where TData : global::Avro.Specific.ISpecificRecord, new()
                {
                    global::Avro.Schema _schema;
                    /// <summary>
                    /// Use this property to get the <see cref="global::Avro.Schema"/> of <typeparamref name="TData"/>
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

                    readonly byte[] valueSerDesName;
                    readonly byte[] valueTypeName = Encoding.UTF8.GetBytes(typeof(TData).ToAssemblyQualified());
                    /// <inheritdoc/>
                    public override bool UseHeaders => true;
                    /// <summary>
                    /// Default initializer
                    /// </summary>
                    public BinaryBuffered(string selectorName)
                    {
                        valueSerDesName = Encoding.UTF8.GetBytes(selectorName);
                        var tRecord = new TData();
                        Schema = tRecord.Schema;
                    }
                    /// <inheritdoc cref="SerDes{T, TJVMT}.Serialize(string, T)"/>
                    public override Java.Nio.ByteBuffer Serialize(string topic, TData data)
                    {
                        return SerializeWithHeaders(topic, null, data);
                    }
                    /// <inheritdoc cref="SerDes{T, TJVMT}.SerializeWithHeaders(string, Headers, T)"/>
                    public override Java.Nio.ByteBuffer SerializeWithHeaders(string topic, Headers headers, TData data)
                    {
                        headers?.Add(KNetSerialization.ValueSerializerIdentifierJVM, valueSerDesName);
                        headers?.Add(KNetSerialization.ValueTypeIdentifierJVM, valueTypeName);

                        MemoryStream memStream = new();
                        BinaryEncoder encoder = new(memStream);
                        SpecificWriter.Write(data, encoder);
                        return ByteBuffer.From(memStream);
                    }
                    /// <inheritdoc cref="SerDes{T, TJVMT}.Deserialize(string, TJVMT)"/>
                    public override TData Deserialize(string topic, Java.Nio.ByteBuffer data)
                    {
                        return DeserializeWithHeaders(topic, null, data);
                    }
                    /// <inheritdoc cref="SerDes{T, TJVMT}.DeserializeWithHeaders(string, Headers, TJVMT)"/>
                    public override TData DeserializeWithHeaders(string topic, Headers headers, Java.Nio.ByteBuffer data)
                    {
                        if (data == null) return default;

                        BinaryDecoder decoder = new(data.ToStream());
                        TData t = new TData();
                        t = SpecificReader.Read(t!, decoder);
                        return t;
                    }
                }
            }

            /// <summary>
            /// Avro Value extension of <see cref="ISerDesSelector{T}"/> for Json encoding, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
            /// </summary>
            /// <typeparam name="T"></typeparam>
            public class Json<T> : ISerDesSelector<T> where T : global::Avro.Specific.ISpecificRecord, new()
            {
                /// <summary>
                /// Returns a new instance of <see cref="Json{T}"/>
                /// </summary>
                /// <returns>The <see cref="ISerDesSelector{T}"/> of <see cref="Json{T}"/></returns>
                public static ISerDesSelector<T> NewInstance() => new Json<T>();
                /// <inheritdoc cref="ISerDesSelector.SelectorTypeName"/>
                public static string SelectorTypeName => typeof(Json<>).ToAssemblyQualified();
                /// <inheritdoc cref="ISerDesSelector.ByteArraySerDes"/>
                public static Type ByteArraySerDes => typeof(JsonRaw<T>);
                /// <inheritdoc cref="ISerDesSelector.ByteBufferSerDes"/>
                public static Type ByteBufferSerDes => typeof(JsonBuffered<T>);
                /// <inheritdoc cref="ISerDesSelector{T}.NewSerDes{TJVM}"/>
                public static ISerDes<T, TJVM> NewSerDes<TJVM>()
                {
                    if (typeof(TJVM) == typeof(Java.Nio.ByteBuffer)) return NewByteBufferSerDes() as ISerDes<T, TJVM>;
                    return NewByteArraySerDes() as ISerDes<T, TJVM>;
                }
                /// <inheritdoc cref="ISerDesSelector{T}.NewByteArraySerDes"/>
                public static ISerDesRaw<T> NewByteArraySerDes() { return new JsonRaw<T>(SelectorTypeName); }
                /// <inheritdoc cref="ISerDesSelector{T}.NewByteBufferSerDes"/>
                public static ISerDesBuffered<T> NewByteBufferSerDes() { return new JsonBuffered<T>(SelectorTypeName); }

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
                /// Avro Value extension of <see cref="SerDes{T, TJVMT}"/> for Json encoding, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
                /// </summary>
                /// <typeparam name="TData"></typeparam>
                sealed class JsonRaw<TData> : SerDesRaw<TData> where TData : global::Avro.Specific.ISpecificRecord, new()
                {
                    global::Avro.Schema _schema;
                    /// <summary>
                    /// Use this property to get the <see cref="global::Avro.Schema"/> of <typeparamref name="TData"/>
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

                    readonly byte[] valueSerDesName;
                    readonly byte[] valueTypeName = Encoding.UTF8.GetBytes(typeof(TData).ToAssemblyQualified());
                    /// <inheritdoc/>
                    public override bool UseHeaders => true;
                    /// <summary>
                    /// Default initializer
                    /// </summary>
                    public JsonRaw(string selectorName)
                    {
                        valueSerDesName = Encoding.UTF8.GetBytes(selectorName);
                        var tRecord = new TData();
                        Schema = tRecord.Schema;
                    }
                    /// <inheritdoc cref="SerDes{T, TJVMT}.Serialize(string, T)"/>
                    public override byte[] Serialize(string topic, TData data)
                    {
                        return SerializeWithHeaders(topic, null, data);
                    }
                    /// <inheritdoc cref="SerDes{T, TJVMT}.SerializeWithHeaders(string, Headers, T)"/>
                    public override byte[] SerializeWithHeaders(string topic, Headers headers, TData data)
                    {
                        headers?.Add(KNetSerialization.ValueSerializerIdentifierJVM, valueSerDesName);
                        headers?.Add(KNetSerialization.ValueTypeIdentifierJVM, valueTypeName);

                        using MemoryStream memStream = new();
                        JsonEncoder encoder = new(Schema, memStream);
                        SpecificWriter.Write(data, encoder);
                        return memStream.ToArray();
                    }
                    /// <inheritdoc cref="SerDes{T, TJVMT}.Deserialize(string, TJVMT)"/>
                    public override TData Deserialize(string topic, byte[] data)
                    {
                        return DeserializeWithHeaders(topic, null, data);
                    }
                    /// <inheritdoc cref="SerDes{T, TJVMT}.DeserializeWithHeaders(string, Headers, TJVMT)"/>
                    public override TData DeserializeWithHeaders(string topic, Headers headers, byte[] data)
                    {
                        if (data == null) return default;

                        using MemoryStream memStream = new(data);
                        JsonDecoder decoder = new(Schema, memStream);
                        TData t = new TData();
                        t = SpecificReader.Read(t!, decoder);
                        return t;
                    }
                }
                /// <summary>
                /// Avro Value extension of <see cref="SerDes{T, TJVMT}"/> for Json encoding, for example <see href="https://masesgroup.github.io/KNet/articles/usageSerDes.html"/>
                /// </summary>
                /// <typeparam name="TData"></typeparam>
                sealed class JsonBuffered<TData> : SerDesBuffered<TData> where TData : global::Avro.Specific.ISpecificRecord, new()
                {
                    global::Avro.Schema _schema;
                    /// <summary>
                    /// Use this property to get the <see cref="global::Avro.Schema"/> of <typeparamref name="TData"/>
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

                    readonly byte[] valueSerDesName;
                    readonly byte[] valueTypeName = Encoding.UTF8.GetBytes(typeof(TData).ToAssemblyQualified());
                    /// <inheritdoc/>
                    public override bool UseHeaders => true;
                    /// <summary>
                    /// Default initializer
                    /// </summary>
                    public JsonBuffered(string selectorName)
                    {
                        valueSerDesName = Encoding.UTF8.GetBytes(selectorName);
                        var tRecord = new T();
                        Schema = tRecord.Schema;
                    }
                    /// <inheritdoc cref="SerDes{T, TJVMT}.Serialize(string, T)"/>
                    public override Java.Nio.ByteBuffer Serialize(string topic, TData data)
                    {
                        return SerializeWithHeaders(topic, null, data);
                    }
                    /// <inheritdoc cref="SerDes{T, TJVMT}.SerializeWithHeaders(string, Headers, T)"/>
                    public override Java.Nio.ByteBuffer SerializeWithHeaders(string topic, Headers headers, TData data)
                    {
                        headers?.Add(KNetSerialization.ValueSerializerIdentifierJVM, valueSerDesName);
                        headers?.Add(KNetSerialization.ValueTypeIdentifierJVM, valueTypeName);

                        MemoryStream memStream = new();
                        JsonEncoder encoder = new(Schema, memStream);
                        SpecificWriter.Write(data, encoder);
                        return ByteBuffer.From(memStream);
                    }
                    /// <inheritdoc cref="SerDes{T, TJVMT}.Deserialize(string, TJVMT)"/>
                    public override TData Deserialize(string topic, Java.Nio.ByteBuffer data)
                    {
                        return DeserializeWithHeaders(topic, null, data);
                    }
                    /// <inheritdoc cref="SerDes{T, TJVMT}.DeserializeWithHeaders(string, Headers, TJVMT)"/>
                    public override TData DeserializeWithHeaders(string topic, Headers headers, Java.Nio.ByteBuffer data)
                    {
                        if (data == null) return default;

                        JsonDecoder decoder = new(Schema, data.ToStream());
                        TData t = new TData();
                        t = SpecificReader.Read(t!, decoder);
                        return t;
                    }
                }
            }
        }
    }
}
