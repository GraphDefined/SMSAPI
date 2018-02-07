using System;
using System.Collections.Specialized;
using System.Collections.Generic;

namespace SMSApi.Api.Action
{

    public class SMSGet : BaseSimple<Response.Status>
    {

        protected IEnumerable<String> Ids   { get; }


        public SMSGet(Credentials  Credentials,
                      HTTPClient   Proxy,
                      String       Id)

            : base(Credentials, Proxy)

        {
            this.Ids = new String[] { Id };
        }

        public SMSGet(Credentials          Credentials,
                      HTTPClient           Proxy,
                      IEnumerable<String>  Ids)

            : base(Credentials, Proxy)

        {
            this.Ids = Ids;
        }


        protected override String Uri() { return "sms.do"; }

        protected override NameValueCollection Values()
            => new NameValueCollection {
                   { "format",   "json" },
                   { "username", Client.Username },
                   { "password", Client.Password },
                   { "status",   String.Join("|", Ids) }
               };

    }

}
