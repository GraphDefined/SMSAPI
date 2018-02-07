using System;

namespace SMSApi.Api.Action
{
    public class DeleteContact : Rest<Response.Base>
    {

        public DeleteContact(Client  Client,
                             IProxy   Proxy,
                             String  contactId)
            : base(Client, Proxy)
        {
            ContactId = contactId;
        }

        protected override string Resource { get { return "contacts/" + ContactId; } }

        protected override RequestMethod Method { get { return RequestMethod.DELETE; } }

        public String ContactId { get; }

    }

}
