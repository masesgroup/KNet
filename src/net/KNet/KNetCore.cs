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

using MASES.CLIParser;
using MASES.KNet.Clients.Consumer;
using MASES.KNet.Clients.Producer;
using MASES.KNet.Common;
using MASES.KNet.Common.Errors;
using MASES.KNet.Connect.Errors;
using MASES.KNet.Streams.Errors;
using System;
using System.Collections.Generic;
using System.IO;
using MASES.JNet;

namespace MASES.KNet
{
    /// <summary>
    /// Public entry point of <see cref="KNetCore{T}"/>
    /// </summary>
    /// <typeparam name="T">A class which inherits from <see cref="KNetCore{T}"/></typeparam>
    public class KNetCore<T> : JNetCore<T>
        where T : KNetCore<T>
    {
        /// <inheritdoc cref="JNetCore{T}.CommandLineArguments"/>
        public override IEnumerable<IArgumentMetadata> CommandLineArguments
        {
            get
            {
                var lst = new List<IArgumentMetadata>(base.CommandLineArguments);
                lst.AddRange(new IArgumentMetadata[]
                {
                    new ArgumentMetadata<string>()
                    {
                        Name = CLIParam.ClassToRun,
                        Help = "The class to be instantiated.",
                    },
                    new ArgumentMetadata<string>()
                    {
                        Name = CLIParam.ScalaVersion,
                        Default = Const.DefaultScalaVersion,
                        Help = "The version of scala to be used.",
                    },
                    new ArgumentMetadata<string>()
                    {
                        Name = CLIParam.KafkaLocation,
                        Default = Const.DefaultRootPath,
                        Help = "The folder where Kafka package is available. Default consider the application use the Jars in the package.",
                    },
                    new ArgumentMetadata<string>()
                    {
                        Name = CLIParam.Log4JConfiguration,
                        Default = Const.DefaultLog4JPath,
                        Help = "The file containing the configuration of log4j.",
                    },
                    new ArgumentMetadata<string>()
                    {
                        Name = CLIParam.LogPath,
                        Default = Const.DefaultLogPath,
                        Help = "The path for log.",
                    },
                });
                return lst;
            }
        }
        /// <summary>
        /// Public initializer
        /// </summary>
        public KNetCore()
        {
            #region Base Exceptions

            JCOBridge.C2JBridge.JCOBridge.RegisterException<KafkaException>();
            JCOBridge.C2JBridge.JCOBridge.RegisterException<InvalidRecordException>();

            #endregion

            #region Common Exceptions

            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(ApiException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(AuthenticationException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(AuthorizationException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(BrokerIdNotRegisteredException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(BrokerNotAvailableException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(ClusterAuthorizationException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(ConcurrentTransactionsException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(ControllerMovedException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(CoordinatorLoadInProgressException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(CoordinatorNotAvailableException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(CorruptRecordException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(DelegationTokenAuthorizationException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(DelegationTokenDisabledException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(DelegationTokenExpiredException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(DelegationTokenNotFoundException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(DelegationTokenOwnerMismatchException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(DisconnectException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(DuplicateBrokerRegistrationException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(DuplicateResourceException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(DuplicateSequenceException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(ElectionNotNeededException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(EligibleLeadersNotAvailableException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(FeatureUpdateFailedException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(FencedInstanceIdException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(FencedLeaderEpochException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(FetchSessionIdNotFoundException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(GroupAuthorizationException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(GroupIdNotFoundException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(GroupMaxSizeReachedException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(GroupNotEmptyException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(GroupSubscribedToTopicException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(IllegalGenerationException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(IllegalSaslStateException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InconsistentClusterIdException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InconsistentGroupProtocolException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InconsistentTopicIdException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InconsistentVoterSetException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InterruptException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InvalidCommitOffsetSizeException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InvalidConfigurationException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InvalidFetchSessionEpochException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InvalidFetchSizeException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InvalidGroupIdException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InvalidMetadataException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(Clients.Consumer.InvalidOffsetException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InvalidPartitionsException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InvalidPidMappingException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InvalidPrincipalTypeException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InvalidProducerEpochException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InvalidReplicaAssignmentException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InvalidReplicationFactorException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InvalidRequestException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InvalidRequiredAcksException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InvalidSessionTimeoutException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InvalidTimestampException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InvalidTopicException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InvalidTxnStateException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InvalidTxnTimeoutException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InvalidUpdateVersionException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(KafkaStorageException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(LeaderNotAvailableException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(ListenerNotFoundException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(LogDirNotFoundException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(MemberIdRequiredException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(NetworkException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(NoReassignmentInProgressException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(NotControllerException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(NotCoordinatorException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(NotEnoughReplicasAfterAppendException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(NotEnoughReplicasException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(NotLeaderForPartitionException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(NotLeaderOrFollowerException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(OffsetMetadataTooLarge));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(OffsetNotAvailableException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(Common.Errors.OffsetOutOfRangeException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(OperationNotAttemptedException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(OutOfOrderSequenceException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(PolicyViolationException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(PositionOutOfRangeException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(PreferredLeaderNotAvailableException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(PrincipalDeserializationException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(ProducerFencedException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(ReassignmentInProgressException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(RebalanceInProgressException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(RecordBatchTooLargeException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(RecordDeserializationException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(RecordTooLargeException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(ReplicaNotAvailableException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(ResourceNotFoundException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(Common.Errors.RetriableException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(SaslAuthenticationException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(SecurityDisabledException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(SerializationException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(SnapshotNotFoundException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(SslAuthenticationException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(StaleBrokerEpochException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(ThrottlingQuotaExceededException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(Common.Errors.TimeoutException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(TopicAuthorizationException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(TopicDeletionDisabledException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(TopicExistsException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(TransactionAbortedException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(TransactionalIdAuthorizationException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(TransactionalIdNotFoundException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(TransactionCoordinatorFencedException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(UnacceptableCredentialException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(UnknownLeaderEpochException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(UnknownMemberIdException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(UnknownProducerIdException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(UnknownServerException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(UnknownTopicIdException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(UnknownTopicOrPartitionException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(UnstableOffsetCommitException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(UnsupportedByAuthenticationException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(UnsupportedCompressionTypeException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(UnsupportedForMessageFormatException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(UnsupportedSaslMechanismException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(UnsupportedVersionException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(WakeupException));

            #endregion

            #region Consumer Exceptions

            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(CommitFailedException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(Clients.Consumer.InvalidOffsetException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(LogTruncationException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(NoOffsetForPartitionException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(Clients.Consumer.OffsetOutOfRangeException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(RetriableCommitFailedException));

            #endregion

            #region Producer Exceptions

            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(BufferExhaustedException));

            #endregion

            #region Streams Exceptions
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(BrokerNotFoundException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InvalidStateStoreException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(InvalidStateStorePartitionException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(LockException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(MissingSourceTopicException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(ProcessorStateException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(StateStoreMigratedException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(StateStoreNotAvailableException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(StreamsException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(StreamsNotStartedException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(StreamsRebalancingException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(TaskAssignmentException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(TaskCorruptedException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(TaskIdFormatException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(TaskMigratedException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(TopologyException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(UnknownStateStoreException));
            #endregion

            #region Connect Exceptions
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(AlreadyExistsException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(ConnectException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(DataException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(IllegalWorkerStateException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(NotFoundException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(Connect.Errors.RetriableException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(SchemaBuilderException));
            JCOBridge.C2JBridge.JCOBridge.RegisterException(typeof(SchemaProjectorException));
            #endregion
        }

        /// <inheritdoc cref="JNetCore{T}.GlobalHeapSize" />
        public override string GlobalHeapSize { get { return null; } }
        /// <inheritdoc cref="JNetCore{T}.InitialHeapSize" />
        public override string InitialHeapSize { get { return null; } }
        /// <inheritdoc cref="JNetCore{T}.ProcessCommandLine" />
        protected override string[] ProcessCommandLine()
        {
            var result = base.ProcessCommandLine();
            GlobalScalaVersion = Const.DefaultScalaVersion;
            GlobalRootPath = Const.DefaultRootPath;
            GlobalLogPath = Const.DefaultLogPath;

            var classToRun = ParsedArgs.Get<string>(CLIParam.ClassToRun);
            GlobalRootPath = ParsedArgs.Get<string>(CLIParam.KafkaLocation);
            GlobalLog4JPath = ParsedArgs.Get<string>(CLIParam.Log4JConfiguration);
            GlobalLogPath = ParsedArgs.Get<string>(CLIParam.LogPath);
            GlobalScalaVersion = ParsedArgs.Get<string>(CLIParam.ScalaVersion);

            if (!string.IsNullOrEmpty(classToRun))
            {
                Type type = null;

                foreach (var item in typeof(KNetCore).Assembly.ExportedTypes)
                {
                    if (item.Name == classToRun || item.FullName == classToRun)
                    {
                        type = item;
                        break;
                    }
                }
                MainClassToRun = type ?? throw new ArgumentException($"Requested class {classToRun} is not a valid class name.");
            }

            switch (classToRun)
            {
                case "VerifiableConsumer":
                    ApplicationHeapSize = "512M";
                    break;
                case "VerifiableProducer":
                    ApplicationHeapSize = "512M";
                    break;
                case "StreamsResetter":
                    ApplicationHeapSize = "512M";
                    break;
                case "ZooKeeperStart":
                    ApplicationHeapSize = "512M";
                    ApplicationInitialHeapSize = "512M";
                    break;
                case "ZooKeeperShell":
                    ApplicationHeapSize = "512M";
                    ApplicationInitialHeapSize = "512M";
                    break;
                case "KafkaStart":
                    ApplicationHeapSize = Environment.Is64BitOperatingSystem ? "1G" : "512M";
                    ApplicationInitialHeapSize = Environment.Is64BitOperatingSystem ? "1G" : "512M";
                    break;
                case "ConnectStandalone":
                    {
                        ApplicationHeapSize = "2G";
                        ApplicationInitialHeapSize = "256M";
                        var tmpResult = new List<string>(result);
                        if (tmpResult.Contains("-daemon"))
                        {
                            tmpResult.Add("-name");
                            tmpResult.Add("connectStandalone");
                        }
                        result = tmpResult.ToArray();
                    }
                    break;
                case "ConnectDistributed":
                    {
                        ApplicationHeapSize = "2G";
                        ApplicationInitialHeapSize = "256M";
                        var tmpResult = new List<string>(result);
                        if (tmpResult.Contains("-daemon"))
                        {
                            tmpResult.Add("-name");
                            tmpResult.Add("connectDistributed");
                        }
                        result = tmpResult.ToArray();
                    }
                    break;
                default:
                    ApplicationHeapSize ??= "256M";
                    break;
            }

            return result;
        }

        /// <summary>
        /// Sets the <see cref="Type"/> to be invoked at startup
        /// </summary>
        public static Type MainClassToRun { get; protected set; }

        /// <summary>
        /// Sets the global value of root path
        /// </summary>
        public static string GlobalRootPath { get; set; }

        /// <summary>
        /// Sets the global value of log4j path
        /// </summary>
        public static string GlobalLog4JPath { get; set; }

        /// <summary>
        /// Sets the global value of log path
        /// </summary>
        public static string GlobalLogPath { get; set; }

        /// <summary>
        /// Sets the global value of root path
        /// </summary>
        public static string GlobalScalaVersion { get; set; }

        /// <summary>
        /// The Scala version to be used
        /// </summary>
        public virtual string ScalaVersion { get { return GlobalScalaVersion; } }

        /// <summary>
        /// The Scala binary version to be used
        /// </summary>
        public virtual string ScalaBinaryVersion { get { var ver = Version.Parse(ScalaVersion); return (ver.Revision == 0) ? string.Format("{0}", ver.Minor) : string.Format("{0}.{1}", ver.Minor, ver.Revision); } }

        /// <summary>
        /// The root path where Apache Kafka is installed
        /// </summary>
        public virtual string RootPath { get { return GlobalRootPath; } }

        /// <summary>
        /// The log folder
        /// </summary>
        public virtual string LogDir { get { return GlobalLogPath; } }

        /// <summary>
        /// The log4j configuration
        /// </summary>
        public virtual string Log4JOpts { get { return string.Format("file:{0}", Path.Combine(RootPath, "config", "tools-log4j.properties")); } }

        /// <inheritdoc cref="JNetCore{T}.PerformanceOptions"/>
        protected override IList<string> PerformanceOptions
        {
            get
            {
                var lst = new List<string>(base.PerformanceOptions);
                lst.AddRange(new string[]
                {
                    // "-server", <- Disabled because it avoids starts of embedded JVM
                    "-XX:+UseG1GC",
                    "-XX:MaxGCPauseMillis=20",
                    "-XX:InitiatingHeapOccupancyPercent=35",
                    "-XX:+ExplicitGCInvokesConcurrent",
                });
                return lst;
            }
        }

        /// <summary>
        /// The path where Apache Kafka core dependencies Jars are installed
        /// </summary>
        public virtual string CoreDependenciesPath { get { return Path.Combine(RootPath, "core", "build", "dependant-libs-" + ScalaVersion, "*.jar"); } }

        /// <summary>
        /// The path where Apache Kafka examples Jars are installed
        /// </summary>
        public virtual string ExamplesPath { get { return Path.Combine(RootPath, "examples", "build", "libs", "kafka-examples*.jar"); } }

        /// <summary>
        /// The path where Apache Kafka clients Jars are installed
        /// </summary>
        public virtual string ClientsPath { get { return Path.Combine(RootPath, "clients", "build", "libs", "kafka-clients*.jar"); } }
        /// <summary>
        /// The path where Apache Kafka Streams Jars are installed
        /// </summary>
        public virtual string StreamsPath { get { return Path.Combine(RootPath, "streams", "build", "libs", "kafka-streams*.jar"); } }

        /// <summary>
        /// The path where Apache Kafka Streams examples Jars are installed
        /// </summary>
        public virtual string StreamsExamplePath { get { return Path.Combine(RootPath, "streams", "examples", "build", "libs", "kafka-streams-examples*.jar"); } }

        /// <summary>
        /// The path where Apache Kafka Streams dependencies Jars are installed
        /// </summary>
        public virtual string StreamsDependenciesPath { get { return Path.Combine(RootPath, "streams", "build", "dependant-libs-" + ScalaVersion, "rocksdb*.jar"); } }

        /// <summary>
        /// The path where Apache Kafka tools Jars are installed
        /// </summary>
        public virtual string ToolsPath { get { return Path.Combine(RootPath, "tools", "build", "libs", "kafka-tools*.jar"); } }

        /// <summary>
        /// The path where Apache Kafka tools Jars are installed
        /// </summary>
        public virtual string ToolsDependenciesPath { get { return Path.Combine(RootPath, "tools", "build", "dependant-libs-" + ScalaVersion, "*.jar"); } }

        /// <summary>
        /// The path where Apache Kafka Connect API Jars are installed
        /// </summary>
        public virtual string ConnectApiPath { get { return Path.Combine(RootPath, "connect", "api", "build", "libs", "connect-api*.jar"); } }

        /// <summary>
        /// The path where Apache Kafka Connect API dependencies Jars are installed
        /// </summary>
        public virtual string ConnectApiDependenciesPath { get { return Path.Combine(RootPath, "connect", "api", "build", "dependant-libs", "*"); } }

        /// <summary>
        /// The path where Apache Kafka Connect runtime Jars are installed
        /// </summary>
        public virtual string ConnectRuntimePath { get { return Path.Combine(RootPath, "connect", "runtime", "build", "libs", "connect-runtime*.jar"); } }

        /// <summary>
        /// The path where Apache Kafka Connect runtime dependencies Jars are installed
        /// </summary>
        public virtual string ConnectRuntimeDependenciesPath { get { return Path.Combine(RootPath, "connect", "runtime", "build", "dependant-libs", "*"); } }

        /// <summary>
        /// The path where Apache Kafka Connect file Jars are installed
        /// </summary>
        public virtual string ConnectFilePath { get { return Path.Combine(RootPath, "connect", "file", "build", "libs", "connect-file*.jar"); } }

        /// <summary>
        /// The path where Apache Kafka Connect file dependencies Jars are installed
        /// </summary>
        public virtual string ConnectFileDependenciesPath { get { return Path.Combine(RootPath, "connect", "file", "build", "dependant-libs", "*"); } }

        /// <summary>
        /// The path where Apache Kafka Connect json Jars are installed
        /// </summary>
        public virtual string ConnectJsonPath { get { return Path.Combine(RootPath, "connect", "json", "build", "libs", "connect-json*.jar"); } }

        /// <summary>
        /// The path where Apache Kafka Connect json dependencies Jars are installed
        /// </summary>
        public virtual string ConnectJsonDependenciesPath { get { return Path.Combine(RootPath, "connect", "json", "build", "dependant-libs", "*"); } }

        /// <summary>
        /// The path where Apache Kafka Connect tools Jars are installed
        /// </summary>
        public virtual string ConnectToolsPath { get { return Path.Combine(RootPath, "connect", "tools", "build", "libs", "connect-tools*.jar"); } }

        /// <summary>
        /// The path where Apache Kafka Connect tools dependencies Jars are installed
        /// </summary>
        public virtual string ConnectToolsDependenciesPath { get { return Path.Combine(RootPath, "connect", "tools", "build", "dependant-libs", "*"); } }

        /// <summary>
        /// The path where Apache Kafka tools Jars are installed
        /// </summary>
        public virtual string ExtraClassPath { get { return string.Empty; } }

        /// <summary>
        /// The path where Apache Kafka libs Jars are installed
        /// </summary>
        public virtual string ReleasePath { get { return Path.Combine(RootPath, "libs", "*"); } }

        /// <summary>
        /// The path where Apache Kafka additional Jars are installed
        /// </summary>
        public virtual string ReleaseAdditionalPath { get { return Path.Combine(RootPath, "core", "build", "libs", "kafka_" + ScalaBinaryVersion + "*.jar"); } }

        /// <inheritdoc cref="JNetCore{T}.Options"/>
        protected override IDictionary<string, string> Options
        {
            get
            {
                if (!Directory.Exists(LogDir)) Directory.CreateDirectory(LogDir);

                IDictionary<string, string> options = new Dictionary<string, string>(base.Options)
                {
                    { "-Dcom.sun.management.jmxremote", null },
                    { "com.sun.management.jmxremote.authenticate", "false" },
                    { "com.sun.management.jmxremote.ssl", "false" },
                    { "log4j.configuration", string.IsNullOrEmpty(GlobalLog4JPath) ? ((GlobalRootPath == Const.DefaultRootPath) ? Log4JOpts : null) : $"file:{GlobalLog4JPath}"},
                    { "kafka.logs.dir", LogDir},
                    { "java.awt.headless", "true" },
                    { "-Xmx" + ApplicationHeapSize, null},
                };

                if (!string.IsNullOrEmpty(ApplicationInitialHeapSize))
                {
                    options.Add("-Xms" + ApplicationInitialHeapSize, null);
                }

                return options;
            }
        }

        /// <inheritdoc cref="JNetCore{T}.PathToParse"/>
        protected override IList<string> PathToParse => new List<string>(new string[]
        {
            RootPath != null ? Path.Combine(RootPath, "*.jar") : RootPath,
            CoreDependenciesPath,
            ExamplesPath,
            ClientsPath,
            StreamsPath,
            StreamsExamplePath,
            StreamsDependenciesPath,
            ToolsPath,
            ToolsDependenciesPath,
            ConnectApiPath,
            ConnectApiDependenciesPath,
            ConnectRuntimePath,
            ConnectRuntimeDependenciesPath,
            ConnectFilePath,
            ConnectFileDependenciesPath,
            ConnectJsonPath,
            ConnectJsonDependenciesPath,
            ConnectToolsPath,
            ConnectToolsDependenciesPath,
            ReleasePath,
            ReleaseAdditionalPath,
        });
    }
    /// <summary>
    /// Directly usable implementation of <see cref="KNetCore{T}"/>
    /// </summary>
    public class KNetCore : KNetCore<KNetCore>
    {

    }
}