﻿/*
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

namespace MASES.KNet.Clients.Admin
{
    public class DeleteTopicsOptions : AbstractOptions<DeleteTopicsOptions>
    {
        public override string BridgeClassName => "org.apache.kafka.clients.admin.DeleteTopicsOptions";

        public new DeleteTopicsOptions TimeoutMs(int timeoutMs)
        {
            return IExecute<DeleteTopicsOptions>("timeoutMs", timeoutMs);
        }

        public DeleteTopicsOptions RetryOnQuotaViolation(bool validateOnly)
        {
            return IExecute<DeleteTopicsOptions>("retryOnQuotaViolation", validateOnly);
        }

        public bool ShouldRetryOnQuotaViolation => IExecute<bool>("shouldRetryOnQuotaViolation");
    }
}
