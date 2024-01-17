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

package org.mases.knet.connect;

// imported from org.slf4j.Logger
public interface KNetConnectLogging {
    boolean isTraceEnabled();

    void trace(String var1);

    void trace(String var1, Throwable var2);

    boolean isDebugEnabled();

    void debug(String var1);

    void debug(String var1, Throwable var2);

    boolean isInfoEnabled();

    void info(String var1);

    void info(String var1, Throwable var2);

    boolean isWarnEnabled();

    void warn(String var1);

    void warn(String var1, Throwable var2);

    boolean isErrorEnabled();

    void error(String var1);

    void error(String var1, Throwable var2);
}
