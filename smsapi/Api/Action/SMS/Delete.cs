using System.Collections.Specialized;

namespace SMSApi.Api.Action
{

    public class SMSDelete : BaseSimple<Response.Countable>
    {

        public SMSDelete(Client Client,
                         IProxy  Proxy)

            : base(Client, Proxy)

        { }

        protected override string Uri() { return "sms.do"; }

        protected string id;

        protected override NameValueCollection Values()
        {

            var collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", Client.Username);
            collection.Add("password", Client.Password);

            collection.Add("sch_del", id);

            return collection;

        }

        public SMSDelete Id(string id)
        {
            this.id = id;
            return this;
        }

    }

}
