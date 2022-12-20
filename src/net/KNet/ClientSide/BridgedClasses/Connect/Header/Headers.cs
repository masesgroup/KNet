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

using Java.Lang;
using Java.Math;
using Java.Util;
using MASES.JCOBridge.C2JBridge;
using MASES.KNet.Connect.Data;

namespace MASES.KNet.Connect.Header
{
    public class Headers : JVMBridgeBase<Headers>
    {
        public override bool IsInterface => true;
        public override string ClassName => "org.apache.kafka.connect.header.Headers";

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public Headers()
        {
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        protected Headers(params object[] args)
            : base(args)
        {
        }

        public static implicit operator Iterable<Header>(Headers headers) { return headers.Cast<Iterable<Header>>(); }

        public int Size => IExecute<int>("size");

        public bool IsEmpty => IExecute<bool>("isEmpty");

        public Iterator<Header> AllWithName(string key) => IExecute<Iterator<Header>>("allWithName", key);

        public Header LastWithName(string key) => IExecute<Header>("lastWithName", key);

        public Headers Add(Header header) => IExecute<Headers>("add", header);

        public Headers Add(string key, SchemaAndValue schemaAndValue) => IExecute<Headers>("add", key, schemaAndValue);

        public Headers Add(string key, object value, Schema schema) => IExecute<Headers>("add", key, value, schema);

        public Headers AddString(string key, string value) => IExecute<Headers>("addString", key, value);

        public Headers AddBoolean(string key, bool value) => IExecute<Headers>("addBoolean", key, value);

        public Headers AddByte(String key, byte value) => IExecute<Headers>("addByte", key, value);

        public Headers AddShort(String key, short value) => IExecute<Headers>("addShort", key, value);

        public Headers AddInt(String key, int value) => IExecute<Headers>("addInt", key, value);

        public Headers AddLong(String key, long value) => IExecute<Headers>("addLong", key, value);

        public Headers AddFloat(String key, float value) => IExecute<Headers>("addFloat", key, value);

        public Headers AddDouble(String key, double value) => IExecute<Headers>("addDouble", key, value);

        public Headers AddBytes(String key, byte[] value) => IExecute<Headers>("addBytes", key, value);

        public Headers AddList(String key, List value, Schema schema) => IExecute<Headers>("addList", key, value, schema);

        public Headers AddMap(String key, Map value, Schema schema) => IExecute<Headers>("addMap", key, value, schema);

        public Headers AddStruct(String key, Struct value) => IExecute<Headers>("addStruct", key, value);

        public Headers AddDecimal(String key, BigDecimal value) => IExecute<Headers>("addDecimal", key, value);

        public Headers AddDate(String key, Java.Util.Date value) => IExecute<Headers>("addDate", key, value);

        public Headers AddTime(String key, Java.Util.Date value) => IExecute<Headers>("addTime", key, value);

        public Headers AddTimestamp(String key, Java.Util.Date value) => IExecute<Headers>("addTimestamp", key, value);

        public Headers Remove(String key) => IExecute<Headers>("remove", key);

        public Headers RetainLatest(String key) => IExecute<Headers>("retainLatest", key);

        public Headers RetainLatest() => IExecute<Headers>("retainLatest");

        public Headers Clear() => IExecute<Headers>("clear");

        public Headers Duplicate() => IExecute<Headers>("duplicate");

        public Headers Apply(HeaderTransform transform) => IExecute<Headers>("apply", transform);

        public Headers Apply(string key, HeaderTransform transform) => IExecute<Headers>("apply", key, transform);

        public class HeaderTransform : JVMBridgeBase<HeaderTransform>
        {
            public override bool IsInterface => true;
            public override string ClassName => "org.apache.kafka.connect.header.Headers$HeaderTransform";

            public Header Apply(Header header) => IExecute<Header>("apply", header);
        }
    }
}
