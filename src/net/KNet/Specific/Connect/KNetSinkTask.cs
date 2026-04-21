/*
*  Copyright (c) 2021-2026 MASES s.r.l.
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
using MASES.JCOBridge.C2JBridge;
using Org.Apache.Kafka.Connect.Sink;
using System.Collections.Generic;

namespace MASES.KNet.Connect
{
    #region IKNetSinkTask
    /// <summary>
    /// Helper interface for <see cref="KNetSinkTask{TTask}"/>
    /// </summary>
    public interface IKNetSinkTask : IKNetTask
    {

    }

    #endregion

    #region KNetSinkTask<TTask>

    /// <summary>
    /// An implementation of <see cref="KNetTask{TTask}"/> for sink task
    /// </summary>
    /// <typeparam name="TTask">The class which extends <see cref="KNetSinkTask{TTask}"/></typeparam>
    public abstract class KNetSinkTask<TTask> : KNetTask<TTask>, IKNetSinkTask
        where TTask : KNetSinkTask<TTask>
    {
        /// <summary>
        /// The <see cref="Put(IEnumerable{SinkRecord})"/> uses the <see cref="JCOBridgeExtensions.WithPrefetch{TEnumerable}(TEnumerable, bool)"/>
        /// </summary>
        protected virtual bool UsePrefetch { get; set; } = false;
        /// <summary>
        /// The <see cref="Put(IEnumerable{SinkRecord})"/> uses the <see cref="JCOBridgeExtensions.WithThread{TEnumerable}(TEnumerable, bool, System.Threading.ThreadPriority)"/>
        /// </summary>
        protected virtual bool UseThread { get; set; } = false;
        /// <summary>
        /// The <see cref="System.Threading.ThreadPriority"/> to be used when <see cref="UseThread"/> is <see langword="true"/>
        /// </summary>
        protected virtual System.Threading.ThreadPriority ThreadPriority { get; set; } = System.Threading.ThreadPriority.AboveNormal;
        /// <summary>
        /// The <see cref="SinkTaskContext"/>
        /// </summary>
        public SinkTaskContext Context => Context<SinkTaskContext>();
        /// <summary>
        /// Set the <see cref="ReflectedTaskClassName"/> of the connector to a fixed value
        /// </summary>
        protected override string ReflectedTaskClassName => "KNetSinkTask";
        /// <summary>
        /// Public method used from Java to trigger <see cref="Put(IEnumerable{SinkRecord})"/>
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void PutInternal()
        {
            try
            {
                using Collection<SinkRecord> collection = DataToExchange<Collection<SinkRecord>>();
                using var collection1 = collection.WithPrefetch(UsePrefetch).WithThread(UseThread, ThreadPriority);
                Put(collection1);
            }
            catch (System.Exception e)
            {
                LogError($"PutInternal failed with {e}");
                throw;
            }
        }
        /// <summary>
        /// Implement the method to execute the Put action
        /// </summary>
        /// <param name="collection">The set of <see cref="SinkRecord"/> from Apache Kafka Connect framework</param>
        public abstract void Put(IEnumerable<SinkRecord> collection);
    }

    #endregion
}
