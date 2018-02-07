using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class SMSGet : BaseSimple<Response.Status>
    {

        public SMSGet(Client Client,
                      IProxy  Proxy)

            : base(Client, Proxy)

        { }

        protected override string Uri() { return "sms.do"; }

        protected string[] id;

        protected override NameValueCollection Values()
        {

            var collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", Client.Username);
            collection.Add("password", Client.Password);

            collection.Add("status", string.Join("|", id));

            return collection;

        }

        public SMSGet Id(string id)
        {
            this.id = new string[] { id };
            return this;
        }

        public SMSGet Ids(string[] ids)
        {
            this.id = ids;
            return this;
        }

    }

}
