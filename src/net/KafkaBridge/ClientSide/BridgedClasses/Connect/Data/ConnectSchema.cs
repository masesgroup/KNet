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

using MASES.KafkaBridge.Java.Util;
using JavaLang = Java.Lang;

namespace MASES.KafkaBridge.Connect.Data
{
    public class ConnectSchema : Schema
    {
        public override string ClassName => "org.apache.kafka.connect.data.ConnectSchema";

        [System.Obsolete("This is not public in Apache Kafka API")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public ConnectSchema()
        {
        }

        public ConnectSchema(Type type, bool optional, JavaLang.Object defaultValue, string name, int version, string doc, Map<string, string> parameters, List<Field> fields, Schema keySchema, Schema valueSchema)
            : base(type, optional, defaultValue, name, version, doc, parameters, fields, keySchema, valueSchema)
        {
        }

        public ConnectSchema(Type type, bool optional, JavaLang.Object defaultValue, string name, int version, string doc)
            :this(type, optional, defaultValue, name, version, doc, null, null, null, null)
        {
        }

        public ConnectSchema(Type type)
            : base(type)
        {
        }

        public static void ValidateValue(Schema schema, object value)
        {
            SExecute<SchemaBuilder>("validateValue", schema, value);
        }

        public static void ValidateValue(string name, Schema schema, object value)
        {
            SExecute<SchemaBuilder>("validateValue",name, schema, value);
        }

        //public static Type schemaType(Class klass)
        //{
        //}

        public void ValidateValue(object value)
        {
            IExecute("validateValue", value);
        }
    }
}
