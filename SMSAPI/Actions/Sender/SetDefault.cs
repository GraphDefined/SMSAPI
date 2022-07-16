using System;
using System.Collections.Specialized;

namespace com.GraphDefined.SMSApi.API.Action
{
    public class SenderSetDefault : BaseSimple<Response.Base>
    {

        public SenderSetDefault(Credentials   Client,
                                SMSAPIClient  Proxy,
                                String      DefaultName)
            : base(Client, Proxy)
        {
            this.DefaultName = DefaultName;
        }

        protected override String Uri => "sender.do";

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
