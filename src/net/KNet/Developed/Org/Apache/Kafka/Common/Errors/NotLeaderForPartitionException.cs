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

namespace Org.Apache.Kafka.Common.Errors
{
    /// <summary>
    /// Obsolote exception
    /// </summary>
    [System.Obsolete]
    public class NotLeaderForPartitionException : InvalidMetadataException
    {
        /// <inheritdoc cref="global::System.Exception()"/>
        public NotLeaderForPartitionException() { }
        /// <inheritdoc cref="global::System.Exception(string)"/>
        public NotLeaderForPartitionException(string message) : base(message) { }
        /// <inheritdoc cref="global::System.Exception(string, global::System.Exception)"/>
        public NotLeaderForPartitionException(string message, global::System.Exception innerException) : base(message, innerException) { }

        /// <inheritdoc/>
        public override string BridgeClassName => "org.apache.kafka.common.errors.NotLeaderForPartitionException";
    }
}
