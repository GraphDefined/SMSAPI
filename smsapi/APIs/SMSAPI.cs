using System;
using System.Collections.Generic;
using org.GraphDefined.Vanaheimr.Hermod;
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
        /// <param name="Hostname">The remote hostname.</param>
        /// <param name="RemotePort">The remote HTTPS port.</param>
        /// <param name="URLPathPrefix">The common URL prefix.</param>
        /// <param name="BasicAuthentication">An optional HTTP basic authentication.</param>
        /// <param name="Credentials">The default API authentication.</param>
        public SMSAPI(HTTPHostname? Hostname             = null,
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
