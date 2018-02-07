using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class SenderAdd : BaseSimple<Response.Base>
    {

        public SenderAdd(Client Client,
                         IProxy  Proxy)
            : base(Client, Proxy)
        { }

        private string name;

        protected override string Uri() { return "sender.do"; }

        public SenderAdd SetName(string name)
        {
            this.name = name;
            return this;
        }

        protected override NameValueCollection Values()
        {
            var collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", Client.Username);
            collection.Add("password", Client.Password);

            collection.Add("add", name);

            return collection;
        }

    }

}
