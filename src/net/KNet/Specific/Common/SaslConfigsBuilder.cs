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
using Java.Util;
using Org.Apache.Kafka.Clients.Admin;
using Org.Apache.Kafka.Common.Config;
using Org.Apache.Kafka.Common.Config.Types;

namespace MASES.KNet.Common
{
    /// <summary>
    /// Common builder for <see cref="SaslConfigsBuilder"/>
    /// </summary>
    public class SaslConfigsBuilder : GenericConfigBuilder<SaslConfigsBuilder>
    {
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_KERBEROS_SERVICE_NAME"/>
        /// </summary>
        public string SaslKerberosServiceName { get { return GetProperty<string>(SaslConfigs.SASL_KERBEROS_SERVICE_NAME); } set { SetProperty(SaslConfigs.SASL_KERBEROS_SERVICE_NAME, value); } }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_KERBEROS_SERVICE_NAME"/>
        /// </summary>
        public SaslConfigsBuilder WithSaslKerberosServiceName(string saslKerberosServiceName)
        {
            var clone = Clone();
            clone.SaslKerberosServiceName = saslKerberosServiceName;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_KERBEROS_KINIT_CMD"/>
        /// </summary>
        public string SaslKerberosKinitCmd { get { return GetProperty<string>(SaslConfigs.SASL_KERBEROS_KINIT_CMD); } set { SetProperty(SaslConfigs.SASL_KERBEROS_KINIT_CMD, value); } }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_KERBEROS_KINIT_CMD"/>
        /// </summary>
        public SaslConfigsBuilder WithSaslKerberosKinitCmd(string saslKerberosKinitCmd)
        {
            var clone = Clone();
            clone.SaslKerberosKinitCmd = saslKerberosKinitCmd;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_KERBEROS_TICKET_RENEW_WINDOW_FACTOR"/>
        /// </summary>
        public double SaslKerberosTicketRenewWindowFactor { get { return GetProperty<double>(SaslConfigs.SASL_KERBEROS_TICKET_RENEW_WINDOW_FACTOR); } set { SetProperty(SaslConfigs.SASL_KERBEROS_TICKET_RENEW_WINDOW_FACTOR, value); } }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_KERBEROS_TICKET_RENEW_WINDOW_FACTOR"/>
        /// </summary>
        public SaslConfigsBuilder WithSaslKerberosTicketRenewWindowFactor(double saslKerberosTicketRenewWindowFactor)
        {
            var clone = Clone();
            clone.SaslKerberosTicketRenewWindowFactor = saslKerberosTicketRenewWindowFactor;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_KERBEROS_TICKET_RENEW_JITTER"/>
        /// </summary>
        public double SaslKerberosTicketRenewJitter { get { return GetProperty<double>(SaslConfigs.SASL_KERBEROS_TICKET_RENEW_JITTER); } set { SetProperty(SaslConfigs.SASL_KERBEROS_TICKET_RENEW_JITTER, value); } }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_KERBEROS_TICKET_RENEW_JITTER"/>
        /// </summary>
        public SaslConfigsBuilder WithSaslKerberosTicketRenewJitter(double saslKerberosTicketRenewJitter)
        {
            var clone = Clone();
            clone.SaslKerberosTicketRenewJitter = saslKerberosTicketRenewJitter;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_KERBEROS_MIN_TIME_BEFORE_RELOGIN"/>
        /// </summary>
        public long SaslKerberosMinTimeBeforeRelogin { get { return GetProperty<long>(SaslConfigs.SASL_KERBEROS_MIN_TIME_BEFORE_RELOGIN); } set { SetProperty(SaslConfigs.SASL_KERBEROS_MIN_TIME_BEFORE_RELOGIN, value); } }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_KERBEROS_MIN_TIME_BEFORE_RELOGIN"/>
        /// </summary>
        public SaslConfigsBuilder WithSaslKerberosMinTimeBeforeRelogin(long saslKerberosMinTimeBeforeRelogin)
        {
            var clone = Clone();
            clone.SaslKerberosMinTimeBeforeRelogin = saslKerberosMinTimeBeforeRelogin;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_LOGIN_REFRESH_WINDOW_FACTOR"/>
        /// </summary>
        public double SaslLoginRefreshWindowFactor { get { return GetProperty<double>(SaslConfigs.SASL_LOGIN_REFRESH_WINDOW_FACTOR); } set { SetProperty(SaslConfigs.SASL_LOGIN_REFRESH_WINDOW_FACTOR, value); } }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_LOGIN_REFRESH_WINDOW_FACTOR"/>
        /// </summary>
        public SaslConfigsBuilder WithSaslLoginRefreshWindowFactor(double saslLoginRefreshWindowFactor)
        {
            var clone = Clone();
            clone.SaslLoginRefreshWindowFactor = saslLoginRefreshWindowFactor;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_LOGIN_REFRESH_WINDOW_JITTER"/>
        /// </summary>
        public double SaslLoginRefreshWindowJitter { get { return GetProperty<double>(SaslConfigs.SASL_LOGIN_REFRESH_WINDOW_JITTER); } set { SetProperty(SaslConfigs.SASL_LOGIN_REFRESH_WINDOW_JITTER, value); } }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_LOGIN_REFRESH_WINDOW_JITTER"/>
        /// </summary>
        public SaslConfigsBuilder WithSaslLoginRefreshWindowJitter(double saslLoginRefreshWindowJitter)
        {
            var clone = Clone();
            clone.SaslLoginRefreshWindowJitter = saslLoginRefreshWindowJitter;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_LOGIN_REFRESH_MIN_PERIOD_SECONDS"/>
        /// </summary>
        public short SaslLoginRefreshMinPeriodSeconds { get { return GetProperty<short>(SaslConfigs.SASL_LOGIN_REFRESH_MIN_PERIOD_SECONDS); } set { SetProperty(SaslConfigs.SASL_LOGIN_REFRESH_MIN_PERIOD_SECONDS, value); } }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_LOGIN_REFRESH_MIN_PERIOD_SECONDS"/>
        /// </summary>
        public SaslConfigsBuilder WithSaslLoginRefreshMinPeriodSeconds(short saslLoginRefreshMinPeriodSeconds)
        {
            var clone = Clone();
            clone.SaslLoginRefreshMinPeriodSeconds = saslLoginRefreshMinPeriodSeconds;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_LOGIN_REFRESH_BUFFER_SECONDS"/>
        /// </summary>
        public short SaslLoginRefreshBufferSeconds { get { return GetProperty<short>(SaslConfigs.SASL_LOGIN_REFRESH_BUFFER_SECONDS); } set { SetProperty(SaslConfigs.SASL_LOGIN_REFRESH_BUFFER_SECONDS, value); } }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_LOGIN_REFRESH_BUFFER_SECONDS"/>
        /// </summary>
        public SaslConfigsBuilder WithSaslLoginRefreshBufferSeconds(short saslLoginRefreshBufferSeconds)
        {
            var clone = Clone();
            clone.SaslLoginRefreshBufferSeconds = saslLoginRefreshBufferSeconds;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_MECHANISM"/>
        /// </summary>
        public string SaslMechanism { get { return GetProperty<string>(SaslConfigs.SASL_MECHANISM); } set { SetProperty(SaslConfigs.SASL_MECHANISM, value); } }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_MECHANISM"/>
        /// </summary>
        public SaslConfigsBuilder WithSaslMechanism(string saslMechanism)
        {
            var clone = Clone();
            clone.SaslMechanism = saslMechanism;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_JAAS_CONFIG"/>
        /// </summary>
        public Password SaslJaasConfig { get { return GetProperty<Password>(SaslConfigs.SASL_JAAS_CONFIG); } set { SetProperty(SaslConfigs.SASL_JAAS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_JAAS_CONFIG"/>
        /// </summary>
        public SaslConfigsBuilder WithSaslJaasConfig(Password saslJaasConfig)
        {
            var clone = Clone();
            clone.SaslJaasConfig = saslJaasConfig;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_CLIENT_CALLBACK_HANDLER_CLASS"/>
        /// </summary>
        public Class SaslClientCallbackHandlerClass { get { return GetProperty<Class>(SaslConfigs.SASL_CLIENT_CALLBACK_HANDLER_CLASS); } set { SetProperty(SaslConfigs.SASL_CLIENT_CALLBACK_HANDLER_CLASS, value); } }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_CLIENT_CALLBACK_HANDLER_CLASS"/>
        /// </summary>
        public SaslConfigsBuilder WithSaslClientCallbackHandlerClass(Class saslClientCallbackHandlerClass)
        {
            var clone = Clone();
            clone.SaslClientCallbackHandlerClass = saslClientCallbackHandlerClass;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_LOGIN_CALLBACK_HANDLER_CLASS"/>
        /// </summary>
        public Class SaslLoginCallbackHandlerClass { get { return GetProperty<Class>(SaslConfigs.SASL_LOGIN_CALLBACK_HANDLER_CLASS); } set { SetProperty(SaslConfigs.SASL_LOGIN_CALLBACK_HANDLER_CLASS, value); } }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_LOGIN_CALLBACK_HANDLER_CLASS"/>
        /// </summary>
        public SaslConfigsBuilder WithSaslLoginCallbackHandlerClass(Class saslLoginCallbackHandlerClass)
        {
            var clone = Clone();
            clone.SaslLoginCallbackHandlerClass = saslLoginCallbackHandlerClass;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_LOGIN_CLASS"/>
        /// </summary>
        public Class SaslLoginClass { get { return GetProperty<Class>(SaslConfigs.SASL_LOGIN_CLASS); } set { SetProperty(SaslConfigs.SASL_LOGIN_CLASS, value); } }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_LOGIN_CLASS"/>
        /// </summary>
        public SaslConfigsBuilder WithSaslLoginClass(Class saslLoginClass)
        {
            var clone = Clone();
            clone.SaslLoginClass = saslLoginClass;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_LOGIN_CONNECT_TIMEOUT_MS"/>
        /// </summary>
        public int SaslLoginConnectTimeoutMs { get { return GetProperty<int>(SaslConfigs.SASL_LOGIN_CONNECT_TIMEOUT_MS); } set { SetProperty(SaslConfigs.SASL_LOGIN_CONNECT_TIMEOUT_MS, value); } }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_LOGIN_CONNECT_TIMEOUT_MS"/>
        /// </summary>
        public SaslConfigsBuilder WithSaslLoginConnectTimeoutMs(int saslLoginConnectTimeoutMs)
        {
            var clone = Clone();
            clone.SaslLoginConnectTimeoutMs = saslLoginConnectTimeoutMs;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_LOGIN_READ_TIMEOUT_MS"/>
        /// </summary>
        public int SaslLoginReadTimeoutMs { get { return GetProperty<int>(SaslConfigs.SASL_LOGIN_READ_TIMEOUT_MS); } set { SetProperty(SaslConfigs.SASL_LOGIN_READ_TIMEOUT_MS, value); } }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_LOGIN_READ_TIMEOUT_MS"/>
        /// </summary>
        public SaslConfigsBuilder WithSaslLoginReadTimeoutMs(int saslLoginReadTimeoutMs)
        {
            var clone = Clone();
            clone.SaslLoginReadTimeoutMs = saslLoginReadTimeoutMs;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_LOGIN_RETRY_BACKOFF_MAX_MS"/>
        /// </summary>
        public long SaslLoginRetryBackoffMaxMs { get { return GetProperty<long>(SaslConfigs.SASL_LOGIN_RETRY_BACKOFF_MAX_MS); } set { SetProperty(SaslConfigs.SASL_LOGIN_RETRY_BACKOFF_MAX_MS, value); } }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_LOGIN_RETRY_BACKOFF_MAX_MS"/>
        /// </summary>
        public SaslConfigsBuilder WithSaslLoginRetryBackoffMaxMs(long saslLoginRetryBackoffMaxMs)
        {
            var clone = Clone();
            clone.SaslLoginRetryBackoffMaxMs = saslLoginRetryBackoffMaxMs;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_LOGIN_RETRY_BACKOFF_MS"/>
        /// </summary>
        public long SaslLoginRetryBackoffMs { get { return GetProperty<long>(SaslConfigs.SASL_LOGIN_RETRY_BACKOFF_MS); } set { SetProperty(SaslConfigs.SASL_LOGIN_RETRY_BACKOFF_MS, value); } }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_LOGIN_RETRY_BACKOFF_MS"/>
        /// </summary>
        public SaslConfigsBuilder WithSaslLoginRetryBackoffMs(long saslLoginRetryBackoffMs)
        {
            var clone = Clone();
            clone.SaslLoginRetryBackoffMs = saslLoginRetryBackoffMs;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_OAUTHBEARER_SCOPE_CLAIM_NAME"/>
        /// </summary>
        public string SaslOauthBearerScopeClaimName { get { return GetProperty<string>(SaslConfigs.SASL_OAUTHBEARER_SCOPE_CLAIM_NAME); } set { SetProperty(SaslConfigs.SASL_OAUTHBEARER_SCOPE_CLAIM_NAME, value); } }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_OAUTHBEARER_SCOPE_CLAIM_NAME"/>
        /// </summary>
        public SaslConfigsBuilder WithSaslOauthBearerScopeClaimName(string saslOauthBearerScopeClaimName)
        {
            var clone = Clone();
            clone.SaslOauthBearerScopeClaimName = saslOauthBearerScopeClaimName;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_OAUTHBEARER_SUB_CLAIM_NAME"/>
        /// </summary>
        public string SaslOauthBearerSubClaimName { get { return GetProperty<string>(SaslConfigs.SASL_OAUTHBEARER_SUB_CLAIM_NAME); } set { SetProperty(SaslConfigs.SASL_OAUTHBEARER_SUB_CLAIM_NAME, value); } }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_OAUTHBEARER_SUB_CLAIM_NAME"/>
        /// </summary>
        public SaslConfigsBuilder WithSaslOauthBearerSubClaimName(string saslOauthBearerSubClaimName)
        {
            var clone = Clone();
            clone.SaslOauthBearerSubClaimName = saslOauthBearerSubClaimName;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_OAUTHBEARER_TOKEN_ENDPOINT_URL"/>
        /// </summary>
        public string SaslOauthBearerTokenEndpointUrl { get { return GetProperty<string>(SaslConfigs.SASL_OAUTHBEARER_TOKEN_ENDPOINT_URL); } set { SetProperty(SaslConfigs.SASL_OAUTHBEARER_TOKEN_ENDPOINT_URL, value); } }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_OAUTHBEARER_TOKEN_ENDPOINT_URL"/>
        /// </summary>
        public SaslConfigsBuilder WithSaslOauthBearerTokenEndpointUrl(string saslOauthBearerTokenEndpointUrl)
        {
            var clone = Clone();
            clone.SaslOauthBearerTokenEndpointUrl = saslOauthBearerTokenEndpointUrl;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_OAUTHBEARER_JWKS_ENDPOINT_URL"/>
        /// </summary>
        public string SaslOauthBearerJwksEndpointUrl { get { return GetProperty<string>(SaslConfigs.SASL_OAUTHBEARER_JWKS_ENDPOINT_URL); } set { SetProperty(SaslConfigs.SASL_OAUTHBEARER_JWKS_ENDPOINT_URL, value); } }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_OAUTHBEARER_JWKS_ENDPOINT_URL"/>
        /// </summary>
        public SaslConfigsBuilder WithSaslOauthBearerJwksEndpointUrl(string saslOauthBearerJwksEndpointUrl)
        {
            var clone = Clone();
            clone.SaslOauthBearerJwksEndpointUrl = saslOauthBearerJwksEndpointUrl;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_OAUTHBEARER_JWKS_ENDPOINT_REFRESH_MS"/>
        /// </summary>
        public long SaslOauthBearerJwksEndpointRefreshMs { get { return GetProperty<long>(SaslConfigs.SASL_OAUTHBEARER_JWKS_ENDPOINT_REFRESH_MS); } set { SetProperty(SaslConfigs.SASL_OAUTHBEARER_JWKS_ENDPOINT_REFRESH_MS, value); } }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_OAUTHBEARER_JWKS_ENDPOINT_REFRESH_MS"/>
        /// </summary>
        public SaslConfigsBuilder WithSaslOauthBearerJwksEndpointRefreshMs(long saslOauthBearerJwksEndpointRefreshMs)
        {
            var clone = Clone();
            clone.SaslOauthBearerJwksEndpointRefreshMs = saslOauthBearerJwksEndpointRefreshMs;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_OAUTHBEARER_JWKS_ENDPOINT_RETRY_BACKOFF_MAX_MS"/>
        /// </summary>
        public long SaslOauthBearerJwksEndpointRetryBackoffMaxMs { get { return GetProperty<long>(SaslConfigs.SASL_OAUTHBEARER_JWKS_ENDPOINT_RETRY_BACKOFF_MAX_MS); } set { SetProperty(SaslConfigs.SASL_OAUTHBEARER_JWKS_ENDPOINT_RETRY_BACKOFF_MAX_MS, value); } }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_OAUTHBEARER_JWKS_ENDPOINT_RETRY_BACKOFF_MAX_MS"/>
        /// </summary>
        public SaslConfigsBuilder WithSaslOauthBearerJwksEndpointRetryBackoffMaxMs(long saslOauthBearerJwksEndpointRetryBackoffMaxMs)
        {
            var clone = Clone();
            clone.SaslOauthBearerJwksEndpointRetryBackoffMaxMs = saslOauthBearerJwksEndpointRetryBackoffMaxMs;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_OAUTHBEARER_JWKS_ENDPOINT_RETRY_BACKOFF_MS"/>
        /// </summary>
        public long SaslOauthBearerJwksEndpointRetryBackoffMs { get { return GetProperty<long>(SaslConfigs.SASL_OAUTHBEARER_JWKS_ENDPOINT_RETRY_BACKOFF_MS); } set { SetProperty(SaslConfigs.SASL_OAUTHBEARER_JWKS_ENDPOINT_RETRY_BACKOFF_MS, value); } }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_OAUTHBEARER_JWKS_ENDPOINT_RETRY_BACKOFF_MS"/>
        /// </summary>
        public SaslConfigsBuilder WithSaslOauthBearerJwksEndpointRetryBackoffMs(long saslOauthBearerJwksEndpointRetryBackoffMs)
        {
            var clone = Clone();
            clone.SaslOauthBearerJwksEndpointRetryBackoffMs = saslOauthBearerJwksEndpointRetryBackoffMs;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_OAUTHBEARER_CLOCK_SKEW_SECONDS"/>
        /// </summary>
        public long SaslOauthBearerClockSkewSeconds { get { return GetProperty<long>(SaslConfigs.SASL_OAUTHBEARER_CLOCK_SKEW_SECONDS); } set { SetProperty(SaslConfigs.SASL_OAUTHBEARER_CLOCK_SKEW_SECONDS, value); } }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_OAUTHBEARER_CLOCK_SKEW_SECONDS"/>
        /// </summary>
        public SaslConfigsBuilder WithSaslOauthBearerClockSkewSeconds(long saslOauthBearerClockSkewSeconds)
        {
            var clone = Clone();
            clone.SaslOauthBearerClockSkewSeconds = saslOauthBearerClockSkewSeconds;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_OAUTHBEARER_EXPECTED_AUDIENCE"/>
        /// </summary>
        public List SaslOauthBearerExpectedAudience { get { return GetProperty<List>(SaslConfigs.SASL_OAUTHBEARER_EXPECTED_AUDIENCE); } set { SetProperty(SaslConfigs.SASL_OAUTHBEARER_EXPECTED_AUDIENCE, value); } }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_OAUTHBEARER_EXPECTED_AUDIENCE"/>
        /// </summary>
        public SaslConfigsBuilder WithSaslOauthBearerExpectedAudience(List saslOauthBearerExpectedAudience)
        {
            var clone = Clone();
            clone.SaslOauthBearerExpectedAudience = saslOauthBearerExpectedAudience;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_OAUTHBEARER_EXPECTED_ISSUER"/>
        /// </summary>
        public string SaslOauthBearerExpectedIssuer { get { return GetProperty<string>(SaslConfigs.SASL_OAUTHBEARER_EXPECTED_ISSUER); } set { SetProperty(SaslConfigs.SASL_OAUTHBEARER_EXPECTED_ISSUER, value); } }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_OAUTHBEARER_EXPECTED_ISSUER"/>
        /// </summary>
        public SaslConfigsBuilder WithSaslOauthBearerExpectedIssuer(string saslOauthBearerExpectedIssuer)
        {
            var clone = Clone();
            clone.SaslOauthBearerExpectedIssuer = saslOauthBearerExpectedIssuer;
            return clone;
        }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_OAUTHBEARER_HEADER_URLENCODE"/>
        /// </summary>
        public bool SaslOauthBearerHeaderUrlEncode { get { return GetProperty<bool>(SaslConfigs.SASL_OAUTHBEARER_HEADER_URLENCODE); } set { SetProperty(SaslConfigs.SASL_OAUTHBEARER_HEADER_URLENCODE, value); } }
        /// <summary>
        /// Manages <see cref="SaslConfigs.SASL_OAUTHBEARER_HEADER_URLENCODE"/>
        /// </summary>
        public SaslConfigsBuilder WithSaslOauthBearerHeaderUrlEncode(bool saslOauthBearerHeaderUrlEncode)
        {
            var clone = Clone();
            clone.SaslOauthBearerHeaderUrlEncode = saslOauthBearerHeaderUrlEncode;
            return clone;
        }
    }
}
