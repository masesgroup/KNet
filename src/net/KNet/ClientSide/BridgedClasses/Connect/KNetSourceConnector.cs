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

using MASES.KNet.Connect.Source;
using System;

namespace MASES.KNet.Connect
{
    /// <summary>
    /// An implementation of <see cref="KNetConnector{TSourceConnector}"/> for source connectors
    /// </summary>
    /// <typeparam name="TSourceConnector">The connector class inherited from <see cref="KNetSinkConnector{TSourceConnector, TTask}"/></typeparam>
    /// <typeparam name="TTask">The task class inherited from <see cref="KNetSourceTask{TTask}"/></typeparam>
    public abstract class KNetSourceConnector<TSourceConnector, TTask> : KNetConnector<TSourceConnector>
        where TSourceConnector : KNetSourceConnector<TSourceConnector, TTask>
        where TTask : KNetSourceTask<TTask>
    {
        /// <summary>
        /// The <see cref="SourceConnectorContext"/>
        /// </summary>
        public SourceConnectorContext Context => Context<SourceConnectorContext>();
        /// <summary>
        /// Set the <see cref="ReflectedConnectorClassName"/> of the connector to a fixed value
        /// </summary>
        public sealed override string ReflectedConnectorClassName => "KNetSourceConnector";
        /// <summary>
        /// Set the <see cref="TaskClassType"/> of the connector to the value defined from <typeparamref name="TTask"/>
        /// </summary>
        public sealed override Type TaskClassType => typeof(TTask);
    }
}
