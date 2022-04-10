using System;
using System.Collections.Specialized;

namespace com.GraphDefined.SMSApi.API.Action
{

    public class PhonebookContactDelete : BaseSimple<Response.Base>
    {

        public PhonebookContactDelete(Credentials Client,
                                      SMSAPIClient Proxy)

            : base(Client, Proxy)

        { }

        protected override String Uri => "phonebook.do";

        protected string number;

        protected override NameValueCollection Values()
        {

            var collection = new NameValueCollection {

                { "format",         "json" },

                { "username",       Credentials.Username },
                { "password",       Credentials.Password },

                { "delete_contact", number }

            };

            return collection;

        }

        public PhonebookContactDelete Number(string number)
        {
            this.number = number;
            return this;
        }

    }

}
