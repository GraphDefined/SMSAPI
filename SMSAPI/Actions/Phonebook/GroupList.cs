using System;
using System.Collections.Specialized;

namespace com.GraphDefined.SMSApi.API.Action
{
    public class PhonebookGroupList : BaseSimple<Response.Groups>
    {

        public PhonebookGroupList(Credentials Client,
                                  SMSAPIClient  Proxy)

            : base(Client, Proxy)

        { }

        protected override String Uri => "phonebook.do";

        protected override NameValueCollection Values()
        {
            var collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", Credentials.Username);
            collection.Add("password", Credentials.Password);

            collection.Add("list_groups", "");

            return collection;
        }

    }

}
