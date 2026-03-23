/*
*  Copyright (c) 2021-2026 MASES s.r.l.
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

using Org.Apache.Kafka.Streams.State;

namespace MASES.KNet.Specific.Streams
{
    /// <summary>
    /// Extends <see cref="RocksDBConfigSetter"/>
    /// </summary>
    public class KNetRocksDBConfigSetter : RocksDBConfigSetter
    {
        /// <inheritdoc/>
        public override string BridgeClassName => "org.mases.knet.developed.streams.KNetRocksDBConfigSetter";
        /// <summary>
        /// Set the <see cref="KNetRocksDBConfigSetterCallback"/> used from the instances of <see cref="KNetRocksDBConfigSetter"/>
        /// </summary>
        /// <param name="callback">The allocated <see cref="KNetRocksDBConfigSetterCallback"/></param>
        public static void SetCallback(KNetRocksDBConfigSetterCallback callback)
        {
            SExecute("setCallback", callback);
        }
    }
}
