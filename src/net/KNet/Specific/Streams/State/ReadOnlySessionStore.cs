/*
*  Copyright (c) 2021-2025 MASES s.r.l.
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

using MASES.KNet.Serialization;

namespace MASES.KNet.Streams.State
{
    /// <summary>
    /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.State.ReadOnlySessionStore{TJVMK, TJVMAGG}"/> 
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="AGG">The value type</typeparam>
    /// <typeparam name="TJVMK">The JVM type of <typeparamref name="K"/></typeparam>
    /// <typeparam name="TJVMAGG">The JVM type of <typeparamref name="AGG"/></typeparam>
    public class ReadOnlySessionStore<K, AGG, TJVMK, TJVMAGG> : ManagedStore<Org.Apache.Kafka.Streams.State.ReadOnlySessionStore<TJVMK, TJVMAGG>>
    {
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.1/org/apache/kafka/streams/state/ReadOnlySessionStore.html#fetch(java.lang.Object,java.lang.Object)"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="K"/></param>
        /// <param name="arg1"><typeparamref name="K"/></param>
        /// <returns><see cref="WindowedKeyValueIterator{K, V, TJVMK, TJVMV}"/></returns>
        public virtual WindowedKeyValueIterator<K, AGG, TJVMK, TJVMAGG> Fetch(K arg0, K arg1)
        {
            IGenericSerDesFactory factory = Factory;
            var _keySerDes = factory?.BuildKeySerDes<K, TJVMK>();

            var r0 = _keySerDes.Serialize(null, arg0);
            var r1 = _keySerDes.Serialize(null, arg1);
            return new WindowedKeyValueIterator<K, AGG, TJVMK, TJVMAGG>(factory, Store.Fetch(r0, r1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.1/org/apache/kafka/streams/state/ReadOnlySessionStore.html#fetch(java.lang.Object)"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="K"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.State.KeyValueIterator"/></returns>
        public virtual WindowedKeyValueIterator<K, AGG, TJVMK, TJVMAGG> Fetch(K arg0)
        {
            IGenericSerDesFactory factory = Factory;
            var _keySerDes = factory?.BuildKeySerDes<K, TJVMK>();

            var r0 = _keySerDes.Serialize(null, arg0);
            return new WindowedKeyValueIterator<K, AGG, TJVMK, TJVMAGG>(factory, Store.Fetch(r0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.1/org/apache/kafka/streams/state/ReadOnlySessionStore.html#fetchSession(java.lang.Object,java.time.Instant,java.time.Instant)"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="K"/></param>
        /// <param name="arg1"><see cref="Java.Time.Instant"/></param>
        /// <param name="arg2"><see cref="Java.Time.Instant"/></param>
        /// <returns><typeparamref name="AGG"/></returns>
        public virtual AGG FetchSession(K arg0, Java.Time.Instant arg1, Java.Time.Instant arg2)
        {
            IGenericSerDesFactory factory = Factory;
            var _keySerDes = factory?.BuildKeySerDes<K, TJVMK>();
            var _valueSerDes = factory?.BuildValueSerDes<AGG, TJVMAGG>();

            var r0 = _keySerDes.Serialize(null, arg0);
            var agg = Store.FetchSession(r0, arg1, arg2);
            return _valueSerDes.Deserialize(null, agg);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.1/org/apache/kafka/streams/state/ReadOnlySessionStore.html#fetchSession(java.lang.Object,long,long)"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="K"/></param>
        /// <param name="arg1"><see cref="long"/></param>
        /// <param name="arg2"><see cref="long"/></param>
        /// <returns><typeparamref name="AGG"/></returns>
        public virtual AGG FetchSession(K arg0, long arg1, long arg2)
        {
            IGenericSerDesFactory factory = Factory;
            var _keySerDes = factory?.BuildKeySerDes<K, TJVMK>();
            var _valueSerDes = factory?.BuildValueSerDes<AGG, TJVMAGG>();

            var r0 = _keySerDes.Serialize(null, arg0);
            var agg = Store.FetchSession(r0, arg1, arg2);
            return _valueSerDes.Deserialize(null, agg);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.1/org/apache/kafka/streams/state/ReadOnlySessionStore.html#backwardFetch(java.lang.Object,java.lang.Object)"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="K"/></param>
        /// <param name="arg1"><typeparamref name="K"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.State.KeyValueIterator"/></returns>
        public virtual WindowedKeyValueIterator<K, AGG, TJVMK, TJVMAGG> BackwardFetch(K arg0, K arg1)
        {
            IGenericSerDesFactory factory = Factory;
            var _keySerDes = factory?.BuildKeySerDes<K, TJVMK>();

            var r0 = _keySerDes.Serialize(null, arg0);
            var r1 = _keySerDes.Serialize(null, arg1);
            return new WindowedKeyValueIterator<K, AGG, TJVMK, TJVMAGG>(factory, Store.BackwardFetch(r0, r1));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.1/org/apache/kafka/streams/state/ReadOnlySessionStore.html#backwardFetch(java.lang.Object)"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="K"/></param>
        /// <returns><see cref="WindowedKeyValueIterator{K, V, TJVMK, TJVMV}"/></returns>
        public virtual WindowedKeyValueIterator<K, AGG, TJVMK, TJVMAGG> BackwardFetch(K arg0)
        {
            IGenericSerDesFactory factory = Factory;
            var _keySerDes = factory?.BuildKeySerDes<K, TJVMK>();

            var r0 = _keySerDes.Serialize(null, arg0);
            return new WindowedKeyValueIterator<K, AGG, TJVMK, TJVMAGG>(factory, Store.BackwardFetch(r0));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.1/org/apache/kafka/streams/state/ReadOnlySessionStore.html#backwardFindSessions(java.lang.Object,java.time.Instant,java.time.Instant)"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="K"/></param>
        /// <param name="arg1"><see cref="Java.Time.Instant"/></param>
        /// <param name="arg2"><see cref="Java.Time.Instant"/></param>
        /// <returns><see cref="WindowedKeyValueIterator{K, V, TJVMK, TJVMV}"/></returns>
        public virtual WindowedKeyValueIterator<K, AGG, TJVMK, TJVMAGG> BackwardFindSessions(K arg0, Java.Time.Instant arg1, Java.Time.Instant arg2)
        {
            IGenericSerDesFactory factory = Factory;
            var _keySerDes = factory?.BuildKeySerDes<K, TJVMK>();

            var r0 = _keySerDes.Serialize(null, arg0);
            return new WindowedKeyValueIterator<K, AGG, TJVMK, TJVMAGG>(factory, Store.BackwardFindSessions(r0, arg1, arg2));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.1/org/apache/kafka/streams/state/ReadOnlySessionStore.html#backwardFindSessions(java.lang.Object,java.lang.Object,java.time.Instant,java.time.Instant)"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="K"/></param>
        /// <param name="arg1"><typeparamref name="K"/></param>
        /// <param name="arg2"><see cref="Java.Time.Instant"/></param>
        /// <param name="arg3"><see cref="Java.Time.Instant"/></param>
        /// <returns><see cref="WindowedKeyValueIterator{K, V, TJVMK, TJVMV}"/></returns>
        public virtual WindowedKeyValueIterator<K, AGG, TJVMK, TJVMAGG> BackwardFindSessions(K arg0, K arg1, Java.Time.Instant arg2, Java.Time.Instant arg3)
        {
            IGenericSerDesFactory factory = Factory;
            var _keySerDes = factory?.BuildKeySerDes<K, TJVMK>();

            var r0 = _keySerDes.Serialize(null, arg0);
            var r1 = _keySerDes.Serialize(null, arg1);
            return new WindowedKeyValueIterator<K, AGG, TJVMK, TJVMAGG>(factory, Store.BackwardFindSessions(r0, r1, arg2, arg3));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.1/org/apache/kafka/streams/state/ReadOnlySessionStore.html#backwardFindSessions(java.lang.Object,java.lang.Object,long,long)"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="K"/></param>
        /// <param name="arg1"><typeparamref name="K"/></param>
        /// <param name="arg2"><see cref="long"/></param>
        /// <param name="arg3"><see cref="long"/></param>
        /// <returns><see cref="WindowedKeyValueIterator{K, V, TJVMK, TJVMV}"/></returns>
        public virtual WindowedKeyValueIterator<K, AGG, TJVMK, TJVMAGG> BackwardFindSessions(K arg0, K arg1, long arg2, long arg3)
        {
            IGenericSerDesFactory factory = Factory;
            var _keySerDes = factory?.BuildKeySerDes<K, TJVMK>();

            var r0 = _keySerDes.Serialize(null, arg0);
            var r1 = _keySerDes.Serialize(null, arg1);
            return new WindowedKeyValueIterator<K, AGG, TJVMK, TJVMAGG>(factory, Store.BackwardFindSessions(r0, r1, arg2, arg3));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.1/org/apache/kafka/streams/state/ReadOnlySessionStore.html#backwardFindSessions(java.lang.Object,long,long)"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="K"/></param>
        /// <param name="arg1"><see cref="long"/></param>
        /// <param name="arg2"><see cref="long"/></param>
        /// <returns><see cref="WindowedKeyValueIterator{K, V, TJVMK, TJVMV}"/></returns>
        public virtual WindowedKeyValueIterator<K, AGG, TJVMK, TJVMAGG> BackwardFindSessions(K arg0, long arg1, long arg2)
        {
            IGenericSerDesFactory factory = Factory;
            var _keySerDes = factory?.BuildKeySerDes<K, TJVMK>();

            var r0 = _keySerDes.Serialize(null, arg0);
            return new WindowedKeyValueIterator<K, AGG, TJVMK, TJVMAGG>(factory, Store.BackwardFindSessions(r0, arg1, arg2));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.1/org/apache/kafka/streams/state/ReadOnlySessionStore.html#findSessions(java.lang.Object,java.time.Instant,java.time.Instant)"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="K"/></param>
        /// <param name="arg1"><see cref="Java.Time.Instant"/></param>
        /// <param name="arg2"><see cref="Java.Time.Instant"/></param>
        /// <returns><see cref="WindowedKeyValueIterator{K, V, TJVMK, TJVMV}"/></returns>
        public virtual WindowedKeyValueIterator<K, AGG, TJVMK, TJVMAGG> FindSessions(K arg0, Java.Time.Instant arg1, Java.Time.Instant arg2)
        {
            IGenericSerDesFactory factory = Factory;
            var _keySerDes = factory?.BuildKeySerDes<K, TJVMK>();

            var r0 = _keySerDes.Serialize(null, arg0);
            return new WindowedKeyValueIterator<K, AGG, TJVMK, TJVMAGG>(factory, Store.BackwardFindSessions(r0, arg1, arg2));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.1/org/apache/kafka/streams/state/ReadOnlySessionStore.html#findSessions(java.lang.Object,java.lang.Object,java.time.Instant,java.time.Instant)"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="K"/></param>
        /// <param name="arg1"><typeparamref name="K"/></param>
        /// <param name="arg2"><see cref="Java.Time.Instant"/></param>
        /// <param name="arg3"><see cref="Java.Time.Instant"/></param>
        /// <returns><see cref="WindowedKeyValueIterator{K, V, TJVMK, TJVMV}"/></returns>
        public virtual WindowedKeyValueIterator<K, AGG, TJVMK, TJVMAGG> FindSessions(K arg0, K arg1, Java.Time.Instant arg2, Java.Time.Instant arg3)
        {
            IGenericSerDesFactory factory = Factory;
            var _keySerDes = factory?.BuildKeySerDes<K, TJVMK>();

            var r0 = _keySerDes.Serialize(null, arg0);
            var r1 = _keySerDes.Serialize(null, arg1);
            return new WindowedKeyValueIterator<K, AGG, TJVMK, TJVMAGG>(factory, Store.FindSessions(r0, r1, arg2, arg3));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.1/org/apache/kafka/streams/state/ReadOnlySessionStore.html#findSessions(java.lang.Object,java.lang.Object,long,long)"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="K"/></param>
        /// <param name="arg1"><typeparamref name="K"/></param>
        /// <param name="arg2"><see cref="long"/></param>
        /// <param name="arg3"><see cref="long"/></param>
        /// <returns><see cref="WindowedKeyValueIterator{K, V, TJVMK, TJVMV}"/></returns>
        public virtual WindowedKeyValueIterator<K, AGG, TJVMK, TJVMAGG> FindSessions(K arg0, K arg1, long arg2, long arg3)
        {
            IGenericSerDesFactory factory = Factory;
            var _keySerDes = factory?.BuildKeySerDes<K, TJVMK>();

            var r0 = _keySerDes.Serialize(null, arg0);
            var r1 = _keySerDes.Serialize(null, arg1);
            return new WindowedKeyValueIterator<K, AGG, TJVMK, TJVMAGG>(factory, Store.FindSessions(r0, r1, arg2, arg3));
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.9.1/org/apache/kafka/streams/state/ReadOnlySessionStore.html#findSessions(java.lang.Object,long,long)"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="K"/></param>
        /// <param name="arg1"><see cref="long"/></param>
        /// <param name="arg2"><see cref="long"/></param>
        /// <returns><see cref="WindowedKeyValueIterator{K, V, TJVMK, TJVMV}"/></returns>
        public virtual WindowedKeyValueIterator<K, AGG, TJVMK, TJVMAGG> FindSessions(K arg0, long arg1, long arg2)
        {
            IGenericSerDesFactory factory = Factory;
            var _keySerDes = factory?.BuildKeySerDes<K, TJVMK>();

            var r0 = _keySerDes.Serialize(null, arg0);
            return new WindowedKeyValueIterator<K, AGG, TJVMK, TJVMAGG>(factory, Store.FindSessions(r0, arg1, arg2));
        }
    }

    /// <summary>
    /// KNet implementation of <see cref="ReadOnlySessionStore{K, AGG, TJVMK, TJVMAGG}"/> 
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="AGG">The value type</typeparam>
    public class ReadOnlySessionStore<K, AGG> : ReadOnlySessionStore<K, AGG, byte[], byte[]>
    {

    }
}
