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

package org.mases.knet.generated.org.apache.kafka.clients.producer;

public final class Partitioner extends org.mases.jcobridge.JCListener implements org.apache.kafka.clients.producer.Partitioner {
    public Partitioner(String key) throws org.mases.jcobridge.JCNativeException {
        super(key);
    }

    //@Override
    public int partition(java.lang.String arg0, java.lang.Object arg1, byte[] arg2, java.lang.Object arg3, byte[] arg4, org.apache.kafka.common.Cluster arg5) {
        raiseEvent("partition", arg0, arg1, arg2, arg3, arg4, arg5); Object retVal = getReturnData(); return (int)retVal;
    }
    //@Override
    public void close() {
        raiseEvent("close");
    }
    //@Override
    public void configure(java.util.Map arg0) {
        raiseEvent("configure", arg0);
    }
    //@Override
    public void onNewBatch(java.lang.String arg0, org.apache.kafka.common.Cluster arg1, int arg2) {
        raiseEvent("onNewBatch", arg0, arg1, arg2);
    }
    //@Override
    public void onNewBatchDefault(java.lang.String arg0, org.apache.kafka.common.Cluster arg1, int arg2) {
        org.apache.kafka.clients.producer.Partitioner.super.onNewBatch(arg0, arg1, arg2);
    }

}