using System;
using System.Collections.Specialized;

namespace com.GraphDefined.SMSApi.API.Action
{

    public class UserList : BaseArray<Response.User>
    {

        protected String Username { get; }

        public UserList(Credentials  Credentials,
                        SMSAPIClient   HTTPClient,
                        String       Username = null)

            : base(Credentials, HTTPClient)

        {
            this.Username = Username;
        }

        protected override String Uri => "user.do";

        protected override NameValueCollection Values()
            => new NameValueCollection {
                   { "format",    "json" },
                   { "username",  Credentials.Username },
                   { "password",  Credentials.Password },
                   { "list",      "1" }
               };

    }

}
