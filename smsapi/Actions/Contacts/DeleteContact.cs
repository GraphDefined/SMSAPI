using System;

namespace com.GraphDefined.SMSApi.API.Action
{
    public class DeleteContact : Rest<Response.Base>
    {

        public DeleteContact(Credentials  Client,
                             SMSAPIClient   Proxy,
                             String  contactId)
            : base(Client, Proxy)
        {
            ContactId = contactId;
        }

        protected override string Resource { get { return "contacts/" + ContactId; } }

        protected override RequestMethods Method { get { return RequestMethods.DELETE; } }

        public String ContactId { get; }

    }

}
