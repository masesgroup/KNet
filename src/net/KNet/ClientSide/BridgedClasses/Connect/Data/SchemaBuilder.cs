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

using Java.Util;

namespace MASES.KNet.Connect.Data
{
    public class SchemaBuilder : Schema
    {
        public override bool IsInterface => false;

        public override string ClassName => "org.apache.kafka.connect.data.SchemaBuilder";

        [System.Obsolete("This is not public in Apache Kafka API")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public SchemaBuilder()
        {
        }

        public SchemaBuilder(Type type)
            : base(type)
        {

        }

        public static SchemaBuilder Type(Type type)
        {
            return SExecute<SchemaBuilder>("type", type);
        }

        public static SchemaBuilder Int8 => SExecute<SchemaBuilder>("int8");

        public static SchemaBuilder Int16 => SExecute<SchemaBuilder>("int16");

        public static SchemaBuilder Int32 => SExecute<SchemaBuilder>("int32");

        public static SchemaBuilder Int64 => SExecute<SchemaBuilder>("int64");

        public static SchemaBuilder Float32 => SExecute<SchemaBuilder>("float32");

        public static SchemaBuilder Float64 => SExecute<SchemaBuilder>("float64");

        public static SchemaBuilder Bool => SExecute<SchemaBuilder>("bool");

        public static SchemaBuilder String => SExecute<SchemaBuilder>("string");

        public static SchemaBuilder Bytes => SExecute<SchemaBuilder>("bytes");

        public static SchemaBuilder Struct => SExecute<SchemaBuilder>("struct");

        public static SchemaBuilder Array(Schema valueSchema)
        {
            return SExecute<SchemaBuilder>("array", valueSchema);
        }

        public static SchemaBuilder Map(Schema keySchema, Schema valueSchema)
        {
            return SExecute<SchemaBuilder>("map", keySchema, valueSchema);
        }

        public SchemaBuilder Optional => IExecute<SchemaBuilder>("optional");

        public SchemaBuilder Required => IExecute<SchemaBuilder>("required");


        public SchemaBuilder DefaultValue(object value)
        {
            return IExecute<SchemaBuilder>("defaultValue", value);
        }

        public SchemaBuilder Name(string name)
        {
            return IExecute<SchemaBuilder>("name", name);
        }

        public SchemaBuilder Version(int version)
        {
            return IExecute<SchemaBuilder>("version", version);
        }

        public SchemaBuilder Doc(string doc)
        {
            return IExecute<SchemaBuilder>("doc", doc);
        }

        public SchemaBuilder Parameter(string propertyName, string propertyValue)
        {
            return IExecute<SchemaBuilder>("parameter", propertyName, propertyValue);
        }

        public SchemaBuilder Parameters(Map<string, string> props)
        {
            return IExecute<SchemaBuilder>("parameters", props);
        }

        public SchemaBuilder Field(string fieldName, Schema fieldSchema)
        {
            return IExecute<SchemaBuilder>("field", fieldName, fieldSchema);
        }

        public Schema Build()
        {
            return IExecute<Schema>("build");
        }
    }
}
