using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class PhonebookGroupDelete : BaseSimple<Response.Base>
    {

        public PhonebookGroupDelete(Credentials Client,
                                    HTTPClient  Proxy)

            : base(Client, Proxy)

        {
            removeContacts = false;
        }


        protected override string Uri() { return "phonebook.do"; }

        protected string name;
        protected bool removeContacts;

        protected override NameValueCollection Values()
        {
            var collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", Client.Username);
            collection.Add("password", Client.Password);

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
