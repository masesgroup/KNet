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

package org.mases.knet.generated.org.apache.kafka.clients.consumer;

public final class ConsumerPartitionAssignor extends org.mases.jcobridge.JCListener implements org.apache.kafka.clients.consumer.ConsumerPartitionAssignor {
    public ConsumerPartitionAssignor(String key) throws org.mases.jcobridge.JCNativeException {
        super(key);
    }

    //@Override
    public java.lang.String name() {
        raiseEvent("name"); Object retVal = getReturnData(); return (java.lang.String)retVal;
    }
    //@Override
    public org.apache.kafka.clients.consumer.ConsumerPartitionAssignor.GroupAssignment assign(org.apache.kafka.common.Cluster arg0, org.apache.kafka.clients.consumer.ConsumerPartitionAssignor.GroupSubscription arg1) {
        raiseEvent("assign", arg0, arg1); Object retVal = getReturnData(); return (org.apache.kafka.clients.consumer.ConsumerPartitionAssignor.GroupAssignment)retVal;
    }
    //@Override
    public java.nio.ByteBuffer subscriptionUserData(java.util.Set arg0) {
        raiseEvent("subscriptionUserData", arg0); Object retVal = getReturnData(); return (java.nio.ByteBuffer)retVal;
    }
    //@Override
    public java.nio.ByteBuffer subscriptionUserDataDefault(java.util.Set arg0) {
        return org.apache.kafka.clients.consumer.ConsumerPartitionAssignor.super.subscriptionUserData(arg0);
    }
    //@Override
    public java.util.List supportedProtocols() {
        raiseEvent("supportedProtocols"); Object retVal = getReturnData(); return (java.util.List)retVal;
    }
    //@Override
    public java.util.List supportedProtocolsDefault() {
        return org.apache.kafka.clients.consumer.ConsumerPartitionAssignor.super.supportedProtocols();
    }
    //@Override
    public short version() {
        raiseEvent("version"); Object retVal = getReturnData(); return (short)retVal;
    }
    //@Override
    public short versionDefault() {
        return org.apache.kafka.clients.consumer.ConsumerPartitionAssignor.super.version();
    }
    //@Override
    public void onAssignment(org.apache.kafka.clients.consumer.ConsumerPartitionAssignor.Assignment arg0, org.apache.kafka.clients.consumer.ConsumerGroupMetadata arg1) {
        raiseEvent("onAssignment", arg0, arg1);
    }
    //@Override
    public void onAssignmentDefault(org.apache.kafka.clients.consumer.ConsumerPartitionAssignor.Assignment arg0, org.apache.kafka.clients.consumer.ConsumerGroupMetadata arg1) {
        org.apache.kafka.clients.consumer.ConsumerPartitionAssignor.super.onAssignment(arg0, arg1);
    }

}