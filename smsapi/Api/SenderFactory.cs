using System;

namespace SMSApi.Api
{

    public class SenderFactory : Factory
    {

        public SenderFactory()
            : base()
        { }

        public SenderFactory(Credentials Credentials)
            : base(Credentials)
        { }

        public SenderFactory(Credentials Credentials, HTTPClient proxy)
            : base(Credentials, proxy)
        { }


        public Action.SenderAdd ActionAdd(String Name)
            => new Action.SenderAdd(Credentials, HTTPClient, Name);

        public Action.SenderDelete ActionDelete(String Name)
            => new Action.SenderDelete(Credentials, HTTPClient, Name);

        public Action.SenderSetDefault ActionSetDefault(String DefaultName)
            => new Action.SenderSetDefault(Credentials, HTTPClient, DefaultName);

        public Action.SenderList ActionList()
            => new Action.SenderList(Credentials, HTTPClient);

    }

}
