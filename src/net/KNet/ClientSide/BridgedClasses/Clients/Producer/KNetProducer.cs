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

using MASES.KNet.Common.Serialization;
using Java.Util;
using Java.Lang;
using MASES.KNet.Common.Header;

namespace MASES.KNet.Clients.Producer
{
    /// <summary>
    /// Extends <see cref="IProducer{K, V}"/> adding less intrusive methods which performs better in high throughput applications
    /// </summary>
    /// <typeparam name="K">Same meaning of <see cref="IProducer{K, V}"/></typeparam>
    /// <typeparam name="V">Same meaning of <see cref="IProducer{K, V}"/></typeparam>
    public interface IKNetProducer<K, V> : IProducer<K, V>
    {
        void SetCallback(Callback callback);

        void Send(string topic, int partition, long timestamp, K key, V value, Iterable<Header> headers);

        void Send(string topic, int partition, long timestamp, K key, V value);

        void Send(string topic, int partition, K key, V value, Iterable<Header> headers);

        void Send(string topic, int partition, K key, V value);

        void Send(string topic, K key, V value);

        void Send(string topic, V value);
    }
    /// <summary>
    /// Extends <see cref="KafkaProducer{K, V}"/> adding less intrusive methods which performs better in high throughput applications
    /// </summary>
    /// <typeparam name="K">Same meaning of <see cref="KafkaProducer{K, V}"/></typeparam>
    /// <typeparam name="V">Same meaning of <see cref="KafkaProducer{K, V}"/></typeparam>
    public class KNetProducer<K, V> : KafkaProducer<K, V>, IKNetProducer<K, V>
    {
        public override string BridgeClassName => "org.mases.knet.clients.producer.KNetProducer";

        public KNetProducer()
        {
        }

        public KNetProducer(Properties props)
            : base(props)
        {
        }

        public KNetProducer(Properties props, Serializer<K> keySerializer, Serializer<V> valueSerializer)
            : base(props, keySerializer, valueSerializer)
        {
        }

        public void SetCallback(Callback callback) => IExecute("setCallback", callback);

        public void Send(string topic, int partition, long timestamp, K key, V value, Iterable<Header> headers) => IExecute("send", topic, partition, timestamp, key, value, headers);

        public void Send(string topic, int partition, long timestamp, K key, V value) => IExecute("send", topic, partition, timestamp, key, value);

        public void Send(string topic, int partition, K key, V value, Iterable<Header> headers) => IExecute("send", topic, partition, key, value, headers);

        public void Send(string topic, int partition, K key, V value) => IExecute("send", topic, partition, key, value);

        public void Send(string topic, K key, V value) => IExecute("send", topic, key, value);

        public void Send(string topic, V value) => IExecute("send", topic, value);
    }
}
