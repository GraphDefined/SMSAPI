using System;
using System.Net.Security;
using System.Collections.Generic;

using org.GraphDefined.Vanaheimr.Hermod.DNS;
using org.GraphDefined.Vanaheimr.Hermod.HTTP;

namespace com.GraphDefined.SMSApi.API
{

    /// <summary>
    /// The HLR API.
    /// </summary>
    public class HLRAPI : SMSAPIClient
    {

        #region Constructor(s)

        /// <summary>
        /// Create a new HLRAPI HTTP client.
        /// </summary>
        /// <param name="RemoteURL">The remote URL of the OICP HTTP endpoint to connect to.</param>
        /// <param name="VirtualHostname">An optional HTTP virtual hostname.</param>
        /// <param name="Description">An optional description of this CPO client.</param>
        /// <param name="RemoteCertificateValidator">The remote SSL/TLS certificate validator.</param>
        /// <param name="HTTPUserAgent">The HTTP user agent identification.</param>
        /// <param name="BasicAuthentication">An optional HTTP basic authentication.</param>
        /// <param name="Credentials">The default API authentication.</param>
        /// <param name="RequestTimeout">An optional request timeout.</param>
        /// <param name="TransmissionRetryDelay">The delay between transmission retries.</param>
        /// <param name="MaxNumberOfRetries">The maximum number of transmission retries for HTTP request.</param>
        /// <param name="DNSClient">The DNS client to use.</param>
        public HLRAPI(URL?                                 RemoteURL                    = null,
                      HTTPHostname?                        VirtualHostname              = null,
                      String                               Description                  = null,
                      RemoteCertificateValidationCallback  RemoteCertificateValidator   = null,
                      String                               HTTPUserAgent                = DefaultHTTPUserAgent,
                      Credentials                          BasicAuthentication          = null,
                      Credentials                          Credentials                  = null,
                      TimeSpan?                            RequestTimeout               = null,
                      TransmissionRetryDelayDelegate       TransmissionRetryDelay       = null,
                      UInt16?                              MaxNumberOfRetries           = DefaultMaxNumberOfRetries,
                      DNSClient                            DNSClient                    = null)

            : base(RemoteURL,
                   VirtualHostname,
                   Description,
                   RemoteCertificateValidator,
                   HTTPUserAgent,
                   BasicAuthentication,
                   Credentials,
                   RequestTimeout,
                   TransmissionRetryDelay,
                   MaxNumberOfRetries,
                   DNSClient)

        { }

        #endregion


        public Action.HLRCheckNumber CheckNumber(String Number)
            => new Action.HLRCheckNumber(Credentials, this, Number);

        public Action.HLRCheckNumber CheckNumber(IEnumerable<String> Numbers)
            => new Action.HLRCheckNumber(Credentials, this, Numbers);

    }

}
