using System;
using System.Net.Security;

using org.GraphDefined.Vanaheimr.Hermod.DNS;
using org.GraphDefined.Vanaheimr.Hermod.HTTP;

namespace com.GraphDefined.SMSApi.API
{
    [Obsolete("use ContactsFactory instead")]
    public class PhonebookFactory : SMSAPIClient
    {

        #region Constructor(s)

        /// <summary>
        /// Create a new PhonebookFactory HTTP client.
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
        public PhonebookFactory(URL?                                 RemoteURL                    = null,
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


        public Action.PhonebookContactAdd ActionContactAdd(string number = null)
        {
            var action = new Action.PhonebookContactAdd(Credentials, this);
            action.SetNumber(number);

            return action;
        }

        public Action.PhonebookContactGet ActionContactGet(string number = null)
        {
            var action = new Action.PhonebookContactGet(Credentials, this);
            action.Number(number);

            return action;
        }

        public Action.PhonebookContactEdit ActionContactEdit(string number = null)
        {
            var action = new Action.PhonebookContactEdit(Credentials, this);
            action.Number(number);

            return action;
        }

        public Action.PhonebookContactDelete ActionContactDelete(string number = null)
        {
            var action = new Action.PhonebookContactDelete(Credentials, this);
            action.Number(number);

            return action;
        }

        public Action.PhonebookContactList ActionContactList()
            => new Action.PhonebookContactList(Credentials, this);

        public Action.PhonebookGroupAdd ActionGroupAdd(string name = null)
        {
            var action = new Action.PhonebookGroupAdd(Credentials, this);
            action.SetName(name);

            return action;
        }

        public Action.PhonebookGroupEdit ActionGroupEdit(string name = null)
        {
            var action = new Action.PhonebookGroupEdit(Credentials, this);
            action.Name(name);

            return action;
        }

        public Action.PhonebookGroupGet ActionGroupGet(string name = null)
        {
            var action = new Action.PhonebookGroupGet(Credentials, this);
            action.Name(name);

            return action;
        }

        public Action.PhonebookGroupDelete ActionGroupDelete(string name = null)
        {
            var action = new Action.PhonebookGroupDelete(Credentials, this);
            action.Name(name);

            return action;
        }

        public Action.PhonebookGroupList ActionGroupList()
            => new Action.PhonebookGroupList(Credentials, this);

    }

}
