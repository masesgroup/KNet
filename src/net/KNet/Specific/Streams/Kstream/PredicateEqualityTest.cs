/*
*  Copyright 2024 MASES s.r.l.
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
using MASES.KNet.Serialization;

namespace MASES.KNet.Streams.Kstream
{
    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.Predicate{K, V}"/> to execute <see cref="Org.Apache.Kafka.Streams.Kstream.Predicate{K, V}.Test(K, V)"/> directly in the JVM
    /// </summary>
    public class PredicateEqualityTest<TKey, TValue> : Predicate<TKey, TValue>, IGenericSerDesFactoryApplier
    {
        TKey _key;
        TValue _value;
        bool? _isKeyCheck;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; updateRemote(); } }
        /// <inheritdoc/>
        public override bool AutoInit => false; // avoid to register callback listener
        /// <summary>
        /// <see href="https://www.jcobridge.com/api-clr/html/P_MASES_JCOBridge_C2JBridge_JVMBridgeBase_BridgeClassName.htm"/>
        /// </summary>
        public override string BridgeClassName => "org.mases.knet.developed.streams.kstream.KNetPredicateEqualityTest";

        void updateRemote()
        {
            if (_factory == null) return;
            var keySerDes = _factory?.BuildKeySerDes<TKey, byte[]>();
            var valueSerDes = _factory?.BuildValueSerDes<TValue, byte[]>();
            byte[] key = !_isKeyCheck.HasValue || _isKeyCheck.Value ? keySerDes.Serialize(null, _key): null;
            byte[] value = !_isKeyCheck.HasValue || !_isKeyCheck.Value ? valueSerDes.Serialize(null, _value) : null;

            IExecute("setWorkingState", key, value, _isKeyCheck.HasValue ? _isKeyCheck.Value : null);
        }

        /// <summary>
        /// Default constructor: even if the corresponding Java class does not have one, it is mandatory for JCOBridge
        /// </summary>
        public PredicateEqualityTest() { }
        /// <summary>
        /// Initialize a new <see cref="PredicateEqualityTest{TKey, TValue}"/> only for key comparison
        /// </summary>
        /// <param name="key">The key to use in comparison</param>
        public PredicateEqualityTest(TKey key)
        {
            _key = key;
            _isKeyCheck = true;
        }
        /// <summary>
        /// Initialize a new <see cref="PredicateEqualityTest{TKey, TValue}"/> only for value comparison
        /// </summary>
        /// <param name="value">The value to use in comparison</param>
        public PredicateEqualityTest(TValue value)
        {
            _value = value;
            _isKeyCheck = false;
        }
        /// <summary>
        /// Initialize a new <see cref="PredicateEqualityTest{TKey, TValue}"/> for both key and value comparison
        /// </summary>
        /// <param name="key">The key to use in comparison</param>
        /// <param name="value">The value to use in comparison</param>
        /// <param name="isKeyCheck">Set to <see langword="true"/> to check the <see cref="Key"/>, set to <see langword="false"/> to check the <see cref="Value"/> or leave undefined to check both <see cref="Key"/> and <see cref="Value"/></param>
        /// <remarks>Both <paramref name="key"/> and <paramref name="value"/> shall be equal to input parameters of <see cref="Org.Apache.Kafka.Streams.Kstream.Predicate{K, V}.Test(K, V)"/> to return <see langword="true"/></remarks>
        public PredicateEqualityTest(TKey key, TValue value, bool? isKeyCheck = null)
        {
            _key = key;
            _value = value;
            _isKeyCheck = isKeyCheck;
        }
        /// <summary>
        /// The <typeparamref name="TKey"/> to check
        /// </summary>
        public new TKey Key { get { return _key; } set { _key = value; updateRemote(); } }
        /// <summary>
        /// The <typeparamref name="TValue"/> to check
        /// </summary>
        public new TValue Value { get { return _value; } set { _value = value; updateRemote(); } }
        /// <summary>
        /// Set to <see langword="true"/> to check the <see cref="Key"/>, set to <see langword="false"/> to check the <see cref="Value"/> or leave undefined to check both <see cref="Key"/> and <see cref="Value"/>
        /// </summary>
        public bool? IsKeyCheck { get { return _isKeyCheck; } set { _isKeyCheck = value; updateRemote(); } }
    }
}
