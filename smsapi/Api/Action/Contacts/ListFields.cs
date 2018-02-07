using System;
using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class ListFields : Rest<Response.Fields>
    {

        public ListFields(Client Client,
                          IProxy Proxy)

            : base(Client, Proxy)

        { }

        protected override string Resource { get { return "contacts/fields"; } }

        protected override RequestMethod Method { get { return RequestMethod.GET; } }

    }

}
