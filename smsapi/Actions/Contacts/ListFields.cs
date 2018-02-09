using System;
using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class ListFields : Rest<Response.Fields>
    {

        public ListFields(Credentials Client,
                          HTTPClient Proxy)

            : base(Client, Proxy)

        { }

        protected override string Resource { get { return "contacts/fields"; } }

        protected override RequestMethods Method { get { return RequestMethods.GET; } }

    }

}
