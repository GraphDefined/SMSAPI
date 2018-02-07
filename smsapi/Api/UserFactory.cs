using System;

namespace SMSApi.Api
{
    public class UserFactory : Factory
    {

        public UserFactory()
            : base()
        { }

        public UserFactory(Client client)
            : base(client)
        { }

        public UserFactory(Client client, IProxy proxy)
            : base(client, proxy)
        { }


        public Action.UserGetCredits ActionGetCredits()
            => new Action.UserGetCredits(Client, Proxy);

        public Action.UserAdd ActionAdd()
            => new Action.UserAdd(Client, Proxy);

        public Action.UserEdit ActionEdit(String username = null)
        {
            var action = new Action.UserEdit(Client, Proxy);
            action.Username(username);

            return action;
        }

        public Action.UserGet ActionGet(String username = null)
        {
            var action = new Action.UserGet(Client, Proxy);
            action.Username(username);

            return action;
        }

        public Action.UserList ActionList()
            => new Action.UserList(Client, Proxy);

    }

}
