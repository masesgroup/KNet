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

using Java.Lang;
using MASES.KNet.Streams;
using Org.Apache.Kafka.Streams;
using Org.Apache.Kafka.Streams.State;

namespace MASES.KNet.Specific.Streams
{
    /// <summary>
    /// Extends <see cref="RocksDBConfigSetter"/>
    /// </summary>
    public class KNetRocksDBConfigSetter : RocksDBConfigSetter
    {
        const string _bridgeClassName = "org.mases.knet.developed.streams.KNetRocksDBConfigSetter";
        /// <inheritdoc/>
        public override string BridgeClassName => _bridgeClassName;
        /// <inheritdoc/>
        public override bool IsBridgeAbstract => false;
        /// <inheritdoc/>
        public override bool IsBridgeInterface => false;
        /// <summary>
        /// Set the <see cref="KNetRocksDBConfigSetterCallback"/> used from the instances of <see cref="KNetRocksDBConfigSetter"/>
        /// </summary>
        /// <param name="callback">The allocated <see cref="KNetRocksDBConfigSetterCallback"/></param>
        public static void SetCallback(KNetRocksDBConfigSetterCallback callback)
        {
            SExecute("setCallback", callback);
        }
        /// <summary>
        /// The <see cref="Java.Lang.Class"/> to be used to set the value of <see cref="StreamsConfigBuilder.RocksDbConfigSetterClass"/> or <see cref="StreamsConfig.ROCKSDB_CONFIG_SETTER_CLASS_CONFIG"/>
        /// </summary>
        public static Java.Lang.Class KNetRocksDBConfigSetterClass => Class.ForName(_bridgeClassName, true, Class.SystemClassLoader);
    }
}
