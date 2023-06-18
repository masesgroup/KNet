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

using Org.Apache.Kafka.Clients.Consumer;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MASES.KNet.Extensions
{
    public static class KafkaConsumerExtensions
    {
        const int internalMs = 100;
        /// <summary>
        /// Consumes <see cref="ConsumerRecord"/> from an instance of <see cref="IConsumer{K, V}"/>
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        /// <param name="consumer">The consumer instance</param>
        /// <param name="token">The <see cref="CancellationToken"/> to use to abort waiting</param>
        /// <returns>The <see cref="ConsumerRecords{K, V}"/> received</returns>
        public static ConsumerRecords<K, V> Consume<K, V>(this IConsumer<K, V> consumer, CancellationToken token)
        {
            Java.Time.Duration duration = TimeSpan.FromMilliseconds(internalMs);
            token.ThrowIfCancellationRequested();
            while (true)
            {
                try
                {
                    var records = consumer.Poll(duration);
                    if (records.Count() == 0) continue;
                    return records;
                }
                catch (OperationCanceledException)
                {
                    return null;
                }
            }
        }
        /// <summary>
        /// Execute the consume in async mode
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        /// <param name="consumer">The consumer instance</param>
        /// <returns>The <see cref="ConsumerRecords{K, V}"/> received</returns>
        public static async Task<ConsumerRecords<K, V>> ConsumeAsync<K, V>(this IConsumer<K, V> consumer)
        {
            return await Task.Run(() =>
            {
                Java.Time.Duration duration = TimeSpan.FromMilliseconds(internalMs);
                while (true)
                {
                    var records = consumer.Poll(duration);
                    if (records.Count() == 0) continue;
                    return records;
                }
            });
        }
    }
}
