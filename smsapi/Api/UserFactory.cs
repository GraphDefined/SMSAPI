using System;

namespace SMSApi.Api
{

    public class UserFactory : Factory
    {

        public UserFactory()
            : base()
        { }

        public UserFactory(Credentials Credentials)
            : base(Credentials)
        { }

        public UserFactory(Credentials Credentials, HTTPClient proxy)
            : base(Credentials, proxy)
        { }


        public Action.UserGetCredits ActionGetCredits()
            => new Action.UserGetCredits(Credentials, HTTPClient);

        public Action.UserAdd  ActionAdd (String Username)
            => new Action.UserAdd (Credentials, HTTPClient, Username);

        public Action.UserEdit ActionEdit(String Username)
            => new Action.UserEdit(Credentials, HTTPClient, Username);

        public Action.UserGet  ActionGet (String Username)
            => new Action.UserGet (Credentials, HTTPClient, Username);

        public Action.UserList ActionList(String Username = null)
            => new Action.UserList(Credentials, HTTPClient, Username);

    }

}
