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
using MASES.KNet.Serialization;
using Org.Apache.Kafka.Clients.Admin;
using Org.Apache.Kafka.Clients.Consumer;
using Org.Apache.Kafka.Clients.Producer;
using Org.Apache.Kafka.Streams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASES.KNet.Specific.Streams
{
    /// <summary>
    /// KNet implementation of <see cref="KafkaClientSupplier"/>
    /// </summary>
    public class KNetClientSupplier : KafkaClientSupplier
    {
        private readonly System.Collections.Generic.List<Org.Apache.Kafka.Clients.Admin.Admin> _admins = new System.Collections.Generic.List<Org.Apache.Kafka.Clients.Admin.Admin>();
        private readonly System.Collections.Generic.List<KNetConsumer<byte[], byte[]>> _consumers = new System.Collections.Generic.List<KNetConsumer<byte[], byte[]>>();
        private readonly System.Collections.Generic.List<KNetProducer<byte[], byte[]>> _producers = new System.Collections.Generic.List<KNetProducer<byte[], byte[]>>();
        /// <summary>
        /// Default initializer
        /// </summary>
        public KNetClientSupplier()
        {
        }
        /// <inheritdoc/>
        public override Org.Apache.Kafka.Clients.Admin.Admin GetAdmin(Map<string, object> arg0)
        {
            var admin = AdminClient.Create(arg0);
            _admins.Add(admin);
            return admin;
        }
        /// <inheritdoc/>
        public override Consumer<byte[], byte[]> GetConsumer(Map<string, object> arg0)
        {
            Properties properties = new();
            properties.PutAll(arg0);

            var consumer =  new KNetConsumer<byte[], byte[]>(properties);
            _consumers.Add(consumer);
            return consumer;
        }
        /// <inheritdoc/>
        public override Consumer<byte[], byte[]> GetGlobalConsumer(Map<string, object> arg0)
        {
            Properties properties = new();
            properties.PutAll(arg0);

            var consumer = new KNetConsumer<byte[], byte[]>(properties);
            _consumers.Add(consumer);
            return consumer;
        }
        /// <inheritdoc/>
        public override Producer<byte[], byte[]> GetProducer(Map<string, object> arg0)
        {
            Properties properties = new();
            properties.PutAll(arg0);

            var producer = new KNetProducer<byte[], byte[]>(properties);
            _producers.Add(producer);
            return producer;
        }
        /// <inheritdoc/>
        public override Consumer<byte[], byte[]> GetRestoreConsumer(Map<string, object> arg0)
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
