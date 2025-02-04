/*
*  Copyright 2025 MASES s.r.l.
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

using Org.Apache.Kafka.Clients.Admin;

namespace MASES.KNet.Admin
{
    /// <summary>
    /// Common builder for <see cref="AdminClientConfig"/>
    /// </summary>
    public class AdminClientConfigBuilder : CommonClientConfigsBuilder<AdminClientConfigBuilder>
    {
        /// <summary>
        /// Manages <see cref="AdminClientConfig.BOOTSTRAP_CONTROLLERS_CONFIG"/>
        /// </summary>
        public string BootstrapControllers { get { return GetProperty<string>(AdminClientConfig.BOOTSTRAP_CONTROLLERS_CONFIG); } set { SetProperty(AdminClientConfig.BOOTSTRAP_CONTROLLERS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="AdminClientConfig.BOOTSTRAP_CONTROLLERS_CONFIG"/>
        /// </summary>
        public AdminClientConfigBuilder WithBootstrapControllers(string bootstrapControllers)
        {
            var clone = Clone();
            clone.BootstrapControllers = bootstrapControllers;
            return clone;
        }

        /// <summary>
        /// Manages <see cref="AdminClientConfig.SECURITY_PROVIDERS_CONFIG"/>
        /// </summary>
        public string SecurityProviders { get { return GetProperty<string>(AdminClientConfig.SECURITY_PROVIDERS_CONFIG); } set { SetProperty(AdminClientConfig.SECURITY_PROVIDERS_CONFIG, value); } }
        /// <summary>
        /// Manages <see cref="AdminClientConfig.SECURITY_PROVIDERS_CONFIG"/>
        /// </summary>
        public AdminClientConfigBuilder WithSecurityProviders(string securityProviders)
        {
            var clone = Clone();
            clone.SecurityProviders = securityProviders;
            return clone;
        }
    }
}
