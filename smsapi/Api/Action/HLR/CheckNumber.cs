using System.Collections.Specialized;

namespace SMSApi.Api.Action
{

    public class HLRCheckNumber : BaseSimple<Response.CheckNumber>
    {

        public HLRCheckNumber(Client Client,
                              IProxy  Proxy)

            : base(Client, Proxy)

        { }

        protected override string Uri() { return "hlrsync.do"; }

        protected string[] numbers;

        public HLRCheckNumber SetNumber(string number)
        {
            this.numbers = new string[] { number };
            return this;
        }

/*
        public HLRCheckNumber SetNumber(string[] numbers)
        {
            this.numbers = numbers;
            return this;
        }
*/

        protected override NameValueCollection Values()
        {
            var collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", Client.Username);
            collection.Add("password", Client.Password);

            collection.Add("number", string.Join(",", numbers));

            return collection;
        }
    }   
}
