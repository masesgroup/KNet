/*
 *  Copyright 2024 MASES s.r.l.
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

/*
*  This file is generated by MASES.JNetReflector (ver. 2.2.5.0)
*/

package org.mases.knet.generated.org.apache.kafka.common.serialization;

public final class Deserializer extends org.mases.jcobridge.JCListener implements org.apache.kafka.common.serialization.Deserializer {
    public Deserializer(String key) throws org.mases.jcobridge.JCNativeException {
        super(key);
    }

    //@Override
    public java.lang.Object deserialize(java.lang.String arg0, byte[] arg1) {
        raiseEvent("deserialize", arg0, arg1); Object retVal = getReturnData(); return (java.lang.Object)retVal;
    }
    //@Override
    public java.lang.Object deserialize(java.lang.String arg0, org.apache.kafka.common.header.Headers arg1, byte[] arg2) {
        raiseEvent("deserialize3", arg0, arg1, arg2); Object retVal = getReturnData(); return (java.lang.Object)retVal;
    }
    //@Override
    public java.lang.Object deserializeDefault(java.lang.String arg0, org.apache.kafka.common.header.Headers arg1, byte[] arg2) {
        return org.apache.kafka.common.serialization.Deserializer.super.deserialize(arg0, arg1, arg2);
    }
    //@Override
    public java.lang.Object deserialize(java.lang.String arg0, org.apache.kafka.common.header.Headers arg1, java.nio.ByteBuffer arg2) {
        raiseEvent("deserialize3_2", arg0, arg1, arg2); Object retVal = getReturnData(); return (java.lang.Object)retVal;
    }
    //@Override
    public java.lang.Object deserializeDefault(java.lang.String arg0, org.apache.kafka.common.header.Headers arg1, java.nio.ByteBuffer arg2) {
        return org.apache.kafka.common.serialization.Deserializer.super.deserialize(arg0, arg1, arg2);
    }
    //@Override
    public void close() {
        raiseEvent("close");
    }
    //@Override
    public void closeDefault() {
        org.apache.kafka.common.serialization.Deserializer.super.close();
    }
    //@Override
    public void configure(java.util.Map arg0, boolean arg1) {
        raiseEvent("configure", arg0, arg1);
    }
    //@Override
    public void configureDefault(java.util.Map arg0, boolean arg1) {
        org.apache.kafka.common.serialization.Deserializer.super.configure(arg0, arg1);
    }

}