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

namespace MASES.KNet.Connect.Data
{
    public class Date : JVMBridgeBase<Date>
    {
        public override string ClassName => "org.apache.kafka.connect.data.Date";

        public static string LOGICAL_NAME => Clazz.GetField<string>("LOGICAL_NAME");

        public static SchemaBuilder Builder => Clazz.GetField<SchemaBuilder>("builder");

        public static Schema SCHEMA => Clazz.GetField<Schema>("SCHEMA");

        public static int FromLogical(Schema schema, Java.Util.Date value)
        {
            return SExecute<int>("fromLogical", schema, value);
        }

        public static Java.Util.Date ToLogical(Schema schema, int value)
        {
            return SExecute<Java.Util.Date>("toLogical", schema, value);
        }
    }
}
