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
using Org.Apache.Kafka.Streams.Kstream;

namespace MASES.KNet.Streams.Kstream
{
    /// <summary>
    /// KNet extension of <see cref="Predicate{K, V}"/>
    /// </summary>
    public class KNetPredicateTester : JVMBridgeBase<KNetPredicateTester>
    {
        /// <summary>
        /// <see href="https://www.jcobridge.com/api-clr/html/P_MASES_JCOBridge_C2JBridge_JVMBridgeBase_BridgeClassName.htm"/>
        /// </summary>
        public override string BridgeClassName => "org.mases.knet.streams.kstream.KNetPredicateTester";
        /// <summary>
        /// Converter from <see cref="KNetPredicateTester"/> to <see cref="Predicate"/>
        /// </summary>
        public static implicit operator Predicate(KNetPredicateTester t) => t.Cast<Predicate>();
        /// <summary>
        /// Converter from <see cref="KNetPredicateTester"/> to <see cref="Predicate{K, V}"/>
        /// </summary>
        /// <remarks>This cast is useful when an API needs in input a type like <see cref="Predicate{K, V}"/>, however the behavior of the <see cref="Predicate{K, V}"/> in output is different from the same class allocated directly</remarks>
        public static implicit operator Predicate<byte[], byte[]>(KNetPredicateTester t) => t.Cast<Predicate<byte[], byte[]>>();
        /// <summary>
        /// Default constructor: even if the corresponding Java class does not have one, it is mandatory for JCOBridge
        /// </summary>
        public KNetPredicateTester() { }
        /// <summary>
        /// Generic constructor: it is useful for JCOBridge when there is a derived class which needs to pass arguments to the highest JVMBridgeBase class
        /// </summary>
        public KNetPredicateTester(params object[] args) : base(args) { }
        /// <summary>
        /// Initialize a new <see cref="KNetPredicateTester"/> for key or value comparison
        /// </summary>
        /// <param name="keyOrValue">The key, or value, to use in comparison</param>
        /// <param name="isKey"><see langword="true"/> if <paramref name="keyOrValue"/> represent a key, <see langword="false"/> otherwise</param>
        public KNetPredicateTester(byte[] keyOrValue, bool isKey)
            : base(keyOrValue, isKey)
        {
        }
        /// <summary>
        /// Initialize a new <see cref="KNetPredicateTester"/> for both key and value comparison
        /// </summary>
        /// <param name="key">The key to use in comparison</param>
        /// <param name="value">The value to use in comparison</param>
        /// <remarks>Both <paramref name="key"/> and <paramref name="value"/> shall be equal to input parameters of <see cref="Predicate{K, V}.Test(K, V)"/> to return <see langword="true"/></remarks>
        public KNetPredicateTester(byte[] key, byte[] value) : base(key, value)
        {
        }
    }
}
