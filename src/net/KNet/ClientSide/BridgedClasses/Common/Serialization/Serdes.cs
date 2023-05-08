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

using MASES.KNet.Common.Utils;
using Java.Lang;
using Java.Util;

namespace MASES.KNet.Common.Serialization
{
    public class Serdes : JCOBridge.C2JBridge.JVMBridgeBase<Serdes>
    {
        public override string BridgeClassName => "org.apache.kafka.common.serialization.Serdes";
        /* disabled to be checked
        public static readonly dynamic VoidSerde = DynBridgeClazz.VoidSerde;

        public static readonly dynamic LongSerde = DynBridgeClazz.LongSerde;

        public static readonly dynamic IntegerSerde = DynBridgeClazz.IntegerSerde;

        public static readonly dynamic ShortSerde = DynBridgeClazz.ShortSerde;

        public static readonly dynamic FloatSerde = DynBridgeClazz.FloatSerde;

        public static readonly dynamic DoubleSerde = DynBridgeClazz.DoubleSerde;

        public static readonly dynamic StringSerde = DynBridgeClazz.StringSerde;

        public static readonly dynamic ByteBufferSerde = DynBridgeClazz.ByteBufferSerde;

        public static readonly dynamic BytesSerde = DynBridgeClazz.BytesSerde;

        public static readonly dynamic ByteArraySerde = DynBridgeClazz.ByteArraySerde;

        public static readonly dynamic UUIDSerde = DynBridgeClazz.UUIDSerde;
        */

        public static Serde<long> Long => SExecute<Serde<long>>("Long");

        public static Serde<int> Integer => SExecute<Serde<int>>("Integer");

        public static Serde<short> Short => SExecute<Serde<short>>("Short");

        public static Serde<float> Float => SExecute<Serde<float>>("Float");

        public static Serde<double> Double => SExecute<Serde<double>>("Double");

        public static Serde<string> String => SExecute<Serde<string>>("String");

        public static dynamic ByteBuffer => DynBridgeClazz.ByteBuffer();

        public static Serde<Bytes> Bytes => SExecute<Serde<Bytes>>("Bytes");

        public static Serde<UUID> UUID => SExecute<Serde<UUID>>("UUID");

        public static Serde<byte[]> ByteArray => SExecute<Serde<byte[]>>("ByteArray");

        public static Serde<Void> Void => SExecute<Serde<Void>>("Void");
    }
}
