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
*  using kafka-tools-3.6.1.jar as reference
*/

using MASES.JCOBridge.C2JBridge;

namespace Org.Apache.Kafka.Tools.Reassign
{
    #region VerifyAssignmentResult
    public partial class VerifyAssignmentResult
    {
        #region Constructors

        #endregion

        #region Class/Interface conversion operators

        #endregion

        #region Fields
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-tools/3.6.1/org/apache/kafka/tools/reassign/VerifyAssignmentResult.html#movesOngoing"/>
        /// </summary>
        public bool movesOngoing { get { if (!_movesOngoingReady) { _movesOngoingContent = IGetField<bool>("movesOngoing"); _movesOngoingReady = true; } return _movesOngoingContent; } }
        private bool _movesOngoingContent = default;
        private bool _movesOngoingReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-tools/3.6.1/org/apache/kafka/tools/reassign/VerifyAssignmentResult.html#partsOngoing"/>
        /// </summary>
        public bool partsOngoing { get { if (!_partsOngoingReady) { _partsOngoingContent = IGetField<bool>("partsOngoing"); _partsOngoingReady = true; } return _partsOngoingContent; } }
        private bool _partsOngoingContent = default;
        private bool _partsOngoingReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-tools/3.6.1/org/apache/kafka/tools/reassign/VerifyAssignmentResult.html#partStates"/>
        /// </summary>
        public Java.Util.Map partStates { get { if (!_partStatesReady) { _partStatesContent = IGetField<Java.Util.Map>("partStates"); _partStatesReady = true; } return _partStatesContent; } }
        private Java.Util.Map _partStatesContent = default;
        private bool _partStatesReady = false; // this is used because in case of generics 
        /// <summary>
        /// <see href="https://www.javadoc.io/doc/org.apache.kafka/kafka-tools/3.6.1/org/apache/kafka/tools/reassign/VerifyAssignmentResult.html#moveStates"/>
        /// </summary>
        public Java.Util.Map moveStates { get { if (!_moveStatesReady) { _moveStatesContent = IGetField<Java.Util.Map>("moveStates"); _moveStatesReady = true; } return _moveStatesContent; } }
        private Java.Util.Map _moveStatesContent = default;
        private bool _moveStatesReady = false; // this is used because in case of generics 

        #endregion

        #region Static methods

        #endregion

        #region Instance methods

        #endregion

        #region Nested classes

        #endregion

        // TODO: complete the class
    }
    #endregion
}