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

/*
*  This file is generated by MASES.JNetReflector (ver. 1.5.5.0)
*  using kafka-streams-3.4.0.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Streams.Kstream
{
    #region TransformerSupplier
    public partial class TransformerSupplier
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Streams.Kstream.TransformerSupplier"/> to <see cref="Org.Apache.Kafka.Streams.Processor.ConnectedStoreProvider"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Processor.ConnectedStoreProvider(Org.Apache.Kafka.Streams.Kstream.TransformerSupplier t) => t.Cast<Org.Apache.Kafka.Streams.Processor.ConnectedStoreProvider>();
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Streams.Kstream.TransformerSupplier"/> to <see cref="Java.Util.Function.Supplier"/>
        /// </summary>
        public static implicit operator Java.Util.Function.Supplier(Org.Apache.Kafka.Streams.Kstream.TransformerSupplier t) => t.Cast<Java.Util.Function.Supplier>();

        #endregion

        #region Fields

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-streams/3.4.0/org/apache/kafka/streams/kstream/TransformerSupplier.html#get()"/>
        /// </summary>

        /// <returns><see cref="object"/></returns>
        public object Get()
        {
            return IExecute("get");
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion

    #region TransformerSupplier<K, V, R>
    public partial class TransformerSupplier<K, V, R>
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Streams.Kstream.TransformerSupplier{K, V, R}"/> to <see cref="Org.Apache.Kafka.Streams.Processor.ConnectedStoreProvider"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Processor.ConnectedStoreProvider(Org.Apache.Kafka.Streams.Kstream.TransformerSupplier<K, V, R> t) => t.Cast<Org.Apache.Kafka.Streams.Processor.ConnectedStoreProvider>();
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Streams.Kstream.TransformerSupplier{K, V, R}"/> to <see cref="Java.Util.Function.Supplier"/>
        /// </summary>
        public static implicit operator Java.Util.Function.Supplier(Org.Apache.Kafka.Streams.Kstream.TransformerSupplier<K, V, R> t) => t.Cast<Java.Util.Function.Supplier>();
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Streams.Kstream.TransformerSupplier{K, V, R}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.TransformerSupplier"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.TransformerSupplier(Org.Apache.Kafka.Streams.Kstream.TransformerSupplier<K, V, R> t) => t.Cast<Org.Apache.Kafka.Streams.Kstream.TransformerSupplier>();

        #endregion

        #region Fields

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-streams/3.4.0/org/apache/kafka/streams/kstream/TransformerSupplier.html#get()"/>
        /// </summary>

        /// <returns><see cref="object"/></returns>
        public object Get()
        {
            return IExecute("get");
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}