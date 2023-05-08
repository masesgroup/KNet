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

using MASES.JCOBridge.C2JBridge;
using Java.Util;

namespace MASES.KNet.Streams.KStream
{
    public class Windows<W> : JVMBridgeBase<Windows<W>>
        where W: Window
    {
        public override string BridgeClassName => "org.apache.kafka.streams.kstream.Windows";

        public Map<long, W> WindowsFor(long timestamp)
        {
            return IExecute<Map<long, W>>("windowsFor", timestamp);
        }

        public long Size => IExecute<long>("size");

        public long GracePeriodMs => IExecute<long>("gracePeriodMs");
    }
}
