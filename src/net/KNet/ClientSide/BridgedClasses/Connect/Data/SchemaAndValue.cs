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

namespace MASES.KNet.Connect.Data
{
    public class SchemaAndValue : JVMBridgeBase<SchemaAndValue>
    {
        public override string ClassName => "org.apache.kafka.connect.data.SchemaAndValue";

        [System.Obsolete("This is not public in Apache Kafka API")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public SchemaAndValue()
        {
        }

        public SchemaAndValue(Schema schema, Java.Lang.Object value)
            :base(schema, value)
        {
        }

        public Schema Schema => IExecute<Schema>("schema");

        public Java.Lang.Object Value => IExecute<Java.Lang.Object>("value");
    }
}
