using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class PhonebookContactGet : BaseSimple<Response.Contact>
    {

        public PhonebookContactGet(Credentials Client,
                                   HTTPClient  Proxy)

            : base(Client, Proxy)

        { }

        protected override string Uri() { return "phonebook.do"; }

        protected string number;

        protected override NameValueCollection Values()
        {
            var collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", Client.Username);
            collection.Add("password", Client.Password);

            collection.Add("get_contact", number);

            return collection;
        }

        public PhonebookContactGet Number(string number)
        {
            this.number = number;
            return this;
        }
    }
}
