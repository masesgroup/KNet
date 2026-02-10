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

package org.mases.knet.developed.connect;

/*
 * All KNet Connect SDK object implements this interface for data exchange between JVM and CLR
 */
public interface KNetConnectDataExchange {
    /* Invoked from CLR to retrieve the object stored from CLR before a method invocation
     * @return the object stored from JVM can be used from CLR
     */
    Object getDataToExchange();

    /* Set the object from CLR to be used from the JVM
     * @param dte the object set from CLR
     */
    void setDataToExchange(Object dte);
}
