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

using Org.Apache.Kafka.Connect.Sink;
using System;

namespace MASES.KNet.Connect
{
    /// <summary>
    /// An implementation of <see cref="KNetConnector{TSinkConnector}"/> for sink connectors
    /// </summary>
    /// <typeparam name="TSinkConnector">The connector class inherited from <see cref="KNetSinkConnector{TSinkConnector, TTask}"/></typeparam>
    /// <typeparam name="TTask">The task class inherited from <see cref="KNetSinkTask{TTask}"/></typeparam>
    public abstract class KNetSinkConnector<TSinkConnector, TTask> : KNetConnector<TSinkConnector>
        where TSinkConnector : KNetSinkConnector<TSinkConnector, TTask>
        where TTask : KNetSinkTask<TTask>
    {
        /// <summary>
        /// The <see cref="SinkConnectorContext"/>
        /// </summary>
        public SinkConnectorContext Context => Context<SinkConnectorContext>();
        /// <summary>
        /// Set the <see cref="IKNetConnector.ReflectedConnectorClassName"/> of the connector to a fixed value
        /// </summary>
        public sealed override string ReflectedConnectorClassName => "KNetSinkConnector";
        /// <summary>
        /// Set the <see cref="IKNetConnector.TaskClassType"/> of the connector to the value defined from <typeparamref name="TTask"/>
        /// </summary>
        public sealed override Type TaskClassType => typeof(TTask);
    }
}
