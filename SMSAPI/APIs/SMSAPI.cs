/*
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

using System;
using System.Net.Security;
using System.Collections.Specialized;
using System.Security.Authentication;

using org.GraphDefined.Vanaheimr.Hermod.DNS;
using org.GraphDefined.Vanaheimr.Hermod.HTTP;
using org.GraphDefined.Vanaheimr.Illias;

#endregion

namespace com.GraphDefined.SMSApi.API
{

    public interface ISMSClient
    {

        event OnSendSMSAPIRequestDelegate   OnSendSMSAPIRequest;

        event OnSendSMSAPIResponseDelegate  OnSendSMSAPIResponse;


        Action.SMSSend Send(String text, String   to);
        Action.SMSSend Send(String text, String[] to);

        Task<Stream> Execute(String               Command,
                             NameValueCollection  Data,
                             Stream               File,
                             RequestMethods       HTTPMethod = RequestMethods.POST);

        Task<Stream> Execute(String                       Command,
                             NameValueCollection          Data,
                             Dictionary<String, Stream>?  Files       = null,
                             RequestMethods               HTTPMethod  = RequestMethods.POST);

    }


    /// <summary>
    /// The SMS API.
    /// </summary>
    public class SMSAPI : SMSAPIClient, ISMSClient
    {

        #region Constructor(s)

        /// <summary>
        /// Create a new SMSAPI HTTP client.
        /// </summary>
        /// <param name="RemoteURL">The remote URL of the OICP HTTP endpoint to connect to.</param>
        /// <param name="VirtualHostname">An optional HTTP virtual hostname.</param>
        /// <param name="Description">An optional description of this CPO client.</param>
        /// <param name="RemoteCertificateValidator">The remote TLS certificate validator.</param>
        /// <param name="HTTPUserAgent">The HTTP user agent identification.</param>
        /// <param name="BasicAuthentication">An optional HTTP basic authentication.</param>
        /// <param name="Credentials">The default API authentication.</param>
        /// <param name="RequestTimeout">An optional request timeout.</param>
        /// <param name="TransmissionRetryDelay">The delay between transmission retries.</param>
        /// <param name="MaxNumberOfRetries">The maximum number of transmission retries for HTTP request.</param>
        /// <param name="DNSClient">The DNS client to use.</param>
        public SMSAPI(URL?                                  RemoteURL                    = null,
                      HTTPHostname?                         VirtualHostname              = null,
                      I18NString?                           Description                  = null,
                      Boolean?                              PreferIPv4                   = null,
                      RemoteCertificateValidationCallback?  RemoteCertificateValidator   = null,
                      SslProtocols?                         TLSProtocol                  = null,
                      String                                HTTPUserAgent                = DefaultHTTPUserAgent,
                      Credentials?                          BasicAuthentication          = null,
                      Credentials?                          Credentials                  = null,
                      TimeSpan?                             RequestTimeout               = null,
                      TransmissionRetryDelayDelegate?       TransmissionRetryDelay       = null,
                      UInt16?                               MaxNumberOfRetries           = DefaultMaxNumberOfRetries,
                      Boolean?                              DisableLogging               = false,
                      DNSClient?                            DNSClient                    = null)

            : base(RemoteURL,
                   VirtualHostname,
                   Description,
                   PreferIPv4,
                   RemoteCertificateValidator,
                   TLSProtocol,
                   HTTPUserAgent,
                   BasicAuthentication,
                   Credentials,
                   RequestTimeout,
                   TransmissionRetryDelay,
                   MaxNumberOfRetries,
                   null,
                   DisableLogging,
                   DNSClient)

        { }

        #endregion


        public Action.SMSDelete Delete(String Id)
            => new (Credentials, this, Id);

        public Action.SMSGet    Get   (String Id)
            => new (Credentials, this, Id);

        public Action.SMSGet    Get   (IEnumerable<String> Ids)
            => new (Credentials, this, Ids);

        public Action.SMSSend   Send  (String text, String to)
            => new (Credentials, this, new String[] { to }, text);

        public Action.SMSSend   Send  (String text, String[] to)
            => new (Credentials, this, to, text);

    }

}
