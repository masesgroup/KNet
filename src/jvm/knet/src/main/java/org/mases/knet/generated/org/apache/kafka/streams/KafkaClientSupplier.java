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
*  This file is generated by MASES.JNetReflector (ver. 2.4.0.0)
*/

package org.mases.knet.generated.org.apache.kafka.streams;

public final class KafkaClientSupplier extends org.mases.jcobridge.JCListener implements org.apache.kafka.streams.KafkaClientSupplier {
    public KafkaClientSupplier(String key) throws org.mases.jcobridge.JCNativeException {
        super(key);
    }

    //@Override
    public org.apache.kafka.clients.consumer.Consumer getConsumer(java.util.Map arg0) {
        raiseEvent("getConsumer", arg0); Object retVal = getReturnData(); return (org.apache.kafka.clients.consumer.Consumer)retVal;
    }
    //@Override
    public org.apache.kafka.clients.consumer.Consumer getGlobalConsumer(java.util.Map arg0) {
        raiseEvent("getGlobalConsumer", arg0); Object retVal = getReturnData(); return (org.apache.kafka.clients.consumer.Consumer)retVal;
    }
    //@Override
    public org.apache.kafka.clients.consumer.Consumer getRestoreConsumer(java.util.Map arg0) {
        raiseEvent("getRestoreConsumer", arg0); Object retVal = getReturnData(); return (org.apache.kafka.clients.consumer.Consumer)retVal;
    }
    //@Override
    public org.apache.kafka.clients.producer.Producer getProducer(java.util.Map arg0) {
        raiseEvent("getProducer", arg0); Object retVal = getReturnData(); return (org.apache.kafka.clients.producer.Producer)retVal;
    }
    //@Override
    public org.apache.kafka.clients.admin.Admin getAdmin(java.util.Map arg0) {
        raiseEvent("getAdmin", arg0); Object retVal = getReturnData(); return (org.apache.kafka.clients.admin.Admin)retVal;
    }
    //@Override
    public org.apache.kafka.clients.admin.Admin getAdminDefault(java.util.Map arg0) {
        return org.apache.kafka.streams.KafkaClientSupplier.super.getAdmin(arg0);
    }

}