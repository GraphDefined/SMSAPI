using System;
using System.Collections.Specialized;

namespace com.GraphDefined.SMSApi.API.Action
{
    public class PhonebookGroupDelete : BaseSimple<Response.Base>
    {

        public PhonebookGroupDelete(Credentials Client,
                                    SMSAPIClient  Proxy)

            : base(Client, Proxy)

        {
            removeContacts = false;
        }


        protected override String Uri => "phonebook.do";

        protected string name;
        protected bool removeContacts;

        protected override NameValueCollection Values()
        {
            var collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", Credentials.Username);
            collection.Add("password", Credentials.Password);

            collection.Add("delete_group", name);

            if (removeContacts == true)
            {
                collection.Add("remove_contacts", "1");
            }

            return collection;
        }

        public PhonebookGroupDelete Name(string name)
        {
            this.name = name;
            return this;
        }

        public PhonebookGroupDelete Contacts(bool flag)
        {
            this.removeContacts = flag;
            return this;
        }
    }
}
