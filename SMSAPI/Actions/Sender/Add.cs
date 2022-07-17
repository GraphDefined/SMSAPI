using System;
using System.Collections.Specialized;

namespace com.GraphDefined.SMSApi.API.Action
{

    public class SenderAdd : BaseSimple<Response.Base>
    {

        public SenderAdd(Credentials   Client,
                         SMSAPIClient  Proxy,
                         String      Name)
            : base(Client, Proxy)
        {
            this.Name = Name;
        }

        private String Name { get; }

        protected override String Uri => "sender.do";

        protected override NameValueCollection Values()
            => new NameValueCollection {
                { "format",   "json" },
                { "username", Credentials.Username },
                { "password", Credentials.Password },
                { "add",      Name }
            };

    }

}
