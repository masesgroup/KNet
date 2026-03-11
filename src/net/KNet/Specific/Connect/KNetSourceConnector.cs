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

using Java.Lang;
using Java.Util;
using Org.Apache.Kafka.Connect.Sink;
using Org.Apache.Kafka.Connect.Source;
using System;

namespace MASES.KNet.Connect
{
    #region IKNetSourceConnector
    /// <summary>
    /// Helper interface for <see cref="KNetSourceConnector{TSinkConnector, TTask}"/>
    /// </summary>
    public interface IKNetSourceConnector : IKNetConnector
    {
        /// <summary>
        /// The <see cref="SourceConnectorContext"/>
        /// </summary>
        SourceConnectorContext Context { get; }
        /// <summary>
        /// Implement the method to return the <see cref="ExactlyOnceSupport"/> value
        /// </summary>
        ExactlyOnceSupport ExactlyOnceSupport { get; }
        /// <summary>
        /// Implement the method to return the <see cref="ConnectorTransactionBoundaries"/> value
        /// </summary>
        ConnectorTransactionBoundaries CanDefineTransactionBoundaries { get; }
    }
    #endregion

    #region KNetSourceConnector<TSourceConnector, TTask>

    /// <summary>
    /// An implementation of <see cref="KNetConnector{TSourceConnector}"/> for source connectors
    /// </summary>
    /// <typeparam name="TSourceConnector">The connector class inherited from <see cref="KNetSourceConnector{TSourceConnector, TTask}"/></typeparam>
    /// <typeparam name="TTask">The task class inherited from <see cref="KNetSourceTask{TTask}"/></typeparam>
    public abstract class KNetSourceConnector<TSourceConnector, TTask> : KNetConnector<TSourceConnector>, IKNetSourceConnector
        where TSourceConnector : KNetSourceConnector<TSourceConnector, TTask>
        where TTask : KNetSourceTask<TTask>
    {
        /// <summary>
        /// The <see cref="SourceConnectorContext"/>
        /// </summary>
        public SourceConnectorContext Context => Context<SourceConnectorContext>();

        /// <summary>
        /// Public method used from Java to trigger <see cref="ExactlyOnceSupport"/>
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public ExactlyOnceSupport ExactlyOnceSupportInternal()
        {
            return ExactlyOnceSupport;
        }
        /// <inheritdoc/>
        public virtual ExactlyOnceSupport ExactlyOnceSupport => ExactlyOnceSupport.UNSUPPORTED;

        /// <summary>
        /// Public method used from Java to trigger <see cref="CanDefineTransactionBoundaries"/>
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public ConnectorTransactionBoundaries CanDefineTransactionBoundariesInternal()
        {
            return CanDefineTransactionBoundaries;
        }
        /// <inheritdoc/>
        public virtual ConnectorTransactionBoundaries CanDefineTransactionBoundaries => ConnectorTransactionBoundaries.UNSUPPORTED;

        /// <summary>
        /// Set the <see cref="ReflectedRemoteObjectClassName"/> of the connector to a fixed value
        /// </summary>
        protected sealed override string ReflectedRemoteObjectClassName => "KNetSourceConnector";
        /// <summary>
        /// Set the <see cref="TaskClassType"/> of the connector to the value defined from <typeparamref name="TTask"/>
        /// </summary>
        public sealed override Type TaskClassType => typeof(TTask);
        /// <summary>
        /// Public method used from Java to trigger <see cref="AlterOffsets(Map{Java.Lang.String, Java.Lang.String}, Map{Map{Java.Lang.String, object}, Map{Java.Lang.String, object}})"/>
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool AlterOffsetsInternal(Map<Java.Lang.String, Java.Lang.String> connectorConfig, Map<Map<Java.Lang.String, object>, Map<Java.Lang.String, object>> offsets)
        {
            return AlterOffsets(connectorConfig, offsets);
        }
        /// <summary>
        /// Invoked when users request to manually alter/reset the offsets for this connector via the Connect worker's REST API. Connectors that manage offsets externally can propagate offset changes to their external system in this method. 
        /// Connectors may also validate these offsets to ensure that the source partitions and source offsets are in a format that is recognizable to them. 
        /// Connectors that neither manage offsets externally nor require custom offset validation need not implement this method beyond simply returning <see langword="true"/>.
        /// </summary>
        /// <param name="connectorConfig">The configuration of the connector</param>
        /// <param name="offsets">A <see cref="Map{K, V}"/>> from source partition to source offset, containing the offsets that the user has requested to alter/reset. 
        /// For any source partitions whose offsets are being reset instead of altered, their corresponding source offset value in the map will be null. 
        /// This map may be empty, but never <see langword="null"/>>.
        /// An empty offsets <see cref="Map{K, V}"/>> could indicate that the offsets were reset previously or that no offsets have been committed yet.</param>
        /// <returns>whether this method has been overridden by the connector; the default implementation returns <see langword="false"/>, and all other implementations (that do not unconditionally throw exceptions) should return <see langword="true"/></returns>
        /// <remarks>User requests to alter/reset offsets will be handled by the Connect runtime and will be reflected in the offsets returned by any OffsetStorageReader instances provided to this connector and its tasks.
        /// Note that altering/resetting offsets is expected to be an idempotent operation and this method should be able to handle being called more than once with the same arguments (which could occur if a user retries the request due to a failure in writing the new offsets to the offsets store, for example).
        /// Similar to validate, this method may be called by the runtime before the <see cref="KNetConnector.Start(IKNetCommonConfiguration)"/>> method is invoked.</remarks>
        public virtual bool AlterOffsets(Map<Java.Lang.String, Java.Lang.String> connectorConfig, Map<Map<Java.Lang.String, object>, Map<Java.Lang.String, object>> offsets)
        {
            return false;
        }
    }
    #endregion
}
