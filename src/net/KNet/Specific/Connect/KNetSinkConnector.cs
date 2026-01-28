/*
*  Copyright (c) 2021-2025 MASES s.r.l.
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

using Java.Lang;
using Java.Util;
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
        /// Set the <see cref="KNetConnector.ReflectedConnectorClassName"/> of the connector to a fixed value
        /// </summary>
        public sealed override string ReflectedConnectorClassName => "KNetSinkConnector";
        /// <summary>
        /// Set the <see cref="IKNetConnector.TaskClassType"/> of the connector to the value defined from <typeparamref name="TTask"/>
        /// </summary>
        public sealed override Type TaskClassType => typeof(TTask);
        /// <summary>
        /// Public method used from Java to trigger <see cref="AlterOffsets(Map{Java.Lang.String, Java.Lang.String}, Map{Org.Apache.Kafka.Common.TopicPartition, Long})"/>
        /// </summary>
        public bool AlterOffsetsInternal(Map<Java.Lang.String, Java.Lang.String> connectorConfig, Map<Org.Apache.Kafka.Common.TopicPartition, Long> offsets)
        {
            return AlterOffsets(connectorConfig, offsets);
        }
        /// <summary>
        /// Invoked when users request to manually alter/reset the offsets for this connector via the Connect worker's REST API. Connectors that manage offsets externally can propagate offset changes to their external system in this method. 
        /// Connectors may also validate these offsets to ensure that the source partitions and source offsets are in a format that is recognizable to them.
        /// Connectors that neither manage offsets externally nor require custom offset validation need not implement this method beyond simply returning <see langword="true"/>.
        /// </summary>
        /// <param name="connectorConfig">The configuration of the connector</param>
        /// <param name="offsets"> map from source partition to source offset, containing the offsets that the user has requested to alter/reset. 
        /// For any source partitions whose offsets are being reset instead of altered, their corresponding source offset value in the map will be null.
        /// This map may be empty, but never null. An empty offsets map could indicate that the offsets were reset previously or that no offsets have been committed yet.</param>
        /// <returns>whether this method has been overridden by the connector; the default implementation returns <see langword="false"/>, and all other implementations (that do not unconditionally throw exceptions) should return <see langword="true"/></returns>
        /// <remarks>User requests to alter/reset offsets will be handled by the Connect runtime and will be reflected in the offsets for this connector's consumer group.
        /// Note that altering/resetting offsets is expected to be an idempotent operation and this method should be able to handle being called more than once with the same arguments (which could occur if a user retries the request due to a failure in altering the consumer group offsets, for example).
        /// Similar to validate, this method may be called by the runtime before the <see cref="KNetConnector.Start(System.Collections.Generic.IReadOnlyDictionary{string, string})"/> method is invoked.</remarks>
        public virtual bool AlterOffsets(Map<Java.Lang.String, Java.Lang.String> connectorConfig, Map<Org.Apache.Kafka.Common.TopicPartition, Long> offsets)
        {
            return false;
        }
    }
}
