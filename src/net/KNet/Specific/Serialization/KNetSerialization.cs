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
using MASES.KNet.Common.Errors;
using MASES.KNet.Common.Serialization;
using System;
using System.Text;

namespace MASES.KNet.Serialization
{
    public static class KNetSerialization
    {
        public enum SerializationType
        {
            External,
            ByteArray,
            ByteBuffer,
            Bytes,
            Double,
            Float,
            Int,
            Long,
            Short,
            String,
            Guid,
            Void
        }

        public static bool IsInternalManaged<TData>()
        {
            return IsInternalManaged(typeof(TData));
        }

        public static bool IsInternalManaged(Type type)
        {
            if (type == typeof(byte[]) || type == typeof(ByteBuffer) || type == typeof(Common.Utils.Bytes)
                || type == typeof(double) || type == typeof(float) || type == typeof(int) || type == typeof(long) || type == typeof(short) || type == typeof(string)
                || type == typeof(Guid) || type == typeof(void))
            {
                return true;
            }

            return false;
        }

        public static SerializationType InternalSerDesType<TData>()
        {
            return InternalSerDesType(typeof(TData));
        }

        public static SerializationType InternalSerDesType(Type type)
        {
            if (type == typeof(byte[])) return SerializationType.ByteArray;
            else if (type == typeof(ByteBuffer)) return SerializationType.ByteBuffer;
            else if (type == typeof(Common.Utils.Bytes)) return SerializationType.Bytes;
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


        public static byte[] SerializeByteArray(string topic, byte[] data)
        {
            return data;
        }

        static readonly Serializer<ByteBuffer> _ByteBufferSerializer = new ByteBufferSerializer();
        public static byte[] SerializeByteBuffer(string topic, ByteBuffer data)
        {
            return _ByteBufferSerializer.Serialize(topic, data);
        }

        static readonly Serializer<Common.Utils.Bytes> _BytesSerializer = new BytesSerializer();
        public static byte[] SerializeBytes(string topic, Common.Utils.Bytes data)
        {
            return _BytesSerializer.Serialize(topic, data);
        }

        static readonly Serializer<double> _DoubleSerializer = new DoubleSerializer();
        public static byte[] SerializeDouble(string topic, double data)
        {
            return _DoubleSerializer.Serialize(topic, data);
        }

        static readonly Serializer<float> _FloatSerializer = new FloatSerializer();
        public static byte[] SerializeFloat(string topic, float data)
        {
            return _FloatSerializer.Serialize(topic, data);
        }

        static readonly Serializer<int> _IntSerializer = new IntegerSerializer();
        public static byte[] SerializeInt(string topic, int data)
        {
            return _IntSerializer.Serialize(topic, data);
            // the following generates an error in container
            //return new byte[] { (byte)(data >>> 24), (byte)(data >>> 16), (byte)(data >>> 8), ((byte)data) };
        }

        static readonly Serializer<long> _LongSerializer = new LongSerializer();
        public static byte[] SerializeLong(string topic, long data)
        {
            return _LongSerializer.Serialize(topic, data);
            // the following generates an error in container
            //return new byte[] { (byte)((int)(data >>> 56)), (byte)((int)(data >>> 48)), (byte)((int)(data >>> 40)), (byte)((int)(data >>> 32)), (byte)((int)(data >>> 24)), (byte)((int)(data >>> 16)), (byte)((int)(data >>> 8)), ((byte)data) };
        }

        static readonly Serializer<short> _ShortSerializer = new ShortSerializer();
        public static byte[] SerializeShort(string topic, short data)
        {
            return _ShortSerializer.Serialize(topic, data);
            // the following generates an error in container
            //return new byte[] { (byte)(data >>> 8), ((byte)data) };
        }

        public static byte[] SerializeString(string topic, string data)
        {
            return Encoding.UTF8.GetBytes(data);
        }

        public static byte[] SerializeGuid(string topic, Guid data)
        {
            return data.ToByteArray();
        }

        public static byte[] SerializeVoid(string topic, Java.Lang.Void data)
        {
            return null;
        }

        public static byte[] DeserializeByteArray(string topic, byte[] data)
        {
            return data;
        }

        static readonly Deserializer<ByteBuffer> _ByteBufferDeserializer = new ByteBufferDeserializer();
        public static ByteBuffer DeserializeByteBuffer(string topic, byte[] data)
        {
            return _ByteBufferDeserializer.Deserialize(topic, data);
        }

        static readonly Deserializer<Common.Utils.Bytes> _BytesDeserializer = new BytesDeserializer();
        public static Common.Utils.Bytes DeserializeBytes(string topic, byte[] data)
        {
            return _BytesDeserializer.Deserialize(topic, data);
        }

        static readonly Deserializer<double> _DoubleDeserializer = new DoubleDeserializer();
        public static double DeserializeDouble(string topic, byte[] data)
        {
            return _DoubleDeserializer.Deserialize(topic, data);
        }

        static readonly Deserializer<float> _FloatDeserializer = new FloatDeserializer();
        public static float DeserializeFloat(string topic, byte[] data)
        {
            return _FloatDeserializer.Deserialize(topic, data);
        }

        static readonly Deserializer<int> _IntDeserializer = new IntegerDeserializer();
        public static int DeserializeInt(string topic, byte[] data)
        {
            return _IntDeserializer.Deserialize(topic, data);

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

        static readonly Deserializer<long> _LongDeserializer = new LongDeserializer();
        public static long DeserializeLong(string topic, byte[] data)
        {
            return _LongDeserializer.Deserialize(topic, data);

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

        static readonly Deserializer<short> _ShortDeserializer = new ShortDeserializer();
        public static short DeserializeShort(string topic, byte[] data)
        {
            return _ShortDeserializer.Deserialize(topic, data);

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

        public static string DeserializeString(string topic, byte[] data)
        {
            return Encoding.UTF8.GetString(data);
        }

        public static Guid DeserializeGuid(string topic, byte[] data)
        {
            return new Guid(data);
        }

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
