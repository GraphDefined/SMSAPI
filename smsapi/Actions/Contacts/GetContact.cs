using System;

namespace SMSApi.Api.Action
{
    public class GetContact : Rest<Response.Contact>
    {

        public GetContact(Credentials  Client,
                          HTTPClient   Proxy,
                          String  contactId)
            : base(Client, Proxy)
        {
            ContactId = contactId;
        }

        protected override string Resource { get { return "contacts/" + ContactId; } }

        protected override RequestMethods Method { get { return RequestMethods.GET; } }


        public string ContactId { get; }

    }

}
