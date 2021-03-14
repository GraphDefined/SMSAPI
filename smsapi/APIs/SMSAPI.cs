using System;
using System.Net.Security;
using System.Collections.Generic;

using org.GraphDefined.Vanaheimr.Hermod.DNS;
using org.GraphDefined.Vanaheimr.Hermod.HTTP;

namespace com.GraphDefined.SMSApi.API
{

    /// <summary>
    /// The SMS API.
    /// </summary>
    public class SMSAPI : SMSAPIClient
    {

        #region Constructor(s)

        /// <summary>
        /// Create a new SMSAPI HTTP client.
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
        public SMSAPI(URL?                                 RemoteURL                    = null,
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


        public Action.SMSDelete Delete(String Id)
            => new Action.SMSDelete(Credentials, this, Id);

        public Action.SMSGet    Get   (String Id)
            => new Action.SMSGet   (Credentials, this, Id);

        public Action.SMSGet    Get   (IEnumerable<String> Ids)
            => new Action.SMSGet   (Credentials, this, Ids);

        public Action.SMSSend   Send  (String text, String to)
            => new Action.SMSSend  (Credentials, this, new String[] { to }, text);

        public Action.SMSSend   Send  (String text, String[] to)
            => new Action.SMSSend  (Credentials, this, to, text);

    }

}
