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

namespace Org.Apache.Kafka.Common.Metrics
{
    public class Quota : MASES.JCOBridge.C2JBridge.JVMBridgeBase<Quota>
    {
        public override string ClassName => "org.apache.kafka.common.metrics.Quota";

        public static Quota UpperBound(double upperBound)
        {
            return SExecute<Quota>("upperBound", upperBound);
        }

        public static Quota LowerBound(double lowerBound)
        {
            return SExecute<Quota>("lowerBound", lowerBound);
        }

        [System.Obsolete("This is not public in Apache Kafka API")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public Quota() { }

        public Quota(double bound, bool upper)
            :base(bound, upper)
        {
        }

        public bool IsUpperBound => IExecute<bool>("isUpperBound");

        public double Bound => IExecute<double>("bound");

        public bool Acceptable(double value)
        {
            return IExecute<bool>("acceptable", value);
        }
    }
}
