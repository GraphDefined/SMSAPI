using System;
using System.Net.Security;

using org.GraphDefined.Vanaheimr.Hermod.DNS;
using org.GraphDefined.Vanaheimr.Hermod.HTTP;

namespace com.GraphDefined.SMSApi.API
{

    /// <summary>
    /// The SMS Sender API.
    /// </summary>
    public class SMSSenderAPI : SMSAPIClient
    {

        #region Constructor(s)

        /// <summary>
        /// Create a new SMSSenderAPI HTTP client.
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
        public SMSSenderAPI(URL?                                 RemoteURL                    = null,
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


        public Action.SenderAdd        Add       (String Name)
            => new Action.SenderAdd       (Credentials, this, Name);

        public Action.SenderDelete     Delete    (String Name)
            => new Action.SenderDelete    (Credentials, this, Name);

        public Action.SenderSetDefault SetDefault(String DefaultName)
            => new Action.SenderSetDefault(Credentials, this, DefaultName);

        public Action.SenderList       GetAllSenderNames()
            => new Action.SenderList      (Credentials, this);

    }

}
