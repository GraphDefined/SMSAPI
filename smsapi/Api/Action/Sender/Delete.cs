using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class SenderDelete : BaseSimple<Response.Base>
    {

        public SenderDelete(Client Client,
                            IProxy  Proxy)
            : base(Client, Proxy)
        { }

        protected override string Uri() { return "sender.do"; }

        private string name;

        public SenderDelete Name(string name)
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

            collection.Add("delete", this.name);

            return collection;
        }
    }
}
