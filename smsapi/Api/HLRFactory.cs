using System;

namespace SMSApi.Api
{
    public class HLRFactory : Factory
    {
        public HLRFactory()
            : base()
        { }

        public HLRFactory(Client client)
            : base(client)
        { }

        public HLRFactory(Client client, IProxy proxy)
            : base(client, proxy)
        { }

        public Action.HLRCheckNumber ActionCheckNumber(String number = null)
        {
            var action = new Action.HLRCheckNumber(Client, Proxy);
            action.SetNumber(number);

            return action;
        }
    }
}
