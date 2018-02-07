using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class UserGetCredits : BaseSimple<Response.Credits>
    {

        public UserGetCredits(Client Client,
                              IProxy Proxy)
            : base(Client, Proxy)
        { }

        protected override string Uri() { return "user.do"; }

        protected override NameValueCollection Values()
        {
            var collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", Client.Username);
            collection.Add("password", Client.Password);

            collection.Add("credits", "1");
            collection.Add("details", "1");

            return collection;
        }
    }
}
