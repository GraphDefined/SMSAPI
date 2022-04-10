using System;
using System.Collections.Specialized;
using System.Collections.Generic;

namespace com.GraphDefined.SMSApi.API.Action
{

    public class SMSGet : BaseSimple<Response.SMSAPIResponseStatus>
    {

        protected IEnumerable<String> Ids   { get; }


        public SMSGet(Credentials   Credentials,
                      SMSAPIClient  SMSAPIClient,
                      String        Id)

            : base(Credentials, SMSAPIClient)

        {
            this.Ids = new String[] { Id };
        }

        public SMSGet(Credentials          Credentials,
                      SMSAPIClient         SMSAPIClient,
                      IEnumerable<String>  Ids)

            : base(Credentials, SMSAPIClient)

        {
            this.Ids = Ids;
        }


        protected override String Uri => "sms.do";

        protected override NameValueCollection Values()
            => new NameValueCollection {
                   { "format",   "json" },
                   { "username", Credentials.Username },
                   { "password", Credentials.Password },
                   { "status",   String.Join("|", Ids) }
               };

    }

}
