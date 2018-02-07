using System;
using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class SenderAdd : BaseSimple<Response.Base>
    {

        public SenderAdd(Credentials   Client,
                         HTTPClient  Proxy,
                         String      Name)
            : base(Client, Proxy)
        {
            this.Name = Name;
        }

        private String Name { get; }

        protected override String Uri() { return "sender.do"; }

        protected override NameValueCollection Values()
            => new NameValueCollection {
                { "format",   "json" },
                { "username", Credentials.Username },
                { "password", Credentials.Password },
                { "add",      Name }
            };

    }

}
