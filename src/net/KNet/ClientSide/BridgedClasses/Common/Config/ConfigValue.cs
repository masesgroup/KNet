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

using Java.Util;
using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Common.Config
{
    public class ConfigValue : JVMBridgeBase<ConfigValue>
    {
        public override string ClassName => "org.apache.kafka.common.config.ConfigValue";

        [System.Obsolete("This is not public in Apache Kafka API")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public ConfigValue()
        {
        }

        public ConfigValue(string name)
            :base(name)
        {
        }

        public ConfigValue(string name, object value, List<object> recommendedValues, List<string> errorMessages)
            :base(name,  value,  recommendedValues,  errorMessages)
        {
        }

        public string Name => IExecute<string>("name");

        public object Value
        {
            get { return IExecute("value"); }
            set { IExecute("value", value); }
        }

        public List<object> RecommendedValues
        {
            get { return IExecute<List<object>>("recommendedValues"); }
            set { IExecute("recommendedValues", value); }
        }

        public List<string> ErrorMessages => IExecute<List<string>>("errorMessages");

        public bool Visible
        {
            get { return IExecute<bool>("visible"); }
            set { IExecute("visible", value); }
        }

        public void AddErrorMessage(string errorMessage) => IExecute("addErrorMessage", errorMessage);
    }
}
