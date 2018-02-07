using System;
using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class SenderDelete : BaseSimple<Response.Base>
    {

        public SenderDelete(Credentials   Client,
                            HTTPClient  Proxy,
                            String      Name)
            : base(Client, Proxy)
        {
            this.Name = Name;
        }

        protected override String Uri() { return "sender.do"; }

        private String Name { get; }

        protected override NameValueCollection Values()
            => new NameValueCollection {
                   { "format",   "json" },
                   { "username", Credentials.Username },
                   { "password", Credentials.Password },
                   { "delete",   Name }
               };

    }

}
