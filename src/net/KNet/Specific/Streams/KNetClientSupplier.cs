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

using Java.Util;
using MASES.KNet.Consumer;
using MASES.KNet.Producer;

namespace MASES.KNet.Streams
{
    /// <summary>
    /// KNet implementation of <see cref="Org.Apache.Kafka.Streams.KafkaClientSupplier"/>
    /// </summary>
    /// <remarks>The default <see cref="Org.Apache.Kafka.Streams.KafkaClientSupplier"/> used from <see cref="Org.Apache.Kafka.Streams.KafkaStreams"/> allocates both <see cref="Org.Apache.Kafka.Clients.Consumer.KafkaConsumer"/> and <see cref="Org.Apache.Kafka.Clients.Producer.KafkaProducer"/>. 
    /// <see cref="KNetClientSupplier"/> uses <see cref="KNetConsumer{K, V}"/> and <see cref="KNetProducer{K, V}"/>, the instance shall be disposed when no more in use, but still be alive still <see cref="Org.Apache.Kafka.Streams.KafkaStreams"/> is alive.</remarks>
    public class KNetClientSupplier : Org.Apache.Kafka.Streams.KafkaClientSupplier
    {
        private readonly System.Collections.Generic.List<Org.Apache.Kafka.Clients.Admin.Admin> _admins = new();
        private readonly System.Collections.Generic.List<Org.Apache.Kafka.Clients.Consumer.Consumer<byte[], byte[]>> _consumers = new();
        private readonly System.Collections.Generic.List<Org.Apache.Kafka.Clients.Producer.Producer<byte[], byte[]>> _producers = new();
        /// <summary>
        /// Default initializer
        /// </summary>
        public KNetClientSupplier()
        {
        }
        /// <inheritdoc/>
        public override Org.Apache.Kafka.Clients.Admin.Admin GetAdmin(Map<string, object> arg0)
        {
            var admin = Org.Apache.Kafka.Clients.Admin.Admin.Create(arg0);
            _admins.Add(admin);
            return admin;
        }
        /// <inheritdoc/>
        public override Org.Apache.Kafka.Clients.Consumer.Consumer<byte[], byte[]> GetConsumer(Map<string, object> arg0)
        {
            Properties properties = new();
            properties.PutAll(arg0);

            var consumer =  new KNetConsumer<byte[], byte[]>(properties);
            _consumers.Add(consumer);
            return consumer;
        }
        /// <inheritdoc/>
        public override Org.Apache.Kafka.Clients.Consumer.Consumer<byte[], byte[]> GetGlobalConsumer(Map<string, object> arg0)
        {
            Properties properties = new();
            properties.PutAll(arg0);

            var consumer = new KNetConsumer<byte[], byte[]>(properties);
            _consumers.Add(consumer);
            return consumer;
        }
        /// <inheritdoc/>
        public override Org.Apache.Kafka.Clients.Producer.Producer<byte[], byte[]> GetProducer(Map<string, object> arg0)
        {
            Properties properties = new();
            properties.PutAll(arg0);

            var producer = new KNetProducer<byte[], byte[]>(properties);
            _producers.Add(producer);
            return producer;
        }
        /// <inheritdoc/>
        public override Org.Apache.Kafka.Clients.Consumer.Consumer<byte[], byte[]> GetRestoreConsumer(Map<string, object> arg0)
        {
            Properties properties = new();
            properties.PutAll(arg0);

            var consumer = new KNetConsumer<byte[], byte[]>(properties);
            _consumers.Add(consumer);
            return consumer;
        }
        /// <inheritdoc/>
        public override void Dispose()
        {
            foreach (var item in _admins)
            {
                item?.Dispose();
            }
            _admins.Clear();

            foreach (var item in _consumers)
            {
                item?.Dispose();
            }
            _consumers.Clear();

            foreach (var item in _producers)
            {
                item?.Dispose();
            }
            _producers.Clear();

            base.Dispose();
        }
    }
}
