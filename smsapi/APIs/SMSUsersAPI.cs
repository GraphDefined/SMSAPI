using System;

namespace SMSApi.Api
{

    /// <summary>
    /// The SMS Users API.
    /// </summary>
    public class SMSUsersAPI : ABaseAPI
    {

        #region Constructor(s)

        public SMSUsersAPI()
        { }

        public SMSUsersAPI(Credentials  Credentials)
            : base(Credentials)
        { }

        public SMSUsersAPI(Credentials  Credentials,
                        HTTPClient   HTTPClient)
            : base(Credentials, HTTPClient)
        { }

        #endregion


        public Action.UserGetCredits GetCredits()
            => new Action.UserGetCredits(Credentials, HTTPClient);

        public Action.UserAdd        Add (String Username)
            => new Action.UserAdd (Credentials, HTTPClient, Username);

        public Action.UserEdit       Edit(String Username)
            => new Action.UserEdit(Credentials, HTTPClient, Username);

        public Action.UserGet        Get (String Username)
            => new Action.UserGet (Credentials, HTTPClient, Username);

        public Action.UserList       List()
            => new Action.UserList(Credentials, HTTPClient);

    }

}
