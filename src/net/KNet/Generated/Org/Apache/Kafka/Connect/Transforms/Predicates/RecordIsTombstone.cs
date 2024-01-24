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
*  This file is generated by MASES.JNetReflector (ver. 2.2.3.0)
*  using connect-transforms-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Connect.Transforms.Predicates
{
    #region RecordIsTombstone
    public partial class RecordIsTombstone
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Connect.Transforms.Predicates.RecordIsTombstone"/> to <see cref="Org.Apache.Kafka.Connect.Transforms.Predicates.Predicate"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Connect.Transforms.Predicates.Predicate(Org.Apache.Kafka.Connect.Transforms.Predicates.RecordIsTombstone t) => t.Cast<Org.Apache.Kafka.Connect.Transforms.Predicates.Predicate>();
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Connect.Transforms.Predicates.RecordIsTombstone"/> to <see cref="Org.Apache.Kafka.Connect.Components.Versioned"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Connect.Components.Versioned(Org.Apache.Kafka.Connect.Transforms.Predicates.RecordIsTombstone t) => t.Cast<Org.Apache.Kafka.Connect.Components.Versioned>();

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-transforms/3.6.1/org/apache/kafka/connect/transforms/predicates/RecordIsTombstone.html#OVERVIEW_DOC"/>
        /// </summary>
        public static string OVERVIEW_DOC { get { if (!_OVERVIEW_DOCReady) { _OVERVIEW_DOCContent = SGetField<string>(LocalBridgeClazz, "OVERVIEW_DOC"); _OVERVIEW_DOCReady = true; } return _OVERVIEW_DOCContent; } }
        private static string _OVERVIEW_DOCContent = default;
        private static bool _OVERVIEW_DOCReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-transforms/3.6.1/org/apache/kafka/connect/transforms/predicates/RecordIsTombstone.html#CONFIG_DEF"/>
        /// </summary>
        public static Org.Apache.Kafka.Common.Config.ConfigDef CONFIG_DEF { get { if (!_CONFIG_DEFReady) { _CONFIG_DEFContent = SGetField<Org.Apache.Kafka.Common.Config.ConfigDef>(LocalBridgeClazz, "CONFIG_DEF"); _CONFIG_DEFReady = true; } return _CONFIG_DEFContent; } }
        private static Org.Apache.Kafka.Common.Config.ConfigDef _CONFIG_DEFContent = default;
        private static bool _CONFIG_DEFReady = false; // this is used because in case of generics 

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-transforms/3.6.1/org/apache/kafka/connect/transforms/predicates/RecordIsTombstone.html#test-org.apache.kafka.connect.connector.ConnectRecord-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Connect.Connector.ConnectRecord"/></param>
        /// <returns><see cref="bool"/></returns>
        public bool Test(Org.Apache.Kafka.Connect.Connector.ConnectRecord arg0)
        {
            return IExecute<bool>("test", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-transforms/3.6.1/org/apache/kafka/connect/transforms/predicates/RecordIsTombstone.html#version--"/>
        /// </summary>

        /// <returns><see cref="string"/></returns>
        public string Version()
        {
            return IExecute<string>("version");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-transforms/3.6.1/org/apache/kafka/connect/transforms/predicates/RecordIsTombstone.html#config--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Config.ConfigDef"/></returns>
        public Org.Apache.Kafka.Common.Config.ConfigDef Config()
        {
            return IExecute<Org.Apache.Kafka.Common.Config.ConfigDef>("config");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-transforms/3.6.1/org/apache/kafka/connect/transforms/predicates/RecordIsTombstone.html#close--"/>
        /// </summary>
        public void Close()
        {
            IExecute("close");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-transforms/3.6.1/org/apache/kafka/connect/transforms/predicates/RecordIsTombstone.html#configure-java.util.Map-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Map"/></param>
        public void Configure(Java.Util.Map arg0)
        {
            IExecute("configure", arg0);
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion

    #region RecordIsTombstone<R>
    public partial class RecordIsTombstone<R> : Org.Apache.Kafka.Connect.Transforms.Predicates.IPredicate<R>, Org.Apache.Kafka.Connect.Components.IVersioned
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Connect.Transforms.Predicates.RecordIsTombstone{R}"/> to <see cref="Org.Apache.Kafka.Connect.Transforms.Predicates.Predicate{R}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Connect.Transforms.Predicates.Predicate<R>(Org.Apache.Kafka.Connect.Transforms.Predicates.RecordIsTombstone<R> t) => t.Cast<Org.Apache.Kafka.Connect.Transforms.Predicates.Predicate<R>>();
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Connect.Transforms.Predicates.RecordIsTombstone{R}"/> to <see cref="Org.Apache.Kafka.Connect.Components.Versioned"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Connect.Components.Versioned(Org.Apache.Kafka.Connect.Transforms.Predicates.RecordIsTombstone<R> t) => t.Cast<Org.Apache.Kafka.Connect.Components.Versioned>();
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Connect.Transforms.Predicates.RecordIsTombstone{R}"/> to <see cref="Org.Apache.Kafka.Connect.Transforms.Predicates.RecordIsTombstone"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Connect.Transforms.Predicates.RecordIsTombstone(Org.Apache.Kafka.Connect.Transforms.Predicates.RecordIsTombstone<R> t) => t.Cast<Org.Apache.Kafka.Connect.Transforms.Predicates.RecordIsTombstone>();

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-transforms/3.6.1/org/apache/kafka/connect/transforms/predicates/RecordIsTombstone.html#OVERVIEW_DOC"/>
        /// </summary>
        public static string OVERVIEW_DOC { get { if (!_OVERVIEW_DOCReady) { _OVERVIEW_DOCContent = SGetField<string>(LocalBridgeClazz, "OVERVIEW_DOC"); _OVERVIEW_DOCReady = true; } return _OVERVIEW_DOCContent; } }
        private static string _OVERVIEW_DOCContent = default;
        private static bool _OVERVIEW_DOCReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-transforms/3.6.1/org/apache/kafka/connect/transforms/predicates/RecordIsTombstone.html#CONFIG_DEF"/>
        /// </summary>
        public static Org.Apache.Kafka.Common.Config.ConfigDef CONFIG_DEF { get { if (!_CONFIG_DEFReady) { _CONFIG_DEFContent = SGetField<Org.Apache.Kafka.Common.Config.ConfigDef>(LocalBridgeClazz, "CONFIG_DEF"); _CONFIG_DEFReady = true; } return _CONFIG_DEFContent; } }
        private static Org.Apache.Kafka.Common.Config.ConfigDef _CONFIG_DEFContent = default;
        private static bool _CONFIG_DEFReady = false; // this is used because in case of generics 

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-transforms/3.6.1/org/apache/kafka/connect/transforms/predicates/RecordIsTombstone.html#test-org.apache.kafka.connect.connector.ConnectRecord-"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="R"/></param>
        /// <returns><see cref="bool"/></returns>
        public bool Test(R arg0)
        {
            return IExecute<bool>("test", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-transforms/3.6.1/org/apache/kafka/connect/transforms/predicates/RecordIsTombstone.html#version--"/>
        /// </summary>

        /// <returns><see cref="string"/></returns>
        public string Version()
        {
            return IExecute<string>("version");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-transforms/3.6.1/org/apache/kafka/connect/transforms/predicates/RecordIsTombstone.html#config--"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Config.ConfigDef"/></returns>
        public Org.Apache.Kafka.Common.Config.ConfigDef Config()
        {
            return IExecute<Org.Apache.Kafka.Common.Config.ConfigDef>("config");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-transforms/3.6.1/org/apache/kafka/connect/transforms/predicates/RecordIsTombstone.html#close--"/>
        /// </summary>
        public void Close()
        {
            IExecute("close");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/connect-transforms/3.6.1/org/apache/kafka/connect/transforms/predicates/RecordIsTombstone.html#configure-java.util.Map-"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Map"/></param>
        public void Configure(Java.Util.Map<string, object> arg0)
        {
            IExecute("configure", arg0);
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}