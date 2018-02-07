using System;
using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class SenderSetDefault : BaseSimple<Response.Base>
    {

        public SenderSetDefault(Credentials   Client,
                                HTTPClient  Proxy,
                                String      DefaultName)
            : base(Client, Proxy)
        {
            this.DefaultName = DefaultName;
        }

        protected override String Uri() { return "sender.do"; }

        private String DefaultName { get; }

        protected override NameValueCollection Values()
            => new NameValueCollection {
                   { "format",   "json" },
                   { "username", Credentials.Username },
                   { "password", Credentials.Password },
                   { "default",  DefaultName }
               };

    }

}
