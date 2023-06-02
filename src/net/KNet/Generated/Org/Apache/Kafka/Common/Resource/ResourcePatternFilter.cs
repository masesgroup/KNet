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
*  using kafka-clients-3.4.0.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Common.Resource
{
    #region ResourcePatternFilter
    public partial class ResourcePatternFilter
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/resource/ResourcePatternFilter.html#%3Cinit%3E(org.apache.kafka.common.resource.ResourceType,java.lang.String,org.apache.kafka.common.resource.PatternType)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Resource.ResourceType"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <param name="arg2"><see cref="Org.Apache.Kafka.Common.Resource.PatternType"/></param>
        public ResourcePatternFilter(Org.Apache.Kafka.Common.Resource.ResourceType arg0, string arg1, Org.Apache.Kafka.Common.Resource.PatternType arg2)
            : base(arg0, arg1, arg2)
        {
        }

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/resource/ResourcePatternFilter.html#ANY"/>
        /// </summary>
        public static Org.Apache.Kafka.Common.Resource.ResourcePatternFilter ANY { get { return SGetField<Org.Apache.Kafka.Common.Resource.ResourcePatternFilter>(LocalBridgeClazz, "ANY"); } }

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/resource/ResourcePatternFilter.html#isUnknown()"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool IsUnknown()
        {
            return IExecute<bool>("isUnknown");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/resource/ResourcePatternFilter.html#matches(org.apache.kafka.common.resource.ResourcePattern)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Resource.ResourcePattern"/></param>
        /// <returns><see cref="bool"/></returns>
        public bool Matches(Org.Apache.Kafka.Common.Resource.ResourcePattern arg0)
        {
            return IExecute<bool>("matches", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/resource/ResourcePatternFilter.html#matchesAtMostOne()"/>
        /// </summary>

        /// <returns><see cref="bool"/></returns>
        public bool MatchesAtMostOne()
        {
            return IExecute<bool>("matchesAtMostOne");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/resource/ResourcePatternFilter.html#findIndefiniteField()"/>
        /// </summary>

        /// <returns><see cref="string"/></returns>
        public string FindIndefiniteField()
        {
            return IExecute<string>("findIndefiniteField");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/resource/ResourcePatternFilter.html#name()"/>
        /// </summary>

        /// <returns><see cref="string"/></returns>
        public string Name()
        {
            return IExecute<string>("name");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/resource/ResourcePatternFilter.html#patternType()"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Resource.PatternType"/></returns>
        public Org.Apache.Kafka.Common.Resource.PatternType PatternType()
        {
            return IExecute<Org.Apache.Kafka.Common.Resource.PatternType>("patternType");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/resource/ResourcePatternFilter.html#resourceType()"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Resource.ResourceType"/></returns>
        public Org.Apache.Kafka.Common.Resource.ResourceType ResourceType()
        {
            return IExecute<Org.Apache.Kafka.Common.Resource.ResourceType>("resourceType");
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}