using System;
using System.Collections.Specialized;

namespace SMSApi.Api.Action
{

    public class UserList : BaseArray<Response.User>
    {

        protected String Username { get; }

        public UserList(Credentials  Client,
                        HTTPClient  Proxy,
                        String  Username = null)

            : base(Client, Proxy)

        {
            this.Username = Username;
        }

        protected override String Uri() { return "user.do"; }

        protected override NameValueCollection Values()
            => new NameValueCollection {
                   { "format",    "json" },
                   { "username",  Credentials.Username },
                   { "password",  Credentials.Password },
                   { "list",      "1" }
               };

    }

}
