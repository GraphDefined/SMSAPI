using System;
using System.Collections.Specialized;

namespace com.GraphDefined.SMSApi.API.Action
{
    public class SenderDelete : BaseSimple<Response.Base>
    {

        public SenderDelete(Credentials   Client,
                            SMSAPIClient  Proxy,
                            String      Name)
            : base(Client, Proxy)
        {
            this.Name = Name;
        }

        protected override String Uri => "sender.do";

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
