using System;

namespace SMSApi.Api.Action
{
    public class ListContactGroups : Rest<Response.Groups>
    {

        public ListContactGroups(Credentials Client,
                                 HTTPClient  Proxy,
                                 String contactId)
            : base(Client, Proxy)
        {
            ContactId = contactId;
        }

        protected override string Resource { get { return "contacts/" + ContactId + "/groups"; } }

        protected override RequestMethods Method { get { return RequestMethods.GET; } }

        public string ContactId { get; }

    }

}
