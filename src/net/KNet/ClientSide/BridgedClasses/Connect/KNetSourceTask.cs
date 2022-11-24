/*
*  Copyright 2022 MASES s.r.l.
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
using MASES.JNet.Extensions;
using MASES.KNet.Connect.Source;
using System.Collections.Generic;

namespace MASES.KNet.Connect
{
    /// <summary>
    /// An implementation of <see cref="KNetTask{TTask}"/> for source task
    /// </summary>
    /// <typeparam name="TTask">The class which extends <see cref="KNetSourceTask{TTask}"/></typeparam>
    public abstract class KNetSourceTask<TTask> : KNetTask<TTask>
        where TTask : KNetSourceTask<TTask>
    {
        /// <summary>
        /// Generates a <see cref="Map{string, K}"/> to be used in <see cref="SourceRecord"/>
        /// </summary>
        /// <typeparam name="T">The <paramref name="identifier"/> type</typeparam>
        /// <param name="identifier">The identifier to be associated in first, or second, parameter of a <see cref="SourceRecord"/></param>
        /// <param name="value">The value to be inserted and associated to the <paramref name="identifier"/></param>
        /// <returns>A <see cref="Map{string, K}"/></returns>
        protected Map<string, T> OffsetForKey<T>(string identifier, T value) => Collections.SingletonMap(identifier, value);
        /// <summary>
        /// Get the offset for the specified partition. If the data isn't already available locally, this gets it from the backing store, which may require some network round trips.
        /// </summary>
        /// <typeparam name="TType">The type of the key set when was called <see cref="OffsetForKey{K}(string, K)"/> to generated first parameter of <see cref="SourceRecord"/></typeparam>
        /// <typeparam name="TOffset">The type of the offset set when was called <see cref="OffsetForKey{K}(string, K)"/> to generated second parameter of <see cref="SourceRecord"/></typeparam>
        /// <param name="keyName">The identifier used when was called <see cref="OffsetForKey{K}(string, K)"/></param>
        /// <param name="keyValue">The value used when was called <see cref="OffsetForKey{K}(string, K)"/></param>
        /// <returns>Return the <see cref="Map{string, TOffset}"/> associated to the element identified from <paramref name="keyName"/> and <paramref name="keyValue"/> which is an object uniquely identifying the offset in the partition of data</returns>
        protected Map<string, TOffset> OffsetAt<TType, TOffset>(string keyName, TType keyValue) => ExecuteOnTask<Map<string, TOffset>>("offsetAt", keyName, keyValue);

        /// <summary>
        /// The <see cref="SourceTaskContext"/>
        /// </summary>
        public SourceTaskContext Context => Context<SourceTaskContext>();
        /// <summary>
        /// Set the <see cref="ReflectedTaskClassName"/> of the connector to a fixed value
        /// </summary>
        public override string ReflectedTaskClassName => "KNetSourceTask";
        /// <summary>
        /// Public method used from Java to trigger <see cref="Poll"/>
        /// </summary>
        public void PollInternal()
        {
            var result = Poll();
            DataToExchange(result.ToJCollection());
        }
        /// <summary>
        /// Implement the method to execute the Poll action
        /// </summary>
        /// <returns>The list of <see cref="SourceRecord"/> to return to Apache Kafka Connect framework</returns>
        public abstract IList<SourceRecord> Poll();
    }
}
