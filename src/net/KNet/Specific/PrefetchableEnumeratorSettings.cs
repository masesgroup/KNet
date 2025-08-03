/*
*  Copyright (c) 2021-2025 MASES s.r.l.
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

using MASES.JCOBridge.C2JBridge;
using System.Threading;

namespace MASES.KNet
{
    class PrefetchableEnumeratorSettings : IEnumerableExtension
    {
        public PrefetchableEnumeratorSettings()
        {
            UsePrefetch = true;
            UseThread = true;
            ThreadPriority = ThreadPriority.AboveNormal;
        }
        public bool UsePrefetch { get; set; }
        public bool UseThread { get; set; }
        public ThreadPriority ThreadPriority { get; set; }
        public IConverterBridge ConverterBridge { get; set; }
    }
}
