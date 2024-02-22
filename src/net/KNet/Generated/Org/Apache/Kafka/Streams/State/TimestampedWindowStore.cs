/*
*  Copyright 2024 MASES s.r.l.
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

/*
*  This file is generated by MASES.JNetReflector (ver. 2.3.0.0)
*  using kafka-streams-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Streams.State
{
    #region TimestampedWindowStore
    public partial class TimestampedWindowStore
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields

        #endregion

        #region Static methods

        #endregion

        #region Instance methods

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion

    #region ITimestampedWindowStore<K, V>
    /// <summary>
    /// .NET interface for TO BE DEFINED FROM USER
    /// </summary>
    public partial interface ITimestampedWindowStore<K, V> : Org.Apache.Kafka.Streams.State.IWindowStore<K, Org.Apache.Kafka.Streams.State.ValueAndTimestamp<V>>
    {
        #region Instance methods

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion

    #region TimestampedWindowStore<K, V>
    public partial class TimestampedWindowStore<K, V> : Org.Apache.Kafka.Streams.State.ITimestampedWindowStore<K, V>
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Streams.State.TimestampedWindowStore{K, V}"/> to <see cref="Org.Apache.Kafka.Streams.State.TimestampedWindowStore"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.State.TimestampedWindowStore(Org.Apache.Kafka.Streams.State.TimestampedWindowStore<K, V> t) => t.Cast<Org.Apache.Kafka.Streams.State.TimestampedWindowStore>();

        #endregion

        #region Fields

        #endregion

        #region Static methods

        #endregion

        #region Instance methods

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}