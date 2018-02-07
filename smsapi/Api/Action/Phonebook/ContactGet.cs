using System;
using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class PhonebookContactGet : BaseSimple<Response.Contact>
    {

        public PhonebookContactGet(Credentials Client,
                                   HTTPClient  Proxy)

            : base(Client, Proxy)

        { }

        protected override String Uri => "phonebook.do";

        protected string number;

        protected override NameValueCollection Values()
        {
            var collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", Credentials.Username);
            collection.Add("password", Credentials.Password);

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
