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
        public static dynamic Long => DynClazz.Long();

        public static dynamic Integer => DynClazz.Integer();

        public static dynamic Short => DynClazz.Short();

        public static dynamic Float => DynClazz.Float();

        public static dynamic Double => DynClazz.Double();

        public static dynamic String => DynClazz.String();

        public static dynamic ByteBuffer => DynClazz.ByteBuffer();

        public static dynamic Bytes => DynClazz.Bytes();

        public static dynamic UUID => DynClazz.UUID();

        public static dynamic ByteArray => DynClazz.ByteArray();

        public static dynamic Void => DynClazz.Void();
    }
}
