using System;
using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class SenderList : BaseArray<Response.Sender>
    {

        public SenderList(Credentials  Client,
                          HTTPClient Proxy)
            : base(Client, Proxy)
        { }

        protected override String Uri => "sender.do";

        protected override NameValueCollection Values()
            => new NameValueCollection {
                   { "format",   "json" },
                   { "username", Credentials.Username },
                   { "password", Credentials.Password },
                   { "list",     "1" }
               };

    }

}
