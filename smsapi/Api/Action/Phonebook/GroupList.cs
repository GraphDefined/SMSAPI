using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class PhonebookGroupList : BaseSimple<Response.Groups>
    {

        public PhonebookGroupList(Credentials Client,
                                  HTTPClient  Proxy)

            : base(Client, Proxy)

        { }

        protected override string Uri() { return "phonebook.do"; }

        protected override NameValueCollection Values()
        {
            var collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", Client.Username);
            collection.Add("password", Client.Password);

            collection.Add("list_groups", "");

            return collection;
        }

    }

}
