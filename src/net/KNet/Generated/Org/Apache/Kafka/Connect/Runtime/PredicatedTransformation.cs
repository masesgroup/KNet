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
*  using connect-runtime-3.4.0.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Connect.Runtime
{
    #region PredicatedTransformation
    public partial class PredicatedTransformation
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Connect.Runtime.PredicatedTransformation"/> to <see cref="Org.Apache.Kafka.Connect.Transforms.Transformation"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Connect.Transforms.Transformation(Org.Apache.Kafka.Connect.Runtime.PredicatedTransformation t) => t.Cast<Org.Apache.Kafka.Connect.Transforms.Transformation>();

        #endregion

        #region Fields

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/PredicatedTransformation.html#config()"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Config.ConfigDef"/></returns>
        public Org.Apache.Kafka.Common.Config.ConfigDef Config()
        {
            return IExecute<Org.Apache.Kafka.Common.Config.ConfigDef>("config");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/PredicatedTransformation.html#apply(org.apache.kafka.connect.connector.ConnectRecord)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Connect.Connector.ConnectRecord"/></param>
        /// <returns><see cref="Org.Apache.Kafka.Connect.Connector.ConnectRecord"/></returns>
        public Org.Apache.Kafka.Connect.Connector.ConnectRecord Apply(Org.Apache.Kafka.Connect.Connector.ConnectRecord arg0)
        {
            return IExecute<Org.Apache.Kafka.Connect.Connector.ConnectRecord>("apply", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/PredicatedTransformation.html#close()"/>
        /// </summary>
        public void Close()
        {
            IExecute("close");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/PredicatedTransformation.html#configure(java.util.Map)"/>
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

    #region PredicatedTransformation<R>
    public partial class PredicatedTransformation<R>
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Connect.Runtime.PredicatedTransformation{R}"/> to <see cref="Org.Apache.Kafka.Connect.Transforms.Transformation{R}"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Connect.Transforms.Transformation<R>(Org.Apache.Kafka.Connect.Runtime.PredicatedTransformation<R> t) => t.Cast<Org.Apache.Kafka.Connect.Transforms.Transformation<R>>();
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Connect.Runtime.PredicatedTransformation{R}"/> to <see cref="Org.Apache.Kafka.Connect.Runtime.PredicatedTransformation"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Connect.Runtime.PredicatedTransformation(Org.Apache.Kafka.Connect.Runtime.PredicatedTransformation<R> t) => t.Cast<Org.Apache.Kafka.Connect.Runtime.PredicatedTransformation>();

        #endregion

        #region Fields

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/PredicatedTransformation.html#config()"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Config.ConfigDef"/></returns>
        public Org.Apache.Kafka.Common.Config.ConfigDef Config()
        {
            return IExecute<Org.Apache.Kafka.Common.Config.ConfigDef>("config");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/PredicatedTransformation.html#apply(org.apache.kafka.connect.connector.ConnectRecord)"/>
        /// </summary>
        /// <param name="arg0"><typeparamref name="R"/></param>
        /// <returns><typeparamref name="R"/></returns>
        public R Apply(R arg0)
        {
            return IExecute<R>("apply", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/PredicatedTransformation.html#close()"/>
        /// </summary>
        public void Close()
        {
            IExecute("close");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/connect-runtime/3.4.0/org/apache/kafka/connect/runtime/PredicatedTransformation.html#configure(java.util.Map)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Map"/></param>
        /// <typeparam name="Arg0Extendsobject"></typeparam>
        public void Configure<Arg0Extendsobject>(Java.Util.Map<string, Arg0Extendsobject> arg0)
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