﻿/*
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

namespace MASES.KNet.Common.Utils
{
    public class Bytes : JCOBridge.C2JBridge.JVMBridgeBase<Bytes>
    {
        public override string BridgeClassName => "org.apache.kafka.common.utils.Bytes";

        public static Bytes Wrap(byte[] bytes)
        {
            return SExecute<Bytes>("wrap", bytes);
        }

        public Bytes()
        {

        }

        public Bytes(byte[] bytes)
            : base(bytes)
        {
        }

        public byte[] Get => IExecute<byte[]>("get");


        public int CompareTo(Bytes that)
        {
            return IExecute<int>("compareTo", that);
        }

        public static Bytes Increment(Bytes input)
        {
            return SExecute<Bytes>("increment", input);
        }
    }
}
