using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class UserGet : BaseSimple<Response.User>
    {

        public UserGet(Client Client,
                       IProxy  Proxy)
            : base(Client, Proxy)
        { }

        protected override string Uri() { return "user.do"; }

        protected override NameValueCollection Values()
        {
            var collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", Client.Username);
            collection.Add("password", Client.Password);

            collection.Add("get_user", username);

            return collection;
        }

        protected string username;

        public UserGet Username(string username)
        {
            this.username = username;
            return this;
        }
    }
}
