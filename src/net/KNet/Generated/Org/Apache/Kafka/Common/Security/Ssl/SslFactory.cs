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

namespace Org.Apache.Kafka.Common.Security.Ssl
{
    #region SslFactory
    public partial class SslFactory
    {
        #region Constructors
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/security/ssl/SslFactory.html#%3Cinit%3E(org.apache.kafka.common.network.Mode,java.lang.String,boolean)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Network.Mode"/></param>
        /// <param name="arg1"><see cref="string"/></param>
        /// <param name="arg2"><see cref="bool"/></param>
        public SslFactory(Org.Apache.Kafka.Common.Network.Mode arg0, string arg1, bool arg2)
            : base(arg0, arg1, arg2)
        {
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/security/ssl/SslFactory.html#%3Cinit%3E(org.apache.kafka.common.network.Mode)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Network.Mode"/></param>
        public SslFactory(Org.Apache.Kafka.Common.Network.Mode arg0)
            : base(arg0)
        {
        }

        #endregion

        #region Class/Interface conversion operators
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Common.Security.Ssl.SslFactory"/> to <see cref="Org.Apache.Kafka.Common.Reconfigurable"/>
        /// </summary>
        public static implicit operator Org.Apache.Kafka.Common.Reconfigurable(Org.Apache.Kafka.Common.Security.Ssl.SslFactory t) => t.Cast<Org.Apache.Kafka.Common.Reconfigurable>();
        /// <summary>
        /// Converter from <see cref="Org.Apache.Kafka.Common.Security.Ssl.SslFactory"/> to <see cref="Java.Io.Closeable"/>
        /// </summary>
        public static implicit operator Java.Io.Closeable(Org.Apache.Kafka.Common.Security.Ssl.SslFactory t) => t.Cast<Java.Io.Closeable>();

        #endregion

        #region Fields

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/security/ssl/SslFactory.html#reconfigurableConfigs()"/>
        /// </summary>

        /// <returns><see cref="Java.Util.Set"/></returns>
        public Java.Util.Set<string> ReconfigurableConfigs()
        {
            return IExecute<Java.Util.Set<string>>("reconfigurableConfigs");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/security/ssl/SslFactory.html#createSslEngine(java.lang.String,int)"/>
        /// </summary>
        /// <param name="arg0"><see cref="string"/></param>
        /// <param name="arg1"><see cref="int"/></param>
        /// <returns><see cref="Javax.Net.Ssl.SSLEngine"/></returns>
        public Javax.Net.Ssl.SSLEngine CreateSslEngine(string arg0, int arg1)
        {
            return IExecute<Javax.Net.Ssl.SSLEngine>("createSslEngine", arg0, arg1);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/security/ssl/SslFactory.html#createSslEngine(java.net.Socket)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Net.Socket"/></param>
        /// <returns><see cref="Javax.Net.Ssl.SSLEngine"/></returns>
        public Javax.Net.Ssl.SSLEngine CreateSslEngine(Java.Net.Socket arg0)
        {
            return IExecute<Javax.Net.Ssl.SSLEngine>("createSslEngine", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/security/ssl/SslFactory.html#sslEngineFactory()"/>
        /// </summary>

        /// <returns><see cref="Org.Apache.Kafka.Common.Security.Auth.SslEngineFactory"/></returns>
        public Org.Apache.Kafka.Common.Security.Auth.SslEngineFactory SslEngineFactory()
        {
            return IExecute<Org.Apache.Kafka.Common.Security.Auth.SslEngineFactory>("sslEngineFactory");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/security/ssl/SslFactory.html#close()"/>
        /// </summary>
        public void Close()
        {
            IExecute("close");
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/security/ssl/SslFactory.html#configure(java.util.Map)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Map"/></param>
        /// <typeparam name="Arg0Extendsobject"></typeparam>
        /// <exception cref="Org.Apache.Kafka.Common.KafkaException"/>
        public void Configure<Arg0Extendsobject>(Java.Util.Map<string, Arg0Extendsobject> arg0)
        {
            IExecute("configure", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/security/ssl/SslFactory.html#reconfigure(java.util.Map)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Map"/></param>
        /// <typeparam name="Arg0Extendsobject"></typeparam>
        /// <exception cref="Org.Apache.Kafka.Common.KafkaException"/>
        public void Reconfigure<Arg0Extendsobject>(Java.Util.Map<string, Arg0Extendsobject> arg0)
        {
            IExecute("reconfigure", arg0);
        }
        /// <summary>
        /// <see href="https://www.javadoc.io/static/org.apache.kafka/kafka-clients/3.4.0/org/apache/kafka/common/security/ssl/SslFactory.html#validateReconfiguration(java.util.Map)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Util.Map"/></param>
        /// <typeparam name="Arg0Extendsobject"></typeparam>
        public void ValidateReconfiguration<Arg0Extendsobject>(Java.Util.Map<string, Arg0Extendsobject> arg0)
        {
            IExecute("validateReconfiguration", arg0);
        }

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}