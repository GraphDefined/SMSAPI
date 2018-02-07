using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class UserGetCredits : BaseSimple<Response.Credits>
    {

        public UserGetCredits(Credentials Client,
                              HTTPClient Proxy)
            : base(Client, Proxy)
        { }

        protected override string Uri() { return "user.do"; }

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
