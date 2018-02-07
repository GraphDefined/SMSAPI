using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class PhonebookContactDelete : BaseSimple<Response.Base>
    {

        public PhonebookContactDelete(Credentials Client,
                                      HTTPClient Proxy)

            : base(Client, Proxy)

        { }

        protected override string Uri() { return "phonebook.do"; }

        protected string number;

        protected override NameValueCollection Values()
        {
            var collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", Credentials.Username);
            collection.Add("password", Credentials.Password);

            collection.Add("delete_contact", number);

            return collection;
        }

        public PhonebookContactDelete Number(string number)
        {
            this.number = number;
            return this;
        }

    }
}
