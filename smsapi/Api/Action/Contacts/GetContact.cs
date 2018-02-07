using System;

namespace SMSApi.Api.Action
{
    public class GetContact : Rest<Response.Contact>
    {

        public GetContact(Client  Client,
                          IProxy   Proxy,
                          String  contactId)
            : base(Client, Proxy)
        {
            ContactId = contactId;
        }

        protected override string Resource { get { return "contacts/" + ContactId; } }

        protected override RequestMethod Method { get { return RequestMethod.GET; } }


        public string ContactId { get; }

    }

}
