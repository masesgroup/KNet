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
using Java.Util;

namespace MASES.KNet.Connect.Data
{
    public enum Type
    {
        /**
         *  8-bit signed integer
         *
         *  Note that if you have an unsigned 8-bit data source, {@link Type#INT16} will be required to safely capture all valid values
         */
        INT8,
        /**
         *  16-bit signed integer
         *
         *  Note that if you have an unsigned 16-bit data source, {@link Type#INT32} will be required to safely capture all valid values
         */
        INT16,
        /**
         *  32-bit signed integer
         *
         *  Note that if you have an unsigned 32-bit data source, {@link Type#INT64} will be required to safely capture all valid values
         */
        INT32,
        /**
         *  64-bit signed integer
         *
         *  Note that if you have an unsigned 64-bit data source, the {@link Decimal} logical type (encoded as {@link Type#BYTES})
         *  will be required to safely capture all valid values
         */
        INT64,
        /**
         *  32-bit IEEE 754 floating point number
         */
        FLOAT32,
        /**
         *  64-bit IEEE 754 floating point number
         */
        FLOAT64,
        /**
         * Boolean value (true or false)
         */
        BOOLEAN,
        /**
         * Character string that supports all Unicode characters.
         *
         * Note that this does not imply any specific encoding (e.g. UTF-8) as this is an in-memory representation.
         */
        STRING,
        /**
         * Sequence of unsigned 8-bit bytes
         */
        BYTES,
        /**
         * An ordered sequence of elements, each of which shares the same type.
         */
        ARRAY,
        /**
         * A mapping from keys to values. Both keys and values can be arbitrarily complex types, including complex types
         * such as {@link Struct}.
         */
        MAP,
        /**
         * A structured record containing a set of named fields, each field using a fixed, independent {@link Schema}.
         */
        STRUCT,
    }

    public interface ISchema : IJVMBridgeBase
    {
        Type Type();

        bool IsOptional { get; }

        Java.Lang.Object DefaultValue();

        string Name();

        int Version();

        string Doc();

        Map<string, string> Parameters();

        Schema KeySchema { get; }

        Schema ValueSchema { get; }

        List<Field> Fields { get; }

        Field Field(string fieldName);

        Schema Schema { get; }
    }

    public class Schema : JVMBridgeBase<Schema>, ISchema
    {
        public override bool IsInterface => true;

        public override string ClassName => "org.apache.kafka.connect.data.Schema";

        [System.Obsolete("This is not public in Apache Kafka API")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public Schema() { }

        [System.Obsolete("This is not public in Apache Kafka API")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public Schema(params object[] args)
            : base(args)
        {
        }

        public static Schema INT8_SCHEMA => SExecute<Schema>("INT8_SCHEMA");
        public static Schema INT16_SCHEMA => SExecute<Schema>("INT16_SCHEMA");
        public static Schema INT32_SCHEMA => SExecute<Schema>("INT32_SCHEMA");
        public static Schema INT64_SCHEMA => SExecute<Schema>("INT64_SCHEMA");
        public static Schema FLOAT32_SCHEMA => SExecute<Schema>("FLOAT32_SCHEMA");
        public static Schema FLOAT64_SCHEMA => SExecute<Schema>("FLOAT64_SCHEMA");
        public static Schema BOOLEAN_SCHEMA => SExecute<Schema>("BOOLEAN_SCHEMA");
        public static Schema STRING_SCHEMA => SExecute<Schema>("STRING_SCHEMA");
        public static Schema BYTES_SCHEMA => SExecute<Schema>("BYTES_SCHEMA");

        public static Schema OPTIONAL_INT8_SCHEMA => SExecute<Schema>("OPTIONAL_INT8_SCHEMA");
        public static Schema OPTIONAL_INT16_SCHEMA => SExecute<Schema>("OPTIONAL_INT16_SCHEMA");
        public static Schema OPTIONAL_INT32_SCHEMA => SExecute<Schema>("OPTIONAL_INT32_SCHEMA");
        public static Schema OPTIONAL_INT64_SCHEMA => SExecute<Schema>("OPTIONAL_INT64_SCHEMA");
        public static Schema OPTIONAL_FLOAT32_SCHEMA => SExecute<Schema>("OPTIONAL_FLOAT32_SCHEMA");
        public static Schema OPTIONAL_FLOAT64_SCHEMA => SExecute<Schema>("OPTIONAL_FLOAT64_SCHEMA");
        public static Schema OPTIONAL_BOOLEAN_SCHEMA => SExecute<Schema>("OPTIONAL_BOOLEAN_SCHEMA");
        public static Schema OPTIONAL_STRING_SCHEMA => SExecute<Schema>("OPTIONAL_STRING_SCHEMA");
        public static Schema OPTIONAL_BYTES_SCHEMA => SExecute<Schema>("OPTIONAL_BYTES_SCHEMA");

        public Type Type() => IExecute<Type>("type"); 

        public bool IsOptional => IExecute<bool>("isOptional");

        public Java.Lang.Object DefaultValue() =>  IExecute<Java.Lang.Object>("defaultValue"); 

        public string Name() => IExecute<string>("name"); 

        public int Version() => IExecute<int>("version"); 

        public string Doc() => IExecute<string>("doc"); 

        public Map<string, string> Parameters() => IExecute<Map<string, string>>("parameters"); 

        public Schema KeySchema => IExecute<Schema>("keySchema");

        public Schema ValueSchema => IExecute<Schema>("valueSchema");

        public List<Field> Fields => IExecute<List<Field>>("fields");

        Schema ISchema.Schema => IExecute<Schema>("schema");

        public Field Field(string fieldName)
        {
            return IExecute<Field>("field", fieldName);
        }
    }
}
