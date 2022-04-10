using System;
using System.Collections.Specialized;

namespace com.GraphDefined.SMSApi.API.Action
{
    public class UserGetCredits : BaseSimple<Response.Credits>
    {

        public UserGetCredits(Credentials Client,
                              SMSAPIClient Proxy)
            : base(Client, Proxy)
        { }

        protected override String Uri => "user.do";

        protected override NameValueCollection Values()
        {
            var collection = new NameValueCollection
            {
                { "format", "json" },
                { "username", Credentials.Username },
                { "password", Credentials.Password },
                { "credits", "1" },
                { "details", "1" }
            };

            return collection;
        }
    }
}
