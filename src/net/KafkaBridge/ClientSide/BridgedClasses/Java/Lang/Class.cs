/*
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
using MASES.JCOBridge.C2JBridge.JVMInterop;

namespace MASES.KafkaBridge.Java.Lang
{
    public class Class : JVMBridgeBase<Class>
    {
        public override string ClassName => "java.lang.Class";

        public static Class ForName(string className)
        {
            return SExecute<Class>("forName", className);
        }

        public static Class<T> ForName<T>() where T : IJVMBridgeBase, new()
        {
            var className = new T().ClassName;
            var exType = SExecute("forName", className);
            return SExecute<Class<T>>("forName", className);
        }

        public string Name => IExecute<string>("getName");

        public bool IsAnnotation => IExecute<bool>("isAnnotation");

        // TO BE VERIFIED
        //public bool IsAnnotationPresent<T>(Class<T> annotationClass)
        //    where T : Annotation
        //{
        //    return IExecute<bool>("isAnnotationPresent", annotationClass.JVMType);
        //}

        public bool IsAnonymousClass => IExecute<bool>("isAnonymousClass");

        public bool IsArray => IExecute<bool>("isArray");

        public bool IsAssignableFrom(Class cls) => IExecute<bool>("isAssignableFrom", cls);

        public bool IsEnum => IExecute<bool>("isEnum");

        public bool IsInstance(object obj) => IExecute<bool>("isInstance", obj);

        public bool IsInterface => IExecute<bool>("isInterface");

        public bool IsLocalClass => IExecute<bool>("isLocalClass");

        public bool IsMemberClass => IExecute<bool>("isMemberClass");

        public bool IsPrimitive => IExecute<bool>("isPrimitive");

        public bool IsSynthetic => IExecute<bool>("isSynthetic");
    }

    public class Class<T> : Class
        where T : IJVMBridgeBase, new()
    {


        public IJavaType JVMType => (new T() as IJVMBridgeBaseStatic).Clazz;     
    }
}
