/*
*  Copyright (c) 2021-2025 MASES s.r.l.
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

using MASES.JCOBridge.C2JBridge;
using MASES.JCOBridge.C2JBridge.JVMInterop;
using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MASES.KNet.Serialization
{
    /// <summary>
    /// Helper for KNetSerDes
    /// </summary>
    public static class KNetSerialization
    {
        #region Private fields
        static readonly Org.Apache.Kafka.Common.Serialization.BooleanSerializer _BooleanSerializer = new();
        static readonly Org.Apache.Kafka.Common.Serialization.ByteBufferSerializer _ByteBufferSerializer = new();
        static readonly Org.Apache.Kafka.Common.Serialization.BytesSerializer _BytesSerializer = new();
        static readonly Org.Apache.Kafka.Common.Serialization.DoubleSerializer _DoubleSerializer = new();
        static readonly Org.Apache.Kafka.Common.Serialization.FloatSerializer _FloatSerializer = new();
        static readonly Org.Apache.Kafka.Common.Serialization.IntegerSerializer _IntSerializer = new();
        static readonly Org.Apache.Kafka.Common.Serialization.LongSerializer _LongSerializer = new();
        static readonly Org.Apache.Kafka.Common.Serialization.ShortSerializer _ShortSerializer = new();

        static readonly Org.Apache.Kafka.Common.Serialization.BooleanDeserializer _BooleanDeserializer = new();
        static readonly Org.Apache.Kafka.Common.Serialization.ByteBufferDeserializer _ByteBufferDeserializer = new();
        static readonly Org.Apache.Kafka.Common.Serialization.BytesDeserializer _BytesDeserializer = new();
        static readonly Org.Apache.Kafka.Common.Serialization.DoubleDeserializer _DoubleDeserializer = new();
        static readonly Org.Apache.Kafka.Common.Serialization.FloatDeserializer _FloatDeserializer = new();
        static readonly Org.Apache.Kafka.Common.Serialization.IntegerDeserializer _IntDeserializer = new();
        static readonly Org.Apache.Kafka.Common.Serialization.LongDeserializer _LongDeserializer = new();
        static readonly Org.Apache.Kafka.Common.Serialization.ShortDeserializer _ShortDeserializer = new();

        static bool CheckRevert(byte[] dotnet, byte[] java)
        {
            bool main = !dotnet.SequenceEqual(java);
            if (main)
            {
                Array.Reverse(dotnet); // revert and check consistency
                if (!dotnet.SequenceEqual(java)) throw new InvalidOperationException($"The sequence {BitConverter.ToString(dotnet)} is not equal to {BitConverter.ToString(java)}");
            }
            return main;
        }
        static readonly bool ShallRevertByteOrderShort = CheckRevert(BitConverter.GetBytes((short)1), _ShortSerializer.Serialize("", Java.Lang.Short.ValueOf(1)));
        static readonly bool ShallRevertByteOrderInt = CheckRevert(BitConverter.GetBytes(1), _IntSerializer.Serialize("", Java.Lang.Integer.ValueOf(1)));
        static readonly bool ShallRevertByteOrderLong = CheckRevert(BitConverter.GetBytes((long)1), _LongSerializer.Serialize("", Java.Lang.Long.ValueOf(1)));
        static readonly bool ShallRevertByteOrderFloat = CheckRevert(BitConverter.GetBytes(1.1F), _FloatSerializer.Serialize("", Java.Lang.Float.ValueOf(1.1F)));
        static readonly bool ShallRevertByteOrderDouble = CheckRevert(BitConverter.GetBytes(1.1), _DoubleSerializer.Serialize("", Java.Lang.Double.ValueOf(1.1)));

        #endregion

        #region Public properties
        /// <summary>
        /// Identity the type of the key used
        /// </summary>
        public const string KeyTypeIdentifier = "key-type";
        /// <summary>
        /// Identity the type of the key used using a <see cref="Java.Lang.String"/>
        /// </summary>
        public static readonly Java.Lang.String KeyTypeIdentifierJVM = new(KeyTypeIdentifier);
        /// <summary>
        /// Identity the serializer for the key
        /// </summary>
        public const string KeySerializerIdentifier = "key-serializer-type";
        /// <summary>
        /// Identity the serializer for the key using a <see cref="Java.Lang.String"/>
        /// </summary>
        public static readonly Java.Lang.String KeySerializerIdentifierJVM = new(KeySerializerIdentifier);
        /// <summary>
        /// Identity the type of the value used
        /// </summary>
        public const string ValueTypeIdentifier = "value-type";
        /// <summary>
        /// Identity the type of the value used using a <see cref="Java.Lang.String"/>
        /// </summary>
        public static readonly Java.Lang.String ValueTypeIdentifierJVM = new(ValueTypeIdentifier);
        /// <summary>
        /// Identity the serializer for the value
        /// </summary>
        public const string ValueSerializerIdentifier = "value-serializer-type";
        /// <summary>
        /// Identity the serializer for the value using a <see cref="Java.Lang.String"/>
        /// </summary>
        public static readonly Java.Lang.String ValueSerializerIdentifierJVM = new(ValueSerializerIdentifier);

        #endregion

        /// <summary>
        /// Returns the typename with the assembly qualification to help reload better the types
        /// </summary>
        /// <param name="type">The <see cref="Type"/> to be converted</param>
        /// <returns>A string with <see cref="Type.FullName"/> along with <see cref="Assembly.FullName"/></returns>
        public static string ToAssemblyQualified(this Type type) => $"{type.FullName}, {type.Assembly.GetName().Name}";

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
            /// <see cref="bool"/>
            /// </summary>
            Boolean,
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
            Integer,
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
        public static bool IsInternalManaged<TData>() => IsInternalManaged(typeof(TData));

        /// <summary>
        /// Check if a serializer is available for <paramref name="type"/>
        /// </summary>
        /// <param name="type">The <see cref="Type"/> to check</param>
        /// <returns><see langword="true"/> if managed</returns>
        public static bool IsInternalManaged(Type type)
        {
            if (type == typeof(bool) || type == typeof(byte[]) || type == typeof(Java.Nio.ByteBuffer) || type == typeof(Org.Apache.Kafka.Common.Utils.Bytes)
                || type == typeof(double) || type == typeof(float) || type == typeof(int) || type == typeof(long) || type == typeof(short) || type == typeof(string)
                || type == typeof(Guid) || type == typeof(void))
            {
                return true;
            }

            return false;
        }
        /// <summary>
        /// Check if a JVM serializer is available for <typeparamref name="TData"/>
        /// </summary>
        /// <typeparam name="TData">The type to check</typeparam>
        /// <returns><see langword="true"/> if managed</returns>
        public static bool IsJVMInternalManaged<TData>() => IsJVMInternalManaged(typeof(TData));

        /// <summary>
        /// Check if a JVM serializer is available for <paramref name="type"/>
        /// </summary>
        /// <param name="type">The <see cref="Type"/> to check</param>
        /// <returns><see langword="true"/> if managed</returns>
        public static bool IsJVMInternalManaged(Type type)
        {
            if (type == typeof(Java.Lang.Boolean) || type == typeof(byte[]) || type == typeof(Java.Nio.ByteBuffer) || type == typeof(Org.Apache.Kafka.Common.Utils.Bytes)
                || type == typeof(Java.Lang.Double) || type == typeof(Java.Lang.Float) || type == typeof(Java.Lang.Integer) || type == typeof(Java.Lang.Long)
                || type == typeof(Java.Lang.Short) || type == typeof(Java.Lang.String)
                || type == typeof(Java.Util.UUID) || type == typeof(Java.Lang.Void))
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
        public static SerializationType InternalSerDesType<TData>() => InternalSerDesType(typeof(TData));

        /// <summary>
        /// Returns the serializer <see cref="SerializationType"/> for <paramref name="type"/>
        /// </summary>
        /// <param name="type">The <see cref="Type"/> to check</param>
        /// <returns><see cref="SerializationType"/></returns>
        public static SerializationType InternalSerDesType(Type type)
        {
            if (type == typeof(bool)) return SerializationType.Boolean;
            else if (type == typeof(byte[])) return SerializationType.ByteArray;
            else if (type == typeof(Java.Nio.ByteBuffer)) return SerializationType.ByteBuffer;
            else if (type == typeof(Org.Apache.Kafka.Common.Utils.Bytes)) return SerializationType.Bytes;
            else if (type == typeof(double)) return SerializationType.Double;
            else if (type == typeof(float)) return SerializationType.Float;
            else if (type == typeof(int)) return SerializationType.Integer;
            else if (type == typeof(long)) return SerializationType.Long;
            else if (type == typeof(short)) return SerializationType.Short;
            else if (type == typeof(string)) return SerializationType.String;
            else if (type == typeof(Guid)) return SerializationType.Guid;
            else if (type == typeof(void)) return SerializationType.Void;

            return SerializationType.External;
        }

        /// <summary>
        /// Returns the JVM serializer <see cref="SerializationType"/> for <typeparamref name="TData"/>
        /// </summary>
        /// <typeparam name="TData">The type to check</typeparam>
        /// <returns><see cref="SerializationType"/></returns>
        public static SerializationType InternalJVMSerDesType<TData>()=> InternalJVMSerDesType(typeof(TData));

        /// <summary>
        /// Returns the JVM serializer <see cref="SerializationType"/> for <paramref name="type"/>
        /// </summary>
        /// <param name="type">The <see cref="Type"/> to check</param>
        /// <returns><see cref="SerializationType"/></returns>
        public static SerializationType InternalJVMSerDesType(Type type)
        {
            if (type == typeof(Java.Lang.Boolean)) return SerializationType.Boolean;
            else if (type == typeof(byte[])) return SerializationType.ByteArray;
            else if (type == typeof(Java.Nio.ByteBuffer)) return SerializationType.ByteBuffer;
            else if (type == typeof(Org.Apache.Kafka.Common.Utils.Bytes)) return SerializationType.Bytes;
            else if (type == typeof(Java.Lang.Double)) return SerializationType.Double;
            else if (type == typeof(Java.Lang.Float)) return SerializationType.Float;
            else if (type == typeof(Java.Lang.Integer)) return SerializationType.Integer;
            else if (type == typeof(Java.Lang.Long)) return SerializationType.Long;
            else if (type == typeof(Java.Lang.Short)) return SerializationType.Short;
            else if (type == typeof(Java.Lang.String)) return SerializationType.String;
            else if (type == typeof(Java.Util.UUID)) return SerializationType.Guid;
            else if (type == typeof(Java.Lang.Void)) return SerializationType.Void;

            return SerializationType.External;
        }

        /// <summary>
        /// Serialize a <see cref="SerializationType.Boolean"/>
        /// </summary>
        public static byte[] SerializeBoolean(bool fallbackToKafka, string topic, bool data)
        {
            if (fallbackToKafka) return _BooleanSerializer.Serialize(topic, data);
            return BitConverter.GetBytes(data);
        }

        /// <summary>
        /// Serialize a <see cref="SerializationType.ByteArray"/>
        /// </summary>
        public static byte[] SerializeByteArray(bool fallbackToKafka, string topic, byte[] data)
        {
            return data;
        }

        /// <summary>
        /// Serialize a <see cref="SerializationType.ByteBuffer"/>
        /// </summary>
        public static byte[] SerializeByteBuffer(bool fallbackToKafka, string topic, Java.Nio.ByteBuffer data)
        {
            if (fallbackToKafka) return _ByteBufferSerializer.Serialize(topic, data);
            return data.ToArray(true);
        }

        /// <summary>
        /// Serialize a <see cref="SerializationType.Bytes"/>
        /// </summary>
        public static byte[] SerializeBytes(bool fallbackToKafka, string topic, Org.Apache.Kafka.Common.Utils.Bytes data)
        {
            return _BytesSerializer.Serialize(topic, data);
        }

        /// <summary>
        /// Serialize a <see cref="SerializationType.Double"/>
        /// </summary>
        public static byte[] SerializeDouble(bool fallbackToKafka, string topic, double data)
        {
            if (fallbackToKafka) return _DoubleSerializer.Serialize(topic, data);
            var array = BitConverter.GetBytes(data);
            if (ShallRevertByteOrderDouble) Array.Reverse(array);
            return array;
        }

        /// <summary>
        /// Serialize a <see cref="SerializationType.Float"/>
        /// </summary>
        public static byte[] SerializeFloat(bool fallbackToKafka, string topic, float data)
        {
            if (fallbackToKafka) return _FloatSerializer.Serialize(topic, data);
            var array = BitConverter.GetBytes(data);
            if (ShallRevertByteOrderFloat) Array.Reverse(array);
            return array;
        }

        /// <summary>
        /// Serialize a <see cref="SerializationType.Integer"/>
        /// </summary>
        public static byte[] SerializeInt(bool fallbackToKafka, string topic, int data)
        {
            if (fallbackToKafka) return _IntSerializer.Serialize(topic, data);
            var array = BitConverter.GetBytes(data);
            if (ShallRevertByteOrderInt) Array.Reverse(array);
            return array;

            // the following generates an error in container
            //return new byte[] { (byte)(data >>> 24), (byte)(data >>> 16), (byte)(data >>> 8), ((byte)data) };
        }

        /// <summary>
        /// Serialize a <see cref="SerializationType.Long"/>
        /// </summary>
        public static byte[] SerializeLong(bool fallbackToKafka, string topic, long data)
        {
            if (fallbackToKafka) return _LongSerializer.Serialize(topic, data);
            var array = BitConverter.GetBytes(data);
            if (ShallRevertByteOrderLong) Array.Reverse(array);
            return array;

            // the following generates an error in container
            //return new byte[] { (byte)((int)(data >>> 56)), (byte)((int)(data >>> 48)), (byte)((int)(data >>> 40)), (byte)((int)(data >>> 32)), (byte)((int)(data >>> 24)), (byte)((int)(data >>> 16)), (byte)((int)(data >>> 8)), ((byte)data) };
        }

        /// <summary>
        /// Serialize a <see cref="SerializationType.Short"/>
        /// </summary>
        public static byte[] SerializeShort(bool fallbackToKafka, string topic, short data)
        {
            if (fallbackToKafka) return _ShortSerializer.Serialize(topic, data);
            var array = BitConverter.GetBytes(data);
            if (ShallRevertByteOrderShort) Array.Reverse(array);
            return array;

            // the following generates an error in container
            //return new byte[] { (byte)(data >>> 8), ((byte)data) };
        }
        /// <summary>
        /// Serialize a <see cref="SerializationType.String"/>
        /// </summary>
        public static byte[] SerializeString(bool fallbackToKafka, string topic, string data)
        {
            return Encoding.UTF8.GetBytes(data);
        }
        /// <summary>
        /// Serialize a <see cref="SerializationType.Guid"/>
        /// </summary>
        public static byte[] SerializeGuid(bool fallbackToKafka, string topic, Guid data)
        {
            return data.ToByteArray();
        }
        /// <summary>
        /// Serialize a <see cref="SerializationType.Void"/>
        /// </summary>
        public static byte[] SerializeVoid(bool fallbackToKafka, string topic, Java.Lang.Void data)
        {
            return null;
        }

        /// <summary>
        /// Deserialize a <see cref="SerializationType.Boolean"/>
        /// </summary>
        public static bool DeserializeBoolean(bool fallbackToKafka, string topic, byte[] data)
        {
            if (data == null || data.Length == 0) return default;
            if (fallbackToKafka)
            {
                var result = _BooleanDeserializer.Deserialize(topic, data);
                if (result is IJavaObject ijo)
                {
                    return JVMBridgeBase.WrapsDirect<Java.Lang.Boolean>(ijo);
                }
                return (bool)result;
            }
            return BitConverter.ToBoolean(data, 0);
        }

        /// <summary>
        /// Deserialize a <see cref="SerializationType.ByteArray"/>
        /// </summary>
        public static byte[] DeserializeByteArray(bool fallbackToKafka, string topic, byte[] data)
        {
            return data;
        }

        /// <summary>
        /// Deserialize a <see cref="SerializationType.ByteBuffer"/>
        /// </summary>
        public static Java.Nio.ByteBuffer DeserializeByteBuffer(bool fallbackToKafka, string topic, byte[] data)
        {
            if (data == null || data.Length == 0) return default;
            return JVMBridgeBase.WrapsDirect<Java.Nio.ByteBuffer>(_ByteBufferDeserializer.Deserialize(topic, data) as IJavaObject);
        }

        /// <summary>
        /// Deserialize a <see cref="SerializationType.Bytes"/>
        /// </summary>
        public static Org.Apache.Kafka.Common.Utils.Bytes DeserializeBytes(bool fallbackToKafka, string topic, byte[] data)
        {
            if (data == null || data.Length == 0) return default;
            return JVMBridgeBase.WrapsDirect<Org.Apache.Kafka.Common.Utils.Bytes>(_BytesDeserializer.Deserialize(topic, data) as IJavaObject);
        }

        /// <summary>
        /// Deserialize a <see cref="SerializationType.Double"/>
        /// </summary>
        public static double DeserializeDouble(bool fallbackToKafka, string topic, byte[] data)
        {
            if (data == null || data.Length == 0) return default;
            if (fallbackToKafka)
            {
                var result = _DoubleDeserializer.Deserialize(topic, data);
                if (result is IJavaObject ijo)
                {
                    return JVMBridgeBase.WrapsDirect<Java.Lang.Double>(ijo);
                }
                return (double)result;
            }
            if (ShallRevertByteOrderDouble) Array.Reverse(data);
            return BitConverter.ToDouble(data, 0);
        }

        /// <summary>
        /// Deserialize a <see cref="SerializationType.Float"/>
        /// </summary>
        public static float DeserializeFloat(bool fallbackToKafka, string topic, byte[] data)
        {
            if (data == null || data.Length == 0) return default;
            if (fallbackToKafka)
            {
                var result = _FloatDeserializer.Deserialize(topic, data);
                if (result is IJavaObject ijo)
                {
                    return JVMBridgeBase.WrapsDirect<Java.Lang.Float>(ijo);
                }
                return (float)result;
            }
            if (ShallRevertByteOrderFloat) Array.Reverse(data);
            return BitConverter.ToSingle(data, 0);
        }

        /// <summary>
        /// Deserialize a <see cref="SerializationType.Integer"/>
        /// </summary>
        public static int DeserializeInt(bool fallbackToKafka, string topic, byte[] data)
        {
            if (data == null || data.Length == 0) return default;
            if (fallbackToKafka)
            {
                var result = _IntDeserializer.Deserialize(topic, data);
                if (result is IJavaObject ijo)
                {
                    return JVMBridgeBase.WrapsDirect<Java.Lang.Integer>(ijo);
                }
                return (int)result;
            }
            if (ShallRevertByteOrderInt) Array.Reverse(data);
            return BitConverter.ToInt32(data, 0);

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

        /// <summary>
        /// Deserialize a <see cref="SerializationType.Long"/>
        /// </summary>
        public static long DeserializeLong(bool fallbackToKafka, string topic, byte[] data)
        {
            if (data == null || data.Length == 0) return default;
            if (fallbackToKafka)
            {
                var result = _LongDeserializer.Deserialize(topic, data);
                if (result is IJavaObject ijo)
                {
                    return JVMBridgeBase.WrapsDirect<Java.Lang.Long>(ijo);
                }
                return (long)result;
            }
            if (ShallRevertByteOrderLong) Array.Reverse(data);
            return BitConverter.ToInt64(data, 0);

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

        /// <summary>
        /// Deserialize a <see cref="SerializationType.Short"/>
        /// </summary>
        public static short DeserializeShort(bool fallbackToKafka, string topic, byte[] data)
        {
            if (data == null || data.Length == 0) return default;
            if (fallbackToKafka)
            {
                var result = _ShortDeserializer.Deserialize(topic, data);
                if (result is IJavaObject ijo)
                {
                    return JVMBridgeBase.WrapsDirect<Java.Lang.Short>(ijo);
                }
                return (short)result;
            }
            if (ShallRevertByteOrderShort) Array.Reverse(data);
            return BitConverter.ToInt16(data, 0);

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
        public static string DeserializeString(bool fallbackToKafka, string topic, byte[] data)
        {
            if (data == null || data.Length == 0) return default;
            return Encoding.UTF8.GetString(data);
        }
        /// <summary>
        /// Deserialize a <see cref="SerializationType.Guid"/>
        /// </summary>
        public static Guid DeserializeGuid(bool fallbackToKafka, string topic, byte[] data)
        {
            if (data == null || data.Length == 0) return Guid.Empty;
            return new Guid(data);
        }
        /// <summary>
        /// Deserialize a <see cref="SerializationType.Void"/>
        /// </summary>
        public static Java.Lang.Void DeserializeVoid(bool fallbackToKafka, string topic, byte[] data)
        {
            if (data != null || data.Length != 0)
            {
                JVMBridgeException<Java.Lang.IllegalArgumentException>.ThrowNew("Data should be null for a VoidDeserializer.");
                throw new Java.Lang.IllegalArgumentException();
            }
            else
            {
                return null;
            }
        }
    }
}
