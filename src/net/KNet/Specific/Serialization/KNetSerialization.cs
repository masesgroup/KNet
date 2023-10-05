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

using Java.Lang;
using Java.Nio;
using MASES.JCOBridge.C2JBridge;
using MASES.JCOBridge.C2JBridge.JVMInterop;
using Org.Apache.Kafka.Common.Errors;
using Org.Apache.Kafka.Common.Serialization;
using Org.Apache.Kafka.Common.Utils;
using System;
using System.Text;

namespace MASES.KNet.Serialization
{
    /// <summary>
    /// Helper for KNetSerDes
    /// </summary>
    public static class KNetSerialization
    {
        /// <summary>
        /// Serializer types
        /// </summary>
        public enum SerializationType
        {
            /// <summary>
            /// Externally managed
            /// </summary>
            External,
            /// <summary>
            /// Array of <see cref="byte"/>
            /// </summary>
            ByteArray,
            /// <summary>
            /// <see cref="Java.Nio.ByteBuffer"/>
            /// </summary>
            ByteBuffer,
            /// <summary>
            /// <see cref="Org.Apache.Kafka.Common.Utils.Bytes"/>
            /// </summary>
            Bytes,
            /// <summary>
            /// <see cref="double"/>
            /// </summary>
            Double,
            /// <summary>
            /// <see cref="float"/>
            /// </summary>
            Float,
            /// <summary>
            /// <see cref="int"/>
            /// </summary>
            Int,
            /// <summary>
            /// <see cref="long"/>
            /// </summary>
            Long,
            /// <summary>
            /// <see cref="short"/>
            /// </summary>
            Short,
            /// <summary>
            /// <see cref="string"/>
            /// </summary>
            String,
            /// <summary>
            /// <see cref="System.Guid"/>
            /// </summary>
            Guid,
            /// <summary>
            /// <see cref="Java.Lang.Void"/>
            /// </summary>
            Void
        }
        /// <summary>
        /// Check if a serializer is available for <typeparamref name="TData"/>
        /// </summary>
        /// <typeparam name="TData">The type to check</typeparam>
        /// <returns><see langword="true"/> if managed</returns>
        public static bool IsInternalManaged<TData>()
        {
            return IsInternalManaged(typeof(TData));
        }
        /// <summary>
        /// Check if a serializer is available for <paramref name="type"/>
        /// </summary>
        /// <param name="type">The <see cref="Type"/> to check</param>
        /// <returns><see langword="true"/> if managed</returns>
        public static bool IsInternalManaged(Type type)
        {
            if (type == typeof(byte[]) || type == typeof(ByteBuffer) || type == typeof(Bytes)
                || type == typeof(double) || type == typeof(float) || type == typeof(int) || type == typeof(long) || type == typeof(short) || type == typeof(string)
                || type == typeof(Guid) || type == typeof(void))
            {
                return true;
            }

            return false;
        }
        /// <summary>
        /// Returns the serializer <see cref="SerializationType"/> for <typeparamref name="TData"/>
        /// </summary>
        /// <typeparam name="TData">The type to check</typeparam>
        /// <returns><see cref="SerializationType"/></returns>
        public static SerializationType InternalSerDesType<TData>()
        {
            return InternalSerDesType(typeof(TData));
        }
        /// <summary>
        /// Returns the serializer <see cref="SerializationType"/> for <paramref name="type"/>
        /// </summary>
        /// <param name="type">The <see cref="Type"/> to check</param>
        /// <returns><see cref="SerializationType"/></returns>
        public static SerializationType InternalSerDesType(Type type)
        {
            if (type == typeof(byte[])) return SerializationType.ByteArray;
            else if (type == typeof(ByteBuffer)) return SerializationType.ByteBuffer;
            else if (type == typeof(Bytes)) return SerializationType.Bytes;
            else if (type == typeof(double)) return SerializationType.Double;
            else if (type == typeof(float)) return SerializationType.Float;
            else if (type == typeof(int)) return SerializationType.Int;
            else if (type == typeof(long)) return SerializationType.Long;
            else if (type == typeof(short)) return SerializationType.Short;
            else if (type == typeof(string)) return SerializationType.String;
            else if (type == typeof(Guid)) return SerializationType.Guid;
            else if (type == typeof(void)) return SerializationType.Void;

            return SerializationType.External;
        }

        /// <summary>
        /// Serialize a <see cref="SerializationType.ByteArray"/>
        /// </summary>
        public static byte[] SerializeByteArray(string topic, byte[] data)
        {
            return data;
        }

        static readonly ByteBufferSerializer _ByteBufferSerializer = new ByteBufferSerializer();
        /// <summary>
        /// Serialize a <see cref="SerializationType.ByteBuffer"/>
        /// </summary>
        public static byte[] SerializeByteBuffer(string topic, ByteBuffer data)
        {
            return _ByteBufferSerializer.Serialize(topic, data);
        }

        static readonly BytesSerializer _BytesSerializer = new BytesSerializer();
        /// <summary>
        /// Serialize a <see cref="SerializationType.Bytes"/>
        /// </summary>
        public static byte[] SerializeBytes(string topic, Bytes data)
        {
            return _BytesSerializer.Serialize(topic, data);
        }

        static readonly DoubleSerializer _DoubleSerializer = new DoubleSerializer();
        /// <summary>
        /// Serialize a <see cref="SerializationType.Double"/>
        /// </summary>
        public static byte[] SerializeDouble(string topic, double data)
        {
            return _DoubleSerializer.Serialize(topic, data);
        }

        static readonly FloatSerializer _FloatSerializer = new FloatSerializer();
        /// <summary>
        /// Serialize a <see cref="SerializationType.Float"/>
        /// </summary>
        public static byte[] SerializeFloat(string topic, float data)
        {
            return _FloatSerializer.Serialize(topic, data);
        }

        static readonly IntegerSerializer _IntSerializer = new IntegerSerializer();
        /// <summary>
        /// Serialize a <see cref="SerializationType.Int"/>
        /// </summary>
        public static byte[] SerializeInt(string topic, int data)
        {
            return _IntSerializer.Serialize(topic, data);
            // the following generates an error in container
            //return new byte[] { (byte)(data >>> 24), (byte)(data >>> 16), (byte)(data >>> 8), ((byte)data) };
        }

        static readonly Serializer<long> _LongSerializer = new LongSerializer();
        /// <summary>
        /// Serialize a <see cref="SerializationType.Long"/>
        /// </summary>
        public static byte[] SerializeLong(string topic, long data)
        {
            return _LongSerializer.Serialize(topic, data);
            // the following generates an error in container
            //return new byte[] { (byte)((int)(data >>> 56)), (byte)((int)(data >>> 48)), (byte)((int)(data >>> 40)), (byte)((int)(data >>> 32)), (byte)((int)(data >>> 24)), (byte)((int)(data >>> 16)), (byte)((int)(data >>> 8)), ((byte)data) };
        }

        static readonly ShortSerializer _ShortSerializer = new ShortSerializer();
        /// <summary>
        /// Serialize a <see cref="SerializationType.Short"/>
        /// </summary>
        public static byte[] SerializeShort(string topic, short data)
        {
            return _ShortSerializer.Serialize(topic, data);
            // the following generates an error in container
            //return new byte[] { (byte)(data >>> 8), ((byte)data) };
        }
        /// <summary>
        /// Serialize a <see cref="SerializationType.String"/>
        /// </summary>
        public static byte[] SerializeString(string topic, string data)
        {
            return Encoding.UTF8.GetBytes(data);
        }
        /// <summary>
        /// Serialize a <see cref="SerializationType.Guid"/>
        /// </summary>
        public static byte[] SerializeGuid(string topic, Guid data)
        {
            return data.ToByteArray();
        }
        /// <summary>
        /// Serialize a <see cref="SerializationType.Void"/>
        /// </summary>
        public static byte[] SerializeVoid(string topic, Java.Lang.Void data)
        {
            return null;
        }
        /// <summary>
        /// Deserialize a <see cref="SerializationType.ByteArray"/>
        /// </summary>
        public static byte[] DeserializeByteArray(string topic, byte[] data)
        {
            return data;
        }

        static readonly ByteBufferDeserializer _ByteBufferDeserializer = new ByteBufferDeserializer();
        /// <summary>
        /// Deserialize a <see cref="SerializationType.ByteBuffer"/>
        /// </summary>
        public static ByteBuffer DeserializeByteBuffer(string topic, byte[] data)
        {
            return JVMBridgeBase.Wraps<ByteBuffer>(_ByteBufferDeserializer.Deserialize(topic, data) as IJavaObject);
        }

        static readonly BytesDeserializer _BytesDeserializer = new BytesDeserializer();
        /// <summary>
        /// Deserialize a <see cref="SerializationType.Bytes"/>
        /// </summary>
        public static Bytes DeserializeBytes(string topic, byte[] data)
        {
            return JVMBridgeBase.Wraps<Bytes>(_BytesDeserializer.Deserialize(topic, data) as IJavaObject);
        }

        static readonly DoubleDeserializer _DoubleDeserializer = new DoubleDeserializer();
        /// <summary>
        /// Deserialize a <see cref="SerializationType.Double"/>
        /// </summary>
        public static double DeserializeDouble(string topic, byte[] data)
        {
            var result = _DoubleDeserializer.Deserialize(topic, data);
            if (result is IJavaObject ijo)
            {
                return JVMBridgeBase.Wraps<Java.Lang.Double>(ijo);
            }
            return (double)result;
        }

        static readonly FloatDeserializer _FloatDeserializer = new FloatDeserializer();
        /// <summary>
        /// Deserialize a <see cref="SerializationType.Float"/>
        /// </summary>
        public static float DeserializeFloat(string topic, byte[] data)
        {
            var result = _FloatDeserializer.Deserialize(topic, data);
            if (result is IJavaObject ijo)
            {
                return JVMBridgeBase.Wraps<Java.Lang.Float>(ijo);
            }
            return (float)result;
        }

        static readonly IntegerDeserializer _IntDeserializer = new IntegerDeserializer();
        /// <summary>
        /// Deserialize a <see cref="SerializationType.Int"/>
        /// </summary>
        public static int DeserializeInt(string topic, byte[] data)
        {
            var result = _IntDeserializer.Deserialize(topic, data);
            if (result is IJavaObject ijo)
            {
                return JVMBridgeBase.Wraps<Java.Lang.Integer>(ijo);
            }
            return (int)result;

            //if (data == null)
            //{
            //    return default;
            //}
            //else if (data.Length != 4)
            //{
            //    JVMBridgeException<SerializationException>.ThrowNew("Size of data received by DeserializeInt is not 4");
            //    throw new SerializationException();
            //}
            //else
            //{
            //    int value = 0;
            //    byte[] var4 = data;
            //    int var5 = data.Length;

            //    for (int var6 = 0; var6 < var5; ++var6)
            //    {
            //        byte b = var4[var6];
            //        value <<= 8;
            //        value |= b & 255;
            //    }

            //    return value;
            //}
        }

        static readonly LongDeserializer _LongDeserializer = new LongDeserializer();
        /// <summary>
        /// Deserialize a <see cref="SerializationType.Long"/>
        /// </summary>
        public static long DeserializeLong(string topic, byte[] data)
        {
            var result = _LongDeserializer.Deserialize(topic, data);
            if (result is IJavaObject ijo)
            {
                return JVMBridgeBase.Wraps<Java.Lang.Long>(ijo);
            }
            return (long)result;

            //if (data == null)
            //{
            //    return default;
            //}
            //else if (data.Length != 8)
            //{
            //    JVMBridgeException<SerializationException>.ThrowNew("Size of data received by DeserializeLong is not 8");
            //    throw new SerializationException();
            //}
            //else
            //{
            //    long value = 0L;
            //    byte[] var5 = data;
            //    int var6 = data.Length;

            //    for (int var7 = 0; var7 < var6; ++var7)
            //    {
            //        byte b = var5[var7];
            //        value <<= 8;
            //        value |= (long)(b & 255);
            //    }

            //    return value;
            //}
        }

        static readonly ShortDeserializer _ShortDeserializer = new ShortDeserializer();
        /// <summary>
        /// Deserialize a <see cref="SerializationType.Short"/>
        /// </summary>
        public static short DeserializeShort(string topic, byte[] data)
        {
            var result = _ShortDeserializer.Deserialize(topic, data);
            if (result is IJavaObject ijo)
            {
                return JVMBridgeBase.Wraps<Java.Lang.Short>(ijo);
            }
            return (short)result;

            //if (data == null)
            //{
            //    return default;
            //}
            //else if (data.Length != 2)
            //{
            //    JVMBridgeException<SerializationException>.ThrowNew("Size of data received by DeserializeShort is not 2");
            //    throw new SerializationException();
            //}
            //else
            //{
            //    short value = 0;
            //    byte[] var4 = data;
            //    int var5 = data.Length;

            //    for (int var6 = 0; var6 < var5; ++var6)
            //    {
            //        byte b = var4[var6];
            //        value = (short)(value << 8);
            //        value = (short)(value | (b & 255));
            //    }

            //    return value;
            //}
        }
        /// <summary>
        /// Deserialize a <see cref="SerializationType.String"/>
        /// </summary>
        public static string DeserializeString(string topic, byte[] data)
        {
            return Encoding.UTF8.GetString(data);
        }
        /// <summary>
        /// Deserialize a <see cref="SerializationType.Guid"/>
        /// </summary>
        public static Guid DeserializeGuid(string topic, byte[] data)
        {
            return new Guid(data);
        }
        /// <summary>
        /// Deserialize a <see cref="SerializationType.Void"/>
        /// </summary>
        public static Java.Lang.Void DeserializeVoid(string topic, byte[] data)
        {
            if (data != null)
            {
                JVMBridgeException<IllegalArgumentException>.ThrowNew("Data should be null for a VoidDeserializer.");
                throw new IllegalArgumentException();
            }
            else
            {
                return null;
            }
        }
    }
}
