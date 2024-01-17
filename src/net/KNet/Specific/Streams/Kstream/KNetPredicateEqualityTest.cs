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
using MASES.KNet.Serialization;

namespace MASES.KNet.Streams.Kstream
{
    /// <summary>
    /// KNet extension of <see cref="Org.Apache.Kafka.Streams.Kstream.Predicate{K, V}"/> to execute <see cref="Org.Apache.Kafka.Streams.Kstream.Predicate{K, V}.Test(K, V)"/> directly in the JVM
    /// </summary>
    public class KNetPredicateEqualityTest<TKey, TValue> : JVMBridgeBase<KNetPredicateEqualityTest<TKey, TValue>>, IGenericSerDesFactoryApplier
    {
        TKey _key;
        TValue _value;
        bool? _isKeyCheck;
        IGenericSerDesFactory _factory;
        IGenericSerDesFactory IGenericSerDesFactoryApplier.Factory { get => _factory; set { _factory = value; } }

        /// <summary>
        /// <see href="https://www.jcobridge.com/api-clr/html/P_MASES_JCOBridge_C2JBridge_JVMBridgeBase_BridgeClassName.htm"/>
        /// </summary>
        public override string BridgeClassName => "org.mases.knet.streams.kstream.KNetPredicateEqualityTest";
        /// <summary>
        /// Converter from <see cref="KNetPredicateEqualityTest{TKey, TValue}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.Predicate{K, V}"/>
        /// </summary>
        /// <remarks>This cast is useful when an API needs in input a type like <see cref="Org.Apache.Kafka.Streams.Kstream.Predicate{K, V}"/>, however the behavior of the <see cref="Org.Apache.Kafka.Streams.Kstream.Predicate{K, V}"/> in output is different from the same class allocated directly</remarks>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.Predicate<byte[], byte[]>(KNetPredicateEqualityTest<TKey, TValue> t)
        {
            if (t._factory == null) throw new System.InvalidOperationException("The operator shall be invoked within a function which set the IGenericSerDesFactory instance.");
            t.updateRemote();
            return t.Cast<Org.Apache.Kafka.Streams.Kstream.Predicate<byte[], byte[]>>();
        }

        void updateRemote()
        {
            if (_factory == null) return;
            var keySerDes = _factory.BuildKeySerDes<TKey>();
            var valueSerDes = _factory.BuildValueSerDes<TValue>();
            byte[] key = !_isKeyCheck.HasValue || _isKeyCheck.Value ? keySerDes.Serialize(null, _key): null;
            byte[] value = !_isKeyCheck.HasValue || !_isKeyCheck.Value ? valueSerDes.Serialize(null, _value) : null;

            IExecute("setWorkingState", key, value, _isKeyCheck.HasValue ? _isKeyCheck.Value : null);
        }

        /// <summary>
        /// Default constructor: even if the corresponding Java class does not have one, it is mandatory for JCOBridge
        /// </summary>
        public KNetPredicateEqualityTest() { }
        /// <summary>
        /// Initialize a new <see cref="KNetPredicateEqualityTest{TKey, TValue}"/> only for key comparison
        /// </summary>
        /// <param name="key">The key to use in comparison</param>
        public KNetPredicateEqualityTest(TKey key)
        {
            _key = key;
            _isKeyCheck = true;
        }
        /// <summary>
        /// Initialize a new <see cref="KNetPredicateEqualityTest{TKey, TValue}"/> only for value comparison
        /// </summary>
        /// <param name="value">The value to use in comparison</param>
        public KNetPredicateEqualityTest(TValue value)
        {
            _value = value;
            _isKeyCheck = false;
        }
        /// <summary>
        /// Initialize a new <see cref="KNetPredicateEqualityTest{TKey, TValue}"/> for both key and value comparison
        /// </summary>
        /// <param name="key">The key to use in comparison</param>
        /// <param name="value">The value to use in comparison</param>
        /// <param name="isKeyCheck">Set to <see langword="true"/> to check the <see cref="Key"/>, set to <see langword="false"/> to check the <see cref="Value"/> or leave undefined to check both <see cref="Key"/> and <see cref="Value"/></param>
        /// <remarks>Both <paramref name="key"/> and <paramref name="value"/> shall be equal to input parameters of <see cref="Org.Apache.Kafka.Streams.Kstream.Predicate{K, V}.Test(K, V)"/> to return <see langword="true"/></remarks>
        public KNetPredicateEqualityTest(TKey key, TValue value, bool? isKeyCheck = null)
        {
            _key = key;
            _value = value;
            _isKeyCheck = isKeyCheck;
        }
        /// <summary>
        /// The <typeparamref name="TKey"/> to check
        /// </summary>
        public TKey Key { get { return _key; } set { _key = value; updateRemote(); } }
        /// <summary>
        /// The <typeparamref name="TValue"/> to check
        /// </summary>
        public TValue Value { get { return _value; } set { _value = value; updateRemote(); } }
        /// <summary>
        /// Set to <see langword="true"/> to check the <see cref="Key"/>, set to <see langword="false"/> to check the <see cref="Value"/> or leave undefined to check both <see cref="Key"/> and <see cref="Value"/>
        /// </summary>
        public bool? IsKeyCheck { get { return _isKeyCheck; } set { _isKeyCheck = value; updateRemote(); } }
    }
}
