using System;
using System.Collections.Specialized;

namespace com.GraphDefined.SMSApi.API.Action
{
    public class PhonebookGroupGet : BaseSimple<Response.Group>
    {

        public PhonebookGroupGet(Credentials Client,
                                 SMSAPIClient  Proxy)

            : base(Client, Proxy)

        { }

        protected override String Uri => "phonebook.do";

        protected string name;

        protected override NameValueCollection Values()
        {
            var collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", Credentials.Username);
            collection.Add("password", Credentials.Password);

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
