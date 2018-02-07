using System.Collections.Generic;
using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class SenderList : BaseArray<Response.Sender>
    {

        public SenderList(Client Client,
                          IProxy  Proxy)
            : base(Client, Proxy)
        { }

        protected override string Uri() { return "sender.do"; }

        protected override NameValueCollection Values()
        {
            var collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", Client.Username);
            collection.Add("password", Client.Password);

            collection.Add("list", "1");

            return collection;
        }
    }
}
