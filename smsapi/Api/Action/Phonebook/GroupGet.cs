using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class PhonebookGroupGet : BaseSimple<Response.Group>
    {

        public PhonebookGroupGet(Credentials Client,
                                 HTTPClient  Proxy)

            : base(Client, Proxy)

        { }

        protected override string Uri() { return "phonebook.do"; }

        protected string name;

        protected override NameValueCollection Values()
        {
            var collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", Client.Username);
            collection.Add("password", Client.Password);

            collection.Add("get_group", name);

            return collection;
        }

        public PhonebookGroupGet Name(string name)
        {
            this.name = name;
            return this;
        }

    }

}
