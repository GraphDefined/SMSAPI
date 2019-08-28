using System;
using org.GraphDefined.Vanaheimr.Hermod;
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
        /// <param name="Hostname">The remote hostname.</param>
        /// <param name="RemotePort">The remote HTTPS port.</param>
        /// <param name="URLPathPrefix">The common URL prefix.</param>
        /// <param name="BasicAuthentication">An optional HTTP basic authentication.</param>
        /// <param name="Credentials">The default API authentication.</param>
        public SMSSenderAPI(HTTPHostname? Hostname             = null,
                            IPPort?       RemotePort           = null,
                            HTTPPath?     URLPathPrefix        = null,
                            Credentials   BasicAuthentication  = null,
                            Credentials   Credentials          = null)

            : base(Hostname,
                   RemotePort,
                   URLPathPrefix,
                   BasicAuthentication,
                   Credentials)

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
