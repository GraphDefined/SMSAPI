using System;
using System.Collections.Specialized;

namespace SMSApi.Api.Action
{

    public class UserGet : BaseSimple<Response.User>
    {

        protected String Username { get; }

        public UserGet(Credentials  Credentials,
                       HTTPClient   HTTPClient,
                       String       Username)

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
                   { "get_user",  Username }
               };

    }

}
