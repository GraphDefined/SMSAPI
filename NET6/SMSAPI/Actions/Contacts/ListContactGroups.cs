using System;

namespace com.GraphDefined.SMSApi.API.Action
{
    public class ListContactGroups : Rest<Response.Groups>
    {

        public ListContactGroups(Credentials Client,
                                 SMSAPIClient  Proxy,
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
