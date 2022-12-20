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
    public class Struct : JVMBridgeBase<Struct>
    {
        public override string ClassName => "org.apache.kafka.connect.data.Struct";

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public Struct() { }

        public Struct(Schema schema)
             : base(schema)
        {
        }

        public Schema Schema => IExecute<Schema>("schema");

        public Java.Lang.Object Get(string fieldName)
        {
            return IExecute<Java.Lang.Object>("get", fieldName);
        }

        public Java.Lang.Object Get(Field field)
        {
            return IExecute<Java.Lang.Object>("get", field);
        }

        public Java.Lang.Object GetWithoutDefault(string fieldName)
        {
            return IExecute<Java.Lang.Object>("getWithoutDefault", fieldName);
        }

        public byte GetInt8(string fieldName)
        {
            return IExecute<byte>("getInt8", fieldName);
        }

        public short GetInt16(string fieldName)
        {
            return IExecute<short>("getInt16", fieldName);
        }

        public int GetInt32(string fieldName)
        {
            return IExecute<int>("getInt32", fieldName);
        }

        public long GetInt64(string fieldName)
        {
            return IExecute<long>("getInt64", fieldName);
        }

        public float GetFloat32(string fieldName)
        {
            return IExecute<float>("getFloat32", fieldName);
        }

        public double GetFloat64(string fieldName)
        {
            return IExecute<double>("getFloat64", fieldName);
        }

        public bool GetBoolean(string fieldName)
        {
            return IExecute<bool>("getBoolean", fieldName);
        }

        public string GetString(string fieldName)
        {
            return IExecute<string>("getString", fieldName);
        }

        public byte[] GetBytes(string fieldName)
        {
            return IExecute<byte[]>("getBytes", fieldName);
        }

        public  List<T> GetArray<T>(string fieldName)
        {
            return IExecute<List<T>>("getArray", fieldName);
        }

        public Map<K, V> GetMap<K, V>(string fieldName)
        {
            return IExecute<Map<K, V>>("getMap", fieldName);
        }

        public Struct GetStruct(string fieldName)
        {
            return IExecute<Struct>("getStruct", fieldName);
        }

        public Struct Put(string fieldName, Java.Lang.Object value)
        {
            return IExecute<Struct>("put", fieldName, value);
        }

        public Struct Put(Field field, Java.Lang.Object value)
        {
            return IExecute<Struct>("put", field, value);
        }

        public void Validate()
        {
            IExecute("validate");
        }
    }
}
