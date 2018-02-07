using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class PhonebookGroupEdit : BaseSimple<Response.Group>
    {

        public PhonebookGroupEdit(Credentials Client,
                                  HTTPClient  Proxy)

            : base(Client, Proxy)

        { }

        protected override string Uri() { return "phonebook.do"; }

        protected string oldName;
        protected string newName;
        protected string info;

        protected override NameValueCollection Values()
        {
            var collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", Client.Username);
            collection.Add("password", Client.Password);

            collection.Add("edit_group", oldName);
            collection.Add("name", newName);
            collection.Add("info", info);

            return collection;
        }

        public PhonebookGroupEdit Name(string name)
        {
            this.oldName = name;
            return this;
        }

        public PhonebookGroupEdit SetName(string name)
        {
            this.newName = name;
            return this;
        }

        public PhonebookGroupEdit SetInfo(string info)
        {
            this.info = info;
            return this;
        }
    }
}
