using System;

namespace SMSApi.Api
{
    public class SenderFactory : Factory
    {

        public SenderFactory()
            : base()
        { }

        public SenderFactory(Client client)
            : base(client)
        { }

        public SenderFactory(Client client, IProxy proxy)
            : base(client, proxy)
        { }

        public Action.SenderAdd ActionAdd(String name = null)
        {
            var action = new Action.SenderAdd(Client, Proxy);
            action.SetName(name);

            return action;
        }

        public Action.SenderDelete ActionDelete(String name = null)
        {
            var action = new Action.SenderDelete(Client, Proxy);
            action.Name(name);

            return action;
        }

        public Action.SenderSetDefault ActionSetDefault(String name = null)
        {
            var action = new Action.SenderSetDefault(Client, Proxy);
            action.Name(name);

            return action;
        }

        public Action.SenderList ActionList()
            => new Action.SenderList(Client, Proxy);

    }

}
