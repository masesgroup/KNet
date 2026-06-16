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
using MASES.JCOBridge.C2JBridge.JVMInterop;
using MASES.JNet.Specific.Extensions;

namespace Org.Apache.Kafka.Common.Header
{
    public partial class Headers
    {
        /// <summary>
        /// Helper to create <see cref="Headers"/>
        /// </summary>
        public static Headers Create()
        {
            return NewAndWrapsDirect<Headers>("org.apache.kafka.common.header.internals.RecordHeaders");
        }
        /// <summary>
        /// Helper to create <see cref="Headers"/>
        /// </summary>
        public static Headers Create(Header[] headers)
        {
            return NewAndWrapsDirect<Headers>("org.apache.kafka.common.header.internals.RecordHeaders", headers);
        }
        /// <summary>
        /// Helper to create <see cref="Headers"/>
        /// </summary>
        public static Headers Create(Iterable<Header> headers)
        {
            return NewAndWrapsDirect<Headers>("org.apache.kafka.common.header.internals.RecordHeaders", headers);
        }

        /// <summary>
        /// <see langword="void"/> version of <see cref="Add(String, byte[])"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <param name="arg1"><see cref="byte"/></param>
        /// <exception cref="Java.Lang.IllegalStateException"/>
        public void AddVoid(Java.Lang.String arg0, byte[] arg1)
        {
            Add(arg0, arg1).DisposeIfDisposable();
        }
        /// <summary>
        /// <see langword="void"/> version of <see cref="Add(Header)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Org.Apache.Kafka.Common.Header.Header"/></param>
        /// <exception cref="Java.Lang.IllegalStateException"/>
        public void AddVoid(Org.Apache.Kafka.Common.Header.Header arg0)
        {
            Add(arg0).DisposeIfDisposable();
        }
        /// <summary>
        /// <see langword="void"/> version of <see cref="Remove(String)"/>
        /// </summary>
        /// <param name="arg0"><see cref="Java.Lang.String"/></param>
        /// <exception cref="Java.Lang.IllegalStateException"/>
        public void RemoveVoid(Java.Lang.String arg0)
        {
            Remove(arg0).DisposeIfDisposable();
        }
    }
}
