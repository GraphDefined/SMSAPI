﻿/*
 * Copyright (c) 2017-2025 GraphDefined GmbH <achim.friedland@graphdefined.com>
 * This file is part of GraphDefined SMSAPI <https://github.com/GraphDefined/SMSAPI>
 *   based on original work of SMSAPI!
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#region Usings

using org.GraphDefined.Vanaheimr.Illias;
using org.GraphDefined.Vanaheimr.Hermod.HTTP;
using org.GraphDefined.Vanaheimr.Hermod.Logging;

#endregion

namespace com.GraphDefined.SMSApi.API
{

    /// <summary>
    /// The SMSAPI logger.
    /// </summary>
    public class SMSAPIClientLogger : HTTPClientLogger
    {

        #region Data

        /// <summary>
        /// The default context for this logger.
        /// </summary>
        public const String DefaultContext = "SMSAPI";

        #endregion

        #region Properties

        /// <summary>
        /// The attached SMSAPI client.
        /// </summary>
        public SMSAPIClient  SMSAPIClient   { get; }

        #endregion

        #region Constructor(s)

        #region SMSAPIClientLogger(SMSAPIClient, Context = DefaultContext, LogfileCreator = null)

        /// <summary>
        /// Create a new SMSAPI logger using the default logging delegates.
        /// </summary>
        /// <param name="SMSAPIClient">An SMSAPI client.</param>
        /// <param name="LoggingPath">The logging path.</param>
        /// <param name="Context">A context of this API.</param>
        /// <param name="LogfileCreator">A delegate to create a log file from the given context and log file name.</param>
        public SMSAPIClientLogger(SMSAPIClient             SMSAPIClient,
                                  String                   LoggingPath,
                                  String                   Context         = DefaultContext,
                                  LogfileCreatorDelegate?  LogfileCreator  = null)

            : this(SMSAPIClient,
                   LoggingPath,
                   Context.IsNotNullOrEmpty() ? Context : DefaultContext,
                   null,
                   null,
                   null,
                   null,

                   LogfileCreator: LogfileCreator)

        { }

        #endregion

        #region SMSAPIClientLogger(SMSAPIClient, Context, ... Logging delegates ...)

        /// <summary>
        /// Create a SMSAPI HTTP logger using the given logging delegates.
        /// </summary>
        /// <param name="SMSAPIClient">An SMSAPI client.</param>
        /// <param name="LoggingPath">The logging path.</param>
        /// <param name="Context">A context of this API.</param>
        /// 
        /// <param name="LogHTTPRequest_toConsole">A delegate to log incoming HTTP requests to console.</param>
        /// <param name="LogHTTPResponse_toConsole">A delegate to log HTTP requests/responses to console.</param>
        /// <param name="LogHTTPRequest_toDisc">A delegate to log incoming HTTP requests to disc.</param>
        /// <param name="LogHTTPResponse_toDisc">A delegate to log HTTP requests/responses to disc.</param>
        /// 
        /// <param name="LogHTTPRequest_toNetwork">A delegate to log incoming HTTP requests to a network target.</param>
        /// <param name="LogHTTPResponse_toNetwork">A delegate to log HTTP requests/responses to a network target.</param>
        /// <param name="LogHTTPRequest_toHTTPSSE">A delegate to log incoming HTTP requests to a HTTP client sent events source.</param>
        /// <param name="LogHTTPResponse_toHTTPSSE">A delegate to log HTTP requests/responses to a HTTP client sent events source.</param>
        /// 
        /// <param name="LogHTTPError_toConsole">A delegate to log HTTP errors to console.</param>
        /// <param name="LogHTTPError_toDisc">A delegate to log HTTP errors to disc.</param>
        /// <param name="LogHTTPError_toNetwork">A delegate to log HTTP errors to a network target.</param>
        /// <param name="LogHTTPError_toHTTPSSE">A delegate to log HTTP errors to a HTTP client sent events source.</param>
        /// 
        /// <param name="LogfileCreator">A delegate to create a log file from the given context and log file name.</param>
        public SMSAPIClientLogger(SMSAPIClient                 SMSAPIClient,
                                  String                       LoggingPath,
                                  String                       Context,

                                  HTTPRequestLoggerDelegate?   LogHTTPRequest_toConsole    = null,
                                  HTTPResponseLoggerDelegate?  LogHTTPResponse_toConsole   = null,
                                  HTTPRequestLoggerDelegate?   LogHTTPRequest_toDisc       = null,
                                  HTTPResponseLoggerDelegate?  LogHTTPResponse_toDisc      = null,

                                  HTTPRequestLoggerDelegate?   LogHTTPRequest_toNetwork    = null,
                                  HTTPResponseLoggerDelegate?  LogHTTPResponse_toNetwork   = null,
                                  HTTPRequestLoggerDelegate?   LogHTTPRequest_toHTTPSSE    = null,
                                  HTTPResponseLoggerDelegate?  LogHTTPResponse_toHTTPSSE   = null,

                                  HTTPResponseLoggerDelegate?  LogHTTPError_toConsole      = null,
                                  HTTPResponseLoggerDelegate?  LogHTTPError_toDisc         = null,
                                  HTTPResponseLoggerDelegate?  LogHTTPError_toNetwork      = null,
                                  HTTPResponseLoggerDelegate?  LogHTTPError_toHTTPSSE      = null,

                                  LogfileCreatorDelegate?      LogfileCreator              = null)

            : base(SMSAPIClient,
                   LoggingPath,
                   Context.IsNotNullOrEmpty() ? Context : DefaultContext,

                   LogHTTPRequest_toConsole,
                   LogHTTPResponse_toConsole,
                   LogHTTPRequest_toDisc,
                   LogHTTPResponse_toDisc,

                   LogHTTPRequest_toNetwork,
                   LogHTTPResponse_toNetwork,
                   LogHTTPRequest_toHTTPSSE,
                   LogHTTPResponse_toHTTPSSE,

                   LogHTTPError_toConsole,
                   LogHTTPError_toDisc,
                   LogHTTPError_toNetwork,
                   LogHTTPError_toHTTPSSE,

                   LogfileCreator)

        {

            #region Initial checks

            this.SMSAPIClient = SMSAPIClient ?? throw new ArgumentNullException(nameof(SMSAPIClient), "The given SMSAPI client must not be null!");

            #endregion

            #region SIMHardware

            //RegisterEvent("SetSIMHardwareStateRequest",
            //              handler => SMSAPIClient.OnSetSIMHardwareStateRequest += handler,
            //              handler => SMSAPIClient.OnSetSIMHardwareStateRequest -= handler,
            //              "SetSIMHardwareState", "SIMHardware", "Requests", "All").
            //    RegisterDefaultConsoleLogTarget(this).
            //    RegisterDefaultDiscLogTarget(this);

            //RegisterEvent("SetSIMHardwareStateResponse",
            //              handler => SMSAPIClient.OnSetSIMHardwareStateResponse += handler,
            //              handler => SMSAPIClient.OnSetSIMHardwareStateResponse -= handler,
            //              "SetSIMHardwareState", "SIMHardware", "Responses", "All").
            //    RegisterDefaultConsoleLogTarget(this).
            //    RegisterDefaultDiscLogTarget(this);

            #endregion

        }

        #endregion

        #endregion

    }

}
