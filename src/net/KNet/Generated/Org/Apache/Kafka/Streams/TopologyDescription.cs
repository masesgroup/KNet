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
*  This file is generated by MASES.JNetReflector (ver. 2.1.1.0)
*  using kafka-streams-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Streams
{
    #region ITopologyDescription
    /// <summary>
    /// .NET interface for TO BE DEFINED FROM USER
    /// </summary>
    public partial interface ITopologyDescription
    {
        #region Instance methods

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion

    #region TopologyDescription
    public partial class TopologyDescription : Org.Apache.Kafka.Streams.ITopologyDescription
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
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/TopologyDescription.html#globalStores--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Set"/></returns>
        public Java.Util.Set<Org.Apache.Kafka.Streams.TopologyDescription.GlobalStore> GlobalStores()
        {
            return IExecute<Java.Util.Set<Org.Apache.Kafka.Streams.TopologyDescription.GlobalStore>>("globalStores");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/TopologyDescription.html#subtopologies--"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Set"/></returns>
        public Java.Util.Set<Org.Apache.Kafka.Streams.TopologyDescription.Subtopology> Subtopologies()
        {
            return IExecute<Java.Util.Set<Org.Apache.Kafka.Streams.TopologyDescription.Subtopology>>("subtopologies");
        }

        #endregion

        #region Nested classes
        #region GlobalStore
        public partial class GlobalStore
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
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/TopologyDescription.GlobalStore.html#id--"/>
            /// </summary>

            /// <returns><see cref="int"/></returns>
            public int Id()
            {
                return IExecute<int>("id");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/TopologyDescription.GlobalStore.html#processor--"/>
            /// </summary>

            /// <returns><see cref="Org.Apache.Kafka.Streams.TopologyDescription.Processor"/></returns>
            public Org.Apache.Kafka.Streams.TopologyDescription.Processor ProcessorMethod()
            {
                return IExecute<Org.Apache.Kafka.Streams.TopologyDescription.Processor>("processor");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/TopologyDescription.GlobalStore.html#source--"/>
            /// </summary>

            /// <returns><see cref="Org.Apache.Kafka.Streams.TopologyDescription.Source"/></returns>
            public Org.Apache.Kafka.Streams.TopologyDescription.Source SourceMethod()
            {
                return IExecute<Org.Apache.Kafka.Streams.TopologyDescription.Source>("source");
            }

            #endregion

            #region Nested classes

            #endregion

            // TODO: complete the class
        }
        #endregion

        #region Node
        public partial class Node
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
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/TopologyDescription.Node.html#name--"/>
            /// </summary>

            /// <returns><see cref="string"/></returns>
            public string Name()
            {
                return IExecute<string>("name");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/TopologyDescription.Node.html#predecessors--"/>
            /// </summary>

            /// <returns><see cref="Java.Util.Set"/></returns>
            public Java.Util.Set<Org.Apache.Kafka.Streams.TopologyDescription.Node> Predecessors()
            {
                return IExecute<Java.Util.Set<Org.Apache.Kafka.Streams.TopologyDescription.Node>>("predecessors");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/TopologyDescription.Node.html#successors--"/>
            /// </summary>

            /// <returns><see cref="Java.Util.Set"/></returns>
            public Java.Util.Set<Org.Apache.Kafka.Streams.TopologyDescription.Node> Successors()
            {
                return IExecute<Java.Util.Set<Org.Apache.Kafka.Streams.TopologyDescription.Node>>("successors");
            }

            #endregion

            #region Nested classes

            #endregion

            // TODO: complete the class
        }
        #endregion

        #region Processor
        public partial class Processor
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
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/TopologyDescription.Processor.html#stores--"/>
            /// </summary>

            /// <returns><see cref="Java.Util.Set"/></returns>
            public Java.Util.Set<string> Stores()
            {
                return IExecute<Java.Util.Set<string>>("stores");
            }

            #endregion

            #region Nested classes

            #endregion

            // TODO: complete the class
        }
        #endregion

        #region Sink
        public partial class Sink
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
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/TopologyDescription.Sink.html#topic--"/>
            /// </summary>

            /// <returns><see cref="string"/></returns>
            public string Topic()
            {
                return IExecute<string>("topic");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/TopologyDescription.Sink.html#topicNameExtractor--"/>
            /// </summary>

            /// <returns><see cref="Org.Apache.Kafka.Streams.Processor.TopicNameExtractor"/></returns>
            public Org.Apache.Kafka.Streams.Processor.TopicNameExtractor TopicNameExtractor()
            {
                return IExecute<Org.Apache.Kafka.Streams.Processor.TopicNameExtractor>("topicNameExtractor");
            }

            #endregion

            #region Nested classes

            #endregion

            // TODO: complete the class
        }
        #endregion

        #region Source
        public partial class Source
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
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/TopologyDescription.Source.html#topicPattern--"/>
            /// </summary>

            /// <returns><see cref="Java.Util.Regex.Pattern"/></returns>
            public Java.Util.Regex.Pattern TopicPattern()
            {
                return IExecute<Java.Util.Regex.Pattern>("topicPattern");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/TopologyDescription.Source.html#topicSet--"/>
            /// </summary>

            /// <returns><see cref="Java.Util.Set"/></returns>
            public Java.Util.Set<string> TopicSet()
            {
                return IExecute<Java.Util.Set<string>>("topicSet");
            }

            #endregion

            #region Nested classes

            #endregion

            // TODO: complete the class
        }
        #endregion

        #region Subtopology
        public partial class Subtopology
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
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/TopologyDescription.Subtopology.html#id--"/>
            /// </summary>

            /// <returns><see cref="int"/></returns>
            public int Id()
            {
                return IExecute<int>("id");
            }
            /// <summary>
            /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-streams/3.6.1/org/apache/kafka/streams/TopologyDescription.Subtopology.html#nodes--"/>
            /// </summary>

            /// <returns><see cref="Java.Util.Set"/></returns>
            public Java.Util.Set<Org.Apache.Kafka.Streams.TopologyDescription.Node> Nodes()
            {
                return IExecute<Java.Util.Set<Org.Apache.Kafka.Streams.TopologyDescription.Node>>("nodes");
            }

            #endregion

            #region Nested classes

            #endregion

            // TODO: complete the class
        }
        #endregion

    
        #endregion

        // TODO: complete the class
    }
    #endregion
}