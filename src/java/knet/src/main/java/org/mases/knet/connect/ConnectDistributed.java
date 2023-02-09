/*
 *  Copyright 2023 MASES s.r.l.
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

// Copied from original Apache Kafka source file ConnectDistributed.java

package org.mases.knet.connect;

import org.apache.kafka.common.utils.Exit;
import org.apache.kafka.common.utils.Time;
import org.apache.kafka.common.utils.Utils;
import org.apache.kafka.connect.runtime.Connect;
import org.apache.kafka.connect.runtime.WorkerInfo;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.util.Arrays;
import java.util.Collections;
import java.util.Map;

/**
 * <p>
 * Command line utility that runs Kafka Connect in distributed mode. In this mode, the process joints a group of other workers
 * and work is distributed among them. This is useful for running Connect as a service, where connectors can be
 * submitted to the cluster to be automatically executed in a scalable, distributed fashion. This also allows you to
 * easily scale out horizontally, elastically adding or removing capacity simply by starting or stopping worker
 * instances.
 * </p>
 */
public class ConnectDistributed {
    private static final Logger log = LoggerFactory.getLogger(ConnectDistributed.class);
    private static final String keyValueSeparator = "=";
    private static final String elementSeparator = "||";

    private final Time time = Time.SYSTEM;
    private final long initStart = time.hiResClockMs();

    public static void main(String[] args) {

        if (args.length < 1 || Arrays.asList(args).contains("--help")) {
            log.info("Usage: ConnectDistributed <Env of worker.properties>");
            Exit.exit(1);
        }

        try {
            WorkerInfo initInfo = new WorkerInfo();
            initInfo.logAll();

            String workerPropsEnv = args[0];
            String workerPropsData = System.getenv(workerPropsEnv);
            Map<String, String> workerProps = !workerPropsData.isEmpty() ?
                    Utils.parseMap(workerPropsData, keyValueSeparator, elementSeparator) : Collections.emptyMap();

            org.apache.kafka.connect.cli.ConnectDistributed connectDistributed = new org.apache.kafka.connect.cli.ConnectDistributed();
            Connect connect = connectDistributed.startConnect(workerProps);

            // Shutdown will be triggered by Ctrl-C or via HTTP shutdown request
            connect.awaitStop();

        } catch (Throwable t) {
            log.error("Stopping due to error", t);
            Exit.exit(2);
        }
    }
}