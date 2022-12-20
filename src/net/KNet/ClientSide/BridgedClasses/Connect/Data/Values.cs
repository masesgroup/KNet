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

using MASES.JCOBridge.C2JBridge;
using Java.Math;
using Java.Util;

namespace MASES.KNet.Connect.Data
{
    public class Values : JVMBridgeBase<Values>
    {
        public override string ClassName => "org.apache.kafka.connect.data.Values";

        public static bool ConvertToBoolean(Schema schema, Java.Lang.Object value)
        {
            return SExecute<bool>("convertToBoolean", schema, value);
        }

        public static byte ConvertToByte(Schema schema, Java.Lang.Object value)
        {
            return SExecute<byte>("convertToByte", schema, value);
        }

        public static short ConvertToShort(Schema schema, Java.Lang.Object value)
        {
            return SExecute<short>("convertToShort", schema, value);
        }

        public static int ConvertToInteger(Schema schema, Java.Lang.Object value)
        {
            return SExecute<int>("convertToInteger", schema, value);
        }

        public static long ConvertToLong(Schema schema, Java.Lang.Object value)
        {
            return SExecute<long>("convertToLong", schema, value);
        }

        public static float ConvertToFloat(Schema schema, Java.Lang.Object value)
        {
            return SExecute<float>("convertToFloat", schema, value);
        }

        public static double ConvertToDouble(Schema schema, Java.Lang.Object value)
        {
            return SExecute<double>("convertToDouble", schema, value);
        }

        public static string ConvertToString(Schema schema, Java.Lang.Object value)
        {
            return SExecute<string>("convertToString", schema, value);
        }

        public static List ConvertToList(Schema schema, Java.Lang.Object value)
        {
            return SExecute<List>("convertToList", schema, value);
        }

        public static Map ConvertToMap(Schema schema, Java.Lang.Object value)
        {
            return SExecute<Map>("convertToMap", schema, value);
        }

        public static Struct ConvertToStruct(Schema schema, Java.Lang.Object value)
        {
            return SExecute<Struct>("convertToStruct", schema, value);
        }

        public static Java.Util.Date ConvertToTime(Schema schema, Java.Lang.Object value)
        {
            return SExecute<Java.Util.Date>("convertToTime", schema, value);
        }

        public static Java.Util.Date ConvertToDate(Schema schema, Java.Lang.Object value)
        {
            return SExecute<Java.Util.Date>("convertToDate", schema, value);
        }

        public static Java.Util.Date ConvertToTimestamp(Schema schema, Java.Lang.Object value)
        {
            return SExecute<Java.Util.Date>("convertToTimestamp", schema, value);
        }

        public static BigDecimal ConvertToDecimal(Schema schema, Java.Lang.Object value, int scale)
        {
            return SExecute<BigDecimal>("convertToDecimal", schema, value, scale);
        }

        public static Schema InferSchema(Java.Lang.Object value)
        {
            return SExecute<Schema>("inferSchema", value);
        }

        public static SchemaAndValue ParseString(string value)
        {
            return SExecute<SchemaAndValue>("parseString", value);
        }
    }
}
