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
using Org.Apache.Kafka.Clients.Admin;
using Org.Apache.Kafka.Common.Config;
using Org.Apache.Kafka.Common.Config.Types;

namespace MASES.KNet.Common
{
    /// <summary>
    /// Common builder for <see cref="SslConfigsBuilder"/>
    /// </summary>
    public class SslConfigsBuilder : GenericConfigBuilder<SslConfigsBuilder>
    {
        /// <summary>
        /// Manages <see cref="SslConfigs.SSL_PROTOCOL_CONFIG"/>
        /// </summary>
        public string SslProtocol { get { return GetProperty<string>(SslConfigs.SSL_PROTOCOL_CONFIG); } set { SetProperty(SslConfigs.SSL_PROTOCOL_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="SslConfigs.SSL_PROTOCOL_CONFIG"/>
        /// </summary>
        public SslConfigsBuilder WithSslProtocol(string sslProtocol)
        {
            var clone = Clone();
            clone.SslProtocol = sslProtocol;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="SslConfigs.SSL_PROVIDER_CONFIG"/>
        /// </summary>
        public string SslProvider { get { return GetProperty<string>(SslConfigs.SSL_PROVIDER_CONFIG); } set { SetProperty(SslConfigs.SSL_PROVIDER_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="SslConfigs.SSL_PROVIDER_CONFIG"/>
        /// </summary>
        public SslConfigsBuilder WithSslProvider(string sslProvider)
        {
            var clone = Clone();
            clone.SslProvider = sslProvider;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="SslConfigs.SSL_CIPHER_SUITES_CONFIG"/>
        /// </summary>
        public string SslCipherSuites { get { return GetProperty<string>(SslConfigs.SSL_CIPHER_SUITES_CONFIG); } set { SetProperty(SslConfigs.SSL_CIPHER_SUITES_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="SslConfigs.SSL_CIPHER_SUITES_CONFIG"/>
        /// </summary>
        public SslConfigsBuilder WithSslCipherSuites(string sslCipherSuites)
        {
            var clone = Clone();
            clone.SslCipherSuites = sslCipherSuites;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="SslConfigs.SSL_ENABLED_PROTOCOLS_CONFIG"/>
        /// </summary>
        public string SslEnabledProtocols { get { return GetProperty<string>(SslConfigs.SSL_ENABLED_PROTOCOLS_CONFIG); } set { SetProperty(SslConfigs.SSL_ENABLED_PROTOCOLS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="SslConfigs.SSL_ENABLED_PROTOCOLS_CONFIG"/>
        /// </summary>
        public SslConfigsBuilder WithSslEnabledProtocols(string sslEnabledProtocols)
        {
            var clone = Clone();
            clone.SslEnabledProtocols = sslEnabledProtocols;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="SslConfigs.SSL_KEYSTORE_TYPE_CONFIG"/>
        /// </summary>
        public string SslKeystoreType { get { return GetProperty<string>(SslConfigs.SSL_KEYSTORE_TYPE_CONFIG); } set { SetProperty(SslConfigs.SSL_KEYSTORE_TYPE_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="SslConfigs.SSL_KEYSTORE_TYPE_CONFIG"/>
        /// </summary>
        public SslConfigsBuilder WithSslKeystoreType(string sslKeystoreType)
        {
            var clone = Clone();
            clone.SslKeystoreType = sslKeystoreType;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="SslConfigs.SSL_KEYSTORE_LOCATION_CONFIG"/>
        /// </summary>
        public string SslKeystoreLocation { get { return GetProperty<string>(SslConfigs.SSL_KEYSTORE_LOCATION_CONFIG); } set { SetProperty(SslConfigs.SSL_KEYSTORE_LOCATION_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="SslConfigs.SSL_KEYSTORE_LOCATION_CONFIG"/>
        /// </summary>
        public SslConfigsBuilder WithSslKeystoreLocation(string sslKeystoreLocation)
        {
            var clone = Clone();
            clone.SslKeystoreLocation = sslKeystoreLocation;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="SslConfigs.SSL_KEYSTORE_PASSWORD_CONFIG"/>
        /// </summary>
        public Password SslKeystorePassword { get { return GetProperty<Password>(SslConfigs.SSL_KEYSTORE_PASSWORD_CONFIG); } set { SetProperty(SslConfigs.SSL_KEYSTORE_PASSWORD_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="SslConfigs.SSL_KEYSTORE_PASSWORD_CONFIG"/>
        /// </summary>
        public SslConfigsBuilder WithSslKeystoreLocation(Password sslKeystorePassword)
        {
            var clone = Clone();
            clone.SslKeystorePassword = sslKeystorePassword;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="SslConfigs.SSL_KEY_PASSWORD_CONFIG"/>
        /// </summary>
        public Password SslKeyPassword { get { return GetProperty<Password>(SslConfigs.SSL_KEY_PASSWORD_CONFIG); } set { SetProperty(SslConfigs.SSL_KEY_PASSWORD_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="SslConfigs.SSL_KEY_PASSWORD_CONFIG"/>
        /// </summary>
        public SslConfigsBuilder WithSslKeyLocation(Password sslKeyPassword)
        {
            var clone = Clone();
            clone.SslKeyPassword = sslKeyPassword;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="SslConfigs.SSL_KEYSTORE_KEY_CONFIG"/>
        /// </summary>
        public Password SslKeystoreKey { get { return GetProperty<Password>(SslConfigs.SSL_KEYSTORE_KEY_CONFIG); } set { SetProperty(SslConfigs.SSL_KEYSTORE_KEY_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="SslConfigs.SSL_KEYSTORE_KEY_CONFIG"/>
        /// </summary>
        public SslConfigsBuilder WithSslKeystoreKeyLocation(Password sslKeystoreKey)
        {
            var clone = Clone();
            clone.SslKeystoreKey = sslKeystoreKey;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="SslConfigs.SSL_KEYSTORE_CERTIFICATE_CHAIN_CONFIG"/>
        /// </summary>
        public Password SslKeystoreCertificateChain { get { return GetProperty<Password>(SslConfigs.SSL_KEYSTORE_CERTIFICATE_CHAIN_CONFIG); } set { SetProperty(SslConfigs.SSL_KEYSTORE_CERTIFICATE_CHAIN_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="SslConfigs.SSL_KEYSTORE_CERTIFICATE_CHAIN_CONFIG"/>
        /// </summary>
        public SslConfigsBuilder WithSslKeystoreCertificateChain(Password sslKeystoreCertificateChain)
        {
            var clone = Clone();
            clone.SslKeystoreCertificateChain = sslKeystoreCertificateChain;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="SslConfigs.SSL_TRUSTSTORE_CERTIFICATES_CONFIG"/>
        /// </summary>
        public Password SslTruststoreCertificates { get { return GetProperty<Password>(SslConfigs.SSL_TRUSTSTORE_CERTIFICATES_CONFIG); } set { SetProperty(SslConfigs.SSL_TRUSTSTORE_CERTIFICATES_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="SslConfigs.SSL_TRUSTSTORE_CERTIFICATES_CONFIG"/>
        /// </summary>
        public SslConfigsBuilder WithSslTruststoreCertificates(Password sslTruststoreCertificates)
        {
            var clone = Clone();
            clone.SslTruststoreCertificates = sslTruststoreCertificates;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="SslConfigs.SSL_TRUSTSTORE_TYPE_CONFIG"/>
        /// </summary>
        public string SslTruststoreType { get { return GetProperty<string>(SslConfigs.SSL_TRUSTSTORE_TYPE_CONFIG); } set { SetProperty(SslConfigs.SSL_TRUSTSTORE_TYPE_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="SslConfigs.SSL_TRUSTSTORE_TYPE_CONFIG"/>
        /// </summary>
        public SslConfigsBuilder WithSslTruststoreType(string sslTruststoreType)
        {
            var clone = Clone();
            clone.SslTruststoreType = sslTruststoreType;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="SslConfigs.SSL_TRUSTSTORE_LOCATION_CONFIG"/>
        /// </summary>
        public string SslTruststoreLocation { get { return GetProperty<string>(SslConfigs.SSL_TRUSTSTORE_LOCATION_CONFIG); } set { SetProperty(SslConfigs.SSL_TRUSTSTORE_LOCATION_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="SslConfigs.SSL_TRUSTSTORE_LOCATION_CONFIG"/>
        /// </summary>
        public SslConfigsBuilder WithSslTruststoreLocation(string sslTruststoreLocation)
        {
            var clone = Clone();
            clone.SslTruststoreLocation = sslTruststoreLocation;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="SslConfigs.SSL_TRUSTSTORE_PASSWORD_CONFIG"/>
        /// </summary>
        public Password SslTruststorePassword { get { return GetProperty<Password>(SslConfigs.SSL_TRUSTSTORE_PASSWORD_CONFIG); } set { SetProperty(SslConfigs.SSL_TRUSTSTORE_PASSWORD_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="SslConfigs.SSL_TRUSTSTORE_PASSWORD_CONFIG"/>
        /// </summary>
        public SslConfigsBuilder WithSslTruststorePassword(Password sslTruststorePassword)
        {
            var clone = Clone();
            clone.SslTruststorePassword = sslTruststorePassword;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="SslConfigs.SSL_KEYMANAGER_ALGORITHM_CONFIG"/>
        /// </summary>
        public string SslKeyManagerAlgorithm { get { return GetProperty<string>(SslConfigs.SSL_KEYMANAGER_ALGORITHM_CONFIG); } set { SetProperty(SslConfigs.SSL_KEYMANAGER_ALGORITHM_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="SslConfigs.SSL_KEYMANAGER_ALGORITHM_CONFIG"/>
        /// </summary>
        public SslConfigsBuilder WithSslKeyManagerAlgorithm(string sslKeyManagerAlgorithm)
        {
            var clone = Clone();
            clone.SslKeyManagerAlgorithm = sslKeyManagerAlgorithm;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="SslConfigs.SSL_TRUSTMANAGER_ALGORITHM_CONFIG"/>
        /// </summary>
        public string SslTrustManagerAlgorithm { get { return GetProperty<string>(SslConfigs.SSL_TRUSTMANAGER_ALGORITHM_CONFIG); } set { SetProperty(SslConfigs.SSL_TRUSTMANAGER_ALGORITHM_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="SslConfigs.SSL_TRUSTMANAGER_ALGORITHM_CONFIG"/>
        /// </summary>
        public SslConfigsBuilder WithSslTrustManagerAlgorithm(string sslTrustManagerAlgorithm)
        {
            var clone = Clone();
            clone.SslTrustManagerAlgorithm = sslTrustManagerAlgorithm;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="SslConfigs.SSL_ENDPOINT_IDENTIFICATION_ALGORITHM_CONFIG"/>
        /// </summary>
        public string SslEndpointIdentificationAlgorithm { get { return GetProperty<string>(SslConfigs.SSL_ENDPOINT_IDENTIFICATION_ALGORITHM_CONFIG); } set { SetProperty(SslConfigs.SSL_ENDPOINT_IDENTIFICATION_ALGORITHM_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="SslConfigs.SSL_ENDPOINT_IDENTIFICATION_ALGORITHM_CONFIG"/>
        /// </summary>
        public SslConfigsBuilder WithSslEndpointIdentificationAlgorithm(string sslEndpointIdentificationAlgorithm)
        {
            var clone = Clone();
            clone.SslEndpointIdentificationAlgorithm = sslEndpointIdentificationAlgorithm;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="SslConfigs.SSL_SECURE_RANDOM_IMPLEMENTATION_CONFIG"/>
        /// </summary>
        public string SslSecureRandomImplementation { get { return GetProperty<string>(SslConfigs.SSL_SECURE_RANDOM_IMPLEMENTATION_CONFIG); } set { SetProperty(SslConfigs.SSL_SECURE_RANDOM_IMPLEMENTATION_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="SslConfigs.SSL_SECURE_RANDOM_IMPLEMENTATION_CONFIG"/>
        /// </summary>
        public SslConfigsBuilder WithSslSecureRandomImplementation(string sslSecureRandomImplementation)
        {
            var clone = Clone();
            clone.SslSecureRandomImplementation = sslSecureRandomImplementation;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="SslConfigs.SSL_ENGINE_FACTORY_CLASS_CONFIG"/>
        /// </summary>
        public Class SslEngineFactoryClass { get { return GetProperty<Class>(SslConfigs.SSL_ENGINE_FACTORY_CLASS_CONFIG); } set { SetProperty(SslConfigs.SSL_ENGINE_FACTORY_CLASS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="SslConfigs.SSL_ENGINE_FACTORY_CLASS_CONFIG"/>
        /// </summary>
        public SslConfigsBuilder WithSslEngineFactoryClass(Class sslEngineFactoryClass)
        {
            var clone = Clone();
            clone.SslEngineFactoryClass = sslEngineFactoryClass;
            return clone;
        }
    }
}
