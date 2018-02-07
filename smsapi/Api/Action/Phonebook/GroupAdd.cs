using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class PhonebookGroupAdd : BaseSimple<Response.Group>
    {

        public PhonebookGroupAdd(Client Client,
                                 IProxy  Proxy)

            : base(Client, Proxy)

        { }

        protected override string Uri() { return "phonebook.do"; }

        protected string name;
        protected string info;

        protected override NameValueCollection Values()
        {
            var collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", Client.Username);
            collection.Add("password", Client.Password);

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
