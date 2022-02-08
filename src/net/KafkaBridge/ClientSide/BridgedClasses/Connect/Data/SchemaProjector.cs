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
using System;

namespace MASES.KafkaBridge.Connect.Data
{
    public class SchemaProjector : JVMBridgeBase<SchemaProjector>
    {
        public override string ClassName => "org.apache.kafka.connect.data.SchemaProjector";

        public static Java.Lang.Object project(Schema source, Object record, Schema target)
        {
            return SExecute<Java.Lang.Object>("project", source, record, target);
        }
    }
}
