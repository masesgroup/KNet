/*
*  Copyright 2022 MASES s.r.l.
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

using MASES.KafkaBridge.Common.Utils;
using Java.Lang;
using MASES.KafkaBridge.Java.Util;

namespace MASES.KafkaBridge.Common.Serialization
{
    public class Serdes : JCOBridge.C2JBridge.JVMBridgeBase<Serdes>
    {
        public override string ClassName => "org.apache.kafka.common.serialization.Serdes";
        /* disabled to be checked
        public static readonly dynamic VoidSerde = DynClazz.VoidSerde;

        public static readonly dynamic LongSerde = DynClazz.LongSerde;

        public static readonly dynamic IntegerSerde = DynClazz.IntegerSerde;

        public static readonly dynamic ShortSerde = DynClazz.ShortSerde;

        public static readonly dynamic FloatSerde = DynClazz.FloatSerde;

        public static readonly dynamic DoubleSerde = DynClazz.DoubleSerde;

        public static readonly dynamic StringSerde = DynClazz.StringSerde;

        public static readonly dynamic ByteBufferSerde = DynClazz.ByteBufferSerde;

        public static readonly dynamic BytesSerde = DynClazz.BytesSerde;

        public static readonly dynamic ByteArraySerde = DynClazz.ByteArraySerde;

        public static readonly dynamic UUIDSerde = DynClazz.UUIDSerde;
        */

        public static Serde<long> Long => SExecute<Serde<long>>("Long");

        public static Serde<int> Integer => SExecute<Serde<int>>("Integer");

        public static Serde<short> Short => SExecute<Serde<short>>("Short");

        public static Serde<float> Float => SExecute<Serde<float>>("Float");

        public static Serde<double> Double => SExecute<Serde<double>>("Double");

        public static Serde<string> String => SExecute<Serde<string>>("String");

        public static dynamic ByteBuffer => DynClazz.ByteBuffer();

        public static Serde<Bytes> Bytes => SExecute<Serde<Bytes>>("Bytes");

        public static Serde<UUID> UUID => SExecute<Serde<UUID>>("UUID");

        public static Serde<byte[]> ByteArray => SExecute<Serde<byte[]>>("ByteArray");

        public static Serde<Void> Void => SExecute<Serde<Void>>("Void");
    }
}
