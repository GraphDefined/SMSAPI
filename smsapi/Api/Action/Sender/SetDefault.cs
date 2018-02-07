using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class SenderSetDefault : BaseSimple<Response.Base>
    {

        public SenderSetDefault(Client Client,
                                IProxy  Proxy)
            : base(Client, Proxy)
        { }

        protected override string Uri() { return "sender.do"; }

        private string name;

        public SenderSetDefault Name(string name)
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

            collection.Add("default", this.name);

            return collection;
        }
    }
}
