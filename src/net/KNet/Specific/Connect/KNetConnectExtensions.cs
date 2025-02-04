/*
*  Copyright 2025 MASES s.r.l.
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
using Org.Apache.Kafka.Connect.Sink;
using Org.Apache.Kafka.Connect.Source;
using System.Collections.Generic;
using System.Linq;

namespace MASES.KNet.Connect
{
    /// <summary>
    /// Some extension method helping to convert types
    /// </summary>
    public static class KNetConnectExtensions
    {
        /// <summary>
        /// Converts an <see cref="SourceRecord{TKey, TValue}"/> in <see cref="SourceRecord"/>
        /// </summary>
        /// <param name="source">The <see cref="SourceRecord{TKey, TValue}"/> to convert</param>
        public static SourceRecord From<TKey, TValue>(this SourceRecord<TKey, TValue> source)
        {
            return source.Cast<SourceRecord>();
        }
        /// <summary>
        /// Converts an <see cref="SourceRecord{TKeySource, TOffset, TKey, TValue}"/> in <see cref="SourceRecord"/>
        /// </summary>
        /// <param name="source">The <see cref="SourceRecord{TKeySource, TOffset, TKey, TValue}"/> to convert</param>
        public static SourceRecord From<TKeySource, TOffset, TKey, TValue>(this SourceRecord<TKeySource, TOffset, TKey, TValue> source)
        {
            return source.Cast<SourceRecord>();
        }
        /// <summary>
        /// Converts an <see cref="IEnumerable{T}"/> of <see cref="SourceRecord{TKey, TValue}"/> in <see cref="List{SourceRecord}"/>
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> of <see cref="SourceRecord{TKey, TValue}"/> to convert</param>
        public static List<SourceRecord> Convert<TKey, TValue>(this IEnumerable<SourceRecord<TKey, TValue>> source)
        {
            return source.Select((o) => o.From()).ToList();
        }

        /// <summary>
        /// Converts an <see cref="IEnumerable{T}"/> of <see cref="SourceRecord{TKeySource, TOffset,TKey, TValue}"/> in <see cref="List{SourceRecord}"/>
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> of <see cref="SourceRecord{TKeySource, TOffset,TKey, TValue}"/> to convert</param>
        public static List<SourceRecord> Convert<TKeySource, TOffset, TKey, TValue>(this IEnumerable<SourceRecord<TKeySource, TOffset, TKey, TValue>> source)
        {
            return source.Select((o) => o.From()).ToList();
        }
        /// <summary>
        /// Converts an <see cref="IEnumerable{SinkRecord}"/> in <see cref="IEnumerable{T}"/> of <see cref="SinkRecord{Object, TValue}"/>
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{SinkRecord}"/> to convert</param>
        public static IEnumerable<SinkRecord<object, TValue>> CastTo<TValue>(this IEnumerable<SinkRecord> source)
        {
            return source.Select((o) => o.CastTo<SinkRecord<object, TValue>>());
        }
        /// <summary>
        /// Converts an <see cref="IEnumerable{SinkRecord}"/> in <see cref="IEnumerable{T}"/> of <see cref="SinkRecord{TKey, TValue}"/>
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{SinkRecord}"/> to convert</param>
        public static IEnumerable<SinkRecord<TKey, TValue>> CastTo<TKey, TValue>(this IEnumerable<SinkRecord> source)
        {
            return source.Select((o) => o.CastTo<SinkRecord<TKey, TValue>>());
        }
    }
}
