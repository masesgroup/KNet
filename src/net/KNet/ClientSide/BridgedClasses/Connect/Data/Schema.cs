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
        Type Type { get; }

        bool IsOptional { get; }

        Java.Lang.Object DefaultValue { get; }

        string Name { get; }

        int Version { get; }

        string Doc { get; }

        Map<string, string> Parameters { get; }

        Schema KeySchema { get; }

        Schema ValueSchema { get; }

        List<Field> Fields { get; }

        Field Field(string fieldName);

        Schema Schema { get; }
    }

    public class Schema : JVMBridgeBase<Schema>, ISchema
    {
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

        public Type Type => IExecute<Type>("type"); 

        public bool IsOptional => IExecute<bool>("isOptional");

        public Java.Lang.Object DefaultValue =>  IExecute<Java.Lang.Object>("defaultValue"); 

        public string Name => IExecute<string>("name"); 

        public int Version => IExecute<int>("version"); 

        public string Doc => IExecute<string>("doc"); 

        public Map<string, string> Parameters => IExecute<Map<string, string>>("parameters"); 

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
