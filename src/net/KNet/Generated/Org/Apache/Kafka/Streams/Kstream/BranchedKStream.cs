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
*  This file is generated by MASES.JNetReflector (ver. 2.4.0.0)
*  using kafka-streams-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Streams.Kstream
{
    #region BranchedKStream
    public partial class BranchedKStream
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
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/BranchedKStream.html#defaultBranch--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Map"/></returns>
        public Java.Util.Map DefaultBranch()
        {
            return IExecuteWithSignature<Java.Util.Map>("defaultBranch", "()Ljava/util/Map;");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/BranchedKStream.html#defaultBranch-org.apache.kafka.streams.kstream.Branched-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Branched"/></param>
        /// <returns><see cref="Java.Util.Map"/></returns>
        public Java.Util.Map DefaultBranch(Org.Apache.Kafka.Streams.Kstream.Branched arg0)
        {
            return IExecuteWithSignature<Java.Util.Map>("defaultBranch", "(Lorg/apache/kafka/streams/kstream/Branched;)Ljava/util/Map;", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/BranchedKStream.html#noDefaultBranch--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Map"/></returns>
        public Java.Util.Map NoDefaultBranch()
        {
            return IExecuteWithSignature<Java.Util.Map>("noDefaultBranch", "()Ljava/util/Map;");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/BranchedKStream.html#branch-org.apache.kafka.streams.kstream.Predicate-org.apache.kafka.streams.kstream.Branched-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Predicate"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Branched"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.BranchedKStream"/></returns>
        public Org.Apache.Kafka.Streams.Kstream.BranchedKStream Branch(Org.Apache.Kafka.Streams.Kstream.Predicate arg0, Org.Apache.Kafka.Streams.Kstream.Branched arg1)
        {
            return IExecute<Org.Apache.Kafka.Streams.Kstream.BranchedKStream>("branch", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/BranchedKStream.html#branch-org.apache.kafka.streams.kstream.Predicate-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Predicate"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.BranchedKStream"/></returns>
        public Org.Apache.Kafka.Streams.Kstream.BranchedKStream Branch(Org.Apache.Kafka.Streams.Kstream.Predicate arg0)
        {
            return IExecuteWithSignature<Org.Apache.Kafka.Streams.Kstream.BranchedKStream>("branch", "(Lorg/apache/kafka/streams/kstream/Predicate;)Lorg/apache/kafka/streams/kstream/BranchedKStream;", arg0);
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion

    #region IBranchedKStream<K, V>
    /// <summary>
    /// .NET interface for TO BE DEFINED FROM USER
    /// </summary>
    public partial interface IBranchedKStream<K, V>
    {
        #region Instance methods

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion

    #region BranchedKStream<K, V>
    public partial class BranchedKStream<K, V> : Org.Apache.Kafka.Streams.Kstream.IBranchedKStream<K, V>
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Streams.Kstream.BranchedKStream{K, V}"/> to <see cref="Org.Apache.Kafka.Streams.Kstream.BranchedKStream"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Streams.Kstream.BranchedKStream(Org.Apache.Kafka.Streams.Kstream.BranchedKStream<K, V> t) => t.Cast<Org.Apache.Kafka.Streams.Kstream.BranchedKStream>();

        #endregion

        #region Fields

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/BranchedKStream.html#defaultBranch--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Map"/></returns>
        public Java.Util.Map<Java.Lang.String, Org.Apache.Kafka.Streams.Kstream.KStream<K, V>> DefaultBranch()
        {
            return IExecuteWithSignature<Java.Util.Map<Java.Lang.String, Org.Apache.Kafka.Streams.Kstream.KStream<K, V>>>("defaultBranch", "()Ljava/util/Map;");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/BranchedKStream.html#defaultBranch-org.apache.kafka.streams.kstream.Branched-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Branched"/></param>
        /// <returns><see cref="Java.Util.Map"/></returns>
        public Java.Util.Map<Java.Lang.String, Org.Apache.Kafka.Streams.Kstream.KStream<K, V>> DefaultBranch(Org.Apache.Kafka.Streams.Kstream.Branched<K, V> arg0)
        {
            return IExecuteWithSignature<Java.Util.Map<Java.Lang.String, Org.Apache.Kafka.Streams.Kstream.KStream<K, V>>>("defaultBranch", "(Lorg/apache/kafka/streams/kstream/Branched;)Ljava/util/Map;", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/BranchedKStream.html#noDefaultBranch--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Map"/></returns>
        public Java.Util.Map<Java.Lang.String, Org.Apache.Kafka.Streams.Kstream.KStream<K, V>> NoDefaultBranch()
        {
            return IExecuteWithSignature<Java.Util.Map<Java.Lang.String, Org.Apache.Kafka.Streams.Kstream.KStream<K, V>>>("noDefaultBranch", "()Ljava/util/Map;");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/BranchedKStream.html#branch-org.apache.kafka.streams.kstream.Predicate-org.apache.kafka.streams.kstream.Branched-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Predicate"/></param>
        /// <param name="arg1"><see cref="Org.Apache.Kafka.Streams.Kstream.Branched"/></param>
        /// <typeparam name="Arg0objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.BranchedKStream"/></returns>
        public Org.Apache.Kafka.Streams.Kstream.BranchedKStream<K, V> Branch<Arg0objectSuperK, Arg0objectSuperV>(Org.Apache.Kafka.Streams.Kstream.Predicate<Arg0objectSuperK, Arg0objectSuperV> arg0, Org.Apache.Kafka.Streams.Kstream.Branched<K, V> arg1) where Arg0objectSuperK: K where Arg0objectSuperV: V
        {
            return IExecute<Org.Apache.Kafka.Streams.Kstream.BranchedKStream<K, V>>("branch", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/kstream/BranchedKStream.html#branch-org.apache.kafka.streams.kstream.Predicate-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Streams.Kstream.Predicate"/></param>
        /// <typeparam name="Arg0objectSuperK"><typeparamref name="K"/></typeparam>
        /// <typeparam name="Arg0objectSuperV"><typeparamref name="V"/></typeparam>
        /// <returns><see cref="Org.Apache.Kafka.Streams.Kstream.BranchedKStream"/></returns>
        public Org.Apache.Kafka.Streams.Kstream.BranchedKStream<K, V> Branch<Arg0objectSuperK, Arg0objectSuperV>(Org.Apache.Kafka.Streams.Kstream.Predicate<Arg0objectSuperK, Arg0objectSuperV> arg0) where Arg0objectSuperK: K where Arg0objectSuperV: V
        {
            return IExecuteWithSignature<Org.Apache.Kafka.Streams.Kstream.BranchedKStream<K, V>>("branch", "(Lorg/apache/kafka/streams/kstream/Predicate;)Lorg/apache/kafka/streams/kstream/BranchedKStream;", arg0);
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}