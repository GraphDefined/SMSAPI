using System;
using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class UserGet : BaseSimple<Response.User>
    {

        protected String Username { get; }

        public UserGet(Credentials Client,
                       HTTPClient  Proxy,
                       String  Username)
            : base(Client, Proxy)
        {
            this.Username = Username;
        }

        protected override String Uri() { return "user.do"; }

        protected override NameValueCollection Values()
            => new NameValueCollection {
                   { "format", "json" },
                   { "username", Client.Username },
                   { "password", Client.Password },
                   { "get_user", Username }
               };

    }

}
