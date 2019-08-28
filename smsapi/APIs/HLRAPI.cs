using org.GraphDefined.Vanaheimr.Hermod;
using org.GraphDefined.Vanaheimr.Hermod.HTTP;
using System;
using System.Collections.Generic;

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
        /// <param name="Hostname">The remote hostname.</param>
        /// <param name="RemotePort">The remote HTTPS port.</param>
        /// <param name="URLPathPrefix">The common URL prefix.</param>
        /// <param name="BasicAuthentication">An optional HTTP basic authentication.</param>
        /// <param name="Credentials">The default API authentication.</param>
        public HLRAPI(HTTPHostname? Hostname             = null,
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


        public Action.HLRCheckNumber CheckNumber(String Number)
            => new Action.HLRCheckNumber(Credentials, this, Number);

        public Action.HLRCheckNumber CheckNumber(IEnumerable<String> Numbers)
            => new Action.HLRCheckNumber(Credentials, this, Numbers);

    }

}
