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
using MASES.JNet.Extensions;
using Org.Apache.Kafka.Connect.Sink;
using System.Collections.Generic;

namespace MASES.KNet.Connect
{
    /// <summary>
    /// An implementation of <see cref="KNetTask{TTask}"/> for sink task
    /// </summary>
    /// <typeparam name="TTask">The class which extends <see cref="KNetSinkTask{TTask}"/></typeparam>
    public abstract class KNetSinkTask<TTask> : KNetTask<TTask>
        where TTask : KNetSinkTask<TTask>
    {
        /// <summary>
        /// The <see cref="SinkTaskContext"/>
        /// </summary>
        public SinkTaskContext Context => Context<SinkTaskContext>();
        /// <summary>
        /// Set the <see cref="ReflectedTaskClassName"/> of the connector to a fixed value
        /// </summary>
        public override string ReflectedTaskClassName => "KNetSinkTask";
        /// <summary>
        /// Public method used from Java to trigger <see cref="Put(Collection{SinkRecord})"/>
        /// </summary>
        public void PutInternal()
        {
            Collection<SinkRecord> collection = DataToExchange<Collection<SinkRecord>>();
            var list = collection.ToList();
            Put(list);
        }
        /// <summary>
        /// Implement the method to execute the Put action
        /// </summary>
        /// <param name="collection">The set of <see cref="SinkRecord"/> from Apache Kafka Connect framework</param>
        public abstract void Put(IEnumerable<SinkRecord> collection);
    }
}
