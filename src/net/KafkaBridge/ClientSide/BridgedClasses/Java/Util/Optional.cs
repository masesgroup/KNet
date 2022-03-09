﻿/*
*  Copyright 2022 MASES s.r.l.
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

namespace Java.Util
{
    public class Optional<T> : JVMBridgeBase<Optional<T>>
    {
        public override string ClassName => "java.util.Optional";

        public static Optional<T> Empty => SExecute<Optional<T>>("empty");

        public static Optional<T> Of(T value) => SExecute<Optional<T>>("of", value);

        public static Optional<T> OfNullable(T value) => SExecute<Optional<T>>("ofNullable", value);

        public bool IsPresent => IExecute<bool>("isPresent");

        public virtual T Get​() { return IExecute<T>("get"); }
    }
}

