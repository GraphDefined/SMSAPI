using System;
using System.Collections.Specialized;

namespace com.GraphDefined.SMSApi.API.Action
{
    public class PhonebookGroupAdd : BaseSimple<Response.Group>
    {

        public PhonebookGroupAdd(Credentials Client,
                                 SMSAPIClient  Proxy)

            : base(Client, Proxy)

        { }

        protected override String Uri => "phonebook.do";

        protected string name;
        protected string info;

        protected override NameValueCollection Values()
        {
            var collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", Credentials.Username);
            collection.Add("password", Credentials.Password);

            collection.Add("add_group", name);
            if (info != null) collection.Add("info", info);

            return collection;
        }

        public PhonebookGroupAdd SetName(string name)
        {
            this.name = name;
            return this;
        }

        public PhonebookGroupAdd SetInfo(string info)
        {
            this.info = info;
            return this;
        }

    }

}
