using System.Collections.Specialized;
using System.Collections.Generic;

namespace SMSApi.Api.Action
{
    public class UserList : BaseArray<Response.User>
    {
        public UserList(Client Client,
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

            collection.Add("list", "1");

            return collection;
        }

        protected string username;

        public UserList Username(string username)
        {
            this.username = username;
            return this;
        }
    }
}
