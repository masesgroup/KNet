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

using MASES.JCOBridge.C2JBridge;
using Java.Math;

namespace MASES.KNet.Connect.Data
{
    public class Decimal : JVMBridgeBase<Decimal>
    {
        public override string BridgeClassName => "org.apache.kafka.connect.data.Decimal";

        public static string LOGICAL_NAME => BridgeClazz.GetField<string>("LOGICAL_NAME");

        public static string SCALE_FIELD => BridgeClazz.GetField<string>("SCALE_FIELD");

        public static SchemaBuilder Builder(int scale) { return SExecute<SchemaBuilder>("builder", scale); }

        public static Schema Schema(int scale) { return SExecute<Schema>("schema"); }

        public static byte[] FromLogical(Schema schema, BigDecimal value)
        {
            return SExecute<byte[]>("fromLogical", schema, value);
        }

        public static BigDecimal ToLogical(Schema schema, byte[] value)
        {
            return SExecute<BigDecimal>("toLogical", schema, value);
        }
    }
}
