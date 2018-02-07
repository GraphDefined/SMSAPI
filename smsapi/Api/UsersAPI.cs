using System;

namespace SMSApi.Api
{

    /// <summary>
    /// The users API.
    /// </summary>
    public class UsersAPI : ABaseAPI
    {

        #region Constructor(s)

        public UsersAPI()
        { }

        public UsersAPI(Credentials  Credentials)
            : base(Credentials)
        { }

        public UsersAPI(Credentials  Credentials,
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
