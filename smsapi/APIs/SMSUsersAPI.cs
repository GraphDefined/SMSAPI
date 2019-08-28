using System;
using org.GraphDefined.Vanaheimr.Hermod;
using org.GraphDefined.Vanaheimr.Hermod.HTTP;

namespace com.GraphDefined.SMSApi.API
{

    /// <summary>
    /// The SMS Users API.
    /// </summary>
    public class SMSUsersAPI : SMSAPIClient
    {

        #region Constructor(s)

        /// <summary>
        /// Create a new SMSUsersAPI HTTP client.
        /// </summary>
        /// <param name="Hostname">The remote hostname.</param>
        /// <param name="RemotePort">The remote HTTPS port.</param>
        /// <param name="URLPathPrefix">The common URL prefix.</param>
        /// <param name="BasicAuthentication">An optional HTTP basic authentication.</param>
        /// <param name="Credentials">The default API authentication.</param>
        public SMSUsersAPI(HTTPHostname? Hostname             = null,
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


        public Action.UserGetCredits GetCredits()
            => new Action.UserGetCredits(Credentials, this);

        public Action.UserAdd        Add (String Username)
            => new Action.UserAdd (Credentials, this, Username);

        public Action.UserEdit       Edit(String Username)
            => new Action.UserEdit(Credentials, this, Username);

        public Action.UserGet        Get (String Username)
            => new Action.UserGet (Credentials, this, Username);

        public Action.UserList       List()
            => new Action.UserList(Credentials, this);

    }

}
